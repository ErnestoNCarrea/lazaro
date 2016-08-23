using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Archivos.Salida
{
        /// <summary>
        /// Generador de archivos de Banco Comafi
        /// </summary>
        public class CitiVentas : ArchivoSalidaVentas
        {
                protected string TipoDeRegistro = "1";

                public CitiVentas()
                        : base() { }

                public CitiVentas(Lfx.Types.OperationProgress progreso)
                        : base(progreso) { }

                public override List<string> FormatearRegistro(int lineNumber, Lbl.Comprobantes.ComprobanteFacturable ComprobanteFacturable)
                {
                        string Renglon = "";
                        //Formato CITI Ventas

                        Renglon += ComprobanteFacturable.Fecha.ToString("yyyyMMdd");  // Fecha del comprobante 
                        Renglon += ((int)(CitiTablas.ComprobantesTiposPorLetra[ComprobanteFacturable.Tipo.Nomenclatura])).ToString().PadLeft(3, '0');  // Tipo de comprobante
                        Renglon += ComprobanteFacturable.PV.ToString().PadLeft(5, '0');  // Punto de venta 
                        Renglon += ComprobanteFacturable.Numero.ToString().PadLeft(20, '0');   // Numero de comrpbante
                        Renglon += ComprobanteFacturable.Numero.ToString().PadLeft(20, '0');   // Numero de comrpbante hasta
                        if (ComprobanteFacturable.Cliente.SituacionTributaria == null || ComprobanteFacturable.Cliente.SituacionTributaria.EsConsumidorFinal) {
                                if (string.IsNullOrEmpty(ComprobanteFacturable.Cliente.NumeroDocumento)) {
                                        Renglon += "99";  // 99: Sin identificar
                                        Renglon += ComprobanteFacturable.Cliente.NumeroDocumento.ToString().PadLeft(20, '0');  // Nº de identificación del comprador
                                } else {
                                        Renglon += "96";  // 96: DNI
                                        Renglon += ComprobanteFacturable.Cliente.NumeroDocumento.ToString().PadLeft(20, '0');  // Nº de identificación del comprador
                                }
                                Renglon += ComprobanteFacturable.Cliente.ToString().PadRight(30, ' ').Substring(0, 30).ToUpper();  //Apellido y nombre o Denominacion del comprador
                        } else {
                                Renglon += "80";  // 80: CUIT
                                Renglon += ComprobanteFacturable.Cliente.Cuit.ToString().Replace("-", "").Replace(" ", "").Replace("/", "").Replace(".", "").PadLeft(20, '0');   // Nº de identificación del comprador
                                Renglon += ComprobanteFacturable.Cliente.RazonSocial.ToString().PadRight(30, ' ').Substring(0, 30).ToUpper();   //Apellido y nombre o Denominacion del vendedor
                        }
                        Renglon += Lfx.Types.Formatting.FormatCurrency(ComprobanteFacturable.Total, 2).ToString().Replace(".", "").PadLeft(15, '0'); // Importe Total de la operacion
                        Renglon += "".PadLeft(15, '0');  // Conceptos que no integran el precio neto gravado
                        Renglon += "".PadLeft(15, '0');  // Percepcion a No Categorizados
                        Renglon += "".PadLeft(15, '0');  // Importe Operaciones Exentas
                        Renglon += "".PadLeft(15, '0');  // Percepciones o pagos a cuenta de otros imp nacionales
                        Renglon += "".PadLeft(15, '0');  // Percepciones de ingresos brutos 
                        Renglon += "".PadLeft(15, '0');  // Percepciones de impuestos municipales 
                        Renglon += "".PadLeft(15, '0');  // Impuestos internos 
                        Renglon += "PES";  // Codigo de moneda 
                        Renglon += "000100";  // Tipo de cambio 
                        Renglon += ComprobanteFacturable.AlicuotasUsadas().Count.ToString().PadLeft(5, '0');   // Cantidad de alicuotas de IVA 
                        if (ComprobanteFacturable.Cliente.PagaIva == Impuestos.SituacionIva.Exento) {
                                Renglon += "N";
                        } else {
                                Renglon += "0";        // Codigo de operacion
                        }

                        Renglon += "".PadLeft(15, '0');  // Otros Tributos
                        Renglon += ComprobanteFacturable.Fecha.ToString("yyyyMMdd");  // Fecha de Vencimiento 
                        return new List<string>() { Renglon };
                }

        }
}