using System.Data;
using System.Collections.Generic;
using System.Reflection;

namespace Lazaro.Orm.Data.Drivers
{
        /// <summary>
        /// Representa un proveedor ADO.NET, el cual se carga en tiempo de ejecución a través de System.Reflection para no
        /// agregar dependencias en tiempo de diseño. La única dependencia en tiempo de diseño es System.Data.Odbc.
        /// </summary>
        public abstract class AbstractDriver : IDriver
        {
                public string AssemblyName = null;
                public string NameSpace = null;
                public string ConnectionClass = null;
                public string CommandClass = null;
                public string AdapterClass = null;
                public string ParameterClass = null;
                public string TransactionClass = null;

                public Dictionary<string, string> Keywords { get; set; }

                protected internal Assembly m_Assembly = null;

                public AbstractDriver(string assemblyName, string nameSpace, string connectionClass, string commandClass, string adapterClass, string parameterClass, string transactionClass)
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

                                        var ApplicationFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                                        var AssemblyPathAndName = System.IO.Path.Combine(ApplicationFolder, this.AssemblyName + ".dll");

                                        if (System.IO.File.Exists(AssemblyPathAndName)) {
                                                m_Assembly = Assembly.LoadFrom(AssemblyPathAndName);
                                        } else if (System.IO.File.Exists(this.AssemblyName + ".dll")) {
                                                m_Assembly = Assembly.LoadFrom(this.AssemblyName + ".dll");
                                        } else {
                                                throw new System.IO.FileNotFoundException(this.AssemblyName + ".dll not found.");
                                        }
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

                public bool CompareColumnDefinitions(IColumnDefinition col1, IColumnDefinition col2)
                {
                        return col1 == col2;
                }
        }
}
