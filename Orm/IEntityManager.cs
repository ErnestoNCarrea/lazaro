using System;
using System.Collections.Generic;
using Lazaro.Orm.Data;
using qGen;

namespace Lazaro.Orm
{
        public interface IEntityManager
        {
                IConnection Connection { get; set; }

                T Find<T>(object primaryKeyId) where T : new();
                List<T> FindAll<T>(string orderBy) where T : new();
                List<T> FindBy<T>(qGen.Where where, string orderBy) where T : new();
        }
}
