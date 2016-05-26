namespace Lfc.Comprobantes.Facturas
{
        partial class SaldoEnCuentaCorriente
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaldoEnCuentaCorriente));
                        this.label2 = new Lui.Forms.Label();
                        this.label1 = new Lui.Forms.Label();
                        this.BotonCancelar = new Lui.Forms.Button();
                        this.BotonContinuar = new Lui.Forms.Button();
                        this.BotonCorregir = new Lui.Forms.Button();
                        this.pictureBox2 = new System.Windows.Forms.PictureBox();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(88, 56);
                        this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(520, 48);
                        this.label2.TabIndex = 1;
                        this.label2.Text = "El cliente tiene saldo a favor en su cuenta corriente, suficiente para cubrir el " +
    "total de la factura que va a imprimir. ¿Desea imprimir esta factura en cuenta co" +
    "rriente?";
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(88, 24);
                        this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(520, 28);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "Posible error en la forma de pago";
                        this.label1.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // BotonCancelar
                        // 
                        this.BotonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonCancelar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.BotonCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BotonCancelar.Image")));
                        this.BotonCancelar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonCancelar.Location = new System.Drawing.Point(88, 304);
                        this.BotonCancelar.Name = "BotonCancelar";
                        this.BotonCancelar.Size = new System.Drawing.Size(520, 72);
                        this.BotonCancelar.SubLabelPos = Lui.Forms.SubLabelPositions.LongBottom;
                        this.BotonCancelar.Subtext = "No imprime la factura. Sólo vuelve al formulario anterior.";
                        this.BotonCancelar.TabIndex = 4;
                        this.BotonCancelar.Text = "Volver atrás";
                        this.BotonCancelar.Click += new System.EventHandler(this.BotonCancelar_Click);
                        // 
                        // BotonContinuar
                        // 
                        this.BotonContinuar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonContinuar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonContinuar.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.BotonContinuar.Image = ((System.Drawing.Image)(resources.GetObject("BotonContinuar.Image")));
                        this.BotonContinuar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonContinuar.Location = new System.Drawing.Point(88, 208);
                        this.BotonContinuar.Name = "BotonContinuar";
                        this.BotonContinuar.Size = new System.Drawing.Size(520, 80);
                        this.BotonContinuar.SubLabelPos = Lui.Forms.SubLabelPositions.LongBottom;
                        this.BotonContinuar.Subtext = "Los pagos ingresados con anterioridad no corresponden a esta factura. Esta factur" +
    "a llevará un pago aparte.";
                        this.BotonContinuar.TabIndex = 3;
                        this.BotonContinuar.Text = "No, usar la forma de pago que yo seleccioné";
                        this.BotonContinuar.Click += new System.EventHandler(this.BotonContinuar_Click);
                        // 
                        // BotonCorregir
                        // 
                        this.BotonCorregir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonCorregir.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonCorregir.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.BotonCorregir.Image = ((System.Drawing.Image)(resources.GetObject("BotonCorregir.Image")));
                        this.BotonCorregir.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonCorregir.Location = new System.Drawing.Point(88, 112);
                        this.BotonCorregir.Name = "BotonCorregir";
                        this.BotonCorregir.Size = new System.Drawing.Size(520, 80);
                        this.BotonCorregir.SubLabelPos = Lui.Forms.SubLabelPositions.LongBottom;
                        this.BotonCorregir.Subtext = "La factura quedará pagada utilizando el saldo que se encuentra en la cuenta del c" +
    "liente.";
                        this.BotonCorregir.TabIndex = 2;
                        this.BotonCorregir.Text = "Si, usar la cuenta corriente del cliente";
                        this.BotonCorregir.Click += new System.EventHandler(this.BotonCorregir_Click);
                        // 
                        // pictureBox2
                        // 
                        this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
                        this.pictureBox2.Location = new System.Drawing.Point(24, 24);
                        this.pictureBox2.Name = "pictureBox2";
                        this.pictureBox2.Size = new System.Drawing.Size(52, 49);
                        this.pictureBox2.TabIndex = 6;
                        this.pictureBox2.TabStop = false;
                        // 
                        // SaldoEnCuentaCorriente
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(634, 400);
                        this.Controls.Add(this.pictureBox2);
                        this.Controls.Add(this.BotonCancelar);
                        this.Controls.Add(this.BotonContinuar);
                        this.Controls.Add(this.BotonCorregir);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.label1);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                        this.Name = "SaldoEnCuentaCorriente";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        this.Text = "Cliente con saldo a favor";
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private Lui.Forms.Label label2;
                private Lui.Forms.Label label1;
                private Lui.Forms.Button BotonCancelar;
                private Lui.Forms.Button BotonContinuar;
                private Lui.Forms.Button BotonCorregir;
                private System.Windows.Forms.PictureBox pictureBox2;
        }
}
