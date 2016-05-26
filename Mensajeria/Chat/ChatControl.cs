using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lazaro.Mensajeria.Chat
{
        public partial class ChatControl : UserControl
        {
                public Lbl.Personas.Persona PersonaRemota { get; set; }
                public string EstacionRemota { get; set; }

                private bool m_Offline = false;

                public ChatControl()
                {
                        InitializeComponent();
                }


                public void IniciarChat(Lbl.Personas.Persona personaRemota, string estacionRemota)
                {
                        this.PersonaRemota = personaRemota;
                        this.EstacionRemota = estacionRemota;
                        
                        EntradaConversacion.Text = this.PersonaRemota.Nombre + " está conectado/a en " + this.EstacionRemota + System.Environment.NewLine;
                        EntradaEnviar.Select();
                        
                        this.ActualizarEstado();
                }


                public void ActualizarEstado()
                {
                        EntradaConversacion.BackColor = this.BackColor;

                        if (this.Offline)
                                EtiquetaNombre.Text = PersonaRemota.Nombres + " (desconectado)";
                        else
                                EtiquetaNombre.Text = PersonaRemota.Nombres + " en " + EstacionRemota;
                }


                public void MensajeRecibido(Lbl.Notificaciones.INotificacion notif)
                {
                        if (EtiquetaNombre.InvokeRequired) {
                                this.Invoke(new MethodInvoker(delegate { this.MensajeRecibido(notif); }));
                        } else {
                                if (notif != null) {
                                        if (EntradaConversacion.Text.Length > 0)
                                                EntradaConversacion.AppendText(System.Environment.NewLine);
                                        EntradaConversacion.AppendText(this.PersonaRemota.Nombres + ": ");
                                        EntradaConversacion.AppendText(notif.Obs);
                                        EntradaConversacion.SelectionStart = EntradaConversacion.TextLength;
                                }

                                if (this.ParentForm.Visible == false && this.ParentForm.InvokeRequired) {
                                        this.ParentForm.Invoke(new MethodInvoker(delegate { this.ParentForm.Show(); }));
                                }
                        }
                }


                private void EntradaEnviar_KeyDown(object sender, KeyEventArgs e)
                {
                        if (e.KeyCode == Keys.Return && EntradaEnviar.Text.Length > 0) {
                                e.Handled = true;

                                Lbl.Notificaciones.NotificacionMemoria Notif = new Lbl.Notificaciones.NotificacionMemoria(this.PersonaRemota, this.EstacionRemota);
                                Notif.Nombre = EntradaEnviar.Text;
                                if (Notif.Nombre.Length > 40)
                                        Notif.Nombre = Notif.Nombre.Substring(0, 40);

                                Notif.Obs = EntradaEnviar.Text;
                                Notif.Destino = "Lazaro.Mensajeria";

                                if (Lbl.Notificaciones.Administrador.Principal.Enviar(Notif)) {
                                        if (EntradaConversacion.Text.Length > 0)
                                                EntradaConversacion.AppendText(System.Environment.NewLine);
                                        EntradaConversacion.AppendText("(no se pudo enviar el mensaje)");
                                } else {
                                        if (EntradaConversacion.Text.Length > 0)
                                                EntradaConversacion.AppendText(System.Environment.NewLine);
                                        EntradaConversacion.AppendText("Yo: ");
                                        EntradaConversacion.AppendText(EntradaEnviar.Text);

                                        EntradaEnviar.Text = "";
                                }
                        }
                }

                public bool Offline
                {
                        get
                        {
                                return m_Offline;
                        }
                        set
                        {
                                m_Offline = value;
                                this.ActualizarEstado();
                        }
                }
        }
}
