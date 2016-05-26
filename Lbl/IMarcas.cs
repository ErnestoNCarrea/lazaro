using System;
using System.Collections.Generic;

namespace Lbl
{
        [Flags]
        public enum Marcas
        {
                Ninguna = 0,
                Eliminado = 1,
                Protegido = 2,
                Destacado = 4,
                RequiereAtencion = 8
        }

        public interface IMarcas
        {
                Marcas Marcas { get; set; }
        }
}
