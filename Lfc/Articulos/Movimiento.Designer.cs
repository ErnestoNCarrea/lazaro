using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Articulos
{
        public partial class Movimiento
        {
                internal Lui.Forms.Label Label1;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.Label Label3;
                internal Lui.Forms.Label Label4;
                internal Lui.Forms.ComboBox EntradaMovimiento;
                internal Lui.Forms.TextBox EntradaCantidad;
                internal Lui.Forms.TextBox EntradaObs;
                internal Lui.Forms.TextBox EntradaDesdeAntes;
                internal Lui.Forms.TextBox EntradaDesdeDespues;
                internal Lcc.Entrada.CodigoDetalle EntradaDesdeSituacion;
                internal Lui.Forms.Label Label7;
                internal Lcc.Entrada.CodigoDetalle EntradaHaciaSituacion;
                internal Lui.Forms.Label Label8;
                internal Lui.Forms.TextBox EntradaHaciaDespues;
                internal Lui.Forms.TextBox EntradaHaciaAntes;
                internal Lui.Forms.Label EtiquetaDesdeSituacion;
                internal Lui.Forms.Label EtiquetaHaciaSituacion;
                internal Lui.Forms.Label Label5;
                internal Lui.Forms.Label Label6;
                public Lcc.Entrada.Articulos.DetalleComprobante EntradaArticulo;
                internal Lui.Forms.Label EtiquetaHaciaFlecha;
                internal Lui.Forms.Label EtiquetaDesdeFlecha;

                #region Código generado por el Diseñador de Windows Forms

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
                        this.Label1 = new Lui.Forms.Label();
                        this.Label2 = new Lui.Forms.Label();
                        this.Label3 = new Lui.Forms.Label();
                        this.Label4 = new Lui.Forms.Label();
                        this.EntradaMovimiento = new Lui.Forms.ComboBox();
                        this.EntradaCantidad = new Lui.Forms.TextBox();
                        this.EntradaObs = new Lui.Forms.TextBox();
                        this.EtiquetaDesdeSituacion = new Lui.Forms.Label();
                        this.EtiquetaHaciaSituacion = new Lui.Forms.Label();
                        this.EntradaDesdeAntes = new Lui.Forms.TextBox();
                        this.EntradaDesdeDespues = new Lui.Forms.TextBox();
                        this.EntradaDesdeSituacion = new Lcc.Entrada.CodigoDetalle();
                        this.Label7 = new Lui.Forms.Label();
                        this.EntradaHaciaSituacion = new Lcc.Entrada.CodigoDetalle();
                        this.Label8 = new Lui.Forms.Label();
                        this.EntradaHaciaDespues = new Lui.Forms.TextBox();
                        this.EntradaHaciaAntes = new Lui.Forms.TextBox();
                        this.EtiquetaDesdeFlecha = new Lui.Forms.Label();
                        this.EtiquetaHaciaFlecha = new Lui.Forms.Label();
                        this.Label5 = new Lui.Forms.Label();
                        this.Label6 = new Lui.Forms.Label();
                        this.EntradaArticulo = new Lcc.Entrada.Articulos.DetalleComprobante();
                        this.label10 = new Lui.Forms.Label();
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(24, 176);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(112, 24);
                        this.Label1.TabIndex = 2;
                        this.Label1.Text = "Artículo";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(24, 224);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(112, 24);
                        this.Label2.TabIndex = 4;
                        this.Label2.Text = "Cantidad";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(24, 416);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(112, 24);
                        this.Label3.TabIndex = 20;
                        this.Label3.Text = "Observaciones";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label4
                        // 
                        this.Label4.Location = new System.Drawing.Point(24, 112);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(112, 24);
                        this.Label4.TabIndex = 0;
                        this.Label4.Text = "Movimiento";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaMovimiento
                        // 
                        this.EntradaMovimiento.AlwaysExpanded = true;
                        this.EntradaMovimiento.AutoSize = true;
                        this.EntradaMovimiento.Location = new System.Drawing.Point(136, 112);
                        this.EntradaMovimiento.Name = "EntradaMovimiento";
                        this.EntradaMovimiento.SetData = new string[] {
        "Entrada|e",
        "Salida|s",
        "Otro|o"};
                        this.EntradaMovimiento.Size = new System.Drawing.Size(192, 56);
                        this.EntradaMovimiento.TabIndex = 1;
                        this.EntradaMovimiento.TextKey = "e";
                        this.EntradaMovimiento.TextChanged += new System.EventHandler(this.EntradaMovimiento_TextChanged);
                        // 
                        // EntradaCantidad
                        // 
                        this.EntradaCantidad.DataType = Lui.Forms.DataTypes.Stock;
                        this.EntradaCantidad.Location = new System.Drawing.Point(136, 224);
                        this.EntradaCantidad.MaxLength = 10;
                        this.EntradaCantidad.Name = "EntradaCantidad";
                        this.EntradaCantidad.Size = new System.Drawing.Size(96, 24);
                        this.EntradaCantidad.TabIndex = 5;
                        this.EntradaCantidad.Text = "0";
                        this.EntradaCantidad.TextChanged += new System.EventHandler(this.EntradaArticulo_TextChanged);
                        // 
                        // EntradaObs
                        // 
                        this.EntradaObs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaObs.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaObs.Location = new System.Drawing.Point(136, 416);
                        this.EntradaObs.MaximumSize = new System.Drawing.Size(480, 64);
                        this.EntradaObs.Name = "EntradaObs";
                        this.EntradaObs.Size = new System.Drawing.Size(440, 24);
                        this.EntradaObs.TabIndex = 21;
                        // 
                        // EtiquetaDesdeSituacion
                        // 
                        this.EtiquetaDesdeSituacion.Location = new System.Drawing.Point(136, 344);
                        this.EtiquetaDesdeSituacion.Name = "EtiquetaDesdeSituacion";
                        this.EtiquetaDesdeSituacion.Size = new System.Drawing.Size(168, 24);
                        this.EtiquetaDesdeSituacion.TabIndex = 12;
                        this.EtiquetaDesdeSituacion.Text = "Situación 1";
                        this.EtiquetaDesdeSituacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EtiquetaHaciaSituacion
                        // 
                        this.EtiquetaHaciaSituacion.Location = new System.Drawing.Point(136, 376);
                        this.EtiquetaHaciaSituacion.Name = "EtiquetaHaciaSituacion";
                        this.EtiquetaHaciaSituacion.Size = new System.Drawing.Size(168, 24);
                        this.EtiquetaHaciaSituacion.TabIndex = 16;
                        this.EtiquetaHaciaSituacion.Text = "Situación 2";
                        this.EtiquetaHaciaSituacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaDesdeAntes
                        // 
                        this.EntradaDesdeAntes.Location = new System.Drawing.Point(304, 344);
                        this.EntradaDesdeAntes.Name = "EntradaDesdeAntes";
                        this.EntradaDesdeAntes.Size = new System.Drawing.Size(96, 24);
                        this.EntradaDesdeAntes.TabIndex = 13;
                        this.EntradaDesdeAntes.TabStop = false;
                        // 
                        // EntradaDesdeDespues
                        // 
                        this.EntradaDesdeDespues.Location = new System.Drawing.Point(440, 344);
                        this.EntradaDesdeDespues.Name = "EntradaDesdeDespues";
                        this.EntradaDesdeDespues.Size = new System.Drawing.Size(96, 24);
                        this.EntradaDesdeDespues.TabIndex = 15;
                        this.EntradaDesdeDespues.TabStop = false;
                        // 
                        // EntradaDesdeSituacion
                        // 
                        this.EntradaDesdeSituacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaDesdeSituacion.AutoTab = true;
                        this.EntradaDesdeSituacion.CanCreate = false;
                        this.EntradaDesdeSituacion.Filter = "";
                        this.EntradaDesdeSituacion.Location = new System.Drawing.Point(136, 256);
                        this.EntradaDesdeSituacion.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaDesdeSituacion.MaxLength = 200;
                        this.EntradaDesdeSituacion.Name = "EntradaDesdeSituacion";
                        this.EntradaDesdeSituacion.Required = true;
                        this.EntradaDesdeSituacion.Size = new System.Drawing.Size(440, 24);
                        this.EntradaDesdeSituacion.TabIndex = 7;
                        this.EntradaDesdeSituacion.NombreTipo = "Lbl.Articulos.Situacion";
                        this.EntradaDesdeSituacion.Text = "0";
                        this.EntradaDesdeSituacion.TextChanged += new System.EventHandler(this.EntradaDesdeHaciaSituacion_TextChanged);
                        // 
                        // Label7
                        // 
                        this.Label7.Location = new System.Drawing.Point(24, 256);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(112, 24);
                        this.Label7.TabIndex = 6;
                        this.Label7.Text = "Origen";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaHaciaSituacion
                        // 
                        this.EntradaHaciaSituacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaHaciaSituacion.AutoTab = true;
                        this.EntradaHaciaSituacion.CanCreate = false;
                        this.EntradaHaciaSituacion.Filter = "";
                        this.EntradaHaciaSituacion.Location = new System.Drawing.Point(136, 288);
                        this.EntradaHaciaSituacion.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaHaciaSituacion.MaxLength = 200;
                        this.EntradaHaciaSituacion.Name = "EntradaHaciaSituacion";
                        this.EntradaHaciaSituacion.Required = true;
                        this.EntradaHaciaSituacion.Size = new System.Drawing.Size(440, 24);
                        this.EntradaHaciaSituacion.TabIndex = 9;
                        this.EntradaHaciaSituacion.NombreTipo = "Lbl.Articulos.Situacion";
                        this.EntradaHaciaSituacion.Text = "0";
                        this.EntradaHaciaSituacion.TextChanged += new System.EventHandler(this.EntradaDesdeHaciaSituacion_TextChanged);
                        // 
                        // Label8
                        // 
                        this.Label8.Location = new System.Drawing.Point(24, 288);
                        this.Label8.Name = "Label8";
                        this.Label8.Size = new System.Drawing.Size(112, 24);
                        this.Label8.TabIndex = 8;
                        this.Label8.Text = "Destino";
                        this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaHaciaDespues
                        // 
                        this.EntradaHaciaDespues.Location = new System.Drawing.Point(440, 376);
                        this.EntradaHaciaDespues.Name = "EntradaHaciaDespues";
                        this.EntradaHaciaDespues.Size = new System.Drawing.Size(96, 24);
                        this.EntradaHaciaDespues.TabIndex = 19;
                        this.EntradaHaciaDespues.TabStop = false;
                        // 
                        // EntradaHaciaAntes
                        // 
                        this.EntradaHaciaAntes.Location = new System.Drawing.Point(304, 376);
                        this.EntradaHaciaAntes.Name = "EntradaHaciaAntes";
                        this.EntradaHaciaAntes.Size = new System.Drawing.Size(96, 24);
                        this.EntradaHaciaAntes.TabIndex = 17;
                        this.EntradaHaciaAntes.TabStop = false;
                        // 
                        // EtiquetaDesdeFlecha
                        // 
                        this.EtiquetaDesdeFlecha.Location = new System.Drawing.Point(408, 344);
                        this.EtiquetaDesdeFlecha.Name = "EtiquetaDesdeFlecha";
                        this.EtiquetaDesdeFlecha.Size = new System.Drawing.Size(24, 24);
                        this.EtiquetaDesdeFlecha.TabIndex = 14;
                        this.EtiquetaDesdeFlecha.Text = "»";
                        this.EtiquetaDesdeFlecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // EtiquetaHaciaFlecha
                        // 
                        this.EtiquetaHaciaFlecha.Location = new System.Drawing.Point(408, 376);
                        this.EtiquetaHaciaFlecha.Name = "EtiquetaHaciaFlecha";
                        this.EtiquetaHaciaFlecha.Size = new System.Drawing.Size(24, 24);
                        this.EtiquetaHaciaFlecha.TabIndex = 18;
                        this.EtiquetaHaciaFlecha.Text = "»";
                        this.EtiquetaHaciaFlecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(304, 320);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(96, 24);
                        this.Label5.TabIndex = 10;
                        this.Label5.Text = "Antes";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                        // 
                        // Label6
                        // 
                        this.Label6.Location = new System.Drawing.Point(440, 320);
                        this.Label6.Name = "Label6";
                        this.Label6.Size = new System.Drawing.Size(96, 24);
                        this.Label6.TabIndex = 11;
                        this.Label6.Text = "Después";
                        this.Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                        // 
                        // EntradaArticulo
                        // 
                        this.EntradaArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaArticulo.BloquearCantidad = false;
                        this.EntradaArticulo.ControlStock = Lcc.Entrada.Articulos.ControlesSock.Ambos;
                        this.EntradaArticulo.Location = new System.Drawing.Point(136, 176);
                        this.EntradaArticulo.MaximumSize = new System.Drawing.Size(480, 64);
                        this.EntradaArticulo.MuestraPrecio = false;
                        this.EntradaArticulo.MostrarExistencias = false;
                        this.EntradaArticulo.Name = "EntradaArticulo";
                        this.EntradaArticulo.PermiteCrear = false;
                        this.EntradaArticulo.Precio = Lcc.Entrada.Articulos.Precios.Pvp;
                        this.EntradaArticulo.BloquearPrecio = false;
                        this.EntradaArticulo.BloquearAtriculo = false;
                        this.EntradaArticulo.Required = true;
                        this.EntradaArticulo.Size = new System.Drawing.Size(440, 24);
                        this.EntradaArticulo.TabIndex = 3;
                        this.EntradaArticulo.NombreTipo = "Lbl.Articulos.Articulo";
                        this.EntradaArticulo.Text = "0";
                        this.EntradaArticulo.PrecioCantidadChanged += new System.EventHandler(this.EntradaArticulo_PrecioCantidadChanged);
                        this.EntradaArticulo.ObtenerDatosSeguimiento += new System.EventHandler(this.EntradaArticulo_ObtenerDatosSeguimiento);
                        // 
                        // label10
                        // 
                        this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label10.Location = new System.Drawing.Point(24, 56);
                        this.label10.Name = "label10";
                        this.label10.Size = new System.Drawing.Size(544, 48);
                        this.label10.TabIndex = 104;
                        this.label10.Text = "Va a realizar un movimiento de mercadería de una situación a otra. Es recomendabl" +
    "e que haga este movimiento por medio de un comprobante si fuera posible.";
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 24);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(387, 30);
                        this.EtiquetaTitulo.TabIndex = 103;
                        this.EtiquetaTitulo.Text = "Entrada o salida manual de mercadería";
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // Movimiento
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(599, 528);
                        this.Controls.Add(this.label10);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Controls.Add(this.EntradaArticulo);
                        this.Controls.Add(this.EtiquetaHaciaFlecha);
                        this.Controls.Add(this.EtiquetaDesdeFlecha);
                        this.Controls.Add(this.EntradaHaciaDespues);
                        this.Controls.Add(this.EntradaHaciaAntes);
                        this.Controls.Add(this.EntradaDesdeDespues);
                        this.Controls.Add(this.EntradaDesdeAntes);
                        this.Controls.Add(this.Label6);
                        this.Controls.Add(this.Label5);
                        this.Controls.Add(this.EntradaHaciaSituacion);
                        this.Controls.Add(this.Label8);
                        this.Controls.Add(this.EntradaDesdeSituacion);
                        this.Controls.Add(this.Label7);
                        this.Controls.Add(this.EtiquetaHaciaSituacion);
                        this.Controls.Add(this.EtiquetaDesdeSituacion);
                        this.Controls.Add(this.EntradaObs);
                        this.Controls.Add(this.EntradaCantidad);
                        this.Controls.Add(this.EntradaMovimiento);
                        this.Controls.Add(this.Label4);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.Label1);
                        this.Name = "Movimiento";
                        this.Text = "Artículos: entradas y salidas";
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.Label2, 0);
                        this.Controls.SetChildIndex(this.Label3, 0);
                        this.Controls.SetChildIndex(this.Label4, 0);
                        this.Controls.SetChildIndex(this.EntradaMovimiento, 0);
                        this.Controls.SetChildIndex(this.EntradaCantidad, 0);
                        this.Controls.SetChildIndex(this.EntradaObs, 0);
                        this.Controls.SetChildIndex(this.EtiquetaDesdeSituacion, 0);
                        this.Controls.SetChildIndex(this.EtiquetaHaciaSituacion, 0);
                        this.Controls.SetChildIndex(this.Label7, 0);
                        this.Controls.SetChildIndex(this.EntradaDesdeSituacion, 0);
                        this.Controls.SetChildIndex(this.Label8, 0);
                        this.Controls.SetChildIndex(this.EntradaHaciaSituacion, 0);
                        this.Controls.SetChildIndex(this.Label5, 0);
                        this.Controls.SetChildIndex(this.Label6, 0);
                        this.Controls.SetChildIndex(this.EntradaDesdeAntes, 0);
                        this.Controls.SetChildIndex(this.EntradaDesdeDespues, 0);
                        this.Controls.SetChildIndex(this.EntradaHaciaAntes, 0);
                        this.Controls.SetChildIndex(this.EntradaHaciaDespues, 0);
                        this.Controls.SetChildIndex(this.EtiquetaDesdeFlecha, 0);
                        this.Controls.SetChildIndex(this.EtiquetaHaciaFlecha, 0);
                        this.Controls.SetChildIndex(this.EntradaArticulo, 0);
                        this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
                        this.Controls.SetChildIndex(this.label10, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private Lui.Forms.Label label10;
                private Lui.Forms.Label EtiquetaTitulo;

        }
}
