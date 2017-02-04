using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Facturas
{
        public partial class Reimprimir : Lui.Forms.ChildDialogForm
        {
                Dictionary<int, int> ProximosNumeros = new Dictionary<int, int>();

                public Reimprimir()
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.Comprobantes.Factura), Lbl.Sys.Permisos.Operaciones.Imprimir) == false) {
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

                        OkButton.Text = "Reimprimir";
                        OkButton.Visible = false;
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

                        int DesdeReal, HastaReal;
                        if (EntradaOrden.TextKey == "1") {
                                DesdeReal = Hasta;
                                HastaReal = Desde - 1;
                        } else {
                                DesdeReal = Desde;
                                HastaReal = Hasta + 1;
                        }

                        Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("Por favor verifique que impresora tenga " + Cantidad.ToString() + " comprobantes, iniciando con el Nº " + PV.ToString("0000") + "-" + DesdeReal.ToString("00000000"), "¿Está seguro de que desea reimprimir " + Cantidad.ToString() + " comprobantes?");
                        Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;

                        if (Pregunta.ShowDialog() == DialogResult.OK) {
                                System.Threading.ThreadStart ThreadFiltro = delegate { ProcesarReimpresion(EntradaTipo.TextKey, PV, DesdeReal, HastaReal); ; };
                                System.Threading.Thread Thr = new System.Threading.Thread(ThreadFiltro);
                                Thr.IsBackground = true;
                                Thr.Start();

                                ProximosNumeros.Clear();

                                EntradaDesde.Text = "0";
                                EntradaHasta.Text = "0";
                                EntradaDesde.Focus();

                                return new Lfx.Types.CancelOperationResult();
                        } else {
                                return new Lfx.Types.FailureOperationResult("La operación fue cancelada.");
                        }
                }


                private void ProcesarReimpresion(string tipo, int pv, int desde, int hasta)
                {
                        using (var Conn = Lfx.Workspace.Master.GetNewConnection("Reimpresión de comprobantes") as Lfx.Data.Connection)
                        using (System.Data.IDbTransaction Trans = Conn.BeginTransaction()) {
                                int Cantidad = Math.Abs(hasta - desde);
                                Lfx.Types.OperationProgress Progreso = new Lfx.Types.OperationProgress("Reimprimiendo", "Se están reimprimiendo " + Cantidad.ToString() + " comprobantes.");
                                Progreso.Cancelable = true;
                                Progreso.Max = Cantidad;
                                Progreso.Modal = true;
                                Progreso.Advertise = true;
                                Progreso.Begin();

                                string IncluyeTipos = "";

                                switch (tipo) {
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

                                        default:
                                                IncluyeTipos = "'" + EntradaTipo.TextKey + "'";
                                                break;
                                }

                                int Paso = desde < hasta ? 1 : -1;
                                for (int Numero = desde; Numero != hasta; Numero += Paso) {
                                        int IdFactura = Connection.FieldInt("SELECT id_comprob FROM comprob WHERE impresa=1 AND anulada=0 AND compra=0 AND tipo_fac IN (" + IncluyeTipos + ") AND pv=" + pv.ToString() + " AND numero=" + Numero.ToString());

                                        if (IdFactura == 0) {
                                                // No existe, supongo que está anulado, lo salteo
                                        } else {
                                                Lbl.Comprobantes.ComprobanteFacturable Fac = new Lbl.Comprobantes.ComprobanteFacturable(Conn, IdFactura);
                                                Progreso.ChangeStatus("Imprimiendo " + Fac.ToString());

                                                var Controlador = new Lazaro.Base.Controller.ComprobanteController(Trans);
                                                Controlador.Imprimir(Fac, null);
                                        }
                                        Progreso.Advance(1);

                                        if (Progreso.Cancelar)
                                                break;
                                }

                                Progreso.End();
                                Trans.Commit();
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


                private void MostrarVistaPrevia()
                {
                        int PV = EntradaPV.ValueInt;
                        int Desde = EntradaDesde.ValueInt;

                        if ((EntradaHasta.ValueInt == 0 || EntradaHasta.ValueInt < Desde) && this.ActiveControl != EntradaHasta)
                                EntradaHasta.ValueInt = Desde;

                        int Hasta = EntradaHasta.ValueInt;
                        int Cantidad = Hasta - Desde + 1;

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

                                default:
                                        IncluyeTipos = "'" + EntradaTipo.TextKey + "'";
                                        break;
                        }

                        if (ProximosNumeros.ContainsKey(PV) == false)
                                ProximosNumeros[PV] = this.Connection.FieldInt("SELECT MAX(numero) FROM comprob WHERE impresa=1 AND tipo_fac IN (" + IncluyeTipos + ") AND compra = 0 AND pv=" + PV.ToString()) + 1;

                        if (PV <= 0 || Desde <= 0 || Cantidad <= 0) {
                                EtiquetaAviso.Text = "El rango seleccionado no es válido.";
                                ComprobanteVistaPrevia.Visible = false;
                                ListadoFacturas.Visible = false;
                                OkButton.Visible = false;
                                return;
                        }

                        if (Desde > ProximosNumeros[PV] || Hasta > ProximosNumeros[PV]) {
                                EtiquetaAviso.Text = "No se puede reimprimir el rango seleccionado porque todavía no se utilizaron los comprobantes desde el " + ProximosNumeros[PV].ToString() + " al " + (Desde - 1).ToString();
                                ComprobanteVistaPrevia.Visible = false;
                                ListadoFacturas.Visible = false;
                                OkButton.Visible = false;
                                return;
                        }

                        ComprobanteVistaPrevia.Visible = Cantidad == 1;
                        ListadoFacturas.Visible = Cantidad > 1;

                        if (Cantidad == 1) {
                                int IdFactura = this.Connection.FieldInt("SELECT id_comprob FROM comprob WHERE impresa=1 AND compra = 0 AND tipo_fac IN (" + IncluyeTipos + ") AND pv=" + PV.ToString() + " AND numero=" + Desde.ToString());

                                Lbl.Comprobantes.ComprobanteFacturable FacturaInicial = null;
                                if (IdFactura > 0)
                                        FacturaInicial = new Lbl.Comprobantes.ComprobanteFacturable(this.Connection, IdFactura);

                                if (FacturaInicial != null && FacturaInicial.Existe) {
                                        ComprobanteVistaPrevia.Elemento = FacturaInicial;
                                        ComprobanteVistaPrevia.ActualizarControl();
                                        ComprobanteVistaPrevia.TemporaryReadOnly = true;
                                        ComprobanteVistaPrevia.Visible = true;

                                        if (FacturaInicial.Anulado) {
                                                EtiquetaAviso.Text = "El comprobante fue anulado y no puede reimprimirse.";
                                                OkButton.Visible = false;
                                        } else {
                                                EtiquetaAviso.Text = "";
                                                OkButton.Visible = true;
                                        }
                                } else {
                                        ComprobanteVistaPrevia.Visible = false;

                                        EtiquetaAviso.Text = "El comprobante " + EntradaTipo.TextKey + " " + PV.ToString("0000") + "-" + Lfx.Types.Parsing.ParseInt(EntradaDesde.Text).ToString("00000000") + " aun no fue impreso y no puede reimprimirse.";
                                        EntradaOrden.TextKey = "0";
                                        OkButton.Visible = false;
                                }
                        } else if (Cantidad > 1) {
                                System.Data.DataTable TablaFacturas = this.Connection.Select("SELECT * FROM comprob WHERE impresa=1 AND compra = 0 AND anulada=0 AND tipo_fac IN (" + IncluyeTipos + ") AND pv=" + PV.ToString() + " AND numero BETWEEN " + Desde.ToString() + " AND " + Hasta.ToString());
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
                                EtiquetaAviso.Text = "Se van a reimprimir " + Cantidad.ToString() + " comprobantes, incluyendo los que se detallan a continuación.";
                                this.OkButton.Visible = true;
                        } else {
                                EtiquetaAviso.Text = "Debe seleccionar un rango que inlcuya al menos 1 comprobante.";
                                ListadoFacturas.Items.Clear();
                                this.OkButton.Visible = false;
                        }
                }
        }
}