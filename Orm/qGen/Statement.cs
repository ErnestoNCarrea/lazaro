using Lazaro.Orm.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace qGen
{
        public abstract class Statement : IStatement
        {
                public ColumnValueCollection ColumnValues { get; set; } = new ColumnValueCollection();
                public SqlIdentifierCollection Tables { get; set; }
                public Where WhereClause { get; set; }

                public Statement()
                {
                }

                public Statement(SqlIdentifier singleTable)
                        : this(new SqlIdentifierCollection() { singleTable })
                {
                }

                public Statement(SqlIdentifierCollection tables)
                        : this()
                {
                        this.Tables = tables;
                }

                public override string ToString()
                {
                        return SqlFormatter.DefaultFormatter.SqlText(this);
                }
        }
}
