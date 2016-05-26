using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lcc.Entrada
{
        public interface IControlEntrada
        {
                bool IsEmpty { get; }
                Size Size { get; set; }
                Padding Margin { get; }
                Point Location { get; set; }
                AnchorStyles Anchor { get; set; }
                int TabIndex { get; set; }
                Control Parent { get; set; }
        }
}
