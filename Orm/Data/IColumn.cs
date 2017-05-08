using qGen;
using System;

namespace Lazaro.Orm.Data
{
        public interface IColumn
        {
                SqlIdentifier ColumnIdentifier { get; set; }
                ColumnTypes DataType { get; set; }
        }
}
