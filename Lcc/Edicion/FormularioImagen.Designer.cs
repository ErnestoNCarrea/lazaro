namespace Lcc.Edicion
{
        partial class FormularioImagen
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
                        if (disposing && (components != null)) {
                                components.Dispose();
                        }
                        base.Dispose(disposing);
                }

                #region Código generado por el Diseñador de Windows Forms

                /// <summary>
                /// Método necesario para admitir el Diseñador. No se puede modificar
                /// el contenido del método con el editor de código.
                /// </summary>
                private void InitializeComponent()
                {
                        this.EntradaImagen = new Lcc.Entrada.Imagen();
                        this.SuspendLayout();
                        // 
                        // EntradaImagen
                        // 
                        this.EntradaImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaImagen.AutoSize = true;
                        this.EntradaImagen.Location = new System.Drawing.Point(8, 8);
                        this.EntradaImagen.MinimumSize = new System.Drawing.Size(240, 160);
                        this.EntradaImagen.Name = "EntradaImagen";
                        this.EntradaImagen.Size = new System.Drawing.Size(620, 298);
                        this.EntradaImagen.TabIndex = 51;
                        // 
                        // FormularioImagen
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(634, 372);
                        this.Controls.Add(this.EntradaImagen);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "FormularioImagen";
                        this.Text = "Imagen";
                        this.Controls.SetChildIndex(this.EntradaImagen, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                public Entrada.Imagen EntradaImagen;

        }
}
