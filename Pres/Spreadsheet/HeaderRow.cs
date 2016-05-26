using System;
using System.Collections.Generic;
using System.Text;

namespace Lazaro.Pres.Spreadsheet
{
        public class HeaderRow : Row
        {
                public HeaderRow(string text)
                        : base()
                {
                        this.Cells.Add(new Cell(text));
                }
        }
}
