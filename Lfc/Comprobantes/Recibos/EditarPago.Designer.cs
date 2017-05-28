namespace Lfc.Comprobantes.Recibos
{
        partial class EditarPago
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
                        this.Pago = new Lcc.Edicion.Comprobantes.Pago();
                        this.SuspendLayout();
                        // 
                        // Pago
                        // 
                        this.Pago.Font = new System.Drawing.Font("Segoe UI", 9.75F);
                        this.Pago.FormaDePagoEditable = true;
                        this.Pago.FormaDePagoVisible = true;
                        this.Pago.ImporteEditable = true;
                        this.Pago.ImporteVisible = true;
                        this.Pago.Location = new System.Drawing.Point(24, 24);
                        this.Pago.Name = "Pago";
                        this.Pago.ObsVisible = true;
                        this.Pago.Size = new System.Drawing.Size(464, 368);
                        this.Pago.TabIndex = 0;
                        this.Pago.Text = "Detalles del pago";
                        this.Pago.TituloVisible = true;
                        // 
                        // EditarPago
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(510, 452);
                        this.Controls.Add(this.Pago);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "EditarPago";
                        this.Text = "Pago";
                        this.Controls.SetChildIndex(this.Pago, 0);
                        this.ResumeLayout(false);

                }

                #endregion

                public Lcc.Edicion.Comprobantes.Pago Pago;

        }
}
