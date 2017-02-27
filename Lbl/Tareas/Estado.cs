using Lazaro.Orm;
using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Tareas
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Estado", Grupo = "Tareas")]
        [Lbl.Atributos.Datos(TablaDatos = "tickets_estados", CampoId = "id_ticket_estado")]
        [Lbl.Atributos.Presentacion()]
        public class EstadoTarea : Lbl.ElementoDeDatos
        {
                public EstadoTarea(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public EstadoTarea(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public EstadoTarea(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                /// <summary>
                /// Obtiene o establece el nombre del elemento.
                /// </summary>
                [Column(Name = "nombre", Type = ColumnTypes.VarChar, Length = 200, Nullable = false)]
                public string Nombre
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


                public override void Crear()
                {
                        base.Crear();
                        this.Estado = 1;
                }


                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.IStatement Comando;

                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.TablaDatos);
                        } else {
                                Comando = new qGen.Update(this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.ColumnValues.AddWithValue("nombre", this.Nombre);
                        Comando.ColumnValues.AddWithValue("obs", this.Obs);
                        Comando.ColumnValues.AddWithValue("estado", this.Estado);

                        this.AgregarTags(Comando);

                        this.Connection.ExecuteNonQuery(Comando);

                        return base.Guardar();
                }


                private static Dictionary<int, EstadoTarea> m_TodosPorNumero = null;
                public static Dictionary<int, EstadoTarea> TodosPorNumero
                {
                        get
                        {
                                if (m_TodosPorNumero == null) {
                                        m_TodosPorNumero = new Dictionary<int, EstadoTarea>();
                                        System.Data.DataTable Tabla = Lfx.Workspace.Master.MasterConnection.Select("SELECT * FROM tickets_estados");
                                        foreach (System.Data.DataRow Reg in Tabla.Rows) {
                                                m_TodosPorNumero.Add(System.Convert.ToInt32(Reg["id_ticket_estado"]), new Lbl.Tareas.EstadoTarea(Lfx.Workspace.Master.MasterConnection, (Lfx.Data.Row)Reg));
                                        }
                                }
                                return m_TodosPorNumero;
                        }
                }
        }
}
