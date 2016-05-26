using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;

namespace Lazaro.Impresion
{
        public class ImpresorListado : Impresor
        {
                public Lazaro.Pres.Spreadsheet.Sheet Sheet;

                private float[] ColumnWidths = null;
                private StringFormat[] ColumnFormats = null;
                private int LastRowPrinted = -1, PageNumber, TotalPages = 0;
                private RectangleF BodyRect, FullBodyRect;
                
                private float HeaderTotalWidth, RowHeight, HeaderHeight, TitleHeight, TotalsHeight, FooterHeight, CursorY;
                private Font HeaderFont, RowFont, TitleFont, TotalsFont, FooterFont;

                private string LastGroup = null;

                public ImpresorListado(Lazaro.Pres.Spreadsheet.Sheet sheet, IDbTransaction transaction)
                        : base(transaction)
                {
                        this.Sheet = sheet;

                        // Calculo el ancho de todas las columnas
                        HeaderTotalWidth = 0;
                        for (int i = 0; i < Sheet.ColumnHeaders.Count; i++) {
                                if (i != this.Sheet.ColumnHeaders.DetailColumn && this.Sheet.ColumnHeaders[i].Printable)
                                        HeaderTotalWidth += Sheet.ColumnHeaders[i].Width;
                        }

                        this.DefaultPageSettings.Landscape = HeaderTotalWidth > 1600;
                        this.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins((int)(10 * mm), (int)(10 * mm), (int)(10 * mm), (int)(10 * mm));
                }

                protected override void OnBeginPrint(PrintEventArgs e)
                {
                        this.DocumentName = Sheet.Name.Replace(":", "");
                        this.PageNumber = 0;

                        base.OnBeginPrint(e);
                }

                protected override void OnPrintPage(PrintPageEventArgs e)
                {
                        this.PageNumber++;

                        if (ColumnWidths == null)
                                this.Inicializar(e);

                        this.PrintHeaders(e);

                        double ThisPageBottom = BodyRect.Bottom;
                        if (this.PageNumber < this.TotalPages)
                                // No hay renglón de totales, así que puedo usar un poquito más de alto
                                ThisPageBottom += TotalsHeight;

                        for(int RowNumber = LastRowPrinted + 1; RowNumber < Sheet.Rows.Count; RowNumber++) {
                                float ThisRowHeight = RowHeight;

                                // Si hay cambio de grupo, este renglón es más alto (por los subtotales y el encabezado del nuevo grupo)
                                if (Sheet.Rows[RowNumber].GetFormattedGroup() != LastGroup)
                                        ThisRowHeight += TotalsHeight + HeaderHeight;

                                if (CursorY + ThisRowHeight > ThisPageBottom) {
                                        // Este renglón no entra en la página...
                                        e.HasMorePages = true;
                                        break;
                                } else {
                                        if (this.Sheet.ColumnHeaders.GroupingColumn >= 0 && Sheet.Rows[RowNumber].GetFormattedGroup() != LastGroup) {
                                                if (LastGroup != null)
                                                        this.PrintTotals(e, LastGroup);

                                                LastGroup = Sheet.Rows[RowNumber].GetFormattedGroup();
                                                this.PrintGroupRow(e, LastGroup);
                                        }
                                        this.PrintRow(e, Sheet.Rows[RowNumber]);
                                        LastRowPrinted = RowNumber;
                                }
                        }

                        if (e.HasMorePages == false && LastGroup != null && this.Sheet.ColumnHeaders.GroupingColumn >= 0)
                                this.PrintTotals(e, LastGroup);

                        if (e.HasMorePages == false)
                                this.PrintTotals(e, null);

                        this.PrintFooters(e);

                        base.OnPrintPage(e);
                }


