using System;
using System.Collections.Generic;

namespace Lfc.Alicuotas
{
	public partial class Inicio : Lazaro.Pres.Listings.Listing
	{
		public Inicio()
		{
                        ElementoTipo = typeof(Lbl.Impuestos.Alicuota);

                        TableName = "alicuotas";
                        OrderBy = "nombre";
                        KeyColumn = new Lazaro.Pres.Field("id_alicuota", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0);
                        Columns = new Lazaro.Pres.FieldCollection()
			{
				new Lazaro.Pres.Field("nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 240),
				new Lazaro.Pres.Field("porcentaje", "Porcentaje", Lfx.Data.InputFieldTypes.Numeric, 160),
				new Lazaro.Pres.Field("importe_minimo", "Imp. Mín.", Lfx.Data.InputFieldTypes.Currency, 160)
			};
		}
	}
}

