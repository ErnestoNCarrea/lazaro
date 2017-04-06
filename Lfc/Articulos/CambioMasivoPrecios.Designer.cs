using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Articulos
{
        public partial class CambioMasivoPrecios
        {
                protected override void Dispose(bool disposing)
                {
                        if (disposing && (components != null)) {
                                components.Dispose();
                        }

                        base.Dispose(disposing);
                }

                private System.ComponentModel.IContainer components = null;

                private void InitializeComponent()
                {
                        this.Label2 = new Lui.Forms.Label();
                        this.Label4 = new Lui.Forms.Label();
                        this.EntradaMovimiento = new Lui.Forms.ComboBox();
                        this.EntradaCantidad = new Lui.Forms.TextBox();
                        this.label10 = new Lui.Forms.Label();
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.EntradaUnidad = new Lui.Forms.ComboBox();
                        this.Listado = new Lui.Forms.ListView();
                        this.ColArticulo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColCosto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColCosto2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColPvp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColPvp2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.EntradaPrecio = new Lui.Forms.ComboBox();
                        this.SuspendLayout();
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(24, 149);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(112, 24);
                        this.Label2.TabIndex = 6;
                        this.Label2.Text = "Cantidad";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label4
                        // 
                        this.Label4.Location = new System.Drawing.Point(24, 100);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(112, 24);
                        this.Label4.TabIndex = 2;
                        this.Label4.Text = "Movimiento";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaMovimiento
                        // 
                        this.EntradaMovimiento.AlwaysExpanded = true;
                        this.EntradaMovimiento.AutoSize = true;
                        this.EntradaMovimiento.Location = new System.Drawing.Point(136, 100);
                        this.EntradaMovimiento.Name = "EntradaMovimiento";
                        this.EntradaMovimiento.SetData = new string[] {
        "Aumento|+",
        "Disminución|-"};
                        this.EntradaMovimiento.Size = new System.Drawing.Size(136, 40);
                        this.EntradaMovimiento.TabIndex = 3;
                        this.EntradaMovimiento.TextKey = "+";
                        this.EntradaMovimiento.TextChanged += new System.EventHandler(this.EntradaMovimiento_TextChanged);
                        // 
                        // EntradaCantidad
                        // 
                        this.EntradaCantidad.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaCantidad.Location = new System.Drawing.Point(136, 149);
                        this.EntradaCantidad.MaxLength = 10;
                        this.EntradaCantidad.Name = "EntradaCantidad";
                        this.EntradaCantidad.Size = new System.Drawing.Size(96, 24);
                        this.EntradaCantidad.Sufijo = "%";
                        this.EntradaCantidad.TabIndex = 7;
                        this.EntradaCantidad.Text = "0.00";
                        this.EntradaCantidad.TextChanged += new System.EventHandler(this.EntradaCantidad_TextChanged);
                        // 
                        // label10
                        // 
                        this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label10.Location = new System.Drawing.Point(24, 56);
                        this.label10.Name = "label10";
                        this.label10.Size = new System.Drawing.Size(668, 33);
                        this.label10.TabIndex = 1;
                        this.label10.Text = "Va a realizar un cambio de precios para todos los artículos del listado.";
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 24);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(269, 30);
                        this.EtiquetaTitulo.TabIndex = 0;
                        this.EtiquetaTitulo.Text = "Cambio masivo de precios";
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // EntradaUnidad
                        // 
                        this.EntradaUnidad.AlwaysExpanded = true;
                        this.EntradaUnidad.AutoSize = true;
                        this.EntradaUnidad.Location = new System.Drawing.Point(283, 100);
                        this.EntradaUnidad.Name = "EntradaUnidad";
                        this.EntradaUnidad.SetData = new string[] {
        "Porcentaje|pct",
        "Pesos|pesos"};
                        this.EntradaUnidad.Size = new System.Drawing.Size(117, 40);
                        this.EntradaUnidad.TabIndex = 4;
                        this.EntradaUnidad.TextKey = "pct";
                        this.EntradaUnidad.TextChanged += new System.EventHandler(this.EntradaUnidad_TextChanged);
                        // 
                        // Listado
                        // 
                        this.Listado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Listado.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.Listado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColArticulo,
            this.ColCosto,
            this.ColCosto2,
            this.ColPvp,
            this.ColPvp2});
                        this.Listado.FieldName = null;
                        this.Listado.GridLines = true;
                        this.Listado.Location = new System.Drawing.Point(27, 188);
                        this.Listado.MultiSelect = false;
                        this.Listado.Name = "Listado";
                        this.Listado.ReadOnly = true;
                        this.Listado.Size = new System.Drawing.Size(673, 256);
                        this.Listado.TabIndex = 8;
                        this.Listado.TabStop = false;
                        this.Listado.UseCompatibleStateImageBehavior = false;
                        this.Listado.View = System.Windows.Forms.View.Details;
                        // 
                        // ColArticulo
                        // 
                        this.ColArticulo.Text = "Artículo";
                        this.ColArticulo.Width = 271;
                        // 
                        // ColCosto
                        // 
                        this.ColCosto.Text = "Costo";
                        this.ColCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.ColCosto.Width = 90;
                        // 
                        // ColCosto2
                        // 
                        this.ColCosto2.Text = "Nuevo costo";
                        this.ColCosto2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.ColCosto2.Width = 90;
                        // 
                        // ColPvp
                        // 
                        this.ColPvp.Text = "PVP";
                        this.ColPvp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.ColPvp.Width = 90;
                        // 
                        // ColPvp2
                        // 
                        this.ColPvp2.Text = "Nuevo PVP";
                        this.ColPvp2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.ColPvp2.Width = 90;
                        // 
                        // EntradaPrecio
                        // 
                        this.EntradaPrecio.AlwaysExpanded = true;
                        this.EntradaPrecio.AutoSize = true;
                        this.EntradaPrecio.Location = new System.Drawing.Point(411, 100);
                        this.EntradaPrecio.Name = "EntradaPrecio";
                        this.EntradaPrecio.SetData = new string[] {
        "Costo|costo",
        "Venta|pvp",
        "Ambos|ambos"};
                        this.EntradaPrecio.Size = new System.Drawing.Size(129, 57);
                        this.EntradaPrecio.TabIndex = 5;
                        this.EntradaPrecio.TextKey = "pvp";
                        this.EntradaPrecio.TextChanged += new System.EventHandler(this.EntradaPrecio_TextChanged);
                        // 
                        // CambioMasivoPrecios
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(723, 528);
                        this.Controls.Add(this.EntradaPrecio);
                        this.Controls.Add(this.Listado);
                        this.Controls.Add(this.EntradaUnidad);
                        this.Controls.Add(this.label10);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Controls.Add(this.EntradaCantidad);
                        this.Controls.Add(this.EntradaMovimiento);
                        this.Controls.Add(this.Label4);
                        this.Controls.Add(this.Label2);
                        this.Name = "CambioMasivoPrecios";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        this.Text = "Artículos: cambio masivo de precios";
                        this.Activated += new System.EventHandler(this.CambioMasivoPrecios_Activated);
                        this.Controls.SetChildIndex(this.Label2, 0);
                        this.Controls.SetChildIndex(this.Label4, 0);
                        this.Controls.SetChildIndex(this.EntradaMovimiento, 0);
                        this.Controls.SetChildIndex(this.EntradaCantidad, 0);
                        this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
                        this.Controls.SetChildIndex(this.label10, 0);
                        this.Controls.SetChildIndex(this.EntradaUnidad, 0);
                        this.Controls.SetChildIndex(this.Listado, 0);
                        this.Controls.SetChildIndex(this.EntradaPrecio, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                internal Lui.Forms.Label Label2;
                internal Lui.Forms.Label Label4;
                internal Lui.Forms.ComboBox EntradaMovimiento;
                internal Lui.Forms.TextBox EntradaCantidad;
                private Lui.Forms.Label label10;
                private Lui.Forms.Label EtiquetaTitulo;
                internal Lui.Forms.ComboBox EntradaUnidad;
                private Lui.Forms.ListView Listado;
                internal Lui.Forms.ComboBox EntradaPrecio;
                private System.Windows.Forms.ColumnHeader ColArticulo;
                private System.Windows.Forms.ColumnHeader ColCosto;
                private System.Windows.Forms.ColumnHeader ColCosto2;
                private System.Windows.Forms.ColumnHeader ColPvp;
                private System.Windows.Forms.ColumnHeader ColPvp2;
        }
}
