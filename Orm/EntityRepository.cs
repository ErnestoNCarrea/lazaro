using System;
using System.Collections.Generic;

namespace Lazaro.Orm
{
        public class EntityRepository<T> : IEntityRepository<T> where T : new()
        {
                public IEntityManager EntityManager { get; }

                public EntityRepository(IEntityManager em)
                {
                        this.EntityManager = em;
                }

                public T Find(object primaryKeyId)
                {
                        return this.EntityManager.Find<T>(primaryKeyId);
                }

                public EntityCollection<T> FindAll(string orderBy)
                {
                        return this.EntityManager.FindAll<T>(orderBy);
                }

                public EntityCollection<T> FindBy(qGen.Where where, string orderBy)
                {
                        return this.EntityManager.FindBy<T>(where, orderBy);
                }
        }
}
