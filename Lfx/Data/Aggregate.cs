using System;
using System.Collections.Generic;

namespace Lfx.Data
{
        [Serializable]
        public class Aggregate
        {
                public string FieldName;
                public AggregationFunctions Function = AggregationFunctions.Distinct;

                public decimal Sum;
                public int Count;

                public Aggregate(AggregationFunctions groupingType, string fieldName)
                {
                        this.Function = groupingType;
                        this.FieldName = fieldName;
                }

                public void Reset()
                {
                        this.ResetCounters();
                }

                public void ResetCounters()
                {

                        this.Count = 0;
                        this.Sum = 0;
                }

                public override string ToString()
                {
                        return this.Function.ToString() + " on " + this.FieldName;
                }
        }
}
