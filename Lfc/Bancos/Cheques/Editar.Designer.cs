namespace Lfc.Bancos.Cheques
{
        partial class Editar
        {
                private System.ComponentModel.IContainer components = null;

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
                        this.EntradaEmisor = new Lui.Forms.TextBox();
                        this.EntradaNumero = new Lui.Forms.TextBox();
                        this.EntradaBanco = new Lcc.Entrada.CodigoDetalle();
                        this.label5 = new Lui.Forms.Label();
                        this.Label3 = new Lui.Forms.Label();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaFechaCobro = new Lui.Forms.TextBox();
                        this.label2 = new Lui.Forms.Label();
                        this.EntradaFechaEmision = new Lui.Forms.TextBox();
                        this.EtiquetaFecha1 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaEmisor
                        // 
                        this.EntradaEmisor.Location = new System.Drawing.Point(140, 0);
                        this.EntradaEmisor.Name = "EntradaEmisor";
                        this.EntradaEmisor.PlaceholderText = "";
                        this.EntradaEmisor.ReadOnly = false;
                        this.EntradaEmisor.Size = new System.Drawing.Size(460, 24);
                        this.EntradaEmisor.TabIndex = 1;
                        // 
                        // EntradaNumero
                        // 
                        this.EntradaNumero.Location = new System.Drawing.Point(140, 64);
                        this.EntradaNumero.Name = "EntradaNumero";
                        this.EntradaNumero.ReadOnly = false;
                        this.EntradaNumero.Size = new System.Drawing.Size(172, 24);
                        this.EntradaNumero.TabIndex = 5;
                        // 
                        // EntradaBanco
                        // 
                        this.EntradaBanco.AutoTab = true;
                        this.EntradaBanco.CanCreate = true;
                        this.EntradaBanco.Filter = "";
                        this.EntradaBanco.Location = new System.Drawing.Point(140, 32);
                        this.EntradaBanco.MaxLength = 200;
                        this.EntradaBanco.Name = "EntradaBanco";
                        this.EntradaBanco.ReadOnly = false;
                        this.EntradaBanco.Required = true;
                        this.EntradaBanco.Size = new System.Drawing.Size(460, 24);
                        this.EntradaBanco.TabIndex = 3;
                        this.EntradaBanco.NombreTipo = "Lbl.Bancos.Banco";
                        this.EntradaBanco.Text = "0";
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
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(0, 64);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(140, 24);
                        this.Label3.TabIndex = 4;
                        this.Label3.Text = "Número";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(0, 32);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(140, 24);
                        this.Label1.TabIndex = 2;
                        this.Label1.Text = "Banco";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFechaCobro
                        // 
                        this.EntradaFechaCobro.DataType = Lui.Forms.DataTypes.Date;
                        this.EntradaFechaCobro.Location = new System.Drawing.Point(140, 128);
                        this.EntradaFechaCobro.Name = "EntradaFechaCobro";
                        this.EntradaFechaCobro.ReadOnly = false;
                        this.EntradaFechaCobro.Size = new System.Drawing.Size(112, 24);
                        this.EntradaFechaCobro.TabIndex = 9;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(0, 128);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(140, 24);
                        this.label2.TabIndex = 8;
                        this.label2.Text = "Fecha de cobro";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFechaEmision
                        // 
                        this.EntradaFechaEmision.DataType = Lui.Forms.DataTypes.Date;
                        this.EntradaFechaEmision.Location = new System.Drawing.Point(140, 96);
                        this.EntradaFechaEmision.Name = "EntradaFechaEmision";
                        this.EntradaFechaEmision.ReadOnly = false;
                        this.EntradaFechaEmision.Size = new System.Drawing.Size(112, 24);
                        this.EntradaFechaEmision.TabIndex = 7;
                        // 
                        // lblFecha1
                        // 
                        this.EtiquetaFecha1.Location = new System.Drawing.Point(0, 96);
                        this.EtiquetaFecha1.Name = "lblFecha1";
                        this.EtiquetaFecha1.Size = new System.Drawing.Size(140, 24);
                        this.EtiquetaFecha1.TabIndex = 6;
                        this.EtiquetaFecha1.Text = "Fecha de emisión";
                        this.EtiquetaFecha1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Editar
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.Controls.Add(this.label5);
                        this.Controls.Add(this.EntradaFechaCobro);
                        this.Controls.Add(this.EntradaFechaEmision);
                        this.Controls.Add(this.EntradaEmisor);
                        this.Controls.Add(this.EntradaNumero);
                        this.Controls.Add(this.EntradaBanco);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.EtiquetaFecha1);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.Label3);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(600, 160);
                        this.ResumeLayout(false);

                }

                #endregion

                internal Lui.Forms.TextBox EntradaEmisor;
                internal Lui.Forms.TextBox EntradaNumero;
                internal Lcc.Entrada.CodigoDetalle EntradaBanco;
                internal Lui.Forms.Label label5;
                internal Lui.Forms.Label Label3;
                internal Lui.Forms.Label Label1;
                internal Lui.Forms.TextBox EntradaFechaCobro;
                internal Lui.Forms.Label label2;
                internal Lui.Forms.TextBox EntradaFechaEmision;
                internal Lui.Forms.Label EtiquetaFecha1;
        }
}
