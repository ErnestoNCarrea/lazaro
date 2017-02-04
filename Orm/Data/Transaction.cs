using System;
using System.Data;

namespace Lazaro.Orm.Data
{
        public class Transaction : IDbTransaction
        {
                internal IDbTransaction DbTransaction = null;
                private IConnection DataConnection = null;

                public Transaction(IConnection connection, IsolationLevel isolationLevel)
                {
                        this.DataConnection = connection;
                        this.DbTransaction = connection.DbConnection.BeginTransaction(isolationLevel);
                }


                public IDbConnection Connection
                {
                        get
                        {
                                return this.DataConnection.DbConnection;
                        }
                }


                public IsolationLevel IsolationLevel
                {
                        get
                        {
                                return this.DbTransaction.IsolationLevel;
                        }
                }

                public void Commit()
                {
                        this.DataConnection.Commit(this);
                }


                public void Rollback()
                {
                        this.DataConnection.Rollback(this);
                }


                public void Dispose()
                {
                        try {
                                this.DataConnection.Rollback(this);
                        } catch {
                                // Nada
                        }
                        if (DbTransaction != null) {
                                DbTransaction.Dispose();
                        }
                        GC.SuppressFinalize(this);
                }
        }
}
