using Lazaro.Orm;
using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Bancos
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Chequera", Grupo = "Bancos")]
        [Lbl.Atributos.Datos(TablaDatos = "chequeras", CampoId = "id_chequera")]
        [Lbl.Atributos.Presentacion()]

        [Entity(TableName = "chequeras", IdFieldName = "id_chequera")]
        public class Chequera : ElementoDeDatos, ICamposBaseEstandar
        {
                public Bancos.Banco Banco;
                public Lbl.Cajas.Caja Caja;
                public Lbl.Entidades.Sucursal Sucursal;

                //Heredar constructor
                public Chequera(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public Chequera(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Chequera(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public override void Crear()
                {
                        this.Sucursal = Lbl.Sys.Config.Empresa.SucursalActual;
                        base.Crear();
                }


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


                [Column(Name = "titular")]
                public string Titular
                {
                        get
                        {
                                return this.GetFieldValue<string>("titular");
                        }
                        set
                        {
                                this.Registro["titular"] = value;
                        }
                }

                [Column(Name = "prefijo")]
                public int Prefijo
                {
                        get
                        {
                                return this.GetFieldValue<int>("prefijo");
                        }
                        set
                        {
                                this.Registro["prefijo"] = value;
                        }
                }

                [Column(Name = "desde")]
                public int Desde
                {
                        get
                        {
                                return this.GetFieldValue<int>("desde");
                        }
                        set
                        {
                                this.Registro["desde"] = value;
                        }
                }

                [Column(Name = "hasta")]
                public int Hasta
                {
                        get
                        {
                                return this.GetFieldValue<int>("hasta");
                        }
                        set
                        {
                                this.Registro["hasta"] = value;
                        }
                }

                public override void OnLoad()
                {
                        if (this.Registro != null) {
                                if (this.GetFieldValue<int>("id_banco") > 0)
                                        this.Banco = new Bancos.Banco(this.Connection, this.GetFieldValue<int>("id_banco"));
                                else
                                        this.Banco = null;

                                if (this.GetFieldValue<int>("id_caja") > 0)
                                        this.Caja = new Cajas.Caja(this.Connection, this.GetFieldValue<int>("id_caja"));
                                else
                                        this.Caja = null;

                                if (this.GetFieldValue<int>("id_sucursal") > 0)
                                        this.Sucursal = new Lbl.Entidades.Sucursal(this.Connection, this.GetFieldValue<int>("id_sucursal"));
                                else
                                        this.Sucursal = null;
                        }
                        base.OnLoad();
                }

                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.IStatement Comando;
                        if (this.Existe == false) {
                                Comando = new qGen.Insert("chequeras");
                                Comando.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                        } else {
                                Comando = new qGen.Update("chequeras");
                                Comando.WhereClause = new qGen.Where("id_chequera", m_ItemId);
                        }

                        if (this.Banco == null)
                                Comando.ColumnValues.AddWithValue("id_banco", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_banco", this.Banco.Id);
                        Comando.ColumnValues.AddWithValue("prefijo", this.Prefijo);
                        Comando.ColumnValues.AddWithValue("desde", this.Desde);
                        Comando.ColumnValues.AddWithValue("hasta", this.Hasta);
                        Comando.ColumnValues.AddWithValue("cheques_total", this.Hasta - this.Desde);
                        if (this.Caja == null)
                                Comando.ColumnValues.AddWithValue("id_caja", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_caja", this.Caja.Id);
                        if (this.Sucursal == null)
                                Comando.ColumnValues.AddWithValue("id_sucursal", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_sucursal", this.Sucursal.Id);
                        Comando.ColumnValues.AddWithValue("titular", this.Titular);
                        Comando.ColumnValues.AddWithValue("estado", this.Estado);

                        Connection.ExecuteNonQuery(Comando);
                        this.ActualizarId();

                        if (this.Desde > 0 && this.Hasta > 0 && this.Hasta > this.Desde) {
				qGen.Update Actua = new qGen.Update("bancos_cheques");
				Actua.ColumnValues.AddWithValue("id_chequera", this.Id);
				Actua.WhereClause = new qGen.Where();
                                Actua.WhereClause.AddWithValue("emitido", 1);
                                Actua.WhereClause.AddWithValue("id_banco", this.Banco.Id);
                                Actua.WhereClause.AddWithValue("numero", this.Desde, this.Hasta);
				Connection.ExecuteNonQuery(Actua);
				
				Actua = new qGen.Update("bancos_cheques");
				Actua.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("id_chequera", Lazaro.Orm.ColumnTypes.Integer, null));
				Actua.WhereClause = new qGen.Where();
                                Actua.WhereClause.AddWithValue("emitido", 1);
                                Actua.WhereClause.AddWithValue("id_banco", this.Banco.Id);
                                Actua.WhereClause.AddWithValue("id_chequera", this.Id);
                                qGen.Where Numeros = new qGen.Where(qGen.AndOr.Or);
                                Numeros.AddWithValue("numero", qGen.ComparisonOperators.LessThan, this.Desde);
                                Numeros.AddWithValue("numero", qGen.ComparisonOperators.GreaterThan, this.Hasta);
                                Actua.WhereClause.AddWithValue(Numeros);
				Connection.ExecuteNonQuery(Actua);

                        }

                        return base.Guardar();
                }

                public override string ToString()
                {
                        String Res = "Chequera ";
                        if (Banco != null)
                                Res += " del " + Banco.ToString();
                        return Res;
                }
        }
}
