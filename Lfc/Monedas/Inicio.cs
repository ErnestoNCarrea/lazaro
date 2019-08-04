using System;
using System.Collections.Generic;

namespace Lfc.Monedas
{
        public class Inicio : Lazaro.Pres.Listings.Listing
        {
                public Inicio()
                {
                        ElementoTipo = typeof(Lbl.Entidades.Moneda);

                        TableName = "monedas";
                        KeyColumn = new Lazaro.Pres.Field("monedas.id_moneda", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0);
                        Columns = new Lazaro.Pres.FieldCollection() 
			{
				new Lazaro.Pres.Field("monedas.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
                                new Lazaro.Pres.Field("monedas.signo", "Signo", Lfx.Data.InputFieldTypes.Text, 70),
                                new Lazaro.Pres.Field("monedas.iso", "Cod. ISO", Lfx.Data.InputFieldTypes.Text, 80),
                                new Lazaro.Pres.Field("monedas.cotizacion", "Cotizacion", Lfx.Data.InputFieldTypes.Currency, 100)
			};
                        OrderBy = "monedas.nombre";
                }
        }
}