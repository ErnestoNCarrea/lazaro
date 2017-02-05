using System;
using System.Windows.Forms;

namespace Lazaro.WinMain.Misc
{
	public partial class AcercaDe : Lui.Forms.Form
	{
                private bool YaBusqueActualizaciones = false;

                public AcercaDe()
                {
                        InitializeComponent();

                        EtiquetaActualizar.Visible = Lfx.Updates.Updater.Master != null;
                }


                private void FormAcercaDe_Load(object sender, System.EventArgs e)
                {
                        ListaComponentes.BackColor = this.BackColor;

                        EtiquetaUsuario.Text = Lbl.Sys.Config.Actual.UsuarioConectado.Id.ToString() + " (" + Lbl.Sys.Config.Actual.UsuarioConectado.Persona.Nombre + ") / " + System.Environment.MachineName;

                        ListaComponentes.Items.Add("Lazaro versión " + System.Diagnostics.FileVersionInfo.GetVersionInfo(Lfx.Environment.Folders.ApplicationFolder + "Lazaro.exe").ProductVersion + " del " + new System.IO.FileInfo(Lfx.Environment.Folders.ApplicationFolder + "Lazaro.exe").LastWriteTime.ToString(Lfx.Types.Formatting.DateTime.FullDateTimePattern));
                        System.IO.DirectoryInfo Dir = new System.IO.DirectoryInfo(Lfx.Environment.Folders.ApplicationFolder);
                        foreach (System.IO.FileInfo DirItem in Dir.GetFiles("*.dll")) {
                                ListaComponentes.Items.Add(DirItem.Name + " versión " + System.Diagnostics.FileVersionInfo.GetVersionInfo(DirItem.FullName).ProductVersion + " del " + new System.IO.FileInfo(DirItem.FullName).LastWriteTime.ToString(Lfx.Types.Formatting.DateTime.FullDateTimePattern));
                        }

                        Dir = new System.IO.DirectoryInfo(Lfx.Environment.Folders.ComponentsFolder);
                        foreach (System.IO.FileInfo DirItem in Dir.GetFiles("*.dll", System.IO.SearchOption.AllDirectories)) {
                                ListaComponentes.Items.Add(DirItem.Name + " versión " + System.Diagnostics.FileVersionInfo.GetVersionInfo(DirItem.FullName).ProductVersion + " del " + new System.IO.FileInfo(DirItem.FullName).LastWriteTime.ToString(Lfx.Types.Formatting.DateTime.FullDateTimePattern));
                        }

                        EtiquetaFramework.Text = Lfx.Environment.SystemInformation.RuntimeName;
                        if (System.Runtime.InteropServices.Marshal.SizeOf(typeof(System.IntPtr)) == 8)
                                EtiquetaFramework.Text += " (64 bits)";

                        EtiquetaAlmacen.Text = Lfx.Workspace.Master.ServerVersion;
                }


		private void BotonActualizar_LinkClicked(System.Object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
                        this.AplicarActualizacion();
		}


                private void AplicarActualizacion()
                {
                        this.Close();
                        if (Lfx.Updates.Updater.Master != null && Lfx.Updates.Updater.Master.UpdatesPending()) {
                                Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("Se descargó una nueva versión de Lázaro. Debe reiniciar la aplicación para instalar la actualización.", "¿Desea reiniciar ahora?");
                                Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                                DialogResult Respuesta = Pregunta.ShowDialog();
                                if (Respuesta == DialogResult.OK)
                                        Ejecutor.Exec("REBOOT");
                        }
                }

		private void OkButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

                private void BotonWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        Help.ShowHelp(this, "http://www.lazarogestion.com");
                }

                private void TimerBuscarActualizaciones_Tick(object sender, EventArgs e)
                {
                        TimerBuscarActualizaciones.Stop();

                        if (Lfx.Updates.Updater.Master == null) {
                                PicEsperar.Visible = false;
                                if (Lfx.Workspace.Master.DebugMode)
                                        EtiquetaActualizar.Text = "Modo de depuración activado.";
                                return;
                        }

                        if (YaBusqueActualizaciones == false) {
                                YaBusqueActualizaciones = true;
                                Lfx.Updates.Updater.Master.ForceCheckNow();
                        }

                        if (Lfx.Updates.Updater.Master.Progress.IsRunning) {
                                PicEsperar.Visible = true;
                                if (Lfx.Updates.Updater.Master.Progress.Max == 0) {
                                        EtiquetaActualizar.Text = "Buscando...";
                                } else {
                                        if (Lfx.Updates.Updater.Master.Progress.Status.StartsWith("Aplicando"))
                                                EtiquetaActualizar.Text = "Instalando " + Lfx.Updates.Updater.Master.Progress.PercentDone.ToString() + "%";
                                        else
                                                EtiquetaActualizar.Text = "Descargando " + Lfx.Updates.Updater.Master.Progress.PercentDone.ToString() + "%";
                                }
                                EtiquetaActualizar.LinkArea = new LinkArea(0, 0);
                        } else {
                                if (Lfx.Updates.Updater.Master.UpdatesPending()) {
                                        PicEsperar.Visible = false;
                                        EtiquetaActualizar.Text = "Hay una actualización lista para aplicarse";
                                        EtiquetaActualizar.LinkArea = new LinkArea(0, EtiquetaActualizar.Text.Length);
                                } else {
                                        PicEsperar.Visible = false;
                                        EtiquetaActualizar.Text = "Lázaro está actualizado";
                                        EtiquetaActualizar.LinkArea = new LinkArea(0, 0);
                                }
                        }

                        TimerBuscarActualizaciones.Start();
                }

                private void EtiquetaActualizar_Click(object sender, EventArgs e)
                {
                        this.AplicarActualizacion();
                }

                private void EtiquetaAlmacen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        if (Lfx.Data.DatabaseCache.DefaultCache.ServerName == "localhost" || Lfx.Data.DatabaseCache.DefaultCache.ServerName == "127.0.0.1") {
                                if (string.Compare(EtiquetaAlmacen.Text, "5.0") > 0) {
                                        Help.ShowHelp(this, "http://www.lazarogestion.com/descargar/servidor/?curver=" + EtiquetaAlmacen.Text);
                                } else if (string.Compare(EtiquetaAlmacen.Text, "10.1.17") < 0) {
                                        Help.ShowHelp(this, "http://www.lazarogestion.com/descargar/servidor/?curver=" + EtiquetaAlmacen.Text);
                                } else {
                                        Lfx.Workspace.Master.RunTime.Toast("Está utilizando la última versión del almacén de datos. No es necesario actualizar.", "Aviso");
                                }
                        } else {
                                Lfx.Workspace.Master.RunTime.Toast("Está accediendo al almacén de datos a través de la red. Puede ver más información sobre el almacén de datos si utiliza esta misma opción en el equipo que tiene lo instalado (" + Lfx.Data.DatabaseCache.DefaultCache.ServerName  + ").", "Aviso");
                        }
                }
	}
}