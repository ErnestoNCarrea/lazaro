using System;
using System.Collections.Generic;
using System.Text;

namespace Lazaro.Pres.Spreadsheet
{
        public class Workbook
        {
                public System.Collections.Generic.List<Sheet> Sheets = new List<Sheet>();

                public void SaveTo(string fileName, SaveFormats format)
                {
                        SaveTo(fileName, format, null);
                }

                public void Print()
                {
                        this.Print(PrintModes.Automatic);
                }

                public void Print(PrintModes printMode)
                {
                        PrintModes FinalPrintMode = printMode;
                        if (FinalPrintMode == PrintModes.Automatic) {
                                if (ExternalPrograms.MsOffice.IsExcelInstalled())
                                        FinalPrintMode = PrintModes.MsOffice;
                                else if (ExternalPrograms.OpenOffice.IsCalcInstalled())
                                        FinalPrintMode = PrintModes.OpenOffice;
                        }

                        switch (FinalPrintMode) {
                                case PrintModes.OpenOffice:
                                        string TempCalcFileName = Lfx.Environment.Folders.TemporaryFolder + System.IO.Path.GetFileName(System.IO.Path.GetRandomFileName()) + ".xml";
                                        this.SaveTo(TempCalcFileName, SaveFormats.ExcelXml);
                                        ExternalPrograms.OpenOffice.PrintWithCalc(TempCalcFileName);
                                        break;
                                case PrintModes.MsOffice:
                                        string TempExcelFileName = Lfx.Environment.Folders.TemporaryFolder + System.IO.Path.GetFileName(System.IO.Path.GetRandomFileName()) + ".xml";
                                        this.SaveTo(TempExcelFileName, SaveFormats.ExcelXml);
                                        ExternalPrograms.MsOffice.PrintWithExcel(TempExcelFileName);
                                        break;
                                default:
                                        throw new NotImplementedException();
                        }
                }

                public void SaveTo(string fileName, SaveFormats format, Sheet sheet)
                {
                        using (System.IO.StreamWriter wr = new System.IO.StreamWriter(new System.IO.FileStream(fileName, System.IO.FileMode.Create)))
                        {
                                switch (format)
                                {
                                        case SaveFormats.ExcelXml:
                                                wr.Write(this.ToExcelXml(sheet));
                                                break;
                                        case SaveFormats.Html:
                                                wr.Write(this.ToHtml(sheet));
                                                break;
                                }
                                wr.Close();
                        }
                }

                protected internal string ToHtml(Sheet sheet)
                {
                        System.Text.StringBuilder Result = new StringBuilder();
                        Result.AppendLine(@"<!DOCTYPE html>");
                        Result.AppendLine(@"<html>");
                        Result.AppendLine(@"<head>");
                        if (sheet == null) {
                                if (this.Sheets.Count > 0) {
                                        Result.AppendLine(@"<title>" + this.Sheets[0].Name + @"</title>");
                                }
                        } else {
                                Result.AppendLine(@"<title>" + sheet.Name + @"</title>");
                        }
                        Result.AppendLine(@"<meta charset=""utf-8"" />");
                        Result.AppendLine(@"<meta name=""generator"" content=""Lázaro (www.lazarogestion.com)"">");
                        Result.AppendLine(@"<meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />");
                        Result.AppendLine(@"<style>");
                        Result.AppendLine(@"@media print { body { margin: 0; padding: 0 } }");
                        Result.AppendLine(@"body, table, td { font-family: Open Sans, Segoe UI, Trebuchet MS, Helvetica, Sans Serif; font-size: 10pt; }");
                        Result.AppendLine(@".StyleTable, table { border-collapse: collapse; empty-cells: show; border: none; }");
                        Result.AppendLine(@".StyleTableCaption, caption { font-size: large; background-color: #C5D900; padding: 4px; }");
                        Result.AppendLine(@".StyleTableHead, thead { display: table-header-group; }");
                        Result.AppendLine(@".StyleColumnHeader, th { padding: 2px; background-color: #C5D9F1; font-weight: bold; }");
                        Result.AppendLine(@".StyleDataRow, tr { page-break-inside: avoid; background-color: white; border-bottom: 1px solid silver; }");
                        Result.AppendLine(@".StyleDataCell, td { padding: 2px; }");
                        Result.AppendLine(@"</style>");
                        Result.AppendLine(@"</head>");

                        Result.AppendLine("<body>");
                        if (sheet == null) {
                                //All sheets
                                foreach (Sheet sht in this.Sheets) {
                                        Result.AppendLine(sht.ToHtml());
                                }
                        } else {
                                //One sheet
                                Result.AppendLine(sheet.ToHtml());
                        }

                        Result.AppendLine("</body>");
                        Result.AppendLine("</html>");

                        return Result.ToString();
                }

                protected internal string ToExcelXml(Sheet sheet)
                {
                        System.Text.StringBuilder Result = new StringBuilder();

                        Result.AppendLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
                        Result.AppendLine(@"<?mso-application progid=""Excel.Sheet""?>");
                        Result.AppendLine(@"<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:c=""urn:schemas-microsoft-com:office:component:spreadsheet"" xmlns:html=""http://www.w3.org/TR/REC-html40"" xmlns:o=""urn:schemas-microsoft-com:office:office"" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:x2=""http://schemas.microsoft.com/office/excel/2003/xml"" xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">");
                        Result.AppendLine(@"  <Styles>
    <Style ss:ID=""Default"" ss:Name=""Normal"">
      <Alignment ss:Vertical=""Bottom"" />
    </Style>
    <Style ss:ID=""StyleData"">
      <Font x:FontName=""Segoe IU"" />
    </Style>
    <Style ss:ID=""StyleHeader"">
      <Font x:FontName=""Segoe IU"" ss:Bold=""1"" />
      <Interior ss:Color=""#C5D9F1"" ss:Pattern=""Solid"" />
    </Style>
   </Styles>");

                        if (sheet == null) {
                                //All sheets
                                foreach (Sheet sht in Sheets) {
                                        Result.AppendLine(sht.ToExcelXml());
                                }
                        } else {
                                //One sheet
                                Result.AppendLine(sheet.ToExcelXml());
                        }

                        Result.AppendLine("</Workbook>");

                        return Result.ToString();
                }

                public Sheet GetSheetByName(string name)
                {
                        foreach (Sheet sht in Sheets) {

                                if (sht.Name == name) {
                                        return sht;
                                }
                        }
                        return null;
                }
        }
}
