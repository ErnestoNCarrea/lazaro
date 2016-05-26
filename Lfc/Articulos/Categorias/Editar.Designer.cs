using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Articulos.Categorias
{
        public partial class Editar
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

                private void InitializeComponent()
                {
                        this.EntradaNombre = new Lui.Forms.TextBox();
                        this.Label5 = new Lui.Forms.Label();
                        this.EntradaNombreSing = new Lui.Forms.TextBox();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaStockMinimo = new Lui.Forms.TextBox();
                        this.Label11 = new Lui.Forms.Label();
                        this.EntradaItem = new Lui.Forms.TextBox();
                        this.Label2 = new Lui.Forms.Label();
                        this.EntradaGarantia = new Lui.Forms.TextBox();
                        this.label20 = new Lui.Forms.Label();
                        this.EntradaSeguimiento = new Lui.Forms.ComboBox();
                        this.label8 = new Lui.Forms.Label();
                        this.EntradaRubro = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaWeb = new Lui.Forms.ComboBox();
                        this.Label7 = new Lui.Forms.Label();
                        this.label9 = new Lui.Forms.Label();
                        this.Frame2 = new Lui.Forms.Frame();
                        this.EntradaItemStock = new Lui.Forms.TextBox();
                        this.EntradaStockActual = new Lui.Forms.TextBox();
                        this.EntradaCosto = new Lui.Forms.TextBox();
                        this.Label6 = new Lui.Forms.Label();
                        this.Label3 = new Lui.Forms.Label();
                        this.Label4 = new Lui.Forms.Label();
                        this.label10 = new Lui.Forms.Label();
                        this.EntradaAlicuota = new Lcc.Entrada.CodigoDetalle();
                        this.label12 = new Lui.Forms.Label();
                        this.label13 = new Lui.Forms.Label();
                        this.Frame2.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // EntradaNombre
                        // 
                        this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaNombre.Location = new System.Drawing.Point(144, 0);
                        this.EntradaNombre.MaxLength = 200;
                        this.EntradaNombre.Name = "EntradaNombre";
                        this.EntradaNombre.Size = new System.Drawing.Size(312, 24);
                        this.EntradaNombre.TabIndex = 1;
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(0, 0);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(136, 24);
                        this.Label5.TabIndex = 0;
                        this.Label5.Text = "Nombre plural";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaNombreSing
                        // 
                        this.EntradaNombreSing.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaNombreSing.Location = new System.Drawing.Point(144, 32);
                        this.EntradaNombreSing.MaxLength = 200;
                        this.EntradaNombreSing.Name = "EntradaNombreSing";
                        this.EntradaNombreSing.Size = new System.Drawing.Size(312, 24);
                        this.EntradaNombreSing.TabIndex = 3;
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(0, 32);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(136, 24);
                        this.Label1.TabIndex = 2;
                        this.Label1.Text = "Nombre singular";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaStockMinimo
                        // 
                        this.EntradaStockMinimo.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaStockMinimo.Location = new System.Drawing.Point(144, 64);
                        this.EntradaStockMinimo.MaxLength = 14;
                        this.EntradaStockMinimo.Name = "EntradaStockMinimo";
                        this.EntradaStockMinimo.Size = new System.Drawing.Size(72, 24);
                        this.EntradaStockMinimo.TabIndex = 5;
                        this.EntradaStockMinimo.Text = "0";
                        // 
                        // Label11
                        // 
                        this.Label11.Location = new System.Drawing.Point(0, 64);
                        this.Label11.Name = "Label11";
                        this.Label11.Size = new System.Drawing.Size(136, 24);
                        this.Label11.TabIndex = 4;
                        this.Label11.Text = "Punto de reposición";
                        this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaItem
                        // 
                        this.EntradaItem.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaItem.Location = new System.Drawing.Point(188, 40);
                        this.EntradaItem.Name = "EntradaItem";
                        this.EntradaItem.Size = new System.Drawing.Size(104, 24);
                        this.EntradaItem.TabIndex = 1;
                        this.EntradaItem.TabStop = false;
                        this.EntradaItem.Text = "0";
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(8, 40);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(180, 24);
                        this.Label2.TabIndex = 0;
                        this.Label2.Text = "Artículos";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaGarantia
                        // 
                        this.EntradaGarantia.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaGarantia.Location = new System.Drawing.Point(144, 304);
                        this.EntradaGarantia.MaxLength = 3;
                        this.EntradaGarantia.Name = "EntradaGarantia";
                        this.EntradaGarantia.PlaceholderText = "Precio de costo o de compra.";
                        this.EntradaGarantia.Size = new System.Drawing.Size(104, 24);
                        this.EntradaGarantia.Sufijo = "meses";
                        this.EntradaGarantia.TabIndex = 15;
                        this.EntradaGarantia.Text = "0";
                        // 
                        // label20
                        // 
                        this.label20.Location = new System.Drawing.Point(0, 304);
                        this.label20.Name = "label20";
                        this.label20.Size = new System.Drawing.Size(136, 24);
                        this.label20.TabIndex = 14;
                        this.label20.Text = "Garantía";
                        this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaSeguimiento
                        // 
                        this.EntradaSeguimiento.AlwaysExpanded = true;
                        this.EntradaSeguimiento.AutoSize = true;
                        this.EntradaSeguimiento.Location = new System.Drawing.Point(144, 152);
                        this.EntradaSeguimiento.Name = "EntradaSeguimiento";
                        this.EntradaSeguimiento.SetData = new string[] {
        "Predeterminado|0",
        "Ninguno|1",
        "Por Números de Serie|3",
        "Por Variaciones|5"};
                        this.EntradaSeguimiento.Size = new System.Drawing.Size(187, 73);
                        this.EntradaSeguimiento.TabIndex = 9;
                        this.EntradaSeguimiento.TextKey = "0";
                        // 
                        // label8
                        // 
                        this.label8.Location = new System.Drawing.Point(0, 152);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(136, 24);
                        this.label8.TabIndex = 8;
                        this.label8.Text = "Seguimiento";
                        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaRubro
                        // 
                        this.EntradaRubro.AutoTab = true;
                        this.EntradaRubro.CanCreate = true;
                        this.EntradaRubro.Filter = "";
                        this.EntradaRubro.Location = new System.Drawing.Point(144, 240);
                        this.EntradaRubro.MaxLength = 200;
                        this.EntradaRubro.Name = "EntradaRubro";
                        this.EntradaRubro.PlaceholderText = "Sin especificar";
                        this.EntradaRubro.Required = true;
                        this.EntradaRubro.Size = new System.Drawing.Size(304, 24);
                        this.EntradaRubro.TabIndex = 11;
                        this.EntradaRubro.NombreTipo = "Lbl.Articulos.Rubro";
                        this.EntradaRubro.Text = "0";
                        // 
                        // EntradaWeb
                        // 
                        this.EntradaWeb.AlwaysExpanded = true;
                        this.EntradaWeb.AutoSize = true;
                        this.EntradaWeb.Location = new System.Drawing.Point(144, 96);
                        this.EntradaWeb.Name = "EntradaWeb";
                        this.EntradaWeb.SetData = new string[] {
        "Sí|1",
        "No|0"};
                        this.EntradaWeb.Size = new System.Drawing.Size(108, 39);
                        this.EntradaWeb.TabIndex = 7;
                        this.EntradaWeb.TextKey = "0";
                        // 
                        // Label7
                        // 
                        this.Label7.Location = new System.Drawing.Point(0, 96);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(136, 24);
                        this.Label7.TabIndex = 6;
                        this.Label7.Text = "Publicar en la web*";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // label9
                        // 
                        this.label9.Location = new System.Drawing.Point(0, 240);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(136, 24);
                        this.label9.TabIndex = 10;
                        this.label9.Text = "Rubro";
                        this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // Frame2
                        // 
                        this.Frame2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.Frame2.Controls.Add(this.EntradaItem);
                        this.Frame2.Controls.Add(this.EntradaItemStock);
                        this.Frame2.Controls.Add(this.EntradaStockActual);
                        this.Frame2.Controls.Add(this.EntradaCosto);
                        this.Frame2.Controls.Add(this.Label2);
                        this.Frame2.Controls.Add(this.Label6);
                        this.Frame2.Controls.Add(this.Label3);
                        this.Frame2.Controls.Add(this.Label4);
                        this.Frame2.Font = new System.Drawing.Font("Bitstream Vera Sans", 9.75F);
                        this.Frame2.Location = new System.Drawing.Point(344, 232);
                        this.Frame2.Name = "Frame2";
                        this.Frame2.Size = new System.Drawing.Size(296, 168);
                        this.Frame2.TabIndex = 50;
                        this.Frame2.Text = "Estadsticas";
                        // 
                        // EntradaItemStock
                        // 
                        this.EntradaItemStock.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaItemStock.Location = new System.Drawing.Point(188, 72);
                        this.EntradaItemStock.Name = "EntradaItemStock";
                        this.EntradaItemStock.Size = new System.Drawing.Size(104, 24);
                        this.EntradaItemStock.TabIndex = 3;
                        this.EntradaItemStock.TabStop = false;
                        this.EntradaItemStock.Text = "0";
                        // 
                        // EntradaStockActual
                        // 
                        this.EntradaStockActual.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaStockActual.Location = new System.Drawing.Point(188, 104);
                        this.EntradaStockActual.Name = "EntradaStockActual";
                        this.EntradaStockActual.Size = new System.Drawing.Size(104, 24);
                        this.EntradaStockActual.TabIndex = 5;
                        this.EntradaStockActual.TabStop = false;
                        this.EntradaStockActual.Text = "0";
                        // 
                        // EntradaCosto
                        // 
                        this.EntradaCosto.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaCosto.Location = new System.Drawing.Point(188, 136);
                        this.EntradaCosto.Name = "EntradaCosto";
                        this.EntradaCosto.Prefijo = "$";
                        this.EntradaCosto.Size = new System.Drawing.Size(104, 24);
                        this.EntradaCosto.TabIndex = 7;
                        this.EntradaCosto.TabStop = false;
                        // 
                        // Label6
                        // 
                        this.Label6.Location = new System.Drawing.Point(8, 72);
                        this.Label6.Name = "Label6";
                        this.Label6.Size = new System.Drawing.Size(180, 24);
                        this.Label6.TabIndex = 2;
                        this.Label6.Text = "Artículos con existencias";
                        this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(8, 104);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(180, 24);
                        this.Label3.TabIndex = 4;
                        this.Label3.Text = "Existencias";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label4
                        // 
                        this.Label4.Location = new System.Drawing.Point(8, 136);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(180, 24);
                        this.Label4.TabIndex = 6;
                        this.Label4.Text = "Valorización";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label10
                        // 
                        this.label10.Location = new System.Drawing.Point(0, 272);
                        this.label10.Name = "label10";
                        this.label10.Size = new System.Drawing.Size(136, 24);
                        this.label10.TabIndex = 12;
                        this.label10.Text = "Alícuota";
                        this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaAlicuota
                        // 
                        this.EntradaAlicuota.AutoTab = true;
                        this.EntradaAlicuota.CanCreate = true;
                        this.EntradaAlicuota.Filter = "";
                        this.EntradaAlicuota.Location = new System.Drawing.Point(144, 272);
                        this.EntradaAlicuota.MaxLength = 200;
                        this.EntradaAlicuota.Name = "EntradaAlicuota";
                        this.EntradaAlicuota.PlaceholderText = "Sin especificar";
                        this.EntradaAlicuota.Required = true;
                        this.EntradaAlicuota.Size = new System.Drawing.Size(304, 24);
                        this.EntradaAlicuota.TabIndex = 13;
                        this.EntradaAlicuota.NombreTipo = "Lbl.Impuestos.Alicuota";
                        this.EntradaAlicuota.Text = "0";
                        // 
                        // label12
                        // 
                        this.label12.Location = new System.Drawing.Point(464, 0);
                        this.label12.Name = "label12";
                        this.label12.Size = new System.Drawing.Size(136, 24);
                        this.label12.TabIndex = 51;
                        this.label12.Text = "(p. ej. \"Zapatos\")";
                        this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label12.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        // 
                        // label13
                        // 
                        this.label13.Location = new System.Drawing.Point(464, 32);
                        this.label13.Name = "label13";
                        this.label13.Size = new System.Drawing.Size(136, 24);
                        this.label13.TabIndex = 52;
                        this.label13.Text = "(p. ej. \"Zapato\")";
                        this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label13.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        // 
                        // Editar
                        // 
                        this.Controls.Add(this.label13);
                        this.Controls.Add(this.label12);
                        this.Controls.Add(this.EntradaAlicuota);
                        this.Controls.Add(this.EntradaGarantia);
                        this.Controls.Add(this.EntradaSeguimiento);
                        this.Controls.Add(this.EntradaRubro);
                        this.Controls.Add(this.EntradaWeb);
                        this.Controls.Add(this.EntradaNombre);
                        this.Controls.Add(this.EntradaNombreSing);
                        this.Controls.Add(this.EntradaStockMinimo);
                        this.Controls.Add(this.Frame2);
                        this.Controls.Add(this.label10);
                        this.Controls.Add(this.label20);
                        this.Controls.Add(this.Label5);
                        this.Controls.Add(this.label8);
                        this.Controls.Add(this.Label11);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.label9);
                        this.Controls.Add(this.Label7);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(640, 400);
                        this.Text = "v";
                        this.Frame2.ResumeLayout(false);
                        this.Frame2.PerformLayout();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                internal Lui.Forms.TextBox EntradaNombre;
                internal Lui.Forms.Label Label5;
                internal Lui.Forms.Label Label1;
                internal Lui.Forms.TextBox EntradaStockMinimo;
                internal Lui.Forms.Label Label11;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.Frame Frame2;
                internal Lui.Forms.Label Label3;
                internal Lui.Forms.Label Label4;
                internal Lui.Forms.TextBox EntradaNombreSing;
                internal Lui.Forms.TextBox EntradaItem;
                internal Lui.Forms.TextBox EntradaStockActual;
                internal Lui.Forms.TextBox EntradaCosto;
                internal Lui.Forms.TextBox EntradaItemStock;
                internal Lui.Forms.Label Label6;
                internal Lui.Forms.ComboBox EntradaWeb;
                internal Lui.Forms.Label Label7;
                private Lcc.Entrada.CodigoDetalle EntradaRubro;
                internal Lui.Forms.Label label9;
                internal Lui.Forms.ComboBox EntradaSeguimiento;
                internal Lui.Forms.Label label8;
                internal Lui.Forms.TextBox EntradaGarantia;
                internal Lui.Forms.Label label20;
                internal Lui.Forms.Label label10;
                private Lcc.Entrada.CodigoDetalle EntradaAlicuota;
                internal Lui.Forms.Label label12;
                internal Lui.Forms.Label label13;
        }
}
