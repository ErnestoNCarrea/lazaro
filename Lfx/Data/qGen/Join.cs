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


                public Join(Lfx.Data.Relation relation)
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
                        System.Text.StringBuilder Res = new System.Text.StringBuilder();
                        switch (this.JoinType) {
                                case JoinTypes.ImplicitJoin:
                                        Res.Append("," + this.TableAndAlias);
                                        break;
                                case JoinTypes.LeftJoin:
                                        Res.Append(" LEFT JOIN " + this.TableAndAlias);
                                        break;
                                case JoinTypes.CrossJoin:
                                        Res.Append(" CROSS JOIN " + this.TableAndAlias);
                                        break;
                                case JoinTypes.FullOuterJoin:
                                        Res.Append(" FULL OUTER JOIN " + this.TableAndAlias);
                                        break;
                                case JoinTypes.InnerJoin:
                                        Res.Append(" INNER JOIN " + this.TableAndAlias);
                                        break;
                                case JoinTypes.LeftOuterJoin:
                                        Res.Append(" LEFT OUTER JOIN " + this.TableAndAlias);
                                        break;
                                case JoinTypes.NaturalJoin:
                                        Res.Append(" NATURAL JOIN " + this.TableAndAlias);
                                        break;
                                case JoinTypes.RightOuterJoin:
                                        Res.Append(" RIGHT OUTER JOIN " + this.TableAndAlias);
                                        break;
                        }

                        if (On != null && On.Length > 0)
                                Res.Append(" ON " + On);

                        return Res.ToString();
                }
        }
}