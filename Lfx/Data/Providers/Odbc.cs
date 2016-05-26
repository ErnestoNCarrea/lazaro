namespace qGen.Providers
{
        /// <summary>
        /// Proveedor compatible ODBC. Este es el único proveedor que está enlazado estáticamente y no trabaja por reflexión.
        /// </summary>
        public class Odbc : Provider
        {
                public Odbc() :
                        base("System.Data.Odbc",
                        "System.Data.Odbc",
                        "OdbcConnection",
                        "OdbcCommand",
                        "OdbcDataAdapter",
                        "OdbcParameter",
                        "OdbcTransaction")
                {
                        this.Settings = new AnsiSettings();
                }

                public override System.Data.IDbConnection GetConnection()
                {
                        return new System.Data.Odbc.OdbcConnection();
                }

                public override System.Data.IDbDataAdapter GetAdapter(string commandText, System.Data.IDbConnection connection)
                {
                        return new System.Data.Odbc.OdbcDataAdapter(commandText, connection as System.Data.Odbc.OdbcConnection);
                }

                public override System.Data.IDbDataParameter GetParameter()
                {
                        return new System.Data.Odbc.OdbcParameter();
                }

                public override System.Data.IDbCommand GetCommand()
                {
                        return new System.Data.Odbc.OdbcCommand();
                }
        }
}
