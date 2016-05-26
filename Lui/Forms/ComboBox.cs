using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lui.Forms
{
        [System.ComponentModel.DefaultEvent("TextChanged")]
        public partial class ComboBox : TextBoxBase
        {
                private string[] m_SetData = new string[] { "" };
                private string[] m_SetDataText = { "" };
                private string[] m_SetDataKey = { "" };
                private int m_SetIndex; private string m_TextKey;
                private bool m_AlwaysExpanded = false;

                public ComboBox()
                {
                        InitializeComponent();

                        this.BorderStyle = BorderStyles.TextBox;
                        this.TextBox1.DoubleClick += new System.EventHandler(this.TextBox1_DoubleClick);
                        this.TextBox1.LostFocus += new System.EventHandler(this.TextBox1_LostFocus);
                        this.TextBox1.GotFocus += new System.EventHandler(this.TextBox1_GotFocus);
                        TextBox1.Multiline = false;
                }


                [System.ComponentModel.Category("Comportamiento")]
                public string[] SetData
                {
                        get
                        {
                                return m_SetData;
                        }
                        set
                        {
                                string OldTextKey = this.TextKey;
                                m_SetData = value;

                                if (m_SetData == null) {
                                        m_SetIndex = -1;
                                } else {
                                        int TamanoSet = m_SetData.Length;
                                        m_SetDataText = new string[TamanoSet];
                                        m_SetDataKey = new string[TamanoSet];

                                        for (int i = 0; i < TamanoSet; i++) {
                                                string Item = m_SetData[i];
                                                m_SetDataText[i] = Lfx.Types.Strings.GetNextToken(ref Item, "|");
                                                m_SetDataKey[i] = Item;
                                        }

                                        if (this.TextRaw.Length == 0 && m_SetData.Length >= 1)
                                                this.TextRaw = m_SetData[0];

                                        ItemList.Items.Clear();

                                        if (string.IsNullOrEmpty(OldTextKey) == false)
                                                this.TextKey = OldTextKey;
                                }
                        }
                }


                public void FromDictionary(IDictionary<int, string> dict)
                {
                        string[] Sd = new string[dict.Count];
                        int i = 0;
                        foreach (KeyValuePair<int, string> Val in dict) {
                                Sd[i++] = Val.Value + "|" + Val.Key.ToString();
                        }

                        this.SetData = Sd;
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
                                TextBox1.ReadOnly = true;
                                ItemList.Enabled = !(value || this.ReadOnly);
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
                                TextBox1.ReadOnly = true;
                                ItemList.Enabled = !(value || this.TemporaryReadOnly);
                        }
                }

                public bool AlwaysExpanded
                {
                        get
                        {
                                return m_AlwaysExpanded;
                        }
                        set
                        {
                                m_AlwaysExpanded = value;
                                this.AutoSizeAlwaysExpandedChanged();
                        }
                }

                new public bool AutoSize
                {
                        get
                        {
                                return base.AutoSize;
                        }
                        set
                        {
                                base.AutoSize = value;
                                this.AutoSizeAlwaysExpandedChanged();
                        }
                }


                private void AutoSizeAlwaysExpandedChanged()
                {
                        if (m_AlwaysExpanded)
                                this.ItemList.Visible = true;
                        else if (this.ContainsFocus == false)
                                this.ItemList.Visible = false;
                }

                
                [System.ComponentModel.Category("Apariencia"),
                        RefreshProperties(RefreshProperties.Repaint)]
                public string TextKey
                {
                        get
                        {
                                if (m_SetIndex >= 0 && m_SetDataKey.Length >= (m_SetIndex + 1))
                                        return m_SetDataKey[m_SetIndex];
                                else
                                        return "";
                        }
                        set
                        {
                                bool EraIgual = m_TextKey == value;

                                if (m_SetData != null && m_SetDataKey.GetLength(0) > 0) {
                                        for (int i = 0; i <= m_SetDataKey.GetUpperBound(0); i++) {
                                                if (m_SetDataKey[i] == value) {
                                                        m_TextKey = value;
                                                        m_SetIndex = i;
                                                        IgnoreChanges++;
                                                        this.TextRaw = m_SetDataText[m_SetIndex];
                                                        if (ItemList.Items.Count >= (i + 1))
                                                                ItemList.SelectedIndex = i;
                                                        IgnoreChanges--;
                                                        break;
                                                }
                                        }
                                }

                                this.Changed = false;
                                
                                if (EraIgual == false)
                                        this.OnTextChanged(EventArgs.Empty);
                        }
                }

                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public int ValueInt
                {
                        get
                        {
                                return Lfx.Types.Parsing.ParseInt(this.TextKey);
                        }
                        set
                        {
                                this.TextKey = value.ToString();
                        }
                }


                private void DetectarTextKey()
                {
                        string Buscar = ItemList.SelectedItem.ToString();
                        for (int i = 0; i < m_SetDataText.Length; i++) {
                                if (m_SetDataText[i] == Buscar) {
                                        m_TextKey = m_SetDataKey[i];
                                        m_SetIndex = i;
                                }
                        }
                }


                private void ImagenSiguiente_Click(object sender, System.EventArgs e)
                {
                        if (this.TemporaryReadOnly == false && this.ReadOnly == false)
                                SetNextValueInSet();
                }


                private void ImagenSiguiente_DoubleClick(object sender, System.EventArgs e)
                {
                        if (this.TemporaryReadOnly == false && this.ReadOnly == false)
                                SetNextValueInSet();
                }

                public void SetNextValueInSet()
                {
                        if (m_SetData != null && m_SetData.Length > 0) {
                                if (m_SetIndex == -1)
                                        m_SetIndex = 0;

                                this.TextRaw = NextValueInSet();
                                this.TextKey = m_SetDataKey[m_SetIndex];

                                this.Changed = true;

                                if (ItemList.Visible)
                                        ItemList.SelectedItem = this.TextRaw;

                                if (this.Focused && PopUps.FormDataSetHelp != null && PopUps.FormDataSetHelp.Visible) {
                                        if (this.TextKey.Length == 0)
                                                PopUps.FormDataSetHelp.TextKey = this.Text;
                                        else
                                                PopUps.FormDataSetHelp.TextKey = this.TextKey;
                                }
                        }
                }

                private string NextValueInSet()
                {
                        string nextValueInSetReturn = null;
                        if (m_SetIndex >= m_SetData.Length - 1)
                                m_SetIndex = 0;
                        else
                                m_SetIndex++;
                        nextValueInSetReturn = m_SetDataText[m_SetIndex];
                        return nextValueInSetReturn;
                }


                public void SetPrevValueInSet()
                {
                        if (m_SetData != null && m_SetData.Length > 0) {
                                if (m_SetIndex == -1)
                                        m_SetIndex = m_SetDataKey.GetUpperBound(0);

                                this.TextRaw = PrevValueInSet();
                                this.TextKey = m_SetDataKey[m_SetIndex];

                                this.Changed = true;

                                if (ItemList.Visible)
                                        ItemList.SelectedItem = this.TextRaw;

                                if (PopUps.FormDataSetHelp != null && PopUps.FormDataSetHelp.Visible) {
                                        if (this.TextKey.Length == 0)
                                                PopUps.FormDataSetHelp.TextKey = this.Text;
                                        else
                                                PopUps.FormDataSetHelp.TextKey = this.TextKey;
                                }
                        }
                }

                private string PrevValueInSet()
                {
                        string prevValueInSetReturn = null;
                        if (m_SetIndex <= 0)
                                m_SetIndex = m_SetData.Length - 1;
                        else
                                m_SetIndex--;
                        prevValueInSetReturn = m_SetDataText[m_SetIndex];
                        return prevValueInSetReturn;
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public override System.String Text
                {
                        get
                        {
                                return base.Text;
                        }
                        set
                        {
                                base.Text = value;
                                this.TextBox1.Select(0, 0);
                                for (int i = 0; i <= m_SetDataText.GetUpperBound(0); i++) {
                                        if (this.TextRaw == m_SetDataText[i]) {
                                                if (this.TextKey != m_SetDataKey[i])
                                                        this.TextKey = m_SetDataKey[i];
                                                break;
                                        }
                                }
                        }
                }

                private void TextBox1_DoubleClick(object sender, System.EventArgs e)
                {
                        if (this.TemporaryReadOnly == false && this.ReadOnly == false)
                                SetNextValueInSet();
                }

                private void TextBox1_LostFocus(object sender, System.EventArgs e)
                {
                        if (IgnoreEvents == 0) {
                                if (PopUps.FormDataSetHelp != null && PopUps.FormDataSetHelp.Visible) {
                                        TimerOcultarPopup.Start();
                                }
                        }
                }

                private void MostrarPopup()
                {
                        TimerOcultarPopup.Stop();
                        if (this.AutoSize == false && this.AlwaysExpanded == false) {
                                if (PopUps.FormDataSetHelp == null && Lfx.Environment.SystemInformation.RunTime == Lfx.Environment.SystemInformation.RunTimes.DotNet)
                                        PopUps.FormDataSetHelp = new DataSetHelp();
                                if (PopUps.FormDataSetHelp != null && this.TemporaryReadOnly == false && this.ReadOnly == false) {
                                        string[] TempSet = new string[this.SetData.Length];
                                        this.SetData.CopyTo(TempSet, 0);
                                        PopUps.FormDataSetHelp.SetData = TempSet;
                                        PopUps.FormDataSetHelp.TextKey = this.TextKey;
                                        PopUps.FormDataSetHelp.Mostrar(this);
                                        this.TextBox1.Focus();
                                }
                        }
                }


                private void ComboBox_Enter(object sender, EventArgs e)
                {
                        if (this.AutoSize || this.AlwaysExpanded)
                                ItemList.Visible = true;

                        if (ItemList.Visible && this.ActiveControl != ItemList) {
                                ItemList.Select();
                        } else if (TextBox1.Visible && this.ActiveControl != TextBox1) {
                                TextBox1.Select();
                        }
                }

                private void ComboBox_Leave(object sender, EventArgs e)
                {
                        if (ItemList.Visible && m_AlwaysExpanded == false && this.AutoSize == true)
                                ItemList.Visible = false;
                }

                private void ComboBox_SizeChanged(object sender, EventArgs e)
                {
                        TextBox1.Location = new System.Drawing.Point(4, 4);
                        TextBox1.Width = this.Width - TextBox1.Left * 2 - ImagenSiguiente.Width;
                        TextBox1.Height = this.Height - TextBox1.Top * 2;
                        ImagenSiguiente.Height = TextBox1.Height;
                        ItemList.Width = this.Width - ItemList.Left * 2;
                }

                private void ItemList_VisibleChanged(object sender, EventArgs e)
                {
                        TextBox1.Visible = !ItemList.Visible;
                        ImagenSiguiente.Visible = TextBox1.Visible;
                        if (ItemList.Visible) {
                                if (m_SetDataText != null && ItemList.Items.Count != m_SetDataText.Length) {
                                        IgnoreChanges++;
                                        ItemList.Items.Clear();
                                        for (int i = m_SetDataText.GetLowerBound(0); i <= m_SetDataText.GetUpperBound(0); i++) {
                                                if (m_SetDataText[i] != null)
                                                        ItemList.Items.Add(m_SetDataText[i]);
                                                if (m_SetDataText[i] == this.Text)
                                                        ItemList.SelectedIndex = ItemList.Items.Count - 1;
                                        }
                                        IgnoreChanges--;
                                }

                                ItemList.Location = new System.Drawing.Point(3, 3);
                                if (this.AutoSize) {
                                        // Manejo el tamaño del control de acuerdo a la lista
                                        if (m_SetDataText.Length > 5)
                                                ItemList.Height = ItemList.ItemHeight * 5;
                                        else
                                                ItemList.Height = ItemList.ItemHeight * m_SetDataText.Length;
                                        this.Height = ItemList.Top + ItemList.Height + ItemList.Margin.Top + ItemList.Margin.Bottom + 1;
                                } else {
                                        // Manejo el tamaño de la lista de acuerdo al control
                                        ItemList.Height = this.ClientRectangle.Height - ItemList.Top - ItemList.Margin.Top + ItemList.Margin.Bottom;
                                }

                                if (ItemList.SelectedIndex < ItemList.TopIndex)
                                        ItemList.TopIndex = ItemList.SelectedIndex;
                                else if (ItemList.SelectedIndex >= ItemList.TopIndex + (ItemList.Height / ItemList.ItemHeight))
                                        ItemList.TopIndex = ItemList.SelectedIndex;
                        } else {
                                if (this.AutoSize)
                                        this.Height = TextBox1.Top + TextBox1.Height + TextBox1.Margin.Top + TextBox1.Margin.Bottom;
                        }
                }

                protected override void OnSizeChanged(EventArgs e)
                {
                        if (ItemList != null && this.AutoSize == false) {
                                ItemList.Height = this.ClientRectangle.Height - ItemList.Top - ItemList.Margin.Top + ItemList.Margin.Bottom;
                        }
                        base.OnSizeChanged(e);
                }


                protected override void OnEnter(EventArgs e)
                {
                        Lfx.Workspace.Master.RunTime.Hint("Utilice las teclas de más y menos (+ y -) o la barra espaciadora para cambiar la selección.", "Consejo");
                        base.OnEnter(e);
                }


                protected override void OnKeyDown(KeyEventArgs e)
                {
                        switch (e.KeyCode) {
                                case Keys.Up:
                                        if (e.Shift == false && e.Alt == false && e.Control == false) {
                                                e.Handled = true;
                                                System.Windows.Forms.SendKeys.Send("+{tab}");
                                        }
                                        break;
                                case Keys.Return:
                                case Keys.Down:
                                        if (e.Shift == false && e.Alt == false && e.Control == false) {
                                                e.Handled = true;
                                                System.Windows.Forms.SendKeys.Send("{tab}");
                                        }
                                        break;
                        }

                        base.OnKeyDown(e);
                }


                private void ItemList_KeyDown(object sender, KeyEventArgs e)
                {
                        switch (e.KeyCode) {
                                case Keys.Subtract:
                                case Keys.OemMinus:
                                        e.Handled = true;
                                        if (this.TemporaryReadOnly == false && this.ReadOnly == false) {
                                                this.SetPrevValueInSet();
                                        }
                                        break;
                                case Keys.Add:
                                case Keys.Oemplus:
                                case Keys.Space:
                                        e.Handled = true;
                                        if (this.TemporaryReadOnly == false && this.ReadOnly == false) {
                                                this.SetNextValueInSet();
                                        }
                                        break;
                                case Keys.Return:
                                        e.Handled = true;
                                        if (m_AutoNav & ItemList.Visible && e.Shift == false && e.Alt == false && e.Control == false) {
                                                System.Windows.Forms.SendKeys.Send("{tab}");
                                        }
                                        break;
                                default:
                                        if (sender == ItemList)
                                                base.TextBox1_KeyDown(sender, e);
                                        break;
                        }
                }

                private void ItemList_SelectedValueChanged(object sender, EventArgs e)
                {
                        if (ItemList.SelectedItem != null) {
                                string ValorAnterior = m_TextKey;

                                if (IgnoreChanges == 0)
                                        this.Changed = true;

                                this.DetectarTextKey();

                                if (ItemList.SelectedIndex < ItemList.TopIndex)
                                        ItemList.TopIndex = ItemList.SelectedIndex;
                                else if (ItemList.SelectedIndex >= ItemList.TopIndex + (ItemList.Height / ItemList.ItemHeight))
                                        ItemList.TopIndex = ItemList.SelectedIndex;

                                if (this.TextKey != ValorAnterior) {
                                        if (ItemList.SelectedItem != null)
                                                this.Text = ItemList.SelectedItem.ToString();
                                        this.OnTextChanged(EventArgs.Empty);
                                }
                        }
                }

                private void TimerOcultarPopup_Tick(object sender, EventArgs e)
                {
                        TimerOcultarPopup.Stop();
                        if (PopUps.FormDataSetHelp != null && PopUps.FormDataSetHelp.Visible)
                                PopUps.FormDataSetHelp.Ocultar();
                }

                private void TextBox1_GotFocus(object sender, System.EventArgs e)
                {
                        if (IgnoreEvents == 0 && this.TemporaryReadOnly == false && this.ReadOnly == false) {
                                IgnoreEvents++;
                                this.TextBox1.Select(0, 0);
                                this.MostrarPopup();
                                IgnoreEvents--;
                        }
                }

                private void TextBox1_Click(object sender, EventArgs e)
                {
                        if (IgnoreEvents == 0 && this.TemporaryReadOnly == false && this.ReadOnly == false) {
                                IgnoreEvents++;
                                this.TextBox1.Select(0, 0);
                                this.MostrarPopup();
                                IgnoreEvents--;
                        }
                }


                public override void ApplyStyle()
                {
                        base.ApplyStyle();
                        this.TextBox1.BackColor = this.BackColor;
                        this.TextBox1.ForeColor = this.ForeColor;
                        this.ItemList.BackColor = this.BackColor;
                        this.ItemList.ForeColor = this.ForeColor;
                }
        }
}
