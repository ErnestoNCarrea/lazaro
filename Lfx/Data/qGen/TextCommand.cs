using System;

namespace qGen
{
        [Serializable]
        public class TextCommand : Command
        {
                public string Commandtext;

                public TextCommand()
                        : base() { }

                public TextCommand(SqlModes sqlMode)
                        : base(sqlMode) { }

                public TextCommand(Lfx.Data.Connection dataBase, string commandtext)
                        : base(dataBase)
                {
                        this.Commandtext = commandtext;
                }

                public TextCommand(string commandtext)
                        : this()
                {
                        this.Commandtext = commandtext;
                }

                public override string ToString()
                {
                        return this.Commandtext;
                }
        }
}
