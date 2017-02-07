using System;
using System.Collections.Generic;

namespace Lazaro.Orm.Mapping
{
        public interface IMetadataFactory
        {
                ClassMetadataCollection ClassMetadata { get; set; }
        }
}
