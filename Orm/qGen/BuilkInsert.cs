using System;
using System.Collections.Generic;
using Lazaro.Orm.Data.Drivers;
using Lazaro.Orm.Data;

namespace qGen
{
        [Serializable]
        public class BuilkInsert : IStatement, IConvertibleToDbCommand
        {
                public IList<string> Tables { get; set; }
                public Where WhereClause { get; set; }

                public IList<Insert> InsertCommands { get; set; } = new List<Insert>();

                public void Clear()
                {
                        this.InsertCommands.Clear();
                }

                public void Add(Insert insertCommand)
                {
                        if (this.InsertCommands.Count > 0) {
                                if (this.Tables.Count != insertCommand.Tables.Count) {
                                        throw new ArgumentException("qGen: BulkInsert requiere que todas las inserciones sean en la misma tabla y con los mismos campos");
                                }
                                if (this.Tables[0] != insertCommand.Tables[0]) {
                                        throw new ArgumentException("qGen: BulkInsert requiere que todas las inserciones sean en la misma tabla y con los mismos campos");
                                }
                        } else {
                                this.Tables = insertCommand.Tables;
                                //this.Fields = insertCommand.Fields.GetFieldNames();
                                //this.WhereClause = insertCommand.WhereClause;
                        }
                        this.InsertCommands.Add(insertCommand);
                }

                public ColumnValueCollection ColumnValues
                {
                        get
                        {
                                throw new InvalidOperationException("No se puede establecer ColumnValues en BulkInsert");
                        }
                        set
                        {
                                throw new InvalidOperationException("No se puede establecer ColumnValues en BulkInsert");
                        }
                }

                public List<string> ColumnNames
                {
                        get
                        {
                                if(this.InsertCommands == null || this.InsertCommands.Count == 0) {
                                        return null;
                                } else {
                                        var Res = new List<string>();
                                        foreach(var Col in this.InsertCommands[0].ColumnValues) {
                                                Res.Add(Col.ColumnName);
                                        }
                                        return Res;
                                }
                        }
                }

                public int Count
                {
                        get
                        {
                                return this.InsertCommands.Count;
                        }
                }
        }
}
