using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Tipo
{
	public partial class Inicio : Lfc.FormularioListado
	{
		public Inicio()
		{
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Comprobantes.Tipo),

                                TableName = "documentos_tipos",
                                OrderBy = "nombre",
                                KeyColumn = new Lazaro.Pres.Field("id_tipo", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 160),
                                        new Lazaro.Pres.Field("nombrelargo", "Nombre compl.", Lfx.Data.InputFieldTypes.Text, 320),
				        new Lazaro.Pres.Field("letra", "Letra", Lfx.Data.InputFieldTypes.Text, 60),
				        new Lazaro.Pres.Field("mueve_stock", "Mueve Stock", Lfx.Data.InputFieldTypes.Bool, 120),
                                        new Lazaro.Pres.Field("numerar_guardar", "Numerar al guardar", Lfx.Data.InputFieldTypes.Bool, 120),
                                        new Lazaro.Pres.Field("numerar_imprimir", "Numerar al imprimir", Lfx.Data.InputFieldTypes.Bool, 120)
			        }
                        };
		}
	}
}

