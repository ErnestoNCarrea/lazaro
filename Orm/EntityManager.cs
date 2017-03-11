using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lazaro.Orm.Data;
using Lazaro.Orm.Mapping;

namespace Lazaro.Orm
{
        public class EntityManager : IEntityManager
        {
                public IConnection Connection { get; set; }
                public IMetadataFactory MetadataFactory { get; set; }

                public EntityManager(IConnection connection, IMetadataFactory metadataFactory)
                {
                        this.Connection = connection;
                        this.MetadataFactory = metadataFactory;
                }

                

                /// <summary>
                /// Persist (insert or update) an entity.
                /// </summary>
                /// <param name="entity">The entity to be persisted.</param>
                public void Persist(object entity)
                {
                        var EntityType = entity.GetType();
                        var ClassName = EntityType.FullName;

                        qGen.IStatement InsertOrUpdate;

                        var ClassMetadata = this.MetadataFactory.GetMetadataForClass(EntityType);
                        if(ClassMetadata.ObjectInfo.IdentifierHasValue(entity)) {
                                InsertOrUpdate = new qGen.Update(ClassMetadata.TableName);
                                InsertOrUpdate.WhereClause = new qGen.Where();
                                foreach(var Col in ClassMetadata.Columns.GetIdColumns()) {
                                        InsertOrUpdate.WhereClause.AddWithValue(Col.Name, ClassMetadata.ObjectInfo.GetColumnValue(entity, Col));
                                }
                        } else {
                                InsertOrUpdate = new qGen.Insert(ClassMetadata.TableName);
                        }

                        foreach(var Col in ClassMetadata.Columns) {
                                if (Col.GeneratedValueStategy == GeneratedValueStategies.None) {
                                        object ColValue;

                                        if (Col.AssociationMetada != null && Col.AssociationMetada.AssociationType != AssociationTypes.None) {
                                                // Association column. Get value from property on the other side
                                                object OtherEndEntity = ClassMetadata.ObjectInfo.GetColumnValue(entity, Col);
                                                if (OtherEndEntity == null) {
                                                        ColValue = null;
                                                } else {
                                                        ColValue = Col.AssociationMetada.OtherEndClass.ObjectInfo.GetColumnValue(OtherEndEntity, Col.AssociationMetada.OtherEndColumn);
                                                }
                                        } else {
                                                // Regular member-to-column value
                                                ColValue = ClassMetadata.ObjectInfo.GetColumnValue(entity, Col);
                                        }

                                        InsertOrUpdate.ColumnValues.AddWithValue(Col.Name, ColValue);
                                }
                        }

                        this.Connection.ExecuteNonQuery(InsertOrUpdate);

                        if (InsertOrUpdate is qGen.Insert) {
                                foreach (var Col in ClassMetadata.Columns) {
                                        if (Col.GeneratedValueStategy == GeneratedValueStategies.DbGenerated) {
                                                ClassMetadata.ObjectInfo.SetColumnValue(entity, Col, this.Connection.GetLastInsertId());
                                                break;
                                        }
                                }
                        }
                }
        }
}
