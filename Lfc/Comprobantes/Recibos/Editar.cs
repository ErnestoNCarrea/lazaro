using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Recibos
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Comprobantes.Recibo);

                        InitializeComponent();
                }


                protected override void OnLoad(EventArgs e)
                {
                        base.OnLoad(e);
                        if (Lbl.Sys.Config.Actual != null && Lbl.Sys.Config.Actual.UsuarioConectado != null)
                                EntradaVendedor.Elemento = Lbl.Sys.Config.Actual.UsuarioConectado.Persona;
                }


                public bool DePago
                {
                        get
                        {
                                Lbl.Comprobantes.Recibo Rec = this.Elemento as Lbl.Comprobantes.Recibo;
                                return Rec.DePago;
                        }
                }

                public override bool TemporaryReadOnly
                {
                        get
                        {
                                return base.TemporaryReadOnly;
                        }
                        set
                        {
                                base.TemporaryReadOnly = value;
                                BotonAgregarFactura.Enabled = !value;
                                BotonQuitarFactura.Enabled = !value;
                                BotonAgregarValor.Enabled = !value;
                                BotonQuitarValor.Enabled = !value;
                                EntradaCliente.TemporaryReadOnly = value;
                                EntradaVendedor.TemporaryReadOnly = value;
                                EntradaNumero.TemporaryReadOnly = value;
                        }
                }

                public override void ActualizarControl()
                {
                        Lbl.Comprobantes.Recibo Rec = this.Elemento as Lbl.Comprobantes.Recibo;

                        EntradaPV.Text = Rec.PV.ToString();
                        EntradaNumero.Text = Rec.Numero.ToString();
                        EntradaVendedor.Elemento = Rec.Vendedor;
                        EntradaCliente.Elemento = Rec.Cliente;
                        EntradaConcepto.Elemento = Rec.Concepto;
                        EntradaConceptoTexto.Text = Rec.ConceptoTexto;

                        if (Rec.DePago) {
                                BotonAgregarValor.Subtext = "F6";
                                BotonQuitarValor.Subtext = "F7";
                        } else {
                                BotonAgregarValor.Subtext = "F4";
                                BotonQuitarValor.Subtext = "F5";
                        }

                        this.MostrarFacturas();
                        this.MostrarValores();

                        if (Rec.Existe) {
                                this.Text = Rec.ToString();
                                this.TemporaryReadOnly = true;
                        } else {
                                this.Text = Rec.Tipo.Nombre;
                        }

                        base.ActualizarControl();
                }


                public override Lfx.Types.OperationResult ValidarControl()
                {
                        Lfx.Types.OperationResult validarReturn = new Lfx.Types.SuccessOperationResult();
                        Lbl.Comprobantes.Recibo Rec = this.Elemento as Lbl.Comprobantes.Recibo;

                        if (EntradaCliente.ValueInt <= 0 || EntradaCliente.ValueInt == 999) {
                                validarReturn.Success = false;
                                validarReturn.Message = "Por favor seleccione un cliente válido." + Environment.NewLine;
                        }

                        if (EntradaConcepto.ValueInt <= 0) {
                                validarReturn.Success = false;
                                validarReturn.Message = "Por favor seleccione un concepto para el movimiento." + Environment.NewLine;
                        }

                        if (this.DePago) {
                                // Recibo de pago
                                if (Rec.Pagos.ImporteTotal <= 0) {
                                        validarReturn.Success = false;
                                        validarReturn.Message = "Debe especificar los valores de pago." + Environment.NewLine;
                                }
                        } else {
                                // Recibo de cobro
                                if (Rec.Cobros.ImporteTotal <= 0) {
                                        validarReturn.Success = false;
                                        validarReturn.Message = "Debe especificar los valores de cobro." + Environment.NewLine;
                                }
                        }

                        if (this.Elemento.Existe == false && EntradaNumero.Text.ParseInt() != 0) {
                                int bExiste = this.Connection.FieldInt("SELECT COUNT(id_recibo) FROM recibos WHERE estado<90 AND pv=" + EntradaPV.ValueInt.ToString() + " AND numero=" + EntradaNumero.ValueInt.ToString());
                                if (bExiste != 0) {
                                        validarReturn.Success = false;
                                        validarReturn.Message = "Ya existe un Recibo con ese número." + Environment.NewLine;
                                }
                        }
                        return validarReturn;
                }

                public override void ActualizarElemento()
                {
                        Lbl.Comprobantes.Recibo Rec = this.Elemento as Lbl.Comprobantes.Recibo;
                        if (this.DePago) {
                                foreach (Lbl.Comprobantes.Pago Pg in Rec.Pagos) {
                                        if (this.EntradaConceptoTexto.Text.Length > 0)
                                                Pg.ConceptoTexto = this.EntradaConceptoTexto.Text;
                                        else
                                                Pg.ConceptoTexto = "Pago s/" + Rec.ToString();
                                }
                        } else {
                                foreach (Lbl.Comprobantes.Cobro Cb in Rec.Cobros) {
                                        if (this.EntradaConceptoTexto.Text.Length > 0)
                                                Cb.ConceptoTexto = this.EntradaConceptoTexto.Text;
                                        else
                                                Cb.ConceptoTexto = "Cobro s/" + Rec.ToString();
                                }
                        }

                        Rec.PV = Lfx.Types.Parsing.ParseInt(EntradaPV.Text);
                        Rec.Numero = Lfx.Types.Parsing.ParseInt(EntradaNumero.Text);
                        Rec.Cliente = new Lbl.Personas.Persona(Rec.Connection, EntradaCliente.ValueInt);
                        Rec.Vendedor = new Lbl.Personas.Persona(Rec.Connection, EntradaVendedor.ValueInt);
                        Rec.ConceptoTexto = EntradaConceptoTexto.Text;
                        if (EntradaConcepto.ValueInt > 0)
                                Rec.Concepto = new Lbl.Cajas.Concepto(Rec.Connection, EntradaConcepto.ValueInt);
                        else
                                Rec.Concepto = null;
                        Rec.Obs = null;

                        base.ActualizarElemento();
                }

                private void BotonFacturasAgregar_Click(object sender, System.EventArgs e)
                {
                        using (Comprobantes.Seleccionar FormularioSeleccionarFactura = new Comprobantes.Seleccionar()) {
                                FormularioSeleccionarFactura.Connection = this.Connection;
                                FormularioSeleccionarFactura.AceptarAnuladas = false;
                                FormularioSeleccionarFactura.AceptarCanceladas = false;
                                if (this.DePago) {
                                        FormularioSeleccionarFactura.AceptarNoImpresas = true;
                                        FormularioSeleccionarFactura.DeCompra = this.DePago;
                                } else {
                                        FormularioSeleccionarFactura.AceptarNoImpresas = false;
                                        FormularioSeleccionarFactura.DeCompra = this.DePago;
                                }

                                if (EntradaCliente.ValueInt > 0) {
                                        FormularioSeleccionarFactura.EntradaCliente.Elemento = EntradaCliente.Elemento;
                                        FormularioSeleccionarFactura.EntradaCliente.Enabled = false;
                                }

                                if (FormularioSeleccionarFactura.ShowDialog() == DialogResult.OK && FormularioSeleccionarFactura.Comprobante != null) {
                                        AgregarFactura(FormularioSeleccionarFactura.Comprobante as Lbl.Comprobantes.ComprobanteFacturable);
                                        if (EntradaCliente.ValueInt == 0) {
                                                EntradaCliente.Elemento = FormularioSeleccionarFactura.Comprobante.Cliente;
                                        }
                                }
                        }
                }


                internal Lfx.Types.OperationResult AgregarFactura(Lbl.Comprobantes.ComprobanteFacturable factura)
                {
                        Lbl.Comprobantes.Recibo Rec = this.Elemento as Lbl.Comprobantes.Recibo;
                        if (Rec.Facturas == null) {
                                Rec.Facturas = new Lbl.Comprobantes.ColeccionComprobanteImporte();
                        } else {
                                foreach (Lbl.Comprobantes.ComprobanteImporte CompImp in Rec.Facturas) {
                                        Lbl.Comprobantes.ComprobanteConArticulos Fc = CompImp.Comprobante;
                                        if (Fc.Id == factura.Id)
                                                return new Lfx.Types.FailureOperationResult("La factura seleccionada ya está en la lista.");
                                }
                        }
                        Rec.Facturas.AddWithValue(factura, factura.ImporteImpago);

                        this.MostrarFacturas();

                        return new Lfx.Types.SuccessOperationResult();
                }

                public void MostrarFacturas()
                {
                        ListaFacturas.BeginUpdate();
                        ListaFacturas.Items.Clear();
                        Lbl.Comprobantes.Recibo Rec = this.Elemento as Lbl.Comprobantes.Recibo;

                        foreach (Lbl.Comprobantes.ComprobanteImporte CompImp in Rec.Facturas) {
                                Lbl.Comprobantes.ComprobanteConArticulos Fc = CompImp.Comprobante;
                                ListViewItem AgregarFactura = ListaFacturas.Items.Add(Fc.GetHashCode().ToString());
                                AgregarFactura.SubItems.Add(new ListViewItem.ListViewSubItem(AgregarFactura, Fc.ToString()));
                                AgregarFactura.SubItems.Add(new ListViewItem.ListViewSubItem(AgregarFactura, Lfx.Types.Formatting.FormatDate(Fc.Fecha)));
                                AgregarFactura.SubItems.Add(new ListViewItem.ListViewSubItem(AgregarFactura, Lfx.Types.Formatting.FormatCurrency(Fc.Total, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales)));
                                AgregarFactura.SubItems.Add(new ListViewItem.ListViewSubItem(AgregarFactura, Lfx.Types.Formatting.FormatCurrency(Fc.Total - Fc.ImporteCancelado, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales)));

                        }

                        LabelAgregarFacturas.Visible = ListaFacturas.Items.Count == 0 && this.Elemento.Existe == false;
                        BotonQuitarFactura.Visible = ListaFacturas.Items.Count > 0;

                        if (ListaFacturas.Items.Count > 0 && ListaFacturas.SelectedItems.Count == 0) {
                                ListaFacturas.Items[ListaFacturas.Items.Count - 1].Selected = true;
                                ListaFacturas.Items[ListaFacturas.Items.Count - 1].Focused = true;
                        }

                        EtiquetaFacturasImporte.Text = Lfx.Types.Formatting.FormatCurrency(Rec.Facturas.ImporteImpago, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);

                        ListaFacturas.EndUpdate();
                }


                private void BotonFacturasQuitar_Click(object sender, System.EventArgs e)
                {
                        if (ListaFacturas.SelectedItems.Count == 0 && ListaFacturas.Items.Count > 0)
                                ListaFacturas.Items[ListaFacturas.Items.Count].Selected = true;

                        if (ListaFacturas.SelectedItems.Count == 0) {
                                Lui.Forms.MessageBox.Show("Debe seleccionar una factura para quitar.", "Error");
                        } else {
                                Lbl.Comprobantes.Recibo Rec = this.Elemento as Lbl.Comprobantes.Recibo;
                                string HashFacturaSeleccionada = ListaFacturas.SelectedItems[0].Text;
                                for (int i = 0; i < Rec.Facturas.Count; i++) {
                                        if (Rec.Facturas[i].GetHashCode().ToString() == HashFacturaSeleccionada) {
                                                Rec.Facturas.RemoveAt(i);
                                                break;
                                        }
                                }
                                this.MostrarFacturas();
                                if (ListaFacturas.Items.Count == 1)
                                        ListaFacturas.Items[0].Selected = true;
                        }
                }


                private void BotonValoresAgregar_Click(object sender, System.EventArgs e)
                {
                        if (this.DePago) {
                                Comprobantes.Recibos.EditarPago FormularioEditarPago = new Comprobantes.Recibos.EditarPago();
                                FormularioEditarPago.Connection = this.Connection;
                                FormularioEditarPago.Pago.FromPago(new Lbl.Comprobantes.Pago(this.Connection, Lbl.Pagos.TiposFormasDePago.Efectivo));
                                FormularioEditarPago.Pago.ObsVisible = false;

                                if (FormularioEditarPago.ShowDialog() == DialogResult.OK) {
                                        Lbl.Comprobantes.Pago MiPago = FormularioEditarPago.Pago.ToPago(this.Connection);
                                        Lbl.Comprobantes.Recibo Rec = this.Elemento as Lbl.Comprobantes.Recibo;
                                        Rec.Pagos.Add(MiPago);
                                        this.MostrarValores();
                                }
                        } else {
                                Comprobantes.Recibos.EditarCobro FormularioEditarCobro = new Comprobantes.Recibos.EditarCobro();
                                FormularioEditarCobro.Connection = this.Connection;
                                FormularioEditarCobro.Cobro.FromCobro(new Lbl.Comprobantes.Cobro(this.Connection, Lbl.Pagos.TiposFormasDePago.Efectivo));
                                FormularioEditarCobro.Cobro.ObsVisible = false;

                                if (FormularioEditarCobro.ShowDialog() == DialogResult.OK) {
                                        Lbl.Comprobantes.Cobro MiCobro = FormularioEditarCobro.Cobro.ToCobro(this.Connection);
                                        Lbl.Comprobantes.Recibo Rec = this.Elemento as Lbl.Comprobantes.Recibo;
                                        Rec.Cobros.Add(MiCobro);
                                        this.MostrarValores();
                                }
                        }
                }


                private void MostrarValores()
                {
                        ListaValores.BeginUpdate();
                        ListaValores.Items.Clear();
                        Lbl.Comprobantes.Recibo Rec = this.Elemento as Lbl.Comprobantes.Recibo;

                        if (this.DePago) {
                                foreach (Lbl.Comprobantes.Pago Pg in Rec.Pagos) {
                                        ListViewItem itm = ListaValores.Items.Add(Pg.GetHashCode().ToString());
                                        switch (Pg.FormaDePago.Tipo) {
                                                case Lbl.Pagos.TiposFormasDePago.Efectivo:
                                                        itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, Pg.FormaDePago.ToString()));
                                                        itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, Lfx.Types.Formatting.FormatCurrency(Pg.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales)));
                                                        break;
                                                case Lbl.Pagos.TiposFormasDePago.Caja:
                                                        itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, Pg.FormaDePago.ToString()));
                                                        itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, Lfx.Types.Formatting.FormatCurrency(Pg.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales)));
                                                        itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, "Débito desde " + Pg.CajaOrigen.ToString()));
                                                        break;
                                                default:
                                                        itm.SubItems.Add(Pg.FormaDePago.ToString());
                                                        itm.SubItems.Add(Lfx.Types.Formatting.FormatCurrency(Pg.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales));
                                                        itm.SubItems.Add(Pg.ToString());
                                                        break;
                                        }
                                }
                                EtiquetaValoresImporte.Text = Lfx.Types.Formatting.FormatCurrency(Rec.Pagos.ImporteTotal, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        } else {
                                foreach (Lbl.Comprobantes.Cobro Cb in Rec.Cobros) {
                                        ListViewItem itm = ListaValores.Items.Add(Cb.GetHashCode().ToString());
                                        switch (Cb.FormaDePago.Tipo) {
                                                case Lbl.Pagos.TiposFormasDePago.Efectivo:
                                                        itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, Cb.FormaDePago.ToString()));
                                                        itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, Lfx.Types.Formatting.FormatCurrency(Cb.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales)));
                                                        break;
                                                case Lbl.Pagos.TiposFormasDePago.Tarjeta:
                                                        itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, Cb.FormaDePago.ToString()));
                                                        itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, Lfx.Types.Formatting.FormatCurrency(Cb.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales)));
                                                        itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, "Cupón Nº " + Cb.Cupon.Numero + " de " + Cb.Cupon.FormaDePago.ToString()));
                                                        break;
                                                case Lbl.Pagos.TiposFormasDePago.Caja:
                                                        itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, Cb.FormaDePago.ToString()));
                                                        itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, Lfx.Types.Formatting.FormatCurrency(Cb.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales)));
                                                        itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, "Depósito en " + Cb.CajaDestino.ToString()));
                                                        break;
                                                default:
                                                        itm.SubItems.Add(Cb.FormaDePago.ToString());
                                                        itm.SubItems.Add(Lfx.Types.Formatting.FormatCurrency(Cb.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales));
                                                        itm.SubItems.Add(Cb.ToString());
                                                        break;
                                        }
                                }
                                EtiquetaValoresImporte.Text = Lfx.Types.Formatting.FormatCurrency(Rec.Cobros.ImporteTotal, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        }

                        LabelAgregarValores.Visible = ListaValores.Items.Count == 0 && this.Elemento.Existe == false;
                        BotonQuitarValor.Visible = ListaValores.Items.Count > 0;

                        if (ListaValores.Items.Count > 0 && ListaValores.SelectedItems.Count == 0) {
                                ListaValores.Items[ListaValores.Items.Count - 1].Selected = true;
                                ListaValores.Items[ListaValores.Items.Count - 1].Focused = true;
                        }

                        ListaValores.EndUpdate();
                }


                private void BotonValoresQuitar_Click(object sender, System.EventArgs e)
                {
                        if (ListaValores.SelectedItems.Count == 0 && ListaValores.Items.Count > 0)
                                ListaValores.Items[ListaValores.Items.Count - 1].Selected = true;

                        if (ListaValores.SelectedItems.Count == 0) {
                                Lui.Forms.MessageBox.Show("Debe seleccionar un valor para quitar.", "Error");
                        } else {
                                Lbl.Comprobantes.Recibo Rec = this.Elemento as Lbl.Comprobantes.Recibo;
                                ListViewItem itm = ListaValores.SelectedItems[0];
                                if (this.DePago) {
                                        for (int i = 0; i < Rec.Pagos.Count; i++) {
                                                if (Rec.Pagos[i].GetHashCode().ToString() == itm.Text) {
                                                        Rec.Pagos.RemoveAt(i);
                                                        break;
                                                }
                                        }
                                } else {
                                        for (int i = 0; i < Rec.Cobros.Count; i++) {
                                                if (Rec.Cobros[i].GetHashCode().ToString() == itm.Text) {
                                                        Rec.Cobros.RemoveAt(i);
                                                        break;
                                                }
                                        }
                                }
                                this.MostrarValores();

                                if (ListaValores.Items.Count == 1)
                                        ListaValores.Items[0].Selected = true;
                        }
                }


                private void ListaFacturas_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
                {
                        switch (e.KeyCode) {
                                case Keys.Up:
                                        if (ListaFacturas.Items.Count == 0) {
                                                System.Windows.Forms.SendKeys.Send("+{tab}");
                                        } else if (ListaFacturas.SelectedItems.Count == 0) {
                                                ListaFacturas.Items[0].Selected = true;
                                                ListaFacturas.Items[0].Focused = true;
                                        } else if (ListaFacturas.SelectedItems[0].Index > 0) {
                                                ListaFacturas.Items[ListaFacturas.SelectedItems[0].Index - 1].Selected = true;
                                                ListaFacturas.Items[ListaFacturas.SelectedItems[0].Index].Focused = true;
                                        } else {
                                                System.Windows.Forms.SendKeys.Send("+{tab}");
                                        }
                                        e.Handled = true;
                                        break;
                                case Keys.Down:
                                        if (ListaFacturas.Items.Count == 0) {
                                                System.Windows.Forms.SendKeys.Send("{tab}");
                                        } else if (ListaFacturas.SelectedItems.Count == 0) {
                                                ListaFacturas.Items[0].Selected = true;
                                                ListaFacturas.Items[0].Focused = true;
                                        } else if (ListaFacturas.SelectedItems[0].Index < ListaFacturas.Items.Count - 1) {
                                                ListaFacturas.Items[ListaFacturas.SelectedItems[0].Index + 1].Selected = true;
                                                ListaFacturas.Items[ListaFacturas.SelectedItems[0].Index].Focused = true;
                                        } else {
                                                System.Windows.Forms.SendKeys.Send("{tab}");
                                        }
                                        e.Handled = true;
                                        break;
                                case Keys.Return:
                                        System.Windows.Forms.SendKeys.Send("{tab}");
                                        e.Handled = true;
                                        break;
                        }

                }


                private void ListaValores_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
                {
                        switch (e.KeyCode) {
                                case Keys.Up:
                                        if (ListaValores.Items.Count == 0) {
                                                System.Windows.Forms.SendKeys.Send("+{tab}");
                                        } else if (ListaValores.SelectedItems.Count == 0) {
                                                ListaValores.Items[0].Selected = true;
                                                ListaValores.Items[0].Focused = true;
                                        } else if (ListaValores.SelectedItems[0].Index > 0) {
                                                ListaValores.Items[ListaValores.SelectedItems[0].Index - 1].Selected = true;
                                                ListaValores.Items[ListaValores.SelectedItems[0].Index].Focused = true;
                                        } else {
                                                System.Windows.Forms.SendKeys.Send("+{tab}");
                                        }
                                        e.Handled = true;
                                        break;
                                case Keys.Down:
                                        if (ListaValores.Items.Count == 0) {
                                                System.Windows.Forms.SendKeys.Send("{tab}");
                                        } else if (ListaValores.SelectedItems.Count == 0) {
                                                ListaValores.Items[0].Selected = true;
                                                ListaValores.Items[0].Focused = true;
                                        } else if (ListaValores.SelectedItems[0].Index < ListaValores.Items.Count - 1) {
                                                ListaValores.Items[ListaValores.SelectedItems[0].Index + 1].Selected = true;
                                                ListaValores.Items[ListaValores.SelectedItems[0].Index].Focused = true;
                                        } else {
                                                System.Windows.Forms.SendKeys.Send("{tab}");
                                        }
                                        e.Handled = true;
                                        break;
                                case Keys.Return:
                                        System.Windows.Forms.SendKeys.Send("{tab}");
                                        e.Handled = true;
                                        break;
                        }

                }


                public override void AfterSave(IDbTransaction transaction)
                {
                        Lbl.Comprobantes.Recibo Rec = this.Elemento as Lbl.Comprobantes.Recibo;
                        if (Rec.Tipo.ImprimirAlGuardar) {
                                Lazaro.Base.Util.Impresion.Comprobantes.ImpresorRecibo Impresor = new Lazaro.Base.Util.Impresion.Comprobantes.ImpresorRecibo(Rec, transaction);
                                Impresor.Imprimir();
                        }
                        base.AfterSave(transaction);
                }


                public override bool PuedeEditar()
                {
                        if (this.Elemento.Existe)
                                return false;

                        return base.PuedeEditar();
                }

                private void LabelAgregarFacturas_Click(object sender, EventArgs e)
                {
                        BotonAgregarFactura.PerformClick();
                }

                private void LabelAgregarValores_Click(object sender, EventArgs e)
                {
                        BotonAgregarValor.PerformClick();
                }


                public override Lazaro.Pres.DisplayStyles.IDisplayStyle HeaderDisplayStyle
                {
                        get
                        {
                                return Lazaro.Pres.DisplayStyles.Template.Current.Comprobantes;
                        }
                }
        }
}