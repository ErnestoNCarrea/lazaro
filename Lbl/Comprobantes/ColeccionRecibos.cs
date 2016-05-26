using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
        public class ColeccionRecibos : List<Recibo>
        {
                public decimal ImporteTotal
                {
                        get
                        {
                                decimal Res = 0;
                                foreach (Recibo comp in this) {
                                        Res += comp.Total;
                                }
                                return Res;
                        }
                }

                public override string ToString()
                {
                        string Res = null;
                        foreach (Recibo Rec in this) {
                                if (Res == null)
                                        Res = Rec.ToString();
                                else
                                        Res += ", " + Rec.ToString();
                        }
                        return Res;
                }
        }
}
