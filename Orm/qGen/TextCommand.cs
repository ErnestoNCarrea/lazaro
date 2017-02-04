using Lazaro.Orm.Data;
using System;

namespace qGen
{
        [Serializable]
        public class TextCommand : Command
        {
                public string Commandtext;

                public TextCommand()
                        : base() { }

                public TextCommand(IConnection dataBase, string commandtext)
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
