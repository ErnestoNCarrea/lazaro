using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Articulos.Marcas
{
	public class Inicio : Lfc.FormularioListado
	{
		public Inicio()
		{
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Articulos.Marca),

                                TableName = "marcas",
                                OrderBy = "nombre",
                                KeyColumn = new Lazaro.Pres.Field("id_marca", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 480),
				        new Lazaro.Pres.Field("url", "Web", Lfx.Data.InputFieldTypes.Text, 120)
			        }
                        };
		}
	}
}