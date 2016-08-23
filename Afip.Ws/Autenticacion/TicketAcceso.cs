using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afip.Ws.Autenticacion
{
        /// <summary>
        /// Un ticket de acceso (TA) recibido del WSAA.
        /// </summary>
        public class TicketAcceso
        {
                // Momento en que fue generado el requerimiento 
                public DateTime GenerationTime;

                // Momento en el que exoira la solicitud 
                public DateTime ExpirationTime;

                // Firma de seguridad recibida en la respuesta 
                public string Sign;

                // Token de seguridad recibido en la respuesta 
                public string Token;

                /// <summary>
                /// Devuelve True si este ticket de acceso todavía es válido.
                /// </summary>
                public bool EsValido()
                {
                        return this.ExpirationTime > System.DateTime.Now;
                }
        }
}
