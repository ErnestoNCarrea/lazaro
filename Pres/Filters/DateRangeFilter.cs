using System;

namespace Lazaro.Pres.Filters
{
        [Serializable]
        public class DateRangeFilter : Filter
        {
                public DateRangeFilter(string label, string columnName)
                        : base(label, columnName)
                {
                }

                public DateRangeFilter(string label, string columnName, Lfx.Types.DateRange dateRange)
                        : this(label, columnName)
                {
                        this.DateRange = dateRange;
                }

                override public bool IsEmpty()
                {
                        return this.DateRange == null;
                }

                public Lfx.Types.DateRange DateRange
                {
                        get
                        {
                                return this.Value as Lfx.Types.DateRange;
                        }
                        set
                        {
                                this.Value = value;
                        }
                }
        }
}
