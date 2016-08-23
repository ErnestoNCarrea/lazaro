using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afip.Ws.FacturaElectronica
{
        /// <summary>
        /// Una lista conteniendo la descripción de uno o más comprobantes para solicitar un CAE.
        /// </summary>
        public class ColeccionComprobantesAsociados : List<ComprobanteAsociado>
        {
                /// <summary>
                /// Devuelve el número de comprobante más bajo de la colección.
                /// </summary>
                public int NumeroDesde()
                {
                        int Res = 0;
                        foreach(ComprobanteAsociado Comprob in this) {
                                if(Res == 0 || Comprob.Numero < Res) {
                                        Res = Comprob.Numero;
                                }
                        }
                        return Res;
                }

                /// <summary>
                /// Devuelve el número de comprobante más alto de la colección.
                /// </summary>
                public int NumeroHasta()
                {
                        int Res = 0;
                        foreach (ComprobanteAsociado Comprob in this) {
                                if (Comprob.Numero > Res) {
                                        Res = Comprob.Numero;
                                }
                        }
                        return Res;
                }

                /// <summary>
                /// Devuelve la suma de los importes totales de todos los comprobantes.
                /// </summary>
                public double ImporteTotal()
                {
                        double Res = 0;
                        foreach (ComprobanteAsociado Comprob in this) {
                                Res += decimal.ToDouble(Comprob.ImporteTotal());
                        }
                        return Res;
                }

                /// <summary>
                /// Devuelve la combinación de todos los conceptos contenidos en los comprobantes.
                /// </summary>
                public Tablas.Conceptos Conceptos()
                {
                        Tablas.Conceptos Res = 0;
                        foreach (ComprobanteAsociado Comprob in this) {
                                // Ya hay un concepto definido... veo si es necesario agregar otro
                                Res = Res | Comprob.Conceptos;
                        }
                        return Res;
                }
        }
}
