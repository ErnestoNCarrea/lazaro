using System.Data;
using MySql.Data.MySqlClient;

namespace qGen.Providers
{
        /// <summary>
        /// Proveedor compatible con MySql Connector/NET versión 6. Requiere la presencia de MySql.Data.dll en el directorio del programa.
        /// </summary>
        public class MySqlProvider : Provider
        {
                public MySqlProvider() :
                        base("MySql.Data",
                        "MySql.Data",
                        "MySqlClient.MySqlConnection",
                        "MySqlClient.MySqlCommand",
                        "MySqlClient.MySqlDataAdapter",
                        "MySqlClient.MySqlParameter",
                        "MySqlClient.MySqlTransaction")
                {
                        this.Settings = new MySqlSettings();
                }
                
                public override IDbConnection GetConnection()
                {
                        return new MySqlConnection();
                }
                
                public override IDbCommand GetCommand()
                {
                        return new MySqlCommand();
                }

                public override IDbDataAdapter GetAdapter(string commandText, IDbConnection connection)
                {
                        return new MySqlDataAdapter(commandText, connection as MySqlConnection);
                        //object[] Params = new object[] { commandText, connection };
                        //return ((System.Data.IDbDataAdapter)(this.Assembly.CreateInstance(this.NameSpace + "." + this.AdapterClass, false, BindingFlags.Default, null, Params, System.Globalization.CultureInfo.CurrentCulture, null)));
                }

                public override IDbDataParameter GetParameter()
                {
                        return new MySqlParameter();
                }
        }
}
