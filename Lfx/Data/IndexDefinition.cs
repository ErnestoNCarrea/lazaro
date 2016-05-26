using System;
using System.Collections.Generic;

namespace Lfx.Data
{
        [Serializable]
        public class IndexDefinition
        {
                public string TableName;
                public string Name;
                public List<string> Columns;
                public bool Unique, Primary;

                public IndexDefinition(string tableName)
                {
                        TableName = tableName;
                }

                public System.Xml.XmlNode ToXml(System.Xml.XmlNode node)
                {
                        System.Xml.XmlDocument document;
                        if (node is System.Xml.XmlDocument)
                                document = (System.Xml.XmlDocument)node;
                        else
                                document = node.OwnerDocument;

                        System.Xml.XmlNode Res = document.CreateElement("Index");

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("table"));
                        Res.Attributes["table"].Value = this.TableName;

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("name"));
                        Res.Attributes["name"].Value = this.Name;

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("columns"));
                        Res.Attributes["columns"].Value = string.Join(",", this.Columns.ToArray());

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("unique"));
                        Res.Attributes["unique"].Value = this.Unique ? "1" : "0";

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("primary"));
                        Res.Attributes["primary"].Value = this.Primary ? "1" : "0";

                        node.AppendChild(Res);

                        return Res;
                }

                public string CommaSeparatedColumns()
                {
                        return "\"" + String.Join(",", this.Columns.ToArray()).Replace(",", "\",\"") + "\"";
                }

                public string SqlDefinition()
                {
                        if (this.Primary) {
                                return "PRIMARY KEY (" + this.CommaSeparatedColumns() + ")";
                        } else {
                                string Res = "INDEX \"" + this.Name + "\" (" + this.CommaSeparatedColumns() + ")"; ;
                                if (this.Unique)
                                        Res = "UNIQUE " + Res;
                                return Res;
                        }
                }

                public static bool operator ==(IndexDefinition f1, IndexDefinition f2)
                {
                        if (object.ReferenceEquals(f1, null) && object.ReferenceEquals(f2, null))
                                return true;
                        if (object.ReferenceEquals(f1, null) || object.ReferenceEquals(f2, null))
                                return false;

                        return string.Compare(f1.TableName, f2.TableName) == 0
                                && f1.Unique == f2.Unique
                                && f1.Primary == f2.Primary
                                && string.Compare(f1.Name, f2.Name) == 0
                                && string.Compare(f1.CommaSeparatedColumns(), f2.CommaSeparatedColumns()) == 0;
                }

                public static bool operator !=(IndexDefinition f1, IndexDefinition f2)
                {
                        return !(f1 == f2);
                }

                public override int GetHashCode()
                {
                        return base.GetHashCode();
                }

                public override bool Equals(object obj)
                {
                        return base.Equals(obj);
                }

                public override string ToString()
                {
                        string Res = this.Name + ": " + this.TableName + " (" + this.CommaSeparatedColumns() + ")";
                        if (this.Primary)
                                Res += " primary";
                        if (this.Primary)
                                Res += " unique";
                        return Res;
                }
        }
}
