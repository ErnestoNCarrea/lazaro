using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lui.Forms
{
        /// <summary>
        /// Control calendario.
        /// </summary>
        public partial class Calendar : EditableControl
        {

                private DateTime m_CurrentDate = System.DateTime.Now;
                private IList<DateTime> m_SelectedDates = new List<DateTime>();
                private bool m_ShowFocusRect = true;
                private bool m_MultiSelect = false;
                private string m_DateFormat = "dd/MM/yyyy";
                private IList<System.Windows.Forms.Label> Dias = new List<System.Windows.Forms.Label>();

                public event System.EventHandler SelectedDatesChanged;
                public event System.EventHandler CurrentDateChanged;
                new public event System.EventHandler DoubleClick;

                public Calendar()
                {
                        InitializeComponent();

                        for (int s = 1; s <= 6; s++) {
                                for (int d = 1; d <= 7; d++) {
                                        System.Windows.Forms.Label EtiquetaDia = new System.Windows.Forms.Label();
                                        EtiquetaDia.BackColor = this.DisplayStyle.DataAreaColor;
                                        EtiquetaDia.Text = "";
                                        EtiquetaDia.Size = new Size(28, 20);
                                        EtiquetaDia.TextAlign = ContentAlignment.MiddleCenter;
                                        EtiquetaDia.ForeColor = this.DisplayStyle.TextColor;
                                        EtiquetaDia.BringToFront();
                                        this.Controls.Add(EtiquetaDia);
                                        Dias.Add(EtiquetaDia);
                                        EtiquetaDia.MouseDown += new System.Windows.Forms.MouseEventHandler(EtiquetaDia_Click);
                                        EtiquetaDia.DoubleClick += new System.EventHandler(EtiquetaDia_DoubleClick);
                                }
                        }
                        EtiquetaMes.BackColor = this.DisplayStyle.BackgroundColor;
                        ReubicarDias();
                        MostrarCalendario();

                }

                

                public string DateFormat
                {
                        get
                        {
                                return m_DateFormat;
                        }
                        set
                        {
                                m_DateFormat = value;
                        }
                }

                public bool MultiSelect
                {
                        get
                        {
                                return m_MultiSelect;
                        }
                        set
                        {
                                m_MultiSelect = value;
                                if (m_MultiSelect == false && m_SelectedDates.Count > 0)
                                        m_SelectedDates = new List<DateTime>();
                        }
                }

                public bool ShowFocusRect
                {
                        get
                        {
                                return m_ShowFocusRect;
                        }
                        set
                        {
                                m_ShowFocusRect = value;
                                MostrarCalendario();
                        }
                }

                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public IList<DateTime> SelectedDates
                {
                        get
                        {
                                return m_SelectedDates;
                        }
                        set
                        {
                                m_SelectedDates = value;

                                this.MostrarCalendario();

                                if (SelectedDatesChanged != null)
                                        SelectedDatesChanged(this, null);
                        }
                }

                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public DateTime CurrentDate
                {
                        get
                        {
                                return m_CurrentDate;
                        }
                        set
                        {
                                m_CurrentDate = new DateTime(value.Year, value.Month, value.Day);
                                
                                if (m_MultiSelect == false)
                                        this.SelectedDates = new List<DateTime>() { m_CurrentDate };

                                MostrarCalendario();

                                if (this.CurrentDateChanged != null)
                                        this.CurrentDateChanged(this, null);
                        }
                }


                private void MostrarCalendario()
                {
                        System.Windows.Forms.Label EtiquetaDia = null;
                        int DiasDelMes = DateTime.DaysInMonth(m_CurrentDate.Year, m_CurrentDate.Month);

                        this.SuspendLayout();

                        EtiquetaMes.Text = m_CurrentDate.ToString(@"MMMM ""de"" yyyy");

                        int PrimerDia = System.Convert.ToInt32(DateTime.ParseExact(m_CurrentDate.ToString("MM/01/yyyy", System.Globalization.CultureInfo.InvariantCulture), "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture).DayOfWeek);

                        for (int i = 0; i <= PrimerDia - 1; i++) {
                                EtiquetaDia = ((System.Windows.Forms.Label)(Dias[i]));
                                EtiquetaDia.Enabled = false;
                                EtiquetaDia.Visible = false;
                                EtiquetaDia.Text = "?";
                                EtiquetaDia.Tag = 0;
                        }

                        for (int i = 1; i <= DiasDelMes; i++) {
                                EtiquetaDia = ((System.Windows.Forms.Label)(Dias[PrimerDia + i - 1]));
                                EtiquetaDia.Text = i.ToString();

                                if (IsSelected(new DateTime(m_CurrentDate.Year, m_CurrentDate.Month, i))) {
                                        EtiquetaDia.BackColor = this.DisplayStyle.SelectionColor;
                                        EtiquetaDia.ForeColor = this.DisplayStyle.TextColor;
                                } else {
                                        EtiquetaDia.BackColor = this.DisplayStyle.DataAreaColor;
                                        EtiquetaDia.ForeColor = this.DisplayStyle.TextColor;
                                }

                                if (m_ShowFocusRect && i == m_CurrentDate.Day)
                                        EtiquetaDia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                else
                                        EtiquetaDia.BorderStyle = System.Windows.Forms.BorderStyle.None;

                                EtiquetaDia.Visible = true;
                                EtiquetaDia.Enabled = true;
                                EtiquetaDia.Tag = i;
                        }

                        for (int i = 0; i <= 42 - DiasDelMes - PrimerDia - 1; i++) {
                                EtiquetaDia = ((System.Windows.Forms.Label)(Dias[DiasDelMes + PrimerDia + i]));
                                EtiquetaDia.Enabled = false;
                                EtiquetaDia.Visible = false;
                                EtiquetaDia.Text = "!";
                                EtiquetaDia.Tag = 0;
                        }

                        this.ResumeLayout();
                }


                private void Calendar_Resize(object sender, System.EventArgs e)
                {
                        ReubicarDias();
                }


                private void ReubicarDias()
                {
                        if (Dias.Count > 0) {
                                this.SuspendLayout();
                                System.Windows.Forms.Label EtiquetaDia = null;
                                for (int s = 1; s <= 6; s++) {
                                        for (int d = 1; d <= 7; d++) {
                                                EtiquetaDia = ((System.Windows.Forms.Label)(Dias[(s - 1) * 7 + d - 1]));
                                                EtiquetaDia.Location = new Point(EtiquetaDia1.Left + (d - 1) * 32, EtiquetaDia1.Top + s * 24);
                                                EtiquetaDia.BringToFront();
                                        }
                                }
                                PanelFondo.SendToBack();
                                this.ResumeLayout();
                        }
                }

                private void EtiquetaDia_DoubleClick(object sender, System.EventArgs e)
                {
                        if (this.DoubleClick != null)
                                this.DoubleClick(this, null);
                }

                private void EtiquetaDia_Click(object sender, System.Windows.Forms.MouseEventArgs e)
                {
                        if (this.Focused == false)
                                this.Select();
                        int Dia = (int)((System.Windows.Forms.Label)sender).Tag;
                        if (Dia > 0) {
                                this.CurrentDate = new DateTime(m_CurrentDate.Year, m_CurrentDate.Month, Dia);
                                if (m_MultiSelect)
                                        InvertSelectedState(m_CurrentDate);
                                else
                                        this.SelectedDates = new List<DateTime>() { this.CurrentDate };
                                MostrarCalendario();
                        }
                }


                protected override void OnKeyDown(KeyEventArgs e)
                {
                        switch (e.KeyCode) {
                                case Keys.Up:
                                        this.CurrentDate = m_CurrentDate.AddDays(-7);
                                        e.Handled = true;
                                        break;
                                case Keys.Down:
                                        this.CurrentDate = m_CurrentDate.AddDays(7);
                                        e.Handled = true;
                                        break;
                                case Keys.Left:
                                        this.CurrentDate = m_CurrentDate.AddDays(-1);
                                        e.Handled = true;
                                        break;
                                case Keys.Right:
                                        this.CurrentDate = m_CurrentDate.AddDays(1);
                                        e.Handled = true;
                                        break;
                                case Keys.PageUp:
                                        this.CurrentDate = m_CurrentDate.AddMonths(-1);
                                        e.Handled = true;
                                        break;
                                case Keys.PageDown:
                                        this.CurrentDate = m_CurrentDate.AddMonths(1);
                                        e.Handled = true;
                                        break;
                                case Keys.Space:
                                        if (m_MultiSelect) {
                                                InvertSelectedState(m_CurrentDate);
                                                MostrarCalendario();
                                                e.Handled = true;
                                        }
                                        break;
                                case Keys.Return:
                                        e.Handled = true;
                                        System.Windows.Forms.SendKeys.Send("{tab}");
                                        break;
                        }
                        base.OnKeyDown(e);
                }


                public void InvertSelectedState(DateTime fecha)
                {
                        // Invierte la marca de un da determinado
                        if (IsSelected(fecha))
                                SelectionRem(fecha);
                        else
                                SelectionAdd(fecha);

                        if (SelectedDatesChanged != null)
                                SelectedDatesChanged(this, null);
                }


                public void SetSelectedState(DateTime Fecha, bool Selected)
                {
                        // Marca a desmarca un da (independientemente de su estado actual, a diferencia de InvertSelectedState)
                        if (Selected == false && IsSelected(Fecha))
                                SelectionRem(Fecha);
                        else if (Selected && IsSelected(Fecha) == false)
                                SelectionAdd(Fecha);

                        if (null != SelectedDatesChanged)
                                SelectedDatesChanged(this, null);
                }


                private void SelectionAdd(System.DateTime fecha)
                {
                        if (m_SelectedDates == null)
                                m_SelectedDates = new List<DateTime>();
                        m_SelectedDates.Add(fecha);
                }

                private void SelectionRem(System.DateTime fecha)
                {
                        foreach (DateTime FechaSeleccionada in m_SelectedDates) {
                                if (FechaSeleccionada == fecha) {
                                        m_SelectedDates.Remove(FechaSeleccionada);
                                        break;
                                }
                        }
                }


                public bool IsSelected(System.DateTime fechaABuscar)
                {
                        if (m_SelectedDates == null)
                                return false;

                        foreach (System.DateTime Fecha in m_SelectedDates) {
                                if (Fecha == fechaABuscar)
                                        return true;
                        }
                        return false;
                }


                public void InvertSelectedRow()
                {
                        // Marca o desmarca la semana completa
                        DateTime PrimerDiaSemana = m_CurrentDate.AddDays(System.Convert.ToInt32(-System.Convert.ToInt64(m_CurrentDate.DayOfWeek)) + 1);
                        bool NuevoEstado = false;

                        // Me baso en el primer da de la semana para saber si marcar o desmarcar toda la semana
                        NuevoEstado = !IsSelected(PrimerDiaSemana);

                        int i = 0;
                        for (i = 1; i <= 7; i++) {
                                SetSelectedState(PrimerDiaSemana.AddDays(i - 1), NuevoEstado);
                        }

                        MostrarCalendario();
                }

                public void InvertSelectedMonth()
                {
                        int DiasDelMes = DateTime.DaysInMonth(m_CurrentDate.Year, m_CurrentDate.Month);
                        bool NuevoEstado = !IsSelected(new DateTime(m_CurrentDate.Year, m_CurrentDate.Month, 1));

                        for (int i = 1; i <= DiasDelMes; i++) {
                                SetSelectedState(new DateTime(m_CurrentDate.Year, m_CurrentDate.Month, i), NuevoEstado);
                        }
                        MostrarCalendario();
                }

        }
}
