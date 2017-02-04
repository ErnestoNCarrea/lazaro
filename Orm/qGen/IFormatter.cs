using System;
using System.Collections.Generic;
using Lazaro.Orm.Data;

namespace qGen
{
        public interface IFormatter
        {
                string FormatDecimal(decimal numero, int decimales);
                string EscapeString(string stringValue);

                string SqlText(ICommand command);
                System.Data.IDbCommand SetupDbCommand(IConvertibleToDbCommand command, ref System.Data.IDbCommand dbCommand, IConnection connection);

                System.Data.IDbCommand SetupDbCommand(Insert insertCommand, ref System.Data.IDbCommand dbCommand, IConnection connection);
                string SqlText(Insert insertCommand);
                string SqlText(Insert insertCommand, bool valuesOnly);

                System.Data.IDbCommand SetupDbCommand(Update updateCommand, ref System.Data.IDbCommand dbCommand, IConnection connection);
                string SqlText(Update updateCommand);

                string SqlText(Select selectCommand);

                System.Data.IDbCommand SetupDbCommand(Delete deleteCommand, ref System.Data.IDbCommand dbCommand, IConnection connection);
                string SqlText(Delete deleteCommand);

                string SqlText(Join join);
                string SqlText(Where where);
        }
}
