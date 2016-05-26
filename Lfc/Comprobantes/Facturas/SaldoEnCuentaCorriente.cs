using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Facturas
{
        public partial class SaldoEnCuentaCorriente : Lui.Forms.Form
        {
                public SaldoEnCuentaCorriente()
                {
                        this.DisplayStyle = Lazaro.Pres.DisplayStyles.Template.Current.White;
                        InitializeComponent();
                }

                private void BotonCancelar_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Hide();
                }

                private void BotonCorregir_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Yes;
                        this.Hide();
                }

                private void BotonContinuar_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.No;
                        this.Hide();
                }
        }
}
