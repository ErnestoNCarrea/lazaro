using System;
using System.Collections.Generic;

namespace Lfx.Data
{
        [Serializable]
        public class Grouping
        {
                public string FieldName;
                public object LastValue = null;

                public Grouping(string fieldName)
                {
                        this.FieldName = fieldName;
                }

                public void Reset()
                {
                        this.LastValue = null;
                }
        }
}
