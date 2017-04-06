using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Bancos.Cheques
{
        public partial class Efectivizar : Lui.Forms.DialogForm
        {
                #region Código generado por el Diseñador de Windows Forms

                // Limpiar los recursos que se estén utilizando.
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }
                        base.Dispose(disposing);
                }


                // Requerido por el Diseñador de Windows Forms
                private System.ComponentModel.IContainer components = null;

                // NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
                // Puede modificarse utilizando el Diseñador de Windows Forms. 
                // No lo modifique con el editor de código.
                internal Lui.Forms.TextBox EntradaSubTotal;
                internal Lui.Forms.Label lblLabel1;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.TextBox EntradaTotal;
                internal Lui.Forms.Label Label8;
                internal Lui.Forms.Label Label3;
                internal Lcc.Entrada.CodigoDetalle EntradaCajaDestino;

                private void InitializeComponent()
                {
                        this.EntradaSubTotal = new Lui.Forms.TextBox();
                        this.lblLabel1 = new Lui.Forms.Label();
                        this.EntradaGestionDeCobro = new Lui.Forms.TextBox();
                        this.Label2 = new Lui.Forms.Label();
                        this.EntradaTotal = new Lui.Forms.TextBox();
                        this.Label8 = new Lui.Forms.Label();
                        this.Label3 = new Lui.Forms.Label();
                        this.EntradaCajaDestino = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaImpuestos = new Lui.Forms.TextBox();
                        this.label4 = new Lui.Forms.Label();
                        this.label1 = new Lui.Forms.Label();
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaSubTotal
                        // 
                        this.EntradaSubTotal.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaSubTotal.Location = new System.Drawing.Point(328, 104);
                        this.EntradaSubTotal.Name = "EntradaSubTotal";
                        this.EntradaSubTotal.Prefijo = "$";
                        this.EntradaSubTotal.ReadOnly = true;
                        this.EntradaSubTotal.Size = new System.Drawing.Size(108, 24);
                        this.EntradaSubTotal.TabIndex = 4;
                        this.EntradaSubTotal.TabStop = false;
                        this.EntradaSubTotal.Text = "0.00";
                        this.EntradaSubTotal.TextChanged += new System.EventHandler(this.EntradaImportes_TextChanged);
                        // 
                        // lblLabel1
                        // 
                        this.lblLabel1.Location = new System.Drawing.Point(72, 104);
                        this.lblLabel1.Name = "lblLabel1";
                        this.lblLabel1.Size = new System.Drawing.Size(256, 24);
                        this.lblLabel1.TabIndex = 1;
                        this.lblLabel1.Text = "Acreditación de cheque por un valor de";
                        this.lblLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaGestionDeCobro
                        // 
                        this.EntradaGestionDeCobro.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaGestionDeCobro.Location = new System.Drawing.Point(328, 136);
                        this.EntradaGestionDeCobro.Name = "EntradaGestionDeCobro";
                        this.EntradaGestionDeCobro.Prefijo = "$";
                        this.EntradaGestionDeCobro.Size = new System.Drawing.Size(108, 24);
                        this.EntradaGestionDeCobro.TabIndex = 6;
                        this.EntradaGestionDeCobro.Text = "0.00";
                        this.EntradaGestionDeCobro.TextChanged += new System.EventHandler(this.EntradaImportes_TextChanged);
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(184, 136);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(144, 24);
                        this.Label2.TabIndex = 5;
                        this.Label2.Text = "- Gestión de Cobro";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaTotal
                        // 
                        this.EntradaTotal.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaTotal.Location = new System.Drawing.Point(224, 216);
                        this.EntradaTotal.Name = "EntradaTotal";
                        this.EntradaTotal.Prefijo = "$";
                        this.EntradaTotal.Size = new System.Drawing.Size(136, 28);
                        this.EntradaTotal.TabIndex = 10;
                        this.EntradaTotal.Text = "0.00";
                        this.EntradaTotal.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
                        this.EntradaTotal.TextChanged += new System.EventHandler(this.EntradaImportes_TextChanged);
                        // 
                        // Label8
                        // 
                        this.Label8.Location = new System.Drawing.Point(64, 216);
                        this.Label8.Name = "Label8";
                        this.Label8.Size = new System.Drawing.Size(160, 28);
                        this.Label8.TabIndex = 9;
                        this.Label8.Text = "Se van a acreditar";
                        this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label8.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(64, 256);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(160, 24);
                        this.Label3.TabIndex = 11;
                        this.Label3.Text = "En la siguiente cuenta";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCajaDestino
                        // 
                        this.EntradaCajaDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCajaDestino.AutoTab = true;
                        this.EntradaCajaDestino.CanCreate = false;
                        this.EntradaCajaDestino.Filter = "estado=1";
                        this.EntradaCajaDestino.Location = new System.Drawing.Point(224, 256);
                        this.EntradaCajaDestino.MaxLength = 200;
                        this.EntradaCajaDestino.Name = "EntradaCajaDestino";
                        this.EntradaCajaDestino.NombreTipo = "Lbl.Cajas.Caja";
                        this.EntradaCajaDestino.Required = true;
                        this.EntradaCajaDestino.Size = new System.Drawing.Size(352, 24);
                        this.EntradaCajaDestino.TabIndex = 12;
                        this.EntradaCajaDestino.Text = "0";
                        // 
                        // EntradaImpuestos
                        // 
                        this.EntradaImpuestos.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaImpuestos.Location = new System.Drawing.Point(328, 168);
                        this.EntradaImpuestos.Name = "EntradaImpuestos";
                        this.EntradaImpuestos.Prefijo = "$";
                        this.EntradaImpuestos.Size = new System.Drawing.Size(108, 24);
                        this.EntradaImpuestos.TabIndex = 8;
                        this.EntradaImpuestos.Text = "0.00";
                        this.EntradaImpuestos.TextChanged += new System.EventHandler(this.EntradaImportes_TextChanged);
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(184, 168);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(144, 24);
                        this.label4.TabIndex = 7;
                        this.label4.Text = "- Otros gastos";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label1
                        // 
                        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label1.Location = new System.Drawing.Point(24, 56);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(584, 24);
                        this.label1.TabIndex = 52;
                        this.label1.Text = "Convertirá el valor de un cheque en efectivo o realizará un depósito bancario en " +
    "una cuenta propia.";
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 24);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(217, 30);
                        this.EtiquetaTitulo.TabIndex = 51;
                        this.EtiquetaTitulo.Text = "Efectivizar un cheque";
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // Efectivizar
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(634, 371);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Controls.Add(this.EntradaCajaDestino);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.EntradaImpuestos);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.EntradaTotal);
                        this.Controls.Add(this.Label8);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.EntradaGestionDeCobro);
                        this.Controls.Add(this.EntradaSubTotal);
                        this.Controls.Add(this.lblLabel1);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "Efectivizar";
                        this.Text = "Efectivizar un cheque";
                        this.Controls.SetChildIndex(this.lblLabel1, 0);
                        this.Controls.SetChildIndex(this.EntradaSubTotal, 0);
                        this.Controls.SetChildIndex(this.EntradaGestionDeCobro, 0);
                        this.Controls.SetChildIndex(this.Label2, 0);
                        this.Controls.SetChildIndex(this.Label8, 0);
                        this.Controls.SetChildIndex(this.EntradaTotal, 0);
                        this.Controls.SetChildIndex(this.label4, 0);
                        this.Controls.SetChildIndex(this.EntradaImpuestos, 0);
                        this.Controls.SetChildIndex(this.Label3, 0);
                        this.Controls.SetChildIndex(this.EntradaCajaDestino, 0);
                        this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
                        this.Controls.SetChildIndex(this.label1, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }
                #endregion

                internal Lui.Forms.TextBox EntradaGestionDeCobro;
                internal Lui.Forms.TextBox EntradaImpuestos;
                internal Lui.Forms.Label label4;
                private Lui.Forms.Label label1;
                private Lui.Forms.Label EtiquetaTitulo;
        }
}
