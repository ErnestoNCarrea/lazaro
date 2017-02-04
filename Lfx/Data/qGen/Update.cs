using System;
using Lazaro.Orm.Data.Drivers;

namespace qGen
{
        [Serializable]
        public class Update : TableCommand
        {
                public Update()
                        : base() { }

                public Update(string tables)
                        : base(tables) { }

                public Update(Lfx.Data.Connection dataBase, string tables)
                        : base(dataBase, tables) { }

                public Update(string tables, Where whereClause)
                        : base(tables, whereClause) { }

                public Update(SqlModes SqlMode)
                        : base(SqlMode) { }

                public override void SetupDbCommand(ref System.Data.IDbCommand baseCommand)
                {
                        baseCommand.Parameters.Clear();
                        System.Text.StringBuilder FieldList = new System.Text.StringBuilder();
                        foreach (Lfx.Data.Field ThisField in this.Fields) {
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

                                if (FieldList.Length == 0)
                                        FieldList.Append(@"""" + ThisField.ColumnName + @"""=" + FieldParam);
                                else
                                        FieldList.Append(@", """ + ThisField.ColumnName + @"""=" + FieldParam);

                                if (FieldParam == "?" || FieldParam.Substring(0, 1) == "@") {
                                        System.Data.IDbDataParameter Param = Lfx.Data.DataBaseCache.DefaultCache.Provider.GetParameter();
                                        Param.ParameterName = "@" + ThisField.ColumnName;
                                        if (ThisField.Value is NullableDateTime && ThisField.Value != null)
                                                Param.Value = ((NullableDateTime)(ThisField.Value)).Value;
                                        else if (ThisField.Value != null && ThisField.Value.GetType().IsEnum)
                                                Param.Value = System.Convert.ToInt32(ThisField.Value);
                                        else
                                                Param.Value = ThisField.Value;
                                        if (ThisField.DataType == Lazaro.Orm.ColumnTypes.Blob)
                                                Param.DbType = System.Data.DbType.Binary;
                                        if (Lfx.Data.DataBaseCache.DefaultCache.Provider is OdbcDriver && ThisField.DataType == Lazaro.Orm.ColumnTypes.Blob)
                                                ((System.Data.Odbc.OdbcParameter)Param).OdbcType = System.Data.Odbc.OdbcType.VarBinary;
                                        baseCommand.Parameters.Add(Param);
                                }
                        }
                        baseCommand.CommandText = @"UPDATE """ + this.Tables + @""" SET " + FieldList.ToString() + " WHERE " + WhereClause.ToString();
                }

                public string SqlText(SqlModes sqlMode)
                {
                        System.Text.StringBuilder FieldList = new System.Text.StringBuilder();
                        foreach (Lfx.Data.Field ThisField in this.Fields) {
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
                                                        ParamValue = Lfx.Types.Formatting.FormatNumberSql(System.Convert.ToDecimal(ThisField.Value), 8);
                                                        break;
                                                case "System.Integer":
                                                case "System.Int16":
                                                case "System.Int32":
                                                case "System.Int64":
                                                        ParamValue = System.Convert.ToInt32(ThisField.Value).ToString();
                                                        break;
                                                default:
                                                        ParamValue = "'" + Lfx.Data.Connection.EscapeString(ThisField.Value.ToString(), sqlMode) + "'";
                                                        break;
                                        }
                                }

                                FieldList.Append("=" + ParamValue);

                        }

                        return @"UPDATE """ + this.Tables + @""" SET " + FieldList.ToString() + " WHERE " + this.WhereClause.ToString();
                }

                public override string ToString()
                {
                        return this.SqlText(this.SqlMode);
                }
        }
}
