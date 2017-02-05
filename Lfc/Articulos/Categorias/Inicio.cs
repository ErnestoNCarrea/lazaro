using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Articulos.Categorias
{
        public partial class Inicio : Lfc.FormularioListado
        {
                internal decimal m_ValorizacionCostoTotal = 0;

                public Inicio()
                {
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Articulos.Categoria),

                                TableName = "articulos_categorias",
                                KeyColumn = new Lazaro.Pres.Field("articulos_categorias.id_categoria", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                GroupBy = new Lazaro.Pres.Field("articulos_categorias.id_categoria", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                Joins = new qGen.JoinCollection() { new qGen.Join("articulos", "articulos_categorias.id_categoria") },
                                OrderBy = "articulos_categorias.nombre",
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("articulos_categorias.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
				        new Lazaro.Pres.Field("articulos_categorias.stock_minimo", "Stock Mín", Lfx.Data.InputFieldTypes.Numeric, 96),
				        new Lazaro.Pres.Field("articulos_categorias.cache_stock_actual", "Stock Act", Lfx.Data.InputFieldTypes.Numeric, 96),
                                        new Lazaro.Pres.Field("articulos_categorias.cache_costo", "Valorización", Lfx.Data.InputFieldTypes.Numeric, 96),
                                        new Lazaro.Pres.Field("0", "Valorización %", Lfx.Data.InputFieldTypes.Numeric, 96)
			        },
                                Filters = new Lazaro.Pres.Filters.FilterCollection()
                                {
                                        new Lazaro.Pres.Filters.SetFilter("Stock Actual", "articulos_categorias.cache_stock_actual", new string[] { "Todos|*", "Con faltantes|f" }, "*")
                                }
                        };
                        
                        this.HabilitarFiltrar = true;
                }


                public override void OnFiltersChanged(Lazaro.Pres.Filters.FilterCollection filters)
                {
                        this.CustomFilters.Clear();

                        if (((Lazaro.Pres.Filters.SetFilter)(filters["articulos_categorias.cache_stock_actual"])).CurrentValue == "f")
                                CustomFilters.AddWithValue("articulos_categorias.stock_minimo>0 AND articulos_categorias.stock_minimo>(SELECT SUM(articulos.stock_actual) FROM articulos WHERE articulos_categorias.id_categoria=id_categoria)");

                        base.OnFiltersChanged(filters);
                }


                protected override void OnBeginRefreshList()
                {
                        using (IDbTransaction Trans = this.Connection.BeginTransaction()) {
                                this.Connection.ExecuteNonQuery("UPDATE articulos_categorias SET cache_stock_actual=(SELECT SUM(stock_actual) FROM articulos WHERE articulos.id_categoria=articulos_categorias.id_categoria), cache_costo=(SELECT SUM(stock_actual*costo) FROM articulos WHERE articulos.id_categoria=articulos_categorias.id_categoria)");
                                Trans.Commit();
                        }
                        m_ValorizacionCostoTotal = this.Connection.FieldDecimal("SELECT SUM(cache_costo) FROM articulos_categorias");

                        base.OnBeginRefreshList();
                }


                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
                {
                        decimal ValPct;
                        if (m_ValorizacionCostoTotal <= 0)
                                ValPct = 0;
                        else
                                ValPct = System.Convert.ToDecimal(row["cache_costo"]) / m_ValorizacionCostoTotal * 100;
                        item.SubItems["0"].Text = Lfx.Types.Formatting.FormatNumber(ValPct, 2) + "%";

                        if (row.Fields["cache_stock_actual"].ValueDecimal < row.Fields["stock_minimo"].ValueDecimal)
                                item.ForeColor = System.Drawing.Color.Red;
                }
        }
}