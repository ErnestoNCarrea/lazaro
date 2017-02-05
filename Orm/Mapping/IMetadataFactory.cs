using System;
using System.Collections.Generic;

namespace Lazaro.Orm.Mapping
{
        public interface IMetadataFactory
        {
                Dictionary<string, ClassMetadata> ClassMetadata { get; set; }
        }
}
