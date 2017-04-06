using Lazaro.Orm;
using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Articulos
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Marca", Grupo = "Artículos")]
        [Lbl.Atributos.Datos(TablaDatos = "marcas", CampoId = "id_marca")]
        [Lbl.Atributos.Presentacion()]
	public class Marca : ElementoDeDatos
	{
		public Personas.Persona Proveedor;
		
		public Marca(Lfx.Data.IConnection dataBase) 
                        : base(dataBase) { }

		public Marca(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Marca(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
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
                                if (value == null) {
                                        this.Registro["obs"] = null;
                                } else {
                                        this.Registro["obs"] = value.Trim(new char[] { '\n', '\r', ' ' });
                                }
                        }
                }


                public string Url
		{
			get
			{
				if(this.Registro["url"] == null || this.Registro["url"] == DBNull.Value)
					return null;
				else
					return this.Registro["url"].ToString();
			}
			set
			{
				this.Registro["url"] = value;
			}
		}

		public override Lfx.Types.OperationResult Guardar()
                {
			qGen.IStatement Comando;

                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.TablaDatos);
                                Comando.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                        } else {
                                Comando = new qGen.Update(this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.ColumnValues.AddWithValue("nombre", this.Nombre);
			Comando.ColumnValues.AddWithValue("url", this.Url);
			if(this.Proveedor == null)
				Comando.ColumnValues.AddWithValue("id_proveedor", null);
			else
				Comando.ColumnValues.AddWithValue("id_proveedor", this.Proveedor.Id);
			Comando.ColumnValues.AddWithValue("obs", this.Obs);
			Comando.ColumnValues.AddWithValue("estado", this.Estado);

			this.AgregarTags(Comando);

                        this.Connection.ExecuteNonQuery(Comando);

			return base.Guardar();
		}
	}
}
