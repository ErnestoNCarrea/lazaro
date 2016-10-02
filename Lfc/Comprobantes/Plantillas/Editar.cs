using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Plantillas
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                public enum MouseOperations
                { 
                        None,
                        KnobDrag,
                        ObjectDrag,
                        PageDrag
                }

                private Lbl.Impresion.Campo CampoSeleccionado;
                private int KnobSize = 32, GridSize = 10;
                private PointF Escala;
                private Point PosicionPagina = new Point(0, 0);
                private Point ButtonDown;
                private Rectangle CampoDown;
                private MouseOperations MouseOperation = MouseOperations.None;
                private float Zoom = 100;
                private Size TamanoPagina;
                private PointF EscalaMm = new PointF(300f / 25.4f, 300f / 25.4f);
                private Font FieldInfoFont = new Font("Arial", 7);
                private bool MostrarTextosDeEjemplo = true;

                private System.Drawing.Pen LapizBordeCampos = new Pen(Color.Silver, 1);
                private Brush BrushSeleccion = new SolidBrush(Color.FromArgb(150, SystemColors.Highlight));
                private Brush BrushKnob = new SolidBrush(Color.FromArgb(200, Color.Black));
                private Pen BrushKnobBorder = new Pen(Color.FromArgb(100, Color.White));

                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Impresion.Plantilla);

                        InitializeComponent();

                        LapizBordeCampos.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                        ZoomBar_Scroll(null, null);
                }


                /// <summary>
                /// Clean up any resources being used.
                /// </summary>
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                                LapizBordeCampos.Dispose();
                                BrushSeleccion.Dispose();
                                BrushKnob.Dispose();
                                BrushKnobBorder.Dispose();
                                FieldInfoFont.Dispose();
                        }

                        base.Dispose(disposing);
                }


                public override void ActualizarControl()
                {
                        Lbl.Impresion.Plantilla Plantilla = this.Elemento as Lbl.Impresion.Plantilla;

                        List<string> CodigosValidos = new List<string>();
                        foreach (string CodigoValido in EntradaCodigo.SetData) {
                                string[] Partes = CodigoValido.Split('|');
                                CodigosValidos.Add(Partes[1]);
                        }
                        if (CodigosValidos.Contains(Plantilla.Codigo)) {
                                EntradaCodigo.TextKey = Plantilla.Codigo;
                                EntradaCodigoPersonalizado.ReadOnly = true;
                                EntradaNombre.ReadOnly = true;
                        } else {
                                EntradaCodigo.TextKey = "*";
                                EntradaCodigoPersonalizado.Text = Plantilla.Codigo;
                                EntradaCodigoPersonalizado.ReadOnly = false;
                                EntradaNombre.ReadOnly = false;
                        }
                        EntradaNombre.Text = Plantilla.Nombre;
                        EntradaTipo.ValueInt = ((int)(Plantilla.Tipo));
                        EntradaPapelTamano.TextKey = Plantilla.TamanoPapel;
                        if (Plantilla.Font != null) {
                                Ingorar_EntradaFuenteFuenteTamano_TextChanged++;
                                EntradaFuente.TextKey = Plantilla.Font.Name;
                                EntradaFuenteTamano.ValueDecimal = System.Convert.ToDecimal(Plantilla.Font.Size);
                                Ingorar_EntradaFuenteFuenteTamano_TextChanged--;
                        } else {
                                Ingorar_EntradaFuenteFuenteTamano_TextChanged++;
                                EntradaFuente.TextKey = "*";
                                EntradaFuenteTamano.ValueDecimal = 10;
                                Ingorar_EntradaFuenteFuenteTamano_TextChanged--;
                        }
                        EntradaLandscape.TextKey = Plantilla.Landscape ? "1" : "0";

                        System.Drawing.Printing.Margins Margen = Plantilla.Margenes;
                        if (Margen == null) {
                                EntradaMargenes.TextKey = "0";
                        } else {
                                EntradaMargenes.TextKey = "1";
                                EntradaMargenIzquierda.ValueInt = Margen.Left;
                                EntradaMargenDerecha.ValueInt = Margen.Right;
                                EntradaMargenArriba.ValueInt = Margen.Top;
                                EntradaMargenAbajo.ValueInt = Margen.Bottom;
                        }
                        EntradaCopias.ValueInt = Plantilla.Copias;

                        EntradaFuenteFuenteTamano_TextChanged(this, null);

                        RecalcularTamanoVistaPrevia();
                        this.MostrarListaCampos();

                        base.ActualizarControl();
                }


                public override Lfx.Types.OperationResult ValidarControl()
                {
                        if (EntradaCodigoPersonalizado.Text == string.Empty)
                                return new Lfx.Types.FailureOperationResult("Debe escribir el código de la plantilla o seleccionar uno de la lista 'Se utiliza para'.");

                        if (EntradaNombre.Text == string.Empty)
                                return new Lfx.Types.FailureOperationResult("Debe escribir el nombre de la plantilla.");

                        string Codigo;
                        if (EntradaCodigo.TextKey == "*")
                                Codigo = EntradaCodigoPersonalizado.Text;
                        else
                                Codigo = EntradaCodigo.TextKey;

                        qGen.Select SelCodDupl = new qGen.Select("sys_plantillas");
                        SelCodDupl.Fields = "id_plantilla";
                        SelCodDupl.WhereClause = new qGen.Where();
                        SelCodDupl.WhereClause.AddWithValue("codigo", Codigo);
                        if (this.Elemento.Existe)
                                SelCodDupl.WhereClause.AddWithValue("id_plantilla", qGen.ComparisonOperators.NotEqual, this.Elemento.Id);
                        int OtroId = this.Connection.FieldInt(SelCodDupl);
                        if (OtroId > 0)
                                return new Lfx.Types.FailureOperationResult("Ya existe otra plantilla para este tipo de comprobante. No se permite tener más de una plantilla para el mismo tipo de comprobante. Si lo desea puede editar la plantilla existente.");

                        return base.ValidarControl();
                }


                public override void ActualizarElemento()
                {
                        Lbl.Impresion.Plantilla Plantilla = this.Elemento as Lbl.Impresion.Plantilla;

                        if (EntradaFuente.TextKey == "*" && EntradaFuenteTamano.ValueDecimal > 1)
                                Plantilla.Font = null;
                        else
                                Plantilla.Font = new Font(EntradaFuente.TextKey, (float)(EntradaFuenteTamano.ValueDecimal));

                        if (EntradaCodigo.TextKey == "*")
                                Plantilla.Codigo = EntradaCodigoPersonalizado.Text;
                        else
                                Plantilla.Codigo = EntradaCodigo.TextKey;
                        Plantilla.Nombre = EntradaNombre.Text;
                        Plantilla.Tipo = (Lbl.Impresion.TipoPlantilla)(EntradaTipo.ValueInt);
                        Plantilla.TamanoPapel = EntradaPapelTamano.TextKey;
                        Plantilla.Landscape = EntradaLandscape.ValueInt == 1;
                        Plantilla.Copias = EntradaCopias.ValueInt;

                        if (EntradaMargenes.TextKey == "1") {
                                Plantilla.Margenes = new System.Drawing.Printing.Margins(
                                        EntradaMargenIzquierda.ValueInt,
                                        EntradaMargenDerecha.ValueInt,
                                        EntradaMargenArriba.ValueInt,
                                        EntradaMargenAbajo.ValueInt);
                        } else {
                                Plantilla.Margenes = null;
                        }

                        base.ActualizarElemento();
                }


                public override void AfterSave(System.Data.IDbTransaction transaction)
                {
                        Lbl.Impresion.Plantilla.TodasPorCodigo.Clear();
                        base.AfterSave(transaction);
                }


                private void ImagePreview_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
                {
                        Lbl.Impresion.Plantilla Plantilla = this.Elemento as Lbl.Impresion.Plantilla;

                        e.Graphics.Clear(Color.Beige);
                        e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        e.Graphics.PageUnit = GraphicsUnit.Document;
                        e.Graphics.ScaleTransform(Zoom / 100f, Zoom / 100f);
                        e.Graphics.TranslateTransform(PosicionPagina.X, PosicionPagina.Y);

                        PointF[] Pts = new PointF[] { new Point(1000, 1000) };
                        e.Graphics.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace.Device, System.Drawing.Drawing2D.CoordinateSpace.Page, Pts);
                        this.Escala = new PointF(1000f / Pts[0].X, 1000f / Pts[0].Y);

                        if (Plantilla == null || Plantilla.Campos == null)
                                return;

                        System.Drawing.RectangleF RectPagina = new System.Drawing.RectangleF(0 * this.EscalaMm.X, 0 * this.EscalaMm.Y, TamanoPagina.Width * this.EscalaMm.X, TamanoPagina.Height * this.EscalaMm.Y);
                        e.Graphics.FillRectangle(Brushes.DarkGray, new System.Drawing.RectangleF(2 * this.EscalaMm.X, 2 * this.EscalaMm.Y, TamanoPagina.Width * this.EscalaMm.X, TamanoPagina.Height * this.EscalaMm.Y));
                        if (Plantilla.Imagen != null)
                                e.Graphics.DrawImage(Plantilla.Imagen, RectPagina);
                        else
                                e.Graphics.FillRectangle(Brushes.White, RectPagina);

                        foreach (Lbl.Impresion.Campo Cam in Plantilla.Campos) {
                                Rectangle DrawRect = Cam.Rectangle;

                                //Invierto rectángulos con ancho o alto negativo, para poder dibujarlos
                                if (DrawRect.Width < 0) {
                                        DrawRect.Width = Math.Abs(DrawRect.Width);
                                        DrawRect.X -= DrawRect.Width;
                                }
                                if (DrawRect.Height < 0) {
                                        DrawRect.Height = Math.Abs(DrawRect.Height);
                                        DrawRect.Y -= DrawRect.Height;
                                }

                                if (Cam.AnchoBorde > 0)
                                        e.Graphics.DrawRectangle(new Pen(Cam.ColorBorde, Cam.AnchoBorde), DrawRect);
                                else
                                        e.Graphics.DrawRectangle(LapizBordeCampos, DrawRect);

                                if (Cam.ColorFondo != Color.Transparent)
                                        e.Graphics.FillRectangle(new SolidBrush(Cam.ColorFondo), DrawRect);

                                System.Drawing.Font FuenteItem;
                                if (Cam.Font != null)
                                        FuenteItem = Cam.Font;
                                else
                                        FuenteItem = Plantilla.Font;

                                string Texto = Cam.Valor;

                                if (this.MostrarTextosDeEjemplo) {
                                        Texto = Texto.Replace("{Cliente}", "Nombre del cliente");
                                        Texto = Texto.Replace("{Cliente.Nombre}", "Nombre del cliente");
                                        Texto = Texto.Replace("{Cliente.Documento}", "20-20123456-6");
                                        Texto = Texto.Replace("{IVA}", "Responsable no inscripto");
                                        Texto = Texto.Replace("{Cliente.SituacionTributaria}", "Responsable no inscripto");
                                        Texto = Texto.Replace("{CUIT}", "30-12345678-9");
                                        Texto = Texto.Replace("{Cliente.ClaveTributaria}", "30-12345678-9");
                                        Texto = Texto.Replace("{Cliente.Cuit}", "Responsable no inscripto");
                                        Texto = Texto.Replace("{Domicilio}", "Avenida San Martín 1234, 3ro. B");
                                        Texto = Texto.Replace("{Cliente.Domicilio}", "Avenida San Martín 1234, 3ro. B");
                                        Texto = Texto.Replace("{Fecha}", System.DateTime.Now.ToString("dd-MM-yyyy"));
                                        Texto = Texto.Replace("{FormaPago}", "Cuenta corriente");
                                        Texto = Texto.Replace("{Total}", "$ 123.456.789,00");
                                        Texto = Texto.Replace("{SubTotal}", "$ 123.456.789,00");
                                        Texto = Texto.Replace("{IvaDiscriminado}", "$ 123.456,00");
                                        Texto = Texto.Replace("{SonPesos}", "ciento veintitres mil seiscientos setenta y ocho con 00/100");
                                        Texto = Texto.Replace("{Articulos.Codigos}", "00123456\r\n00123456\r\nABR012PM\r\nCODIGO99");
                                        Texto = Texto.Replace("{Codigos}", "00123456\r\n00123456\r\nABR012PM\r\nCODIGO99");
                                        Texto = Texto.Replace("{Articulos.Cantidades}", "1\r\n2\r\n1\r\n1");
                                        Texto = Texto.Replace("{Articulos.Descuentos}", "--\r\n--\r\n10%\r\n--");
                                        Texto = Texto.Replace("{Cantidades}", "1\r\n2\r\n1\r\n1");
                                        Texto = Texto.Replace("{Articulos.Precios}", "$ 123.456,00\r\n$ 123.456,00\r\n$ 123.456,00\r\n$ 123.456,00");
                                        Texto = Texto.Replace("{Precios}", "$ 123.456,00\r\n$ 123.456,00\r\n$ 123.456,00\r\n$ 123.456,00");
                                        Texto = Texto.Replace("{Articulos.Unitarios}", "$ 123.456,00\r\n$ 123.456,00\r\n$ 123.456,00\r\n$ 123.456,00");
                                        Texto = Texto.Replace("{Articulos.Importes}", "$ 123.456,00\r\n$ 123.456,00\r\n$ 123.456,00\r\n$ 123.456,00");
                                        Texto = Texto.Replace("{Importes}", "$ 123.456,00\r\n$ 123.456,00\r\n$ 123.456,00\r\n$ 123.456,00");
                                        Texto = Texto.Replace("{Articulos.Detalles}", "Producto de ejemplo Nº 1\r\nProducto de ejemplo Nº 2\r\nProducto de ejemplo Nº 3\r\nProducto de ejemplo Nº 4");
                                        Texto = Texto.Replace("{Detalles}", "Producto de ejemplo Nº 1\r\nProducto de ejemplo Nº 2\r\nProducto de ejemplo Nº 3\r\nProducto de ejemplo Nº 4");
                                        Texto = Texto.Replace("{Valores}", "Efectivo        : $ 100.\r\nCheque          : $ 100.\r\nTarjeta de Déb. : $ 100.\r\nTarjeta de Cré. : $ 100.");
                                        Texto = Texto.Replace("{Tipo}", "Nota de crédito");
                                        Texto = Texto.Replace("{Numero}", "1234");
                                        Texto = Texto.Replace("{espejo}", "Esta es una zona especial en la cual se imprime un duplicado del comprobante.");
                                }

                                StringFormat StrFmt = new StringFormat(StringFormatFlags.NoClip);
                                StrFmt.Trimming = StringTrimming.None;
                                StrFmt.Alignment = Cam.Alignment;
                                StrFmt.LineAlignment = Cam.LineAlignment;

                                if (FuenteItem == null)
                                        FuenteItem = Lazaro.Pres.DisplayStyles.Template.Current.DefaultFont;
                                e.Graphics.DrawString(Texto, FuenteItem, new SolidBrush(Cam.ColorTexto), DrawRect, StrFmt);

                                if (CampoSeleccionado == Cam) {
                                        e.Graphics.FillRectangle(BrushSeleccion, DrawRect);

                                        string Lbl = DrawRect.Location.ToString();
                                        RectangleF LabelRect = new RectangleF(new PointF(DrawRect.X + 10, DrawRect.Y + DrawRect.Height + 11), e.Graphics.MeasureString(Lbl, FieldInfoFont));
                                        LabelRect.Inflate(10, 10);
                                        e.Graphics.FillRectangle(SystemBrushes.Info, LabelRect);
                                        StrFmt = new StringFormat(StringFormatFlags.NoClip);
                                        StrFmt.Alignment = StringAlignment.Center;
                                        StrFmt.LineAlignment = StringAlignment.Center;
                                        e.Graphics.DrawString(Lbl, FieldInfoFont, SystemBrushes.InfoText, LabelRect, StrFmt);

                                        Rectangle RectKnob = new Rectangle(Cam.Rectangle.Right - KnobSize / 2, Cam.Rectangle.Bottom - KnobSize / 2, KnobSize, KnobSize);
                                        e.Graphics.FillEllipse(BrushKnob, RectKnob);
                                        e.Graphics.DrawEllipse(BrushKnobBorder, RectKnob);
                                }
                        }
                }


                private void ListaCampos_SelectedIndexChanged(object sender, System.EventArgs e)
                {
                        Lbl.Impresion.Plantilla Plantilla = this.Elemento as Lbl.Impresion.Plantilla;

                        if (Plantilla.Campos != null && ListaCampos.SelectedItems.Count > 0) {
                                CampoSeleccionado = ListaCampos.SelectedItems[0].Tag as Lbl.Impresion.Campo;
                        } else {
                                CampoSeleccionado = null;
                        }

                        ImagePreview.Invalidate();
                }

                private Point PuntoDesdePantalla(Point pt)
                {
                        return PuntoDesdePantalla(pt, true);
                }

                private Point PuntoDesdePantalla(Point pt, bool usarGrilla)
                {
                        Point Res = new Point(System.Convert.ToInt32(pt.X * this.Escala.X / (this.Zoom / 100F)), System.Convert.ToInt32(pt.Y * this.Escala.Y / (this.Zoom / 100F)));
                        Res.Offset(-PosicionPagina.X, -PosicionPagina.Y);
                        if (usarGrilla) {
                                Res.X = System.Convert.ToInt32(Res.X / this.GridSize) * this.GridSize;
                                Res.Y = System.Convert.ToInt32(Res.Y / this.GridSize) * this.GridSize;
                        }
                        return Res;
                }


                private void ImagePreview_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
                {
                        if (e.Delta != 0) {
                                float NewZoom = this.Zoom + (e.Delta / 10f);
                                if (NewZoom < ZoomBar.Minimum)
                                        NewZoom = ZoomBar.Minimum;
                                else if (NewZoom > ZoomBar.Maximum)
                                        NewZoom = ZoomBar.Maximum;

                                this.ChangeZoom((int)NewZoom, e.Location);
                        }
                }


                private void ChangeZoom(int newZoom, Point from)
                {
                        if (newZoom != this.Zoom) {
                                // Si no si especifica un punto, se asume el centro de la imagen
                                if (from == Point.Empty)
                                        from = new Point(ImagePreview.ClientRectangle.Width / 2, ImagePreview.ClientRectangle.Height / 2);


                                // Posición relativa del mouse, dentro de la página
                                //Point PosPagina = this.PosicionPagina;
                                //Point PosRelMouse = new Point(from.X - PosPagina.X, from.Y - PosPagina.Y);
                                //Point NuevaPosRelMouse = new Point(Convert.ToInt32(PosRelMouse.X / this.Zoom * newZoom), Convert.ToInt32(PosRelMouse.Y / this.Zoom * newZoom));

                                this.Zoom = newZoom;
                                //this.PosicionPagina = NuevaPosicionPagina;

                                if (ZoomBar.Value != newZoom)
                                        ZoomBar.Value = newZoom;

                                RecalcularTamanoVistaPrevia();
                        }
                }


                private void ImagePreview_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
                {
                        if (e.Button == System.Windows.Forms.MouseButtons.Middle) {
                                ButtonDown = new Point(e.X, e.Y);
                                MouseOperation = MouseOperations.PageDrag;
                        } else if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                                ButtonDown = PuntoDesdePantalla(new Point(e.X, e.Y));
                                Point MyButtonDown = PuntoDesdePantalla(new Point(e.X, e.Y), false);

                                //Lbl.Impresion.Campo CampoSeleccionadoOriginal = CampoSeleccionado;
                                if (CampoSeleccionado != null) {
                                        Rectangle RectKnob = new Rectangle(CampoSeleccionado.Rectangle.Right - KnobSize / 2, CampoSeleccionado.Rectangle.Bottom - KnobSize / 2, KnobSize, KnobSize);
                                        if (CampoSeleccionado != null && RectKnob.Contains(MyButtonDown)) {
                                                //Agarró el knob
                                                MouseOperation = MouseOperations.KnobDrag;
                                                return;
                                        } else {
                                                MouseOperation = MouseOperations.None;
                                        }
                                }

                                Lbl.Impresion.Plantilla Plantilla = this.Elemento as Lbl.Impresion.Plantilla;

                                bool Select = false;
                                CampoSeleccionado = null;
                                foreach (Lbl.Impresion.Campo Cam in Plantilla.Campos) {
                                        //Busco el campo del clic (según coordenadas)
                                        if (Cam.Valor == null || Cam.Valor.Length == 0 && Cam.AnchoBorde > 0) {
                                                //En el caso particular de los rectángulos con borde y sin texto, tiene que hacer clic en el contorno
                                                if ((MyButtonDown.X >= (Cam.Rectangle.Left - 5) && (MyButtonDown.X <= (Cam.Rectangle.Left + 5)) ||
                                                        MyButtonDown.X >= (Cam.Rectangle.Right - 5) && (MyButtonDown.X <= (Cam.Rectangle.Right + 5)) ||
                                                        MyButtonDown.Y >= (Cam.Rectangle.Top - 5) && (MyButtonDown.Y <= (Cam.Rectangle.Top + 5)) ||
                                                        MyButtonDown.Y >= (Cam.Rectangle.Bottom - 5) && (MyButtonDown.Y <= (Cam.Rectangle.Bottom + 5)))) {
                                                        Select = true;
                                                        MouseOperation = MouseOperations.ObjectDrag;
                                                } else {
                                                        Select = false;
                                                        MouseOperation = MouseOperations.None;
                                                }
                                        } else if (Cam.Rectangle.Contains(MyButtonDown)) {
                                                //El resto de los campos, se seleccionan haciendo clic en cualquier parte del rectángulo
                                                Select = true;
                                                MouseOperation = MouseOperations.ObjectDrag;
                                        }

                                        if (Select) {
                                                //Encontré el campo del Click
                                                //Lo selecciono mediante la listview
                                                CampoSeleccionado = Cam;
                                                this.SeleccionarCampo(Cam);
                                                MouseOperation = MouseOperations.ObjectDrag;
                                                break;
                                        }
                                }

                                //if (CampoSeleccionado == null)
                                //        CampoSeleccionado = CampoSeleccionadoOriginal;

                                if (CampoSeleccionado == null) {
                                        this.SeleccionarCampo(null);
                                        ButtonDown = new Point(e.X, e.Y);
                                        MouseOperation = MouseOperations.PageDrag;
                                } else {
                                        CampoDown = CampoSeleccionado.Rectangle;
                                }
                        } else if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                                this.MostrarTextosDeEjemplo = !this.MostrarTextosDeEjemplo;
                                ImagePreview.Invalidate();
                        }
                }

                private void ImagePreview_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
                {
                        if (e.Button == System.Windows.Forms.MouseButtons.Left || e.Button == System.Windows.Forms.MouseButtons.Middle) {
                                switch (MouseOperation) {
                                        case MouseOperations.KnobDrag:
                                                if (CampoSeleccionado != null) {
                                                        //Point NewCampoPos = new Point(CampoDown.Right, CampoDown.Bottom);
                                                        Point PosCursor = PuntoDesdePantalla(new Point(e.X, e.Y));
                                                        PosCursor.X -= CampoSeleccionado.Rectangle.Left;
                                                        PosCursor.Y -= CampoSeleccionado.Rectangle.Top;
                                                        CampoSeleccionado.Rectangle.Width = PosCursor.X;
                                                        CampoSeleccionado.Rectangle.Height = PosCursor.Y;
                                                        ImagePreview.Invalidate();
                                                }
                                                break;
                                        case MouseOperations.PageDrag:
                                                Point OldDesplazamiento = this.PosicionPagina;
                                                this.PosicionPagina = new Point(0, 0);
                                                Point Diferencia = PuntoDesdePantalla(new Point(e.X - ButtonDown.X, e.Y - ButtonDown.Y), false);
                                                this.PosicionPagina = OldDesplazamiento;
                                                this.PosicionPagina.Offset(Diferencia);
                                                ButtonDown = new Point(e.X, e.Y);
                                                ImagePreview.Invalidate();
                                                break;
                                        case MouseOperations.ObjectDrag:
                                                if (CampoSeleccionado != null) {
                                                        Point NewCampoPos = CampoDown.Location;
                                                        Point PosCursor = PuntoDesdePantalla(new Point(e.X, e.Y));
                                                        NewCampoPos.Offset(PosCursor.X - ButtonDown.X, PosCursor.Y - ButtonDown.Y);
                                                        CampoSeleccionado.Rectangle.Location = NewCampoPos;
                                                        ImagePreview.Invalidate();
                                                }
                                                break;
                                }
                        }
                }

                private void EntradaPapelTamano_TextChanged(object sender, System.EventArgs e)
                {
                        Lbl.Impresion.Plantilla Plantilla = this.Elemento as Lbl.Impresion.Plantilla;

                        Plantilla.TamanoPapel = EntradaPapelTamano.TextKey;
                        Plantilla.Landscape = EntradaLandscape.TextKey == "1";

                        RecalcularTamanoVistaPrevia();
                }

                private static System.Drawing.Size ObtenerTamanoPapel(string tipoPapel)
                {
                        switch (tipoPapel.ToLower()) {
                                case "a4":
                                        return new System.Drawing.Size(210, 297);
                                case "a5":
                                        return new System.Drawing.Size(148, 210);
                                case "letter":
                                        return new System.Drawing.Size(216, 279);
                                case "legal":
                                        return new System.Drawing.Size(216, 356);
                                case "cont":
                                        return new System.Drawing.Size(216, 305);
                                default:
                                        //Predeterminado A4
                                        return new System.Drawing.Size(210, 297);
                        }
                }

                private void ListaCampos_DoubleClick(object sender, System.EventArgs e)
                {
                        EditarCampoSeleccionado();
                }


                private void ImagePreview_DoubleClick(object sender, System.EventArgs e)
                {
                        EditarCampoSeleccionado();
                }


                private void EditarCampoSeleccionado()
                {
                        if (CampoSeleccionado != null) {
                                EditarCampo FormEditarCampo = new EditarCampo(CampoSeleccionado);
                                if (FormEditarCampo.ShowDialog() == DialogResult.OK) {
                                        this.ActualizarCampos();
                                        ImagePreview.Invalidate();
                                }
                        }
                }


                private void BotonAgregar_Click(object sender, EventArgs e)
                {
                        Lbl.Impresion.Plantilla Plantilla = this.Elemento as Lbl.Impresion.Plantilla;

                        Lbl.Impresion.Campo Cam = new Lbl.Impresion.Campo();
                        Cam.Valor = "Nuevo campo";
                        Cam.Rectangle = new Rectangle(10, 10, 280, 52);
                        Plantilla.Campos.Add(Cam);
                        this.AgregarCampo(Cam);
                        this.SeleccionarCampo(Cam);
                        ListaCampos_DoubleClick(sender, e);
                        ImagePreview.Invalidate();
                }

                private void SeleccionarCampo(Lbl.Impresion.Campo campo)
                {
                        foreach (ListViewItem Itm in ListaCampos.Items) {
                                if (Itm.Tag == campo) {
                                        Itm.Selected = true;
                                        Itm.EnsureVisible();
                                } else {
                                        Itm.Selected = false;
                                }
                        }
                }

                private void MostrarListaCampos()
                {
                        Lbl.Impresion.Plantilla Plantilla = this.Elemento as Lbl.Impresion.Plantilla;

                        ListaCampos.BeginUpdate();
                        ListaCampos.Items.Clear();
                        if (Plantilla.Campos != null) {
                                foreach (Lbl.Impresion.Campo Cam in Plantilla.Campos) {
                                        AgregarCampo(Cam);
                                }
                        }
                        ListaCampos.EndUpdate();
                }

                private void AgregarCampo(Lbl.Impresion.Campo campo)
                {
                        ListViewItem Itm = ListaCampos.Items.Add(campo.Valor);
                        Itm.Tag = campo;
                }

                private void ActualizarCampos()
                {
                        foreach (ListViewItem Itm in ListaCampos.Items) {
                                Lbl.Impresion.Campo Cam = Itm.Tag as Lbl.Impresion.Campo;
                                if (Cam != null) {
                                        Itm.Text = Cam.Valor;
                                }
                        }
                }


                private void BotonQuitar_Click(object sender, EventArgs e)
                {
                        if (CampoSeleccionado != null) {
                                Lbl.Impresion.Plantilla Plantilla = this.Elemento as Lbl.Impresion.Plantilla;

                                Plantilla.Campos.Remove(CampoSeleccionado);
                                this.MostrarListaCampos();
                                ImagePreview.Invalidate();
                        }
                }


                private int Ingorar_EntradaFuenteFuenteTamano_TextChanged = 0;
                private void EntradaFuenteFuenteTamano_TextChanged(object sender, EventArgs e)
                {
                        if (Ingorar_EntradaFuenteFuenteTamano_TextChanged > 0)
                                return;

                        Lbl.Impresion.Plantilla Plantilla = this.Elemento as Lbl.Impresion.Plantilla;

                        EntradaFuenteTamano.Enabled = (EntradaFuente.TextKey != "*");
                        if (EntradaFuente.TextKey != "*" && EntradaFuenteTamano.ValueDecimal > 0)
                                Plantilla.Font = new Font(EntradaFuente.TextKey, ((float)(EntradaFuenteTamano.ValueDecimal)));
                        else
                                Plantilla.Font = new Font("Courier New", 10);
                }

                private void ZoomBar_Scroll(object sender, EventArgs e)
                {
                        this.ChangeZoom(ZoomBar.Value, Point.Empty);
                }

                public void RecalcularTamanoVistaPrevia()
                {
                        Lbl.Impresion.Plantilla Plantilla = this.Elemento as Lbl.Impresion.Plantilla;

                        if (Plantilla == null)
                                return;

                        TamanoPagina = ObtenerTamanoPapel(Plantilla.TamanoPapel);
                        if (Plantilla.Landscape)
                                TamanoPagina = new Size(TamanoPagina.Height, TamanoPagina.Width);

                        ImagePreview.Invalidate();
                }

                private Lfx.Types.OperationResult Guardar()
                {
                        Lbl.Impresion.Plantilla Plantilla = this.Elemento as Lbl.Impresion.Plantilla;

                        SaveFileDialog FileDialog = new SaveFileDialog();
                        FileDialog.CheckFileExists = false;
                        FileDialog.CheckPathExists = true;
                        FileDialog.InitialDirectory = System.IO.Path.Combine(Lfx.Environment.Folders.UserFolder, "Plantillas");
                        FileDialog.Title = "Guardar plantilla";
                        FileDialog.ValidateNames = true;
                        switch ((Lbl.Impresion.TipoPlantilla)(EntradaTipo.ValueInt)) {
                                case Lbl.Impresion.TipoPlantilla.Pdf:
                                        FileDialog.Filter = "Archivos PDF|*.pdf";
                                        FileDialog.DefaultExt = "pdf";
                                        break;
                                default:
                                        FileDialog.Filter = "Archivos de plantilla|*.ltx";
                                        FileDialog.DefaultExt = "ltx";
                                        break;
                        }
                        FileDialog.FileName = Plantilla.ToString();
                        if (FileDialog.ShowDialog() == DialogResult.OK) {
                                switch ((Lbl.Impresion.TipoPlantilla)(EntradaTipo.ValueInt)) {
                                        case Lbl.Impresion.TipoPlantilla.Pdf:
                                                using (System.IO.FileStream Str = new System.IO.FileStream(FileDialog.FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write, System.IO.FileShare.None))
                                                using (System.IO.BinaryWriter Wrtr = new System.IO.BinaryWriter(Str)) {
                                                        Wrtr.Write(Plantilla.Archivo);
                                                        Wrtr.Close();
                                                        Str.Close();
                                                }
                                                break;
                                        default:
                                                using (System.IO.StreamWriter Str = new System.IO.StreamWriter(FileDialog.FileName, false)) {
                                                        Str.Write(Plantilla.Definicion.InnerXml);
                                                        Str.Close();
                                                }
                                                break;
                                }
                                return new Lfx.Types.SuccessOperationResult();
                        } else {
                                return new Lfx.Types.CancelOperationResult();
                        }
                }

                private Lfx.Types.OperationResult Cargar()
                {
                        Lbl.Impresion.Plantilla Plantilla = this.Elemento as Lbl.Impresion.Plantilla;

                        using (var DialogoCargarArchivo = new OpenFileDialog()) {
                                DialogoCargarArchivo.CheckFileExists = true;
                                DialogoCargarArchivo.CheckPathExists = true;
                                DialogoCargarArchivo.InitialDirectory = System.IO.Path.Combine(Lfx.Environment.Folders.UserFolder, "Plantillas");
                                DialogoCargarArchivo.Multiselect = false;
                                DialogoCargarArchivo.Title = "Cargar plantilla";
                                DialogoCargarArchivo.ValidateNames = true;

                                switch ((Lbl.Impresion.TipoPlantilla)(EntradaTipo.ValueInt)) {
                                        case Lbl.Impresion.TipoPlantilla.Pdf:
                                                DialogoCargarArchivo.Filter = "Archivos PDF|*.pdf";
                                                DialogoCargarArchivo.DefaultExt = "pdf";
                                                break;
                                        default:
                                                DialogoCargarArchivo.Filter = "Archivos de plantilla|*.ltx";
                                                DialogoCargarArchivo.DefaultExt = "ltx";
                                                break;
                                }
                                if (DialogoCargarArchivo.ShowDialog() == DialogResult.OK && DialogoCargarArchivo.FileName != null && DialogoCargarArchivo.FileName.Length > 0) {
                                        switch ((Lbl.Impresion.TipoPlantilla)(EntradaTipo.ValueInt)) {
                                                case Lbl.Impresion.TipoPlantilla.Pdf:
                                                        int TotalBytes = (int)(new System.IO.FileInfo(DialogoCargarArchivo.FileName).Length);
                                                        using (System.IO.FileStream Str = new System.IO.FileStream(DialogoCargarArchivo.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read))
                                                        using (System.IO.BinaryReader Rdr = new System.IO.BinaryReader(Str)) {
                                                                Plantilla.Archivo = Rdr.ReadBytes(TotalBytes);
                                                                Rdr.Close();
                                                                Str.Close();
                                                        }
                                                        break;
                                                default:
                                                        using (System.IO.StreamReader Str = new System.IO.StreamReader(DialogoCargarArchivo.FileName, true)) {
                                                                Plantilla.CargarXml(Str.ReadToEnd());
                                                                Str.Close();
                                                        }
                                                        break;
                                        }
                                        this.MostrarListaCampos();
                                        BotonDiseno.PerformClick();
                                        ImagePreview.Invalidate();
                                        return new Lfx.Types.SuccessOperationResult();
                                } else {
                                        return new Lfx.Types.CancelOperationResult();
                                }
                        }
                }

                private void ImagePreview_MouseUp(object sender, MouseEventArgs e)
                {
                        if (CampoSeleccionado != null) {
                                if (CampoSeleccionado.Rectangle.Width < 0) {
                                        CampoSeleccionado.Rectangle.Width = Math.Abs(CampoSeleccionado.Rectangle.Width);
                                        CampoSeleccionado.Rectangle.X -= CampoSeleccionado.Rectangle.Width;
                                }
                                if (CampoSeleccionado.Rectangle.Height < 0) {
                                        CampoSeleccionado.Rectangle.Height = Math.Abs(CampoSeleccionado.Rectangle.Height);
                                        CampoSeleccionado.Rectangle.Y -= CampoSeleccionado.Rectangle.Height;
                                }
                                ImagePreview.Invalidate();
                        }
                        MouseOperation = MouseOperations.None;
                }


                private void Editar_KeyDown(object sender, KeyEventArgs e)
                {
                        if (e.KeyCode == Keys.Delete && e.Alt == false && e.Control == false && e.Shift == false) {
                                BotonQuitar.PerformClick();
                        }
                }


                private void EntradaMargenes_TextChanged(object sender, EventArgs e)
                {
                        EntradaMargenIzquierda.Visible = EntradaMargenes.TextKey == "1";
                        EntradaMargenDerecha.Visible = EntradaMargenIzquierda.Visible;
                        EntradaMargenArriba.Visible = EntradaMargenIzquierda.Visible;
                        EntradaMargenAbajo.Visible = EntradaMargenIzquierda.Visible;
                }


                public override Lazaro.Pres.DisplayStyles.IDisplayStyle HeaderDisplayStyle
                {
                        get
                        {
                                return Lazaro.Pres.DisplayStyles.Template.Current.Comprobantes;
                        }
                }


                public override Lazaro.Pres.Forms.FormActionCollection GetFormActions()
                {
                        Lazaro.Pres.Forms.FormActionCollection Res = base.GetFormActions();
                        Res.Add(new Lazaro.Pres.Forms.FormAction("Guardar", "F4", "guardar", 20, Lazaro.Pres.Forms.FormActionVisibility.Secondary));
                        Res.Add(new Lazaro.Pres.Forms.FormAction("Cargar", "F5", "cargar", 10, Lazaro.Pres.Forms.FormActionVisibility.Secondary));
                        return Res;
                }


                public override Lfx.Types.OperationResult PerformFormAction(string name)
                {
                        switch (name) {
                                case "guardar":
                                        return Guardar();
                                case "cargar":
                                        return Cargar();
                                default:
                                        return base.PerformFormAction(name);
                        }
                }

                private void BotonGeneral_Click(object sender, EventArgs e)
                {
                        PanelGeneral.Visible = true;
                        PanelDiseno.Visible = false;
                }

                private void BotonDiseno_Click(object sender, EventArgs e)
                {
                        PanelGeneral.Visible = false;
                        PanelDiseno.Visible = true;
                }

                private void ImagePreview_MouseEnter(object sender, EventArgs e)
                {
                        ImagePreview.Focus();
                }

                private void EntradaCodigo_TextChanged(object sender, EventArgs e)
                {
                        if(EntradaCodigo.TextKey == "*") {
                                EntradaCodigoPersonalizado.ReadOnly = false;
                                EntradaNombre.ReadOnly = false;
                        } else {
                                EntradaCodigoPersonalizado.ReadOnly = true;
                                EntradaNombre.ReadOnly = true;
                                EntradaCodigoPersonalizado.Text = EntradaCodigo.TextKey;
                                EntradaNombre.Text = EntradaCodigo.Text;
                        }
                }

                private void EntradaTipo_TextChanged(object sender, EventArgs e)
                {
                        switch ((Lbl.Impresion.TipoPlantilla)(EntradaTipo.ValueInt)) {
                                case Lbl.Impresion.TipoPlantilla.Pdf:
                                        BotonDiseno.Enabled = false;
                                        break;
                                default:
                                        BotonDiseno.Enabled = true;
                                        break;
                        }

                        EntradaFuente.Enabled = BotonDiseno.Enabled;
                        EntradaFuenteTamano.Enabled = BotonDiseno.Enabled;
                }
        }
}
