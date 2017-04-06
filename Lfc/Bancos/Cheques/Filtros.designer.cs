using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Bancos.Cheques
{
        public partial class Filtros
        {

                #region Código generado por el diseñador
                /// <summary>
                /// Limpiar los recursos que se están utilizando.
                /// </summary>
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }
                        base.Dispose(disposing);
                }

                /// <summary>
                /// Método necesario para admitir el Diseñador. No se puede modificar
                /// el contenido del método con el editor de código.
                /// </summary>
                private void InitializeComponent()
                {
                        this.EntradaEstado = new Lui.Forms.ComboBox();
                        this.Label7 = new Lui.Forms.Label();
                        this.LabelCaja = new Lui.Forms.Label();
                        this.EntradaPersona = new Lcc.Entrada.CodigoDetalle();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaBanco = new Lcc.Entrada.CodigoDetalle();
                        this.label2 = new Lui.Forms.Label();
                        this.EntradaFechas = new Lcc.Entrada.RangoFechas();
                        this.label3 = new Lui.Forms.Label();
                        this.EntradaSucursal = new Lcc.Entrada.CodigoDetalle();
                        this.SuspendLayout();
                        // 
                        // EntradaEstado
                        // 
                        this.EntradaEstado.AlwaysExpanded = true;
                        this.EntradaEstado.AutoSize = true;
                        this.EntradaEstado.Location = new System.Drawing.Point(108, 20);
                        this.EntradaEstado.Name = "EntradaEstado";
                        this.EntradaEstado.SetData = new string[] {
        "Todos|-1",
        "A pagar|0",
        "Depositado|5",
        "Pagado|10",
        "Anulado|90"};
                        this.EntradaEstado.Size = new System.Drawing.Size(204, 91);
                        this.EntradaEstado.TabIndex = 1;
                        this.EntradaEstado.TextKey = "-1";
                        // 
                        // Label7
                        // 
                        this.Label7.Location = new System.Drawing.Point(20, 20);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(88, 24);
                        this.Label7.TabIndex = 0;
                        this.Label7.Text = "Estado";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // LabelCaja
                        // 
                        this.LabelCaja.Location = new System.Drawing.Point(20, 184);
                        this.LabelCaja.Name = "LabelCaja";
                        this.LabelCaja.Size = new System.Drawing.Size(88, 24);
                        this.LabelCaja.TabIndex = 6;
                        this.LabelCaja.Text = "Persona";
                        this.LabelCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaPersona
                        // 
                        this.EntradaPersona.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaPersona.AutoTab = true;
                        this.EntradaPersona.CanCreate = true;
                        this.EntradaPersona.Location = new System.Drawing.Point(108, 184);
                        this.EntradaPersona.MaxLength = 200;
                        this.EntradaPersona.Name = "EntradaPersona";
                        this.EntradaPersona.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaPersona.Required = false;
                        this.EntradaPersona.Size = new System.Drawing.Size(366, 24);
                        this.EntradaPersona.TabIndex = 7;
                        this.EntradaPersona.Text = "0";
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(20, 152);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(88, 24);
                        this.Label1.TabIndex = 4;
                        this.Label1.Text = "Banco";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaBanco
                        // 
                        this.EntradaBanco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaBanco.AutoTab = true;
                        this.EntradaBanco.CanCreate = true;
                        this.EntradaBanco.Location = new System.Drawing.Point(108, 152);
                        this.EntradaBanco.MaxLength = 200;
                        this.EntradaBanco.Name = "EntradaBanco";
                        this.EntradaBanco.NombreTipo = "Lbl.Bancos.Banco";
                        this.EntradaBanco.Required = false;
                        this.EntradaBanco.Size = new System.Drawing.Size(366, 24);
                        this.EntradaBanco.TabIndex = 5;
                        this.EntradaBanco.Text = "0";
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(20, 216);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(88, 24);
                        this.label2.TabIndex = 8;
                        this.label2.Text = "Fecha";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFechas
                        // 
                        this.EntradaFechas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaFechas.Font = new System.Drawing.Font("Segoe UI", 9.75F);
                        this.EntradaFechas.Location = new System.Drawing.Point(108, 216);
                        this.EntradaFechas.MuestraFuturos = false;
                        this.EntradaFechas.Name = "EntradaFechas";
                        this.EntradaFechas.Size = new System.Drawing.Size(366, 92);
                        this.EntradaFechas.TabIndex = 9;
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(20, 120);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(88, 24);
                        this.label3.TabIndex = 2;
                        this.label3.Text = "Sucursal";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaSucursal
                        // 
                        this.EntradaSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaSucursal.AutoTab = true;
                        this.EntradaSucursal.CanCreate = true;
                        this.EntradaSucursal.Location = new System.Drawing.Point(108, 120);
                        this.EntradaSucursal.MaxLength = 200;
                        this.EntradaSucursal.Name = "EntradaSucursal";
                        this.EntradaSucursal.NombreTipo = "Lbl.Entidades.Sucursal";
                        this.EntradaSucursal.Required = false;
                        this.EntradaSucursal.Size = new System.Drawing.Size(366, 24);
                        this.EntradaSucursal.TabIndex = 3;
                        this.EntradaSucursal.Text = "0";
                        // 
                        // Filtros
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.ClientSize = new System.Drawing.Size(494, 375);
                        this.Controls.Add(this.EntradaSucursal);
                        this.Controls.Add(this.EntradaFechas);
                        this.Controls.Add(this.EntradaPersona);
                        this.Controls.Add(this.EntradaBanco);
                        this.Controls.Add(this.EntradaEstado);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.LabelCaja);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.Label7);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "Filtros";
                        this.Text = "Filtros";
                        this.Controls.SetChildIndex(this.Label7, 0);
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.LabelCaja, 0);
                        this.Controls.SetChildIndex(this.label2, 0);
                        this.Controls.SetChildIndex(this.label3, 0);
                        this.Controls.SetChildIndex(this.EntradaEstado, 0);
                        this.Controls.SetChildIndex(this.EntradaBanco, 0);
                        this.Controls.SetChildIndex(this.EntradaPersona, 0);
                        this.Controls.SetChildIndex(this.EntradaFechas, 0);
                        this.Controls.SetChildIndex(this.EntradaSucursal, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }
                #endregion

                internal Lui.Forms.ComboBox EntradaEstado;
                private Lui.Forms.Label Label7;
                private Lui.Forms.Label LabelCaja;
                internal Lcc.Entrada.CodigoDetalle EntradaPersona;
                private Lui.Forms.Label Label1;
                internal Lcc.Entrada.CodigoDetalle EntradaBanco;
                private System.ComponentModel.IContainer components = null;
                private Lui.Forms.Label label2;
                internal Lcc.Entrada.RangoFechas EntradaFechas;
                private Lui.Forms.Label label3;
                internal Lcc.Entrada.CodigoDetalle EntradaSucursal;
        }
}
