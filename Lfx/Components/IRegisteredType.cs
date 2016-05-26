using System;

namespace Lfx.Components
{
        public interface IRegisteredType
        {
                ActionCollection Actions { get; set; }
                Type LblType { get; set; }
        }
}
