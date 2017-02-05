using System;
using Lazaro.Orm.Data;
using Lazaro.Orm.Data.Drivers;
using System.Collections.Generic;

namespace qGen
{
        [Serializable]
        public class Insert : Statement, IConvertibleToDbCommand
        {
                public bool OnDuplicateKeyUpdate { get; set; }

                public Insert()
                        : base()
                { }

                public Insert(string singleTable)
                        : this(new List<string> { singleTable })
                {
                }

                public Insert(IList<string> tables)
                        : this()
                {
                        this.Tables = tables;
                }
        }
}
