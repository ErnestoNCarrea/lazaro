using System;
using System.Collections.Generic;

namespace Lazaro.Orm.Attributes
{
        [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
        public class Model : System.Attribute
        {
                public string Name { get; set; }
        }
}
