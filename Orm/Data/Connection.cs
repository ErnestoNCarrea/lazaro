using System;
using System.Data;

namespace Lazaro.Orm.Data
{
        public class Connection
        {
                internal System.Data.IDbConnection DriverConnection { get; set; }
        }
}
