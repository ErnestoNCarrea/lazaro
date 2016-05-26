namespace qGen.Providers
{
        /// <summary>
        /// Proveedor compatible con Npgsql versión 2. Requiere la presencia de Npgsql.dll en el directorio del programa.
        /// </summary>
        public class Npgsql : Provider
        {
                public Npgsql() :
                        base("Npgsql",
                        "Npgsql",
                        "NpgsqlConnection",
                        "NpgsqlCommand",
                        "NpgsqlDataAdapter",
                        "NpgsqlParameter",
                        "NpgsqlTransacion")
                {
                        this.Settings = new NpgsqlSettings();
                }
        }
}

