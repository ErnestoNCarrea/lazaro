using System;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lui.Forms
{
        public class ButtonPanel : System.Windows.Forms.FlowLayoutPanel, IControl, IDisplayStyleControl
        {
                public ButtonPanel()
                {
                        this.AdoctrinarHijos();
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public virtual Lazaro.Pres.DisplayStyles.IDisplayStyle DisplayStyle
                {
                        get
                        {
                                if (this.Parent is IForm)
                                        return ((IForm)(this.Parent)).DisplayStyle;
                                else if (this.Parent is IDisplayStyleControl)
                                        return ((IDisplayStyleControl)(this.Parent)).DisplayStyle;
                                else
                                        return Lazaro.Pres.DisplayStyles.Template.Current.Default;
                        }
                }


                protected override void OnControlAdded(ControlEventArgs e)
                {
                        base.OnControlAdded(e);
                        this.AdoctrinarControl(e.Control);
                }


                private void AdoctrinarHijos()
                {
                        if (this.Created == false)
                                return;

                        foreach (Control Ctl in this.Controls) {
                                AdoctrinarControl(Ctl);
                        }
                }


                private void AdoctrinarControl(System.Windows.Forms.Control control)
                {
                        if (control.Created == false)
                                return;

                        control.MaximumSize = new System.Drawing.Size(108, 40);
                        control.MinimumSize = new Size(96, 32);

                        switch (this.FlowDirection) {
                                case System.Windows.Forms.FlowDirection.BottomUp:
                                        control.Margin = new Padding(0, this.Padding.Bottom / 2, 0, 0);
                                        break;
                                case System.Windows.Forms.FlowDirection.LeftToRight:
                                        control.Margin = new Padding(0, 0, this.Padding.Left / 2, 0);
                                        break;
                                case System.Windows.Forms.FlowDirection.RightToLeft:
                                        control.Margin = new Padding(this.Padding.Right / 2, 0, 0, 0);
                                        break;
                                case System.Windows.Forms.FlowDirection.TopDown:
                                        control.Margin = new Padding(0, 0, 0, this.Padding.Top / 2);
                                        break;
                        }

                        switch (this.FlowDirection) {
                                case System.Windows.Forms.FlowDirection.LeftToRight:
                                case System.Windows.Forms.FlowDirection.RightToLeft:
                                        control.Height = this.ClientRectangle.Height - this.Padding.Vertical;
                                        break;
                                case System.Windows.Forms.FlowDirection.BottomUp:
                                case System.Windows.Forms.FlowDirection.TopDown:
                                        control.Width = this.ClientRectangle.Width - this.Padding.Horizontal;
                                        break;
                        }
                }


                protected override void OnPaddingChanged(EventArgs e)
                {
                        base.OnPaddingChanged(e);
                        AdoctrinarHijos();
                }

                protected override void OnSizeChanged(EventArgs e)
                {
                        base.OnSizeChanged(e);
                        AdoctrinarHijos();
                }


                protected override void OnLayout(LayoutEventArgs levent)
                {
                        base.OnLayout(levent);
                        this.AdoctrinarHijos();
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                new public Color BackColor
                {
                        get
                        {
                                return this.DisplayStyle.BackgroundColor;
                        }
                }


                protected override void OnParentChanged(EventArgs e)
                {
                        base.OnParentChanged(e);
                        this.ApplyStyle();
                }


                protected override void OnParentBackColorChanged(EventArgs e)
                {
                        base.OnParentBackColorChanged(e);
                        this.ApplyStyle();
                }


                private void ApplyStyle()
                {
                        base.BackColor = this.DisplayStyle.DarkColor;
                }
        }
}
