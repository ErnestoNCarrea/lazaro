using System;
using System.Collections.Generic;
using System.Text;

namespace Lazaro.Pres.Spreadsheet
{
        public class CellCollection : System.Collections.Generic.List<Cell>
        {
                public Row ParentRow = null;

                public CellCollection(Row parent)
                {
                        this.ParentRow = parent;
                }

                public void AddWithValue(string cellContent)
                {
                        Cell Res = new Cell(this.ParentRow);
                        Res.ColumnNumber = ParentRow.Cells.Count;
                        Res.Content = cellContent;
                        this.Add(Res);
                }


                public void AddWithValue(decimal cellContent)
                {
                        Cell Res = new Cell(this.ParentRow);
                        Res.ColumnNumber = ParentRow.Cells.Count;
                        Res.Content = cellContent;
                        this.Add(Res);
                }

                public void AddWithValue(DateTime cellContent)
                {
                        Cell Res = new Cell(this.ParentRow);
                        Res.ColumnNumber = ParentRow.Cells.Count;
                        Res.Content = cellContent;
                        this.Add(Res);
                }


                new public void Add(Cell cell)
                {
                        cell.ParentRow = this.ParentRow;
                        cell.ColumnNumber = ParentRow.Cells.Count;
                        base.Add(cell);
                }

                public Cell Add()
                {
                        Cell Res = new Cell(this.ParentRow);
                        Res.ColumnNumber = ParentRow.Cells.Count;
                        base.Add(Res);
                        return Res;
                }
        }
}
