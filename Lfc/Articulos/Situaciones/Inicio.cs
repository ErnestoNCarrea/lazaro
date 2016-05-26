using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Articulos.Situaciones
{
        public partial class Inicio : Lfc.FormularioListado
        {
                public Inicio()
                {
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Articulos.Situacion),

                                TableName = "articulos_situaciones",
                                KeyColumn = new Lazaro.Pres.Field("articulos_situaciones.id_situacion", "Cód.", Lfx.Data.InputFieldTypes.Serial, 80),
                                DetailColumnName = "nombre",
                                OrderBy = "articulos_situaciones.nombre",
                                Columns = new Lazaro.Pres.FieldCollection()
                                {
				        new Lazaro.Pres.Field("articulos_situaciones.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
                                        new Lazaro.Pres.Field("articulos_situaciones.cuenta_stock", "Suma Stock", 96, new Dictionary<int, string> { {0, "No" }, { 1, "Sí" } } ),
				        new Lazaro.Pres.Field("articulos_situaciones.facturable", "Facturable", 96, new Dictionary<int, string> { {0, "No" }, { 1, "Sí" } } ),
				        new Lazaro.Pres.Field("articulos_situaciones.deposito", "Depósito", Lfx.Data.InputFieldTypes.Integer, 96),
			        },
                        };

                        this.HabilitarFiltrar = false;
                }

                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
                {
                        if(row.Fields["articulos_situaciones.deposito"].ValueInt == 0)
                                item.SubItems["articulos_situaciones.deposito"].Text = "No";
                        base.OnItemAdded(item, row);
                }
        }
}