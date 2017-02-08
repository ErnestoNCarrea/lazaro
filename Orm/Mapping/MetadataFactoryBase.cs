using System;

namespace Lazaro.Orm.Mapping
{
        public class MetadataFactoryBase : IMetadataFactory
        {
                public ClassMetadataCollection ClassMetadata { get; set; } = new ClassMetadataCollection();

                public ClassMetadata GetMetadataForClass(Type objType)
                {
                        return this.GetMetadataForClass(objType.FullName);
                }

                public ClassMetadata GetMetadataForClass(string className)
                {
                        if(this.ClassMetadata.ContainsKey(className)) {
                                return this.ClassMetadata[className];
                        } else {
                                throw new ApplicationException("No metadata found for class " + className);
                        }
                }
        }
}
