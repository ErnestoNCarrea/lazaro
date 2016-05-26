using System;

namespace Lfx.Data
{
        [Serializable]
        public class ConstraintDefinition
        {
                public string TableName;
                public string Name;
                public string Column;
                public string ReferenceTable, ReferenceColumn;
                public KeyActions OnDelete = KeyActions.Unknown, OnUpdate = KeyActions.Unknown;

                public ConstraintDefinition(string tableName)
                {
                        TableName = tableName;
                }

                public static bool operator ==(ConstraintDefinition f1, ConstraintDefinition f2)
                {
                        if (object.ReferenceEquals(f1, null) && object.ReferenceEquals(f2, null))
                                return true;

                        if (object.ReferenceEquals(f1, null) || object.ReferenceEquals(f2, null))
                                return false;

                        return f1.TableName == f2.TableName
                                && f1.ToString() == f2.ToString();
                }

                public static bool operator !=(ConstraintDefinition f1, ConstraintDefinition f2)
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
                        return this.Name + "\" FOREIGN KEY (\"" + this.Column + "\") REFERENCES \"" + this.ReferenceTable + "\" (\"" + this.ReferenceColumn + "\") $DEFERRABLE$";
                }

                public System.Xml.XmlNode ToXml(System.Xml.XmlNode node)
                {
                        System.Xml.XmlDocument document;
                        if (node is System.Xml.XmlDocument)
                                document = (System.Xml.XmlDocument)node;
                        else
                                document = node.OwnerDocument;

                        System.Xml.XmlNode Res = document.CreateElement("Constraint");

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("name"));
                        Res.Attributes["name"].Value = this.Name;

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("table"));
                        Res.Attributes["table"].Value = this.TableName;

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("column"));
                        Res.Attributes["column"].Value = this.Column;

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("reference_table"));
                        Res.Attributes["reference_table"].Value = this.ReferenceTable;

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("reference_column"));
                        Res.Attributes["reference_column"].Value = this.ReferenceColumn;

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("on_delete"));
                        Res.Attributes["on_delete"].Value = this.OnDelete.ToString();

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("on_update"));
                        Res.Attributes["on_update"].Value = this.OnUpdate.ToString();

                        node.AppendChild(Res);

                        return Res;
                }
        }
}