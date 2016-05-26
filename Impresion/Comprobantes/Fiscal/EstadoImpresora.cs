using System;
using System.Collections.Generic;
using System.Text;

namespace Lazaro.Impresion.Comprobantes.Fiscal
{
        public class EstadoImpresora
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
