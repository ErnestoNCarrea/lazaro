using System;
using System.Collections.Generic;

namespace Lbl.Personas
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Tipo", Grupo = "Personas")]
        [Lbl.Atributos.Datos(TablaDatos = "personas_tipos", CampoId = "id_tipo_persona")]
        [Lbl.Atributos.Presentacion()]
        public class Tipo : Lbl.ElementoDeDatos, Lbl.ICamposBaseEstandar
        {
                public Tipo(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

		public Tipo(Lfx.Data.Connection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Tipo(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }
        }
}
