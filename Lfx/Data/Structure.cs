using System;
using System.Collections.Generic;
using Lazaro.Orm;

namespace Lfx.Data
{
        /// <summary>
        /// Describe la estructura de una base de datos.
        /// </summary>
        public class Structure
        {
                private Dictionary<string, Lfx.Data.TagCollection> m_TagList = null; // Si... una colección de colecciones

                private Dictionary<string, Lfx.Data.ConstraintDefinition> m_Constraints = null;
                private Dictionary<string, Lfx.Data.TableStructure> m_Tables = null;
                private List<System.Xml.XmlDocument> BuiltIns = new List<System.Xml.XmlDocument>();

                /// <summary>
                /// Obtiene las claves foráneas desde dbstruct.xml (puede no coincidir con el contenido actual de la base de datos)
                /// </summary>
                public System.Collections.Generic.Dictionary<string, Lfx.Data.ConstraintDefinition> Constraints
                {
                        get
                        {
                                if (m_Constraints == null)
                                        this.LoadBuiltIn();
                                return m_Constraints;
                        }
                }


                /// <summary>
                /// Obtiene las estructuras de las tablas desde dbstruct.xml (puede no coincidir con el contenido actual de la base de datos)
                /// </summary>
                public System.Collections.Generic.Dictionary<string, Lfx.Data.TableStructure> Tables
                {
                        get
                        {
                                if (m_Tables == null)
                                        this.LoadBuiltIn();
                                return m_Tables;
                        }
                }

                public System.Xml.XmlNode ToXml(System.Xml.XmlNode node)
                {
                        System.Xml.XmlDocument document;
                        if (node is System.Xml.XmlDocument)
                                document = (System.Xml.XmlDocument)node;
                        else
                                document = node.OwnerDocument;

                        System.Xml.XmlNode Res = document.CreateElement("Database");
                        node.AppendChild(Res);

                        foreach (string Tabla in Lfx.Data.DataBaseCache.DefaultCache.GetTableNames()) {
                                Res.AppendChild(Lfx.Workspace.Master.MasterConnection.GetTableStructure(Tabla, false).ToXml(Res));
                        }

                        IDictionary<string, ConstraintDefinition> Keys = Lfx.Workspace.Master.MasterConnection.GetConstraints();
                        foreach (ConstraintDefinition Key in Keys.Values) {
                                Res.AppendChild(Key.ToXml(Res));
                        }

                        return Res;
                }

                /// <summary>
                /// Carga la información de las estructuras de las tablas de datos desde un archivo XML.
                /// </summary>
                /// <param name="nombreArchivo">La ruta completa del archivo.</param>
                public void LoadFromFile(string nombreArchivo)
                {
                        this.Clear();
                        using (System.IO.StreamReader Lector = new System.IO.StreamReader(nombreArchivo, System.Text.Encoding.Default)) {
                                System.Xml.XmlDocument Doc = new System.Xml.XmlDocument();
                                Doc.Load(Lector);
                                Lector.Close();
                                this.AddFromXml(Doc);
                        }
                }

                /// <summary>
                /// Carga la información de las estructuras de las tablas de datos predeterminadas del sistema.
                /// </summary>
                public void LoadBuiltIn()
                {
                        this.Clear();
                        using (System.IO.Stream RecursoXml = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Lfx.Data.Struct.dbstruct.xml")) {
                                using (System.IO.StreamReader Lector = new System.IO.StreamReader(RecursoXml)) {
                                        System.Xml.XmlDocument Doc = new System.Xml.XmlDocument();
                                        Doc.Load(Lector);
                                        Lector.Close();
                                        RecursoXml.Close();
                                        this.AddFromXml(Doc);
                                }
                        }

                        foreach (System.Xml.XmlDocument Doc in BuiltIns) {
                                this.AddFromXml(Doc);
                        }
                }

                public void AddToBuiltIn(System.Xml.XmlDocument doc)
                {
                        this.BuiltIns.Add(doc);
                        this.AddFromXml(doc);
                }

                public void Clear()
                {
                        m_Constraints = new System.Collections.Generic.Dictionary<string, Lfx.Data.ConstraintDefinition>();
                        m_Tables = new System.Collections.Generic.Dictionary<string, Lfx.Data.TableStructure>();
                }

