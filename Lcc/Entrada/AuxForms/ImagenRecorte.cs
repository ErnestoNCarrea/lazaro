using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lcc.Entrada.AuxForms
{
        public partial class ImagenRecorte : Lui.Forms.DialogForm
        {
                public enum MouseActions
                {
                        None,
                        Draw,
                        Drag
                }

                private System.Drawing.Rectangle CropRect = System.Drawing.Rectangle.Empty;
                private System.Drawing.Point StartPoint = System.Drawing.Point.Empty;
                private System.Drawing.Brush SelectionBrush = null;
                private Rectangle RectImagen;
                private double UsarZoom;
                private System.Drawing.Image m_Imagen = null;
                private decimal SelectionRatio = 0;
                private MouseActions MouseAction = MouseActions.None;

                public ImagenRecorte()
                {
                        InitializeComponent();
                }


                /// <summary>
                /// Limpiar los recursos que se estén utilizando.
                /// </summary>
                /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null)
                                        components.Dispose();
                                if (SelectionBrush != null)
                                        SelectionBrush.Dispose();
                        }
                        base.Dispose(disposing);
                }


                public System.Drawing.Image Imagen
                {
                        set
                        {
                                m_Imagen = value;
                        }
                        get
                        {
                                return this.m_Imagen;
                        }
                }


                private void EntradaImagen_MouseDown(object sender, MouseEventArgs e)
                {
                        switch (e.Button) {
                                case MouseButtons.Left:
                                        if (CropRect.Contains(e.Location)) {
                                                MouseAction = MouseActions.Drag;
                                                StartPoint.X = e.X - CropRect.X;
                                                StartPoint.Y = e.Y - CropRect.Y;
                                        } else {
                                                MouseAction = MouseActions.Draw;
                                                StartPoint = e.Location;
                                        }
                                        break;
                                case MouseButtons.Middle:
                                        MouseAction = MouseActions.Drag;
                                        StartPoint.X = e.X - CropRect.X;
                                        StartPoint.Y = e.Y - CropRect.Y;
                                        break;
                        }
                }

                private void EntradaImagen_MouseMove(object sender, MouseEventArgs e)
                {
                        if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Middle) {
                                switch (MouseAction) {
                                        case MouseActions.Draw:
                                                CropRect = RectangleFromPoints(StartPoint, e.Location);
                                                if (this.SelectionRatio != 0) {
                                                        CropRect.Width = System.Convert.ToInt32(CropRect.Height * SelectionRatio);
                                                }
                                                EntradaImagen.Invalidate();
                                                break;
                                        case MouseActions.Drag:
                                                CropRect.X = e.X - StartPoint.X;
                                                CropRect.Y = e.Y - StartPoint.Y;
                                                EntradaImagen.Invalidate();
                                                break;
                                }
                        }
                }

                private System.Drawing.Rectangle RectangleFromPoints(Point p1, Point p2) 
                {
                        int X, Y;

                        if(p1.X <= p2.X)
                            X = p1.X;
                        else
                            X = p2.X;

                        if(p1.Y <= p2.Y)
                            Y = p1.Y;
                        else
                            Y = p2.Y;

                        return new Rectangle(X, Y, Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
                }

                private void EntradaImagen_Paint(object sender, PaintEventArgs e)
                {
                        if (Imagen != null) {
                                if (SelectionBrush == null)
                                        SelectionBrush = new SolidBrush(Color.FromArgb(50, Color.White));

                                double ZoomAncho = System.Convert.ToDouble(EntradaImagen.ClientRectangle.Width) / System.Convert.ToDouble(this.Imagen.Size.Width);
                                double ZoomAlto = System.Convert.ToDouble(EntradaImagen.ClientRectangle.Height) / System.Convert.ToDouble(this.Imagen.Size.Height);
                                if (this.Imagen.Height * ZoomAncho > EntradaImagen.ClientRectangle.Height) {
                                        // Usando a todo el ancho se pasa de alto
                                        UsarZoom = ZoomAlto;
                                } else {
                                        UsarZoom = ZoomAncho;
                                }

                                Size TamImagen = new Size(System.Convert.ToInt32(this.Imagen.Width * UsarZoom), System.Convert.ToInt32(this.Imagen.Height * UsarZoom));
                                Point UbicImagen = new Point((EntradaImagen.ClientRectangle.Width - TamImagen.Width) / 2,(EntradaImagen.ClientRectangle.Height - TamImagen.Height) / 2);
                                RectImagen = new Rectangle(UbicImagen, TamImagen);
                                this.Text = UsarZoom.ToString();
                                
                                e.Graphics.DrawImage(Imagen, RectImagen);
                                if (CropRect != System.Drawing.Rectangle.Empty) {
                                        e.Graphics.FillRectangle(SelectionBrush, CropRect);
                                        e.Graphics.DrawRectangle(Pens.Black, CropRect);
                                }
                        }
                }

                public override Lfx.Types.OperationResult  Ok()
{
                        if(CropRect != System.Drawing.Rectangle.Empty) {
                                Bitmap Target = new Bitmap(System.Convert.ToInt32(CropRect.Width / UsarZoom), System.Convert.ToInt32(CropRect.Height / UsarZoom));
                                System.Drawing.Rectangle CropRectZoomed = new System.Drawing.Rectangle(
                                        System.Convert.ToInt32((CropRect.X - RectImagen.Left) / UsarZoom), System.Convert.ToInt32((CropRect.Y - RectImagen.Top) / UsarZoom),
                                        System.Convert.ToInt32(CropRect.Width / UsarZoom), System.Convert.ToInt32(CropRect.Height / UsarZoom)
                                        );
                                using (Graphics g = Graphics.FromImage(Target)) {
                                        Bitmap Source = m_Imagen as Bitmap;
                                        g.DrawImage(Source, new Rectangle(0, 0, Target.Width, Target.Height), CropRectZoomed, GraphicsUnit.Pixel);
                                }
                                m_Imagen = Target;
                        }
                        return base.Ok();
                }

                private void EntradaRatio_TextChanged(object sender, EventArgs e)
                {
                        if (EntradaRatio.TextKey == "-1") {
                                this.CropRect = System.Drawing.Rectangle.Empty;
                                this.SelectionRatio = -1;
                        } else {
                                this.SelectionRatio = Lfx.Types.Parsing.ParseDecimal(EntradaRatio.TextKey);
                                CropRect.Width = System.Convert.ToInt32(CropRect.Height * SelectionRatio);
                        }
                        EntradaImagen.Invalidate();
                }


                private void CopiarAlPortapapelesToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        try {
                                System.Windows.Forms.Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, EntradaImagen.Image);
                        } catch {
                                // Nada
                        }
                }

                private void GuardarEnUnArchivoToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        System.Windows.Forms.SaveFileDialog Guardar = new SaveFileDialog();
                        Guardar.DefaultExt = ".jpg";
                        Guardar.Filter = "Imagen JPEG|*.jpg";
                        if (Guardar.ShowDialog() == DialogResult.OK) {
                                EntradaImagen.Image.Save(Guardar.FileName);
                        }
                }

                private void EntradaImagen_MouseUp(object sender, MouseEventArgs e)
                {
                        MouseAction = MouseActions.None;
                }

                private void BotonRotarDer_Click(object sender, EventArgs e)
                {
                        this.Imagen.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        this.EntradaImagen.Invalidate();
                }

                private void BotonRotarIzq_Click(object sender, EventArgs e)
                {
                        this.Imagen.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        this.EntradaImagen.Invalidate();
                }
        }
}