                private void Inicializar(PrintPageEventArgs e)
                {
                        Graphics g = e.Graphics;

                        this.TitleFont = new Font(Lazaro.Pres.DisplayStyles.Template.Current.DefaultPrintFontName, 12, FontStyle.Bold);
                        this.HeaderFont = new Font(Lazaro.Pres.DisplayStyles.Template.Current.DefaultPrintFontName, 8, FontStyle.Bold);
                        this.RowFont = new Font(Lazaro.Pres.DisplayStyles.Template.Current.DefaultPrintFontName, 7);
                        this.TotalsFont = new Font(Lazaro.Pres.DisplayStyles.Template.Current.DefaultPrintFontName, 7, FontStyle.Bold);
                        this.FooterFont = new Font(Lazaro.Pres.DisplayStyles.Template.Current.DefaultPrintFontName, 7);

                        // Rectángulo que incluye toda el área imprimible
                        FullBodyRect = new RectangleF(e.MarginBounds.Left - (e.PageBounds.Width - g.VisibleClipBounds.Width) / 2,
                                e.MarginBounds.Top - (e.PageBounds.Height - g.VisibleClipBounds.Height) / 2,
                                e.MarginBounds.Width,
                                e.MarginBounds.Height);

                        TitleHeight = this.TitleFont.GetHeight(g) * 1.3f;
                        HeaderHeight = this.HeaderFont.GetHeight(g) * 1.3f;
                        RowHeight = this.RowFont.GetHeight(g) * 1.3f;
                        FooterHeight = this.FooterFont.GetHeight(g) * 1.3f;

                        // Existe un campo principal de detalle, duplico la altura del renglón
                        if (this.Sheet.ColumnHeaders.DetailColumn >= 0) {
                                RowHeight *= 2;
                        }

                        ColumnFormats = new StringFormat[Sheet.ColumnHeaders.Count];
                        ColumnWidths = new float[Sheet.ColumnHeaders.Count];

                        // Calculo las columnas de ancho fijo (como fechas y moneda)
                        float RectFixedWidth = 0, HeaderFixedWidth = 0;
                        for (int i = 0; i < Sheet.ColumnHeaders.Count; i++) {
                                if (Sheet.ColumnHeaders[i].Printable) {
                                        switch (Sheet.ColumnHeaders[i].DataType) {
                                                case Lfx.Data.InputFieldTypes.Date:
                                                        ColumnWidths[i] = g.MeasureString("00-00-0000 ", RowFont).Width;
                                                        HeaderFixedWidth += Sheet.ColumnHeaders[i].Width;
                                                        break;
                                                case Lfx.Data.InputFieldTypes.DateTime:
                                                        ColumnWidths[i] = g.MeasureString("00-00-0000 00:00:00 ", RowFont).Width;
                                                        HeaderFixedWidth += Sheet.ColumnHeaders[i].Width;
                                                        break;
                                                case Lfx.Data.InputFieldTypes.Bool:
                                                        ColumnWidths[i] = g.MeasureString("Si ", RowFont).Width;
                                                        HeaderFixedWidth += Sheet.ColumnHeaders[i].Width;
                                                        break;
                                                case Lfx.Data.InputFieldTypes.Currency:
                                                        ColumnWidths[i] = g.MeasureString("12345678.90 ", RowFont).Width;
                                                        HeaderFixedWidth += Sheet.ColumnHeaders[i].Width;
                                                        break;
                                                default:
                                                        ColumnWidths[i] = 0;
                                                        break;
                                        }
                                        RectFixedWidth += ColumnWidths[i];
                                }
                        }

                        // Ahora calculo los anchos de las columnas de ancho proporcional
                        for (int i = 0; i < Sheet.ColumnHeaders.Count; i++) {
                                if (ColumnWidths[i] == 0) {
                                        float ColWidth = (Sheet.ColumnHeaders[i].Width / (HeaderTotalWidth - HeaderFixedWidth)) * (FullBodyRect.Width - RectFixedWidth);
                                        ColumnWidths[i] = ColWidth;
                                }
                                StringFormat NewFmt = new StringFormat();
                                switch (Sheet.ColumnHeaders[i].TextAlignment) {
                                        case Lfx.Types.StringAlignment.Far:
                                                NewFmt.Alignment = StringAlignment.Far;
                                                break;
                                        case Lfx.Types.StringAlignment.Center:
                                                NewFmt.Alignment = StringAlignment.Center;
                                                break;
                                        case Lfx.Types.StringAlignment.Near:
                                                NewFmt.Alignment = StringAlignment.Near;
                                                break;
                                }
                                NewFmt.FormatFlags = StringFormatFlags.LineLimit;
                                NewFmt.Trimming = StringTrimming.EllipsisCharacter;
                                NewFmt.LineAlignment = StringAlignment.Center;
                                ColumnFormats[i] = NewFmt;

                                if (Sheet.ColumnHeaders[i].TotalFunction != null) {
                                        // Tiene una función de totales, calculo una altura para el renglón de totales
                                        if (TotalsHeight == 0)
                                                TotalsHeight = this.TotalsFont.GetHeight(g) * 1.3f;
                                }
                        }

                        // Rectángulo que incluye el área de listado, quitando título, encab y pié
                        BodyRect = new RectangleF(FullBodyRect.X, FullBodyRect.Y + TitleHeight + HeaderHeight, FullBodyRect.Width, FullBodyRect.Height - TitleHeight - HeaderHeight - FooterHeight - TotalsHeight);
                        
                        // Calculo la altura total que van a ocupar los renglones del reporte
                        // (Altura de los renglones
                        //      + altura de los encabezados de grupo
                        //      + altura de los subtotales de grupo
                        //      + altura de los totales
                        float TotalRowHeight = (this.Sheet.Rows.Count * RowHeight);
                        if (this.Sheet.ColumnHeaders.GroupingColumn >= 0) {
                                TotalRowHeight += (this.Sheet.Groups.Count * HeaderHeight);
                                TotalRowHeight += (this.Sheet.Groups.Count * TotalsHeight);
                        }
                        if (TotalsHeight >= 0)
                                TotalRowHeight += TotalsHeight;
                        TotalPages = (int)Math.Ceiling(TotalRowHeight / BodyRect.Height);
                        
                        if (TotalPages < 1)
                                TotalPages = 1;
                }

