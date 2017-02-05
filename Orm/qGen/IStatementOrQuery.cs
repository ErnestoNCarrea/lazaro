using System;
using System.Collections.Generic;

namespace qGen
{
        public interface IStatementOrQuery
        {
                IList<string> Tables { get; set; }
                Where WhereClause { get; set; }
        }
}
