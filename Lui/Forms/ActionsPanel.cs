using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Lui.Forms
{
        public partial class ActionsPanel : UserControl, IControl, IDisplayStyleControl
        {
                public Lazaro.Pres.Forms.FormActionCollection FormActions { get; set; }
                public event EventHandler ButtonClick;

                public ActionsPanel()
                {
                        InitializeComponent();
                        base.BackColor = this.DisplayStyle.DarkColor;
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


                public void ActualizarControl()
                {
                        if (FormActions == null) {
                                PanelPrimario.Controls.Clear();
                                PanelSecundario.Controls.Clear();
                                return;
                        }

                        this.SuspendLayout();
                        PanelPrimario.SuspendLayout();
                        PanelSecundario.SuspendLayout();

                        // Primero elimino los botones que ya no están en la lista
                        foreach (Control btn in PanelPrimario.Controls) {
                                if (btn is Lui.Forms.Button) {
                                        if (FormActions.ContainsKey(btn.Name) == false) {
                                                // No existe... lo elimino
                                                PanelPrimario.Controls.Remove(btn);
                                                btn.Dispose();
                                        } else if (FormActions[btn.Name].Visibility != Lazaro.Pres.Forms.FormActionVisibility.Main) {
                                                // Existe... pero no en el panel primario
                                                PanelPrimario.Controls.Remove(btn);
                                                btn.Dispose();
                                        }
                                }
                        }

                        foreach (Control btn in PanelSecundario.Controls) {
                                if (btn is Lui.Forms.Button) {
                                        if (FormActions.ContainsKey(btn.Name) == false) {
                                                // No existe... lo elimino
                                                PanelSecundario.Controls.Remove(btn);
                                                btn.Dispose();
                                        } else if (FormActions[btn.Name].Visibility != Lazaro.Pres.Forms.FormActionVisibility.Secondary) {
                                                // Existe... pero no en el panel secundario
                                                PanelSecundario.Controls.Remove(btn);
                                                btn.Dispose();
                                        }
                                }
                        }

                        int PrimaryWidth = 0, SecondaryWidth = 0;

                        // Ordeno por TabIndex
                        this.FormActions.Sort(delegate(Lazaro.Pres.Forms.FormAction itm, Lazaro.Pres.Forms.FormAction itm2) { return itm.TabIndex.CompareTo(itm2.TabIndex); });

                        int IdxPri = 0, IdxSec = 0;
                        // Ahora agrego o actualizo los botones existentes
                        foreach (Lazaro.Pres.Forms.FormAction act in this.FormActions) {
                                // Me fijo en que panel va
                                FlowLayoutPanel Panel;
                                if (act.Visibility == Lazaro.Pres.Forms.FormActionVisibility.Main)
                                        Panel = this.PanelPrimario;
                                else if (act.Visibility == Lazaro.Pres.Forms.FormActionVisibility.Secondary)
                                        Panel = this.PanelSecundario;
                                else
                                        Panel = null;

                                if (Panel != null) {
                                        Lui.Forms.Button Btn;
                                        if (Panel.Controls.ContainsKey(act.Name)) {
                                                // Existe, lo actualizo
                                                Btn = Panel.Controls[act.Name] as Lui.Forms.Button;
                                        } else {
                                                // No existe, lo agrego
                                                Btn = new Lui.Forms.Button();
                                                Btn.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                                                Btn.Name = act.Name;
                                                Btn.Size = new System.Drawing.Size(116, Panel.ClientRectangle.Height);
                                                Btn.Visible = true;
                                                Btn.Click += new EventHandler(this.Btn_Click);

                                                Panel.Controls.Add(Btn);
                                        }

                                        Btn.Text = act.Text;
                                        Btn.Subtext = act.SubText;
                                        if (act.SubText == null)
                                                Btn.SubLabelPos = SubLabelPositions.None;
                                        else
                                                Btn.SubLabelPos = SubLabelPositions.Bottom;
                                        Btn.Enabled = act.Enabled;
                                        Btn.TabIndex = act.TabIndex;
                                        if (Panel == this.PanelPrimario)
                                                Panel.Controls.SetChildIndex(Btn, IdxPri++);
                                        else
                                                Panel.Controls.SetChildIndex(Btn, IdxSec++);

                                        if (act.Visibility == Lazaro.Pres.Forms.FormActionVisibility.Main)
                                                PrimaryWidth += Btn.Width + Btn.Margin.Left + Btn.Margin.Right;
                                        else if (act.Visibility == Lazaro.Pres.Forms.FormActionVisibility.Secondary)
                                                SecondaryWidth += Btn.Width + Btn.Margin.Left + Btn.Margin.Right;
                                }
                        }

                        PanelPrimario.Width = PrimaryWidth + 8;
                        PanelSecundario.Width = SecondaryWidth + 8;

                        PanelSecundario.ResumeLayout(true);
                        PanelPrimario.ResumeLayout(true);
                        this.ResumeLayout(true);
                }


                [DefaultValue(System.Windows.Forms.FlowDirection.RightToLeft)]
                public FlowDirection FlowDirection
                {
                        get
                        {
                                return this.PanelPrimario.FlowDirection;
                        }
                        set
                        {
                                this.PanelPrimario.FlowDirection = value;
                                switch(value) {
                                        case System.Windows.Forms.FlowDirection.BottomUp:
                                                PanelSecundario.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
                                                break;
                                        case System.Windows.Forms.FlowDirection.LeftToRight:
                                                PanelSecundario.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
                                                break;
                                        case System.Windows.Forms.FlowDirection.RightToLeft:
                                                PanelSecundario.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
                                                break;
                                        case System.Windows.Forms.FlowDirection.TopDown:
                                                PanelSecundario.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
                                                break;
                                }
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

                private void Btn_Click(object sender, EventArgs e)
                {
                        if (this.ButtonClick != null)
                                this.ButtonClick(sender, e);
                }
        }
}
