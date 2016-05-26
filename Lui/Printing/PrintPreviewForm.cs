using System.Windows.Forms;

namespace Lui.Printing
{
        public partial  class PrintPreviewForm : Lui.Forms.ChildForm
        {
                public PrintPreviewForm()
                {
                        InitializeComponent();

                        PrintPreview.BackColor = this.DisplayStyle.BackgroundColor;
                        CancelCommandButton.Text = "Volver";
                        SaveButton.Visible = false;
                }


		private void BotonCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		private void PrintPreview_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			FormVistaPrevia_KeyDown(sender, e);
		}


		private void FormVistaPrevia_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.Control == false && e.Shift == false) {
				switch(e.KeyCode) {
					case Keys.PageDown:
						e.Handled = true;
						PrintPreview.Focus();
						SendKeys.Send("{PGDN}");
						break;
					case Keys.PageUp:
						e.Handled = true;
						PrintPreview.Focus();
						SendKeys.Send("{PGUP}");
						break;
				}
			}
		}


		private void BotonZoom_Click(object sender, System.EventArgs e)
		{
			PrintPreview.AutoZoom = !PrintPreview.AutoZoom;
			if(PrintPreview.AutoZoom == false)
				PrintPreview.Zoom = 1;
		}

	}
}