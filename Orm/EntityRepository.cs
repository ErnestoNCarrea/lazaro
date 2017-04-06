using System;
using System.Collections.Generic;

namespace Lazaro.Orm
{
        public class EntityRepository<T> : List<T>, IEnumerable<T> where T : new()
        {

        }
}
