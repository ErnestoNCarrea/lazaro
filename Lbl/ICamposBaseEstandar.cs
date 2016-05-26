using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl
{
        public interface ICamposBaseEstandar : IElementoDeDatos
        {
                string Nombre { get; set; }
                string Obs { get; set; }
                DateTime Fecha { get; }
                int Estado { get; set; }
        }
}
