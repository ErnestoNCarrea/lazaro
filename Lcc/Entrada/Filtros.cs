using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lcc.Entrada
{
        public partial class Filtros : Lui.Forms.Control
        {
                public event System.EventHandler Apply;

                private Lazaro.Pres.Filters.FilterCollection ColFiltros;

                public Filtros()
                {
                        InitializeComponent();
                }


                public void FromFilters(Lazaro.Pres.Filters.FilterCollection filters)
                {
                        this.SuspendLayout();
                        this.TablaFiltros.SuspendLayout();
                        this.ColFiltros = filters;
                        this.TablaFiltros.RowCount = filters.Count;

                        while (TablaFiltros.RowStyles.Count < TablaFiltros.RowCount)
                                TablaFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.AutoSize));

                        int i = 0;
                        foreach (Lazaro.Pres.Filters.IFilter Filtro in this.ColFiltros) {
                                Label Etiqueta = new Label();
                                Etiqueta.Name = "etiqueta" + i.ToString();
                                Etiqueta.Text = Filtro.Label;
                                Etiqueta.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                                Etiqueta.Margin = new System.Windows.Forms.Padding(0, 4, 4, 0);
                                Etiqueta.Dock = DockStyle.Fill;
                                this.TablaFiltros.Controls.Add(Etiqueta, 0, i);

                                Control Entrada;
                                if (Filtro is Lazaro.Pres.Filters.NumericRangeFilter) {
                                        Lcc.Entrada.RangoNumerico EntradaRangoNumerico = new Lcc.Entrada.RangoNumerico();
                                        Lazaro.Pres.Filters.NumericRangeFilter FiltroNumerico = Filtro as Lazaro.Pres.Filters.NumericRangeFilter;
                                        EntradaRangoNumerico.DecimalPlaces = FiltroNumerico.DecimalPlaces;
                                        EntradaRangoNumerico.Valule1 = System.Convert.ToDecimal(FiltroNumerico.Value);
                                        EntradaRangoNumerico.Valule2 = System.Convert.ToDecimal(FiltroNumerico.Value2);
                                        EntradaRangoNumerico.Dock = DockStyle.Top;
                                        Entrada = EntradaRangoNumerico;
                                } else if (Filtro is Lazaro.Pres.Filters.SetFilter) {
                                        Lazaro.Pres.Filters.SetFilter FiltroSet = Filtro as Lazaro.Pres.Filters.SetFilter;
                                        Lui.Forms.ComboBox EntradaSet = new Lui.Forms.ComboBox();
                                        EntradaSet.SetData = FiltroSet.SetData;
                                        EntradaSet.TextKey = FiltroSet.CurrentValue;
                                        EntradaSet.Size = new System.Drawing.Size(200, 24);
                                        EntradaSet.AlwaysExpanded = EntradaSet.SetData != null && (EntradaSet.SetData.Length <= 4 || TablaFiltros.RowCount <= 6);
                                        EntradaSet.AutoSize = EntradaSet.AlwaysExpanded;
                                        EntradaSet.Dock = DockStyle.Top;
                                        Entrada = EntradaSet;
                                } else if (Filtro is Lazaro.Pres.Filters.DateRangeFilter) {
                                        Lazaro.Pres.Filters.DateRangeFilter FiltroFechas = Filtro as Lazaro.Pres.Filters.DateRangeFilter;
                                        Lcc.Entrada.RangoFechas EntradaRangoFechas = new Lcc.Entrada.RangoFechas();
                                        EntradaRangoFechas.Rango = FiltroFechas.DateRange;
                                        EntradaRangoFechas.Size = new System.Drawing.Size(160, 46);
                                        EntradaRangoFechas.AutoSize = true;
                                        EntradaRangoFechas.Dock = DockStyle.Top;
                                        Entrada = EntradaRangoFechas;
                                } else if (Filtro is Lazaro.Pres.Filters.RelationFilter) {
                                        Lazaro.Pres.Filters.RelationFilter FiltroRelacion = Filtro as Lazaro.Pres.Filters.RelationFilter;
                                        Lcc.Entrada.CodigoDetalle EntradaRelacion = new Lcc.Entrada.CodigoDetalle();
                                        EntradaRelacion.Required = false;
                                        EntradaRelacion.Size = new System.Drawing.Size(160, 24);
                                        EntradaRelacion.Relation = FiltroRelacion.Relation;
                                        if (FiltroRelacion.Filter != null)
                                                EntradaRelacion.Filter = Lfx.Workspace.Master.Formatter.SqlText(FiltroRelacion.Filter);
                                        EntradaRelacion.Elemento = (Lbl.IElementoDeDatos)FiltroRelacion.Elemento;
                                        EntradaRelacion.Dock = DockStyle.Top;
                                        Entrada = EntradaRelacion;
                                } else {
                                        Entrada = new Label();
                                        Entrada.Text = Filtro.GetType().ToString();
                                        Etiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                                }

                                Entrada.Name = "entrada" + i.ToString();
                                Filtro.Control = Entrada;

                                this.TablaFiltros.Controls.Add(Entrada, 1, i);
                                i++;
                        }

                        this.TablaFiltros.ResumeLayout();
                        this.ResumeLayout();
                }


                /// <summary>
                /// Actualiza la variable ColFiltros según los controles en pantalla.
                /// </summary>
                public void ActualizarFiltros()
                {
                        foreach (Lazaro.Pres.Filters.IFilter Filtro in this.ColFiltros) {
                                if (Filtro is Lazaro.Pres.Filters.NumericRangeFilter) {
                                        Lcc.Entrada.RangoNumerico EntradaRangoNumerico = Filtro.Control as Lcc.Entrada.RangoNumerico;
                                        Lazaro.Pres.Filters.NumericRangeFilter FiltroNumerico = Filtro as Lazaro.Pres.Filters.NumericRangeFilter;

                                        FiltroNumerico.Value = EntradaRangoNumerico.Valule1;
                                        FiltroNumerico.Value2 = EntradaRangoNumerico.Valule2;
                                } else if (Filtro is Lazaro.Pres.Filters.SetFilter) {
                                        Lazaro.Pres.Filters.SetFilter FiltroSet = Filtro as Lazaro.Pres.Filters.SetFilter;
                                        Lui.Forms.ComboBox EntradaSet = Filtro.Control as Lui.Forms.ComboBox;

                                        FiltroSet.CurrentValue = EntradaSet.TextKey;
                                } else if (Filtro is Lazaro.Pres.Filters.DateRangeFilter) {
                                        Lazaro.Pres.Filters.DateRangeFilter FiltroFechas = Filtro as Lazaro.Pres.Filters.DateRangeFilter;
                                        Lcc.Entrada.RangoFechas EntradaRangoFechas = Filtro.Control as Lcc.Entrada.RangoFechas;

                                        FiltroFechas.DateRange = EntradaRangoFechas.Rango;
                                } else if (Filtro is Lazaro.Pres.Filters.RelationFilter) {
                                        Lazaro.Pres.Filters.RelationFilter FiltroRelacion = Filtro as Lazaro.Pres.Filters.RelationFilter;
                                        Lcc.Entrada.CodigoDetalle EntradaRelacion = Filtro.Control as Lcc.Entrada.CodigoDetalle;

                                        FiltroRelacion.Elemento = EntradaRelacion.Elemento;
                                } else {
                                        // Tipo de filtro de reconocidgo
                                }
                        }
                }


                private void BotonAplicar_Click(object sender, EventArgs e)
                {
                        this.ActualizarFiltros();

                        EventHandler Appl = this.Apply;
                        if (Appl != null)
                                Appl(this, new EventArgs());
                }


                /// <summary>
                /// Establece si se muestra o no un botón de aplicar filtros.
                /// </summary>
                public bool ShowApplyButton
                {
                        get
                        {
                                return this.BotonAplicar.Visible;
                        }
                        set
                        {
                                this.BotonAplicar.Visible = value;
                        }
                }
        }
}
