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

namespace Lfx.Data
{
        /// <summary>
        /// Proporciona una conexión a la base de datos y acceso de bajo nivel (sin abstracción) a los datos. Se utiliza normalmente para ejecutar consultas.
        /// Vea Lbl.* para para acceso de alto nivel a los datos.
        /// </summary>
        public class Connection : Lazaro.Orm.Data.Connection, Lfx.Data.IConnection
        {
                private static readonly ILog Log = LogManager.GetLogger(typeof(Connection));

                private static int LastHandle = 0;

                public Connection(IConnectionFactory factory, string ownerName)
                        : base(factory, LastHandle++, ownerName)
                {
                }

                public override void Open()
                {
                        EnableRecover = false;

                        if (DbConnection != null && DbConnection.State != System.Data.ConnectionState.Closed && DbConnection.State != System.Data.ConnectionState.Broken)
                                return;

                        Log.Info(this.Handle.ToString() + ": Abriendo " + this.Name);

                        System.Text.StringBuilder ConnectionString = new System.Text.StringBuilder();

                        switch (Lfx.Data.DatabaseCache.DefaultCache.AccessMode) {
                                case AccessModes.MySql:
                                        ConnectionString.Append("Convert Zero Datetime=true;");
                                        ConnectionString.Append("Connection Timeout=10;");
                                        ConnectionString.Append("Default Command Timeout=30;");
                                        ConnectionString.Append("Allow User Variables=True;");
                                        ConnectionString.Append("Allow Batch=True;");
                                        // ConnectionString.Append("KeepAlive=20;");     // No sirve, uso KeepAlive propio
                                        if (Lfx.Data.DatabaseCache.DefaultCache.Pooling) {
                                                ConnectionString.Append("Pooling=true;");
                                        } else {
                                                ConnectionString.Append("Pooling=false;");
                                        }
                                        ConnectionString.Append("Cache Server Properties=false;");
                                        switch (System.Text.Encoding.Default.BodyName) {
                                                case "utf-8":
                                                        ConnectionString.Append("charset=utf8;");
                                                        break;
                                                case "iso-8859-1":
                                                        ConnectionString.Append("charset=latin1;");
                                                        break;
                                        }
                                        if (Lfx.Data.DatabaseCache.DefaultCache.SlowLink) {
                                                ConnectionString.Append("Compress=true;");
                                                ConnectionString.Append("Use Compression=true;");
                                        }
                                        break;
                                case AccessModes.Odbc:
                                        throw new NotImplementedException("Soporte ODBC no implementado");
                                case AccessModes.Npgsql:
                                        throw new NotImplementedException("Soporte PostgreSQL no implementado");
                                case AccessModes.MSSql:
                                        throw new NotImplementedException("Soporte SQL Server no implementado");
                        }

                        if (Lfx.Data.DatabaseCache.DefaultCache.OdbcDriver != null)
                                ConnectionString.Append("DRIVER={" + Lfx.Data.DatabaseCache.DefaultCache.OdbcDriver + "};");

                        string Server, Port;
                        if (Lfx.Workspace.Master.ConnectionParameters.ServerName.IndexOf(':') >= 0) {
                                string[] Temp = Lfx.Workspace.Master.ConnectionParameters.ServerName.Split(new char[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries);
                                Server = Temp[0];
                                Port = Temp[1];
                        } else {
                                Server = Lfx.Workspace.Master.ConnectionParameters.ServerName;
                                Port = null;
                        }

                        ConnectionString.Append("SERVER=" + Server + ";");
                        if (string.IsNullOrEmpty(Port) == false)
                                ConnectionString.Append("PORT=" + Port + ";");

                        if (string.IsNullOrWhiteSpace(Lfx.Workspace.Master.ConnectionParameters.DatabaseName) == false)
                                ConnectionString.Append("DATABASE=" + Lfx.Workspace.Master.ConnectionParameters.DatabaseName + ";");
                        ConnectionString.Append("UID=" + Lfx.Workspace.Master.ConnectionParameters.UserName + ";");
                        ConnectionString.Append("PWD=" + Lfx.Workspace.Master.ConnectionParameters.Password + ";");

                        DbConnection = this.Factory.Driver.GetConnection();
                        DbConnection.ConnectionString = ConnectionString.ToString();
                        try {
                                DbConnection.Open();
                        } catch (Exception ex) {
                                throw ex;
                        }

                        this.SetupConnection(this.DbConnection);
                        EnableRecover = true;

                        if (KeepAlive > 0 && KeepAliveTimer == null) {
                                KeepAliveTimer = new System.Timers.Timer(this.KeepAlive * 1000);
                                KeepAliveTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.KeepAliveTimer_Elapsed);
                                KeepAliveTimer.Start();
                        }

                        if (DbConnection is System.Data.Odbc.OdbcConnection) {
                                System.Data.Odbc.OdbcConnection OdbcConnection = DbConnection as System.Data.Odbc.OdbcConnection;
                                try {
                                        OdbcConnection.StateChange -= new System.Data.StateChangeEventHandler(this.Connection_StateChange);
                                } catch {
                                        // Nada
                                }
                                OdbcConnection.StateChange += new System.Data.StateChangeEventHandler(this.Connection_StateChange);
                        }

                        if (Lfx.Workspace.Master.ServerVersion == null)
                                Lfx.Workspace.Master.ServerVersion = this.ServerVersion;
                }


                


