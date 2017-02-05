using System;

namespace Lazaro.Orm.Data
{
        public interface IColumn
        {
                string ColumnName { get; set; }
                ColumnTypes DataType { get; set; }
        }
}
