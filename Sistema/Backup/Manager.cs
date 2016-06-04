using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Lazaro.WinMain.Backup
{
        public partial class Manager : Lui.Forms.ChildDialogForm
        {
                Lfx.Backups.Manager BackupManager = new Lfx.Backups.Manager();

                public Manager()
                {
                        InitializeComponent();

                        OkButton.Visible = false;
                        MostrarListaBackups();
                }


                protected override void OnActivated(EventArgs e)
                {
                        base.OnActivated(e);
                        MostrarListaBackups();
                }

                public void MostrarListaBackups()
                {
                        BackupManager.BackupPath = System.IO.Path.Combine(Lbl.Sys.Config.CarpetaEmpresa, "Copias de seguridad" + System.IO.Path.DirectorySeparatorChar);
                        List<Lfx.Backups.BackupInfo> Backups = this.BackupManager.GetBackups();
                        string BackupMasNuevo = this.BackupManager.GetNewestBackupName();

                        Listado.BeginUpdate();
                        Listado.Items.Clear();
                        int i = 1;
                        foreach (Lfx.Backups.BackupInfo Backup in Backups) {
                                ListViewItem Itm = new ListViewItem(i.ToString("0000"));
                                Itm = Listado.Items.Add(Backup.Name);
                                if (BackupMasNuevo == Backup.Name) {
                                        Itm.Font = new Font(Itm.Font, FontStyle.Bold);
                                }
                                Itm.SubItems.Add(i.ToString("00"));
                                Itm.SubItems.Add(Lfx.Types.Formatting.FormatSmartDateAndTime(Backup.BackupDate));
                                Itm.SubItems.Add(Backup.UserName);
                                i++;
                        }
                        Listado.EndUpdate();
                }


                private void BotonBackup_Click(System.Object sender, System.EventArgs e)
                {
                        BotonBackup.Enabled = false;
                        Ejecutor.Exec("BACKUP NOW");
                }


                private void BotonEliminar_Click(object sender, System.EventArgs e)
                {
                        if (Listado.SelectedItems.Count > 0 && Listado.SelectedItems[0] != null) {
                                string NombreCarpeta = Listado.SelectedItems[0].Text;
                                Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("Puede eliminar una copia de seguridad antigua o que ya no sea de utilidad. Al eliminar una copia de seguridad no se modificarán los datos actualmente almacenados en el sistema, ni tampoco se impide que el sistema haga nuevas copias de seguridad.", "¿Desea eliminar la copia de seguridad seleccionada?");
                                Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                                if (Pregunta.ShowDialog() == DialogResult.OK) {
                                        this.BackupManager.Delete(NombreCarpeta);
                                        MostrarListaBackups();
                                }
                        }
                }


                private void BotonRestaurar_Click(object sender, System.EventArgs e)
                {
                        if (Listado.SelectedItems.Count > 0 && Listado.SelectedItems[0] != null) {
                                string NombreCarpeta = Listado.SelectedItems[0].Text;
                                string FechaYHora = Listado.SelectedItems[0].SubItems[2].Text;

                                WinMain.Backup.Restore Pregunta = new WinMain.Backup.Restore();
                                Pregunta.lblFecha.Text = FechaYHora;
                                if (Pregunta.ShowDialog() == DialogResult.OK) {
                                        this.BackupManager.Restore(NombreCarpeta);
                                        Lfx.Workspace.Master.RunTime.Execute("REBOOT");
                                        this.Close();
                                }
                        }
                }

                private void BotonCopiar_Click(object sender, EventArgs e)
                {
                        Lfx.Environment.Shell.Execute(this.BackupManager.BackupPath, "", ProcessWindowStyle.Normal, false);
                }
        }
}