using System;
using System.Collections.Generic;
using System.Text;

namespace Lui.Forms
{
        public partial class Calendar
        {
                internal System.Windows.Forms.Label EtiquetaMes;
                internal System.Windows.Forms.Label EtiquetaDia7;
                internal System.Windows.Forms.Label EtiquetaDia6;
                internal System.Windows.Forms.Label EtiquetaDia5;
                internal System.Windows.Forms.Label EtiquetaDia4;
                internal System.Windows.Forms.Label EtiquetaDia3;
                internal System.Windows.Forms.Label EtiquetaDia2;
                internal System.Windows.Forms.Label EtiquetaDia1;
                internal System.Windows.Forms.PictureBox PanelFondo;

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
                        this.EtiquetaMes = new System.Windows.Forms.Label();
                        this.EtiquetaDia7 = new System.Windows.Forms.Label();
                        this.EtiquetaDia6 = new System.Windows.Forms.Label();
                        this.EtiquetaDia5 = new System.Windows.Forms.Label();
                        this.EtiquetaDia4 = new System.Windows.Forms.Label();
                        this.EtiquetaDia3 = new System.Windows.Forms.Label();
                        this.EtiquetaDia2 = new System.Windows.Forms.Label();
                        this.EtiquetaDia1 = new System.Windows.Forms.Label();
                        this.PanelFondo = new System.Windows.Forms.PictureBox();
                        this.SuspendLayout();
                        // 
                        // lblMes
                        // 
                        this.EtiquetaMes.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.EtiquetaMes.BackColor = this.DisplayStyle.BackgroundColor;
                        this.EtiquetaMes.Location = new System.Drawing.Point(8, 8);
                        this.EtiquetaMes.Name = "lblMes";
                        this.EtiquetaMes.Size = new System.Drawing.Size(220, 24);
                        this.EtiquetaMes.TabIndex = 101;
                        this.EtiquetaMes.Text = "Septiembre de 2004";
                        this.EtiquetaMes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // lblDia7
                        // 
                        this.EtiquetaDia7.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.EtiquetaDia7.Location = new System.Drawing.Point(200, 36);
                        this.EtiquetaDia7.Name = "lblDia7";
                        this.EtiquetaDia7.Size = new System.Drawing.Size(28, 20);
                        this.EtiquetaDia7.TabIndex = 100;
                        this.EtiquetaDia7.Text = "S";
                        this.EtiquetaDia7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // lblDia6
                        // 
                        this.EtiquetaDia6.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.EtiquetaDia6.Location = new System.Drawing.Point(168, 36);
                        this.EtiquetaDia6.Name = "lblDia6";
                        this.EtiquetaDia6.Size = new System.Drawing.Size(28, 20);
                        this.EtiquetaDia6.TabIndex = 99;
                        this.EtiquetaDia6.Text = "Vi";
                        this.EtiquetaDia6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // lblDia5
                        // 
                        this.EtiquetaDia5.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.EtiquetaDia5.Location = new System.Drawing.Point(136, 36);
                        this.EtiquetaDia5.Name = "lblDia5";
                        this.EtiquetaDia5.Size = new System.Drawing.Size(28, 20);
                        this.EtiquetaDia5.TabIndex = 98;
                        this.EtiquetaDia5.Text = "Ju";
                        this.EtiquetaDia5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // lblDia4
                        // 
                        this.EtiquetaDia4.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.EtiquetaDia4.Location = new System.Drawing.Point(104, 36);
                        this.EtiquetaDia4.Name = "lblDia4";
                        this.EtiquetaDia4.Size = new System.Drawing.Size(28, 20);
                        this.EtiquetaDia4.TabIndex = 97;
                        this.EtiquetaDia4.Text = "Mi";
                        this.EtiquetaDia4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // lblDia3
                        // 
                        this.EtiquetaDia3.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.EtiquetaDia3.Location = new System.Drawing.Point(72, 36);
                        this.EtiquetaDia3.Name = "lblDia3";
                        this.EtiquetaDia3.Size = new System.Drawing.Size(28, 20);
                        this.EtiquetaDia3.TabIndex = 96;
                        this.EtiquetaDia3.Text = "Ma";
                        this.EtiquetaDia3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // lblDia2
                        // 
                        this.EtiquetaDia2.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.EtiquetaDia2.Location = new System.Drawing.Point(40, 36);
                        this.EtiquetaDia2.Name = "lblDia2";
                        this.EtiquetaDia2.Size = new System.Drawing.Size(28, 20);
                        this.EtiquetaDia2.TabIndex = 95;
                        this.EtiquetaDia2.Text = "Lu";
                        this.EtiquetaDia2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // lblDia1
                        // 
                        this.EtiquetaDia1.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.EtiquetaDia1.Location = new System.Drawing.Point(8, 36);
                        this.EtiquetaDia1.Name = "lblDia1";
                        this.EtiquetaDia1.Size = new System.Drawing.Size(28, 20);
                        this.EtiquetaDia1.TabIndex = 94;
                        this.EtiquetaDia1.Text = "Do";
                        this.EtiquetaDia1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // pctFondo
                        // 
                        this.PanelFondo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
                        this.PanelFondo.Location = new System.Drawing.Point(4, 4);
                        this.PanelFondo.Name = "pctFondo";
                        this.PanelFondo.Size = new System.Drawing.Size(228, 204);
                        this.PanelFondo.TabIndex = 102;
                        this.PanelFondo.TabStop = false;
                        // 
                        // Calendar
                        // 
                        this.Controls.Add(this.EtiquetaMes);
                        this.Controls.Add(this.EtiquetaDia7);
                        this.Controls.Add(this.EtiquetaDia6);
                        this.Controls.Add(this.EtiquetaDia5);
                        this.Controls.Add(this.EtiquetaDia4);
                        this.Controls.Add(this.EtiquetaDia3);
                        this.Controls.Add(this.EtiquetaDia2);
                        this.Controls.Add(this.EtiquetaDia1);
                        this.Controls.Add(this.PanelFondo);
                        this.DockPadding.All = 2;
                        this.Name = "Calendar";
                        this.Size = new System.Drawing.Size(236, 212);
                        this.ResumeLayout(false);
                        base.Resize += new System.EventHandler(Calendar_Resize);
                }


                #endregion
        }
}
