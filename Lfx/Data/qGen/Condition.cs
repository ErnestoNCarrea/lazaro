using System;
using System.Text;

namespace qGen
{
        [Serializable]
        public class Condition
        {
                protected qGen.SqlModes m_Mode = qGen.SqlModes.Ansi;

                public Condition()
                {
                }

                public qGen.SqlModes Mode
                {
                        get
                        {
                                return m_Mode;
                        }
                        set
                        {
                                m_Mode = value;
                        }
                }

                public string ToString(qGen.SqlModes mode)
                {
                        m_Mode = mode;
                        return this.ToString();
                }
        }

        public class NestedCondition : Condition
        {
                public qGen.Where Where;

                public NestedCondition(Where where)
                {
                        this.Where = where;
                }

                public override string ToString()
                {
                        this.Where.SqlMode = this.m_Mode;
                        return "(" + this.Where.ToString() + ")";
                }
        }

        internal class SqlCondition : Condition
        {
                protected string Text = "";

                public SqlCondition()
                        : base()
                {
                }

                public SqlCondition(string text)
                        : this()
                {
                        this.Text = text;
                }

                public override string ToString()
                {
                        return this.Text;
                }
        }

        public class ComparisonCondition : Condition
        {
                protected string LeftValue = "";
                protected object m_RightValue = "", m_RightValue2 = "";
                public qGen.ComparisonOperators Operator = qGen.ComparisonOperators.Equals;

                public ComparisonCondition()
                        : base()
                {
                }

                public ComparisonCondition(string LeftValue, object RightValue)
                        : this(LeftValue, qGen.ComparisonOperators.Equals, RightValue)
                {
                }

                public ComparisonCondition(string leftValue, qGen.ComparisonOperators compOperator, object rightValue)
                        : this()
                {
                        this.LeftValue = leftValue;
                        this.Operator = compOperator;
                        this.m_RightValue = rightValue;
                }

                public ComparisonCondition(string leftValue, object minValue, object maxValue)
                        : this()
                {
                        this.LeftValue = leftValue;
                        this.Operator = ComparisonOperators.Between;
                        this.m_RightValue = minValue;
                        this.m_RightValue2 = maxValue;
                }

                public ComparisonCondition(qGen.SqlModes Mode, string LeftValue, qGen.ComparisonOperators compOperator, object RightValue)
                        : this(LeftValue, compOperator, RightValue)
                {
                        m_Mode = Mode;
                }

                public object RightValue
                {
                        get
                        {
                                return m_RightValue;
                        }
                        set
                        {
                                this.m_RightValue = value;
                        }
                }

                private string FormatValue(object value)
                {
                        if (value == null || value is DBNull) {
                                return "NULL";
                        } else if (value is double || value is decimal) {
                                return Lfx.Types.Formatting.FormatNumberSql(System.Convert.ToDecimal(value), 8);
                        } else if (value is NullableDateTime && value != null) {
                                return "'" + Lfx.Types.Formatting.FormatDateTimeSql(((NullableDateTime)(value)).Value) + "'";
                        } else if (value is DateTime) {
                                return "'" + Lfx.Types.Formatting.FormatDateTimeSql((DateTime)value) + "'";
                        } else if (value is int || value is long) {
                                return value.ToString();
                        } else if (value is SqlExpression) {
                                return value.ToString();
                        } else if (value is qGen.Select) {
                                // Sub select
                                return "(" + value.ToString() + ")";
                        } else if (value is SqlFunctions) {
                                switch((SqlFunctions)value) {
                                        case SqlFunctions.Now:
                                                return "NOW()";
                                        default:
                                                return value.ToString();
                                }
                        } else if (value is int[]) {
                                string[] RightValStr = Array.ConvertAll<int, string>((int[])value, new Converter<int, string>(Convert.ToString));
                                return string.Join(",", RightValStr);
                        } else if (value is string[]) {
                                string[] EscapedStrings = ((string[])(value));
                                for (int i = 0; i < EscapedStrings.Length; i++) {
                                        EscapedStrings[i] = Lfx.Data.Connection.EscapeString(EscapedStrings[i], m_Mode);
                                }
                                return "'" + string.Join("','", EscapedStrings) + "'";
                        } else if (value is System.Collections.IList) {
                                // Si es una lista, formateo cada uno de los elementos
                                StringBuilder Res = new StringBuilder();
                                System.Collections.IList Lista = (System.Collections.IList)value;
                                foreach (object a in Lista) {
                                        if(Res.Length == 0)
                                                Res.Append(FormatValue(a));
                                        else
                                                Res.Append("," + FormatValue(a));
                                }
                                return Res.ToString();
                        } else {
                                return "'" + Lfx.Data.Connection.EscapeString(value.ToString(), m_Mode) + "'";
                        }
                }

