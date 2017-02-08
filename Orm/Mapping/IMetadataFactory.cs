using System;
using System.Collections.Generic;

namespace Lazaro.Orm.Mapping
{
        public interface IMetadataFactory
        {
                ClassMetadataCollection ClassMetadata { get; set; }

                ClassMetadata GetMetadataForClass(Type objType);
                ClassMetadata GetMetadataForClass(string className);
        }
}
