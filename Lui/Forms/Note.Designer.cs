namespace Lui.Forms
{
	partial class Note
	{
		/// <summary> 
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de componentes

		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
                        this.LabelTitle = new Lui.Forms.Label();
                        this.LabelText = new Lui.Forms.Label();
                        this.label1 = new System.Windows.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // LabelTitle
                        // 
                        this.LabelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.LabelTitle.AutoEllipsis = true;
                        this.LabelTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.LabelTitle.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        this.LabelTitle.Location = new System.Drawing.Point(4, 4);
                        this.LabelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.LabelTitle.Name = "LabelTitle";
                        this.LabelTitle.Size = new System.Drawing.Size(312, 24);
                        this.LabelTitle.TabIndex = 0;
                        this.LabelTitle.Text = "Title";
                        this.LabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.LabelTitle.UseMnemonic = false;
                        // 
                        // LabelText
                        // 
                        this.LabelText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.LabelText.AutoEllipsis = true;
                        this.LabelText.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.LabelText.Location = new System.Drawing.Point(16, 36);
                        this.LabelText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.LabelText.Name = "LabelText";
                        this.LabelText.Size = new System.Drawing.Size(297, 120);
                        this.LabelText.TabIndex = 1;
                        this.LabelText.Text = "Text";
                        this.LabelText.UseMnemonic = false;
                        // 
                        // label1
                        // 
                        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
                        this.label1.Location = new System.Drawing.Point(4, 30);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(313, 1);
                        this.label1.TabIndex = 2;
                        // 
                        // Note
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.LabelTitle);
                        this.Controls.Add(this.LabelText);
                        this.Name = "Note";
                        this.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
                        this.Size = new System.Drawing.Size(320, 160);
                        this.Controls.SetChildIndex(this.LabelText, 0);
                        this.Controls.SetChildIndex(this.LabelTitle, 0);
                        this.Controls.SetChildIndex(this.label1, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

		}

		#endregion

		private Lui.Forms.Label LabelTitle;
		private Lui.Forms.Label LabelText;
                private System.Windows.Forms.Label label1;
	}
}
