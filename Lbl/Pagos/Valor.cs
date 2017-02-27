using Lazaro.Orm;
using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Pagos
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Valor de pago", Grupo = "Cobros y pagos")]
        [Lbl.Atributos.Datos(TablaDatos = "pagos_valores", CampoId = "id_valor")]
        [Lbl.Atributos.Presentacion()]
        public class Valor : ElementoDeDatos
        {
                public Lbl.Pagos.FormaDePago FormaDePago;
                public Lbl.Comprobantes.Recibo Recibo;

                //Heredar constructor
		public Valor(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public Valor(Lfx.Data.IConnection dataBase, int idValor)
			: this(dataBase)
		{
                        m_ItemId = idValor;
                        this.Cargar();
		}

                public Valor(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
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


                public override void OnLoad()
                {
                        if (this.Registro != null) {
                                if (this.GetFieldValue<int>("id_formapago") > 0)
                                        this.FormaDePago = new Lbl.Pagos.FormaDePago(this.Connection, this.GetFieldValue<int>("id_formapago"));
                                else
                                        this.FormaDePago = null;
                        }
                        base.OnLoad();
                }

                public override string ToString()
                {
                        String Res = this.FormaDePago.ToString();
                        if (this.Numero != null && this.Numero.Length > 0)
                                Res += " Nº " + this.Numero;

                        return Res;
                }

                public string Numero
                {
                        get
                        {
                                return this.GetFieldValue<string>("numero");
                        }
                        set
                        {
                                this.Registro["numero"] = value;
                        }
                }

                public int ItemId
                {
                        get
                        {
                                return this.GetFieldValue<int>("id_item");
                        }
                        set
                        {
                                this.Registro["id_item"] = value;
                        }
                }

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

                public void Anular()
                {
                        return;
                }

                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.IStatement Comando;
                        if (this.Existe) {
                                Comando = new qGen.Update(this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        } else {
                                Comando = new qGen.Insert(this.TablaDatos);
                        }

                        Comando.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));

                        if (this.FormaDePago == null)
                                throw new InvalidOperationException("Lbl.Pagos.Valor.Guardar: Debe especificar la forma de pago");
                        else
                                Comando.ColumnValues.AddWithValue("id_formapago", this.FormaDePago.Id);

                        if (this.Recibo == null)
                                throw new InvalidOperationException("Lbl.Pagos.Valor.Guardar: Debe especificar el recibo");
                        else
                                Comando.ColumnValues.AddWithValue("id_recibo", this.Recibo.Id);

                        if(this.Nombre == null || this.Nombre.Length == 0)
                                Comando.ColumnValues.AddWithValue("nombre", this.FormaDePago.ToString() + " Nº " + this.Numero);
                        else
                                Comando.ColumnValues.AddWithValue("nombre", this.Nombre);

                        Comando.ColumnValues.AddWithValue("numero", this.Numero);
                        Comando.ColumnValues.AddWithValue("id_sucursal", Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual);

                        Comando.ColumnValues.AddWithValue("importe", this.Importe);
                        Comando.ColumnValues.AddWithValue("obs", this.Obs);

                        this.AgregarTags(Comando);

                        this.Connection.ExecuteNonQuery(Comando);

                        return base.Guardar();
                }
        }
}
