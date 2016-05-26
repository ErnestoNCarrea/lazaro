using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Archivos.Salida
{
        /// <summary>
        /// Describe un archivo con una lista de cobris i pagos realizados mediante débito de una cuenta bancaria.
        /// </summary>
        public abstract class ArchivoSalidaCompras : Lbl.Archivos.Salida.ArchivoSalidaConComprobantesFacturables
        {
                public ArchivoSalidaCompras()
                        : base()
                { }
        }
}
