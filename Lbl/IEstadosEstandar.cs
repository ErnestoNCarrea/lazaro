using System;
using System.Collections.Generic;

namespace Lbl
{
        /// <summary>
        /// Describe un elemento que puede ser desactivado, poniendo su estado en cero.
        /// </summary>
        public interface IEstadosEstandar
        {
                Lbl.Estados EstadoEstandar { get; set; }
                void Activar(bool activar);
        }
}
