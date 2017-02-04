using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Personas
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Grupo", Grupo = "Personas")]
        [Lbl.Atributos.Datos(TablaDatos = "personas_grupos", CampoId = "id_grupo")]
        [Lbl.Atributos.Presentacion()]
	public class Grupo : ElementoDeDatos
	{
                private Grupo m_Parent = null;

		public Grupo(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

		public Grupo(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Grupo(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public override void OnLoad()
                {
                        m_Parent = null;

                        base.OnLoad();
                }

                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.TableCommand Comando;
                        if (this.Existe == false) {
                                Comando = new qGen.Insert(Connection, "personas_grupos");
                                Comando.Fields.AddWithValue("fecha", qGen.SqlFunctions.Now);
                        } else {
                                Comando = new qGen.Update(Connection, "personas_grupos");
                                Comando.WhereClause = new qGen.Where("id_grupo", this.Id);
                        }

                        Comando.Fields.AddWithValue("nombre", this.Nombre);
                        Comando.Fields.AddWithValue("descuento", this.Descuento);
                        Comando.Fields.AddWithValue("predet", this.Predeterminado ? 1 : 0);
                        if (this.Parent != null)
                                Comando.Fields.AddWithValue("parent", this.Parent.Id);
                        else
                                Comando.Fields.AddWithValue("parent", null);

                        Connection.Execute(Comando);
                        
                        return base.Guardar();
                }

                public decimal Descuento
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("descuento");
                        }
                        set
                        {
                                this.Registro["descuento"] = value;
                        }
                }

                public bool Predeterminado
                {
                        get
                        {
                                return this.GetFieldValue<int>("predet") == 1;
                        }
                        set
                        {
                                this.Registro["predet"] = value ? 1 : 0;
                        }
                }

                public Grupo Parent
                {
                        get
                        {
                                if(m_Parent == null && this.GetFieldValue<int>("parent") != 0)
                                        m_Parent = new Grupo(this.Connection, this.GetFieldValue<int>("parent"));

                                return m_Parent;
                        }
                        set
                        {
                                m_Parent = value;
                                if (value != null)
                                        this.Registro["parent"] = value.Id;
                        }
                }
	}
}
