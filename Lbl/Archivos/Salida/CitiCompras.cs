using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Archivos.Salida
{
        /// <summary>
        /// Generador de archivos de Banco Comafi
        /// </summary>
        public class CitiCompras : ArchivoSalidaVentas
        {
                protected string TipoDeRegistro = "1";

                public CitiCompras()
                        : base()
                { }

                public CitiCompras(Lfx.Types.OperationProgress progreso)
                        : base(progreso)
                { }

                public override List<string> FormatearRegistro(int lineNumber, Lbl.Comprobantes.ComprobanteFacturable ComprobanteFacturable)
                {
                        string Renglon = "";
                        //Formato CITI COMPRAS
                        Renglon += ComprobanteFacturable.Fecha.ToString("yyyyMMdd");  // Fecha del comprobante 1-8
                        Renglon += ((int)(CitiTablas.ComprobantesTiposPorLetra[ComprobanteFacturable.Tipo.Nomenclatura])).ToString().PadLeft(3, '0');  // Tipo de comprobante 9-11
                        Renglon += ComprobanteFacturable.PV.ToString().PadLeft(5, '0');  // Punto de venta 12-16
                        Renglon += ComprobanteFacturable.Numero.ToString().PadLeft(20, '0');  // Numero de comrpbante 17-36
                        Renglon += "".PadRight(16, ' ');  // Numero de despacho de importacion  37-52
                        Renglon += "80";  // 80:CUIT Codigo de documento del vendedor 53-54                        
                        Renglon += ComprobanteFacturable.Cliente.Cuit.ToString().Replace("-", "").Replace(" ", "").Replace("/", "").Replace(".", "").PadLeft(20, '0');  // Numero de identificacion del vendedor 64-74
                        Renglon += ComprobanteFacturable.Cliente.RazonSocial.ToString().PadRight(30, ' ').Substring(0, 30).ToUpper();  //Apellido y nombre o Denominacion del vendedor 75-104
                        Renglon += Lfx.Types.Formatting.FormatCurrency(ComprobanteFacturable.Total, 2).ToString().Replace(".", "").PadLeft(15, '0');  // Importe Total de la operacion 105-119
                        Renglon += "".PadLeft(15, '0');  // Conceptos que no integran el precio neto gravado 120-134
                        Renglon += "".PadLeft(15, '0');  // Importes de operaciones extras 135-149
                        Renglon += "".PadLeft(15, '0');  // Percepciones o pagos a cuenta del IVA 150-164
                        Renglon += "".PadLeft(15, '0');  // Percepciones o pagos a cuenta de otros imp nacionales 165-179
                        Renglon += "".PadLeft(15, '0');  // Percepciones de ingresos brutos 180-194
                        Renglon += "".PadLeft(15, '0');  // Percepciones de impuestos municipales 195-209
                        Renglon += "".PadLeft(15, '0');  // Impuestos internos 210-224
                        Renglon += "PES";  // Codigo de moneda 225-227
                        Renglon += "000100";  // Tipo de cambio 228-233
                        if (ComprobanteFacturable.DiscriminaIva) {
                                Renglon += ComprobanteFacturable.AlicuotasUsadas().Count.ToString().PadLeft(5, '0'); // Cantidad de alicuotas de IVA 234-238
                        } else {
                                Renglon += "".PadLeft(5, '0'); // Cantidad de alicuotas de IVA 234-238
                        }
                        if (ComprobanteFacturable.Cliente.ObtenerSituacionIva() == Impuestos.SituacionIva.Exento) {
                                Renglon += "N";
                        } else {

                                Renglon += "0";        // Codigo de operacion 239
                        }
                        Renglon += "".PadLeft(15, '0');  // IVA Liquidado o Credito fiscal computable 240-254
                        Renglon += "".PadLeft(15, '0'); // Otros Tributos 255-269
                        Renglon += "".PadLeft(11, '0'); // CUIT emisor/corredor 270-280
                        Renglon += "".PadRight(30, ' '); // Denominación del emisor/corredor 281-310
                        Renglon += "".PadLeft(15, '0'); // IVA comisión 311-325


                        return new List<string>() { Renglon };
                }


        }
}