using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lui.Forms
{
        /// <summary>
        /// Control botón estándar.
        /// </summary>
        public partial class Button : Control, IControl, IDisplayStyleControl, IButtonControl
        {
                private SubLabelPositions m_SubLabelPos = SubLabelPositions.None;
                private ImagePositions m_ImagePos = ImagePositions.Top;
                private System.Windows.Forms.DialogResult m_DialogResult = DialogResult.None;

                public Button()
                {
                        InitializeComponent();
                        this.BorderStyle = BorderStyles.Button;
                        this.ReubicarTodo();
                }


                [EditorBrowsable(EditorBrowsableState.Always), System.ComponentModel.Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
                public override string Text
                {
                        get
                        {
                                return MainText.Text;
                        }
                        set
                        {
                                MainText.Text = value;
                                base.Text = "";
                        }
                }


                public System.Drawing.Image Image
                {
                        get
                        {
                                return IconPicture.Image;
                        }
                        set
                        {
                                IconPicture.Image = value;
                                IconPicture.Visible = (value != null);
                                this.Invalidate();
                        }
                }


                public ImagePositions ImagePos
                {
                        get
                        {
                                return m_ImagePos;
                        }
                        set
                        {
                                m_ImagePos = value;
                                this.Invalidate();
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                new public Font Font
                {
                        get
                        {
                                return base.Font;
                        }
                }


                public SubLabelPositions SubLabelPos
                {
                        get
                        {
                                return m_SubLabelPos;
                        }
                        set
                        {
                                m_SubLabelPos = value;
                                this.Invalidate();
                        }
                }


                private void ReubicarTodo()
                {
                        const int SmallSubTextHeight = 12;
                        const int SmallSubTextWidth = 10;
                        int HorizontalMargin = 4;
                        int VerticalMargin = 4;

                        if (m_SubLabelPos == SubLabelPositions.LongBottom) {
                                HorizontalMargin = 6;
                                VerticalMargin = 6;
                        }

                        this.SuspendLayout();
                        if (this.IconPicture.Visible) {
                                //Si hay imagen, el texto principal a la derecha de la imagen
                                IconPicture.Left = HorizontalMargin;
                                if (m_ImagePos == ImagePositions.Middle)
                                        IconPicture.Top = (this.Height - IconPicture.Height) / 2;
                                else
                                        IconPicture.Top = VerticalMargin;
                                MainText.Left = IconPicture.Width + IconPicture.Left + HorizontalMargin;
                        } else {
                                //Si no hay imagen, el texto principal contra el margen derecho
                                MainText.Left = HorizontalMargin;
                        }

                        switch (m_SubLabelPos) {
                                case SubLabelPositions.None:
                                        //No hay subtexto, el texto ocupa todo
                                        MainText.Width = this.Width - MainText.Left - HorizontalMargin;
                                        MainText.Height = this.Height - (VerticalMargin * 2);
                                        MainText.Font = Lazaro.Pres.DisplayStyles.Template.Current.DefaultFont;

                                        SubText.Visible = false;
                                        break;
                                case SubLabelPositions.Bottom:
                                        //Subtexto pequeño abajo, texto ocupando el resto
                                        MainText.Width = this.Width - MainText.Left - HorizontalMargin;
                                        MainText.Height = this.Height - SmallSubTextHeight - (VerticalMargin * 2);
                                        MainText.TextAlign = ContentAlignment.MiddleCenter;
                                        MainText.Font = Lazaro.Pres.DisplayStyles.Template.Current.DefaultFont;

                                        SubText.Left = MainText.Left;
                                        SubText.Width = MainText.Width;
                                        SubText.Height = SmallSubTextHeight;
                                        SubText.Top = MainText.Top + MainText.Height;
                                        SubText.TextAlign = ContentAlignment.MiddleCenter;
                                        SubText.Font = Lazaro.Pres.DisplayStyles.Template.Current.SmallerFont;
                                        SubText.Visible = true;
                                        break;
                                case SubLabelPositions.Right:
                                        //Subtexto pequeño a la derecha, texto ocupando el resto
                                        MainText.Width = this.Width - MainText.Left - HorizontalMargin - SmallSubTextWidth;
                                        MainText.Height = this.Height - VerticalMargin * 2;
                                        MainText.TextAlign = ContentAlignment.MiddleCenter;
                                        MainText.Font = Lazaro.Pres.DisplayStyles.Template.Current.DefaultFont;

                                        SubText.Size = new Size(SmallSubTextWidth, this.Height - VerticalMargin * 2);
                                        SubText.Location = new Point(this.Width - SubText.Width - HorizontalMargin, MainText.Top);
                                        SubText.TextAlign = ContentAlignment.MiddleCenter;
                                        SubText.Font = Lazaro.Pres.DisplayStyles.Template.Current.SmallerFont;
                                        SubText.Visible = true;
                                        break;
                                case SubLabelPositions.LongBottom:
                                        //Subtexto pequeño abajo, texto ocupando el resto
                                        MainText.Width = this.Width - MainText.Left - HorizontalMargin;
                                        if (IconPicture.Visible && m_ImagePos == ImagePositions.Top)
                                                MainText.Height = IconPicture.Height + (VerticalMargin * 2);
                                        else
                                                MainText.Height = 22;
                                        MainText.TextAlign = ContentAlignment.MiddleLeft;
                                        MainText.Font = Lazaro.Pres.DisplayStyles.Template.Current.GroupHeaderFont;

                                        SubText.Left = MainText.Left;
                                        SubText.Width = MainText.Width;
                                        SubText.Top = MainText.Top + MainText.Height;
                                        SubText.Height = this.Height - SubText.Top - VerticalMargin;
                                        SubText.TextAlign = ContentAlignment.TopLeft;
                                        SubText.Font = Lazaro.Pres.DisplayStyles.Template.Current.SmallFont;
                                        SubText.Visible = true;
                                        break;
                        }
                        this.ApplyStyles();
                        this.ResumeLayout();
                }

                public string Subtext
                {
                        get
                        {
                                return SubText.Text;
                        }
                        set
                        {
                                SubText.Text = value;
                        }
                }

                protected override void OnEnter(EventArgs e)
                {
                        m_Highlighted = true;
                        this.ApplyStyles();
                        this.Invalidate();
                        base.OnEnter(e);
                }


                protected override void OnCreateControl()
                {
                        this.ApplyStyles();
                        this.Invalidate();
                        base.OnCreateControl();
                }

                protected override void OnLeave(EventArgs e)
                {
                        m_Highlighted = false;
                        this.ApplyStyles();
                        this.Invalidate();
                        base.OnLeave(e);
                }


                private void MainText_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
                {
                        this.Select();
                }


                private void MainText_Click(System.Object sender, System.EventArgs e)
                {
                        this.Select();
                        this.RaiseClick(e);
                }


                private void MainText_DoubleClick(object sender, System.EventArgs e)
                {
                        this.Select();
                        this.RaiseClick(e);
                }


                private void SubText_Click(System.Object sender, System.EventArgs e)
                {
                        this.Select();
                        this.RaiseClick(e);
                }


                private void SubText_DoubleClick(object sender, System.EventArgs e)
                {
                        this.Select();
                        this.RaiseClick(e);
                }


                protected override void OnClick(EventArgs e)
                {
                        base.OnClick(e);
                        this.Select();
                        this.RaiseClick(e);
                }


                protected override void OnDoubleClick(EventArgs e)
                {
                        base.OnDoubleClick(e);
                        this.Select();
                        this.RaiseClick(e);
                }


                protected override void OnKeyDown(KeyEventArgs e)
                {
                        if (e.KeyCode == Keys.Down) {
                                e.Handled = true;
                                System.Windows.Forms.SendKeys.Send("{tab}");
                        } else if (e.KeyCode == Keys.Up) {
                                e.Handled = true;
                                System.Windows.Forms.SendKeys.Send("+{tab}");
                        } else if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Space) {
                                e.Handled = true;
                                this.PerformClick();
                        } else {
                                this.RaiseKeyDown(e);
                        }

                        base.OnKeyDown(e);
                }


                //IButtonControl
                public void NotifyDefault(bool value)
                {
                        //TODO: implementar
                        return;
                }

                public void PerformClick()
                {
                        if (this.Enabled && this.Visible)
                                this.OnClick(EventArgs.Empty);
                }

                public System.Windows.Forms.DialogResult DialogResult
                {
                        get
                        {
                                return this.m_DialogResult;
                        }

                        set
                        {
                                if (Enum.IsDefined(typeof(System.Windows.Forms.DialogResult), value)) {
                                        this.m_DialogResult = value;
                                }
                        }
                }


                [System.Security.Permissions.UIPermission(System.Security.Permissions.SecurityAction.LinkDemand,
                        Window = System.Security.Permissions.UIPermissionWindow.AllWindows)]
                protected override bool ProcessMnemonic(char charCode)
                {
                        if (this.Enabled && this.Visible && IsMnemonic(charCode, this.Text)) {
                                this.Select();
                                this.PerformClick();
                                return true;
                        } else {
                                return base.ProcessMnemonic(charCode);
                        }
                }


                public void ApplyStyles()
                {
                        this.ForeColor = this.DisplayStyle.TextColor;
                        if (this.Highlighted) {
                                ((System.Windows.Forms.Control)(this)).BackColor = this.DisplayStyle.LightColor;
                        } else {
                                ((System.Windows.Forms.Control)(this)).BackColor = this.DisplayStyle.BackgroundColor;
                        }
                        MainText.BackColor = this.BackColor;
                        MainText.ForeColor = this.ForeColor;
                        SubText.BackColor = MainText.BackColor;
                        SubText.ForeColor = MainText.ForeColor;
                }

                private void Button_SizeChanged(object sender, EventArgs e)
                {
                        this.ReubicarTodo();
                }

                public override string ToString()
                {
                        return this.Text;
                }

                private void Button_Layout(object sender, LayoutEventArgs e)
                {
                        this.ReubicarTodo();
                }
        }
}