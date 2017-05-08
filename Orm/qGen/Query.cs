using System;
using System.Collections.Generic;

namespace qGen
{
        public abstract class Query : IQuery
        {
                public SqlIdentifierCollection Tables { get; set; }
                public SqlIdentifierCollection Columns { get; set; } = SqlIdentifierCollection.Asterisk;
                public Where WhereClause { get; set; }

                public Query()
                {
                }

                public Query(SqlIdentifier singleTable)
                        : this(new SqlIdentifierCollection() { singleTable })
                {
                }

                public Query(SqlIdentifierCollection tables)
                        : this()
                {
                        this.Tables = tables;
                }

                public override string ToString()
                {
                        throw new InvalidOperationException("Not allowed");
                }
        }
}
