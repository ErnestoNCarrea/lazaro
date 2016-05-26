using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
        public class Lote : ColeccionGenerica<ComprobanteConArticulos>
        {
                public Lote(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }
        }
}
