using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Articulos
{
        public partial class VerConformacion : Lui.Forms.ChildDialogForm
        {
                public VerConformacion()
                {
                        InitializeComponent();
                        this.OkButton.Visible = false;
                }

                public void Mostrar(Lbl.Articulos.Articulo articulo)
                {
                        this.EtiquetaTitulo.Text = "Conformación de existencias de " + articulo.ToString();

                        ListaConformacion.BeginUpdate();
                        ListaConformacion.Items.Clear();
                        System.Data.DataTable Situaciones = this.Connection.Select("SELECT id_situacion, nombre FROM articulos_situaciones WHERE id_situacion IN (SELECT DISTINCT id_situacion FROM articulos_stock WHERE id_articulo=" + articulo.Id.ToString() + ")");
                        
                        foreach (System.Data.DataRow Situacion in Situaciones.Rows) {
                                ListViewGroup Grupo = ListaConformacion.Groups.Add(Situacion["id_situacion"].ToString(), Situacion["nombre"].ToString());
                                System.Data.DataTable Articulos = this.Connection.Select("SELECT serie, cantidad FROM articulos_series WHERE cantidad<>0 AND id_articulo=" + articulo.Id.ToString() + " AND id_situacion=" + Situacion["id_situacion"].ToString());
                                foreach(System.Data.DataRow Articulo in Articulos.Rows){
                                        string Serie = Articulo["serie"].ToString();
                                        ListViewItem Itm = ListaConformacion.Items.Add(Serie);
                                        Itm.SubItems[0].Text = Serie;
                                        Itm.SubItems.Add(Lfx.Types.Formatting.FormatStock(System.Convert.ToDecimal(Articulo["cantidad"]), Lbl.Sys.Config.Articulos.Decimales));
                                        Itm.Group = Grupo;
                                }
                        }

                        DataTable Stocks = this.Connection.Select("SELECT id_articulo, id_situacion, cantidad FROM articulos_stock WHERE id_articulo=" + articulo.Id.ToString() + " AND cantidad<>0 AND id_situacion<>998 AND id_situacion<>999 ORDER BY id_situacion");

                        if (Stocks != null) {
                                ListViewGroup Grupo = ListaConformacion.Groups.Add("000", "Totales por depósito");

                                foreach (System.Data.DataRow Stock in Stocks.Rows) {
                                        Lfx.Data.Row Situacion = this.Connection.Row("articulos_situaciones", "id_situacion", System.Convert.ToInt32(Stock["id_situacion"]));

                                        ListViewItem Itm = ListaConformacion.Items.Add(Situacion["nombre"].ToString());
                                        Itm.SubItems.Add(Lfx.Types.Formatting.FormatStock(System.Convert.ToDecimal(Stock["cantidad"]), Lbl.Sys.Config.Articulos.Decimales));

                                        Itm.Group = Grupo;
                                }
                        }

                        ListaConformacion.EndUpdate();
                }
        }
}
