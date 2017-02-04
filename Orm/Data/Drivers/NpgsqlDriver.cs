using System.Collections.Generic;

namespace Lazaro.Orm.Data.Drivers
{
        /// <summary>
        /// Driver for Npgsql versión 2. Untested.
        /// </summary>
        public class NpgsqlDriver : AbstractDriver, IDriver
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

