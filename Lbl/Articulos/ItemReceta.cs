using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Articulos
{
        public class ItemReceta
        {
                public Lbl.Articulos.Articulo Articulo = null;
                public decimal Cantidad = 0;

                public ItemReceta(Lbl.Articulos.Articulo articulo, decimal cantidad)
                {
                        this.Articulo = articulo;
                        this.Cantidad = cantidad;
                }

                public override string ToString()
                {
                        if (this.Articulo == null)
                                return "";
                        else
                                return this.Cantidad.ToString() + " " + this.Articulo.ToString();
                }

                public decimal Costo
                {
                        get
                        {
                                return this.Articulo.CostoLocal * this.Cantidad;
                        }
                }

                public decimal Pvp
                {
                        get
                        {
                                return this.Articulo.PvpLocal * this.Cantidad;
                        }
                }
        }
}
