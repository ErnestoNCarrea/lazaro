using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Recibos
{
        public class Filtros : Lui.Forms.DialogForm
        {
                #region Código generado por el Diseñador de Windows Forms

                public Filtros()
                {
                        InitializeComponent();
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
                internal Lcc.Entrada.CodigoDetalle EntradaCliente;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.Label Label1;
                internal Lcc.Entrada.CodigoDetalle EntradaVendedor;
                internal Lui.Forms.Label Label5;
                internal Lui.Forms.Label label7;
                private TableLayoutPanel tableLayoutPanel1;
                internal Lcc.Entrada.RangoFechas EntradaFechas;
                internal Lcc.Entrada.CodigoDetalle EntradaSucursal;

                private void InitializeComponent()
                {
                        this.EntradaCliente = new Lcc.Entrada.CodigoDetalle();
                        this.Label2 = new Lui.Forms.Label();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaVendedor = new Lcc.Entrada.CodigoDetalle();
                        this.Label5 = new Lui.Forms.Label();
                        this.EntradaSucursal = new Lcc.Entrada.CodigoDetalle();
                        this.label7 = new Lui.Forms.Label();
                        this.tableLayoutPanel1 = new Lui.Forms.TableLayoutPanel();
                        this.EntradaFechas = new Lcc.Entrada.RangoFechas();
                        this.tableLayoutPanel1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // OkButton
                        // 
                        this.OkButton.Location = new System.Drawing.Point(394, 8);
                        // 
                        // CancelCommandButton
                        // 
                        this.CancelCommandButton.Location = new System.Drawing.Point(514, 8);
                        // 
                        // EntradaCliente
                        // 
                        this.EntradaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCliente.AutoSize = true;
                        this.EntradaCliente.CanCreate = false;
                        this.EntradaCliente.Filter = "";
                        this.EntradaCliente.Location = new System.Drawing.Point(133, 31);
                        this.EntradaCliente.MaxLength = 200;
                        this.EntradaCliente.Name = "EntradaCliente";
                        this.EntradaCliente.ReadOnly = false;
                        this.EntradaCliente.Required = false;
                        this.EntradaCliente.Size = new System.Drawing.Size(448, 22);
                        this.EntradaCliente.TabIndex = 5;
                        this.EntradaCliente.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaCliente.Text = "0";
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(3, 28);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(124, 24);
                        this.Label2.TabIndex = 4;
                        this.Label2.Text = "Cliente";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(3, 84);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(124, 24);
                        this.Label1.TabIndex = 8;
                        this.Label1.Text = "Fecha";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaVendedor
                        // 
                        this.EntradaVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaVendedor.AutoSize = true;
                        this.EntradaVendedor.CanCreate = false;
                        this.EntradaVendedor.Filter = "(tipo&4)=4";
                        this.EntradaVendedor.Location = new System.Drawing.Point(133, 59);
                        this.EntradaVendedor.MaxLength = 200;
                        this.EntradaVendedor.Name = "EntradaVendedor";
                        this.EntradaVendedor.ReadOnly = false;
                        this.EntradaVendedor.Required = false;
                        this.EntradaVendedor.Size = new System.Drawing.Size(448, 22);
                        this.EntradaVendedor.TabIndex = 7;
                        this.EntradaVendedor.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaVendedor.Text = "0";
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(3, 56);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(124, 24);
                        this.Label5.TabIndex = 6;
                        this.Label5.Text = "Vendedor";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaSucursal
                        // 
                        this.EntradaSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaSucursal.AutoSize = true;
                        this.EntradaSucursal.CanCreate = false;
                        this.EntradaSucursal.Filter = "";
                        this.EntradaSucursal.Location = new System.Drawing.Point(133, 3);
                        this.EntradaSucursal.MaxLength = 200;
                        this.EntradaSucursal.Name = "EntradaSucursal";
                        this.EntradaSucursal.ReadOnly = false;
                        this.EntradaSucursal.Required = false;
                        this.EntradaSucursal.Size = new System.Drawing.Size(448, 22);
                        this.EntradaSucursal.TabIndex = 3;
                        this.EntradaSucursal.NombreTipo = "Lbl.Entidades.Sucursal";
                        this.EntradaSucursal.Text = "0";
                        // 
                        // label7
                        // 
                        this.label7.Location = new System.Drawing.Point(3, 0);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(124, 24);
                        this.label7.TabIndex = 2;
                        this.label7.Text = "Sucursal";
                        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // tableLayoutPanel1
                        // 
                        this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.tableLayoutPanel1.ColumnCount = 2;
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                        this.tableLayoutPanel1.Controls.Add(this.EntradaSucursal, 1, 0);
                        this.tableLayoutPanel1.Controls.Add(this.EntradaCliente, 1, 1);
                        this.tableLayoutPanel1.Controls.Add(this.EntradaVendedor, 1, 2);
                        this.tableLayoutPanel1.Controls.Add(this.EntradaFechas, 1, 3);
                        this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
                        this.tableLayoutPanel1.Controls.Add(this.Label2, 0, 1);
                        this.tableLayoutPanel1.Controls.Add(this.Label5, 0, 2);
                        this.tableLayoutPanel1.Controls.Add(this.Label1, 0, 3);
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 24);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 5;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 280);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // EntradaFechas
                        // 
                        this.EntradaFechas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaFechas.AutoSize = true;
                        this.EntradaFechas.Font = new System.Drawing.Font("Bitstream Vera Sans", 9.75F);
                        this.EntradaFechas.Location = new System.Drawing.Point(133, 87);
                        this.EntradaFechas.MuestraFuturos = false;
                        this.EntradaFechas.Name = "EntradaFechas";
                        this.EntradaFechas.ReadOnly = false;
                        this.EntradaFechas.Size = new System.Drawing.Size(448, 33);
                        this.EntradaFechas.TabIndex = 9;
                        // 
                        // Filtros
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.ClientSize = new System.Drawing.Size(634, 374);
                        this.Controls.Add(this.tableLayoutPanel1);
                        this.Name = "Filtros";
                        this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
                        this.tableLayoutPanel1.ResumeLayout(false);
                        this.tableLayoutPanel1.PerformLayout();
                        this.ResumeLayout(false);

                }

                #endregion
       }
}
