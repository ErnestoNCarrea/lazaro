using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Lazaro.Orm.Mapping
{
        [DebuggerDisplay("Name = {Name}, Table = {TableName}")]
        public class ClassMetadata
        {
                public string Name { get; set; }
                public string TableName { get; set; }
                public string SchemaName { get; set; }
                public INamingStrategy NamingStrategy { get; set; }

                public ObjectInfo ObjectInfo { get; set; }

                public ColumnMetadataCollection Columns { get; set; }
        }
}
