using System;
using System.Collections.Generic;
using System.Text;

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
                

                protected internal string ToHtml()
                {
                        System.Text.StringBuilder Result = new StringBuilder();

                        Result.AppendLine(@"<table width=""100%"" class=""StyleTable"">");
                        Result.AppendLine(@"<caption class=""StyleTableCaption"">" +  Lfx.Types.Strings.EscapeHtml(this.Name) + "</caption>");

                        //Column headers
                        Result.AppendLine(@"<thead class=""StyleTableHead"">");
                        Result.AppendLine("<tr>");
                        foreach (ColumnHeader ch in this.ColumnHeaders) {
                                Result.AppendLine(@"<th class=""StyleColumnHeader"">" + Lfx.Types.Strings.EscapeHtml(ch.Text) + "</th>");
                        }
                        Result.AppendLine("</tr>");
                        Result.AppendLine("</thead>");

                        //Data
                        Result.AppendLine("<tbody>");
                        foreach (Row rw in this.Rows) {
                                Result.AppendLine(@"<tr class=""StyleDataRow"">");
                                foreach (Cell cl in rw.Cells) {
                                        string CellString = @"<td class=""StyleDataCell"">";
                                        CellString += Lfx.Types.Strings.EscapeHtml(cl.ToString());
                                        CellString += "</td>";
                                        Result.AppendLine(CellString);
                                }
                                Result.AppendLine("</tr>");
                        }
                        Result.AppendLine("</tbody>");
                        Result.AppendLine("</table>");

                        return Result.ToString();
                }

                protected internal string ToExcelXml()
                {
                        System.Text.StringBuilder Result = new StringBuilder();

                        if (this.Name != null && this.Name.Length > 0)
                                Result.AppendLine(@"<Worksheet ss:Name=""" + Lfx.Types.Strings.EscapeXml(this.Name.Substring(0, this.Name.Length > 31 ? 31 : this.Name.Length).Replace(":", "")) + @""">");
                        else
                                Result.AppendLine(@"<Worksheet ss:Name=""sin título"">");
                        Result.AppendLine(@"<ss:Table>");

                        //Column headers
                        int i = 0;
                        foreach (ColumnHeader ch in this.ColumnHeaders) {
                                string ColDef = @"<ss:Column ss:Index=""" + (++i).ToString() + @"""";
                                if (ch.Width > 0)
                                        ColDef += @" ss:Width=""" + ch.Width.ToString() + @"""";
                                ColDef += @" ss:AutoFitWidth=""1"" />";
                                Result.AppendLine(ColDef);
                        }

                        Result.AppendLine(@"<ss:Row>");
                        foreach (ColumnHeader ch in this.ColumnHeaders) {
                                Result.AppendLine(@"<ss:Cell ss:StyleID=""StyleHeader""><Data ss:Type=""String"">" + Lfx.Types.Strings.EscapeXml(ch.Text) + @"</Data></ss:Cell>");
                        }
                        Result.AppendLine(@"</ss:Row>");

                        //Data
                        foreach (Row rw in this.Rows) {
                                Result.AppendLine(@"<ss:Row>");
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
                                        Result.AppendLine(CellString);
                                }
                                Result.AppendLine(@"</ss:Row>");
                        }
                        Result.AppendLine(@"</ss:Table>");
                        Result.AppendLine(@"</Worksheet>");

                        return Result.ToString();
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
