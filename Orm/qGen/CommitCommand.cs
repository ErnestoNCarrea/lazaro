using System;
using Lazaro.Orm.Data;

namespace qGen
{
        [Serializable]
        public class CommitCommand : Statement
        {
                public CommitCommand()
                        : base() { }
        }
}
