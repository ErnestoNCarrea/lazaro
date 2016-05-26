namespace qGen.Providers
{
        /// <summary>
        /// Proveedor compatible con MySql Connector/NET versión 6. Requiere la presencia de MySql.Data.dll en el directorio del programa.
        /// </summary>
        public class MySql : Provider
        {
                public MySql() :
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
        }
}
