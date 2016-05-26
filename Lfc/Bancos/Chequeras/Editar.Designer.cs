using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Bancos.Chequeras
{
        public partial class Editar
        {
                #region Código generado por el diseñador
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
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaBanco = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaDesde = new Lui.Forms.TextBox();
                        this.Label3 = new Lui.Forms.Label();
                        this.EntradaHasta = new Lui.Forms.TextBox();
                        this.label2 = new Lui.Forms.Label();
                        this.LabelCaja = new Lui.Forms.Label();
                        this.EntradaCaja = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaEstado = new Lui.Forms.ComboBox();
                        this.Label7 = new Lui.Forms.Label();
                        this.label5 = new Lui.Forms.Label();
                        this.EntradaTitular = new Lui.Forms.TextBox();
                        this.label4 = new Lui.Forms.Label();
                        this.label8 = new Lui.Forms.Label();
                        this.EntradaSucursal = new Lcc.Entrada.CodigoDetalle();
                        this.label6 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(0, 32);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(120, 24);
                        this.Label1.TabIndex = 2;
                        this.Label1.Text = "Banco";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaBanco
                        // 
                        this.EntradaBanco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaBanco.AutoTab = true;
                        this.EntradaBanco.CanCreate = true;
                        this.EntradaBanco.Location = new System.Drawing.Point(120, 32);
                        this.EntradaBanco.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaBanco.MaxLength = 200;
                        this.EntradaBanco.Name = "EntradaBanco";
                        this.EntradaBanco.NombreTipo = "Lbl.Bancos.Banco";
                        this.EntradaBanco.Required = true;
                        this.EntradaBanco.Size = new System.Drawing.Size(440, 24);
                        this.EntradaBanco.TabIndex = 3;
                        this.EntradaBanco.Text = "0";
                        // 
                        // EntradaDesde
                        // 
                        this.EntradaDesde.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaDesde.Location = new System.Drawing.Point(184, 64);
                        this.EntradaDesde.MaxLength = 10;
                        this.EntradaDesde.Name = "EntradaDesde";
                        this.EntradaDesde.Size = new System.Drawing.Size(116, 24);
                        this.EntradaDesde.TabIndex = 8;
                        this.EntradaDesde.Text = "0";
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(0, 64);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(120, 24);
                        this.Label3.TabIndex = 4;
                        this.Label3.Text = "Numeración";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaHasta
                        // 
                        this.EntradaHasta.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaHasta.Location = new System.Drawing.Point(368, 64);
                        this.EntradaHasta.MaxLength = 10;
                        this.EntradaHasta.Name = "EntradaHasta";
                        this.EntradaHasta.Size = new System.Drawing.Size(112, 24);
                        this.EntradaHasta.TabIndex = 10;
                        this.EntradaHasta.Text = "0";
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(308, 64);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(60, 24);
                        this.label2.TabIndex = 9;
                        this.label2.Text = "hasta";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // LabelCaja
                        // 
                        this.LabelCaja.Location = new System.Drawing.Point(0, 128);
                        this.LabelCaja.Name = "LabelCaja";
                        this.LabelCaja.Size = new System.Drawing.Size(120, 24);
                        this.LabelCaja.TabIndex = 13;
                        this.LabelCaja.Text = "Se debita de";
                        this.LabelCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCaja
                        // 
                        this.EntradaCaja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCaja.AutoTab = true;
                        this.EntradaCaja.CanCreate = true;
                        this.EntradaCaja.Filter = "estado=1";
                        this.EntradaCaja.Location = new System.Drawing.Point(120, 128);
                        this.EntradaCaja.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaCaja.MaxLength = 200;
                        this.EntradaCaja.Name = "EntradaCaja";
                        this.EntradaCaja.NombreTipo = "Lbl.Cajas.Caja";
                        this.EntradaCaja.PlaceholderText = "Ninguna";
                        this.EntradaCaja.Required = false;
                        this.EntradaCaja.Size = new System.Drawing.Size(440, 24);
                        this.EntradaCaja.TabIndex = 14;
                        this.EntradaCaja.Text = "0";
                        // 
                        // EntradaEstado
                        // 
                        this.EntradaEstado.AlwaysExpanded = true;
                        this.EntradaEstado.AutoSize = true;
                        this.EntradaEstado.Location = new System.Drawing.Point(120, 160);
                        this.EntradaEstado.Name = "EntradaEstado";
                        this.EntradaEstado.SetData = new string[] {
        "Fuera de uso|0",
        "Activa|1"};
                        this.EntradaEstado.Size = new System.Drawing.Size(172, 40);
                        this.EntradaEstado.TabIndex = 16;
                        this.EntradaEstado.TextKey = "1";
                        // 
                        // Label7
                        // 
                        this.Label7.Location = new System.Drawing.Point(0, 160);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(120, 24);
                        this.Label7.TabIndex = 15;
                        this.Label7.Text = "Estado";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label5
                        // 
                        this.label5.Location = new System.Drawing.Point(0, 0);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(120, 24);
                        this.label5.TabIndex = 0;
                        this.label5.Text = "Titular";
                        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaTitular
                        // 
                        this.EntradaTitular.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaTitular.Location = new System.Drawing.Point(120, 0);
                        this.EntradaTitular.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaTitular.MaxLength = 200;
                        this.EntradaTitular.Name = "EntradaTitular";
                        this.EntradaTitular.PlaceholderText = "";
                        this.EntradaTitular.Size = new System.Drawing.Size(440, 24);
                        this.EntradaTitular.TabIndex = 1;
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(120, 64);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(64, 24);
                        this.label4.TabIndex = 7;
                        this.label4.Text = "desde";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label8
                        // 
                        this.label8.Location = new System.Drawing.Point(0, 96);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(120, 24);
                        this.label8.TabIndex = 11;
                        this.label8.Text = "Sucursal";
                        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaSucursal
                        // 
                        this.EntradaSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaSucursal.AutoTab = true;
                        this.EntradaSucursal.CanCreate = true;
                        this.EntradaSucursal.Location = new System.Drawing.Point(120, 96);
                        this.EntradaSucursal.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaSucursal.MaxLength = 200;
                        this.EntradaSucursal.Name = "EntradaSucursal";
                        this.EntradaSucursal.NombreTipo = "Lbl.Entidades.Sucursal";
                        this.EntradaSucursal.PlaceholderText = "Todas";
                        this.EntradaSucursal.Required = false;
                        this.EntradaSucursal.Size = new System.Drawing.Size(440, 24);
                        this.EntradaSucursal.TabIndex = 12;
                        this.EntradaSucursal.Text = "0";
                        // 
                        // label6
                        // 
                        this.label6.Location = new System.Drawing.Point(484, 64);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(96, 24);
                        this.label6.TabIndex = 5;
                        this.label6.Text = "(inclusive)";
                        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Editar
                        // 
                        this.Controls.Add(this.label5);
                        this.Controls.Add(this.EntradaSucursal);
                        this.Controls.Add(this.label6);
                        this.Controls.Add(this.EntradaTitular);
                        this.Controls.Add(this.EntradaEstado);
                        this.Controls.Add(this.EntradaCaja);
                        this.Controls.Add(this.EntradaHasta);
                        this.Controls.Add(this.EntradaDesde);
                        this.Controls.Add(this.EntradaBanco);
                        this.Controls.Add(this.label8);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.Label7);
                        this.Controls.Add(this.LabelCaja);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.label2);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(560, 200);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }
                #endregion

                internal Lui.Forms.Label Label1;
                internal Lcc.Entrada.CodigoDetalle EntradaBanco;
                internal Lui.Forms.Label Label3;
                internal Lui.Forms.Label label2;
                internal Lui.Forms.Label Label7;
                internal Lui.Forms.TextBox EntradaDesde;
                internal Lui.Forms.TextBox EntradaHasta;
                internal Lcc.Entrada.CodigoDetalle EntradaCaja;
                internal Lui.Forms.ComboBox EntradaEstado;
                internal Lui.Forms.Label label5;
                internal Lui.Forms.Label LabelCaja;
                internal Lui.Forms.TextBox EntradaTitular;
                internal Lcc.Entrada.CodigoDetalle EntradaSucursal;
                private System.ComponentModel.IContainer components = null;
                internal Lui.Forms.Label label4;
                internal Lui.Forms.Label label8;
                internal Lui.Forms.Label label6;
        }
}
