using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Articulos.Margenes
{
	public class Inicio : Lfc.FormularioListado
	{
		public Inicio()
		{
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Articulos.Margen),

                                TableName = "margenes",
                                OrderBy = "nombre",
                                KeyColumn = new Lazaro.Pres.Field("id_margen", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 480),
                                        new Lazaro.Pres.Field("porcentaje", "Porcentaje", Lfx.Data.InputFieldTypes.Numeric, 120),
                                        new Lazaro.Pres.Field("predet", "Predeterminado", Lfx.Data.InputFieldTypes.Bool, 120)
			        }
                        };
		}
	}
}