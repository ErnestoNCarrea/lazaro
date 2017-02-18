using System;
using System.Collections.Generic;

namespace Lazaro.Orm.Attributes
{
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
        public class ManyToMany : Association
        {
        }
}
