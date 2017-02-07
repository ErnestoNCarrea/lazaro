using System;
using System.Collections.Generic;

namespace Lazaro.Orm.Mapping
{
        public class ColumnMetadataCollection : List<ColumnMetadata>
        {
                public ColumnMetadataCollection GetIdColumns()
                {
                        var Res = new ColumnMetadataCollection();

                        foreach(var Col in this) {
                                if(Col.Id) {
                                        Res.Add(Col);
                                }
                        }

                        return Res;
                }
        }
}
