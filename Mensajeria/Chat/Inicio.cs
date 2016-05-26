using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lazaro.Mensajeria.Chat
{
        public partial class Inicio : Lui.Forms.Form
        {
                [DllImport("user32.dll")]
                static extern Int32 FlashWindowEx(ref FLASHWINFO pwfi);

                [StructLayout(LayoutKind.Sequential)]
                public struct FLASHWINFO
                {
#pragma warning disable CS3003 // El tipo no es conforme a CLS
                        public UInt32 cbSize;
#pragma warning restore CS3003 // El tipo no es conforme a CLS
                        public IntPtr hwnd;
                        public Int32 dwFlags;
#pragma warning disable CS3003 // El tipo no es conforme a CLS
                        public UInt32 uCount;
#pragma warning restore CS3003 // El tipo no es conforme a CLS
                        public Int32 dwTimeout;
                }


                private bool Active = false;

                public Inicio()
                {
                        InitializeComponent();
                        this.DisplayStyle = Lazaro.Pres.DisplayStyles.Template.Current.White;
                        Lfx.Workspace.Master.RunTime.IpcEvent += new Lfx.RunTimeServices.IpcEventHandler(Workspace_IpcEvent);
                }


                public ChatControl IniciarChat(string nombre)
                {
                        foreach (Lbl.Notificaciones.UsuarioConectado Usu in Lbl.Notificaciones.Administrador.Usuarios.Values) {
                                if (Usu.Nombre == nombre) {
                                        return this.IniciarChat(Usu.Persona, Usu.Estacion);
                                }
                        }

                        return null;
                }


                protected override void OnClosing(CancelEventArgs e)
                {
                        TimerContactos.Stop();
                        this.Hide();
                        e.Cancel = true;
                        base.OnClosing(e);
                }


                protected override void OnShown(EventArgs e)
                {
                        TimerContactos.Interval = 1000;
                        TimerContactos.Start();
                        base.OnShown(e);
                }


                protected override void OnActivated(EventArgs e)
                {
                        this.Active = true;
                        base.OnActivated(e);
                }


                protected override void OnDeactivate(EventArgs e)
                {
                        this.Active = false;
                        base.OnDeactivate(e);
                }


                public ChatControl IniciarChat(Lbl.Personas.Persona personaRemota, string estacionRemota)
                {
                        if (this.InvokeRequired) {
                                object Res = this.Invoke((Func<object>)(delegate { return this.IniciarChat(personaRemota, estacionRemota); }));
                                return Res as ChatControl;
                        } else {

                                ChatControl NuevoCtrl = new ChatControl();

                                NuevoCtrl.Margin = new Padding(8);
                                NuevoCtrl.Dock = DockStyle.Fill;
                                NuevoCtrl.Visible = true;
                                this.SuspendLayout();
                                this.Controls.Add(NuevoCtrl);
                                this.ResumeLayout(true);

                                NuevoCtrl.IniciarChat(personaRemota, estacionRemota);

                                ToolStripButton Pestania = new ToolStripButton(personaRemota.ToString());
                                Pestania.Margin = new System.Windows.Forms.Padding(2);
                                Pestania.Tag = NuevoCtrl;
                                Pestania.Checked = true;
                                this.Pestanias.Items.Add(Pestania);

                                NuevoCtrl.Select();
                                Listado.Visible = false;

                                return NuevoCtrl;
                        }
                }


                public void MensajeRecibido(Lbl.Notificaciones.INotificacion notif)
                {
                        ChatControl Ctrl = null;
                        bool Encontrado = false;
                        foreach (System.Windows.Forms.ToolStripItem Btn in this.Pestanias.Items) {
                                if (Btn is System.Windows.Forms.ToolStripButton) {
                                        Ctrl = Btn.Tag as ChatControl;
                                        if (Ctrl.PersonaRemota.Id == notif.Remitente.Id) {
                                                Encontrado = true;
                                                Ctrl.MensajeRecibido(notif);
                                        }
                                }
                        }

                        if (Encontrado == false) {
                                Ctrl = this.IniciarChat(notif.Remitente, notif.EstacionOrigen);
                                Ctrl.MensajeRecibido(notif);
                        }

                        if (this.InvokeRequired) {
                                this.Invoke(new MethodInvoker(delegate { this.ShowAndFlash(); }));
                        } else {
                                this.ShowAndFlash();
                        }
                }


                public void ShowAndFlash()
                {
                        if (this.Visible == false)
                                this.Show();

                        if (this.Active == false && Lfx.Environment.SystemInformation.Platform == Lfx.Environment.SystemInformation.Platforms.Windows) {
                                FLASHWINFO fw = new FLASHWINFO();
                                fw.cbSize = Convert.ToUInt32(Marshal.SizeOf(typeof(FLASHWINFO)));
                                fw.hwnd = this.Handle;
                                fw.dwFlags = 2 + 4;
                                fw.uCount = 5;
                                FlashWindowEx(ref fw);
                        }
                }


                public void MostrarContactos()
                {
                        if (Lbl.Notificaciones.Administrador.Principal != null) {
                                Lbl.Notificaciones.Administrador.Principal.ActualizarUsuariosConectados();

                                List<ListViewItem> Eliminar = new List<ListViewItem>();
                                foreach (ListViewItem Itm in Listado.Items) {
                                        Eliminar.Add(Itm);
                                }

                                if (Lbl.Notificaciones.Administrador.Usuarios.Count > 0) {
                                        foreach (Lbl.Notificaciones.UsuarioConectado Usu in Lbl.Notificaciones.Administrador.Usuarios.Values) {
                                                string IdContacto = Usu.Id.ToString();

                                                ListViewItem Itm;
                                                if (Listado.Items.ContainsKey(IdContacto))
                                                        Itm = Listado.Items[IdContacto];
                                                else
                                                        Itm = Listado.Items.Add(IdContacto, Usu.Nombre, 0);

                                                if (Usu.Estado == 0) {
                                                        Itm.ForeColor = Color.Silver;
                                                        Itm.ToolTipText = "Desconectado";
                                                } else {
                                                        Itm.ForeColor = Listado.ForeColor;
                                                        Itm.ToolTipText = "Conectado en " + Usu.Estacion;
                                                }

                                                if (Eliminar.Contains(Itm))
                                                        Eliminar.Remove(Itm);

                                                Itm.Name = IdContacto;
                                                Itm.Text = Usu.Nombre;
                                        }
                                }


                                foreach (ListViewItem Itm in Eliminar) {
                                        Listado.Items.Remove(Itm);
                                }


                                // Actualizo las ventanas de chat
                                foreach (System.Windows.Forms.ToolStripItem Btn in this.Pestanias.Items) {
                                        if (Btn is System.Windows.Forms.ToolStripButton) {
                                                ChatControl Ctrl = Btn.Tag as ChatControl;
                                                Ctrl.Offline = !Lbl.Notificaciones.Administrador.Usuarios.ContainsKey(Ctrl.PersonaRemota.Id);
                                        }
                                }

                                Listado.Sort();
                        }
                }


                public void Workspace_IpcEvent(object sender, ref Lfx.RunTimeServices.IpcEventArgs e)
                {
                        if (e.Destination == "Lazaro.Mensajeria") {
                                switch(e.EventType) {
                                        case Lfx.RunTimeServices.IpcEventArgs.EventTypes.Notification:
                                                this.MensajeRecibido(e.Arguments[0] as Lbl.Notificaciones.INotificacion);
                                                break;
                                }
                        }
                }


                private void Pestanias_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
                {
                        this.MostrarChat(e.ClickedItem.Text);
                }


                private void Listado_DoubleClick(object sender, EventArgs e)
                {
                        if (Listado.SelectedItems != null && Listado.SelectedItems.Count > 0) {
                                string NombreClicado = Listado.SelectedItems[0].Text;
                                if (this.MostrarChat(NombreClicado) == false) {
                                        // Inicio un nuevo chat
                                        this.IniciarChat(NombreClicado);
                                }
                        }
                }


                public bool MostrarChat(string nombre)
                {
                        bool Encontrado = false;
                        foreach (System.Windows.Forms.ToolStripItem Btn in this.Pestanias.Items) {
                                if (Btn is System.Windows.Forms.ToolStripButton) {
                                        ChatControl Ctrl = Btn.Tag as ChatControl;
                                        if (Ctrl.PersonaRemota.Nombre == nombre) {
                                                Ctrl.Visible = true;
                                                Encontrado = true;
                                                Ctrl.Select();
                                        } else {
                                                Ctrl.Visible = false;
                                        }
                                }
                        }

                        Listado.Visible = Encontrado == false;

                        return Encontrado;
                }


                private void TimerContactos_Tick(object sender, EventArgs e)
                {
                        this.TimerContactos.Stop();
                        this.MostrarContactos();

                        this.TimerContactos.Interval = 10000;
                        this.TimerContactos.Start();
                }
        }
}
