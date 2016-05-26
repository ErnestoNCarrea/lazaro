using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lcc.Entrada.AuxForms
{
        public partial class DetailBoxQuickSelect : Lui.Forms.Form, Lui.Forms.IDataForm
        {
                private string m_Table = "";
                private string m_KeyField = "";
                private string m_DetailField = "";
                private string m_ExtraDetailFields = "";
                private string m_Filter = "";
                private bool m_IgnoreEvents;

                public System.Windows.Forms.Control ControlDestino { get; set; }
                public Type ElementoTipo { get; set; }

                public DetailBoxQuickSelect()
                {
                        InitializeComponent();
                }


                protected override void OnLoad(EventArgs e)
                {
                        base.OnLoad(e);
                        if (Lfx.Workspace.Master == null || Lfx.Workspace.Master.SlowLink)
                                Timer1.Interval = 750;
                        else
                                Timer1.Interval = 75;
                }


                public bool CanCreate
                {
                        set
                        {
                                BotonNuevo.Visible = value;
                                if (value)
                                        EntradaBuscar.Width = BotonNuevo.Left - (EntradaBuscar.Left * 2);
                                else
                                        EntradaBuscar.Width = this.ClientSize.Width - (EntradaBuscar.Left * 2);
                        }
                }

                [System.ComponentModel.Category("Datos")]
                public string Table
                {
                        get
                        {
                                return m_Table;
                        }
                        set
                        {
                                m_Table = value;
                                UpdateDetail();
                        }
                }

                [System.ComponentModel.Category("Datos")]
                public string KeyField
                {
                        set
                        {
                                m_KeyField = value;
                                UpdateDetail();
                        }
                }

                [System.ComponentModel.Category("Datos")]
                public string DetailField
                {
                        set
                        {
                                m_DetailField = value;
                                UpdateDetail();
                        }
                }


                [System.ComponentModel.Category("Datos")]
                public string ExtraDetailFields
                {
                        set
                        {
                                m_ExtraDetailFields = value;
                                UpdateDetail();
                        }
                }

                [System.ComponentModel.Category("Datos")]
                public string Filter
                {
                        set
                        {
                                m_Filter = value;
                                UpdateDetail();
                        }
                }

                private void UpdateDetail()
                {
                        int CamposExtra = 0;

                        if (m_Table == "articulos" && (m_ExtraDetailFields == null || m_ExtraDetailFields.Length == 0))
                                m_ExtraDetailFields = "codigo1,codigo2,codigo3,codigo4";
                        else if (m_Table == "personas" && (m_ExtraDetailFields == null || m_ExtraDetailFields.Length == 0))
                                m_ExtraDetailFields = "num_doc,cuit,extra1";
                        else if (m_Table == "ciudades" && (m_ExtraDetailFields == null || m_ExtraDetailFields.Length == 0))
                                m_ExtraDetailFields = "cp,(SELECT nombre FROM ciudades b WHERE b.id_ciudad=ciudades.id_provincia)";
                        else if (m_Table == "tipo_doc" && (m_ExtraDetailFields == null || m_ExtraDetailFields.Length == 0)) {
                                m_ExtraDetailFields = "nombre";
                                m_DetailField = "descripcion";
                        }

                        if (m_ExtraDetailFields != null)
                                CamposExtra = m_ExtraDetailFields.Length - m_ExtraDetailFields.Replace(",", "").Length + 1;

                        if (CamposExtra > 4)
                                CamposExtra = 4;

                        this.Width = 480 + (80 * CamposExtra);
                        if (ListaItem.Columns.Count > 0)
                                ListaItem.Columns[1].Width = ListaItem.Width - ListaItem.Columns[0].Width - (80 * CamposExtra) - 20;

                        if (CamposExtra >= 1)
                                extra1.Width = 80;
                        else
                                extra1.Width = 0;

                        if (CamposExtra >= 2)
                                extra1.Width = 80;
                        else
                                extra2.Width = 0;

                        if (CamposExtra >= 3)
                                extra1.Width = 80;
                        else
                                extra3.Width = 0;

                        if (CamposExtra >= 4)
                                extra1.Width = 80;
                        else
                                extra4.Width = 0;
                }


                public DialogResult Buscar(string valorInicial)
                {
                        Refrescar();
                        m_IgnoreEvents = true;
                        EntradaBuscar.Text = valorInicial.Trim();
                        m_IgnoreEvents = false;
                        EntradaBuscar.SelectionLength = 0;
                        EntradaBuscar.SelectionStart = EntradaBuscar.Text.Length;
                        this.Refrescar();
                        if (!this.Visible)
                                return this.ShowDialog();
                        else
                                return System.Windows.Forms.DialogResult.Retry;
                }

                internal void Refrescar()
                {
                        ListaItem.Items.Clear();
                        if (this.Connection != null) {
                                if (m_Table.Length > 0 && m_KeyField.Length > 0 && m_DetailField != null && m_DetailField.Length > 0) {
                                        string TextoSql = null;
                                        string sBuscar = EntradaBuscar.Text;

                                        sBuscar = this.Connection.EscapeString(sBuscar.Replace("  ", " ").Trim());

                                        if (m_Table.Length >= 7 && m_Table.Substring(0, 7) == "SELECT ") {
                                                TextoSql = m_Table;
                                        } else {
                                                TextoSql = "SELECT " + m_KeyField + ", " + m_DetailField;
                                                if (m_ExtraDetailFields != null && m_ExtraDetailFields.Length > 0)
                                                        TextoSql += ", " + m_ExtraDetailFields;

                                                // Si es la tabla de artículos, muestro algunas cosas más
                                                if (m_Table == "articulos")
                                                        TextoSql += ", control_stock, stock_actual, pedido, destacado";

                                                TextoSql += " FROM " + m_Table;
                                                bool AgregueWhere = false;
                                                if (sBuscar != null && sBuscar.Length > 1) {
                                                        TextoSql += " WHERE (" + m_DetailField + " LIKE '%" + sBuscar.Replace(" ", "%' AND " + m_DetailField + " LIKE '%") + "%'";
                                                        AgregueWhere = true;
                                                } else if (sBuscar != null && sBuscar.Length > 0) {
                                                        TextoSql += " WHERE (" + m_DetailField + " LIKE '" + this.Connection.EscapeString(sBuscar) + "%'";
                                                        AgregueWhere = true;
                                                }

                                                if (m_ExtraDetailFields != null && m_ExtraDetailFields.Length > 0 && sBuscar != null && sBuscar.Length > 1) {
                                                        string TempExtraDetailFields = m_ExtraDetailFields;
                                                        string TempWhere = "";
                                                        string ExtraField = Lfx.Types.Strings.GetNextToken(ref TempExtraDetailFields, ",");
                                                        while (ExtraField.Length > 0) {
                                                                if (TempWhere.Length == 0)
                                                                        TempWhere += ExtraField + " LIKE '%" + sBuscar + "%'";
                                                                else
                                                                        TempWhere += " OR " + ExtraField + " LIKE '%" + sBuscar + "%'";
                                                                ExtraField = Lfx.Types.Strings.GetNextToken(ref TempExtraDetailFields, ",");
                                                        }
                                                        TextoSql += " OR (" + TempWhere + ")";
                                                }
                                                if (AgregueWhere)
                                                        TextoSql += ") ";

                                                if (m_Filter != null && m_Filter.Length > 0) {
                                                        if (AgregueWhere)
                                                                TextoSql += " AND (" + m_Filter + ")";
                                                        else
                                                                TextoSql += " WHERE " + m_Filter;
                                                }

                                                if (m_Table == "articulos")
                                                        TextoSql += " ORDER BY IF(stock_actual+pedido>0,0,1), " + m_DetailField;
                                                else
                                                        TextoSql += " ORDER BY " + m_DetailField;

                                                // TODO: Código dependiente de MySql/PostgreSql. Pasar a qGen.SqlCommandBuilder
                                                if (Lfx.Workspace.Master.SlowLink)
                                                        TextoSql += " LIMIT 40";
                                                else
                                                        TextoSql += " LIMIT 100";
                                        }

                                        System.Data.DataTable TableRes = this.Connection.Select(TextoSql);
                                        ListaItem.SuspendLayout();
                                        ListaItem.BeginUpdate();
                                        foreach (System.Data.DataRow OrgRow in TableRes.Rows) {
                                                Lfx.Data.Row RowRes = (Lfx.Data.Row)OrgRow;
                                                ListViewItem itm = ListaItem.Items.Add(RowRes.Fields[m_KeyField].ValueInt.ToString("00000"));
                                                itm.SubItems.Add(new ListViewItem.ListViewSubItem(itm, RowRes.Fields[m_DetailField].ValueString));
                                                if (m_ExtraDetailFields != null && m_ExtraDetailFields.Length > 0) {
                                                        string TempExtraDetailFields = m_ExtraDetailFields;
                                                        string Campo = Lfx.Types.Strings.GetNextToken(ref TempExtraDetailFields, ",").Trim();
                                                        while (Campo.Length > 0) {
                                                                if (RowRes.Fields[Campo].Value == null) {
                                                                        itm.SubItems.Add("");
                                                                } else {
                                                                        switch (RowRes[Campo].GetType().ToString()) {
                                                                                case "System.Single":
                                                                                case "System.Double":
                                                                                case "System.Decimal":
                                                                                        itm.SubItems.Add(Lfx.Types.Formatting.FormatNumber(RowRes.Fields[Campo].ValueDecimal, 4));
                                                                                        break;

                                                                                default:
                                                                                        itm.SubItems.Add(System.Convert.ToString(RowRes.Fields[Campo].Value));
                                                                                        break;
                                                                        }
                                                                }

                                                                Campo = Lfx.Types.Strings.GetNextToken(ref TempExtraDetailFields, ",").Trim();
                                                        }
                                                }
                                                // TODO: que tome m_ExtraDetailFields esto en cuenta
                                                if (m_Table == "articulos") {
                                                        if (System.Convert.ToInt32(RowRes["control_stock"]) != 0 && System.Convert.ToDouble(RowRes["stock_actual"]) <= 0) {
                                                                // No hay stock.
                                                                if (System.Convert.ToDouble(RowRes["pedido"]) + System.Convert.ToDouble(RowRes["stock_actual"]) > 0) {
                                                                        // Pero hay pedido suficiente para cubrir un stock negativo y sobra
                                                                        itm.ForeColor = System.Drawing.Color.OrangeRed;
                                                                        itm.Font = new Font(itm.Font, FontStyle.Regular);
                                                                } else {
                                                                        itm.ForeColor = System.Drawing.Color.Red;
                                                                        itm.Font = new Font(itm.Font, FontStyle.Strikeout);
                                                                }
                                                        } else if (System.Convert.ToInt32(RowRes["destacado"]) != 0) {
                                                                itm.ForeColor = System.Drawing.Color.DarkGreen;
                                                                itm.Font = new Font(itm.Font, FontStyle.Regular);
                                                        }
                                                }
                                        }
                                        ListaItem.EndUpdate();
                                        ListaItem.ResumeLayout();

                                        if (ListaItem.Items.Count > 0)
                                                ListaItem.Items[0].Selected = true;
                                }
                        }
                }


                private void EntradaBuscar_TextChanged(object sender, System.EventArgs e)
                {
                        if (m_IgnoreEvents == false && this.Connection != null)
                                Timer1.Start();
                }


                private void EntradaBuscar_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
                {
                        byte Tecla = System.Text.Encoding.ASCII.GetBytes(System.Convert.ToString(e.KeyChar))[0];
                        if (Tecla == System.Convert.ToByte(Keys.Escape)) {
                                e.Handled = true;
                                this.Close();
                        } else if (Tecla == System.Convert.ToByte(Keys.Return)) {
                                e.Handled = true;
                                this.DarleEnter();
                        }
                }


                private void EntradaBuscar_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
                {
                        if (ListaItem.Items.Count > 0) {
                                switch (e.KeyCode) {
                                        case Keys.Up:
                                                if (ListaItem.SelectedItems.Count == 0)
                                                        ListaItem.SelectedItems[0].Selected = true;
                                                else if (ListaItem.SelectedItems[0].Index > 0)
                                                        ListaItem.Items[ListaItem.SelectedItems[0].Index - 1].Selected = true;
                                                e.Handled = true;
                                                break;
                                        case Keys.Down:
                                                if (ListaItem.SelectedItems.Count == 0)
                                                        ListaItem.SelectedItems[0].Selected = true;
                                                else if (ListaItem.SelectedItems[0].Index < ListaItem.Items.Count - 1)
                                                        ListaItem.Items[ListaItem.SelectedItems[0].Index + 1].Selected = true;
                                                e.Handled = true;
                                                break;
                                        case Keys.PageUp:
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Up));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Up));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Up));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Up));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Up));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Up));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Up));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Up));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Up));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Up));
                                                break;
                                        case Keys.PageDown:
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Down));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Down));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Down));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Down));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Down));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Down));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Down));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Down));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Down));
                                                this.EntradaBuscar_KeyDown(sender, new System.Windows.Forms.KeyEventArgs(Keys.Down));
                                                break;
                                }
                        }
                }


                private void ListaItem_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
                {
                        byte Tecla = System.Text.Encoding.ASCII.GetBytes(System.Convert.ToString(e.KeyChar))[0];
                        if (Tecla == System.Convert.ToByte(Keys.Return)) {
                                e.Handled = true;
                                this.DarleEnter();
                        } else if (Tecla == System.Convert.ToByte(Keys.Escape)) {
                                e.Handled = true;
                                this.Close();
                        } else if (Tecla == System.Convert.ToByte(Keys.Back)) {
                                if (EntradaBuscar.Text.Length > 0) {
                                        e.Handled = true;
                                        EntradaBuscar.Text = EntradaBuscar.Text.Substring(0, EntradaBuscar.Text.Length - 1);
                                }
                                e.Handled = true;
                        } else if ((@"ABCDEFGHIJKLMNOPQRSTUVWXYZ* """).IndexOf(char.ToUpper(e.KeyChar)) != -1) {
                                e.Handled = true;
                                EntradaBuscar.Text += System.Convert.ToString(e.KeyChar);
                        }
                }


                internal void DarleEnter()
                {
                        if (ListaItem.SelectedItems.Count > 0) {
                                if (m_Table == "articulos") {
                                        string Codigo = this.Connection.FieldString("SELECT " + Lfx.Workspace.Master.CurrentConfig.Productos.CodigoPredeterminado() + " FROM articulos WHERE id_articulo=" + int.Parse(ListaItem.SelectedItems[0].Text).ToString());
                                        if (Codigo.Length == 0)
                                                Codigo = int.Parse(ListaItem.SelectedItems[0].Text).ToString();
                                        ControlDestino.Text = Codigo;
                                        if (ControlDestino is Lui.Forms.IEditableControl)
                                                ((Lui.Forms.IEditableControl)(ControlDestino)).Changed = true;
                                } else {
                                        ControlDestino.Text = int.Parse(ListaItem.SelectedItems[0].Text).ToString();
                                        if (ControlDestino is Lui.Forms.IEditableControl)
                                                ((Lui.Forms.IEditableControl)(ControlDestino)).Changed = true;
                                }
                                this.Close();
                        }
                }


                private void BotonNuevo_Click(object sender, System.EventArgs e)
                {
                        this.Hide();
                        object Resultado = null;

                        if (this.ElementoTipo == null && m_Table == "personas") {
                                // Esta es una excepción para reconocer cuando se está creando un proveedor
                                if (m_Filter != null && m_Filter.IndexOf("tipo&2") >= 0)
                                        this.ElementoTipo = typeof(Lbl.Personas.Proveedor);
                                else
                                        this.ElementoTipo = typeof(Lbl.Personas.Persona);
                        }

                        try {
                                if (this.ElementoTipo != null)
                                        Resultado = Lfx.Workspace.Master.RunTime.Execute("CREATE", new string[] { ElementoTipo.ToString() });

                                if (Resultado == null)
                                        Resultado = Lfx.Workspace.Master.RunTime.Execute("CREATE", new string[] { m_Table });
                        } catch {
                                Lfx.Workspace.Master.RunTime.Toast("No se puede crear el elemento.", "Error");
                        }
                        
                        if (Resultado == null) {
                                // No se puede crear
                                this.Show();
                        } else if (Resultado.GetType().ToString() == "Lfc.FormularioEdicion") {
                                // Como no puedo establecer la propiedad porque no conozco el tipo Lfc.FormularioEdicion,
                                // lo hago usando reflexión
                                System.Type Tipo = Resultado.GetType();
                                System.Reflection.PropertyInfo PropInfo = Tipo.GetProperty("ControlDestino");
                                if (PropInfo != null)
                                        PropInfo.SetValue(Resultado, this.ControlDestino, null);
                                this.DialogResult = DialogResult.Retry;
                                this.Tag = Resultado;
                                this.Close();
                        } else if (Resultado is Form) {
                                this.DialogResult = DialogResult.Retry;
                                this.Close();
                        } else if (Resultado is Lfx.Types.OperationResult) {
                                Lfx.Workspace.Master.RunTime.Toast(((Lfx.Types.OperationResult)(Resultado)).Message, "Mensaje");
                        } else {
                                // Devolvió algo raro.
                        }
                }


                public void VerDetalles()
                {
                        if (ListaItem.SelectedItems.Count > 0) {
                                int ItemId = int.Parse(ListaItem.SelectedItems[0].Text);
                                if (ItemId > 0)
                                        Lfx.Workspace.Master.RunTime.Info("ITEMFOCUS", new string[] { "TABLE", this.Table, ItemId.ToString() });
                        }
                }


                private void ListaItem_SelectedIndexChanged(object sender, System.EventArgs e)
                {
                        if (ListaItem.SelectedItems.Count > 0) {
                                ListaItem.Items[ListaItem.SelectedItems[0].Index].Focused = true;
                                ListaItem.Items[ListaItem.SelectedItems[0].Index].EnsureVisible();
                        }
                        VerDetalles();
                }


                private void Timer1_Tick(System.Object sender, System.EventArgs e)
                {
                        this.Refrescar();
                        Timer1.Enabled = false;
                }

                private void ListaItem_DoubleClick(object sender, System.EventArgs e)
                {
                        DarleEnter();
                }


                private void DetailBoxQuickSelect_KeyDown(object sender, KeyEventArgs e)
                {
                        if (e.Alt == false && e.Control == false) {
                                switch(e.KeyCode) {
                                        case Keys.F6:
                                                e.Handled = true;
                                                if (BotonNuevo.Visible && BotonNuevo.Enabled)
                                                        BotonNuevo.PerformClick();
                                                break;
                                }
                        }
                }
        }
}