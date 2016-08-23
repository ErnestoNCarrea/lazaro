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
                public enum ComprobantesTipos
                {
                        FacturaA = 1,
                        NotaDeDebitoA = 2,
                        NotaDeCreditoA = 3,
                        FacturaB = 6,
                        NotaDeDebitoB = 7,
                        NotaDeCreditoB = 8,
                        RecibosA = 4,
                        NotasDeVentaAlContadoA = 5,
                        RecibosB = 9,
                        NotasDeVentaAlContadoB = 10,
                        FacturaE = 19,
                        NotaDeDebitoE = 20,     // sin confirmar
                        NotaDeCreditoE = 21,    // sin confirmar
                        LiquidacionA = 63,
                        LiquidacionB = 64,
                        CbtesADelAnexoIApartadoAIncF_RG1415 = 34,
                        CbtesBDelAnexoIApartadoAIncF_RG1415 = 35,
                        OtrosComprobantesAQueCumplanCon_RG1415 = 39,
                        OtrosComprobantesBQueCumplanCon_RG1415 = 40,
                        CtaDeVtaYLiquidoProdA = 60,
                        CtaDeVtaYLiquidoProdB = 61,
                        FacturaC = 11,
                        NotaDeDebitoC = 12,
                        NotaDeCreditoC = 13,
                        ReciboC = 15,
                        ComprobantedeCompradeBienesUsadosAConsumidorFinal = 49,
                        FacturaM = 51,
                        NotaDeDebitoM = 52,
                        NotaDeCreditoM = 53,
                        ReciboM = 54,
                        Ticket = 83
                }

                public enum Conceptos
                {
                        Producto = 1,
                        Servicios = 2,
                        ProductosYServicios = 3
                }

                public static Dictionary<string, ComprobantesTipos> ComprobantesTiposPorLetra = new Dictionary<string, ComprobantesTipos>()
                {
                        // TODO: pasar esto a Lazaro.{Base|*}

                        { "FA", ComprobantesTipos.FacturaA },
                        { "NDA", ComprobantesTipos.NotaDeCreditoA },
                        { "NCA", ComprobantesTipos.NotaDeCreditoA },

                        { "FB", ComprobantesTipos.FacturaB },
                        { "NDB", ComprobantesTipos.NotaDeDebitoB },
                        { "NCB", ComprobantesTipos.NotaDeCreditoB },

                        { "FC", ComprobantesTipos.FacturaC },
                        { "NCC", ComprobantesTipos.NotaDeCreditoC },
                        { "NDC", ComprobantesTipos.NotaDeDebitoC },

                        { "FE", ComprobantesTipos.FacturaE },

                        { "FM", ComprobantesTipos.FacturaM },
                        { "NCM", ComprobantesTipos.NotaDeCreditoM },
                        { "NDM", ComprobantesTipos.NotaDeDebitoM },

                        { "T", ComprobantesTipos.Ticket }
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