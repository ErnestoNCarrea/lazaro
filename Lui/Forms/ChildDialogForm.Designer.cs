namespace Lui.Forms
{
	partial class ChildDialogForm
	{
		#region Código generado por el Diseñador de Windows Forms

                internal Lui.Forms.ButtonPanel LowerPanel;
		public Lui.Forms.Button OkButton;
		public Lui.Forms.Button CancelCommandButton;

		private void InitializeComponent()
		{
                        this.LowerPanel = new Lui.Forms.ButtonPanel();
                        this.CancelCommandButton = new Lui.Forms.Button();
                        this.OkButton = new Lui.Forms.Button();
                        this.LowerPanel.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // LowerPanel
                        // 
                        this.LowerPanel.Controls.Add(this.CancelCommandButton);
                        this.LowerPanel.Controls.Add(this.OkButton);
                        this.LowerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.LowerPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
                        this.LowerPanel.Location = new System.Drawing.Point(0, 230);
                        this.LowerPanel.Name = "LowerPanel";
                        this.LowerPanel.Padding = new System.Windows.Forms.Padding(12);
                        this.LowerPanel.Size = new System.Drawing.Size(474, 64);
                        this.LowerPanel.TabIndex = 100;
                        // 
                        // CancelCommandButton
                        // 
                        this.CancelCommandButton.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.CancelCommandButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.CancelCommandButton.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.CancelCommandButton.Image = null;
                        this.CancelCommandButton.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.CancelCommandButton.Location = new System.Drawing.Point(334, 12);
                        this.CancelCommandButton.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.CancelCommandButton.Name = "CancelCommandButton";
                        this.CancelCommandButton.Size = new System.Drawing.Size(116, 40);
                        this.CancelCommandButton.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.CancelCommandButton.Subtext = "Esc";
                        this.CancelCommandButton.TabIndex = 1;
                        this.CancelCommandButton.Text = "Volver";
                        this.CancelCommandButton.Click += new System.EventHandler(this.CancelCommandButton_Click);
                        // 
                        // OkButton
                        // 
                        this.OkButton.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.OkButton.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.OkButton.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.OkButton.Image = null;
                        this.OkButton.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.OkButton.Location = new System.Drawing.Point(212, 12);
                        this.OkButton.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.OkButton.Name = "OkButton";
                        this.OkButton.Size = new System.Drawing.Size(116, 40);
                        this.OkButton.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.OkButton.Subtext = "F9";
                        this.OkButton.TabIndex = 0;
                        this.OkButton.Text = "Aceptar";
                        this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
                        // 
                        // ChildDialogForm
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.CancelButton = this.CancelCommandButton;
                        this.ClientSize = new System.Drawing.Size(474, 294);
                        this.Controls.Add(this.LowerPanel);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.Name = "ChildDialogForm";
                        this.Text = "Diálogo";
                        this.SizeChanged += new System.EventHandler(this.ChildDialogForm_SizeChanged);
                        this.LowerPanel.ResumeLayout(false);
                        this.ResumeLayout(false);

		}

		#endregion
	}
}
