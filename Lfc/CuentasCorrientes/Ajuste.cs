using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.CuentasCorrientes
{
        public partial class Ajuste : Lui.Forms.DialogForm
        {
                protected internal decimal SaldoActual = 0;

                public Ajuste()
                {
                        InitializeComponent();
                }

                private void EntradaImporte_TextChanged(object sender, System.EventArgs e)
                {
                        decimal Importe = Lfx.Types.Parsing.ParseCurrency(EntradaImporte.Text);
                        if (Importe < 0 && EntradaDireccion.TextKey != "0")
                                EntradaDireccion.TextKey = "0";
                        else if (Importe > 0 && EntradaDireccion.TextKey != "1")
                                EntradaDireccion.TextKey = "1";

                        EntradaNuevoSaldo.Text = Lfx.Types.Formatting.FormatCurrency(SaldoActual + Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                }

                private void EntradaDireccion_TextChanged(object sender, System.EventArgs e)
                {
                        if (EntradaDireccion.TextKey == "0" && Lfx.Types.Parsing.ParseCurrency(EntradaImporte.Text) > 0)
                                EntradaImporte.Text = Lfx.Types.Formatting.FormatCurrency(-Lfx.Types.Parsing.ParseCurrency(EntradaImporte.Text), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        else if (EntradaDireccion.TextKey == "1" && Lfx.Types.Parsing.ParseCurrency(EntradaImporte.Text) < 0)
                                EntradaImporte.Text = Lfx.Types.Formatting.FormatCurrency(-Lfx.Types.Parsing.ParseCurrency(EntradaImporte.Text), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                }

                private void EntradaConcepto_Leave(object sender, EventArgs e)
                {
                        if (EntradaConcepto.ValueInt == 0)
                                EntradaConcepto.ValueInt = 30000;
                }
        }
}