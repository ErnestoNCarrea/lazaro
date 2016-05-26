using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Inicio
{
        public partial class ControlComprobantes : ControlTablero
        {
                public ControlComprobantes()
                {
                        InitializeComponent();
                }

                private void BotonCrearRecibo_Click(object sender, EventArgs e)
                {
                        Lfx.Workspace.Master.RunTime.Execute("CREAR", new string[] { "Lbl.Comprobantes.ReciboDeCobro" });
                }

                private void BotonCrearFactura_Click(object sender, EventArgs e)
                {
                        Lfx.Workspace.Master.RunTime.Execute("CREAR", new string[] { "Lbl.Comprobantes.Factura" });
                }

                private void BotonListadoRecibos_Click(object sender, EventArgs e)
                {
                        Lfx.Workspace.Master.RunTime.Execute("LISTAR", new string[] { "Lbl.Comprobantes.ReciboDeCobro" });
                }

                private void BotonListadoFacturas_Click(object sender, EventArgs e)
                {
                        Lfx.Workspace.Master.RunTime.Execute("LISTAR", new string[] { "Lbl.Comprobantes.Factura" });
                }
        }
}
