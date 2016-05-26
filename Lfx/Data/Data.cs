using System;

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


        public enum DbTypes
        {
                Serial,         // Un entero autoincremental, clave primaria
                Relation,       // Un entero del mismo tamaño que Serial, pero no es autoincremental ni clave primaria
                Integer,        // 4 bytes / 32 bits
                MediumInt,      // 3 bytes
                SmallInt,       // 2 bytes / 16 bits
                TinyInt,        // 1 byte
                Numeric,
                Currency,
                VarChar,
                Text,
                Blob,
                DateTime,
                NonExactDecimal
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
                public static DbTypes ToDbType(InputFieldTypes columnType)
                {
                        switch(columnType)
                        {
                                case InputFieldTypes.Currency:
                                        return DbTypes.Numeric;
                                case InputFieldTypes.Date:
                                case InputFieldTypes.DateTime:
                                        return DbTypes.DateTime;
                                case InputFieldTypes.Numeric:
                                        return DbTypes.Numeric;
                                case InputFieldTypes.Integer:
                                case InputFieldTypes.Serial:
                                        return DbTypes.Integer;
                                case InputFieldTypes.Text:
                                        return DbTypes.VarChar;
                                case InputFieldTypes.Memo:
                                        return DbTypes.Text;
                                case InputFieldTypes.Binary:
                                case InputFieldTypes.Image:
                                        return DbTypes.Blob;
                                case InputFieldTypes.Bool:
                                        return DbTypes.SmallInt;
                                default:
                                        throw new NotImplementedException();
                        }
                }

		public static DbTypes FromSqlType(string sqlType)
		{
			switch (sqlType.ToUpperInvariant()) {
                                case "VARCHAR":
				case "CHAR":
				case "NVARCHAR":
				case "NCHAR":
				case "CHARACTER VARYING":
                                        return Lfx.Data.DbTypes.VarChar;
                                case "SERIAL":
                                        return Lfx.Data.DbTypes.Serial;
                                case "MEDIUMINT":
                                        return Lfx.Data.DbTypes.MediumInt;
                                case "SMALLINT":
                                        return Lfx.Data.DbTypes.SmallInt;
                                case "TINYINT":
                                        return Lfx.Data.DbTypes.TinyInt;
                                case "INTEGER":
				case "BIGINT":
				case "INT":
                                        return Lfx.Data.DbTypes.Integer;
                                case "BOOL":
				case "BOOLEAN":
                                        return Lfx.Data.DbTypes.TinyInt;
                                case "DECIMAL":         // FIXME: DECIMAL no es lo mismo que NUMERIC, pero MySQL 5.0 los trata igual y reporta los numeric como decimal
                                case "NUMERIC":
                                        return Lfx.Data.DbTypes.Numeric;
                                case "DOUBLE":
                                case "DOUBLE PRECISION":
                                case "FLOAT":
                                case "SINGLE":
                                case "REAL":
                                        return Lfx.Data.DbTypes.NonExactDecimal;
                                case "BLOB":
				case "LONGBLOB":
				case "BYTEA":
                                        return Lfx.Data.DbTypes.Blob;
                                case "DATETIME":
				case "TIMESTAMP":
				case "TIMESTAMP WITHOUT TIME ZONE":
                                        return Lfx.Data.DbTypes.DateTime;
                                default:
                                        return Lfx.Data.DbTypes.Text;
                        }
		}
        }
}
