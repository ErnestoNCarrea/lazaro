using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Personas.Grupos
{
	public class Inicio : Lfc.FormularioListado
	{
		public Inicio()
		{
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Personas.Grupo),

                                TableName = "personas_grupos",
                                KeyColumn = new Lazaro.Pres.Field("id_grupo", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                OrderBy = "parent, nombre",
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
				        new Lazaro.Pres.Field("descuento", "Descuento", Lfx.Data.InputFieldTypes.Numeric, 320),
                                        new Lazaro.Pres.Field("parent", "Parent", Lfx.Data.InputFieldTypes.Integer, 0),
			        }
                        };
		}
	}
}

