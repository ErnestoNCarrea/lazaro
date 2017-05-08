using System;
using System.Collections.Generic;

namespace qGen
{
        /// <summary>
        /// Comando SELECT
        /// </summary>
        [Serializable]
        public class Select : Query, IWithColumnList
        {
                public Window Window = null;
                public string Order = null;
                public string Group = "";
                public bool ForUpdate = false;
                public JoinCollection Joins = new JoinCollection();

                public Where HavingClause = null;

                public Select()
                        : base()
                {
                }

                public Select(string singleTable)
                        : this(new SqlIdentifierCollection() { singleTable })
                {
                }

                public Select(SqlIdentifier singleTable)
                        : this(new SqlIdentifierCollection() { singleTable })
                {
                }

                public Select(SqlIdentifierCollection tables)
                       : base(tables)
                {
                }

                public Select(SqlIdentifierCollection tables, bool forUpdate)
                        : base(tables)
                {
                        this.ForUpdate = forUpdate;
                }

                public Select(string singleTable, bool forUpdate)
                        : this(new SqlIdentifierCollection() { singleTable }, forUpdate)
                {
                }

                public Select(SqlIdentifier singleTable, bool forUpdate)
                        : this(new SqlIdentifierCollection() { singleTable })
                {
                        this.ForUpdate = forUpdate;
                }


                public Select Clone()
                {
                        var Res = ((Select)(this.MemberwiseClone()));
                        if (this.WhereClause != null)
                                Res.WhereClause = this.WhereClause.Clone();
                        if (this.HavingClause != null)
                                Res.HavingClause = this.HavingClause.Clone();
                        if (this.Joins != null) {
                                Res.Joins = new JoinCollection();
                                Res.Joins.AddRange(this.Joins);
                        }
                        return Res;
                }
        }
}
