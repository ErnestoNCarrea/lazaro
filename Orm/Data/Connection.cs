using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using Lazaro.Orm;
using Lazaro.Orm.Data;
using Lazaro.Orm.Data.Drivers;
using qGen;
using log4net;

namespace Lazaro.Orm.Data
{
        /// <summary>
        /// Proporciona una conexión a la base de datos y acceso de bajo nivel (sin abstracción) a los datos. Se utiliza normalmente para ejecutar consultas.
        /// Vea Lbl.* para para acceso de alto nivel a los datos.
        /// </summary>
        public class Connection : IDisposable, IConnection, System.Data.IDbConnection
        {
                private static readonly ILog Log = LogManager.GetLogger(typeof(Connection));

                public string Name { get; set; }

                public bool EnableRecover { get; set; } = false;
                public bool RequiresTransaction { get; set; } = true;
                public bool ReadOnly { get; set; } = false;

                public int KeepAlive { get; set; } = 600;
                protected System.Timers.Timer KeepAliveTimer = null;

                private int m_Handle = 0;
                protected bool m_InTransaction = false;
                protected bool m_Closing = false;

                // IConnection
                public IDbConnection DbConnection { get; set; }
                public IConnectionFactory Factory { get; set; }

                public Connection(IConnectionFactory factory, int handle, string ownerName)
                {
                        this.Factory = factory;
                        this.m_Handle = handle;
                        this.Name = ownerName;
                }


                public int Handle
                {
                        get
                        {
                                return m_Handle;
                        }
                }


                public virtual void Open()
                {

                }


                protected void KeepAliveTimer_Elapsed(object source, System.Timers.ElapsedEventArgs e)
                {
                        try {
                                IDbCommand Cmd = this.GetCommand("SELECT 1");
                                Cmd.Connection = this.DbConnection;
                                Cmd.ExecuteNonQuery();
                        } catch {
                                // Nada
                        }
                }

                protected void ResetKeepAliveTimer()
                {
                        if (this.KeepAliveTimer != null) {
                                this.KeepAliveTimer.Stop();
                                this.KeepAliveTimer.Start();
                        }
                }

                
                protected void Connection_StateChange(Object sender, System.Data.StateChangeEventArgs e)
                {
                        if (m_Closing)
                                return;

                        if (e.OriginalState == System.Data.ConnectionState.Open &&
                                (e.CurrentState == System.Data.ConnectionState.Closed ||
                                e.CurrentState == System.Data.ConnectionState.Broken ||
                                e.CurrentState == System.Data.ConnectionState.Connecting)) {
                                //Estaba OK y ahora está mal
                                while (true) {
                                        int intentos = 10;
                                        while (this.DbConnection.State != System.Data.ConnectionState.Open && intentos-- > 0) {
                                                try {
                                                        this.Open();
                                                } catch {
                                                        System.Threading.Thread.Sleep(1000);
                                                }
                                        }
                                        if (this.DbConnection.State == System.Data.ConnectionState.Open)
                                                break;
                                        else if (--intentos == 0)
                                                break;
                                }
                        }
                }



                public virtual void Dispose()
                {
                        this.Close();

                        if (KeepAliveTimer != null) {
                                KeepAliveTimer.Dispose();
                                KeepAliveTimer = null;
                        }

                        if (DbConnection != null) {
                                DbConnection.Dispose();
                                DbConnection = null;
                        }
                }


                public virtual void Close()
                {
                        if (this.DbConnection != null) {
                                m_Closing = true;

                                if (DbConnection.State == System.Data.ConnectionState.Open)
                                        DbConnection.Close();

                                DbConnection.Dispose();
                                DbConnection = null;

                                m_Closing = false;
                        }
                }


                public System.Data.IDbCommand GetCommand(string commandText)
                {
                        System.Data.IDbCommand TempCommand = this.Factory.Driver.GetCommand();
                        TempCommand.Connection = this.DbConnection;
                        TempCommand.CommandText = commandText;

                        return TempCommand;
                }

                public System.Data.IDbCommand GetCommand(qGen.IConvertibleToDbCommand command)
                {
                        System.Data.IDbCommand TempCommand = this.Factory.Driver.GetCommand();
                        TempCommand.Connection = this.DbConnection;
                        return this.Factory.Formatter.SetupDbCommand(command, ref TempCommand, this);
                }

                
                public bool IsOpen()
                {
                        return (this.State == System.Data.ConnectionState.Open) || (this.State == System.Data.ConnectionState.Executing) || (this.State == System.Data.ConnectionState.Fetching);
                }


                protected void EsperarFinDeLectura()
                {
                        // Intento asegurarme de que no esté leyendo
                        int Intentos = 0;
                        while (this.DbConnection.State == ConnectionState.Fetching) {
                                System.Threading.Thread.Sleep(100);
                                Intentos++;
                                if (Intentos == 100) {
                                        break;
                                }
                        }
                }


