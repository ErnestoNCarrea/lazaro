using System.Windows.Forms;

namespace Lazaro.WinMain.Config
{
	public partial class ErrorConexion : Lui.Forms.Form
	{
                public ErrorConexion()
                {
                        InitializeComponent();
                }


		private void BotonSalir_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}


		private void BotonReintentar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Retry;
		}


		private void BotonConfigurar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Yes;
		}

		public string Ayuda
		{
                        get
                        {
                                return EtiquetaAyuda.Text;
                        }
			set
			{
                                EtiquetaAyuda.Text = value;
			}
		}

                public string ErrorOriginal
                {
                        get
                        {
                                return EtiquetaErrorOriginal.Text;
                        }
                        set
                        {
                                EtiquetaErrorOriginal.Text = value;
                        }
                }
	}
}