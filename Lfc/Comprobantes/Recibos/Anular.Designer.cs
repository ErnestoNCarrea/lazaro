namespace Lfc.Comprobantes.Recibos
{
        partial class Anular
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anular));
                        this.Label7 = new Lui.Forms.Label();
                        this.EntradaPV = new Lui.Forms.TextBox();
                        this.EntradaNumero = new Lui.Forms.TextBox();
                        this.Label2 = new Lui.Forms.Label();
                        this.EntradaTipo = new Lui.Forms.ComboBox();
                        this.Label1 = new Lui.Forms.Label();
                        this.EtiquetaAviso = new Lui.Forms.Label();
                        this.EntradaCliente = new Lui.Forms.TextBox();
                        this.Label4 = new Lui.Forms.Label();
                        this.EntradaImporte = new Lui.Forms.TextBox();
                        this.Label5 = new Lui.Forms.Label();
                        this.EntradaFecha = new Lui.Forms.TextBox();
                        this.Label3 = new Lui.Forms.Label();
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.label6 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // Label7
                        // 
                        this.Label7.Location = new System.Drawing.Point(168, 168);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(16, 24);
                        this.Label7.TabIndex = 4;
                        this.Label7.Text = "-";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // EntradaPV
                        // 
                        this.EntradaPV.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaPV.Location = new System.Drawing.Point(120, 168);
                        this.EntradaPV.Name = "EntradaPV";
                        this.EntradaPV.Size = new System.Drawing.Size(48, 24);
                        this.EntradaPV.TabIndex = 3;
                        this.EntradaPV.Text = "1";
                        this.EntradaPV.TextChanged += new System.EventHandler(this.EntradaNumeroTipoPV);
                        // 
                        // EntradaNumero
                        // 
                        this.EntradaNumero.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaNumero.Location = new System.Drawing.Point(184, 168);
                        this.EntradaNumero.Name = "EntradaNumero";
                        this.EntradaNumero.Size = new System.Drawing.Size(100, 24);
                        this.EntradaNumero.TabIndex = 5;
                        this.EntradaNumero.Text = "0";
                        this.EntradaNumero.TextChanged += new System.EventHandler(this.EntradaNumeroTipoPV);
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(24, 168);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(96, 24);
                        this.Label2.TabIndex = 2;
                        this.Label2.Text = "Número";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaTipo
                        // 
                        this.EntradaTipo.AlwaysExpanded = true;
                        this.EntradaTipo.AutoSize = true;
                        this.EntradaTipo.Location = new System.Drawing.Point(120, 120);
                        this.EntradaTipo.Name = "EntradaTipo";
                        this.EntradaTipo.SetData = new string[] {
        "De Pago|RCP",
        "De Cobro|RC"};
                        this.EntradaTipo.Size = new System.Drawing.Size(164, 39);
                        this.EntradaTipo.TabIndex = 1;
                        this.EntradaTipo.TextKey = "RC";
                        this.EntradaTipo.TextChanged += new System.EventHandler(this.EntradaNumeroTipoPV);
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(24, 120);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(96, 24);
                        this.Label1.TabIndex = 0;
                        this.Label1.Text = "Tipo";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EtiquetaAviso
                        // 
                        this.EtiquetaAviso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaAviso.Location = new System.Drawing.Point(120, 304);
                        this.EtiquetaAviso.Name = "EtiquetaAviso";
                        this.EtiquetaAviso.Size = new System.Drawing.Size(488, 56);
                        this.EtiquetaAviso.TabIndex = 12;
                        // 
                        // EntradaCliente
                        // 
                        this.EntradaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCliente.Location = new System.Drawing.Point(120, 272);
                        this.EntradaCliente.Name = "EntradaCliente";
                        this.EntradaCliente.Size = new System.Drawing.Size(488, 24);
                        this.EntradaCliente.TabIndex = 11;
                        this.EntradaCliente.TabStop = false;
                        // 
                        // Label4
                        // 
                        this.Label4.Location = new System.Drawing.Point(24, 272);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(96, 24);
                        this.Label4.TabIndex = 10;
                        this.Label4.Text = "Cliente";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaImporte
                        // 
                        this.EntradaImporte.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaImporte.Location = new System.Drawing.Point(120, 240);
                        this.EntradaImporte.Name = "EntradaImporte";
                        this.EntradaImporte.Prefijo = "$";
                        this.EntradaImporte.Size = new System.Drawing.Size(116, 24);
                        this.EntradaImporte.TabIndex = 9;
                        this.EntradaImporte.TabStop = false;
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(24, 240);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(96, 24);
                        this.Label5.TabIndex = 8;
                        this.Label5.Text = "Importe";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFecha
                        // 
                        this.EntradaFecha.Location = new System.Drawing.Point(120, 204);
                        this.EntradaFecha.Name = "EntradaFecha";
                        this.EntradaFecha.Size = new System.Drawing.Size(116, 24);
                        this.EntradaFecha.TabIndex = 7;
                        this.EntradaFecha.TabStop = false;
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(24, 204);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(96, 24);
                        this.Label3.TabIndex = 6;
                        this.Label3.Text = "Fecha";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 24);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(172, 30);
                        this.EtiquetaTitulo.TabIndex = 110;
                        this.EtiquetaTitulo.Text = "Anular un recibo";
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // label6
                        // 
                        this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label6.AutoEllipsis = true;
                        this.label6.Location = new System.Drawing.Point(24, 64);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(584, 56);
                        this.label6.TabIndex = 109;
                        this.label6.Text = resources.GetString("label6.Text");
                        this.label6.UseMnemonic = false;
                        // 
                        // Anular
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(634, 435);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Controls.Add(this.EtiquetaAviso);
                        this.Controls.Add(this.EntradaCliente);
                        this.Controls.Add(this.EntradaImporte);
                        this.Controls.Add(this.EntradaFecha);
                        this.Controls.Add(this.Label7);
                        this.Controls.Add(this.EntradaPV);
                        this.Controls.Add(this.EntradaNumero);
                        this.Controls.Add(this.EntradaTipo);
                        this.Controls.Add(this.Label4);
                        this.Controls.Add(this.Label5);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.label6);
                        this.Name = "Anular";
                        this.Text = "Anular recibo";
                        this.Controls.SetChildIndex(this.label6, 0);
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.Label2, 0);
                        this.Controls.SetChildIndex(this.Label3, 0);
                        this.Controls.SetChildIndex(this.Label5, 0);
                        this.Controls.SetChildIndex(this.Label4, 0);
                        this.Controls.SetChildIndex(this.EntradaTipo, 0);
                        this.Controls.SetChildIndex(this.EntradaNumero, 0);
                        this.Controls.SetChildIndex(this.EntradaPV, 0);
                        this.Controls.SetChildIndex(this.Label7, 0);
                        this.Controls.SetChildIndex(this.EntradaFecha, 0);
                        this.Controls.SetChildIndex(this.EntradaImporte, 0);
                        this.Controls.SetChildIndex(this.EntradaCliente, 0);
                        this.Controls.SetChildIndex(this.EtiquetaAviso, 0);
                        this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                internal Lui.Forms.Label Label7;
                internal Lui.Forms.TextBox EntradaPV;
                internal Lui.Forms.TextBox EntradaNumero;
                internal Lui.Forms.Label Label2;
                public Lui.Forms.ComboBox EntradaTipo;
                internal Lui.Forms.Label Label1;
                internal Lui.Forms.Label EtiquetaAviso;
                internal Lui.Forms.TextBox EntradaCliente;
                internal Lui.Forms.Label Label4;
                internal Lui.Forms.TextBox EntradaImporte;
                internal Lui.Forms.Label Label5;
                internal Lui.Forms.TextBox EntradaFecha;
                internal Lui.Forms.Label Label3;
                private Lui.Forms.Label EtiquetaTitulo;
                private Lui.Forms.Label label6;
        }
}
