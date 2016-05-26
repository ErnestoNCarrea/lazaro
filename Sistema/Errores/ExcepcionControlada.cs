using System;
using System.Windows.Forms;

namespace Lazaro.WinMain.Errores
{
        public partial class ExcepcionControlada : Lui.Forms.Form
        {
                public ExcepcionControlada()
                {
                        this.DisplayStyle = Lazaro.Pres.DisplayStyles.Template.Current.White;
                        InitializeComponent();
                }

                private void BotonAmpliar_Click(object sender, EventArgs e)
                {
                        if (EtiquetaMasInformacion.Visible) {
                                this.Height -= EtiquetaMasInformacion.Height;
                                EtiquetaMasInformacion.Visible = false;
                        } else {
                                this.Height += EtiquetaMasInformacion.Height;
                                EtiquetaMasInformacion.Visible = true;
                        }
                }

                private void EtiquetaMasInformacion_TextChanged(object sender, EventArgs e)
                {
                        BotonAmpliar.Visible = (EtiquetaMasInformacion.Text.Length > 3);
                }

                private void BotonCerrar_Click(object sender, EventArgs e)
                {
                        this.Close();
                }
        }
}
