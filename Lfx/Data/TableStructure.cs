using System;
using System.Collections.Generic;

namespace Lfx.Data
{
        [Serializable]
        public class TableStructure
        {
                public string Name, Label = null;
                public IDictionary<string, ColumnDefinition> Columns = null;
                public IDictionary<string, IndexDefinition> Indexes = null;
                public IDictionary<string, ConstraintDefinition> Constraints = null;
                protected string CodePage;

                public TableStructure()
                {
                        Columns = new Dictionary<string, ColumnDefinition>();
                }

                public ColumnDefinition PrimaryKey
                {
                        get
                        {
                                foreach (ColumnDefinition Def in this.Columns.Values) {
                                        if (Def.PrimaryKey)
                                                return Def;
                                }
                                return null;
                        }
                }

                public override string ToString()
                {
                        if (Columns == null || Columns.Count == 0)
                                return "";

                        string FieldsSql = "", PrimaryKeys = "";
                        foreach (ColumnDefinition Col in Columns.Values) {
                                if (FieldsSql.Length == 0)
                                        FieldsSql = "  " + Col.Name + " " + Col.SqlDefinition(false);
                                else
                                        FieldsSql += "," + System.Environment.NewLine + "  " + Col.Name + " " + Col.SqlDefinition(false);

                                if (Col.PrimaryKey) {
                                        if (PrimaryKeys.Length == 0)
                                                PrimaryKeys = Col.Name;
                                        else
                                                PrimaryKeys += "," + Col.Name;
                                }
                        }

                        string TableSql = @"CREATE TABLE """ + this.Name + @""" (" + System.Environment.NewLine;
                        TableSql += FieldsSql;
                        if (PrimaryKeys.Length > 0)
                                TableSql += "," + System.Environment.NewLine + "  PRIMARY KEY (" + PrimaryKeys + ")";
                        TableSql += System.Environment.NewLine + ") $CREATETABLE_OPTIONS$;" + System.Environment.NewLine + System.Environment.NewLine;

                        return TableSql;
                }

                public System.Xml.XmlNode ToXml(System.Xml.XmlNode node)
                {
                        System.Xml.XmlDocument document;
                        if (node is System.Xml.XmlDocument)
                                document = (System.Xml.XmlDocument)node;
                        else
                                document = node.OwnerDocument;

                        System.Xml.XmlNode Res = document.CreateElement("Table");
                        node.AppendChild(Res);

                        Res.Attributes.Append(document.CreateAttribute("name"));
                        Res.Attributes["name"].Value = this.Name;

                        if (this.Label != null) {
                                Res.Attributes.Append(document.CreateAttribute("label"));
                                Res.Attributes["label"].Value = this.Label;
                        }

                        foreach (ColumnDefinition Col in Columns.Values) {
                                Res.AppendChild(Col.ToXml(Res));
                        }

                        if (Indexes != null) {
                                foreach (IndexDefinition Index in Indexes.Values) {
                                        Res.AppendChild(Index.ToXml(Res));
                                }
                        }

                        return Res;
                }

                public static bool operator ==(TableStructure t1, TableStructure t2)
                {
                        if (object.ReferenceEquals(t1, null) || object.ReferenceEquals(t2, null))
                                return false;

                        return t1.ToString() == t2.ToString();
                }

                public static bool operator !=(TableStructure t1, TableStructure t2)
                {
                        if (object.ReferenceEquals(t1, null) || object.ReferenceEquals(t2, null))
                                return true;

                        return !(t1.ToString() == t2.ToString());
                }

                public override int GetHashCode()
                {
                        return this.ToString().GetHashCode();
                }

                public override bool Equals(object obj)
                {
                        return base.Equals(obj);
                }
        }
}
