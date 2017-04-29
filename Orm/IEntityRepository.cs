using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazaro.Orm
{
        public interface IEntityRepository<T> where T : new()
        {
                T Find(object primaryKeyId);
                List<T> FindAll(string orderBy);
                List<T> FindBy(qGen.Where where, string orderBy);
        }
}
