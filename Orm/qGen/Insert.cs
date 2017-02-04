using System;
using Lazaro.Orm.Data;
using Lazaro.Orm.Data.Drivers;

namespace qGen
{
        [Serializable]
        public class Insert : TableCommand, IConvertibleToDbCommand
        {
                public bool OnDuplicateKeyUpdate { get; set; }

                public Insert()
                        : base() { }

                public Insert(string Tables)
                        : base(Tables) { }

                public Insert(IConnection dataBase, string tables)
                        : base(dataBase, tables) { }
        }
}
