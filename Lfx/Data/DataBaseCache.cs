using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Lfx.Data
{
        public class DataBaseCache
        {
                public static DataBaseCache DefaultCache;

                private Lfx.Data.Connection Connection;

                public DataBaseCache(Lfx.Data.Connection connection)
                {
                        this.Connection = connection;
                }
                
                public qGen.Providers.IProvider Provider = null;
                public string OdbcDriver = null;
                public string ServerName = null, DataBaseName, UserName, Password;
                public bool SlowLink = false, Mars = true, Pooling = true;
                public Lfx.Data.AccessModes AccessMode = Lfx.Data.AccessModes.Undefined;
                public qGen.SqlModes SqlMode = qGen.SqlModes.Ansi;
                public System.Data.IsolationLevel DefaultIsolationLevel = System.Data.IsolationLevel.Serializable;

                public void Clear()
                {
                        ServerName = null;
                        DataBaseName = null;
                        UserName = null;
                        Password = null;
                }


                public Lfx.Data.TableCollection m_Tables = null;

                /// <summary>
                /// Devuelve una colección con las tablas de datos.
                /// </summary>
                public Lfx.Data.TableCollection Tables
                {
                        get
                        {
                                if (m_Tables == null || m_Tables.Count == 0) {
                                        m_Tables = this.Connection.GetTables();
                                }
                                return m_Tables;
                        }
                }


                /// <summary>
                /// Obtiene una lista de tablas actualmente presente en la base de datos (puede no coincidir con dbstruct.xml)
                /// </summary>
                public IList<string> GetTableNames()
                {
                        IList<string> m_TableList = new List<string>();

                        System.Data.DataTable Tablas = null;
                        switch (SqlMode) {
                                case qGen.SqlModes.MySql:
                                case qGen.SqlModes.Oracle:
                                        Tablas = this.Connection.Select("SHOW TABLES");
                                        break;
                                case qGen.SqlModes.SQLite:
                                        Tablas = this.Connection.Select("SELECT name FROM sqlite_master WHERE type='table'");
                                        break;
                                default:
                                        Tablas = this.Connection.Select("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_SCHEMA='public'");
                                        break;
                        }

                        foreach (System.Data.DataRow Tabla in Tablas.Rows) {
                                if (m_TableList.Contains(Tabla[0].ToString()) == false)
                                        m_TableList.Add(Tabla[0].ToString());
                        }

                        return m_TableList;
                }
        }
}