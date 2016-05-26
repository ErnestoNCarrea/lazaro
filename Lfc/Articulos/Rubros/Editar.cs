using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Articulos.Rubros
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Articulos.Rubro);

                        InitializeComponent();
                }

                public override void ActualizarControl()
                {
                        Lbl.Articulos.Rubro Rubro = this.Elemento as Lbl.Articulos.Rubro;

                        EntradaNombre.Text = Rubro.Nombre;
                        EntradaAlicuota.Elemento = Rubro.Alicuota;

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Articulos.Rubro Rubro = this.Elemento as Lbl.Articulos.Rubro;

                        Rubro.Nombre = EntradaNombre.Text;
                        Rubro.Alicuota = EntradaAlicuota.Elemento as Lbl.Impuestos.Alicuota;

                        base.ActualizarElemento();
                }

                public override Lazaro.Pres.DisplayStyles.IDisplayStyle HeaderDisplayStyle
                {
                        get
                        {
                                return Lazaro.Pres.DisplayStyles.Template.Current.Articulos;
                        }
                }
        }
}