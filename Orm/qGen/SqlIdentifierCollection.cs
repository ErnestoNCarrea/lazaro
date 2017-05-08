using System;
using System.Collections.Generic;

namespace qGen
{
        /// <summary>
        /// Represents a collection of SQL indentifiers.
        /// </summary>
        public class SqlIdentifierCollection : List<SqlIdentifier>
        {
                public static SqlIdentifierCollection Asterisk = new SqlIdentifierCollection() { "*" };

                public SqlIdentifierCollection()
                {

                }

                public SqlIdentifierCollection(string singleIdentifier)
                {
                        this.Add(new SqlIdentifier(singleIdentifier));
                }

                public SqlIdentifierCollection(IList<string> fromStrings)
                {
                        foreach(string identifier in fromStrings) {
                                this.Add(new SqlIdentifier(identifier));
                        }
                }

                public void Add(string fromString)
                {
                        this.Add(new SqlIdentifier(fromString));
                }

                public override string ToString()
                {
                        return SqlFormatter.DefaultFormatter.SqlText(this);
                }
        }
}
