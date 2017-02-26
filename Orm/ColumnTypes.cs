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
                TinyInt,
                Numeric,
                Currency,
                VarChar,
                Text,
                Blob,
                Date,
                DateTime,
                NonExactDecimal
        }
}
