using System;
using Lazaro.Orm.Data;
using System.Collections.Generic;

namespace qGen
{
        [Serializable]
        public class Update : Statement, IColumnValueCollection, IConvertibleToDbCommand
        {
                public Update()
                        : base()
                {
                }

                public Update(string singleTable)
                        : this(new List<string> { singleTable })
                {
                }

                public Update(IList<string> tables)
                        : this()
                {
                        this.Tables = tables;
                }

                public Update(string singleTable, Where whereClause)
                        : this(new List<string> { singleTable }, whereClause)
                {
                }

                public Update(IList<string> tables, Where whereClause)
                        : this(tables)
                {
                        this.WhereClause = whereClause;
                }
        }
}
