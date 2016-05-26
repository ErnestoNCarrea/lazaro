using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Archivos.Salida
{
        /// <summary>
        /// Describe un archivo con una lista de cobros o pagos realizados mediante débito de una cuenta bancaria.
        /// </summary>
        public abstract class ArchivoSalidaVentas : Lbl.Archivos.Salida.ArchivoSalidaConComprobantesFacturables
        {
                public ArchivoSalidaVentas()
                        : base()
                { }

                public ArchivoSalidaVentas(Lfx.Types.OperationProgress progreso)
                        : base(progreso) { }
        }
}
