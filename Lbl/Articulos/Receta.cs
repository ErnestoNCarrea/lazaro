using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Articulos
{
        public class Receta : List<ItemReceta>
        {
                public decimal Costo
                {
                        get
                        {
                                decimal Res = 0;
                                foreach (ItemReceta Itm in this) {
                                        Res += Itm.Costo;
                                }
                                return Res;
                        }
                }

                public decimal Pvp
                {
                        get
                        {
                                decimal Res = 0;
                                foreach (ItemReceta Itm in this) {
                                        Res += Itm.Pvp;
                                }
                                return Res;
                        }
                }
        }
}
