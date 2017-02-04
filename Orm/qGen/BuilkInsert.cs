using System;
using System.Collections.Generic;
using Lazaro.Orm.Data.Drivers;

namespace qGen
{
        [Serializable]
        public class BuilkInsert : TableCommand, IConvertibleToDbCommand
        {
                public System.Collections.Generic.List<Insert> InsertCommands { get; set; } = new List<Insert>();

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
