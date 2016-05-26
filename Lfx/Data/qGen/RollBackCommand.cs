using System;

namespace qGen
{
        [Serializable]
        public class RollBackCommand : Command
        {
                public RollBackCommand()
                        : base() { }

                public RollBackCommand(SqlModes sqlMode)
                        : base(sqlMode) { }

                public RollBackCommand(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

                public override string ToString()
                {
                        return "ROLLBACK";
                }
        }
}
