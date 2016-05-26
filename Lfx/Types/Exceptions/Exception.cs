using System;

namespace Lfx.Types.Exceptions
{
        public class Exception : ApplicationException
        {
                public Exception(string message) : base(message) { }
        }
}
