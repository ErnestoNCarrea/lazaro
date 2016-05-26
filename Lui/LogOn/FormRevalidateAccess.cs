using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lui.LogOn
{
	internal partial class FormRevalidateAccess : Lui.Forms.DialogForm
	{
		public string Explain = null;

		public FormRevalidateAccess()
		{
			InitializeComponent();
			CancelCommandButton.Text = "Cancelar";
		}

		public bool Revalidate()
		{
                        return this.ValidateAs(Lbl.Sys.Config.Actual.UsuarioConectado.Id);
		}

		public bool ValidateAs(int userId)
		{
			if(userId == 1) {
				Titulo.Text = "Escriba la contraseña de Administrador";
				if(Explain == null)
					LabelExplain.Text = "La operación que intenta realizar requiere por motivos de seguridad que escriba la contraseña de Administrador.";
				else
					LabelExplain.Text = Explain;
                        } else if (userId != Lbl.Sys.Config.Actual.UsuarioConectado.Id) {
				this.Titulo.Text = "Para continuar, por favor escriba la contraseña del usuario.";
				if(Explain == null)
					this.LabelExplain.Text = "La operación que intenta realizar requiere por motivos de seguridad que escribir la contraseña de un usuario con permiso.";
				else
					LabelExplain.Text = Explain;
			}

                        Lbl.Personas.Usuario Usuario = new Lbl.Personas.Usuario(this.Connection, userId);

			EntradaUsuario.Text = Usuario.Nombre;
			EntradaContrasena.Text = "";
			if(this.ShowDialog() == DialogResult.OK) {
				if(Usuario.ContrasenaValida(EntradaContrasena.Text) == true) {
					return true;
				} else {
					Lui.Forms.MessageBox.Show("La contraseña proporcionada no es correcta.", "Error");
					System.Threading.Thread.Sleep(1000);
					return false;
				}
			} else {
				return false;
			}
		}
	}
}