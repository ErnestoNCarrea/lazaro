using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lui.Forms
{
        public class Label : System.Windows.Forms.Label, IControl, IDisplayStyleControl
        {
                protected Lazaro.Pres.DisplayStyles.TextStyles m_LabelStyle = Lazaro.Pres.DisplayStyles.TextStyles.Default;

                public Label()
                {
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
                new public Color ForeColor
                {
                        get
                        {
                                return base.ForeColor;
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


                [DefaultValue(Lazaro.Pres.DisplayStyles.TextStyles.Default), Browsable(true)]
                public Lazaro.Pres.DisplayStyles.TextStyles TextStyle
                {
                        get
                        {
                                return m_LabelStyle;
                        }
                        set
                        {
                                m_LabelStyle = value;
                                this.ApplyStyle();
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


                public void ApplyStyle()
                {
                        switch (m_LabelStyle) {
                                case Lazaro.Pres.DisplayStyles.TextStyles.MainHeader:
                                        base.Font = Lazaro.Pres.DisplayStyles.Template.Current.MainHeaderFont;
                                        base.Padding = new Padding(0);
                                        if (this.Parent != null)
                                                base.BackColor = this.Parent.BackColor;
                                        base.ForeColor = Color.MidnightBlue;
                                        break;
                                case Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader:
                                        base.Font = Lazaro.Pres.DisplayStyles.Template.Current.GroupHeaderFont;
                                        base.Padding = new Padding(0, 2, 0, 2);
                                        if (this.Parent != null)
                                                base.BackColor = this.Parent.BackColor;
                                        base.ForeColor = Color.MidnightBlue;
                                        break;
                                case Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader2:
                                        base.Font = Lazaro.Pres.DisplayStyles.Template.Current.GroupHeader2Font;
                                        base.Padding = new Padding(0, 2, 0, 2);
                                        if (this.Parent != null)
                                                base.BackColor = this.Parent.BackColor;
                                        base.ForeColor = Color.MidnightBlue;
                                        break;
                                case Lazaro.Pres.DisplayStyles.TextStyles.Small:
                                        base.Font = Lazaro.Pres.DisplayStyles.Template.Current.SmallFont;
                                        base.Padding = new Padding(0, 0, 0, 0);
                                        if (this.Parent != null)
                                                base.BackColor = this.Parent.BackColor;
                                        base.ForeColor = this.DisplayStyle.TextColor;
                                        break;
                                case Lazaro.Pres.DisplayStyles.TextStyles.Default:
                                        base.Font = Lazaro.Pres.DisplayStyles.Template.Current.DefaultFont;
                                        base.Padding = new Padding(0, 3, 0, 0);
                                        if (this.Parent != null)
                                                base.BackColor = this.Parent.BackColor;
                                        base.ForeColor = this.DisplayStyle.TextColor;
                                        break;
                                case Lazaro.Pres.DisplayStyles.TextStyles.Big:
                                        base.Font = Lazaro.Pres.DisplayStyles.Template.Current.BigFont;
                                        base.Padding = new Padding(3);
                                        if (this.Parent != null)
                                                base.BackColor = this.Parent.BackColor;
                                        base.ForeColor = this.DisplayStyle.TextColor;
                                        break;
                                case Lazaro.Pres.DisplayStyles.TextStyles.Bigger:
                                        base.Font = Lazaro.Pres.DisplayStyles.Template.Current.BiggerFont;
                                        base.Padding = new Padding(3);
                                        if (this.Parent != null)
                                                base.BackColor = this.Parent.BackColor;
                                        base.ForeColor = this.DisplayStyle.TextColor;
                                        break;
                                case Lazaro.Pres.DisplayStyles.TextStyles.Warning:
                                        base.Font = Lazaro.Pres.DisplayStyles.Template.Current.DefaultFont;
                                        base.Padding = new Padding(0, 4, 0, 4);
                                        base.BackColor = System.Drawing.Color.Tomato;
                                        base.ForeColor = System.Drawing.Color.White;
                                        break;
                                case Lazaro.Pres.DisplayStyles.TextStyles.SmallWarning:
                                        base.Font = Lazaro.Pres.DisplayStyles.Template.Current.SmallFont;
                                        base.Padding = new Padding(0, 2, 0, 2);
                                        base.BackColor = System.Drawing.Color.Tomato;
                                        base.ForeColor = System.Drawing.Color.White;
                                        break;
                                case Lazaro.Pres.DisplayStyles.TextStyles.Info:
                                        base.Font = Lazaro.Pres.DisplayStyles.Template.Current.DefaultFont;
                                        base.Padding = new Padding(0, 4, 0, 4);
                                        base.BackColor = System.Drawing.SystemColors.Info;
                                        base.ForeColor = System.Drawing.SystemColors.InfoText;
                                        break;
                                case Lazaro.Pres.DisplayStyles.TextStyles.DataEntry:
                                        base.Font = Lazaro.Pres.DisplayStyles.Template.Current.DataEntryFont;
                                        base.Padding = new Padding(0, 4, 0, 4);
                                        base.BackColor = this.DisplayStyle.DataAreaColor;
                                        base.ForeColor = this.DisplayStyle.DataAreaTextColor;
                                        break;
                        }
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
