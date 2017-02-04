using Lazaro.Orm.Data;
using System;

namespace qGen
{
        [Serializable]
        public class Join
        {
                public string Table {get;set;}
                public string Alias { get; set; }
                public string On { get; set; }
                public JoinTypes JoinType = JoinTypes.LeftJoin;

                public Join(string table, string on)
                {
                        if (table.IndexOf(' ') >= 0) {
                                string[] Partes = table.Split(new char[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                                this.Table = Partes[0];
                                this.Alias = Partes[1];
                        } else {
                                this.Table = table;
                        }
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


                public string TableAndAlias
                {
                        get
                        {
                                if(this.Alias != null && this.Alias.Length > 0) {
                                        return this.Table + " " + this.Alias;
                                } else {
                                        return this.Table;
                                }
                        }
                }

                public override string ToString()
                {
                        throw new Exception("Not allowed");
                }
        }
}