using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Bancos
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Cheque recibido", Grupo = "Cobros y pagos")]
	public class ChequeRecibido : Cheque
	{
                //Heredar constructor
		public ChequeRecibido(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

		public ChequeRecibido(Lfx.Data.Connection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public ChequeRecibido(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                new public bool Emitido
                {
                        get
                        {
                                return false;
                        }
                }
	}
}
