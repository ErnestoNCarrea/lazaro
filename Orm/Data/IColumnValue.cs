using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazaro.Orm.Data
{
        public interface IColumnValue : IColumn, IDbValue
        {
                bool ValueCanBeParameter { get; }
        }
}
