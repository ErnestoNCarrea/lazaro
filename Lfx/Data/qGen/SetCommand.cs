using System;

namespace qGen
{
        [Serializable]
        public class SetCommand : Command
        {
                public string SetParameters;

                public SetCommand()
                        : base() { }

                public SetCommand(SqlModes sqlMode)
                        : base(sqlMode) { }

                public SetCommand(Lfx.Data.Connection dataBase, string setParameters)
                        : base(dataBase)
                {
                        this.SetParameters = setParameters;
                }

                public SetCommand(string setParameters)
                        : this()
                {
                        this.SetParameters = setParameters;
                }

                public override string ToString()
                {
                        return "SET " + this.SetParameters;
                }
        }
}
