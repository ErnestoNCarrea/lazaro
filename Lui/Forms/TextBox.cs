using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lui.Forms
{
	[System.ComponentModel.DefaultEvent("TextChanged")]
        public partial class TextBox : TextBoxBase
	{
                protected Lazaro.Pres.DisplayStyles.TextStyles m_LabelStyle = Lazaro.Pres.DisplayStyles.TextStyles.DataEntry;
                
                protected internal TextCasing m_ForceCase = TextCasing.None;
		protected internal char m_PasswordChar = '\0';
		protected internal DataTypes m_DataType = DataTypes.FreeText;
                protected internal int m_DecimalPlaces = -1;
                protected string m_PlaceholderText = null;                

		private System.Windows.Forms.MenuItem MenuItemPegadoRapido;
		private System.Windows.Forms.MenuItem MenuItemPegadoRapidoAgregar;

                public TextBox()
                {
                        InitializeComponent();

                        this.BorderStyle = BorderStyles.TextBox;
                        //this.BackColor = TextBox1.BackColor;
                        TextBox1.BackColor = this.DisplayStyle.DataAreaColor;
                        TextBox1.ForeColor = this.DisplayStyle.TextColor;

                        EtiquetaPrefijo.Font = Lazaro.Pres.DisplayStyles.Template.Current.SmallerFont;
                        EtiquetaSufijo.Font = EtiquetaPrefijo.Font;
                        EtiquetaPrefijo.ForeColor = this.DisplayStyle.TextColor;
                        EtiquetaPrefijo.BackColor = this.DisplayStyle.DataAreaColor;
                        EtiquetaSufijo.ForeColor = this.DisplayStyle.TextColor;
                        EtiquetaSufijo.BackColor = this.DisplayStyle.DataAreaColor;
                        
                        this.TextBox1.ContextMenu = this.MiContextMenu;
                        this.TextBox1.DoubleClick += new System.EventHandler(this.TextBox1_DoubleClick);
                        this.TextBox1.LostFocus += new System.EventHandler(this.TextBox1_LostFocus);
                        this.TextBox1.GotFocus += new System.EventHandler(this.TextBox1_GotFocus);

                        this.ReubicarControles();
                }


                [Category("Comportamiento")]
                [DefaultValue(TextCasing.None)]
                public TextCasing ForceCase
                {
                        get
                        {
                                return m_ForceCase;
                        }
                        set
                        {
                                m_ForceCase = value;
                                this.TextRaw = FormatearDatos(this.TextRaw);
                        }
                }


                [DefaultValue("")]
		public virtual string Prefijo
		{
			get
			{
				return EtiquetaPrefijo.Text;
			}
			set
			{
                                string Pref = value;
                                if (Pref == "$" || this.DataType == DataTypes.Currency)
                                        Pref = Lbl.Sys.Config.Moneda.Simbolo;
				EtiquetaPrefijo.Text = Pref;
                                EtiquetaPrefijo.Visible = Pref != null && Pref.Length > 0;
                                this.ReubicarControles();
			}
		}


                [DefaultValue("")]
		public string Sufijo
		{
			get
			{
				return EtiquetaSufijo.Text;
			}
			set
			{
				EtiquetaSufijo.Text = value;
				EtiquetaSufijo.Visible = EtiquetaSufijo.Text.Length > 0;
                                this.ReubicarControles();
			}
		}


                [DefaultValue(32767)]
                public int MaxLength
                {
                        get
                        {
                                return TextBox1.MaxLength;
                        }
                        set
                        {
                                TextBox1.MaxLength = value;
                        }
                }


                [DefaultValue(-1)]
		public int DecimalPlaces
		{
			get
			{
				return m_DecimalPlaces;
			}
			set
			{
				m_DecimalPlaces = value;
				IgnoreChanges++;
                                this.TextRaw = FormatearDatos(this.TextRaw);
				IgnoreChanges--;
			}
		}


                [DefaultValue(null)]
                public string PlaceholderText
                {
                        get
                        {
                                return m_PlaceholderText;
                        }
                        set
                        {
                                if (TextBox1.Text == m_PlaceholderText && this.Grayed) {
                                        IgnoreEvents++;
                                        TextBox1.Text = value;
                                        IgnoreEvents--;
                                }

                                m_PlaceholderText = value;
                                this.SetTipIfBlank();
                        }
                }


                private void SetTipIfBlank()
                {
                        if (ActiveControl != TextBox1 && TextBox1.Text == "" && this.PlaceholderText != null && this.PlaceholderText.Length > 0) {
                                this.Grayed = true;
                                this.ApplyStyle();
                                IgnoreChanges++;
                                TextBox1.Text = this.PlaceholderText;
                                IgnoreChanges--;
                                TextBox1.SelectionStart = 0;
                                TextBox1.SelectionLength = 0;
                        } else {
                                this.Grayed = false;
                                this.ApplyStyle();
                        }
                }


                protected override void OnEnter(EventArgs e)
                {
                        if (this.Grayed && this.TextBox1.Text == m_PlaceholderText) {
                                IgnoreEvents++;
                                IgnoreChanges++;
                                this.TextBox1.Text = "";
                                this.Grayed = false;
                                this.ApplyStyle();
                                IgnoreEvents--;
                                IgnoreChanges--;
                        }
                        base.OnEnter(e);
                }

                protected override void OnLeave(EventArgs e)
                {
                        this.SetTipIfBlank();
                        base.OnLeave(e);
                }


		[EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int SelectionStart
		{
			get
			{
				return TextBox1.SelectionStart;
			}
			set
			{
				TextBox1.SelectionStart = value;
			}
		}


		[EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int SelectionLength
		{
			get
			{
				return TextBox1.SelectionLength;
			}
			set
			{
				TextBox1.SelectionLength = value;
			}
		}


		[Category("Comportamiento")]
                [DefaultValue('\0')]
		public char PasswordChar
		{
			get
			{
				return m_PasswordChar;
			}
			set
			{
				m_PasswordChar = value;
				TextBox1.PasswordChar = m_PasswordChar;
                                if (m_PasswordChar != '\0')
                                        this.MultiLine = false;
			}
		}


		[System.ComponentModel.Category("Comportamiento")]
                [DefaultValue(false)]
		public bool MultiLine
		{
			get
			{
                                return TextBox1.Multiline;
			}
			set
			{
                                TextBox1.Multiline = value;
                                this.ReubicarControles();
			}
		}


		[System.ComponentModel.Category("Comportamiento")]
                [DefaultValue(DataTypes.FreeText)]
		public virtual DataTypes DataType
		{
			get
			{
				return m_DataType;
			}
			set
			{
				m_DataType = value;
				switch (m_DataType)
				{
					case DataTypes.Float:
					case DataTypes.Integer:
					case DataTypes.Currency:
                                        case DataTypes.Stock:
						TextBox1.TextAlign = HorizontalAlignment.Right;
						break;
					default:
						TextBox1.TextAlign = HorizontalAlignment.Left;
						break;
				}
                                this.TextRaw = FormatearDatos(this.TextRaw);
			}
		}

                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
                        DefaultValue(false)]
                public override bool TemporaryReadOnly
                {
                        get
                        {
                                return base.TemporaryReadOnly;
                        }
                        set
                        {
                                base.TemporaryReadOnly = value;
                                TextBox1.ReadOnly = m_ReadOnly || m_TemporaryReadOnly;
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
                                TextBox1.ReadOnly = m_ReadOnly || m_TemporaryReadOnly;
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public decimal ValueDecimal
                {
                        get
                        {
                                return this.Text.ParseDecimal();
                        }
                        set
                        {
                                this.TextRaw = FormatearDatos(value);
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public int ValueInt
                {
                        get
                        {
                                return Lfx.Types.Parsing.ParseInt(this.Text);
                        }
                        set
                        {
                                this.TextRaw = FormatearDatos(value);
                        }
                }


                private void MenuItemCopiar_Click(System.Object sender, System.EventArgs e)
		{
                        try {
                                if (TextBox1.SelectionLength > 0)
                                        Clipboard.SetDataObject(TextBox1.SelectedText);
                                else
                                        Clipboard.SetDataObject(this.Text);
                        } catch {
                                // Error de portapapeles
                        }
		}


                private void MenuItemPegar_Click(System.Object sender, System.EventArgs e)
                {
                        try {
                                string DatosPortapapeles = System.Convert.ToString(Clipboard.GetDataObject().GetData(DataFormats.Text, true));
                                this.Text = FormatearDatos(DatosPortapapeles);
                        } catch {
                                // Nada
                        }
                }


		private void MenuItemCalculadora_Click(System.Object sender, System.EventArgs e)
		{
                        Lfx.Workspace.Master.RunTime.Execute("CALC", null);
		}


		private void MenuItemEditor_Click(System.Object sender, System.EventArgs e)
		{
			Lui.Forms.AuxForms.TextEdit OFormEditorExtendido = new Lui.Forms.AuxForms.TextEdit();
			OFormEditorExtendido.Text = "Números de serie";
			OFormEditorExtendido.EditText = this.Text;
			if (OFormEditorExtendido.ShowDialog() == DialogResult.OK)
				this.Text = OFormEditorExtendido.EditText;
		}


		private void MiContextMenu_Popup(object sender, System.EventArgs e)
		{
			string DatosPortapapeles = System.Convert.ToString(Clipboard.GetDataObject().GetData(DataFormats.Text, true));
			MenuItemCalendario.Visible = (this.TemporaryReadOnly == false && this.ReadOnly == false && (m_DataType == DataTypes.Date || m_DataType == DataTypes.DateTime));
			MenuItemHoy.Visible = MenuItemCalendario.Visible;
			MenuItemAyer.Visible = MenuItemCalendario.Visible;
			MenuItemCalculadora.Visible = (m_DataType == DataTypes.Float || m_DataType == DataTypes.Currency  || m_DataType == DataTypes.Stock || m_DataType == DataTypes.Integer);
			MenuItemCalculadora.Enabled = !(this.TemporaryReadOnly || this.ReadOnly);
                        MenuItemEditor.Enabled = (this.TemporaryReadOnly == false && this.ReadOnly == false && m_DataType == DataTypes.FreeText && m_PasswordChar == '\0');
                        MenuItemCopiar.Enabled = m_PasswordChar == '\0' && this.Text.Length > 0;
                        if (m_PasswordChar == '\0')
			{
				if (DatosPortapapeles == null || DatosPortapapeles.Length == 0)
				{
					MenuItemPegar.Enabled = false;
				}
				else
				{
					if (DatosPortapapeles.Length > 32)
						DatosPortapapeles = DatosPortapapeles.Substring(0, 32) + "...";

					MenuItemPegar.Text = @"Pegar """ + DatosPortapapeles + @"""";
					if (m_DataType == DataTypes.Date)
						MenuItemPegar.Enabled = this.TemporaryReadOnly == false && this.ReadOnly == false && System.Text.RegularExpressions.Regex.IsMatch(DatosPortapapeles, @"^[0-3]\d(-|/)[0-1]\d(-|/)(\d{2}|\d{4})$");
					else
						MenuItemPegar.Enabled = this.TemporaryReadOnly == false && this.ReadOnly == false;
				}
				MenuItemPegadoRapido.Enabled = this.MultiLine;
			}
			else
			{
				MenuItemPegar.Enabled = false;
				MenuItemPegadoRapido.Enabled = false;
			}
		}

		private void MenuItemHoy_Click(object sender, System.EventArgs e)
		{
			this.Text = FormatearDatos(System.DateTime.Now);
		}


		private void MenuItemAyer_Click(System.Object sender, System.EventArgs e)
		{
			this.Text = FormatearDatos(System.DateTime.Now.AddDays(-1));
		}

		private void MostrarCalendario()
		{
			CalendarPopUp Calendario = new CalendarPopUp();
			if (this.Text.IsDate())
				Calendario.CurrentDate = Lfx.Types.Parsing.ParseDate(this.Text).Value;
			if (Calendario.ShowDialog() == DialogResult.OK)
				this.Text = FormatearDatos(Calendario.CurrentDate);
			Calendario.Close();
			Calendario = null;
		}



		private void MenuItemPegadoRapido_Popup(object sender, System.EventArgs e)
		{
			if (this.Text.Length == 0)
			{
				MenuItemPegadoRapidoAgregar.Text = "Agregar al menú";
				MenuItemPegadoRapidoAgregar.Enabled = false;
			}
			else
			{
				string MuestraTexto;
				if (this.TextBox1.SelectionLength > 0)
					MuestraTexto = this.TextBox1.SelectedText;
				else
					MuestraTexto = this.Text.Replace(System.Environment.NewLine, "");

				if (MuestraTexto.Length > 30)
					MuestraTexto = MuestraTexto.Substring(0, 30) + "...";
				MenuItemPegadoRapidoAgregar.Text = "Agregar \"" + MuestraTexto + "\" a este menú";
				MenuItemPegadoRapidoAgregar.Enabled = true;
			}

			for (int i = MenuItemPegadoRapido.MenuItems.Count - 1; i > 0; i--)
			{
				MenuItemPegadoRapido.MenuItems.RemoveAt(i);
			}
                        if (Lfx.Workspace.Master.MasterConnection != null) {
                                System.Data.DataTable QuickPastes = Lfx.Workspace.Master.MasterConnection.Select("SELECT texto FROM sys_quickpaste ORDER BY fecha DESC LIMIT 12");
                                foreach (System.Data.DataRow QuickPaste in QuickPastes.Rows) {
                                        System.Windows.Forms.MenuItem NuevoItem = new System.Windows.Forms.MenuItem();
                                        NuevoItem.Text = QuickPaste["texto"].ToString();
                                        NuevoItem.Click += new System.EventHandler(this.MenuItemPegadoRapidoTexto_Click);
                                        MenuItemPegadoRapido.MenuItems.Add(NuevoItem);
                                }
                        }
		}

		private void MenuItemPegadoRapidoAgregar_Click(object sender, System.EventArgs e)
		{
                        // FIXME: almacenar esto en otro lado, no en la BD
                        /* qGen.Insert Comando = new qGen.Insert("sys_quickpaste");
			Comando.Fields.AddWithValue("texto", this.Text);
			Comando.Fields.AddWithValue("estacion", Lfx.Environment.SystemInformation.MachineName);
			Comando.Fields.AddWithValue("usuario", Lbl.Sys.Config.Actual.UsuarioConectado.Id);
			Comando.Fields.AddWithValue("fecha", qGen.SqlFunctions.Now);
                        Lfx.Workspace.Master.MasterConnection.Execute(Comando); */
		}


		private void MenuItemPegadoRapidoTexto_Click(object sender, System.EventArgs e)
		{
			this.Text = FormatearDatos(((System.Windows.Forms.MenuItem)sender).Text);
		}


                public override System.String Text
                {
                        get
                        {
                                if (this.Grayed && TextBox1.Text == m_PlaceholderText)
                                        return "";
                                else
                                        return FormatearDatos(base.Text);
                        }
                        set
                        {
                                if (value == null)
                                        base.Text = FormatearDatos("");
                                else
                                        base.Text = FormatearDatos(value);

                                TextBox1.Select(TextBox1.Text.Length, 0);
                                this.SetTipIfBlank();
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public AutoCompleteStringCollection AutoCompleteStringCollection
                {
                        get
                        {
                                return TextBox1.AutoCompleteCustomSource;
                        }
                        set
                        {
                                if (value == null) {
                                        TextBox1.AutoCompleteMode = AutoCompleteMode.None;
                                } else {
                                        TextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                                }
                                TextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                                TextBox1.AutoCompleteCustomSource = value;
                        }
                }


                private string FormatearDatos(object datos)
                {
                        string Res = null;
                        switch (m_DataType) {
                                case DataTypes.Integer:
                                        long DatoInt;
                                        if (datos is Int16 || datos is Int32 || datos is Int64) {
                                                DatoInt = System.Convert.ToInt64(datos);
                                        } else {
                                                try {
                                                        DatoInt = System.Convert.ToInt64(Lfx.Types.Evaluator.EvaluateDecimal(datos.ToString()));
                                                } catch {
                                                        // Nada... supongo que un desbordamiento
                                                        DatoInt = 0;
                                                }
                                        }

                                        if (DatoInt > int.MaxValue || DatoInt < int.MinValue)
                                                Res = "0";
                                        else
                                                Res = System.Convert.ToInt32(DatoInt).ToString();
                                        break;

                                case DataTypes.Float:
                                        decimal DatoDouble;
                                        if (datos is decimal || datos is double || datos is Single || datos is float)
                                                DatoDouble = System.Convert.ToDecimal(datos);
                                        else
                                                DatoDouble = Lfx.Types.Evaluator.EvaluateDecimal(datos.ToString());

                                        if (m_DecimalPlaces == -1)
                                                Res = Lfx.Types.Formatting.FormatNumber(DatoDouble, 4);
                                        else
                                                Res = Lfx.Types.Formatting.FormatNumber(DatoDouble, m_DecimalPlaces);
                                        break;

                                case DataTypes.Currency:
                                        decimal DatoDinero;
                                        if(datos is decimal || datos is double)
                                                DatoDinero = System.Convert.ToDecimal(datos);
                                        else
                                                DatoDinero =Lfx.Types.Evaluator.EvaluateDecimal(datos.ToString());

                                        if (m_DecimalPlaces == -1)
                                                Res = Lfx.Types.Formatting.FormatCurrency(DatoDinero, Lbl.Sys.Config.Moneda.Decimales);
                                        else
                                                Res = Lfx.Types.Formatting.FormatCurrency(DatoDinero, m_DecimalPlaces);
                                        break;

                                case DataTypes.Stock:
                                        decimal DatoStock;
                                        if(datos is decimal || datos is double)
                                                DatoStock = System.Convert.ToDecimal(datos);
                                        else
                                                DatoStock =Lfx.Types.Evaluator.EvaluateDecimal(datos.ToString());

                                        if (m_DecimalPlaces == -1)
                                                Res = Lfx.Types.Formatting.FormatCurrency(DatoStock, Lbl.Sys.Config.Articulos.Decimales);
                                        else
                                                Res = Lfx.Types.Formatting.FormatCurrency(DatoStock, m_DecimalPlaces);
                                        break;

                                case DataTypes.Date:
                                        if (datos is DateTime) {
                                                Res = Lfx.Types.Formatting.FormatDate(System.Convert.ToDateTime(datos));
                                        } else {
                                                if (datos == null)
                                                        Res = "";
                                                else if (datos.ToString().IsDate())
                                                        // Reformateo la fecha
                                                        Res = Lfx.Types.Formatting.FormatDate(Lfx.Types.Parsing.ParseDate(datos.ToString()));
                                                else
                                                        Res = "";
                                        }
                                        break;

                                case DataTypes.DateTime:
                                        if (datos is DateTime) {
                                                Res = Lfx.Types.Formatting.FormatDateAndTime(System.Convert.ToDateTime(datos));
                                        } else {
                                                if (datos == null)
                                                        Res = "";
                                                else if (datos.ToString().IsDate())
                                                        // Reformateo la fecha
                                                        Res = Lfx.Types.Formatting.FormatDateAndTime(Lfx.Types.Parsing.ParseDate(datos.ToString()));
                                                else
                                                        Res = "";
                                        }
                                        break;

                                default:
                                        Res = datos.ToString().UnixToWindows();
                                        break;
                        }

                        switch (m_ForceCase) {
                                case TextCasing.LowerCase:
                                        Res = Res.ToLower();
                                        break;
                                case TextCasing.UpperCase:
                                        Res = Res.ToUpper();
                                        break;
                                case TextCasing.Caption:
                                        Res = Res.ToTitleCase();
                                        break;
                                case TextCasing.Automatic:
                                        if (Res == Res.ToLower() || Res == Res.ToUpper())
                                                Res = Res.ToTitleCase();
                                        break;
                        }

                        return Res;
                }


                private void TextBox1_DoubleClick(object sender, System.EventArgs e)
                {
                        if (this.TemporaryReadOnly == false && this.ReadOnly == false) {
                                if (m_DataType == DataTypes.Date) {
                                        MostrarCalendario();
                                }
                        }
                }


                private void TextBox1_LostFocus(object sender, System.EventArgs e)
                {
                        if (IgnoreEvents == 0) {
                                string Res = FormatearDatos(this.TextRaw);
                                if (this.TextRaw != Res)
                                        this.TextRaw = Res;
                        }
                }


                private void TextBox1_GotFocus(object sender, System.EventArgs e)
                {
                        if (IgnoreEvents == 0 && this.TemporaryReadOnly == false && this.ReadOnly == false) {
                                if (m_TemporaryReadOnly == false && this.ReadOnly == false) {
                                        if (m_TemporaryReadOnly == false && this.ReadOnly == false) {
                                                switch (this.DataType) {
                                                        case DataTypes.Currency:
                                                        case DataTypes.Date:
                                                        case DataTypes.Float:
                                                        case DataTypes.Integer:
                                                        case DataTypes.Stock:
                                                                TextBox1.SelectAll();
                                                                break;
                                                        default:
                                                                TextBox1.Select(TextBox1.Text.Length, 0);
                                                                break;
                                                }

                                        } else {
                                                TextBox1.Select(TextBox1.Text.Length, 0);
                                        }
                                } else {
                                        TextBox1.Select(TextBox1.Text.Length, 0);
                                }
                        }
                }


                protected override void OnFontChanged(EventArgs e)
                {
                        base.OnFontChanged(e);
                        this.ReubicarControles();
                }


                protected override void OnSizeChanged(EventArgs e)
                {
                        base.OnSizeChanged(e);
                        this.ReubicarControles();
                }


                protected override void OnCreateControl()
                {
                        base.OnCreateControl();
                        this.ReubicarControles();
                }


                private void ReubicarControles()
                {
                        if (this.Created == false)
                                return;

                        this.SuspendLayout();

                        if (EtiquetaPrefijo.Visible) {
                                EtiquetaPrefijo.MinimumSize = new Size(0, this.ClientRectangle.Height - 4);
                                EtiquetaPrefijo.Location = new Point(3, 2);
                                TextBox1.Left = EtiquetaPrefijo.Left + EtiquetaPrefijo.Width + 2;
                        } else {
                                TextBox1.Left = 3;
                        }

                        int SufijoWidth;
                        if (EtiquetaSufijo.Visible) {
                                EtiquetaSufijo.MinimumSize = new Size(0, this.ClientRectangle.Height - 4);
                                EtiquetaSufijo.Location = new Point(this.ClientRectangle.Width - EtiquetaSufijo.Width - 3, 2);
                                SufijoWidth = EtiquetaSufijo.Width + 3;
                        } else {
                                SufijoWidth = 3;
                        }

                        TextBox1.Top = 3;
                        TextBox1.Width = this.ClientRectangle.Width - TextBox1.Left - SufijoWidth;
                        TextBox1.Height = this.ClientRectangle.Height - (TextBox1.Top * 2);

                        this.ResumeLayout(false);
                }


                private void TextBox1_FontChanged(object sender, System.EventArgs e)
                {
                        EtiquetaPrefijo.Font = new Font(this.Font.Name, this.Font.Size * 0.8f);
                        EtiquetaSufijo.Font = EtiquetaPrefijo.Font;
                }


                [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                new public Font Font
                {
                        get
                        {
                                return TextBox1.Font;
                        }
                }


                [DefaultValue(Lazaro.Pres.DisplayStyles.TextStyles.DataEntry)]
                public Lazaro.Pres.DisplayStyles.TextStyles TextStyle
                {
                        get
                        {
                                return m_LabelStyle;
                        }
                        set
                        {
                                m_LabelStyle = value;
                                switch(m_LabelStyle) {
                                        case Lazaro.Pres.DisplayStyles.TextStyles.DataEntry:
                                                TextBox1.Font = Lazaro.Pres.DisplayStyles.Template.Current.DataEntryFont;
                                                break;
                                        case Lazaro.Pres.DisplayStyles.TextStyles.Big:
                                                TextBox1.Font = Lazaro.Pres.DisplayStyles.Template.Current.BigFont;
                                                break;
                                        case Lazaro.Pres.DisplayStyles.TextStyles.Bigger:
                                                TextBox1.Font = Lazaro.Pres.DisplayStyles.Template.Current.BiggerFont;
                                                break;
                                        case Lazaro.Pres.DisplayStyles.TextStyles.Small:
                                                TextBox1.Font = Lazaro.Pres.DisplayStyles.Template.Current.SmallFont;
                                                break;
                                        default:
                                                TextBox1.Font = Lazaro.Pres.DisplayStyles.Template.Current.DefaultFont;
                                                break;
                                }
                        }
                }

                private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
                {
                        if (this.TemporaryReadOnly == false && this.ReadOnly == false) {
                                if (m_DataType == DataTypes.Date) {
                                        if (e.KeyChar == ' ') {
                                                e.Handled = true;
                                                MostrarCalendario();
                                        } else if (char.IsControl(e.KeyChar)) {
                                                // Nada... son caracteres de control
                                        } else if ("0123456789-/".IndexOf(e.KeyChar) < 0) {
                                                e.Handled = true;
                                        }
                                }
                        }
                }
	}
}
