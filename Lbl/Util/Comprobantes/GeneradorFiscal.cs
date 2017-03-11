using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazaro.Base.Util.Comprobantes
{
        /// <summary>
        /// Un generador de comprobantes que obtiene numeración de un controlador fiscal homologado
        /// de AFIP.
        /// 
        /// Este generador también imprime en el mismo acto.
        /// </summary>
        public abstract class GeneradorFiscal : Generador
        {
                public GeneradorFiscal(Lbl.Comprobantes.ComprobanteFacturable comprobante)
                        : base(comprobante)
                { }
        }
}
