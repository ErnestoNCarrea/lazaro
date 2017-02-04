using System.Collections.Generic;

namespace Lazaro.Orm.Data.Drivers
{
        /// <summary>
        /// Proveedor compatible con Npgsql versión 2. Requiere la presencia de Npgsql.dll en el directorio del programa.
        /// </summary>
        public class NpgsqlDriver : AbstractDriver
        {
                public NpgsqlDriver() :
                        base("Npgsql",
                        "Npgsql",
                        "NpgsqlConnection",
                        "NpgsqlCommand",
                        "NpgsqlDataAdapter",
                        "NpgsqlParameter",
                        "NpgsqlTransacion")
                {
                        this.Keywords = new Dictionary<string, string>() {
                                { "SERIAL", "SERIAL" },
                                { "BLOB", "BYTEA" },
                                { "TINYINT", "SMALLINT" },
                                { "SMALLINT", "SMALLINT" },
                                { "MEDIUMINT", "INTEGER" },
                                { "TIMESTAMP", "TIMESTAMP" },
                                { "DATETIME", "TIMESTAMP" },
                                { "CREATETABLE_OPTIONS", "" },
                                { "DEFERRABLE", "DEFERRABLE" }
                        };
                }
        }
}

