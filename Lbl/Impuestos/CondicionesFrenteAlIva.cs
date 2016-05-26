using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Impuestos
{
        public enum CondicionesFrenteAlIva
        {
                ConsumidorFinal = 1,
                ResponsableInscripto = 2,
                ResponsableNoInscripto = 3,
                ResponsableMonotributista = 4,
                Exento = 5,
                NoResponsable = 6,
                NoCategorizado = 7
        }
}
