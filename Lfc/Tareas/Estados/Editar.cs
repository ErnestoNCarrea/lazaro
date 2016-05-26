using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Tareas.Estados
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Tareas.Estado);

                        InitializeComponent();

                }


                public override void ActualizarControl()
                {
                        Lbl.Tareas.Estado Elem = this.Elemento as Lbl.Tareas.Estado;

                        EntradaNombre.Text = Elem.Nombre;
                        EntradaObs.Text = Elem.Obs;

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Tareas.Estado Elem = this.Elemento as Lbl.Tareas.Estado;

                        Elem.Nombre = EntradaNombre.Text;
                        Elem.Obs = EntradaObs.Text;

                        base.ActualizarElemento();
                }
        }
}