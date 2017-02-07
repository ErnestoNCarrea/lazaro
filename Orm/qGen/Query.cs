using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace qGen
{
        public abstract class Query : IQuery
        {
                public IList<string> Tables { get; set; }
                public IList<string> Columns { get; set; } = new List<string> { "*" };
                public Where WhereClause { get; set; }

                public Query()
                {
                }

                public Query(string singleTable)
                        : this(new List<string> { singleTable })
                {
                }

                public Query(IList<string> tables)
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
