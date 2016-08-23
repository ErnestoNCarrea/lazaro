using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afip.Ws.FacturaElectronica
{
        /// <summary>
        /// El importe contabilizado de una alícuota en un comprobante. Un comprobante puede contener
        /// uno o más importes, dependiendo de las alícuotas de los artículos contenidos en el comprobante.
        /// </summary>
        public class ImporteAlicuota
        {
                /// <summary>
                /// La alícuota de IVA.
                /// </summary>
                public Tablas.Alicuotas Alicuota { get; set; }

                /// <summary>
                /// El importe gravado para esta alícuota.
                /// </summary>
                public decimal BaseImponible { get; set; }

                /// <summary>
                /// El importe contabilizado a tributar para esta alícuota.
                /// </summary>
                public decimal Importe { get; set; }
        }
}
