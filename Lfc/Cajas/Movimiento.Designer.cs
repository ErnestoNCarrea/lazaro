using System;
using System.Collections.Generic;

namespace Lfc.Cajas
{
        public partial class Movimiento
        {
                #region Código generado por el Diseñador de Windows Forms


                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }
                        base.Dispose(disposing);
                }

                private System.ComponentModel.IContainer components = null;

                private void InitializeComponent()
                {
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Movimiento));
                        this.EntradaDestino = new Lcc.Entrada.CodigoDetalle();
                        this.Label3 = new Lui.Forms.Label();
                        this.EntradaImporte = new Lui.Forms.TextBox();
                        this.Label2 = new Lui.Forms.Label();
                        this.EntradaConcepto = new Lcc.Entrada.CodigoDetalle();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaObs = new Lui.Forms.TextBox();
                        this.Label4 = new Lui.Forms.Label();
                        this.EntradaComprob = new Lui.Forms.TextBox();
                        this.Label5 = new Lui.Forms.Label();
                        this.EntradaOrigen = new Lcc.Entrada.CodigoDetalle();
                        this.Label6 = new Lui.Forms.Label();
                        this.EntradaImporteDestino = new Lui.Forms.TextBox();
                        this.label8 = new Lui.Forms.Label();
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.EtiquetaImporteDestino = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaDestino
                        // 
                        this.EntradaDestino.AutoTab = true;
                        this.EntradaDestino.CanCreate = false;
                        this.EntradaDestino.Filter = "estado=1";
                        this.EntradaDestino.Location = new System.Drawing.Point(136, 168);
                        this.EntradaDestino.MaxLength = 200;
                        this.EntradaDestino.Name = "EntradaDestino";
                        this.EntradaDestino.PlaceholderText = "Seleccione la caja a la cual ingresa el dinero";
                        this.EntradaDestino.Required = false;
                        this.EntradaDestino.Size = new System.Drawing.Size(432, 24);
                        this.EntradaDestino.TabIndex = 5;
                        this.EntradaDestino.NombreTipo = "Lbl.Cajas.Caja";
                        this.EntradaDestino.Text = "0";
                        this.EntradaDestino.TextChanged += new System.EventHandler(this.EntradaOrigenDestino_TextChanged);
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(24, 168);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(112, 24);
                        this.Label3.TabIndex = 4;
                        this.Label3.Text = "Cada de destino";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaImporte
                        // 
                        this.EntradaImporte.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaImporte.Location = new System.Drawing.Point(136, 200);
                        this.EntradaImporte.Name = "EntradaImporte";
                        this.EntradaImporte.Prefijo = "$";
                        this.EntradaImporte.Size = new System.Drawing.Size(108, 24);
                        this.EntradaImporte.TabIndex = 7;
                        this.EntradaImporte.TextChanged += new System.EventHandler(this.EntradaImporte_TextChanged);
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(24, 200);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(112, 24);
                        this.Label2.TabIndex = 6;
                        this.Label2.Text = "Importe";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaConcepto
                        // 
                        this.EntradaConcepto.AutoTab = true;
                        this.EntradaConcepto.CanCreate = false;
                        this.EntradaConcepto.Filter = "";
                        this.EntradaConcepto.FreeTextCode = "*";
                        this.EntradaConcepto.Location = new System.Drawing.Point(136, 232);
                        this.EntradaConcepto.MaxLength = 200;
                        this.EntradaConcepto.Name = "EntradaConcepto";
                        this.EntradaConcepto.PlaceholderText = "Seleccione la razón del movimiento";
                        this.EntradaConcepto.Required = true;
                        this.EntradaConcepto.Size = new System.Drawing.Size(432, 24);
                        this.EntradaConcepto.TabIndex = 11;
                        this.EntradaConcepto.NombreTipo = "Lbl.Cajas.Concepto";
                        this.EntradaConcepto.Text = "0";
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(24, 232);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(112, 24);
                        this.Label1.TabIndex = 10;
                        this.Label1.Text = "Concepto";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaObs
                        // 
                        this.EntradaObs.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaObs.Location = new System.Drawing.Point(136, 296);
                        this.EntradaObs.MultiLine = true;
                        this.EntradaObs.Name = "EntradaObs";
                        this.EntradaObs.Size = new System.Drawing.Size(432, 64);
                        this.EntradaObs.TabIndex = 15;
                        this.EntradaObs.Enter += new System.EventHandler(this.EntradaObs_Enter);
                        // 
                        // Label4
                        // 
                        this.Label4.Location = new System.Drawing.Point(24, 296);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(112, 24);
                        this.Label4.TabIndex = 14;
                        this.Label4.Text = "Obs.";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaComprob
                        // 
                        this.EntradaComprob.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaComprob.Location = new System.Drawing.Point(136, 264);
                        this.EntradaComprob.MaxLength = 200;
                        this.EntradaComprob.Name = "EntradaComprob";
                        this.EntradaComprob.PlaceholderText = "El tipo y número de comprobante asociado (opcional)";
                        this.EntradaComprob.Size = new System.Drawing.Size(432, 24);
                        this.EntradaComprob.TabIndex = 13;
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(24, 264);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(112, 24);
                        this.Label5.TabIndex = 12;
                        this.Label5.Text = "Comprobante";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaOrigen
                        // 
                        this.EntradaOrigen.AutoTab = true;
                        this.EntradaOrigen.CanCreate = false;
                        this.EntradaOrigen.Filter = "estado=1";
                        this.EntradaOrigen.Location = new System.Drawing.Point(136, 136);
                        this.EntradaOrigen.MaxLength = 200;
                        this.EntradaOrigen.Name = "EntradaOrigen";
                        this.EntradaOrigen.PlaceholderText = "Seleccione la caja de la cual sale el dinero";
                        this.EntradaOrigen.Required = false;
                        this.EntradaOrigen.Size = new System.Drawing.Size(432, 24);
                        this.EntradaOrigen.TabIndex = 3;
                        this.EntradaOrigen.NombreTipo = "Lbl.Cajas.Caja";
                        this.EntradaOrigen.TabStop = false;
                        this.EntradaOrigen.Text = "0";
                        this.EntradaOrigen.TextChanged += new System.EventHandler(this.EntradaOrigenDestino_TextChanged);
                        // 
                        // Label6
                        // 
                        this.Label6.Location = new System.Drawing.Point(24, 136);
                        this.Label6.Name = "Label6";
                        this.Label6.Size = new System.Drawing.Size(112, 24);
                        this.Label6.TabIndex = 2;
                        this.Label6.Text = "Caja de origen";
                        this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaImporteDestino
                        // 
                        this.EntradaImporteDestino.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaImporteDestino.Location = new System.Drawing.Point(288, 200);
                        this.EntradaImporteDestino.Name = "EntradaImporteDestino";
                        this.EntradaImporteDestino.Prefijo = "$";
                        this.EntradaImporteDestino.Size = new System.Drawing.Size(108, 24);
                        this.EntradaImporteDestino.TabIndex = 9;
                        this.EntradaImporteDestino.Visible = false;
                        // 
                        // label8
                        // 
                        this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label8.Location = new System.Drawing.Point(24, 48);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(544, 64);
                        this.label8.TabIndex = 1;
                        this.label8.Text = resources.GetString("label8.Text");
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 16);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(266, 30);
                        this.EtiquetaTitulo.TabIndex = 0;
                        this.EtiquetaTitulo.Text = "Movimiento entre cuentas";
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // EtiquetaImporteDestino
                        // 
                        this.EtiquetaImporteDestino.Location = new System.Drawing.Point(256, 200);
                        this.EtiquetaImporteDestino.Name = "EtiquetaImporteDestino";
                        this.EtiquetaImporteDestino.Size = new System.Drawing.Size(24, 24);
                        this.EtiquetaImporteDestino.TabIndex = 8;
                        this.EtiquetaImporteDestino.Text = "->";
                        this.EtiquetaImporteDestino.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.EtiquetaImporteDestino.Visible = false;
                        // 
                        // Movimiento
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(594, 457);
                        this.Controls.Add(this.label8);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Controls.Add(this.EntradaImporte);
                        this.Controls.Add(this.EntradaImporteDestino);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.EntradaDestino);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.EtiquetaImporteDestino);
                        this.Controls.Add(this.EntradaOrigen);
                        this.Controls.Add(this.Label6);
                        this.Controls.Add(this.EntradaObs);
                        this.Controls.Add(this.Label4);
                        this.Controls.Add(this.EntradaComprob);
                        this.Controls.Add(this.Label5);
                        this.Controls.Add(this.EntradaConcepto);
                        this.Controls.Add(this.Label1);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "Movimiento";
                        this.Text = "Movimiento entre cuentas";
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.EntradaConcepto, 0);
                        this.Controls.SetChildIndex(this.Label5, 0);
                        this.Controls.SetChildIndex(this.EntradaComprob, 0);
                        this.Controls.SetChildIndex(this.Label4, 0);
                        this.Controls.SetChildIndex(this.EntradaObs, 0);
                        this.Controls.SetChildIndex(this.Label6, 0);
                        this.Controls.SetChildIndex(this.EntradaOrigen, 0);
                        this.Controls.SetChildIndex(this.EtiquetaImporteDestino, 0);
                        this.Controls.SetChildIndex(this.Label3, 0);
                        this.Controls.SetChildIndex(this.EntradaDestino, 0);
                        this.Controls.SetChildIndex(this.Label2, 0);
                        this.Controls.SetChildIndex(this.EntradaImporteDestino, 0);
                        this.Controls.SetChildIndex(this.EntradaImporte, 0);
                        this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
                        this.Controls.SetChildIndex(this.label8, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                protected Lui.Forms.Label Label3;
                protected Lui.Forms.TextBox EntradaImporte;
                protected Lui.Forms.Label Label2;
                protected internal Lcc.Entrada.CodigoDetalle EntradaConcepto;
                protected Lui.Forms.Label Label1;
                protected Lui.Forms.TextBox EntradaObs;
                protected Lui.Forms.Label Label4;
                protected Lui.Forms.TextBox EntradaComprob;
                protected Lui.Forms.Label Label5;
                protected Lui.Forms.Label Label6;
                protected internal Lcc.Entrada.CodigoDetalle EntradaDestino;
                protected internal Lcc.Entrada.CodigoDetalle EntradaOrigen;
                protected Lui.Forms.TextBox EntradaImporteDestino;
                protected int iMonedaOrigen;
                protected int iMonedaDestino;
                private Lui.Forms.Label label8;
                private Lui.Forms.Label EtiquetaTitulo;
                protected Lui.Forms.Label EtiquetaImporteDestino;
        }
}
