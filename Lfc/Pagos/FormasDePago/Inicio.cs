using System;
using System.Collections.Generic;

namespace Lfc.Pagos.FormasDePago
{
        public class Inicio : Lazaro.Pres.Listings.Listing
        {
                public Inicio()
                {
                        ElementoTipo = typeof(Lbl.Pagos.FormaDePago);

                        TableName = "formaspago";
                        KeyColumn = new Lazaro.Pres.Field("formaspago.id_formapago", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0);
                        Columns = new Lazaro.Pres.FieldCollection() 
			{
				new Lazaro.Pres.Field("formaspago.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
				new Lazaro.Pres.Field("formaspago.tipo", "Tipo", 240, new Dictionary<int, string>() {
                                        { 1, "Efectivo" },
                                        { 2, "Cheque (propio)" },
                                        { 3, "Cuenta corriente" },
                                        { 4, "Tarjeta" },
                                        { 6, "Caja" },
                                        { 7, "Otro" },
                                        { 8, "Cheque (terceros)" }
                                }),
				new Lazaro.Pres.Field("formaspago.id_caja", "Caja", Lfx.Data.InputFieldTypes.Relation, 320),
                                new Lazaro.Pres.Field("formaspago.descuento", "Desc./Recargo", Lfx.Data.InputFieldTypes.Numeric, 120),
                                new Lazaro.Pres.Field("formaspago.retencion", "Retención", Lfx.Data.InputFieldTypes.Numeric, 120),
                                new Lazaro.Pres.Field("formaspago.pagos", "Pagos", Lfx.Data.InputFieldTypes.Bool, 96),
                                new Lazaro.Pres.Field("formaspago.cobros", "Cobros", Lfx.Data.InputFieldTypes.Bool, 96),
			};
                        OrderBy = "formaspago.nombre";
                }
        }
}