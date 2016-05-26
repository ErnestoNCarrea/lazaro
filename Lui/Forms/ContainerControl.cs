using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lui.Forms
{
        [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
        public partial class ContainerControl : System.Windows.Forms.Panel, IControl, IDisplayStyleControl
        {
                public ContainerControl()
                {
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                new public Color BackColor
                {
                        get
                        {
                                return base.BackColor;
                        }
                }


                protected override void OnParentChanged(System.EventArgs e)
                {
                        base.OnParentChanged(e);
                        this.ApplyStyle();
                }


                protected override void OnParentBackColorChanged(System.EventArgs e)
                {
                        base.OnParentBackColorChanged(e);
                        this.ApplyStyle();
                }


                public virtual void ApplyStyle()
                {
                        base.BackColor = this.DisplayStyle.BackgroundColor;
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
        }
}
