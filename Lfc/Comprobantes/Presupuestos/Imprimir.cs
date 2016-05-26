#region License
// Copyright 2004-2010 South Bridge S.R.L.
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
// Este programa es software libre; puede distribuirlo y/o moficiarlo de
// acuerdo a los términos de la Licencia Pública General de GNU (GNU
// General Public License), como la publica la Fundación para el Software
// Libre (Free Software Foundation), tanto la versión 3 de la Licencia
// como (a su elección) cualquier versión posterior.
//
// Este programa se distribuye con la esperanza de que sea útil, pero SIN
// GARANTÍA ALGUNA; ni siquiera la garantía MERCANTIL implícita y sin
// garantizar su CONVENIENCIA PARA UN PROPÓSITO PARTICULAR. Véase la
// Licencia Pública General de GNU para más detalles. 
//
// Debería haber recibido una copia de la Licencia Pública General junto
// con este programa. Si no ha sido así, vea <http://www.gnu.org/licenses/>.
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace Lfc.Comprobantes.Presupuestos
{
	public class Imprimir : Lui.Printing.PrintDocument
	{
                private Lbl.Comprobantes.Presupuesto Comprobante;
		private Lfx.Data.Row m_Comprob = null;
		private DataTable m_Detalle = null;
		private string m_Cliente = "";
		private string m_Vendedor = "";
		private int m_Pagina;
		private int m_LastRow;

		public Imprimir(Lbl.Comprobantes.Presupuesto comprobante)
			: base()
		{
                        this.Comprobante = comprobante;
		}

		protected override void OnBeginPrint(System.Drawing.Printing.PrintEventArgs ev)
		{
			base.OnBeginPrint(ev);
			// Abro el Comprobante
                        m_Comprob = this.Workspace.DefaultDataBase.Row("comprob", "id_comprob", this.Comprobante.Id);
                        m_Detalle = this.Workspace.DefaultDataBase.Select("SELECT * FROM comprob_detalle WHERE id_comprob=" + this.Comprobante.Id.ToString());
                        m_Cliente = this.Workspace.DefaultDataBase.FieldString("SELECT nombre_visible FROM personas WHERE id_persona=" + m_Comprob["id_cliente"].ToString());
                        m_Vendedor = this.Workspace.DefaultDataBase.FieldString("SELECT nombre FROM personas WHERE id_persona=" + m_Comprob["id_vendedor"].ToString());
			m_Pagina = 0;
			m_LastRow = 0;
			this.DocumentName = "Presupuesto N " + m_Comprob["numero"].ToString();
			DefaultPageSettings.Margins.Bottom = 60;
			DefaultPageSettings.Margins.Top = 140;
			DefaultPageSettings.Margins.Left = 100;
			DefaultPageSettings.Margins.Right = 80;
		}

		protected override void OnPrintPage(System.Drawing.Printing.PrintPageEventArgs ev)
		{
			ev.PageSettings.Landscape = false;
                        ev.Graphics.PageUnit = GraphicsUnit.Display;
			
			m_Pagina++;

			int PrintAreaHeight = base.DefaultPageSettings.PaperSize.Height - base.DefaultPageSettings.Margins.Top - base.DefaultPageSettings.Margins.Bottom,
				PrintAreaWidth = base.DefaultPageSettings.PaperSize.Width - base.DefaultPageSettings.Margins.Left - base.DefaultPageSettings.Margins.Right,
				MarginLeft = base.DefaultPageSettings.Margins.Left,
				MarginTop = base.DefaultPageSettings.Margins.Top;

			// intMarginBottom = MyBase.DefaultPageSettings.Margins.Bottom
			if (base.DefaultPageSettings.Landscape)
			{
				int intTemp = 0;
				intTemp = PrintAreaHeight;
				PrintAreaHeight = PrintAreaWidth;
				PrintAreaWidth = intTemp;
			}

			//RectangleF PrintingArea = new RectangleF(MarginLeft, MarginTop, PrintAreaWidth, PrintAreaHeight);

			StringFormat FormatoCC = new StringFormat();
			FormatoCC.Alignment = StringAlignment.Center;
			FormatoCC.LineAlignment = StringAlignment.Center;
			StringFormat FormatoLC = new StringFormat();
			FormatoLC.Alignment = StringAlignment.Near;
			FormatoLC.LineAlignment = StringAlignment.Center;
			FormatoLC.FormatFlags = StringFormatFlags.NoWrap;
			FormatoLC.Trimming = StringTrimming.EllipsisCharacter;
			StringFormat FormatoRC = new StringFormat();
			FormatoRC.Alignment = StringAlignment.Far;
			FormatoRC.LineAlignment = StringAlignment.Center;
			StringFormat FormatoLT = new StringFormat();
			FormatoLT.Alignment = StringAlignment.Near;
			FormatoLT.LineAlignment = StringAlignment.Near;
			FormatoLT.FormatFlags = StringFormatFlags.LineLimit;
			FormatoLT.Trimming = StringTrimming.EllipsisWord;

			Font Fuente = null;
			Font FuentePequena = new Font("Arial", 7);
			RectangleF Rect = new System.Drawing.RectangleF();
			int iTop = MarginTop;

			// Título: PRESUPUESTO
			Fuente = new Font("Arial Black", 20);
			Rect = new RectangleF(MarginLeft, iTop, PrintAreaWidth, 32);
			ev.Graphics.DrawString("PRESUPUESTO", Fuente, Brushes.SteelBlue, Rect, FormatoCC);
			// ev.Graphics.DrawRectangle(Pens.Silver, Rect.X, Rect.Y, Rect.Width, Rect.Height)
			iTop += System.Convert.ToInt32(Rect.Height);

			// Fecha
			Fuente = new Font("Arial", 9);
			Rect = new RectangleF(MarginLeft, iTop, PrintAreaWidth, 18);
                        ev.Graphics.DrawString(System.DateTime.Now.ToString(Lfx.Types.Formatting.DateTime.LongDatePattern), Fuente, Brushes.Black, Rect,
					       FormatoCC);
			// ev.Graphics.DrawRectangle(Pens.Red, Rect.X, Rect.Y, Rect.Width, Rect.Height)
			iTop += System.Convert.ToInt32(Rect.Height + 4);

			// Cliente
			Rect = new RectangleF(MarginLeft, iTop, PrintAreaWidth - 100, 20);
			ev.Graphics.DrawString("Para: " + m_Cliente, Fuente, Brushes.Black, Rect, FormatoLC);
			// ev.Graphics.DrawRectangle(Pens.Blue, Rect.X, Rect.Y, Rect.Width, Rect.Height)

			// Nº PS
			Rect = new RectangleF(MarginLeft + PrintAreaWidth - 100, iTop, 100, 20);
			ev.Graphics.DrawString("PS" + System.Convert.ToInt32(m_Comprob["numero"]).ToString("000000"), Fuente,
					       Brushes.Black, Rect,
					       FormatoRC);
			// ev.Graphics.DrawRectangle(Pens.Green, Rect.X, Rect.Y, Rect.Width, Rect.Height)
			iTop += System.Convert.ToInt32(Rect.Height + 4);

			// Encab
			Fuente = new Font("Arial", 10, FontStyle.Bold);
			Rect = new RectangleF(MarginLeft, iTop, PrintAreaWidth, 20);
			ev.Graphics.FillRectangle(Brushes.Wheat, Rect.X, Rect.Y, Rect.Width, Rect.Height);
			Rect = new RectangleF(MarginLeft, iTop, 20, 20);
			ev.Graphics.DrawString("#", Fuente, Brushes.DimGray, Rect, FormatoRC);
			Rect = new RectangleF(MarginLeft + 26, iTop, 40, 20);
			ev.Graphics.DrawString("Cant", Fuente, Brushes.Black, Rect, FormatoRC);
			Rect = new RectangleF(MarginLeft + 70, iTop, PrintAreaWidth - MarginLeft - 160, 20);
			ev.Graphics.DrawString("Detalle", Fuente, Brushes.Black, Rect, FormatoLC);
			// ev.Graphics.DrawRectangle(Pens.Violet, Rect.X, Rect.Y, Rect.Width, Rect.Height)
			Rect = new RectangleF(MarginLeft + PrintAreaWidth - 160, iTop, 80, 20);
			ev.Graphics.DrawString("Precio", Fuente, Brushes.Black, Rect, FormatoRC);
			Rect = new RectangleF(MarginLeft + PrintAreaWidth - 80, iTop, 80, 20);
			ev.Graphics.DrawString("Importe", Fuente, Brushes.Black, Rect, FormatoRC);
			// ev.Graphics.DrawRectangle(Pens.Violet, Rect.X, Rect.Y, Rect.Width, Rect.Height)
			iTop += System.Convert.ToInt32(Rect.Height + 4);

			// Obs
			int AlturaPie = 0;

			if (System.Convert.ToString(m_Comprob["obs"]).Length > 0)
			{
				Rect = new RectangleF(MarginLeft, 0, PrintAreaWidth, 500);
				SizeF Tamano = ev.Graphics.MeasureString("Obs: " + System.Convert.ToString(m_Comprob["obs"]),
									 FuentePequena,
									 Rect.Size,
									 FormatoLT);
				Rect.Height = Tamano.Height;
				Rect.Y = MarginTop + PrintAreaHeight - 20 - Rect.Height;
				ev.Graphics.DrawString("Obs: " + System.Convert.ToString(m_Comprob["obs"]), FuentePequena,
						       Brushes.Black, Rect,
						       FormatoLT);
				AlturaPie += System.Convert.ToInt32(Rect.Height);
			}

			AlturaPie += 24;

			// Detalle
			Fuente = new Font("Bitstream Vera Sans", 10);
			int RowNumber = 0;

			for (RowNumber = m_LastRow; RowNumber <= m_Detalle.Rows.Count - 1; RowNumber++)
			{
				DataRow Detalle = m_Detalle.Rows[RowNumber];
				Rect = new RectangleF(MarginLeft, iTop, 20, 20);
				ev.Graphics.DrawString((RowNumber + 1).ToString(), Fuente, Brushes.DarkGray, Rect, FormatoRC);
				Rect = new RectangleF(MarginLeft + 26, iTop, 40, 20);
				ev.Graphics.DrawString(
				    Lfx.Types.Formatting.FormatNumber(System.Convert.ToDouble(Detalle["cantidad"]), this.Workspace.CurrentConfig.Productos.DecimalesStock),
				    Fuente,
				    Brushes.Black, Rect, FormatoRC);
				Rect = new RectangleF(MarginLeft + 70, iTop, PrintAreaWidth - MarginLeft - 160, 20);
				ev.Graphics.DrawString(System.Convert.ToString(Detalle["nombre"]), Fuente, Brushes.Black, Rect, FormatoLC);
				Rect = new RectangleF(MarginLeft + PrintAreaWidth - 160, iTop, 80, 20);
				ev.Graphics.DrawString(Lfx.Types.Currency.CurrencySymbol + " " + Lfx.Types.Formatting.FormatNumber(System.Convert.ToDouble(Detalle["precio"]), this.Workspace.CurrentConfig.Moneda.DecimalesCosto), Fuente, Brushes.Black, Rect, FormatoRC);
				Rect = new RectangleF(MarginLeft + PrintAreaWidth - 80, iTop, 80, 20);
				ev.Graphics.DrawString(Lfx.Types.Currency.CurrencySymbol + " " + Lfx.Types.Formatting.FormatNumber(System.Convert.ToDouble(Detalle["importe"]), this.Workspace.CurrentConfig.Moneda.DecimalesCosto), Fuente, Brushes.Black, Rect, FormatoRC);
				iTop += 20;

				if (Lfx.Data.DataBase.ConvertDBNullToZero(Detalle["id_articulo"]) > 0)
				{
					Rect = new RectangleF(MarginLeft + 70, iTop, PrintAreaWidth - MarginLeft - 140, 100);
                                        string Descrip = this.Workspace.DefaultDataBase.FieldString("SELECT descripcion FROM articulos WHERE id_articulo=" + Detalle["id_articulo"].ToString());

					if (Descrip.Length > 0)
					{
						SizeF Tamano = ev.Graphics.MeasureString(Descrip, FuentePequena, Rect.Size, FormatoLT);

						if (Tamano.Height > 50)
						{
							Tamano.Height = 50;
						}

						Rect.Height = Tamano.Height;
						ev.Graphics.DrawString(Descrip, FuentePequena, Brushes.Black, Rect, FormatoLT);
						iTop += System.Convert.ToInt32(Rect.Height);
					}
				}

				Rect = new RectangleF(MarginLeft, iTop, PrintAreaWidth, 4);
				ev.Graphics.DrawLine(Pens.Gray, Rect.X, Rect.Y, Rect.X + Rect.Width, Rect.Y);
				iTop += System.Convert.ToInt32(Rect.Height);

				if (iTop > PrintAreaHeight - AlturaPie - 52)
				{
					// Los 52 son para Subtotal y total
					break;
				}
			}

			m_LastRow = RowNumber + 1;

			if (RowNumber < m_Detalle.Rows.Count - 1)
			{
				//No es última página
				// Pie Der
				Fuente = new Font("Arial", 8, FontStyle.Italic);
				iTop = MarginTop + PrintAreaHeight - 24;
				Rect = new RectangleF(MarginLeft + PrintAreaWidth - 160, iTop, 160, 12);
				ev.Graphics.DrawString("Página " + m_Pagina.ToString(), Fuente, Brushes.Black, Rect, FormatoRC);
				iTop += System.Convert.ToInt32(Rect.Height);
				Rect = new RectangleF(MarginLeft + PrintAreaWidth - 160, iTop, 160, 12);
				ev.Graphics.DrawString("Continúa en pág. " + (m_Pagina + 1).ToString(), Fuente, Brushes.Black, Rect, FormatoRC);
				ev.HasMorePages = true;
			}
			else
			{
				iTop += 10;
				int iTopOld = iTop; // Guardo el iTop. Imprimo a la iquierda, vuelvo arriba e imprimo a la derecha

				if (System.Convert.ToDouble(m_Comprob["descuento"]) > 0)
				{
					Rect = new RectangleF(MarginLeft, iTop, 240, 14);
					ev.Graphics.DrawString("Descuento: " + Lfx.Types.Formatting.FormatNumber(System.Convert.ToDouble(m_Comprob["descuento"]), 2) + "%", Fuente, Brushes.Black, Rect, FormatoLC);
					iTop += System.Convert.ToInt32(Rect.Height);
				}

				if (System.Convert.ToDouble(m_Comprob["interes"]) > 0)
				{
					Rect = new RectangleF(MarginLeft, iTop, 240, 14);
					ev.Graphics.DrawString("Recargo: " + Lfx.Types.Formatting.FormatNumber(System.Convert.ToDouble(m_Comprob["interes"]), 2) + "%", Fuente, Brushes.Black, Rect, FormatoLC);
					iTop += System.Convert.ToInt32(Rect.Height);
				}

				if (System.Convert.ToInt32(m_Comprob["cuotas"]) > 0)
				{
					Rect = new RectangleF(MarginLeft, iTop, 240, 14);
					ev.Graphics.DrawString(m_Comprob["cuotas"].ToString() + " cuotas de " + Lfx.Types.Currency.CurrencySymbol + Lfx.Types.Formatting.FormatCurrency(System.Convert.ToDouble(m_Comprob["total"]) / System.Convert.ToInt32(m_Comprob["cuotas"]), this.Workspace.CurrentConfig.Moneda.Decimales), Fuente, Brushes.Black, Rect, FormatoLC);
					iTop += System.Convert.ToInt32(Rect.Height);
				}

				iTop = iTopOld;
				Fuente = new Font("Arial", 12);
				Rect = new RectangleF(MarginLeft + PrintAreaWidth - 160, iTop, 160, 20);
				ev.Graphics.DrawString("Sub total: " + Lfx.Types.Currency.CurrencySymbol + " " + Lfx.Types.Formatting.FormatCurrency(System.Convert.ToDouble(m_Comprob["subtotal"]), this.Workspace.CurrentConfig.Moneda.Decimales), Fuente, Brushes.Black, Rect, FormatoRC);
				iTop += System.Convert.ToInt32(Rect.Height + 4);

				Fuente = new Font("Arial Black", 14);
				Rect = new RectangleF(MarginLeft + PrintAreaWidth - 220, iTop, 220, 28);
				string Total = "Total: " + Lfx.Types.Currency.CurrencySymbol + " " + Lfx.Types.Formatting.FormatCurrency(System.Convert.ToDouble(m_Comprob["total"]), this.Workspace.CurrentConfig.Moneda.Decimales);
				SizeF Tamano = ev.Graphics.MeasureString(Total, Fuente, Rect.Location, FormatoLT);
				Rect.Width = Tamano.Width + 20;
				Rect.Height = Tamano.Height + 10;
				Rect.X = MarginLeft + PrintAreaWidth - Rect.Width;
				ev.Graphics.DrawRectangle(new Pen(Color.Gray, 2), Rect.X, Rect.Y, Rect.Width, Rect.Height);
				ev.Graphics.DrawString(Total, Fuente, Brushes.Black, Rect, FormatoCC);

				Fuente = new Font("Arial", 8, FontStyle.Italic);
				iTop = MarginTop + PrintAreaHeight - 24;
				Rect = new RectangleF(MarginLeft + PrintAreaWidth - 160, iTop, 160, 12);
				ev.Graphics.DrawString("Página " + m_Pagina.ToString(), Fuente, Brushes.Black, Rect, FormatoRC);
				iTop += System.Convert.ToInt32(Rect.Height);

				if (m_Pagina == 1)
				{
					Rect = new RectangleF(MarginLeft + PrintAreaWidth - 160, iTop, 160, 12);
					ev.Graphics.DrawString("de 1.", Fuente, Brushes.Black, Rect, FormatoRC);
				}
				else
				{
					Rect = new RectangleF(MarginLeft + PrintAreaWidth - 160, iTop, 160, 12);
					ev.Graphics.DrawString("Esta es la última página.", Fuente, Brushes.Black, Rect, FormatoRC);
				}

				ev.HasMorePages = false;
			}

			// Pie Izq
			Fuente = new Font("Arial", 9);
			iTop = MarginTop + PrintAreaHeight - 12;
			Rect = new RectangleF(MarginLeft, iTop, PrintAreaWidth - 160, 12);
			ev.Graphics.DrawString("Lo atendió: " + m_Vendedor, Fuente, Brushes.Black, Rect, FormatoLC);

                        base.OnPrintPage(ev);
		}
	}
}