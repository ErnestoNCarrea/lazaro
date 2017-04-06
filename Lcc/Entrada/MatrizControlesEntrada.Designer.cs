using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace Lcc.Entrada
{
        public partial class MatrizControlesEntrada<T>
        {
                /// <summary> 
                /// Variable del diseñador requerida.
                /// </summary>
                private System.ComponentModel.IContainer components = null;

                /// <summary> 
                /// Limpiar los recursos que se estén utilizando.
                /// </summary>
                /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
                protected override void Dispose(bool disposing)
                {
                        if (disposing && (components != null)) {
                                components.Dispose();
                        }
                        base.Dispose(disposing);
                }

                private void InitializeComponent()
                {
                        this.PanelGrilla = new Lui.Forms.Panel();
                        this.SuspendLayout();
                        // 
                        // PanelGrilla
                        // 
                        this.PanelGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.PanelGrilla.AutoScroll = true;
                        this.PanelGrilla.AutoScrollMargin = new System.Drawing.Size(20, 0);
                        this.PanelGrilla.Location = new System.Drawing.Point(0, 0);
                        this.PanelGrilla.Name = "PanelGrilla";
                        this.PanelGrilla.Size = new System.Drawing.Size(536, 180);
                        this.PanelGrilla.TabIndex = 999;
                        // 
                        // MatrizControlesEntrada
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                        this.AutoScrollMargin = new System.Drawing.Size(4, 4);
                        this.Controls.Add(this.PanelGrilla);
                        this.Name = "MatrizControlesEntrada";
                        this.Size = new System.Drawing.Size(536, 180);
                        this.ResumeLayout(false);

                }

                internal Lui.Forms.Panel PanelGrilla;
        }
}
