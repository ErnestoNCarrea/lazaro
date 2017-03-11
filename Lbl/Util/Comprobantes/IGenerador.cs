using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazaro.Base.Util.Comprobantes
{
        public interface IGenerador
        {
                Lbl.Comprobantes.Comprobante Comprobante { get; set; }
        }
}
