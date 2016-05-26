using System;
using System.Collections.Generic;

namespace Lbl.Notificaciones
{
        public class NotificacionMemoria : INotificacion
        {
                public int Id { get; set; }
                public string Nombre { get; set; }
                public string Destino { get; set; }
                public string Obs { get; set; }
                public DateTime Fecha { get; set; }
                public int Estado { get; set; }

                public Lbl.Personas.Persona Remitente { get; set; }
                public Lbl.Personas.Persona Destinatario { get; set; }

                public string EstacionOrigen { get; set; }
                public string EstacionDestino { get; set; }

                public NullableDateTime FechaRecibido { get; set; }

                public NotificacionMemoria()
                {
                        this.Remitente = Lbl.Sys.Config.Actual.UsuarioConectado.Persona;
                        this.EstacionOrigen = Lfx.Environment.SystemInformation.MachineName;
                        this.Fecha = System.DateTime.Now;
                }


                public NotificacionMemoria(Lbl.Personas.Persona destinatario, string estacionDestino)
                        : this()
                {
                        this.Destinatario = destinatario;
                        this.EstacionDestino = estacionDestino;
                }
        }
}
