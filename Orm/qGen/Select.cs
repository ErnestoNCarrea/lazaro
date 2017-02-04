using System;
using System.Collections.Generic;

namespace qGen
{
        /// <summary>
        /// Comando SELECT
        /// </summary>
        [Serializable]
        public class Select : TableCommand
        {
                new public string Fields = "*";
                public Window Window = null;
                public string Order = null;
                public string Group = "";
                public bool ForUpdate = false;
                public JoinCollection Joins = new JoinCollection();

                public Where HavingClause = null;

                public Select()
                        : base() { }

                public Select(string Tables)
                        : base(Tables) { }

                public Select(string Tables, bool forUpdate)
                        : this(Tables)
                {
                        this.ForUpdate = forUpdate;
                }


                public Select Clone()
                {
                        Select Res = ((Select)(this.MemberwiseClone()));
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
