using Lazaro.Orm.Mapping;
using System;
using System.Collections.Generic;

namespace Lazaro.Orm.Attributes
{
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
        public class Event : System.Attribute
        {
                public EventTypes Type { get; set; } = EventTypes.None;
        }
}
