using System;
using Lazaro.Orm.Data;

namespace qGen
{
        [Serializable]
        public class RollBackCommand : Statement
        {
                public RollBackCommand()
                        : base() { }
        }
}
