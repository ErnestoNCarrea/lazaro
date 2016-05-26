using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Articulos
{
        public partial class EditarSeguimiento : Lui.Forms.DialogForm
        {
                public Lbl.Articulos.Situacion SituacionOrigen;
                private Lbl.Articulos.Articulo m_Articulo;
                private int m_Cantidad = 1;
                private Lbl.Articulos.ColeccionDatosSeguimiento m_DatosSeguimiento = null;
                private bool TextoLibre = false;

                public EditarSeguimiento()
                {
                        InitializeComponent();
                }


                public Lbl.Articulos.Articulo Articulo
                {
                        get
                        {
                                return m_Articulo;
                        }
                        set
                        {
                                m_Articulo = value;
                                this.Actualizar();
                        }
                }


                public int Cantidad
                {
                        get
                        {
                                return m_Cantidad;
                        }
                        set
                        {
                                m_Cantidad = value;
                                this.Actualizar();
                        }
                }


                private void Actualizar()
                {
                        string Ayuda;
                        if (m_Articulo != null) {
                                Ayuda = "Proporcione los datos de " + Articulo.ToString();
                                switch (m_Articulo.ObtenerSeguimiento()) {
                                        case Lbl.Articulos.Seguimientos.NumerosDeSerie:
                                                VariacionesCantidades.EsNumeroDeSerie = true;
                                                break;
                                        case Lbl.Articulos.Seguimientos.TallesYColores:
                                                VariacionesCantidades.EsNumeroDeSerie = false;
                                                break;
                                }
                        } else {
                                Ayuda = "Seguimiento";
                        }
                        EtiquetaArticulo.Text = Ayuda;
                }


                public Lbl.Articulos.ColeccionDatosSeguimiento DatosSeguimiento
                {
                        get
                        {
                                if (TextoLibre) {
                                        return VariacionesCantidades.DatosSeguimiento;
                                } else {
                                        Lbl.Articulos.ColeccionDatosSeguimiento Res = new Lbl.Articulos.ColeccionDatosSeguimiento();
                                        if (ListaDatosSeguimiento.CheckedItems == null || ListaDatosSeguimiento.CheckedItems.Count == 0)
                                                return null;
                                        foreach (ListViewItem Itm in ListaDatosSeguimiento.CheckedItems) {
                                                if (Res.ContainsKey(Itm.Text))
                                                        Res[Itm.Text].Cantidad += Lfx.Types.Parsing.ParseInt(Itm.SubItems[1].Text);
                                                else
                                                        Res.AddWithValue(Itm.Text, Lfx.Types.Parsing.ParseInt(Itm.SubItems[1].Text));
                                        }
                                        return Res;
                                }
                        }
                        set
                        {
                                m_DatosSeguimiento = value;
                                this.RefreshList();
                        }
                }

                public override Lfx.Types.OperationResult Ok()
                {
                        decimal CantidadSelect = 0;

                        if (TextoLibre) {
                                CantidadSelect = VariacionesCantidades.DatosSeguimiento.CantidadTotal;
                        } else {
                                if (VariacionesCantidades.EsNumeroDeSerie && ListaDatosSeguimiento.CheckedItems.Count == 0 && ListaDatosSeguimiento.SelectedItems.Count == 1)
                                        ListaDatosSeguimiento.SelectedItems[0].Checked = true;
                                CantidadSelect = ListaDatosSeguimiento.CheckedItems.Count;
                        }

                        m_Cantidad = System.Convert.ToInt32(CantidadSelect);
                        return base.Ok();
                }

                private void RefreshList()
                {
                        if (SituacionOrigen != null && SituacionOrigen.CuentaExistencias) {
                                Lbl.Articulos.ColeccionDatosSeguimiento SelectedSeries = new Lbl.Articulos.ColeccionDatosSeguimiento();
                                if (m_DatosSeguimiento != null && m_DatosSeguimiento.Count > 0)
                                        SelectedSeries.AddRange(m_DatosSeguimiento);

                                ListaDatosSeguimiento.BeginUpdate();
                                ListaDatosSeguimiento.Items.Clear();

                                System.Data.DataTable TablaListaItem = this.Connection.Select("SELECT serie, cantidad FROM articulos_series WHERE id_articulo=" + this.Articulo.Id.ToString() + " AND cantidad>0 AND id_situacion=" + this.SituacionOrigen.Id.ToString());
                                foreach (System.Data.DataRow RowItem in TablaListaItem.Rows) {
                                        string Variacion = RowItem["serie"].ToString();
                                        decimal StockVariacion = System.Convert.ToDecimal(RowItem["cantidad"]);

                                        ListViewItem Itm = ListaDatosSeguimiento.Items.Add(Variacion);
                                        Itm.UseItemStyleForSubItems = false;
                                        Itm.SubItems[0].Text = Variacion;
                                        Itm.SubItems.Add("0");
                                        Itm.SubItems.Add(System.Convert.ToInt32(StockVariacion).ToString());
                                        Itm.SubItems[2].ForeColor = this.DisplayStyle.DataAreaGrayTextColor;
                                        if (SelectedSeries.ContainsKey(Variacion)) {
                                                if (SelectedSeries[Variacion].Cantidad-- > 0)
                                                        Itm.Checked = SelectedSeries.ContainsKey(Variacion);
                                        }
                                }

                                ListaDatosSeguimiento.CheckBoxes = true;
                                ListaDatosSeguimiento.EndUpdate();
                                ListaDatosSeguimiento.Visible = true;
                                if (ListaDatosSeguimiento.Items.Count > 0) {
                                        ListaDatosSeguimiento.Items[0].Selected = true;
                                        ListaDatosSeguimiento.Items[0].Focused = true;
                                }
                                VariacionesCantidades.Visible = false;
                                TextoLibre = false;
                        } else {
                                ListaDatosSeguimiento.Visible = false;
                                VariacionesCantidades.Visible = true;
                                TextoLibre = true;
                                VariacionesCantidades.DatosSeguimiento = m_DatosSeguimiento;
                        }
                }

                private void EditarSeries_KeyDown(object sender, KeyEventArgs e)
                {
                        if (e.KeyCode == Keys.S && e.Control == true && e.Alt == false && e.Shift == false) {
                                ListaDatosSeguimiento.Visible = false;
                                VariacionesCantidades.Visible = true;
                                TextoLibre = true;
                        }
                }

                private void ListaSeries_KeyDown(object sender, KeyEventArgs e)
                {
                        if (e.Control == false && e.Alt == false && e.Shift == false) {
                                switch (e.KeyCode) {
                                        case Keys.Return:
                                                if (ListaDatosSeguimiento.CheckBoxes == true && ListaDatosSeguimiento.CheckedItems.Count == 0 && ListaDatosSeguimiento.SelectedItems.Count == 1)
                                                        // Si no hay ninguno tildado, tildo el elemento seleccionado
                                                        ListaDatosSeguimiento.SelectedItems[0].Checked = true;

                                                OkButton.PerformClick();
                                                e.Handled = true;
                                                break;
                                }
                        }
                }

                private void ListaDatosSeguimiento_KeyPress(object sender, KeyPressEventArgs e)
                {
                        if (VariacionesCantidades.EsNumeroDeSerie == false) {
                                ListViewItem Itm = null;
                                decimal Cantidad = 0, StockActual = 0;
                                if (ListaDatosSeguimiento.Visible && ListaDatosSeguimiento.SelectedItems.Count > 0) {
                                        Itm = ListaDatosSeguimiento.SelectedItems[0];
                                        Cantidad = Lfx.Types.Parsing.ParseStock(Itm.SubItems[1].Text);
                                        StockActual = Lfx.Types.Parsing.ParseStock(Itm.SubItems[2].Text);
                                }
                                decimal CantidadOriginal = Cantidad;

                                switch (e.KeyChar) {
                                        case '+':
                                                Cantidad++;
                                                e.Handled = true;
                                                break;
                                        case '-':
                                                Cantidad--;
                                                e.Handled = true;
                                                break;
                                        case '0':
                                                string NewCant = Lui.Forms.InputBox.ShowInputBox("Escriba la cantidad");
                                                Cantidad = Lfx.Types.Parsing.ParseInt(NewCant);
                                                e.Handled = true;
                                                break;
                                        case '1':
                                        case '2':
                                        case '3':
                                        case '4':
                                        case '5':
                                        case '6':
                                        case '7':
                                        case '8':
                                        case '9':
                                                Cantidad = int.Parse(e.KeyChar.ToString());
                                                e.Handled = true;
                                                break;
                                }

                                if (Cantidad > StockActual)
                                        Cantidad = StockActual;
                                if (Cantidad < 0)
                                        Cantidad = 0;

                                if (Itm != null && Cantidad >= 0 && Cantidad != CantidadOriginal) {
                                        Itm.SubItems[1].Text = Cantidad.ToString();
                                        Itm.Checked = Cantidad > 0;
                                }
                        }
                }

                private void ListaDatosSeguimiento_ItemChecked(object sender, ItemCheckedEventArgs e)
                {
                        if (e.Item.Checked) {
                                if (e.Item.SubItems[1].Text == "0")
                                        e.Item.SubItems[1].Text = "1";
                        } else {
                                if (e.Item.SubItems[1].Text != "0")
                                        e.Item.SubItems[1].Text = "0";
                        }
                }
        }
}

