namespace Lcc.Entrada.Articulos
{
        partial class VariacionCantidad
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
                        this.EntradaCantidad = new Lui.Forms.TextBox();
                        this.EntradaVariacion = new Lui.Forms.TextBox();
                        this.SuspendLayout();
                        // 
                        // EntradaCantidad
                        // 
                        this.EntradaCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCantidad.DataType = Lui.Forms.DataTypes.Float;
                        this.EntradaCantidad.Location = new System.Drawing.Point(368, 0);
                        this.EntradaCantidad.Name = "EntradaCantidad";
                        this.EntradaCantidad.ReadOnly = false;
                        this.EntradaCantidad.Size = new System.Drawing.Size(112, 24);
                        this.EntradaCantidad.TabIndex = 54;
                        this.EntradaCantidad.Text = "1.0000";
                        this.EntradaCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntradaCantidad_KeyDown);
                        this.EntradaCantidad.TextChanged += new System.EventHandler(this.EntradaVariacionCantidad_TextChanged);
                        // 
                        // EntradaVariacion
                        // 
                        this.EntradaVariacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaVariacion.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaVariacion.Location = new System.Drawing.Point(0, 0);
                        this.EntradaVariacion.Name = "EntradaVariacion";
                        this.EntradaVariacion.ReadOnly = false;
                        this.EntradaVariacion.Size = new System.Drawing.Size(364, 24);
                        this.EntradaVariacion.TabIndex = 53;
                        this.EntradaVariacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntradaVariacion_KeyDown);
                        this.EntradaVariacion.TextChanged += new System.EventHandler(this.EntradaVariacionCantidad_TextChanged);
                        // 
                        // VariacionCantidad
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.EntradaCantidad);
                        this.Controls.Add(this.EntradaVariacion);
                        this.Name = "VariacionCantidad";
                        this.Size = new System.Drawing.Size(480, 24);
                        this.Controls.SetChildIndex(this.EntradaVariacion, 0);
                        this.Controls.SetChildIndex(this.EntradaCantidad, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private Lui.Forms.TextBox EntradaCantidad;
                private Lui.Forms.TextBox EntradaVariacion;
        }
}
