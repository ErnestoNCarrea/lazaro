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
        }
}
