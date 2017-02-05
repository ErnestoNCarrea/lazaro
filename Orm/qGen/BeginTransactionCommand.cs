using System;
using Lazaro.Orm.Data;

namespace qGen
{
        [Serializable]
        public class BeginTransactionCommand : Statement
        {
                public BeginTransactionCommand()
                        : base() { }
        }
}
