using System;
using System.Collections.Generic;

namespace Lfc.Pagos.Planes
{
        public class Inicio : Lazaro.Pres.Listings.Listing
        {
                public Inicio()
                {
                        ElementoTipo = typeof(Lbl.Pagos.Plan);

                        TableName = "tarjetas_planes";
                        KeyColumn = new Lazaro.Pres.Field("tarjetas_planes.id_plan", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0);
                        Columns = new Lazaro.Pres.FieldCollection() 
			{
				new Lazaro.Pres.Field("tarjetas_planes.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
                                new Lazaro.Pres.Field("tarjetas_planes.cuotas", "Cuotas", Lfx.Data.InputFieldTypes.Integer, 96),
                                new Lazaro.Pres.Field("tarjetas_planes.interes", "Desc./Recargo", Lfx.Data.InputFieldTypes.Numeric, 120),
                                new Lazaro.Pres.Field("tarjetas_planes.comision", "Retención", Lfx.Data.InputFieldTypes.Numeric, 120)
			};
                        OrderBy = "tarjetas_planes.nombre";
                }
        }
}