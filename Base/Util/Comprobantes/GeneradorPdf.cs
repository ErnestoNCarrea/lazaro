using System;
using System.Collections.Generic;
using System.Text;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Lazaro.Base.Util.Comprobantes
{
        public enum Variantes
        {
                AzulYVerde = 1,
                RojoYNegro = 2
        }

        public class GeneradorPdf
        {
                public const double mm = 2.834645669d;
                public const string FuenteSans = "Calibri";
                public Variantes Variante = Variantes.AzulYVerde;

#pragma warning disable CS3003 // Il tipo non è conforme a CLS
                protected XColor Color1, Color2, Color3;
#pragma warning restore CS3003 // Il tipo non è conforme a CLS

                public class Margenes
                {
                        public const double Izquierda = 25 * mm, Derecha = 10 * mm, Arriba = 10 * mm, Abajo = 10 * mm;
                }

                protected Lbl.Comprobantes.ComprobanteConArticulos Comprob;

                public GeneradorPdf(Lbl.Comprobantes.ComprobanteConArticulos comprob)
                {
                        this.Comprob = comprob;
                }


                /// <summary>
                /// Generar un PDF a partir de un comprobante y guardarlo en un archivo.
                /// </summary>
                public void GenerarYGuardar(string archivo)
                {
                        if (this.Comprob is Lbl.Comprobantes.ComprobanteFacturable) {
                                this.GenerarFactura().Save(archivo);
                        }
                }


                /// <summary>
                /// Genera el texto o secuencia de números que componen el código de barras.
                /// Según http://www.afip.gov.ar/afip/resol170204.html
                /// 
                /// Clave Unica de Identificación Tributaria(C.U.I.T.) del emisor de la factura.
                /// Código de tipo de comprobante.
                /// Punto de venta.
                /// Código de Autorización de Impresión(C.A.I.).
                /// Fecha de vencimiento.
                /// Dígito verificador.
                /// </summary>
                /// <returns>Una secuencia de números que se deben codificar en ITF (Interleaved 2 of 5)</returns>
                public string GenerarTextoCodigoDeBarras()
                {
                        string Res = "";

                        //Res = "202524853261100026627693000799720160716";
                        //Res += Afip.Ws.FacturaElectronica.ServicioFacturaElectronica.DigitoVerificadorIdentificacionComprobante(Res).ToString().PadLeft(1, '0');

                        Res += Lbl.Sys.Config.Empresa.ClaveTributaria.ToString().Replace("-", "").PadLeft(11, '0');
                        Res += Afip.Ws.FacturaElectronica.Tablas.CodigoDeComprobantePorLetra(Comprob.Tipo.Nomenclatura).ToString().PadLeft(2, '0');
                        Res += Comprob.PV.ToString().PadLeft(4, '0');
                        Res += Comprob.CaeNumero.ToString().PadLeft(14, '0');
                        Res += Lfx.Types.Formatting.FormatDate(Comprob.CaeVencimiento).Replace("/", "").PadLeft(8, '0');
                        Res += Afip.Ws.FacturaElectronica.ServicioFacturaElectronica.DigitoVerificadorIdentificacionComprobante(Res).ToString().PadLeft(1, '0');
                        return Res;
                }


                /// <summary>
                /// Generar un PDF para un comprobante facturable.
                /// </summary>
                public PdfDocument GenerarFactura()
                {
                        var Res = new PdfDocument();

                        switch (this.Variante) {
                                case Variantes.RojoYNegro:
                                        this.Color1 = XColor.FromArgb(242, 46, 46);
                                        this.Color2 = XColor.FromArgb(220, 200, 135);
                                        this.Color3 = XColor.FromArgb(220, 200, 135);
                                        break;

                                default:
                                case Variantes.AzulYVerde:
                                        this.Color1 = XColor.FromArgb(48, 113, 242);
                                        this.Color2 = XColor.FromArgb(194, 243, 31);
                                        this.Color3 = XColors.Orange;
                                        break;
                        }


                        Res.Options.CompressContentStreams = true;
                        Res.Language = "es_AR";
                        Res.Info.Title = Comprob.ToString();
                        Res.Info.Author = Lbl.Sys.Config.Empresa.RazonSocial;
                        Res.Info.Creator = "Lázaro Gestión; http://www.lazarogestion.com";
                        Res.Info.Subject = "Factura electrónica autorizada por AFIP, CAE " + Comprob.CaeNumero;

                        var Pagina = new PdfPage(Res)
                        {
                                Size = PageSize.A4
                        };

                        var Gfx = XGraphics.FromPdfPage(Pagina);

                        var FuentePredeterminada = new XFont(FuenteSans, 11);
                        var FuenteResaltada = new XFont(FuenteSans, 11, XFontStyle.Bold);
                        var FuentePequena = new XFont(FuenteSans, 9);
                        var FuenteArticulos = new XFont(FuenteSans, 10);
                        var AreaUsable = new XRect(Margenes.Izquierda, Margenes.Arriba, Pagina.Width - Margenes.Derecha - Margenes.Izquierda, Pagina.Height - Margenes.Arriba - Margenes.Abajo);
                        var Tf = new XTextFormatter(Gfx)
                        {
                                Font = FuentePredeterminada
                        };

                        var LineaFina = new XPen(this.Color1, .3);

                        var CuadroEncab = new XRect(AreaUsable.Left, AreaUsable.Top, AreaUsable.Width, 30 * mm);

                        //Gfx.DrawRectangle(new XPen(Azul), XBrushes.Transparent, new XRect(-10, AreaUsable.Top, AreaUsable.Right + 10, 30 * mm));
                        Gfx.DrawRectangle(XPens.Transparent, new XSolidBrush(this.Color3), new XRect(AreaUsable.Left + AreaUsable.Width / 2 - 12 * mm, -10, 24 * mm, AreaUsable.Top + 10 + 16 * mm));

                        Gfx.DrawString(Comprob.Tipo.LetraONomenclatura, new XFont(FuenteSans, 24, XFontStyle.Bold), XBrushes.Black, new XRect(AreaUsable.Left + AreaUsable.Width / 2 - 12 * mm, AreaUsable.Top + 1 * mm, 24 * mm, 10 * mm), XStringFormats.Center);
                        Gfx.DrawString("Cód. " + Afip.Ws.FacturaElectronica.Tablas.CodigoDeComprobantePorLetra(Comprob.Tipo.Nomenclatura).ToString().PadLeft(2, '0'), FuentePequena, XBrushes.Black, new XRect(AreaUsable.Left + AreaUsable.Width / 2 - 12 * mm, AreaUsable.Top + 10 * mm, 24 * mm, 6 * mm), XStringFormats.Center);

                        var EncabIzquierdo = new XRect(AreaUsable.Left + 2 * mm, AreaUsable.Top + 2 * mm, AreaUsable.Width / 2 - 16 * mm, 26 * mm);
                        var EncabDerecho = new XRect(AreaUsable.Left + AreaUsable.Width / 2 + 14 * mm, AreaUsable.Top + 2 * mm, AreaUsable.Width / 2 - 16 * mm, 26 * mm);

                        Tf.Alignment = XParagraphAlignment.Right;
                        Tf.DrawString(Comprob.PV.ToString().PadLeft(4, '0') + "-" + Comprob.Numero.ToString().PadLeft(8, '0') + "\n" + Comprob.Tipo.Nombre + "\n\n" + Lfx.Types.Formatting.FormatDate(Comprob.Fecha), FuenteResaltada, XBrushes.Black, EncabDerecho);
                        Tf.Alignment = XParagraphAlignment.Left;

                        var TextoEncab = "";
                        TextoEncab += Lbl.Sys.Config.Empresa.RazonSocial + "\n";
                        if (Lbl.Sys.Config.Empresa.SituacionTributaria > 0) {
                                var EmpresaSituacion = new Lbl.Impuestos.SituacionTributaria(Comprob.Connection, Lbl.Sys.Config.Empresa.SituacionTributaria);
                                if (EmpresaSituacion.Existe) {
                                        TextoEncab += EmpresaSituacion.Nombre + "\n";
                                }
                        }
                        if (Lbl.Sys.Config.Empresa.SucursalActual != null && string.IsNullOrWhiteSpace(Lbl.Sys.Config.Empresa.SucursalActual.Direccion) == false) {
                                TextoEncab += Lbl.Sys.Config.Empresa.SucursalActual.Direccion + "\n";
                        }
                        if (Lbl.Sys.Config.Empresa.ClaveTributaria != null) {
                                TextoEncab += Lbl.Sys.Config.Empresa.ClaveTributaria.Nombre + ": " + Lbl.Sys.Config.Empresa.ClaveTributaria.ToString() + "\n";
                        }
                        if (string.IsNullOrWhiteSpace(Lbl.Sys.Config.Empresa.NumeroIngresosBrutos) == false) {
                                TextoEncab += "II.BB.: " + Lbl.Sys.Config.Empresa.NumeroIngresosBrutos + "\n";
                        }
                        if (Lbl.Sys.Config.Empresa.InicioDeActividades != null) {
                                TextoEncab += "Inicio act.: " + Lfx.Types.Formatting.FormatDate(Lbl.Sys.Config.Empresa.InicioDeActividades) + "\n";
                        }
                
                        Tf.DrawString(TextoEncab, FuentePequena, XBrushes.Black, EncabDerecho);
                

                        var Logo = new Lbl.Sys.Blob(this.Comprob.Connection, 1);
                        if (Logo.Existe && Logo.Imagen != null) {
                                // Poner el logotipo, centrado en el espacio de logo
                                var XImagenLogo = XImage.FromGdiPlusImage(Logo.Imagen);

                                var RatioX = (double)EncabIzquierdo.Width / XImagenLogo.PointWidth;
                                var RatioY = (double)EncabDerecho.Height / XImagenLogo.PointHeight;
                                var RatioFinal = Math.Min(RatioX, RatioY);

                                var LogoTamanio = new XSize(XImagenLogo.PointWidth * RatioFinal, XImagenLogo.PointHeight * RatioFinal);
                                var LogoRect = new XRect(EncabIzquierdo.Left + (EncabIzquierdo.Width - LogoTamanio.Width) / 2, EncabIzquierdo.Top + (EncabIzquierdo.Height - LogoTamanio.Height) / 2, LogoTamanio.Width, LogoTamanio.Height);

                                Gfx.DrawImage(XImagenLogo, LogoRect);
                        } else {
                                // Poner el nombre de la empresa
                                Tf.Alignment = XParagraphAlignment.Center;
                                Tf.DrawString(Lbl.Sys.Config.Empresa.Nombre, new XFont(FuenteSans, 16, XFontStyle.Bold), new XSolidBrush(this.Color1), EncabIzquierdo);
                        }

                        var CuadroCliente = new XRect(AreaUsable.Left , CuadroEncab.Bottom + 4 * mm, AreaUsable.Width, 14 * mm);

                        //Gfx.DrawLine(LineaFinaGris, CuadroCliente.Left, CuadroCliente.Bottom, CuadroCliente.Right, CuadroCliente.Bottom);
                        Tf.Alignment = XParagraphAlignment.Left;
                        Tf.DrawString("Cliente\nDomicilio\nCUIT", FuentePredeterminada, XBrushes.Black, CuadroCliente);
                        string DatosCliente1 = Comprob.Cliente.ToString() + "\n" + Comprob.Cliente.Domicilio + "\n";
                        if (Comprob.Cliente.ClaveTributaria != null) {
                                DatosCliente1 += Comprob.Cliente.ClaveTributaria.ToString();
                        }
                        Tf.DrawString(DatosCliente1, FuenteResaltada, XBrushes.Black, new XRect(CuadroCliente.Left + 20 * mm, CuadroCliente.Top, CuadroCliente.Width, CuadroCliente.Width));

                        Tf.DrawString("Condición\nSituación\nCiudad", FuentePredeterminada, XBrushes.Black, new XRect(CuadroCliente.Left + 100 * mm, CuadroCliente.Top, CuadroCliente.Width, CuadroCliente.Width));
                        string DatosCliente2 = Comprob.FormaDePago.ToString() + "\n" + Comprob.Cliente.SituacionTributaria.ToString() + "\n";
                        if(Comprob.Cliente.Localidad != null) {
                                DatosCliente2 += Comprob.Cliente.Localidad.ToString();
                        }
                        Tf.DrawString(DatosCliente2, FuenteResaltada, XBrushes.Black, new XRect(CuadroCliente.Left + 120 * mm, CuadroCliente.Top, CuadroCliente.Width, CuadroCliente.Width));

                        // *** Artículos y detalles

                        var CuadroArticulos = new XRect(AreaUsable.Left, CuadroCliente.Bottom + 4 * mm, AreaUsable.Width, 140 * mm);
                        //Gfx.DrawRectangle(LineaFinaGris, CuadroArticulos);
                        Gfx.DrawLine(LineaFina, CuadroArticulos.Left, CuadroArticulos.Top, CuadroArticulos.Right, CuadroArticulos.Top);

                        var ColAnchos = new int[] { 24, 92, 14, 22, 22 };

                        var CuadroArticulosCodigos = new XRect(CuadroArticulos.Left, CuadroArticulos.Top, ColAnchos[0] * mm, CuadroArticulos.Height);
                        var CuadroArticulosDetalles = new XRect(CuadroArticulosCodigos.Right, CuadroArticulos.Top, ColAnchos[1] * mm, CuadroArticulos.Height);
                        var CuadroArticulosCantidades = new XRect(CuadroArticulosDetalles.Right, CuadroArticulos.Top, ColAnchos[2] * mm, CuadroArticulos.Height);
                        var CuadroArticulosUnitarios = new XRect(CuadroArticulosCantidades.Right, CuadroArticulos.Top, ColAnchos[3] * mm, CuadroArticulos.Height);
                        var CuadroArticulosSubtotales = new XRect(CuadroArticulosUnitarios.Right, CuadroArticulos.Top, ColAnchos[4] * mm, CuadroArticulos.Height);

                        Gfx.DrawLine(LineaFina, CuadroArticulos.Left, CuadroArticulos.Top + 7 * mm, CuadroArticulos.Right, CuadroArticulos.Top + 7 * mm);
                        CuadroArticulosCodigos.Offset(0, 1 * mm);
                        CuadroArticulosDetalles.Offset(0, 1 * mm);
                        CuadroArticulosCantidades.Offset(0, 1 * mm);
                        CuadroArticulosUnitarios.Offset(0, 1 * mm);
                        CuadroArticulosSubtotales.Offset(0, 1 * mm);

                        Tf.Alignment = XParagraphAlignment.Left;
                        Tf.DrawString("Código", FuenteResaltada, XBrushes.Black, CuadroArticulosCodigos);
                        Tf.DrawString("Detalle", FuenteResaltada, XBrushes.Black, CuadroArticulosDetalles);
                        Tf.Alignment = XParagraphAlignment.Right;
                        Tf.DrawString("Cantidad", FuenteResaltada, XBrushes.Black, CuadroArticulosCantidades);
                        Tf.DrawString("P. unitario", FuenteResaltada, XBrushes.Black, CuadroArticulosUnitarios);
                        Tf.DrawString("Subtotal", FuenteResaltada, XBrushes.Black, CuadroArticulosSubtotales);

                        CuadroArticulosCodigos.Offset(0, 7 * mm);
                        CuadroArticulosDetalles.Offset(0, 7 * mm);
                        CuadroArticulosCantidades.Offset(0, 7 * mm);
                        CuadroArticulosUnitarios.Offset(0, 7 * mm);
                        CuadroArticulosSubtotales.Offset(0, 7 * mm);

                        Tf.Alignment = XParagraphAlignment.Left;

                        // Generar un listado de códigos, detalles, cantidades, etc.
                        string Codigos = "", Detalles = "", Cantidades = "", Unitarios = "", Importes ="";
                        foreach(var Det in Comprob.Articulos) {
                                string CodigoImprimir, DetalleImprimir;
                                if (Det.Articulo == null) {
                                        CodigoImprimir = "";
                                        DetalleImprimir = Det.Nombre;
                                } else {
                                        CodigoImprimir = Det.Articulo.Id.ToString();
                                        DetalleImprimir = Det.Articulo.ToString();
                                }

                                Codigos += CodigoImprimir + "\n";
                                Detalles += DetalleImprimir + "\n";
                                Cantidades += Lfx.Types.Formatting.FormatNumberForPrint(Det.Cantidad, Lbl.Sys.Config.Articulos.Decimales) + "\n";
                                Unitarios += Lfx.Types.Formatting.FormatCurrencyForPrint(Det.ImporteUnitarioFinalAImprimir, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal) + "\n";
                                Importes += Lfx.Types.Formatting.FormatCurrencyForPrint(Det.ImporteAImprimir, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal) + "\n";
                        }
                        Tf.DrawString(Codigos, FuenteArticulos, XBrushes.Black, CuadroArticulosCodigos);
                        Tf.DrawString(Detalles, FuenteArticulos, XBrushes.Black, CuadroArticulosDetalles);
                        Tf.Alignment = XParagraphAlignment.Right;
                        Tf.DrawString(Cantidades, FuenteArticulos, XBrushes.Black, CuadroArticulosCantidades);
                        Tf.DrawString(Unitarios, FuenteArticulos, XBrushes.Black, CuadroArticulosUnitarios);
                        Tf.DrawString(Importes, FuenteArticulos, XBrushes.Black, CuadroArticulosSubtotales);

                        // *** Observaciones

                        var CuadroObs = new XRect(AreaUsable.Left, CuadroArticulos.Bottom + 4 * mm, AreaUsable.Width, 26 * mm);
                        Tf.Alignment = XParagraphAlignment.Left;
                        if (Comprob.Obs != null && Comprob.Obs.Length > 0) {
                                Tf.DrawString(Comprob.Obs, Comprob.Obs.Length > 400 ? FuentePequena : FuentePredeterminada, XBrushes.Black, CuadroObs);
                        }

                        Gfx.DrawLine(LineaFina, CuadroObs.Left, CuadroObs.Bottom, CuadroObs.Right, CuadroObs.Bottom);

                        // *** Subtotal, IVA, descuento y total

                        var CuadroTotales = new XRect(AreaUsable.Left, CuadroObs.Bottom + 4 * mm, 50 * mm, 14 * mm);

                        Tf.Alignment = XParagraphAlignment.Left;
                        Tf.DrawString("Subtotal\nIVA\nDescuento / recargo", FuentePredeterminada, XBrushes.Black, CuadroTotales);
                        Tf.Alignment = XParagraphAlignment.Right;
                        Tf.DrawString(string.Concat(
                                Lfx.Types.Formatting.FormatCurrency(Comprob.SubtotalSinIvaFinal), "\n",
                                Lfx.Types.Formatting.FormatCurrency(Comprob.ImporteIvaDiscriminadoFinal), "\n",
                                Lfx.Types.Formatting.FormatNumber(Comprob.Descuento, 2) + "%"
                                ), FuenteResaltada, XBrushes.Black, CuadroTotales);

                        //Tf.DrawString("\nSon ciento veintitresmil cuatrocientos cincuenta y seis pesos con 00/100.", FuentePequena, XBrushes.Black, CuadroTotales);

                        var CuadroTotal = new XRect(AreaUsable.Right - 50 * mm, CuadroTotales.Top, 50 * mm, CuadroTotales.Height);
                        var CuadroFondoTotal = new XRect(AreaUsable.Right - 45 * mm, CuadroTotales.Top, 90 * mm, CuadroTotales.Height);
                        Gfx.DrawRectangle(new XSolidBrush(this.Color2), CuadroFondoTotal);
                        //Gfx.DrawRectangle(XBrushes.Silver, CuadroTotal);
                        CuadroTotal.Offset(0, 3 * mm);
                        Gfx.DrawString("TOTAL", new XFont(FuenteSans, 8), XBrushes.Black, CuadroFondoTotal.Left + 1 * mm, CuadroFondoTotal.Top + 3 * mm);
                        Tf.Alignment = XParagraphAlignment.Right;
                        Tf.DrawString("$ " + Lfx.Types.Formatting.FormatCurrency(Comprob.Total), new XFont(FuenteSans, 18, XFontStyle.Bold), XBrushes.Black, CuadroTotal);


                        // *** Pie con información de AFIP y código de barras

                        var CuadroPie = new XRect(AreaUsable.Left, AreaUsable.Bottom - 20 * mm, AreaUsable.Width, 20 * mm);
                        Gfx.DrawLine(LineaFina, CuadroPie.Left, CuadroPie.Top, CuadroPie.Right, CuadroPie.Top);

                        CuadroPie.Offset(0, 1 * mm);

                        Tf.Alignment = XParagraphAlignment.Left;
                        Tf.DrawString("Comprobante electrónico\nCAE Nº " + Comprob.CaeNumero + "\nCAE Vence " + Lfx.Types.Formatting.FormatDate(Comprob.CaeVencimiento), FuentePredeterminada, XBrushes.Black, new XRect(CuadroPie.Left + 110 * mm, CuadroPie.Top, CuadroPie.Width, CuadroPie.Height));
         
                        string TextoCodigoBarras = this.GenerarTextoCodigoDeBarras();
                        var CodBarras = new BarcodeLib.Barcode();
                        var ImagenCodBarras = CodBarras.Encode(BarcodeLib.TYPE.Interleaved2of5, TextoCodigoBarras, 1000, 120);
                        var XImagenCodBarras = XImage.FromGdiPlusImage(ImagenCodBarras);
                        Gfx.DrawImage(XImagenCodBarras, new XRect(CuadroPie.Left, CuadroPie.Bottom - 20 * mm, 100 * mm, 12 * mm));
                        Tf.Alignment = XParagraphAlignment.Center;
                        Tf.DrawString(TextoCodigoBarras, FuentePredeterminada, XBrushes.Black, new XRect(CuadroPie.Left, CuadroPie.Bottom - 7 * mm, 100 * mm, 7 * mm));

                        Res.AddPage(Pagina);

                        return Res;
                }
        }
}
