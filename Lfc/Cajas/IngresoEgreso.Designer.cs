using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Cajas
{
        public partial class IngresoEgreso : Lui.Forms.DialogForm
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
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaImporte = new Lui.Forms.TextBox();
                        this.Label2 = new Lui.Forms.Label();
                        this.EntradaConcepto = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaComprobante = new Lui.Forms.TextBox();
                        this.Label3 = new Lui.Forms.Label();
                        this.EntradaObs = new Lui.Forms.TextBox();
                        this.Label4 = new Lui.Forms.Label();
                        this.EntradaPersona = new Lcc.Entrada.CodigoDetalle();
                        this.Label5 = new Lui.Forms.Label();
                        this.EntradaCaja = new Lcc.Entrada.CodigoDetalle();
                        this.label6 = new Lui.Forms.Label();
                        this.EntradaNuevoSaldo = new Lui.Forms.TextBox();
                        this.label7 = new Lui.Forms.Label();
                        this.label8 = new Lui.Forms.Label();
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(24, 200);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(120, 24);
                        this.Label1.TabIndex = 8;
                        this.Label1.Text = "Concepto";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaImporte
                        // 
                        this.EntradaImporte.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaImporte.Location = new System.Drawing.Point(144, 128);
                        this.EntradaImporte.Name = "EntradaImporte";
                        this.EntradaImporte.Prefijo = "$";
                        this.EntradaImporte.Size = new System.Drawing.Size(108, 24);
                        this.EntradaImporte.TabIndex = 5;
                        this.EntradaImporte.TextChanged += new System.EventHandler(this.EntradaImporte_TextChanged);
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(24, 128);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(120, 24);
                        this.Label2.TabIndex = 4;
                        this.Label2.Text = "Importe";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaConcepto
                        // 
                        this.EntradaConcepto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaConcepto.AutoTab = true;
                        this.EntradaConcepto.CanCreate = false;
                        this.EntradaConcepto.Filter = "es=1";
                        this.EntradaConcepto.FreeTextCode = "*";
                        this.EntradaConcepto.Location = new System.Drawing.Point(144, 200);
                        this.EntradaConcepto.MaxLength = 200;
                        this.EntradaConcepto.Name = "EntradaConcepto";
                        this.EntradaConcepto.PlaceholderText = "Seleccione la razón del movimiento";
                        this.EntradaConcepto.Required = true;
                        this.EntradaConcepto.Size = new System.Drawing.Size(464, 24);
                        this.EntradaConcepto.TabIndex = 9;
                        this.EntradaConcepto.NombreTipo = "Lbl.Cajas.Concepto";
                        this.EntradaConcepto.Text = "0";
                        // 
                        // EntradaComprobante
                        // 
                        this.EntradaComprobante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaComprobante.Location = new System.Drawing.Point(144, 264);
                        this.EntradaComprobante.Name = "EntradaComprobante";
                        this.EntradaComprobante.PlaceholderText = "El tipo y número de comprobante asociado (opcional)";
                        this.EntradaComprobante.Size = new System.Drawing.Size(464, 24);
                        this.EntradaComprobante.TabIndex = 13;
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(24, 264);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(120, 24);
                        this.Label3.TabIndex = 12;
                        this.Label3.Text = "Comprobante";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaObs
                        // 
                        this.EntradaObs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaObs.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaObs.Location = new System.Drawing.Point(144, 296);
                        this.EntradaObs.MultiLine = true;
                        this.EntradaObs.Name = "EntradaObs";
                        this.EntradaObs.Size = new System.Drawing.Size(464, 72);
                        this.EntradaObs.TabIndex = 15;
                        // 
                        // Label4
                        // 
                        this.Label4.Location = new System.Drawing.Point(24, 296);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(120, 24);
                        this.Label4.TabIndex = 14;
                        this.Label4.Text = "Obs.";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaPersona
                        // 
                        this.EntradaPersona.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaPersona.AutoTab = true;
                        this.EntradaPersona.CanCreate = false;
                        this.EntradaPersona.Filter = "";
                        this.EntradaPersona.Location = new System.Drawing.Point(144, 232);
                        this.EntradaPersona.MaxLength = 200;
                        this.EntradaPersona.Name = "EntradaPersona";
                        this.EntradaPersona.PlaceholderText = "Asociar el movimiento con un cliente o proveedor (opcional)";
                        this.EntradaPersona.Required = true;
                        this.EntradaPersona.Size = new System.Drawing.Size(464, 24);
                        this.EntradaPersona.TabIndex = 11;
                        this.EntradaPersona.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaPersona.Text = "0";
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(24, 232);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(120, 24);
                        this.Label5.TabIndex = 10;
                        this.Label5.Text = "Persona";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCaja
                        // 
                        this.EntradaCaja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCaja.AutoTab = true;
                        this.EntradaCaja.CanCreate = true;
                        this.EntradaCaja.Filter = "estado=1";
                        this.EntradaCaja.FreeTextCode = "*";
                        this.EntradaCaja.Location = new System.Drawing.Point(144, 96);
                        this.EntradaCaja.MaxLength = 200;
                        this.EntradaCaja.Name = "EntradaCaja";
                        this.EntradaCaja.ReadOnly = true;
                        this.EntradaCaja.Required = true;
                        this.EntradaCaja.Size = new System.Drawing.Size(464, 24);
                        this.EntradaCaja.TabIndex = 3;
                        this.EntradaCaja.NombreTipo = "Lbl.Cajas.Caja";
                        this.EntradaCaja.Text = "0";
                        // 
                        // label6
                        // 
                        this.label6.Location = new System.Drawing.Point(24, 96);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(120, 24);
                        this.label6.TabIndex = 2;
                        this.label6.Text = "Caja";
                        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaNuevoSaldo
                        // 
                        this.EntradaNuevoSaldo.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaNuevoSaldo.Location = new System.Drawing.Point(488, 160);
                        this.EntradaNuevoSaldo.Name = "EntradaNuevoSaldo";
                        this.EntradaNuevoSaldo.Prefijo = "$";
                        this.EntradaNuevoSaldo.Size = new System.Drawing.Size(120, 24);
                        this.EntradaNuevoSaldo.TabIndex = 7;
                        this.EntradaNuevoSaldo.TabStop = false;
                        // 
                        // label7
                        // 
                        this.label7.Location = new System.Drawing.Point(144, 160);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(344, 24);
                        this.label7.TabIndex = 6;
                        this.label7.Text = "El saldo de la caja después del movimiento será de";
                        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label8
                        // 
                        this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label8.Location = new System.Drawing.Point(24, 56);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(584, 24);
                        this.label8.TabIndex = 1;
                        this.label8.Text = "Escriba la cantidad (importe) y la razón (concepto) del movimiento de dinero.";
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 24);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(236, 30);
                        this.EtiquetaTitulo.TabIndex = 0;
                        this.EtiquetaTitulo.Text = "Ingreso/egreso de caja";
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // IngresoEgreso
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.ClientSize = new System.Drawing.Size(634, 455);
                        this.Controls.Add(this.EntradaNuevoSaldo);
                        this.Controls.Add(this.label8);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Controls.Add(this.label7);
                        this.Controls.Add(this.EntradaCaja);
                        this.Controls.Add(this.label6);
                        this.Controls.Add(this.EntradaPersona);
                        this.Controls.Add(this.Label5);
                        this.Controls.Add(this.EntradaObs);
                        this.Controls.Add(this.Label4);
                        this.Controls.Add(this.EntradaComprobante);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.EntradaConcepto);
                        this.Controls.Add(this.EntradaImporte);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.Label1);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "IngresoEgreso";
                        this.Text = "Ingreso o egreso de caja";
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.Label2, 0);
                        this.Controls.SetChildIndex(this.EntradaImporte, 0);
                        this.Controls.SetChildIndex(this.EntradaConcepto, 0);
                        this.Controls.SetChildIndex(this.Label3, 0);
                        this.Controls.SetChildIndex(this.EntradaComprobante, 0);
                        this.Controls.SetChildIndex(this.Label4, 0);
                        this.Controls.SetChildIndex(this.EntradaObs, 0);
                        this.Controls.SetChildIndex(this.Label5, 0);
                        this.Controls.SetChildIndex(this.EntradaPersona, 0);
                        this.Controls.SetChildIndex(this.label6, 0);
                        this.Controls.SetChildIndex(this.EntradaCaja, 0);
                        this.Controls.SetChildIndex(this.label7, 0);
                        this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
                        this.Controls.SetChildIndex(this.label8, 0);
                        this.Controls.SetChildIndex(this.EntradaNuevoSaldo, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                internal Lui.Forms.Label Label1;
                internal Lui.Forms.Label Label2;
                internal Lcc.Entrada.CodigoDetalle EntradaConcepto;
                internal Lui.Forms.TextBox EntradaComprobante;
                internal Lui.Forms.Label Label3;
                internal Lui.Forms.TextBox EntradaObs;
                internal Lui.Forms.Label Label4;
                internal Lcc.Entrada.CodigoDetalle EntradaPersona;
                internal Lui.Forms.Label Label5;
                internal Lui.Forms.TextBox EntradaImporte;
                internal Lcc.Entrada.CodigoDetalle EntradaCaja;
                internal Lui.Forms.TextBox EntradaNuevoSaldo;
                internal Lui.Forms.Label label6;
                internal Lui.Forms.Label label7;
                private Lui.Forms.Label label8;
                private Lui.Forms.Label EtiquetaTitulo;
        }
}
