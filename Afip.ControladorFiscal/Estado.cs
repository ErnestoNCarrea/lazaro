using System;
using System.Collections.Generic;
using System.Text;

namespace Afip.ControladorFiscal
{
        /// <summary>
        /// El estado del controlador fiscal.
        /// </summary>
        public class Estado
        {
                public long CodigoEstado;

                public bool Bit(int bitNumber)
                {
                        return (CodigoEstado & (long)Math.Pow(2, bitNumber)) != 0;
                }
                public bool BanderaDeError
                {
                        get
                        {
                                return this.Bit(15);
                        }
                }
        }
}
