using System;
using System.Collections.Generic;

namespace Lbl.Notificaciones
{
        /// <summary>
        /// Representa una notificación que se puede recibir local o remotamente.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Notificación")]
        [Lbl.Atributos.Datos(TablaDatos = "sys_messages", CampoId = "id_message")]
        [Lbl.Atributos.Presentacion()]
        public class NotificacionRegistro : ElementoDeDatos, INotificacion
        {
                //Heredar constructor
                public NotificacionRegistro(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public NotificacionRegistro(Lfx.Data.IConnection dataBase, int itemId)
                        : base(dataBase, itemId) { }

                public NotificacionRegistro(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public Lbl.Personas.Persona Remitente
                {
                        get
                        {
                                return this.GetFieldValue<Lbl.Personas.Persona>("id_remitente");
                        }
                        set
                        {
                                this.SetFieldValue("id_remitente", value);
                        }
                }


                public Lbl.Personas.Persona Destinatario
                {
                        get
                        {
                                return this.GetFieldValue<Lbl.Personas.Persona>("id_destinatario");
                        }
                        set
                        {
                                this.SetFieldValue("id_destinatario", value);
                        }
                }


                public string EstacionOrigen
                {
                        get
                        {
                                return this.GetFieldValue<string>("estacion_envia");
                        }
                        set
                        {
                                this.SetFieldValue("estacion_envia", value);
                        }
                }


                public string EstacionDestino
                {
                        get
                        {
                                return this.GetFieldValue<string>("estacion_recibe");
                        }
                        set
                        {
                                this.SetFieldValue("estacion_recibe", value);
                        }
                }


                public string Destino
                {
                        get
                        {
                                return this.GetFieldValue<string>("destino");
                        }
                        set
                        {
                                this.SetFieldValue("destino", value);
                        }
                }


                public NullableDateTime FechaRecibido
                {
                        get
                        {
                                return this.GetFieldValue<NullableDateTime>("fecha_recibo");
                        }
                        set
                        {
                                this.SetFieldValue("fecha_recibo", value);
                        }
                }
        }
}
