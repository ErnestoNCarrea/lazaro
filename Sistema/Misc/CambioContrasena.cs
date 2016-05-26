using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lazaro.WinMain.Misc
{
	public partial class CambioContrasena : Lui.Forms.Form
	{

                public CambioContrasena()
                {
                        InitializeComponent();
                }


		private void BotonAceptar_Click(object sender, System.EventArgs e)
		{
                        Lbl.Sys.Config.Actual.UsuarioConectado.Usuario.Cargar();

                        if (Lbl.Sys.Config.Actual.UsuarioConectado.Usuario.ContrasenaValida(EntradaContrasena.Text) == false) {
				System.Threading.Thread.Sleep(800);
				MessageBox.Show("La contraseña no es correcta. Por favor escriba su contraseña actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				EntradaContrasena.Focus();
                                return;
			}

                        if(EntradaContrasenaNueva1.Text.Length < 6 || EntradaContrasenaNueva1.Text.Length > 32) {
                                MessageBox.Show("La contraseña nueva no puede tener menos de 6 ni más de 32 caracteres. Por favor escriba otra contraseña.", "Error");
                                return;
                        }

                        if(EntradaContrasenaNueva1.Text != EntradaContrasenaNueva2.Text) {
                                MessageBox.Show("Debe escribir la contraseña nueva dos veces. Las dos contraseñas proporcionadas no coinciden.", "Error");
                                return;
                        }

                        Lbl.Sys.Config.Actual.UsuarioConectado.Usuario.Contrasena = EntradaContrasenaNueva1.Text;
                        Lbl.Sys.Config.Actual.UsuarioConectado.Usuario.Guardar();

                        this.Hide();
                        Lfx.Workspace.Master.RunTime.Toast("Su contraseña ha sido cambiada. A partir de ahora debe utilizar siempre su nueva contraseña.", "Error");
                        this.Close();
                }


		private void BotonCancelar_Click(object sender, System.EventArgs e)
		{
                        this.Hide();
                        Lfx.Workspace.Master.RunTime.Toast("Su contraseña no ha sido cambiada.", "Aviso");
                        this.Close();
                }
	}
}