                protected void SetupConnection(System.Data.IDbConnection setupConnection)
                {
                        if (this.AccessMode == AccessModes.Odbc) {
                                //Detecto el tipo de servidor y asigno directamente a la variable porque la propiedad es sólo lectura
                                System.Data.Odbc.OdbcConnection OdbcConnection = setupConnection as System.Data.Odbc.OdbcConnection;
                                if (OdbcConnection.ServerVersion.IndexOf("PostgreSql", StringComparison.InvariantCultureIgnoreCase) >= 0)
                                        Lfx.Data.DatabaseCache.DefaultCache.SqlMode = qGen.SqlModes.PostgreSql;
                                else if (OdbcConnection.Driver.IndexOf("myodbc", StringComparison.InvariantCultureIgnoreCase) >= 0)
                                        Lfx.Data.DatabaseCache.DefaultCache.SqlMode = qGen.SqlModes.MySql;
                                else if (OdbcConnection.Driver.IndexOf("SqlSRV", StringComparison.InvariantCultureIgnoreCase) >= 0)
                                        Lfx.Data.DatabaseCache.DefaultCache.SqlMode = qGen.SqlModes.TransactSql;
                        }

                        switch (this.SqlMode) {
                                case qGen.SqlModes.MySql:
                                        // Pongo a MySql en modo ANSI
                                        this.ExecuteNonQuery(new qGen.SetCommand("sql_mode='ANSI'"));
                                        switch (System.Text.Encoding.Default.BodyName) {
                                                case "utf-8":
                                                        this.ExecuteNonQuery(new qGen.SetCommand("CHARACTER SET UTF8"));
                                                        break;
                                                case "iso-8859-1":
                                                        this.ExecuteNonQuery(new qGen.SetCommand("CHARACTER SET LATIN1"));
                                                        break;
                                        }
                                        break;
                                case qGen.SqlModes.PostgreSql:
                                        switch (System.Text.Encoding.Default.BodyName) {
                                                case "utf-8":
                                                        this.ExecuteNonQuery(new qGen.SetCommand("CLIENT_ENCODING TO 'UTF8'"));
                                                        break;
                                                case "iso-8859-1":
                                                        this.ExecuteNonQuery(new qGen.SetCommand("CLIENT_ENCODING TO 'LATIN1'"));
                                                        break;
                                        }
                                        break;
                        }
                }


                public void SetTableStructure(Data.TableStructure newTableDef)
                {
                        Data.TableStructure CurrentTableDef = this.GetTableStructure(newTableDef.Name, false);
                        bool TablaCreada = false;
                        if (CurrentTableDef.Columns.Count == 0) {
                                // Crear la tabla
                                string Sql = newTableDef.ToString();
                                this.ExecuteNonQuery(this.CustomizeSql(Sql));
                                TablaCreada = true;
                        } else {
                                // Modificar tabla existente

                                // Primero dropeo las que ya no son claves primarias
                                foreach (Data.ColumnDefinition NewFieldDef in newTableDef.Columns.Values) {
                                        if (CurrentTableDef.Columns.ContainsKey(NewFieldDef.Name)) {
                                                Data.ColumnDefinition CurrentFieldDef = CurrentTableDef.Columns[NewFieldDef.Name];
                                                if (CurrentFieldDef.PrimaryKey == true && NewFieldDef.PrimaryKey == false) {
                                                        DropPrimaryKey(newTableDef.Name);
                                                        break;
                                                }
                                        }
                                }

                                // Luego hago las modificaciones pertinentes
                                string LastColName = null;
                                List<string> Alterations = new List<string>();
                                foreach (Data.ColumnDefinition NewFieldDef in newTableDef.Columns.Values) {
                                        if (CurrentTableDef.Columns.ContainsKey(NewFieldDef.Name) == false) {
                                                //Agregar campo a una tabla existente
                                                string Sql = "ADD COLUMN \"" + NewFieldDef.Name + "\" " + NewFieldDef.SqlDefinition(true);
                                                if (this.SqlMode == qGen.SqlModes.MySql) {
                                                        if (LastColName == null)
                                                                Sql += " FIRST";
                                                        else
                                                                Sql += " AFTER \"" + LastColName + "\"";
                                                }
                                                Alterations.Add(Sql);
                                        } else {
                                                Data.ColumnDefinition CurrentFieldDef = CurrentTableDef.Columns[NewFieldDef.Name];
                                                if (CurrentFieldDef != NewFieldDef) {
                                                        //Existe el campo, pero no es igual... hay que modificarlo
                                                        if (this.AccessMode == AccessModes.Npgsql) {
                                                                if (CurrentFieldDef.FieldType != NewFieldDef.FieldType || CurrentFieldDef.Lenght != NewFieldDef.Lenght || CurrentFieldDef.Precision != NewFieldDef.Precision)
                                                                        Alterations.Add("ALTER COLUMN \"" + NewFieldDef.Name + "\" TYPE " + NewFieldDef.SqlType());
                                                                if (CurrentFieldDef.Nullable != NewFieldDef.Nullable) {
                                                                        if (NewFieldDef.Nullable)
                                                                                Alterations.Add("ALTER COLUMN \"" + NewFieldDef.Name + "\" DROP NOT NULL");
                                                                        else
                                                                                Alterations.Add("ALTER COLUMN \"" + NewFieldDef.Name + "\" SET NOT NULL");
                                                                }
                                                                if (CurrentFieldDef.DefaultValue != NewFieldDef.DefaultValue && NewFieldDef.FieldType != ColumnTypes.Serial) {
                                                                        //Cambio de default value (salvo en Serial, que en PostgreSQL es siempre 0)
                                                                        switch (NewFieldDef.FieldType) {
                                                                                case ColumnTypes.VarChar:
                                                                                case ColumnTypes.Text:
                                                                                        if (NewFieldDef.DefaultValue == null)
                                                                                                Alterations.Add("ALTER COLUMN \"" + NewFieldDef.Name + "\" SET DEFAULT ''");
                                                                                        else if (NewFieldDef.DefaultValue == "NULL")
                                                                                                Alterations.Add("ALTER COLUMN \"" + NewFieldDef.Name + "\" SET DEFAULT NULL");
                                                                                        else
                                                                                                Alterations.Add("ALTER COLUMN \"" + NewFieldDef.Name + "\" SET DEFAULT '" + NewFieldDef.DefaultValue + "'");
                                                                                        break;
                                                                                default:
                                                                                        if (NewFieldDef.DefaultValue != null && NewFieldDef.DefaultValue.Length > 0)
                                                                                                Alterations.Add("ALTER COLUMN \"" + NewFieldDef.Name + "\" SET DEFAULT " + NewFieldDef.DefaultValue);
                                                                                        else
                                                                                                Alterations.Add("ALTER COLUMN \"" + NewFieldDef.Name + "\" DROP DEFAULT");
                                                                                        break;
                                                                        }
                                                                }
                                                        } else {
                                                                string Alter = "MODIFY COLUMN \"" + NewFieldDef.Name + "\" " + NewFieldDef.SqlDefinition(false);
                                                                if (this.SqlMode == qGen.SqlModes.MySql) {
                                                                        if (LastColName == null)
                                                                                Alter += " FIRST";
                                                                        else
                                                                                Alter += " AFTER \"" + LastColName + "\"";
                                                                }
                                                                Alterations.Add(Alter);
                                                        }
                                                }
                                        }
                                        LastColName = NewFieldDef.Name;
                                }

                                foreach (Data.ColumnDefinition FieldDef in CurrentTableDef.Columns.Values) {
                                        if (newTableDef.Columns.ContainsKey(FieldDef.Name) == false) {
                                                // TODO: que marque la columna para eliminarla en el futuro
                                                // Alterations.Add("DROP COLUMN \"" + FieldDef.Name + "\"");
                                        }
                                }

                                // Ejecuto todas las alteraciones juntas
                                if (Alterations.Count > 0) {
                                        string Sql = "ALTER TABLE \"" + newTableDef.Name + "\" " + string.Join("," + System.Environment.NewLine, Alterations.ToArray());
                                        this.ExecuteNonQuery(this.CustomizeSql(Sql));
                                }
                        }

                        //Crear y modificar indices
                        if (newTableDef.Indexes != null) {
                                foreach (Data.IndexDefinition NewIndex in newTableDef.Indexes.Values) {
                                        if (NewIndex.Primary && this.AccessMode == AccessModes.Npgsql)
                                                NewIndex.Name = NewIndex.TableName + "_pkey";

                                        bool Create = false;
                                        if (CurrentTableDef.Indexes == null || CurrentTableDef.Indexes.ContainsKey(NewIndex.Name) == false) {
                                                //No existe, lo creo
                                                Create = true;
                                        } else {
                                                //Existe
                                                Data.IndexDefinition CurrentIndex = CurrentTableDef.Indexes[NewIndex.Name];
                                                if (CurrentIndex != NewIndex) {
                                                        //Es diferente, lo modifico (lo elimino y lo creo nuevamente)
                                                        this.DropIndex(CurrentIndex);
                                                        Create = true;
                                                }
                                        }

                                        //Al crear la tabla, se crea la clave primaria y no necesito crearla aquí
                                        if (Create && (TablaCreada == false || NewIndex.Primary == false)) {
                                                try {
                                                        this.CreateIndex(NewIndex);
                                                } catch {
                                                        // No pude crear un índice... no importa
                                                        // en algún momento se intentará de nuevo
                                                }
                                        }
                                }
                        }

                        //Eliminar indices
                        if (CurrentTableDef.Indexes != null) {
                                foreach (Data.IndexDefinition CurrentIndex in CurrentTableDef.Indexes.Values) {
                                        if (CurrentIndex.Primary && CurrentIndex.Name != "PRIMARY")
                                                CurrentIndex.Name = "PRIMARY";

                                        if (newTableDef.Indexes.ContainsKey(CurrentIndex.Name) == false) {
                                                try {
                                                        this.DropIndex(CurrentIndex);
                                                } catch {
                                                        // Nada... lo dropeo en la próxima?
                                                }
                                        }
                                }
                        }
                }


