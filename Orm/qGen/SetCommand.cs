using System;
using Lazaro.Orm.Data;

namespace qGen
{
        [Serializable]
        public class SetCommand : Command
        {
                public string SetParameters;

                public SetCommand()
                        : base() { }

                public SetCommand(IConnection dataBase, string setParameters)
                        : base(dataBase)
                {
                        this.SetParameters = setParameters;
                }

                public SetCommand(string setParameters)
                        : this()
                {
                        this.SetParameters = setParameters;
                }
        }
}
