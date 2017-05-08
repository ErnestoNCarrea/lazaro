using System;
using System.Text;
using Lazaro.Orm.Data;
using Lazaro.Orm.Data.Drivers;
using System.Data;
using System.Collections.Generic;

namespace qGen
{
        public class SqlFormatter : IFormatter
        {
                public static SqlFormatter DefaultFormatter = new SqlFormatter();

                public FormatterParameters Parameters = FormatterParameters.MySqlAnsiFormatterParameters;

                public static readonly string SqlDateFormat = "yyyy-MM-dd";
                public static readonly string SqlDateTimeFormat = "yyyy-MM-dd HH:mm:ss";

                public SqlFormatter()
                {
                }


                public string EscapeString(string stringValue)
                {
                        return stringValue.Replace("'", "''").Replace(@"\", @"\\");
                }


                public string FormatDecimal(decimal numero, int decimales)
                {
                        if (decimales < 0)
                                decimales = 4;

                        return numero.ToString("0." + "0000000000".Substring(0, decimales),
                                System.Globalization.CultureInfo.InvariantCulture);
                }

                public string SqlText(SqlIdentifierCollection identifiers)
                {
                        var Res = new StringBuilder();

                        foreach(var tblName in identifiers) {
                                if(Res.Length > 0) {
                                        Res.Append(", ");
                                }
                                Res.Append(SqlText(tblName));
                        }

                        return Res.ToString();
                }

                protected string QuoteIdentifier(string identifier)
                {
                        return Parameters.IdentifierOpenQuote + identifier + Parameters.IdentifierCloseQuote;
                }

                public string SqlText(SqlIdentifier identifier)
                {
                        return this.QuoteIdentifier(identifier.Prefix, identifier.Name, identifier.Alias);
                }

                protected string QuoteIdentifier(string prefix, string name, string alias)
                {
                        string Res = "";

                        if (string.IsNullOrEmpty(prefix) == false) {
                                Res += Parameters.IdentifierOpenQuote + prefix + Parameters.IdentifierCloseQuote + ".";
                        }

                        if (SqlIdentifier.IsValidIdentifierName(name)) {
                                Res += Parameters.IdentifierOpenQuote + name + Parameters.IdentifierCloseQuote;
                        } else {
                                // Do not quote. Not a real identifier.
                                Res += name;
                        }

                        if (string.IsNullOrEmpty(alias) == false) {
                                Res += " AS " + Parameters.IdentifierOpenQuote + alias + Parameters.IdentifierCloseQuote;
                        }

                        return Res;
                }


                public System.Data.IDbCommand SetupDbCommand(Insert insertCommand, IConnection connection)
                {
                        var DbCommand = connection.DbConnection.CreateCommand();

                        DbCommand.CommandText =
                                @"INSERT INTO "
                                + this.SqlText(insertCommand.Tables)
                                + " "
                                + this.SqlText(insertCommand.ColumnValues, ColumnValueFormatStyles.InsertStyle, true);

                        if (insertCommand.WhereClause != null) {
                                DbCommand.CommandText += " WHERE " + this.SqlText(insertCommand.WhereClause);
                        }

                        if (insertCommand.OnDuplicateKeyUpdate) {
                                var UpdateClause = new StringBuilder();
                                foreach (IColumnValue ThisField in insertCommand.ColumnValues) {
                                        if (UpdateClause.Length == 0) {
                                                UpdateClause.Append(" ON DUPLICATE KEY UPDATE ");
                                        } else {
                                                UpdateClause.Append(", ");
                                        }
                                        UpdateClause.Append(this.SqlText(ThisField.ColumnIdentifier) + @"=VALUES(" + this.SqlText(ThisField.ColumnIdentifier) + @")");
                                }

                                DbCommand.CommandText += UpdateClause.ToString();
                        }

                        this.PopulateParameters(connection, DbCommand.Parameters, insertCommand.ColumnValues);

                        return DbCommand;
                }


                public string SqlText(Insert insert)
                {
                        return this.SqlText(insert, false);
                }


                public string SqlText(Insert insertCommand, bool valuesOnly)
                {
                        if (valuesOnly) {
                                return this.SqlText(insertCommand.ColumnValues, ColumnValueFormatStyles.InsertStyleValuesOnly, false);
                        } else {
                                var Res = new StringBuilder();

                                Res.Append("INSERT INTO ");
                                Res.Append(this.SqlText(insertCommand.Tables));
                                Res.Append(" ");
                                Res.Append(this.SqlText(insertCommand.ColumnValues, ColumnValueFormatStyles.InsertStyle, false));
                                ;

                                if (insertCommand.WhereClause != null) {
                                        Res.Append(" WHERE " + this.SqlText(insertCommand.WhereClause));
                                }

                                if (insertCommand.OnDuplicateKeyUpdate) {
                                        var First = true;
                                        foreach (IColumnValue ThisField in insertCommand.ColumnValues) {
                                                if (First) {
                                                        First = false;
                                                        Res.Append(@" ON DUPLICATE KEY UPDATE ");
                                                } else {
                                                        Res.Append(@", ");
                                                }
                                                Res.Append(this.SqlText(ThisField.ColumnIdentifier) + @"=VALUES(" + this.SqlText(ThisField.ColumnIdentifier) + @")");
                                        }
                                }

                                return Res.ToString();
                        }
                }


                public string SqlText(IStatementOrQuery command)
                {
                        if (command is Select) {
                                return this.SqlText(command as Select);
                        } else if (command is Update) {
                                return this.SqlText(command as Update);
                        } else if (command is Insert) {
                                return this.SqlText(command as Insert);
                        } else if (command is Delete) {
                                return this.SqlText(command as Delete);
                        } else if (command is SetCommand) {
                                return this.SqlText(command as SetCommand);
                        } else if (command is BeginTransactionCommand) {
                                return this.SqlText(command as BeginTransactionCommand);
                        } else if (command is CommitCommand) {
                                return this.SqlText(command as CommitCommand);
                        } else if (command is RollBackCommand) {
                                return this.SqlText(command as RollBackCommand);
                        } else if (command is BuilkInsert) {
                                return this.SqlText(command as BuilkInsert);
                        } else {
                                throw new NotImplementedException("Unrecognized ICommand command type " + command.GetType().ToString());
                        }
                }


                public string SqlText(Select selectCommand)
                {
                        System.Text.StringBuilder Command = new System.Text.StringBuilder();

                        Command.Append("SELECT " + this.SqlText(selectCommand.Columns));

                        if (selectCommand.Tables != null && selectCommand.Tables.Count > 0) {
                                Command.Append(" FROM " + this.SqlText(selectCommand.Tables));

                                foreach (Join Jo in selectCommand.Joins) {
                                        Command.Append(this.SqlText(Jo));
                                }
                        }

                        if (selectCommand.WhereClause != null) {
                                string WhereString = this.SqlText(selectCommand.WhereClause);

                                if (WhereString.Length > 0)
                                        Command.Append(" WHERE " + WhereString);
                        }

                        if (selectCommand.Group != null && selectCommand.Group.Length > 0)
                                Command.Append(" GROUP BY " + selectCommand.Group);

                        if (selectCommand.HavingClause != null) {
                                string HavingString = this.SqlText(selectCommand.HavingClause);

                                if (HavingString.Length > 0)
                                        Command.Append(" HAVING " + HavingString);
                        }

                        if (selectCommand.Order != null && selectCommand.Order.Length > 0)
                                Command.Append(" ORDER BY " + selectCommand.Order);

                        if (selectCommand.Window != null && selectCommand.Window.Limit > 0) {
                                Command.Append(" LIMIT " + selectCommand.Window.Limit.ToString());
                                if (selectCommand.Window.Offset > 0) {
                                        Command.Append(" OFFSET " + selectCommand.Window.Offset.ToString());
                                }
                        }

                        if (selectCommand.ForUpdate) {
                                Command.Append(" FOR UPDATE");
                        }

                        return Command.ToString();
                }


                public string SqlText(Join join)
                {
                        System.Text.StringBuilder Res = new System.Text.StringBuilder();
                        switch (join.JoinType) {
                                case JoinTypes.ImplicitJoin:
                                        Res.Append("," + this.SqlText(join.Table));
                                        break;
                                case JoinTypes.LeftJoin:
                                        Res.Append(" LEFT JOIN " + this.SqlText(join.Table));
                                        break;
                                case JoinTypes.CrossJoin:
                                        Res.Append(" CROSS JOIN " + this.SqlText(join.Table));
                                        break;
                                case JoinTypes.FullOuterJoin:
                                        Res.Append(" FULL OUTER JOIN " + this.SqlText(join.Table));
                                        break;
                                case JoinTypes.InnerJoin:
                                        Res.Append(" INNER JOIN " + this.SqlText(join.Table));
                                        break;
                                case JoinTypes.LeftOuterJoin:
                                        Res.Append(" LEFT OUTER JOIN " + this.SqlText(join.Table));
                                        break;
                                case JoinTypes.NaturalJoin:
                                        Res.Append(" NATURAL JOIN " + this.SqlText(join.Table));
                                        break;
                                case JoinTypes.RightOuterJoin:
                                        Res.Append(" RIGHT OUTER JOIN " + this.SqlText(join.Table));
                                        break;
                        }

                        if (string.IsNullOrEmpty(join.On) == false) {
                                Res.Append(" ON " + join.On);
                        }

                        return Res.ToString();
                }


                public System.Data.IDbCommand SetupDbCommand(Update updateCommand, IConnection connection)
                {
                        var DbCommand = connection.DbConnection.CreateCommand();

                        DbCommand.CommandText =
                                @"UPDATE "
                                + this.SqlText(updateCommand.Tables)
                                + @" SET "
                                + this.SqlText(updateCommand.ColumnValues, ColumnValueFormatStyles.UpdateStyle, true)
                                + " WHERE " + this.SqlText(updateCommand.WhereClause);

                        this.PopulateParameters(connection, DbCommand.Parameters, updateCommand.ColumnValues);

                        return DbCommand;
                }

                public void PopulateParameters(IConnection connection, IDataParameterCollection parameters, ColumnValueCollection columnValues)
                {
                        foreach (IColumnValue Fld in columnValues) {
                                if (Fld.ValueCanBeParameter) {
                                        var Param = connection.Factory.Driver.GetParameter();
                                        Param.ParameterName = "@" + this.GetParameterName(Fld.ColumnIdentifier);
                                        if (Fld.Value is DbDateTime && Fld.Value != null) {
                                                Param.Value = ((DbDateTime)(Fld.Value)).Value;
                                        } else if (Fld.Value != null && Fld.Value.GetType().IsEnum) {
                                                Param.Value = System.Convert.ToInt32(Fld.Value);
                                        } else {
                                                Param.Value = Fld.Value;
                                        }
                                        if (Fld.DataType == Lazaro.Orm.ColumnTypes.Blob) {
                                                Param.DbType = System.Data.DbType.Binary;
                                        }

                                        // FIXME: no debería hacer una excepción para OdbcDriver
                                        if (connection.Factory.Driver is OdbcDriver && Fld.DataType == Lazaro.Orm.ColumnTypes.Blob)
                                                ((System.Data.Odbc.OdbcParameter)Param).OdbcType = System.Data.Odbc.OdbcType.VarBinary;

                                        parameters.Add(Param);
                                }
                        }
                }

                public string SqlText(Update updateCommand)
                {
                        return @"UPDATE " + this.SqlText(updateCommand.Tables) 
                                + @" SET " 
                                + this.SqlText(updateCommand.ColumnValues, ColumnValueFormatStyles.UpdateStyle, false) 
                                + " WHERE " + this.SqlText(updateCommand.WhereClause);
                }


                /// <summary>
                /// Returns an SQL representation of a collection of identifier names (i.e. column names) and
                /// values.
                /// </summary>
                /// <param name="columnValues">The collection containin one or more pair of column name and value.</param>
                /// <param name="style">Update or Insert style.</param>
                /// <param name="useParameters">Use parameter names instead of actual values.</param>
                /// <returns>A string containing the SQL portion.</returns>
                private string SqlText(ColumnValueCollection columnValues, ColumnValueFormatStyles style, bool useParameters)
                {
                        switch (style) {
                                case ColumnValueFormatStyles.UpdateStyle:
                                        // UPDATE style: col1=val1, col2=val2, ...
                                        var ResUpd = new StringBuilder();
                                        foreach (var Col in columnValues) {
                                                if (ResUpd.Length > 0) {
                                                        ResUpd.Append(", ");
                                                }
                                                ResUpd.Append(this.SqlText(Col.ColumnIdentifier));
                                                ResUpd.Append("=");
                                                if (useParameters && Col.ValueCanBeParameter) {
                                                        ResUpd.Append("@" + this.GetParameterName(Col.ColumnIdentifier));
                                                } else {
                                                        ResUpd.Append(this.FormatValue(Col.Value));
                                                }
                                        }
                                        return ResUpd.ToString();

                                case ColumnValueFormatStyles.InsertStyle:
                                        // INSERT style: (col1, col2, ...) VAUES (val1, val2, ...)
                                        var ResInsCols = new StringBuilder();
                                        var ResInsVals = new StringBuilder();

                                        foreach (var Col in columnValues) {
                                                if (ResInsCols.Length > 0) {
                                                        ResInsCols.Append(", ");
                                                        ResInsVals.Append(", ");
                                                }
                                                ResInsCols.Append(this.SqlText(Col.ColumnIdentifier));
                                                if (useParameters && Col.ValueCanBeParameter) {
                                                        ResInsVals.Append("@" + this.GetParameterName(Col.ColumnIdentifier));
                                                } else {
                                                        ResInsVals.Append(this.FormatValue(Col.Value));
                                                }
                                        }
                                        return "(" + ResInsCols.ToString() + ") VALUES (" + ResInsVals.ToString() + ")";

                                case ColumnValueFormatStyles.InsertStyleValuesOnly:
                                        // INSERT style: (col1, col2, ...) VAUES (val1, val2, ...)
                                        var ResInsValsOnly = new StringBuilder();

                                        foreach (var Col in columnValues) {
                                                if (ResInsValsOnly.Length > 0) {
                                                        ResInsValsOnly.Append(", ");
                                                }
                                                if (useParameters && Col.ValueCanBeParameter) {
                                                        ResInsValsOnly.Append("@" + this.GetParameterName(Col.ColumnIdentifier));
                                                } else {
                                                        ResInsValsOnly.Append(this.FormatValue(Col.Value));
                                                }
                                        }
                                        return "(" + ResInsValsOnly.ToString() + ")";

                                default:
                                        throw new NotImplementedException("Unknown ColumnValueFormatStyles " + style.ToString());
                        }
                }

                /// <summary>
                /// Generates a unique name for an identifier, to use as a named parameter.
                /// </summary>
                /// <param name="columnIdentifier">The identifier definition.</param>
                /// <returns>A string containing the generated name.</returns>
                public string GetParameterName(SqlIdentifier columnIdentifier)
                {
                        return "param_" + columnIdentifier.Definition.Trim().Replace('.', '_').Replace(' ', '_');
                }

                public string SqlText(Where whereClause)
                {
                        if (whereClause.Count > 0) {
                                System.Text.StringBuilder Command = new System.Text.StringBuilder();

                                foreach (ICondition Cond in whereClause) {
                                        if (Cond != null) {
                                                if (whereClause.Operator == AndOr.And) {
                                                        Command.Append(" AND ");
                                                } else {
                                                        Command.Append(" OR ");
                                                }

                                                Command.Append(this.SqlText(Cond));
                                        }
                                }

                                string CommandString = Command.ToString().TrimStart();

                                if (CommandString.Length > 0) {
                                        // Debería quedar slamente "condición", "cond AND cond", "cond AND cond AND cond", etc.
                                        // Me deshago de cosas invalidas como operadores sin condicion ("AND"),
                                        // operadores de más (AND cond AND cond), etc.
                                        if (CommandString == "AND" || CommandString == "OR") {
                                                return "";
                                        } else if (CommandString.Length >= 4 && CommandString.Substring(0, 4) == "AND ") {
                                                CommandString = CommandString.Substring(4, CommandString.Length - 4);
                                        } else if (CommandString.Length >= 3 && CommandString.Substring(0, 3) == "OR ") {
                                                CommandString = CommandString.Substring(3, CommandString.Length - 3);
                                        }
                                }

                                if (CommandString.Length > 0) {
                                        return "(" + CommandString + ")";
                                } else {
                                        return "";
                                }
                        } else {
                                return "TRUE";
                        }
                }

                public string SqlText(ICondition cond)
                {
                        if (cond is NestedCondition) {
                                return this.SqlText(cond as NestedCondition);
                        } else if (cond is SqlCondition) {
                                return this.SqlText(cond as SqlCondition);
                        } else if (cond is ComparisonCondition) {
                                return this.SqlText(cond as ComparisonCondition);
                        } else {
                                throw new NotImplementedException("Not implemented condition type");
                        }
                }

                public string SqlText(SqlCondition sqlCond)
                {
                        return sqlCond.Text;
                }

                public string SqlText(NestedCondition nestedCond)
                {
                        if (nestedCond.Where.Count > 0) {
                                return "(" + this.SqlText(nestedCond.Where) + ")";
                        } else {
                                return "";
                        }
                }


                public string FormatValue(object value)
                {
                        if (value == null || value is DBNull) {
                                return "NULL";
                        } else if (value is double || value is decimal) {
                                return this.FormatDecimal(System.Convert.ToDecimal(value), 8);
                        } else if (value is DbDateTime) {
                                return "'" + (((DbDateTime)(value)).Value).ToString(SqlDateTimeFormat) + "'";
                        } else if (value is DateTime) {
                                return "'" + ((DateTime)value).ToString(SqlDateTimeFormat) + "'";
                        } else if (value is int || value is long) {
                                return value.ToString();
                        } else if (value is SqlExpression) {
                                return value.ToString();
                        } else if (value is qGen.Select) {
                                // Sub select
                                return "(" + this.SqlText(value as qGen.Select) + ")";
                        } else if (value is SqlFunctions) {
                                switch ((SqlFunctions)value) {
                                        case SqlFunctions.Now:
                                                return "NOW()";
                                        default:
                                                return value.ToString();
                                }
                        } else if (value is int[]) {
                                string[] RightValStr = Array.ConvertAll<int, string>((int[])value, new Converter<int, string>(Convert.ToString));
                                return string.Join<string>(",", RightValStr);
                        } else if (value is string[]) {
                                string[] EscapedStrings = ((string[])(value));
                                for (int i = 0; i < EscapedStrings.Length; i++) {
                                        EscapedStrings[i] = this.EscapeString(EscapedStrings[i]);
                                }
                                return "'" + string.Join("','", EscapedStrings) + "'";
                        } else if (value is System.Collections.IList) {
                                // Si es una lista, formateo cada uno de los elementos
                                StringBuilder Res = new StringBuilder();
                                System.Collections.IList Lista = (System.Collections.IList)value;
                                foreach (object a in Lista) {
                                        if (Res.Length == 0)
                                                Res.Append(FormatValue(a));
                                        else
                                                Res.Append("," + FormatValue(a));
                                }
                                return Res.ToString();
                        } else {
                                return "'" + this.EscapeString(value.ToString()) + "'";
                        }
                }

                public static string FormatDateTimeSql(System.DateTime dateToFormat)
                {
                        return dateToFormat.ToString(SqlDateTimeFormat);
                }

                public static object FormatDateTimeSql(string dateToFormat)
                {
                        // Permite DDMMYYYY, DD-MM-YYYY, DD/MM/YYYY, DDMMYY, DD-MM-YY y DD/MM/YY
                        if (dateToFormat.Length > 0) {
                                dateToFormat = dateToFormat.Trim().Replace("-", string.Empty);
                                dateToFormat = dateToFormat.Replace("/", string.Empty);
                                dateToFormat = dateToFormat.Replace(".", string.Empty);

                                var dateDay = int.Parse(dateToFormat.Substring(0, 2));
                                var dateMonth = int.Parse(dateToFormat.Substring(2, 2));
                                var dateYear = int.Parse(dateToFormat.Substring(4, 4));

                                if (dateYear < 50)
                                        dateYear = dateYear + 2000;
                                else if (dateYear < 100)
                                        dateYear = dateYear + 1900;

                                var Res = (dateYear.ToString("0000") + "-" + dateMonth.ToString("00") + "-" + dateDay.ToString("00"));

                                if (dateToFormat.Length > 9)
                                        Res += " " + dateToFormat.Substring(9, dateToFormat.Length - 9).Trim();

                                return Res;
                        } else {
                                return null;
                        }
                }


                public string SqlText(ComparisonCondition cond)
                {
                        string Result = null;

                        switch (cond.Operator) {
                                case qGen.ComparisonOperators.NullSafeEquals:
                                        Result = cond.LeftValue + "<=>" + FormatValue(cond.RightValue);
                                        break;

                                case qGen.ComparisonOperators.Equals:
                                        if (cond.RightValue == null)
                                                Result = cond.LeftValue + " IS " + FormatValue(cond.RightValue);
                                        else
                                                Result = cond.LeftValue + "=" + FormatValue(cond.RightValue);
                                        break;

                                case qGen.ComparisonOperators.GreaterOrEqual:
                                        Result = cond.LeftValue + ">=" + FormatValue(cond.RightValue);
                                        break;

                                case qGen.ComparisonOperators.GreaterThan:
                                        Result = cond.LeftValue + ">" + FormatValue(cond.RightValue);
                                        break;

                                case qGen.ComparisonOperators.InsensitiveLike:
                                        Result = cond.LeftValue + " LIKE " + FormatValue(cond.RightValue);
                                        break;

                                case qGen.ComparisonOperators.InsensitiveNotLike:
                                        Result = cond.LeftValue + " NOT LIKE " + FormatValue(cond.RightValue);
                                        break;

                                case qGen.ComparisonOperators.LessOrEqual:
                                        Result = cond.LeftValue + "<=" + FormatValue(cond.RightValue);
                                        break;

                                case qGen.ComparisonOperators.LessThan:
                                        Result = cond.LeftValue + "<" + FormatValue(cond.RightValue);
                                        break;

                                case qGen.ComparisonOperators.NotEqual:
                                        if (cond.RightValue == null)
                                                Result = cond.LeftValue + " IS NOT " + FormatValue(cond.RightValue);
                                        else
                                                Result = cond.LeftValue + "<>" + FormatValue(cond.RightValue);
                                        break;

                                case qGen.ComparisonOperators.SensitiveLike:
                                        Result = "BINARY " + cond.LeftValue + " LIKE BINARY " + FormatValue(cond.RightValue);
                                        break;

                                case qGen.ComparisonOperators.SensitiveNotLike:
                                        Result = "BINARY " + cond.LeftValue + " NOT LIKE BINARY " + FormatValue(cond.RightValue);
                                        break;

                                case qGen.ComparisonOperators.SoundsLike:
                                        // FIXME: Parece que el SOUNDS LIKE no funciona bien en MySql
                                        // Result = LeftValue.Replace("%", "") & " SOUNDS LIKE " & RightValue.Replace("%", "")
                                        Result = cond.LeftValue + " LIKE " + FormatValue(cond.RightValue);
                                        break;

                                case qGen.ComparisonOperators.In:
                                        Result = cond.LeftValue + " IN (" + FormatValue(cond.RightValue) + ")";
                                        break;

                                case qGen.ComparisonOperators.NotIn:
                                        Result = cond.LeftValue + " NOT IN (" + FormatValue(cond.RightValue) + ")";
                                        break;

                                case ComparisonOperators.Between:
                                        Result = cond.LeftValue + " BETWEEN " + FormatValue(cond.RightValue) + " AND " + FormatValue(cond.RightValue2);
                                        break;
                        }

                        return Result;
                }

                public string SqlText(Delete deleteCommand)
                {
                        var Res = "DELETE FROM " + this.SqlText(deleteCommand.Tables);

                        if (deleteCommand.WhereClause != null) {
                                Res += " WHERE " + this.SqlText(deleteCommand.WhereClause);
                        } else if (deleteCommand.EnableDeleleteWithoutWhere == false) {
                                System.Console.WriteLine("SqlDeleteBuilder needs a Where clause or EnableDeleleteWithoutWhere = true.");
                                return "";
                        }

                        return Res;
                }

                public System.Data.IDbCommand SetupDbCommand(Delete deleteCommand, IConnection connection)
                {
                        var DbCommand = connection.DbConnection.CreateCommand();

                        DbCommand.CommandText = this.SqlText(deleteCommand);

                        return DbCommand;
                }


                public System.Data.IDbCommand SetupDbCommand(IStatementOrQuery statementOrQuery, IConnection connection)
                {
                        if (statementOrQuery is Update) {
                                return this.SetupDbCommand(statementOrQuery as Update, connection);
                        } else if (statementOrQuery is Insert) {
                                return this.SetupDbCommand(statementOrQuery as Insert, connection);
                        } else if (statementOrQuery is Delete) {
                                return this.SetupDbCommand(statementOrQuery as Delete, connection);
                        } else if (statementOrQuery is BuilkInsert) {
                                return SetupDbCommand(statementOrQuery as BuilkInsert, connection);
                        } else {
                                var DbCommand = connection.DbConnection.CreateCommand();
                                DbCommand.CommandText = this.SqlText(statementOrQuery);
                                return DbCommand;
                        }
                }


                public System.Data.IDbCommand SetupDbCommand(BuilkInsert bulkInsertCommand, IConnection connection)
                {
                        var DbCommand = connection.DbConnection.CreateCommand();

                        var CmdText = new StringBuilder();
                        CmdText.Append("INSERT INTO ");
                        CmdText.Append(this.SqlText(bulkInsertCommand.Tables));
                        CmdText.Append(" ");
                        CmdText.Append(this.SqlText(bulkInsertCommand.InsertCommands[0].ColumnValues, ColumnValueFormatStyles.InsertStyle, true));

                        this.PopulateParameters(connection, DbCommand.Parameters, bulkInsertCommand.InsertCommands[0].ColumnValues);

                        if(bulkInsertCommand.InsertCommands.Count > 1) {
                                var Skip = true;
                                foreach(var Ic in bulkInsertCommand.InsertCommands) {
                                        if(Skip) {
                                                // Skip first INSERT, which is already included above
                                                Skip = false;
                                        } else {
                                                CmdText.Append(this.SqlText(Ic, true));
                                                this.PopulateParameters(connection, DbCommand.Parameters, Ic.ColumnValues);
                                        }
                                }
                        }


                        if (bulkInsertCommand.WhereClause != null) {
                                CmdText.Append(" WHERE " + this.SqlText(bulkInsertCommand.WhereClause));
                        }

                        DbCommand.CommandText = CmdText.ToString();

                        return DbCommand;
                }

                public string SqlText(BuilkInsert bulkInsertCommand)
                {
                        System.Text.StringBuilder Res = null;

                        foreach (Insert Cmd in bulkInsertCommand.InsertCommands) {
                                if (Res == null) {
                                        Res = new System.Text.StringBuilder();
                                        Res.AppendLine(this.SqlText(Cmd));
                                } else {
                                        Res.Append(", ");
                                        Res.AppendLine(this.SqlText(Cmd, true));
                                }
                        }

                        if (bulkInsertCommand.WhereClause != null) {
                                Res.Append(" WHERE " + this.SqlText(bulkInsertCommand.WhereClause));
                        }

                        if (Res == null)
                                return "";
                        else
                                return Res.ToString();
                }

                public string SqlText(BeginTransactionCommand cmd)
                {
                        return "START TRANSACTION WITH CONSISTENT SNAPSHOT";
                }

                public string SqlText(CommitCommand cmd)
                {
                        return "COMMIT";
                }

                public string SqlText(RollBackCommand cmd)
                {
                        return "ROLLBACK";
                }

                public string SqlText(SetCommand cmd)
                {
                        return "SET " + cmd.SetParameters;
                }
        }
}