                protected void DropPrimaryKey(string table)
                {
                        string Sql = "ALTER TABLE \"" + table + "\" DROP PRIMARY KEY;";
                        this.ExecuteNonQuery(this.CustomizeSql(Sql));
                }


                protected void CreateIndex(Data.IndexDefinition index)
                {
                        string Sql = null;
                        switch (this.AccessMode) {
                                case AccessModes.Npgsql:
                                        if (index.Primary)
                                                Sql = "ALTER TABLE \"" + index.TableName + "\" ADD PRIMARY KEY (" + index.CommaSeparatedColumns() + "); ";
                                        else {
                                                Sql = "CREATE ";
                                                if (index.Unique)
                                                        Sql += " UNIQUE";
                                                Sql += " INDEX \"" + index.Name + "\" ON \"" + index.TableName + "\" (" + index.CommaSeparatedColumns() + ")";
                                        }
                                        break;
                                default:
                                        Sql = "ALTER TABLE \"" + index.TableName + "\" ADD " + index.SqlDefinition();
                                        break;
                        }
                        this.ExecuteNonQuery(Sql);
                }

                protected void DropIndex(Data.IndexDefinition index)
                {
                        // Elimino las claves foráneas que se vean afectadas por la eliminación de este índice
                        // (esto parece ser especialmente necesario para evitar corrupción de datos con MySQL 5.5)
                        IDictionary<string, ConstraintDefinition> EfKeys = this.GetConstraints();
                        foreach (ConstraintDefinition EfKey in EfKeys.Values) {
                                if (EfKey.TableName == index.TableName && index.Columns.Contains(EfKey.Column))
                                        DropForeignKey(EfKey);
                                else if (EfKey.ReferenceTable == index.TableName && index.Columns.Contains(EfKey.ReferenceColumn))
                                        DropForeignKey(EfKey);
                        }

                        string Sql;
                        switch (this.AccessMode) {
                                case AccessModes.Npgsql:
                                        if (index.Primary)
                                                Sql = "ALTER TABLE \"" + index.TableName + "\" DROP CONSTRAINT \"" + index.TableName + "_pkey\"";
                                        else
                                                Sql = "DROP INDEX \"" + index.Name + "\"";
                                        break;
                                default:
                                        if (index.Primary)
                                                Sql = "ALTER TABLE \"" + index.TableName + "\" DROP PRIMARY KEY";
                                        else
                                                Sql = "ALTER TABLE \"" + index.TableName + "\" DROP INDEX \"" + index.Name + "\"";
                                        break;
                        }
                        this.ExecuteNonQuery(Sql);
                }


