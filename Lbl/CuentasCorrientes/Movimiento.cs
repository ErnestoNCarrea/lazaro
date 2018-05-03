using Lazaro.Orm;
using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;

namespace Lbl.CuentasCorrientes
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Movimiento de cuenta corriente", Grupo = "Cuentas")]
        [Lbl.Atributos.Datos(TablaDatos = "ctacte", CampoId = "id_movim", CampoNombre = "concepto")]
        [Lbl.Atributos.Presentacion(PanelExtendido = Lbl.Atributos.PanelExtendido.Nunca)]

        [Entity(TableName = "ctacte", IdFieldName = "id_movim")]
        public class Movimiento : ElementoDeDatos
        {
                Lbl.Personas.Persona m_Persona = null;
                Lbl.Cajas.Concepto m_Concepto = null;

                public Movimiento()
                        : base() { }

                //Heredar constructor
                public Movimiento(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

		public Movimiento(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Movimiento(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                /// <summary>
                /// Obtiene o establece el nombre del elemento.
                /// </summary>
                [Column(Name = "concepto", Type = ColumnTypes.VarChar, Length = 200, Nullable = false)]
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


                [Column(Name = "fecha")]
                public DateTime Fecha
                {
                        get
                        {
                                return this.GetFieldValue<DateTime>("fecha");
                        }
                        set
                        {
                                this.SetFieldValue("fecha", value);
                        }
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

                        Comando.ColumnValues.AddWithValue("fecha", this.Fecha);
                        Comando.ColumnValues.AddWithValue("auto", this.Auto ? 1 : 0);
                        Comando.ColumnValues.AddWithValue("concepto", this.Nombre);
                        Comando.ColumnValues.AddWithValue("id_cliente", this.IdCliente);
                        Comando.ColumnValues.AddWithValue("importe", this.Importe);
                        Comando.ColumnValues.AddWithValue("comprob", this.Comprobantes);
                        Comando.ColumnValues.AddWithValue("obs", this.Obs);

                        if (this.IdConcepto == 0)
                                Comando.ColumnValues.AddWithValue("id_concepto", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_concepto", this.IdConcepto);

                        this.AgregarTags(Comando);

                        this.Connection.ExecuteNonQuery(Comando);

                        return base.Guardar();
                }


                [Column(Name = "id_cliente")]
                protected internal int IdCliente
                {
                        get
                        {
                                return this.GetFieldValue<int>("id_cliente");
                        }
                        set
                        {
                                this.Registro["id_cliente"] = value;
                        }
                }


                [Column(Name = "id_concepto")]
                protected internal int IdConcepto
                {
                        get
                        {
                                return this.GetFieldValue<int>("id_concepto");
                        }
                        set
                        {
                                this.Registro["id_concepto"] = value;
                        }
                }


                [Column(Name = "importe")]
                public decimal Importe
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("importe");
                        }
                        set
                        {
                                this.Registro["importe"] = value;
                        }
                }


                [Column(Name = "saldo")]
                public decimal Saldo
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("saldo");
                        }
                        set
                        {
                                this.Registro["saldo"] = value;
                        }
                }


                [Column(Name = "comprob")]
                public string Comprobantes
                {
                        get
                        {
                                return this.GetFieldValue<string>("comprob");
                        }
                        set
                        {
                                this.Registro["comprob"] = value;
                        }
                }


                [Column(Name = "auto")]
                public bool Auto
                {
                        get
                        {
                                return this.GetFieldValue<int>("auto") != 0;
                        }
                        set
                        {
                                this.Registro["auto"] = value ? 1 : 0;
                        }
                }

                public Lbl.Personas.Persona Persona
                {
                        get
                        {
                                if (IdCliente > 0)
                                        m_Persona = new Personas.Persona(this.Connection, IdCliente);
                                return m_Persona;
                        }
                        set
                        {
                                m_Persona = value;
                                IdCliente = m_Persona.Id;
                        }
                }

                public Cajas.Concepto Concepto
                {
                        get
                        {
                                if (m_Concepto == null && IdConcepto > 0)
                                        m_Concepto = new Cajas.Concepto(this.Connection,IdConcepto);

                                return m_Concepto;
                        }
                        set
                        {
                                m_Concepto = value;
                                IdConcepto= m_Concepto.Id;
                        }
                }

        }

}
