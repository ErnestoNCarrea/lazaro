using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lazaro.Orm.Mapping
{
        public class ReflectionMetadataFactory : MetadataFactoryBase, IMetadataFactory
        {
                public Dictionary<string, ClassMetadata> ClassMetadata { get; set; }
                public Dictionary<string, Assembly> Assemblies { get; set; }

                public ReflectionMetadataFactory()
                {
                        this.Assemblies = new Dictionary<string, Assembly>();
                }


                /* public void AddFolder(string folderName)
                {

                } */


                public void AddAssembly(Assembly assembly)
                {
                        this.Assemblies.Add(assembly.FullName, assembly);
                }
        }
}
