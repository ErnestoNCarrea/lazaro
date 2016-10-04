using System;
using System.Collections.Generic;
using OfficeOpenXml;
using System.Drawing;

namespace Lazaro.Pres.Spreadsheet
{
        public class Sheet
        {
                public string Name = "untitled";
                public ColumnHeaderCollection ColumnHeaders;
                public RowCollection Rows;
                public Workbook Workbook;
                public System.Drawing.Color BackColor = System.Drawing.Color.Empty;
                public System.Drawing.Color ForeColor = System.Drawing.Color.Empty;

                public Sheet()
                {
                        ColumnHeaders = new ColumnHeaderCollection(this);
                }

                public Sheet(string name)
                        : this()
                {
                        this.Rows = new RowCollection(this);
                        this.Name = name;
                }


                public List<string> Groups
                {
                        get
                        {
                                List<string> Res = new List<string>();

                                foreach (Row Rw in this.Rows) {
                                        if (Rw.Group != null && Res.Contains(Rw.Group.ToString()) == false)
                                                Res.Add(Rw.Group.ToString());
                                }

                                return Res;
                        }
                }

                public int Width
                {
                        get
                        {
                                int Result = this.ColumnHeaders.Count;
                                foreach (Row rw in this.Rows) {
                                        if (rw.Cells.Count > Result)
                                                Result = rw.Cells.Count;
                                }
                                return Result;
                        }
                }


                public string GetFormattedTotal(int column, string group)
                {
                        object Res = this.GetTotal(column, group);
                        if (Res == null) {
                                return "";
                        } else if (Res is double) {
                                return Lfx.Types.Formatting.FormatNumber((decimal)Res, 2);
                        } else if (Res is decimal) {
                                return Lfx.Types.Formatting.FormatNumber((decimal)Res, 2);
                        } else {
                                return Res.ToString();
                        }
                }


                public object GetTotal(int column, string group)
                {
                        object ColType = this.ColumnHeaders[column].TotalFunction;
                        if (ColType == null) {
                                return null;
                        } else if (ColType is QuickFunctions) {
                                QuickFunctions TotType = (QuickFunctions)ColType;
                                switch (TotType) {
                                        // Funciones varias
                                        case QuickFunctions.TotalName:
                                                if (group == null)
                                                        return "TOTAL";
                                                else
                                                        return "Subtotal " + group;

                                        // Funciones que cuentan
                                        case QuickFunctions.Count:
                                                if (group == null) {
                                                        return this.Rows.Count;
                                                } else {
                                                        decimal ResCount = 0;
                                                        foreach (Row Rw in this.Rows) {
                                                                if (group == Rw.GetFormattedGroup())
                                                                        ResCount++;
                                                        }
                                                        return ResCount;
                                                }

                                        // Funciones que suman
                                        default:
                                                decimal ResSum = 0;
                                                foreach (Row Rw in this.Rows) {
                                                        if (group == null || group == Rw.GetFormattedGroup()) {
                                                                decimal CellValue = System.Convert.ToDecimal(Rw.Cells[column].Content);
                                                                switch (TotType) {
                                                                        case QuickFunctions.Sum:
                                                                                ResSum += CellValue;
                                                                                break;
                                                                        case QuickFunctions.SumNegatives:
                                                                                if (CellValue < 0)
                                                                                        ResSum += CellValue;
                                                                                break;
                                                                        case QuickFunctions.SumPositives:
                                                                                if (CellValue > 0)
                                                                                        ResSum += CellValue;
                                                                                break;
                                                                }
                                                        }
                                                }
                                                return ResSum;
                                }
                        } else {
                                return ColType.ToString();
                        }
                }
                

                protected internal void ToHtml(System.IO.StreamWriter wr)
                {
                        wr.WriteLine(@"<table width=""100%"" class=""StyleTable"">");
                        wr.WriteLine(@"<caption class=""StyleTableCaption"">" +  Lfx.Types.Strings.EscapeHtml(this.Name) + "</caption>");

                        //Column headers
                        wr.WriteLine(@"<thead class=""StyleTableHead"">");
                        wr.WriteLine("<tr>");
                        foreach (ColumnHeader ch in this.ColumnHeaders) {
                                wr.WriteLine(@"<th class=""StyleColumnHeader"">" + Lfx.Types.Strings.EscapeHtml(ch.Text) + "</th>");
                        }
                        wr.WriteLine("</tr>");
                        wr.WriteLine("</thead>");

                        //Data
                        wr.WriteLine("<tbody>");
                        foreach (Row rw in this.Rows) {
                                wr.WriteLine(@"<tr class=""StyleDataRow"">");
                                foreach (Cell cl in rw.Cells) {
                                        string CellString = @"<td class=""StyleDataCell"">";
                                        CellString += Lfx.Types.Strings.EscapeHtml(cl.ToString());
                                        CellString += "</td>";
                                        wr.WriteLine(CellString);
                                }
                                wr.WriteLine("</tr>");
                        }
                        wr.WriteLine("</tbody>");
                        wr.WriteLine("</table>");
                }


