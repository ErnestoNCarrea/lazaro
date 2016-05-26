using System;
using System.Windows.Forms;

namespace Lui.Forms
{
        public partial class YesNo : Lui.Forms.EditableControl
        {
                new public event System.EventHandler TextChanged;

                public YesNo()
                {
                        InitializeComponent();

                        this.BorderStyle = BorderStyles.GenericEditable;
                }

                public bool Value
                {
                        get
                        {
                                return EtiquetaSi.BackColor == System.Drawing.SystemColors.Highlight;
                        }
                        set
                        {
                                this.Changed = false;
                                if (value) {
                                        EtiquetaSi.BackColor = System.Drawing.SystemColors.Highlight;
                                        EtiquetaSi.ForeColor = System.Drawing.SystemColors.HighlightText;
                                        EtiquetaNo.BackColor = this.DisplayStyle.BackgroundColor;
                                        EtiquetaNo.ForeColor = this.DisplayStyle.TextColor;
                                } else {
                                        EtiquetaSi.BackColor = this.DisplayStyle.BackgroundColor;
                                        EtiquetaSi.ForeColor = this.DisplayStyle.TextColor;
                                        EtiquetaNo.BackColor = System.Drawing.SystemColors.Highlight;
                                        EtiquetaNo.ForeColor = System.Drawing.SystemColors.HighlightText;
                                }
                        }
                }


                protected override void OnKeyDown(KeyEventArgs e)
                {
                        if (e.Control == false && e.Alt == false && e.Shift == false) {
                                switch (e.KeyCode) {
                                        case Keys.S:
                                        case Keys.Left:
                                                e.Handled = true;
                                                if (this.ReadOnly || this.TemporaryReadOnly) {
                                                        // Nada
                                                } else if (this.Value == false) {
                                                        this.Value = true;
                                                        this.Changed = true;
                                                }
                                                break;
                                        case Keys.N:
                                        case Keys.Right:
                                                e.Handled = true;
                                                if (this.ReadOnly || this.TemporaryReadOnly) {
                                                        // Nada
                                                } else if (this.Value == true) {
                                                        this.Value = false;
                                                        this.Changed = true;
                                                }
                                                break;
                                        case Keys.Space:
                                                e.Handled = true;
                                                if (this.ReadOnly || this.TemporaryReadOnly) {
                                                        // Nada
                                                } else {
                                                        this.Value = !this.Value;
                                                        this.Changed = true;
                                                }
                                                break;
                                        case Keys.Up:
                                                e.Handled = true;
                                                System.Windows.Forms.SendKeys.Send("+{tab}");
                                                break;
                                        case Keys.Return:
                                        case Keys.Down:
                                                e.Handled = true;
                                                System.Windows.Forms.SendKeys.Send("{tab}");
                                                break;
                                }
                        }

                        base.OnKeyDown(e);
                }


                protected override void OnEnter(EventArgs e)
                {
                        this.Highlighted = true;
                        base.OnEnter(e);
                }


                protected override void OnLeave(EventArgs e)
                {
                        this.Highlighted = false;
                        base.OnLeave(e);
                }

                private void EtiquetaSi_Click(object sender, EventArgs e)
                {
                        this.Select();
                        if (this.ReadOnly || this.TemporaryReadOnly)
                                return;
                        bool Was = this.Value;
                        this.Value = true;
                        if (Was != true) {
                                this.Changed = true;
                                if (this.TextChanged != null)
                                        this.TextChanged(this, e);
                        }
                }

                private void EtiquetaNo_Click(object sender, EventArgs e)
                {
                        this.Select();
                        if (this.ReadOnly || this.TemporaryReadOnly)
                                return;
                        bool Was = this.Value;
                        this.Value = false;
                        if (Was != false) {
                                this.Changed = true;
                                if (this.TextChanged != null)
                                        this.TextChanged(this, e);
                        }
                }
        }
}
