using System;
using Lazaro.Orm;

namespace Lfx.Data
{
        public enum AccessModes
        {
                Undefined,
                Odbc,
                MySql,          // MySQL Connector/NET
                Npgsql,
                MSSql,
                SQLite,
                Oracle,
        }


        public enum KeyActions
        {
                Unknown,
                None,
                Delete,
                Cascade,
                Restrict
        }


        public static class Types
        {
                public static ColumnTypes ToDbType(InputFieldTypes columnType)
                {
                        switch(columnType)
                        {
                                case InputFieldTypes.Currency:
                                        return ColumnTypes.Numeric;
                                case InputFieldTypes.Date:
                                        return ColumnTypes.Date;
                                case InputFieldTypes.DateTime:
                                        return ColumnTypes.DateTime;
                                case InputFieldTypes.Numeric:
                                        return ColumnTypes.Numeric;
                                case InputFieldTypes.Integer:
                                case InputFieldTypes.Serial:
                                        return ColumnTypes.Integer;
                                case InputFieldTypes.Text:
                                        return ColumnTypes.VarChar;
                                case InputFieldTypes.Memo:
                                        return ColumnTypes.Text;
                                case InputFieldTypes.Binary:
                                case InputFieldTypes.Image:
                                        return ColumnTypes.Blob;
                                case InputFieldTypes.Bool:
                                        return ColumnTypes.SmallInt;
                                default:
                                        throw new NotImplementedException();
                        }
                }

		public static ColumnTypes FromSqlType(string sqlType)
		{
			switch (sqlType.ToUpperInvariant()) {
                                case "VARCHAR":
				case "CHAR":
				case "NVARCHAR":
				case "NCHAR":
				case "CHARACTER VARYING":
                                        return Lazaro.Orm.ColumnTypes.VarChar;
                                case "SERIAL":
                                        return Lazaro.Orm.ColumnTypes.Serial;
                                case "MEDIUMINT":
                                        return Lazaro.Orm.ColumnTypes.MediumInt;
                                case "SMALLINT":
                                        return Lazaro.Orm.ColumnTypes.SmallInt;
                                case "TINYINT":
                                        return Lazaro.Orm.ColumnTypes.TinyInt;
                                case "INTEGER":
				case "BIGINT":
				case "INT":
                                        return Lazaro.Orm.ColumnTypes.Integer;
                                case "BOOL":
				case "BOOLEAN":
                                        return Lazaro.Orm.ColumnTypes.TinyInt;
                                case "DECIMAL":         // FIXME: DECIMAL no es lo mismo que NUMERIC, pero MySQL 5.0 los trata igual y reporta los numeric como decimal
                                case "NUMERIC":
                                        return Lazaro.Orm.ColumnTypes.Numeric;
                                case "DOUBLE":
                                case "DOUBLE PRECISION":
                                case "FLOAT":
                                case "SINGLE":
                                case "REAL":
                                        return Lazaro.Orm.ColumnTypes.NonExactDecimal;
                                case "BLOB":
				case "LONGBLOB":
				case "BYTEA":
                                        return Lazaro.Orm.ColumnTypes.Blob;
                                case "DATE":
                                        return Lazaro.Orm.ColumnTypes.Date;
                                case "DATETIME":
				case "TIMESTAMP":
				case "TIMESTAMP WITHOUT TIME ZONE":
                                        return Lazaro.Orm.ColumnTypes.DateTime;
                                default:
                                        return Lazaro.Orm.ColumnTypes.Text;
                        }
		}
        }
}
