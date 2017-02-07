using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Lcc.Entrada
{
        public partial class RangoFechas : Lui.Forms.Control
        {
                private bool m_MuestraFuturos = false;
                private Lfx.Types.DateRange m_Rango = new Lfx.Types.DateRange("dia-0");

                public RangoFechas()
                {
                        InitializeComponent();

                        EntradaTipoDeRango_TextChanged(this, null);
                        EntradaRango_TextChanged(this, null);
                }

                public bool MuestraFuturos
                {
                        get
                        {
                                return m_MuestraFuturos;
                        }
                        set
                        {
                                m_MuestraFuturos = value;
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public override string Text
                {
                        get
                        {
                                return "";
                        }
                        set
                        {
                                base.Text = "";
                        }
                }

                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public Lfx.Types.DateRangeTypes TipoDeRango
                {
                        get
                        {
                                switch (EntradaTipoDeRango.TextKey) {
                                        case "dia":
                                                return Lfx.Types.DateRangeTypes.Day;
                                        case "semana":
                                                return Lfx.Types.DateRangeTypes.Week;
                                        case "mes":
                                                return Lfx.Types.DateRangeTypes.Month;
                                        default:
                                                return Lfx.Types.DateRangeTypes.Range;
                                }
                        }
                }

                private void EntradaTipoDeRango_TextChanged(object sender, EventArgs e)
                {
                        switch (EntradaTipoDeRango.TextKey) {
                                case "dia":
                                        List<string> ListaDias = new List<string>();
                                        if (m_Rango.AllowPast) {
                                                ListaDias.Add("El " + DateTime.Now.AddDays(-5).ToString("dddd d") + "|dia-5");
                                                ListaDias.Add("El " + DateTime.Now.AddDays(-4).ToString("dddd d") + "|dia-4");
                                                ListaDias.Add("El " + DateTime.Now.AddDays(-3).ToString("dddd d") + "|dia-3");
                                                ListaDias.Add("El " + DateTime.Now.AddDays(-2).ToString("dddd d") + "|dia-2");
                                                ListaDias.Add("Ayer|dia-1");
                                        }
                                        ListaDias.Add("Hoy|dia-0");
                                        if (m_Rango.AllowFuture) {
                                                ListaDias.Add("Mañana|dia+1");
                                                ListaDias.Add("El " + DateTime.Now.AddDays(2).ToString("dddd d") + "|dia+2");
                                                ListaDias.Add("El " + DateTime.Now.AddDays(3).ToString("dddd d") + "|dia+3");
                                                ListaDias.Add("El " + DateTime.Now.AddDays(4).ToString("dddd d") + "|dia+4");
                                                ListaDias.Add("El " + DateTime.Now.AddDays(5).ToString("dddd d") + "|dia+5");
                                        }
                                        ListaDias.Add("Un día específico|dia");
                                        EntradaRango.SetData = ListaDias.ToArray();
                                        EntradaRango.TextKey = "dia-0";
                                        EtiquetaDesde.Text = "día";
                                        break;
                                case "semana":
                                        List<string> ListaSemana = new List<string>();
                                        if (m_Rango.AllowPast) {
                                                ListaSemana.Add("La semana del " + DateTime.Now.AddDays(-((int)(DateTime.Now.DayOfWeek)) - 20).ToString("dddd d") + "|semana-3");
                                                ListaSemana.Add("La semana del " + DateTime.Now.AddDays(-((int)(DateTime.Now.DayOfWeek)) - 13).ToString("dddd d") + "|semana-2");
                                                ListaSemana.Add("La semana pasada|semana-1");

                                        }
                                        ListaSemana.Add("Esta semana|semana-0");
                                        if (m_Rango.AllowFuture) {
                                                ListaSemana.Add("La semana que viene|semana+1");
                                                ListaSemana.Add("La semana del " + DateTime.Now.AddDays(-((int)(DateTime.Now.DayOfWeek)) + 15).ToString("dddd d") + "|semana+2");
                                                ListaSemana.Add("La semana del " + DateTime.Now.AddDays(-((int)(DateTime.Now.DayOfWeek)) + 22).ToString("dddd d") + "|semana+3");
                                        }
                                        ListaSemana.Add("La semana del|semana");

                                        EntradaRango.SetData = ListaSemana.ToArray();
                                        EntradaRango.TextKey = "semana-0";
                                        EtiquetaDesde.Text = "día";
                                        break;
                                case "mes":
                                        List<string> ListaMes = new List<string>();
                                        if (m_Rango.AllowPast) {
                                                ListaMes.Add(DateTime.Now.AddMonths(-8).ToString("MMMM").ToTitleCase() + "|mes-8");
                                                ListaMes.Add(DateTime.Now.AddMonths(-7).ToString("MMMM").ToTitleCase() + "|mes-7");
                                                ListaMes.Add(DateTime.Now.AddMonths(-6).ToString("MMMM").ToTitleCase() + "|mes-6");
                                                ListaMes.Add(DateTime.Now.AddMonths(-5).ToString("MMMM").ToTitleCase() + "|mes-5");
                                                ListaMes.Add(DateTime.Now.AddMonths(-4).ToString("MMMM").ToTitleCase() + "|mes-4");
                                                ListaMes.Add(DateTime.Now.AddMonths(-3).ToString("MMMM").ToTitleCase() + "|mes-3");
                                                ListaMes.Add(DateTime.Now.AddMonths(-2).ToString("MMMM").ToTitleCase() + "|mes-2");
                                                ListaMes.Add("El mes pasado|mes-1");
                                        }
                                        ListaMes.Add("Este mes|mes-0");
                                        if (m_Rango.AllowFuture) {
                                                ListaMes.Add("El mes que viene|mes+1");
                                                ListaMes.Add(DateTime.Now.AddMonths(2).ToString("MMMM").ToTitleCase() + "|mes+2");
                                                ListaMes.Add(DateTime.Now.AddMonths(3).ToString("MMMM").ToTitleCase() + "|mes+3");
                                                ListaMes.Add(DateTime.Now.AddMonths(4).ToString("MMMM").ToTitleCase() + "|mes+4");
                                        }
                                        EntradaRango.SetData = ListaMes.ToArray();
                                        EntradaRango.TextKey = "mes-0";
                                        EtiquetaDesde.Text = "mes";
                                        break;
                                case "rango":
                                case "-":
                                        EntradaRango.SetData = null;
                                        EntradaRango.TextKey = null;
                                        EntradaRango.Text = "-";
                                        EtiquetaDesde.Text = "Desde";
                                        m_Rango.Rep = "-";
                                        break;
                                case "todas":
                                case "*":
                                        EntradaRango.SetData = null;
                                        EntradaRango.TextKey = null;
                                        EntradaRango.Text = "*";
                                        EtiquetaDesde.Text = "Desde";
                                        m_Rango.Rep = "*";
                                        break;
                        }

                        EntradaRango_TextChanged(sender, e);
                }

                private void EntradaRango_TextChanged(object sender, EventArgs e)
                {
                        if (EntradaRango.TextKey.Length > 0)
                                m_Rango.Rep = EntradaRango.TextKey;

                        bool MuestraDesde = false, MuestraHasta = false;

                        EntradaRango.Visible = m_Rango.Rep != "*" && m_Rango.Rep != "-";

                        MuestraDesde = EntradaTipoDeRango.TextKey == "rango" ||
                                EntradaRango.TextKey == "dia" ||
                                EntradaRango.TextKey == "semana";

                        MuestraHasta = EntradaTipoDeRango.TextKey == "rango";

                        EntradaRango.Visible = EntradaTipoDeRango.TextKey == "dia" ||
                                EntradaTipoDeRango.TextKey == "semana" ||
                                EntradaTipoDeRango.TextKey == "mes";

                        EtiquetaDesde.Visible = MuestraDesde;
                        EntradaDesde.Visible = MuestraDesde;
                        EntradaHasta.Visible = MuestraHasta;
                        EtiquetaHasta.Visible = MuestraHasta;

                        PanelFechas.Visible = MuestraDesde || MuestraHasta;
                }

                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public Lfx.Types.DateRange Rango
                {
                        get
                        {
                                DbDateTime Desde = Lfx.Types.Parsing.ParseDate(EntradaDesde.Text);
                                DbDateTime Hasta = Lfx.Types.Parsing.ParseDate(EntradaHasta.Text);
                                if (Desde != null)
                                        m_Rango.From = Desde.Value;
                                if (Hasta != null)
                                        m_Rango.To = Hasta.Value;
                                else if(Desde != null)
                                        m_Rango.To = Desde.Value;
                                return m_Rango;
                        }
                        set
                        {
                                switch (value.RangeType)
                                {
                                        case Lfx.Types.DateRangeTypes.Day:
                                                EntradaTipoDeRango.TextKey = "dia";
                                                break;
                                        case Lfx.Types.DateRangeTypes.Week:
                                                EntradaTipoDeRango.TextKey = "semana";
                                                break;
                                        case Lfx.Types.DateRangeTypes.Month:
                                                EntradaTipoDeRango.TextKey = "mes";
                                                break;
                                        case Lfx.Types.DateRangeTypes.Range:
                                                EntradaTipoDeRango.TextKey = "rango";
                                                break;
                                        case Lfx.Types.DateRangeTypes.All:
                                                EntradaTipoDeRango.TextKey = "todas";
                                                break;
                                }
                                EntradaRango.TextKey = value.Rep;
                                EntradaDesde.Text = Lfx.Types.Formatting.FormatDate(value.From);
                                EntradaHasta.Text = Lfx.Types.Formatting.FormatDate(value.To);
                                m_Rango = value;
                        }
                }

                private void EntradaDesde_TextChanged(object sender, EventArgs e)
                {
                        DbDateTime Fecha = Lfx.Types.Parsing.ParseDate(EntradaDesde.Text);
                        if (Fecha != null)
                                m_Rango.From = Fecha.Value;
                }

                private void EntradaHasta_TextChanged(object sender, EventArgs e)
                {
                        DbDateTime Fecha = Lfx.Types.Parsing.ParseDate(EntradaHasta.Text);
                        if (Fecha != null)
                                m_Rango.To = Fecha.Value;
                }

                private void Combos_SizeChanged(object sender, EventArgs e)
                {
                        PanelCombos.Height = (EntradaRango.Height > EntradaTipoDeRango.Height ? EntradaRango.Height : EntradaTipoDeRango.Height) + 4;
                }

                private void Paneles_SizeChanged(object sender, EventArgs e)
                {
                        if (this.AutoSize)
                                this.Height = PanelCombos.Height + (PanelFechas.Visible ? PanelFechas.Height : 0) + 2;
                }
        }
}
