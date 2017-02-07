using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lfx.Components.Attributes
{
        [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
        public class Component : System.Attribute
        {
                public string Name { get; set; }
        }
}