                private void PrintHeaders(PrintPageEventArgs e)
                {
                        Graphics g = e.Graphics;

                        StringFormat TitleFmt = new StringFormat();
                        TitleFmt.Alignment = StringAlignment.Center;
                        TitleFmt.LineAlignment = StringAlignment.Center;
                        TitleFmt.FormatFlags = StringFormatFlags.LineLimit;

                        // El título del archivo
                        RectangleF TitleRect = new RectangleF(FullBodyRect.Top, FullBodyRect.Left, FullBodyRect.Width, TitleHeight);
                        g.FillRectangle(Brushes.Khaki, TitleRect);
                        g.DrawString(this.DocumentName, TitleFont, Brushes.Black, TitleRect, TitleFmt);

                        StringFormat HeaderFmt = new StringFormat();
                        HeaderFmt.FormatFlags = StringFormatFlags.LineLimit;
                        HeaderFmt.Trimming = StringTrimming.EllipsisCharacter;
                        HeaderFmt.Alignment = StringAlignment.Center;
                        HeaderFmt.LineAlignment = StringAlignment.Center;

                        // Pongo el cursor debajo del título
                        CursorY = FullBodyRect.Top + TitleHeight;
                        float CursorX = BodyRect.Left;
                        g.FillRectangle(Brushes.Lavender, CursorX, CursorY, BodyRect.Width, HeaderHeight);
                        for (int i = 0; i < Sheet.ColumnHeaders.Count; i++) {
                                if (i != this.Sheet.ColumnHeaders.DetailColumn && this.Sheet.ColumnHeaders[i].Printable) {
                                        RectangleF ChRect = new RectangleF(CursorX, CursorY, ColumnWidths[i], HeaderHeight);
                                        g.DrawString(Sheet.ColumnHeaders[i].Text, HeaderFont, Brushes.Black, ChRect, HeaderFmt);

                                        CursorX += ColumnWidths[i];
                                }
                        }

                        // Pongo el cursor al inicio del área de listado
                        CursorY = BodyRect.Top;
                }


                private void PrintTotals(PrintPageEventArgs e, string group)
                {
                        Graphics g = e.Graphics;

                        // Pongo los totales
                        if (TotalsHeight > 0) {
                                StringFormat TotalsFmt = new StringFormat();
                                TotalsFmt.FormatFlags = StringFormatFlags.LineLimit;
                                TotalsFmt.Trimming = StringTrimming.EllipsisCharacter;
                                TotalsFmt.Alignment = StringAlignment.Far;
                                TotalsFmt.LineAlignment = StringAlignment.Center;

                                // Pongo el cursor debajo del título
                                float CursorX = BodyRect.Left;
                                if (group == null)
                                        g.FillRectangle(Brushes.Lavender, CursorX, CursorY, BodyRect.Width, TotalsHeight);
                                for (int i = 0; i < Sheet.ColumnHeaders.Count; i++) {
                                        if (i != this.Sheet.ColumnHeaders.DetailColumn && this.Sheet.ColumnHeaders[i].Printable) {
                                                if (Sheet.ColumnHeaders[i].TotalFunction != null) {
                                                        RectangleF ChRect = new RectangleF(CursorX, CursorY, ColumnWidths[i], TotalsHeight);
                                                        g.DrawString(Sheet.GetFormattedTotal(i, group), TotalsFont, Brushes.Black, ChRect, ColumnFormats[i]);
                                                }
                                                CursorX += ColumnWidths[i];
                                        }
                                }

                                CursorY += TotalsHeight;
                        }
                }
                
