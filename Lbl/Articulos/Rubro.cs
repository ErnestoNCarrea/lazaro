using Lazaro.Orm;
using Lazaro.Orm.Attributes;
using Lbl.Impuestos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Articulos
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Rubro", Grupo = "Artículos")]
        [Lbl.Atributos.Datos(TablaDatos = "articulos_rubros", CampoId = "id_rubro")]
        [Lbl.Atributos.Presentacion()]

        [Entity(TableName = "articulos_rubros", IdFieldName = "id_rubro")]
        public class Rubro : ElementoDeDatos
	{
                private Lbl.Impuestos.Alicuota m_Alicuota = null;

		public Rubro(Lfx.Data.IConnection dataBase) 
                        : base(dataBase) { }

		public Rubro(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Rubro(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
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


                public override Lfx.Types.OperationResult Guardar()
                {
                        var Em = new Lazaro.Orm.EntityManager(this.Connection, Lfx.Workspace.Master.MetadataFactory);

                        Em.Persist(this);

                        /* qGen.IStatement Comando;

                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.TablaDatos);
                        } else {
                                Comando = new qGen.Update(this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.ColumnValues.AddWithValue("nombre", this.Nombre);
                        if (this.Alicuota == null)
                                Comando.ColumnValues.AddWithValue("id_alicuota", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_alicuota", this.Alicuota.Id);

			this.AgregarTags(Comando);

                        this.Connection.ExecuteNonQuery(Comando); */

			return base.Guardar();
		}

                [Column(Name = "id_alicuota")]
                [ManyToOne]
                public Alicuota Alicuota
                {
                        get
                        {
                                var Em = new Lazaro.Orm.EntityManager(this.Connection, Lfx.Workspace.Master.MetadataFactory);
                                return this.LazyLoad<Alicuota>(Em, ref m_Alicuota, this.GetFieldValue<int>("id_alicuota"));
                        }
                        set
                        {
                                m_Alicuota = value;
                                this.SetFieldValue("id_alicuota", value);
                        }
                }
	}
}
