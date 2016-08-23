using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text.RegularExpressions;

namespace Lazaro.Base.Util.Impresion
{
        public class ImpresorElemento : Impresor
        {
                public Lbl.ElementoDeDatos Elemento = null;
                public Lbl.Impresion.Plantilla Plantilla = null;
                private Lbl.Comprobantes.Tipo Tipo = null;

                //private MuPDFLib.MuPDF PdfDoc;

                public ImpresorElemento(Lbl.ElementoDeDatos elemento, IDbTransaction transaction)
                        : base(transaction)
		{
                        this.Elemento = elemento;
                        m_DataBase = elemento.Connection;
		}


                protected override void Dispose(bool disposing)
                {
                        /* if (PdfDoc != null) {
                                PdfDoc.Dispose();
                                PdfDoc = null;
                        } */
                        base.Dispose(disposing);
                }


                protected virtual Lbl.Impresion.Plantilla ObtenerPlantilla()
                {
                        return this.ObtenerPlantilla(this.Elemento.GetType());
                }


                protected virtual Lbl.Impresion.Plantilla ObtenerPlantilla(Type tipoElemento)
                {
                        string nombreTipo = tipoElemento.ToString();
                        if (Lbl.Impresion.Plantilla.TodasPorCodigo.ContainsKey(nombreTipo))
                                return Lbl.Impresion.Plantilla.TodasPorCodigo[nombreTipo];
                        else if (tipoElemento.BaseType != null) {
                                return this.ObtenerPlantilla(tipoElemento.BaseType);
                        } else {
                                Lbl.Impresion.Plantilla Res = new Lbl.Impresion.Plantilla(this.Connection);
                                Res.Crear();
                                return Res;
                        }
                }

                public virtual Lbl.Comprobantes.Tipo ObtenerTipo()
                {
                        int TipoId = this.Connection.FieldInt("SELECT id_tipo FROM documentos_tipos WHERE letra='" + this.Elemento.GetType().ToString() + "'");

                        if (TipoId > 0)
                                return new Lbl.Comprobantes.Tipo(this.Connection, TipoId);
                        else
                                return null;
                }

                protected virtual Lbl.Impresion.Impresora ObtenerImpresora()
                {
                        if (this.Tipo == null)
                                this.Tipo = this.ObtenerTipo();

                        if (this.Tipo == null)
                                return null;

                        // Intento obtener una impresora para esta susursal, para esta estación
                        foreach (Lbl.Impresion.TipoImpresora Impr in this.Tipo.Impresoras) {
                                if (Impr.Estacion != null && Impr.Estacion.ToUpperInvariant() == Lfx.Environment.SystemInformation.MachineName
                                        && Impr.Sucursal != null && Impr.Sucursal.Id == Lbl.Sys.Config.Empresa.SucursalActual.Id)
                                        return Impr.Impresora;
                        }

                        // Intento obtener una impresora para esta estación, cualquier sucursal
                        foreach (Lbl.Impresion.TipoImpresora Impr in this.Tipo.Impresoras) {
                                if (Impr.Estacion != null && Impr.Estacion.ToUpperInvariant() == Lfx.Environment.SystemInformation.MachineName
                                        && Impr.Sucursal == null)
                                        return Impr.Impresora;
                        }

                        // Intento obtener una impresora para esta sucursal, cualquier estacion
                        foreach (Lbl.Impresion.TipoImpresora Impr in this.Tipo.Impresoras) {
                                if (Impr.Estacion == null
                                        && Impr.Sucursal != null && Impr.Sucursal.Id == Lbl.Sys.Config.Empresa.SucursalActual.Id)
                                        return Impr.Impresora;
                        }

                        // Intento obtener una impresora para cual sucursal, cualquier estacion
                        foreach (Lbl.Impresion.TipoImpresora Impr in this.Tipo.Impresoras) {
                                if (Impr.Estacion == null && Impr.Sucursal == null)
                                        return Impr.Impresora;
                        }

                        return null;
                }

