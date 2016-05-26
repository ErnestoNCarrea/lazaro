using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Articulos.Rubros
{
        public partial class Editar
        {
                internal Lui.Forms.Label label9;
                internal Lui.Forms.TextBox EntradaNombre;
                internal Lui.Forms.Label Label5;
                private Lcc.Entrada.CodigoDetalle EntradaAlicuota;

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
                        this.EntradaAlicuota = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaNombre = new Lui.Forms.TextBox();
                        this.Label5 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // label9
                        // 
                        this.label9.Location = new System.Drawing.Point(0, 32);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(116, 24);
                        this.label9.TabIndex = 2;
                        this.label9.Text = "Alícuota";
                        this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaAlicuota
                        // 
                        this.EntradaAlicuota.CanCreate = true;
                        this.EntradaAlicuota.Filter = "";
                        this.EntradaAlicuota.Location = new System.Drawing.Point(116, 32);
                        this.EntradaAlicuota.MaxLength = 200;
                        this.EntradaAlicuota.Name = "EntradaAlicuota";
                        this.EntradaAlicuota.PlaceholderText = "Sin especificar";
                        this.EntradaAlicuota.ReadOnly = false;
                        this.EntradaAlicuota.Required = true;
                        this.EntradaAlicuota.Size = new System.Drawing.Size(388, 24);
                        this.EntradaAlicuota.TabIndex = 3;
                        this.EntradaAlicuota.NombreTipo = "Lbl.Impuestos.Alicuota";
                        this.EntradaAlicuota.Text = "0";
                        // 
                        // EntradaNombre
                        // 
                        this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaNombre.Location = new System.Drawing.Point(116, 0);
                        this.EntradaNombre.Name = "EntradaNombre";
                        this.EntradaNombre.ReadOnly = false;
                        this.EntradaNombre.Size = new System.Drawing.Size(388, 24);
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
                        // Editar
                        // 
                        this.Controls.Add(this.label9);
                        this.Controls.Add(this.EntradaAlicuota);
                        this.Controls.Add(this.EntradaNombre);
                        this.Controls.Add(this.Label5);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(488, 237);
                        this.ResumeLayout(false);

                }

                #endregion
        }
}
