using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Cajas
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Caja", Grupo = "Cajas")]
        [Lbl.Atributos.Datos(TablaDatos = "cajas", CampoId = "id_caja")]
        [Lbl.Atributos.Presentacion()]
	public class Caja : ElementoDeDatos, Lbl.ICamposBaseEstandar, Lbl.ICuenta, Lbl.IEstadosEstandar
	{
                private Lbl.Bancos.Banco m_Banco = null;
                private Lbl.Entidades.Moneda m_Moneda = null;

		//Heredar constructores
                public Caja(Lfx.Data.IConnection dataBase) 
                        : base(dataBase) { }

		public Caja(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Caja(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                /// <summary>
                /// Obtiene o establece el nombre del elemento.
                /// </summary>
                [Column(Name = "nombre")]
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


                public virtual decimal ObtenerSaldo(bool forUpdate)
		{
                        qGen.Select SelSaldo = new qGen.Select("cajas_movim", forUpdate);
                        SelSaldo.Columns = new List<string> { "saldo" };
                        SelSaldo.WhereClause = new qGen.Where("id_caja", this.Id);
                        SelSaldo.Order = "id_movim DESC";
                        SelSaldo.Window = new qGen.Window(1);

                        return this.Connection.FieldDecimal(SelSaldo);
		}

                public Bancos.Banco Banco
                {
                        get
                        {
                                if (m_Banco == null && this.GetFieldValue<int>("id_banco") > 0)
                                        m_Banco = new Bancos.Banco(this.Connection, this.GetFieldValue<int>("id_banco"));
                                return m_Banco;
                        }
                        set
                        {
                                m_Banco = value;
                                this.SetFieldValue("id_banco", value);
                        }
                }


                public Entidades.Moneda ObtenerMoneda()
                {
                        if (this.Moneda == null)
                                return Lbl.Sys.Config.Moneda.MonedaPredeterminada;
                        else
                                return this.Moneda;
                }


                public Entidades.Moneda Moneda
                {
                        get
                        {
                                if (m_Moneda == null && this.GetFieldValue<int>("id_moneda") > 0)
                                        m_Moneda = new Entidades.Moneda(this.Connection, this.GetFieldValue<int>("id_moneda"));
                                return m_Moneda;
                        }
                        set
                        {
                                m_Moneda = value;
                                this.SetFieldValue("id_moneda", value);
                        }
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

                public string ClaveBancaria
                {
                        get
                        {
                                return this.GetFieldValue<string>("cbu");
                        }
                        set
                        {
                                this.Registro["cbu"] = value;
                        }
                }

                public TiposDeCaja Tipo
                {
                        get
                        {
                                return (TiposDeCaja)(this.GetFieldValue<int>("tipo"));
                        }
                        set
                        {
                                this.Registro["tipo"] = (int)value;
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

                        Comando.ColumnValues.AddWithValue(this.CampoNombre, this.Nombre);
                        Comando.ColumnValues.AddWithValue("titular", this.Titular);
                        if (Banco == null)
                                Comando.ColumnValues.AddWithValue("id_banco", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_banco", this.Banco.Id);
                        if (this.Moneda == null)
                                Comando.ColumnValues.AddWithValue("id_moneda", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_moneda", this.Moneda.Id);
                        Comando.ColumnValues.AddWithValue("numero", this.Numero);
                        Comando.ColumnValues.AddWithValue("tipo", (int)(this.Tipo));
                        Comando.ColumnValues.AddWithValue("cbu", this.ClaveBancaria);
                        Comando.ColumnValues.AddWithValue("estado", this.Estado);

                        Connection.ExecuteNonQuery(Comando);

                        return base.Guardar();
                }

                public void Arqueo()
                {
                        this.Movimiento(false, null, "Arqueo de caja - Saldo: " + Lbl.Sys.Config.Moneda.Simbolo + " " + Lfx.Types.Formatting.FormatCurrency(this.ObtenerSaldo(false)), Lbl.Sys.Config.Actual.UsuarioConectado.Persona, 0, null, null, null, null);
                }

                public void Movimiento(bool auto, Lbl.Cajas.Concepto concepto, string textoConcepto,
                        Lbl.Personas.Persona cliente, decimal importe, string obs,
                        Lbl.Comprobantes.ComprobanteConArticulos factura, Lbl.Comprobantes.Recibo recibo, string comprobantes)
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(this, Lbl.Sys.Permisos.Operaciones.Mover) == false) {
                                throw new Lfx.Types.Exceptions.AccessDeniedException("No tiene permiso para hacer movimientos en la caja solicitada");
                        }

                        decimal SaldoActual = this.ObtenerSaldo(true);

                        qGen.IStatement InsertarMovimiento = new qGen.Insert("cajas_movim");
			InsertarMovimiento.ColumnValues.AddWithValue("id_caja", this.Id);
			InsertarMovimiento.ColumnValues.AddWithValue("auto", auto ? 1 : 0);
                        if (concepto == null)
                                InsertarMovimiento.ColumnValues.AddWithValue("id_concepto", null);
                        else
                                InsertarMovimiento.ColumnValues.AddWithValue("id_concepto", concepto.Id);
                        InsertarMovimiento.ColumnValues.AddWithValue("concepto", textoConcepto);
                        InsertarMovimiento.ColumnValues.AddWithValue("id_persona", Lbl.Sys.Config.Actual.UsuarioConectado.Id);
                        if (cliente == null)
                                InsertarMovimiento.ColumnValues.AddWithValue("id_cliente", null);
                        else
                                InsertarMovimiento.ColumnValues.AddWithValue("id_cliente", cliente.Id);
			InsertarMovimiento.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
			InsertarMovimiento.ColumnValues.AddWithValue("importe", importe);
                        if (factura == null)
                                InsertarMovimiento.ColumnValues.AddWithValue("id_comprob", null);
                        else
                                InsertarMovimiento.ColumnValues.AddWithValue("id_comprob", factura.Id);
                        if (recibo == null)
                                InsertarMovimiento.ColumnValues.AddWithValue("id_recibo", null);
                        else
                                InsertarMovimiento.ColumnValues.AddWithValue("id_recibo", recibo.Id);
			InsertarMovimiento.ColumnValues.AddWithValue("comprob", comprobantes);
			InsertarMovimiento.ColumnValues.AddWithValue("saldo", SaldoActual + importe);
			InsertarMovimiento.ColumnValues.AddWithValue("obs", obs);
			this.Connection.ExecuteNonQuery(InsertarMovimiento);
		}


                /// <summary>
                /// Recalcula completamente el saldo de la caja, para corregir errores de transporte. Principalmente de uso interno.
                /// </summary>
                public void Recalcular()
                {
                        Lfx.Types.OperationProgress Progreso = new Lfx.Types.OperationProgress("Recalculando", "Se va a recalcular el saldo de la caja " + this.ToString());
                        Progreso.Begin();

                        System.Data.DataTable Movims = this.Connection.Select("SELECT id_movim, importe FROM cajas_movim WHERE id_caja=" + this.Id.ToString() + " ORDER BY id_movim");
                        decimal Saldo = 0;
                        Progreso.Max = Movims.Rows.Count;
                        foreach (System.Data.DataRow Movim in Movims.Rows) {
                                Saldo += System.Convert.ToDecimal(Movim["importe"]);

                                qGen.Update Upd = new qGen.Update("cajas_movim");
                                Upd.ColumnValues.AddWithValue("saldo", Saldo);
                                Upd.WhereClause = new qGen.Where("id_movim", System.Convert.ToInt32(Movim["id_movim"]));
                                this.Connection.ExecuteNonQuery(Upd);

                                Progreso.Advance(1);
                        }
                        Progreso.End();
                }


                public void Activar(bool activar)
                {
                        this.Estado = 0;
                        qGen.Update ActCmd = new qGen.Update(this.TablaDatos);
                        ActCmd.ColumnValues.AddWithValue("estado", activar ? 1 : 0);
                        ActCmd.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        this.Connection.ExecuteNonQuery(ActCmd);
                        Lbl.Sys.Config.ActionLog(this.Connection, Lbl.Sys.Log.Acciones.Delete, this, activar ? "Activar" : "Desactivar");
                }
	}
}
