using System;

namespace Lazaro.Orm.Mapping
{
        public class ColumnMetadata
        {
                public bool Id { get; set; }
                public string Name { get; set; }

                public ColumnTypes Type { get; set; }
                public int Length { get; set; }
                public int Precision { get; set; }
                public bool Nullable { get; set; }
                public bool Unique { get; set; }
        }
}
