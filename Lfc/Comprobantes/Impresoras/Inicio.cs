using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Impresoras
{
	public partial class Inicio : Lfc.FormularioListado
	{
		public Inicio()
		{
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Impresion.Impresora),

                                TableName = "impresoras",
                                OrderBy = "nombre",
                                KeyColumn = new Lazaro.Pres.Field("id_impresora", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 240),
                                        new Lazaro.Pres.Field("dispositivo", "Dispositivo", Lfx.Data.InputFieldTypes.Text, 240),
                                        new Lazaro.Pres.Field("ubicacion", "Ubicacion", Lfx.Data.InputFieldTypes.Text, 240)
			        }
                        };
		}
	}
}

