using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lfc.Cajas.Vencimientos
{
        public partial class Inicio : Lfc.FormularioListado
        {
                public Inicio()
                {
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Vencimientos.Vencimiento),

                                TableName = "vencimientos",
                                KeyColumn = new Lazaro.Pres.Field("vencimientos.id_vencimiento", "Cód.", Lfx.Data.InputFieldTypes.Serial, 20),
                                Joins = new qGen.JoinCollection() { new qGen.Join("conceptos", "vencimientos.id_concepto=conceptos.id_concepto") },
                                OrderBy = "vencimientos.fecha_proxima DESC",
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("vencimientos.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 120),
				        new Lazaro.Pres.Field("vencimientos.importe", "Importe", Lfx.Data.InputFieldTypes.Currency, 96),
				        new Lazaro.Pres.Field("vencimientos.frecuencia", "Frecuencia", Lfx.Data.InputFieldTypes.Text, 120),
				        new Lazaro.Pres.Field("vencimientos.fecha_proxima", "Próxima Ocurrencia", Lfx.Data.InputFieldTypes.Date, 96),
				        new Lazaro.Pres.Field("conceptos.nombre", "Concepto", Lfx.Data.InputFieldTypes.Text, 160),
				        new Lazaro.Pres.Field("vencimientos.estado", "Estado", Lfx.Data.InputFieldTypes.Text, 96),
                                        new Lazaro.Pres.Field("vencimientos.obs", "Obs", Lfx.Data.InputFieldTypes.Memo, 320)
			        }
                        };

                        Listado.CheckBoxes = true;
                        this.HabilitarCrear = true;
                        this.HabilitarFiltrar = true;
                }

                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
                {
                        switch (row.Fields["vencimientos.estado"].ValueInt) {
                                case 1:
                                        item.SubItems["vencimientos.estado"].Text = "Activo";
                                        DbDateTime Vencimiento = row.Fields["vencimientos.fecha_proxima"].ValueDateTime;
                                        if (Vencimiento != null) {
                                                if (Vencimiento <= DateTime.Now)
                                                        item.ForeColor = System.Drawing.Color.Red;
                                                else if (Vencimiento <= DateTime.Now.AddDays(5))
                                                        item.ForeColor = System.Drawing.Color.Orange;
                                        }
                                        break;
                                case 2:
                                        item.SubItems["vencimientos.estado"].Text = "Inactivo";
                                        break;
                                case 100:
                                        item.SubItems["vencimientos.estado"].Text = "Terminado";
                                        break;
                        }                        
                }
        }
}