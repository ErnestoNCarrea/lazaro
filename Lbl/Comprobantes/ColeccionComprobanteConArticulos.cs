using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
        public class ColeccionComprobanteConArticulos : Lbl.ColeccionGenerica<ComprobanteConArticulos>
        {
                public ColeccionComprobanteConArticulos(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public ColeccionComprobanteConArticulos(Lfx.Data.IConnection dataBase, System.Data.DataTable tabla)
                        : base(dataBase, tabla) { }

                public decimal Total
                {
                        get
                        {
                                decimal Res = 0;
                                foreach (ComprobanteConArticulos comp in this) {
                                        Res += comp.Total;
                                }
                                return Res;
                        }
                }

                public decimal ImporteCancelado
                {
                        get
                        {
                                decimal Res = 0;
                                foreach (ComprobanteConArticulos comp in this) {
                                        Res += comp.ImporteCancelado;
                                }
                                return Res;
                        }
                }


                public override string ToString()
                {
                        string Res = null;
                        foreach (ComprobanteConArticulos Cb in this) {
                                if (Res == null)
                                        Res = Cb.ToString();
                                else
                                        Res += System.Environment.NewLine + Cb.ToString();
                        }
                        return Res;
                }
        }
}
