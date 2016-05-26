using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lbl.Archivos.Salida
{
        /// <summary>
        /// Contiene tablas con códigos para exportación de archivos del régimen informativo de compras y ventas de AFIP.
        /// </summary>
        public static class CitiTablas
        {
                public static Dictionary<string, int> ComprobantesTipos = new Dictionary<string, int>()
                {
                        { "FA", 1 },
                        { "NDA", 2 },
                        { "NCA", 3 },

                        { "FB", 6 },
                        { "NDB", 7 },
                        { "NCB", 8 },

                        { "FC", 11 },
                        { "NCC", 12 },
                        { "NDC", 13 },

                        { "FM", 51 },
                        { "NCM", 52 },
                        { "NDM", 53 },

                        { "T", 83 },
                };

                /// <summary>
                /// Alícuotas [ Lázaro, AFIP ]
                /// </summary>
                public static Dictionary<int, int> Alicuotas = new Dictionary<int, int>()
                {
                        { 1, 5 },  // 21%
                        { 2, 4 },  // 10.5%
                        { 3, 6 },  // 27%
                        { 4, 3 },  // 0%
                        { 5, 8 },  // 5%
                        { 6, 9 },  // 2.5%
                };
        }
}