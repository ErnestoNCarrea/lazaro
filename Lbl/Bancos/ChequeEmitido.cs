using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Bancos
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Cheque emitido", Grupo = "Cobros y pagos")]
	public class ChequeEmitido : Cheque
	{
                //Heredar constructor
		public ChequeEmitido(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

		public ChequeEmitido(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public ChequeEmitido(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                new public bool Emitido
                {
                        get
                        {
                                return true;
                        }
                }
	}
}
