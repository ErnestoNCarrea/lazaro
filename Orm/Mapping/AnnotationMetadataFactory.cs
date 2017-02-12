using log4net;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lazaro.Orm.Mapping
{
        public class AnnotationMetadataFactory : MetadataFactoryBase, IMetadataFactory
        {
                private static readonly ILog Log = LogManager.GetLogger(typeof(AnnotationMetadataFactory));

                public List<Assembly> Assemblies { get; set; } = new List<Assembly>();

                public AnnotationMetadataFactory()
                {
                }


                public void Init()
                {
                        /* foreach(var Asm in this.Assemblies) {
                                var ModelAttr = Asm.GetCustomAttributes(typeof(Attributes.Model), false);
                                if(ModelAttr.Length > 0) {
                                        Log.Info("Model found on " + Asm.Location);
                                        this.AddAssembly(Asm);
                                }
                        } */
                }

                public void ScanFolder(string folderName, bool recursive)
                {
                        var Files = System.IO.Directory.EnumerateFiles(folderName, "*.dll", recursive ? System.IO.SearchOption.AllDirectories : System.IO.SearchOption.TopDirectoryOnly);
                        foreach(var File in Files) {
                                var Assembly = System.Reflection.Assembly.LoadFrom(File);
                                var ModelAttr = Assembly.GetCustomAttributes(typeof(Attributes.Model), false);
                                if (ModelAttr.Length > 0) {
                                        Log.Info("Model found on " + Assembly.Location);
                                        this.ScanAssembly(Assembly);
                                }
                        }
                }


                private void ScanAssembly(Assembly assembly)
                {
                        this.Assemblies.Add(assembly);

                        foreach (var Cls in assembly.GetExportedTypes()) {
                                var Attr = Cls.GetCustomAttributes(typeof(Attributes.Entity), false);
                                if (Attr.Length > 0) {
                                        var EntityAttr = Attr[0] as Attributes.Entity;
                                        Log.Info("Entity found on " + Cls.FullName);

                                        var ClsMeta = new Mapping.ClassMetadata()
                                        {
                                                Name = Cls.Name,
                                                TableName = EntityAttr.TableName,
                                                Columns = this.ScanClass(Cls)
                                        };
                                        ClsMeta.ObjectInfo = new Mapping.ObjectInfo(Cls, ClsMeta);

                                        if (string.IsNullOrWhiteSpace(EntityAttr.IdFieldName) == false) {
                                                // Overide id column name at table level, for compatibility with some ORMs
                                                ClsMeta.Columns.GetIdColumns()[0].Name = EntityAttr.IdFieldName;
                                        }

                                        this.ClassMetadata.Add(Cls.FullName, ClsMeta);
                                }
                        }
                }


                private ColumnMetadataCollection ScanClass(Type clsType)
                {
                        var Res = new ColumnMetadataCollection();

                        var Members = clsType.GetMembers(BindingFlags.Instance | BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Public);
                        foreach(MemberInfo Mbr in Members) {
                                var ColAttrs = Mbr.GetCustomAttributes(typeof(Attributes.Column), true);
                                if(ColAttrs.Length > 0) {
                                        var ColumnAttr = ColAttrs[0] as Attributes.Column;
                                        var NewCol = new ColumnMetadata()
                                        {
                                                MemberName = Mbr.Name,
                                                Id = ColumnAttr.Id,
                                                GeneratedValueStategy = ColumnAttr.GeneratedValueStategy,
                                                Name = ColumnAttr.Name,
                                                Type = ColumnAttr.Type,
                                                Length = ColumnAttr.Length,
                                                Precision = ColumnAttr.Precision,
                                                Nullable = ColumnAttr.Nullable,
                                                Unique = ColumnAttr.Unique,
                                        };
                                        if(Mbr is PropertyInfo) {
                                                NewCol.PropertyInfo = Mbr as PropertyInfo;
                                                NewCol.MemberType = NewCol.PropertyInfo.PropertyType;
                                        } else if (Mbr is FieldInfo) {
                                                NewCol.FieldInfo = Mbr as FieldInfo;
                                                NewCol.MemberType = NewCol.FieldInfo.FieldType;
                                        }

                                        Res.Add(NewCol);
                                }
                        }

                        return Res;
                }
        }
}
