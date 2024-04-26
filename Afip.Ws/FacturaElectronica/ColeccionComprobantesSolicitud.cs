using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afip.Ws.FacturaElectronica
{
        /// <summary>
        /// Una lista conteniendo uno o más comprobantes para solicitar un CAE.
        /// </summary>
        public class ColeccionComprobantesSolicitud : List<ComprobanteSolicitud>
        {
                /// <summary>
                /// Devuelve el número de comprobante más bajo de la colección.
                /// </summary>
                public int NumeroDesde()
                {
                        var Res = 0;
                        foreach (ComprobanteSolicitud Comprob in this) {
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
                        var Res = 0;
                        foreach (ComprobanteSolicitud Comprob in this) {
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
                        foreach (ComprobanteSolicitud Comprob in this) {
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
                        foreach (ComprobanteSolicitud Comprob in this) {
                                // Ya hay un concepto definido... veo si es necesario agregar otro
                                Res = Res | Comprob.Conceptos;
                        }
                        return Res;
                }
        }
}
