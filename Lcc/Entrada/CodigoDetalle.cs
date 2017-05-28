using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lcc.Entrada
{
        public partial class CodigoDetalle : ControlSeleccionElemento
        {
                private bool m_SelectOnFocus = true;
                private bool m_AutoTab = true;
                private bool m_AutoUpdate = true;
                private bool m_Required = true;
                private string m_FreeTextCode = "";
                private string m_LastText1;
                private string m_TeclaDespuesDeEnter = "{tab}";
                private string m_ExtraDetailFields = "";
                private string m_Filter = "";
                private bool m_CanCreate = true;

                [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
                new public event System.Windows.Forms.KeyEventHandler KeyDown;

                public CodigoDetalle()
                {
                        InitializeComponent();
                        this.BorderStyle = Lui.Forms.Control.BorderStyles.TextBox;
                }


                [DefaultValue(null)]
                public string PlaceholderText { get; set; }


                [EditorBrowsable(EditorBrowsableState.Never), 
                        System.ComponentModel.Browsable(false), 
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public bool AutoUpdate
                {
                        get
                        {
                                return m_AutoUpdate;
                        }
                        set
                        {
                                m_AutoUpdate = value;
                        }
                }

                
                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public string TeclaDespuesDeEnter
                {
                        get
                        {
                                return m_TeclaDespuesDeEnter;
                        }
                        set
                        {
                                m_TeclaDespuesDeEnter = value;
                        }
                }

                public int MaxLength
                {
                        get
                        {
                                return EntradaFreeText.MaxLength;
                        }
                        set
                        {
                                EntradaFreeText.MaxLength = value;
                        }
                }

                [System.ComponentModel.Category("Datos"),
                        DefaultValue("")]
                public string FreeTextCode
                {
                        get
                        {
                                return m_FreeTextCode;
                        }
                        set
                        {
                                m_FreeTextCode = value;
                        }
                }

                [System.ComponentModel.Category("Datos")]
                public bool CanCreate
                {
                        get
                        {
                                return m_CanCreate;
                        }
                        set
                        {
                                m_CanCreate = value;
                        }
                }

                
                /// <summary>
                /// Devuelve True si el control no tiene un valor o tiene sólo espacios.
                /// </summary>
                public override bool IsEmpty
                {
                        get
                        {
                                if (this.Text == this.FreeTextCode)
                                        return string.IsNullOrWhiteSpace(this.EntradaFreeText.Text);
                                else
                                        return string.IsNullOrWhiteSpace(this.Text) || this.Text == "0";
                        }
                }


                /// <summary>
                /// Devuelve True 
                /// </summary>
                public bool IsFreeText
                {
                        get
                        {
                                return string.IsNullOrWhiteSpace(this.FreeTextCode) == false && this.EntradaCodigo.Text == this.FreeTextCode;
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                new public Padding Padding
                {
                        get
                        {
                                return base.Padding;
                        }
                }


                public override bool ReadOnly
                {
                        get
                        {
                                return base.ReadOnly;
                        }
                        set
                        {
                                base.ReadOnly = value;
                                EntradaCodigo.ReadOnly = this.TemporaryReadOnly || this.ReadOnly;
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
                                EntradaCodigo.ReadOnly = this.TemporaryReadOnly || this.ReadOnly;
                                if (Label1.Text == "???")
                                        ProgramarActualizacionDetalle(false);
                        }
                }

                [System.ComponentModel.Category("Datos")]
                override protected string Table
                {
                        get
                        {
                                return base.Table;
                        }
                        set
                        {
                                base.Table = value;
                                if (this.Relation.ReferenceTable == "articulos")
                                        EntradaCodigo.Width = 96;
                                else
                                        EntradaCodigo.Width = 50;
                                ReubicarDetalle();
                                ProgramarActualizacionDetalle(false);
                        }
                }

                [System.ComponentModel.Category("Datos")]
                override protected string DataValueField
                {
                        get
                        {
                                return base.DataValueField;
                        }
                        set
                        {
                                base.DataValueField = value;
                        }
                }

                [System.ComponentModel.Category("Datos")]
                override protected string DataTextField
                {
                        get
                        {
                                return base.DataTextField;
                        }
                        set
                        {
                                base.DataTextField = value;
                                ProgramarActualizacionDetalle(false);
                        }
                }

                [System.ComponentModel.Category("Datos"),
                        DefaultValue("")]
                public string ExtraDetailFields
                {
                        get
                        {
                                return m_ExtraDetailFields;
                        }
                        set
                        {
                                m_ExtraDetailFields = value;
                                ProgramarActualizacionDetalle(false);
                        }
                }

                [System.ComponentModel.Category("Datos"), DefaultValue("")]
                public string Filter
                {
                        get
                        {
                                return m_Filter;
                        }
                        set
                        {
                                m_Filter = value;
                                ProgramarActualizacionDetalle(false);
                        }
                }

                [System.ComponentModel.Category("Comportamiento")]
                public bool AutoTab
                {
                        get
                        {
                                return m_AutoTab;
                        }
                        set
                        {
                                m_AutoTab = value;
                        }
                }

                [System.ComponentModel.Category("Comportamiento")]
                public bool Required
                {
                        get
                        {
                                return m_Required;
                        }
                        set
                        {
                                m_Required = value;
                        }
                }

                [System.ComponentModel.Category("Apariencia")]
                public override System.String Text
                {
                        get
                        {
                               if (string.IsNullOrWhiteSpace(m_FreeTextCode) == false && this.EntradaCodigo.Text == m_FreeTextCode)
                                        return m_FreeTextCode;
                                else if (Label1.Text == "???")
                                        return "";
                                else
                                        return m_ItemId.ToString();
                        }
                        set
                        {
                                if (value == "0") {
                                        m_ItemId = 0;
                                        this.EntradaCodigo.Text = "";
                                } else {
                                        this.EntradaCodigo.Text = value;
                                        m_ItemId = Lfx.Types.Parsing.ParseInt(value);
                                }

                                this.DispararTextChanged = true;
                                this.ActualizarDetalle();

                                this.Changed = false;
                        }
                }

                [System.ComponentModel.Category("Apariencia"),
                        EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public System.String TextDetail
                {
                        get
                        {
                                if (m_FreeTextCode.Length > 0 && this.EntradaCodigo.Text == m_FreeTextCode)
                                        return EntradaFreeText.Text;
                                else if (Label1.Text == "???" || Label1.Text == this.PlaceholderText)
                                        return "";
                                else
                                        return Label1.Text;
                        }
                        set
                        {
                                if (this.IsFreeText)
                                        EntradaFreeText.Text = value;
                                else
                                        Label1.Text = value;
                                this.Changed = false;
                        }
                }

                private void TextBox1_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
                {
                        if (e == null) {
                                // Nada
                        } else if (@"ABCDEFGHIJKLMNOPQRSTUVWXYZ """.IndexOf(char.ToUpper(e.KeyChar)) != -1 && !EntradaCodigo.ReadOnly) {
                                MostrarBuscador(e.KeyChar.ToString());
                                e.Handled = true;
                        } else if (System.Text.Encoding.ASCII.GetBytes(System.Convert.ToString(e.KeyChar))[0] == System.Convert.ToByte(Keys.Return)) {
                                e.Handled = true;
                        } else if (("0123456789-" + m_FreeTextCode + (char)Keys.Back).IndexOf(e.KeyChar) == -1) {
                                e.Handled = true;
                        }
                }


                private void MostrarBuscador(string valorIncial)
                {
                        if (this.ReadOnly || this.TemporaryReadOnly)
                                return;

                        using (Statics.BusquedaRapida = new AuxForms.BusquedaRapida()) {
                                Statics.BusquedaRapida.Owner = this.ParentForm;
                                Statics.BusquedaRapida.ElementoTipo = this.ElementoTipo;
                                Statics.BusquedaRapida.CanCreate = this.CanCreate;
                                //Statics.BusquedaRapida.Table = this.Relation.ReferenceTable;
                                //Statics.BusquedaRapida.DetailField = this.Relation.DetailColumn;
                                //Statics.BusquedaRapida.KeyField = this.Relation.ReferenceColumn;
                                Statics.BusquedaRapida.Filter = m_Filter;
                                Statics.BusquedaRapida.ExtraDetailFields = m_ExtraDetailFields;
                                Statics.BusquedaRapida.ControlDestino = this;
                                Statics.BusquedaRapida.Top = System.Convert.ToInt32((this.DisplayRectangle.Top + this.DisplayRectangle.Height / 2) - (Statics.BusquedaRapida.Height / 2));
                                Statics.BusquedaRapida.Left = System.Convert.ToInt32((this.DisplayRectangle.Left + this.DisplayRectangle.Width / 2) - (Statics.BusquedaRapida.Width / 2));
                                DialogResult Res = Statics.BusquedaRapida.Buscar(valorIncial);
                                if (Res != DialogResult.Cancel) {
                                        if (EntradaCodigo.Text.Length > 0) {
                                                System.Windows.Forms.SendKeys.Send(m_TeclaDespuesDeEnter);
                                        }
                                }
                        }
                }


                private void TextBox1_GotFocus(System.Object sender, System.EventArgs e)
                {
                        if(this.ReadOnly == false && this.TemporaryReadOnly == false)
                                EntradaCodigo.ForeColor = this.DisplayStyle.DataAreaTextColor;

                        if (m_SelectOnFocus)
                                EntradaCodigo.SelectAll();
                }

                private void EntradaFreeText_GotFocus(object sender, System.EventArgs e)
                {
                        EntradaFreeText.SelectionStart = 1024;
                }

                private void TextBox1_LostFocus(System.Object sender, System.EventArgs e)
                {
                        EntradaCodigo.ForeColor = this.DisplayStyle.DataAreaGrayTextColor;
                }

                private void EntradaFreeText_LostFocus(object sender, System.EventArgs e)
                {
                        EntradaFreeText.BackColor = this.DisplayStyle.DataAreaColor;
                }


                private void EntradaCodigo_TextChanged(object sender, System.EventArgs e)
                {
                        if (EntradaCodigo.Text.Length > 13) {
                                if (EntradaCodigo.Font.Size > 7) {
                                        EntradaCodigo.Font = new Font(this.Font.Name, 7);
                                        if (EntradaCodigo.Width < 128)
                                                EntradaCodigo.Width = 128;
                                        ReubicarDetalle();
                                }
                        } else {
                                if (EntradaCodigo.Width > 96) {
                                        EntradaCodigo.Width = 96;
                                        ReubicarDetalle();
                                }

                                if (EntradaCodigo.Text.Length > 11) {
                                        if (EntradaCodigo.Font.Size > 8)
                                                EntradaCodigo.Font = new Font(this.Font.Name, 8);

                                } else {
                                        if (EntradaCodigo.Font.Size < 10)
                                                EntradaCodigo.Font = this.Font;
                                }
                        }

                        ProgramarActualizacionDetalle(true);

                        if (Label1.Text == "???" && EntradaCodigo.Text.Length > 6)
                                MostrarBuscador(EntradaCodigo.Text);

                        this.Changed = true;
                }

                private bool DispararTextChanged = false;
                private void ProgramarActualizacionDetalle(bool textChanged)
                {
                        TimerActualizar.Stop();

                        if (string.IsNullOrEmpty(m_FreeTextCode) == false && this.EntradaCodigo.Text == m_FreeTextCode) {
                                m_ItemId = 0;
                                this.CurrentRow = null;
                                m_LastText1 = "";
                                if (EntradaFreeText.Visible == false) {
                                        EntradaFreeText.Visible = true;
                                        EntradaFreeText.Focus();
                                }

                                if (textChanged) {
                                        //this.DispararTextChanged = true;
                                        //this.TimerActualizar.Start();
                                        this.DispararTextChangedAhora();
                                }
                        } else if (this.Relation.IsEmpty() == false && string.IsNullOrWhiteSpace(EntradaCodigo.Text) == false && EntradaCodigo.Text != "0") {
                                Label1.ForeColor = this.DisplayStyle.TextColor;
                                if (this.AutoUpdate) {
                                        if (Lfx.Workspace.Master == null || Lfx.Workspace.Master.SlowLink)
                                                this.TimerActualizar.Interval = 500;
                                        else
                                                this.TimerActualizar.Interval = 200;

                                        if (textChanged) {
                                                this.DispararTextChanged = true;
                                                this.TimerActualizar.Start();
                                        }
                                } else {
                                        if (textChanged) {
                                                this.DispararTextChangedAhora();
                                        }
                                }
                        } else {
                                m_ItemId = 0;
                                this.CurrentRow = null;
                                m_LastText1 = "";
                                Label1.Text = this.PlaceholderText;
                                Label1.ForeColor = this.DisplayStyle.DataAreaGrayTextColor;

                                if (textChanged) {
                                        this.DispararTextChangedAhora();
                                }
                        }
                }


                private void ActualizarDetalle()
                {
                        if (this.Connection != null && this.ElementoTipo != null) {
                                if (m_FreeTextCode.Length > 0 && EntradaCodigo.Text == m_FreeTextCode) {
                                        // *** Esta escribiendo texto libre
                                        m_ItemId = 0;
                                        this.CurrentRow = null;
                                        m_LastText1 = "";
                                        EntradaFreeText.Visible = true;
                                } else if (this.Relation.IsEmpty() == false && EntradaCodigo.Text.Length > 0 && EntradaCodigo.Text != "0") {
                                        // *** Ingresó un código que parece válido
                                        string KeyFieldAlt = this.Relation.ReferenceColumn; // KeyField Alternativo
                                        if (this.Relation.ReferenceTable == "articulos" && KeyFieldAlt == "id_articulo")
                                                KeyFieldAlt = Lfx.Workspace.Master.CurrentConfig.Productos.CodigoPredeterminado();

                                        if (EntradaCodigo.Text != m_LastText1) {
                                                EntradaFreeText.Visible = false;
                                                string TextoSql = "", Campos = "*";

                                                TextoSql = "SELECT " + Campos + " FROM " + this.Relation.ReferenceTable + " WHERE " + KeyFieldAlt + "='" + this.Connection.EscapeString(EntradaCodigo.Text) + "'";
                                                if (m_Filter != null && m_Filter.Length > 0 && this.TemporaryReadOnly == false)
                                                        TextoSql += " AND (" + m_Filter + ")";

                                                CurrentRow = this.Connection.FirstRowFromSelect(TextoSql);
                                                if (CurrentRow == null && this.Relation.ReferenceColumn != KeyFieldAlt) {
                                                        TextoSql = "SELECT " + Campos + " FROM " + this.Relation.ReferenceTable + " WHERE " + this.Relation.ReferenceColumn + "='" + this.Connection.EscapeString(EntradaCodigo.Text) + "'";
                                                        if (m_Filter != null && m_Filter.Length > 0 && this.TemporaryReadOnly == false)
                                                                TextoSql += " AND (" + m_Filter + ")";
                                                        CurrentRow = this.Connection.FirstRowFromSelect(TextoSql);
                                                }
                                                if (CurrentRow == null) {
                                                        m_ItemId = 0;
                                                        m_LastText1 = "";
                                                        Label1.Text = "???";
                                                        Label1.ForeColor = this.DisplayStyle.DataAreaGrayTextColor;
                                                } else {
                                                        m_ItemId = System.Convert.ToInt32(CurrentRow[this.Relation.ReferenceColumn]);
                                                        m_LastText1 = EntradaCodigo.Text;
                                                        Label1.Text = System.Convert.ToString(CurrentRow[this.Relation.DetailColumn]);
                                                        Label1.ForeColor = this.DisplayStyle.TextColor;
                                                }
                                        }

                                } else {
                                        // El campo está en blanco o con algo que no parece un código válido
                                        m_ItemId = 0;
                                        this.CurrentRow = null;
                                        m_LastText1 = "";
                                        Label1.Text = this.PlaceholderText;
                                        Label1.ForeColor = this.DisplayStyle.DataAreaGrayTextColor;
                                }
                        } else {
                                m_ItemId = 0;
                                this.CurrentRow = null;
                                m_LastText1 = "";
                                Label1.Text = "";
                        }

                        if (this.DispararTextChanged) {
                                this.DispararTextChangedAhora();
                        }

                        if (this.ValueInt > 0 && this.Visible)
                                Lfx.Workspace.Master.RunTime.Info("ITEMFOCUS", new string[] { "TABLE", this.Relation.ReferenceTable, this.Text });
                }


                private void DispararTextChangedAhora()
                {
                        this.DispararTextChanged = false;
                        this.OnTextChanged(EventArgs.Empty);
                }


                private void TextBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
                {
                        switch (e.KeyCode) {
                                case Keys.E:
                                        if (this.ValueInt > 0 && e.Control && e.Alt == false && e.Shift == false) {
                                                e.Handled = true;
                                                this.Edit();
                                        }
                                        break;
                                case Keys.Down:
                                        System.Windows.Forms.SendKeys.Send("{tab}");
                                        e.Handled = true;
                                        break;
                                case Keys.Up:
                                        System.Windows.Forms.SendKeys.Send("+{tab}");
                                        e.Handled = true;
                                        break;
                                case Keys.Right:
                                        if (EntradaFreeText.Visible) {
                                                e.Handled = true;
                                                EntradaFreeText.Focus();
                                                EntradaFreeText.SelectionStart = 0;
                                        } else {
                                                if (null != KeyDown) KeyDown(sender, e);
                                        }
                                        break;
                                case Keys.Return:
                                        if (m_Required && this.ValueInt == 0 && !EntradaCodigo.ReadOnly) {
                                                e.Handled = true;
                                                MostrarBuscador(EntradaCodigo.Text);
                                        } else {
                                                if (m_AutoTab) {
                                                        e.Handled = true;
                                                        System.Windows.Forms.SendKeys.Send(m_TeclaDespuesDeEnter);
                                                } else {
                                                        e.Handled = true;
                                                }
                                        }
                                        break;
                                default:
                                        if (null != KeyDown) KeyDown(sender, e);
                                        break;
                        }

                }


                private void Label1_Click(System.Object sender, System.EventArgs e)
                {
                        EntradaCodigo.Focus();
                }



                protected override void OnEnter(EventArgs e)
                {
                        EntradaCodigo.ScrollToCaret();
                        if (this.ReadOnly == false && this.TemporaryReadOnly == false) {
                                BotonBuscar.Visible = true;
                                switch (new Random().Next(1, 4)) {
                                        case 1:
                                                Lfx.Workspace.Master.RunTime.Hint("Comience a escribir para mostrar una ventana de búsqueda.", "Consejo");
                                                break;
                                        case 2:
                                                Lfx.Workspace.Master.RunTime.Hint("Si recuerda el código, escríbalo. Si no oprima la tecla de espacio (barra espaciadora) para ver una lista.", "Consejo");
                                                break;
                                }
                        }
                        ProgramarActualizacionDetalle(false);
                        this.Refresh();
                        base.OnEnter(e);
                }


                protected override void OnLeave(EventArgs e)
                {
                        BotonBuscar.Visible = false;
                        base.OnLeave(e);
                }


                private void EntradaFreeText_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
                {
                        switch (e.KeyCode) {
                                case Keys.Left:
                                        if (EntradaFreeText.SelectionStart == 0) {
                                                e.Handled = true;
                                                EntradaCodigo.Focus();
                                        }
                                        break;
                                case Keys.Right:
                                        if (EntradaFreeText.SelectionStart >= EntradaFreeText.Text.Length) {
                                                e.Handled = true;
                                                if (null != KeyDown)
                                                        KeyDown(sender, e);
                                        }
                                        break;
                                case Keys.Down:
                                        System.Windows.Forms.SendKeys.Send("{tab}");
                                        e.Handled = true;
                                        break;
                                case Keys.Up:
                                        System.Windows.Forms.SendKeys.Send("+{tab}");
                                        e.Handled = true;
                                        break;
                                case Keys.Return:
                                        if (EntradaFreeText.Text.Length > 0 || m_Required == false) {
                                                e.Handled = true;
                                                if (null != KeyDown) 
                                                        KeyDown(sender, e);
                                        } else {
                                                if (null != KeyDown) 
                                                        KeyDown(sender, e);
                                        }
                                        break;
                                case Keys.Back:
                                        if (EntradaFreeText.Text.Length == 0) {
                                                e.Handled = true;
                                                EntradaCodigo.Focus();
                                        }
                                        break;
                                default:
                                        if (null != KeyDown) KeyDown(sender, e);
                                        break;
                        }

                }


                private void DetailBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
                {
                        if (@"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ* """.IndexOf(char.ToUpper(e.KeyChar)) != -1 && !EntradaCodigo.ReadOnly) {
                                MostrarBuscador(e.KeyChar.ToString());
                                e.Handled = true;
                        }
                }


                private void ReubicarDetalle()
                {
                        // Reubico los campos EntradaFreeText y Label1
                        // Llamar a esta función después de haber cambiado el Width de TextBox1
                        this.SuspendLayout();
                        EntradaFreeText.Left = EntradaCodigo.Width + 4;
                        EntradaFreeText.Width = this.Width - EntradaFreeText.Left - 4;
                        Label1.Location = EntradaFreeText.Location;
                        Label1.Size = EntradaFreeText.Size;
                        this.ResumeLayout();
                }


                public object Edit()
                {
                        if (this.ValueInt > 0)
                                return Lfx.Workspace.Master.RunTime.Execute("EDIT", new string[] { this.Relation.ReferenceTable, this.ValueInt.ToString() });
                        else
                                return null;
                }


                private void MenuItemCopiarCodigo_Click(object sender, System.EventArgs e)
                {
                        try {
                                Clipboard.SetDataObject(this.Text, true);
                        } catch {
                                // Error de portapapeles
                        }
                }


                private void MenuItemCopiarNombre_Click(object sender, System.EventArgs e)
                {
                        try {
                                Clipboard.SetDataObject(this.TextDetail, true);
                        } catch {
                                // Error de portapapeles
                        }
                }


                private void MenuItemPegar_Click(object sender, System.EventArgs e)
                {
                        try {
                                string DatosPortapapeles = System.Convert.ToString(Clipboard.GetDataObject().GetData(DataFormats.Text, true));
                                if (DatosPortapapeles != null)
                                        this.Text = DatosPortapapeles;
                        } catch {
                                // Error de portapapeles
                        }
                }


                private void MenuItemEditar_Click(object sender, System.EventArgs e)
                {
                        this.Edit();
                }


                private void ContextMenu_Popup(System.Object sender, System.EventArgs e)
                {
                        this.Focus();
                        MenuItemEditar.Enabled = (EntradaCodigo.ReadOnly == false && m_CanCreate && this.ValueInt > 0);
                        if (MenuItemEditar.Enabled)
                                MenuItemEditar.Text = @"Editar """ + this.TextDetail + @"""";
                        else
                                MenuItemEditar.Text = "Editar";

                        MenuItemCopiarCodigo.Enabled = this.Text.Length > 0;
                        MenuItemCopiarNombre.Enabled = this.TextDetail.Length > 0;
                        string DatosPortapapeles = System.Convert.ToString(Clipboard.GetDataObject().GetData(DataFormats.Text, true));
                        if (DatosPortapapeles == null || EntradaCodigo.ReadOnly == true) {
                                MenuItemPegar.Enabled = false;
                        } else {
                                MenuItemPegar.Enabled = true;
                                if (DatosPortapapeles.Length > 32)
                                        DatosPortapapeles = DatosPortapapeles.Substring(0, 32) + "...";
                                MenuItemPegar.Text = @"Pegar """ + DatosPortapapeles + @"""";
                        }
                        MenuItemBuscadorRapido.Enabled = (EntradaCodigo.ReadOnly == false);
                }


                private void MenuItemBuscadorRapido_Click(System.Object sender, System.EventArgs e)
                {
                        if (EntradaCodigo.ReadOnly == false)
                                MostrarBuscador("");
                }


                private void Label1_DoubleClick(object sender, System.EventArgs e)
                {
                        if (EntradaCodigo.ReadOnly == false)
                                this.MostrarBuscador("");
                }


                private void TextBox1_DoubleClick(object sender, System.EventArgs e)
                {
                        if (EntradaCodigo.ReadOnly == false)
                                this.MostrarBuscador("");
                }


                private void TimerActualizar_Tick(object sender, EventArgs e)
                {
                        TimerActualizar.Stop();
                        ActualizarDetalle();
                }

                new public Color ForeColor
                {
                        get
                        {
                                return EntradaCodigo.ForeColor;
                        }
                        set
                        {
                                Label1.ForeColor = this.ForeColor;
                                EntradaFreeText.ForeColor = this.ForeColor;
                        }
                }

                [EditorBrowsable(EditorBrowsableState.Never), System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                new public Font Font
                {
                        get
                        {
                                return base.Font;
                        }
                }

                private void EntradaFreeText_TextChanged(object sender, EventArgs e)
                {
                        if (EntradaFreeText.Text.Length == 1 || EntradaFreeText.Text.Length == 0)
                                this.OnTextChanged(EventArgs.Empty);
                }


                public override void ApplyStyle()
                {
                        base.ApplyStyle();
                        Label1.BackColor = this.DisplayStyle.DataAreaColor;
                        Label1.ForeColor = this.DisplayStyle.DataAreaTextColor;
                        EntradaCodigo.BackColor = Label1.BackColor;
                        EntradaCodigo.ForeColor = this.DisplayStyle.DataAreaGrayTextColor;
                        EntradaFreeText.BackColor = Label1.BackColor;
                        EntradaFreeText.ForeColor = Label1.ForeColor;
                }

                private void BotonBuscar_Click(object sender, EventArgs e)
                {
                        MostrarBuscador("");
                }

                private void EntradaCodigo_SizeChanged(object sender, EventArgs e)
                {
                        this.Height = EntradaCodigo.Height + (EntradaCodigo.Top * 2);
                }
        }
}
