using System;
using System.Collections.Generic;
using Lazaro.Orm.Data.Drivers;

namespace qGen
{
        [Serializable]
        public class BuilkInsert : TableCommand
        {
                System.Collections.Generic.List<Insert> InsertCommands = new List<Insert>();

                public void Clear()
                {
                        this.InsertCommands.Clear();
                }

                public void Add(Insert insertCommand)
                {
                        if (this.InsertCommands.Count > 0) {
                                if (this.Tables != insertCommand.Tables)
                                        throw new ArgumentException("qGen: BulkInsert requiere que todas las inserciones sean en la misma tabla y con los mismos campos");
                        } else {
                                this.Tables = insertCommand.Tables;
                                this.Fields = insertCommand.Fields;
                                this.DataBase = insertCommand.DataBase;
                                this.WhereClause = insertCommand.WhereClause;
                                this.m_Mode = insertCommand.m_Mode;
                        }
                        this.InsertCommands.Add(insertCommand);
                }

                public int Count
                {
                        get
                        {
                                return this.InsertCommands.Count;
                        }
                }

                public override string ToString()
                {
                        System.Text.StringBuilder Res = null;
                        foreach (Insert Cmd in this.InsertCommands) {
                                if (Res == null) {
                                        Res = new System.Text.StringBuilder();
                                        Res.AppendLine(Cmd.ToString());
                                } else {
                                        Res.Append(", ");
                                        Res.AppendLine(Cmd.ToString(true));
                                }
                        }
                        if (Res == null)
                                return "";
                        else
                                return Res.ToString();
                }


                public override void SetupDbCommand(ref System.Data.IDbCommand baseCommand)
                {
                        if (this.InsertCommands.Count == 0)
                                return;

                        System.Text.StringBuilder CmdText = new System.Text.StringBuilder(baseCommand.CommandText);

                        System.Text.StringBuilder FieldList = new System.Text.StringBuilder();
                        foreach (Lfx.Data.Field ThisField in this.Fields) {
                                if (FieldList.Length == 0)
                                        FieldList.Append(@"""" + ThisField.ColumnName + @"""");
                                else
                                        FieldList.Append(@", """ + ThisField.ColumnName + @"""");

                        }

                        CmdText.Append(@"INSERT INTO """ + this.Tables + @""" (" + FieldList.ToString() + ") VALUES ");
                        int CmdNum = 1;
                        foreach (Insert Cmd in this.InsertCommands) {
                                System.Text.StringBuilder ParamList = new System.Text.StringBuilder();
                                foreach (Lfx.Data.Field ThisField in Cmd.Fields) {
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
                                                if (baseCommand.Connection is System.Data.Odbc.OdbcConnection)
                                                        FieldParam = "?";
                                                else
                                                        FieldParam = ParamName;
                                        }

                                        if (ParamList.Length == 0)
                                                ParamList.Append(FieldParam);
                                        else
                                                ParamList.Append(", " + FieldParam);

                                        if (FieldParam == "?" || FieldParam.Substring(0, 1) == "@") {
                                                System.Data.IDbDataParameter Param = Lfx.Data.DataBaseCache.DefaultCache.Provider.GetParameter();
                                                Param.ParameterName = ParamName;
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
                                if (CmdNum > 1)
                                        CmdText.AppendLine(",");
                                CmdText.Append(@"(" + ParamList.ToString() + ")");
                                CmdNum++;
                        }
                        
                        baseCommand.CommandText = CmdText.ToString();
                }
        }
}
