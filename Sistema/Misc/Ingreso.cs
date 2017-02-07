using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lazaro.WinMain.Misc
{
	public partial class Ingreso : Lui.Forms.Form
	{

                public Ingreso()
                {
                        InitializeComponent();
                }


		private void FormIngreso_Load(object sender, System.EventArgs e)
		{
                        int UltimoUsuario = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Ingreso.UltimoUsuario", 0);
                        if (UltimoUsuario == 0 && Lfx.Workspace.Master.ConnectionParameters.ServerName.ToUpperInvariant() == "LOCALHOST")
                                // Si estoy en localhost, el usuario predeterminado es Administrador
                                UltimoUsuario = 1;

                        EntradaUsuario.ValueInt = UltimoUsuario;
		}


		private void BotonAceptar_Click(object sender, System.EventArgs e)
		{
                        if (EntradaUsuario.ValueInt == 0) {
                                MessageBox.Show("Por favor ingrese su número de usuario y su contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return;
                        }

                        if (EntradaUsuario.ValueInt == 1 && Lfx.Workspace.Master.DebugMode == false) {
                                string[] EstacionesAdministrador = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Ingreso.Administrador.Estaciones", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                bool Puede = false;
                                if (EstacionesAdministrador.Length == 0) {
                                        Puede = true;
                                } else {
                                        foreach (string Estacion in EstacionesAdministrador) {
                                                if (Estacion.ToUpperInvariant() == Lfx.Environment.SystemInformation.MachineName) {
                                                        Puede = true;
                                                        break;
                                                }
                                        }
                                }

                                if (Puede == false) {
                                        System.Threading.Thread.Sleep(800);
                                        Lbl.Sys.Config.ActionLog(Lfx.Workspace.Master.MasterConnection, Lbl.Sys.Log.Acciones.LogOnFail, EntradaUsuario.Elemento, "Equipo no permitido.");
                                        MessageBox.Show("No se permite el acceso como Administrador desde este equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        return;
                                }
                        }

                        Lbl.Personas.Usuario Usu = new Lbl.Personas.Usuario(Lfx.Workspace.Master.MasterConnection, EntradaUsuario.ValueInt);
                        if(Usu.ContrasenaValida(EntradaContrasena.Text) == false) {
				System.Threading.Thread.Sleep(800);
                                Lbl.Sys.Config.ActionLog(Lfx.Workspace.Master.MasterConnection, Lbl.Sys.Log.Acciones.LogOnFail, EntradaUsuario.Elemento, "Usuario o contraseña incorrecto.");
				MessageBox.Show("El nombre de usuario o la contraseña son incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                EntradaContrasena.SelectionStart = 0;
                                EntradaContrasena.SelectionLength = EntradaContrasena.Text.Length;
				EntradaContrasena.Focus();
			} else {
				OkButton.Text = "Ingresando...";
				OkButton.Refresh();
                                //Lbl.Personas.Persona Usuario = new Lbl.Personas.Persona(Lfx.Workspace.Master.MasterConnection, Usu.Id);
                                Lbl.Sys.Config.Actual.UsuarioConectado = new Lbl.Sys.Configuracion.UsuarioConectado(Usu);
                                Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Ingreso.UltimoUsuario", Lbl.Sys.Config.Actual.UsuarioConectado.Id.ToString(), Lfx.Environment.SystemInformation.MachineName);
				Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Ingreso.UltimoIngreso", Lfx.Types.Formatting.FormatDateTimeSql(System.DateTime.Now), Lfx.Environment.SystemInformation.MachineName);
                                Lbl.Sys.Config.ActionLog(Lfx.Workspace.Master.MasterConnection, Lbl.Sys.Log.Acciones.LogOn, Usu, null);
				this.Close();
			}
		}


		private void BotonCancelar_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("¿Está seguro de que desea abandonar el programa?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				System.Environment.Exit(0);
			}
		}


		private void CambioDatos(object sender, System.EventArgs e)
		{
			OkButton.Enabled = EntradaUsuario.Text.Length > 0;
		}

                private void BotonWebAyuda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        if (EntradaUsuario.ValueInt == 1)
                                Lui.Forms.MessageBox.Show("Si es la primera vez que utiliza el sistema, escriba la contraseña 'admin' (sin las comillas)", "Información");
                        else
                                Lui.Forms.MessageBox.Show("Si no dispone de una contraseña, por favor póngase en contacto con el administrador.", "Información");
                }
	}
}