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

                protected void FillAssociationInfo()
                {
                        // Fill both ends on association columns
                        foreach (var Cls in this.ClassMetadata.Values) {
                                foreach(var Col in Cls.Columns) {
                                        if(Col.AssociationMetada != null) {
                                                if (Col.AssociationMetada.AssociationType == AssociationTypes.ManyToOne) {
                                                        var OtherEnd = GetMetadataForClass(Col.MemberType);

                                                        Col.AssociationMetada.OtherEndClass = OtherEnd;

                                                        // We only support association to Id column for now
                                                        Col.AssociationMetada.OtherEndColumn = OtherEnd.Columns.GetIdColumns()[0];
                                                }
                                        }
                                }
                        }
                }
        }
}
