using Lazaro.Orm.Data;
using System;

namespace qGen
{
        [Serializable]
        public class Join
        {
                public SqlIdentifier Table {get;set;}
                public string On { get; set; }
                public JoinTypes JoinType = JoinTypes.LeftJoin;

                public Join(string table, string on)
                {
                        if (table.IndexOf(" AS ") >= 0) {
                                this.Table = new SqlIdentifier(table);
                        } else if (table.IndexOf(' ') >= 0) {
                                // FIXME: should we assume that an space means an alias? Only if unquoted...
                                string[] Partes = table.Split(new char[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                                this.Table = new SqlIdentifier(Partes[0], Partes[1]);
                        } else {
                                this.Table = new SqlIdentifier(table);
                        }
                        this.On = on;

                }
                public Join(SqlIdentifier table, string on)
                {
                        this.Table = table;
                        this.On = on;
                }


                public Join(string table, string on, JoinTypes joinType)
                        : this(table, on)
                {
                        this.JoinType = joinType;
                }


                public Join(Relation relation)
                        : this(relation.ReferenceTable, relation.Column + "=" + relation.ReferenceTable + "." + relation.ReferenceColumn)
                {
                }


                public override string ToString()
                {
                        return SqlFormatter.DefaultFormatter.SqlText(this);
                }
        }
}