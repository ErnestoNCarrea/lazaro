using System;
using System.Collections.Generic;
using Lazaro.Orm.Data;
using qGen;

namespace Lazaro.Orm
{
        public interface IEntityManager
        {
                IConnection Connection { get; set; }
        }
}