                public object RightValue2
                {
                        get
                        {
                                return m_RightValue2;
                        }
                        set
                        {
                                this.m_RightValue2 = value;
                        }
                }

                public override string ToString()
                {
                        string Result = null;

                        switch (Operator) {
                                case qGen.ComparisonOperators.NullSafeEquals:
                                        Result = LeftValue + "<=>" + FormatValue(RightValue);
                                        break;

                                case qGen.ComparisonOperators.Equals:
                                        if (m_RightValue == null)
                                                Result = LeftValue + " IS " + FormatValue(RightValue);
                                        else
                                                Result = LeftValue + "=" + FormatValue(RightValue);
                                        break;

                                case qGen.ComparisonOperators.GreaterOrEqual:
                                        Result = LeftValue + ">=" + FormatValue(RightValue);
                                        break;

                                case qGen.ComparisonOperators.GreaterThan:
                                        Result = LeftValue + ">" + FormatValue(RightValue);
                                        break;

                                case qGen.ComparisonOperators.InsensitiveLike:
                                        switch (m_Mode) {
                                                case qGen.SqlModes.PostgreSql:
                                                        Result = LeftValue + " ILIKE " + FormatValue(RightValue);
                                                        break;
                                                default:
                                                        Result = LeftValue + " LIKE " + FormatValue(RightValue);
                                                        break;
                                        }
                                        break;

                                case qGen.ComparisonOperators.InsensitiveNotLike:
                                        switch (m_Mode) {
                                                case qGen.SqlModes.PostgreSql:
                                                        Result = LeftValue + " NOT ILIKE " + FormatValue(RightValue);
                                                        break;
                                                default:
                                                        Result = LeftValue + " NOT LIKE " + FormatValue(RightValue);
                                                        break;
                                        }
                                        break;

                                case qGen.ComparisonOperators.LessOrEqual:
                                        Result = LeftValue + "<=" + FormatValue(RightValue);
                                        break;

                                case qGen.ComparisonOperators.LessThan:
                                        Result = LeftValue + "<" + FormatValue(RightValue);
                                        break;

                                case qGen.ComparisonOperators.NotEqual:
                                        if (m_RightValue == null)
                                                Result = LeftValue + " IS NOT " + FormatValue(RightValue);
                                        else
                                                Result = LeftValue + "<>" + FormatValue(RightValue);
                                        break;

                                case qGen.ComparisonOperators.SensitiveLike:
                                        switch (m_Mode) {
                                                case qGen.SqlModes.MySql:
                                                        Result = "BINARY " + LeftValue + " LIKE BINARY " + FormatValue(RightValue);
                                                        break;
                                                default:
                                                        Result = LeftValue + " LIKE " + FormatValue(RightValue);
                                                        break;
                                        }
                                        break;

                                case qGen.ComparisonOperators.SensitiveNotLike:
                                        switch (m_Mode) {
                                                case qGen.SqlModes.MySql:
                                                        Result = "BINARY " + LeftValue + " NOT LIKE BINARY " + FormatValue(RightValue);
                                                        break;
                                                default:
                                                        Result = LeftValue + " NOT LIKE " + FormatValue(RightValue);
                                                        break;
                                        }
                                        break;

                                case qGen.ComparisonOperators.SoundsLike:
                                        switch (m_Mode) {
                                                case qGen.SqlModes.MySql:
                                                        // FIXME: Parece que el SOUNDS LIKE no funciona bien en MySql
                                                        // Result = LeftValue.Replace("%", "") & " SOUNDS LIKE " & RightValue.Replace("%", "")
                                                        Result = LeftValue + " LIKE " + FormatValue(RightValue);
                                                        break;
                                                case qGen.SqlModes.PostgreSql:
                                                        Result = LeftValue + " ILIKE " + FormatValue(RightValue);
                                                        break;
                                                default:
                                                        Result = LeftValue + " LIKE " + FormatValue(RightValue);
                                                        break;
                                        }
                                        break;

                                case qGen.ComparisonOperators.In:
                                        Result = LeftValue + " IN (" + FormatValue(RightValue) + ")";
                                        break;

                                case qGen.ComparisonOperators.NotIn:
                                        Result = LeftValue + " NOT IN (" + FormatValue(RightValue) + ")";
                                        break;

                                case ComparisonOperators.Between:
                                        Result = LeftValue + " BETWEEN " + FormatValue(RightValue) + " AND " + FormatValue(RightValue2);
                                        break;
                        }

                        return Result;
                }
        }
}