                protected internal void ToExcel(ExcelWorksheet sheet)
                {
                        sheet.Cells.Style.Font.Size = 10.5F;
                        sheet.Cells.Style.Font.Name = "Calibri";

                        //Column headers
                        int Row = 1, Col = 1;
                        foreach (ColumnHeader ch in this.ColumnHeaders) {
                                sheet.Cells[Row, Col].Value = ch.Text;
                                sheet.Cells[Row, Col].Style.Font.Bold = true;
                                Col++;
                        }

                        //Data
                        foreach (Row rw in this.Rows) {
                                Col = 1;
                                Row++;
                                foreach (Cell cl in rw.Cells) {
                                        if (cl.Formula != null) {
                                                sheet.Cells[Row, Col].Formula = cl.Formula.ToString();
                                        }

                                        if (cl.Content != null) {
                                                switch (cl.Content.GetType().ToString()) {
                                                        case "System.Single":
                                                        case "System.Double":
                                                                sheet.Cells[Row, Col].Value = cl.Content;
                                                                sheet.Cells[Row, Col].Style.Numberformat.Format = "0.00";
                                                                break;
                                                        case "System.Decimal":
                                                                sheet.Cells[Row, Col].Value = cl.Content;
                                                                break;
                                                        case "System.Integer":
                                                        case "System.Int16":
                                                        case "System.Int32":
                                                        case "System.Int64":
                                                                sheet.Cells[Row, Col].Value = cl.Content;
                                                                break;
                                                        case "System.DateTime":
                                                                DateTime clContent = (DateTime)cl.Content;
                                                                if (clContent.Hour == 0 && clContent.Minute == 0 && clContent.Second == 0) {
                                                                        sheet.Cells[Row, Col].Style.Numberformat.Format = "dd-mm-yyyy";
                                                                        sheet.Cells[Row, Col].Formula = "=DATE(" + clContent.ToString("yyyy,MM,dd") + ")";
                                                                } else {
                                                                        sheet.Cells[Row, Col].Style.Numberformat.Format = "dd-mm-yyyy";
                                                                        sheet.Cells[Row, Col].Value = clContent;
                                                                }
                                                                break;
                                                        case "System.String":
                                                                sheet.Cells[Row, Col].Value = cl.Content.ToString();
                                                                break;
                                                }
                                        }
                                        Col++;
                                }
                        }

                        using (var range = sheet.Cells[1, 1, 1, this.ColumnHeaders.Count]) {
                                range.Style.Font.Bold = false;
                                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                range.Style.Fill.BackgroundColor.SetColor(Color.LightSteelBlue);
                                range.Style.Font.Color.SetColor(Color.Black);
                                range.Style.ShrinkToFit = false;
                        }

                        Col = 1;
                        foreach (ColumnHeader ch in this.ColumnHeaders) {
                                switch(ch.DataType) {
                                        case Lfx.Data.InputFieldTypes.Currency:
                                                using (var range = sheet.Cells[2, Col, Row, Col]) {
                                                        range.Style.Numberformat.Format = "\"$\"#,##0.00;[Red]\"$\"#,##0.00";
                                                }
                                                break;
                                }
                                Col++;
                        }

                        using (var range = sheet.Cells[1, 1, Row, this.ColumnHeaders.Count]) {
                                range.AutoFitColumns();
                        }
                }


