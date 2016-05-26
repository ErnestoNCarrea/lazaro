namespace Lcc.Edicion.Comprobantes
{
        partial class Pago
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
                        this.EntradaImporte = new Lui.Forms.TextBox();
                        this.label1 = new Lui.Forms.Label();
                        this.PanelImporte = new Lui.Forms.Panel();
                        this.PanelChequePropio = new Lui.Forms.Panel();
                        this.label2 = new Lui.Forms.Label();
                        this.EntradaFechaCobro = new Lui.Forms.TextBox();
                        this.label3 = new Lui.Forms.Label();
                        this.label6 = new Lui.Forms.Label();
                        this.EntradaFechaEmision = new Lui.Forms.TextBox();
                        this.EntradaNumeroCheque = new Lui.Forms.TextBox();
                        this.EtiquetaFecha1 = new Lui.Forms.Label();
                        this.EntradaBanco = new Lcc.Entrada.CodigoDetalle();
                        this.PanelTitulo = new Lui.Forms.Panel();
                        this.FrameTitulo = new Lui.Forms.Frame();
                        this.PanelCaja = new Lui.Forms.Panel();
                        this.label9 = new Lui.Forms.Label();
                        this.EntradaCaja = new Lcc.Entrada.CodigoDetalle();
                        this.PanelEfectivo = new Lui.Forms.Panel();
                        this.label8 = new Lui.Forms.Label();
                        this.PanelTarjeta = new Lui.Forms.Panel();
                        this.EntradaAutorizacion = new Lui.Forms.TextBox();
                        this.EntradaCupon = new Lui.Forms.TextBox();
                        this.EntradaInteres = new Lui.Forms.TextBox();
                        this.Label14 = new Lui.Forms.Label();
                        this.EntradaCuotas = new Lui.Forms.TextBox();
                        this.label4 = new Lui.Forms.Label();
                        this.EntradaPlan = new Lcc.Entrada.CodigoDetalle();
                        this.Label10 = new Lui.Forms.Label();
                        this.Label11 = new Lui.Forms.Label();
                        this.Label15 = new Lui.Forms.Label();
                        this.PanelObs = new Lui.Forms.Panel();
                        this.EntradaObs = new Lui.Forms.TextBox();
                        this.Label20 = new Lui.Forms.Label();
                        this.PanelCuentaCorriente = new Lui.Forms.Panel();
                        this.label7 = new Lui.Forms.Label();
                        this.PanelFormaDePago = new Lui.Forms.Panel();
                        this.EntradaFormaDePago = new Lcc.Entrada.CodigoDetalle();
                        this.label13 = new Lui.Forms.Label();
                        this.label12 = new Lui.Forms.Label();
                        this.PanelSeparadorInferior = new Lui.Forms.Panel();
                        this.PanelChequeTerceros = new Lui.Forms.Panel();
                        this.label5 = new Lui.Forms.Label();
                        this.EntradaChequeTerceros = new Lcc.Entrada.CodigoDetalle();
                        this.PanelValor = new Lui.Forms.Panel();
                        this.EtiquetaPagoConValor = new Lui.Forms.Label();
                        this.EntradaValor = new Lcc.Entrada.CodigoDetalle();
                        this.PanelImporte.SuspendLayout();
                        this.PanelChequePropio.SuspendLayout();
                        this.PanelTitulo.SuspendLayout();
                        this.PanelCaja.SuspendLayout();
                        this.PanelEfectivo.SuspendLayout();
                        this.PanelTarjeta.SuspendLayout();
                        this.PanelObs.SuspendLayout();
                        this.PanelCuentaCorriente.SuspendLayout();
                        this.PanelFormaDePago.SuspendLayout();
                        this.PanelChequeTerceros.SuspendLayout();
                        this.PanelValor.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // EntradaImporte
                        // 
                        this.EntradaImporte.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaImporte.Location = new System.Drawing.Point(140, 0);
                        this.EntradaImporte.Name = "EntradaImporte";
                        this.EntradaImporte.Prefijo = "$";
                        this.EntradaImporte.Size = new System.Drawing.Size(116, 24);
                        this.EntradaImporte.TabIndex = 1;
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(0, 0);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(136, 24);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "Importe";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // PanelImporte
                        // 
                        this.PanelImporte.Controls.Add(this.EntradaImporte);
                        this.PanelImporte.Controls.Add(this.label1);
                        this.PanelImporte.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelImporte.Location = new System.Drawing.Point(0, 66);
                        this.PanelImporte.Name = "PanelImporte";
                        this.PanelImporte.Size = new System.Drawing.Size(460, 30);
                        this.PanelImporte.TabIndex = 2;
                        // 
                        // PanelChequePropio
                        // 
                        this.PanelChequePropio.Controls.Add(this.label2);
                        this.PanelChequePropio.Controls.Add(this.EntradaFechaCobro);
                        this.PanelChequePropio.Controls.Add(this.label3);
                        this.PanelChequePropio.Controls.Add(this.label6);
                        this.PanelChequePropio.Controls.Add(this.EntradaFechaEmision);
                        this.PanelChequePropio.Controls.Add(this.EntradaNumeroCheque);
                        this.PanelChequePropio.Controls.Add(this.EtiquetaFecha1);
                        this.PanelChequePropio.Controls.Add(this.EntradaBanco);
                        this.PanelChequePropio.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelChequePropio.Location = new System.Drawing.Point(0, 128);
                        this.PanelChequePropio.Name = "PanelChequePropio";
                        this.PanelChequePropio.Size = new System.Drawing.Size(460, 134);
                        this.PanelChequePropio.TabIndex = 4;
                        this.PanelChequePropio.Visible = false;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(0, 0);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(136, 24);
                        this.label2.TabIndex = 0;
                        this.label2.Text = "Banco";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFechaCobro
                        // 
                        this.EntradaFechaCobro.DataType = Lui.Forms.DataTypes.Date;
                        this.EntradaFechaCobro.Location = new System.Drawing.Point(140, 96);
                        this.EntradaFechaCobro.Name = "EntradaFechaCobro";
                        this.EntradaFechaCobro.Size = new System.Drawing.Size(112, 24);
                        this.EntradaFechaCobro.TabIndex = 7;
                        this.EntradaFechaCobro.Enter += new System.EventHandler(this.EntradaFechaCobro_Enter);
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(0, 32);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(136, 24);
                        this.label3.TabIndex = 2;
                        this.label3.Text = "Número";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label6
                        // 
                        this.label6.Location = new System.Drawing.Point(0, 96);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(140, 24);
                        this.label6.TabIndex = 6;
                        this.label6.Text = "Fecha de cobro";
                        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFechaEmision
                        // 
                        this.EntradaFechaEmision.DataType = Lui.Forms.DataTypes.Date;
                        this.EntradaFechaEmision.Location = new System.Drawing.Point(140, 64);
                        this.EntradaFechaEmision.Name = "EntradaFechaEmision";
                        this.EntradaFechaEmision.Size = new System.Drawing.Size(112, 24);
                        this.EntradaFechaEmision.TabIndex = 5;
                        this.EntradaFechaEmision.Enter += new System.EventHandler(this.EntradaFechaEmision_Enter);
                        // 
                        // EntradaNumeroCheque
                        // 
                        this.EntradaNumeroCheque.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaNumeroCheque.Location = new System.Drawing.Point(140, 32);
                        this.EntradaNumeroCheque.Name = "EntradaNumeroCheque";
                        this.EntradaNumeroCheque.PlaceholderText = "Estado para esta chequera.";
                        this.EntradaNumeroCheque.Size = new System.Drawing.Size(176, 24);
                        this.EntradaNumeroCheque.TabIndex = 3;
                        this.EntradaNumeroCheque.Text = "0";
                        // 
                        // EtiquetaFecha1
                        // 
                        this.EtiquetaFecha1.Location = new System.Drawing.Point(0, 64);
                        this.EtiquetaFecha1.Name = "EtiquetaFecha1";
                        this.EtiquetaFecha1.Size = new System.Drawing.Size(140, 24);
                        this.EtiquetaFecha1.TabIndex = 4;
                        this.EtiquetaFecha1.Text = "Fecha de emisión";
                        this.EtiquetaFecha1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaBanco
                        // 
                        this.EntradaBanco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaBanco.AutoTab = true;
                        this.EntradaBanco.CanCreate = true;
                        this.EntradaBanco.Filter = "";
                        this.EntradaBanco.Location = new System.Drawing.Point(140, 0);
                        this.EntradaBanco.MaxLength = 200;
                        this.EntradaBanco.Name = "EntradaBanco";
                        this.EntradaBanco.NombreTipo = "Lbl.Bancos.Banco";
                        this.EntradaBanco.Required = true;
                        this.EntradaBanco.Size = new System.Drawing.Size(320, 24);
                        this.EntradaBanco.TabIndex = 1;
                        this.EntradaBanco.Text = "0";
                        // 
                        // PanelTitulo
                        // 
                        this.PanelTitulo.Controls.Add(this.FrameTitulo);
                        this.PanelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelTitulo.Location = new System.Drawing.Point(0, 32);
                        this.PanelTitulo.Name = "PanelTitulo";
                        this.PanelTitulo.Size = new System.Drawing.Size(460, 34);
                        this.PanelTitulo.TabIndex = 1;
                        // 
                        // FrameTitulo
                        // 
                        this.FrameTitulo.Dock = System.Windows.Forms.DockStyle.Top;
                        this.FrameTitulo.Location = new System.Drawing.Point(0, 0);
                        this.FrameTitulo.Name = "FrameTitulo";
                        this.FrameTitulo.Size = new System.Drawing.Size(460, 32);
                        this.FrameTitulo.TabIndex = 0;
                        this.FrameTitulo.Text = "Datos del pago";
                        // 
                        // PanelCaja
                        // 
                        this.PanelCaja.Controls.Add(this.label9);
                        this.PanelCaja.Controls.Add(this.EntradaCaja);
                        this.PanelCaja.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelCaja.Location = new System.Drawing.Point(0, 262);
                        this.PanelCaja.Name = "PanelCaja";
                        this.PanelCaja.Size = new System.Drawing.Size(460, 56);
                        this.PanelCaja.TabIndex = 5;
                        this.PanelCaja.Visible = false;
                        // 
                        // label9
                        // 
                        this.label9.Location = new System.Drawing.Point(0, 0);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(440, 20);
                        this.label9.TabIndex = 0;
                        this.label9.Text = "Pago mediante débito en la siguiente cuenta";
                        // 
                        // EntradaCaja
                        // 
                        this.EntradaCaja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCaja.AutoTab = true;
                        this.EntradaCaja.CanCreate = true;
                        this.EntradaCaja.Filter = "estado=1";
                        this.EntradaCaja.Location = new System.Drawing.Point(140, 20);
                        this.EntradaCaja.MaxLength = 200;
                        this.EntradaCaja.Name = "EntradaCaja";
                        this.EntradaCaja.NombreTipo = "Lbl.Cajas.Caja";
                        this.EntradaCaja.Required = true;
                        this.EntradaCaja.Size = new System.Drawing.Size(320, 24);
                        this.EntradaCaja.TabIndex = 1;
                        this.EntradaCaja.Text = "0";
                        // 
                        // PanelEfectivo
                        // 
                        this.PanelEfectivo.Controls.Add(this.label8);
                        this.PanelEfectivo.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelEfectivo.Location = new System.Drawing.Point(0, 318);
                        this.PanelEfectivo.Name = "PanelEfectivo";
                        this.PanelEfectivo.Size = new System.Drawing.Size(460, 32);
                        this.PanelEfectivo.TabIndex = 6;
                        this.PanelEfectivo.Visible = false;
                        // 
                        // label8
                        // 
                        this.label8.Location = new System.Drawing.Point(0, 0);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(456, 20);
                        this.label8.TabIndex = 0;
                        this.label8.Text = "Pago en efectivo, con débito de la caja diaria.";
                        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // PanelTarjeta
                        // 
                        this.PanelTarjeta.Controls.Add(this.EntradaAutorizacion);
                        this.PanelTarjeta.Controls.Add(this.EntradaCupon);
                        this.PanelTarjeta.Controls.Add(this.EntradaInteres);
                        this.PanelTarjeta.Controls.Add(this.Label14);
                        this.PanelTarjeta.Controls.Add(this.EntradaCuotas);
                        this.PanelTarjeta.Controls.Add(this.label4);
                        this.PanelTarjeta.Controls.Add(this.EntradaPlan);
                        this.PanelTarjeta.Controls.Add(this.Label10);
                        this.PanelTarjeta.Controls.Add(this.Label11);
                        this.PanelTarjeta.Controls.Add(this.Label15);
                        this.PanelTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelTarjeta.Location = new System.Drawing.Point(0, 350);
                        this.PanelTarjeta.Name = "PanelTarjeta";
                        this.PanelTarjeta.Size = new System.Drawing.Size(460, 130);
                        this.PanelTarjeta.TabIndex = 7;
                        this.PanelTarjeta.Visible = false;
                        // 
                        // EntradaAutorizacion
                        // 
                        this.EntradaAutorizacion.Location = new System.Drawing.Point(140, 100);
                        this.EntradaAutorizacion.Name = "EntradaAutorizacion";
                        this.EntradaAutorizacion.Size = new System.Drawing.Size(164, 24);
                        this.EntradaAutorizacion.TabIndex = 11;
                        // 
                        // EntradaCupon
                        // 
                        this.EntradaCupon.Location = new System.Drawing.Point(140, 68);
                        this.EntradaCupon.Name = "EntradaCupon";
                        this.EntradaCupon.Size = new System.Drawing.Size(164, 24);
                        this.EntradaCupon.TabIndex = 9;
                        // 
                        // EntradaInteres
                        // 
                        this.EntradaInteres.DataType = Lui.Forms.DataTypes.Float;
                        this.EntradaInteres.Location = new System.Drawing.Point(368, 60);
                        this.EntradaInteres.Name = "EntradaInteres";
                        this.EntradaInteres.Size = new System.Drawing.Size(80, 24);
                        this.EntradaInteres.Sufijo = "%";
                        this.EntradaInteres.TabIndex = 7;
                        this.EntradaInteres.TabStop = false;
                        this.EntradaInteres.Text = "0.0000";
                        // 
                        // Label14
                        // 
                        this.Label14.Location = new System.Drawing.Point(300, 28);
                        this.Label14.Name = "Label14";
                        this.Label14.Size = new System.Drawing.Size(68, 24);
                        this.Label14.TabIndex = 6;
                        this.Label14.Text = "Interés";
                        this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCuotas
                        // 
                        this.EntradaCuotas.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaCuotas.Location = new System.Drawing.Point(228, 28);
                        this.EntradaCuotas.Name = "EntradaCuotas";
                        this.EntradaCuotas.Size = new System.Drawing.Size(60, 24);
                        this.EntradaCuotas.TabIndex = 5;
                        this.EntradaCuotas.TabStop = false;
                        this.EntradaCuotas.Text = "0";
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(156, 28);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(72, 24);
                        this.label4.TabIndex = 4;
                        this.label4.Text = "Cuotas";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaPlan
                        // 
                        this.EntradaPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaPlan.AutoTab = true;
                        this.EntradaPlan.CanCreate = false;
                        this.EntradaPlan.Filter = "";
                        this.EntradaPlan.Location = new System.Drawing.Point(140, 0);
                        this.EntradaPlan.MaxLength = 200;
                        this.EntradaPlan.Name = "EntradaPlan";
                        this.EntradaPlan.NombreTipo = "Lbl.Pagos.Plan";
                        this.EntradaPlan.Required = false;
                        this.EntradaPlan.Size = new System.Drawing.Size(320, 24);
                        this.EntradaPlan.TabIndex = 3;
                        this.EntradaPlan.Text = "0";
                        this.EntradaPlan.TextChanged += new System.EventHandler(this.EntradaPlan_TextChanged);
                        // 
                        // Label10
                        // 
                        this.Label10.Location = new System.Drawing.Point(0, 100);
                        this.Label10.Name = "Label10";
                        this.Label10.Size = new System.Drawing.Size(136, 24);
                        this.Label10.TabIndex = 10;
                        this.Label10.Text = "Autorización";
                        this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label11
                        // 
                        this.Label11.Location = new System.Drawing.Point(0, 68);
                        this.Label11.Name = "Label11";
                        this.Label11.Size = new System.Drawing.Size(136, 24);
                        this.Label11.TabIndex = 8;
                        this.Label11.Text = "Número de Cupón";
                        this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label15
                        // 
                        this.Label15.Location = new System.Drawing.Point(0, 0);
                        this.Label15.Name = "Label15";
                        this.Label15.Size = new System.Drawing.Size(136, 24);
                        this.Label15.TabIndex = 2;
                        this.Label15.Text = "Plan";
                        this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // PanelObs
                        // 
                        this.PanelObs.Controls.Add(this.EntradaObs);
                        this.PanelObs.Controls.Add(this.Label20);
                        this.PanelObs.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelObs.Location = new System.Drawing.Point(0, 592);
                        this.PanelObs.Name = "PanelObs";
                        this.PanelObs.Size = new System.Drawing.Size(460, 58);
                        this.PanelObs.TabIndex = 8;
                        // 
                        // EntradaObs
                        // 
                        this.EntradaObs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaObs.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaObs.Location = new System.Drawing.Point(140, 0);
                        this.EntradaObs.Name = "EntradaObs";
                        this.EntradaObs.Size = new System.Drawing.Size(320, 52);
                        this.EntradaObs.TabIndex = 1;
                        // 
                        // Label20
                        // 
                        this.Label20.Location = new System.Drawing.Point(0, 0);
                        this.Label20.Name = "Label20";
                        this.Label20.Size = new System.Drawing.Size(136, 24);
                        this.Label20.TabIndex = 0;
                        this.Label20.Text = "Observaciones";
                        this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // PanelCuentaCorriente
                        // 
                        this.PanelCuentaCorriente.Controls.Add(this.label7);
                        this.PanelCuentaCorriente.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelCuentaCorriente.Location = new System.Drawing.Point(0, 96);
                        this.PanelCuentaCorriente.Name = "PanelCuentaCorriente";
                        this.PanelCuentaCorriente.Size = new System.Drawing.Size(460, 32);
                        this.PanelCuentaCorriente.TabIndex = 3;
                        this.PanelCuentaCorriente.Visible = false;
                        // 
                        // label7
                        // 
                        this.label7.Location = new System.Drawing.Point(0, 0);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(456, 20);
                        this.label7.TabIndex = 0;
                        this.label7.Text = "Se va a enviar saldo a la cuenta corriente del cliente.";
                        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // PanelFormaDePago
                        // 
                        this.PanelFormaDePago.Controls.Add(this.EntradaFormaDePago);
                        this.PanelFormaDePago.Controls.Add(this.label13);
                        this.PanelFormaDePago.Controls.Add(this.label12);
                        this.PanelFormaDePago.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelFormaDePago.Location = new System.Drawing.Point(0, 0);
                        this.PanelFormaDePago.Name = "PanelFormaDePago";
                        this.PanelFormaDePago.Size = new System.Drawing.Size(460, 32);
                        this.PanelFormaDePago.TabIndex = 0;
                        this.PanelFormaDePago.Visible = false;
                        // 
                        // EntradaFormaDePago
                        // 
                        this.EntradaFormaDePago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaFormaDePago.AutoTab = true;
                        this.EntradaFormaDePago.CanCreate = true;
                        this.EntradaFormaDePago.Filter = "pagos=1";
                        this.EntradaFormaDePago.Location = new System.Drawing.Point(136, 0);
                        this.EntradaFormaDePago.MaxLength = 200;
                        this.EntradaFormaDePago.Name = "EntradaFormaDePago";
                        this.EntradaFormaDePago.NombreTipo = "Lbl.Pagos.FormaDePago";
                        this.EntradaFormaDePago.Required = true;
                        this.EntradaFormaDePago.Size = new System.Drawing.Size(324, 24);
                        this.EntradaFormaDePago.TabIndex = 1;
                        this.EntradaFormaDePago.Text = "0";
                        this.EntradaFormaDePago.TextChanged += new System.EventHandler(this.EntradaFormaDePago_TextChanged);
                        // 
                        // label13
                        // 
                        this.label13.Location = new System.Drawing.Point(0, 32);
                        this.label13.Name = "label13";
                        this.label13.Size = new System.Drawing.Size(456, 20);
                        this.label13.TabIndex = 2;
                        this.label13.Text = "Cambie la forma de pago usando la tecla \"barra espaciadora\".";
                        this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // label12
                        // 
                        this.label12.Location = new System.Drawing.Point(0, 0);
                        this.label12.Name = "label12";
                        this.label12.Size = new System.Drawing.Size(136, 24);
                        this.label12.TabIndex = 0;
                        this.label12.Text = "Forma de pago";
                        this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // PanelSeparadorInferior
                        // 
                        this.PanelSeparadorInferior.BackColor = System.Drawing.SystemColors.ControlDark;
                        this.PanelSeparadorInferior.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelSeparadorInferior.Location = new System.Drawing.Point(0, 650);
                        this.PanelSeparadorInferior.Name = "PanelSeparadorInferior";
                        this.PanelSeparadorInferior.Size = new System.Drawing.Size(460, 2);
                        this.PanelSeparadorInferior.TabIndex = 10;
                        // 
                        // PanelChequeTerceros
                        // 
                        this.PanelChequeTerceros.Controls.Add(this.label5);
                        this.PanelChequeTerceros.Controls.Add(this.EntradaChequeTerceros);
                        this.PanelChequeTerceros.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelChequeTerceros.Location = new System.Drawing.Point(0, 480);
                        this.PanelChequeTerceros.Name = "PanelChequeTerceros";
                        this.PanelChequeTerceros.Size = new System.Drawing.Size(460, 56);
                        this.PanelChequeTerceros.TabIndex = 11;
                        this.PanelChequeTerceros.Visible = false;
                        // 
                        // label5
                        // 
                        this.label5.Location = new System.Drawing.Point(0, 0);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(440, 20);
                        this.label5.TabIndex = 0;
                        this.label5.Text = "Pago con cheque de terceros";
                        // 
                        // EntradaChequeTerceros
                        // 
                        this.EntradaChequeTerceros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaChequeTerceros.AutoTab = true;
                        this.EntradaChequeTerceros.CanCreate = true;
                        this.EntradaChequeTerceros.Filter = "emitido=0 AND estado=0";
                        this.EntradaChequeTerceros.Location = new System.Drawing.Point(140, 20);
                        this.EntradaChequeTerceros.MaxLength = 200;
                        this.EntradaChequeTerceros.Name = "EntradaChequeTerceros";
                        this.EntradaChequeTerceros.NombreTipo = "Lbl.Bancos.ChequeRecibido";
                        this.EntradaChequeTerceros.Required = true;
                        this.EntradaChequeTerceros.Size = new System.Drawing.Size(320, 24);
                        this.EntradaChequeTerceros.TabIndex = 1;
                        this.EntradaChequeTerceros.Text = "0";
                        this.EntradaChequeTerceros.TextChanged += new System.EventHandler(this.EntradaChequeTerceros_TextChanged);
                        // 
                        // PanelValor
                        // 
                        this.PanelValor.Controls.Add(this.EtiquetaPagoConValor);
                        this.PanelValor.Controls.Add(this.EntradaValor);
                        this.PanelValor.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelValor.Location = new System.Drawing.Point(0, 536);
                        this.PanelValor.Name = "PanelValor";
                        this.PanelValor.Size = new System.Drawing.Size(460, 56);
                        this.PanelValor.TabIndex = 12;
                        this.PanelValor.Visible = false;
                        // 
                        // EtiquetaPagoConValor
                        // 
                        this.EtiquetaPagoConValor.Location = new System.Drawing.Point(0, 0);
                        this.EtiquetaPagoConValor.Name = "EtiquetaPagoConValor";
                        this.EtiquetaPagoConValor.Size = new System.Drawing.Size(440, 20);
                        this.EtiquetaPagoConValor.TabIndex = 0;
                        this.EtiquetaPagoConValor.Text = "Pago con ...";
                        // 
                        // EntradaValor
                        // 
                        this.EntradaValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaValor.AutoTab = true;
                        this.EntradaValor.CanCreate = true;
                        this.EntradaValor.Filter = "estado=0";
                        this.EntradaValor.Location = new System.Drawing.Point(140, 20);
                        this.EntradaValor.MaxLength = 200;
                        this.EntradaValor.Name = "EntradaValor";
                        this.EntradaValor.NombreTipo = "Lbl.Pagos.Valor";
                        this.EntradaValor.Required = true;
                        this.EntradaValor.Size = new System.Drawing.Size(320, 24);
                        this.EntradaValor.TabIndex = 1;
                        this.EntradaValor.Text = "0";
                        this.EntradaValor.TextChanged += new System.EventHandler(this.EntradaValor_TextChanged);
                        // 
                        // Pago
                        // 
                        this.Controls.Add(this.PanelSeparadorInferior);
                        this.Controls.Add(this.PanelObs);
                        this.Controls.Add(this.PanelValor);
                        this.Controls.Add(this.PanelChequeTerceros);
                        this.Controls.Add(this.PanelTarjeta);
                        this.Controls.Add(this.PanelEfectivo);
                        this.Controls.Add(this.PanelCaja);
                        this.Controls.Add(this.PanelChequePropio);
                        this.Controls.Add(this.PanelCuentaCorriente);
                        this.Controls.Add(this.PanelImporte);
                        this.Controls.Add(this.PanelTitulo);
                        this.Controls.Add(this.PanelFormaDePago);
                        this.Name = "Pago";
                        this.Size = new System.Drawing.Size(460, 697);
                        this.PanelImporte.ResumeLayout(false);
                        this.PanelChequePropio.ResumeLayout(false);
                        this.PanelTitulo.ResumeLayout(false);
                        this.PanelCaja.ResumeLayout(false);
                        this.PanelEfectivo.ResumeLayout(false);
                        this.PanelTarjeta.ResumeLayout(false);
                        this.PanelObs.ResumeLayout(false);
                        this.PanelCuentaCorriente.ResumeLayout(false);
                        this.PanelFormaDePago.ResumeLayout(false);
                        this.PanelChequeTerceros.ResumeLayout(false);
                        this.PanelValor.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                internal Lui.Forms.TextBox EntradaImporte;
                private Lui.Forms.Label label1;
                private Lui.Forms.Panel PanelImporte;
                private Lui.Forms.Panel PanelChequePropio;
                private Lui.Forms.Label label2;
                internal Lui.Forms.TextBox EntradaFechaCobro;
                private Lui.Forms.Label label3;
                internal Lui.Forms.Label label6;
                public Lui.Forms.TextBox EntradaFechaEmision;
                internal Lui.Forms.TextBox EntradaNumeroCheque;
                internal Lui.Forms.Label EtiquetaFecha1;
                private Lui.Forms.Panel PanelTitulo;
                private Lui.Forms.Frame FrameTitulo;
                private Lui.Forms.Panel PanelCaja;
                private Lui.Forms.Panel PanelEfectivo;
                private Lui.Forms.Label label8;
                private Lui.Forms.Panel PanelTarjeta;
                public Lui.Forms.TextBox EntradaAutorizacion;
                public Lui.Forms.TextBox EntradaCupon;
                public Lui.Forms.TextBox EntradaInteres;
                internal Lui.Forms.Label Label14;
                public Lui.Forms.TextBox EntradaCuotas;
                internal Lui.Forms.Label label4;
                public Lcc.Entrada.CodigoDetalle EntradaPlan;
                internal Lui.Forms.Label Label10;
                internal Lui.Forms.Label Label11;
                internal Lui.Forms.Label Label15;
                private Lui.Forms.Panel PanelObs;
                private Lui.Forms.Label label9;
                public Lui.Forms.TextBox EntradaObs;
                internal Lui.Forms.Label Label20;
                private Lui.Forms.Panel PanelCuentaCorriente;
                private Lui.Forms.Label label7;
                private Lui.Forms.Panel PanelFormaDePago;
                private Lui.Forms.Label label13;
                private Lui.Forms.Label label12;
                private Lui.Forms.Panel PanelSeparadorInferior;
                public Lcc.Entrada.CodigoDetalle EntradaCaja;
                public Lcc.Entrada.CodigoDetalle EntradaBanco;
                internal Lcc.Entrada.CodigoDetalle EntradaFormaDePago;
                private Lui.Forms.Panel PanelChequeTerceros;
                private Lui.Forms.Label label5;
                public Lcc.Entrada.CodigoDetalle EntradaChequeTerceros;
                private Lui.Forms.Panel PanelValor;
                private Lui.Forms.Label EtiquetaPagoConValor;
                public Lcc.Entrada.CodigoDetalle EntradaValor;
        }
}
