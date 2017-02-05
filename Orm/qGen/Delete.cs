using System;
using System.Collections.Generic;
using Lazaro.Orm.Data;

namespace qGen
{
        [Serializable]
        public class Delete : Statement
        {
                public bool EnableDeleleteWithoutWhere { get; set; } = false;

                public Delete()
                        : base() { }

                public Delete(string singleTable)
                        : this(new List<string> { singleTable })
                {
                }

                public Delete(IList<string> tables)
                        : this()
                {
                        this.Tables = tables;
                }

                public Delete(string singleTable, Where whereClause)
                        : this(new List<string> { singleTable }, whereClause)
                {
                }

                public Delete(IList<string> tables, Where whereClause)
                        : this(tables)
                {
                        this.WhereClause = whereClause;
                }

        }
}
