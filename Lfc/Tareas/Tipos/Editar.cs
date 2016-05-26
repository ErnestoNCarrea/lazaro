using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Tareas.Tipos
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Tareas.Tipo);

                        InitializeComponent();

                }


                public override void ActualizarControl()
                {
                        Lbl.Tareas.Tipo Elem = this.Elemento as Lbl.Tareas.Tipo;

                        EntradaNombre.Text = Elem.Nombre;
                        EntradaObs.Text = Elem.Obs;

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Tareas.Tipo Elem = this.Elemento as Lbl.Tareas.Tipo;

                        Elem.Nombre = EntradaNombre.Text;
                        Elem.Obs = EntradaObs.Text;

                        base.ActualizarElemento();
                }
        }
}