using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Bancos
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Cheque", Grupo = "Cobros y pagos")]
        [Lbl.Atributos.Datos(TablaDatos = "bancos_cheques", CampoId = "id_cheque")]
        [Lbl.Atributos.Presentacion()]
	public class Cheque : ElementoDeDatos
	{
                public Bancos.Banco Banco;
                public Lbl.Comprobantes.Recibo m_Recibo, m_ReciboPago;
                public Lbl.Cajas.Concepto Concepto;
                public Lbl.Personas.Persona Cliente;
                public Lbl.Bancos.Chequera Chequera;
                public Lbl.Comprobantes.ComprobanteConArticulos Factura;
                
                //Heredar constructor
		public Cheque(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

		public Cheque(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Cheque(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                public Cheque(Lfx.Data.IConnection dataBase, Lbl.Comprobantes.ComprobanteConArticulos factura)
                        : this(dataBase)
                {
                        m_ItemId = this.Connection.FieldInt("SELECT MAX(id_cheque) FROM bancos_cheques WHERE id_comprob=" + factura.Id.ToString());
                        this.Cargar();
                }

                public Cheque(Lfx.Data.IConnection dataBase, decimal importe, int numero, string emisor, DbDateTime fechaEmision, DbDateTime fechaCobro, Bancos.Banco banco)
			: this(dataBase)
		{
			this.Importe = importe;
                        this.Numero = numero;
                        this.Emisor = emisor;
                        this.FechaEmision = fechaEmision;
                        this.FechaCobro = fechaCobro;
                        this.Banco = banco;
		}


                public override void OnLoad()
                {
                        if (this.Registro != null) {
                                if (this.GetFieldValue<int>("id_banco") > 0)
                                        this.Banco = new Bancos.Banco(this.Connection, this.GetFieldValue<int>("id_banco"));
                                else
                                        this.Banco = null;

                                if (this.GetFieldValue<int>("id_concepto") > 0)
                                        this.Concepto = new Cajas.Concepto(this.Connection, this.GetFieldValue<int>("id_concepto"));
                                else
                                        this.Concepto = null;

                                if (this.GetFieldValue<int>("id_chequera") > 0)
                                        this.Chequera = new Bancos.Chequera(this.Connection, this.GetFieldValue<int>("id_chequera"));
                                else
                                        this.Chequera = null;

                                if (this.GetFieldValue<int>("id_cliente") > 0)
                                        this.Cliente = new Personas.Persona(this.Connection, this.GetFieldValue<int>("id_cliente"));
                                else
                                        this.Cliente = null;

                                if (this.GetFieldValue<int>("id_comprob") > 0)
                                        this.Factura = new Comprobantes.ComprobanteConArticulos(this.Connection, this.GetFieldValue<int>("id_comprob"));
                                else
                                        this.Factura = null;
                        }
                        base.OnLoad();
                }


                public Lbl.Comprobantes.Recibo ReciboCobro
                {
                        get
                        {
                                if (m_Recibo == null && this.GetFieldValue<int>("id_recibo") > 0)
                                        this.m_Recibo = this.GetFieldValue<Comprobantes.ReciboDeCobro>("id_recibo");
                                return m_Recibo;
                        }
                        set
                        {
                                m_Recibo = value;
                        }
                }


                public Lbl.Comprobantes.Recibo ReciboPago
                {
                        get
                        {
                                if (m_ReciboPago == null && this.GetFieldValue<int>("id_recibo_pago") > 0)
                                        this.m_ReciboPago = this.GetFieldValue<Comprobantes.ReciboDeCobro>("id_recibo_pago");
                                return m_ReciboPago;
                        }
                        set
                        {
                                m_ReciboPago = value;
                        }
                }


		public override string ToString()
		{
			String Res = "Cheque Nº " + Numero;
                        string Emitido = this.Emitido ? " a nombre de " : " emitido por "; 
			if(Banco != null)
				Res += " del " + Banco.ToString();
			if(Emisor != null)
				Res += ", " + Emitido + " " + Emisor;
                        else if (Cliente != null)
                                Res += ", " + Emitido + " " + Cliente.Nombre;

			return Res;
		}

                public bool Emitido
                {
                        get
                        {
                                return this.GetFieldValue<int>("emitido") != 0;
                        }
                        set
                        {
                                this.Registro["emitido"] = value ? 1 : 0;
                        }
                }

                public string Emisor
                {
                        get
                        {
                                return this.GetFieldValue<string>("emitidopor");
                        }
                        set
                        {
                                this.Registro["emitidopor"] = value;
                        }
                }

                public void Pagar(Lbl.Cajas.Caja cajaOrigen)
                {
                        cajaOrigen.Movimiento(true, this.Concepto,
                                                this.Concepto.Nombre,
                                                this.Cliente, -this.Importe,
                                                "Pago de " + this.ToString(),
                                                null,
                                                this.ReciboCobro != null ? this.ReciboCobro : this.ReciboPago,
                                                null);

                        qGen.Update ActualizarEstado = new qGen.Update(this.TablaDatos);
                        ActualizarEstado.ColumnValues.AddWithValue("estado", 10);
                        ActualizarEstado.WhereClause =new qGen.Where(this.CampoId, this.Id);
                        this.Connection.Execute(ActualizarEstado);
                }

                public int Numero
                {
                        get
                        {
                                return this.GetFieldValue<int>("numero");
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

                public DbDateTime FechaEmision
                {
                        get
                        {
                                return this.FieldDateTime("fechaemision");
                        }
                        set
                        {
                                this.Registro["fechaemision"] = value;
                        }
                }

                public DbDateTime FechaCobro
                {
                        get
                        {
                                return this.FieldDateTime("fechacobro");
                        }
                        set
                        {
                                this.Registro["fechacobro"] = value;
                        }
                }

                public bool Anulado
                {
                        get
                        {
                                return this.Estado == 90;
                        }
                }


                public Lfx.Types.OperationResult Entregar(Lbl.Comprobantes.Recibo reciboDePago)
                {
                        this.Estado = 11;
                        this.AgregarComentario("Entregado s/" + reciboDePago.ToString());
                        this.ReciboPago = reciboDePago;
                        return this.Guardar();
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
                        if (this.Concepto == null)
                                Comando.ColumnValues.AddWithValue("id_concepto", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_concepto", this.Concepto.Id);

                        if (this.ConceptoTexto == null || this.ConceptoTexto.Length == 0) {
				if (this.Concepto == null)
					Comando.ColumnValues.AddWithValue("concepto", "");
				else
                                	Comando.ColumnValues.AddWithValue("concepto", this.Concepto.Nombre);
			} else {
                                Comando.ColumnValues.AddWithValue("concepto", this.ConceptoTexto);
			}

                        if (this.Banco == null)
                                Comando.ColumnValues.AddWithValue("id_banco", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_banco", this.Banco.Id);

                        if (this.Chequera == null)
                                Comando.ColumnValues.AddWithValue("id_chequera", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_chequera", this.Chequera.Id);

			Comando.ColumnValues.AddWithValue("numero", this.Numero);
			Comando.ColumnValues.AddWithValue("id_sucursal", Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual);

                        if (this.ReciboCobro == null)
                                Comando.ColumnValues.AddWithValue("id_recibo", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_recibo", this.ReciboCobro.Id);

                        if (this.ReciboPago == null)
                                Comando.ColumnValues.AddWithValue("id_recibo_pago", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_recibo_pago", this.ReciboPago.Id);

                        if (this.Cliente == null && this.ReciboCobro != null)
                                this.Cliente = this.ReciboCobro.Cliente;
                        if (this.Cliente == null && this.ReciboPago != null)
                                this.Cliente = this.ReciboPago.Cliente;

                        if (this.Cliente == null)
                                Comando.ColumnValues.AddWithValue("id_cliente", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_cliente", this.Cliente.Id);
                        
                        if (this.Factura == null)
                                Comando.ColumnValues.AddWithValue("id_comprob", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_comprob", this.Factura.Id);

                        if (this.Emitido)
                                Comando.ColumnValues.AddWithValue("nombre", "Nº " + this.Numero + " por " + Lbl.Sys.Config.Moneda.Simbolo + " " + Lfx.Types.Formatting.FormatCurrency(this.Importe, 2));
                        else
                                Comando.ColumnValues.AddWithValue("nombre", "Nº " + this.Numero + " por " + Lbl.Sys.Config.Moneda.Simbolo + " " + Lfx.Types.Formatting.FormatCurrency(this.Importe, 2) + " emitido por " + this.Emisor);
			Comando.ColumnValues.AddWithValue("importe", this.Importe);
			Comando.ColumnValues.AddWithValue("fechaemision", this.FechaEmision);
			Comando.ColumnValues.AddWithValue("emitidopor", this.Emisor);
                        Comando.ColumnValues.AddWithValue("emitido", this.Emitido ? 1 : 0);
                        Comando.ColumnValues.AddWithValue("estado", this.Estado);
			Comando.ColumnValues.AddWithValue("fechacobro", this.FechaCobro);
			Comando.ColumnValues.AddWithValue("obs", this.Obs);

			this.AgregarTags(Comando);

			this.Connection.Execute(Comando);

                        if (this.Chequera != null) {
                                qGen.Update ActualizarChequeras = new qGen.Update("chequeras");
                                ActualizarChequeras.ColumnValues.AddWithValue("cheques_emitidos", new qGen.SqlExpression("cheques_emitidos+1"));
                                ActualizarChequeras.WhereClause = new qGen.Where("id_chequera", this.Chequera.Id);
                                this.Connection.Execute(ActualizarChequeras);
                        }

                        if (this.Existe == false && this.Emitido == false) {
                                //Asiento en la cuenta cheques, sólo para cheques de cobro
                                Cajas.Caja CajaCheques = new Lbl.Cajas.Caja(this.Connection, Lfx.Workspace.Master.CurrentConfig.Empresa.CajaCheques);
                                Lbl.Personas.Persona UsarCliente = this.Cliente;
                                if (UsarCliente == null && this.Factura != null)
                                        UsarCliente = this.Factura.Cliente;
                                if (UsarCliente == null && this.ReciboCobro != null)
                                        UsarCliente = this.ReciboCobro.Cliente;
                                if (UsarCliente == null && this.ReciboPago != null)
                                        UsarCliente = this.ReciboPago.Cliente;
                                CajaCheques.Movimiento(true, 
                                        this.Concepto, this.ConceptoTexto, 
                                        UsarCliente, 
                                        this.ReciboPago != null ? -this.Importe : this.Importe,
                                        this.ToString(), 
                                        this.Factura, 
                                        this.ReciboCobro != null ? this.ReciboCobro : this.ReciboPago, 
                                        null);
                        }

                        return base.Guardar();
		}

                public void Anular()
                {
                        if (this.Existe && this.Anulado == false) {
                                if (this.Estado == 11)
                                        // Cheque entregado, lo marco de nuevo como activo
                                        this.Estado = 0;
                                else
                                        // Cheque activo, lo marco como anulado
                                        this.Estado = 90;

                                // Marco el recibo como anulado
                                qGen.Update Act = new qGen.Update(this.TablaDatos);
                                Act.ColumnValues.AddWithValue("estado", this.Estado);
                                Act.WhereClause = new qGen.Where(this.CampoId, this.Id);
                                this.Connection.Execute(Act);

                                if (this.Emitido == false) {
                                        //Asiento en la cuenta cheques, sólo para cheques de cobro
                                        Cajas.Caja CajaCheques = new Lbl.Cajas.Caja(this.Connection, Lfx.Workspace.Master.CurrentConfig.Empresa.CajaCheques);
                                        Lbl.Personas.Persona UsarCliente = this.Cliente;
                                        if (UsarCliente == null && this.Factura != null)
                                                UsarCliente = this.Factura.Cliente;
                                        if (UsarCliente == null && this.ReciboCobro != null)
                                                UsarCliente = this.ReciboCobro.Cliente;
                                        if (UsarCliente == null && this.ReciboPago != null)
                                                UsarCliente = this.ReciboPago.Cliente;

                                        string TextoConcepto;
                                        if (this.ReciboCobro != null && string.IsNullOrEmpty(this.ReciboCobro.ConceptoTexto) == false)
                                                TextoConcepto = this.ReciboCobro.ConceptoTexto;
                                        else if (this.ReciboPago != null && string.IsNullOrEmpty(this.ReciboPago.ConceptoTexto) == false)
                                                TextoConcepto = this.ReciboPago.ConceptoTexto;
                                        else if (string.IsNullOrEmpty(this.ConceptoTexto) == false)
                                                TextoConcepto = this.ConceptoTexto;
                                        else
                                                TextoConcepto = this.ToString();

                                        CajaCheques.Movimiento(true, 
                                                this.Concepto, 
                                                "Anulación. " + TextoConcepto, 
                                                UsarCliente,
                                                this.Estado == 1 ? this.Importe : -this.Importe, 
                                                null, 
                                                this.Factura, 
                                                this.ReciboCobro != null ? this.ReciboCobro : this.ReciboPago, 
                                                null);
                                }

                                Lbl.Sys.Config.ActionLog(this.Connection, Sys.Log.Acciones.Delete, this, null);
                        }
                }

                public void Efectivizar(Lbl.Cajas.Caja destino, decimal GestionDeCobro, decimal Impuestos)
                {
                        Lbl.Cajas.Caja CajaCheques = new Lbl.Cajas.Caja(Connection, Lfx.Workspace.Master.CurrentConfig.Empresa.CajaCheques);

                        CajaCheques.Movimiento(true, Lbl.Cajas.Concepto.AjustesYMovimientos, "Efectivización de cheque(s)",
                                                null, -this.Importe, this.ToString(), null, null, null);

                        destino.Movimiento(true, Lbl.Cajas.Concepto.AjustesYMovimientos,
                                "Efectivización de cheque(s)", null, this.Importe - GestionDeCobro - Impuestos,
                                this.ToString(), null, null, null);

                        if (GestionDeCobro != 0)
                                destino.Movimiento(true, new Lbl.Cajas.Concepto(this.Connection, 24010), "Gestion de cobro de cheque(s)", null, -GestionDeCobro, this.ToString(), null, null, null);
                        if (Impuestos != 0)
                                destino.Movimiento(true, new Lbl.Cajas.Concepto(this.Connection, 23030), "Impuestos de cheque(s)", null, -Impuestos, this.ToString(), null, null, null);

                        this.Estado = 10;
                        qGen.Update ActualizarEstado = new qGen.Update(this.TablaDatos);
                        ActualizarEstado.ColumnValues.AddWithValue("estado", this.Estado);
                        ActualizarEstado.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        this.Connection.Execute(ActualizarEstado);
                }
	}
}
