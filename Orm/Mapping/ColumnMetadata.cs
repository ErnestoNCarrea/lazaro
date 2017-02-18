using System;
using System.Diagnostics;
using System.Reflection;

namespace Lazaro.Orm.Mapping
{
        [DebuggerDisplay("Name = {Name}, Class member = {MemberName}, Type = {Type}")]
        public class ColumnMetadata
        {
                public string MemberName { get; internal set; }
                public PropertyInfo PropertyInfo { get; internal set; }
                public FieldInfo FieldInfo { get; internal set; }

                public AssociationMetadata AssociationMetada { get; set; }

                public bool Id { get; internal set; }
                public GeneratedValueStategies GeneratedValueStategy { get; internal set; }
                public string Name { get; internal set; }

                public ColumnTypes Type { get; internal set; }
                public int Length { get; internal set; }
                public int Precision { get; internal set; }
                public bool Nullable { get; internal set; }
                public bool Unique { get; internal set; }
                public Type MemberType { get; internal set; }
        }
}
