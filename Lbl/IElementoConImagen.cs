using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl
{
        public interface IElementoConImagen : IElementoDeDatos
        {
                System.Drawing.Image Imagen { get; set; }
                bool ImagenCambio { get; }
        }
}
