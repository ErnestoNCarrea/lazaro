using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;

namespace Lfc.Comprobantes.Facturas
{
        public partial class Editar : Lfc.Comprobantes.Editar
        {
                private bool m_PuedeEditarPago = false;
                public Control ControlDestino = null;

                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Comprobantes.ComprobanteConArticulos);

                        InitializeComponent();

                        this.EntradaCliente.TextChanged += new System.EventHandler(this.EntradaCliente_TextChanged);

                        EntradaProductos.Top = EntradaTipo.Bottom + 8;
                        EntradaProductos.Height = EntradaSubTotal.Top - 8 - EntradaProductos.Top;
                }

                public Editar(string tipo)
                        : this()
                {
                        switch (tipo) {
                                case "F":
                                        TipoPredet = "FB";
                                        break;
                                case "NC":
                                        TipoPredet = "NCB";
                                        break;
                                case "ND":
                                        TipoPredet = "NDB";
                                        break;
                                default:
                                        TipoPredet = tipo;
                                        break;
                        }
                }


                public override Lfx.Types.OperationResult ValidarControl()
                {
                        Lfx.Types.OperationResult Res = base.ValidarControl();

                        if (Res.Success == true) {
                                if (EntradaRemito.Text.Length > 0) {
                                        int RemitoNumero, RemitoPv;
                                        if (EntradaRemito.Text.IndexOfAny(new char[] { '-' }) >= 0) {
                                                // El número de remito tiene guión
                                                string[] Partes = EntradaRemito.Text.Split(new char[] { '-' });
                                                RemitoNumero = Lfx.Types.Parsing.ParseInt(Partes[0]);
                                                RemitoPv = Lfx.Types.Parsing.ParseInt(Partes[1]);
                                        } else {
                                                // El número de remito no tiene guión, asumo el mismo PV que la factura
                                                RemitoNumero = EntradaRemito.ValueInt;
                                                RemitoPv = EntradaPV.ValueInt;
                                        }

                                        int RemitoId = this.Connection.FieldInt("SELECT id_comprob FROM comprob WHERE compra=0 AND tipo_fac!='R' AND pv=" + RemitoPv.ToString() + " AND numero=" + RemitoNumero.ToString() + " AND impresa>0 AND anulada=0");
                                        if (RemitoId == 0) {
                                                Res.Success = false;
                                                Res.Message += "El número de remito no es válido." + Environment.NewLine;
                                        }
                                }

                                Lbl.Pagos.FormaDePago FormaPago = EntradaFormaPago.Elemento as Lbl.Pagos.FormaDePago;
                                Lbl.Comprobantes.Tipo Tipo = new Lbl.Comprobantes.Tipo(this.Connection, EntradaTipo.TextKey);
                                if (FormaPago == null && Tipo.EsFacturaOTicket) {
                                        Res.Success = false;
                                        Res.Message += "Por favor seleccione la forma de pago." + Environment.NewLine;
                                }
                                if (EntradaCliente.ValueInt == 999 && FormaPago != null && FormaPago.Tipo == Lbl.Pagos.TiposFormasDePago.CuentaCorriente) {
                                        Res.Success = false;
                                        Res.Message += @"El cliente ""Consumidor final"" no puede tener una cuenta corriente. Deber facturar a nombre de un cliente identificado para poder usar la cuenta corriente." + Environment.NewLine;
                                }

                                // En Argentina, obligo a ingresar la CUIT
                                Lbl.Personas.Persona Cliente = EntradaCliente.Elemento as Lbl.Personas.Persona;
                                if (Cliente == null) {
                                        Res.Success = false;
                                        Res.Message += "Por favor seleccione un cliente." + Environment.NewLine;
                                } else if (Lbl.Sys.Config.Pais.Id == 1 && Cliente.SituacionTributaria != null && (Cliente.SituacionTributaria.Id == 2 || Cliente.SituacionTributaria.Id == 3)) {
                                        if (Cliente.ClaveTributaria == null || Cliente.ClaveTributaria.EsValido() == false) {
                                                Res.Success = false;
                                                Res.Message += "El cliente debe tener una clave tributaria válida." + Environment.NewLine;
                                        }
                                }
                        }
                        return Res;
                }

                public override void ActualizarControl()
                {
                        Lbl.Comprobantes.ComprobanteConArticulos Res = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;

                        if (this.Tipo.EsFactura || this.Tipo.EsTicket) {
                                List<Lbl.Comprobantes.Tipo> TiposFac = new List<Lbl.Comprobantes.Tipo>();
                                foreach (Lbl.Comprobantes.Tipo Tp in Lbl.Comprobantes.Tipo.TodosPorLetra.Values) {
                                        if (Tp.EsFacturaOTicket)
                                                TiposFac.Add(Tp);
                                }
                                string[] NombresYTipos = new string[TiposFac.Count];
                                int i = 0;
                                foreach (Lbl.Comprobantes.Tipo Tp in TiposFac) {
                                        NombresYTipos[i++] = Tp.Nombre + "|" + Tp.Nomenclatura;
                                }
                                EntradaTipo.SetData = NombresYTipos;
                                EntradaFormaPago.Elemento = Res.FormaDePago;
                                PanelFormaPago.Visible = true;
                                PanelComprobanteOriginal.Visible = false;
                        } else if (this.Tipo.EsNotaCredito || this.Tipo.EsNotaDebito) {
                                List<Lbl.Comprobantes.Tipo> TiposFac = new List<Lbl.Comprobantes.Tipo>();
                                foreach (Lbl.Comprobantes.Tipo Tp in Lbl.Comprobantes.Tipo.TodosPorLetra.Values) {
                                        if (Tp.EsNotaCredito || Tp.EsNotaDebito)
                                                TiposFac.Add(Tp);
                                }
                                string[] NombresYTipos = new string[TiposFac.Count];
                                int i = 0;
                                foreach (Lbl.Comprobantes.Tipo Tp in TiposFac) {
                                        NombresYTipos[i++] = Tp.Nombre + "|" + Tp.Nomenclatura;
                                }
                                EntradaTipo.SetData = NombresYTipos;
                                EntradaFormaPago.ValueInt = 3;
                                EntradaComprobanteOriginal.Elemento = Res.ComprobanteOriginal;

                                if (Res.ComprobanteOriginal != null && Res.ComprobanteOriginal.Cliente != null) {
                                        EntradaComprobanteOriginal.Filter = "tipo_fac IN ('FA', 'FB', 'FC', 'FE', 'FM') AND numero>0 AND id_cliente=" + Res.ComprobanteOriginal.Cliente.Id.ToString();
                                }

                                PanelFormaPago.Visible = false;
                                PanelComprobanteOriginal.Visible = true;
                        }

                        EntradaTipo.TextKey = Res.Tipo.Nomenclatura;

                        if (Res.IdRemito == 0)
                                EntradaRemito.Text = "";
                        else
                                EntradaRemito.Text = Lbl.Comprobantes.Comprobante.NumeroCompleto(Res.Connection, Res.IdRemito);
                        PuedeEditarPago = EsCancelable();

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Comprobantes.ComprobanteConArticulos Res = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
                        //Agrego campos propios de esta instancia
                        if (EntradaFormaPago.ValueInt > 0)
                                Res.FormaDePago = new Lbl.Pagos.FormaDePago(Res.Connection, EntradaFormaPago.ValueInt);
                        else
                                Res.FormaDePago = null;

                        if (PanelComprobanteOriginal.Visible) {
                                Res.ComprobanteOriginal = EntradaComprobanteOriginal.Elemento as Lbl.Comprobantes.ComprobanteFacturable;
                        }

                        if (EntradaRemito.Text.Length > 0) {
                                int RemitoNumero, RemitoPv;
                                if (EntradaRemito.Text.IndexOfAny(new char[] { '-' }) >= 0) {
                                        // El número de remito tiene guión
                                        string[] Partes = EntradaRemito.Text.Split(new char[] { '-' });
                                        RemitoNumero = Lfx.Types.Parsing.ParseInt(Partes[0]);
                                        RemitoPv = Lfx.Types.Parsing.ParseInt(Partes[1]);
                                } else {
                                        // El número de remito no tiene guión, asumo el mismo PV que la factura
                                        RemitoNumero = EntradaRemito.ValueInt;
                                        RemitoPv = EntradaPV.ValueInt;
                                }

                                Res.IdRemito = this.Connection.FieldInt("SELECT id_comprob FROM comprob WHERE compra=0 AND tipo_fac!='R' AND pv=" + RemitoPv.ToString() + " AND numero=" + RemitoNumero.ToString() + " AND impresa>0 AND anulada=0");
                        } else {
                                Res.IdRemito = 0;
                        }

                        base.ActualizarElemento();
                }


                public override Lfx.Types.OperationResult BeforePrint()
                {
                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
                        if (Comprob.Articulos.Count >= 1 && (Comprob.Articulos[0].Cantidad < 0 || Comprob.Articulos[0].Unitario < 0))
                                return new Lfx.Types.OperationResult(false, "El primer ítem de la factura no puede ser negativo. Utilice los ítem negativos en último lugar.");

                        Comprob.Cliente.Cargar();

                        if (Comprob.FormaDePago == null)
                                return new Lfx.Types.FailureOperationResult("Por favor seleccione la forma de pago.");

                        if (Comprob.Cliente == null)
                                return new Lfx.Types.FailureOperationResult("Por favor seleccione un cliente.");

                        if (Comprob.Tipo == null)
                                return new Lfx.Types.FailureOperationResult("Por favor seleccione el tipo de comprobante.");

                        if (Lbl.Sys.Config.Pais.Id == 1) {
                                // Verificaciones especiales para Argentina
                                if (Comprob.Tipo.EsFacturaNCoND && Comprob.Cliente.SituacionTributaria != null && Comprob.Tipo.Letra != Comprob.Cliente.LetraPredeterminada()) {
                                        Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog(@"La situación tributaria del cliente y el tipo de comprobante no se corresponden.
Un cliente " + Comprob.Cliente.SituacionTributaria.ToString() + @" debería llevar un comprobante tipo " + Comprob.Cliente.LetraPredeterminada() + @". No debería continuar con la impresión. 
¿Desea continuar de todos modos?", "Tipo de comprobante incorrecto");
                                        Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                                        if (Pregunta.ShowDialog() == DialogResult.Cancel)
                                                return new Lfx.Types.FailureOperationResult("Corrija la situación tributaria del cliente o el tipo de comprobante.");
                                }

                                if (Comprob.Tipo.Letra.ToUpperInvariant() == "A") {
                                        if (Comprob.Cliente.ClaveTributaria == null || Comprob.Cliente.ClaveTributaria.EsValido() == false)
                                                return new Lfx.Types.FailureOperationResult("El cliente no tiene una CUIT válida. Por favor edite el cliente y escriba una CUIT válida.");
                                } else if (Comprob.Tipo.Letra == "B") {
                                        //Si es factura B de más de $ 1000, debe llevar el Nº de DNI
                                        if (Comprob.Total >= 1000 && Comprob.Cliente.NumeroDocumento.Length < 5 &&
                                                (Comprob.Cliente.ClaveTributaria == null || Comprob.Cliente.ClaveTributaria.EsValido() == false))
                                                return new Lfx.Types.FailureOperationResult("Para Facturas B de $ 1.000 o más debe proporcionar el número de DNI/CUIT del cliente.");
                                        //Si es factura B de más de $ 1000, debe llevar domicilio
                                        if (Comprob.Total >= 1000 && Comprob.Cliente.Domicilio.Length < 1)
                                                return new Lfx.Types.FailureOperationResult("Para Facturas B de $ 1.000 o más debe proporcionar el domicilio del cliente.");
                                }
                        }

                        if (EntradaProductos.ShowStock && this.Tipo.MueveExistencias < 0 && Comprob.HayExistencias() == false) {
                                Lui.Forms.YesNoDialog OPregunta = new Lui.Forms.YesNoDialog("Las existencias actuales no son suficientes para cubrir la operación que intenta realizar.\n¿Desea continuar de todos modos?", "No hay existencias suficientes");
                                OPregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                                if (OPregunta.ShowDialog() == DialogResult.Cancel)
                                        return new Lfx.Types.FailureOperationResult("No se imprimir el comprobante por falta de existencias.");
                        }

                        if (Comprob.Cliente.Id != 999 && (Comprob.Tipo.EsFactura || Comprob.Tipo.EsNotaDebito)) {
                                decimal SaldoCtaCte = Comprob.Cliente.CuentaCorriente.ObtenerSaldo(false);

                                if (Comprob.FormaDePago != null && Comprob.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.CuentaCorriente) {
                                        decimal LimiteCredito = Comprob.Cliente.LimiteCredito;

                                        if (LimiteCredito == 0)
                                                LimiteCredito = Lfx.Types.Parsing.ParseCurrency(Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Cuentas.LimiteCreditoPredet", "0"));

                                        if (LimiteCredito != 0 && (Comprob.Total + SaldoCtaCte) > LimiteCredito)
                                                return new Lfx.Types.FailureOperationResult("El valor de la factura y/o el saldo en cuenta corriente supera el límite de crédito de este cliente.");
                                } else {
                                        if (SaldoCtaCte < 0) {
                                                using (SaldoEnCuentaCorriente FormularioError = new SaldoEnCuentaCorriente()) {
                                                        switch (FormularioError.ShowDialog()) {
                                                                case DialogResult.Yes:
                                                                        //Corregir el problema
                                                                        this.EntradaFormaPago.ValueInt = 3;
                                                                        this.Save();
                                                                        Comprob.FormaDePago.Tipo = Lbl.Pagos.TiposFormasDePago.CuentaCorriente;
                                                                        break;
                                                                case DialogResult.No:
                                                                        //Continuar. No corregir el problema.
                                                                        break;
                                                                default:
                                                                        //Cancelar y volver a la edición.
                                                                        return new Lfx.Types.OperationResult(false);
                                                        }
                                                }
                                        }
                                }
                        }

                        if (Comprob.PV < 1)
                                return new Lfx.Types.FailureOperationResult("Por favor escriba un punto de venta válido.");

                        if (Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.ContainsKey(Comprob.PV) == false) {
                                // No existe el PV... vacío la caché antes intentar de nuevo y dar un error
                                Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.Clear();
                                if (Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.ContainsKey(Comprob.PV) == false)
                                        return new Lfx.Types.FailureOperationResult("El punto de venta no existe. Si desea definir un nuevo punto de venta, utilice el menú Comprobantes -> Tablas -> Puntos de venta.");
                        }

                        Lbl.Comprobantes.PuntoDeVenta Pv = Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero[Comprob.PV];
                        if (Pv.Tipo == Lbl.Comprobantes.TipoPv.Talonario) {
                                Lbl.Impresion.Impresora Impresora = Comprob.ObtenerImpresora();

                                if (Pv.CargaManual && (Impresora == null || Impresora.CargaPapel == Lbl.Impresion.CargasPapel.Automatica)) {
                                        Lui.Printing.ManualFeedDialog FormularioCargaManual = new Lui.Printing.ManualFeedDialog();
                                        FormularioCargaManual.DocumentName = Comprob.Tipo.ToString() + " " + Comprob.PV.ToString("0000") + "-" + Lbl.Comprobantes.Numerador.ProximoNumero(Comprob).ToString("00000000");
                                        // Muestro el nombre de la impresora
                                        if (Impresora != null) {
                                                FormularioCargaManual.PrinterName = Impresora.Nombre;
                                        } else {
                                                System.Drawing.Printing.PrinterSettings objPrint = new System.Drawing.Printing.PrinterSettings();
                                                FormularioCargaManual.PrinterName = objPrint.PrinterName;
                                        }
                                        if (FormularioCargaManual.ShowDialog() == DialogResult.Cancel)
                                                return new Lfx.Types.CancelOperationResult();
                                }
                        }

                        if (Comprob.Tipo.MueveExistencias != 0) {
                                Lfx.Types.OperationResult Res = Comprob.VerificarSeries();
                                if (Res.Success == false)
                                        return Res;
                        }

                        return base.BeforePrint();
                }

                public override void AfterPrint()
                {
                        PuedeEditarPago = this.EsCancelable();

                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;

                        if (Comprob.Impreso) {
                                switch (Comprob.FormaDePago.Tipo) {
                                        case Lbl.Pagos.TiposFormasDePago.Efectivo:
                                                //El pago lo asentó la rutina de impresión
                                                //Yo sólo muestro la ventanita de calcular el cambio
                                                Comprobantes.PagoVuelto FormularioVuelto = new Comprobantes.PagoVuelto();
                                                FormularioVuelto.Total = Lfx.Types.Parsing.ParseCurrency(EntradaTotal.Text);
                                                FormularioVuelto.ShowDialog();
                                                break;
                                        case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                                        case Lbl.Pagos.TiposFormasDePago.ChequeTerceros:
                                        case Lbl.Pagos.TiposFormasDePago.Tarjeta:
                                        case Lbl.Pagos.TiposFormasDePago.OtroValor:
                                        case Lbl.Pagos.TiposFormasDePago.Caja:
                                                if (this.EsCancelable())
                                                        EditarPago();
                                                break;
                                }
                        }
                }


                private void EntradaCliente_TextChanged(object sender, System.EventArgs e)
                {
                        if (PanelComprobanteOriginal.Visible) {
                                EntradaComprobanteOriginal.Filter = "tipo_fac IN ('FA', 'FB', 'FC', 'FE', 'FM') AND numero>0 AND id_cliente=" + EntradaCliente.ValueInt.ToString();
                                Lbl.Comprobantes.ComprobanteFacturable Comprob = EntradaComprobanteOriginal.Elemento as Lbl.Comprobantes.ComprobanteFacturable;
                                if (Comprob == null || Comprob.Cliente == null || Comprob.Cliente.Id != EntradaComprobanteOriginal.ValueInt) {
                                        EntradaComprobanteOriginal.ValueInt = 0;
                                }
                        }
                }


                private void EntradaTipo_TextChanged(object sender, System.EventArgs e)
                {
                        this.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra[EntradaTipo.TextKey];
                }


                private Lfx.Types.OperationResult EditarPago()
                {
                        Lbl.Comprobantes.ComprobanteConArticulos Factura = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;

                        if (Factura.ImporteCancelado >= Factura.Total)
                                return new Lfx.Types.FailureOperationResult("Este comprobante ya fue cancelado en su totalidad.");

                        if (Factura.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.Efectivo) {
                                using (IDbTransaction Trans = Factura.Connection.BeginTransaction()) {
                                        Factura.AsentarPago(false);
                                        Factura.MoverExistencias(false);
                                        Trans.Commit();
                                }
                                this.PuedeEditarPago = false;
                        } else if (Factura.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.CuentaCorriente) {
                                CrearReciboParaEstaFactura();
                        } else {
                                using (Comprobantes.Recibos.EditarCobro FormularioEditarPago = new Comprobantes.Recibos.EditarCobro()) {
                                        FormularioEditarPago.Cobro.FromCobro(new Lbl.Comprobantes.Cobro(this.Connection, Factura.FormaDePago));
                                        FormularioEditarPago.Cobro.FormaDePagoEditable = true;
                                        FormularioEditarPago.Cobro.Importe = Factura.Total;
                                        FormularioEditarPago.Cobro.ImporteVisible = true;
                                        FormularioEditarPago.Cobro.ImporteEditable = false;
                                        if (FormularioEditarPago.ShowDialog() == DialogResult.OK) {
                                                Lbl.Comprobantes.Cobro MiCobro = FormularioEditarPago.Cobro.ToCobro(Factura.Connection);
                                                if (MiCobro.FormaDePago.Id != Factura.FormaDePago.Id) {
                                                        // Tengo que actualizar la forma de pago
                                                        using (IDbTransaction Trans = Factura.Connection.BeginTransaction()) {
                                                                Factura.FormaDePago = MiCobro.FormaDePago;
                                                                EntradaFormaPago.Elemento = MiCobro;
                                                                Factura.Connection.FieldInt("UPDATE comprob SET id_formapago=" + MiCobro.FormaDePago.Id.ToString() + " WHERE id_comprob=" + Factura.Id.ToString());
                                                                if (MiCobro.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.CuentaCorriente) {
                                                                        // Si la nueva forma de pago es cta. cte., asiento el saldo
                                                                        // Y uso saldo a favor, si lo hay
                                                                        decimal Saldo = Factura.Cliente.CuentaCorriente.ObtenerSaldo(true);
                                                                        Factura.Cliente.CuentaCorriente.Movimiento(true,
                                                                                Lbl.Cajas.Concepto.IngresosPorFacturacion,
                                                                                "Saldo a Cta. Cte. s/" + Factura.ToString(),
                                                                                Factura.ImporteImpago,
                                                                                null,
                                                                                Factura,
                                                                                null,
                                                                                null);
                                                                        if (Saldo < 0) {
                                                                                Saldo = Math.Abs(Saldo);
                                                                                if (Saldo > Factura.Total)
                                                                                        Factura.CancelarImporte(Factura.Total, null);
                                                                                else
                                                                                        Factura.CancelarImporte(Saldo, null);
                                                                        }
                                                                }
                                                                Trans.Commit();
                                                        }
                                                }
                                                switch (Factura.FormaDePago.Tipo) {
                                                        case Lbl.Pagos.TiposFormasDePago.Efectivo:
                                                                using (IDbTransaction TransEfe = Factura.Connection.BeginTransaction()) {
                                                                        Lbl.Cajas.Caja CajaDiaria = new Lbl.Cajas.Caja(Factura.Connection, Lfx.Workspace.Master.CurrentConfig.Empresa.CajaDiaria);
                                                                        CajaDiaria.Movimiento(true, Lbl.Cajas.Concepto.IngresosPorFacturacion, Factura.ToString(), Factura.Cliente, Factura.ImporteImpago, Factura.Obs, Factura, null, null);
                                                                        Factura.CancelarImporte(Factura.Total, null);
                                                                        TransEfe.Commit();
                                                                }
                                                                break;
                                                        case Lbl.Pagos.TiposFormasDePago.CuentaCorriente:
                                                                CrearReciboParaEstaFactura();
                                                                break;
                                                        case Lbl.Pagos.TiposFormasDePago.ChequeTerceros:
                                                                using (IDbTransaction TransCheTer = Factura.Connection.BeginTransaction()) {
                                                                        Lbl.Bancos.Cheque Cheque = MiCobro.Cheque;
                                                                        Cheque.Concepto = Lbl.Cajas.Concepto.IngresosPorFacturacion;
                                                                        Cheque.ConceptoTexto = "Cobro s/" + this.Elemento.ToString();
                                                                        Cheque.Factura = Factura;
                                                                        Cheque.Guardar();
                                                                        Factura.CancelarImporte(Factura.Total, null);
                                                                        TransCheTer.Commit();
                                                                }
                                                                PuedeEditarPago = false;
                                                                break;
                                                        case Lbl.Pagos.TiposFormasDePago.Tarjeta:
                                                                using (IDbTransaction TransTarj = Factura.Connection.BeginTransaction()) {
                                                                        Lbl.Pagos.Cupon CuponCredito = MiCobro.Cupon;
                                                                        CuponCredito.Concepto = Lbl.Cajas.Concepto.IngresosPorFacturacion;
                                                                        CuponCredito.ConceptoTexto = "Cobro s/" + Factura.ToString();

                                                                        if (EntradaVendedor.ValueInt > 0)
                                                                                CuponCredito.Vendedor = new Lbl.Personas.Persona(Factura.Connection, EntradaVendedor.ValueInt);

                                                                        CuponCredito.Factura = Factura;
                                                                        CuponCredito.Guardar();

                                                                        Factura.CancelarImporte(Factura.Total, null);
                                                                        TransTarj.Commit();
                                                                }
                                                                PuedeEditarPago = false;
                                                                break;
                                                        case Lbl.Pagos.TiposFormasDePago.Caja:
                                                                using (IDbTransaction TransCaja = Factura.Connection.BeginTransaction()) {
                                                                        Lbl.Cajas.Caja CajaDeposito = MiCobro.CajaDestino;
                                                                        CajaDeposito.Movimiento(true, Lbl.Cajas.Concepto.IngresosPorFacturacion, "Cobro s/" + Factura.ToString(), Factura.Cliente, MiCobro.Importe, MiCobro.Obs, Factura, null, null);
                                                                        Factura.CancelarImporte(Factura.Total, null);
                                                                        TransCaja.Commit();
                                                                }
                                                                PuedeEditarPago = false;
                                                                break;
                                                        default:
                                                                throw new NotImplementedException("No se reconoce la forma de pago " + Factura.FormaDePago.Tipo.ToString());
                                                }

                                        } else {
                                                return new Lfx.Types.SuccessOperationResult();
                                        }
                                }
                                this.PuedeEditarPago = false;
                        }

                        return new Lfx.Types.SuccessOperationResult();
                }

                private void CrearReciboParaEstaFactura()
                {
                        Lbl.Comprobantes.ComprobanteConArticulos Factura = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
                        Lbl.Comprobantes.ReciboDeCobro Recibo = new Lbl.Comprobantes.ReciboDeCobro(Lfx.Workspace.Master.GetNewConnection("Nuevo recibo para " + Factura.ToString()));
                        Recibo.Crear();
                        Recibo.Facturas.AddWithValue(Factura, Factura.ImporteImpago);
                        Recibo.Cliente = Factura.Cliente;

                        Recibo.Concepto = Lbl.Cajas.Concepto.IngresosPorFacturacion;
                        Recibo.ConceptoTexto = "Cancelación de " + Factura.ToString();

                        Lfc.FormularioEdicion NuevoRecibo = Lfc.Instanciador.InstanciarFormularioEdicion(Recibo);
                        NuevoRecibo.MdiParent = this.ParentForm.MdiParent;
                        NuevoRecibo.Show();
                }


                internal bool EsCancelable()
                {
                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
                        if (Comprob == null || Comprob.ImporteImpago == 0) {
                                return false;
                        } else {
                                return (Comprob.Impreso && Comprob.Anulado == false && Comprob.Existe && Comprob.FormaDePago != null);
                        }
                }


                private void EntradaRemito_TextChanged(object sender, System.EventArgs e)
                {
                        int RemitoId = Lfx.Types.Parsing.ParseInt(EntradaRemito.Text);
                        if (RemitoId > 0) {
                                Lfx.Data.Row Remito = this.Connection.FirstRowFromSelect("SELECT * FROM comprob WHERE tipo_fac='R' AND numero=" + RemitoId.ToString() + " AND impresa>0 AND anulada=0");
                                if (Remito == null)
                                        EntradaProductos.ShowStock = true;
                                else
                                        EntradaProductos.ShowStock = false;
                        } else {
                                EntradaProductos.ShowStock = true;
                        }
                }


                private void EntradaFormaPago_Leave(object sender, System.EventArgs e)
                {
                        if (EntradaFormaPago.ValueInt == 99)
                                EntradaFormaPago.ValueInt = 3;
                        if (EntradaFormaPago.ValueInt == 5)
                                EntradaFormaPago.ValueInt = 4;
                }


                [EditorBrowsable(EditorBrowsableState.Never), System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public override Lbl.Comprobantes.Tipo Tipo
                {
                        get
                        {
                                return base.Tipo;
                        }
                        set
                        {
                                base.Tipo = value;
                                PanelFormaPago.Visible = value.EsFactura || value.EsTicket;
                                PanelComprobanteOriginal.Visible = value.EsNotaCredito;
                                if (EntradaTipo.TextKey != value.Nomenclatura)
                                        EntradaTipo.TextKey = value.Nomenclatura;
                        }
                }


                private bool PuedeEditarPago
                {
                        get
                        {
                                return m_PuedeEditarPago;
                        }
                        set
                        {
                                m_PuedeEditarPago = value;
                                FireFormActionsChanged();
                        }
                }

                public override Lazaro.Pres.Forms.FormActionCollection GetFormActions()
                {
                        Lazaro.Pres.Forms.FormActionCollection Res = base.GetFormActions();
                        if (this.PuedeEditarPago)
                                Res.Add(new Lazaro.Pres.Forms.FormAction("Pago", "F2", "pago", 10, Lazaro.Pres.Forms.FormActionVisibility.Secondary));
                        return Res;
                }


                public override Lfx.Types.OperationResult PerformFormAction(string name)
                {
                        switch (name) {
                                case "pago":
                                        EditarPago();
                                        return new Lfx.Types.SuccessOperationResult();
                                default:
                                        return base.PerformFormAction(name);
                        }
                }
        }
}