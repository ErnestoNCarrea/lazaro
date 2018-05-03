using System;
using System.Collections.Generic;
using Lazaro.Orm.Data;
using Lazaro.Orm.Mapping;
using System.Reflection;
using System.Data;
using log4net;

namespace Lazaro.Orm
{
        public class EntityManager : IEntityManager
        {
                private static readonly ILog Log = LogManager.GetLogger(typeof(EntityManager));

                public IConnection Connection { get; set; }
                public IMetadataFactory MetadataFactory { get; set; }

                public EntityManager(IConnection connection, IMetadataFactory metadataFactory)
                {
                        this.Connection = connection;
                        this.MetadataFactory = metadataFactory;
                }

                /// <summary>
                /// Finds a single entity by it's primary key.
                /// </summary>
                /// <typeparam name="T">The entity type.</typeparam>
                /// <param name="primaryKeyId">The primary key value.</param>
                /// <returns>An entity or null.</returns>
                public T Find<T>(object primaryKeyId) where T : new()
                {
                        // Get class metadata
                        var EntityType = typeof(T);
                        var ClassName = EntityType.FullName;
                        var ClassMetadata = this.MetadataFactory.GetMetadataForClass(EntityType);

                        // Construct select
                        var IdCols = ClassMetadata.Columns.GetIdColumns();
                        var Select = new qGen.Select(ClassMetadata.TableName);
                        if (IdCols.Count == 1) {
                                Select.WhereClause = new qGen.Where(IdCols[0].Name, primaryKeyId);
                        } else {
                                throw new ApplicationException("Can not use Find(scalar): " + ClassMetadata.Name + " has multiple primary keys.");
                        }

                        // Execute query
                        var DataTable = this.Connection.Select(Select);
                        if (DataTable.Rows.Count == 0) {
                                return default(T);
                        } else if (DataTable.Rows.Count > 1) {
                                throw new ApplicationException("Find(scalar): " + ClassMetadata.Name + " returned more than one row.");
                        }

                        // Convert row to entity
                        return this.HydrateEntity<T>(ClassMetadata, DataTable.Rows[0]);
                }

                /// <summary>
                /// Gets a generic entity repository for a given type.
                /// </summary>
                /// <typeparam name="T">The entity type.</typeparam>
                /// <returns>An EntityRepository.</returns>
                public EntityRepository<T> GerRepository<T>() where T : new()
                {
                        return new EntityRepository<T>(this);
                }


                /// <summary>
                /// Finds all entities of a given type.
                /// </summary>
                /// <typeparam name="T">The entity type.</typeparam>
                /// <param name="orderBy">The order of the resulting set.</param>
                /// <returns>An EntityRepository with zero or more entities.</returns>
                public EntityCollection<T> FindAll<T>(string orderBy) where T : new()
                {
                        // Call FindBy with a null where
                        return this.FindBy<T>(null, orderBy);
                }


                /// <summary>
                /// Finds all entities using a search crtieria.
                /// </summary>
                /// <typeparam name="T">The entity type.</typeparam>
                /// <param name="where">The search crtieria.</param>
                /// <param name="orderBy">The order of the resulting set.</param>
                /// <returns>An EntityRepository with zero or more entities.</returns>
                public EntityCollection<T> FindBy<T>(qGen.Where where, string orderBy = null, qGen.Window window = null) where T : new()
                {
                        // Get class metadata
                        var EntityType = typeof(T);
                        var ClassName = EntityType.FullName;
                        var ClassMetadata = this.MetadataFactory.GetMetadataForClass(EntityType);

                        // Construct select
                        var IdCols = ClassMetadata.Columns.GetIdColumns();
                        var Select = new qGen.Select(ClassMetadata.TableName);
                        Select.WhereClause = where;

                        if (orderBy != null) {
                                Select.Order = orderBy;
                        }
                        if(window != null) {
                                Select.Window = window;
                        }

                        // Execute query
                        var DataTable = this.Connection.Select(Select);
                        var Res = new EntityCollection<T>();

                        // Fill the list
                        if (DataTable.Rows.Count > 0) {
                                foreach (DataRow Row in DataTable.Rows) {
                                        Res.Add(this.HydrateEntity<T>(ClassMetadata, Row));
                                }
                        }

                        return Res;
                }


