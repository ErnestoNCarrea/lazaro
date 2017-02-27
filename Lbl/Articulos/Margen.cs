using Lazaro.Orm;
using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Articulos
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Márgen", Grupo = "Artículos")]
        [Lbl.Atributos.Datos(TablaDatos = "margenes", CampoId = "id_margen")]
        [Lbl.Atributos.Presentacion()]
	public class Margen : ElementoDeDatos
	{
		public Margen(Lfx.Data.IConnection dataBase) 
                        : base(dataBase) { }

		public Margen(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Margen(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
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


                public decimal Porcentaje
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("porcentaje");
                        }
                        set
                        {
                                this.SetFieldValue("porcentaje", value);
                        }
                }


                public bool Predeterminado
                {
                        get
                        {
                                return this.GetFieldValue<bool>("predet");
                        }
                        set
                        {
                                this.SetFieldValue("predet", value ? 1 : 0);
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
                        Comando.ColumnValues.AddWithValue("porcentaje", this.Porcentaje);
                        Comando.ColumnValues.AddWithValue("predet", this.Predeterminado ? 1 : 0);
                        Comando.ColumnValues.AddWithValue("obs", this.Obs);
                        Comando.ColumnValues.AddWithValue("estado", this.Estado);

                        this.AgregarTags(Comando);

                        this.Connection.ExecuteNonQuery(Comando);

                        return base.Guardar();
                }
	}
}
