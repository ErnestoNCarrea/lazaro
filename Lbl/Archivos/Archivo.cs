using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Archivos
{
        /// <summary>
        /// Clase base para archivos de entrada o salida.
        /// </summary>
        public abstract class Archivo
        {
                public Lfx.Types.OperationProgress Progreso { get; set; }
                protected int LineCounter = 0;

                public Archivo() { }
                public Archivo(Lfx.Types.OperationProgress progreso)
                        : this()
                {
                        this.Progreso = progreso;
                }
        }
}
