using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Lcc.Entrada
{
        public class ControlEntrada : ControlDeDatos, IControlEntrada
        {
                public virtual bool IsEmpty
                {
                        get
                        {
                                return this.Text.Length == 0;
                        }
                }

                private void InitializeComponent()
                {
                        this.SuspendLayout();
                        // 
                        // ControlEntrada
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                        this.Name = "ControlEntrada";
                        this.ResumeLayout(false);

                }
        }
}