                protected internal void ToExcelXml(System.IO.StreamWriter wr)
                {
                        if (this.Name != null && this.Name.Length > 0)
                                wr.WriteLine(@"<Worksheet ss:Name=""" + Lfx.Types.Strings.EscapeXml(this.Name.Substring(0, this.Name.Length > 31 ? 31 : this.Name.Length).Replace(":", "")) + @""">");
                        else
                                wr.WriteLine(@"<Worksheet ss:Name=""sin título"">");
                        wr.WriteLine(@"<ss:Table>");

                        //Column headers
                        int i = 0;
                        foreach (ColumnHeader ch in this.ColumnHeaders) {
                                string ColDef = @"<ss:Column ss:Index=""" + (++i).ToString() + @"""";
                                if (ch.Width > 0)
                                        ColDef += @" ss:Width=""" + ch.Width.ToString() + @"""";
                                ColDef += @" ss:AutoFitWidth=""1"" />";
                                wr.WriteLine(ColDef);
                        }

                        wr.WriteLine(@"<ss:Row>");
                        foreach (ColumnHeader ch in this.ColumnHeaders) {
                                wr.WriteLine(@"<ss:Cell ss:StyleID=""StyleHeader""><Data ss:Type=""String"">" + Lfx.Types.Strings.EscapeXml(ch.Text) + @"</Data></ss:Cell>");
                        }
                        wr.WriteLine(@"</ss:Row>");

                        //Data
                        foreach (Row rw in this.Rows) {
                                wr.WriteLine(@"<ss:Row>");
                                foreach (Cell cl in rw.Cells) {
                                        string CellString = @"<ss:Cell ss:StyleID=""StyleData""";
                                        if (cl.Formula != null)
                                                CellString += @" ss:Formula=""" + Lfx.Types.Strings.EscapeXml(cl.Formula.ToString()) + @"""";

                                        CellString += ">";
                                        if (cl.Content != null) {
                                                switch (cl.Content.GetType().ToString()) {
                                                        case "System.Single":
                                                        case "System.Double":
                                                                CellString += @"<Data ss:Type=""Number"">" + Lfx.Types.Formatting.FormatNumber(System.Convert.ToDecimal(cl.Content), 8) + @"</Data>";
                                                                break;
                                                        case "System.Decimal":
                                                                CellString += @"<Data ss:Type=""Number"">" + Lfx.Types.Formatting.FormatNumber(System.Convert.ToDecimal(cl.Content), 8) + @"</Data>";
                                                                break;
                                                        case "System.Integer":
                                                        case "System.Int16":
                                                        case "System.Int32":
                                                        case "System.Int64":
                                                                CellString += @"<Data ss:Type=""Number"">" + cl.Content.ToString() + @"</Data>";
                                                                break;
                                                        case "System.DateTime":
                                                                CellString += @"<Data ss:Type=""String"">";
                                                                DateTime clContent = (DateTime)cl.Content;
                                                                if (clContent.Hour == 0 && clContent.Minute == 0 && clContent.Second == 0)
                                                                        CellString += clContent.ToString(Lfx.Types.Formatting.DateTime.ShortDatePattern);
                                                                else
                                                                        CellString += clContent.ToString(Lfx.Types.Formatting.DateTime.FullDateTimePattern);
                                                                CellString += @"</Data>";
                                                                break;
                                                        case "System.String":
                                                                CellString += @"<Data ss:Type=""String"">" + Lfx.Types.Strings.EscapeXml(cl.Content.ToString()) + @"</Data>";
                                                                break;
                                                }
                                        }
                                        CellString += @"</ss:Cell>";
                                        wr.WriteLine(CellString);
                                }
                                wr.WriteLine(@"</ss:Row>");
                        }
                        wr.WriteLine(@"</ss:Table>");
                        wr.WriteLine(@"</Worksheet>");
                }

                public void SortByGroupAndColumn(int column, bool ascending)
                {
                        if (ascending) {
                                this.Rows.Sort(delegate(Row r1, Row r2)
                                {
                                        if (r1.Group == r2.Group) {
                                                if (column < 0)
                                                        return 0;
                                                // Mismo grupo, comparo las celdas
                                                return Lfx.Types.Object.CompareByValue(r2.Cells[column].Content, r1.Cells[column].Content);
                                        } else {
                                                // Diferente grupo, comparo los grupos
                                                return Lfx.Types.Object.CompareByValue(r1.Group, r2.Group);
                                        }
                                });
                        } else {
                                this.Rows.Sort(delegate(Row r1, Row r2)
                                {
                                        if (r1.Group == r2.Group) {
                                                if (column < 0)
                                                        return 0;
                                                // Mismo grupo, comparo las celdas
                                                return -Lfx.Types.Object.CompareByValue(r2.Cells[column].Content, r1.Cells[column].Content);
                                        } else {
                                                // Diferente grupo, comparo los grupos
                                                return -Lfx.Types.Object.CompareByValue(r1.Group, r2.Group);
                                        }
                                });
                        }
                }

                public void Sort(int column, bool ascending)
                {
                        if (ascending) {
                                this.Rows.Sort(delegate(Row r1, Row r2)
                                {
                                        return r1.Cells[column].CompareTo(r2.Cells[column]);
                                });
                        } else {
                                this.Rows.Sort(delegate(Row r1, Row r2)
                                {
                                        return r2.Cells[column].CompareTo(r1.Cells[column]);
                                });
                        }
                }

                public override string ToString()
                {
                        return this.Name;
                }
        }
}
