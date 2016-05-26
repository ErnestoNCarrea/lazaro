using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc
{
        public partial class FormularioListadoTexto : Lui.Forms.ChildForm
        {
                public System.Text.StringBuilder ListingContent = new System.Text.StringBuilder();
                public Lazaro.Pres.Spreadsheet.Workbook Report;

                public FormularioListadoTexto()
                {
                        InitializeComponent();
                }

                public virtual Lfx.Types.OperationResult RefreshList()
                {
                        return new Lfx.Types.SuccessOperationResult();
                }


                private void BotonCancelar_Click(object sender, System.EventArgs e)
                {
                        this.Close();
                }

                private void BotonMostrar_Click(object sender, System.EventArgs e)
                {
                        RefreshList();
                }


                private void BotonCopiar_Click(object sender, System.EventArgs e)
                {
                        try {
                                Clipboard.SetDataObject(ListingContent.ToString());
                        } catch {
                                // Error de portapapeles
                        }
                }
        }
}