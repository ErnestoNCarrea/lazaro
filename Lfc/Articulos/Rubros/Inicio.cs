using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Articulos.Rubros
{
	public class Inicio : Lfc.FormularioListado
	{
		public Inicio()
		{
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Articulos.Rubro),

                                TableName = "articulos_rubros",
                                KeyColumn = new Lazaro.Pres.Field("articulos_rubros.id_rubro", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                OrderBy = "articulos_rubros.nombre",
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("articulos_rubros.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
				        new Lazaro.Pres.Field("articulos_rubros.id_alicuota", "Alícuota", Lfx.Data.InputFieldTypes.Integer, 160)
			        }
                        };
		}
	}
}