                /// <summary>
                /// Carga lee la información de la estructura de las tablas de datos desde un documento XML.
                /// </summary>
                /// <param name="xmlDoc">El documento desde el cual cargar la información de la estructura.</param>
                private void AddFromXml(System.Xml.XmlDocument xmlDoc)
                {
                        System.Xml.XmlNodeList ClavesXml = xmlDoc.SelectNodes("/Database/Constraint");
                        foreach (System.Xml.XmlNode ClaveXml in ClavesXml) {
                                Lfx.Data.ConstraintDefinition Con = new Lfx.Data.ConstraintDefinition(ClaveXml.Attributes["table"].Value);
                                Con.Name = ClaveXml.Attributes["name"].Value;
                                Con.Column = ClaveXml.Attributes["column"].Value;
                                Con.ReferenceTable = ClaveXml.Attributes["reference_table"].Value;
                                Con.ReferenceColumn = ClaveXml.Attributes["reference_column"].Value;
                                Constraints.Add(Con.Name, Con);
                        }

                        System.Xml.XmlNodeList TablasXml = xmlDoc.SelectNodes("/Database/Table");
                        foreach (System.Xml.XmlNode TablaXml in TablasXml) {
                                string TableName = TablaXml.Attributes["name"].Value;
                                Lfx.Data.TableStructure Tabla;
                                
                                if (m_Tables.ContainsKey(TableName)) {
                                        // Ya existe la tabla, sólo agrego la definición de las columnas nuevas
                                        Tabla = m_Tables[TableName];
                                } else {
                                        // Es una definición de una tabla nueva
                                        Tabla = new Lfx.Data.TableStructure();
                                        Tabla.Name = TableName;
                                        if (TablaXml.Attributes["label"] != null)
                                                Tabla.Label = TablaXml.Attributes["label"].Value;
                                        Tabla.Columns = new System.Collections.Generic.Dictionary<string, Lfx.Data.ColumnDefinition>();
                                }

                                System.Xml.XmlNodeList ColumnasXml = TablaXml.SelectNodes("Column");
                                foreach (System.Xml.XmlNode ColumnaXml in ColumnasXml) {
                                        Lfx.Data.ColumnDefinition Columna = new Lfx.Data.ColumnDefinition();
                                        Columna.Name = ColumnaXml.Attributes["name"].Value;

                                        if (ColumnaXml.Attributes["inputtype"] != null) {
                                                switch (ColumnaXml.Attributes["inputtype"].Value) {
                                                        case "AlphanumericSet":
                                                                Columna.InputFieldType = InputFieldTypes.AlphanumericSet;
                                                                Columna.FieldType = ColumnTypes.VarChar;
                                                                break;
                                                        case "Binary":
                                                                Columna.InputFieldType = InputFieldTypes.Binary;
                                                                Columna.FieldType = ColumnTypes.Blob;
                                                                break;
                                                        case "Bool":
                                                                Columna.InputFieldType = InputFieldTypes.Bool;
                                                                Columna.FieldType = ColumnTypes.TinyInt;
                                                                break;
                                                        case "Currency":
                                                                Columna.InputFieldType = InputFieldTypes.Currency;
                                                                Columna.FieldType = ColumnTypes.Currency;
                                                                Columna.Lenght = 15;
                                                                Columna.Precision = 4;
                                                                break;
                                                        case "Date":
                                                                Columna.InputFieldType = InputFieldTypes.Date;
                                                                Columna.FieldType = ColumnTypes.DateTime;
                                                                break;
                                                        case "DateTime":
                                                                Columna.InputFieldType = InputFieldTypes.DateTime;
                                                                Columna.FieldType = ColumnTypes.DateTime;
                                                                break;
                                                        case "Image":
                                                                Columna.InputFieldType = InputFieldTypes.Image;
                                                                Columna.FieldType = ColumnTypes.Blob;
                                                                break;
                                                        case "Integer":
                                                                Columna.InputFieldType = InputFieldTypes.Integer;
                                                                Columna.FieldType = ColumnTypes.Integer;
                                                                break;
                                                        case "MediumInt":
                                                                Columna.InputFieldType = InputFieldTypes.Integer;
                                                                Columna.FieldType = ColumnTypes.MediumInt;
                                                                break;
                                                        case "SmallInt":
                                                                Columna.InputFieldType = InputFieldTypes.Integer;
                                                                Columna.FieldType = ColumnTypes.SmallInt;
                                                                break;
                                                        case "TinyInt":
                                                                Columna.InputFieldType = InputFieldTypes.Integer;
                                                                Columna.FieldType = ColumnTypes.TinyInt;
                                                                break;
                                                        case "Memo":
                                                                Columna.InputFieldType = InputFieldTypes.Memo;
                                                                Columna.FieldType = ColumnTypes.Text;
                                                                break;
                                                        case "Numeric":
                                                                Columna.InputFieldType = InputFieldTypes.Numeric;
                                                                Columna.FieldType = ColumnTypes.Numeric;
                                                                Columna.Lenght = 15;
                                                                Columna.Precision = 4;
                                                                break;
                                                        case "NumericSet":
                                                                Columna.InputFieldType = InputFieldTypes.NumericSet;
                                                                Columna.FieldType = ColumnTypes.SmallInt;
                                                                break;
                                                        case "Relation":
                                                                Columna.InputFieldType = InputFieldTypes.Relation;
                                                                if (ColumnaXml.Attributes["relation_table"] != null)
                                                                        Columna.Relation = new Relation(Columna.Name, ColumnaXml.Attributes["relation_table"].Value, ColumnaXml.Attributes["relation_key"].Value, ColumnaXml.Attributes["relation_detail"].Value);
                                                                Columna.FieldType = ColumnTypes.Integer;
                                                                break;
                                                        case "Serial":
                                                                Columna.InputFieldType = InputFieldTypes.Serial;
                                                                Columna.FieldType = ColumnTypes.Serial;
                                                                break;
                                                        case "Text":
                                                                Columna.InputFieldType = InputFieldTypes.Text;
                                                                Columna.FieldType = ColumnTypes.VarChar;
                                                                break;
                                                        default:
                                                                throw new NotImplementedException("Lfx.Data.DataBaseCache.CargarEstructuraDesdeXml: Falta implementar " + ColumnaXml.Attributes["inputtype"].Value);
                                                }
                                        } else {
                                                Columna.FieldType = Lfx.Data.Types.FromSqlType(ColumnaXml.Attributes["datatype"].Value);
                                        }

                                        if (ColumnaXml.Attributes["lenght"] != null)
                                                Columna.Lenght = Lfx.Types.Parsing.ParseInt(ColumnaXml.Attributes["lenght"].Value);
                                        else if (Columna.FieldType == ColumnTypes.VarChar)
                                                // La longitud predeterminada para los campos VarChar es de 200
                                                Columna.Lenght = 200;

                                        if (ColumnaXml.Attributes["precision"] != null)
                                                Columna.Precision = Lfx.Types.Parsing.ParseInt(ColumnaXml.Attributes["precision"].Value);

                                        if (ColumnaXml.Attributes["label"] != null)
                                                Columna.Label = ColumnaXml.Attributes["label"].Value;
                                        else
                                                Columna.Label = Columna.Name;

                                        if (ColumnaXml.Attributes["section"] != null)
                                                Columna.Section = ColumnaXml.Attributes["section"].Value;

                                        if (ColumnaXml.Attributes["required"] != null && ColumnaXml.Attributes["required"].Value == "!")
                                                Columna.Required = true;
                                        else
                                                Columna.Required = false;

                                        if (ColumnaXml.Attributes["nullable"] == null)
                                                Columna.Nullable = false;
                                        else if (ColumnaXml.Attributes["nullable"].Value == "1")
                                                Columna.Nullable = true;
                                        else
                                                Columna.Nullable = false;

                                        if (ColumnaXml.Attributes["primary_key"] != null)
                                                Columna.PrimaryKey = System.Convert.ToBoolean(Lfx.Types.Parsing.ParseInt(ColumnaXml.Attributes["primary_key"].Value));

                                        if (ColumnaXml.Attributes["default"] != null && ColumnaXml.Attributes["default"].Value.Length > 0) {
                                                Columna.DefaultValue = ColumnaXml.Attributes["default"].Value;
                                        } else {
                                                switch (Columna.FieldType) {
                                                        case ColumnTypes.VarChar:
                                                                Columna.DefaultValue = null;
                                                                break;
                                                        case ColumnTypes.Text:
                                                        case ColumnTypes.Blob:
                                                                Columna.DefaultValue = null;
                                                                break;
                                                        case ColumnTypes.Currency:
                                                        case ColumnTypes.Integer:
                                                        case ColumnTypes.NonExactDecimal:
                                                        case ColumnTypes.Numeric:
                                                        case ColumnTypes.Serial:
                                                        case ColumnTypes.SmallInt:
                                                        case ColumnTypes.TinyInt:
                                                        case ColumnTypes.MediumInt:
                                                                if (Columna.Nullable)
                                                                        Columna.DefaultValue = "NULL";
                                                                else
                                                                        Columna.DefaultValue = null;
                                                                break;
                                                        case ColumnTypes.DateTime:
                                                                Columna.DefaultValue = null;
                                                                break;
                                                        default:
                                                                Columna.DefaultValue = "";
                                                                break;
                                                }
                                        }

                                        if (Tabla.Columns.ContainsKey(Columna.Name))
                                                Tabla.Columns[Columna.Name] = Columna;
                                        else
                                                Tabla.Columns.Add(Columna.Name, Columna);
                                }

                                //Agrego los campos de sys_tags
                                if (this.TagList.ContainsKey(Tabla.Name)) {
                                        foreach (Data.Tag Tg in this.TagList[Tabla.Name]) {
                                                Lfx.Data.ColumnDefinition Columna = new Lfx.Data.ColumnDefinition(Tg.FieldName, Tg.FieldType);
                                                switch (Columna.FieldType) {
                                                        case Lazaro.Orm.ColumnTypes.VarChar:
                                                                Columna.Lenght = 200;
                                                                break;
                                                        case Lazaro.Orm.ColumnTypes.Numeric:
                                                                Columna.Lenght = 15;
                                                                Columna.Precision = 4;
                                                                break;
                                                }
                                                Columna.Nullable = Tg.Nullable;
                                                Columna.PrimaryKey = false;
                                                Columna.Label = Tg.Label;

                                                if (Tg.DefaultValue != null)
                                                        Columna.DefaultValue = Tg.DefaultValue.ToString();

                                                if (Tabla.Columns.ContainsKey(Tg.FieldName))
                                                        Tabla.Columns[Columna.Name] = Columna;
                                                else
                                                        Tabla.Columns.Add(Columna.Name, Columna);
                                        }
                                }

                                if (Tabla.Indexes == null)
                                        Tabla.Indexes = new System.Collections.Generic.Dictionary<string, Lfx.Data.IndexDefinition>();

                                System.Xml.XmlNodeList IndicesXml = TablaXml.SelectNodes("Index");
                                foreach (System.Xml.XmlNode IndiceXml in IndicesXml) {
                                        Lfx.Data.IndexDefinition Indice = new Lfx.Data.IndexDefinition(Tabla.Name);
                                        Indice.Name = IndiceXml.Attributes["name"].Value;
                                        if (IndiceXml.Attributes["unique"] != null)
                                                Indice.Unique = System.Convert.ToBoolean(Lfx.Types.Parsing.ParseInt(IndiceXml.Attributes["unique"].Value));
                                        if (IndiceXml.Attributes["primary"] != null)
                                                Indice.Primary = System.Convert.ToBoolean(Lfx.Types.Parsing.ParseInt(IndiceXml.Attributes["primary"].Value));
                                        Indice.Columns = new List<string>(IndiceXml.Attributes["columns"].Value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
                                        Tabla.Indexes.Add(Indice.Name, Indice);

                                        if (Indice.Primary) {
                                                // Marco las claves primarias
                                                foreach (string ColName in Indice.Columns) {
                                                        Tabla.Columns[ColName].PrimaryKey = true;
                                                }
                                        }
                                }

                                if (m_Tables.ContainsKey(Tabla.Name) == false)
                                        this.m_Tables.Add(Tabla.Name, Tabla);
                        }
                }


                public void LoadTagList()
                {
                        m_TagList = null;
                }

                public System.Collections.Generic.Dictionary<string, Lfx.Data.TagCollection> TagList
                {
                        get
                        {
                                if (m_TagList == null || m_TagList.Count == 0) {
                                        if (m_TagList == null)
                                                m_TagList = new System.Collections.Generic.Dictionary<string, Data.TagCollection>();
                                        if (Lfx.Data.DataBaseCache.DefaultCache.Tables.ContainsKey("sys_tags")) {
                                                System.Data.DataTable TagsTable = Lfx.Workspace.Master.MasterConnection.Select("SELECT * FROM sys_tags WHERE fieldtype NOT IN ('action') ORDER BY tablename");
                                                foreach (System.Data.DataRow TagRow in TagsTable.Rows) {
                                                        string TableName = TagRow["tablename"].ToString();
                                                        if (m_TagList.ContainsKey(TableName) == false)
                                                                m_TagList.Add(TableName, new Data.TagCollection());

                                                        Data.TagCollection CurrentCol = m_TagList[TableName];

                                                        Data.Tag NewTag = new Data.Tag(Lfx.Workspace.Master.MasterConnection, TableName, (Lfx.Data.Row)TagRow);
                                                        CurrentCol.Add(NewTag);
                                                }
                                        }
                                }
                                return m_TagList;
                        }
                }
        }
}
