using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Articulos
{
        public partial class MasInfo  {
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
                        this.EntradaFechaCreado = new Lui.Forms.TextBox();
                        this.EntradaFechaPrecio = new Lui.Forms.TextBox();
                        this.Label2 = new Lui.Forms.Label();
                        this.EntradaCostoUltimaCompra = new Lui.Forms.TextBox();
                        this.Label3 = new Lui.Forms.Label();
                        this.EntradaCostoUltimas5Compras = new Lui.Forms.TextBox();
                        this.Label4 = new Lui.Forms.Label();
                        this.lvItems = new Lui.Forms.ListView();
                        this.fecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.costo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.pvp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.usuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.Label5 = new Lui.Forms.Label();
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(24, 56);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(208, 24);
                        this.Label1.TabIndex = 0;
                        this.Label1.Text = "El artículo fue creado el";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFechaCreado
                        // 
                        this.EntradaFechaCreado.DataType = Lui.Forms.DataTypes.DateTime;
                        this.EntradaFechaCreado.Location = new System.Drawing.Point(232, 56);
                        this.EntradaFechaCreado.Name = "EntradaFechaCreado";
                        this.EntradaFechaCreado.ReadOnly = true;
                        this.EntradaFechaCreado.Size = new System.Drawing.Size(136, 24);
                        this.EntradaFechaCreado.TabIndex = 51;
                        // 
                        // EntradaFechaPrecio
                        // 
                        this.EntradaFechaPrecio.DataType = Lui.Forms.DataTypes.DateTime;
                        this.EntradaFechaPrecio.Location = new System.Drawing.Point(232, 88);
                        this.EntradaFechaPrecio.Name = "EntradaFechaPrecio";
                        this.EntradaFechaPrecio.ReadOnly = true;
                        this.EntradaFechaPrecio.Size = new System.Drawing.Size(136, 24);
                        this.EntradaFechaPrecio.TabIndex = 53;
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(24, 88);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(208, 24);
                        this.Label2.TabIndex = 52;
                        this.Label2.Text = "El precio actual fue puesto el";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCostoUltimaCompra
                        // 
                        this.EntradaCostoUltimaCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaCostoUltimaCompra.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaCostoUltimaCompra.Location = new System.Drawing.Point(380, 320);
                        this.EntradaCostoUltimaCompra.Name = "EntradaCostoUltimaCompra";
                        this.EntradaCostoUltimaCompra.Prefijo = "$";
                        this.EntradaCostoUltimaCompra.ReadOnly = true;
                        this.EntradaCostoUltimaCompra.Size = new System.Drawing.Size(100, 24);
                        this.EntradaCostoUltimaCompra.TabIndex = 55;
                        // 
                        // Label3
                        // 
                        this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.Label3.Location = new System.Drawing.Point(24, 320);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(356, 24);
                        this.Label3.TabIndex = 54;
                        this.Label3.Text = "Costo de la última compra";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCostoUltimas5Compras
                        // 
                        this.EntradaCostoUltimas5Compras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaCostoUltimas5Compras.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaCostoUltimas5Compras.Location = new System.Drawing.Point(380, 352);
                        this.EntradaCostoUltimas5Compras.Name = "EntradaCostoUltimas5Compras";
                        this.EntradaCostoUltimas5Compras.Prefijo = "$";
                        this.EntradaCostoUltimas5Compras.ReadOnly = true;
                        this.EntradaCostoUltimas5Compras.Size = new System.Drawing.Size(100, 24);
                        this.EntradaCostoUltimas5Compras.TabIndex = 57;
                        // 
                        // Label4
                        // 
                        this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.Label4.Location = new System.Drawing.Point(24, 352);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(356, 24);
                        this.Label4.TabIndex = 56;
                        this.Label4.Text = "Costo promedio de las últimas 5 compras";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // lvItems
                        // 
                        this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.lvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.lvItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fecha,
            this.costo,
            this.pvp,
            this.usuario});
                        this.lvItems.FullRowSelect = true;
                        this.lvItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.lvItems.LabelWrap = false;
                        this.lvItems.Location = new System.Drawing.Point(24, 152);
                        this.lvItems.MultiSelect = false;
                        this.lvItems.Name = "lvItems";
                        this.lvItems.Size = new System.Drawing.Size(608, 156);
                        this.lvItems.TabIndex = 59;
                        this.lvItems.TabStop = false;
                        this.lvItems.UseCompatibleStateImageBehavior = false;
                        this.lvItems.View = System.Windows.Forms.View.Details;
                        // 
                        // fecha
                        // 
                        this.fecha.Text = "Fecha";
                        this.fecha.Width = 155;
                        // 
                        // costo
                        // 
                        this.costo.Text = "Costo";
                        this.costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.costo.Width = 111;
                        // 
                        // pvp
                        // 
                        this.pvp.Text = "PVP";
                        this.pvp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.pvp.Width = 106;
                        // 
                        // usuario
                        // 
                        this.usuario.Text = "Usuario";
                        this.usuario.Width = 205;
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(24, 120);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(608, 32);
                        this.Label5.TabIndex = 60;
                        this.Label5.Text = "Historial de precios anteriores";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label5.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 16);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(333, 30);
                        this.EtiquetaTitulo.TabIndex = 101;
                        this.EtiquetaTitulo.Text = "Información adicional del artículo";
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // MasInfo
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(658, 466);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Controls.Add(this.Label5);
                        this.Controls.Add(this.lvItems);
                        this.Controls.Add(this.EntradaCostoUltimas5Compras);
                        this.Controls.Add(this.Label4);
                        this.Controls.Add(this.EntradaCostoUltimaCompra);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.EntradaFechaPrecio);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.EntradaFechaCreado);
                        this.Controls.Add(this.Label1);
                        this.Name = "MasInfo";
                        this.Text = "Artículo: Información adicional";
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.EntradaFechaCreado, 0);
                        this.Controls.SetChildIndex(this.Label2, 0);
                        this.Controls.SetChildIndex(this.EntradaFechaPrecio, 0);
                        this.Controls.SetChildIndex(this.Label3, 0);
                        this.Controls.SetChildIndex(this.EntradaCostoUltimaCompra, 0);
                        this.Controls.SetChildIndex(this.Label4, 0);
                        this.Controls.SetChildIndex(this.EntradaCostoUltimas5Compras, 0);
                        this.Controls.SetChildIndex(this.lvItems, 0);
                        this.Controls.SetChildIndex(this.Label5, 0);
                        this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion


                internal Lui.Forms.Label Label1;
                internal Lui.Forms.TextBox EntradaFechaCreado;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.Label Label3;
                internal Lui.Forms.Label Label4;
                internal Lui.Forms.TextBox EntradaFechaPrecio;
                internal Lui.Forms.TextBox EntradaCostoUltimaCompra;
                internal Lui.Forms.TextBox EntradaCostoUltimas5Compras;
                internal Lui.Forms.ListView lvItems;
                internal Lui.Forms.Label Label5;
                internal System.Windows.Forms.ColumnHeader fecha;
                internal System.Windows.Forms.ColumnHeader costo;
                internal System.Windows.Forms.ColumnHeader pvp;
                internal System.Windows.Forms.ColumnHeader usuario;
                private Lui.Forms.Label EtiquetaTitulo;
        }
}
