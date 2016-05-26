using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Archivos.Salida
{
        /// <summary>
        /// 
        /// </summary>
        public class CitiVentasAlicuotas: Lbl.Archivos.Salida.ArchivoSalidaConComprobantesFacturables
        {
                protected CitiVentas ArchivoCitiVentas;

                public CitiVentasAlicuotas(CitiVentas archivoCitiVentas)
                        : base()
                {
                        this.ArchivoCitiVentas = archivoCitiVentas;
                        this.Comprobantes = archivoCitiVentas.Comprobantes;
                        this.Progreso = archivoCitiVentas.Progreso;
                }


                public override List<string> FormatearRegistro(int lineNumber, Lbl.Comprobantes.ComprobanteFacturable ComprobanteFacturable)
                {
                        var Res = new List<string>();
                        var Alicuotas = ComprobanteFacturable.AlicuotasUsadas();
                        if (ComprobanteFacturable.Cliente.PagaIva == Impuestos.SituacionIva.Exento) {
                                decimal ImporteIva = 0m;
                                decimal ImporteGravado = ComprobanteFacturable.Total - ImporteIva;

                                string Renglon = "";

                                Renglon += CitiTablas.ComprobantesTipos[ComprobanteFacturable.Tipo.Nomenclatura].ToString().PadLeft(3, '0');  // Tipo de comprobante 1-3
                                Renglon += ComprobanteFacturable.PV.ToString().PadLeft(5, '0');  // Punto de venta 4-8
                                Renglon += ComprobanteFacturable.Numero.ToString().PadLeft(20, '0'); // Numero de comprobante 9-28
                                Renglon += Lfx.Types.Formatting.FormatCurrency(ImporteGravado, 2).Replace(".", "").PadLeft(15, '0'); // Neto Gravado 29-43
                                Renglon += "3".PadLeft(4, '0'); // Codigo de Alicuota 44-47
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
                                        Renglon += Lfx.Types.Formatting.FormatCurrency(ImporteGravado, 2).Replace(".", "").PadLeft(15, '0'); // Neto Gravado 29-43
                                        Renglon += CitiTablas.Alicuotas[Alic.Id].ToString().PadLeft(4, '0'); // Codigo de Alicuota 44-47
                                        Renglon += Lfx.Types.Formatting.FormatCurrency(ImporteIva, 2).Replace(".", "").PadLeft(15, '0'); //Impuesto liquidado 58-62

                                        Res.Add(Renglon);
                                }
                        }

                        return Res;
                }

        }
}