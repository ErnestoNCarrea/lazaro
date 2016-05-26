using System.ComponentModel;

namespace Lui.Forms
{
        public class EditableControl : Control, IEditableControl
        {
                [DefaultValue(null)]
                public string FieldName { get; set; }

                /// <summary>
                /// IDataControl
                /// </summary>
                [EditorBrowsable(EditorBrowsableState.Never), System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public bool Changed
                {
                        get
                        {
                                if (this.GetControlsChanged(this.Controls, false))
                                        return true;
                                else
                                        return m_Changed;
                        }
                        set
                        {
                                m_Changed = value;
                                this.SetControlsChanged(this.Controls, value);
                                Invalidate();
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
                public override string Text
                {
                        get
                        {
                                return base.Text;
                        }
                        set
                        {
                                base.Text = value;
                                //this.Changed = false;
                        }
                }

                protected void SetControlsChanged(System.Windows.Forms.Control.ControlCollection controles, bool newValue)
                {
                        if (controles == null)
                                return;

                        // Pongo los Changed en newValue
                        foreach (System.Windows.Forms.Control ctl in controles) {
                                if (ctl == null) {
                                        //Nada
                                } else if (ctl is IEditableControl) {
                                        ((IEditableControl)ctl).Changed = newValue;
                                } else if (ctl.Controls.Count > 0) {
                                        SetControlsChanged(ctl.Controls, newValue);
                                }
                        }
                }

                protected bool GetControlsChanged(System.Windows.Forms.Control.ControlCollection controls, bool showChanges)
                {
                        bool Result = false;
                        // Ver si algo cambió
                        foreach (System.Windows.Forms.Control ctl in controls) {
                                if (ctl == null) {
                                        //Nada
                                } else if (ctl is IEditableControl) {
                                        if (((IEditableControl)ctl).Changed)
                                                Result = true;
                                } else if (ctl.Controls.Count > 0) {
                                        if (GetControlsChanged(ctl.Controls, showChanges)) {
                                                //this.Changed = true;
                                                Result = true;
                                        }
                                }
                        }
                        return Result;
                }
        }
}
