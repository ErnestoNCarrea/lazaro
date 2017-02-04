using System;
using Lazaro.Orm.Data;

namespace qGen
{
        [Serializable]
        public class Delete : TableCommand
        {
                public bool EnableDeleleteWithoutWhere = false;

                public Delete()
                        : base() { }

                public Delete(string Tables)
                        : base(Tables) { }

                public Delete(IConnection dataBase, string tables)
                        : base(dataBase, tables) { }

                public Delete(string tables, Where whereClause)
                        : base(tables, whereClause) { }
        }
}
