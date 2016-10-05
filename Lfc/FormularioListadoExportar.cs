using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lfc
{
        public enum FormatoExportar
        {
                Html,
                Excel,
                Imprimir,
                ImprimirAvanzado
        }

	public partial class FormularioListadoExportar : Lui.Forms.Form
	{
                public FormatoExportar SaveFormat = FormatoExportar.Html;

                public FormularioListadoExportar()
                {
                        InitializeComponent();
                }

		private void BotonHtml_Click(object sender, System.EventArgs e)
		{
                        this.SaveFormat = FormatoExportar.Html;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Hide();
		}


		private void BotonExcel_Click(object sender, System.EventArgs e)
		{
                        this.SaveFormat = FormatoExportar.Excel;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Hide();
		}

                private void BotonImprimir_Click(object sender, EventArgs e)
                {
                        this.SaveFormat = FormatoExportar.Imprimir;
                        this.DialogResult = DialogResult.OK;
                        this.Hide();
                }

                private void BotonCancelar_Click(object sender, EventArgs e)
                {
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.Hide();
                }

                private void BotonImprimirAvanzado_Click(object sender, EventArgs e)
                {
                        this.SaveFormat = FormatoExportar.ImprimirAvanzado;
                        this.DialogResult = DialogResult.OK;
                        this.Hide();
                }
	}
}