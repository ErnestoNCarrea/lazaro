using System;
using Lazaro.Orm.Data;

namespace qGen
{
        [Serializable]
        public class Update : TableCommand, IConvertibleToDbCommand
        {
                public Update()
                        : base() { }

                public Update(string tables)
                        : base(tables) { }

                public Update(IConnection dataBase, string tables)
                        : base(dataBase, tables) { }

                public Update(string tables, Where whereClause)
                        : base(tables, whereClause) { }
        }
}
