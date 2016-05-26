using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Tarjetas.Cupones
{
        public partial class Acreditar : Lui.Forms.DialogForm
        {
                internal bool IgnorarCambios;

                public Acreditar()
                {
                        InitializeComponent();
                }

                private void EntradaTotal_TextChanged(object sender, System.EventArgs e)
                {
                        if (IgnorarCambios == false) {
                                IgnorarCambios = true;
                                EntradaComisionUsuario.Text = Lfx.Types.Formatting.FormatCurrency(EntradaCuponesSubTotal.Text.ParseCurrency() - EntradaTotal.Text.ParseCurrency() - EntradaComisionTarjeta.Text.ParseCurrency() - EntradaComisionPlan.Text.ParseCurrency(), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                                IgnorarCambios = false;
                        }
                }

                private void EntradaComisionTarjeta_TextChanged(object sender, EventArgs e)
                {
                        lblComisionTarjetaPct.Text = "(" + Lfx.Types.Formatting.FormatNumber(EntradaComisionTarjeta.Text.ParseCurrency() / EntradaCuponesSubTotal.Text.ParseCurrency() * 100, 2) + "%)";
                }

                private void EntradaComisionPlan_TextChanged(object sender, EventArgs e)
                {
                        lblComisionPlanPct.Text = "(" + Lfx.Types.Formatting.FormatNumber(EntradaComisionPlan.Text.ParseCurrency() / EntradaCuponesSubTotal.Text.ParseCurrency() * 100, 2) + "%)";
                }

                private void EntradaComisionUsuario_TextChanged(object sender, System.EventArgs e)
                {
                        lblComisionUsuarioPct.Text = "(" + Lfx.Types.Formatting.FormatNumber(EntradaComisionUsuario.Text.ParseCurrency() / EntradaCuponesSubTotal.Text.ParseCurrency() * 100, 2) + "%)";
                        if (IgnorarCambios == false) {
                                IgnorarCambios = true;
                                EntradaTotal.Text = Lfx.Types.Formatting.FormatCurrency(EntradaCuponesSubTotal.Text.ParseCurrency() - EntradaComisionTarjeta.Text.ParseCurrency() - EntradaComisionPlan.Text.ParseCurrency() - EntradaComisionUsuario.Text.ParseCurrency(), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                                IgnorarCambios = false;
                        }
                }

        }
}
