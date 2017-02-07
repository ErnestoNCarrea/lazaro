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
                public IList<string> Tables { get; set; }
                public Where WhereClause { get; set; }

                public Statement()
                {
                }

                public Statement(string singleTable)
                        : this(new List<string> { singleTable })
                {
                }

                public Statement(IList<string> tables)
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
