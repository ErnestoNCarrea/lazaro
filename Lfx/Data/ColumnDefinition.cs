using System;
using Lazaro.Orm;
using Lazaro.Orm.Data;

namespace Lfx.Data
{
        [Serializable]
        public class ColumnDefinition : IColumnDefinition
        {
                public string Name { get; set; }
                public ColumnTypes FieldType;
                public int Lenght, Precision;
                public bool Nullable, PrimaryKey, Unsigned;
                public string DefaultValue = null;

                // Propiedades que tienen que ver con la representación
                public string Label, Section;
                private InputFieldTypes m_InputFieldType;
                public bool Required = false;
                public Relation Relation;

                public ColumnDefinition()
                {
                }

                public ColumnDefinition(string name, ColumnTypes fieldType)
                {
                        this.Name = name;
                        this.FieldType = fieldType;
                }

                public override string ToString()
                {
                        return this.Name + " " + this.SqlDefinition(true);
                }

                public string SqlType()
                {
                        string Def = "";
                        switch (FieldType) {
                                case ColumnTypes.Serial:
                                        return "$SERIAL$";
                                case ColumnTypes.Relation:
                                        Def = "MEDIUMINT";
                                        break;
                                case ColumnTypes.DateTime:
                                        Def = "$DATETIME$";
                                        break;
                                case ColumnTypes.VarChar:
                                        Def = "VARCHAR";
                                        break;
                                case ColumnTypes.Integer:
                                        Def = "INTEGER";
                                        break;
                                case ColumnTypes.MediumInt:
                                        Def = "$MEDIUMINT$";
                                        break;
                                case ColumnTypes.SmallInt:
                                        Def = "$SMALLINT$";
                                        break;
                                case ColumnTypes.TinyInt:
                                        Def = "$TINYINT$";
                                        break;
				case ColumnTypes.Currency:
                                case ColumnTypes.Numeric:
                                        Def = "NUMERIC";
                                        break;
                                case ColumnTypes.Blob:
                                        Def = "$BLOB$";
                                        break;
                                case ColumnTypes.Text:
                                        Def = "TEXT";
                                        break;
                        }

                        if (this.Lenght > 0) {
                                Def += "(" + this.Lenght.ToString();
                                if (this.Precision > 0)
                                        Def += "," + this.Precision.ToString();
                                Def += ")";
                        }
                        return Def;
                }

                public InputFieldTypes InputFieldType
                {
                        get
                        {
                                return m_InputFieldType;
                        }
                        set
                        {
                                this.m_InputFieldType = value;
                                switch (this.m_InputFieldType) {
                                        case InputFieldTypes.AlphanumericSet:
                                                this.FieldType = ColumnTypes.VarChar;
                                                break;
                                        case InputFieldTypes.Binary:
                                                this.FieldType = ColumnTypes.Blob;
                                                break;
                                        case InputFieldTypes.Bool:
                                                this.FieldType = ColumnTypes.SmallInt;
                                                break;
                                        case InputFieldTypes.Currency:
                                                this.FieldType = ColumnTypes.Currency;
                                                break;
                                        case InputFieldTypes.Date:
                                        case InputFieldTypes.DateTime:
                                                this.FieldType = ColumnTypes.DateTime;
                                                break;
                                        case InputFieldTypes.Image:
                                                this.FieldType = ColumnTypes.Blob;
                                                break;
                                        case InputFieldTypes.Integer:
                                                this.FieldType = ColumnTypes.Integer;
                                                break;
                                        case InputFieldTypes.Memo:
                                                this.FieldType = ColumnTypes.Text;
                                                break;
                                        case InputFieldTypes.Numeric:
                                                this.FieldType = ColumnTypes.Numeric;
                                                break;
                                        case InputFieldTypes.NumericSet:
                                                this.FieldType = ColumnTypes.SmallInt;
                                                break;
                                        case InputFieldTypes.Relation:
                                                this.FieldType = ColumnTypes.MediumInt;
                                                break;
                                        case InputFieldTypes.Serial:
                                                this.FieldType = ColumnTypes.Serial;
                                                break;
                                        case InputFieldTypes.Text:
                                                this.FieldType = ColumnTypes.VarChar;
                                                break;
                                        default:
                                                throw new NotImplementedException("Lfx.Data.ColumnDefinition.InputFieldType: Falta implementar " + this.m_InputFieldType.ToString());
                                }
                        }
                }


