using System;
using Lazaro.Orm.Data;
using Lazaro.Orm.Data.Drivers;
using qGen;

namespace Lazaro.Orm.Data
{
        public interface IConnectionFactory
        {
                IConnection GetNewConnection(string ownerName);

                IDriver Driver { get; set; }
                IFormatter Formatter { get; set; }
        }
}
