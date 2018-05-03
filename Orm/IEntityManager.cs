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
                EntityCollection<T> FindAll<T>(string orderBy) where T : new();
                EntityCollection<T> FindBy<T>(qGen.Where where, string orderBy = null, qGen.Window window = null) where T : new();
                T FindOneBy<T>(qGen.Where where, string orderBy = null, qGen.Window window = null) where T : new();

                void Persist(object entity);
        }
}
