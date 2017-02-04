using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazaro.Orm.Data
{
        public interface IField
        {
                string ColumnName { get; set; }
                object Value { get; set; }
                ColumnTypes DataType { get; set; }

                decimal ValueDecimal { get; }
                string ValueString { get; }
                int ValueInt { get; }
                DateTime ValueDateTime { get; }
        }
}
