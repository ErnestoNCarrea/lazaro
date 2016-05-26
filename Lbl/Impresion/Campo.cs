using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Lbl.Impresion
{
        /// <summary>
        /// Define un campo para una Plantilla.
        /// </summary>
        public class Campo
        {
                public string Valor { get; set; }
                public string Formato { get; set; }
                public int AnchoBorde { get; set; }
                public Color ColorTexto = Color.Black, ColorFondo = Color.Transparent, ColorBorde = Color.Gray;
                public Rectangle Rectangle;
                public Font Font { get; set; }
                public StringAlignment Alignment = StringAlignment.Near;
                public StringAlignment LineAlignment = StringAlignment.Near;
                public bool Wrap { get; set; }
                public bool Preimpreso { get; set; }

                public override string ToString()
                {
                        return this.Valor;
                }
        }
}
