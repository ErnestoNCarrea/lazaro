using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Articulos
{
        public class DatosSeguimiento
        {
                public string Variacion { get; set; }
                public decimal Cantidad { get; set; }

                public DatosSeguimiento(string variacion, decimal cantidad)
                {
                        this.Variacion = variacion;
                        this.Cantidad = cantidad;
                }
        }
}
