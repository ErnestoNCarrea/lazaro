using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Recibos
{
        public partial class EditarCobro : Lui.Forms.DialogForm
        {
                #region Código generado por el Diseñador de Windows Forms

                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }

                        base.Dispose(disposing);
                }

                private System.ComponentModel.Container components = null;

                internal void InitializeComponent()
                {
                        this.Cobro = new Lcc.Edicion.Comprobantes.Cobro();
                        this.SuspendLayout();
                        // 
                        // Cobro
                        // 
                        this.Cobro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Cobro.Font = new System.Drawing.Font("Segoe UI", 9.75F);
                        this.Cobro.FormaDePagoEditable = true;
                        this.Cobro.FormaDePagoVisible = true;
                        this.Cobro.ImporteEditable = true;
                        this.Cobro.ImporteVisible = true;
                        this.Cobro.Location = new System.Drawing.Point(24, 24);
                        this.Cobro.Name = "Cobro";
                        this.Cobro.ObsEditable = true;
                        this.Cobro.ObsVisible = true;
                        this.Cobro.Size = new System.Drawing.Size(464, 361);
                        this.Cobro.TabIndex = 0;
                        this.Cobro.Text = "Detalles del cobro";
                        this.Cobro.TituloVisible = true;
                        // 
                        // EditarCobro
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.ClientSize = new System.Drawing.Size(510, 452);
                        this.Controls.Add(this.Cobro);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "EditarCobro";
                        this.Text = "Cobro";
                        this.Controls.SetChildIndex(this.Cobro, 0);
                        this.ResumeLayout(false);

                }

                #endregion

                public Lcc.Edicion.Comprobantes.Cobro Cobro;
        }
}
