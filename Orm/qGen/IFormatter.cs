using System;
using System.Collections.Generic;
using Lazaro.Orm.Data;

namespace qGen
{
        public interface IFormatter
        {
                string FormatDecimal(decimal numero, int decimales);
                string EscapeString(string stringValue);

                string SqlText(IStatementOrQuery command);
                System.Data.IDbCommand SetupDbCommand(IStatementOrQuery command, IConnection connection);

                string SqlText(Insert insertCommand);
                string SqlText(Insert insertCommand, bool valuesOnly);

                string SqlText(Update updateCommand);

                string SqlText(Select selectCommand);

                string SqlText(Delete deleteCommand);

                string SqlText(Join join);
                string SqlText(Where where);
        }
}
