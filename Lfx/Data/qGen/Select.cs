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

                public Select(SqlModes SqlMode)
                        : base(SqlMode) { }

                public Select(string Tables)
                        : base(Tables) { }

                public Select(string Tables, bool forUpdate)
                        : this(Tables)
                {
                        this.ForUpdate = forUpdate;
                }

                public override string ToString()
                {
                        System.Text.StringBuilder Command = new System.Text.StringBuilder();

                        Command.Append("SELECT ");
                        if (this.Window != null && this.Window.Limit > 0)
                                switch (this.SqlMode) {
                                        case SqlModes.MySql:
                                        case SqlModes.PostgreSql:
                                                // Nada. Se hace con LIMIT x OFFSET y
                                                break;
                                        case SqlModes.Ansi:
                                                // Nada. Se hace con OFFSET x FETCH y
                                                break;
                                        default:
                                                Command.Append("ROW_NUMBER() OVER (ORDER BY key ASC) AS window_function_rownum, ");
                                                break;
                                }
                        Command.Append(Fields);

                        if (Tables != null && Tables.Length > 0) {
                                string[] TableList = Tables.Split(',');

                                if (TableList.Length == 1) {
                                        //Single table
                                        Command.Append(" FROM " + Tables);
                                } else {
                                        Command.Append(" FROM " + TableList[0]);
                                }
                                foreach (Join Jo in Joins) {
                                        Command.Append(Jo.ToString());
                                }
                        }

                        if (WhereClause != null) {
                                string WhereString = WhereClause.ToString(m_Mode);

                                if (WhereString.Length > 0)
                                        Command.Append(" WHERE " + WhereString);
                        }

                        if (Group != null && Group.Length > 0)
                                Command.Append(" GROUP BY " + Group);

                        if (HavingClause != null) {
                                string HavingString = HavingClause.ToString(m_Mode);

                                if (HavingString.Length > 0)
                                        Command.Append(" HAVING " + HavingString);
                        }

                        if (Order != null && Order.Length > 0)
                                Command.Append(" ORDER BY " + Order);

                        if (this.Window != null && this.Window.Limit > 0) {
                                switch (this.SqlMode) {
                                        case SqlModes.MySql:
                                        case SqlModes.PostgreSql:
                                        case SqlModes.SQLite:
                                                // TODO: Postgre desde la versión 9 permite el estándar ANSI SQL:2008 (OFFSET x FETCH y ONLY)
                                                Command.Append(" LIMIT " + this.Window.Limit.ToString());
                                                if (this.Window.Offset > 0)
                                                        Command.Append(" OFFSET " + this.Window.Offset.ToString());
                                                break;
                                        case SqlModes.Ansi:
                                                // Estándar ANSI SQL:2008
                                                if (this.Window.Offset > 0)
                                                        Command.Append(" OFFSET " + this.Window.Offset.ToString());
                                                Command.Append(" FETCH " + this.Window.Limit.ToString() + " ONLY");
                                                break;
                                        case SqlModes.Oracle:
                                                // Casi lo mismo que el estándar, pero sin AS ... ya que Oracle no soporta ni requiere etiquetar las subconsultas
                                                Command.Insert(0, "SELECT * FROM (");
                                                Command.Append(") WHERE window_function_rownum>" + this.Window.Limit.ToString());
                                                if (this.Window.Offset > 0)
                                                        Command.Append(" AND window_function_rownum <=(" + this.Window.Offset.ToString() + "+" + this.Window.Limit.ToString() + ")");
                                                break;
                                        default:
                                                Command.Insert(0, "SELECT * FROM (");
                                                Command.Append(") AS window_function WHERE window_function_rownum>" + this.Window.Limit.ToString());
                                                if (this.Window.Offset > 0)
                                                        Command.Append(" AND window_function_rownum <=(" + this.Window.Offset.ToString() + "+" + this.Window.Limit.ToString() + ")");
                                                break;
                                }
                        }

                        if (this.ForUpdate)
                                Command.Append(" FOR UPDATE");

                        return Command.ToString();
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
