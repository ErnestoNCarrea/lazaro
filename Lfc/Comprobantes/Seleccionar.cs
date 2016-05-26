using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Comprobantes
{
        public partial class Seleccionar : Lui.Forms.DialogForm
        {
                public enum TiposComprob
                {
                        FacturasNDyND,
                        Remitos,
                        Presupuestos
                }

                public bool AceptarAnuladas = false, AceptarNoImpresas = false, AceptarCanceladas = true, DeCompra = false;
                private Lbl.Comprobantes.ComprobanteConArticulos m_Comprobante;
                private TiposComprob m_TipoComprob;

                public Seleccionar()
                {
                        InitializeComponent();
                }


                public Lbl.Comprobantes.ComprobanteConArticulos Comprobante
                {
                        get
                        {
                                return m_Comprobante;
                        }
                        set
                        {
                                m_Comprobante = value;
                        }
                }



                public Lbl.Personas.Persona Cliente
                {
                        get
                        {
                                return EntradaCliente.Elemento as Lbl.Personas.Persona;
                        }
                        set
                        {
                                EntradaCliente.Elemento = value;
                        }
                }


                public TiposComprob TipoComprob
                {
                        get
                        {
                                return m_TipoComprob;
                        }
                        set
                        {
                                m_TipoComprob = value;
                                switch (m_TipoComprob) {
                                        case Seleccionar.TiposComprob.FacturasNDyND:
                                                this.EntradaTipo.SetData = new string[] {
                                                        "Facturas A|A",
                                                        "Facturas B|B",
                                                        "Facturas C|C",
                                                        "Facturas E|E",
                                                        "Facturas M|M",
                                                        "Todas|*"};
                                                this.EntradaTipo.TextKey = "*";
                                                ColCancelada.Width = 120;
                                                break;
                                        case Seleccionar.TiposComprob.Presupuestos:
                                                this.EntradaTipo.SetData = new string[] {
                                                        "Presupuestos|PS"};
                                                this.EntradaTipo.TextKey = "PS";
                                                ColCancelada.Width = 0;
                                                break;
                                        case Seleccionar.TiposComprob.Remitos:
                                                this.EntradaTipo.SetData = new string[] {
                                                        "Remitos|R"};
                                                this.EntradaTipo.TextKey = "R";
                                                ColCancelada.Width = 0;
                                                break;
                                }
                        }
                }


                private void EntradaVendedorClienteTipoPVNumero_TextChanged(System.Object sender, System.EventArgs e)
                {
                        qGen.Select SelFac = new qGen.Select("comprob");
                        SelFac.WhereClause = new qGen.Where();

                        if (EntradaVendedor.ValueInt > 0)
                                SelFac.WhereClause.AddWithValue("id_vendedor", EntradaVendedor.ValueInt);

                        if (EntradaCliente.ValueInt > 0)
                                SelFac.WhereClause.AddWithValue("id_cliente", EntradaCliente.ValueInt);

                        if (this.AceptarCanceladas == false)
                                SelFac.WhereClause.AddWithValue("cancelado", qGen.ComparisonOperators.LessThan, new qGen.SqlExpression("total"));

                        if (this.DeCompra) {
                                SelFac.WhereClause.AddWithValue("compra", qGen.ComparisonOperators.NotEqual, 0);
                        } else {
                                SelFac.WhereClause.AddWithValue("compra", 0);
                                if (this.AceptarNoImpresas == false)
                                        SelFac.WhereClause.AddWithValue("impresa", qGen.ComparisonOperators.NotEqual, 0);
                        }

                        if (this.AceptarAnuladas == false)
                                SelFac.WhereClause.AddWithValue("anulada", 0);

                        switch (EntradaTipo.TextKey) {
                                case "A":
                                case "B":
                                case "C":
                                case "E":
                                case "M":
                                        SelFac.WhereClause.AddWithValue("tipo_fac", qGen.ComparisonOperators.In, new string[] { "F" + EntradaTipo.TextKey, "NC" + EntradaTipo.TextKey, "ND" + EntradaTipo.TextKey });
                                        break;
                                case "*":
                                        SelFac.WhereClause.AddWithValue("tipo_fac", qGen.ComparisonOperators.In, new string[] { "FA", "FB", "FC", "FM", "FE", "NCA", "NCB", "NCC", "NCM", "NCE", "NDA", "NDB", "NDC", "NDM", "NDE" });
                                        break;
                                case "PS":
                                        SelFac.WhereClause.AddWithValue("tipo_fac", "PS");
                                        break;
                                case "R":
                                        SelFac.WhereClause.AddWithValue("tipo_fac", "R");
                                        break;
                        }

                        if (EntradaPv.ValueInt > 0)
                                SelFac.WhereClause.AddWithValue("pv", EntradaPv.ValueInt);

                        if (EntradaNumero.ValueInt > 0)
                                SelFac.WhereClause.AddWithValue("numero", EntradaNumero.ValueInt);

                        SelFac.Order = "fecha DESC";
                        DataTable Facturas = this.Connection.Select(SelFac);

                        Listado.BeginUpdate();
                        Listado.Items.Clear();
                        foreach (System.Data.DataRow RowFactura in Facturas.Rows) {
                                ListViewItem Itm = Listado.Items.Add(System.Convert.ToString(RowFactura["id_comprob"]));
                                Itm.Tag = RowFactura;
                                Itm.SubItems.Add(new ListViewItem.ListViewSubItem(Itm, Lfx.Types.Formatting.FormatDate(RowFactura["fecha"])));
                                Itm.SubItems.Add(new ListViewItem.ListViewSubItem(Itm, System.Convert.ToString(RowFactura["tipo_fac"])));
                                Itm.SubItems.Add(new ListViewItem.ListViewSubItem(Itm, System.Convert.ToInt32(RowFactura["pv"]).ToString("0000") + "-" + System.Convert.ToInt32(RowFactura["numero"]).ToString("00000000")));
                                Itm.SubItems.Add(new ListViewItem.ListViewSubItem(Itm, this.Connection.FieldString("SELECT nombre_visible FROM personas WHERE id_persona=" + RowFactura["id_cliente"].ToString())));
                                Itm.SubItems.Add(new ListViewItem.ListViewSubItem(Itm, Lfx.Types.Formatting.FormatCurrency(System.Convert.ToDecimal(RowFactura["total"]), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales)));
                                if (System.Convert.ToDouble(RowFactura["cancelado"]) >= System.Convert.ToDouble(RowFactura["total"]))
                                        Itm.SubItems.Add(new ListViewItem.ListViewSubItem(Itm, "Sí"));
                                else
                                        Itm.SubItems.Add(new ListViewItem.ListViewSubItem(Itm, Lfx.Types.Formatting.FormatCurrency(System.Convert.ToDecimal(RowFactura["cancelado"]), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales)));
                        }
                        if (Listado.Items.Count > 0) {
                                Listado.Items[0].Selected = true;
                                Listado.Items[0].Focused = true;
                        }
                        Listado.EndUpdate();
                }


                private void Listado_SelectedIndexChanged(object sender, System.EventArgs e)
                {
                        System.Data.DataRow RowFactura = null;
                        ListViewItem Itm = null;
                        if (Listado.SelectedItems.Count > 0) {
                                Itm = Listado.SelectedItems[0];
                                RowFactura = Listado.SelectedItems[0].Tag as System.Data.DataRow;
                        }

                        if (RowFactura != null) {
                                Lbl.Comprobantes.ComprobanteFacturable Factura = new Lbl.Comprobantes.ComprobanteFacturable(this.Connection, (Lfx.Data.Row)RowFactura);
                                this.Comprobante = Factura;
                                if (this.Comprobante.Anulado && AceptarAnuladas == false) {
                                        EtiquetaAviso.Text = "Este comprobante fue anulado.";
                                        OkButton.Visible = false;
                                } else if (Factura.Cancelado && AceptarCanceladas == false) {
                                        EtiquetaAviso.Text = "Comprobante ya fue pagado.";
                                        OkButton.Visible = false;
                                } else if (Factura.ImporteCancelado > 0 && Factura.Cancelado == false) {
                                        EtiquetaAviso.Text = "Este comprobante fue pagado parcialmente.";
                                        OkButton.Visible = true;
                                } else {
                                        EtiquetaAviso.Text = "";
                                        OkButton.Visible = true;
                                }
                        } else {
                                EtiquetaAviso.Text = "";
                                OkButton.Visible = false;
                        }
                }


                private void Listado_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
                {
                        switch (e.KeyCode) {
                                case Keys.Up:
                                        if (Listado.Items.Count == 0) {
                                                e.Handled = true;
                                                System.Windows.Forms.SendKeys.Send("+{tab}");
                                        } else if (Listado.SelectedItems[0].Index == 0) {
                                                e.Handled = true;
                                                System.Windows.Forms.SendKeys.Send("+{tab}");
                                        }
                                        break;
                                case Keys.Down:
                                        if (Listado.Items.Count == 0) {
                                                e.Handled = true;
                                                System.Windows.Forms.SendKeys.Send("{tab}");
                                        } else if (Listado.SelectedItems.Count > 0 && Listado.SelectedItems[0].Index == Listado.Items.Count - 1) {
                                                e.Handled = true;
                                                System.Windows.Forms.SendKeys.Send("{tab}");
                                        }
                                        break;
                                case Keys.Return:
                                        e.Handled = true;
                                        if (OkButton.Visible && OkButton.Enabled)
                                                OkButton.PerformClick();
                                        break;
                        }
                }

                private void Listado_DoubleClick(object sender, EventArgs e)
                {
                        if (OkButton.Visible && OkButton.Enabled)
                                OkButton.PerformClick();
                }
        }
}
