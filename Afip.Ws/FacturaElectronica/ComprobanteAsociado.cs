using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Afip.Ws.FacturaElectronica.Tablas;

namespace Afip.Ws.FacturaElectronica
{
        /// <summary>
        /// Representa un comprobante asociado a otro comprobante (para una solicitud de CAE).
        /// </summary>
        public class ComprobanteAsociado
        {
                /// <summary>
                /// El tipo de comprobante.
                /// </summary>
                public ComprobantesTipos Tipo { get; set; }

                /// <summary>
                /// El punto de venta del comprobante.
                /// </summary>
                public int PuntoDeVenta { get; set; }

                /// <summary>
                /// El número de comprobante.
                /// </summary>
                public int Numero { get; set; }

                /// <summary>
                /// El CUIT del cliente.
                /// </summary>
                public string Cuit{ get; set; }

                /// <summary>
                /// La fecha del comprobante asociado.
                /// </summary>
                public DateTime Fecha { get; set; }
        }
}
