using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Comprobantes
{
        public class PagoVuelto : Lui.Forms.DialogForm
        {

                #region Código generado por el Diseñador de Windows Forms

                public PagoVuelto()
                        :
                        base()
                {

                        // Necesario para admitir el Diseñador de Windows Forms
                        InitializeComponent();

                        // agregar código de constructor después de llamar a InitializeComponent
                        OkButton.Visible = false;
                }

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
                internal Lui.Forms.Label Label1;
                internal Lui.Forms.TextBox EntradaTotal;
                internal Lui.Forms.TextBox EntradaPago;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.TextBox EntradaCambio;
                internal Lui.Forms.Label Label3;
                private Lui.Forms.Label EtiquetaTitulo;
                internal Lui.Forms.Label lblDesdeSituacion;
                internal System.Windows.Forms.PictureBox PictureBox1;

                private void InitializeComponent()
                {
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaTotal = new Lui.Forms.TextBox();
                        this.EntradaPago = new Lui.Forms.TextBox();
                        this.Label2 = new Lui.Forms.Label();
                        this.EntradaCambio = new Lui.Forms.TextBox();
                        this.Label3 = new Lui.Forms.Label();
                        this.PictureBox1 = new System.Windows.Forms.PictureBox();
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.lblDesdeSituacion = new Lui.Forms.Label();
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // Label1
                        // 
                        this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
                        this.Label1.Location = new System.Drawing.Point(48, 120);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(164, 32);
                        this.Label1.TabIndex = 0;
                        this.Label1.Text = "Importe a cobrar";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label1.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
                        // 
                        // EntradaTotal
                        // 
                        this.EntradaTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
                        this.EntradaTotal.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaTotal.Location = new System.Drawing.Point(212, 120);
                        this.EntradaTotal.Name = "EntradaTotal";
                        this.EntradaTotal.Prefijo = "$";
                        this.EntradaTotal.Size = new System.Drawing.Size(152, 32);
                        this.EntradaTotal.TabIndex = 1;
                        this.EntradaTotal.TabStop = false;
                        this.EntradaTotal.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Bigger;
                        // 
                        // EntradaPago
                        // 
                        this.EntradaPago.Anchor = System.Windows.Forms.AnchorStyles.Top;
                        this.EntradaPago.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaPago.Location = new System.Drawing.Point(212, 168);
                        this.EntradaPago.Name = "EntradaPago";
                        this.EntradaPago.Prefijo = "$";
                        this.EntradaPago.Size = new System.Drawing.Size(152, 32);
                        this.EntradaPago.TabIndex = 3;
                        this.EntradaPago.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Bigger;
                        this.EntradaPago.TextChanged += new System.EventHandler(this.EntradaPago_TextChanged);
                        // 
                        // Label2
                        // 
                        this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
                        this.Label2.Location = new System.Drawing.Point(48, 168);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(164, 32);
                        this.Label2.TabIndex = 2;
                        this.Label2.Text = "Pago recibido";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label2.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
                        // 
                        // EntradaCambio
                        // 
                        this.EntradaCambio.Anchor = System.Windows.Forms.AnchorStyles.Top;
                        this.EntradaCambio.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaCambio.Location = new System.Drawing.Point(212, 236);
                        this.EntradaCambio.Name = "EntradaCambio";
                        this.EntradaCambio.Prefijo = "$";
                        this.EntradaCambio.Size = new System.Drawing.Size(152, 32);
                        this.EntradaCambio.TabIndex = 6;
                        this.EntradaCambio.TabStop = false;
                        this.EntradaCambio.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Bigger;
                        // 
                        // Label3
                        // 
                        this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
                        this.Label3.Location = new System.Drawing.Point(48, 236);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(164, 32);
                        this.Label3.TabIndex = 5;
                        this.Label3.Text = "Cambio a entregar";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label3.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
                        // 
                        // PictureBox1
                        // 
                        this.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
                        this.PictureBox1.Location = new System.Drawing.Point(32, 216);
                        this.PictureBox1.Name = "PictureBox1";
                        this.PictureBox1.Size = new System.Drawing.Size(352, 4);
                        this.PictureBox1.TabIndex = 51;
                        this.PictureBox1.TabStop = false;
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 24);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(155, 30);
                        this.EtiquetaTitulo.TabIndex = 108;
                        this.EtiquetaTitulo.Text = "Calcular vuelto";
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // lblDesdeSituacion
                        // 
                        this.lblDesdeSituacion.Location = new System.Drawing.Point(24, 64);
                        this.lblDesdeSituacion.Name = "lblDesdeSituacion";
                        this.lblDesdeSituacion.Size = new System.Drawing.Size(368, 48);
                        this.lblDesdeSituacion.TabIndex = 109;
                        this.lblDesdeSituacion.Text = "Escriba el importe del pago recibido para calcular el vuelto. O pulse la tecla <E" +
    "sc> para cancelar.";
                        // 
                        // PagoVuelto
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(418, 355);
                        this.Controls.Add(this.lblDesdeSituacion);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Controls.Add(this.PictureBox1);
                        this.Controls.Add(this.EntradaCambio);
                        this.Controls.Add(this.EntradaPago);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.EntradaTotal);
                        this.Controls.Add(this.Label1);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "PagoVuelto";
                        this.Text = "Pago: calcular vuelto";
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.EntradaTotal, 0);
                        this.Controls.SetChildIndex(this.Label2, 0);
                        this.Controls.SetChildIndex(this.Label3, 0);
                        this.Controls.SetChildIndex(this.EntradaPago, 0);
                        this.Controls.SetChildIndex(this.EntradaCambio, 0);
                        this.Controls.SetChildIndex(this.PictureBox1, 0);
                        this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
                        this.Controls.SetChildIndex(this.lblDesdeSituacion, 0);
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                public decimal Total
                {
                        get
                        {
                                return EntradaTotal.ValueDecimal;
                        }
                        set
                        {
                                EntradaTotal.ValueDecimal = value;
                        }
                }

                private void EntradaPago_TextChanged(object sender, System.EventArgs e)
                {
                        EntradaCambio.Text = Lfx.Types.Formatting.FormatCurrency(Lfx.Types.Parsing.ParseCurrency(EntradaPago.Text) - Lfx.Types.Parsing.ParseCurrency(EntradaTotal.Text), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                }
        }
}
