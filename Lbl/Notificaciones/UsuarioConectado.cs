using System;
using System.Collections.Generic;

namespace Lbl.Notificaciones
{
        public class UsuarioConectado
        {
                public int Id { get; set; }

                public Lbl.Personas.Persona Persona { get; set; }
                public string Estacion { get; set; }
                public string Nombre { get; set; }
                public DateTime Fecha { get; set; }

                public int Estado { get; set; }

                public UsuarioConectado(Lfx.Data.Row fromRow)
                {
                        this.FromRow(fromRow);
                }


                protected void FromRow(Lfx.Data.Row fromRow)
                {
                        this.Id = System.Convert.ToInt32(fromRow["id_usuario"]);

                        int IdUsuario = System.Convert.ToInt32(fromRow["id_usuario"]);
                        if (IdUsuario != 0)
                                this.Persona = new Personas.Persona(Lfx.Workspace.Master.MasterConnection, IdUsuario);

                        this.Nombre = fromRow["nombre"].ToString();
                        this.Estacion = fromRow["estacion"].ToString();
                        this.Estado = System.Convert.ToInt32(fromRow["estado"]);
                        this.Fecha = System.Convert.ToDateTime(fromRow["fecha"]);
                }
        }
}
