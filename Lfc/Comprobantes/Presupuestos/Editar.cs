using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Presupuestos
{
        public partial class Editar : Lfc.Comprobantes.Editar
	{
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Comprobantes.Presupuesto);

                        InitializeComponent();
                }


                public Editar(string tipo)
                        : this()
                {
                        TipoPredet = tipo;
                }
	}
}