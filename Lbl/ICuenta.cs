using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl
{
        public interface ICuenta
        {
                decimal ObtenerSaldo(bool forUpdate);

                void Recalcular();
        }
}
