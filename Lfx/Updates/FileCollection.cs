using System;
using System.Collections.Generic;

namespace Lfx.Updates
{
        public class FileCollection : List<File>
        {
                public File this[string fileName]
                {
                        get
                        {
                                foreach (File Fil in this) {
                                        if (string.Compare(Fil.Name, fileName, true) == 0)
                                                return Fil;
                                }
                                throw new IndexOutOfRangeException();
                        }
                }

                public bool ContainsKey(string fileName)
                {
                        foreach (File Fil in this) {
                                if (string.Compare(Fil.Name, fileName, true) == 0)
                                        return true;
                        }
                        return false;
                }
        }
}
