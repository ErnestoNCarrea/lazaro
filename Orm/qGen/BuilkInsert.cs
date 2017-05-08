using System;
using System.Collections.Generic;
using Lazaro.Orm.Data.Drivers;
using Lazaro.Orm.Data;

namespace qGen
{
        [Serializable]
        public class BuilkInsert : IStatement, IConvertibleToDbCommand
        {
                public SqlIdentifierCollection Tables { get; set; }
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
                                        throw new ArgumentException("qGen: BulkInsert requires all Insert to be on the same tables");
                                }
                                if (this.Tables[0].PrefixAndName != insertCommand.Tables[0].PrefixAndName) {
                                        // TODO: check all tables
                                        throw new ArgumentException("qGen: BulkInsert requires all Insert to be on the same table");
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
                                throw new InvalidOperationException("Can not get ColumnValues for BulkInsert; use Bulkinsert.InsertCommands[n].ColumnValues");
                        }
                        set
                        {
                                throw new InvalidOperationException("Can not set ColumnValues for BulkInsert; use Bulkinsert.InsertCommands[n].ColumnValues");
                        }
                }

                public SqlIdentifierCollection ColumnNames
                {
                        get
                        {
                                if(this.InsertCommands == null || this.InsertCommands.Count == 0) {
                                        return null;
                                } else {
                                        return this.InsertCommands[0].ColumnValues.ColumnNames;
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
