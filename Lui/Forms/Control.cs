using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lui.Forms
{
	/// <summary>
	/// Clase base que define a un control.
	/// </summary>
	[Designer("System.Windows.Forms.Design.ControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner)),
                DefaultEvent("Click"),
                DefaultProperty("Text")]
        public partial class Control : System.Windows.Forms.UserControl, IControl, IDisplayStyleControl
	{
                protected bool m_AutoNav = true;
		protected bool m_Highlighted;
                protected Lui.Forms.Control.BorderStyles m_BorderStyle = Lui.Forms.Control.BorderStyles.Control;
                protected bool m_Changed, m_ReadOnly = false, m_TemporaryReadOnly = false, m_ShowChanged, m_AutoHeight = false;
                protected int IgnoreChanges { get; set; }
		protected string m_Error = "";

                [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
                new public event System.EventHandler TextChanged;
                new public event System.EventHandler Click;
                new public event System.Windows.Forms.KeyEventHandler KeyDown;

		public enum BorderStyles
		{
			None = 0,
			Control,
			Frame,
                        EditableNoHightlight,
                        GenericEditable,
			TextBox,
			Button
		}


                public Control()
                {
                        InitializeComponent();

                        this.Font = Lazaro.Pres.DisplayStyles.Template.Current.DefaultFont;
                        base.BackColor = this.DisplayStyle.BackgroundColor;
                }


		[EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual string ErrorText
		{
			get
			{
				return m_Error;
			}
			set
			{
				m_Error = value;
				Invalidate();
			}
		}


                protected void RaiseClick(EventArgs e)
                {
                        if (this.Enabled && this.Click != null)
                                this.Click(this, e);
                }


                protected void RaiseKeyDown(KeyEventArgs e)
                {
                        if (this.Enabled && this.KeyDown != null)
                                this.KeyDown(this, e);
                }


                /// <summary>
                /// Obtiene o establece un valor que indica si el control tiene navegación con teclado mejorada.
                /// </summary>
                [System.ComponentModel.Category("Comportamiento"),
                        DefaultValue(true)]
                public bool AutoNav
                {
                        get
                        {
                                return m_AutoNav;
                        }
                        set
                        {
                                m_AutoNav = value;
                        }
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
                                EventHandler Tc = null;
                                if (base.Text != value)
                                        Tc = this.TextChanged;

				base.Text = value;

                                if (Tc != null)
                                        this.TextChanged(this, new EventArgs());
			}
		}


		[EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		new public System.Drawing.Color BackColor
		{
			get
			{
				return base.BackColor;
			}
                        /* set
                        {
                                base.BackColor = value;
                        } */
		}


                /// <summary>
                /// Devuelve o establece si el control está temporalmente (o permanentemente) inhabilitado para realizar cambios.
                /// </summary>
                [EditorBrowsable(EditorBrowsableState.Never), 
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
                        DefaultValue(false)]
		public virtual bool TemporaryReadOnly
		{
			get
			{
				return m_TemporaryReadOnly || m_ReadOnly;
			}
			set
			{
                                if (m_TemporaryReadOnly != value)
                                        Invalidate();
				m_TemporaryReadOnly = value;
                                this.SetControlsTemporaryReadOnly(this.Controls, value);
				
			}
		}


                /// <summary>
                /// Devuelve o establece si se trata de un control sólo de lectura.
                /// </summary>
                [EditorBrowsable(EditorBrowsableState.Always),
                        System.ComponentModel.Browsable(true),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible),
                        DefaultValue(false)]
                public virtual bool ReadOnly
                {
                        get
                        {
                                return m_ReadOnly;
                        }
                        set
                        {
                                if (m_ReadOnly != value)
                                        Invalidate();
                                m_ReadOnly = value;
                        }
                }


                /// <summary>
                /// Pongo la propiedad TemporaryReadOnly de los controles hijos en cascada.
                /// </summary>
                internal void SetControlsTemporaryReadOnly(System.Windows.Forms.Control.ControlCollection controles, bool newValue)
                {
                        if (controles == null)
                                return;

                        foreach (System.Windows.Forms.Control ctl in controles) {
                                if (ctl == null) {
                                        //Nada
                                } else if (ctl is Lui.Forms.Control) {
                                        ((Lui.Forms.Control)ctl).TemporaryReadOnly = newValue;
                                } else if (ctl.Controls != null && ctl.Controls.Count > 0) {
                                        SetControlsTemporaryReadOnly(ctl.Controls, newValue);
                                }
                        }
                }


		protected override bool IsInputKey(Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Up:
				case Keys.Down:
				case Keys.Left:
				case Keys.Right:
					return true;
				default:
					return base.IsInputKey(keyData);
			}
		}


		[EditorBrowsable(EditorBrowsableState.Never), System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected new Lui.Forms.Control.BorderStyles BorderStyle
		{
			get
			{
				return m_BorderStyle;
			}
			set
			{
				m_BorderStyle = value;
				Invalidate();
			}
		}


		[EditorBrowsable(EditorBrowsableState.Never), System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Highlighted
		{
			get
			{
				return m_Highlighted;
			}
			set
			{
				m_Highlighted = value;
				Invalidate();
			}
		}


		private void Control_Enter(object sender, System.EventArgs e)
		{
			this.Highlighted = true;
		}


		private void Control_Leave(object sender, System.EventArgs e)
		{
			this.Highlighted = false;
		}


		private void Control_TabStopChanged(object sender, System.EventArgs e)
		{
			Invalidate();
		}


		[EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		virtual public bool ShowChanged
		{
			set
			{
				m_ShowChanged = value;
                                this.ShowControlsChanged(this.Controls, value);
				Invalidate();
			}
		}


                private void ShowControlsChanged(System.Windows.Forms.Control.ControlCollection controles, bool newValue)
                {
                        if (controles == null)
                                return;

                        // Pongo los Changed en newValue
                        foreach (System.Windows.Forms.Control ctl in controles) {
                                if (ctl == null) {
                                        //Nada
                                } else if (ctl is IEditableControl) {
                                        ((IEditableControl)ctl).ShowChanged = newValue;
                                } else if (ctl.Controls.Count > 0) {
                                        ShowControlsChanged(ctl.Controls, newValue);
                                }
                        }
                }


		private void Control_Resize(object sender, System.EventArgs e)
		{
			this.Invalidate();
		}


                protected override void OnTextChanged(EventArgs e)
                {
                        EventHandler Tceh = this.TextChanged;
                        if (Tceh != null)
                                Tceh(this, e);

                        base.OnTextChanged(e);
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
                        set
                        {
                                base.Font = value;
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
                        set
                        {
                                base.ForeColor = value;
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Always),
                        Browsable(true),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public virtual Lazaro.Pres.DisplayStyles.IDisplayStyle DisplayStyle
                {
                        get
                        {
                                if (this.Parent is IForm)
                                        return ((IForm)(this.Parent)).DisplayStyle;
                                else if (this.Parent is IDisplayStyleControl)
                                        return ((IDisplayStyleControl)(this.Parent)).DisplayStyle;
                                else if (this.ParentForm is IForm)
                                        return ((IForm)(this.ParentForm)).DisplayStyle;
                                else
                                        return Lazaro.Pres.DisplayStyles.Template.Current.Default;
                        }
                }


                protected override void OnParentChanged(EventArgs e)
                {
                        base.OnParentChanged(e);
                        this.DisposePens();
                        this.ApplyStyle();
                }

                protected override void OnParentBackColorChanged(EventArgs e)
                {
                        base.OnParentBackColorChanged(e);
                        this.DisposePens();
                        this.ApplyStyle();
                }

                public virtual void ApplyStyle()
                {
                        base.BackColor = this.DisplayStyle.BackgroundColor;
                        this.Invalidate();
                }


                private Pen m_PenBorderColor, m_PenActiveBorderColor, m_PenDataAreaGrayTextColor, m_PenLightColor, m_PenDataAreaColor;

                private void DisposePens()
                {
                        if (m_PenBorderColor != null) {
                                m_PenBorderColor.Dispose();
                                m_PenBorderColor = null;
                        }
                        if (m_PenActiveBorderColor != null) {
                                m_PenActiveBorderColor.Dispose();
                                m_PenActiveBorderColor = null;
                        }
                        if (m_PenDataAreaGrayTextColor != null) {
                                m_PenDataAreaGrayTextColor.Dispose();
                                m_PenDataAreaGrayTextColor = null;
                        }
                        if (m_PenLightColor != null) {
                                m_PenLightColor.Dispose();
                                m_PenLightColor = null;
                        }
                        if (m_PenDataAreaColor != null) {
                                m_PenDataAreaColor.Dispose();
                                m_PenDataAreaColor = null;
                        }
                }

                protected Pen PenBorderColor
                {
                        get
                        {
                                if (m_PenBorderColor == null)
                                        m_PenBorderColor = new Pen(this.DisplayStyle.BorderColor);
                                return m_PenBorderColor;
                        }
                }

                protected Pen PenActiveBorderColor
                {
                        get
                        {
                                if (m_PenActiveBorderColor == null)
                                        m_PenActiveBorderColor = new Pen(this.DisplayStyle.ActiveBorderColor);
                                return m_PenActiveBorderColor;
                        }
                }

                protected Pen PenDataAreaGrayTextColor
                {
                        get
                        {
                                if (m_PenDataAreaGrayTextColor == null)
                                        m_PenDataAreaGrayTextColor = new Pen(this.DisplayStyle.DataAreaGrayTextColor);
                                return m_PenDataAreaGrayTextColor;
                        }
                }

                protected Pen PenLightColor
                {
                        get
                        {
                                if (m_PenLightColor == null)
                                        m_PenLightColor = new Pen(this.DisplayStyle.LightColor);
                                return m_PenLightColor;
                        }
                }

                protected Pen PenDataAreaColor
                {
                        get
                        {
                                if (m_PenDataAreaColor == null)
                                        m_PenDataAreaColor = new Pen(this.DisplayStyle.DataAreaColor);
                                return m_PenDataAreaColor;
                        }
                }

                protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
                {
                        switch (m_BorderStyle) {
                                case BorderStyles.Button:
                                        e.Graphics.Clear(this.BackColor);
                                        break;
                                case BorderStyles.TextBox:
                                        e.Graphics.Clear(this.DisplayStyle.DataAreaColor);
                                        break;
                                default:
                                        e.Graphics.Clear(this.DisplayStyle.BackgroundColor);
                                        break;
                        }

                        switch (m_BorderStyle) {
                                case BorderStyles.None:
                                        break;
                                case BorderStyles.EditableNoHightlight:
                                        if (m_ShowChanged && m_Changed && m_ReadOnly == false) {
                                                e.Graphics.DrawRectangle(System.Drawing.Pens.Red, new System.Drawing.Rectangle(3, this.Height - 2, this.Width - 6, 1));
                                        }
                                        break;
                                case BorderStyles.GenericEditable:
                                        if (m_Highlighted) {
                                                if (m_ReadOnly || m_TemporaryReadOnly) {
                                                        e.Graphics.DrawRectangle(PenDataAreaGrayTextColor, new System.Drawing.Rectangle(0, 0, this.Width - 1, this.Height - 1));
                                                        e.Graphics.DrawRectangle(PenDataAreaGrayTextColor, new System.Drawing.Rectangle(1, 1, this.Width - 3, this.Height - 3));
                                                } else {
                                                        e.Graphics.DrawRectangle(PenActiveBorderColor, new System.Drawing.Rectangle(0, 0, this.Width - 1, this.Height - 1));
                                                        e.Graphics.DrawRectangle(PenActiveBorderColor, new System.Drawing.Rectangle(1, 1, this.Width - 3, this.Height - 3));
                                                }
                                        }
                                        if (m_ShowChanged && m_Changed && m_ReadOnly == false) {
                                                e.Graphics.DrawRectangle(System.Drawing.Pens.Red, new System.Drawing.Rectangle(3, this.Height - 2, this.Width - 6, 1));
                                        }
                                        break;
                                case BorderStyles.TextBox:
                                        // Subrayado
                                        // e.Graphics.DrawRectangle(new System.Drawing.Pen(Color.Silver), new System.Drawing.Rectangle(0, this.Height - 1, this.Width - 1, this.Height - 1));
                                        if (m_ShowChanged && m_Changed && m_ReadOnly == false) {
                                                e.Graphics.DrawRectangle(System.Drawing.Pens.Red, new System.Drawing.Rectangle(3, this.Height - 2, this.Width - 6, 1));
                                        } else if (m_Highlighted) {
                                                if (m_ReadOnly || m_TemporaryReadOnly) {
                                                        e.Graphics.DrawRectangle(PenDataAreaGrayTextColor, new System.Drawing.Rectangle(0, 0, this.Width - 1, this.Height - 1));
                                                        e.Graphics.DrawRectangle(PenDataAreaGrayTextColor, new System.Drawing.Rectangle(1, 1, this.Width - 3, this.Height - 3));
                                                } else {
                                                        e.Graphics.DrawRectangle(PenActiveBorderColor, new System.Drawing.Rectangle(0, 0, this.Width - 1, this.Height - 1));
                                                        e.Graphics.DrawRectangle(PenActiveBorderColor, new System.Drawing.Rectangle(1, 1, this.Width - 3, this.Height - 3));
                                                        //Borde redondeado
                                                        //e.Graphics.DrawRectangle(new System.Drawing.Pen(this.DisplayStyle.SelectionColor), new System.Drawing.Rectangle(0, 0, this.Width - 1, this.Height - 1));
                                                        //e.Graphics.DrawRectangle(new System.Drawing.Pen(this.DisplayStyle.SelectionColor), new System.Drawing.Rectangle(1, 1, this.Width - 3, this.Height - 3));
                                                }
                                        } else {
                                                // Borde fino
                                                e.Graphics.DrawRectangle(m_Highlighted ? PenActiveBorderColor : PenBorderColor, new System.Drawing.Rectangle(0, 0, this.Width - 1, this.Height - 1));
                                                //e.Graphics.DrawRectangle(m_Highlighted ? PenActiveBorderColor : PenBorderColor, new System.Drawing.Rectangle(0, this.Height - 1, this.Width - 1, this.Height - 1));
                                        }
                                        if (m_Error != null && m_Error.Length > 0 && m_ShowChanged == false)
                                                e.Graphics.DrawRectangle(System.Drawing.Pens.DarkViolet, new System.Drawing.Rectangle(3, this.Height - 2, this.Width - 6, 1));
                                        break;
                                case BorderStyles.Button:
                                        if (m_Highlighted) {
                                                e.Graphics.DrawRectangle(PenActiveBorderColor, new System.Drawing.Rectangle(0, 0, this.Width - 1, this.Height - 1));
                                                e.Graphics.DrawRectangle(PenActiveBorderColor, new System.Drawing.Rectangle(1, 1, this.Width - 3, this.Height - 3));
                                        } else {
                                                e.Graphics.DrawRectangle(PenLightColor, new System.Drawing.Rectangle(0, 0, this.Width - 1, this.Height - 1));
                                                e.Graphics.DrawRectangle(PenLightColor, new System.Drawing.Rectangle(1, 1, this.Width - 3, this.Height - 3));
                                        }
                                        break;
                        }

                        base.OnPaint(e);
                }
	}
}