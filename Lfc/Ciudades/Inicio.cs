using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Ciudades
{
	public class Inicio : Lfc.FormularioListado
	{
		public Inicio()
		{
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Entidades.Localidad),

                                TableName = "ciudades",
                                KeyColumn = new Lazaro.Pres.Field("ciudades.id_ciudad", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                Joins = new qGen.JoinCollection() { new qGen.Join("paises", "ciudades.id_pais=paises.id_pais"),
                                        new qGen.Join("ciudades b", "ciudades.id_provincia=b.id_ciudad") },
                                OrderBy = "ciudades.parent, ciudades.nombre",
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("ciudades.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
                                        new Lazaro.Pres.Field("ciudades.cp", "Cód. Postal", Lfx.Data.InputFieldTypes.Text, 120),
                                        new Lazaro.Pres.Field("b.nombre", "Provincia", Lfx.Data.InputFieldTypes.Text, 160),
                                        new Lazaro.Pres.Field("paises.nombre", "País", Lfx.Data.InputFieldTypes.Text, 160)
			        }
                        };
		}
	}
}
