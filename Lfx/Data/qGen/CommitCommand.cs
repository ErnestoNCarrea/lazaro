using System;

namespace qGen
{
        [Serializable]
        public class CommitCommand : Command
        {
                public CommitCommand()
                        : base() { }

                public CommitCommand(SqlModes sqlMode)
                        : base(sqlMode) { }

                public CommitCommand(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

                public override string ToString()
                {
                        return "COMMIT";
                }
        }
}
