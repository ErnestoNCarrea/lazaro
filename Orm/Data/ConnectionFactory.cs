using Lazaro.Orm.Data.Drivers;
using qGen;
using System;
using System.Collections.Generic;

namespace Lazaro.Orm.Data
{
        public class ConnectionFactory : IConnectionFactory
        {
                private static int LastHandle = 0;

                public IDriver Driver { get; set; }
                public IFormatter Formatter { get; set; }
                public ConnectionParameters ConnectionParameters { get; set; }

                public IConnection GetNewConnection(string ownerName)
                {
                        return new Connection(this, LastHandle++, ownerName);
                }
        }
}
