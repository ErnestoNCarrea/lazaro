using System;

namespace Lfc.Articulos.Margenes
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Articulos.Margen);

                        InitializeComponent();
                }

                public override void ActualizarControl()
                {
                        Lbl.Articulos.Margen Item = this.Elemento as Lbl.Articulos.Margen;

                        EntradaNombre.Text = Item.Nombre;
                        EntradaPorcentaje.ValueDecimal = Item.Porcentaje;
                        EntradaPredet.TextKey = Item.Predeterminado ? "1" : "0";

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Articulos.Margen Item = this.Elemento as Lbl.Articulos.Margen;

                        Item.Nombre = EntradaNombre.Text;
                        Item.Porcentaje = EntradaPorcentaje.ValueDecimal;
                        Item.Predeterminado = EntradaPredet.TextKey == "1";

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