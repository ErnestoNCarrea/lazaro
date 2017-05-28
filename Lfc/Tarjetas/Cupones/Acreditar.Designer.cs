using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace Lfc.Tarjetas.Cupones
{
        public partial class Acreditar
        {
                private System.ComponentModel.IContainer components = null;

                internal Lui.Forms.Label Label11;
                internal Lui.Forms.Label lblLabel1;
                internal Lui.Forms.Label Label1;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.Frame Frame1;
                internal Lui.Forms.Label Label3;
                internal Lui.Forms.Label Label4;
                internal Lui.Forms.Label Label5;
                internal Lui.Forms.Label Label6;
                internal Lui.Forms.Label Label7;
                internal Lui.Forms.TextBox EntradaCuponesCantidad;
                internal Lui.Forms.TextBox EntradaCuponesSubTotal;
                internal Lui.Forms.TextBox EntradaComisionTarjeta;
                internal Lui.Forms.TextBox EntradaComisionPlan;
                internal Lui.Forms.TextBox EntradaComisionUsuario;
                internal Lui.Forms.Label Label8;
                internal Lui.Forms.ComboBox EntradaFormaPago;
                internal Lui.Forms.TextBox EntradaTotal;

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

                private void InitializeComponent()
                {
                        this.EntradaFormaPago = new Lui.Forms.ComboBox();
                        this.Label11 = new Lui.Forms.Label();
                        this.EntradaCuponesCantidad = new Lui.Forms.TextBox();
                        this.lblLabel1 = new Lui.Forms.Label();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaCuponesSubTotal = new Lui.Forms.TextBox();
                        this.EntradaComisionTarjeta = new Lui.Forms.TextBox();
                        this.Label2 = new Lui.Forms.Label();
                        this.Frame1 = new Lui.Forms.Frame();
                        this.lblComisionTarjetaPct = new Lui.Forms.Label();
                        this.EntradaComisionPlan = new Lui.Forms.TextBox();
                        this.Label3 = new Lui.Forms.Label();
                        this.EntradaComisionUsuario = new Lui.Forms.TextBox();
                        this.lblComisionPlanPct = new Lui.Forms.Label();
                        this.lblComisionUsuarioPct = new Lui.Forms.Label();
                        this.Label4 = new Lui.Forms.Label();
                        this.Label5 = new Lui.Forms.Label();
                        this.Label6 = new Lui.Forms.Label();
                        this.Label7 = new Lui.Forms.Label();
                        this.EntradaTotal = new Lui.Forms.TextBox();
                        this.Label8 = new Lui.Forms.Label();
                        this.Frame1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // EntradaFormaPago
                        // 
                        this.EntradaFormaPago.AlwaysExpanded = true;
                        this.EntradaFormaPago.AutoSize = true;
                        this.EntradaFormaPago.Location = new System.Drawing.Point(244, 272);
                        this.EntradaFormaPago.Name = "EntradaFormaPago";
                        this.EntradaFormaPago.SetData = new string[] {
        "Efectivo|1",
        "Cheque|2",
        "Depósito en cuenta|6"};
                        this.EntradaFormaPago.Size = new System.Drawing.Size(200, 56);
                        this.EntradaFormaPago.TabIndex = 17;
                        this.EntradaFormaPago.TextKey = "6";
                        // 
                        // Label11
                        // 
                        this.Label11.Location = new System.Drawing.Point(112, 272);
                        this.Label11.Name = "Label11";
                        this.Label11.Size = new System.Drawing.Size(132, 24);
                        this.Label11.TabIndex = 16;
                        this.Label11.Text = "Pago";
                        this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCuponesCantidad
                        // 
                        this.EntradaCuponesCantidad.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaCuponesCantidad.Location = new System.Drawing.Point(136, 24);
                        this.EntradaCuponesCantidad.Name = "EntradaCuponesCantidad";
                        this.EntradaCuponesCantidad.Size = new System.Drawing.Size(56, 24);
                        this.EntradaCuponesCantidad.TabIndex = 1;
                        this.EntradaCuponesCantidad.TabStop = false;
                        this.EntradaCuponesCantidad.Text = "0";
                        // 
                        // lblLabel1
                        // 
                        this.lblLabel1.Location = new System.Drawing.Point(24, 24);
                        this.lblLabel1.Name = "lblLabel1";
                        this.lblLabel1.Size = new System.Drawing.Size(112, 24);
                        this.lblLabel1.TabIndex = 0;
                        this.lblLabel1.Text = "Acreditación de";
                        this.lblLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(200, 24);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(168, 24);
                        this.Label1.TabIndex = 2;
                        this.Label1.Text = "cupones por un total de";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCuponesSubTotal
                        // 
                        this.EntradaCuponesSubTotal.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaCuponesSubTotal.Location = new System.Drawing.Point(368, 24);
                        this.EntradaCuponesSubTotal.Name = "EntradaCuponesSubTotal";
                        this.EntradaCuponesSubTotal.Prefijo = "$";
                        this.EntradaCuponesSubTotal.Size = new System.Drawing.Size(100, 24);
                        this.EntradaCuponesSubTotal.TabIndex = 3;
                        this.EntradaCuponesSubTotal.TabStop = false;
                        // 
                        // EntradaComisionTarjeta
                        // 
                        this.EntradaComisionTarjeta.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaComisionTarjeta.Location = new System.Drawing.Point(120, 40);
                        this.EntradaComisionTarjeta.Name = "EntradaComisionTarjeta";
                        this.EntradaComisionTarjeta.Prefijo = "$";
                        this.EntradaComisionTarjeta.Size = new System.Drawing.Size(104, 24);
                        this.EntradaComisionTarjeta.TabIndex = 6;
                        this.EntradaComisionTarjeta.TabStop = false;
                        this.EntradaComisionTarjeta.TextChanged += new System.EventHandler(this.EntradaComisionTarjeta_TextChanged);
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(8, 40);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(112, 24);
                        this.Label2.TabIndex = 5;
                        this.Label2.Text = "De las tarjetas";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Frame1
                        // 
                        this.Frame1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Frame1.Controls.Add(this.Label2);
                        this.Frame1.Controls.Add(this.EntradaComisionTarjeta);
                        this.Frame1.Controls.Add(this.lblComisionTarjetaPct);
                        this.Frame1.Controls.Add(this.EntradaComisionPlan);
                        this.Frame1.Controls.Add(this.Label3);
                        this.Frame1.Controls.Add(this.EntradaComisionUsuario);
                        this.Frame1.Controls.Add(this.lblComisionPlanPct);
                        this.Frame1.Controls.Add(this.lblComisionUsuarioPct);
                        this.Frame1.Controls.Add(this.Label4);
                        this.Frame1.Controls.Add(this.Label5);
                        this.Frame1.Controls.Add(this.Label6);
                        this.Frame1.Controls.Add(this.Label7);
                        this.Frame1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
                        this.Frame1.Location = new System.Drawing.Point(24, 72);
                        this.Frame1.Name = "Frame1";
                        this.Frame1.Size = new System.Drawing.Size(600, 136);
                        this.Frame1.TabIndex = 4;
                        this.Frame1.Text = "Comisiones y otros decuentos";
                        // 
                        // lblComisionTarjetaPct
                        // 
                        this.lblComisionTarjetaPct.Location = new System.Drawing.Point(232, 40);
                        this.lblComisionTarjetaPct.Name = "lblComisionTarjetaPct";
                        this.lblComisionTarjetaPct.Size = new System.Drawing.Size(76, 24);
                        this.lblComisionTarjetaPct.TabIndex = 8;
                        this.lblComisionTarjetaPct.Text = "(0%)";
                        this.lblComisionTarjetaPct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaComisionPlan
                        // 
                        this.EntradaComisionPlan.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaComisionPlan.Location = new System.Drawing.Point(120, 72);
                        this.EntradaComisionPlan.Name = "EntradaComisionPlan";
                        this.EntradaComisionPlan.Prefijo = "$";
                        this.EntradaComisionPlan.Size = new System.Drawing.Size(104, 24);
                        this.EntradaComisionPlan.TabIndex = 9;
                        this.EntradaComisionPlan.TabStop = false;
                        this.EntradaComisionPlan.TextChanged += new System.EventHandler(this.EntradaComisionPlan_TextChanged);
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(8, 72);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(112, 24);
                        this.Label3.TabIndex = 8;
                        this.Label3.Text = "De los planes";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaComisionUsuario
                        // 
                        this.EntradaComisionUsuario.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaComisionUsuario.Location = new System.Drawing.Point(120, 104);
                        this.EntradaComisionUsuario.Name = "EntradaComisionUsuario";
                        this.EntradaComisionUsuario.Prefijo = "$";
                        this.EntradaComisionUsuario.Size = new System.Drawing.Size(104, 24);
                        this.EntradaComisionUsuario.TabIndex = 12;
                        this.EntradaComisionUsuario.TextChanged += new System.EventHandler(this.EntradaComisionUsuario_TextChanged);
                        // 
                        // lblComisionPlanPct
                        // 
                        this.lblComisionPlanPct.Location = new System.Drawing.Point(232, 72);
                        this.lblComisionPlanPct.Name = "lblComisionPlanPct";
                        this.lblComisionPlanPct.Size = new System.Drawing.Size(76, 24);
                        this.lblComisionPlanPct.TabIndex = 9;
                        this.lblComisionPlanPct.Text = "(0%)";
                        this.lblComisionPlanPct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // lblComisionUsuarioPct
                        // 
                        this.lblComisionUsuarioPct.Location = new System.Drawing.Point(232, 104);
                        this.lblComisionUsuarioPct.Name = "lblComisionUsuarioPct";
                        this.lblComisionUsuarioPct.Size = new System.Drawing.Size(76, 24);
                        this.lblComisionUsuarioPct.TabIndex = 10;
                        this.lblComisionUsuarioPct.Text = "(0%)";
                        this.lblComisionUsuarioPct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label4
                        // 
                        this.Label4.Location = new System.Drawing.Point(8, 104);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(112, 24);
                        this.Label4.TabIndex = 11;
                        this.Label4.Text = "Otros";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(312, 40);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(288, 24);
                        this.Label5.TabIndex = 7;
                        this.Label5.Text = "(Comisiones normales de las tarjetas)";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label5.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        // 
                        // Label6
                        // 
                        this.Label6.Location = new System.Drawing.Point(312, 72);
                        this.Label6.Name = "Label6";
                        this.Label6.Size = new System.Drawing.Size(288, 24);
                        this.Label6.TabIndex = 10;
                        this.Label6.Text = "(Comisiones adicionales de algunos planes)";
                        this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label6.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        // 
                        // Label7
                        // 
                        this.Label7.Location = new System.Drawing.Point(312, 104);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(288, 24);
                        this.Label7.TabIndex = 13;
                        this.Label7.Text = "(Otros descuentos)";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label7.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        // 
                        // EntradaTotal
                        // 
                        this.EntradaTotal.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaTotal.Location = new System.Drawing.Point(244, 232);
                        this.EntradaTotal.Name = "EntradaTotal";
                        this.EntradaTotal.Prefijo = "$";
                        this.EntradaTotal.Size = new System.Drawing.Size(136, 28);
                        this.EntradaTotal.TabIndex = 15;
                        this.EntradaTotal.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
                        this.EntradaTotal.TextChanged += new System.EventHandler(this.EntradaTotal_TextChanged);
                        // 
                        // Label8
                        // 
                        this.Label8.Location = new System.Drawing.Point(112, 232);
                        this.Label8.Name = "Label8";
                        this.Label8.Size = new System.Drawing.Size(132, 28);
                        this.Label8.TabIndex = 14;
                        this.Label8.Text = "Total a acreditar";
                        this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Acreditar
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.ClientSize = new System.Drawing.Size(650, 413);
                        this.Controls.Add(this.EntradaTotal);
                        this.Controls.Add(this.Label8);
                        this.Controls.Add(this.EntradaCuponesSubTotal);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.EntradaCuponesCantidad);
                        this.Controls.Add(this.lblLabel1);
                        this.Controls.Add(this.EntradaFormaPago);
                        this.Controls.Add(this.Label11);
                        this.Controls.Add(this.Frame1);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "Acreditar";
                        this.Text = "Acreditación de cupones de pago";
                        this.Controls.SetChildIndex(this.Frame1, 0);
                        this.Controls.SetChildIndex(this.Label11, 0);
                        this.Controls.SetChildIndex(this.EntradaFormaPago, 0);
                        this.Controls.SetChildIndex(this.lblLabel1, 0);
                        this.Controls.SetChildIndex(this.EntradaCuponesCantidad, 0);
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.EntradaCuponesSubTotal, 0);
                        this.Controls.SetChildIndex(this.Label8, 0);
                        this.Controls.SetChildIndex(this.EntradaTotal, 0);
                        this.Frame1.ResumeLayout(false);
                        this.Frame1.PerformLayout();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                internal Lui.Forms.Label lblComisionUsuarioPct;
                internal Lui.Forms.Label lblComisionPlanPct;
                internal Lui.Forms.Label lblComisionTarjetaPct;
        }
}
