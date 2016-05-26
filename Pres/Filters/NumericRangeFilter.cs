using System;

namespace Lazaro.Pres.Filters
{
        [Serializable]
        public class NumericRangeFilter : Filter
        {
                public decimal Min { get; set; }
                public decimal Max { get; set; }

                public int DecimalPlaces = 2;

                public NumericRangeFilter(string label, string columnName)
                        : base(label, columnName)
                {
                }


                public NumericRangeFilter(string label, string columnName, int decimalPlaces)
                        : this(label, columnName)
                {
                        this.DecimalPlaces = decimalPlaces;
                        this.Value = 0m;
                        this.Value2 = 0m;
                }


                public decimal From
                {
                        get
                        {
                                return System.Convert.ToDecimal(this.Value);
                        }
                        set
                        {
                                this.Value = value;
                        }
                }


                public decimal To
                {
                        get
                        {
                                return System.Convert.ToDecimal(this.Value2);
                        }
                        set
                        {
                                this.Value2 = value;
                        }
                }


                override public bool IsEmpty()
                {
                        return this.From == 0 && this.To == 0;
                }
        }
}
