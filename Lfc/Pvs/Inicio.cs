using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lfc.Pvs
{
	public class Inicio : Lfc.FormularioListado
	{
		public Inicio()
		{
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Comprobantes.PuntoDeVenta),

                                TableName = "pvs",
                                KeyColumn = new Lazaro.Pres.Field("pvs.id_pv", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                Joins = new qGen.JoinCollection() { new qGen.Join("sucursales", "pvs.id_sucursal=sucursales.id_sucursal") },
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("pvs.id_pv", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                        new Lazaro.Pres.Field("pvs.nombre", "PV", Lfx.Data.InputFieldTypes.Text, 120),
				        new Lazaro.Pres.Field("pvs.tipo", "Tipo", Lfx.Data.InputFieldTypes.Text, 120),
                                        new Lazaro.Pres.Field("pvs.tipo_fac", "Comprobantes", Lfx.Data.InputFieldTypes.Text, 180),
				        new Lazaro.Pres.Field("sucursales.nombre", "Sucursal", Lfx.Data.InputFieldTypes.Text, 160),
				        new Lazaro.Pres.Field("pvs.estacion", "Estacion", Lfx.Data.InputFieldTypes.Text, 160),
				        new Lazaro.Pres.Field("pvs.carga", "Carga", Lfx.Data.InputFieldTypes.Text, 120),
                                        new Lazaro.Pres.Field("pvs.detalonario", "Usa Talonarios", Lfx.Data.InputFieldTypes.Bool, 120)
			        },
                                Filters = new Lazaro.Pres.Filters.FilterCollection()
                                {
                                        new Lazaro.Pres.Filters.SetFilter("Tipo", "pvs.tipo", new string[] { "Todos|*", "Inactivo|0", "Normal|1", "Fiscal|2" }, "*")
                                }
                        };

                        this.HabilitarFiltrar = false;
		}


                public override void OnFiltersChanged(Lazaro.Pres.Filters.FilterCollection filters)
                {
                        this.CustomFilters.Clear();

                        if (((Lazaro.Pres.Filters.SetFilter)(filters["pvs.tipo"])).CurrentValue != "*")
                                CustomFilters.AddWithValue("pvs.tipo", Lfx.Types.Parsing.ParseInt(filters[0].Value.ToString()));

                        base.OnFiltersChanged(filters);
                }


                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
                {
                        switch (row.Fields["pvs.tipo_fac"].ValueString) {
                                case "F":
                                        item.SubItems[Listado.Columns["pvs.tipo_fac"].Index].Text = "Facturas";
                                        break;
                                case "F,ND":
                                        item.SubItems[Listado.Columns["pvs.tipo_fac"].Index].Text = "Facturas y notas de débito";
                                        break;
                                case "F,NC,ND":
                                        item.SubItems[Listado.Columns["pvs.tipo_fac"].Index].Text = "Facturas, notas de crédito y débito";
                                        break;
                                case "R":
                                        item.SubItems[Listado.Columns["pvs.tipo_fac"].Index].Text = "Remitos";
                                        break;
                                case "RC":
                                        item.SubItems[Listado.Columns["pvs.tipo_fac"].Index].Text = "Recibos de cobro";
                                        break;
                                case "RP":
                                        item.SubItems[Listado.Columns["pvs.tipo_fac"].Index].Text = "Recibos de pago";
                                        break;
                        }

                        int TipoPv = row.Fields["pvs.tipo"].ValueInt;
                        if (TipoPv == 0)
                                item.SubItems[Listado.Columns["pvs.tipo"].Index].Text = "Inactivo";
                        if (TipoPv == 1)
                                item.SubItems[Listado.Columns["pvs.tipo"].Index].Text = "Talonario / Papel";
                        else if (TipoPv == 2)
                                item.SubItems[Listado.Columns["pvs.tipo"].Index].Text = "Controlador fiscal AFIP";
                        else if (TipoPv == 10)
                                item.SubItems[Listado.Columns["pvs.tipo"].Index].Text = "Electrónico AFIP";

                        if (item.SubItems[Listado.Columns["pvs.carga"].Index].Text == "0")
                                item.SubItems[Listado.Columns["pvs.carga"].Index].Text = "Automática";
                        else if (item.SubItems[Listado.Columns["pvs.carga"].Index].Text == "1")
                                item.SubItems[Listado.Columns["pvs.carga"].Index].Text = "Manual";
                }
	}
}