                public override Lfx.Types.OperationResult Imprimir()
                {
                        // Determino la impresora que le corresponde
                        if (this.Impresora == null)
                                this.Impresora = this.ObtenerImpresora();

                        if (this.Plantilla == null)
                                this.Plantilla = this.ObtenerPlantilla();

                        // Es una plantilla común... se imprime con Lázaro
                        Lfx.Types.OperationResult Res = base.Imprimir();

                        System.Data.IDbTransaction Trans = null;
                        if (this.Connection.InTransaction == false)
                                Trans = this.Connection.BeginTransaction();

                        if (Res.Success)
                                Lbl.Sys.Config.ActionLog(this.Connection, Lbl.Sys.Log.Acciones.Print, this.Elemento, null);
                        else
                                Lbl.Sys.Config.ActionLog(this.Connection, Lbl.Sys.Log.Acciones.PrintFail, this.Elemento, Res.Message);

                        if (Trans != null) {
                                Trans.Commit();
                                Trans.Dispose();
                                Trans = null;
                        }

                        return Res;
                }

                protected override void OnBeginPrint(PrintEventArgs e)
                {
                        PaginaNumero = 0;

                        if (this.DocumentName == null || this.DocumentName.Length == 0 || this.DocumentName == "document")
                                this.DocumentName = this.Elemento.ToString();

                        if (this.Plantilla != null) {
                                if (this.Plantilla.Copias > 1)
                                        this.PrinterSettings.Copies = (short)(this.Plantilla.Copias);

                                if (this.Plantilla.Margenes != null)
                                        this.DefaultPageSettings.Margins = this.Plantilla.Margenes;
                                else
                                        this.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);

                                if (this.Plantilla.Bandeja > 0) {
                                        if (this.Plantilla.Bandeja > this.PrinterSettings.PaperSources.Count)
                                                throw new InvalidOperationException("El número de bandeja no es válido para esta impresora");
                                        else
                                                this.DefaultPageSettings.PaperSource = this.PrinterSettings.PaperSources[this.Plantilla.Bandeja - 1];
                                }
                        }

                        base.OnBeginPrint(e);
                }

                protected override void OnPrintPage(PrintPageEventArgs e)
                {
                        this.PaginaNumero++;
                        e.Graphics.PageUnit = GraphicsUnit.Document;

                        if (this.Plantilla != null) {
                                e.PageSettings.Landscape = Plantilla.Landscape;

                                switch(this.Plantilla.Tipo) {
                                        case Lbl.Impresion.TipoPlantilla.Preimpresa:
                                                this.ImprimirInterna(e);
                                                break;
                                        case Lbl.Impresion.TipoPlantilla.EnBlanco:
                                                if (Plantilla.Imagen != null)
                                                        e.Graphics.DrawImage(Plantilla.Imagen, e.PageBounds);
                                                this.ImprimirInterna(e);
                                                break;
                                        case Lbl.Impresion.TipoPlantilla.Pdf:
                                                /* if (this.PdfDoc == null) {
                                                        iTextSharp.text.pdf.PdfReader Rdr = new iTextSharp.text.pdf.PdfReader(this.Plantilla.Archivo, null);
                                                        using (System.IO.MemoryStream OutStream = new System.IO.MemoryStream()) {
                                                                using (iTextSharp.text.pdf.PdfStamper Stmpr = new iTextSharp.text.pdf.PdfStamper(Rdr, OutStream)) {
                                                                        System.Collections.Generic.IDictionary<String, iTextSharp.text.pdf.TextField> Mp = Stmpr.AcroFields.FieldCache;
                                                                        foreach (string FldName in Stmpr.AcroFields.Fields.Keys) {
                                                                                string NombreCampo = FldName.Trim(new char[] { '{', '}' });
                                                                                Stmpr.AcroFields.SetField(NombreCampo, ObtenerValorCampo(NombreCampo, null));
                                                                        }
                                                                        Stmpr.FormFlattening = true;
                                                                        Stmpr.Writer.CloseStream = false;
                                                                        Stmpr.Close();
                                                                }
                                                                this.PdfDoc = new MuPDFLib.MuPDF(OutStream.GetBuffer(), null);
                                                        }

                                                        this.PdfDoc.AntiAlias = false;
                                                } */

                                                this.ImprimirPdf(e);
                                                break;
                                }
                                
                        }
                        base.OnPrintPage(e);
                }


