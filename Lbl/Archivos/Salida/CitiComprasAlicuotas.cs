using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Archivos.Salida
{
        /// <summary>
        /// 
        /// </summary>
        public class CitiComprasAlicuotas: Lbl.Archivos.Salida.ArchivoSalidaConComprobantesFacturables
        {
                protected CitiCompras ArchivoCitiCompras;

                public CitiComprasAlicuotas(CitiCompras archivoCitiCompras)
                        : base()
                {
                        this.ArchivoCitiCompras = archivoCitiCompras;
                        this.Comprobantes = archivoCitiCompras.Comprobantes;
                        this.Progreso = archivoCitiCompras.Progreso;
                }


                public override List<string> FormatearRegistro(int lineNumber, Lbl.Comprobantes.ComprobanteFacturable ComprobanteFacturable)
                {
                        var Res = new List<string>();
                        var Alicuotas = ComprobanteFacturable.AlicuotasUsadas();
                        if (ComprobanteFacturable.Cliente.PagaIva == Impuestos.SituacionIva.Exento) {
                                decimal ImporteIva = 0m;
                                decimal ImporteGravado = ComprobanteFacturable.Total - ImporteIva;
                                string Renglon = CitiTablas.ComprobantesTipos[ComprobanteFacturable.Tipo.Nomenclatura].ToString().PadLeft(3, '0');  // Tipo de comprobante 1-3
                                Renglon += ComprobanteFacturable.PV.ToString().PadLeft(5, '0');  // Punto de venta 4-8
                                Renglon += ComprobanteFacturable.Numero.ToString().PadLeft(20, '0'); // Numero de comprobante 9-28
                                Renglon += "80";  // 80:CUIT Codigo de documento del vendedor  29-30
                                Renglon += "".PadLeft(9, '0');  // Imoprte del Comprobante sin iva 31-39
                                Renglon += ComprobanteFacturable.Cliente.Cuit.ToString().Replace("-", "").Replace(" ", "").Replace("/", "").Replace(".", "");  // Numero de identificacion del vendedor 40-50
                                Renglon += Lfx.Types.Formatting.FormatCurrency(ImporteGravado, 2).Replace(".", "").PadLeft(15, '0'); // Neto Gravado 51-65
                                Renglon += "3".PadLeft(4, '0'); // Codigo de Alicuota 66-69
                                Renglon += Lfx.Types.Formatting.FormatCurrency(ImporteIva, 2).Replace(".", "").PadLeft(15, '0'); //Impuesto liquidado 58-62

                                Res.Add(Renglon);
                        } else {
                                foreach (Lbl.Impuestos.Alicuota Alic in Alicuotas.Values) {
                                        decimal ImporteIva = ComprobanteFacturable.TotalIvaAlicuota(Alic.Id);
                                        decimal ImporteGravado = ComprobanteFacturable.TotalConIvaAlicuota(Alic.Id) - ImporteIva;
                                        string Renglon = "";

                                        Renglon += CitiTablas.ComprobantesTipos[ComprobanteFacturable.Tipo.Nomenclatura].ToString().PadLeft(3, '0');  // Tipo de comprobante 1-3
                                        Renglon += ComprobanteFacturable.PV.ToString().PadLeft(5, '0');  // Punto de venta 4-8
                                        Renglon += ComprobanteFacturable.Numero.ToString().PadLeft(20, '0'); // Numero de comprobante 9-28
                                        Renglon += "80";  // 80:CUIT Codigo de documento del vendedor  29-30
                                        Renglon += "".PadLeft(9, '0');  // Imoprte del Comprobante sin iva 31-39
                                        Renglon += ComprobanteFacturable.Cliente.Cuit.ToString().Replace("-", "").Replace(" ", "").Replace("/", "").Replace(".", "");  // Numero de identificacion del vendedor 40-50
                                        Renglon += Lfx.Types.Formatting.FormatCurrency(ImporteGravado, 2).Replace(".", "").PadLeft(15, '0'); // Neto Gravado 51-65
                                        Renglon += CitiTablas.Alicuotas[Alic.Id].ToString().PadLeft(4, '0'); // Codigo de Alicuota 66-69
                                        Renglon += Lfx.Types.Formatting.FormatCurrency(ImporteIva, 2).Replace(".", "").PadLeft(15, '0'); //Impuesto liquidado 58-62

                                        Res.Add(Renglon);
                                }
                        }

                        return Res;
                }

        }
}