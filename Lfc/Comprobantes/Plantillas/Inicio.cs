using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Plantillas
{
	public class Inicio : Lfc.FormularioListado
	{
		public Inicio()
		{
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Impresion.Plantilla),

                                TableName = "sys_plantillas",
                                KeyColumn = new Lazaro.Pres.Field("sys_plantillas.id_plantilla", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("sys_plantillas.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
                                        new Lazaro.Pres.Field("sys_plantillas.tamanopapel", "Papel", Lfx.Data.InputFieldTypes.Text, 64),
                                        new Lazaro.Pres.Field("sys_plantillas.landscape", "Orientación", 96, new Dictionary<int, string> { {0, "Alta" }, { 1, "Apaisada" } }),
				        new Lazaro.Pres.Field("sys_plantillas.copias", "Copias", Lfx.Data.InputFieldTypes.Integer, 64)
			        },
                                OrderBy = "sys_plantillas.nombre"
                        };

			this.HabilitarFiltrar = false;
		}


                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
                {
                        string TamanoPapel = row["tamanopapel"].ToString();
                        switch(TamanoPapel) {
                                case "a4":
                                        item.SubItems["sys_plantillas.tamanopapel"].Text = "A4";
                                        break;
                                case "a5":
                                        item.SubItems["sys_plantillas.tamanopapel"].Text = "A5";
                                        break;
                                case "letter":
                                        item.SubItems["sys_plantillas.tamanopapel"].Text = "Carta";
                                        break;
                                case "legal":
                                        item.SubItems["sys_plantillas.tamanopapel"].Text = "Oficio";
                                        break;
                                case "cont":
                                        item.SubItems["sys_plantillas.tamanopapel"].Text = "Continuo";
                                        break;
                                default:
                                        item.SubItems["sys_plantillas.tamanopapel"].Text = TamanoPapel.ToTitleCase();
                                        break;
                        }
                        base.OnItemAdded(item, row);
                }
	}
}

