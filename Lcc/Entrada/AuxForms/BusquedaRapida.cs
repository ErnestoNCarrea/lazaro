using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lcc.Entrada.AuxForms
{
        public partial class BusquedaRapida : Lui.Forms.Form, Lui.Forms.IDataForm, IFormularioBusqueda
        {
                private string m_Table = "";
                private string m_KeyField = "";
                private string m_DetailField = "";
                private string m_ExtraDetailFields = "";
                private string m_Filter = "";
                private bool m_CanCreate = false;
                private bool m_IgnoreEvents;
                private Type m_ElementoTipo;
                
                private Lbl.Atributos.Nomenclatura AttrNom = null;
                public System.Windows.Forms.Control ControlDestino { get; set; }

                public BusquedaRapida()
                {
                        this.DisplayStyle = Lazaro.Pres.DisplayStyles.Template.Current.White;
                        InitializeComponent();
                }


                protected override void OnLoad(EventArgs e)
                {
                        base.OnLoad(e);
                        if (Lfx.Workspace.Master == null || Lfx.Workspace.Master.SlowLink)
                                TimerRefrescar.Interval = 750;
                        else
                                TimerRefrescar.Interval = 100;
                }


                public bool CanCreate
                {
                        set
                        {
                                BotonNuevo.Visible = value;
                                m_CanCreate = value;
                                if (value)
                                        EntradaBuscar.Width = BotonNuevo.Left - (EntradaBuscar.Left * 2);
                                else
                                        EntradaBuscar.Width = this.ClientSize.Width - (EntradaBuscar.Left * 2);
                        }
                        get
                        {
                                return m_CanCreate;
                        }
                }


                public Type ElementoTipo {
                        get
                        {
                                return m_ElementoTipo;
                        }
                        set
                        {
                                m_ElementoTipo = value;
                                AttrNom = m_ElementoTipo.GetAttribute<Lbl.Atributos.Nomenclatura>();
                                if (AttrNom != null) {
                                        EtiquetaTitulo.Text = AttrNom.NombrePlural;
                                }

                                Lbl.Atributos.Datos AttrDatos = m_ElementoTipo.GetAttribute<Lbl.Atributos.Datos>();
                                if (AttrDatos != null) {
                                        this.Table = AttrDatos.TablaDatos;
                                        this.DetailField = AttrDatos.CampoNombre;
                                        this.KeyField = AttrDatos.CampoId;
                                }
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

                        this.Width = 640 + (120 * CamposExtra);
                        if (Listado.Columns.Count > 0)
                                Listado.Columns[1].Width = Listado.Width - Listado.Columns[0].Width - (120 * CamposExtra) - 20;

                        if (CamposExtra >= 1)
                                extra1.Width = 120;
                        else
                                extra1.Width = 0;

                        if (CamposExtra >= 2)
                                extra1.Width = 120;
                        else
                                extra2.Width = 0;

                        if (CamposExtra >= 3)
                                extra1.Width = 120;
                        else
                                extra3.Width = 0;

                        if (CamposExtra >= 4)
                                extra1.Width = 120;
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
                                return System.Windows.Forms.DialogResult.Cancel;
                }

                internal void Refrescar()
                {
                        Listado.Items.Clear();
                        if (this.Connection != null) {
                                if (m_Table.Length > 0 && m_KeyField.Length > 0 && m_DetailField != null && m_DetailField.Length > 0) {
                                        string TextoSql = null;
                                        string TextoBuscar = EntradaBuscar.Text;

                                        TextoBuscar = this.Connection.EscapeString(TextoBuscar.Replace("  ", " ").Trim());

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
                                                if (TextoBuscar != null && TextoBuscar.Length > 1) {
                                                        TextoSql += " WHERE (" + m_DetailField + " LIKE '%" + TextoBuscar.Replace(" ", "%' AND " + m_DetailField + " LIKE '%") + "%'";
                                                        AgregueWhere = true;
                                                } else if (TextoBuscar != null && TextoBuscar.Length > 0) {
                                                        TextoSql += " WHERE (" + m_DetailField + " LIKE '" + this.Connection.EscapeString(TextoBuscar) + "%'";
                                                        AgregueWhere = true;
                                                }

                                                if (m_ExtraDetailFields != null && m_ExtraDetailFields.Length > 0 && TextoBuscar != null && TextoBuscar.Length > 1) {
                                                        string TempExtraDetailFields = m_ExtraDetailFields;
                                                        string TempWhere = "";
                                                        string ExtraField = Lfx.Types.Strings.GetNextToken(ref TempExtraDetailFields, ",");
                                                        while (ExtraField.Length > 0) {
                                                                if (TempWhere.Length == 0)
                                                                        TempWhere += ExtraField + " LIKE '%" + TextoBuscar + "%'";
                                                                else
                                                                        TempWhere += " OR " + ExtraField + " LIKE '%" + TextoBuscar + "%'";
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
                                        Listado.SuspendLayout();
                                        Listado.BeginUpdate();
                                        foreach (System.Data.DataRow OrgRow in TableRes.Rows) {
                                                Lfx.Data.Row RowRes = (Lfx.Data.Row)OrgRow;
                                                ListViewItem itm = Listado.Items.Add(RowRes.Fields[m_KeyField].ValueInt.ToString("00000"));
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
                                        Listado.EndUpdate();
                                        Listado.ResumeLayout();
                                        if (Listado.Items.Count > 0 && Listado.SelectedItems.Count == 0)
                                                Listado.Items[0].Selected = true;
                                        MostrarEtiquetas();
                                }
                        }
                }


                private void MostrarEtiquetas()
                {
                        if (Listado.Items.Count > 0) {
                                if (EntradaBuscar.Text.Length == 0)
                                        EtiquetaResultados.Text = "Comience a escribir para buscar, o seleccione de la lista:";
                                else
                                        EtiquetaResultados.Text = "Los siguientes elementos coinciden con su búsqueda:";
                                if (Listado.Items.Count < 10 && Listado.SelectedItems.Count == 1) {
                                        EtiquetaSeleccionar.Text = string.Format(EtiquetaSeleccionar.Tag.ToString(), Listado.SelectedItems[0].SubItems[1].Text);
                                        EtiquetaSeleccionar.Visible = true;
                                } else {
                                        EtiquetaSeleccionar.Visible = false;
                                }
                        } else {
                                EtiquetaSeleccionar.Visible = false;
                                if (EntradaBuscar.Text.Length == 0)
                                        EtiquetaResultados.Text = "Aun no hay " + AttrNom.NombrePlural.ToLowerInvariant() + ". Use el botón Crear (F6) para agregar uno/a ahora.";
                                else if (EntradaBuscar.Text.Length == 1)
                                        EtiquetaResultados.Text = "No hay " + AttrNom.NombrePlural.ToLowerInvariant() + " que comiencen con la letra '" + EntradaBuscar.Text.ToUpperInvariant() + "'.";
                                else
                                        EtiquetaResultados.Text = "No hay " + AttrNom.NombrePlural.ToLowerInvariant() +" que coincidan con su búsqueda.";
                        }
                }


                private void EntradaBuscar_TextChanged(object sender, System.EventArgs e)
                {
                        if (m_IgnoreEvents == false && this.Connection != null)
                                TimerRefrescar.Start();

                        MostrarEtiquetas();
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
                        if (Listado.Items.Count > 0) {
                                switch (e.KeyCode) {
                                        case Keys.Up:
                                                if (Listado.SelectedItems.Count == 0)
                                                        Listado.SelectedItems[0].Selected = true;
                                                else if (Listado.SelectedItems[0].Index > 0)
                                                        Listado.Items[Listado.SelectedItems[0].Index - 1].Selected = true;
                                                e.Handled = true;
                                                break;
                                        case Keys.Down:
                                                if (Listado.SelectedItems.Count == 0)
                                                        Listado.SelectedItems[0].Selected = true;
                                                else if (Listado.SelectedItems[0].Index < Listado.Items.Count - 1)
                                                        Listado.Items[Listado.SelectedItems[0].Index + 1].Selected = true;
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


                private void Listado_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
                {
                        switch (e.KeyCode) {
                                case Keys.Left:
                                        if (EntradaBuscar.Focused == false) {
                                                EntradaBuscar.Select();
                                                SendKeys.Send("{left}");
                                                e.Handled = true;
                                        }
                                        break;
                                case Keys.Right:
                                        if (EntradaBuscar.Focused == false) {
                                                EntradaBuscar.Select();
                                                SendKeys.Send("{right}");
                                                e.Handled = true;
                                        }
                                        break;
                                case Keys.Return:
                                        e.Handled = true;
                                        this.DarleEnter();
                                        break;
                                case Keys.Escape:
                                        e.Handled = true;
                                        this.Close();
                                        break;
                                case Keys.Back:
                                        if (EntradaBuscar.Focused == false) {
                                                EntradaBuscar.Select();
                                                SendKeys.Send("{backspace}");
                                                e.Handled = true;
                                        }
                                        break;
                                default:
                                        char KeyChar = (char)(e.KeyCode);
                                        if (char.IsLetterOrDigit(KeyChar)) {
                                                e.Handled = true;
                                                EntradaBuscar.Text += System.Convert.ToString(KeyChar).ToLowerInvariant();
                                        }
                                        break;
                        }
                }


                internal void DarleEnter()
                {
                        if (Listado.SelectedItems.Count > 0) {
                                if (m_Table == "articulos") {
                                        string Codigo = this.Connection.FieldString("SELECT " + Lfx.Workspace.Master.CurrentConfig.Productos.CodigoPredeterminado() + " FROM articulos WHERE id_articulo=" + int.Parse(Listado.SelectedItems[0].Text).ToString());
                                        if (Codigo.Length == 0)
                                                Codigo = int.Parse(Listado.SelectedItems[0].Text).ToString();
                                        ControlDestino.Text = Codigo;
                                        if (ControlDestino is Lui.Forms.IEditableControl)
                                                ((Lui.Forms.IEditableControl)(ControlDestino)).Changed = true;
                                } else {
                                        ControlDestino.Text = int.Parse(Listado.SelectedItems[0].Text).ToString();
                                        if (ControlDestino is Lui.Forms.IEditableControl)
                                                ((Lui.Forms.IEditableControl)(ControlDestino)).Changed = true;
                                }
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
                                this.DialogResult = DialogResult.Cancel;
                                this.Tag = Resultado;
                                this.Close();
                        } else if (Resultado is Form) {
                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                        } else if (Resultado is Lfx.Types.OperationResult) {
                                Lfx.Workspace.Master.RunTime.Toast(((Lfx.Types.OperationResult)(Resultado)).Message, "Mensaje");
                        } else {
                                // Devolvió algo raro.
                        }
                }


                public void VerDetalles()
                {
                        if (Listado.SelectedItems.Count > 0) {
                                int ItemId = int.Parse(Listado.SelectedItems[0].Text);
                                if (ItemId > 0)
                                        Lfx.Workspace.Master.RunTime.Info("ITEMFOCUS", new string[] { "TABLE", this.Table, ItemId.ToString() });
                        }
                }


                private void Listado_SelectedIndexChanged(object sender, System.EventArgs e)
                {
                        if (Listado.SelectedItems.Count > 0) {
                                Listado.Items[Listado.SelectedItems[0].Index].Focused = true;
                                Listado.Items[Listado.SelectedItems[0].Index].EnsureVisible();
                        }
                        VerDetalles();
                        MostrarEtiquetas();
                }


                private void TimerRefrescar_Tick(System.Object sender, System.EventArgs e)
                {
                        TimerRefrescar.Stop();
                        this.Refrescar();
                }

                private void Listado_DoubleClick(object sender, System.EventArgs e)
                {
                        DarleEnter();
                }
        }
}