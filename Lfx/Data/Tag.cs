using System;

namespace Lfx.Data
{
        public class Tag
        {
                public int Id { get; set; }
                public string TableName, FieldName, Label, Extra, LblType;
                public bool Nullable { get; set; }
                public bool Internal { get; set; }
                public int Access { get; set; }
                public Lfx.Data.DbTypes FieldType = Lfx.Data.DbTypes.VarChar;
                public Lfx.Data.InputFieldTypes InputFieldType = InputFieldTypes.Text;
                public object Value { get; set; }
                public object DefaultValue { get; set; }
                public Connection DataBase { get; set; }
                public Lfx.Data.Relation Relation { get; set; }

                public Tag(Connection dataBase, string tableName, Lfx.Data.Row fromRow)
                {
                        this.DataBase = dataBase;
                        this.TableName = tableName;
                        this.Id = System.Convert.ToInt32(fromRow["id_tag"]);
                        this.FieldName = fromRow["fieldname"].ToString();
                        this.Label = fromRow["label"].ToString();
                        if (fromRow["extra"] != null)
                                this.Extra = fromRow["extra"].ToString();
                        string FldType = fromRow["fieldtype"].ToString();
                        switch(FldType) {
                                case "relation":
                                        this.FieldType = DbTypes.Integer;
                                        string[] RelationFields = this.Extra.Split(new char[] { ',' });
                                        string ReferenceTable = RelationFields[0], ReferenceColumn, DetailColumn;
                                        
                                        if(RelationFields.Length >= 2)
                                                ReferenceColumn = RelationFields[1];
                                        else
                                                ReferenceColumn = dataBase.Tables[ReferenceTable].PrimaryKey;

                                        if(RelationFields.Length >= 3)
                                                DetailColumn = RelationFields[2];
                                        else
                                                DetailColumn = "nombre";

                                        this.Relation = new Relation(this.FieldName, ReferenceTable, ReferenceColumn, DetailColumn);

                                        if (RelationFields.Length >= 4)
                                                LblType = RelationFields[3];
                                        else
                                                LblType = null;
                                        break;
                                default:
                                        this.FieldType = Lfx.Data.Types.FromSqlType(FldType);
                                        break;
                        }

                        if (fromRow["inputtype"] != null && fromRow["inputtype"].ToString() != string.Empty)
                                this.InputFieldType = (Lfx.Data.InputFieldTypes)(Enum.Parse(typeof(Lfx.Data.InputFieldTypes), fromRow["inputtype"].ToString()));
                                                
                        this.Nullable = System.Convert.ToBoolean(fromRow["fieldnullable"]);
                        this.Internal = System.Convert.ToBoolean(fromRow["internal"]);
                        this.Access = System.Convert.ToInt32(fromRow["access"]);
                        this.DefaultValue = fromRow["fielddefault"];
                        if (this.DefaultValue is DBNull)
                                this.DefaultValue = null;

                }


                public Tag(string tableName, string fieldName, string label)
                {
                        this.TableName = tableName;
                        this.FieldName = fieldName;
                        this.Label = label;
                }


                public void Save()
                {
                        qGen.TableCommand InsertOrUpdate;
                        if (this.Id == 0) {
                                InsertOrUpdate = new qGen.Insert("sys_tags");
                        } else {
                                InsertOrUpdate = new qGen.Update("sys_tags");
                                InsertOrUpdate.WhereClause = new qGen.Where("id_tag", this.Id);
                        }

                        InsertOrUpdate.Fields.AddWithValue("tablename", this.TableName);
                        InsertOrUpdate.Fields.AddWithValue("fieldname", this.FieldName);
                        InsertOrUpdate.Fields.AddWithValue("label", this.Label);
                        switch(this.FieldType) {
                                case DbTypes.VarChar:
                                        InsertOrUpdate.Fields.AddWithValue("fieldtype", "varchar");
                                        break;
                                case DbTypes.Integer:
                                        InsertOrUpdate.Fields.AddWithValue("fieldtype", "integer");
                                        break;
                                case DbTypes.Text:
                                        InsertOrUpdate.Fields.AddWithValue("fieldtype", "text");
                                        break;
                        }
                        InsertOrUpdate.Fields.AddWithValue("fieldnullable", this.Nullable ? 1 : 0);
                        InsertOrUpdate.Fields.AddWithValue("fielddefault", this.DefaultValue);
                        InsertOrUpdate.Fields.AddWithValue("internal", this.Internal ? 1 : 0);
                        InsertOrUpdate.Fields.AddWithValue("access", this.Access);

                        this.DataBase.Execute(InsertOrUpdate);
                }
        }
}
