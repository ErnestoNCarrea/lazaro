using System;
using System.Collections.Generic;
using System.Text;
using Lazaro.Orm;
using Lazaro.Orm.Attributes;

namespace Lbl.Entidades
{
        /// <summary>
        /// Representa una moneda (divisa).
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Moneda", Grupo = "Cuentas")]
        [Lbl.Atributos.Datos(TablaDatos = "monedas", CampoId = "id_moneda")]
        [Lbl.Atributos.Presentacion()]

        [Entity(TableName = "monedas", IdFieldName = "id_moneda")]
        public class Moneda : ElementoDeDatos
        {
                //Heredar constructor
                public Moneda(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public Moneda(Lfx.Data.IConnection dataBase, int itemId)
                        : base(dataBase, itemId) { }

                public Moneda(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public string Simbolo
                {
                        get
                        {
                                return this.GetFieldValue<string>("signo");
                        }
                        set
                        {
                                this.Registro["signo"] = value;
                        }
                }

                public string NomenclaturaIso
                {
                        get
                        {
                                return this.GetFieldValue<string>("iso");
                        }
                        set
                        {
                                this.Registro["iso"] = value;
                        }
                }

                public decimal Cotizacion
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("cotizacion");
                        }
                        set
                        {
                                this.Registro["cotizacion"] = value;
                        }
                }

                public string Nombre
                {
                        get
                        {
                                return this.GetFieldValue<string>("nombre");
                        }
                        set
                        {
                                this.Registro["nombre"] = value;
                        }
                }

                [Column(Name = "fecha")]
                public DbDateTime Fecha
                {
                        get
                        {
                                return this.GetFieldValue<DbDateTime>("fecha");
                        }
                }

                public int Decimales
                {
                        get
                        {
                                return this.GetFieldValue<int>("decimales");
                        }
                        set
                        {
                                this.Registro["decimales"] = value;
                        }
                }

                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.IStatement Comando;
                        if (this.Existe == false)
                        {
                                Comando = new qGen.Insert(this.TablaDatos);
                                Comando.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                                Comando.ColumnValues.AddWithValue("estado", 1);
                                Comando.ColumnValues.AddWithValue("decimales", 2);

                        } else
                        {
                                Comando = new qGen.Update("monedas");
                                Comando.WhereClause = new qGen.Where("id_moneda", m_ItemId);
                                Comando.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                        }
                        

                        Comando.ColumnValues.AddWithValue("nombre", this.Nombre);
                        Comando.ColumnValues.AddWithValue("iso", this.NomenclaturaIso);
                        Comando.ColumnValues.AddWithValue("signo", this.Simbolo);
                        if (this.Cotizacion > 0)
                                Comando.ColumnValues.AddWithValue("cotizacion", this.Cotizacion);  
                        

                        Connection.ExecuteNonQuery(Comando);

                        return base.Guardar();
                }
        }
}
