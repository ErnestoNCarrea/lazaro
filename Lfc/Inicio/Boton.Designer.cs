namespace Lfc.Inicio
{
        partial class Boton
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

                #region Código generado por el Diseñador de componentes

                /// <summary> 
                /// Método necesario para admitir el Diseñador. No se puede modificar 
                /// el contenido del método con el editor de código.
                /// </summary>
                private void InitializeComponent()
                {
                        this.EtiquetaTexto = new System.Windows.Forms.Label();
                        this.ImagenIcono = new System.Windows.Forms.PictureBox();
                        ((System.ComponentModel.ISupportInitialize)(this.ImagenIcono)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // EtiquetaTexto
                        // 
                        this.EtiquetaTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaTexto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.EtiquetaTexto.ForeColor = System.Drawing.Color.White;
                        this.EtiquetaTexto.Location = new System.Drawing.Point(36, 4);
                        this.EtiquetaTexto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.EtiquetaTexto.Name = "EtiquetaTexto";
                        this.EtiquetaTexto.Size = new System.Drawing.Size(200, 32);
                        this.EtiquetaTexto.TabIndex = 0;
                        this.EtiquetaTexto.Text = "label1";
                        this.EtiquetaTexto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.EtiquetaTexto.UseMnemonic = false;
                        this.EtiquetaTexto.Click += new System.EventHandler(this.EtiquetaTexto_Click);
                        // 
                        // ImagenIcono
                        // 
                        this.ImagenIcono.Location = new System.Drawing.Point(4, 4);
                        this.ImagenIcono.Name = "ImagenIcono";
                        this.ImagenIcono.Size = new System.Drawing.Size(32, 32);
                        this.ImagenIcono.TabIndex = 1;
                        this.ImagenIcono.TabStop = false;
                        this.ImagenIcono.Click += new System.EventHandler(this.ImagenIcono_Click);
                        // 
                        // Boton
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.ImagenIcono);
                        this.Controls.Add(this.EtiquetaTexto);
                        this.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.Font = new System.Drawing.Font("Bitstream Vera Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.Name = "Boton";
                        this.Size = new System.Drawing.Size(240, 40);
                        ((System.ComponentModel.ISupportInitialize)(this.ImagenIcono)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Label EtiquetaTexto;
                private System.Windows.Forms.PictureBox ImagenIcono;
        }
}