                public string SqlDefinition(bool specifyPrimaryKey)
                {
                        string Def = this.SqlType();

                        if (this.FieldType != ColumnTypes.Serial) {
                                if (this.Unsigned)
                                        Def += " UNSIGNED";

                                if (this.Nullable == false)
                                        Def += " NOT NULL";

                                switch (FieldType) {
                                        case ColumnTypes.Text:
                                        case ColumnTypes.Blob:
                                                // No pueden tener default
                                                break;
                                        case ColumnTypes.VarChar:
                                                if (this.DefaultValue == null) {
                                                        //Def += " DEFAULT ''";	//Default to empty string
                                                } else if (this.DefaultValue == "NULL") {
                                                        Def += " DEFAULT NULL";
                                                } else {
                                                        Def += " DEFAULT '" + this.DefaultValue + "'";
                                                }
                                                break;
                                        case ColumnTypes.Currency:
                                        case ColumnTypes.Numeric:
                                                if (this.DefaultValue == null) {
                                                        /* if(this.Nullable)
                                                                Def += " DEFAULT NULL";	// Nullable columns default to null
                                                        else
                                                                Def += " DEFAULT 0";	// Otherwise, default to zero */
                                                } else if (this.DefaultValue == "NULL") {
                                                        Def += " DEFAULT NULL";
                                                } else {
                                                        Def += " DEFAULT " + Lfx.Types.Formatting.FormatNumberSql(Lfx.Types.Parsing.ParseDecimal(this.DefaultValue), 4) + "";
                                                }
                                                break;
                                        case ColumnTypes.Integer:
                                        case ColumnTypes.SmallInt:
                                        case ColumnTypes.MediumInt:
                                        case ColumnTypes.TinyInt:
                                                if (this.DefaultValue == null) {
                                                        /* if(this.Nullable)
                                                                Def += " DEFAULT NULL";	// Nullable columns default to null
                                                        else
                                                                Def += " DEFAULT 0";	// Otherwise, default to zero */
                                                } else if (this.DefaultValue == "NULL") {
                                                        Def += " DEFAULT NULL";
                                                } else {
                                                        Def += " DEFAULT " + this.DefaultValue + "";
                                                }
                                                break;  
                                        default:
                                                if (this.DefaultValue != null && this.DefaultValue.Length > 0)
                                                        Def += " DEFAULT " + this.DefaultValue;
                                                break;
                                }
                        }

                        if (specifyPrimaryKey && this.PrimaryKey)
                                Def += " PRIMARY KEY";
                        return Def;
                }

                public System.Xml.XmlNode ToXml(System.Xml.XmlNode node)
                {
                        System.Xml.XmlDocument document;
                        if (node is System.Xml.XmlDocument)
                                document = (System.Xml.XmlDocument)node;
                        else
                                document = node.OwnerDocument;

                        System.Xml.XmlNode Res = document.CreateElement("Column");

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("name"));
                        Res.Attributes["name"].Value = this.Name;

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("datatype"));
                        Res.Attributes["datatype"].Value = this.FieldType.ToString();

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("nullable"));
                        Res.Attributes["nullable"].Value = this.Nullable ? "1" : "0";

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("primary_key"));
                        Res.Attributes["primary_key"].Value = this.PrimaryKey ? "1" : "0";

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("lenght"));
                        Res.Attributes["lenght"].Value = this.Lenght.ToString();

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("precision"));
                        Res.Attributes["precision"].Value = this.Precision.ToString();

                        Res.Attributes.Append(node.OwnerDocument.CreateAttribute("default"));
                        Res.Attributes["default"].Value = this.DefaultValue;

                        node.AppendChild(Res);

                        return Res;
                }

                public static bool operator ==(ColumnDefinition f1, ColumnDefinition f2)
                {
                        if (object.ReferenceEquals(f1, null) && object.ReferenceEquals(f2, null))
                                return true;
                        if (object.ReferenceEquals(f1, null) || object.ReferenceEquals(f2, null))
                                return false;

                        string s1 = f1.ToString(), s2 = f2.ToString();

                        return f1.PrimaryKey == f2.PrimaryKey
                                && f1.Unsigned == f2.Unsigned
                                && f1.Nullable == f2.Nullable
                                && s1 == s2;
                }

                public static bool operator !=(ColumnDefinition f1, ColumnDefinition f2)
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

        }
}
