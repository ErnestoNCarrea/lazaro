using Lazaro.Orm;
using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Articulos
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Situación", Grupo = "Artículos")]
        [Lbl.Atributos.Datos(TablaDatos = "articulos_situaciones", CampoId = "id_situacion")]
        [Lbl.Atributos.Presentacion()]
	public class Situacion : ElementoDeDatos
	{
		//Heredar constructor
		public Situacion(Lfx.Data.IConnection dataBase) : base(dataBase) { }

		public Situacion(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Situacion(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
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
                /// Indica si los artículos en esta situación suman al stock.
                /// </summary>
		public bool CuentaExistencias
		{
			get
			{
				return this.GetFieldValue<bool>("cuenta_stock");
			}
                        set
                        {
                                this.SetFieldValue("cuenta_stock", value ? 1 : 0);
                        }
		}


                /// <summary>
                /// Indica si los artículos en esta situación pueden ser facturados.
                /// </summary>
                public bool Facturable
                {
                        get
                        {
                                return this.GetFieldValue<bool>("facturable");
                        }
                        set
                        {
                                this.SetFieldValue("facturable", value ? 1 : 0);
                        }
                }


                /// <summary>
                /// Indica -si esta situación es un depósito- el número de depósito. Si es 0, no es un depósito.
                /// </summary>
                public int Deposito
                {
                        get
                        {
                                return this.GetFieldValue<int>("deposito");
                        }
                        set
                        {
                                this.SetFieldValue("deposito", value);
                        }
                }


                public override Lfx.Types.OperationResult Guardar()
                {
                        try {
				qGen.IStatement Comando;
                                if (this.Existe) {
					Comando = new qGen.Update(this.TablaDatos);
					Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
				} else {
					Comando = new qGen.Insert(this.TablaDatos);
                                        Comando.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                                }

                                Comando.ColumnValues.AddWithValue("nombre", this.Registro["nombre"].ToString());
                                Comando.ColumnValues.AddWithValue("cuenta_stock", this.CuentaExistencias ? 1 : 0);
                                Comando.ColumnValues.AddWithValue("deposito", this.Deposito);
                                Comando.ColumnValues.AddWithValue("facturable", this.Facturable ? 1 : 0);
                                Comando.ColumnValues.AddWithValue("estado", this.Estado);
                                Comando.ColumnValues.AddWithValue("obs", this.Obs);
				
				this.AgregarTags(Comando);

	                        this.Connection.ExecuteNonQuery(Comando);

				return new Lfx.Types.SuccessOperationResult();
                        }
                        catch (Exception ex) {
                                return new Lfx.Types.FailureOperationResult(ex.ToString());
                        }
                }
	}
}
