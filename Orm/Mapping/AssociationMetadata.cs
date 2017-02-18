using System;

namespace Lazaro.Orm.Mapping
{
        public class AssociationMetadata
        {
                public AssociationTypes AssociationType { get; set; } = AssociationTypes.None;

                public ClassMetadata OtherEndClass { get; set; }
                public ColumnMetadata OtherEndColumn { get; set; }
        }
}
