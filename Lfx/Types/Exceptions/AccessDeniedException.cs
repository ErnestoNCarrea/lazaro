using System;

namespace Lfx.Types.Exceptions
{
        public class AccessDeniedException : Lfx.Types.Exceptions.Exception
        {
                public AccessDeniedException(string message) : base(message) { }
                public AccessDeniedException() : this("Acceso denegado") { }
        }
}
