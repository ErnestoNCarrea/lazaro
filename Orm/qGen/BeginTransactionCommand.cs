using System;
using Lazaro.Orm.Data;

namespace qGen
{
        [Serializable]
        public class BeginTransactionCommand : Command
        {
                public BeginTransactionCommand()
                        : base() { }

                public BeginTransactionCommand(IConnection dataBase)
                        : base(dataBase) { }
        }
}
