using System;
using System.Collections.Generic;

namespace Lazaro.Orm
{
        public class EntityCollection<T> : List<T> where T : new()
        {
        }
}
