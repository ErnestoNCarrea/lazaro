using System;
using System.Diagnostics;
using System.Reflection;

namespace Lazaro.Orm.Mapping
{
        [DebuggerDisplay("Name = {Name}, Class member = {MemberName}, Type = {Type}")]
        public class ColumnMetadata
        {
                public string MemberName { get; set; }
                public PropertyInfo PropertyInfo { get; internal set; }
                public FieldInfo FieldInfo { get; internal set; }

                public bool Id { get; set; }
                public GeneratedValueStategies GeneratedValueStategy { get; set; }
                public string Name { get; set; }

                public ColumnTypes Type { get; set; }
                public int Length { get; set; }
                public int Precision { get; set; }
                public bool Nullable { get; set; }
                public bool Unique { get; set; }
        }
}
