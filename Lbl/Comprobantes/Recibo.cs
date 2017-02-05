using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Recibo", Grupo = "Comprobantes")]
        [Lbl.Atributos.Datos(TablaDatos = "recibos", CampoId = "id_recibo", TablaImagenes = "recibos_imagenes")]
        [Lbl.Atributos.Presentacion()]
        public class Recibo : Comprobante
        {
                private ColeccionComprobanteImporte m_Facturas = null;

                //Heredar constructor
                public Recibo(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public Recibo(Lfx.Data.IConnection dataBase, Personas.Persona cliente)
                        : this(dataBase)
                {
                        this.Crear();
                        this.Cliente = cliente;
                }

                public Recibo(Lfx.Data.IConnection dataBase, int idRecibo)
                        : base(dataBase, idRecibo) { }

                public Recibo(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                /// <summary>
                /// Una colección conteniendo las facturas, NC o ND que cancela este recibo.
                /// </summary>
                public ColeccionComprobanteImporte Facturas
                {
                        get
                        {
                                //Cargo comprob asociadas al recibo
                                if (m_Facturas == null || m_Facturas.Count == 0) {
                                        m_Facturas = new ColeccionComprobanteImporte();
                                        using (System.Data.DataTable TablaFacturas = Connection.Select("SELECT * FROM recibos_comprob WHERE id_recibo=" + this.Id.ToString())) {
                                                foreach (System.Data.DataRow Factura in TablaFacturas.Rows) {
                                                        m_Facturas.AddWithValue(new ComprobanteConArticulos(this.Connection, System.Convert.ToInt32(Factura["id_comprob"])), System.Convert.ToDecimal(Factura["importe"]));
                                                }
                                        }
                                }
                                return m_Facturas;
                        }
                        set
                        {
                                m_Facturas = value;
                        }
                }

                public Cajas.Concepto Concepto { get; set; }
                public ColeccionDeCobros Cobros = new ColeccionDeCobros();
                public ColeccionDePagos Pagos = new ColeccionDePagos();

                public override void Crear()
                {
                        base.Crear();
                        
                        this.Fecha = this.Connection.ServerDateTime;

                        Facturas = new ColeccionComprobanteImporte();
                        
                        if (this.Tipo == null)
                                this.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra["RC"];
                        
                        this.PV = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Documentos." + this.Tipo.Nomenclatura + ".PV", Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual);
                        this.Vendedor = new Personas.Persona(this.Connection, Lbl.Sys.Config.Actual.UsuarioConectado.Id);
                }

                public bool DePago
                {
                        get
                        {
                                return this.Tipo != null && this.Tipo.Nomenclatura == "RCP";
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


                public bool Anulado
                {
                        get
                        {
                                return this.Estado == 90;
                        }
                }


                public override string ToString()
                {
                        string Res = this.Tipo.Nombre;
                        if (Numero > 0)
                                Res += " Nº " + this.PV.ToString("0000") + "-" + this.Numero.ToString("00000000");
                        else
                                Res += " S/N";

                        return Res;
                }

                public string ToString(bool incluyeCliente)
                {
                        string Res = this.ToString();

                        if (incluyeCliente && Cliente != null)
                                Res += " de " + Cliente.ToString();

                        return Res;
                }

                public override decimal Total
                {
                        get
                        {
                                decimal Res = 0;
                                if (DePago) {
                                        foreach (Pago Pg in Pagos) {
                                                Res += Pg.Importe;
                                        }
                                } else {
                                        foreach (Cobro Pg in Cobros) {
                                                Res += Pg.Importe;
                                        }
                                }
                                return Res;
                        }
                }

                public override void OnLoad()
                {
                        if (this.Registro != null) {
                                this.Numero = System.Convert.ToInt32(m_Registro["numero"]);
                                this.PV = System.Convert.ToInt32(m_Registro["pv"]);

                                if (m_Registro["id_concepto"] != null)
                                        this.Concepto = new Lbl.Cajas.Concepto(this.Connection, this.GetFieldValue<int>("id_concepto"));
                                else
                                        this.Concepto = null;

                                if (m_Registro["concepto"] != null)
                                        this.ConceptoTexto = m_Registro["concepto"].ToString();
                                else
                                        this.ConceptoTexto = string.Empty;

                                this.Cobros = new ColeccionDeCobros();
                                this.Pagos = new ColeccionDePagos();

                                // Cargo pagos asociados al registro
                                // Pagos en efectivo
                                using (System.Data.DataTable TablaPagos = Connection.Select("SELECT * FROM cajas_movim WHERE id_caja=" + Lfx.Workspace.Master.CurrentConfig.Empresa.CajaDiaria.ToString() + " AND id_recibo=" + Id.ToString())) {
                                        foreach (System.Data.DataRow Pago in TablaPagos.Rows) {
                                                decimal ImporteCaja = System.Convert.ToDecimal(Pago["importe"]);
                                                if (this.DePago && ImporteCaja < 0) {
                                                        Pago Pg = new Pago(this.Connection, Lbl.Pagos.TiposFormasDePago.Efectivo, -ImporteCaja);
                                                        Pg.Recibo = this;
                                                        Pagos.Add(Pg);
                                                } else if (this.DePago == false && ImporteCaja > 0) {
                                                        Cobro Cb = new Cobro(this.Connection, Lbl.Pagos.TiposFormasDePago.Efectivo, ImporteCaja);
                                                        Cb.Recibo = this;
                                                        Cobros.Add(Cb);
                                                }
                                        }
                                }

                                // Pagos con cheque
                                using (System.Data.DataTable TablaPagos = this.Connection.Select("SELECT * FROM bancos_cheques WHERE (id_recibo=" + this.Id.ToString() + " OR id_recibo_pago=" + this.Id.ToString() + ")")) {
                                        foreach (System.Data.DataRow Pago in TablaPagos.Rows) {
                                                Bancos.Cheque Ch = new Lbl.Bancos.Cheque(Connection, (Lfx.Data.Row)Pago);
                                                if (this.DePago)
                                                        Ch.ReciboPago = this;
                                                else
                                                        Ch.ReciboCobro = this;
                                                if (this.DePago)
                                                        Pagos.Add(new Pago(Ch));
                                                else 
                                                        Cobros.Add(new Cobro(Ch));
                                        }
                                }

                                // Pagos con Tarjetas de Crédito y Débito
                                using (System.Data.DataTable TablaPagos = this.Connection.Select("SELECT id_cupon FROM tarjetas_cupones WHERE id_recibo=" + Id.ToString())) {
                                        foreach (System.Data.DataRow Pago in TablaPagos.Rows) {
                                                Pagos.Cupon Cp = new Pagos.Cupon(Connection, System.Convert.ToInt32(Pago["id_cupon"]));
                                                Cobros.Add(new Cobro(Cp));
                                        }
                                }

                                // Acreditaciones en cuenta regular (excepto caja diaria)
                                using (System.Data.DataTable TablaPagos = this.Connection.Select("SELECT * FROM cajas_movim WHERE auto=1 AND id_caja<>" + Lfx.Workspace.Master.CurrentConfig.Empresa.CajaDiaria.ToString() + " AND id_caja<>" + Lfx.Workspace.Master.CurrentConfig.Empresa.CajaCheques.ToString() + " AND id_recibo=" + this.Id.ToString())) {
                                        foreach (System.Data.DataRow Pago in TablaPagos.Rows) {
                                                if (this.DePago) {
                                                        Pago Pg = new Pago(this.Connection, Lbl.Pagos.TiposFormasDePago.Caja, Math.Abs(System.Convert.ToDecimal(Pago["importe"])));
                                                        Pg.Recibo = this;
                                                        Pg.CajaOrigen = new Cajas.Caja(Connection, System.Convert.ToInt32(Pago["id_caja"]));
                                                        Pagos.Add(Pg);
                                                } else {
                                                        Cobro Cb = new Cobro(this.Connection, Lbl.Pagos.TiposFormasDePago.Caja, System.Convert.ToDecimal(Pago["importe"]));
                                                        Cb.Recibo = this;
                                                        Cb.CajaDestino = new Cajas.Caja(Connection, System.Convert.ToInt32(Pago["id_caja"]));
                                                        Cobros.Add(Cb);
                                                }
                                        }
                                }

                                // Otros valores
                                using (System.Data.DataTable TablaPagos = this.Connection.Select("SELECT id_valor FROM pagos_valores WHERE id_recibo=" + Id.ToString())) {
                                        foreach (System.Data.DataRow Pago in TablaPagos.Rows) {
                                                Lbl.Pagos.Valor Vl = new Lbl.Pagos.Valor(Connection, System.Convert.ToInt32(Pago["id_valor"]));
                                                Vl.Recibo = this;
                                                if (this.DePago)
                                                        Pagos.Add(new Pago(Vl));
                                                else
                                                        Cobros.Add(new Cobro(Vl));
                                        }
                                }
                        }
                        base.OnLoad();
                }

                public override Lfx.Types.OperationResult Guardar()
                {
                        this.Cliente.Connection = this.Connection;
                        if (this.Facturas != null) {
                                foreach (Lbl.Comprobantes.ComprobanteImporte Comp in this.Facturas) {
                                        Comp.Comprobante.Connection = this.Connection;
                                }
                        }

                        if (this.Concepto == null) {
                                //Concepto predeterminado para recibos
                                if (this.DePago)
                                        //Compra de mercadería
                                        this.Concepto = new Lbl.Cajas.Concepto(this.Connection, 21000);
                                else
                                        //Ingresos por facturación
                                        this.Concepto = Lbl.Cajas.Concepto.IngresosPorFacturacion;
                        } else {
                                this.Concepto.Connection = this.Connection;
                        }
                        if (this.Tipo.NumerarAlGuardar) {
                                new Lbl.Comprobantes.Numerador(this).Numerar(false);
                        }

                        // Asiento el recibo
                        qGen.IStatement Comando;

                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.TablaDatos);
                                Comando.ColumnValues.AddWithValue("fecha", qGen.SqlFunctions.Now);
                        } else {
                                throw new Lfx.Types.DomainException("Lbl: No se puede cambiar un recibo impreso");
                        }

                        if (this.Concepto != null)
                                Comando.ColumnValues.AddWithValue("id_concepto", this.Concepto.Id);
                        else
                                Comando.ColumnValues.AddWithValue("id_concepto", null);

                        Comando.ColumnValues.AddWithValue("concepto", this.ConceptoTexto);
                        Comando.ColumnValues.AddWithValue("tipo_fac", this.Tipo.Nomenclatura);
                        Comando.ColumnValues.AddWithValue("pv", this.PV);
                        Comando.ColumnValues.AddWithValue("numero", this.Numero);
                        Comando.ColumnValues.AddWithValue("nombre", this.PV.ToString("0000") + "-" + this.Numero.ToString("00000000"));
                        Comando.ColumnValues.AddWithValue("id_vendedor", Lfx.Data.Connection.ConvertZeroToDBNull(this.Vendedor.Id));
                        Comando.ColumnValues.AddWithValue("id_cliente", Lfx.Data.Connection.ConvertZeroToDBNull(this.Cliente.Id));
                        Comando.ColumnValues.AddWithValue("id_sucursal", Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual);
                        Comando.ColumnValues.AddWithValue("total", this.Total);
                        Comando.ColumnValues.AddWithValue("obs", this.Obs);

                        this.AgregarTags(Comando);

                        this.Connection.Execute(Comando);
                        this.ActualizarId();

                        string ObsPago = string.Empty;
                        if (this.Obs != null && this.Obs.Length > 0)
                                ObsPago += this.Obs + " ///";
                        else if (this.DePago)
                                ObsPago = "Pago";
                        else
                                ObsPago = "Cobro";

                        ObsPago += " s/" + this.ToString(true);

                        if (ConceptoTexto == null || ConceptoTexto.Length == 0)
                                ConceptoTexto = ObsPago;

                        // Asiento los valores
                        foreach (Cobro Pg in this.Cobros) {
                                Pg.Concepto = this.Concepto;
                                Pg.ConceptoTexto = this.ConceptoTexto;
                                switch (Pg.FormaDePago.Tipo) {
                                        case Lbl.Pagos.TiposFormasDePago.Efectivo:
                                                Cajas.Caja CajaDiaria = new Cajas.Caja(this.Connection, Lfx.Workspace.Master.CurrentConfig.Empresa.CajaDiaria);
                                                CajaDiaria.Movimiento(true, this.Concepto, this.ConceptoTexto, Cliente, Pg.Importe, ObsPago, null, this, string.Empty);
                                                break;
                                        case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                                        case Lbl.Pagos.TiposFormasDePago.ChequeTerceros:
                                                Pg.Cheque.Connection = this.Connection;
                                                Pg.Cheque.Obs = ObsPago;
                                                Pg.Cheque.Concepto = Pg.Concepto;
                                                Pg.Cheque.ConceptoTexto = Pg.ConceptoTexto;
                                                if (this.DePago)
                                                        Pg.Cheque.ReciboPago = this;
                                                else
                                                        Pg.Cheque.ReciboCobro = this;
                                                Pg.Cheque.Cliente = this.Cliente;
                                                Pg.Cheque.Emitido = Pg.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.ChequePropio;
                                                Lfx.Types.OperationResult ResultadoCheque = Pg.Cheque.Guardar();
                                                if (ResultadoCheque.Success == false)
                                                        return ResultadoCheque;
                                                break;
                                        case Lbl.Pagos.TiposFormasDePago.Tarjeta:
                                                Pg.Cupon.Connection = this.Connection;
                                                Pg.Cupon.Obs = ObsPago;
                                                Pg.Cupon.ConceptoTexto = Pg.ConceptoTexto;
                                                Pg.Cupon.Recibo = this;
                                                Pg.Cupon.Cliente = this.Cliente;
                                                Lfx.Types.OperationResult ResultadoCupon = Pg.Cupon.Guardar();
                                                if (ResultadoCupon.Success == false)
                                                        return ResultadoCupon;
                                                break;
                                        case Lbl.Pagos.TiposFormasDePago.Caja:
                                                Pg.CajaDestino.Connection = this.Connection;
                                                Pg.CajaDestino.Movimiento(true, Pg.Concepto, Pg.ConceptoTexto, this.Cliente, Pg.Importe, ObsPago, null, this, string.Empty);
                                                break;
                                        case Lbl.Pagos.TiposFormasDePago.OtroValor:
                                                Pg.Valor.Connection = this.Connection;
                                                Pg.Valor.Obs = ObsPago;
                                                Pg.Valor.Recibo = this;
                                                Lfx.Types.OperationResult ResultadoValor = Pg.Valor.Guardar();
                                                if (ResultadoValor.Success == false)
                                                        return ResultadoValor;
                                                break;
                                }
                        }

                        foreach (Pago Pg in this.Pagos) {
                                Pg.Concepto = this.Concepto;
                                Pg.ConceptoTexto = this.ConceptoTexto;
                                switch (Pg.FormaDePago.Tipo) {
                                        case Lbl.Pagos.TiposFormasDePago.Efectivo:
                                                Cajas.Caja CajaDiaria = new Cajas.Caja(this.Connection, Lfx.Workspace.Master.CurrentConfig.Empresa.CajaDiaria);
                                                CajaDiaria.Movimiento(true, Pg.Concepto, Pg.ConceptoTexto, this.Cliente, -Pg.Importe, ObsPago, null, this, string.Empty);
                                                break;
                                        case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                                                Pg.Cheque.Connection = this.Connection;
                                                Pg.Cheque.Concepto = Pg.Concepto;
                                                Pg.Cheque.Cliente = this.Cliente;
                                                Pg.Cheque.ConceptoTexto = Pg.ConceptoTexto;
                                                Pg.Cheque.Obs = ObsPago;
                                                Pg.Cheque.Emitido = true;
                                                Pg.Cheque.ReciboPago = this;
                                                Lfx.Types.OperationResult ResultadoCheque = Pg.Cheque.Guardar();
                                                if (ResultadoCheque.Success == false)
                                                        return ResultadoCheque;
                                                break;
                                        case Lbl.Pagos.TiposFormasDePago.Caja:
                                                Pg.CajaOrigen.Connection = this.Connection;
                                                Pg.CajaOrigen.Movimiento(true, Pg.Concepto, Pg.ConceptoTexto, this.Cliente, -Pg.Importe, ObsPago, null, this, string.Empty);
                                                break;
                                        case Lbl.Pagos.TiposFormasDePago.ChequeTerceros:
                                                Pg.Cheque.Connection = this.Connection;
                                                Lfx.Types.OperationResult ResultadoChequeTerceros = Pg.Cheque.Entregar(this);
                                                if (ResultadoChequeTerceros.Success == false)
                                                        return ResultadoChequeTerceros;
                                                break;
                                        case Lbl.Pagos.TiposFormasDePago.OtroValor:
                                                Pg.Valor.Connection = this.Connection;
                                                Pg.Valor.Estado = 11;
                                                if (Pg.Valor.Obs.Length > 0)
                                                        Pg.Valor.Obs += " /// ";
                                                Pg.Valor.Obs += "Entregado s/" + this.ToString();
                                                Pg.Valor.Recibo = this;
                                                Pg.Valor.Guardar();
                                                Lfx.Types.OperationResult ResultadoValor = Pg.Valor.Guardar();
                                                if (ResultadoValor.Success == false)
                                                        return ResultadoValor;
                                                break;
                                }
                        }

                        CancelarImpagos(this.Cliente, this.Facturas, this, this.DePago ? -this.Total : this.Total);
                        this.Cliente.CuentaCorriente.Movimiento(true, this.Concepto, this.ConceptoTexto, this.DePago ? this.Total : -this.Total, this.Obs, null, this, this.ToString());

                        base.Guardar();

                        return new Lfx.Types.SuccessOperationResult();
                }


                /// <summary>
                /// Cancela el importe impago de los comprobantes en listaComprob y si sobra continúa cancelando en los comprobantes
                /// más viejos que tengan saldo pendiente. Si continúa sobrando, deja el saldo a favor en cta. cte.
                /// </summary>
                /// <param name="cliente">El cliente.</param>
                /// <param name="listaComprob">La lista de comprobantes en los cuales cancelar saldo impago.</param>
                /// <param name="comprob">El comprobante que está cancelando saldos. Puede ser un recibo o una NC.</param>
                /// <param name="importe">El importe total a cancelar. Puede ser negativo para hacerlo en contra del cliente.</param>
                public static decimal CancelarImpagos(Lbl.Personas.Persona cliente, ColeccionComprobanteImporte listaComprob, Lbl.Comprobantes.Comprobante comprob, decimal importe)
                {
                        decimal TotalACancelar = Math.Abs(importe);

                        if (listaComprob != null && listaComprob.Count > 0) {
                                // Si hay una lista de facturas, las cancelo
                                foreach (ComprobanteImporte CompImp in listaComprob) {
                                        // Calculo cuanto queda por cancelar en esta factura
                                        decimal ImportePendiente = CompImp.Comprobante.Total - CompImp.Comprobante.ImporteCancelado;

                                        // Intento cancelar todo
                                        decimal Cancelando = ImportePendiente;

                                        // Si se acabó la plata, hago un pago parcial
                                        if (Cancelando > TotalACancelar)
                                                Cancelando = TotalACancelar;

                                        // Si alcanzo a cancelar algo, lo asiento
                                        if (Cancelando > 0)
                                                CompImp.Comprobante.CancelarImporte(Cancelando, comprob);
                                        
                                        CompImp.Importe = Cancelando;

                                        TotalACancelar -= Cancelando;
                                        if (TotalACancelar <= 0)
                                                break;
                                }
                        }

                        if (TotalACancelar > 0) {
                                // Si queda más saldo, sigo buscando facturas a cancelar
                                qGen.Select SelFacConSaldo = new qGen.Select("comprob");
                                SelFacConSaldo.WhereClause = new qGen.Where();
                                SelFacConSaldo.WhereClause.AddWithValue("impresa", qGen.ComparisonOperators.NotEqual, 0);
                                SelFacConSaldo.WhereClause.AddWithValue("anulada", 0);
                                SelFacConSaldo.WhereClause.AddWithValue("numero", qGen.ComparisonOperators.GreaterThan, 0);
                                SelFacConSaldo.WhereClause.AddWithValue("id_formapago", qGen.ComparisonOperators.In, new int[] { 1, 3, 99 });
                                SelFacConSaldo.WhereClause.AddWithValue("cancelado", qGen.ComparisonOperators.LessThan, new qGen.SqlExpression("total"));
                                SelFacConSaldo.WhereClause.AddWithValue("id_cliente", cliente.Id);
                                SelFacConSaldo.WhereClause.AddWithValue("tipo_fac", qGen.ComparisonOperators.In, new string[] { "FA", "FB", "FC", "FE", "FM", "NDA", "NDB", "NDC", "NDE", "NDM" });
                                if (importe > 0) {
                                        // Cancelo facturas y ND regulares
                                        SelFacConSaldo.WhereClause.AddWithValue("compra", 0);
                                } else {
                                        // Cancelo facturas y de compra
                                        SelFacConSaldo.WhereClause.AddWithValue("compra", qGen.ComparisonOperators.NotEqual, 0);
                                }
                                SelFacConSaldo.Order = "id_comprob";
                                using (System.Data.DataTable FacturasConSaldo = cliente.Connection.Select(SelFacConSaldo)) {
                                        foreach (System.Data.DataRow Factura in FacturasConSaldo.Rows) {
                                                Lbl.Comprobantes.ComprobanteConArticulos Fact = new ComprobanteConArticulos(cliente.Connection, (Lfx.Data.Row)Factura);

                                                decimal SaldoFactura = Fact.ImporteImpago;
                                                decimal ImporteASaldar = SaldoFactura;

                                                if (ImporteASaldar > TotalACancelar)
                                                        ImporteASaldar = TotalACancelar;

                                                listaComprob.AddWithValue(Fact, ImporteASaldar);
                                                Fact.CancelarImporte(ImporteASaldar, comprob);

                                                TotalACancelar -= ImporteASaldar;

                                                if (TotalACancelar <= 0)
                                                        break;
                                        }
                                }
                        }

                        /* if (TotalACancelar > 0) {
                                Lbl.Cajas.Concepto Conc;
                                if (comprob is Recibo)
                                        Conc = ((Recibo)comprob).Concepto;
                                else
                                        Conc = Lbl.Cajas.Concepto.IngresosPorFacturacion;
                                cliente.CuentaCorriente.Movimiento(true, Conc, "Saldo s/" + comprob.ToString(), TotalACancelar * DireccionCtaCte, comprob.Obs, comprob as Lbl.Comprobantes.ComprobanteConArticulos, comprob as Lbl.Comprobantes.Recibo, null);
                                cliente.CuentaCorriente.CancelarComprobantesConSaldo(TotalACancelar * -DireccionCtaCte, true);
                                TotalACancelar = 0;
                        } */

                        // Devuelvo el sobrante
                        return TotalACancelar;
                }


                public static decimal DescancelarImpagos(Lbl.Personas.Persona cliente, Lbl.Comprobantes.ColeccionComprobanteImporte listaComprob, Lbl.Comprobantes.Comprobante comprob, decimal importe)
                {
                        // Doy los comprob por cancelados
                        decimal TotalACancelar = Math.Abs(importe);

                        //"Descancelo" comprob
                        if (listaComprob != null && listaComprob.Count > 0) {
                                // Si hay una lista de comprob, los descancelo
                                foreach (ComprobanteImporte CompImp in listaComprob) {
                                        // Intento descancelar todo
                                        decimal Cancelando = CompImp.Importe;

                                        // Si mes demasiado, hago un pago parcial
                                        if (Cancelando > CompImp.Comprobante.ImporteCancelado)
                                                Cancelando = CompImp.Comprobante.ImporteCancelado;

                                        // Si se acabó la plata, hago un pago parcial
                                        if (Cancelando > TotalACancelar)
                                                Cancelando = TotalACancelar;

                                        // Si alcanzo a cancelar algo, lo asiento
                                        if (Cancelando > 0)
                                                CompImp.Comprobante.DescancelarImporte(Cancelando, comprob);

                                        TotalACancelar = TotalACancelar - Cancelando;
                                        if (TotalACancelar == 0)
                                                break;
                                }
                        }

                        if (TotalACancelar > 0) {
                                // Si queda más saldo, sigo buscando facturas a descancelar
                                qGen.Select SelFacConSaldo = new qGen.Select("comprob");
                                SelFacConSaldo.WhereClause = new qGen.Where();
                                SelFacConSaldo.WhereClause.AddWithValue("impresa", qGen.ComparisonOperators.NotEqual, 0);
                                SelFacConSaldo.WhereClause.AddWithValue("anulada", 0);
                                SelFacConSaldo.WhereClause.AddWithValue("numero", qGen.ComparisonOperators.GreaterThan, 0);
                                SelFacConSaldo.WhereClause.AddWithValue("id_formapago", qGen.ComparisonOperators.In, new int[] { 1, 3, 99 });
                                SelFacConSaldo.WhereClause.AddWithValue("cancelado", qGen.ComparisonOperators.GreaterThan, 0);
                                SelFacConSaldo.WhereClause.AddWithValue("id_cliente", cliente.Id);
                                SelFacConSaldo.WhereClause.AddWithValue("tipo_fac", qGen.ComparisonOperators.In, new string[] { "FA", "FB", "FC", "FE", "FM", "NDA", "NDB", "NDC", "NDE", "NDM" });
                                if (importe > 0) {
                                        // Cancelo facturas y ND regulares
                                        SelFacConSaldo.WhereClause.AddWithValue("compra", 0);
                                } else {
                                        // Cancelo facturas y de compra
                                        SelFacConSaldo.WhereClause.AddWithValue("compra", qGen.ComparisonOperators.NotEqual, 0);
                                }
                                SelFacConSaldo.Order = "id_comprob DESC";
                                using (System.Data.DataTable FacturasConSaldo = cliente.Connection.Select(SelFacConSaldo)) {
                                        foreach (System.Data.DataRow Factura in FacturasConSaldo.Rows) {
                                                Lbl.Comprobantes.ComprobanteConArticulos Fact = new ComprobanteConArticulos(cliente.Connection, (Lfx.Data.Row)Factura);

                                                decimal SaldoFactura = Fact.ImporteCancelado;
                                                decimal ImporteASaldar = SaldoFactura;

                                                if (ImporteASaldar > TotalACancelar)
                                                        ImporteASaldar = TotalACancelar;

                                                Fact.DescancelarImporte(ImporteASaldar, comprob);

                                                TotalACancelar -= ImporteASaldar;

                                                if (TotalACancelar <= 0)
                                                        break;
                                        }
                                }
                        }

                        /* if (TotalACancelar > 0) {
                                Lbl.Cajas.Concepto Conc;
                                if (comprob is Recibo)
                                        Conc = ((Recibo)comprob).Concepto;
                                else
                                        Conc = Lbl.Cajas.Concepto.AjustesYMovimientos;
                                cliente.CuentaCorriente.Movimiento(true, Conc, "Anulación de " + comprob.ToString(), TotalACancelar * DireccionCtaCte, comprob.Obs, comprob as Lbl.Comprobantes.ComprobanteConArticulos, comprob as Lbl.Comprobantes.Recibo, null);
                                TotalACancelar = 0;
                        } */

                        // Devuelvo el sobrante
                        return TotalACancelar;
                }


                public void Anular()
                {
                        if (this.Existe && this.Anulado == false) {
                                this.Estado = 90;

                                // Marco el recibo como anulado
                                qGen.Update Act = new qGen.Update(this.TablaDatos);
                                Act.ColumnValues.AddWithValue("estado", this.Estado);
                                Act.WhereClause = new qGen.Where(this.CampoId, this.Id);
                                this.Connection.Execute(Act);

                                Lbl.Sys.Config.ActionLog(this.Connection, Lbl.Sys.Log.Acciones.Delete, this, null);

                                if (this.DePago) {
                                        foreach (Pago Pg in this.Pagos) {
                                                Pg.Anular();
                                        }
                                } else {
                                        foreach (Cobro Cb in this.Cobros) {
                                                Cb.Anular();
                                        }
                                }

                                DescancelarImpagos(this.Cliente, this.Facturas, this, this.DePago ? -this.Total : this.Total);
                                this.Cliente.CuentaCorriente.Movimiento(true, this.Concepto, "Anulación de " + this.ToString(), this.DePago ? -this.Total : this.Total, this.Obs, null, this, null);
                        }
                }
        }
}
