using System;
using System.Collections.Generic;

namespace Lbl.Notificaciones
{
        public interface INotificacion
        {
                int Id { get; }
                string Nombre { get; set; }
                string Destino { get; set; }
                string Obs { get; set; }
                DateTime Fecha { get; }
                int Estado { get; set; }

                Lbl.Personas.Persona Remitente { get; set; }
                Lbl.Personas.Persona Destinatario { get; set; }
                
                string EstacionOrigen { get; set; }
                string EstacionDestino { get; set; }

                NullableDateTime FechaRecibido { get; set; }
        }
}
