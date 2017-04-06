namespace Lfc.Articulos
{
        partial class Receta
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
                        this.MatrizArticulos = new Lcc.Entrada.Articulos.MatrizDetalleComprobante();
                        this.SuspendLayout();
                        // 
                        // MatrizArticulos
                        // 
                        this.MatrizArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.MatrizArticulos.AplicaIva = true;
                        this.MatrizArticulos.AutoScroll = true;
                        this.MatrizArticulos.AutoScrollMargin = new System.Drawing.Size(4, 4);
                        this.MatrizArticulos.BloquearAtriculo = false;
                        this.MatrizArticulos.BloquearCantidad = false;
                        this.MatrizArticulos.BloquearDescuento = true;
                        this.MatrizArticulos.BloquearPrecio = true;
                        this.MatrizArticulos.DiscriminarIva = false;
                        this.MatrizArticulos.FreeTextCode = "*";
                        this.MatrizArticulos.Location = new System.Drawing.Point(24, 24);
                        this.MatrizArticulos.MostrarExistencias = false;
                        this.MatrizArticulos.Name = "MatrizArticulos";
                        this.MatrizArticulos.Precio = Lcc.Entrada.Articulos.Precios.Costo;
                        this.MatrizArticulos.Size = new System.Drawing.Size(584, 272);
                        this.MatrizArticulos.TabIndex = 0;
                        // 
                        // Receta
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(634, 372);
                        this.Controls.Add(this.MatrizArticulos);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "Receta";
                        this.Text = "Conformación de producto compuesto";
                        this.Controls.SetChildIndex(this.MatrizArticulos, 0);
                        this.ResumeLayout(false);

                }

                #endregion

                public Lcc.Entrada.Articulos.MatrizDetalleComprobante MatrizArticulos;
        }
}