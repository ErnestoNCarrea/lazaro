using System;
using System.Collections.Generic;

namespace Lfx.Types
{
        /// <summary>
        /// Describe una excepción en el dominio de la lógica de negocio, para diferenciarlas de las excepciones de la aplicación.
        /// </summary>
        public class DomainException : Exception
        {
                public DomainException(string message)
                        : base(message)
                {
                }
        }
}
