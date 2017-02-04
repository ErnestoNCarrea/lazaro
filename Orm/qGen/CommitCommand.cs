using System;
using Lazaro.Orm.Data;

namespace qGen
{
        [Serializable]
        public class CommitCommand : Command
        {
                public CommitCommand()
                        : base() { }

                public CommitCommand(IConnection dataBase)
                        : base(dataBase) { }
        }
}
