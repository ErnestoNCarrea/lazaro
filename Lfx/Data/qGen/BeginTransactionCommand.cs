using System;

namespace qGen
{
        [Serializable]
        public class BeginTransactionCommand : Command
        {
                public BeginTransactionCommand()
                        : base() { }

                public BeginTransactionCommand(SqlModes sqlMode)
                        : base(sqlMode) { }

                public BeginTransactionCommand(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

                public override string ToString()
                {
                        switch (this.SqlMode) {
                                case SqlModes.TransactSql:
                                        return "BEGIN TRANSACTION";
                                case SqlModes.MySql:
                                        return "START TRANSACTION WITH CONSISTENT SNAPSHOT";
                                default:
                                        return "BEGIN";
                        }
                }
        }
}
