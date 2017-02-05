using System;
using System.Text;
using Lazaro.Orm.Data;
using Lazaro.Orm.Data.Drivers;

namespace qGen
{
        public class MySqlFormatter : IFormatter
        {
                public static readonly string SqlDateFormat = "yyyy-MM-dd";
                public static readonly string SqlDateTimeFormat = "yyyy-MM-dd HH:mm:ss";

                public MySqlFormatter()
                {
                }


                public string EscapeString(string stringValue)
                {
                        return stringValue.Replace("'", "''").Replace(@"\", @"\\");
                }


                public string FormatDecimal(decimal numero, int decimales)
                {
                        string formatearNumeroSqlReturn = null;

                        if (decimales < 0)
                                decimales = 4;

                        formatearNumeroSqlReturn = numero.ToString("0." + "0000000000".Substring(0, decimales),
                                System.Globalization.CultureInfo.InvariantCulture);
                        return formatearNumeroSqlReturn;
                }


                public System.Data.IDbCommand SetupDbCommand(Insert insertCommand, ref System.Data.IDbCommand baseCommand, IConnection connection)
                {
                        System.Text.StringBuilder FieldList = new System.Text.StringBuilder();
                        System.Text.StringBuilder ParamList = new System.Text.StringBuilder();
                        foreach (IColumnValue ThisField in insertCommand.ColumnValues) {
                                if (FieldList.Length == 0)
                                        FieldList.Append(@"""" + ThisField.ColumnName + @"""");
                                else
                                        FieldList.Append(@", """ + ThisField.ColumnName + @"""");

                                string FieldParam;

                                if (ThisField.Value is qGen.SqlFunctions) {
                                        switch (((qGen.SqlFunctions)(ThisField.Value))) {
                                                case SqlFunctions.Now:
                                                        FieldParam = "NOW()";
                                                        break;
                                                default:
                                                        throw new NotImplementedException();
                                        }
                                } else if (ThisField.Value is qGen.SqlExpression) {
                                        FieldParam = ThisField.Value.ToString();
                                } else {
                                        if (baseCommand.Connection is System.Data.Odbc.OdbcConnection)
                                                FieldParam = "?";
                                        else
                                                FieldParam = "@" + ThisField.ColumnName;
                                }

                                if (ParamList.Length == 0)
                                        ParamList.Append(FieldParam);
                                else
                                        ParamList.Append(", " + FieldParam);

                                if (FieldParam == "?" || FieldParam.Substring(0, 1) == "@") {
                                        System.Data.IDbDataParameter Param = connection.Factory.Driver.GetParameter();
                                        Param.ParameterName = "@" + ThisField.ColumnName;
                                        if (ThisField.Value is DbDateTime && ThisField.Value != null)
                                                Param.Value = ((DbDateTime)(ThisField.Value)).Value;
                                        else
                                                Param.Value = ThisField.Value;
                                        if (ThisField.DataType == Lazaro.Orm.ColumnTypes.Blob)
                                                Param.DbType = System.Data.DbType.Binary;

                                        // FIXME: no debería hacer una excepción para OdbcDriver
                                        if (connection.Factory.Driver is OdbcDriver && ThisField.DataType == Lazaro.Orm.ColumnTypes.Blob)
                                                ((System.Data.Odbc.OdbcParameter)Param).OdbcType = System.Data.Odbc.OdbcType.VarBinary;

                                        baseCommand.Parameters.Add(Param);
                                }

                        }
                        baseCommand.CommandText += @"INSERT INTO """ + string.Join<string>(",", insertCommand.Tables) + @""" (" + FieldList.ToString() + ") VALUES (" + ParamList.ToString() + ")";

                        if (insertCommand.OnDuplicateKeyUpdate) {
                                string UpdateClause = null;
                                foreach (IColumnValue ThisField in insertCommand.ColumnValues) {
                                        if (UpdateClause == null)
                                                UpdateClause = @" ON DUPLICATE KEY UPDATE """ + ThisField.ColumnName + @"""=VALUES(""" + ThisField.ColumnName + @""")";
                                        else
                                                UpdateClause += @", """ + ThisField.ColumnName + @"""=VALUES(""" + ThisField.ColumnName + @""")";
                                }

                                baseCommand.CommandText += UpdateClause;
                        }

                        return baseCommand;
                }


                public string SqlText(Insert insert)
                {
                        return this.SqlText(insert, false);
                }

                public string SqlText(Insert insert, bool valuesOnly)
                {
                        System.Text.StringBuilder FieldList = new System.Text.StringBuilder();
                        System.Text.StringBuilder ParamList = new System.Text.StringBuilder();
                        foreach (IColumnValue ThisField in insert.ColumnValues) {
                                if (FieldList.Length == 0)
                                        FieldList.Append(@"""" + ThisField.ColumnName + @"""");
                                else
                                        FieldList.Append(@", """ + ThisField.ColumnName + @"""");

                                string ParamValue = "";
                                if (ThisField.Value == null || ThisField.Value == DBNull.Value) {
                                        ParamValue = "NULL";
                                } else {
                                        string Tipo = ThisField.Value.GetType().Name.Replace("System.", "");
                                        switch (Tipo) {
                                                case "qGen.SqlFunctions":
                                                        switch (((qGen.SqlFunctions)(ThisField.Value))) {
                                                                case SqlFunctions.Now:
                                                                        ParamValue = "NOW()";
                                                                        break;
                                                                default:
                                                                        throw new NotImplementedException();
                                                        }
                                                        break;
                                                case "Lfx.Data.SqlLiteral":
                                                        ParamValue = ThisField.Value.ToString();
                                                        break;
                                                case "Lfx.Data.LDateTime":
                                                        ParamValue = "'" + ((DbDateTime)(ThisField.Value)).Value.ToString(SqlDateTimeFormat) + "'";
                                                        break;
                                                case "DateTime":
                                                        ParamValue = "'" + System.Convert.ToDateTime(ThisField.Value).ToString(SqlDateTimeFormat) + "'";
                                                        break;
                                                case "Single":
                                                case "Double":
                                                case "Decimal":
                                                        ParamValue = this.FormatDecimal(System.Convert.ToDecimal(ThisField.Value), 8);
                                                        break;
                                                case "Integer":
                                                case "Int16":
                                                case "Int32":
                                                case "Int64":
                                                        ParamValue = System.Convert.ToInt32(ThisField.Value).ToString();
                                                        break;
                                                default:
                                                        ParamValue = "'" + this.EscapeString(ThisField.Value.ToString()) + "'";
                                                        break;
                                        }
                                }

                                if (ParamList.Length == 0)
                                        ParamList.Append(ParamValue);
                                else
                                        ParamList.Append(", " + ParamValue);
                        }

                        if (valuesOnly) {
                                return "(" + ParamList.ToString() + ")";
                        } else {
                                string Res = @"INSERT INTO """ + string.Join<string>(",", insert.Tables) + @""" (" + FieldList.ToString() + ") VALUES (" + ParamList.ToString() + ")";

                                if (insert.OnDuplicateKeyUpdate) {
                                        string UpdateClause = null;
                                        foreach (IColumnValue ThisField in insert.ColumnValues) {
                                                if (UpdateClause == null)
                                                        UpdateClause = @" ON DUPLICATE KEY UPDATE """ + ThisField.ColumnName + @"""=VALUES(""" + ThisField.ColumnName + @""")";
                                                else
                                                        UpdateClause += @", """ + ThisField.ColumnName + @"""=VALUES(""" + ThisField.ColumnName + @""")";
                                        }

                                        Res += UpdateClause;
                                }

                                return Res;
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


                public System.Data.IDbCommand SetupDbCommand(IConvertibleToDbCommand command, ref System.Data.IDbCommand dbCommand, IConnection connection)
                {
                        if(command is Update) {
                                return this.SetupDbCommand(command as Update, ref dbCommand, connection);
                        } else if (command is Insert) {
                                return this.SetupDbCommand(command as Insert, ref dbCommand, connection);
                        } else if (command is Delete) {
                                return this.SetupDbCommand(command as Delete, ref dbCommand, connection);
                        } else if (command is BuilkInsert) {
                                return this.SetupDbCommand(command as BuilkInsert, ref dbCommand, connection);
                        } else {
                                throw new NotImplementedException("Unrecognized IConvertibleToDbCommand command type");
                        }
                }


                public string SqlText(Select selectCommand)
                {
                        System.Text.StringBuilder Command = new System.Text.StringBuilder();

                        Command.Append("SELECT ");
                        Command.Append(string.Join(",", selectCommand.Columns));

                        if (selectCommand.Tables != null && selectCommand.Tables.Count > 0) {
                                Command.Append(" FROM " + string.Join<string>(",", selectCommand.Tables));

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
                                        Res.Append("," + join.TableAndAlias);
                                        break;
                                case JoinTypes.LeftJoin:
                                        Res.Append(" LEFT JOIN " + join.TableAndAlias);
                                        break;
                                case JoinTypes.CrossJoin:
                                        Res.Append(" CROSS JOIN " + join.TableAndAlias);
                                        break;
                                case JoinTypes.FullOuterJoin:
                                        Res.Append(" FULL OUTER JOIN " + join.TableAndAlias);
                                        break;
                                case JoinTypes.InnerJoin:
                                        Res.Append(" INNER JOIN " + join.TableAndAlias);
                                        break;
                                case JoinTypes.LeftOuterJoin:
                                        Res.Append(" LEFT OUTER JOIN " + join.TableAndAlias);
                                        break;
                                case JoinTypes.NaturalJoin:
                                        Res.Append(" NATURAL JOIN " + join.TableAndAlias);
                                        break;
                                case JoinTypes.RightOuterJoin:
                                        Res.Append(" RIGHT OUTER JOIN " + join.TableAndAlias);
                                        break;
                        }

                        if (join.On != null && join.On.Length > 0)
                                Res.Append(" ON " + join.On);

                        return Res.ToString();
                }


                public System.Data.IDbCommand SetupDbCommand(Update updateCommand, ref System.Data.IDbCommand dbCommand, IConnection connection)
                {
                        dbCommand.Parameters.Clear();
                        System.Text.StringBuilder FieldList = new System.Text.StringBuilder();
                        foreach (IColumnValue Fld in updateCommand.ColumnValues) {
                                string FieldParam;

                                if (Fld.Value is qGen.SqlFunctions) {
                                        switch (((qGen.SqlFunctions)(Fld.Value))) {
                                                case SqlFunctions.Now:
                                                        FieldParam = "NOW()";
                                                        break;
                                                default:
                                                        throw new NotImplementedException();
                                        }
                                } else if (Fld.Value is qGen.SqlExpression) {
                                        FieldParam = Fld.Value.ToString();
                                } else {
                                        if (dbCommand.Connection is System.Data.Odbc.OdbcConnection)
                                                FieldParam = "?";
                                        else
                                                FieldParam = "@" + Fld.ColumnName;
                                }

                                if (FieldList.Length == 0)
                                        FieldList.Append(@"""" + Fld.ColumnName + @"""=" + FieldParam);
                                else
                                        FieldList.Append(@", """ + Fld.ColumnName + @"""=" + FieldParam);

                                if (FieldParam == "?" || FieldParam.Substring(0, 1) == "@") {
                                        System.Data.IDbDataParameter Param = connection.Factory.Driver.GetParameter();
                                        Param.ParameterName = "@" + Fld.ColumnName;
                                        if (Fld.Value is DbDateTime && Fld.Value != null)
                                                Param.Value = ((DbDateTime)(Fld.Value)).Value;
                                        else if (Fld.Value != null && Fld.Value.GetType().IsEnum)
                                                Param.Value = System.Convert.ToInt32(Fld.Value);
                                        else
                                                Param.Value = Fld.Value;
                                        if (Fld.DataType == Lazaro.Orm.ColumnTypes.Blob)
                                                Param.DbType = System.Data.DbType.Binary;
                                        
                                        // FIXME: no debería hacer una excepción para OdbcDriver
                                        if (connection.Factory.Driver is OdbcDriver && Fld.DataType == Lazaro.Orm.ColumnTypes.Blob)
                                                ((System.Data.Odbc.OdbcParameter)Param).OdbcType = System.Data.Odbc.OdbcType.VarBinary;
                                        dbCommand.Parameters.Add(Param);
                                }
                        }
                        dbCommand.CommandText = @"UPDATE """ + string.Join<string>(",", updateCommand.Tables) + @""" SET " + FieldList.ToString() + " WHERE " + this.SqlText(updateCommand.WhereClause);

                        return dbCommand;
                }

                public string SqlText(Update updateCommand)
                {
                        System.Text.StringBuilder FieldList = new System.Text.StringBuilder();
                        foreach (IColumnValue ThisField in updateCommand.ColumnValues) {
                                if (FieldList.Length == 0)
                                        FieldList.Append(@"""" + ThisField.ColumnName + @"""");
                                else
                                        FieldList.Append(@", """ + ThisField.ColumnName + @"""");

                                string ParamValue = "";
                                if (ThisField.Value == null || ThisField.Value == DBNull.Value) {
                                        ParamValue = "NULL";
                                } else {
                                        switch (ThisField.Value.GetType().Name) {
                                                case "qGen.SqlFunctions":
                                                        switch (((qGen.SqlFunctions)(ThisField.Value))) {
                                                                case SqlFunctions.Now:
                                                                        ParamValue = "NOW()";
                                                                        break;
                                                                default:
                                                                        throw new NotImplementedException();
                                                        }
                                                        break;
                                                case "Lfx.Data.SqlLiteral":
                                                        ParamValue = ThisField.Value.ToString();
                                                        break;
                                                case "System.Single":
                                                case "System.Double":
                                                case "System.Decimal":
                                                        ParamValue = this.FormatDecimal(System.Convert.ToDecimal(ThisField.Value), 8);
                                                        break;
                                                case "System.Integer":
                                                case "System.Int16":
                                                case "System.Int32":
                                                case "System.Int64":
                                                        ParamValue = System.Convert.ToInt32(ThisField.Value).ToString();
                                                        break;
                                                default:
                                                        ParamValue = "'" + this.EscapeString(ThisField.Value.ToString()) + "'";
                                                        break;
                                        }
                                }

                                FieldList.Append("=" + ParamValue);

                        }

                        return @"UPDATE """ + string.Join<string>(", ", updateCommand.Tables) + @""" SET " + FieldList.ToString() + " WHERE " + this.SqlText(updateCommand.WhereClause);
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
                        } else if (value is DbDateTime && value != null) {
                                return "'" + (((DbDateTime)(value)).Value).ToString(SqlDateTimeFormat) + "'";
                        } else if (value is DateTime) {
                                return "'" + ((DateTime)value).ToString(SqlDateTimeFormat) + "'";
                        } else if (value is int || value is long) {
                                return value.ToString();
                        } else if (value is SqlExpression) {
                                return value.ToString();
                        } else if (value is qGen.Select) {
                                // Sub select
                                return "(" + value.ToString() + ")";
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

                public string FormatDateTimeSql(System.DateTime Fecha)
                {
                        return Fecha.ToString(SqlDateTimeFormat);
                }

                public object FormatDateTimeSql(string fecha)
                {
                        object formatearFechaSqlReturn = null;

                        // Permite DDMMYYYY, DD-MM-YYYY, DD/MM/YYYY, DDMMYY, DD-MM-YY y DD/MM/YY
                        if (fecha.Length > 0) {
                                long lngDia = 0;
                                long lngMes = 0;
                                long lngAnio = 0;

                                fecha = fecha.Trim().Replace("-", string.Empty);
                                fecha = fecha.Replace("/", string.Empty);
                                fecha = fecha.Replace(".", string.Empty);

                                lngDia = int.Parse(fecha.Substring(0, 2));
                                lngMes = int.Parse(fecha.Substring(2, 2));
                                lngAnio = int.Parse(fecha.Substring(4, 4));

                                if (lngAnio < 50)
                                        lngAnio = lngAnio + 2000;
                                else if (lngAnio < 100)
                                        lngAnio = lngAnio + 1900;

                                string Resultado = (lngAnio.ToString("0000") + "-" + lngMes.ToString("00") + "-" + lngDia.ToString("00"));

                                if (fecha.Length > 9)
                                        Resultado += " " + fecha.Substring(9, fecha.Length - 9).Trim();

                                formatearFechaSqlReturn = Resultado;
                        } else {
                                formatearFechaSqlReturn = null;
                        }

                        return formatearFechaSqlReturn;
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
                        var Res = "DELETE FROM " + string.Join<string>(",", deleteCommand.Tables);

                        if (deleteCommand.WhereClause != null) {
                                Res += " WHERE " + this.SqlText(deleteCommand.WhereClause);
                        } else if (deleteCommand.EnableDeleleteWithoutWhere == false) {
                                System.Console.WriteLine("SqlDeleteBuilder necesita una cláusula Where o Truncate = true.");
                                return "";
                        }

                        return Res;
                }

                public System.Data.IDbCommand SetupDbCommand(Delete deleteCommand, ref System.Data.IDbCommand dbCommand, IConnection connection)
                {
                        dbCommand.CommandText = this.SqlText(deleteCommand);

                        return dbCommand;
                }


                public System.Data.IDbCommand SetupDbCommand(BuilkInsert insertCommand, ref System.Data.IDbCommand dbCommand, IConnection connection)
                {
                        if (insertCommand.InsertCommands.Count == 0)
                                return dbCommand;

                        System.Text.StringBuilder CmdText = new System.Text.StringBuilder(dbCommand.CommandText);

                        System.Text.StringBuilder FieldList = new System.Text.StringBuilder();
                        foreach (var Fld in insertCommand.ColumnValues) {
                                if (FieldList.Length == 0)
                                        FieldList.Append(@"""" + Fld.ColumnName + @"""");
                                else
                                        FieldList.Append(@", """ + Fld.ColumnName + @"""");

                        }

                        CmdText.Append(@"INSERT INTO """ + string.Join<string>(",", insertCommand.Tables) + @""" (" + FieldList.ToString() + ") VALUES ");
                        int CmdNum = 1;
                        foreach (Insert Cmd in insertCommand.InsertCommands) {
                                System.Text.StringBuilder ParamList = new System.Text.StringBuilder();
                                foreach (IColumnValue ThisField in Cmd.ColumnValues) {
                                        string FieldParam;

                                        string ParamName = "@" + ThisField.ColumnName + "_" + CmdNum.ToString();
                                        if (ThisField.Value is qGen.SqlFunctions) {
                                                switch (((qGen.SqlFunctions)(ThisField.Value))) {
                                                        case SqlFunctions.Now:
                                                                FieldParam = "NOW()";
                                                                break;
                                                        default:
                                                                throw new NotImplementedException();
                                                }
                                        } else if (ThisField.Value is qGen.SqlExpression) {
                                                FieldParam = ThisField.Value.ToString();
                                        } else {
                                                if (dbCommand.Connection is System.Data.Odbc.OdbcConnection)
                                                        FieldParam = "?";
                                                else
                                                        FieldParam = ParamName;
                                        }

                                        if (ParamList.Length == 0)
                                                ParamList.Append(FieldParam);
                                        else
                                                ParamList.Append(", " + FieldParam);

                                        if (FieldParam == "?" || FieldParam.Substring(0, 1) == "@") {
                                                System.Data.IDbDataParameter Param = connection.Factory.Driver.GetParameter();
                                                Param.ParameterName = ParamName;
                                                if (ThisField.Value is DbDateTime && ThisField.Value != null)
                                                        Param.Value = ((DbDateTime)(ThisField.Value)).Value;
                                                else
                                                        Param.Value = ThisField.Value;
                                                if (ThisField.DataType == Lazaro.Orm.ColumnTypes.Blob)
                                                        Param.DbType = System.Data.DbType.Binary;

                                                // FIXME: No debería hacer una excepción para ODBC
                                                if (connection.Factory.Driver is OdbcDriver && ThisField.DataType == Lazaro.Orm.ColumnTypes.Blob)
                                                        ((System.Data.Odbc.OdbcParameter)Param).OdbcType = System.Data.Odbc.OdbcType.VarBinary;

                                                dbCommand.Parameters.Add(Param);
                                        }

                                }
                                if (CmdNum > 1)
                                        CmdText.AppendLine(",");
                                CmdText.Append(@"(" + ParamList.ToString() + ")");
                                CmdNum++;
                        }

                        dbCommand.CommandText = CmdText.ToString();

                        return dbCommand;
                }

                public string SqlText(BuilkInsert insertCommand)
                {
                        System.Text.StringBuilder Res = null;

                        foreach (Insert Cmd in insertCommand.InsertCommands) {
                                if (Res == null) {
                                        Res = new System.Text.StringBuilder();
                                        Res.AppendLine(this.SqlText(Cmd));
                                } else {
                                        Res.Append(", ");
                                        Res.AppendLine(this.SqlText(Cmd, true));
                                }
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