using System;
using System.Collections.Generic;

namespace Lazaro.Pres.Filters
{
        [Serializable]
        public class SetFilter : Filter
        {
                [NonSerialized]
                public string[] SetData = null;

                public SetFilter(string label, string columnName)
                        : base(label, columnName)
                {
                }


                public SetFilter(string label, string columnName, string[] setData, string initialValue)
                        : this(label, columnName)
                {
                        this.SetData = setData;
                        this.CurrentValue = initialValue;
                }


                public SetFilter(string label, string columnName, IDictionary<int, string> setValues, int initialValue)
                        : this(label, columnName)
                {
                        this.SetData = new string[setValues.Count];
                        int i = 0;
                        foreach (KeyValuePair<int, string> Val in setValues) {
                                this.SetData[i++] = Val.Value + "|" + Val.Key.ToString();
                        }
                        this.CurrentValue = initialValue.ToString();
                }


                public string CurrentValue
                {
                        get
                        {
                                return System.Convert.ToString(this.Value);
                        }
                        set
                        {
                                this.Value = value;
                        }
                }


                override public bool IsEmpty()
                {
                        return this.Value == null;
                }
        }
}
