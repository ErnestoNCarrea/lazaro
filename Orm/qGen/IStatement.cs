using System;

namespace qGen
{
        public interface IStatement : IStatementOrQuery, IColumnValueCollection
        {
        }
}
