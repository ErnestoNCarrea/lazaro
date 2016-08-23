using System;
using System.Collections.Generic;
using System.Text;

namespace Afip.ControladorFiscal
{
        /// <summary>
        /// Los modelos soportados de controlador fiscal.
        /// </summary>
        public enum Modelos
        {
                Desconocido = 0,
                Emulacion = 1,
                HasarGenerico = 100,
                HasarTiquedora = 110,
                EpsonGenerico = 300,
                EpsonTiquedora = 310
        }
}
