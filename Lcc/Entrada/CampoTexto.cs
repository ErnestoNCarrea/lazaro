using System;
using System.Collections.Generic;

namespace Lcc.Entrada
{
        public class CampoTexto : Lui.Forms.TextBox, IControlEntrada
        {
                public bool IsEmpty
                {
                        get{
                                return this.Text == null || this.Text.Length == 0;
                        }
                }

                private void InitializeComponent()
                {
                        this.SuspendLayout();
                        // 
                        // TextBox1
                        // 
                        this.TextBox1.ForeColor = System.Drawing.Color.Black;
                        this.TextBox1.Location = new System.Drawing.Point(5, 3);
                        // 
                        // CampoTexto
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                        this.Name = "CampoTexto";
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }
        }
}
