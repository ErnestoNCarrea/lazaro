using System;
using System.Diagnostics;
using System.Reflection;

namespace Lazaro.Orm.Mapping
{
        [DebuggerDisplay("Type = {Type}, Class method = {MethodName}")]
        public class EventMetadata
        {
                public EventTypes Type { get; internal set; }
                public string MethodName { get; internal set; }

                public MethodInfo MethodInfo { get; internal set; }
        }
}
