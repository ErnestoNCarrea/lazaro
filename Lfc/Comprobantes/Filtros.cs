using System;
using System.Windows.Forms;

namespace Lfc.Comprobantes
{
        public partial class Filtros : Lui.Forms.DialogForm
        {
                public Filtros()
                {
                        InitializeComponent();
                }


                private void EntradaTipo_TextChanged(object sender, EventArgs e)
                {
                        EntradaLetra.Enabled = (EntradaTipo.TextKey == "Lbl.Comprobantes.Factura"
                                || EntradaTipo.TextKey == "Lbl.Comprobantes.ComprobanteFacturable"
                                || EntradaTipo.TextKey == "Lbl.Comprobantes.NotaDeCredito"
                                || EntradaTipo.TextKey == "Lbl.Comprobantes.NotaDeDebito");
                }
        }
}