using System;
using Lazaro.Orm.Data;

namespace qGen
{
        [Serializable]
        public class SetCommand : Statement
        {
                public string SetParameters { get; set; }

                public SetCommand()
                        : base() { }

                public SetCommand(string setParameters)
                        : this()
                {
                        this.SetParameters = setParameters;
                }
        }
}
