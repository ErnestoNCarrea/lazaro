using System;
using System.Collections.Generic;

namespace Lazaro.Pres.Filters
{
        public class FilterCollection : List<IFilter>
        {
                public bool ContainsKey(string columnName)
                {
                        foreach (IFilter fil in this) {
                                if (fil.ColumnName == columnName)
                                        return true;
                        }
                        return false;
                }


                public IFilter this[string columnName]
                {
                        get
                        {
                                foreach (IFilter fil in this) {
                                        if (fil.ColumnName == columnName)
                                                return fil;
                                }
                                throw new IndexOutOfRangeException();
                        }
                }
        }
}
