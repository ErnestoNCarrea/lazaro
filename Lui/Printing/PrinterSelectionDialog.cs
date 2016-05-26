using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Lui.Printing
{
        public partial class PrinterSelectionDialog : Lui.Forms.DialogForm
	{
		private Lbl.Impresion.Impresora m_Resultado = null;
                protected string m_ExtraItems = "";
		private System.Windows.Forms.ColumnHeader NombreVisible;
                public bool MuestraImpresorasDeWindows = true, MuestraImpresorasLazaro = true;

                public PrinterSelectionDialog()
                {
                        InitializeComponent();
                }


                private void AgregarImpresora(Lbl.Impresion.Impresora impresora)
                {
                        ListViewItem Itm = Listado.Items.Add(impresora.Id.ToString());
                        Itm.SubItems.Add(impresora.Nombre);
                        Itm.Tag = impresora;

                        if (impresora == m_Resultado) {
                                if (Listado.SelectedItems.Count > 0)
                                        Listado.SelectedItems[0].Selected = false;

                                Itm.Selected = true;
                                Itm.Focused = true;
                        }
                }

		private void FormSeleccionarImpresora_Activated(object sender, System.EventArgs e)
		{
			Listado.Items.Clear();

                        if (MuestraImpresorasLazaro) {
                                Lbl.ColeccionGenerica<Lbl.Impresion.Impresora> Impresoras = Lbl.Sys.Config.Actual.Impresion.Impresoras;
                                if (Impresoras != null) {
                                        foreach (Lbl.Impresion.Impresora Impresora in Impresoras) {
                                                this.AgregarImpresora(Impresora);
                                        }
                                }
                        }

                        if (MuestraImpresorasDeWindows) {
                                foreach (string NombreImpresora in PrinterSettings.InstalledPrinters) {
                                        //PrinterSettings PrinterInfo = new PrinterSettings();
                                        //PrinterInfo.PrinterName = Impresora;

                                        Lbl.Impresion.Impresora Impr = Lbl.Impresion.Impresora.InstanciarImpresoraLocal(this.Connection, NombreImpresora);
                                        this.AgregarImpresora(Impr);
                                }
                        }
			
			Listado.Columns[1].Width = -2;
			if(Listado.Items.Count > 0 && Listado.SelectedItems.Count == 0) {
				Listado.Items[0].Selected = true;
				Listado.Items[0].Focused = true;
			}
		}


                public override Lfx.Types.OperationResult Ok()
                {
                        if (Listado.SelectedItems != null && Listado.SelectedItems.Count > 0)
                                m_Resultado = Listado.SelectedItems[0].Tag as Lbl.Impresion.Impresora;

                        this.DialogResult = DialogResult.OK;
                        this.Hide();
                        return base.Ok();
                }


		private void Listado_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Return) {
				e.Handled = true;
				this.Ok();
			}
		}


		private void Listado_DoubleClick(object sender, System.EventArgs e)
		{
			this.Ok();
		}

		public Lbl.Impresion.Impresora SelectedPrinter
		{
			get
			{
				return m_Resultado;
			}
			set
			{
				m_Resultado = value;
			}
		}
	}
}