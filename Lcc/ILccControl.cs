using System;
using System.Collections.Generic;
using System.Text;

namespace Lcc
{
        public interface ILccControl
        {
                /// <summary>
                /// Indica si el control permite navegación mejorada.
                /// </summary>
                [System.ComponentModel.Category("Comportamiento")]
                bool AutoNav
                {
                        get;
                        set;
                }

                /// <summary>
                /// Indica si el control es sólo de lectura.
                /// </summary>
                bool ReadOnly
                {
                        get;
                        set;
                }
        }
}
