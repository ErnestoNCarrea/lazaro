using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afip.Ws.FacturaElectronica
{
        /// <summary>
        /// Representa una solicitud de CAE para uno o más comprobantes.
        /// </summary>
        public class SolicitudCae
        {
                /// <summary>
                /// El tipo de el o los comprobantes para por los cuales se solicita un CAE. Todos los
                /// comprobantes deben ser del mismo tipo.
                /// </summary>
                public Tablas.ComprobantesTipos TipoComprobante { get; set; }

                /// <summary>
                /// El punto de venta para todos los comprobantes de esta solicitud.
                /// </summary>
                public int PuntoDeVenta { get; set; }

                /// <summary>
                /// Los comprobantes para los cuales se solicita un CAE.
                /// </summary>
                public ColeccionComprobantesSolicitud Comprobantes { get; set; }

                /// <summary>
                /// Las observaciones devueltas, en caso de devolver comprobantes observados.
                /// </summary>
                public List<Observacion> Observaciones { get; set; }
        }
}
