using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Pagos
{
        /// <summary>
        /// Describe un pago con un cupón (por ejemplo pagos con tarjeta de crédito, vales, mutuales, etc.)
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Cupón", Grupo = "Pagos y Cobros")]
        [Lbl.Atributos.Datos(TablaDatos = "tarjetas_cupones", CampoId = "id_cupon")]
        [Lbl.Atributos.Presentacion()]
	public class Cupon : ElementoDeDatos
	{
                private Pagos.FormaDePago m_FormaDePago;
                private Pagos.Plan m_Plan;
                private Lbl.Comprobantes.Recibo m_Recibo;
                private Lbl.Comprobantes.ComprobanteConArticulos m_Factura;
                private Cajas.Concepto m_Concepto;
                private Personas.Persona m_Cliente, m_Vendedor;

		//Heredar constructor
		public Cupon(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public Cupon(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Cupon(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                /* public Cupon(Lfx.Data.IConnection dataBase, Lbl.Comprobantes.ComprobanteConArticulos factura)
                        : this(dataBase)
                {
                        m_ItemId = dataBase.FieldInt("SELECT MAX(id_cupon) FROM tarjetas_cupones WHERE id_comprob=" + factura.Id.ToString());
                        this.Cargar();
                } */

                public Cupon(Lfx.Data.IConnection dataBase, decimal importe, Pagos.FormaDePago tarjeta, Pagos.Plan plan, string numero, string autorizacion)
			: this(dataBase)
		{
			Importe = importe;
			FormaDePago = tarjeta;
			Plan = plan;
			Numero = numero;
			Autorizacion = autorizacion;
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

                public string ConceptoTexto
                {
                        get
                        {
                                return this.GetFieldValue<string>("concepto");
                        }
                        set
                        {
                                this.Registro["concepto"] = value;
                        }
                }

                public string Autorizacion
                {
                        get
                        {
                                return this.GetFieldValue<string>("autorizacion");
                        }
                        set
                        {
                                this.Registro["autorizacion"] = value;
                        }
                }

                public NullableDateTime FechaPresentacion
                {
                        get
                        {
                                return this.FieldDateTime("fecha_pres");
                        }
                        set
                        {
                                this.Registro["fecha_pres"] = value;
                        }
                }

                public NullableDateTime FechaAcreditacion
                {
                        get
                        {
                                return this.FieldDateTime("fecha_acred");
                        }
                        set
                        {
                                this.Registro["fecha_acred"] = value;
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

                public bool Anulado
                {
                        get
                        {
                                return this.Estado == ((int)(Lbl.Pagos.EstadosCupones.Anulado));
                        }
                }

                public Pagos.FormaDePago FormaDePago
                {
                        get
                        {
                                if (m_FormaDePago == null && this.GetFieldValue<int>("id_tarjeta") > 0)
                                        m_FormaDePago = new Pagos.FormaDePago(this.Connection, this.GetFieldValue<int>("id_tarjeta"));

                                return m_FormaDePago;
                        }
                        set
                        {
                                m_FormaDePago = value;
                                this.SetFieldValue("id_tarjeta", m_FormaDePago);
                        }
                }


                public Cajas.Concepto Concepto
                {
                        get
                        {
                                if (m_Concepto == null && this.GetFieldValue<int>("id_concepto") > 0)
                                        m_Concepto = new Cajas.Concepto(this.Connection, this.GetFieldValue<int>("id_concepto"));

                                return m_Concepto;
                        }
                        set
                        {
                                m_Concepto = value;
                                this.SetFieldValue("id_concepto", m_Concepto);
                        }
                }


                public Plan Plan
                {
                        get
                        {
                                if (m_Plan == null && this.GetFieldValue<int>("id_plan") > 0)
                                        m_Plan = new Plan(this.Connection, this.GetFieldValue<int>("id_plan"));

                                return m_Plan;
                        }
                        set
                        {
                                m_Plan = value;
                                this.SetFieldValue("id_plan", m_Plan);
                        }
                }


                public Comprobantes.Recibo Recibo
                {
                        get
                        {
                                if (m_Recibo == null && this.GetFieldValue<int>("id_recibo") > 0)
                                        m_Recibo = new Comprobantes.Recibo(this.Connection, this.GetFieldValue<int>("id_recibo"));

                                return m_Recibo;
                        }
                        set
                        {
                                m_Recibo = value;
                                this.SetFieldValue("id_recibo", m_Recibo);
                        }
                }


                public Comprobantes.ComprobanteConArticulos Factura
                {
                        get
                        {
                                if (m_Factura == null && this.GetFieldValue<int>("id_comprob") > 0)
                                        m_Factura = new Comprobantes.ComprobanteConArticulos(this.Connection, this.GetFieldValue<int>("id_comprob"));

                                return m_Factura;
                        }
                        set
                        {
                                m_Factura = value;
                                this.SetFieldValue("id_comprob", m_Factura);
                        }
                }


                public Personas.Persona Cliente
                {
                        get
                        {
                                if (m_Cliente == null && this.GetFieldValue<int>("id_cliente") > 0)
                                        m_Cliente = new Personas.Persona(this.Connection, this.GetFieldValue<int>("id_cliente"));

                                return m_Cliente;
                        }
                        set
                        {
                                m_Cliente = value;
                                this.SetFieldValue("id_cliente", m_Cliente);
                        }
                }

                public Personas.Persona Vendedor
                {
                        get
                        {
                                if (m_Vendedor == null && this.GetFieldValue<int>("id_vendedor") > 0)
                                        m_Vendedor = new Personas.Persona(this.Connection, this.GetFieldValue<int>("id_vendedor"));

                                return m_Vendedor;
                        }
                        set
                        {
                                m_Vendedor = value;
                                this.SetFieldValue("id_vendedor", m_Vendedor);
                        }
                }


                public void Presentar()
                {
                        qGen.Update ActualizarEstado = new qGen.Update(this.TablaDatos);
                        ActualizarEstado.Fields.AddWithValue("estado", 10);
                        ActualizarEstado.Fields.AddWithValue("fecha_pres", qGen.SqlFunctions.Now);
                        ActualizarEstado.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        this.Connection.Execute(ActualizarEstado);
                }


                public void Acreditar()
                {
                        qGen.Update ActualizarEstado = new qGen.Update(this.TablaDatos);
                        ActualizarEstado.Fields.AddWithValue("estado", 20);
                        ActualizarEstado.Fields.AddWithValue("fecha_acred", qGen.SqlFunctions.Now);
                        ActualizarEstado.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        this.Connection.Execute(ActualizarEstado);
                }


		public override string ToString()
		{
			string Res = this.Registro["numero"].ToString();
			if(FormaDePago != null)
				Res += " de " + FormaDePago.ToString();

			return Res;
		}

		public override Lfx.Types.OperationResult Guardar()
		{
                        if (this.Existe == false) {
                                if (this.FormaDePago != null && this.FormaDePago.AutoPresentacion) {
                                        this.Estado = 10;
                                        this.FechaPresentacion = System.DateTime.Now;
                                }
                        }

			qGen.TableCommand Comando;

                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.Connection, this.TablaDatos);
                                Comando.Fields.AddWithValue("fecha", qGen.SqlFunctions.Now);
                        } else {
                                Comando = new qGen.Update(this.Connection, this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.Fields.AddWithValue("nombre", this.Numero + " de " + this.FormaDePago.ToString());
			Comando.Fields.AddWithValue("numero", this.Numero);
                        
                        if (this.Concepto == null)
                                Comando.Fields.AddWithValue("id_concepto", null);
                        else
                                Comando.Fields.AddWithValue("id_concepto", this.Concepto.Id);

                        if (this.ConceptoTexto == null || this.ConceptoTexto.Length == 0) {
				if (this.Concepto == null)
					Comando.Fields.AddWithValue("concepto", "");
				else
                                	Comando.Fields.AddWithValue("concepto", this.Concepto.Nombre);
			} else {
                                Comando.Fields.AddWithValue("concepto", this.ConceptoTexto);
			}

			Comando.Fields.AddWithValue("autorizacion", this.Autorizacion);
                        
                        if (this.FormaDePago != null)
                                Comando.Fields.AddWithValue("id_tarjeta", this.FormaDePago.Id);
                        else
                                Comando.Fields.AddWithValue("id_tarjeta", null);

			if(this.Plan != null)
				Comando.Fields.AddWithValue("id_plan", this.Plan.Id);
			else
				Comando.Fields.AddWithValue("id_plan", null);

                        if(this.Cliente != null)
                                Comando.Fields.AddWithValue("id_cliente", this.Cliente.Id);
                        else if (this.Recibo != null && this.Recibo.Cliente != null)
                                Comando.Fields.AddWithValue("id_cliente", this.Recibo.Cliente.Id);
                        else
                                Comando.Fields.AddWithValue("id_cliente", null);

                        if (this.Vendedor != null)
                                Comando.Fields.AddWithValue("id_vendedor", this.Vendedor.Id);
                        else if (this.Recibo != null && this.Recibo.Vendedor != null)
                                Comando.Fields.AddWithValue("id_vendedor", this.Recibo.Vendedor.Id);
                        else
                                Comando.Fields.AddWithValue("id_vendedor", null);

                        if (this.Recibo != null)
                                Comando.Fields.AddWithValue("id_recibo", this.Recibo.Id);
                        else
                                Comando.Fields.AddWithValue("id_recibo", null);

                        if (this.Factura == null)
                                Comando.Fields.AddWithValue("id_comprob", null);
                        else
                                Comando.Fields.AddWithValue("id_comprob", this.Factura.Id);

			Comando.Fields.AddWithValue("importe", this.Importe);
			Comando.Fields.AddWithValue("obs", this.Obs);

                        if (this.FechaAcreditacion != null)
                                Comando.Fields.AddWithValue("fecha_acred", this.FechaAcreditacion.Value);
                        else
                                Comando.Fields.AddWithValue("fecha_acred", null);

                        if (this.FechaPresentacion != null)
                                Comando.Fields.AddWithValue("fecha_pres", this.FechaPresentacion.Value);
                        else
                                Comando.Fields.AddWithValue("fecha_pres", null);

                        Comando.Fields.AddWithValue("estado", this.Estado);

			this.AgregarTags(Comando);

			this.Connection.Execute(Comando);

			return new Lfx.Types.SuccessOperationResult();
		}

                public void Anular()
                {
                        if (this.Anulado == false) {
                                // Marco el cheque como anulado
                                qGen.Update Act = new qGen.Update(this.TablaDatos);
                                Act.Fields.AddWithValue("estado", 1);
                                Act.WhereClause = new qGen.Where(this.CampoId, this.Id);
                                this.Connection.Execute(Act);

                                Lbl.Sys.Config.ActionLog(this.Connection, Lbl.Sys.Log.Acciones.Delete, this, null);
                        }
                }
	}
}
