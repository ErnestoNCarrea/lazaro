using System;
using System.Collections.Generic;

namespace Lfx.Data
{
	public class TagCollection : List<Tag>
        {
                public Tag this[string columnName]
                {
                        get
                        {
                                foreach (Tag Tg in this) {
                                        if (Tg.FieldName == columnName)
                                                return Tg;
                                }
                                throw new IndexOutOfRangeException();
                        }
                }
        }
}
