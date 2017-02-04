using System;
using Lazaro.Orm.Data;

namespace qGen
{
        [Serializable]
        public class RollBackCommand : Command
        {
                public RollBackCommand()
                        : base() { }

                public RollBackCommand(IConnection dataBase)
                        : base(dataBase) { }
        }
}
