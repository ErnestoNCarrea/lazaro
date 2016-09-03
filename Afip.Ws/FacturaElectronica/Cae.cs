using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afip.Ws.FacturaElectronica
{
        public class Cae
        {
                /// <summary>
                /// El número de CAE.
                /// </summary>
                public string CodigoCae;

                /// <summary>
                /// La fecha de vencimiento del CAE.
                /// </summary>
                public DateTime Vencimiento;

                /// <summary>
                /// Las observaciones.
                /// </summary>
                public string Obs;

                /// <summary>
                /// Devuelve True si este CAE todavía es válido.
                /// </summary>
                public bool TodaviaEstaVigente()
                {
                        return this.Vencimiento > System.DateTime.Now;
                }
        }
}
