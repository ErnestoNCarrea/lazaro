namespace Lfc.Inicio
{
        partial class ControlTablero
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
                        this.EtiquetaTitulo = new System.Windows.Forms.Label();
                        this.ImagenIcono = new System.Windows.Forms.PictureBox();
                        this.EtiquetaDescripcion = new System.Windows.Forms.Label();
                        ((System.ComponentModel.ISupportInitialize)(this.ImagenIcono)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.EtiquetaTitulo.ForeColor = System.Drawing.Color.White;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(75, 20);
                        this.EtiquetaTitulo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(140, 41);
                        this.EtiquetaTitulo.TabIndex = 0;
                        this.EtiquetaTitulo.Text = "Personas";
                        this.EtiquetaTitulo.UseMnemonic = false;
                        // 
                        // ImagenIcono
                        // 
                        this.ImagenIcono.InitialImage = null;
                        this.ImagenIcono.Location = new System.Drawing.Point(20, 20);
                        this.ImagenIcono.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                        this.ImagenIcono.Name = "ImagenIcono";
                        this.ImagenIcono.Size = new System.Drawing.Size(45, 40);
                        this.ImagenIcono.TabIndex = 1;
                        this.ImagenIcono.TabStop = false;
                        // 
                        // EtiquetaDescripcion
                        // 
                        this.EtiquetaDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.EtiquetaDescripcion.ForeColor = System.Drawing.Color.WhiteSmoke;
                        this.EtiquetaDescripcion.Location = new System.Drawing.Point(80, 60);
                        this.EtiquetaDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.EtiquetaDescripcion.Name = "EtiquetaDescripcion";
                        this.EtiquetaDescripcion.Size = new System.Drawing.Size(495, 140);
                        this.EtiquetaDescripcion.TabIndex = 4;
                        this.EtiquetaDescripcion.Text = "Descripción del elemento.";
                        // 
                        // ControlTablero
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                        this.BackColor = System.Drawing.Color.MediumSeaGreen;
                        this.Controls.Add(this.ImagenIcono);
                        this.Controls.Add(this.EtiquetaDescripcion);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Font = new System.Drawing.Font("Bitstream Vera Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                        this.Name = "ControlTablero";
                        this.Size = new System.Drawing.Size(600, 200);
                        ((System.ComponentModel.ISupportInitialize)(this.ImagenIcono)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.Label EtiquetaTitulo;
                private System.Windows.Forms.PictureBox ImagenIcono;
                private System.Windows.Forms.Label EtiquetaDescripcion;
        }
}
