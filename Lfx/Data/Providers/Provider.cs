using System.Data;
using System.Reflection;

namespace qGen.Providers
{
        /// <summary>
        /// Representa un proveedor ADO.NET, el cual se carga en tiempo de ejecución a través de System.Reflection para no
        /// agregar dependencias en tiempo de diseño. La única dependencia en tiempo de diseño es System.Data.Odbc.
        /// </summary>
        public abstract class Provider : IProvider
        {
                public string AssemblyName = null;
                public string NameSpace = null;
                public string ConnectionClass = null;
                public string CommandClass = null;
                public string AdapterClass = null;
                public string ParameterClass = null;
                public string TransactionClass = null;

                public ProviderSettings Settings { get; set; }

                protected internal Assembly m_Assembly = null;

                public Provider(string assemblyName, string nameSpace, string connectionClass, string commandClass, string adapterClass, string parameterClass, string transactionClass)
                {
                        this.AssemblyName = assemblyName;
                        this.NameSpace = nameSpace;
                        this.ConnectionClass = connectionClass;
                        this.CommandClass = commandClass;
                        this.AdapterClass = adapterClass;
                        this.ParameterClass = parameterClass;
                        this.TransactionClass = transactionClass;
                }

                protected Assembly Assembly
                {
                        get
                        {
                                if (m_Assembly == null) {
                                        if (System.IO.File.Exists(Lfx.Environment.Folders.ApplicationFolder + this.AssemblyName + ".dll"))
                                                m_Assembly = Assembly.LoadFrom(Lfx.Environment.Folders.ApplicationFolder + this.AssemblyName + ".dll");
                                        else if (System.IO.File.Exists(this.AssemblyName + ".dll"))
                                                m_Assembly = Assembly.LoadFrom(this.AssemblyName + ".dll");
                                        else
                                                throw new System.IO.FileNotFoundException("No se encuentra " + this.AssemblyName + ".dll");
                                }
                                return m_Assembly;
                        }
                }

                public virtual IDbConnection GetConnection()
                {
                        return ((System.Data.IDbConnection)(this.Assembly.CreateInstance(this.NameSpace + "." + this.ConnectionClass)));
                }

                public virtual IDbCommand GetCommand()
                {
                        return ((System.Data.IDbCommand)(this.Assembly.CreateInstance(this.NameSpace + "." + this.CommandClass)));
                }

                public virtual IDbDataAdapter GetAdapter(string commandText, IDbConnection connection)
                {
                        object[] Params = new object[] { commandText, connection };
                        return ((System.Data.IDbDataAdapter)(this.Assembly.CreateInstance(this.NameSpace + "." + this.AdapterClass, false, BindingFlags.Default, null, Params, System.Globalization.CultureInfo.CurrentCulture, null)));
                }

                public virtual IDbDataParameter GetParameter()
                {
                        return ((System.Data.IDbDataParameter)(this.Assembly.CreateInstance(this.NameSpace + "." + this.ParameterClass)));
                }
        }
}
