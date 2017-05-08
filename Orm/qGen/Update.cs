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
                        : this(new SqlIdentifierCollection() { singleTable })
                {
                }

                public Update(SqlIdentifier singleTable)
                        : this(new SqlIdentifierCollection() { singleTable })
                {
                }

                public Update(SqlIdentifierCollection tables)
                        : this()
                {
                        this.Tables = tables;
                }

                public Update(string singleTable, Where whereClause)
                        : this(new SqlIdentifierCollection() { singleTable }, whereClause)
                {
                }

                public Update(SqlIdentifier singleTable, Where whereClause)
                        : this(new SqlIdentifierCollection() { singleTable }, whereClause)
                {
                }

                public Update(SqlIdentifierCollection tables, Where whereClause)
                        : this(tables)
                {
                        this.WhereClause = whereClause;
                }
        }
}
