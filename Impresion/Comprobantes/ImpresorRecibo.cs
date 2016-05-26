using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;

namespace Lazaro.Impresion.Comprobantes
{
	public class ImpresorRecibo : ImpresorComprobante
	{
                public ImpresorRecibo(Lbl.ElementoDeDatos elemento, IDbTransaction transaction)
                        : base(elemento, transaction) { }

                public Lbl.Comprobantes.Recibo Recibo
                {
                        get
                        {
                                return this.Elemento as Lbl.Comprobantes.Recibo;
                        }
                }

                public override string ObtenerValorCampo(string nombreCampo, string formato)
                {
                        switch (nombreCampo.ToUpperInvariant()) {
                                case "CLIENTE":
                                case "CLIENTE.NOMBRE":
                                        return this.Comprobante.Cliente.ToString();

                                case "LOCALIDAD":
                                case "LOCALIDAD.NOMBRE":
                                case "CLIENTE.LOCALIDAD":
                                case "CLIENTE.LOCALIDAD.NOMBRE":
                                        if (this.Comprobante.Cliente.Localidad == null)
                                                return "";
                                        else
                                                return this.Comprobante.Cliente.Localidad.ToString();

                                case "DOMICILIO":
                                case "CLIENTE.DOMICILIO":
                                        if (this.Comprobante.Cliente.Domicilio != null && this.Comprobante.Cliente.Domicilio.Length > 0)
                                                return this.Comprobante.Cliente.Domicilio;
                                        else
                                                return this.Comprobante.Cliente.DomicilioLaboral;

                                case "CLIENTE.DOCUMENTO":
                                        if (this.Comprobante.Cliente.ClaveTributaria != null)
                                                return this.Comprobante.Cliente.ClaveTributaria.ToString();
                                        else
                                                return this.Comprobante.Cliente.NumeroDocumento;
                                case "CUIT":
                                case "CLIENTE.CUIT":
                                        if (this.Comprobante.Cliente.ClaveTributaria != null)
                                                return this.Comprobante.Cliente.ClaveTributaria.ToString();
                                        else
                                                return "";

                                case "IVA":
                                case "CLIENTE.IVA":
                                        return this.Comprobante.Cliente.SituacionTributaria.ToString();

                                case "CLIENTE.ID":
                                        return this.Comprobante.Cliente.Id.ToString();

                                case "VENDEDOR":
                                case "VENDEDOR.NOMBRE":
                                        return this.Comprobante.Vendedor.ToString();

                                case "TOTAL":
                                case "COMPROBANTE.TOTAL":
                                        return Lfx.Types.Formatting.FormatCurrencyForPrint(this.Recibo.Total, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal);

				case "SONPESOS":
                                        return Lfx.Types.Formatting.SpellNumber(this.Recibo.Total);

				case "FACTURAS":
                                        if (Recibo.Facturas.Count > 0) {
                                                string Res = null;
                                                foreach (Lbl.Comprobantes.ComprobanteImporte CompImp in Recibo.Facturas) {
                                                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = CompImp.Comprobante;
                                                        if (Res == null)
                                                                Res = Comprob.ToString();
                                                        else
                                                                Res += ", " + Comprob.ToString();
                                                }
                                                return Res;
                                        } else {
                                                return "";
                                        }

                                case "VALORES":
                                        System.Text.StringBuilder Valores = new System.Text.StringBuilder();
                                        foreach (Lbl.Comprobantes.Cobro Pg in Recibo.Cobros) {
                                                switch (Pg.FormaDePago.Tipo) {
                                                        case Lbl.Pagos.TiposFormasDePago.Efectivo:
                                                                Valores.AppendLine("Efectivo                 : " + Lbl.Sys.Config.Moneda.Simbolo + " " + Lfx.Types.Formatting.FormatCurrency(Pg.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales));
                                                                break;
                                                        case Lbl.Pagos.TiposFormasDePago.ChequeTerceros:
                                                        case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                                                                Valores.AppendLine("Cheque                   : " + Lbl.Sys.Config.Moneda.Simbolo + " " + Lfx.Types.Formatting.FormatCurrency(Pg.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales));
                                                                Valores.AppendLine("                           Nº " + Pg.Cheque.Numero + " del banco " + Pg.Cheque.Banco.ToString());
                                                                Valores.AppendLine("                           emitido por " + Pg.Cheque.Emisor);
                                                                Valores.AppendLine("                           el día " + Lfx.Types.Formatting.FormatDate(Pg.Cheque.FechaEmision));
                                                                Valores.AppendLine("                           pagadero el " + Lfx.Types.Formatting.FormatDate(Pg.Cheque.FechaCobro));
                                                                break;
                                                        case Lbl.Pagos.TiposFormasDePago.Tarjeta:
                                                                Valores.AppendLine("Pago con Tarjeta         : " + Lbl.Sys.Config.Moneda.Simbolo + " " + Lfx.Types.Formatting.FormatCurrency(Pg.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales));
                                                                Valores.AppendLine("                           cupón " + Pg.Cupon.ToString());
                                                                break;
                                                        case Lbl.Pagos.TiposFormasDePago.Caja:
                                                                Valores.AppendLine("Ingreso en Cuenta        : " + Lbl.Sys.Config.Moneda.Simbolo + " " + Lfx.Types.Formatting.FormatCurrency(Pg.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales));
                                                                Valores.AppendLine("                           cuenta " + Pg.CajaDestino.ToString());
                                                                break;
                                                        default:
                                                                Valores.AppendLine("Otro Pago                : " + Lbl.Sys.Config.Moneda.Simbolo + " " + Lfx.Types.Formatting.FormatCurrency(Pg.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales));
                                                                Valores.AppendLine("                           " + Pg.ToString());
                                                                break;
                                                }
                                        }
                                        return Valores.ToString();
                                default:
                                        return base.ObtenerValorCampo(nombreCampo, formato);
                        }
                }
	}
}
