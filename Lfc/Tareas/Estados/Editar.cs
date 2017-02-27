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
                        ElementoTipo = typeof(Lbl.Tareas.EstadoTarea);

                        InitializeComponent();

                }


                public override void ActualizarControl()
                {
                        Lbl.Tareas.EstadoTarea Elem = this.Elemento as Lbl.Tareas.EstadoTarea;

                        EntradaNombre.Text = Elem.Nombre;
                        EntradaObs.Text = Elem.Obs;

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Tareas.EstadoTarea Elem = this.Elemento as Lbl.Tareas.EstadoTarea;

                        Elem.Nombre = EntradaNombre.Text;
                        Elem.Obs = EntradaObs.Text;

                        base.ActualizarElemento();
                }
        }
}