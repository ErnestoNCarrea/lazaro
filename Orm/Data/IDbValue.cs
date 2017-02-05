using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazaro.Orm.Data
{
        public interface IDbValue
        {
                object Value { get; set; }

                decimal ValueDecimal { get; }
                string ValueString { get; }
                int ValueInt { get; }
                DateTime ValueDateTime { get; }
        }
}
