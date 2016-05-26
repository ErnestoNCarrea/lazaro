using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Lui.Forms
{
        public partial class FormHeader : UserControl, IControl, IDisplayStyleControl
        {
                Lazaro.Pres.DisplayStyles.IDisplayStyle m_DisplayStyle;

                public FormHeader()
                {
                        InitializeComponent();
                        base.TabStop = false;
                        base.BackColor = this.DisplayStyle.LightColor;
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


                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                new public bool TabStop
                {
                        get
                        {
                                return false;
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Always),
                        Browsable(true),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
                public override string Text
                {
                        get
                        {
                                return LabelCaption.Text;
                        }
                        set
                        {
                                LabelCaption.Text = value;
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public virtual Lazaro.Pres.DisplayStyles.IDisplayStyle DisplayStyle
                {
                        get
                        {
                                if(m_DisplayStyle != null)
                                        return m_DisplayStyle;
                                else if (this.Parent is IForm)
                                        return ((IForm)(this.Parent)).DisplayStyle;
                                else if (this.Parent is IDisplayStyleControl)
                                        return ((IDisplayStyleControl)(this.Parent)).DisplayStyle;
                                else
                                        return Lazaro.Pres.DisplayStyles.Template.Current.Default;
                        }
                        set
                        {
                                m_DisplayStyle = value;
                                if (DisplayStyle != null) {
                                        //base.BackColor = m_DisplayStyle.LightColor;
                                        LabelCaption.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                                        LabelColor.BackColor = m_DisplayStyle.LightColor;
                                        LabelColor2.BackColor = m_DisplayStyle.BackgroundColor;
                                        ImageIcon.Image = m_DisplayStyle.Icon;
                                }
                        }
                }
        }
}
