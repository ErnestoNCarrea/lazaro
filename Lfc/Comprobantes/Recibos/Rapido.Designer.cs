namespace Lfc.Comprobantes.Recibos
{
    partial class Rapido
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
            if (disposing && (components != null))
            {
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
                        this.EntradaCaja = new Lcc.Entrada.CodigoDetalle();
                        this.Label3 = new Lui.Forms.Label();
                        this.EntradaCliente = new Lcc.Entrada.CodigoDetalle();
                        this.Label5 = new Lui.Forms.Label();
                        this.EntradaImporte = new Lui.Forms.TextBox();
                        this.EtiquetaFecha1 = new Lui.Forms.Label();
                        this.label1 = new Lui.Forms.Label();
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaCaja
                        // 
                        this.EntradaCaja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCaja.AutoTab = true;
                        this.EntradaCaja.CanCreate = false;
                        this.EntradaCaja.Filter = "estado=1";
                        this.EntradaCaja.Location = new System.Drawing.Point(136, 184);
                        this.EntradaCaja.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaCaja.MaxLength = 200;
                        this.EntradaCaja.Name = "EntradaCaja";
                        this.EntradaCaja.Required = true;
                        this.EntradaCaja.Size = new System.Drawing.Size(368, 24);
                        this.EntradaCaja.TabIndex = 5;
                        this.EntradaCaja.NombreTipo = "Lbl.Cajas.Caja";
                        this.EntradaCaja.Text = "0";
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(24, 184);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(112, 24);
                        this.Label3.TabIndex = 4;
                        this.Label3.Text = "Caja o cuenta";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCliente
                        // 
                        this.EntradaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCliente.AutoTab = true;
                        this.EntradaCliente.CanCreate = false;
                        this.EntradaCliente.Filter = "";
                        this.EntradaCliente.Location = new System.Drawing.Point(136, 120);
                        this.EntradaCliente.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaCliente.MaxLength = 200;
                        this.EntradaCliente.Name = "EntradaCliente";
                        this.EntradaCliente.Required = true;
                        this.EntradaCliente.Size = new System.Drawing.Size(368, 24);
                        this.EntradaCliente.TabIndex = 1;
                        this.EntradaCliente.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaCliente.Text = "0";
                        this.EntradaCliente.TextChanged += new System.EventHandler(this.EntradaCliente_TextChanged);
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(24, 120);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(112, 24);
                        this.Label5.TabIndex = 0;
                        this.Label5.Text = "Cliente";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaImporte
                        // 
                        this.EntradaImporte.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaImporte.Location = new System.Drawing.Point(136, 152);
                        this.EntradaImporte.Name = "EntradaImporte";
                        this.EntradaImporte.Prefijo = "$";
                        this.EntradaImporte.Size = new System.Drawing.Size(104, 24);
                        this.EntradaImporte.TabIndex = 3;
                        // 
                        // lblFecha1
                        // 
                        this.EtiquetaFecha1.Location = new System.Drawing.Point(24, 152);
                        this.EtiquetaFecha1.Name = "lblFecha1";
                        this.EtiquetaFecha1.Size = new System.Drawing.Size(112, 24);
                        this.EtiquetaFecha1.TabIndex = 2;
                        this.EtiquetaFecha1.Text = "Importe";
                        this.EtiquetaFecha1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label1
                        // 
                        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label1.AutoEllipsis = true;
                        this.label1.Location = new System.Drawing.Point(24, 64);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(480, 48);
                        this.label1.TabIndex = 101;
                        this.label1.Text = "Se va a confeccionar un recibo con un único pago en efectivo o depósito en caja o" +
    " cuenta seleccionada.";
                        this.label1.UseMnemonic = false;
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 24);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(236, 30);
                        this.EtiquetaTitulo.TabIndex = 108;
                        this.EtiquetaTitulo.Text = "Hacer un recibo rápido";
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // Rapido
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(529, 386);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.EntradaImporte);
                        this.Controls.Add(this.EntradaCaja);
                        this.Controls.Add(this.EntradaCliente);
                        this.Controls.Add(this.EtiquetaFecha1);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.Label5);
                        this.Name = "Rapido";
                        this.Text = "Recibo rápido";
                        this.Controls.SetChildIndex(this.Label5, 0);
                        this.Controls.SetChildIndex(this.Label3, 0);
                        this.Controls.SetChildIndex(this.EtiquetaFecha1, 0);
                        this.Controls.SetChildIndex(this.EntradaCliente, 0);
                        this.Controls.SetChildIndex(this.EntradaCaja, 0);
                        this.Controls.SetChildIndex(this.EntradaImporte, 0);
                        this.Controls.SetChildIndex(this.label1, 0);
                        this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

        }

        #endregion

        internal Lcc.Entrada.CodigoDetalle EntradaCaja;
        internal Lui.Forms.Label Label3;
        internal Lcc.Entrada.CodigoDetalle EntradaCliente;
        internal Lui.Forms.Label Label5;
        internal Lui.Forms.TextBox EntradaImporte;
        internal Lui.Forms.Label EtiquetaFecha1;
        private Lui.Forms.Label label1;
        private Lui.Forms.Label EtiquetaTitulo;
    }
}
