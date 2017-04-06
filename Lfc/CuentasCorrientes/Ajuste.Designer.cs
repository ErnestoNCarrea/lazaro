using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.CuentasCorrientes
{
        public partial class Ajuste
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
                        this.EntradaConcepto = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaImporte = new Lui.Forms.TextBox();
                        this.Label2 = new Lui.Forms.Label();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaObs = new Lui.Forms.TextBox();
                        this.Label4 = new Lui.Forms.Label();
                        this.EntradaDireccion = new Lui.Forms.ComboBox();
                        this.label5 = new Lui.Forms.Label();
                        this.EntradaNuevoSaldo = new Lui.Forms.TextBox();
                        this.label3 = new Lui.Forms.Label();
                        this.label6 = new Lui.Forms.Label();
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaConcepto
                        // 
                        this.EntradaConcepto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaConcepto.AutoTab = true;
                        this.EntradaConcepto.CanCreate = true;
                        this.EntradaConcepto.Filter = "";
                        this.EntradaConcepto.FreeTextCode = "*";
                        this.EntradaConcepto.Location = new System.Drawing.Point(144, 112);
                        this.EntradaConcepto.MaxLength = 200;
                        this.EntradaConcepto.Name = "EntradaConcepto";
                        this.EntradaConcepto.Required = true;
                        this.EntradaConcepto.Size = new System.Drawing.Size(464, 24);
                        this.EntradaConcepto.TabIndex = 1;
                        this.EntradaConcepto.NombreTipo = "Lbl.Cajas.Concepto";
                        this.EntradaConcepto.Text = "0";
                        this.EntradaConcepto.Leave += new System.EventHandler(this.EntradaConcepto_Leave);
                        // 
                        // EntradaImporte
                        // 
                        this.EntradaImporte.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaImporte.Location = new System.Drawing.Point(144, 144);
                        this.EntradaImporte.Name = "EntradaImporte";
                        this.EntradaImporte.Prefijo = "$";
                        this.EntradaImporte.Size = new System.Drawing.Size(128, 24);
                        this.EntradaImporte.TabIndex = 3;
                        this.EntradaImporte.TextChanged += new System.EventHandler(this.EntradaImporte_TextChanged);
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(24, 144);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(120, 24);
                        this.Label2.TabIndex = 2;
                        this.Label2.Text = "Importe";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(24, 112);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(120, 24);
                        this.Label1.TabIndex = 0;
                        this.Label1.Text = "Concepto";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaObs
                        // 
                        this.EntradaObs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaObs.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaObs.Location = new System.Drawing.Point(144, 208);
                        this.EntradaObs.MultiLine = true;
                        this.EntradaObs.Name = "EntradaObs";
                        this.EntradaObs.Size = new System.Drawing.Size(464, 92);
                        this.EntradaObs.TabIndex = 7;
                        // 
                        // Label4
                        // 
                        this.Label4.Location = new System.Drawing.Point(24, 208);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(120, 24);
                        this.Label4.TabIndex = 6;
                        this.Label4.Text = "Observaciones";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaDireccion
                        // 
                        this.EntradaDireccion.AlwaysExpanded = false;
                        this.EntradaDireccion.Location = new System.Drawing.Point(144, 176);
                        this.EntradaDireccion.Name = "EntradaDireccion";
                        this.EntradaDireccion.SetData = new string[] {
        "Débito|1",
        "Crédito|0"};
                        this.EntradaDireccion.Size = new System.Drawing.Size(128, 24);
                        this.EntradaDireccion.TabIndex = 5;
                        this.EntradaDireccion.TextKey = "1";
                        this.EntradaDireccion.TextChanged += new System.EventHandler(this.EntradaDireccion_TextChanged);
                        // 
                        // label5
                        // 
                        this.label5.Location = new System.Drawing.Point(24, 176);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(120, 24);
                        this.label5.TabIndex = 4;
                        this.label5.Text = "Dirección";
                        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaNuevoSaldo
                        // 
                        this.EntradaNuevoSaldo.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaNuevoSaldo.Location = new System.Drawing.Point(400, 144);
                        this.EntradaNuevoSaldo.Name = "EntradaNuevoSaldo";
                        this.EntradaNuevoSaldo.Prefijo = "$";
                        this.EntradaNuevoSaldo.Size = new System.Drawing.Size(128, 24);
                        this.EntradaNuevoSaldo.TabIndex = 52;
                        this.EntradaNuevoSaldo.TabStop = false;
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(304, 144);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(96, 24);
                        this.label3.TabIndex = 51;
                        this.label3.Text = "Nuevo saldo";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label6
                        // 
                        this.label6.Location = new System.Drawing.Point(24, 56);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(584, 48);
                        this.label6.TabIndex = 105;
                        this.label6.Text = "¡Atención! Esta opción es de uso especial y puede causar desfasaje en la cuenta c" +
    "orriente. No utilice esta opción a menos que conozca sus consecuencias.";
                        this.label6.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Warning;
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 24);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(341, 30);
                        this.EtiquetaTitulo.TabIndex = 104;
                        this.EtiquetaTitulo.Text = "Ajuste manual en cuenta corriente";
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // Ajuste
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.ClientSize = new System.Drawing.Size(634, 386);
                        this.Controls.Add(this.label6);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Controls.Add(this.EntradaNuevoSaldo);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.EntradaDireccion);
                        this.Controls.Add(this.EntradaObs);
                        this.Controls.Add(this.EntradaConcepto);
                        this.Controls.Add(this.EntradaImporte);
                        this.Controls.Add(this.label5);
                        this.Controls.Add(this.Label4);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.Label1);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "Ajuste";
                        this.Text = "Ajuste manual en cuenta corriente";
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.Label2, 0);
                        this.Controls.SetChildIndex(this.Label4, 0);
                        this.Controls.SetChildIndex(this.label5, 0);
                        this.Controls.SetChildIndex(this.EntradaImporte, 0);
                        this.Controls.SetChildIndex(this.EntradaConcepto, 0);
                        this.Controls.SetChildIndex(this.EntradaObs, 0);
                        this.Controls.SetChildIndex(this.EntradaDireccion, 0);
                        this.Controls.SetChildIndex(this.label3, 0);
                        this.Controls.SetChildIndex(this.EntradaNuevoSaldo, 0);
                        this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
                        this.Controls.SetChildIndex(this.label6, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }


                #endregion

                internal Lcc.Entrada.CodigoDetalle EntradaConcepto;
                internal Lui.Forms.TextBox EntradaImporte;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.Label Label1;
                internal Lui.Forms.TextBox EntradaObs;
                internal Lui.Forms.Label Label4;
                internal Lui.Forms.Label label5;
                internal Lui.Forms.ComboBox EntradaDireccion;
                internal Lui.Forms.TextBox EntradaNuevoSaldo;
                internal Lui.Forms.Label label3;
                internal Lui.Forms.Label label6;
                private Lui.Forms.Label EtiquetaTitulo;
        }
}