                private void PrintFooters(PrintPageEventArgs e)
                {
                        Graphics g = e.Graphics;

                        StringFormat FooterFmt = new StringFormat();
                        FooterFmt.Alignment = StringAlignment.Center;
                        FooterFmt.LineAlignment = StringAlignment.Center;
                        FooterFmt.FormatFlags = StringFormatFlags.LineLimit;

                        // La cantidad de páginas
                        string InfoReporte = "Reporte generado el " + System.DateTime.Now.ToString(Lfx.Types.Formatting.DateTime.ShortDatePattern);
                        if (this.PageNumber == this.TotalPages)
                                InfoReporte += ", total " + this.Sheet.Rows.Count.ToString() + " renglones.";

                        RectangleF FooterRect = new RectangleF(FullBodyRect.X, FullBodyRect.Bottom - FooterHeight, FullBodyRect.Width, FooterHeight);
                        FooterFmt.Alignment = StringAlignment.Near;
                        g.DrawString(InfoReporte, FooterFont, Brushes.Black, FooterRect, FooterFmt);

                        FooterFmt.Alignment = StringAlignment.Center;
                        g.DrawString("www.lazarogestion.com ", FooterFont, Brushes.Gray, FooterRect, FooterFmt);

                        FooterFmt.Alignment = StringAlignment.Far;
                        g.DrawString("Página " + this.PageNumber.ToString(), FooterFont, Brushes.Black, FooterRect, FooterFmt);

                }

                private void PrintGroupRow(PrintPageEventArgs e, string text)
                {
                        Graphics g = e.Graphics;

                        StringFormat HeaderFmt = new StringFormat();
                        HeaderFmt.FormatFlags = StringFormatFlags.LineLimit;
                        HeaderFmt.Trimming = StringTrimming.EllipsisCharacter;
                        HeaderFmt.Alignment = StringAlignment.Center;
                        HeaderFmt.LineAlignment = StringAlignment.Center;

                        float CursorX = BodyRect.Left;
                        RectangleF ChRect = new RectangleF(CursorX, CursorY, BodyRect.Width, HeaderHeight);
                        g.FillRectangle(Brushes.Beige, CursorX, CursorY, BodyRect.Width, HeaderHeight);
                        g.DrawString(text, HeaderFont, Brushes.Black, ChRect, HeaderFmt);
                        g.DrawLine(Pens.LightGray, ChRect.X, ChRect.Bottom, ChRect.Right, ChRect.Bottom);

                        CursorY += RowHeight;
                }

                private void PrintRow(PrintPageEventArgs e, Lazaro.Pres.Spreadsheet.Row row)
                {
                        Graphics g = e.Graphics;

                        float CursorX = BodyRect.Left;

                        float ThisRowHeight = RowHeight;

                        // Imprimo primero la columna de detalle principal
                        if (this.Sheet.ColumnHeaders.DetailColumn >= 0) {
                                ThisRowHeight = RowHeight / 2;
                                RectangleF ChRect = new RectangleF(CursorX, CursorY, BodyRect.Width, RowHeight / 2);
                                g.DrawString(row.Cells[this.Sheet.ColumnHeaders.DetailColumn].ToString(), new Font(RowFont, FontStyle.Bold), Brushes.Black, ChRect, ColumnFormats[this.Sheet.ColumnHeaders.DetailColumn]);
                                CursorY += ThisRowHeight;
                        }

                        for (int i = 0; i < row.Cells.Count; i++) {
                                if (i != this.Sheet.ColumnHeaders.DetailColumn && this.Sheet.ColumnHeaders[i].Printable) {
                                        RectangleF ChRect = new RectangleF(CursorX, CursorY, ColumnWidths[i], ThisRowHeight);
                                        g.DrawString(row.Cells[i].ToString(), RowFont, Brushes.Black, ChRect, ColumnFormats[i]);
                                        g.DrawLine(Pens.LightGray, ChRect.X, ChRect.Bottom, ChRect.Right, ChRect.Bottom);

                                        CursorX += ColumnWidths[i];
                                }
                        }

                        CursorY += ThisRowHeight;
                }
        }
}
