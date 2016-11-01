using System;
using System.Data;

namespace Lfc.Cajas
{
        public partial class Movimiento : Lui.Forms.DialogForm
        {
                protected Lbl.Entidades.Moneda MonedaOrigen, MonedaDestino;
                protected Lbl.Cajas.Caja CajaOrigen, CajaDestino;

                public Movimiento()
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.Cajas.Caja), Lbl.Sys.Permisos.Operaciones.Mover) == false) {
                                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                                this.Close();
                                return;
                        }

                        InitializeComponent();
                }


                public override Lfx.Types.OperationResult Ok()
                {
                        Lfx.Types.OperationResult aceptarReturn = new Lfx.Types.SuccessOperationResult();

                        if (CajaOrigen == null) {
                                aceptarReturn.Success = false;
                                aceptarReturn.Message += "Debe especificar la Caja de Origen." + Environment.NewLine;
                        }
                        if (CajaDestino == null) {
                                aceptarReturn.Success = false;
                                aceptarReturn.Message += "Debe especificar la Caja de Destino." + Environment.NewLine;
                        }
                        if (EntradaImporte.ValueDecimal <= 0) {
                                aceptarReturn.Success = false;
                                aceptarReturn.Message += "Debe especificar el importe." + Environment.NewLine;
                        }
                        if (EntradaConcepto.ValueInt == 0) {
                                aceptarReturn.Success = false;
                                aceptarReturn.Message += "Debe especificar el Concepto." + Environment.NewLine;
                        }

                        if (aceptarReturn.Success == true) {
                                decimal Importe = EntradaImporte.ValueDecimal;
                                CajaOrigen.Connection = this.Connection;
                                CajaDestino.Connection = this.Connection;
                                IDbTransaction Trans = this.Connection.BeginTransaction(IsolationLevel.Serializable);
                                CajaOrigen.Movimiento(false, EntradaConcepto.Elemento as Lbl.Cajas.Concepto,
                                        EntradaConcepto.TextDetail,
                                        Lbl.Sys.Config.Actual.UsuarioConectado.Persona,
                                        -Importe,
                                        EntradaObs.Text, null, null, EntradaComprob.Text);
                                if (EntradaImporteDestino.Visible)
                                        Importe = EntradaImporteDestino.ValueDecimal;
                                CajaDestino.Movimiento(false,
                                        EntradaConcepto.Elemento as Lbl.Cajas.Concepto,
                                        EntradaConcepto.TextDetail,
                                        Lbl.Sys.Config.Actual.UsuarioConectado.Persona,
                                        Importe,
                                        EntradaObs.Text, null, null, EntradaComprob.Text);
                                Trans.Commit();
                        }
                        return aceptarReturn;
                }


                private void EntradaObs_Enter(object sender, System.EventArgs e)
                {
                        if (EntradaObs.Text.Length == 0 && CajaOrigen != null && CajaDestino != null && CajaOrigen.Id != CajaDestino.Id) {
                                EntradaObs.Text = "Movimiento entre " + CajaOrigen.ToString() + " y " + CajaDestino.ToString();
                        }
                }


                private void EntradaOrigenDestino_TextChanged(object sender, System.EventArgs e)
                {
                        CajaOrigen = EntradaOrigen.Elemento as Lbl.Cajas.Caja;
                        CajaDestino = EntradaDestino.Elemento as Lbl.Cajas.Caja;
                        if (CajaOrigen == null || CajaDestino == null)
                                return;

                        MonedaOrigen = CajaOrigen.ObtenerMoneda();
                        MonedaDestino = CajaDestino.ObtenerMoneda();

                        if (MonedaOrigen != null && MonedaDestino != null) {
                                EntradaImporte.Prefijo = MonedaOrigen.Simbolo;
                                EntradaImporteDestino.Prefijo = MonedaDestino.Simbolo;
                                if (MonedaDestino.Cotizacion != MonedaOrigen.Cotizacion) {
                                        EntradaImporteDestino.ValueDecimal = EntradaImporte.ValueDecimal * MonedaDestino.Cotizacion / MonedaOrigen.Cotizacion;
                                        EntradaImporteDestino.Visible = true;
                                        EtiquetaImporteDestino.Visible = true;
                                        // TODO: EntradaImporteDestino.ShowBalloon("Se realiza una conversión de moneda según la cotización " + System.Convert.ToString(MonedaOrigen["signo"]) + " " + Lfx.Types.Formatting.FormatCurrency(System.Convert.ToDecimal(MonedaOrigen["cotizacion"]), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales) + " = " + System.Convert.ToString(MonedaDestino["signo"]) + " " + Lfx.Types.Formatting.FormatCurrency(System.Convert.ToDecimal(MonedaDestino["cotizacion"]), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales));
                                } else {
                                        EntradaImporteDestino.Visible = false;
                                        EtiquetaImporteDestino.Visible = false;
                                }
                        } else {
                                EntradaImporteDestino.Visible = false;
                                EtiquetaImporteDestino.Visible = false;
                        }
                }


                private void EntradaImporte_TextChanged(object sender, System.EventArgs e)
                {
                        if (MonedaOrigen != null && MonedaDestino != null && MonedaOrigen.Cotizacion != MonedaDestino.Cotizacion)
                                EntradaImporteDestino.ValueDecimal = EntradaImporte.ValueDecimal * MonedaDestino.Cotizacion / MonedaOrigen.Cotizacion;
                }
        }
}
