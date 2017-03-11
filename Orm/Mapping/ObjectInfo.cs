using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Lazaro.Orm.Mapping
{
        [DebuggerDisplay("Type = {ObjectType}")]
        public class ObjectInfo
        {
                public ClassMetadata ClassMetadata { get; }
                public Type ObjectType { get; }

                public ObjectInfo(Type objType, ClassMetadata classMetadata)
                {
                        this.ObjectType = objType;
                        this.ClassMetadata = classMetadata;
                }


                /// <summary>
                /// Returns true if a value has been set for the id column(s) of an entity (i.e. if the entity has an id).
                /// </summary>
                /// <param name="obj">The entity.</param>
                /// <returns>True if the entity id column(s) have value(s).</returns>
                public bool IdentifierHasValue(object obj)
                {
                        var IdValues = GetIdValues(obj);
                        var DefaultIdValues = GetDefaultIdValues(obj);

                        if(IdValues.Length == 0) {
                                throw new ApplicationException("The entity has no Id column.");
                        }

                        if(IdValues.Length != DefaultIdValues.Length) {
                                throw new ApplicationException("The number of id columns and default values does not match.");
                        }

                        for(var i = 0; i < IdValues.Length; i++) {
                                if(IdValues[i].Equals(DefaultIdValues[i]) == false) {
                                        return true;
                                }
                        }

                        return false;
                }


                public object[] GetIdValues(object obj)
                {
                        List<object> IdValues = new List<object>();
                        var IdColumns = this.ClassMetadata.Columns.GetIdColumns();
                        foreach(var IdCol in IdColumns) {
                                IdValues.Add(this.GetColumnValue(obj, IdCol));
                        }

                        return IdValues.ToArray();
                }


                public object[] GetDefaultIdValues(object obj)
                {
                        List<object> IdDefaultValues = new List<object>();
                        var IdColumns = this.ClassMetadata.Columns.GetIdColumns();

                        foreach (var IdCol in IdColumns) {
                                IdDefaultValues.Add(GetDefault(IdCol.MemberType));
                        }

                        return IdDefaultValues.ToArray();
                }


                /// <summary>
                /// Returns the default value for a given type.
                /// </summary>
                /// <param name="type">The type for which the default value is requested.</param>
                /// <returns>The default value for the given type.</returns>
                public static object GetDefault(Type type)
                {
                        if (type.IsValueType) {
                                return Activator.CreateInstance(type);
                        }
                        return null;
                }


                public object GetColumnValue(object obj, ColumnMetadata col)
                {
                        if (col.PropertyInfo != null) {
                                if (obj == null) {
                                        return null;
                                } else {
                                        return col.PropertyInfo.GetValue(obj, null);
                                }
                        } else if (col.FieldInfo != null) {
                                if (obj == null) {
                                        return null;
                                } else {
                                        return col.FieldInfo.GetValue(obj);
                                }
                        } else {
                                throw new ApplicationException("Column has no associated field or property.");
                        }
                }


                public void SetColumnValue(object obj, ColumnMetadata col, object newValue)
                {
                        if (col.PropertyInfo != null) {
                                col.PropertyInfo.SetValue(obj, newValue, null);
                        } else if (col.FieldInfo != null) {
                                col.FieldInfo.SetValue(obj, newValue);
                        } else {
                                throw new ApplicationException("Column has no associated field or property.");
                        }
                }
        }
}
