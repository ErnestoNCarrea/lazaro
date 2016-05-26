using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Archivos.Salida
{
        interface IArchivoSalida
        {
                /// <summary>
                /// Genera el encabezado del archivo.
                /// </summary>
                string GenerarEncabezado(int lineNumber);

                /// <summary>
                /// Genera el pie del archivo.
                /// </summary>
                string GenerarPie(int lineNumber);
        }
}
