using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Personas.Grupos
{
        public partial class Editar
        {
                private System.ComponentModel.IContainer components = null;

                /// <summary>
                /// Limpiar los recursos que se estén utilizando.
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

                #region Código generado por el diseñador
                /// <summary>
                /// Método necesario para admitir el Diseñador. No se puede modificar
                /// el contenido del método con el editor de código.
                /// </summary>
                private void InitializeComponent()
                {
                        this.EntradaDescuento = new Lui.Forms.TextBox();
                        this.label4 = new Lui.Forms.Label();
                        this.EntradaNombre = new Lui.Forms.TextBox();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaPredet = new Lui.Forms.ComboBox();
                        this.label2 = new Lui.Forms.Label();
                        this.EntradaGrupo = new Lcc.Entrada.CodigoDetalle();
                        this.Label16 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaDescuento
                        // 
                        this.EntradaDescuento.DataType = Lui.Forms.DataTypes.Float;
                        this.EntradaDescuento.Location = new System.Drawing.Point(120, 64);
                        this.EntradaDescuento.Name = "EntradaDescuento";
                        this.EntradaDescuento.Size = new System.Drawing.Size(88, 24);
                        this.EntradaDescuento.Sufijo = "%";
                        this.EntradaDescuento.TabIndex = 5;
                        this.EntradaDescuento.Text = "0.0000";
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(0, 64);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(120, 24);
                        this.label4.TabIndex = 4;
                        this.label4.Text = "Descuento";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaNombre
                        // 
                        this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaNombre.Location = new System.Drawing.Point(120, 32);
                        this.EntradaNombre.Name = "EntradaNombre";
                        this.EntradaNombre.Size = new System.Drawing.Size(437, 24);
                        this.EntradaNombre.TabIndex = 3;
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(0, 32);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(120, 24);
                        this.Label1.TabIndex = 2;
                        this.Label1.Text = "Nombre";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaPredet
                        // 
                        this.EntradaPredet.AlwaysExpanded = true;
                        this.EntradaPredet.AutoSize = true;
                        this.EntradaPredet.Location = new System.Drawing.Point(120, 96);
                        this.EntradaPredet.Name = "EntradaPredet";
                        this.EntradaPredet.ReadOnly = false;
                        this.EntradaPredet.SetData = new string[] {
        "Sí|1",
        "No|0"};
                        this.EntradaPredet.Size = new System.Drawing.Size(88, 40);
                        this.EntradaPredet.TabIndex = 7;
                        this.EntradaPredet.TextKey = "0";
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(0, 96);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(120, 24);
                        this.label2.TabIndex = 6;
                        this.label2.Text = "Predeterminado";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaGrupo
                        // 
                        this.EntradaGrupo.AutoTab = true;
                        this.EntradaGrupo.CanCreate = true;
                        this.EntradaGrupo.Filter = "";
                        this.EntradaGrupo.Location = new System.Drawing.Point(120, 0);
                        this.EntradaGrupo.MaxLength = 200;
                        this.EntradaGrupo.Name = "EntradaGrupo";
                        this.EntradaGrupo.PlaceholderText = "Ninguno";
                        this.EntradaGrupo.ReadOnly = false;
                        this.EntradaGrupo.Required = false;
                        this.EntradaGrupo.Size = new System.Drawing.Size(440, 24);
                        this.EntradaGrupo.TabIndex = 1;
                        this.EntradaGrupo.NombreTipo = "Lbl.Personas.Grupo";
                        this.EntradaGrupo.Text = "0";
                        // 
                        // Label16
                        // 
                        this.Label16.Location = new System.Drawing.Point(0, 0);
                        this.Label16.Name = "Label16";
                        this.Label16.Size = new System.Drawing.Size(120, 24);
                        this.Label16.TabIndex = 0;
                        this.Label16.Text = "Depende de";
                        this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Editar
                        // 
                        this.AutoSize = true;
                        this.Controls.Add(this.Label16);
                        this.Controls.Add(this.EntradaGrupo);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.EntradaPredet);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.EntradaDescuento);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.EntradaNombre);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(565, 141);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }
                #endregion


                internal Lui.Forms.Label label4;
                internal Lui.Forms.TextBox EntradaNombre;
                internal Lui.Forms.Label Label1;
                internal Lui.Forms.TextBox EntradaDescuento;
                internal Lui.Forms.ComboBox EntradaPredet;
                internal Lcc.Entrada.CodigoDetalle EntradaGrupo;
                internal Lui.Forms.Label label2;
                internal Lui.Forms.Label Label16;
        }
}
