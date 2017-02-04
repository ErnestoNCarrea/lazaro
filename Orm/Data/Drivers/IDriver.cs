using System.Data;
using System.Collections.Generic;

namespace Lazaro.Orm.Data.Drivers
{
        public interface IDriver
        {
                IDbConnection GetConnection();
                IDbCommand GetCommand();
                IDbDataAdapter GetAdapter(string commandText, IDbConnection connection);
                IDbDataParameter GetParameter();

                Dictionary<string, string> Keywords { get; set; }
                bool CompareColumnDefinitions(IColumnDefinition col1, IColumnDefinition col2);

        }
}
