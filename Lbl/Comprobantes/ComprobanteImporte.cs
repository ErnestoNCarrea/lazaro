using System;
using System.Collections.Generic;

namespace Lbl.Comprobantes
{
        /// <summary>
        /// Describe un comprobante y un importe asociado, que puede ser total o parcial con respecto al importe del comprobante.
        /// Ver ColeccionComprobanteImporte
        /// </summary>
        public class ComprobanteImporte
        {
                public Lbl.Comprobantes.ComprobanteConArticulos Comprobante { get; set; }
                public decimal Importe { get; set; }

                public ComprobanteImporte(Lbl.Comprobantes.ComprobanteConArticulos comprob, decimal importe)
                {
                        this.Comprobante = comprob;
                        this.Importe = importe;
                }
        }
}
