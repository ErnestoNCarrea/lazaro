using Lazaro.Orm;
using Lazaro.Orm.Attributes;
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


                /// <summary>
                /// Obtiene o establece el nombre del elemento.
                /// </summary>
                [Column(Name = "nombre", Type = ColumnTypes.VarChar, Length = 200, Nullable = false)]
                public virtual string Nombre
                {
                        get
                        {
                                return this.GetFieldValue<string>(CampoNombre);
                        }
                        set
                        {
                                this.Registro[CampoNombre] = value;
                        }
                }


                /// <summary>
                /// Obtiene o establece un texto que representa las observaciones del elemento.
                /// </summary>
                [Column(Name = "obs")]
                public string Obs
                {
                        get
                        {
                                if (this.Registro["obs"] == null || this.Registro["obs"] == DBNull.Value)
                                        return null;
                                else
                                        return this.Registro["obs"].ToString();
                        }
                        set
                        {
                                this.Registro["obs"] = value.Trim(new char[] { '\n', '\r', ' ' });
                        }
                }


                [Column(Name = "fecha")]
                public DateTime Fecha
                {
                        get
                        {
                                return this.GetFieldValue<DateTime>("fecha");
                        }
                }


                /// <summary>
                /// Devuelve o establece el estado del elemento. El valor de esta propiedad tiene diferentes significados para cada clase derivada.
                /// </summary>
                [Column(Name = "estado")]
                public int Estado
                {
                        get
                        {
                                return this.GetFieldValue<int>("estado");
                        }
                        set
                        {
                                this.Registro["estado"] = value;
                        }
                }


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


                public DbDateTime FechaRecibido
                {
                        get
                        {
                                return this.GetFieldValue<DbDateTime>("fecha_recibo");
                        }
                        set
                        {
                                this.SetFieldValue("fecha_recibo", value);
                        }
                }
        }
}
