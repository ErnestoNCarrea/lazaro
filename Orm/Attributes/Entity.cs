using System;
using System.Collections.Generic;

namespace Lazaro.Orm.Attributes
{
        [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
        public class Entity : System.Attribute
        {
                public string TableName { get; set; }

                public string IdFieldName { get; set; }
        }
}
