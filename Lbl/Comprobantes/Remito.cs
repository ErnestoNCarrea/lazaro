using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
	public class Remito : ComprobanteConArticulos
	{
		//Heredar constructor
                public Remito(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

                public Remito(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
			: base(dataBase, row) { }

                public Remito(Lfx.Data.Connection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public override void Crear()
                {
                        base.Crear();
                        this.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra["R"];
                }

                public override Lfx.Types.OperationResult Guardar()
                {
                        this.FormaDePago = null;
                        return base.Guardar();
                }
	}
}