                protected virtual void ImprimirPdf(PrintPageEventArgs e)
                {
                        /* this.PdfDoc.Page = this.PaginaNumero;

                        float Dpi = 72;
                        int w = System.Convert.ToInt32(e.PageBounds.Width * 5);
                        int h = System.Convert.ToInt32(e.PageBounds.Height * 5);
                        Bitmap FirstImage = PdfDoc.GetBitmap(w, h, Dpi, Dpi, 0, MuPDFLib.RenderType.Grayscale, false, false, 0);
                        e.Graphics.DrawImage(FirstImage, 0, 0, e.Graphics.VisibleClipBounds.Width, e.Graphics.VisibleClipBounds.Height);
                        e.Graphics.DrawString("Hola", new Font("Arial", 18), System.Drawing.Brushes.Black, new PointF(5, 5)); */
                }


                protected override void OnEndPrint(PrintEventArgs e)
                {
                        /* if (this.PdfDoc != null) {
                                this.PdfDoc.Dispose();
                                this.PdfDoc = null;
                        } */
                        base.OnEndPrint(e);
                }


                protected virtual void ImprimirInterna(PrintPageEventArgs e)
                {
                        ImprimirInterna(e, e.PageBounds, true);
                }


                protected virtual void ImprimirInterna(PrintPageEventArgs e, Rectangle recorte, bool imprimirEspejos)
                {
                        e.Graphics.TranslateTransform(recorte.X, recorte.Y);
                        foreach (Lbl.Impresion.Campo Cam in this.Plantilla.Campos) {
                                if (Cam.Valor.ToUpperInvariant() != "{ESPEJO}")
                                        this.ImprimirInternaCampo(e, Cam);
                        }
                        foreach (Lbl.Impresion.Campo Cam in this.Plantilla.Campos) {
                                if (Cam.Valor.ToUpperInvariant() == "{ESPEJO}" && imprimirEspejos)
                                        this.ImprimirInterna(e, Cam.Rectangle, false);
                        }
                }

                protected virtual void ImprimirInternaCampo(PrintPageEventArgs e, Lbl.Impresion.Campo Cam)
                {
                        if (Plantilla.Tipo == Lbl.Impresion.TipoPlantilla.Preimpresa && Cam.Preimpreso)
                                return;

                        if (Cam.ColorFondo != Color.Transparent)
                                e.Graphics.FillRectangle(new SolidBrush(Cam.ColorFondo), Cam.Rectangle);

                        if (Cam.AnchoBorde > 0)
                                e.Graphics.DrawRectangle(new Pen(Cam.ColorBorde, Cam.AnchoBorde), Cam.Rectangle);

                        // Imprimir texto
                        string Texto = Cam.Valor;
                        // Expando variables tipo {nombrecampo} por el valor del campo
                        Regex Rx = new Regex(@"\{[_\.0-9a-zA-Z]+\}", RegexOptions.ExplicitCapture | RegexOptions.Singleline);
                        MatchCollection NombresCampo = Rx.Matches(Texto);
                        foreach (Match Mt in NombresCampo) {
                                string ValorCampo = ObtenerValorCampo(Mt.Value.Substring(1, Mt.Value.Length - 2), Cam.Formato);
                                Texto = Texto.Replace(Mt.Value, ValorCampo);
                        }

                        StringFormat Fmt = new StringFormat(); //StringFormatFlags.NoClip);
                        if (Cam.Wrap == false)
                                Fmt.FormatFlags |= StringFormatFlags.NoWrap;
                        Fmt.Alignment = Cam.Alignment;
                        Fmt.LineAlignment = Cam.LineAlignment;
                        Fmt.Trimming = StringTrimming.EllipsisCharacter;
                        Font Fnt = Cam.Font;
                        if (Fnt == null)
                                Fnt = Plantilla.Font;
                        if (Fnt == null)
                                Fnt = Lazaro.Pres.DisplayStyles.Template.Current.DefaultFont;
                        e.Graphics.DrawString(Texto, Fnt, new SolidBrush(Cam.ColorTexto), Cam.Rectangle, Fmt);
                }

