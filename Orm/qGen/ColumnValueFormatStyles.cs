using System;
using System.ComponentModel;

namespace qGen
{
        public enum ColumnValueFormatStyles
        {
                [Description("UPDATE style: col1=val1, col2=val2, ...")]
                UpdateStyle,

                [Description("INSERT style: (col1, col2, ...) VAUES (val1, val2, ...)")]
                InsertStyle,

                [Description("VALUES oly style: (val1, val2, ...)")]
                InsertStyleValuesOnly,
        }
}
