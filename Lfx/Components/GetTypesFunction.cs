using System;
using System.Collections.Generic;

namespace Lfx.Components
{
        /// <summary>
        /// Esta función debe ser implementada por todos los componentes, y se utiliza para obtener una lista de los tipos que registra el componente.
        /// </summary>
        public class GetTypesFunction : Function
        {
                public GetTypesFunction()
                {
                        this.FunctionType = FunctionTypes.Executable;
                }
        }
}