                public Data.TableStructure GetTableStructure(string tableName, bool withConstraints)
                {
                        Data.TableStructure TableDef = new Data.TableStructure();
                        TableDef.Name = tableName;

                        //requiere INFORMATION_SCHEMA. No compatible con MySql < 5 ni PostgreSQL < 7.4
                        string Sql;
                        if (this.AccessMode == AccessModes.Npgsql)
                                Sql = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='public' AND TABLE_CATALOG='" + this.DbConnection.Database + "' AND TABLE_NAME='" + tableName + "' ORDER BY ORDINAL_POSITION";
                        else
                                Sql = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" + this.DbConnection.Database + "' AND TABLE_NAME='" + tableName + "' ORDER BY ORDINAL_POSITION";
                        System.Data.DataTable Columnas = this.Select(Sql);

                        if (Columnas.Rows.Count == 0)
                                return TableDef;

                        foreach (System.Data.DataRow Columna in Columnas.Rows) {
                                Data.ColumnDefinition FieldDef = new Data.ColumnDefinition();
                                FieldDef.Name = Columna["COLUMN_NAME"].ToString();
                                FieldDef.FieldType = Lfx.Data.Types.FromSqlType(Columna["DATA_TYPE"].ToString());
                                switch (FieldDef.FieldType) {
                                        case Lazaro.Orm.ColumnTypes.VarChar:
                                                FieldDef.Lenght = System.Convert.ToInt32(Columna["CHARACTER_MAXIMUM_LENGTH"]);
                                                break;
                                        case Lazaro.Orm.ColumnTypes.Numeric:
                                                FieldDef.Lenght = System.Convert.ToInt32(Columna["NUMERIC_PRECISION"]);
                                                if (FieldDef.Lenght == 0)
                                                        FieldDef.Lenght = 15;
                                                FieldDef.Precision = System.Convert.ToInt32(Columna["NUMERIC_SCALE"]);
                                                if (FieldDef.Precision == 0)
                                                        FieldDef.Precision = 4;
                                                break;
                                }
                                string COLUMN_TYPE = (this.AccessMode == AccessModes.Npgsql) ? "DATA_TYPE" : "COLUMN_TYPE";
                                if (Columna[COLUMN_TYPE].ToString().ToLower().IndexOf("unsigned") >= 0)
                                        FieldDef.Unsigned = true;

                                if (Columna["IS_NULLABLE"].ToString() == "NO")
                                        FieldDef.Nullable = false;
                                else
                                        FieldDef.Nullable = true;

                                if (!(Columna["COLUMN_DEFAULT"] == null || Columna["COLUMN_DEFAULT"] is DBNull)) {
                                        FieldDef.DefaultValue = Columna["COLUMN_DEFAULT"].ToString();

                                        switch (FieldDef.FieldType) {
                                                case ColumnTypes.Integer:
                                                case ColumnTypes.SmallInt:
                                                case ColumnTypes.MediumInt:
                                                case ColumnTypes.Currency:
                                                case ColumnTypes.Numeric:
                                                        if (Lfx.Types.Parsing.ParseDecimal(FieldDef.DefaultValue) == 0)
                                                                FieldDef.DefaultValue = "0";
                                                        break;
                                                case ColumnTypes.DateTime:
                                                        if (FieldDef.DefaultValue == "0000-00-00 00:00:00")
                                                                FieldDef.DefaultValue = "NULL";
                                                        break;
                                        }

                                        //Quito castings de PostgreSQL
                                        if (FieldDef.DefaultValue != null) {
                                                if (FieldDef.DefaultValue.EndsWith("::character varying"))
                                                        FieldDef.DefaultValue = FieldDef.DefaultValue.Substring(0, FieldDef.DefaultValue.Length - 19);
                                                else if (FieldDef.DefaultValue.EndsWith("::text"))
                                                        FieldDef.DefaultValue = FieldDef.DefaultValue.Substring(0, FieldDef.DefaultValue.Length - 6);

                                                if (FieldDef.DefaultValue.StartsWith("'") && FieldDef.DefaultValue.EndsWith("'"))
                                                        FieldDef.DefaultValue = FieldDef.DefaultValue.Substring(1, FieldDef.DefaultValue.Length - 2);	//Quito comillas
                                        }
                                } else {
                                        if (FieldDef.Nullable == false) {
                                                // null es sin default value, "NULL" es default to NULL
                                                FieldDef.DefaultValue = null;
                                        } else {
                                                switch (FieldDef.FieldType) {
                                                        case ColumnTypes.Text:
                                                        case ColumnTypes.Blob:
                                                        case ColumnTypes.DateTime:
                                                                // No pueden tener default value
                                                                FieldDef.DefaultValue = null;
                                                                break;
                                                        default:
                                                                FieldDef.DefaultValue = "NULL";
                                                                break;
                                                }
                                        }
                                }

                                //Es la clave autonumérica?
                                if (this.SqlMode == qGen.SqlModes.MySql && Columna["EXTRA"].ToString() == "auto_increment") {
                                        FieldDef.FieldType = ColumnTypes.Serial;
                                } else if (this.AccessMode == AccessModes.Npgsql && Columna["COLUMN_DEFAULT"].ToString().IndexOf("nextval(") >= 0) {
                                        FieldDef.FieldType = ColumnTypes.Serial;
                                }

                                if (this.SqlMode == qGen.SqlModes.MySql) {
                                        //Particularidades de MySQL
                                        if (Columna["COLUMN_KEY"].ToString() == "PRI")
                                                FieldDef.PrimaryKey = true;
                                }

                                TableDef.Columns.Add(FieldDef.Name, FieldDef);
                        }

                        //Indices
                        if (this.AccessMode == AccessModes.Npgsql) {
                                /*
                                Sql = @"SELECT a.table_catalog, a.table_schema, a.table_name, a.constraint_name AS INDEX_NAME, a.constraint_type, array_to_string(array(SELECT column_name::varchar FROM information_schema.key_column_usage WHERE constraint_name = a.constraint_name ORDER BY ordinal_position), ', ') as column_list, c.table_name, c.column_name
					FROM information_schema.table_constraints a 
					INNER JOIN information_schema.key_column_usage b
					ON a.constraint_name = b.constraint_name
					LEFT JOIN information_schema.constraint_column_usage c 
					ON a.constraint_name = c.constraint_name AND 
					   a.constraint_type = 'FOREIGN KEY'
					WHERE a.table_catalog='" + this.DbConnection.Database + @"' AND a.table_schema='public' AND a.table_name='" + tableName + @"'
					GROUP BY a.table_catalog, a.table_schema, a.table_name, 
						 a.constraint_name, a.constraint_type, 
						 c.table_name, c.column_name
					ORDER BY a.table_catalog, a.table_schema, a.table_name, 
						 a.constraint_name"; */
                                Sql = @"SELECT pg_attribute.attname AS COLUMN_NAME, pg_attribute.attnum,
	pg_class.relname AS TABLE_NAME,
	(CASE pg_index.indisunique WHEN 't' THEN 0 ELSE 1 END) AS NON_UNIQUE,
	(CASE pg_index.indisprimary WHEN 't' THEN 'PRIMARY KEY' ELSE '' END) AS CONSTRAINT_TYPE,
	(SELECT relname FROM pg_class WHERE pg_class.oid=pg_index.indexrelid) AS INDEX_NAME,
	pg_index.indexrelid,pg_class.relfilenode
     FROM pg_index
LEFT JOIN pg_class
       ON pg_index.indrelid  = pg_class.oid
LEFT JOIN pg_attribute
       ON pg_attribute.attrelid = pg_class.oid
      AND pg_attribute.attnum = ANY(indkey)
    WHERE pg_class.relname = '" + tableName + @"'";
                        } else {
                                Sql = @"SELECT NON_UNIQUE, INDEX_NAME, seq_in_index, COLUMN_NAME, collation, cardinality, sub_part, packed, nullable, index_type, comment
					FROM information_schema.STATISTICS
					WHERE table_schema = '" + this.DbConnection.Database + @"'
					AND table_name = '" + tableName + @"'
					ORDER BY index_name, seq_in_index";
                        }

                        System.Data.DataTable Indexes = this.Select(Sql);

                        if (Indexes.Rows.Count > 0) {
                                TableDef.Indexes = new Dictionary<string, IndexDefinition>();
                                foreach (System.Data.DataRow Index in Indexes.Rows) {
                                        string IndexName = Index["INDEX_NAME"].ToString();

                                        if (TableDef.Indexes.ContainsKey(IndexName)) {
                                                //Es un índice existente... agrego el campo
                                                string ColName = Index["COLUMN_NAME"].ToString();
                                                TableDef.Indexes[IndexName].Columns.Add(ColName);
                                                // Y marco la columna como primaria en la definición de la tabla
                                                switch (this.AccessMode) {
                                                        case AccessModes.MySql:
                                                                if (IndexName.ToUpperInvariant() == "PRIMARY")
                                                                        TableDef.Columns[ColName].PrimaryKey = true;
                                                                break;
                                                        case AccessModes.Npgsql:
                                                                if (Index["CONSTRAINT_TYPE"].ToString() == "PRIMARY KEY")
                                                                        TableDef.Columns[ColName].PrimaryKey = true;
                                                                break;
                                                }
                                        } else {
                                                //Es un índice nuevo
                                                Data.IndexDefinition NewIndex = new IndexDefinition(tableName);
                                                NewIndex.Name = Index["INDEX_NAME"].ToString();
                                                NewIndex.Columns = new List<string>(Index["COLUMN_NAME"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
                                                NewIndex.Unique = System.Convert.ToInt32(Index["NON_UNIQUE"]) == 0;
                                                switch (this.AccessMode) {
                                                        case AccessModes.MySql:
                                                                if (IndexName.ToUpperInvariant() == "PRIMARY")
                                                                        NewIndex.Primary = true;
                                                                break;
                                                        case AccessModes.Npgsql:
                                                                if (Index["CONSTRAINT_TYPE"].ToString() == "PRIMARY KEY")
                                                                        NewIndex.Primary = true;
                                                                break;
                                                }
                                                TableDef.Indexes.Add(NewIndex.Name, NewIndex);
                                                if (NewIndex.Primary) {
                                                        // Pongo las columnas como primarias en la definición de la tabla
                                                        for (int i = 0; i < NewIndex.Columns.Count; i++) {
                                                                TableDef.Columns[NewIndex.Columns[i]].PrimaryKey = true;
                                                        }
                                                }
                                        }
                                }
                        }

                        if (withConstraints) {
                                //Claves foráneas
                                TableDef.Constraints = new Dictionary<string, ConstraintDefinition>();
                                System.Data.DataTable Constraints = this.Select(@"SELECT INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_NAME, INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME, INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_TYPE,
					INFORMATION_SCHEMA.KEY_COLUMN_USAGE.COLUMN_NAME, INFORMATION_SCHEMA.KEY_COLUMN_USAGE.REFERENCED_TABLE_NAME, INFORMATION_SCHEMA.KEY_COLUMN_USAGE.REFERENCED_COLUMN_NAME
					FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS, INFORMATION_SCHEMA.KEY_COLUMN_USAGE
					WHERE INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_NAME=INFORMATION_SCHEMA.KEY_COLUMN_USAGE.CONSTRAINT_NAME
						AND INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_SCHEMA=INFORMATION_SCHEMA.KEY_COLUMN_USAGE.CONSTRAINT_SCHEMA
						AND INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_SCHEMA='" + this.DbConnection.Database + @"' AND INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME='" + tableName + @"'
						AND INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_TYPE='FOREIGN KEY'
						ORDER BY INFORMATION_SCHEMA.KEY_COLUMN_USAGE.ORDINAL_POSITION");
                                foreach (System.Data.DataRow Constraint in Constraints.Rows) {
                                        switch (Constraint["CONSTRAINT_TYPE"].ToString().ToUpper()) {
                                                case "FOREIGN KEY":
                                                        Data.ConstraintDefinition NewKey = new ConstraintDefinition(tableName);
                                                        NewKey.Name = Constraint["CONSTRAINT_NAME"].ToString();
                                                        NewKey.Column = Constraint["COLUMN_NAME"].ToString();
                                                        NewKey.ReferenceTable = Constraint["REFERENCED_TABLE_NAME"].ToString();
                                                        NewKey.ReferenceColumn = Constraint["REFERENCED_COLUMN_NAME"].ToString();
                                                        TableDef.Constraints.Add(NewKey.Name, NewKey);
                                                        break;
                                        }
                                }
                        }

                        return TableDef;
                }

                public void EmptyConstraints()
                {
                        // Borra todas las claves foráneas
                        IDictionary<string, ConstraintDefinition> CurrentConstraints = this.GetConstraints();
                        foreach (Data.ConstraintDefinition Con in CurrentConstraints.Values) {
                                string Sql = "ALTER TABLE \"" + Con.TableName + "\" DROP FOREIGN KEY \"" + Con.Name + "\"";
                                this.ExecuteNonQuery(this.CustomizeSql(Sql));
                        }
                }

                public void SetConstraints(Dictionary<string, ConstraintDefinition> newConstraints, bool deleteOnly)
                {
                        IDictionary<string, ConstraintDefinition> CurrentConstraints = this.GetConstraints();
                        //string Sql = null;
                        if (deleteOnly == false) {
                                foreach (Data.ConstraintDefinition NewCon in newConstraints.Values) {
                                        //Data.ConstraintDefinition CurrentCon;
                                        if (CurrentConstraints.ContainsKey(NewCon.Name) == false) {
                                                //Agregar
                                                CreateForeignKey(NewCon);
                                        } else if (CurrentConstraints[NewCon.Name] != NewCon) {
                                                //No es igual... hay que modificarlo
                                                DropForeignKey(NewCon);
                                                CreateForeignKey(NewCon);
                                        }
                                }
                        } //deleteOnly

                        //Eliminar constraints obsoletas
                        foreach (Data.ConstraintDefinition CurCon in CurrentConstraints.Values) {
                                if (CurCon != null && newConstraints.ContainsKey(CurCon.Name) == false) {
                                        DropForeignKey(CurCon);
                                }
                        }
                }


                public void CreateForeignKey(Data.ConstraintDefinition constraint)
                {
                        string Sql = "ALTER TABLE \"" + constraint.TableName + "\" ADD CONSTRAINT \"" + constraint.Name + "\" FOREIGN KEY (\"" + constraint.Column + "\") REFERENCES \"" + constraint.ReferenceTable + "\" (\"" + constraint.ReferenceColumn + "\") $DEFERRABLE$";
                        this.ExecuteNonQuery(this.CustomizeSql(Sql));
                }


                public void DropForeignKey(Data.ConstraintDefinition constraint)
                {
                        // FIXME: "DROP FOREIGN KEY" puede ser léxico MySQL. MySQL puede soportar en un futuro la sintáxis "DROP CONSTRAINT" que es más estándar

                        string Sql;
                        if (this.AccessMode == AccessModes.Npgsql)
                                Sql = "ALTER TABLE \"" + constraint.TableName + "\" DROP CONSTRAINT \"" + constraint.Name + "\"";
                        else
                                Sql = "ALTER TABLE \"" + constraint.TableName + "\" DROP FOREIGN KEY \"" + constraint.Name + "\"";

                        this.ExecuteNonQuery(this.CustomizeSql(Sql));
                }


                public IDictionary<string, ConstraintDefinition> GetConstraints()
                {
                        IDictionary<string, ConstraintDefinition> Res = new Dictionary<string, ConstraintDefinition>();
                        //Claves foráneas
                        string SQL;
                        if (this.AccessMode == AccessModes.Npgsql) {
                                SQL = @"SELECT INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_NAME, INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME, INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME, INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_TYPE,
					INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.COLUMN_NAME, INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.table_name AS REFERENCED_TABLE_NAME, INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.column_name AS REFERENCED_COLUMN_NAME
					FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
					ON INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_NAME=INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.CONSTRAINT_NAME
						AND INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_CATALOG=INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.CONSTRAINT_CATALOG
						WHERE INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_CATALOG='" + this.DbConnection.Database + @"'
						AND INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_TYPE='FOREIGN KEY'
						ORDER BY INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME";
                        } else {
                                SQL = @"SELECT INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_NAME, INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME, INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME, INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_TYPE,
					INFORMATION_SCHEMA.KEY_COLUMN_USAGE.COLUMN_NAME, INFORMATION_SCHEMA.KEY_COLUMN_USAGE.REFERENCED_TABLE_NAME, INFORMATION_SCHEMA.KEY_COLUMN_USAGE.REFERENCED_COLUMN_NAME
					FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS, INFORMATION_SCHEMA.KEY_COLUMN_USAGE
					WHERE INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_NAME=INFORMATION_SCHEMA.KEY_COLUMN_USAGE.CONSTRAINT_NAME
						AND INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_SCHEMA=INFORMATION_SCHEMA.KEY_COLUMN_USAGE.CONSTRAINT_SCHEMA
						AND INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_SCHEMA='" + this.DbConnection.Database + @"'
						AND INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_TYPE='FOREIGN KEY'
						ORDER BY INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME, INFORMATION_SCHEMA.KEY_COLUMN_USAGE.ORDINAL_POSITION";
                        }

                        System.Data.DataTable Constraints = this.Select(SQL);
                        foreach (System.Data.DataRow Constraint in Constraints.Rows) {
                                switch (Constraint["CONSTRAINT_TYPE"].ToString().ToUpper()) {
                                        case "FOREIGN KEY":
                                                Data.ConstraintDefinition NewKey = new ConstraintDefinition(Constraint["TABLE_NAME"].ToString());
                                                NewKey.Name = Constraint["CONSTRAINT_NAME"].ToString();
                                                NewKey.Column = Constraint["COLUMN_NAME"].ToString();
                                                NewKey.ReferenceTable = Constraint["REFERENCED_TABLE_NAME"].ToString();
                                                NewKey.ReferenceColumn = Constraint["REFERENCED_COLUMN_NAME"].ToString();
                                                if (Res.ContainsKey(NewKey.Name))
                                                        Res[NewKey.Name] = NewKey;
                                                else
                                                        Res.Add(NewKey.Name, NewKey);
                                                break;
                                        default:
                                                throw new NotImplementedException("GetConstraints: " + Constraint["CONSTRAINT_TYPE"].ToString().ToUpper() + " " + Constraint["CONSTRAINT_NAME"].ToString() + " no reconocida");
                                }
                        }
                        return Res;
                }



                public override void Dispose()
                {
                        if (this.Handle == 0 && Lfx.Workspace.Master.Disposing == false) {
                                throw new InvalidOperationException("No se puede deshechar el espacio de trabajo maestro");
                        } else {
                                Lfx.Workspace.Master.ActiveConnections.Remove(this);
                                Log.Info(this.Handle.ToString() + ": Deshechando " + this.Name);

                                base.Dispose();
                        }
                }


                public override void Close()
                {
                        try {
                                base.Close();
                        } catch (Exception ex) {
                                if (Lfx.Workspace.Master.DebugMode)
                                        throw ex;
                        }
                }


                public TableCollection GetTables()
                {
                        TableCollection Res = new Lfx.Data.TableCollection(Lfx.Workspace.Master.MasterConnection);
                        foreach (string TblName in Lfx.Data.DatabaseCache.DefaultCache.GetTableNames()) {
                                Lfx.Data.Table NewTable = new Lfx.Data.Table(Lfx.Workspace.Master.MasterConnection, TblName);
                                switch (TblName) {
                                        case "alicuotas":
                                        case "articulos_codigos":
                                        case "articulos_situaciones":
                                        case "bancos":
                                        case "cajas":
                                        case "conceptos":
                                        case "ciudades":
                                        case "documentos_tipos":
                                        case "formaspago":
                                        case "impresoras":
                                        case "margenes":
                                        case "monedas":
                                        case "paises":
                                        case "personas_tipos":
                                        case "pvs":
                                        case "situaciones":
                                        case "sucursales":
                                        case "sys_permisos_objetos":
                                        case "sys_plantillas":
                                        case "sys_tags":
                                        case "tickets_estados":
                                        case "tipo_doc":
                                                NewTable.AlwaysCache = true;
                                                break;

                                        case "sys_log":
                                        case "sys_programador":
                                        case "sys_config":
                                                NewTable.Cacheable = false;
                                                break;
                                }

                                Res.Add(NewTable);
                        }

                        return Res;
                }


                public int Update(qGen.Update updateCommand)
                {
                        if (this.ReadOnly)
                                throw new InvalidOperationException("No se pueden realizar cambios en la conexión de lectura");

                        if (this.IsOpen() == false)
                                this.Open();

                        using (System.Data.IDbCommand TempCommand = this.GetCommand(updateCommand)) {
                                while (true) {
                                        try {
                                                TempCommand.Connection = this.DbConnection;
                                                this.ResetKeepAliveTimer();
                                                int Res = TempCommand.ExecuteNonQuery();
                                                return Res;
                                        } catch (Exception ex) {
                                                if (this.TryToRecover(ex)) {
                                                        ex.Data.Add("Command", updateCommand.ToString());
                                                        throw ex;
                                                }
                                        }
                                }
                        }
                }

                public int Delete(qGen.Delete deleteCommand)
                {
                        if (this.ReadOnly)
                                throw new InvalidOperationException("No se pueden realizar cambios en la conexión de lectura");

                        if (this.IsOpen() == false)
                                this.Open();

                        return this.ExecuteNonQuery(this.Factory.Formatter.SqlText(deleteCommand));
                }

                public int Insert(qGen.Insert insertCommand)
                {
                        if (this.ReadOnly)
                                throw new InvalidOperationException("No se pueden realizar cambios en la conexión de lectura");

                        if (this.IsOpen() == false)
                                this.Open();

                        System.Data.IDbCommand TempCommand = this.GetCommand(insertCommand);
                        Log.Debug(this.Handle.ToString() + ":  " + TempCommand.CommandText);
                        try {
                                return TempCommand.ExecuteNonQuery();
                        } catch (Exception ex) {
                                Log.Error(TempCommand.CommandText, ex);
                                throw ex;
                        }
                }
                




                public string FieldString(qGen.Select selectCommand)
                {
                        object Res = this.ExecuteScalar(this.Factory.Formatter.SqlText(selectCommand));
                        if (Res == null || Res is DBNull)
                                return null;
                        else
                                return Res.ToString();
                }


                public string FieldString(string selectCommand)
                {
                        object Res = this.ExecuteScalar(selectCommand);
                        if (Res == null || Res is DBNull)
                                return null;
                        else
                                return Res.ToString();
                }

                public string FieldIntCSV(string selectCommand)
                {
                        System.Data.DataTable TmpTable = this.Select(selectCommand);
                        if (TmpTable == null || TmpTable.Rows.Count == 0) {
                                return string.Empty;
                        } else {
                                System.Text.StringBuilder Result = new System.Text.StringBuilder();
                                foreach (System.Data.DataRow Registro in TmpTable.Rows) {
                                        if (Result.Length == 0)
                                                Result.Append(Registro[0].ToString());
                                        else
                                                Result.Append("," + Registro[0].ToString());
                                }
                                return Result.ToString();
                        }
                }


                public IList<int> FieldIntCollection(string selectCommand)
                {
                        System.Collections.Generic.List<int> ListaInts = new List<int>();

                        System.Data.DataTable TmpTable = this.Select(selectCommand);
                        if (TmpTable == null || TmpTable.Rows.Count == 0) {
                                return ListaInts;
                        } else {
                                System.Text.StringBuilder Result = new System.Text.StringBuilder();
                                foreach (System.Data.DataRow Registro in TmpTable.Rows) {
                                        ListaInts.Add(System.Convert.ToInt32(Registro[0]));
                                }
                                return ListaInts;
                        }
                }


                private object ExecuteScalar(string selectCommand)
                {
                        if (this.ReadOnly)
                                throw new InvalidOperationException("No se pueden realizar cambios en la conexión de lectura");

                        if (this.IsOpen() == false)
                                this.Open();

                        System.Data.IDbCommand Cmd = this.GetCommand(selectCommand);
                        Log.Debug(this.Handle.ToString() + ":  " + Cmd.CommandText);
                        int Intentos = 3;
                        while (true) {
                                try {
                                        object Res = Cmd.ExecuteScalar();
                                        return Res;
                                } catch (Exception ex) {
                                        if (this.TryToRecover(ex) || Intentos-- <= 0) {
                                                Log.Error(selectCommand, ex);
                                                ex.Data.Add("Command", selectCommand);
                                                throw ex;
                                        }
                                }
                        }
                }

                public int FieldInt(string selectCommand)
                {
                        object Res = this.ExecuteScalar(selectCommand);
                        if (Res == null || Res is DBNull)
                                return 0;
                        else
                                return System.Convert.ToInt32(Res);
                }

                public int FieldInt(qGen.Select selectCommand)
                {
                        object Res = this.ExecuteScalar(this.Factory.Formatter.SqlText(selectCommand));
                        if (Res == null || Res is DBNull)
                                return 0;
                        else
                                return System.Convert.ToInt32(Res);
                }

                public DateTime FieldDateTime(string selectCommand, DateTime defaultValue)
                {
                        object Res = this.ExecuteScalar(selectCommand);
                        if (Res == null || Res is DBNull)
                                return defaultValue;
                        else
                                return System.Convert.ToDateTime(Res);
                }

                public decimal FieldDecimal(string selectCommand)
                {
                        object Res = this.ExecuteScalar(selectCommand);
                        if (Res == null || Res is DBNull)
                                return 0;
                        else
                                return System.Convert.ToDecimal(Res);
                }

                public decimal FieldDecimal(qGen.Select selectCommand)
                {
                        object Res = this.ExecuteScalar(this.Factory.Formatter.SqlText(selectCommand));
                        if (Res == null || Res is DBNull)
                                return 0;
                        else
                                return System.Convert.ToDecimal(Res);
                }

                public Lfx.Data.Row Row(string tableName, string fieldList, string idField, int id)
                {
                        return this.FirstRowFromSelect("SELECT " + fieldList + " FROM " + tableName + " WHERE " + idField + "=" + id.ToString());
                }

                public Lfx.Data.Row Row(string tableName, string idField, int id)
                {
                        return this.Row(tableName, "*", idField, id);
                }

                public Lfx.Data.Row FirstRowFromSelect(string selectCommand)
                {
                        /* System.Data.DataTable SelTbl = this.Select(selectCommand);
                        if (SelTbl.Rows.Count == 0)
                                return null;

                        Lfx.Data.Row Res = ((Lfx.Data.Row)(SelTbl.Rows[0]));
                        Res.IsNew = false;
                        return Res; */

                        using (System.Data.IDataReader Rdr = this.GetReader(selectCommand)) {
                                if (Rdr != null) {
                                        Lfx.Data.Row Res = null;
                                        if (Rdr.Read()) {
                                                Res = new Lfx.Data.Row();
                                                Res.IsNew = false;
                                                for (int i = 0; i < Rdr.FieldCount; i++) {
                                                        object Val = Rdr[i];
                                                        if (Val is DateTime && (DateTime)Val == DateTime.MinValue)
                                                                Res[Rdr.GetName(i)] = null;
                                                        else if (Val == DBNull.Value)
                                                                Res[Rdr.GetName(i)] = null;
                                                        else
                                                                Res[Rdr.GetName(i)] = Rdr[i];
                                                }
                                                Res.IsModified = false;
                                        }
                                        Rdr.Close();
                                        return Res;
                                } else {
                                        return null;
                                }
                        }
                }

                public Lfx.Data.Row FirstRowFromSelect(qGen.Select selectCommand)
                {
                        return this.FirstRowFromSelect(this.Factory.Formatter.SqlText(selectCommand));
                }


                


                private bool m_ConstraintsEnabled = true;
                public bool ConstraintsEnabled
                {
                        get
                        {
                                return m_ConstraintsEnabled;
                        }
                }

                public void EnableConstraints(bool enable)
                {
                        switch (this.SqlMode) {
                                case qGen.SqlModes.MySql:
                                        if (enable)
                                                this.ExecuteNonQuery(new qGen.SetCommand("FOREIGN_KEY_CHECKS=1"));
                                        else
                                                this.ExecuteNonQuery(new qGen.SetCommand("FOREIGN_KEY_CHECKS=0"));
                                        break;
                                case qGen.SqlModes.PostgreSql:
                                        if (enable)
                                                this.ExecuteNonQuery(new qGen.SetCommand("CONSTRAINTS ALL IMMEDIATE"));
                                        else
                                                this.ExecuteNonQuery(new qGen.SetCommand("CONSTRAINTS ALL DEFERRED"));
                                        break;
                        }
                        m_ConstraintsEnabled = enable;
                }

                public void SetGlobalLock(bool enable)
                {
                        SetLock(enable, "Global");
                }

                public void SetLock(bool enable, string lockName)
                {
                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Lock." + lockName, enable ? 1 : 0);
                        if (enable)
                                System.Threading.Thread.Sleep(5000);
                }

                public bool HasLock(string lockName)
                {
                        Lfx.Workspace.Master.CurrentConfig.ClearCache();
                        return Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Lock." + lockName, 0) != 0;
                }

                public bool HasGlobalLock()
                {
                        return this.HasLock("Global");
                }


                public qGen.SqlModes SqlMode
                {
                        get
                        {
                                return Lfx.Data.DatabaseCache.DefaultCache.SqlMode;
                        }
                }


                public DateTime ServerDateTime
                {
                        get
                        {
                                return this.FieldDateTime("SELECT NOW()", DateTime.Now);
                        }
                }


                private static string m_ServerVersion = null;
                public string ServerVersion
                {
                        get
                        {
                                if (m_ServerVersion == null) {
                                        try {
                                                m_ServerVersion = this.FieldString("SELECT VERSION()");
                                        } catch {
                                                m_ServerVersion = "unknown";
                                        }
                                }
                                return m_ServerVersion;
                        }
                }


                private void SetTransactionIsolationLevel(System.Data.IsolationLevel level)
                {
                        string SqlCommand;
                        switch (this.SqlMode) {
                                case qGen.SqlModes.MySql:
                                        SqlCommand = "SESSION TRANSACTION ISOLATION LEVEL";
                                        break;
                                case qGen.SqlModes.PostgreSql:
                                        SqlCommand = "TRANSACTION ISOLATION LEVEL";
                                        break;
                                default:
                                        SqlCommand = "TRANSACTION ISOLATION LEVEL";
                                        break;
                        }

                        string SqlLevel;
                        switch (level) {
                                case System.Data.IsolationLevel.ReadUncommitted:
                                        SqlLevel = "READ UNCOMMITTED";
                                        break;
                                case System.Data.IsolationLevel.ReadCommitted:
                                        SqlLevel = "READ COMMITTED";
                                        break;
                                case System.Data.IsolationLevel.RepeatableRead:
                                        SqlLevel = "REPEATABLE READ";
                                        break;
                                case System.Data.IsolationLevel.Serializable:
                                        SqlLevel = "SERIALIZABLE";
                                        break;
                                default:
                                        throw new ArgumentException("No se reconoce el nivel de aislamiento");
                        }

                        this.ExecuteNonQuery(new qGen.SetCommand(SqlCommand + " " + SqlLevel));
                }


                public System.Data.IDataReader GetReader(qGen.Select comando)
                {
                        return this.GetReader(this.Factory.Formatter.SqlText(comando));
                }

                protected System.Data.IDataReader GetReader(string selectCommand)
                {
                        if (this.IsOpen() == false)
                                this.Open();

                        System.Data.IDbCommand Cmd = this.GetCommand(selectCommand);
                        while (true) {
                                try {
                                        Cmd.Connection = this.DbConnection;
                                        this.ResetKeepAliveTimer();
                                        System.Data.IDataReader Rdr = Cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                                        return Rdr;
                                } catch (Exception ex) {
                                        if (this.TryToRecover(ex)) {
                                                Log.Error(selectCommand, ex);
                                                ex.Data.Add("Command", selectCommand);
                                                throw ex;
                                        }
                                }
                        }
                }

                public string EscapeString(string stringValue)
                {
                        switch (this.SqlMode) {
                                case qGen.SqlModes.PostgreSql:
                                        return stringValue.Replace("'", "''");
                                case qGen.SqlModes.MySql:
                                default:
                                        return stringValue.Replace("'", "''").Replace(@"\", @"\\");
                        }
                }


                public AccessModes AccessMode
                {
                        get
                        {
                                return Lfx.Data.DatabaseCache.DefaultCache.AccessMode;
                        }
                }
        }
}