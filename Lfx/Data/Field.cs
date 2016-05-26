using System;

namespace Lfx.Data
{
        [Serializable]
	public class Field
	{
		public string ColumnName, m_Label;
		public object Value = null;
		public Lfx.Data.DbTypes DataType = Lfx.Data.DbTypes.VarChar;

		public Field(string columnName)
		{
			this.ColumnName = columnName;
		}

                public Field(string columnName, object value)
                        : this(columnName)
                {
                        this.Value = value;
                        if (value is double || value is decimal)
                                this.DataType = DbTypes.Numeric;
                        else if (value is int || value is long)
                                this.DataType = DbTypes.Integer;
                        else if (value is DateTime)
                                this.DataType = DbTypes.DateTime;
                        else if (value is bool)
                                this.DataType = DbTypes.SmallInt;
                        else if (value is byte[])
                                this.DataType = DbTypes.Blob;
                }

                public Field(string columnName, DbTypes fieldType, object fieldValue)
                        : this(columnName, fieldValue)
                {
                        this.DataType = fieldType;
                }

		public string Label
		{
			get
			{
				if(m_Label == null)
					return ColumnName;
				else
					return Label;
			}
			set
			{
				m_Label = value;
			}
		}

                public virtual Field Clone()
                {
                        Field Res = new Field(this.ColumnName);
                        Res.m_Label = this.m_Label;
                        Res.Value = this.Value;
                        Res.DataType = this.DataType;
                        return Res;
                }

                public override string ToString()
                {
                        return this.Value.ToString();
                }

                public decimal ValueDecimal
                {
                        get
                        {
                                return System.Convert.ToDecimal(this.Value);
                        }
                }

                public string ValueString
                {
                        get
                        {
                                return System.Convert.ToString(this.Value);
                        }
                }

                public int ValueInt
                {
                        get
                        {
                                return System.Convert.ToInt32(this.Value);
                        }
                }

                public DateTime ValueDateTime
                {
                        get
                        {
                                return System.Convert.ToDateTime(this.Value);
                        }
                }


                /// <summary>
                /// Devuelve de una expresión SQL el nombre del alias o el campo.
                /// Para "tabla.campo" devulve "campo", para "tabla.campo AS alias" devuelve "alias",
                /// para "funcion() AS alias" devuelve "alias".
                /// </summary>
                public static string GetNameOnly(string fieldName)
                {
                        int r = fieldName.IndexOf(" AS ");
                        if (r >= 0) {
                                // Si tiene una cláusula AS, ese es el nombre de la columna
                                return fieldName.Substring(r + 4, fieldName.Length - r - 4).Trim();
                        }

                        r = fieldName.IndexOf("(") + 1;
                        if (r > 0) {
                                // Si hay un parntesis asumo que es una función sin cláusula AS y por lo tanto lo devuelvo como viene
                                return fieldName;
                        }

                        r = fieldName.IndexOf(".") + 1;
                        if (r > 0) {
                                return fieldName.Substring(r, fieldName.Length - r).Trim();
                        } else {
                                return fieldName.Trim();
                        }
                }


                public static bool HaveSameName(string f1, string f2)
                {
                        return string.Compare(Field.GetNameOnly(f1), Field.GetNameOnly(f2)) == 0;
                }
	}
}
