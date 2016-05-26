using System;
using System.Collections.Generic;
using System.Text;

namespace Lazaro.Pres.Spreadsheet
{
        public class Row
        {
                public Sheet ParentSheet;
                public CellCollection Cells;
                public System.Drawing.Color BackColor = System.Drawing.Color.Empty;
                public System.Drawing.Color ForeColor = System.Drawing.Color.Empty;

                public Row()
                {
                        this.Cells = new CellCollection(this);
                }

                public Row(Sheet sheet)
                {
                        this.ParentSheet = sheet;
                        this.Cells = new CellCollection(this); 
                }

                public string GetFormattedGroup()
                {
                        return this.FormatCellValue(this.ParentSheet.ColumnHeaders.GroupingColumn, this.Group);
                }

                public object Group
                {
                        get
                        {
                                if (this.ParentSheet.ColumnHeaders.GroupingColumn < 0)
                                        return null;
                                else
                                        return this.Cells[this.ParentSheet.ColumnHeaders.GroupingColumn].Content;
                        }
                }

                public string FormatCellValue(int columnNumber, object cellValue)
                {
                        if (cellValue != null) {
                                string ColFormat = this.ParentSheet.ColumnHeaders[columnNumber].Format;
                                switch (cellValue.GetType().ToString()) {
                                        case "System.Single":
                                        case "System.Double":
                                                if (ColFormat != null)
                                                        return System.Convert.ToDouble(cellValue).ToString(ColFormat);
                                                else
                                                        return Lfx.Types.Formatting.FormatNumber(System.Convert.ToDecimal(cellValue), 2);
                                        case "System.Decimal":
                                                if (ColFormat != null)
                                                        return System.Convert.ToDecimal(cellValue).ToString(ColFormat);
                                                else
                                                        return Lfx.Types.Formatting.FormatNumber(System.Convert.ToDecimal(cellValue), 4);
                                        case "System.Integer":
                                        case "System.Int16":
                                        case "System.Int32":
                                                if (ColFormat != null)
                                                        return System.Convert.ToInt32(cellValue).ToString(ColFormat);
                                                else
                                                        return cellValue.ToString();
                                        case "System.DateTime":
                                                if (ColFormat != null) {
                                                        return System.Convert.ToDateTime(cellValue).ToString(ColFormat);
                                                } else {
                                                        switch (this.ParentSheet.ColumnHeaders[columnNumber].DataType) {
                                                                case Lfx.Data.InputFieldTypes.Date:
                                                                        return System.Convert.ToDateTime(cellValue).ToString(Lfx.Types.Formatting.DateTime.ShortDatePattern);
                                                                default:
                                                                        return cellValue.ToString();
                                                        }
                                                }
                                        case "System.String":
                                                return cellValue.ToString();
                                        default:
                                                return cellValue.ToString();
                                }
                        } else {
                                return "";
                        }
                }

                public override string ToString()
                {
                        string Res = null;
                        foreach (Cell Cl in Cells) {
                                if (Res == null)
                                        Res = "Row cells: " + Cl.ToString();
                                else
                                        Res += "; " + Cl.ToString();
                        }
                        return Res;
                }
        }
}
