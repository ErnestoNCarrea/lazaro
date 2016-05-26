using System;
using System.Collections.Generic;

namespace Lfc.Bancos.Cheques
{
        public partial class Pagar
        {

                /// <summary>
                /// Limpiar los recursos que se estén utilizando.
                /// </summary>
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }
                        base.Dispose(disposing);
                }

                #region Código generado por el diseñador
                /// <summary>
                /// Método necesario para admitir el Diseñador. No se puede modificar
                /// el contenido del método con el editor de código.
                /// </summary>
                private void InitializeComponent()
                {
                        this.EntradaImpuestos = new Lui.Forms.TextBox();
                        this.label4 = new Lui.Forms.Label();
                        this.EntradaSubTotal = new Lui.Forms.TextBox();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaCantidad = new Lui.Forms.TextBox();
                        this.Label2 = new Lui.Forms.Label();
                        this.EntradaCajaOrigen = new Lcc.Entrada.CodigoDetalle();
                        this.Label3 = new Lui.Forms.Label();
                        this.EntradaTotal = new Lui.Forms.TextBox();
                        this.Label8 = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaImpuestos
                        // 
                        this.EntradaImpuestos.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaImpuestos.Location = new System.Drawing.Point(416, 136);
                        this.EntradaImpuestos.Name = "EntradaImpuestos";
                        this.EntradaImpuestos.Prefijo = "$";
                        this.EntradaImpuestos.Size = new System.Drawing.Size(108, 24);
                        this.EntradaImpuestos.TabIndex = 8;
                        this.EntradaImpuestos.TextChanged += new System.EventHandler(this.Importes_TextChanged);
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(296, 136);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(120, 24);
                        this.label4.TabIndex = 7;
                        this.label4.Text = "+ Otros gastos";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaSubTotal
                        // 
                        this.EntradaSubTotal.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaSubTotal.Location = new System.Drawing.Point(416, 104);
                        this.EntradaSubTotal.Name = "EntradaSubTotal";
                        this.EntradaSubTotal.Prefijo = "$";
                        this.EntradaSubTotal.ReadOnly = true;
                        this.EntradaSubTotal.Size = new System.Drawing.Size(108, 24);
                        this.EntradaSubTotal.TabIndex = 4;
                        this.EntradaSubTotal.TabStop = false;
                        this.EntradaSubTotal.TextChanged += new System.EventHandler(this.Importes_TextChanged);
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(240, 104);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(176, 24);
                        this.Label1.TabIndex = 3;
                        this.Label1.Text = "cheque(s) por un total de";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCantidad
                        // 
                        this.EntradaCantidad.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaCantidad.Location = new System.Drawing.Point(176, 104);
                        this.EntradaCantidad.Name = "EntradaCantidad";
                        this.EntradaCantidad.ReadOnly = true;
                        this.EntradaCantidad.Size = new System.Drawing.Size(56, 24);
                        this.EntradaCantidad.TabIndex = 2;
                        this.EntradaCantidad.TabStop = false;
                        this.EntradaCantidad.Text = "0";
                        // 
                        // lblLabel1
                        // 
                        this.Label2.Location = new System.Drawing.Point(64, 104);
                        this.Label2.Name = "lblLabel1";
                        this.Label2.Size = new System.Drawing.Size(112, 24);
                        this.Label2.TabIndex = 1;
                        this.Label2.Text = "Pago de";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCajaOrigen
                        // 
                        this.EntradaCajaOrigen.AutoTab = true;
                        this.EntradaCajaOrigen.CanCreate = false;
                        this.EntradaCajaOrigen.Filter = "estado=1";
                        this.EntradaCajaOrigen.Location = new System.Drawing.Point(224, 224);
                        this.EntradaCajaOrigen.MaxLength = 200;
                        this.EntradaCajaOrigen.Name = "EntradaCajaOrigen";
                        this.EntradaCajaOrigen.Required = true;
                        this.EntradaCajaOrigen.Size = new System.Drawing.Size(352, 24);
                        this.EntradaCajaOrigen.TabIndex = 12;
                        this.EntradaCajaOrigen.NombreTipo = "Lbl.Cajas.Caja";
                        this.EntradaCajaOrigen.Text = "0";
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(64, 224);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(160, 24);
                        this.Label3.TabIndex = 11;
                        this.Label3.Text = "De la siguiente cuenta";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaTotal
                        // 
                        this.EntradaTotal.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaTotal.Location = new System.Drawing.Point(224, 184);
                        this.EntradaTotal.Name = "EntradaTotal";
                        this.EntradaTotal.Prefijo = "$";
                        this.EntradaTotal.Size = new System.Drawing.Size(136, 28);
                        this.EntradaTotal.TabIndex = 10;
                        this.EntradaTotal.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
                        this.EntradaTotal.TextChanged += new System.EventHandler(this.Importes_TextChanged);
                        // 
                        // Label8
                        // 
                        this.Label8.Location = new System.Drawing.Point(64, 184);
                        this.Label8.Name = "Label8";
                        this.Label8.Size = new System.Drawing.Size(160, 28);
                        this.Label8.TabIndex = 9;
                        this.Label8.Text = "Se van a descontar";
                        this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label8.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
                        // 
                        // label2
                        // 
                        this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label2.Location = new System.Drawing.Point(24, 56);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(584, 24);
                        this.label2.TabIndex = 54;
                        this.label2.Text = "Asentará el pago de un cheque emitido.";
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 24);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(175, 30);
                        this.EtiquetaTitulo.TabIndex = 53;
                        this.EtiquetaTitulo.Text = "Pagar un cheque";
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // Pagar
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(634, 338);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Controls.Add(this.EntradaCajaOrigen);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.EntradaTotal);
                        this.Controls.Add(this.Label8);
                        this.Controls.Add(this.EntradaImpuestos);
                        this.Controls.Add(this.EntradaSubTotal);
                        this.Controls.Add(this.EntradaCantidad);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.Label1);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "Pagar";
                        this.Text = "Pagar un cheque";
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.label4, 0);
                        this.Controls.SetChildIndex(this.Label2, 0);
                        this.Controls.SetChildIndex(this.EntradaCantidad, 0);
                        this.Controls.SetChildIndex(this.EntradaSubTotal, 0);
                        this.Controls.SetChildIndex(this.EntradaImpuestos, 0);
                        this.Controls.SetChildIndex(this.Label8, 0);
                        this.Controls.SetChildIndex(this.EntradaTotal, 0);
                        this.Controls.SetChildIndex(this.Label3, 0);
                        this.Controls.SetChildIndex(this.EntradaCajaOrigen, 0);
                        this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
                        this.Controls.SetChildIndex(this.label2, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }
                #endregion


                internal Lui.Forms.TextBox EntradaImpuestos;
                internal Lui.Forms.Label label4;
                internal Lui.Forms.TextBox EntradaSubTotal;
                internal Lui.Forms.Label Label1;
                internal Lui.Forms.TextBox EntradaCantidad;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.Label Label3;
                internal Lui.Forms.TextBox EntradaTotal;
                internal Lui.Forms.Label Label8;
                public Lcc.Entrada.CodigoDetalle EntradaCajaOrigen;
                private Lui.Forms.Label label2;
                private Lui.Forms.Label EtiquetaTitulo;
                private System.ComponentModel.IContainer components = null;
        }
}
