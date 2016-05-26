using System;
using System.Collections.Generic;

namespace Lfc.Bancos
{
        public class Inicio : Lazaro.Pres.Listings.Listing
        {
                public Inicio()
                {
                        ElementoTipo = typeof(Lbl.Bancos.Banco);

                        TableName = "bancos";
                        KeyColumn = new Lazaro.Pres.Field("bancos.id_banco", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0);
                        Columns = new Lazaro.Pres.FieldCollection() 
			{
				new Lazaro.Pres.Field("bancos.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
				new Lazaro.Pres.Field("bancos.url", "Página", Lfx.Data.InputFieldTypes.Text, 320)
			};
                        OrderBy = "bancos.nombre";
                }
        }
}