namespace Lui.Forms.AuxForms
{
	partial class TextEdit
	{
		#region Código generado por el Diseñador de Windows Forms

		private void InitializeComponent()
		{
                        this.EntradaTexto = new Lui.Forms.TextBox();
                        this.SuspendLayout();
                        // 
                        // EntradaTexto
                        // 
                        this.EntradaTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaTexto.Location = new System.Drawing.Point(24, 24);
                        this.EntradaTexto.MultiLine = true;
                        this.EntradaTexto.Name = "EntradaTexto";
                        this.EntradaTexto.Size = new System.Drawing.Size(576, 248);
                        this.EntradaTexto.TabIndex = 0;
                        // 
                        // TextEdit
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(624, 362);
                        this.Controls.Add(this.EntradaTexto);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "TextEdit";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        this.Text = "Editor extendido";
                        this.Controls.SetChildIndex(this.EntradaTexto, 0);
                        this.ResumeLayout(false);

		}

                protected Lui.Forms.TextBox EntradaTexto;

		#endregion
	}
}
