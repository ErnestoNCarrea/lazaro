using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Articulos.Situaciones
{
        public partial class Editar
        {
                internal Lui.Forms.Label label9;
                internal Lui.Forms.TextBox EntradaNombre;
                internal Lui.Forms.Label Label5;

                #region Código generado por el diseñador

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

                private void InitializeComponent()
                {
                        this.label9 = new Lui.Forms.Label();
                        this.EntradaNombre = new Lui.Forms.TextBox();
                        this.Label5 = new Lui.Forms.Label();
                        this.EntradaCuentaStock = new Lui.Forms.ComboBox();
                        this.EntradaFacturable = new Lui.Forms.ComboBox();
                        this.label1 = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.EntradaDeposito = new Lui.Forms.TextBox();
                        this.SuspendLayout();
                        // 
                        // label9
                        // 
                        this.label9.Location = new System.Drawing.Point(0, 32);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(120, 24);
                        this.label9.TabIndex = 2;
                        this.label9.Text = "Cuenta stock";
                        this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaNombre
                        // 
                        this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaNombre.Location = new System.Drawing.Point(124, 0);
                        this.EntradaNombre.Name = "EntradaNombre";
                        this.EntradaNombre.ReadOnly = false;
                        this.EntradaNombre.Size = new System.Drawing.Size(412, 24);
                        this.EntradaNombre.TabIndex = 1;
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(0, 0);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(120, 24);
                        this.Label5.TabIndex = 0;
                        this.Label5.Text = "Nombre";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCuentaStock
                        // 
                        this.EntradaCuentaStock.AlwaysExpanded = true;
                        this.EntradaCuentaStock.AutoSize = true;
                        this.EntradaCuentaStock.Location = new System.Drawing.Point(124, 32);
                        this.EntradaCuentaStock.Name = "EntradaCuentaStock";
                        this.EntradaCuentaStock.ReadOnly = false;
                        this.EntradaCuentaStock.SetData = new string[] {
        "Sí|1",
        "No|0"};
                        this.EntradaCuentaStock.Size = new System.Drawing.Size(88, 36);
                        this.EntradaCuentaStock.TabIndex = 3;
                        this.EntradaCuentaStock.TextKey = "0";
                        // 
                        // EntradaFacturable
                        // 
                        this.EntradaFacturable.AlwaysExpanded = true;
                        this.EntradaFacturable.AutoSize = true;
                        this.EntradaFacturable.Location = new System.Drawing.Point(124, 80);
                        this.EntradaFacturable.Name = "EntradaFacturable";
                        this.EntradaFacturable.ReadOnly = false;
                        this.EntradaFacturable.SetData = new string[] {
        "Sí|1",
        "No|0"};
                        this.EntradaFacturable.Size = new System.Drawing.Size(88, 36);
                        this.EntradaFacturable.TabIndex = 5;
                        this.EntradaFacturable.TextKey = "0";
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(0, 80);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(120, 24);
                        this.label1.TabIndex = 4;
                        this.label1.Text = "Facturable";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(0, 128);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(120, 24);
                        this.label2.TabIndex = 6;
                        this.label2.Text = "Nº de depósito";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaDeposito
                        // 
                        this.EntradaDeposito.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaDeposito.Location = new System.Drawing.Point(124, 128);
                        this.EntradaDeposito.Name = "EntradaDeposito";
                        this.EntradaDeposito.ReadOnly = false;
                        this.EntradaDeposito.Size = new System.Drawing.Size(52, 24);
                        this.EntradaDeposito.TabIndex = 7;
                        this.EntradaDeposito.Text = "0";
                        // 
                        // Editar
                        // 
                        this.Controls.Add(this.EntradaDeposito);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.EntradaFacturable);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.EntradaCuentaStock);
                        this.Controls.Add(this.label9);
                        this.Controls.Add(this.EntradaNombre);
                        this.Controls.Add(this.Label5);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(488, 237);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                internal Lui.Forms.ComboBox EntradaCuentaStock;
                internal Lui.Forms.ComboBox EntradaFacturable;
                internal Lui.Forms.Label label1;
                internal Lui.Forms.Label label2;
                internal Lui.Forms.TextBox EntradaDeposito;
        }
}
