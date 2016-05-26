using System.Data;
using System.Reflection;

namespace qGen.Providers
{
        public interface IProvider
        {
                IDbConnection GetConnection();
                IDbCommand GetCommand();
                IDbDataAdapter GetAdapter(string commandText, IDbConnection connection);
                IDbDataParameter GetParameter();

                ProviderSettings Settings { get; set; }
        }
}
