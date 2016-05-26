using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Lui.Forms
{
        /// <summary>
        /// Descripción breve de Chart.
        /// </summary>
        public class Chart : System.Windows.Forms.UserControl, IControl, IDisplayStyleControl
        {
                /// <summary> 
                /// Variable del diseñador requerida.
                /// </summary>
                private System.ComponentModel.IContainer components = null;

                public Chart()
                {
                        // Llamada necesaria para el Diseñador de formularios Windows.Forms.
                        InitializeComponent();
                }

                /// <summary> 
                /// Limpiar los recursos que se estén utilizando.
                /// </summary>
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }
                        base.Dispose(disposing);
                }

                #region Código generado por el Diseñador de componentes
                /// <summary> 
                /// Método necesario para admitir el Diseñador. No se puede modificar 
                /// el contenido del método con el editor de código.
                /// </summary>
                private void InitializeComponent()
                {
                        this.ChartPic = new System.Windows.Forms.PictureBox();
                        this.TitleLabel = new Lui.Forms.Label();
                        ((System.ComponentModel.ISupportInitialize)(this.ChartPic)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // ChartPic
                        // 
                        this.ChartPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.ChartPic.BackColor = System.Drawing.Color.White;
                        this.ChartPic.Location = new System.Drawing.Point(4, 32);
                        this.ChartPic.Name = "ChartPic";
                        this.ChartPic.Size = new System.Drawing.Size(440, 204);
                        this.ChartPic.TabIndex = 1;
                        this.ChartPic.TabStop = false;
                        this.ChartPic.Click += new System.EventHandler(this.ChartPic_Click);
                        this.ChartPic.Paint += new System.Windows.Forms.PaintEventHandler(this.ChartPic_Paint);
                        // 
                        // TitleLabel
                        // 
                        this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
                        this.TitleLabel.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        this.TitleLabel.Location = new System.Drawing.Point(0, 0);
                        this.TitleLabel.Name = "TitleLabel";
                        this.TitleLabel.Size = new System.Drawing.Size(448, 32);
                        this.TitleLabel.TabIndex = 2;
                        this.TitleLabel.Text = "Title";
                        this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // Chart
                        // 
                        this.BackColor = System.Drawing.Color.White;
                        this.Controls.Add(this.TitleLabel);
                        this.Controls.Add(this.ChartPic);
                        this.Name = "Chart";
                        this.Size = new System.Drawing.Size(448, 240);
                        this.Resize += new System.EventHandler(this.ChartPic_Resize);
                        ((System.ComponentModel.ISupportInitialize)(this.ChartPic)).EndInit();
                        this.ResumeLayout(false);

                }
                #endregion

                public enum GraphicTypes
                {
                        Lines,
                        Pie
                }

                private bool m_VerticalGrid = true;
                public GraphicTypes GraphicType = GraphicTypes.Lines;
                private System.Windows.Forms.PictureBox ChartPic;
                public System.Collections.Generic.List<Lbl.Charts.Serie> Series = null;

                private Lui.Forms.Label TitleLabel;
                private decimal CacheMax;

                public string Title
                {
                        get
                        {
                                return TitleLabel.Text;
                        }
                        set
                        {
                                TitleLabel.Text = value;
                        }
                }

                public bool VerticalGrid
                {
                        get
                        {
                                return m_VerticalGrid;
                        }
                        set
                        {
                                m_VerticalGrid = value;
                        }
                }

                public decimal GetMax()
                {
                        decimal Max = decimal.MinValue;
                        for (int i = 0; i < Series.Count; i++) {
                                if (Series[i] != null && Series[i].Elements != null) {
                                        foreach (Lbl.Charts.Element El in Series[i].Elements) {
                                                if (El != null && El.Value > Max)
                                                        Max = El.Value;
                                        }
                                }
                        }
                        return Max;
                }


                public int BiggestSerie()
                {
                        int Max = 0;
                        for (int i = 0; i < Series.Count; i++) {
                                if (Series[i] != null && Series[i].Elements != null) {
                                        if (Series[i].Elements.Length > Max)
                                                Max = Series[i].Elements.Length;
                                }
                        }
                        return Max;
                }

                protected override void OnInvalidated(InvalidateEventArgs e)
                {
                        base.OnInvalidated(e);
                        this.Redraw();
                }


                public void Redraw()
                {
                        System.Drawing.Graphics gfx = ChartPic.CreateGraphics();
                        gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        gfx.Clear(System.Drawing.Color.White);

                        if (Series != null) {
                                //CacheMin = GetMin();
                                CacheMax = GetMax();

                                if (m_VerticalGrid)
                                        DrawVerticalGrid(gfx, ChartPic.Size);

                                for (int i = 0; i < Series.Count; i++) {
                                        if (Series[i] != null)
                                                DrawSerie(Series[i], gfx, ChartPic.Size);
                                }
                        }
                }

                private void DrawVerticalGrid(System.Drawing.Graphics Canvas, System.Drawing.Size Size)
                {
                        if (GraphicType == GraphicTypes.Lines) {
                                int BigSerie = this.BiggestSerie();
                                float ElementWidth = Size.Width / (BigSerie - 1);
                                for (int i = 1; i < BigSerie; i++) {
                                        float ElementX = ElementWidth * (i - 1);
                                        Canvas.DrawLine(System.Drawing.Pens.WhiteSmoke, ElementX, 0, ElementX, Size.Height);
                                }
                        }
                }

                private void DrawSerie(Lbl.Charts.Serie DrawSerie, System.Drawing.Graphics Canvas, System.Drawing.Size Size)
                {

                        switch (GraphicType) {
                                case GraphicTypes.Pie:
                                        DrawPie(DrawSerie, Canvas, Size);
                                        break;
                                default:
                                        DrawLines(DrawSerie, Canvas, Size);
                                        break;
                        }
                }

                private void DrawLines(Lbl.Charts.Serie Serie, System.Drawing.Graphics Canvas, System.Drawing.Size Size)
                {
                        Canvas.DrawLine(System.Drawing.Pens.WhiteSmoke, 0, Size.Height - 1, 2000, Size.Height - 1);
                        if (Serie.Elements == null)
                                return;

                        int ElementNumber = 1;
                        if (Serie.Elements.Length > 0 && CacheMax != 0) {
                                System.Drawing.PointF LastPoint = new PointF(0, 65000);
                                float ElementWidth = Size.Width / (Serie.Elements.Length - 1);
                                foreach (Lbl.Charts.Element El in Serie.Elements) {
                                        if (El != null) {
                                                PointF ThisPoint = new PointF(ElementWidth * (ElementNumber - 1), Size.Height - (int)(El.Value / CacheMax * Size.Height));
                                                if (ElementNumber == 1)
                                                        LastPoint = ThisPoint;

                                                Canvas.DrawLine(new System.Drawing.Pen(Serie.Color, 2), LastPoint, ThisPoint);
                                                LastPoint = ThisPoint;
                                        }
                                        ElementNumber++;
                                }
                        }
                }

                private static void DrawPie(Lbl.Charts.Serie Serie, System.Drawing.Graphics Canvas, System.Drawing.Size Size)
                {
                        decimal Sum = Serie.GetSum();

                        Rectangle PieRect = new Rectangle(0, 0, Size.Width, Size.Height);
                        if (PieRect.Width > PieRect.Height) {
                                PieRect.X += (PieRect.Width - PieRect.Height) / 2;
                                PieRect.Width = PieRect.Height;
                        } else {
                                PieRect.Y += (PieRect.Height - PieRect.Width) / 2;
                                PieRect.Height = PieRect.Width;
                        }

                        float LastAngle = 0;
                        foreach (Lbl.Charts.Element El in Serie.Elements) {
                                float ElementAngle = (float)(El.Value / Sum * 360);

                                Canvas.FillPie(System.Drawing.Brushes.Tomato, PieRect, LastAngle, LastAngle + ElementAngle);
                                LastAngle += ElementAngle;
                        }

                        LastAngle = 0;
                        foreach (Lbl.Charts.Element El in Serie.Elements) {
                                float ElementAngle = (float)(El.Value / Sum * 360);

                                Canvas.DrawPie(System.Drawing.Pens.Black, PieRect, LastAngle, LastAngle + ElementAngle);
                                LastAngle += ElementAngle;
                        }
                }

                private void ChartPic_Resize(object sender, System.EventArgs e)
                {
                        this.Invalidate();
                }

                private void ChartPic_Click(object sender, System.EventArgs e)
                {
                        this.Invalidate();
                }


                private void ChartPic_Paint(object sender, PaintEventArgs e)
                {
                        this.Redraw();
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public virtual Lazaro.Pres.DisplayStyles.IDisplayStyle DisplayStyle
                {
                        get
                        {
                                return null;
                        }
                        set
                        {
                        }
                }

        }
}