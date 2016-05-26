using System;
using System.Collections.Generic;

namespace Lbl.Comprobantes
{
        /// <summary>
        /// Describe una lista de comprobantes, con un importe asociado a cada comprobante.
        /// Por ejemplo, una lista de las facturas canceladas por un recibo, y el importe (total o parcial)
        /// de cada factura que fue cancelado por el recibo.
        /// </summary>
        public class ColeccionComprobanteImporte : List<ComprobanteImporte>
        {
                public void AddWithValue(Lbl.Comprobantes.ComprobanteConArticulos comprob, decimal importe)
                {
                        this.Add(new ComprobanteImporte(comprob, importe));
                }


                public decimal Total
                {
                        get
                        {
                                decimal Res = 0;
                                foreach (ComprobanteImporte CompImp in this) {
                                        Res += CompImp.Comprobante.Total;
                                }
                                return Res;
                        }
                }

                public decimal ImporteImpago
                {
                        get
                        {
                                decimal Res = 0;
                                foreach (ComprobanteImporte CompImp in this) {
                                        Res += CompImp.Comprobante.ImporteImpago;
                                }
                                return Res;
                        }
                }


                public decimal ImporteCancelado
                {
                        get
                        {
                                decimal Res = 0;
                                foreach (ComprobanteImporte CompImp in this) {
                                        Res += CompImp.Comprobante.ImporteCancelado;
                                }
                                return Res;
                        }
                }
        }
}
