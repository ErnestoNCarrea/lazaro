using System;
using Lazaro.Orm.Data.Drivers;

namespace qGen
{
        [Serializable]
        public class Insert : TableCommand
        {
                public bool OnDuplicateKeyUpdate { get; set; }

                public Insert()
                        : base() { }

                public Insert(string Tables)
                        : base(Tables) { }

                public Insert(Lfx.Data.Connection dataBase, string tables)
                        : base(dataBase, tables) { }

                public Insert(SqlModes SqlMode)
                        : base(SqlMode) { }


                public override void SetupDbCommand(ref System.Data.IDbCommand baseCommand)
                {
                        System.Text.StringBuilder FieldList = new System.Text.StringBuilder();
                        System.Text.StringBuilder ParamList = new System.Text.StringBuilder();
                        foreach (Lfx.Data.Field ThisField in this.Fields) {
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
                                        System.Data.IDbDataParameter Param = Lfx.Data.DataBaseCache.DefaultCache.Provider.GetParameter();
                                        Param.ParameterName = "@" + ThisField.ColumnName;
                                        if (ThisField.Value is NullableDateTime && ThisField.Value != null)
                                                Param.Value = ((NullableDateTime)(ThisField.Value)).Value;
                                        else
                                                Param.Value = ThisField.Value;
                                        if (ThisField.DataType == Lazaro.Orm.ColumnTypes.Blob)
                                                Param.DbType = System.Data.DbType.Binary;
                                        if (Lfx.Data.DataBaseCache.DefaultCache.Provider is OdbcDriver && ThisField.DataType == Lazaro.Orm.ColumnTypes.Blob)
                                                ((System.Data.Odbc.OdbcParameter)Param).OdbcType = System.Data.Odbc.OdbcType.VarBinary;

                                        baseCommand.Parameters.Add(Param);
                                }

                        }
                        baseCommand.CommandText += @"INSERT INTO """ + this.Tables + @""" (" + FieldList.ToString() + ") VALUES (" + ParamList.ToString() + ")";

                        if (this.OnDuplicateKeyUpdate) {
                                string UpdateClause = null;
                                foreach (Lfx.Data.Field ThisField in this.Fields) {
                                        if (UpdateClause == null)
                                                UpdateClause = @" ON DUPLICATE KEY UPDATE """ + ThisField.ColumnName + @"""=VALUES(""" + ThisField.ColumnName + @""")";
                                        else
                                                UpdateClause += @", """ + ThisField.ColumnName + @"""=VALUES(""" + ThisField.ColumnName + @""")";
                                }

                                baseCommand.CommandText += UpdateClause;
                        }
                }

                private string SqlText(SqlModes sqlMode)
                {
                        return this.SqlText(sqlMode, false);
                }

                private string SqlText(SqlModes sqlMode, bool valuesOnly)
                {
                        System.Text.StringBuilder FieldList = new System.Text.StringBuilder();
                        System.Text.StringBuilder ParamList = new System.Text.StringBuilder();
                        foreach (Lfx.Data.Field ThisField in this.Fields) {
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
                                                        ParamValue = "'" + ((NullableDateTime)(ThisField.Value)).Value.ToString(Lfx.Types.Formatting.DateTime.SqlDateTimeFormat) + "'";
                                                        break;
                                                case "DateTime":
                                                        ParamValue = "'" + System.Convert.ToDateTime(ThisField.Value).ToString(Lfx.Types.Formatting.DateTime.SqlDateTimeFormat) + "'";
                                                        break;
                                                case "Single":
                                                case "Double":
                                                case "Decimal":
                                                        ParamValue = Lfx.Types.Formatting.FormatNumberSql(System.Convert.ToDecimal(ThisField.Value), 8);
                                                        break;
                                                case "Integer":
                                                case "Int16":
                                                case "Int32":
                                                case "Int64":
                                                        ParamValue = System.Convert.ToInt32(ThisField.Value).ToString();
                                                        break;
                                                default:
                                                        ParamValue = "'" + Lfx.Data.Connection.EscapeString(ThisField.Value.ToString(), sqlMode) + "'";
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
                                string Res = @"INSERT INTO """ + this.Tables + @""" (" + FieldList.ToString() + ") VALUES (" + ParamList.ToString() + ")";

                                if (this.OnDuplicateKeyUpdate) {
                                        string UpdateClause = null;
                                        foreach (Lfx.Data.Field ThisField in this.Fields) {
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

                public override string ToString()
                {
                        return this.SqlText(this.SqlMode);
                }

                protected internal string ToString(bool valuesOnly)
                {
                        return this.SqlText(this.SqlMode, valuesOnly);
                }
        }
}
