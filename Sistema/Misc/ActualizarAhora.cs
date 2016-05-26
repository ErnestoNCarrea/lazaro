using System;
using System.Windows.Forms;

namespace Lazaro.WinMain.Misc
{
        public partial class ActualizarAhora : Lui.Forms.Form
        {
                private bool YaBusqueActualizaciones = false;

                public ActualizarAhora()
                {
                        InitializeComponent();
                }

                private void BotonInstalar_Click(object sender, EventArgs e)
                {
                        switch (BotonInstalar.Text) {
                                case "Continuar":
                                        this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
                                        break;
                                case "Instalar":
                                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                        Lfx.Environment.Shell.Reboot();
                                        break;
                                case "Cancelar":
                                default:
                                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                        break;
                        }
                        this.Close();
                }

                private void TimerProgreso_Tick(object sender, EventArgs e)
                {
                        TimerProgreso.Stop();

                        if (Lfx.Updates.Updater.Master == null)
                                return;

                        if (YaBusqueActualizaciones == false) {
                                YaBusqueActualizaciones = true;
                                Lfx.Updates.Updater.Master.ForceCheckNow();
                        }

                        if (Lfx.Updates.Updater.Master.Progress.IsRunning) {
                                BotonInstalar.Text = "Cancelar";
                                EtiquetaEstado.Text = "Descargando...";
                                BarraProgreso.Maximum = Lfx.Updates.Updater.Master.Progress.Max;
                                BarraProgreso.Value = Lfx.Updates.Updater.Master.Progress.Value;
                                EtiquetaProgreso.Text = Lfx.Updates.Updater.Master.Progress.PercentDone.ToString() + "%";
                                EtiquetaAyuda.Text = @"Si no desea instalar la actualización ahora, haga clic en el botón 'Cancelar'. La descarga continuará en segundo plano y se instalará en otro momento.";
                        } else {
                                if (Lfx.Updates.Updater.Master.UpdatesPending()) {
                                        BotonInstalar.Text = "Instalar";
                                        EtiquetaEstado.Text = "Finalizado";
                                        EtiquetaProgreso.Text = "100%";
                                        BarraProgreso.Value = BarraProgreso.Maximum;
                                        EtiquetaAyuda.Text = @"Se descargaron las actualizaciones y están listas para ser instaladas. Haga clic en el botón 'Instalar'.";
                                        BotonInstalar.PerformClick();
                                        return;
                                } else {
                                        BotonInstalar.Text = "Continuar";
                                        EtiquetaEstado.Text = "Finalizado";
                                        EtiquetaAyuda.Text = @"No se encontraron actualizaciones. La actualización se intentará nuevamente en otro momento. Puede continuar.";
                                        BotonInstalar.PerformClick();
                                        return;
                                }
                        }

                        TimerProgreso.Start();
                }
        }
}
