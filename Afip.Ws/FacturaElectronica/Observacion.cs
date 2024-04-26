using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afip.Ws.FacturaElectronica
{
        /// <summary>
        /// Observación, cuando se devuelve un comprobante observador en una solicitud de CAE.
        /// </summary>
        public class Observacion
        {
                /// <summary>
                /// El código de observación.
                /// </summary>
                public int Codigo;

                /// <summary>
                /// El mensaje asociado a la observación.
                /// </summary>
                public string Mensaje;

                /// <summary>
                /// El comprobante al cual está asociada esta observación, o null si no corresponde
                /// </summary>
                public ComprobanteSolicitud Comprobante = null;

                public Observacion()
                {
                }

                public Observacion(int codigo, string mensaje)
                        : this()
                {
                        this.Codigo = codigo;
                        this.Mensaje = mensaje;

                }

                public Observacion(int codigo, string mensaje, ComprobanteSolicitud comprob)
                        : this(codigo, mensaje)
                {
                        this.Codigo = codigo;
                        this.Mensaje = mensaje;
                        this.Comprobante = comprob;
                }
        }
}
