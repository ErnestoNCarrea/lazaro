using System;
using System.Collections.Generic;
using Lazaro.Orm.Data.Drivers;
using Lazaro.Orm.Data;

namespace qGen
{
        [Serializable]
        public class BuilkInsert : IStatement, IConvertibleToDbCommand
        {
                public ColumnValueCollection ColumnValues { get; set; }
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
                                if (this.Tables != insertCommand.Tables)
                                        throw new ArgumentException("qGen: BulkInsert requiere que todas las inserciones sean en la misma tabla y con los mismos campos");
                        } else {
                                this.Tables = insertCommand.Tables;
                                //this.Fields = insertCommand.Fields.GetFieldNames();
                                //this.WhereClause = insertCommand.WhereClause;
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
        }
}
