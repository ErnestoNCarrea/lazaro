using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lazaro.Orm.Data;

namespace Lazaro.Orm
{
        public class EntityManager : IEntityManager
        {
                public IConnection Connection { get; set; }

                public EntityManager(IConnection connection)
                {
                        this.Connection = connection;
                }
        }
}
