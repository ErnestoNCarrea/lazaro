using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Cajas.Conceptos
{
        public partial class Editar
        {
                private System.ComponentModel.IContainer components = null;

                internal Lui.Forms.Label Label1;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.Label Label3;
                internal Lui.Forms.TextBox EntradaNombre;
                internal Lui.Forms.ComboBox EntradaDireccion;
                internal Lui.Forms.Label label4;
                internal Lui.Forms.TextBox EntradaCodigo;
                internal Lui.Forms.ComboBox EntradaGrupo;

                #region Windows Form Designer generated code

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
                        this.Label2 = new Lui.Forms.Label();
                        this.Label3 = new Lui.Forms.Label();
                        this.EntradaNombre = new Lui.Forms.TextBox();
                        this.EntradaDireccion = new Lui.Forms.ComboBox();
                        this.EntradaGrupo = new Lui.Forms.ComboBox();
                        this.EntradaCodigo = new Lui.Forms.TextBox();
                        this.label4 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(0, 32);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(104, 24);
                        this.Label1.TabIndex = 4;
                        this.Label1.Text = "Nombre";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(0, 64);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(104, 24);
                        this.Label2.TabIndex = 6;
                        this.Label2.Text = "Dirección";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(-4, 128);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(100, 24);
                        this.Label3.TabIndex = 8;
                        this.Label3.Text = "Tipo";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaNombre
                        // 
                        this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaNombre.Location = new System.Drawing.Point(104, 32);
                        this.EntradaNombre.Name = "EntradaNombre";
                        this.EntradaNombre.ReadOnly = false;
                        this.EntradaNombre.Size = new System.Drawing.Size(504, 24);
                        this.EntradaNombre.TabIndex = 5;
                        // 
                        // EntradaDireccion
                        // 
                        this.EntradaDireccion.AlwaysExpanded = true;
                        this.EntradaDireccion.AutoSize = true;
                        this.EntradaDireccion.Location = new System.Drawing.Point(104, 64);
                        this.EntradaDireccion.Name = "EntradaDireccion";
                        this.EntradaDireccion.ReadOnly = false;
                        this.EntradaDireccion.SetData = new string[] {
        "Ambas|0",
        "Entrada|1",
        "Salida|2"};
                        this.EntradaDireccion.Size = new System.Drawing.Size(180, 51);
                        this.EntradaDireccion.TabIndex = 7;
                        this.EntradaDireccion.TextKey = "0";
                        // 
                        // EntradaGrupo
                        // 
                        this.EntradaGrupo.AlwaysExpanded = true;
                        this.EntradaGrupo.AutoSize = true;
                        this.EntradaGrupo.Location = new System.Drawing.Point(100, 128);
                        this.EntradaGrupo.Name = "EntradaGrupo";
                        this.EntradaGrupo.ReadOnly = false;
                        this.EntradaGrupo.SetData = new string[] {
        "Ninguno|0",
        "Cobros|110",
        "Otros ingresos|100",
        "Gastos fijos|230",
        "Gastos variables|240",
        "Otros gastos|200",
        "Pérdida|260",
        "Reinversión|250",
        "Costo materiales|210",
        "Costo capital|220",
        "Sueldos y salarios|231",
        "Movimientos y ajustes|300"};
                        this.EntradaGrupo.Size = new System.Drawing.Size(284, 81);
                        this.EntradaGrupo.TabIndex = 9;
                        this.EntradaGrupo.TextKey = "200";
                        // 
                        // EntradaCodigo
                        // 
                        this.EntradaCodigo.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaCodigo.Enabled = false;
                        this.EntradaCodigo.Location = new System.Drawing.Point(104, 0);
                        this.EntradaCodigo.Name = "EntradaCodigo";
                        this.EntradaCodigo.ReadOnly = false;
                        this.EntradaCodigo.Size = new System.Drawing.Size(76, 24);
                        this.EntradaCodigo.TabIndex = 3;
                        this.EntradaCodigo.Text = "0";
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(0, 0);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(104, 24);
                        this.label4.TabIndex = 0;
                        this.label4.Text = "Código";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Editar
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                        this.AutoSize = true;
                        this.Controls.Add(this.EntradaCodigo);
                        this.Controls.Add(this.EntradaGrupo);
                        this.Controls.Add(this.EntradaDireccion);
                        this.Controls.Add(this.EntradaNombre);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.Label2);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(620, 214);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion
        }
}
