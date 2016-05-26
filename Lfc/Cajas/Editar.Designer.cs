using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Cajas
{
        public partial class Editar
        {
                internal Lui.Forms.Label Label3;
                internal Lui.Forms.Label Label1;
                internal Lui.Forms.TextBox EntradaNumero;
                internal Lcc.Entrada.CodigoDetalle EntradaBanco;
                internal Lui.Forms.Label Label7;
                internal Lui.Forms.TextBox EntradaNombre;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.ComboBox EntradaTipo;
                internal Lui.Forms.Label Label4;
                internal Lui.Forms.TextBox EntradaClaveBancaria;
                internal Lui.Forms.Label EtiquetaClaveBancaria;
                internal Lui.Forms.TextBox EntradaTitular;
                internal Lui.Forms.ComboBox EntradaEstado;
                internal Lcc.Entrada.CodigoDetalle EntradaMoneda;

                #region Código generado por el Diseñador de Windows Forms

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
                        this.EntradaNumero = new Lui.Forms.TextBox();
                        this.Label3 = new Lui.Forms.Label();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaBanco = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaTipo = new Lui.Forms.ComboBox();
                        this.Label7 = new Lui.Forms.Label();
                        this.EntradaNombre = new Lui.Forms.TextBox();
                        this.Label2 = new Lui.Forms.Label();
                        this.Label4 = new Lui.Forms.Label();
                        this.EntradaMoneda = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaClaveBancaria = new Lui.Forms.TextBox();
                        this.EtiquetaClaveBancaria = new Lui.Forms.Label();
                        this.EntradaTitular = new Lui.Forms.TextBox();
                        this.label6 = new Lui.Forms.Label();
                        this.EntradaEstado = new Lui.Forms.ComboBox();
                        this.label8 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaNumero
                        // 
                        this.EntradaNumero.Location = new System.Drawing.Point(124, 152);
                        this.EntradaNumero.Name = "EntradaNumero";
                        this.EntradaNumero.ReadOnly = false;
                        this.EntradaNumero.Size = new System.Drawing.Size(228, 24);
                        this.EntradaNumero.TabIndex = 9;
                        this.EntradaNumero.TextChanged += new System.EventHandler(this.NumeroBanco_TextChanged);
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(0, 152);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(120, 24);
                        this.Label3.TabIndex = 8;
                        this.Label3.Text = "Número";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(0, 120);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(120, 24);
                        this.Label1.TabIndex = 6;
                        this.Label1.Text = "Banco";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaBanco
                        // 
                        this.EntradaBanco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaBanco.CanCreate = true;
                        this.EntradaBanco.Filter = "";
                        this.EntradaBanco.Location = new System.Drawing.Point(124, 120);
                        this.EntradaBanco.MaxLength = 200;
                        this.EntradaBanco.Name = "EntradaBanco";
                        this.EntradaBanco.ReadOnly = false;
                        this.EntradaBanco.Required = false;
                        this.EntradaBanco.Size = new System.Drawing.Size(488, 24);
                        this.EntradaBanco.TabIndex = 7;
                        this.EntradaBanco.NombreTipo = "Lbl.Bancos.Banco";
                        this.EntradaBanco.Text = "0";
                        this.EntradaBanco.TextChanged += new System.EventHandler(this.NumeroBanco_TextChanged);
                        // 
                        // EntradaTipo
                        // 
                        this.EntradaTipo.AlwaysExpanded = true;
                        this.EntradaTipo.AutoSize = true;
                        this.EntradaTipo.Location = new System.Drawing.Point(124, 64);
                        this.EntradaTipo.Name = "EntradaTipo";
                        this.EntradaTipo.ReadOnly = false;
                        this.EntradaTipo.SetData = new string[] {
        "Efectivo|0",
        "Caja de ahorro|1",
        "Cuenta corriente|2"};
                        this.EntradaTipo.Size = new System.Drawing.Size(168, 51);
                        this.EntradaTipo.TabIndex = 5;
                        this.EntradaTipo.TextKey = "1";
                        this.EntradaTipo.TextChanged += new System.EventHandler(this.EntradaTipo_TextChanged);
                        // 
                        // Label7
                        // 
                        this.Label7.Location = new System.Drawing.Point(0, 64);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(120, 24);
                        this.Label7.TabIndex = 4;
                        this.Label7.Text = "Tipo de Caja";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaNombre
                        // 
                        this.EntradaNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaNombre.Location = new System.Drawing.Point(124, 0);
                        this.EntradaNombre.Name = "EntradaNombre";
                        this.EntradaNombre.ReadOnly = false;
                        this.EntradaNombre.Size = new System.Drawing.Size(488, 24);
                        this.EntradaNombre.TabIndex = 1;
                        this.EntradaNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EntradaNombre_KeyPress);
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(0, 0);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(120, 24);
                        this.Label2.TabIndex = 0;
                        this.Label2.Text = "Nombre";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // Label4
                        // 
                        this.Label4.Location = new System.Drawing.Point(0, 184);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(120, 24);
                        this.Label4.TabIndex = 10;
                        this.Label4.Text = "Moneda";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaMoneda
                        // 
                        this.EntradaMoneda.CanCreate = true;
                        this.EntradaMoneda.Filter = "";
                        this.EntradaMoneda.Location = new System.Drawing.Point(124, 184);
                        this.EntradaMoneda.MaxLength = 200;
                        this.EntradaMoneda.Name = "EntradaMoneda";
                        this.EntradaMoneda.ReadOnly = false;
                        this.EntradaMoneda.Required = false;
                        this.EntradaMoneda.Size = new System.Drawing.Size(228, 24);
                        this.EntradaMoneda.TabIndex = 11;
                        this.EntradaMoneda.NombreTipo = "Lbl.Entidades.Moneda";
                        this.EntradaMoneda.Text = "0";
                        // 
                        // EntradaClaveBancaria
                        // 
                        this.EntradaClaveBancaria.Location = new System.Drawing.Point(124, 216);
                        this.EntradaClaveBancaria.MaxLength = 23;
                        this.EntradaClaveBancaria.Name = "EntradaClaveBancaria";
                        this.EntradaClaveBancaria.ReadOnly = false;
                        this.EntradaClaveBancaria.Size = new System.Drawing.Size(228, 24);
                        this.EntradaClaveBancaria.TabIndex = 13;
                        // 
                        // EtiquetaClaveBancaria
                        // 
                        this.EtiquetaClaveBancaria.Location = new System.Drawing.Point(0, 216);
                        this.EtiquetaClaveBancaria.Name = "EtiquetaClaveBancaria";
                        this.EtiquetaClaveBancaria.Size = new System.Drawing.Size(120, 24);
                        this.EtiquetaClaveBancaria.TabIndex = 12;
                        this.EtiquetaClaveBancaria.Text = "Clave Bancaria";
                        this.EtiquetaClaveBancaria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaTitular
                        // 
                        this.EntradaTitular.Location = new System.Drawing.Point(124, 32);
                        this.EntradaTitular.Name = "EntradaTitular";
                        this.EntradaTitular.ReadOnly = false;
                        this.EntradaTitular.Size = new System.Drawing.Size(436, 24);
                        this.EntradaTitular.TabIndex = 3;
                        // 
                        // label6
                        // 
                        this.label6.Location = new System.Drawing.Point(0, 32);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(120, 24);
                        this.label6.TabIndex = 2;
                        this.label6.Text = "Titular";
                        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaEstado
                        // 
                        this.EntradaEstado.AlwaysExpanded = true;
                        this.EntradaEstado.AutoSize = true;
                        this.EntradaEstado.Location = new System.Drawing.Point(124, 248);
                        this.EntradaEstado.Name = "EntradaEstado";
                        this.EntradaEstado.ReadOnly = false;
                        this.EntradaEstado.SetData = new string[] {
        "Activa|1",
        "Inactiva|0"};
                        this.EntradaEstado.Size = new System.Drawing.Size(168, 36);
                        this.EntradaEstado.TabIndex = 15;
                        this.EntradaEstado.TextKey = "1";
                        // 
                        // label8
                        // 
                        this.label8.Location = new System.Drawing.Point(0, 248);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(120, 24);
                        this.label8.TabIndex = 14;
                        this.label8.Text = "Estado";
                        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // Editar
                        // 
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.EntradaEstado);
                        this.Controls.Add(this.label8);
                        this.Controls.Add(this.EntradaTitular);
                        this.Controls.Add(this.label6);
                        this.Controls.Add(this.EntradaClaveBancaria);
                        this.Controls.Add(this.EtiquetaClaveBancaria);
                        this.Controls.Add(this.Label4);
                        this.Controls.Add(this.EntradaMoneda);
                        this.Controls.Add(this.EntradaNombre);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.EntradaTipo);
                        this.Controls.Add(this.Label7);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.EntradaBanco);
                        this.Controls.Add(this.EntradaNumero);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(615, 352);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                internal Lui.Forms.Label label6;
                internal Lui.Forms.Label label8;
        }
}
