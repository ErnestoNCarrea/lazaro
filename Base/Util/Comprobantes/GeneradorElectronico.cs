using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazaro.Base.Util.Comprobantes
{
        /// <summary>
        /// Un generador de comprobantes que obtiene numeración y autorización a través de internet
        /// mediate servicios web de AFIP.
        /// </summary>
        public abstract class GeneradorElectronico : Generador
        {
                public GeneradorElectronico(Lbl.Comprobantes.ComprobanteFacturable comprobante)
                        : base(comprobante)
                { }
        }
}
