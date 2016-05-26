using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Alicuotas
{
        public partial class Editar
        {
                internal Lui.Forms.TextBox EntradaNombre;
                internal Lui.Forms.Label Label5;
                internal Lui.Forms.Label label1;
                internal Lui.Forms.Label label2;
                internal Lui.Forms.TextBox EntradaPorcentaje;
                internal Lui.Forms.TextBox EntradaImporteMinimo;
                private System.ComponentModel.IContainer components = null;

                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }
                        base.Dispose(disposing);
                }

                #region Código generado por el diseñador

                private void InitializeComponent()
                {
                        this.EntradaNombre = new Lui.Forms.TextBox();
                        this.Label5 = new Lui.Forms.Label();
                        this.EntradaPorcentaje = new Lui.Forms.TextBox();
                        this.label1 = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.EntradaImporteMinimo = new Lui.Forms.TextBox();
                        this.SuspendLayout();
                        // 
                        // EntradaNombre
                        // 
                        this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaNombre.Location = new System.Drawing.Point(120, 0);
                        this.EntradaNombre.MaxLength = 200;
                        this.EntradaNombre.Name = "EntradaNombre";
                        this.EntradaNombre.ReadOnly = false;
                        this.EntradaNombre.Size = new System.Drawing.Size(436, 24);
                        this.EntradaNombre.TabIndex = 1;
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(0, 0);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(116, 24);
                        this.Label5.TabIndex = 0;
                        this.Label5.Text = "Nombre";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaPorcentaje
                        // 
                        this.EntradaPorcentaje.DataType = Lui.Forms.DataTypes.Float;
                        this.EntradaPorcentaje.Location = new System.Drawing.Point(120, 32);
                        this.EntradaPorcentaje.Name = "EntradaPorcentaje";
                        this.EntradaPorcentaje.ReadOnly = false;
                        this.EntradaPorcentaje.Size = new System.Drawing.Size(104, 24);
                        this.EntradaPorcentaje.Sufijo = "%";
                        this.EntradaPorcentaje.TabIndex = 3;
                        this.EntradaPorcentaje.Text = "0.0000";
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(0, 32);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(116, 24);
                        this.label1.TabIndex = 2;
                        this.label1.Text = "Porcentaje";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(0, 64);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(116, 24);
                        this.label2.TabIndex = 4;
                        this.label2.Text = "Importe Mínimo";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaImporteMinimo
                        // 
                        this.EntradaImporteMinimo.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaImporteMinimo.Location = new System.Drawing.Point(120, 64);
                        this.EntradaImporteMinimo.Name = "EntradaImporteMinimo";
                        this.EntradaImporteMinimo.ReadOnly = false;
                        this.EntradaImporteMinimo.Size = new System.Drawing.Size(104, 24);
                        this.EntradaImporteMinimo.TabIndex = 5;
                        // 
                        // Editar
                        // 
                        this.AutoSize = true;
                        this.Controls.Add(this.EntradaImporteMinimo);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.EntradaPorcentaje);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.EntradaNombre);
                        this.Controls.Add(this.Label5);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(561, 93);
                        this.ResumeLayout(false);

                }
                #endregion
        }
}
