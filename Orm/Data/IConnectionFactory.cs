using System;
using Lazaro.Orm.Data;
using Lazaro.Orm.Data.Drivers;
using qGen;

namespace Lazaro.Orm.Data
{
        public interface IConnectionFactory
        {
                IDriver Driver { get; set; }
                IFormatter Formatter { get; set; }
                ConnectionParameters ConnectionParameters { get; set; }

                IConnection GetNewConnection(string ownerName);
        }
}
