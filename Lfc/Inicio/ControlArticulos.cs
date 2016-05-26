using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Inicio
{
        public partial class ControlArticulos : ControlTablero
        {
                public ControlArticulos()
                {
                        InitializeComponent();
                }

                private void BotonListado_Click(object sender, EventArgs e)
                {
                        Lfx.Workspace.Master.RunTime.Execute("LISTAR", new string[] { "Lbl.Articulos.Articulo" });
                }

                private void BotonCrearArticulo_Click(object sender, EventArgs e)
                {
                        Lfx.Workspace.Master.RunTime.Execute("CREAR", new string[] { "Lbl.Articulos.Articulo" });
                }

                private void BotonCrearCategoria_Click(object sender, EventArgs e)
                {
                        Lfx.Workspace.Master.RunTime.Execute("CREAR", new string[] { "Lbl.Articulos.Categoria" });
                }
        }
}
