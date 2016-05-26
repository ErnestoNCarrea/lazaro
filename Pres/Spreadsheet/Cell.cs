using System;
using System.Collections.Generic;
using System.Text;

namespace Lazaro.Pres.Spreadsheet
{
        public class Cell : System.IComparable<Cell>
        {
                public object Content = null;
                public object Formula = null;
                public Row ParentRow = null;
                public int ColumnNumber = 0;

                public Cell()
                {
                }

                public Cell(Row parent)
                {
                        this.ParentRow = parent;
                }

                public Cell(object content)
                        : this()
                {
                        this.Content = content;
                }

                public Cell(Formula formula)
                        : this()
                {
                        this.Formula = formula;
                }

                public Cell(Formula formula, object altContent)
                        : this()
                {
                        this.Formula = formula;
                        this.Content = altContent;
                }

                public override string ToString()
                {
                        if (this.Formula != null) {
                                return this.Formula.ToString();
                        } else {
                                return this.ParentRow.FormatCellValue(this.ColumnNumber, this.Content);
                        }
                }

                public int CompareTo(Cell other)
                {
                        if (this.Content == null || other.Content == null)
                                return 0;
                        else if (this.Content is double && other.Content is double)
                                return ((double)(this.Content)).CompareTo(other.Content);
                        else if (this.Content is decimal && other.Content is decimal)
                                return ((decimal)(this.Content)).CompareTo(other.Content);
                        else if (this.Content is int && other.Content is int)
                                return ((int)(this.Content)).CompareTo(other.Content);
                        else if (this.Content is string && other.Content is string)
                                return ((string)(this.Content)).CompareTo(other.Content);
                        else
                                return 0;
                }
        }
}
