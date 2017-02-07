using System;
using System.Collections.Generic;

namespace qGen
{
        [Serializable]
        public class Where : List<ICondition>
        {
                public SqlModes SqlMode = SqlModes.Ansi;
                public AndOr Operator = AndOr.And;

                public Where()
                        : base()
                {
                }

                public Where(AndOr operand)
                        : this()
                {
                        this.Operator = operand;
                }


                public Where(ICondition Condition)
                        : this()
                {
                        this.Add(Condition);
                }

                public Where(string sqlWhere)
                        : this()
                {
                        this.Add(new SqlCondition(sqlWhere));
                }

                public Where(string columnName, object equalsValue)
                        : this(new ComparisonCondition(columnName, equalsValue))
                {
                }

                public Where(string columnName, ComparisonOperators compOperator, object equalsValue)
                        : this(new ComparisonCondition(columnName, compOperator, equalsValue))
                {
                }

                public void AddWithValue(string text)
                {
                        this.Add(new SqlCondition(text));
                }

                public void AddWithValue(Where where)
                {
                        this.Add(new NestedCondition(where));
                }

                public void AddWithValue(string leftValue, object rightValue)
                {
                        this.Add(new ComparisonCondition(leftValue, rightValue));
                }

                public void AddWithValue(string leftValue, qGen.ComparisonOperators compOperator, object rightValue)
                {
                        this.Add(new ComparisonCondition(leftValue, compOperator, rightValue));
                }

                public void AddWithValue(string leftValue, object minValue, object maxValue)
                {
                        this.Add(new ComparisonCondition(leftValue, minValue, maxValue));
                }


                public Where Clone()
                {
                        Where Res = new Where(this.Operator);
                        Res.SqlMode = this.SqlMode;
                        if (this.Count > 0)
                                Res.AddRange(this);
                        return Res;
                }

                public override string ToString()
                {
                        throw new InvalidOperationException("Not allowed");
                }
        }
}
