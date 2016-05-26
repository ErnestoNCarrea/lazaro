using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Tareas.Tipos
{
        public partial class Editar
        {
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

                #region Designer generated code

                private void InitializeComponent()
                {
                        this.EntradaNombre = new Lui.Forms.TextBox();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaObs = new Lui.Forms.TextBox();
                        this.Label13 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaNombre
                        // 
                        this.EntradaNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaNombre.Location = new System.Drawing.Point(116, 0);
                        this.EntradaNombre.Name = "EntradaNombre";
                        this.EntradaNombre.ReadOnly = false;
                        this.EntradaNombre.Size = new System.Drawing.Size(524, 24);
                        this.EntradaNombre.TabIndex = 1;
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(0, 0);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(120, 24);
                        this.Label1.TabIndex = 0;
                        this.Label1.Text = "Nombre";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaObs
                        // 
                        this.EntradaObs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaObs.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaObs.Location = new System.Drawing.Point(116, 28);
                        this.EntradaObs.MultiLine = true;
                        this.EntradaObs.Name = "EntradaObs";
                        this.EntradaObs.ReadOnly = false;
                        this.EntradaObs.Size = new System.Drawing.Size(524, 72);
                        this.EntradaObs.TabIndex = 3;
                        this.EntradaObs.PlaceholderText = "Descripción larga";
                        // 
                        // Label13
                        // 
                        this.Label13.Location = new System.Drawing.Point(0, 28);
                        this.Label13.Name = "Label13";
                        this.Label13.Size = new System.Drawing.Size(116, 24);
                        this.Label13.TabIndex = 2;
                        this.Label13.Text = "Observaciones";
                        this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Editar
                        // 
                        this.Controls.Add(this.EntradaObs);
                        this.Controls.Add(this.Label13);
                        this.Controls.Add(this.EntradaNombre);
                        this.Controls.Add(this.Label1);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(640, 400);
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.EntradaNombre, 0);
                        this.Controls.SetChildIndex(this.Label13, 0);
                        this.Controls.SetChildIndex(this.EntradaObs, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }
                #endregion

                private Lui.Forms.TextBox EntradaNombre;
                private Lui.Forms.Label Label1;
                internal Lui.Forms.TextBox EntradaObs;
                internal Lui.Forms.Label Label13;

        }
}
