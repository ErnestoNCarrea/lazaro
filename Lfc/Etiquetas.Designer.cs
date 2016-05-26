namespace Lfc
{
        partial class Etiquetas
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
                        this.EntradaEtiquetas = new Lcc.Edicion.Etiquetas();
                        this.EntradaComentarios = new Lcc.Edicion.Comentarios();
                        this.SuspendLayout();
                        // 
                        // OkButton
                        // 
                        this.OkButton.Location = new System.Drawing.Point(384, 8);
                        // 
                        // CancelCommandButton
                        // 
                        this.CancelCommandButton.Location = new System.Drawing.Point(504, 8);
                        // 
                        // EntradaEtiquetas
                        // 
                        this.EntradaEtiquetas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaEtiquetas.Font = new System.Drawing.Font("Bitstream Vera Sans", 9.75F);
                        this.EntradaEtiquetas.Location = new System.Drawing.Point(453, 11);
                        this.EntradaEtiquetas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
                        this.EntradaEtiquetas.Name = "EntradaEtiquetas";
                        this.EntradaEtiquetas.ReadOnly = false;
                        this.EntradaEtiquetas.Size = new System.Drawing.Size(160, 287);
                        this.EntradaEtiquetas.TabIndex = 3;
                        this.EntradaEtiquetas.Text = "Etiquetas";
                        // 
                        // EntradaComentarios
                        // 
                        this.EntradaComentarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaComentarios.Font = new System.Drawing.Font("Bitstream Vera Sans", 9.75F);
                        this.EntradaComentarios.Location = new System.Drawing.Point(13, 11);
                        this.EntradaComentarios.Name = "EntradaComentarios";
                        this.EntradaComentarios.ReadOnly = false;
                        this.EntradaComentarios.Size = new System.Drawing.Size(434, 287);
                        this.EntradaComentarios.TabIndex = 1;
                        this.EntradaComentarios.Text = "Comentarios";
                        // 
                        // Etiquetas
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(624, 364);
                        this.Controls.Add(this.EntradaComentarios);
                        this.Controls.Add(this.EntradaEtiquetas);
                        this.Name = "Etiquetas";
                        this.Text = "Etiquetas";
                        this.Controls.SetChildIndex(this.EntradaEtiquetas, 0);
                        this.Controls.SetChildIndex(this.EntradaComentarios, 0);
                        this.ResumeLayout(false);

                }

                #endregion

                private Lcc.Edicion.Etiquetas EntradaEtiquetas;
                protected internal Lcc.Edicion.Comentarios EntradaComentarios;
        }
}
