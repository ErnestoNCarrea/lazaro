using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Tareas
{
        public partial class Articulos
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

                internal Lcc.Entrada.Articulos.MatrizDetalleComprobante MatrizArticulos;
                internal Lui.Forms.Label EtiquetaTitulo;
                internal Lui.Forms.Label Label4;
                internal Lui.Forms.TextBox EntradaTotal;
                internal Lui.Forms.TextBox EntradaDescuento;
                internal Lui.Forms.Label Label6;
                internal Lui.Forms.TextBox EntradaSubTotal;
                internal Lui.Forms.Label Label5;

                private void InitializeComponent()
                {
                        this.MatrizArticulos = new Lcc.Entrada.Articulos.MatrizDetalleComprobante();
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.Label4 = new Lui.Forms.Label();
                        this.EntradaTotal = new Lui.Forms.TextBox();
                        this.EntradaDescuento = new Lui.Forms.TextBox();
                        this.Label6 = new Lui.Forms.Label();
                        this.EntradaSubTotal = new Lui.Forms.TextBox();
                        this.Label5 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // MatrizArticulos
                        // 
                        this.MatrizArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.MatrizArticulos.AutoScroll = true;
                        this.MatrizArticulos.AutoScrollMargin = new System.Drawing.Size(4, 4);
                        this.MatrizArticulos.Font = new System.Drawing.Font("Bitstream Vera Sans", 9.75F);
                        this.MatrizArticulos.FreeTextCode = "*";
                        this.MatrizArticulos.Location = new System.Drawing.Point(24, 64);
                        this.MatrizArticulos.BloquearPrecio = false;
                        this.MatrizArticulos.BloquearCantidad = false;
                        this.MatrizArticulos.BloquearAtriculo = false;
                        this.MatrizArticulos.Name = "MatrizArticulos";
                        this.MatrizArticulos.Precio = Lcc.Entrada.Articulos.Precios.Pvp;
                        this.MatrizArticulos.MostrarExistencias = true;
                        this.MatrizArticulos.Size = new System.Drawing.Size(624, 256);
                        this.MatrizArticulos.TabIndex = 1;
                        this.MatrizArticulos.TotalChanged += new System.EventHandler(this.ProductArray_TotalChanged);
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 24);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(624, 32);
                        this.EtiquetaTitulo.TabIndex = 0;
                        this.EtiquetaTitulo.Text = "Artículos";
                        this.EtiquetaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // Label4
                        // 
                        this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label4.Location = new System.Drawing.Point(416, 336);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(88, 32);
                        this.Label4.TabIndex = 53;
                        this.Label4.Text = "Total";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        this.Label4.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Bigger;
                        // 
                        // EntradaTotal
                        // 
                        this.EntradaTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaTotal.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaTotal.Location = new System.Drawing.Point(504, 336);
                        this.EntradaTotal.Name = "EntradaTotal";
                        this.EntradaTotal.Prefijo = "$";
                        this.EntradaTotal.Size = new System.Drawing.Size(144, 32);
                        this.EntradaTotal.TabIndex = 54;
                        this.EntradaTotal.TabStop = false;
                        this.EntradaTotal.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Bigger;
                        // 
                        // EntradaDescuento
                        // 
                        this.EntradaDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaDescuento.DataType = Lui.Forms.DataTypes.Float;
                        this.EntradaDescuento.Location = new System.Drawing.Point(288, 336);
                        this.EntradaDescuento.Name = "EntradaDescuento";
                        this.EntradaDescuento.Size = new System.Drawing.Size(80, 24);
                        this.EntradaDescuento.Sufijo = "%";
                        this.EntradaDescuento.TabIndex = 58;
                        this.EntradaDescuento.Text = "0.0000";
                        this.EntradaDescuento.TextChanged += new System.EventHandler(this.EntradaSubTotal_TextChanged);
                        // 
                        // Label6
                        // 
                        this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.Label6.Location = new System.Drawing.Point(200, 336);
                        this.Label6.Name = "Label6";
                        this.Label6.Size = new System.Drawing.Size(88, 24);
                        this.Label6.TabIndex = 57;
                        this.Label6.Text = "Descuento";
                        this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaSubTotal
                        // 
                        this.EntradaSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaSubTotal.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaSubTotal.Location = new System.Drawing.Point(96, 336);
                        this.EntradaSubTotal.Name = "EntradaSubTotal";
                        this.EntradaSubTotal.Prefijo = "$";
                        this.EntradaSubTotal.Size = new System.Drawing.Size(88, 24);
                        this.EntradaSubTotal.TabIndex = 56;
                        this.EntradaSubTotal.TabStop = false;
                        this.EntradaSubTotal.TextChanged += new System.EventHandler(this.EntradaSubTotal_TextChanged);
                        // 
                        // Label5
                        // 
                        this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.Label5.Location = new System.Drawing.Point(16, 336);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(80, 24);
                        this.Label5.TabIndex = 55;
                        this.Label5.Text = "Subtotal";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Articulos
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(675, 441);
                        this.Controls.Add(this.EntradaDescuento);
                        this.Controls.Add(this.Label6);
                        this.Controls.Add(this.EntradaSubTotal);
                        this.Controls.Add(this.Label5);
                        this.Controls.Add(this.Label4);
                        this.Controls.Add(this.EntradaTotal);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Controls.Add(this.MatrizArticulos);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "Articulos";
                        this.Text = "Artículos asociados a la tarea";
                        this.Controls.SetChildIndex(this.MatrizArticulos, 0);
                        this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
                        this.Controls.SetChildIndex(this.EntradaTotal, 0);
                        this.Controls.SetChildIndex(this.Label4, 0);
                        this.Controls.SetChildIndex(this.Label5, 0);
                        this.Controls.SetChildIndex(this.EntradaSubTotal, 0);
                        this.Controls.SetChildIndex(this.Label6, 0);
                        this.Controls.SetChildIndex(this.EntradaDescuento, 0);
                        this.ResumeLayout(false);

                }

                #endregion

        }
}
