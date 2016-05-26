namespace Lcc.Edicion.Comprobantes
{
        partial class Cobro
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
                        this.PanelChequeTerceros = new Lui.Forms.Panel();
                        this.EntradaEmisor = new Lui.Forms.TextBox();
                        this.EntradaFechaCobro = new Lui.Forms.TextBox();
                        this.EntradaFechaEmision = new Lui.Forms.TextBox();
                        this.EntradaNumeroCheque = new Lui.Forms.TextBox();
                        this.EntradaBanco = new Lcc.Entrada.CodigoDetalle();
                        this.label2 = new Lui.Forms.Label();
                        this.label3 = new Lui.Forms.Label();
                        this.label6 = new Lui.Forms.Label();
                        this.lblFecha1 = new Lui.Forms.Label();
                        this.label5 = new Lui.Forms.Label();
                        this.PanelTitulo = new Lui.Forms.Panel();
                        this.FrameTitulo = new Lui.Forms.Frame();
                        this.PanelCaja = new Lui.Forms.Panel();
                        this.EntradaCaja = new Lcc.Entrada.CodigoDetalle();
                        this.label9 = new Lui.Forms.Label();
                        this.PanelEfectivo = new Lui.Forms.Panel();
                        this.label8 = new Lui.Forms.Label();
                        this.PanelTarjeta = new Lui.Forms.Panel();
                        this.EntradaCupon = new Lui.Forms.TextBox();
                        this.EntradaInteres = new Lui.Forms.TextBox();
                        this.Label14 = new Lui.Forms.Label();
                        this.EntradaCuotas = new Lui.Forms.TextBox();
                        this.label4 = new Lui.Forms.Label();
                        this.EntradaPlan = new Lcc.Entrada.CodigoDetalle();
                        this.Label11 = new Lui.Forms.Label();
                        this.Label15 = new Lui.Forms.Label();
                        this.PanelObs = new Lui.Forms.Panel();
                        this.EntradaObs = new Lui.Forms.TextBox();
                        this.Label20 = new Lui.Forms.Label();
                        this.PanelCuentaCorriente = new Lui.Forms.Panel();
                        this.label7 = new Lui.Forms.Label();
                        this.PanelFormaDePago = new Lui.Forms.Panel();
                        this.EntradaFormaDePago = new Lcc.Entrada.CodigoDetalle();
                        this.AyudaFormaDePago = new Lui.Forms.Label();
                        this.label12 = new Lui.Forms.Label();
                        this.PanelSeparadorInferior = new Lui.Forms.Panel();
                        this.PanelValor = new Lui.Forms.Panel();
                        this.EntradaValorNumero = new Lui.Forms.TextBox();
                        this.label16 = new Lui.Forms.Label();
                        this.PanelImporte.SuspendLayout();
                        this.PanelChequeTerceros.SuspendLayout();
                        this.PanelTitulo.SuspendLayout();
                        this.PanelCaja.SuspendLayout();
                        this.PanelEfectivo.SuspendLayout();
                        this.PanelTarjeta.SuspendLayout();
                        this.PanelObs.SuspendLayout();
                        this.PanelCuentaCorriente.SuspendLayout();
                        this.PanelFormaDePago.SuspendLayout();
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
                        // PanelChequeTerceros
                        // 
                        this.PanelChequeTerceros.Controls.Add(this.EntradaEmisor);
                        this.PanelChequeTerceros.Controls.Add(this.EntradaFechaCobro);
                        this.PanelChequeTerceros.Controls.Add(this.EntradaFechaEmision);
                        this.PanelChequeTerceros.Controls.Add(this.EntradaNumeroCheque);
                        this.PanelChequeTerceros.Controls.Add(this.EntradaBanco);
                        this.PanelChequeTerceros.Controls.Add(this.label2);
                        this.PanelChequeTerceros.Controls.Add(this.label3);
                        this.PanelChequeTerceros.Controls.Add(this.label6);
                        this.PanelChequeTerceros.Controls.Add(this.lblFecha1);
                        this.PanelChequeTerceros.Controls.Add(this.label5);
                        this.PanelChequeTerceros.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelChequeTerceros.Location = new System.Drawing.Point(0, 128);
                        this.PanelChequeTerceros.Name = "PanelChequeTerceros";
                        this.PanelChequeTerceros.Size = new System.Drawing.Size(460, 166);
                        this.PanelChequeTerceros.TabIndex = 4;
                        this.PanelChequeTerceros.Visible = false;
                        // 
                        // EntradaEmisor
                        // 
                        this.EntradaEmisor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaEmisor.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaEmisor.Location = new System.Drawing.Point(140, 0);
                        this.EntradaEmisor.Name = "EntradaEmisor";
                        this.EntradaEmisor.Size = new System.Drawing.Size(320, 24);
                        this.EntradaEmisor.TabIndex = 1;
                        // 
                        // EntradaFechaCobro
                        // 
                        this.EntradaFechaCobro.DataType = Lui.Forms.DataTypes.Date;
                        this.EntradaFechaCobro.Location = new System.Drawing.Point(140, 128);
                        this.EntradaFechaCobro.Name = "EntradaFechaCobro";
                        this.EntradaFechaCobro.Size = new System.Drawing.Size(112, 24);
                        this.EntradaFechaCobro.TabIndex = 9;
                        this.EntradaFechaCobro.Enter += new System.EventHandler(this.EntradaFechaCobro_Enter);
                        // 
                        // EntradaFechaEmision
                        // 
                        this.EntradaFechaEmision.DataType = Lui.Forms.DataTypes.Date;
                        this.EntradaFechaEmision.Location = new System.Drawing.Point(140, 96);
                        this.EntradaFechaEmision.Name = "EntradaFechaEmision";
                        this.EntradaFechaEmision.Size = new System.Drawing.Size(112, 24);
                        this.EntradaFechaEmision.TabIndex = 7;
                        // 
                        // EntradaNumeroCheque
                        // 
                        this.EntradaNumeroCheque.AutoSize = false;
                        this.EntradaNumeroCheque.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaNumeroCheque.Location = new System.Drawing.Point(140, 64);
                        this.EntradaNumeroCheque.Name = "EntradaNumeroCheque";
                        this.EntradaNumeroCheque.Size = new System.Drawing.Size(184, 24);
                        this.EntradaNumeroCheque.TabIndex = 5;
                        this.EntradaNumeroCheque.Text = "0";
                        this.EntradaNumeroCheque.PlaceholderText = "Estado para esta chequera.";
                        // 
                        // EntradaBanco
                        // 
                        this.EntradaBanco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaBanco.CanCreate = true;
                        this.EntradaBanco.Filter = "";
                        this.EntradaBanco.Location = new System.Drawing.Point(140, 32);
                        this.EntradaBanco.MaxLength = 200;
                        this.EntradaBanco.Name = "EntradaBanco";
                        this.EntradaBanco.Required = true;
                        this.EntradaBanco.Size = new System.Drawing.Size(320, 24);
                        this.EntradaBanco.TabIndex = 3;
                        this.EntradaBanco.NombreTipo = "Lbl.Bancos.Banco";
                        this.EntradaBanco.TeclaDespuesDeEnter = "{tab}";
                        this.EntradaBanco.Text = "0";
                        this.EntradaBanco.ValueInt = 0;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(0, 32);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(140, 24);
                        this.label2.TabIndex = 2;
                        this.label2.Text = "Banco";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(0, 64);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(140, 24);
                        this.label3.TabIndex = 4;
                        this.label3.Text = "Número";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label6
                        // 
                        this.label6.Location = new System.Drawing.Point(0, 128);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(140, 24);
                        this.label6.TabIndex = 8;
                        this.label6.Text = "Fecha de cobro";
                        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // lblFecha1
                        // 
                        this.lblFecha1.Location = new System.Drawing.Point(0, 96);
                        this.lblFecha1.Name = "lblFecha1";
                        this.lblFecha1.Size = new System.Drawing.Size(140, 24);
                        this.lblFecha1.TabIndex = 6;
                        this.lblFecha1.Text = "Fecha de emisión";
                        this.lblFecha1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label5
                        // 
                        this.label5.Location = new System.Drawing.Point(0, 0);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(140, 24);
                        this.label5.TabIndex = 0;
                        this.label5.Text = "Librador";
                        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
                        this.FrameTitulo.TabStop = false;
                        this.FrameTitulo.Text = "frame1";
                        // 
                        // PanelCaja
                        // 
                        this.PanelCaja.Controls.Add(this.EntradaCaja);
                        this.PanelCaja.Controls.Add(this.label9);
                        this.PanelCaja.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelCaja.Location = new System.Drawing.Point(0, 294);
                        this.PanelCaja.Name = "PanelCaja";
                        this.PanelCaja.Size = new System.Drawing.Size(460, 56);
                        this.PanelCaja.TabIndex = 5;
                        this.PanelCaja.Visible = false;
                        // 
                        // EntradaCaja
                        // 
                        this.EntradaCaja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCaja.CanCreate = true;
                        this.EntradaCaja.Filter = "estado=1";
                        this.EntradaCaja.Location = new System.Drawing.Point(140, 20);
                        this.EntradaCaja.MaxLength = 200;
                        this.EntradaCaja.Name = "EntradaCaja";
                        this.EntradaCaja.Required = true;
                        this.EntradaCaja.Size = new System.Drawing.Size(320, 24);
                        this.EntradaCaja.TabIndex = 1;
                        this.EntradaCaja.NombreTipo = "Lbl.Cajas.Caja";
                        this.EntradaCaja.TeclaDespuesDeEnter = "{tab}";
                        this.EntradaCaja.Text = "0";
                        this.EntradaCaja.ValueInt = 0;
                        // 
                        // label9
                        // 
                        this.label9.Location = new System.Drawing.Point(0, 0);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(440, 20);
                        this.label9.TabIndex = 0;
                        this.label9.Text = "Cobro mediante acreditación en la siguiente cuenta";
                        // 
                        // PanelEfectivo
                        // 
                        this.PanelEfectivo.Controls.Add(this.label8);
                        this.PanelEfectivo.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelEfectivo.Location = new System.Drawing.Point(0, 350);
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
                        this.label8.Text = "Cobro en efectivo, con acreditación en la caja diaria.";
                        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // PanelTarjeta
                        // 
                        this.PanelTarjeta.Controls.Add(this.EntradaCupon);
                        this.PanelTarjeta.Controls.Add(this.EntradaInteres);
                        this.PanelTarjeta.Controls.Add(this.Label14);
                        this.PanelTarjeta.Controls.Add(this.EntradaCuotas);
                        this.PanelTarjeta.Controls.Add(this.label4);
                        this.PanelTarjeta.Controls.Add(this.EntradaPlan);
                        this.PanelTarjeta.Controls.Add(this.Label11);
                        this.PanelTarjeta.Controls.Add(this.Label15);
                        this.PanelTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelTarjeta.Location = new System.Drawing.Point(0, 382);
                        this.PanelTarjeta.Name = "PanelTarjeta";
                        this.PanelTarjeta.Size = new System.Drawing.Size(460, 98);
                        this.PanelTarjeta.TabIndex = 7;
                        this.PanelTarjeta.Visible = false;
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
                        this.EntradaInteres.Location = new System.Drawing.Point(368, 28);
                        this.EntradaInteres.Name = "EntradaInteres";
                        this.EntradaInteres.TemporaryReadOnly = true;
                        this.EntradaInteres.Size = new System.Drawing.Size(80, 24);
                        this.EntradaInteres.Sufijo = "%";
                        this.EntradaInteres.TabIndex = 7;
                        this.EntradaInteres.TabStop = false;
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
                        this.EntradaCuotas.TemporaryReadOnly = true;
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
                        this.EntradaPlan.CanCreate = false;
                        this.EntradaPlan.Filter = "";
                        this.EntradaPlan.Location = new System.Drawing.Point(140, 0);
                        this.EntradaPlan.MaxLength = 200;
                        this.EntradaPlan.Name = "EntradaPlan";
                        this.EntradaPlan.Required = false;
                        this.EntradaPlan.Size = new System.Drawing.Size(320, 24);
                        this.EntradaPlan.TabIndex = 3;
                        this.EntradaPlan.NombreTipo = "Lbl.Pagos.Plan";
                        this.EntradaPlan.TeclaDespuesDeEnter = "{tab}";
                        this.EntradaPlan.Text = "0";
                        this.EntradaPlan.ValueInt = 0;
                        this.EntradaPlan.TextChanged += new System.EventHandler(this.EntradaPlan_TextChanged);
                        // 
                        // Label11
                        // 
                        this.Label11.Location = new System.Drawing.Point(0, 68);
                        this.Label11.Name = "Label11";
                        this.Label11.Size = new System.Drawing.Size(136, 24);
                        this.Label11.TabIndex = 8;
                        this.Label11.Text = "Número de cupón";
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
                        this.PanelObs.Location = new System.Drawing.Point(0, 512);
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
                        this.EntradaObs.MultiLine = true;
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
                        this.PanelFormaDePago.Controls.Add(this.AyudaFormaDePago);
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
                        this.EntradaFormaDePago.CanCreate = true;
                        this.EntradaFormaDePago.Filter = "cobros=1";
                        this.EntradaFormaDePago.Location = new System.Drawing.Point(136, 0);
                        this.EntradaFormaDePago.MaxLength = 200;
                        this.EntradaFormaDePago.Name = "EntradaFormaDePago";
                        this.EntradaFormaDePago.Required = true;
                        this.EntradaFormaDePago.Size = new System.Drawing.Size(324, 24);
                        this.EntradaFormaDePago.TabIndex = 1;
                        this.EntradaFormaDePago.NombreTipo = "Lbl.Pagos.FormaDePago";
                        this.EntradaFormaDePago.TeclaDespuesDeEnter = "{tab}";
                        this.EntradaFormaDePago.Text = "0";
                        this.EntradaFormaDePago.ValueInt = 0;
                        this.EntradaFormaDePago.TextChanged += new System.EventHandler(this.EntradaFormaDePago_TextChanged);
                        // 
                        // AyudaFormaDePago
                        // 
                        this.AyudaFormaDePago.Location = new System.Drawing.Point(0, 32);
                        this.AyudaFormaDePago.Name = "AyudaFormaDePago";
                        this.AyudaFormaDePago.Size = new System.Drawing.Size(456, 20);
                        this.AyudaFormaDePago.TabIndex = 2;
                        this.AyudaFormaDePago.Text = "Cambie la forma de pago usando la tecla \"barra espaciadora\".";
                        this.AyudaFormaDePago.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.AyudaFormaDePago.VisibleChanged += new System.EventHandler(this.FormaDePago_SizeChanged);
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
                        this.PanelSeparadorInferior.Location = new System.Drawing.Point(0, 570);
                        this.PanelSeparadorInferior.Name = "PanelSeparadorInferior";
                        this.PanelSeparadorInferior.Size = new System.Drawing.Size(460, 2);
                        this.PanelSeparadorInferior.TabIndex = 9;
                        // 
                        // PanelValor
                        // 
                        this.PanelValor.Controls.Add(this.EntradaValorNumero);
                        this.PanelValor.Controls.Add(this.label16);
                        this.PanelValor.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelValor.Location = new System.Drawing.Point(0, 480);
                        this.PanelValor.Name = "PanelValor";
                        this.PanelValor.Size = new System.Drawing.Size(460, 32);
                        this.PanelValor.TabIndex = 10;
                        this.PanelValor.Visible = false;
                        // 
                        // EntradaValorNumero
                        // 
                        this.EntradaValorNumero.Location = new System.Drawing.Point(140, 0);
                        this.EntradaValorNumero.Name = "EntradaValorNumero";
                        this.EntradaValorNumero.Size = new System.Drawing.Size(284, 24);
                        this.EntradaValorNumero.TabIndex = 11;
                        // 
                        // label16
                        // 
                        this.label16.Location = new System.Drawing.Point(0, 0);
                        this.label16.Name = "label16";
                        this.label16.Size = new System.Drawing.Size(136, 24);
                        this.label16.TabIndex = 10;
                        this.label16.Text = "Número";
                        this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Cobro
                        // 
                        this.Controls.Add(this.PanelSeparadorInferior);
                        this.Controls.Add(this.PanelObs);
                        this.Controls.Add(this.PanelValor);
                        this.Controls.Add(this.PanelTarjeta);
                        this.Controls.Add(this.PanelEfectivo);
                        this.Controls.Add(this.PanelCaja);
                        this.Controls.Add(this.PanelChequeTerceros);
                        this.Controls.Add(this.PanelCuentaCorriente);
                        this.Controls.Add(this.PanelImporte);
                        this.Controls.Add(this.PanelTitulo);
                        this.Controls.Add(this.PanelFormaDePago);
                        this.Name = "Cobro";
                        this.Size = new System.Drawing.Size(460, 629);
                        this.PanelImporte.ResumeLayout(false);
                        this.PanelChequeTerceros.ResumeLayout(false);
                        this.PanelTitulo.ResumeLayout(false);
                        this.PanelCaja.ResumeLayout(false);
                        this.PanelEfectivo.ResumeLayout(false);
                        this.PanelTarjeta.ResumeLayout(false);
                        this.PanelObs.ResumeLayout(false);
                        this.PanelCuentaCorriente.ResumeLayout(false);
                        this.PanelFormaDePago.ResumeLayout(false);
                        this.PanelValor.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                internal Lui.Forms.TextBox EntradaImporte;
                private Lui.Forms.Label label1;
                private Lui.Forms.Panel PanelImporte;
                private Lui.Forms.Panel PanelChequeTerceros;
                private Lui.Forms.Label label2;
                internal Lui.Forms.TextBox EntradaFechaCobro;
                private Lui.Forms.Label label3;
                internal Lui.Forms.Label label6;
                internal Lui.Forms.TextBox EntradaFechaEmision;
                internal Lui.Forms.TextBox EntradaNumeroCheque;
                internal Lui.Forms.Label lblFecha1;
                internal Lcc.Entrada.CodigoDetalle EntradaBanco;
                private Lui.Forms.Label label5;
                private Lui.Forms.Panel PanelTitulo;
                private Lui.Forms.Frame FrameTitulo;
                private Lui.Forms.Panel PanelCaja;
                public Lcc.Entrada.CodigoDetalle EntradaCaja;
                private Lui.Forms.Panel PanelEfectivo;
                private Lui.Forms.Label label8;
                private Lui.Forms.Panel PanelTarjeta;
                public Lui.Forms.TextBox EntradaCupon;
                public Lui.Forms.TextBox EntradaInteres;
                internal Lui.Forms.Label Label14;
                public Lui.Forms.TextBox EntradaCuotas;
                internal Lui.Forms.Label label4;
                public Lcc.Entrada.CodigoDetalle EntradaPlan;
                internal Lui.Forms.Label Label11;
                internal Lui.Forms.Label Label15;
                private Lui.Forms.Panel PanelObs;
                private Lui.Forms.Label label9;
                public Lui.Forms.TextBox EntradaObs;
                internal Lui.Forms.Label Label20;
                private Lui.Forms.Panel PanelCuentaCorriente;
                private Lui.Forms.Label label7;
                internal Lui.Forms.TextBox EntradaEmisor;
                private Lui.Forms.Panel PanelFormaDePago;
                private Lui.Forms.Label AyudaFormaDePago;
                private Lui.Forms.Label label12;
                private Lui.Forms.Panel PanelSeparadorInferior;
                internal Lcc.Entrada.CodigoDetalle EntradaFormaDePago;
                private Lui.Forms.Panel PanelValor;
                public Lui.Forms.TextBox EntradaValorNumero;
                internal Lui.Forms.Label label16;
        }
}
