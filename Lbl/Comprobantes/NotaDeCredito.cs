using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Nota de Crédito", Grupo = "Comprobantes")]
        [Lbl.Atributos.Datos(TablaDatos = "comprob", CampoId = "id_comprob")]
        [Lbl.Atributos.Presentacion()]
        public class NotaDeCredito : ComprobanteFacturable
        {
                //Heredar constructor
                public NotaDeCredito(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

                public NotaDeCredito(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                public NotaDeCredito(Lfx.Data.Connection dataBase, int itemId)
                        : base(dataBase, itemId) { }

                public override void Crear()
                {
                        base.Crear();
                        this.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra["NCB"];
                }
        }
}
