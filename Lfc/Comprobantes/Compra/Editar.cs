using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Compra
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                private IDictionary<int, decimal> ArticulosCantidadesOriginales = new Dictionary<int, decimal>();
                //Requiere permisos de comprobantes con articulos 
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Comprobantes.ComprobanteDeCompra);

                        InitializeComponent();

                        List<Lbl.Comprobantes.Tipo> ListaTiposDeCompra = new List<Lbl.Comprobantes.Tipo>();
                        foreach (Lbl.Comprobantes.Tipo Tp in Lbl.Comprobantes.Tipo.TodosPorLetra.Values) {
                                if (Tp.PermiteCompra)
                                        ListaTiposDeCompra.Add(Tp);
                        }
                        EntradaTipo.SetData = Lbl.Comprobantes.Tipo.ToSetData(ListaTiposDeCompra);
                }


                protected override void OnLoad(EventArgs e)
                {
                        base.OnLoad(e);
                        if (Lfx.Workspace.Master != null && Lfx.Workspace.Master.CurrentConfig != null) {
                                EntradaHaciaSituacion.Visible = Lfx.Workspace.Master.CurrentConfig.Productos.StockMultideposito;
                                EtiquetaHaciaSituacion.Visible = Lfx.Workspace.Master.CurrentConfig.Productos.StockMultideposito;
                        }
                }


                public override Lfx.Types.OperationResult ValidarControl()
                {
                        Lfx.Types.OperationResult Res = base.ValidarControl();

                        if (EntradaHaciaSituacion.Visible && EntradaHaciaSituacion.ValueInt == 0) {
                                Res.Success = false;
                                Res.Message += "Por favor seleccione un depósito de destino." + Environment.NewLine;
                        }

                        if (EntradaProveedor.ValueInt == 0) {
                                Res.Success = false;
                                Res.Message += "Por favor seleccione el proveedor." + Environment.NewLine;
                        } else if(this.Elemento.Existe == false) {
                                qGen.Select SelDesde = new qGen.Select("comprob");
                                SelDesde.Columns = new qGen.SqlIdentifierCollection() { "id_comprob" };
                                SelDesde.WhereClause = new qGen.Where();
                                SelDesde.WhereClause.AddWithValue("compra", 1);
                                SelDesde.WhereClause.AddWithValue("anulada", 0);
                                SelDesde.WhereClause.AddWithValue("id_cliente", EntradaProveedor.ValueInt);
                                SelDesde.WhereClause.AddWithValue("tipo_fac", EntradaTipo.TextKey);
                                SelDesde.WhereClause.AddWithValue("pv", EntradaPV.ValueInt);
                                SelDesde.WhereClause.AddWithValue("numero", EntradaNumero.ValueInt);

                                int IdFactura = this.Connection.FieldInt(SelDesde);
                                if (IdFactura > 0) {
                                        Res.Success = false;
                                        Res.Message += "Ya existe un comprobante con ese número. Por favor verifique los datos e intente nuevamente. Si el comprobante cargado anteriormente tiene un error de carga, deberá anularlo antes de cargarlo nuevamente." + Environment.NewLine;
                                }
                        }

                        return Res;
                }


                public override void ActualizarControl()
                {
                        Lbl.Comprobantes.ComprobanteDeCompra Fac = this.Elemento as Lbl.Comprobantes.ComprobanteDeCompra;
                        this.SuspendLayout();

                        this.TipoComprob = Fac.Tipo;

                        EntradaProveedor.Elemento = Fac.Cliente;

                        if (Fac.FormaDePago != null)
                                EntradaFormaPago.ValueInt = Fac.FormaDePago.Id;
                        else
                                EntradaFormaPago.ValueInt = 0;

                        EntradaFormaPago.Enabled = Fac.Tipo.EsFactura;

                        EntradaPV.Text = Fac.PV.ToString("0000");
                        EntradaNumero.Text = Fac.Numero.ToString("00000000");
                        EntradaHaciaSituacion.Elemento = Fac.SituacionDestino;
                        EntradaHaciaSituacion.TemporaryReadOnly = Fac.Existe;
                        EntradaTipo.TextKey = Fac.Tipo.Nomenclatura;
                        EntradaEstado.TextKey = Fac.Estado.ToString();
                        EntradaTotal.ValueDecimal = Fac.Total;
                        EntradaCancelado.ValueDecimal = Fac.ImporteCancelado;
                        EntradaGastosEnvio.ValueDecimal = Fac.GastosDeEnvio;
                        EntradaOtrosGastos.ValueDecimal = Fac.OtrosGastos;
                        EntradaFecha.Text = Lfx.Types.Formatting.FormatDate(Fac.Fecha);
                        EntradaObs.Text = Fac.Obs;

                        EntradaProductos.CargarArticulos(Fac.Articulos);
                        foreach (Lbl.Comprobantes.DetalleArticulo Det in Fac.Articulos) {
                                if (Det.Articulo != null && ArticulosCantidadesOriginales.ContainsKey(Det.Articulo.Id) == false) {
                                        ArticulosCantidadesOriginales.Add(Det.Articulo.Id, Det.Cantidad);
                                }
                        }

                        EntradaProductos.Changed = false;
                        BotonConvertir.Visible = this.Elemento.Existe;

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Comprobantes.ComprobanteDeCompra Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteDeCompra;

                        Comprob.Compra = true;
                        Comprob.Fecha = Lfx.Types.Parsing.ParseDate(EntradaFecha.Text);
                        if (EntradaFormaPago.TextKey != "0")
                                Comprob.FormaDePago = new Lbl.Pagos.FormaDePago(Comprob.Connection, Lfx.Types.Parsing.ParseInt(EntradaFormaPago.TextKey));
                        else
                                Comprob.FormaDePago = null;

                        Comprob.Vendedor = Lbl.Sys.Config.Actual.UsuarioConectado.Persona;
                        Comprob.Cliente = EntradaProveedor.Elemento as Lbl.Personas.Persona;
                        Comprob.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra[EntradaTipo.TextKey];
                        Comprob.PV = EntradaPV.ValueInt;
                        Comprob.Numero = EntradaNumero.ValueInt;
                        Comprob.SituacionDestino = EntradaHaciaSituacion.Elemento as Lbl.Articulos.Situacion;
                        Comprob.GastosDeEnvio = EntradaGastosEnvio.ValueDecimal;
                        Comprob.OtrosGastos = EntradaOtrosGastos.ValueDecimal;
                        Comprob.Obs = EntradaObs.Text;

                        if (EntradaEstado.Enabled && EntradaEstado.Visible)
                                Comprob.Estado = EntradaEstado.ValueInt;
                        else
                                Comprob.Estado = 0;

                        Comprob.Articulos = EntradaProductos.ObtenerArticulos(Comprob);

                        base.ActualizarControl();
                }


                public override bool PuedeEditar()
                {
                        return !this.Elemento.Existe;
                }

                public override bool PuedeImprimir()
                {
                        return false;
                }


                public virtual Lbl.Comprobantes.Tipo TipoComprob
                {
                        get
                        {
                                Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
                                return Comprob.Tipo;
                        }
                        set
                        {
                                Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
                                Comprob.Tipo = value;
                                EntradaTipo.TextKey = Comprob.Tipo.Nomenclatura;

                                switch (Comprob.Tipo.Nomenclatura) {
                                        case "NP":
                                                EntradaEstado.SetData = new string[] {
							"A pedir|50",
							"Pedido|100",
							"Cancelado|200"
						};
                                                EntradaEstado.Visible = true;
                                                EtiquetaEstado.Visible = true;
                                                break;
                                        case "PD":
                                                EntradaEstado.SetData = new string[] {
							"Sin especificar|0",
							"En camino|50",
							"Recibido|100",
							"Cancelado|200"
						};
                                                EntradaEstado.Visible = true;
                                                EtiquetaEstado.Visible = true;
                                                break;
                                        default:
                                                EntradaEstado.SetData = new string[] { "N/A|1" };
                                                EntradaEstado.Visible = false;
                                                EtiquetaEstado.Visible = false;
                                                break;
                                }

                                EtiquetaHaciaSituacion.Visible = Comprob.Tipo.EsFactura;
                                EntradaHaciaSituacion.Visible = Comprob.Tipo.EsFactura;
                        }
                }


                private void BotonObs_Click(object sender, EventArgs e)
                {
                        Lui.Forms.AuxForms.TextEdit FormularioObs = new Lui.Forms.AuxForms.TextEdit();
                        FormularioObs.EditText = EntradaObs.Text;
                        FormularioObs.ReadOnly = this.TemporaryReadOnly;
                        if (FormularioObs.ShowDialog() == DialogResult.OK)
                                EntradaObs.Text = FormularioObs.EditText;
                }


                private void BotonConvertir_Click(object sender, EventArgs e)
                {
                        using (Lfc.Comprobantes.Compra.Crear FormularioConvertir = new Lfc.Comprobantes.Compra.Crear()) {
                                if (FormularioConvertir.ShowDialog() == DialogResult.OK) {
                                        Lbl.Comprobantes.ComprobanteDeCompra Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteDeCompra;
                                        if ((Comprob.Tipo.Nomenclatura == "NP" || Comprob.Tipo.Nomenclatura == "PD") && EntradaEstado.TextKey != "100") {
                                                EntradaEstado.TextKey = "100";
                                                EntradaEstado.Changed = true;
                                        } else if ((Comprob.Tipo.EsPedido || FormularioConvertir.TipoComprob == "F"
                                                || FormularioConvertir.TipoComprob == "FP"
                                                || FormularioConvertir.TipoComprob == "R") && EntradaEstado.TextKey != "100") {
                                                EntradaEstado.TextKey = "100";
                                                EntradaEstado.Changed = true;
                                        }

                                        Lbl.Comprobantes.ComprobanteDeCompra NuevoComprob;
                                        if (FormularioConvertir.TipoComprob == "FP") {
                                                Lbl.Comprobantes.Tipo NuevoTipo = Lbl.Comprobantes.Tipo.TodosPorLetra["FA"];
                                                NuevoComprob = Comprob.Convertir(NuevoTipo);
                                                NuevoComprob.FormaDePago = new Lbl.Pagos.FormaDePago(this.Connection, 3);
                                        } else if (FormularioConvertir.TipoComprob == "RP") {
                                                Lbl.Comprobantes.Tipo NuevoTipo = Lbl.Comprobantes.Tipo.TodosPorLetra["R"];
                                                NuevoComprob = Comprob.Convertir(NuevoTipo);
                                                NuevoComprob.FormaDePago = new Lbl.Pagos.FormaDePago(this.Connection, 3);
                                        } else {
                                                Lbl.Comprobantes.Tipo NuevoTipo = Lbl.Comprobantes.Tipo.TodosPorLetra[FormularioConvertir.TipoComprob];
                                                NuevoComprob = Comprob.Convertir(NuevoTipo);
                                        }

                                        Lfc.FormularioEdicion FormularioEdicion = Lfc.Instanciador.InstanciarFormularioEdicion(NuevoComprob);
                                        FormularioEdicion.MdiParent = this.ParentForm.MdiParent;
                                        FormularioEdicion.Show();
                                }
                        }
                }


                private void RecalcularTotal(System.Object sender, System.EventArgs e)
                {
                        decimal GastosEnvio = Lfx.Types.Parsing.ParseCurrency(EntradaGastosEnvio.Text);
                        decimal OtrosGastos = Lfx.Types.Parsing.ParseCurrency(EntradaOtrosGastos.Text);
                        EntradaTotal.Text = Lfx.Types.Formatting.FormatCurrency(EntradaProductos.Total + GastosEnvio + OtrosGastos, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                }


                private void EntradaNumero_Leave(object sender, EventArgs e)
                {
                        if (EntradaNumero.ValueInt > 0)
                                EntradaNumero.Text = EntradaNumero.ValueInt.ToString("00000000");
                }


                private void EntradaProductos_ObtenerDatosSeguimiento(object sender, EventArgs e)
                {
                        Lcc.Entrada.Articulos.DetalleComprobante Prod = ((Lcc.Entrada.Articulos.DetalleComprobante)(sender));
                        Lbl.Articulos.Articulo Articulo = Prod.Elemento as Lbl.Articulos.Articulo;
                        decimal Cant = Prod.Cantidad;

                        if (Cant != 0) {
                                Lbl.Comprobantes.ComprobanteDeCompra Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteDeCompra;

                                Lfc.Articulos.EditarSeguimiento Editar = new Lfc.Articulos.EditarSeguimiento();
                                Editar.Articulo = Articulo;
                                Editar.Cantidad = Math.Abs(System.Convert.ToInt32(Cant));
                                Editar.SituacionOrigen = Comprob.SituacionOrigen;
                                Editar.DatosSeguimiento = Prod.DatosSeguimiento;
                                if (Editar.ShowDialog() == DialogResult.OK) {
                                        Prod.DatosSeguimiento = Editar.DatosSeguimiento;
                                }
                        }
                }

                private void EntradaTipoPvNumero_TextChanged(object sender, EventArgs e)
                {
                        if (Lbl.Comprobantes.Tipo.TodosPorLetra.ContainsKey(EntradaTipo.TextKey)) {
                                var Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra[EntradaTipo.TextKey];

                                if (Tipo.Existe) {
                                        EntradaFormaPago.Enabled = Tipo.EsFacturaNCoND;
                                        EntradaProductos.DiscriminarIva = Tipo.DiscriminaIva;
                                } else {
                                        EntradaFormaPago.Enabled = false;
                                }

                                if (EntradaNumero.ValueInt > 0)
                                        this.Text = Tipo.ToString() + " " + this.EntradaPV.ValueInt.ToString("0000") + "-" + EntradaNumero.ValueInt.ToString("00000000");
                                else
                                        this.Text = Tipo.ToString() + " " + this.EntradaPV.ValueInt.ToString("0000");

                                if (Tipo.EsNotaCredito)
                                        EtiquetaHaciaSituacion.Text = "Origen";
                                else
                                        EtiquetaHaciaSituacion.Text = "Destino";
                        }
                }


                protected override void OnResize(EventArgs e)
                {
                        if (this.Created)
                                Contenedor.Size = this.ClientSize;

                        base.OnResize(e);
                }


                public override Lazaro.Pres.DisplayStyles.IDisplayStyle HeaderDisplayStyle
                {
                        get
                        {
                                return Lazaro.Pres.DisplayStyles.Template.Current.Comprobantes;
                        }
                }
        }
}
