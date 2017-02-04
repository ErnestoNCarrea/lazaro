using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Bancos
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Chequera", Grupo = "Bancos")]
        [Lbl.Atributos.Datos(TablaDatos = "chequeras", CampoId = "id_chequera")]
        [Lbl.Atributos.Presentacion()]
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
                        qGen.TableCommand Comando;
                        if (this.Existe == false) {
                                Comando = new qGen.Insert(Connection, "chequeras");
                                Comando.Fields.AddWithValue("fecha", qGen.SqlFunctions.Now);
                        } else {
                                Comando = new qGen.Update(Connection, "chequeras");
                                Comando.WhereClause = new qGen.Where("id_chequera", m_ItemId);
                        }

                        if (this.Banco == null)
                                Comando.Fields.AddWithValue("id_banco", null);
                        else
                                Comando.Fields.AddWithValue("id_banco", this.Banco.Id);
                        Comando.Fields.AddWithValue("prefijo", this.Prefijo);
                        Comando.Fields.AddWithValue("desde", this.Desde);
                        Comando.Fields.AddWithValue("hasta", this.Hasta);
                        Comando.Fields.AddWithValue("cheques_total", this.Hasta - this.Desde);
                        if (this.Caja == null)
                                Comando.Fields.AddWithValue("id_caja", null);
                        else
                                Comando.Fields.AddWithValue("id_caja", this.Caja.Id);
                        if (this.Sucursal == null)
                                Comando.Fields.AddWithValue("id_sucursal", null);
                        else
                                Comando.Fields.AddWithValue("id_sucursal", this.Sucursal.Id);
                        Comando.Fields.AddWithValue("titular", this.Titular);
                        Comando.Fields.AddWithValue("estado", this.Estado);

                        Connection.Execute(Comando);
                        this.ActualizarId();

                        if (this.Desde > 0 && this.Hasta > 0 && this.Hasta > this.Desde) {
				qGen.Update Actua = new qGen.Update("bancos_cheques");
				Actua.Fields.AddWithValue("id_chequera", this.Id);
				Actua.WhereClause = new qGen.Where();
                                Actua.WhereClause.AddWithValue("emitido", 1);
                                Actua.WhereClause.AddWithValue("id_banco", this.Banco.Id);
                                Actua.WhereClause.AddWithValue("numero", this.Desde, this.Hasta);
				Connection.Execute(Actua);
				
				Actua = new qGen.Update("bancos_cheques");
				Actua.Fields.Add(new Lazaro.Orm.Data.Field("id_chequera", Lazaro.Orm.ColumnTypes.Integer, null));
				Actua.WhereClause = new qGen.Where();
                                Actua.WhereClause.AddWithValue("emitido", 1);
                                Actua.WhereClause.AddWithValue("id_banco", this.Banco.Id);
                                Actua.WhereClause.AddWithValue("id_chequera", this.Id);
                                qGen.Where Numeros = new qGen.Where(qGen.AndOr.Or);
                                Numeros.AddWithValue("numero", qGen.ComparisonOperators.LessThan, this.Desde);
                                Numeros.AddWithValue("numero", qGen.ComparisonOperators.GreaterThan, this.Hasta);
                                Actua.WhereClause.AddWithValue(Numeros);
				Connection.Execute(Actua);

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
