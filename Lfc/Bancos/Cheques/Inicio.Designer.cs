using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Bancos.Cheques
{
        public partial class Inicio
        {
                #region Código generado por el Diseñador de Windows Forms

                // Limpiar los recursos que se están utilizando.
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

                private void InitializeComponent()
                {
                        this.DepositarPagar = new Lui.Forms.Button();
                        this.BotonEfectivizar = new Lui.Forms.Button();
                        this.SuspendLayout();
                        // 
                        // DepositarPagar
                        // 
                        this.DepositarPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.DepositarPagar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.DepositarPagar.Image = null;
                        this.DepositarPagar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.DepositarPagar.Location = new System.Drawing.Point(12, 283);
                        this.DepositarPagar.Name = "DepositarPagar";
                        this.DepositarPagar.Size = new System.Drawing.Size(104, 64);
                        this.DepositarPagar.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.DepositarPagar.Subtext = "F5";
                        this.DepositarPagar.TabIndex = 56;
                        this.DepositarPagar.Text = "Depositar";
                        this.DepositarPagar.Click += new System.EventHandler(this.DepositarPagar_Click);
                        // 
                        // BotonEfectivizar
                        // 
                        this.BotonEfectivizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonEfectivizar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonEfectivizar.Image = null;
                        this.BotonEfectivizar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonEfectivizar.Location = new System.Drawing.Point(12, 283);
                        this.BotonEfectivizar.Name = "BotonEfectivizar";
                        this.BotonEfectivizar.Size = new System.Drawing.Size(104, 64);
                        this.BotonEfectivizar.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.BotonEfectivizar.Subtext = "F5";
                        this.BotonEfectivizar.TabIndex = 56;
                        this.BotonEfectivizar.Text = "Efetivizar";
                        this.BotonEfectivizar.Click += new System.EventHandler(this.BotonEfectivizar_Click);
                        // 
                        // Inicio
                        // 
                        this.PanelAcciones.Controls.Add(this.DepositarPagar);
                        this.PanelAcciones.Controls.Add(this.BotonEfectivizar);
                        this.Name = "Listado de cheques";
                        this.ResumeLayout(false);

                }

                #endregion

                internal Lui.Forms.Button DepositarPagar;
                internal Lui.Forms.Button BotonEfectivizar;
        }
}
