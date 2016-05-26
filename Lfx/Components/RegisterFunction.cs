using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Components
{
        /// <summary>
        /// Esta función debe ser implementada por todos los componentes, y se utiliza para registrar (incializar) el componente.
        /// </summary>
        public class RegisterFunction : Function
        {
                public RegisterFunction()
                {
                        this.FunctionType = FunctionTypes.Executable;
                }
        }
}
