using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lui.Forms
{
        public interface IControl
        {
                Size Size { get; set; }
                Point Location { get; set; }
        }
}
