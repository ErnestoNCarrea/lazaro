using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Sucursales
{
        public class Inicio : Lfc.FormularioListado
        {
                public Inicio()
                {
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Entidades.Sucursal),

                                TableName = "sucursales",
                                KeyColumn = new Lazaro.Pres.Field("sucursales.id_sucursal", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                Columns = new Lazaro.Pres.FieldCollection() 
			        {
				        new Lazaro.Pres.Field("sucursales.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
				        new Lazaro.Pres.Field("sucursales.direccion", "Dirección", Lfx.Data.InputFieldTypes.Text, 120),
				        new Lazaro.Pres.Field("sucursales.telefono", "Teléfono", Lfx.Data.InputFieldTypes.Text, 320)
			        },
                                OrderBy = "sucursales.nombre"
                        };
                }
        }
}