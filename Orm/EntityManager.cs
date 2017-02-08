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
                public Mapping.IMetadataFactory MetadataFactory { get; set; }

                public EntityManager(IConnection connection)
                {
                        this.Connection = connection;
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
                                        InsertOrUpdate.ColumnValues.AddWithValue(Col.Name, ClassMetadata.ObjectInfo.GetColumnValue(entity, Col));
                                }
                        }

                        this.Connection.ExecuteNonQuery(InsertOrUpdate);
                }
        }
}