                public bool InTransaction
                {
                        get
                        {
                                return m_InTransaction;
                        }
                }


                //Función: CustomizeSql
                //	Convierte un Sql "genérico" en Sql para un servidor en particular
                public string CustomizeSql(string sqlOrigen)
                {
                        string Res = sqlOrigen;

                        Regex Rx = new Regex(@"\$[_\.0-9a-zA-Z]+\$", RegexOptions.ExplicitCapture | RegexOptions.Singleline);
                        MatchCollection VariableKeywords = Rx.Matches(Res);
                        foreach (Match Mt in VariableKeywords) {
                                string KeywordName = Mt.Value.Substring(1, Mt.Value.Length - 2);
                                if (this.Factory.Driver.Keywords.ContainsKey(KeywordName)) {
                                        Res = Res.Replace("$" + KeywordName + "$", this.Factory.Driver.Keywords[KeywordName]);
                                } else {
                                        Res = Res.Replace("$" + KeywordName + "$", KeywordName);
                                }
                        }

                        return Res;
                }


                public static string EscapeString(string stringValue, qGen.SqlModes sqlMode)
                {
                        switch (sqlMode) {
                                case qGen.SqlModes.PostgreSql:
                                        return stringValue.Replace("'", "''");
                                case qGen.SqlModes.MySql:
                                default:
                                        return stringValue.Replace("'", "''").Replace(@"\", @"\\");
                        }
                }


                public override string ToString()
                {
                        return this.Name;
                }


                public static int ConvertDBNullToZero(object valor)
                {
                        if (valor == null || valor == DBNull.Value || valor == null)
                                return 0;
                        else
                                return System.Convert.ToInt32(valor);
                }


                public static object ConvertZeroToDBNull(int valor)
                {
                        if (valor == 0)
                                return DBNull.Value;
                        else
                                return valor;
                }


                public System.Data.ConnectionState State
                {
                        get
                        {
                                if (this.DbConnection != null) {
                                        System.Data.ConnectionState TempCS = this.DbConnection.State;
                                        return TempCS;
                                } else {
                                        return System.Data.ConnectionState.Closed;
                                }
                        }
                }


                /// <summary>
                /// Obtiene el primer comando SQL en una lista separada por punto y coma. Elimina el comando de la lista.
                /// </summary>
                /// <param name="comandos">La lista de comandos.</param>
                /// <returns>El primer comando de la lista.</returns>
                public static string GetNextCommand(ref string comandos)
                {
                        if (comandos != null && comandos.Length == 0)
                                return "";

                        int r = comandos.IndexOf(@";
");
                        string Res;
                        if (r < 0) {
                                // No encontré... devuelvo el comando completo
                                Res = comandos;
                                comandos = "";
                        } else {
                                Res = comandos.Substring(0, r);
                                comandos = comandos.Substring(r + 1, comandos.Length - (r + 1));
                        }

                        return Res;
                }


                public void ChangeDatabase(string databaseName)
                {
                        this.DbConnection.ChangeDatabase(databaseName);
                }


                public System.Data.IDbCommand CreateCommand()
                {
                        return this.DbConnection.CreateCommand();
                }


                public string ConnectionString
                {
                        get
                        {
                                return this.DbConnection.ConnectionString;
                        }
                        set
                        {
                                this.DbConnection.ConnectionString = value;
                        }
                }


                public string Database
                {
                        get
                        {
                                return this.DbConnection.Database;
                        }
                }


                public int ConnectionTimeout
                {
                        get
                        {
                                return this.DbConnection.ConnectionTimeout;
                        }
                }


                public IDbTransaction BeginTransaction()
                {
                        return this.BeginTransaction(System.Data.IsolationLevel.Serializable);
                }


                public IDbTransaction BeginTransaction(System.Data.IsolationLevel il)
                {
                        if (this.ReadOnly)
                                throw new InvalidOperationException("No se pueden realizar transacciones en la conexión de lectura");

                        if (this.IsOpen() == false)
                                this.Open();

                        if (m_InTransaction)
                                throw new InvalidOperationException(this.Name + ": Ya se inició una transacción");

                        m_InTransaction = true;

                        return new Transaction(this, il);
                }


                public void Commit(Transaction transaction)
                {
                        //if (m_InTransaction == false)
                        //        throw new InvalidOperationException("Commit sin BeginTransaction");

                        transaction.DbTransaction.Commit();
                        m_InTransaction = false;
                }


                public void Rollback(Transaction transaction)
                {
                        //if (m_InTransaction == false)
                        //        throw new InvalidOperationException("Rollback sin BeginTransaction");

                        transaction.DbTransaction.Rollback();
                        m_InTransaction = false;
                }


                protected bool TryToRecover(Exception ex)
                {
                        // Intento recuperar algunos errores de MySQL desconectando y volviendo a conectar
                        // Pero sólo puedo hacer esto si no estoy en una transacción
                        if (EnableRecover == true && m_InTransaction == false && ex.Source == "MySql.Data" &&
                                (ex.Message.IndexOf("server has gone away", StringComparison.InvariantCultureIgnoreCase) >= 0
                                || ex.Message.IndexOf("se ha desactivado la conexión", StringComparison.InvariantCultureIgnoreCase) >= 0
                                || ex.Message.IndexOf("Referencia a objeto no establecida como instancia de un objeto", StringComparison.InvariantCultureIgnoreCase) >= 0
                                || ex.Message.IndexOf("Object reference not set to an instance of an object", StringComparison.InvariantCultureIgnoreCase) >= 0
                                || ex.Message.IndexOf("Fatal error encountered during command execution", StringComparison.InvariantCultureIgnoreCase) >= 0
                                || ex.Message.IndexOf("Connection must be valid and open", StringComparison.InvariantCultureIgnoreCase) >= 0
                                || ex.Message.IndexOf("el estado actual de la conexión es cerrada", StringComparison.InvariantCultureIgnoreCase) >= 0
                                )) {

                                if (this.IsOpen())
                                        return false;

                                EnableRecover = false;

                                if (DbConnection != null && DbConnection.State != System.Data.ConnectionState.Closed)
                                        this.Close();

                                System.Threading.Thread.Sleep(500);

                                int intentos = 5;
                                while ((DbConnection == null || DbConnection.State != System.Data.ConnectionState.Open) && intentos-- > 0) {
                                        try {
                                                this.Open();
                                                DbConnection.ChangeDatabase(this.Factory.ConnectionParameters.DatabaseName);
                                        } catch {
                                                System.Threading.Thread.Sleep(2000);
                                        }
                                }
                                EnableRecover = true;
                                return false;
                        } else {
                                return true;
                        }
                }


                public System.Data.DataTable Select(string selectCommand)
                {
                        if (this.IsOpen() == false)
                                this.Open();

                        Log.Debug(this.Handle.ToString() + ":  " + selectCommand);

                        this.EsperarFinDeLectura();
                        var Adaptador = this.Factory.Driver.GetAdapter(selectCommand, this.DbConnection);
                        lock (Adaptador) {
                                using (System.Data.DataSet Lector = new System.Data.DataSet()) {
                                        Lector.Locale = System.Globalization.CultureInfo.CurrentCulture;
                                        while (true) {
                                                try {
                                                        this.ResetKeepAliveTimer();
                                                        Adaptador.Fill(Lector);
                                                        break;
                                                } catch (Exception ex) {
                                                        if (this.TryToRecover(ex)) {
                                                                Log.Error(selectCommand, ex);
                                                                ex.Data.Add("Command", selectCommand);
                                                                throw ex;
                                                        }
                                                }
                                        }
                                        return Lector.Tables[0];
                                }
                        }
                }


                public System.Data.DataTable Select(qGen.Select selectCommand)
                {
                        if (this.IsOpen() == false)
                                this.Open();

                        return this.Select(this.Factory.Formatter.SqlText(selectCommand));
                }


                public int ExecuteNonQuery(System.Data.IDbCommand command)
                {
                        if (this.ReadOnly)
                                throw new InvalidOperationException("No se pueden realizar cambios en la conexión de lectura");

                        if (this.IsOpen() == false)
                                this.Open();

                        Log.Debug(this.Handle.ToString() + ":  " + command.CommandText);

                        int Intentos = 3;
                        while (true) {
                                try {
                                        if (command.Connection == null)
                                                command.Connection = this.DbConnection;

                                        this.ResetKeepAliveTimer();
                                        int Res = command.ExecuteNonQuery();
                                        return Res;
                                } catch (Exception ex) {
                                        if (this.TryToRecover(ex) || Intentos-- <= 0) {
                                                Log.Error(command.CommandText, ex);
                                                ex.Data.Add("Command", command.CommandText);
                                                throw ex;
                                        }
                                }
                        }
                }

                public int ExecuteNonQuery(string sqlCommand)
                {
                        if (this.ReadOnly)
                                throw new InvalidOperationException("No se pueden realizar cambios en la conexión de lectura");

                        Log.Debug(this.Handle.ToString() + ":  " + sqlCommand);

                        if (this.RequiresTransaction && m_InTransaction == false)
                                throw new InvalidOperationException("Comandos fuera de transacción: " + sqlCommand);

                        sqlCommand = sqlCommand.Trim(new char[] { ' ', (char)13, (char)10, (char)9 });
                        if (sqlCommand.Length == 0)
                                return 0;

                        IDbCommand Cmd = this.GetCommand(sqlCommand);
                        // Doy más tiempo para los comandos escritos en SQL
                        Cmd.CommandTimeout = 300;
                        return this.ExecuteNonQuery(Cmd);
                }
        }
}