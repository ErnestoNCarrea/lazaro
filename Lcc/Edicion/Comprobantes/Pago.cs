using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lcc.Edicion.Comprobantes
{
        public partial class Pago : ControlEdicion
        {
                public Pago()
                {
                        InitializeComponent();
                }

                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public Lbl.Pagos.FormaDePago FormaDePago
                {
                        get
                        {
                                if (this.ElementoPago == null)
                                        return null;
                                else
                                        return this.ElementoPago.FormaDePago;
                        }
                        set
                        {
                                if (this.ElementoPago == null)
                                        this.ElementoPago = new Lbl.Comprobantes.Pago(this.Connection, value);
                                else
                                        this.ElementoPago.FormaDePago = value;
                                if (value != null && EntradaFormaDePago.ValueInt != value.Id)
                                        EntradaFormaDePago.ValueInt = value.Id;
                                this.MostrarPaneles();
                        }
                }

                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public decimal Importe
                {
                        get
                        {
                                return EntradaImporte.Text.ParseCurrency();
                        }
                        set
                        {
                                EntradaImporte.Text = Lfx.Types.Formatting.FormatCurrency(value, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        }
                }

                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public string Obs
                {
                        get
                        {
                                return EntradaObs.Text;
                        }
                        set
                        {
                                EntradaObs.Text = value;
                        }
                }

                private Lbl.Comprobantes.Pago ElementoPago
                {
                        get
                        {
                                return this.Elemento as Lbl.Comprobantes.Pago;
                        }
                        set
                        {
                                this.Elemento = value;
                        }
                }

                public Lfx.Types.OperationResult ValidateData()
                {
                        if (Lfx.Types.Parsing.ParseCurrency(EntradaImporte.Text) <= 0)
                                return new Lfx.Types.FailureOperationResult("Debe especificar el importe correctamente.");

                        if(this.FormaDePago == null || this.FormaDePago.Existe == false)
                                return new Lfx.Types.FailureOperationResult("Debe seleccionar la forma de pago.");

                        if (this.FormaDePago.PuedeHacerPagos == false)
                                return new Lfx.Types.FailureOperationResult("La forma seleccionada no es válida para realizar pagos, sólo para realizar cobros.");

                        switch (this.FormaDePago.Tipo) {
                                case Lbl.Pagos.TiposFormasDePago.Efectivo:
                                case Lbl.Pagos.TiposFormasDePago.CuentaCorriente:
                                        //Nada que verificar
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                                        if (EntradaBanco.ValueInt <= 0) {
                                                return new Lfx.Types.FailureOperationResult("Debe seleccionar un banco.");
                                        }  else {
                                                int Numero = Lfx.Types.Parsing.ParseInt(EntradaNumeroCheque.Text);
                                                int IdChequera = this.Connection.FieldInt("SELECT id_chequera FROM chequeras WHERE estado=1 AND id_banco=" + EntradaBanco.ValueInt.ToString() + " AND " + Numero.ToString() + " BETWEEN desde AND hasta AND (id_sucursal=" + Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual.ToString() + " OR id_sucursal IS NULL)");
                                                if (IdChequera == 0)
                                                        return new Lfx.Types.FailureOperationResult("El Número de cheque no corresponde a ninguna Chequera del banco seleccionado.");

                                                int IdChequePrevio = this.Connection.FieldInt("SELECT id_cheque FROM bancos_cheques WHERE estado<>90 AND numero=" + Lfx.Types.Parsing.ParseInt(EntradaNumeroCheque.Text).ToString() + " AND (id_sucursal=" + Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual.ToString() + " OR id_sucursal IS NULL)");
                                                if (IdChequePrevio != 0)
                                                        return new Lfx.Types.FailureOperationResult("El Número corresponde a un cheque que ya fue emitido.");

                                        }
                                        if (EntradaFechaEmision.Text.Length == 0)
                                                return new Lfx.Types.FailureOperationResult("Debe especificar la fecha de emisión.");
                                        if (EntradaFechaCobro.Text.Length == 0)
                                                return new Lfx.Types.FailureOperationResult("Debe especificar la fecha de cobro. Si lo desea puede especificar la misma fecha que de emisión.");
                                        
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.Tarjeta:
                                        if (EntradaCupon.Text.Length == 0)
                                                return new Lfx.Types.FailureOperationResult("Debe especificar el número de cupón.");
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.Caja:
                                        if (EntradaCaja.ValueInt <= 0)
                                                return new Lfx.Types.FailureOperationResult("Debe seleccionar la cuenta bancaria.");
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.ChequeTerceros:
                                        if (EntradaChequeTerceros.ValueInt <= 0)
                                                return new Lfx.Types.FailureOperationResult("Debe seleccionar el cheque.");
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.OtroValor:
                                        if (EntradaValor.ValueInt <= 0)
                                                return new Lfx.Types.FailureOperationResult("Debe seleccionar el " + this.FormaDePago.ToString());
                                        break;
                                default:
                                        return new Lfx.Types.FailureOperationResult("Debe seleccionar un modo de pago válido.");
                        }

                        return new Lfx.Types.SuccessOperationResult();
                }

                public virtual Lbl.Comprobantes.Pago ToPago(Lfx.Data.IConnection dataBase)
                {
                        switch (this.ElementoPago.FormaDePago.Tipo) {
                                case Lbl.Pagos.TiposFormasDePago.Efectivo:
                                case Lbl.Pagos.TiposFormasDePago.CuentaCorriente:
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                                        this.ElementoPago.Cheque = new Lbl.Bancos.Cheque(dataBase);
                                        this.ElementoPago.Cheque.Emitido = true;
                                        this.ElementoPago.Cheque.FechaCobro = Lfx.Types.Parsing.ParseDate(EntradaFechaCobro.Text);
                                        this.ElementoPago.Cheque.FechaEmision = Lfx.Types.Parsing.ParseDate(EntradaFechaEmision.Text);
                                        this.ElementoPago.Cheque.Importe = Lfx.Types.Parsing.ParseCurrency(EntradaImporte.Text);
                                        this.ElementoPago.Cheque.Numero = Lfx.Types.Parsing.ParseInt(EntradaNumeroCheque.Text);
                                        int IdChequera = this.Connection.FieldInt("SELECT id_chequera FROM chequeras WHERE estado=1 AND id_banco=" + EntradaBanco.ValueInt.ToString() + " AND " + this.ElementoPago.Cheque.Numero.ToString() + " BETWEEN desde AND hasta AND (id_sucursal=" + Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual.ToString() + " OR id_sucursal IS NULL)");
                                        if (IdChequera == 0)
                                                this.ElementoPago.Cheque.Chequera = null;
                                        else
                                                this.ElementoPago.Cheque.Chequera = new Lbl.Bancos.Chequera(dataBase, IdChequera);
                                        if (EntradaBanco.ValueInt > 0)
                                                this.ElementoPago.Cheque.Banco = new Lbl.Bancos.Banco(dataBase, EntradaBanco.ValueInt);
                                        else
                                                this.ElementoPago.Cheque.Banco = null;
                                        this.ElementoPago.Cheque.Obs = EntradaObs.Text;
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.Caja:
                                        if (EntradaCaja.ValueInt > 0)
                                                this.ElementoPago.CajaOrigen = new Lbl.Cajas.Caja(dataBase, EntradaCaja.ValueInt);
                                        else
                                                this.ElementoPago.CajaOrigen = null;
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.ChequeTerceros:
                                        this.ElementoPago.Cheque = new Lbl.Bancos.Cheque(dataBase, EntradaChequeTerceros.ValueInt);
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.OtroValor:
                                        this.ElementoPago.Valor = new Lbl.Pagos.Valor(dataBase, EntradaValor.ValueInt);
                                        break;
                        }
                        this.ElementoPago.Importe = Lfx.Types.Parsing.ParseCurrency(EntradaImporte.Text);
                        this.ElementoPago.Obs = EntradaObs.Text;
                        return this.ElementoPago;
                }

                public void FromPago(Lbl.Comprobantes.Pago pago)
                {
                        this.ElementoPago = pago;
                        if (pago == null)
                                this.EntradaFormaDePago.Elemento = null;
                        else
                                this.EntradaFormaDePago.Elemento = pago.FormaDePago;
                        this.MostrarPaneles();

                        switch (this.ElementoPago.FormaDePago.Tipo) {
                                case Lbl.Pagos.TiposFormasDePago.Efectivo:
                                case Lbl.Pagos.TiposFormasDePago.CuentaCorriente:
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                                        if (this.ElementoPago.FormaDePago.Tipo != Lbl.Pagos.TiposFormasDePago.ChequePropio)
                                                throw new InvalidOperationException();

                                        if (this.ElementoPago.Cheque != null) {
                                                if (this.ElementoPago.Cheque.Banco != null)
                                                        EntradaBanco.ValueInt = this.ElementoPago.Cheque.Banco.Id;
                                                else
                                                        EntradaBanco.ValueInt = 0;
                                                EntradaFechaCobro.Text = Lfx.Types.Formatting.FormatDate(this.ElementoPago.Cheque.FechaCobro);
                                                EntradaFechaEmision.Text = Lfx.Types.Formatting.FormatDate(this.ElementoPago.Cheque.FechaEmision);
                                                EntradaNumeroCheque.Text = this.ElementoPago.Cheque.Numero.ToString();
                                        } else {
                                                EntradaBanco.ValueInt = 0;
                                                EntradaFechaCobro.Text = "";
                                                EntradaFechaEmision.Text = "";
                                                EntradaNumeroCheque.Text = "";
                                        }
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.Caja:
                                        if (this.ElementoPago.CajaOrigen != null)
                                                EntradaCaja.ValueInt = this.ElementoPago.CajaOrigen.Id;
                                        else
                                                EntradaCaja.ValueInt = 0;
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.ChequeTerceros:
                                        if (this.ElementoPago.Cheque != null)
                                                EntradaChequeTerceros.ValueInt = this.ElementoPago.Cheque.Id;
                                        break;
                                case Lbl.Pagos.TiposFormasDePago.OtroValor:
                                        if (this.ElementoPago.Valor != null)
                                                EntradaValor.ValueInt = this.ElementoPago.Valor.Id;
                                        break;
                        }
                        EntradaImporte.Text = Lfx.Types.Formatting.FormatCurrency(this.ElementoPago.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        EntradaObs.Text = this.ElementoPago.Obs;
                }

                private void MostrarPaneles()
                {
                        if (this.ElementoPago.FormaDePago == null) {
                                PanelEfectivo.Visible = false;
                                PanelChequePropio.Visible = false;
                                PanelCaja.Visible = false;
                                PanelTarjeta.Visible = false;
                                PanelCuentaCorriente.Visible = false;
                                PanelChequeTerceros.Visible = false;
                                PanelValor.Visible = false;
                        } else {
                                PanelEfectivo.Visible = this.ElementoPago.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.Efectivo;
                                PanelChequePropio.Visible = this.ElementoPago.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.ChequePropio;
                                PanelCaja.Visible = this.ElementoPago.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.Caja;
                                PanelTarjeta.Visible = this.ElementoPago.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.Tarjeta;
                                PanelCuentaCorriente.Visible = this.ElementoPago.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.CuentaCorriente;
                                PanelChequeTerceros.Visible = this.ElementoPago.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.ChequeTerceros; PanelChequeTerceros.Visible = this.ElementoPago.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.ChequeTerceros;
                                PanelValor.Visible = this.ElementoPago.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.OtroValor;
                                if (this.ElementoPago.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.OtroValor) {
                                        EtiquetaPagoConValor.Text = "Pago con " + this.FormaDePago.ToString();
                                        EntradaValor.Filter = "id_formapago=" + this.ElementoPago.FormaDePago.Id.ToString() + " AND estado=0";

                                }
                                EntradaImporte.TemporaryReadOnly = this.ElementoPago.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.ChequeTerceros || this.ElementoPago.FormaDePago.Tipo == Lbl.Pagos.TiposFormasDePago.OtroValor;
                                EntradaImporte.TabStop = !EntradaImporte.TemporaryReadOnly;
                        }
                        this.Height = PanelSeparadorInferior.Bottom + 1;
                }

                public bool ImporteVisible
                {
                        get
                        {
                                return PanelImporte.Visible;
                        }
                        set
                        {
                                PanelImporte.Visible = value;
                        }
                }

                public bool FormaDePagoVisible
                {
                        get
                        {
                                return PanelFormaDePago.Visible;
                        }
                        set
                        {
                                PanelFormaDePago.Visible = value;
                        }
                }

                public bool ObsVisible
                {
                        get
                        {
                                return PanelObs.Visible;
                        }
                        set
                        {
                                PanelObs.Visible = value;
                        }
                }

                public bool ImporteEditable
                {
                        get
                        {
                                return !EntradaImporte.TemporaryReadOnly;
                        }
                        set
                        {
                                EntradaImporte.TemporaryReadOnly = !value;
                                EntradaImporte.TabStop = value;
                        }
                }

                public bool FormaDePagoEditable
                {
                        get
                        {
                                return !EntradaFormaDePago.TemporaryReadOnly;
                        }
                        set
                        {
                                EntradaFormaDePago.TemporaryReadOnly = !value;
                                EntradaFormaDePago.TabStop = value;
                        }
                }

                public bool TituloVisible
                {
                        get
                        {
                                return PanelTitulo.Visible;
                        }
                        set
                        {
                                PanelTitulo.Visible = value;
                        }
                }

                public override string Text
                {
                        get
                        {
                                return FrameTitulo.Text;
                        }
                        set
                        {
                                FrameTitulo.Text = value;
                        }
                }

                private void EntradaPlan_TextChanged(object sender, EventArgs e)
                {
                        Lfx.Data.Row Plan = Lfx.Workspace.Master.Tables["tarjetas_planes"].FastRows[EntradaPlan.ValueInt];

                        if (Plan != null) {
                                EntradaCuotas.ValueInt = System.Convert.ToInt32(Plan["cuotas"]);
                                EntradaInteres.ValueDecimal = System.Convert.ToDecimal(Plan["interes"]);
                        } else {
                                EntradaCuotas.ValueInt = 0;
                                EntradaInteres.ValueDecimal = 0m;
                        }
                }

                private void EntradaFechaCobro_Enter(object sender, EventArgs e)
                {
                        if (EntradaFechaCobro.Text.Length == 0) {
                                EntradaFechaCobro.Text = EntradaFechaEmision.Text;
                                EntradaFechaCobro.SelectionStart = 0;
                                EntradaFechaCobro.SelectionLength = EntradaFechaCobro.Text.Length;
                        }
                }

                private void EntradaFormaDePago_TextChanged(object sender, EventArgs e)
                {
                        if (this.FormaDePago == null || this.FormaDePago.Id != EntradaFormaDePago.ValueInt) {
                                this.FormaDePago = EntradaFormaDePago.Elemento as Lbl.Pagos.FormaDePago;
                        }
                }

                private void EntradaFechaEmision_Enter(object sender, EventArgs e)
                {
                        if (EntradaFechaEmision.Text.Length == 0) {
                                EntradaFechaEmision.Text = Lfx.Types.Formatting.FormatDate(System.DateTime.Now);
                                EntradaFechaEmision.SelectionStart = 0;
                                EntradaFechaEmision.SelectionLength = EntradaFechaEmision.Text.Length;
                        }
                }

                private void EntradaChequeTerceros_TextChanged(object sender, EventArgs e)
                {
                        if (EntradaChequeTerceros.ValueInt == 0) {
                                this.ElementoPago.Cheque = null;
                        } else {
                                this.ElementoPago.Cheque = new Lbl.Bancos.Cheque(Connection, EntradaChequeTerceros.ValueInt);
                                this.Importe = this.ElementoPago.Cheque.Importe;
                        }
                }

                private void EntradaValor_TextChanged(object sender, EventArgs e)
                {
                        if (EntradaValor.ValueInt == 0) {
                                this.ElementoPago.Valor = null;
                        } else {
                                this.ElementoPago.Valor = new Lbl.Pagos.Valor(Connection, EntradaValor.ValueInt);
                                this.Importe = this.ElementoPago.Valor.Importe;
                        }
                }
        }
}