using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Facturas
{
	public partial class Anular : Lui.Forms.ChildDialogForm
	{
                // Caché de próximos números (PV, número)
		protected Dictionary<int, int> ProximosNumeros = new Dictionary<int, int>();

                public bool m_DeCompra = false;

                public bool DeCompra
                {
                        get
                        {
                                return m_DeCompra;
                        }
                        set
                        {
                                m_DeCompra = value;
                        }
                }

                public Anular()
                        :this(null)
                { }


                public Anular(string tipo)
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.Comprobantes.Factura), Lbl.Sys.Permisos.Operaciones.Eliminar) == false) {
                                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                                this.Close();
                                return;
                        }
                        InitializeComponent();

                        // Lleno el listado de tipos de factura
                        List<Lbl.Comprobantes.Tipo> TiposFacturaVenta = new List<Lbl.Comprobantes.Tipo>();
                        foreach (Lbl.Comprobantes.Tipo Tp in Lbl.Comprobantes.Tipo.TodosPorLetra.Values) {
                                if (Tp.EsFacturaOTicket && Tp.PermiteVenta) {
                                        TiposFacturaVenta.Add(Tp);
                                }
                        }
                        string[] ListaFactVenta = new string[TiposFacturaVenta.Count];
                        int i = 0;
                        foreach (Lbl.Comprobantes.Tipo Tp in TiposFacturaVenta) {
                                ListaFactVenta[i++] = Tp.NombreLargo + "|" + Tp.LetraONomenclatura;
                        }

                        this.EntradaTipo.SetData = ListaFactVenta;

                        OkButton.Text = "Anular";
                        OkButton.Visible = false;
                }


                private void MostrarVistaPrevia()
                {
                        int PV = EntradaPV.ValueInt;
                        int Desde = EntradaDesde.ValueInt;

                        if (EntradaHasta.ValueInt < Desde && this.ActiveControl != EntradaHasta)
                                EntradaHasta.ValueInt = Desde;

                        int Hasta = EntradaHasta.ValueInt;
                        int Cantidad = Hasta - Desde + 1;

                        string[] IncluyeTipos;

                        switch (EntradaTipo.TextKey) {
                                case "A":
                                        IncluyeTipos = new string[] { "FA", "NCA", "NDA" };
                                        break;

                                case "B":
                                        IncluyeTipos = new string[] { "FB", "NCB", "NDB" };
                                        break;

                                case "C":
                                        IncluyeTipos = new string[] { "FC", "NCC", "NDC" };
                                        break;

                                case "E":
                                        IncluyeTipos = new string[] { "FE", "NCE", "NDE" };
                                        break;

                                case "M":
                                        IncluyeTipos = new string[] { "FM", "NCM", "NDM" };
                                        break;

                                case "T":
                                        IncluyeTipos = new string[] { "T" };
                                        break;

                                default:
                                        IncluyeTipos = new string[] { EntradaTipo.TextKey };
                                        break;
                        }

                        qGen.Where WhereAnular = new qGen.Where();
                        WhereAnular.AddWithValue("compra", m_DeCompra ? 1 : 0);
                        WhereAnular.AddWithValue("impresa", qGen.ComparisonOperators.NotEqual, 0);
                        WhereAnular.AddWithValue("tipo_fac", qGen.ComparisonOperators.In, IncluyeTipos);
                        WhereAnular.AddWithValue("pv", PV);

                        if (ProximosNumeros.ContainsKey(PV) == false) {
                                qGen.Select SelProxNum = new qGen.Select("comprob");
                                SelProxNum.Columns = new qGen.SqlIdentifierCollection() { "MAX(numero)" };
                                SelProxNum.WhereClause = WhereAnular;
                                ProximosNumeros[PV] = this.Connection.FieldInt(SelProxNum) + 1;
                        }

                        if (PV <= 0 || Desde <= 0 || Cantidad <= 0) {
                                EtiquetaAviso.Text = "El rango seleccionado no es válido.";
                                ComprobanteVistaPrevia.Visible = false;
                                ListadoFacturas.Visible = false;
                                OkButton.Visible = false;
                                return;
                        }

                        if (Desde > ProximosNumeros[PV]) {
                                EtiquetaAviso.Text = "No se puede anular el rango seleccionado porque todavía no se utilizaron los comprobantes desde el " + ProximosNumeros[PV].ToString() + " al " + (Desde - 1).ToString();
                                ComprobanteVistaPrevia.Visible = false;
                                ListadoFacturas.Visible = false;
                                OkButton.Visible = false;
                                return;
                        }

                        ComprobanteVistaPrevia.Visible = Cantidad == 1;
                        ListadoFacturas.Visible = Cantidad > 1;

                        if (Cantidad == 1) {
                                qGen.Select SelDesde = new qGen.Select("comprob");
                                SelDesde.Columns = new qGen.SqlIdentifierCollection() { "id_comprob" };
                                SelDesde.WhereClause = WhereAnular.Clone();
                                SelDesde.WhereClause.AddWithValue("numero", Desde);
                                SelDesde.Order = "anulada";

                                int IdFactura = this.Connection.FieldInt(SelDesde);

                                Lbl.Comprobantes.ComprobanteConArticulos FacturaInicial = null;
                                if (IdFactura > 0)
                                        FacturaInicial = new Lbl.Comprobantes.ComprobanteConArticulos(this.Connection, IdFactura);

                                if (FacturaInicial != null && FacturaInicial.Existe) {
                                        ComprobanteVistaPrevia.Elemento = FacturaInicial;
                                        ComprobanteVistaPrevia.ActualizarControl();
                                        ComprobanteVistaPrevia.TemporaryReadOnly = true;
                                        ComprobanteVistaPrevia.Visible = true;

                                        if (FacturaInicial.Anulado) {
                                                EtiquetaAviso.Text = "El comprobante ya fue anulado y no puede anularse nuevamente.";
                                                OkButton.Visible = false;
                                        } else {
                                                if (this.DeCompra) {
                                                        EtiquetaAviso.Text = "Al anular comprobantes de compra, estos serán excluidos de los listados.";
                                                } else {
                                                        EtiquetaAviso.Text = "Recuerde que necesitar archivar todas las copias del comprobante anulado.";
                                                }
                                                OkButton.Visible = true;
                                                if (FacturaInicial.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.CuentaCorriente) {
                                                        EntradaAnularPagos.TextKey = "1";
                                                } else {
                                                        EntradaAnularPagos.TextKey = "0";
                                                }
                                        }
                                } else {
                                        ComprobanteVistaPrevia.Visible = false;

                                        if (Desde == ProximosNumeros[PV]) {
                                                EtiquetaAviso.Text = "El comprobante " + EntradaTipo.TextKey + " " + PV.ToString("0000") + "-" + Desde.ToString("00000000") + " aun no fue impreso, pero es el próximo en el talonario. Si lo anula, el sistema salteará dicho comprobante.";
                                                EntradaAnularPagos.TextKey = "0";
                                                OkButton.Visible = true;
                                        } else {
                                                EtiquetaAviso.Text = "El comprobante " + EntradaTipo.TextKey + " " + PV.ToString("0000") + "-" + Lfx.Types.Parsing.ParseInt(EntradaDesde.Text).ToString("00000000") + " aun no fue impreso y no puede anularse.";
                                                EntradaAnularPagos.TextKey = "0";
                                                OkButton.Visible = false;
                                        }
                                }
                        } else if (Cantidad > 1) {
                                EntradaAnularPagos.TextKey = "1";

                                qGen.Select SelComprobs = new qGen.Select("comprob");
                                SelComprobs.Columns = qGen.SqlIdentifierCollection.Asterisk;
                                SelComprobs.WhereClause = WhereAnular.Clone();
                                SelComprobs.WhereClause.AddWithValue("numero", Desde, Hasta);

                                System.Data.DataTable TablaFacturas = this.Connection.Select(SelComprobs);
                                Lbl.Comprobantes.ColeccionComprobanteConArticulos Facturas = new Lbl.Comprobantes.ColeccionComprobanteConArticulos(this.Connection, TablaFacturas);
                                ListadoFacturas.BeginUpdate();
                                ListadoFacturas.Items.Clear();
                                foreach (Lbl.Comprobantes.ComprobanteConArticulos Fac in Facturas) {
                                        ListViewItem Itm = ListadoFacturas.Items.Add(Fac.Tipo.ToString());
                                        Itm.SubItems.Add(Fac.PV.ToString("0000") + "-" + Fac.Numero.ToString("00000000"));
                                        Itm.SubItems.Add(Fac.Fecha.ToString(Lfx.Types.Formatting.DateTime.ShortDatePattern));
                                        Itm.SubItems.Add(Fac.Cliente.ToString());
                                        Itm.SubItems.Add(Lfx.Types.Formatting.FormatCurrency(Fac.Total));
                                }
                                ListadoFacturas.EndUpdate();
                                EtiquetaAviso.Text = "Se van a anular " + Cantidad.ToString() + " comprobantes, incluyendo los que se detallan a continuación.";
                                this.OkButton.Visible = true;
                        } else {
                                EtiquetaAviso.Text = "Debe seleccionar un rango que inlcuya al menos 1 comprobante.";
                                ListadoFacturas.Items.Clear();
                                this.OkButton.Visible = false;
                        }
                }


                private void EntradaDesdeTipoPV_TextChanged(object sender, System.EventArgs e)
                {
                        if (sender == EntradaTipo)
                                this.ProximosNumeros.Clear();

                        this.OkButton.Visible = false;
                        TimerRefrescar.Stop();
                        TimerRefrescar.Start();
                }

                public override Lfx.Types.OperationResult Ok()
                {
                        int PV = EntradaPV.ValueInt;
                        int Desde = EntradaDesde.ValueInt;
                        int Hasta = EntradaHasta.ValueInt;
                        int Cantidad = Hasta - Desde + 1;

                        Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("Una vez anulados, los comprobantes deberán ser archivados en todas sus copias y no podrán ser rehabilitados ni reutilizados.", "¿Está seguro de que desea anular " + Cantidad.ToString() + " comprobantes?");
                        Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;

                        if (Pregunta.ShowDialog() == DialogResult.OK) {
                                bool AnularPagos = EntradaAnularPagos.ValueInt != 0;

                                int m_Id = 0;
                                string IncluyeTipos = "";

                                switch (EntradaTipo.TextKey) {
                                        case "A":
                                                IncluyeTipos = "'FA', 'NCA', 'NDA'";
                                                break;

                                        case "B":
                                                IncluyeTipos = "'FB', 'NCB', 'NDB'";
                                                break;

                                        case "C":
                                                IncluyeTipos = "'FC', 'NCC', 'NDC'";
                                                break;

                                        case "E":
                                                IncluyeTipos = "'FE', 'NCE', 'NDE'";
                                                break;

                                        case "M":
                                                IncluyeTipos = "'FM', 'NCM', 'NDM'";
                                                break;

                                        case "T":
                                                IncluyeTipos = "'T'";
                                                break;

                                        default:
                                                IncluyeTipos = "'" + EntradaTipo.TextKey + "'";
                                                break;
                                }

                                Lfx.Types.OperationProgress Progreso = new Lfx.Types.OperationProgress("Anulando comprobantes", "Se están anulando los comprobantes seleccionados.");
                                Progreso.Cancelable = true;
                                Progreso.Max = Cantidad;
                                Progreso.Begin();

                                IDbTransaction Trans = this.Connection.BeginTransaction(IsolationLevel.Serializable);
                                for (int Numero = Desde; Numero <= Hasta; Numero++) {
                                        int IdFactura = Connection.FieldInt("SELECT id_comprob FROM comprob WHERE impresa=1 AND tipo_fac IN (" + IncluyeTipos + ") AND pv=" + PV.ToString() + " AND numero=" + Numero.ToString() + " ORDER BY anulada");

                                        if (IdFactura == 0) {
                                                // Es una factura que todava no existe
                                                // Tengo que crear la factura y anularla
                                                qGen.Insert InsertarComprob = new qGen.Insert("comprob");
                                                InsertarComprob.ColumnValues.AddWithValue("tipo_fac", "F" + EntradaTipo.TextKey);
                                                InsertarComprob.ColumnValues.AddWithValue("id_formapago", 3);
                                                InsertarComprob.ColumnValues.AddWithValue("id_sucursal", Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual);
                                                InsertarComprob.ColumnValues.AddWithValue("pv", Lfx.Types.Parsing.ParseInt(EntradaPV.Text));
                                                InsertarComprob.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                                                InsertarComprob.ColumnValues.AddWithValue("id_vendedor", Lbl.Sys.Config.Actual.UsuarioConectado.Id);
                                                InsertarComprob.ColumnValues.AddWithValue("id_cliente", Lbl.Sys.Config.Actual.UsuarioConectado.Id);
                                                InsertarComprob.ColumnValues.AddWithValue("obs", "Comprobante anulado antes de ser impreso.");
                                                InsertarComprob.ColumnValues.AddWithValue("impresa", 1);
                                                InsertarComprob.ColumnValues.AddWithValue("anulada", 1);
                                                Connection.ExecuteNonQuery(InsertarComprob);
                                                m_Id = Connection.FieldInt("SELECT LAST_INSERT_ID()");
                                                Lbl.Comprobantes.ComprobanteConArticulos NuevoComprob = new Lbl.Comprobantes.ComprobanteConArticulos(this.Connection, m_Id);
                                                new Lbl.Comprobantes.Numerador(NuevoComprob).Numerar(true);
                                        } else {
                                                Lbl.Comprobantes.ComprobanteConArticulos Fac = new Lbl.Comprobantes.ComprobanteConArticulos(Connection, IdFactura);
                                                if (Fac.Anulado == false)
                                                        Fac.Anular(AnularPagos);
                                        }

                                        Progreso.Advance(1);
                                        if (Progreso.Cancelar)
                                                break;
                                }

                                Progreso.End();

                                if (Progreso.Cancelar) {
                                        Trans.Rollback();
                                        Lfx.Workspace.Master.RunTime.Toast("La operación fue cancelada.", "Aviso");
                                } else {
                                        Trans.Commit();
                                        ProximosNumeros.Clear();
                                        if (this.DeCompra) {
                                                Lui.Forms.MessageBox.Show("Se anularon los comprobantes seleccionados. Si fueron anulados por error de carga, ahora puede cargarlos nuevamente.", "Aviso");
                                        } else {
                                                Lui.Forms.MessageBox.Show("Se anularon los comprobantes seleccionados. Recuerde archivar ambas copias.", "Aviso");
                                        }
                                }

                                EntradaDesde.ValueInt = 0;
                                EntradaHasta.ValueInt = 0;
                                EntradaDesde.Focus();

                                return base.Ok(); 
                        } else {
                                return new Lfx.Types.FailureOperationResult("La operación fue cancelada.");
                        }
                }

                private void EntradaHasta_Enter(object sender, EventArgs e)
                {
                        if (EntradaHasta.ValueInt == 0 && EntradaDesde.ValueInt > 0)
                                EntradaHasta.ValueInt = EntradaDesde.ValueInt;
                }

                protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
                {
                        TimerRefrescar.Stop();
                        base.OnClosing(e);
                }

                private void TimerRefrescar_Tick(object sender, EventArgs e)
                {
                        TimerRefrescar.Stop();
                        MostrarVistaPrevia();
                }

                private void EntradaCompra_TextChanged(object sender, EventArgs e)
                {
                        this.DeCompra = EntradaCompra.TextKey == "1";
                        TimerRefrescar.Stop();
                        TimerRefrescar.Start();
                }
        }
}