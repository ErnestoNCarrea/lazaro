using System;
using System.Collections.Generic;
using System.Text;

namespace Lazaro.Pres.Spreadsheet
{
        public class ColumnHeader
        {
                public string Text = null, Name = null, Format = null;
                public int Width = 0;
                public bool Printable = true;
                public Lfx.Types.StringAlignment TextAlignment = Lfx.Types.StringAlignment.Near;
                public Lfx.Data.InputFieldTypes DataType = Lfx.Data.InputFieldTypes.Text;
                public object TotalFunction = null;

                public ColumnHeader(string text)
                {
                        this.Text = text;
                }


                public ColumnHeader(string text, int width)
                        : this(text)
                {
                        this.Width = width;
                }

                public ColumnHeader(string text, int width, Lfx.Types.StringAlignment textAlignment)
                        : this(text, width)
                {
                        this.TextAlignment = textAlignment;
                }

                public override string ToString()
                {
                        return this.Name;
                }
        }
}
