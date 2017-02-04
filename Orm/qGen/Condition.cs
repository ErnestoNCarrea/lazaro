using System;
using System.Text;

namespace qGen
{
        public interface ICondition
        {

        }


        public class NestedCondition : ICondition
        {
                public qGen.Where Where { get; set; }

                public NestedCondition()
                        : base()
                {
                }

                public NestedCondition(Where where)
                        : this()
                {
                        this.Where = where;
                }
        }


        public class SqlCondition : ICondition
        {
                public string Text { get; set; } = "";

                public SqlCondition()
                        : base()
                {
                }

                public SqlCondition(string text)
                        : this()
                {
                        this.Text = text;
                }
        }


        public class ComparisonCondition : ICondition
        {
                public string LeftValue { get; set; } = "";
                public object RightValue { get; set; } = "";
                public object RightValue2 { get; set; } = "";
                public qGen.ComparisonOperators Operator { get; set; } = qGen.ComparisonOperators.Equals;

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
                        this.RightValue = rightValue;
                }

                public ComparisonCondition(string leftValue, object minValue, object maxValue)
                        : this()
                {
                        this.LeftValue = leftValue;
                        this.Operator = ComparisonOperators.Between;
                        this.RightValue = minValue;
                        this.RightValue2 = maxValue;
                }
        }
}
