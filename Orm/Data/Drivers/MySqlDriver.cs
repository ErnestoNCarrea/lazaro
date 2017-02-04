using System.Data;
using System.Collections.Generic;
using Lazaro.Orm.Data.Drivers;
using MySql.Data.MySqlClient;

namespace Lazaro.Orm.Data.Drivers
{
        /// <summary>
        /// Proveedor compatible con MySql Connector/NET versión 6. Requiere la presencia de MySql.Data.dll en el directorio del programa.
        /// </summary>
        public class MySqlDriver : AbstractDriver, IDriver
        {
                public MySqlDriver() :
                        base("MySql.Data",
                        "MySql.Data",
                        "MySqlClient.MySqlConnection",
                        "MySqlClient.MySqlCommand",
                        "MySqlClient.MySqlDataAdapter",
                        "MySqlClient.MySqlParameter",
                        "MySqlClient.MySqlTransaction")
                {
                        this.Keywords = new Dictionary<string, string>() {
                                { "SERIAL", "INTEGER AUTO_INCREMENT NOT NULL" },
                                { "BLOB", "LONGBLOB" },
                                { "TIMESTAMP", "DATETIME" },
                                { "DATETIME", "DATETIME" },
                                { "CREATETABLE_OPTIONS", " ENGINE=InnoDB CHARACTER SET=utf8" },
                                { "DEFERRABLE", "" }
                        };
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
