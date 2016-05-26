using System;
using System.Windows.Forms;

namespace Lfc.Personas
{
        public partial class AltaDuplicada : Lui.Forms.Form
	{
		public AltaDuplicada()
		{
			InitializeComponent();
		}

		private void CmdCrearNuevo_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Yes;
			this.Hide();
		}

		private void CmdCancelar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Hide();
		}

		private void CmdActualizar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.No;
			this.Hide();
		}

                private void TimerHabilitarBotones_Tick(object sender, EventArgs e)
                {
                        TimerHabilitarBotones.Stop();
                        BotonCancelar.Focus();
                        BotonCancelar.Enabled = true;
                        BotonContinuar.Enabled = true;
                        BotonCorregir.Enabled = true;
                }
	}
}

