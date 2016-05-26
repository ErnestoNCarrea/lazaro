using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Bancos
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Cheque emitido", Grupo = "Cobros y pagos")]
	public class ChequeEmitido : Cheque
	{
                //Heredar constructor
		public ChequeEmitido(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

		public ChequeEmitido(Lfx.Data.Connection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public ChequeEmitido(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
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
