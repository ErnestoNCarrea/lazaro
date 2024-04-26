using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
    [Lbl.Atributos.Nomenclatura(NombreSingular = "Comprobante con artículos")]
    [Lbl.Atributos.Datos(TablaDatos = "comprob", CampoId = "id_comprob", TablaImagenes = "comprob_imagenes")]
    [Lbl.Atributos.Presentacion(PanelExtendido = Lbl.Atributos.PanelExtendido.Nunca)]

    [Entity(TableName = "comprob", IdFieldName = "id_comprob")]
    public class ComprobanteConArticulos : Comprobante
    {
        private ColeccionComprobanteImporte m_ComprobRelacionados = null;
        private ColeccionDetalleArticulos m_Articulos = null, m_ArticulosOriginales = null;
        private Articulos.Situacion m_SituacionOrigen, m_SituacionDestino;
        //private Lbl.Articulos.Situacion m_SituacionDestinoOriginal = null;
        private ColeccionRecibos m_Recibos = null;
        private Lbl.Pagos.FormaDePago m_FormaDePago = null;

        //Heredar constructor
        public ComprobanteConArticulos(Lfx.Data.IConnection dataBase)
                : base(dataBase) { }

        public ComprobanteConArticulos(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
    : base(dataBase, row) { }

        public ComprobanteConArticulos(Lfx.Data.IConnection dataBase, int itemId)
            : base(dataBase, itemId) { }


        public bool Anulado
        {
            get
            {
                return System.Convert.ToBoolean(this.GetFieldValue<int>("anulada"));
            }
        }


        public override void Crear()
        {
            base.Crear();

            this.ComprobRelacionados = new ColeccionComprobanteImporte();
            if (this.Vendedor == null && Lbl.Sys.Config.Actual.UsuarioConectado != null && Lbl.Sys.Config.Actual.UsuarioConectado.Id > 0)
            {
                this.Vendedor = new Lbl.Personas.Persona(this.Connection, Lbl.Sys.Config.Actual.UsuarioConectado.Id);
            }
        }


        /// <summary>
        /// Una colección con los comprobantes relacionados a este, por ejemplo las facturas o ND canceladas por esta si fuera una NC.
        /// </summary>
        public ColeccionComprobanteImporte ComprobRelacionados
        {
            get
            {
                if (m_ComprobRelacionados == null)
                {
                    m_ComprobRelacionados = new ColeccionComprobanteImporte();
                    using (System.Data.DataTable TablaFacturas = Connection.Select("SELECT * FROM comprob_comprob WHERE id_comprob=" + this.Id.ToString()))
                    {
                        foreach (System.Data.DataRow Factura in TablaFacturas.Rows)
                        {
                            m_ComprobRelacionados.AddWithValue(new ComprobanteConArticulos(this.Connection, System.Convert.ToInt32(Factura["id_comprob_rel"])), System.Convert.ToDecimal(Factura["importe"]));
                        }
                    }
                }
                return m_ComprobRelacionados;
            }
            set
            {
                m_ComprobRelacionados = value;
            }
        }

        public void Anular(bool anularPagos)
        {
            if (this.Anulado)
                return;

            if (string.IsNullOrWhiteSpace(this.CaeNumero) == false)
            {
                throw new InvalidOperationException("No se puede anular un comprobante electrónico.");
            }

            // Marco la factura como anulada
            qGen.Update Act = new qGen.Update(this.TablaDatos);
            Act.ColumnValues.AddWithValue("anulada", 1);
            Act.WhereClause = new qGen.Where(this.CampoId, this.Id);
            this.Connection.ExecuteNonQuery(Act);

            if (anularPagos)
                // Anulos los pagos y descancelo los comprobantes
                this.AsentarPago(true);

            if (this.Tipo.MueveExistencias != 0)
                // Vuelvo el stock a su posición original
                this.MoverExistencias(true);

            Lbl.Sys.Config.ActionLog(this.Connection, Lbl.Sys.Log.Acciones.DeleteAndRevert, this, null);
        }


        public Articulos.Situacion SituacionOrigen
        {
            get
            {
                if (m_SituacionOrigen == null && this.GetFieldValue<int>("situacionorigen") > 0)
                    m_SituacionOrigen = new Lbl.Articulos.Situacion(this.Connection, this.GetFieldValue<int>("situacionorigen"));

                return m_SituacionOrigen;
            }
            set
            {
                m_SituacionOrigen = value;
                this.SetFieldValue("situacionorigen", value);
            }
        }

        public Articulos.Situacion SituacionDestino
        {
            get
            {
                if (m_SituacionDestino == null && this.GetFieldValue<int>("situaciondestino") > 0)
                    m_SituacionDestino = new Lbl.Articulos.Situacion(this.Connection, this.GetFieldValue<int>("situaciondestino"));

                return m_SituacionDestino;
            }
            set
            {
                m_SituacionDestino = value;
                this.SetFieldValue("situaciondestino", value);
            }
        }


        /// <summary>
        /// El total de descuentos, pero en moneda.
        /// </summary>
        public decimal ImporteDescuentos
        {
            get
            {
                if (Lbl.Sys.Config.Moneda.UnidadMonetariaMinima > 0)
                    return Math.Floor((this.Subtotal * this.Descuento / 100m) / Lbl.Sys.Config.Moneda.UnidadMonetariaMinima) * Lbl.Sys.Config.Moneda.UnidadMonetariaMinima;
                else
                    return Math.Round(this.Subtotal * this.Descuento / 100m, Lbl.Sys.Config.Moneda.DecimalesFinal);
            }
        }


        /// <summary>
        /// El total de recargos, pero en moneda.
        /// </summary>
        public decimal ImporteRecargos
        {
            get
            {
                if (Lbl.Sys.Config.Moneda.UnidadMonetariaMinima > 0)
                    return Math.Floor((Subtotal * this.Recargo / 100m) / Lbl.Sys.Config.Moneda.UnidadMonetariaMinima) * Lbl.Sys.Config.Moneda.UnidadMonetariaMinima;
                else
                    return Math.Round(Subtotal * this.Recargo / 100m, Lbl.Sys.Config.Moneda.DecimalesFinal);
            }
        }


        /// <summary>
        /// Devuelve el porcentaje de descuento que se aplicó al comprobante.
        /// </summary>
        public decimal Descuento
        {
            get
            {
                return this.GetFieldValue<decimal>("descuento");
            }
            set
            {
                Registro["descuento"] = value;
            }
        }


        /// <summary>
        /// Devuelve o establece el porcentaje de recargo que se aplicó al comprobante.
        /// </summary>
        public decimal Recargo
        {
            get
            {
                return this.GetFieldValue<decimal>("interes");
            }
            set
            {
                Registro["interes"] = value;
            }
        }

        /// <summary>
        /// Devuelve o establece el importe del comprobante que ya fue cancelado (pagado).
        /// </summary>
        public decimal ImporteCancelado
        {
            get
            {
                return this.GetFieldValue<decimal>("cancelado");
            }
            set
            {
                Registro["cancelado"] = value;
            }
        }

        /// <summary>
        /// Devuelve o establece el importe de los gastos de envío.
        /// </summary>
        public decimal GastosDeEnvio
        {
            get
            {
                return this.GetFieldValue<decimal>("gastosenvio");
            }
            set
            {
                Registro["gastosenvio"] = value;
            }
        }

        /// <summary>
        /// Devuelve o establece el importe de otros gastos.
        /// </summary>
        public decimal OtrosGastos
        {
            get
            {
                return this.GetFieldValue<decimal>("otrosgastos");
            }
            set
            {
                Registro["otrosgastos"] = value;
            }
        }

        /// <summary>
        /// Devuelve True si el comprobante discrimina IVA el los precios de los detalles (por ejemplo en Argentina factura A).
        /// </summary>
        public bool DiscriminaIva
        {
            get
            {
                return this.Tipo.DiscriminaIva;
            }
        }

        /// <summary>
        /// Devuelve True si es un comprobante de compra o false si es un comprobante de venta.
        /// </summary>
        public bool Compra
        {
            get
            {
                return System.Convert.ToBoolean(Registro["compra"]);
            }
            set
            {
                Registro["compra"] = value ? 1 : 0;
            }
        }

        public int Cuotas
        {
            get
            {
                return System.Convert.ToInt32(Registro["cuotas"]);
            }
            set
            {
                Registro["cuotas"] = value;
            }
        }

        /// <summary>
        /// Devuelve True si el comprobante fue cancelado (pagado) en su totalidad.
        /// </summary>
        public bool Cancelado
        {
            get
            {
                return this.Total - this.ImporteCancelado < 0.01m;
            }
        }


        public override Lbl.Impresion.Impresora ObtenerImpresora()
        {
            // Intento obtener una impresora para este PV, esta susursal, para esta estación
            foreach (Lbl.Impresion.TipoImpresora Impr in Tipo.Impresoras)
            {
                if (Impr.Estacion != null && Impr.Estacion.ToUpperInvariant() == Lfx.Environment.SystemInformation.MachineName
                        && Impr.PuntoDeVenta != null && Impr.PuntoDeVenta.Numero == this.PV
                        && Impr.Sucursal != null && Impr.Sucursal.Id == Lbl.Sys.Config.Empresa.SucursalActual.Id)
                    return Impr.Impresora;
            }

            // Caso contrario, obtengo la impresora para este tipo de comprobante
            Lbl.Impresion.Impresora Res = base.ObtenerImpresora();

            if (Res != null)
            {
                return Res;
            }
            else if (this.PV != 0)
            {
                // Si base.ObtenerImpresora() no pudo encontrar nada, busco en el punto de venta
                int IdPv = 0;
                if (Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.ContainsKey(this.PV))
                    IdPv = Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero[this.PV].Id;
                if (IdPv == 0)
                    throw new Lfx.Types.DomainException("No existe el punto de venta " + this.PV.ToString());
                PuntoDeVenta Pun = new PuntoDeVenta(this.Connection, IdPv);
                return Pun.Impresora;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Devuelve el subtotal, que es el importe de los artículos del comprobante, antes de descuentos y recargos.
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                decimal Res = 0;
                foreach (DetalleArticulo Art in this.Articulos)
                {
                    Res += Art.ImporteAImprimir;
                }
                return Math.Round(Res, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
            }
        }

        /// <summary>
        /// Devuelve el subtotal sin IVA final (con descuentos, recargos y redondeos).
        /// </summary>
        public decimal SubtotalSinIvaFinal
        {
            get
            {
                return Math.Round(this.SubtotalSinIva * this.FactorDescuentoORecargo, 4);
            }
        }


        /// <summary>
        /// Devuelve el subtotal sin IVA original (antes de descuentos y recargos).
        /// </summary>
        public decimal SubtotalSinIva
        {
            get
            {
                decimal Res = 0;
                foreach (DetalleArticulo Art in this.Articulos)
                {
                    Res += Math.Round(Art.ImporteSinIvaFinal, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                }
                return Res;
            }
        }


        /// <summary>
        /// Devuelve el descuento o recargo como un factor (por ejemplo 0.9 para descuento de 10% o 1.25 para recargo de 25%).
        /// </summary>
        public decimal FactorDescuentoORecargo
        {
            get
            {
                return (1m + (Recargo - Descuento) / 100m);
            }
        }


        /// <summary>
        /// Devuelve el importe total de la factura, redondeado a la cantidad de decimales configurada para el sistema.
        /// </summary>
        public override decimal Total
        {
            get
            {
                if (this.Existe && this.Modificado == false && this.GetFieldValue<decimal>("total") != 0)
                    return this.GetFieldValue<decimal>("total");
                else
                    return this.RedondearImporte(this.TotalSinRedondeo);
            }
        }


        /// <summary>
        /// Devuelve el importe de la factura, sin redondeos adicionales.
        /// </summary>
        public decimal TotalSinRedondeo
        {
            get
            {
                return Math.Round((this.SubtotalSinIva + this.ImporteIva) * this.FactorDescuentoORecargo, 4);
            }
        }

        /// <summary>
        /// Devuelve el importe que aun está impago.
        /// </summary>
        public decimal ImporteImpago
        {
            get
            {
                return this.Total - this.ImporteCancelado;
            }
        }

        /// <summary>
        /// Devuelve el importe de IVA final (con descuento o recargo) para esta factura.
        /// </summary>
        public decimal ImporteIvaFinal
        {
            get
            {
                return Math.Round(this.ImporteIva * this.FactorDescuentoORecargo, 4);
            }
        }


        /// <summary>
        /// Devuelve el importe de IVA original (antes del descuento) para esta factura.
        /// </summary>
        public decimal ImporteIva
        {
            get
            {
                if (this.Cliente != null)
                {
                    if (this.Cliente.ObtenerSituacionIva() == Impuestos.SituacionIva.Exento)
                        // El cliente está exento de IVA
                        return 0m;
                    else if (this.Cliente.Localidad != null && this.Cliente.Localidad.ObtenerIva() == Impuestos.SituacionIva.Exento)
                        // La localidad o provincia está exenta de IVA
                        return 0m;
                    else if (Lbl.Sys.Config.Empresa.AlicuotaPredeterminada.Id == 4)
                        // Nuestra empresa está exenta de IVA (o soy monotributista y manejo sólo precios finales)
                        return 0m;
                }

                decimal Res = 0m;
                foreach (DetalleArticulo Det in this.Articulos)
                {
                    Res += Det.ImporteIvaUnitarioFinal * Det.Cantidad;
                }
                return this.RedondearImporte(Math.Round(Res, 4));
            }
        }

        /// <summary>
        /// Redondea y trunca un importe según la configuración de decimales y redondeo del sistema.
        /// </summary>
        /// <param name="importe">El importe a redondear.</param>
        /// <returns>El importe redondeado y truncado.</returns>
        public decimal RedondearImporte(decimal importe)
        {
            decimal Redondeo = Lbl.Sys.Config.Moneda.UnidadMonetariaMinima;
            if (this.Compra || Redondeo == 0)
                return Lfx.Types.Currency.Truncate(importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
            else
                return Lfx.Types.Currency.Truncate(Math.Floor(importe / Redondeo) * Redondeo, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
        }

        public Lbl.Pagos.FormaDePago FormaDePago
        {
            get
            {
                if (m_FormaDePago == null && this.GetFieldValue<int>("id_formapago") != 0)
                    m_FormaDePago = new Lbl.Pagos.FormaDePago(this.Connection, this.GetFieldValue<int>("id_formapago"));
                return m_FormaDePago;
            }
            set
            {
                m_FormaDePago = value;
            }
        }

        public int IdRemito
        {
            get
            {
                return this.GetFieldValue<int>("id_remito");
            }
            set
            {
                this.Registro["id_remito"] = value;
            }
        }


        /// <summary>
        /// El número de CAE de AFIP (sólo válido para factura electrónica AFIP).
        /// </summary>
        public string CaeNumero
        {
            get
            {
                return this.GetFieldValue<string>("cae_numero");
            }
            set
            {
                this.Registro["cae_numero"] = value;
            }
        }

        /// <summary>
        /// La fecha de vencimiento del CAE de AFIP (sólo válido para factura electrónica AFIP).
        /// </summary>
        public DateTime CaeVencimiento
        {
            get
            {
                return this.GetFieldValue<DateTime>("cae_vencimiento");
            }
            set
            {
                this.Registro["cae_vencimiento"] = value;
            }
        }


        public decimal ImporteIvaDiscriminadoFinal
        {
            get
            {
                return Math.Round(this.ImporteIvaDiscriminado * this.FactorDescuentoORecargo, 4);
            }
        }


        /// <summary>
        /// Devuelve el importe de IVA discriminado original (antes de descuentos o recargos).
        /// </summary>
        public decimal ImporteIvaDiscriminado
        {
            get
            {
                if (this.Cliente != null && this.Cliente.ObtenerSituacionIva() == Impuestos.SituacionIva.Exento)
                    return 0m;

                if (this.Tipo != null && this.Tipo.DiscriminaIva == false)
                {
                    return 0m;
                }

                decimal Res = 0m;
                foreach (DetalleArticulo Det in this.Articulos)
                {
                    Res += Det.ImporteIvaDiscriminadoFinal;
                }
                return Math.Round(Res, 4);
            }
        }


        /// <summary>
        /// Ídem TotalIvaAlicuota pero con los precios de los artículos incluídos, no sólo el IVA.
        /// </summary>
        public decimal TotalConIvaAlicuota(int idAlicuota)
        {
            decimal Res = 0;
            foreach (DetalleArticulo Det in this.Articulos)
            {
                Res += Det.ImporteConIvaFinalAlicuota(idAlicuota);
            }
            return Math.Round(Res, 4);
        }


        /// <summary>
        /// Devuelve el importe gravado para una alícuota de IVA.
        /// </summary>
        public decimal ImporteGravadoAlicuota(int idAlicuota)
        {
            decimal Res = 0;
            foreach (DetalleArticulo Det in this.Articulos)
            {
                Res += Det.ImporteSinIvaFinalAlicuota(idAlicuota);
            }
            return Math.Round(Res, 4);
        }


        /// <summary>
        /// Devuelve la cantidad de IVA que este comprobante lleva de una alícuota en particular, o 0 si este artículo no se le aplica esa alícuota.
        /// Útil para Paraguay, donde por cada renglón de la factura van dos columnas, una con el importe IVA tasa regular y
        /// otra con la tasa reducida (o cero). Una de las dos columnas puede estar en blanco.
        /// </summary>
        public decimal TotalIvaAlicuota(int idAlicuota)
        {
            /* if (this.Cliente != null && this.Cliente.PagaIva == Impuestos.SituacionIva.Exento)
                    return 0;
            */

            decimal Res = 0;
            foreach (DetalleArticulo Det in this.Articulos)
            {
                Res += Det.ImporteIvaFinalAlicuota(idAlicuota);
            }
            return Math.Round(Res, 4);
        }


        /// <summary>
        /// Devuelve la cantidad de IVA que este comprobante lleva de una alícuota en particular, o 0 si este artículo no se le aplica esa alícuota.
        /// Útil para Paraguay, donde por cada renglón de la factura van dos columnas, una con el importe IVA tasa regular y
        /// otra con la tasa reducida (o cero). Una de las dos columnas puede estar en blanco.
        /// </summary>
        public decimal TotalSinIvaAlicuota(int idAlicuota)
        {
            if (this.Cliente != null && this.Cliente.ObtenerSituacionIva() == Impuestos.SituacionIva.Exento)
                return 0;

            decimal Res = 0;
            foreach (DetalleArticulo Det in this.Articulos)
            {
                Res += Det.ImporteSinIvaFinalAlicuota(idAlicuota);
            }
            return Math.Round(Res, 4);
        }


        /// <summary>
        /// Devuelve una lista con las alícuotas utilizadas en este comprobante.
        /// </summary>
        public Dictionary<int, Lbl.Impuestos.Alicuota> AlicuotasUsadas()
        {
            var Res = new Dictionary<int, Lbl.Impuestos.Alicuota>();

            foreach (DetalleArticulo Det in this.Articulos)
            {
                Lbl.Impuestos.Alicuota Alic;
                if (Det.Articulo != null)
                {
                    Alic = Det.Articulo.ObtenerAlicuota();
                }
                else
                {
                    Alic = Lbl.Sys.Config.Empresa.AlicuotaPredeterminada;
                }
                if (Alic != null && Res.ContainsKey(Alic.Id) == false)
                {
                    Res.Add(Alic.Id, Alic);
                }
            }
            return Res;
        }


        /// <summary>
        /// Asienta los movimientos de stock correspondientes al comprobante.
        /// </summary>
        /// <param name="anulacion">Indica si el movimiento es por anulación de comprobante.</param>
        public void MoverExistencias(bool anulacion)
        {
            if (this.Tipo.MueveExistencias != 0)
            {
                if (this.Tipo.EsRemito || (this.Tipo.EsFacturaNCoND && this.IdRemito == 0))
                {
                    // Es un Remito, factura, NC o ND
                    // Resta lo facturado del stock
                    string NombreMovim = null;

                    if (anulacion)
                        NombreMovim = "Anulación de ";
                    else
                        NombreMovim = "Movimiento s/";

                    string NombreComprob = "comprob. ";

                    if (this.Compra)
                        NombreComprob += "de compra ";

                    foreach (Comprobantes.DetalleArticulo Det in this.Articulos)
                    {
                        if (Det.Articulo != null && Det.Articulo.Id > 0)
                        {
                            if (anulacion)
                            {
                                Det.Articulo.MoverExistencias(this, Det.Cantidad,
                                        NombreMovim + NombreComprob + this.ToString(),
                                        this.SituacionDestino,
                                        this.SituacionOrigen,
                                        Det.DatosSeguimiento);
                            }
                            else
                            {
                                Det.Articulo.MoverExistencias(this, Det.Cantidad,
                                        NombreMovim + NombreComprob + this.ToString(),
                                        this.SituacionOrigen,
                                        this.SituacionDestino,
                                        Det.DatosSeguimiento);
                            }
                        }
                    }
                }
            }
        }


        public void AsentarPago(bool anulacion)
        {
            if (this.FormaDePago == null)
                return;

            decimal ImporteMovim;
            if (anulacion)
                // Al cancelar, desasiento el importe pagado
                ImporteMovim = this.ImporteCancelado;
            else
                // Al ingresar la factura, asiento el importe impago (que normalmente es el total)
                ImporteMovim = this.Total;

            if (this.FormaDePago.Tipo == Pagos.TiposFormasDePago.CuentaCorriente)
                // Si es cuenta corriente muevo siempre el total (incluso al anular)
                ImporteMovim = this.Total;

            if (this.Tipo.DireccionCtaCte < 0)
                // Este tipo de comprobantes hace créditos en cuenta corriente
                ImporteMovim = -ImporteMovim;

            if (this.Compra)
            {
                // Es comprobante de compra, invierto la dirección del movimiento
                ImporteMovim = -ImporteMovim;
            }

            if (anulacion == false)
            {
                // Asiento el pago (sólo efectivo y cta. cte.)
                // El resto de los pagos los maneja el formulario desde donde se mandó a imprimir
                switch (this.FormaDePago.Tipo)
                {
                    case Lbl.Pagos.TiposFormasDePago.Efectivo:
                        if (this.ImporteImpago > 0)
                        {
                            Lbl.Cajas.Caja CajaDiaria = new Lbl.Cajas.Caja(this.Connection, Lfx.Workspace.Master.CurrentConfig.Empresa.CajaDiaria);
                            CajaDiaria.Movimiento(true,
                                    Lbl.Cajas.Concepto.IngresosPorFacturacion,
                                    this.ToString(),
                                    this.Cliente,
                                    ImporteMovim,
                                    null,
                                    this,
                                    null,
                                    null);
                            this.CancelarImporte(this.ImporteImpago, null);
                        }
                        break;
                    case Lbl.Pagos.TiposFormasDePago.CuentaCorriente:
                        this.Cliente.CuentaCorriente.AsentarMovimiento(true,
                                Lbl.Cajas.Concepto.IngresosPorFacturacion,
                                this.ToString(),
                                ImporteMovim,
                                null,
                                this,
                                null,
                                null);
                        if (this.Tipo.EsNotaCredito)
                        {
                            if (this.ComprobRelacionados == null || this.ComprobRelacionados.Count == 0)
                            {
                                // Si no hay comprobantes asociados, pero esta nota de crédito viene de un comprobante anteior
                                // asocio el comprobante original a esta nota de crédito
                                if (this.ComprobanteOriginal != null && this.ComprobanteOriginal.Tipo.EsFacturaOTicket)
                                {
                                    this.ComprobRelacionados = new ColeccionComprobanteImporte();
                                    this.ComprobRelacionados.AddWithValue(this.ComprobanteOriginal, 0);
                                }
                            }
                            Lbl.Comprobantes.Recibo.CancelarImpagos(this.Cliente, this.ComprobRelacionados, this, this.Compra ? -this.Total : this.Total);
                        }

                        decimal FacturaSaldo = this.ImporteImpago;
                        if (FacturaSaldo > 0)
                        {
                            decimal SaldoCtaCteAntes = -(ImporteMovim - this.Cliente.CuentaCorriente.ObtenerSaldo(true));
                            // Busca un saldo en cta cte para cancelar este comprobante
                            if ((ImporteMovim > 0 && SaldoCtaCteAntes < 0) || (ImporteMovim < 0 && SaldoCtaCteAntes > 0))
                            {
                                decimal SaldoACancelar = ImporteMovim < 0 ? SaldoCtaCteAntes : -SaldoCtaCteAntes;

                                if (SaldoACancelar > FacturaSaldo)
                                    SaldoACancelar = FacturaSaldo;

                                // Cancelo la factura con un saldo a favor que tenía en cta. cte.
                                qGen.Update ActualizarComprob = new qGen.Update("comprob");
                                ActualizarComprob.ColumnValues.AddWithValue("cancelado", new qGen.SqlExpression("cancelado+" + Lfx.Types.Formatting.FormatCurrencySql(SaldoACancelar)));
                                ActualizarComprob.WhereClause = new qGen.Where("id_comprob", this.Id);
                                this.Connection.ExecuteNonQuery(ActualizarComprob);
                            }
                        }
                        break;
                }
            }
            else
            {
                // Es una anulación, invierto la dirección del movimiento
                ImporteMovim = -ImporteMovim;

                switch (this.FormaDePago.Tipo)
                {
                    case Lbl.Pagos.TiposFormasDePago.Efectivo:
                        // Hago un movimiento en caja diaria
                        Lbl.Cajas.Caja Caja = new Lbl.Cajas.Caja(Connection, Lfx.Workspace.Master.CurrentConfig.Empresa.CajaDiaria);
                        Caja.Movimiento(true,
                                Lbl.Cajas.Concepto.IngresosPorFacturacion,
                                "Anulación " + this.ToString(),
                                this.Cliente,
                                ImporteMovim,
                                null,
                                this,
                                null,
                                null);
                        break;

                    case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                    case Pagos.TiposFormasDePago.ChequeTerceros:
                        Lbl.Bancos.Cheque Cheque = new Lbl.Bancos.Cheque(Connection, this);
                        if (Cheque != null && Cheque.Existe)
                            Cheque.Anular();
                        break;

                    case Pagos.TiposFormasDePago.Caja:
                        throw new NotImplementedException("No implementado: anular comprobante pagado con depósito en caja.");

                    case Lbl.Pagos.TiposFormasDePago.CuentaCorriente:
                        // Quito el saldo pagado de la cuenta corriente
                        this.Cliente.CuentaCorriente.AsentarMovimiento(true, Lbl.Cajas.Concepto.IngresosPorFacturacion, "Anulación " + this.ToString(), ImporteMovim, null, this, null, null);
                        if (this.Tipo.EsNotaCredito)
                            Lbl.Comprobantes.Recibo.DescancelarImpagos(this.Cliente, this.ComprobRelacionados, this, this.Compra ? -this.Total : this.Total);
                        //this.Cliente.CuentaCorriente.CancelarComprobantesConSaldo(ImporteMovimCtaCte, false);
                        break;

                    case Lbl.Pagos.TiposFormasDePago.Tarjeta:
                    case Pagos.TiposFormasDePago.OtroValor:
                        int IdCupon = this.Connection.FieldInt("SELECT MAX(id_cupon) FROM tarjetas_cupones WHERE id_comprob=" + this.Id.ToString());
                        if (IdCupon > 0)
                        {
                            Lbl.Pagos.Cupon Cupon = new Lbl.Pagos.Cupon(Connection, IdCupon);
                            if (Cupon != null && Cupon.Existe)
                            {
                                Cupon.Anular();
                            }
                        }
                        break;
                }
            }
        }


        public bool HayExistencias()
        {
            //Verifica si hay suficientes existencias para el comprobante
            if (this.Articulos != null)
            {
                foreach (Comprobantes.DetalleArticulo Det in this.Articulos)
                {
                    if (Det.Id > 0 && Det.Articulo != null
                            && Det.Articulo.TipoDeArticulo != Lbl.Articulos.TiposDeArticulo.Servicio
                            && Det.Articulo.Existencias < Det.Cantidad)
                        return false;
                }
            }
            return true;
        }

        public override void OnLoad()
        {
            //this.m_SituacionDestinoOriginal = this.SituacionDestino;
            this.m_ComprobRelacionados = null;

            base.OnLoad();
        }

        public ColeccionDetalleArticulos Articulos
        {
            get
            {
                if (m_Articulos == null)
                {
                    m_Articulos = new ColeccionDetalleArticulos(this);
                    if (this.Existe)
                    {
                        System.Data.DataTable Dets = this.Connection.Select("SELECT * FROM comprob_detalle WHERE id_comprob=" + this.Id.ToString() + " ORDER BY orden");
                        foreach (System.Data.DataRow Det in Dets.Rows)
                        {
                            Comprobantes.DetalleArticulo DetArt = new DetalleArticulo(this, (Lfx.Data.Row)Det);
                            m_Articulos.Add(DetArt);
                        }
                    }
                    this.m_ArticulosOriginales = this.Articulos.Clone();
                }
                return m_Articulos;
            }
            set
            {
                m_Articulos = value;
            }
        }

        public ColeccionRecibos Recibos
        {
            get
            {
                if (m_Recibos == null || m_Recibos.Count == 0)
                {
                    m_Recibos = new ColeccionRecibos();
                    if (this.Existe)
                    {
                        System.Data.DataTable Recs = this.Connection.Select("SELECT id_recibo FROM recibos_comprob WHERE id_comprob=" + this.Id.ToString());
                        foreach (System.Data.DataRow Rec in Recs.Rows)
                        {
                            m_Recibos.Add(new Recibo(Connection, System.Convert.ToInt32(Rec["id_recibo"])));
                        }
                    }
                }
                return m_Recibos;
            }
        }

        public Lfx.Types.OperationResult CancelarImporte(decimal importe, Lbl.Comprobantes.Comprobante comprob)
        {
            if (this.ImporteCancelado + importe > this.Total)
                throw new Lfx.Types.DomainException("ComprobanteConArticulos.CancelarImporte: El importe a cancelar no puede ser mayor que el saldo impago");
            this.ImporteCancelado += importe;
            qGen.Update Actualizar = new qGen.Update("comprob", new qGen.Where("id_comprob", this.Id));
            Actualizar.ColumnValues.AddWithValue("cancelado", this.ImporteCancelado);
            this.Connection.ExecuteNonQuery(Actualizar);

            if (comprob is Lbl.Comprobantes.Recibo)
            {
                qGen.Insert AsentarComprobantesDeEsteRecibo = new qGen.Insert("recibos_comprob");
                AsentarComprobantesDeEsteRecibo.ColumnValues.AddWithValue("id_comprob", this.Id);
                AsentarComprobantesDeEsteRecibo.ColumnValues.AddWithValue("id_recibo", comprob.Id);
                AsentarComprobantesDeEsteRecibo.ColumnValues.AddWithValue("importe", importe);
                this.Connection.ExecuteNonQuery(AsentarComprobantesDeEsteRecibo);
            }
            else if (comprob is Lbl.Comprobantes.ComprobanteConArticulos)
            {
                Lbl.Comprobantes.ComprobanteConArticulos factura = comprob as Lbl.Comprobantes.ComprobanteConArticulos;
                qGen.Insert AsentarComprobantesDeEsteRecibo = new qGen.Insert("comprob_comprob");
                AsentarComprobantesDeEsteRecibo.ColumnValues.AddWithValue("id_comprob", factura.Id);
                AsentarComprobantesDeEsteRecibo.ColumnValues.AddWithValue("id_comprob_rel", this.Id);
                AsentarComprobantesDeEsteRecibo.ColumnValues.AddWithValue("importe", importe);
                this.Connection.ExecuteNonQuery(AsentarComprobantesDeEsteRecibo);
            }
            return new Lfx.Types.SuccessOperationResult();
        }


        public Lfx.Types.OperationResult DescancelarImporte(decimal importe, Lbl.Comprobantes.Comprobante comprob)
        {
            if (importe > this.ImporteCancelado)
                throw new Lfx.Types.DomainException("ComprobanteConArticulos.CancelarImporte: El importe a cancelar no puede ser mayor que el saldo impago");
            this.ImporteCancelado -= importe;
            qGen.Update Actualizar = new qGen.Update("comprob", new qGen.Where("id_comprob", this.Id));
            Actualizar.ColumnValues.AddWithValue("cancelado", this.ImporteCancelado);
            this.Connection.ExecuteNonQuery(Actualizar);

            // Debería eliminar la asociación entre este comprobante y el recibo (o NC) que lo canceló orignalmente?
            return new Lfx.Types.SuccessOperationResult();
        }


        public override Lfx.Types.OperationResult Guardar()
        {
            this.Articulos.ElementoPadre = this;

            qGen.IStatement Comando;
            if (this.Total <= 0)
                return new Lfx.Types.FailureOperationResult("El comprobante debe tener un importe superior a $ 0.00.");

            if (this.Existe == false)
            {
                Comando = new qGen.Insert(this.TablaDatos);
            }
            else
            {
                Comando = new qGen.Update(this.TablaDatos);
                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
            }

            if (this.Existe == false && this.Numero == 0 && this.Tipo.NumerarAlGuardar)
            {
                new Lbl.Comprobantes.Numerador(this).Numerar(false);
            }

            if (this.Fecha.Year == 1)
            {
                Comando.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
            }
            else
            {
                Comando.ColumnValues.AddWithValue("fecha", this.Fecha);
            }

            if (this.ComprobanteOriginal == null)
                Comando.ColumnValues.AddWithValue("id_comprob_orig", null);
            else
                Comando.ColumnValues.AddWithValue("id_comprob_orig", this.ComprobanteOriginal.Id);

            if (this.FormaDePago == null)
                Comando.ColumnValues.AddWithValue("id_formapago", null);
            else
                Comando.ColumnValues.AddWithValue("id_formapago", FormaDePago.Id);

            if (this.Vendedor == null)
                Comando.ColumnValues.AddWithValue("id_vendedor", null);
            else
                Comando.ColumnValues.AddWithValue("id_vendedor", this.Vendedor.Id);

            if (this.Sucursal == null)
                Comando.ColumnValues.AddWithValue("id_sucursal", Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual);
            else
                Comando.ColumnValues.AddWithValue("id_sucursal", this.Sucursal.Id);

            if (this.IdRemito == 0)
                Comando.ColumnValues.AddWithValue("id_remito", null);
            else
                Comando.ColumnValues.AddWithValue("id_remito", this.IdRemito);

            Comando.ColumnValues.AddWithValue("pv", this.PV);
            Comando.ColumnValues.AddWithValue("numero", this.Numero);
            Comando.ColumnValues.AddWithValue("nombre", this.PV.ToString("0000") + "-" + this.Numero.ToString("00000000"));
            Comando.ColumnValues.AddWithValue("id_cliente", Lfx.Data.Connection.ConvertZeroToDBNull(this.Cliente.Id));
            if (this.SituacionOrigen == null)
                Comando.ColumnValues.AddWithValue("situacionorigen", null);
            else
                Comando.ColumnValues.AddWithValue("situacionorigen", this.SituacionOrigen.Id);
            if (this.SituacionDestino == null)
                Comando.ColumnValues.AddWithValue("situaciondestino", null);
            else
                Comando.ColumnValues.AddWithValue("situaciondestino", this.SituacionDestino.Id);
            Comando.ColumnValues.AddWithValue("tipo_fac", this.Tipo.Nomenclatura);
            Comando.ColumnValues.AddWithValue("subtotal", this.SubtotalSinIva);
            Comando.ColumnValues.AddWithValue("descuento", this.Descuento);
            Comando.ColumnValues.AddWithValue("interes", this.Recargo);
            Comando.ColumnValues.AddWithValue("cuotas", this.Cuotas);
            Comando.ColumnValues.AddWithValue("total", this.RedondearImporte(this.TotalSinRedondeo));
            Comando.ColumnValues.AddWithValue("iva", this.ImporteIvaFinal);
            Comando.ColumnValues.AddWithValue("totalreal", this.TotalSinRedondeo);
            Comando.ColumnValues.AddWithValue("gastosenvio", this.GastosDeEnvio);
            Comando.ColumnValues.AddWithValue("otrosgastos", this.OtrosGastos);
            Comando.ColumnValues.AddWithValue("obs", this.Obs);
            // Lo comprobantes de compra se marcan siempre como impresos
            Comando.ColumnValues.AddWithValue("impresa", this.Compra ? 1 : (this.Impreso ? 1 : 0));
            Comando.ColumnValues.AddWithValue("compra", this.Compra ? 1 : 0);
            Comando.ColumnValues.AddWithValue("estado", this.Estado);
            Comando.ColumnValues.AddWithValue("series", this.Articulos.DatosSeguimiento.ToString());

            Comando.ColumnValues.AddWithValue("cae_numero", this.CaeNumero);
            Comando.ColumnValues.AddWithValue("cae_vencimiento", this.CaeVencimiento);

            if (this.Tipo.EsFacturaOTicket == false && this.Tipo.EsNotaDebito == false)
            {
                // Este comprobante no es cancelable
                this.ImporteCancelado = this.Total;
                Comando.ColumnValues.AddWithValue("cancelado", this.Total);
            }

            this.AgregarTags(Comando);

            this.Connection.ExecuteNonQuery(Comando);
            this.ActualizarId();

            this.GuardarDetalle();

            if (this.Compra)
            {
                if (this.Tipo.MueveExistencias != 0)
                {
                    // Comprobantes de compra mueven stock al guardar
                    Lfx.Types.OperationResult Res = VerificarSeries();
                    if (Res.Success == false)
                        return Res;
                }

                if (this.Tipo.EsFacturaNCoND)
                    this.AsentarPago(false);

                if (this.Tipo.MueveExistencias != 0)
                {
                    // Comprobantes de compra mueven stock al guardar
                    this.MoverExistencias(false);

                    Lbl.ListaIds ArticulosAfectados = new Lbl.ListaIds();
                    foreach (DetalleArticulo Det in m_Articulos)
                    {
                        if (Det.IdArticulo != 0 && ArticulosAfectados.Contains(Det.IdArticulo) == false)
                            ArticulosAfectados.Add(Det.IdArticulo);
                    }

                    if (m_ArticulosOriginales != null)
                    {
                        foreach (DetalleArticulo Det in m_ArticulosOriginales)
                        {
                            if (Det.IdArticulo > 0 && ArticulosAfectados.Contains(Det.IdArticulo) == false)
                                ArticulosAfectados.Add(Det.IdArticulo);
                        }
                    }

                    if (ArticulosAfectados.Count > 0)
                    {
                        string ArtCsv = ArticulosAfectados.ToString();
                        // Actualizo cantidades pedidas y a pedir
                        Connection.ExecuteNonQuery(@"UPDATE articulos SET apedir=(
							SELECT SUM(cantidad)
							FROM comprob, comprob_detalle
							WHERE comprob.id_comprob=comprob_detalle.id_comprob
							AND comprob.compra=1
							AND tipo_fac='NP' AND estado=50 AND comprob_detalle.id_articulo=articulos.id_articulo)
						WHERE control_stock=1 AND id_articulo IN (" + ArtCsv + " )");
                        Connection.ExecuteNonQuery(@"UPDATE articulos SET pedido=(
							SELECT SUM(cantidad)
							FROM comprob, comprob_detalle
							WHERE comprob.id_comprob=comprob_detalle.id_comprob
							AND comprob.compra=1
							AND tipo_fac='PD' AND estado=50 AND comprob_detalle.id_articulo=articulos.id_articulo)
						WHERE control_stock=1 AND id_articulo IN (" + ArtCsv + " )");
                    }
                }
            }

            return base.Guardar();
        }

        public Lfx.Types.OperationResult VerificarSeries()
        {
            foreach (Lbl.Comprobantes.DetalleArticulo Art in this.Articulos)
            {
                if (Art.Articulo != null && Art.Articulo.ObtenerSeguimiento() != Lbl.Articulos.Seguimientos.Ninguno)
                {
                    if (Art.DatosSeguimiento == null || Art.DatosSeguimiento.Count == 0)
                    {
                        return new Lfx.Types.FailureOperationResult("Debe ingresar los datos de seguimiento (Ctrl-S) del artículo '" + Art.Nombre + "' para poder realizar movimientos de stock.");
                    }
                    else
                    {
                        if (Art.DatosSeguimiento.CantidadTotal < Art.Cantidad)
                            return new Lfx.Types.FailureOperationResult("Debe ingresar los datos de seguimiento (Ctrl-S) de todos los artículos '" + Art.Nombre + "' para poder realizar movimientos de stock.");
                    }
                }
            }
            return new Lfx.Types.SuccessOperationResult();
        }

        private void GuardarDetalle()
        {
            this.Articulos.ElementoPadre = this;

            qGen.Delete EliminarDetallesViejos = new qGen.Delete("comprob_detalle");
            EliminarDetallesViejos.WhereClause = new qGen.Where("id_comprob", this.Id);
            this.Connection.ExecuteNonQuery(EliminarDetallesViejos);

            int i = 1;
            for (int Pasada = 1; Pasada <= 2; Pasada++)
            {
                foreach (Lbl.Comprobantes.DetalleArticulo Art in m_Articulos)
                {
                    // En la primera pasada, guardo sólo importes y cantidades positivos (o cero)
                    // en la segunda pasada, guardo sólo los negativos.
                    // De esa manera, los negativos siempre quedan últimos
                    // lo cual es un requerimiento de las fiscales Hasar.
                    if ((Pasada == 1 && Art.Cantidad >= 0 && Art.ImporteUnitario >= 0)
                            || (Pasada == 2 && (Art.Cantidad < 0 || Art.ImporteUnitario < 0)))
                    {
                        qGen.IStatement Comando = new qGen.Insert("comprob_detalle");
                        Comando.ColumnValues.AddWithValue("id_comprob", this.Id);
                        Comando.ColumnValues.AddWithValue("orden", i);

                        if (Art.Articulo == null)
                        {
                            Comando.ColumnValues.AddWithValue("id_articulo", null);
                            Comando.ColumnValues.AddWithValue("nombre", Art.Nombre);
                            Comando.ColumnValues.AddWithValue("descripcion", "");
                        }
                        else
                        {
                            Comando.ColumnValues.AddWithValue("id_articulo", Art.Articulo.Id);
                            Comando.ColumnValues.AddWithValue("nombre", Art.Nombre);
                            Comando.ColumnValues.AddWithValue("descripcion", Art.Articulo.Descripcion);
                        }

                        if (Art.Alicuota == null)
                        {
                            Comando.ColumnValues.AddWithValue("id_alicuota", null);
                        }
                        else
                        {
                            Comando.ColumnValues.AddWithValue("id_alicuota", Art.Alicuota.Id);
                        }

                        Comando.ColumnValues.AddWithValue("cantidad", Art.Cantidad);
                        Comando.ColumnValues.AddWithValue("precio", Art.ImporteUnitario);
                        Comando.ColumnValues.AddWithValue("iva", Art.ImporteIvaUnitario);
                        Comando.ColumnValues.AddWithValue("recargo", Art.Recargo);
                        if (Art.Costo == 0 && Art.Articulo != null)
                            Comando.ColumnValues.AddWithValue("costo", Art.Articulo.Costo);
                        else
                            Comando.ColumnValues.AddWithValue("costo", Art.Costo);
                        Comando.ColumnValues.AddWithValue("importe", Art.ImporteAImprimir);
                        Comando.ColumnValues.AddWithValue("total", Art.ImporteTotalConIvaFinal);
                        Comando.ColumnValues.AddWithValue("series", Art.DatosSeguimiento.ToString());
                        Comando.ColumnValues.AddWithValue("obs", Art.Obs);

                        this.AgregarTags(Comando, Art.Registro, "comprob_detalle");

                        this.Connection.ExecuteNonQuery(Comando);
                        i++;
                    }
                }
            }
        }

        public virtual ComprobanteConArticulos Clone(Tipo tipo)
        {
            Type TipoComprob = tipo.ObtenerTipoLbl();
            Lbl.Comprobantes.ComprobanteConArticulos Nuevo = Lbl.Instanciador.Instanciar(TipoComprob, this.Connection) as Lbl.Comprobantes.ComprobanteConArticulos;

            Nuevo.Tipo = this.Tipo;
            Nuevo.Compra = this.Compra;
            Nuevo.Cliente = this.Cliente;
            Nuevo.Descuento = this.Descuento;
            Nuevo.Cuotas = this.Cuotas;
            Nuevo.Estado = this.Estado;
            Nuevo.Fecha = this.Fecha;
            Nuevo.FormaDePago = this.FormaDePago;
            Nuevo.GastosDeEnvio = this.GastosDeEnvio;
            //Nuevo.Imagen = this.Imagen;
            //Nuevo.ImporteCancelado = this.ImporteCancelado;
            //Nuevo.Impreso = this.Impreso;
            Nuevo.Numero = this.Numero;
            Nuevo.IdRemito = this.IdRemito;
            Nuevo.Obs = this.Obs;
            Nuevo.OtrosGastos = this.OtrosGastos;
            Nuevo.PV = this.PV;
            Nuevo.SituacionDestino = this.SituacionDestino;
            Nuevo.SituacionOrigen = this.SituacionOrigen;
            Nuevo.Sucursal = this.Sucursal;
            Nuevo.Articulos = this.Articulos.Clone(Nuevo);
            Nuevo.Vendedor = this.Vendedor;

            return Nuevo;
        }

        public virtual ComprobanteConArticulos Convertir(Tipo tipo)
        {
            Lbl.Comprobantes.ComprobanteConArticulos Nuevo = this.Clone(tipo);
            Nuevo.ComprobanteOriginal = this;
            Nuevo.Estado = 0;
            Nuevo.Impreso = false;
            Nuevo.Numero = 0;
            Nuevo.PV = 0;
            Nuevo.Tipo = tipo;
            Nuevo.Obs = "s/" + this.ToString();
            Nuevo.Compra = this.Compra;
            return Nuevo;
        }


        public override Tipo Tipo
        {
            get
            {
                return base.Tipo;
            }
            set
            {
                base.Tipo = value;

                if (Tipo != null)
                {
                    if (this.Compra)
                    {
                        // Los comprobantes de compra mueven el stock en dirección inversa
                        this.SituacionOrigen = Tipo.SituacionDestino;
                        this.SituacionDestino = Tipo.SituacionOrigen;

                        // Es de compra. Uso "Proveedor" donde usaría "Cliente"
                        if (this.SituacionDestino != null && this.SituacionDestino.Id == 999)
                            this.SituacionDestino = new Lbl.Articulos.Situacion(this.Connection, 998);
                        if (this.SituacionOrigen != null && this.SituacionOrigen.Id == 999)
                            this.SituacionOrigen = new Lbl.Articulos.Situacion(this.Connection, 998);
                    }
                    else
                    {
                        this.SituacionOrigen = Tipo.SituacionOrigen;
                        this.SituacionDestino = Tipo.SituacionDestino;
                    }
                }
            }
        }


        public override string ToString()
        {
            string Res = this.Tipo.ToString();
            if (this.Compra)
                Res += " de compra";
            Res += " Nº " + this.PV.ToString("0000") + "-" + this.Numero.ToString("00000000");
            if (this.Cliente != null)
                Res += " de " + this.Cliente.ToString();
            return Res;
        }
    }
}