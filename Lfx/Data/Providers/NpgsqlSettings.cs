using System;
using System.Collections.Generic;

namespace qGen.Providers
{
        public class NpgsqlSettings : ProviderSettings
        {
                public NpgsqlSettings()
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
