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
                        : this(new SqlIdentifierCollection() { singleTable })
                {
                }

                public Delete(SqlIdentifier singleTable)
                        : this(new SqlIdentifierCollection() { singleTable })
                {
                }

                public Delete(SqlIdentifierCollection tables)
                        : this()
                {
                        this.Tables = tables;
                }

                public Delete(string singleTable, Where whereClause)
                        : this(new SqlIdentifierCollection() { singleTable }, whereClause)
                {
                }

                public Delete(SqlIdentifier singleTable, Where whereClause)
                        : this(new SqlIdentifierCollection() { singleTable }, whereClause)
                {
                }

                public Delete(SqlIdentifierCollection tables, Where whereClause)
                        : this(tables)
                {
                        this.WhereClause = whereClause;
                }

        }
}
