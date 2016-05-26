using System;

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

                public Delete(Lfx.Data.Connection dataBase, string tables)
                        : base(dataBase, tables) { }

                public Delete(string tables, Where whereClause)
                        : base(tables, whereClause) { }

                public override string ToString()
                {
                        string Command = null;

                        Command = "DELETE FROM " + Tables;

                        if (WhereClause != null) {
                                Command += " WHERE " + WhereClause.ToString();
                        } else if (EnableDeleleteWithoutWhere == false) {
                                System.Console.WriteLine("SqlDeleteBuilder necesita una cláusula Where o Truncate = true.");
                                return "";
                        }

                        return Command;
                }

                public override void SetupDbCommand(ref System.Data.IDbCommand baseCommand)
                {
                        baseCommand.CommandText = this.ToString();
                }
        }
}
