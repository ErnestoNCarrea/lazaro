using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Sys
{
        public partial class Config
        {
                public class Moneda : Configuracion.SeccionConfiguracion
                {
                        public static Lbl.Entidades.Moneda MonedaPredeterminada { get; set; }

                        public static string Simbolo = "$";

                        /// <summary>
                        /// La cantidad de decimales para los precios de venta en general.
                        /// </summary>
                        public static int Decimales = 2;

                        /// <summary>
                        /// La cantidad de decimales para los precios de compra y de costo.
                        /// </summary>
                        public static int DecimalesCosto = 2;

                        /// <summary>
                        /// La cantidad de decimales para el importe final del comprobante.
                        /// </summary>
                        public static int DecimalesFinal = 2;

                        /// <summary>
                        /// La unidad monetaria mínima para el importe final de los comprobantes de venta.
                        /// Esto puede conicidir con el valor de la divisa monetaria más pequeña en circulación, para evitar dar cambio en
                        /// monedas que no existen. Por ejemplo, si la moneda más pequeña es de 5 centavos, este valor podría ser 0.05 para evitar
                        /// dar cambio de 1, 2, 3 y 4 centavos, que es imposible.
                        /// Ejemplos: 
                        ///     UnidadMonetariaMinima = 0        El importe final no se trunca.
                        ///     UnidadMonetariaMinima = 0.05     El importe final se trunca a 5 centavos, o sea algo que cuesta $ 1.18 se factura a $ 1.15.
                        ///     UnidadMonetariaMinima = 1        El importe final se trunca a 1 peso, o sea se eliminan los centavos.
                        /// </summary>
                        public static decimal UnidadMonetariaMinima = 0;
                }
        }
}
