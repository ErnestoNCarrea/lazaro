using System;
using System.Collections.Generic;

namespace qGen
{
        [Serializable]
        public class JoinCollection : List<qGen.Join>
        {
                public Join this[string tableName]
                {
                        get
                        {
                                foreach (Join Jn in this) {
                                        if (Jn.Table.EqualsByName(tableName)) {
                                                return Jn;
                                        }
                                }

                                return null;
                        }
                }

                new public bool Contains(Join join)
                {
                        foreach(Join Jn in this) {
                                if (Jn.Table.Definition == join.Table.Definition && Jn.On == join.On) {
                                        return true;
                                }
                        }
                        return false;
                }
        }
}
