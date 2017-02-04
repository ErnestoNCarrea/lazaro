using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Tareas
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Estado", Grupo = "Tareas")]
        [Lbl.Atributos.Datos(TablaDatos = "tickets_estados", CampoId = "id_ticket_estado")]
        [Lbl.Atributos.Presentacion()]
        public class Estado : Lbl.ElementoDeDatos
        {
                public Estado(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public Estado(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Estado(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public override void Crear()
                {
                        base.Crear();
                        this.Estado = 1;
                }


                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.TableCommand Comando;

                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.Connection, this.TablaDatos);
                        } else {
                                Comando = new qGen.Update(this.Connection, this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.Fields.AddWithValue("nombre", this.Nombre);
                        Comando.Fields.AddWithValue("obs", this.Obs);
                        Comando.Fields.AddWithValue("estado", this.Estado);

                        this.AgregarTags(Comando);

                        this.Connection.Execute(Comando);

                        return base.Guardar();
                }


                private static Dictionary<int, Estado> m_TodosPorNumero = null;
                public static Dictionary<int, Estado> TodosPorNumero
                {
                        get
                        {
                                if (m_TodosPorNumero == null) {
                                        m_TodosPorNumero = new Dictionary<int, Estado>();
                                        System.Data.DataTable Tabla = Lfx.Workspace.Master.MasterConnection.Select("SELECT * FROM tickets_estados");
                                        foreach (System.Data.DataRow Reg in Tabla.Rows) {
                                                m_TodosPorNumero.Add(System.Convert.ToInt32(Reg["id_ticket_estado"]), new Lbl.Tareas.Estado(Lfx.Workspace.Master.MasterConnection, (Lfx.Data.Row)Reg));
                                        }
                                }
                                return m_TodosPorNumero;
                        }
                }
        }
}
