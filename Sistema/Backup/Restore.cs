using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lazaro.WinMain.Backup
{
        public partial class Restore : Lui.Forms.DialogForm
        {
                public Restore()
                {
                        InitializeComponent();
                        OkButton.Enabled = false;
                }

                private void EntradaConfirmar_TextChanged(object sender, System.EventArgs e)
                {
                        string Texto = EntradaConfirmar.Text.Replace("\"", "").ToUpperInvariant().Trim();
                        OkButton.Enabled = (Texto == "SÍ" || Texto == "SI");
                }
        }
}