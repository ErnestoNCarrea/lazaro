using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazaro.Orm.Mapping
{
        public class ClassMetadata
        {
                public string Name { get; set; }
                public string TableName { get; set; }
                public string SchemaName { get; set; }
                public INamingStrategy NamingStrategy { get; set; }

                public ColumnMetadataCollection Columns { get; set; }
        }
}
