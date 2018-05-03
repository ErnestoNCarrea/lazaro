using System;
using System.Collections.Generic;

namespace Lazaro.Orm
{
        interface IEntityCollection<T> : IList<T> where T : new()
        {
        }
}
