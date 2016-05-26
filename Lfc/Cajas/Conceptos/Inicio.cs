using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Cajas.Conceptos
{
        public class Inicio : Lfc.FormularioListado
        {
                public Inicio()
                {
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Cajas.Concepto),

                                TableName = "conceptos",
                                KeyColumn = new Lazaro.Pres.Field("conceptos.id_concepto", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("conceptos.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
				        new Lazaro.Pres.Field("conceptos.es", "Tipo", Lfx.Data.InputFieldTypes.Text, 120),
				        new Lazaro.Pres.Field("conceptos.grupo", "Grupo", Lfx.Data.InputFieldTypes.Text, 120)
			        }
                        };
                }

                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
                {
                        switch (row.Fields["conceptos.es"].ValueInt) {
                                case 1:
                                        item.SubItems["conceptos.es"].Text = "Entrada";
                                        break;
                                case 2:
                                        item.SubItems["conceptos.es"].Text = "Salida";
                                        break;
                                case 0:
                                        item.SubItems["conceptos.es"].Text = "Entrada/Salida";
                                        break;
                                default:
                                        item.SubItems["conceptos.es"].Text = "???";
                                        break;
                        }

                        switch (row.Fields["conceptos.grupo"].ValueInt) {
                                case 0:
                                        item.SubItems["conceptos.grupo"].Text = "-";
                                        break;
                                case 110:
                                        item.SubItems["conceptos.grupo"].Text = "Cobros";
                                        break;
                                case 100:
                                        item.SubItems["conceptos.grupo"].Text = "Otros ingresos";
                                        break;
                                case 230:
                                        item.SubItems["conceptos.grupo"].Text = "Gastos fijos";
                                        break;
                                case 240:
                                        item.SubItems["conceptos.grupo"].Text = "Gastos variables";
                                        break;
                                case 200:
                                        item.SubItems["conceptos.grupo"].Text = "Otros gastos";
                                        break;
                                case 260:
                                        item.SubItems["conceptos.grupo"].Text = "Pérdida";
                                        break;
                                case 250:
                                        item.SubItems["conceptos.grupo"].Text = "Reinversión";
                                        break;
                                case 210:
                                        item.SubItems["conceptos.grupo"].Text = "Costo materiales";
                                        break;
                                case 220:
                                        item.SubItems["conceptos.grupo"].Text = "Costo capital";
                                        break;
                                case 231:
                                        item.SubItems["conceptos.grupo"].Text = "Sueldos y salarios";
                                        break;
                                case 300:
                                        item.SubItems["conceptos.grupo"].Text = "Movimientos y ajustes";
                                        break;
                                default:
                                        item.SubItems["conceptos.grupo"].Text = "???";
                                        break;
                        }

                }
        }
}