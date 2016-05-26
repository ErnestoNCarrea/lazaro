using System;
using System.Collections.Generic;

namespace qGen.Providers
{
        /// <summary>
        /// Proveedor compatible con SQLite. Requiere la presencia de System.Data.SQLite.dll en el directorio del programa.
        /// </summary>
        public class SQLite : Provider
        {
                public SQLite() :
                        base("System.Data.SQLite",
                        "System.Data.SQLite",
                        "SQLiteConnection",
                        "SQLiteCommand",
                        "SQLiteDataAdapter",
                        "SQLiteParameter",
                        "SQLiteTransaction")
                {
                }
        }
}