                /// <summary>
                /// Finds the first entity using a search crtieria.
                /// </summary>
                /// <typeparam name="T">The entity type.</typeparam>
                /// <param name="where">The search crtieria.</param>
                /// <param name="orderBy">The order of the resulting set.</param>
                /// <returns>An entity or null.</returns>
                public T FindOneBy<T>(qGen.Where where, string orderBy = null, qGen.Window window = null) where T : new()
                {
                        // Get class metadata
                        var EntityType = typeof(T);
                        var ClassName = EntityType.FullName;
                        var ClassMetadata = this.MetadataFactory.GetMetadataForClass(EntityType);

                        // Construct select
                        var IdCols = ClassMetadata.Columns.GetIdColumns();
                        var Select = new qGen.Select(ClassMetadata.TableName);
                        Select.WhereClause = where;

                        if (orderBy != null) {
                                Select.Order = orderBy;
                        }
                        if (window != null) {
                                Select.Window = window;
                        }

                        // Execute query
                        var DataTable = this.Connection.Select(Select);
                        var Res = new EntityCollection<T>();

                        // Fill the list
                        if (DataTable.Rows.Count > 0) {
                                return this.HydrateEntity<T>(ClassMetadata, DataTable.Rows[0]);
                        } else {
                                return default(T);
                        }
                }


                /// <summary>
                /// Hydrates an entity (creates an entity from a data row).
                /// </summary>
                /// <typeparam name="T">The entity type.</typeparam>
                /// <param name="classMetadata">The class metadata to use for hydration.</param>
                /// <param name="row">The DataRow from the database.</param>
                /// <returns>An entity.</returns>
                public T HydrateEntity<T>(ClassMetadata classMetadata, System.Data.DataRow row) where T : new()
                {
                        T Res = new T();

                        foreach (var Col in classMetadata.Columns) {
                                object ColValue = row[Col.Name];

                                if (Col.AssociationMetada != null && Col.AssociationMetada.AssociationType != AssociationTypes.None) {
                                        // Association column
                                        // TODO: lazy loading

                                        // Use reflection to get the generic Find<Col.MemberType>
                                        MethodInfo Mthd = this.GetType().GetMethod("Find").MakeGenericMethod(new Type[] { Col.MemberType });

                                        // Use Find<Col.MemberType> to get the related entity
                                        var RelEntity = Mthd.Invoke(this, new object[] { ColValue });

                                        classMetadata.ObjectInfo.SetColumnValue(Res, Col, RelEntity);
                                } else {
                                        // Regular member-to-column value
                                        classMetadata.ObjectInfo.SetColumnValue(Res, Col, ColValue);
                                }
                        }

                        return Res;
                }



                /// <summary>
                /// Persist (insert or update) an entity.
                /// </summary>
                /// <param name="entity">The entity to be persisted.</param>
                public void Persist(object entity)
                {
                        var EntityType = entity.GetType();
                        var ClassName = EntityType.FullName;

                        Log.Debug("Persist " + ClassName);

                        qGen.IStatement InsertOrUpdate;

                        var ClassMetadata = this.MetadataFactory.GetMetadataForClass(EntityType);

                        var PrePersistEvt = ClassMetadata.Events.GetByType(EventTypes.PrePersist);
                        if(PrePersistEvt != null) {
                                PrePersistEvt.MethodInfo.Invoke(entity, null);
                        }

                        if (ClassMetadata.ObjectInfo.IdentifierHasValue(entity)) {
                                InsertOrUpdate = new qGen.Update(ClassMetadata.TableName);
                                InsertOrUpdate.WhereClause = new qGen.Where();
                                foreach (var Col in ClassMetadata.Columns.GetIdColumns()) {
                                        InsertOrUpdate.WhereClause.AddWithValue(Col.Name, ClassMetadata.ObjectInfo.GetColumnValue(entity, Col));
                                }
                        } else {
                                InsertOrUpdate = new qGen.Insert(ClassMetadata.TableName);
                        }

                        foreach (var Col in ClassMetadata.Columns) {
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

                        Log.Debug(InsertOrUpdate.ToString());
                        this.Connection.ExecuteNonQuery(InsertOrUpdate);

                        if (InsertOrUpdate is qGen.Insert) {
                                foreach (var Col in ClassMetadata.Columns) {
                                        if (Col.GeneratedValueStategy == GeneratedValueStategies.DbGenerated) {
                                                var Id = this.Connection.GetLastInsertId();
                                                ClassMetadata.ObjectInfo.SetColumnValue(entity, Col, Id);
                                                Log.Debug("Last insert id: " + Id.ToString());
                                                break;
                                        }
                                }
                        }

                        var PostPersistEvt = ClassMetadata.Events.GetByType(EventTypes.PostPersist);
                        if (PostPersistEvt != null) {
                                PostPersistEvt.MethodInfo.Invoke(entity, null);
                        }

                }
        }
}