using System;

namespace Lazaro.Orm
{
        public enum ColumnTypes
        {
                None = 0,
                Serial,
                Association,
                Integer,
                MediumInt,
                SmallInt,
                BigInt,
                TinyInt,
                Numeric,
                Currency,
                VarChar,
                Text,
                LongText,
                Blob,
                Date,
                DateTime,
                NonExactDecimal
        }
}
