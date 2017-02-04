using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazaro.Orm
{
        public enum ColumnTypes
        {
                Serial,
                Relation,
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
