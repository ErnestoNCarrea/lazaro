using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Pagos
{
        /// <summary>
        /// Representa un plan de una tarjeta de crédito (p. ej.: "Plan 12 cuotas sin interés").
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Plan", Grupo = "Cobros y pagos")]
        [Lbl.Atributos.Datos(TablaDatos = "tarjetas_planes", CampoId = "id_plan")]
        [Lbl.Atributos.Presentacion()]
	public class Plan : ElementoDeDatos
	{
		//Heredar constructor
		public Plan(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

		public Plan(Lfx.Data.Connection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Plan(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public decimal Comision
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("comision");
                        }
                        set
                        {
                                this.Registro["comision"] = value;
                        }
                }
	}
}