                public virtual string ObtenerValorCampo(string nombreCampo, string formato)
                {
                        switch (nombreCampo.ToUpperInvariant()) {
                                case "PAGINANUMERO":
                                case "PÁGINANÚMERO":
                                        return this.PaginaNumero.ToString();
                                case "HOY":
                                        if (formato != null) {
                                                try {
                                                        return DateTime.Now.ToString(formato);
                                                } catch {
                                                        return "Formato no válido";
                                                }
                                        } else {
                                                return DateTime.Now.ToString(Lfx.Types.Formatting.DateTime.ShortDatePattern);
                                        }

                                case "EMPRESA":
                                case "EMPRESA.NOMBRE":
                                        return Lbl.Sys.Config.Empresa.Nombre;
                                case "EMPRESA.DOMICILIO":
                                        return Lfx.Workspace.Master.CurrentConfig.Empresa.Domicilio;
                                case "EMPRESA.CIUDAD":
                                case "EMPRESA.LOCALIDAD":
                                        return Lfx.Workspace.Master.CurrentConfig.Empresa.NombreLocalidad;
                                case "EMPRESA.TELEFONO":
                                        return Lfx.Workspace.Master.CurrentConfig.Empresa.Telefono;

                                default:
                                        // Intento obtener por nombre de propiedad del objeto
                                        object Val = ObtenerPropiedadElemento(this.Elemento, nombreCampo);
                                        if (Val == null) {
                                                // Intento obtener por nombre de campo
                                                Val = this.Elemento.GetFieldValue<object>(nombreCampo.ToLowerInvariant());
                                        }

                                        if (Val != null && Val is DateTime || Val is NullableDateTime) {
                                                if (Val is NullableDateTime)
                                                        Val = ((NullableDateTime)(Val)).Value;
                                                if (formato != null) {
                                                        try {
                                                                return ((DateTime)Val).ToString(formato);
                                                        } catch {
                                                                return "Formato no válido";
                                                        }
                                                } else {
                                                        return ((DateTime)Val).ToString(Lfx.Types.Formatting.DateTime.ShortDatePattern);
                                                }
                                        } else if (Val is decimal) {
                                                if (formato != null) {
                                                        try {
                                                                return ((decimal)Val).ToString(formato);
                                                        } catch {
                                                                return "Formato no válido";
                                                        }
                                                } else {
                                                        if (((decimal)Val) == 0)
                                                                return "0";
                                                        else
                                                                return ((decimal)Val).ToString("#.00");
                                                }
                                        } else if (Val is bool) {
                                                return (bool)Val ? "Sí" : "No";
                                        } else if (Val == null) {
                                                return "";
                                        } else {
                                                return Val.ToString();
                                        }
                        }
                }

                private object ObtenerPropiedadElemento(Lbl.ElementoDeDatos elemento, string nombrePropiedad)
                {
                        // Intento obtener una propiedad por su nombre
                        if (nombrePropiedad == null || nombrePropiedad.Length == 0)
                                return null;

                        string[] Partes = nombrePropiedad.Split(new char[] { '.' }, 2);
                        if(Partes.Length == 0)
                                return null;

                        System.Reflection.PropertyInfo Prop = elemento.GetType().GetProperty(Partes[0]);
                        object Val = null;

                        if (Prop != null) {
                                Val = Prop.GetValue(elemento, null);
                        } else {
                                // No hay propiedad... busco un miembro público
                                System.Reflection.FieldInfo Fi = elemento.GetType().GetField(Partes[0]);
                                try {
                                        Val = elemento.GetType().InvokeMember(Fi.Name, System.Reflection.BindingFlags.GetField, null, elemento, null);
                                } catch {
                                        Val = null;
                                }
                        }

                        
                        if (Val == null) {
                                return null;
                        } else if (Val is Lbl.ElementoDeDatos && Partes.Length > 1) {
                                return ObtenerPropiedadElemento(Val as Lbl.ElementoDeDatos, Partes[1]);
                        } else {
                                return Val;
                        }
                }
        }
}
