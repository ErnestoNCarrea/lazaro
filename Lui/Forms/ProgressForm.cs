using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lui.Forms
{
	public partial class ProgressForm : Lui.Forms.Form
	{
                public Lfx.Types.OperationProgress Progreso = null;

                public ProgressForm()
                {
                        this.DisplayStyle = Lazaro.Pres.DisplayStyles.Template.Current.White;
                        InitializeComponent();
                }

                public void MostrarProgreso(IList<Lfx.Types.OperationProgress> operaciones, Lfx.Types.OperationProgress progreso)
                {
                        this.Progreso = progreso;

                        this.TopMost = progreso.Modal;
                        ProgressBar.Maximum = progreso.Max;
                        if (ProgressBar.Value > 0)
                                ProgressBar.Style = ProgressBarStyle.Continuous;
                        else
                                ProgressBar.Style = ProgressBarStyle.Marquee;


                        EtiquetaNombreOperacion.Text = progreso.Name;
                        if (operaciones.Count > 1)
                                EtiquetaOtrasOperaciones.Text = "(Hay otras operaciones pendientes)";
                        EtiquetaEstado.Text = progreso.Status;
                        EtiquetaDescripcion.Text = progreso.Description;
                        if (progreso.Value < ProgressBar.Minimum)
                                ProgressBar.Value = ProgressBar.Minimum;
                        else if (progreso.Value > ProgressBar.Maximum)
                                ProgressBar.Value = ProgressBar.Maximum;
                        else
                                ProgressBar.Value = progreso.Value;
                        BotonCancelar.Visible = progreso.Cancelable;

                        this.Refresh();
                }

                private void BotonCancelar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        if (this.Progreso != null && this.Progreso.Cancelable)
                                this.Progreso.Cancelar = true;
                }
	}
}