using System;
using qGen;

namespace Lazaro.Orm.Data
{
        public interface IConnection : IDisposable
        {
                int Handle { get; }
                string Name { get; set; }
                bool RequiresTransaction { get; set; }
                bool InTransaction { get; }
                System.Data.ConnectionState State { get; }
                bool EnableRecover { get; set; }

                IConnectionFactory Factory { get; set; }
                System.Data.IDbConnection DbConnection { get; set; }

                void Open();
                void Close();
                bool IsOpen();

                System.Data.IDbTransaction BeginTransaction();
                System.Data.IDbTransaction BeginTransaction(System.Data.IsolationLevel il);
                void Commit(Transaction transaction);
                void Rollback(Transaction transaction);

                int ExecuteNonQuery(string sqlCommand);
                int ExecuteNonQuery(qGen.IStatementOrQuery sqlCommand);
                System.Data.DataTable Select(string selectCommand);

                string CustomizeSql(string sqlOrigen);
        }
}
