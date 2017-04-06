using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Bancos.Chequeras
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
                        this.EntradaCaja = new Lcc.Entrada.CodigoDetalle();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaBanco = new Lcc.Entrada.CodigoDetalle();
                        this.SuspendLayout();
                        // 
                        // EntradaEstado
                        // 
                        this.EntradaEstado.AlwaysExpanded = false;
                        this.EntradaEstado.Location = new System.Drawing.Point(140, 20);
                        this.EntradaEstado.Name = "EntradaEstado";
                        this.EntradaEstado.SetData = new string[] {
        "Todos|-1",
        "Activas|1",
        "Fuera de uso|0"};
                        this.EntradaEstado.Size = new System.Drawing.Size(172, 24);
                        this.EntradaEstado.TabIndex = 1;
                        this.EntradaEstado.TextKey = "-1";
                        // 
                        // Label7
                        // 
                        this.Label7.Location = new System.Drawing.Point(20, 20);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(120, 24);
                        this.Label7.TabIndex = 0;
                        this.Label7.Text = "Estado";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // LabelCaja
                        // 
                        this.LabelCaja.Location = new System.Drawing.Point(20, 84);
                        this.LabelCaja.Name = "LabelCaja";
                        this.LabelCaja.Size = new System.Drawing.Size(120, 24);
                        this.LabelCaja.TabIndex = 4;
                        this.LabelCaja.Text = "Caja";
                        this.LabelCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCaja
                        // 
                        this.EntradaCaja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCaja.AutoTab = true;
                        this.EntradaCaja.CanCreate = true;
                        this.EntradaCaja.Filter = "estado=1";
                        this.EntradaCaja.Location = new System.Drawing.Point(140, 84);
                        this.EntradaCaja.MaxLength = 200;
                        this.EntradaCaja.Name = "EntradaCaja";
                        this.EntradaCaja.NombreTipo = "Lbl.Cajas.Caja";
                        this.EntradaCaja.Required = false;
                        this.EntradaCaja.Size = new System.Drawing.Size(280, 24);
                        this.EntradaCaja.TabIndex = 5;
                        this.EntradaCaja.Text = "0";
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(20, 52);
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
                        this.EntradaBanco.Location = new System.Drawing.Point(140, 52);
                        this.EntradaBanco.MaxLength = 200;
                        this.EntradaBanco.Name = "EntradaBanco";
                        this.EntradaBanco.NombreTipo = "Lbl.Bancos.Banco";
                        this.EntradaBanco.Required = true;
                        this.EntradaBanco.Size = new System.Drawing.Size(280, 24);
                        this.EntradaBanco.TabIndex = 3;
                        this.EntradaBanco.Text = "0";
                        // 
                        // Filtros
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(436, 331);
                        this.Controls.Add(this.LabelCaja);
                        this.Controls.Add(this.EntradaCaja);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.EntradaBanco);
                        this.Controls.Add(this.EntradaEstado);
                        this.Controls.Add(this.Label7);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "Filtros";
                        this.Text = "Filtros";
                        this.Controls.SetChildIndex(this.Label7, 0);
                        this.Controls.SetChildIndex(this.EntradaEstado, 0);
                        this.Controls.SetChildIndex(this.EntradaBanco, 0);
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.EntradaCaja, 0);
                        this.Controls.SetChildIndex(this.LabelCaja, 0);
                        this.ResumeLayout(false);

                }
                #endregion


                internal Lui.Forms.ComboBox EntradaEstado;
                private Lui.Forms.Label Label7;
                private Lui.Forms.Label LabelCaja;
                internal Lcc.Entrada.CodigoDetalle EntradaCaja;
                private Lui.Forms.Label Label1;
                internal Lcc.Entrada.CodigoDetalle EntradaBanco;
                private System.ComponentModel.IContainer components = null;
        }
}
