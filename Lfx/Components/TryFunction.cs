using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Components
{
        /// <summary>
        /// Esta función debe ser implementada por todos los componentes, y se utiliza para decidir si el componente se carga o no al inicio de la aplicación.
        /// </summary>
        public class TryFunction : Function
        {
                public TryFunction()
                {
                        this.FunctionType = FunctionTypes.Executable;
                }
        }
}
