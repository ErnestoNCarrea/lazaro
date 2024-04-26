using System;
using Lazaro.Orm;
using System.Diagnostics;
using qGen;

namespace Lazaro.Orm.Data
{
        [DebuggerDisplay("Name = {ColumnName}, Value = {Value}")]
        public class ColumnValue : IColumnValue
	{
                public SqlIdentifier ColumnIdentifier { get; set; }
		public object Value { get; set; }
		public ColumnTypes DataType { get; set; } = ColumnTypes.VarChar;

                protected string m_Label;

                public ColumnValue(string columnName)
		{
			this.ColumnIdentifier = new SqlIdentifier(columnName);
		}

                public ColumnValue(SqlIdentifier columnName)
                {
                        this.ColumnIdentifier = columnName;
                }

                public ColumnValue(SqlIdentifier columnName, object value)
                        : this(columnName)
                {
                        this.Value = value;
                        if (value is double || value is decimal)
                                this.DataType = ColumnTypes.Numeric;
                        else if (value is int)
                                this.DataType = ColumnTypes.Integer;
                        else if (value is long)
                                this.DataType = ColumnTypes.BigInt;
                        else if (value is DateTime)
                                this.DataType = ColumnTypes.DateTime;
                        else if (value is bool)
                                this.DataType = ColumnTypes.SmallInt;
                        else if (value is byte[])
                                this.DataType = ColumnTypes.Blob;
                }

                public ColumnValue(string columnName, object value)
                        : this(new SqlIdentifier(columnName), value)
                {
                }

                public ColumnValue(SqlIdentifier columnName, ColumnTypes fieldType, object fieldValue)
                        : this(columnName, fieldValue)
                {
                        this.DataType = fieldType;
                }

                public ColumnValue(string columnName, ColumnTypes fieldType, object fieldValue)
                        : this(new SqlIdentifier(columnName), fieldType, fieldValue)
                {
                }

                public string Label
		{
			get
			{
				if(m_Label == null)
					return ColumnIdentifier.Name;
				else
					return Label;
			}
			set
			{
				m_Label = value;
			}
		}

                public virtual ColumnValue Clone()
                {
                        var Res = new ColumnValue(this.ColumnIdentifier, this.DataType, this.Value);
                        Res.Label = this.m_Label;
                        Res.Value = this.Value;
                        Res.DataType = this.DataType;
                        return Res;
                }

                public override string ToString()
                {
                        return this.Value.ToString();
                }


                public T GetValue<T>() {
                        return (T)(System.Convert.ChangeType(this.Value, typeof(T)));
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

                public long ValueLong
                {
                        get
                        {
                                return System.Convert.ToInt64(this.Value);
                        }
                }

                public DateTime ValueDateTime
                {
                        get
                        {
                                return System.Convert.ToDateTime(this.Value);
                        }
                }

                public bool ValueCanBeParameter
                {
                        get
                        {
                                return !(this.Value is qGen.SqlFunctions ||
                                        this.Value is qGen.SqlExpression);
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
                        return string.Compare(ColumnValue.GetNameOnly(f1), ColumnValue.GetNameOnly(f2)) == 0;
                }
	}
}
