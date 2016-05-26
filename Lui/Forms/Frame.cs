using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lui.Forms
{
        [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner))]

        public partial class Frame : ContainerControl
        {
                public Frame()
                {
                        InitializeComponent();
                }


                /* protected override void OnEnter(EventArgs e)
                {
                        base.OnEnter(e);
                        this.Highlighted = true;
                }


                protected override void OnLeave(EventArgs e)
                {
                        base.OnLeave(e);
                        this.Highlighted = false;
                } */

                /* [Category("Appearance")]
                [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
                public Panel ContainerPanel
                {
                        get
                        {
                                return PanelContenedor;
                        }
                } */

                protected override void OnPaint(PaintEventArgs e)
                {
                        base.OnPaint(e);

                        int y = 0;
                        if (EtiquetaTitulo.Visible)
                                y += EtiquetaTitulo.Top + EtiquetaTitulo.Height;
                        e.Graphics.DrawLine(new System.Drawing.Pen(this.DisplayStyle.DarkColor), 0, y, this.Width - 1, y);
                }

                public override void ApplyStyle()
                {
                        this.EtiquetaTitulo.ApplyStyle();
                }


                [EditorBrowsable(EditorBrowsableState.Always),
                        Browsable(true),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
                public override string Text
                {
                        get
                        {
                                return base.Text;
                        }
                        set
                        {
                                base.Text = value;
                                EtiquetaTitulo.Text = value;
                                EtiquetaTitulo.Visible = (value.Length > 0);
                                this.Refresh();
                        }
                }
        }


        /* public class FrameDesigner : System.Windows.Forms.Design.ParentControlDesigner
        {
                public override void Initialize(System.ComponentModel.IComponent component)
                {
                        base.Initialize(component);

                        if (this.Control is Lui.Forms.Frame) {
                                this.EnableDesignMode(((Lui.Forms.Frame)this.Control).ContainerPanel, "ContainerPanel");
                        }
                }
        } */
}