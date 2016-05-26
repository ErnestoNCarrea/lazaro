using System;
using System.Collections.Generic;
using System.Text;

namespace Lazaro.Pres.Spreadsheet
{
        public class ColumnHeaderCollection : List<ColumnHeader>
        {
                public Sheet ParentSheet;
                public int DetailColumn = -1, GroupingColumn = -1;

                public ColumnHeaderCollection(Sheet parent)
                {
                        this.ParentSheet = parent;
                }

                public ColumnHeader this[string name]
                {
                        get
                        {
                                foreach (ColumnHeader Ch in this) {
                                        if (Ch.Name == name)
                                                return Ch;
                                }
                                return null;
                        }
                }
        }
}
