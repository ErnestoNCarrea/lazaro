using System;
using System.Collections.Generic;

namespace qGen.Providers
{
        public class MySqlSettings : ProviderSettings
        {
                public MySqlSettings()
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
        }
}
