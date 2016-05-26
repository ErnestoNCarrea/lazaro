using System;
using System.Collections.Generic;
using System.Text;

namespace Lazaro.Pres.Spreadsheet
{
        public class RowCollection : System.Collections.Generic.List<Row>
        {
                public Sheet ParentSheet = null;

                public RowCollection(Sheet parent)
                {
                        this.ParentSheet = parent;
                }

                new public void Add(Row row)
                {
                        row.ParentSheet = this.ParentSheet;
                        base.Add(row);
                }

                public Row Add()
                {
                        Row Res = new Row(this.ParentSheet);
                        base.Add(Res);
                        return Res;
                }
        }
}
