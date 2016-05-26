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

        }
}
