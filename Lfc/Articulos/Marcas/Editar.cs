using System;

namespace Lfc.Articulos.Marcas
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Articulos.Marca);

                        InitializeComponent();
                }

                public override void ActualizarControl()
                {
                        Lbl.Articulos.Marca Mar = this.Elemento as Lbl.Articulos.Marca;

                        EntradaNombre.Text = Mar.Nombre;
                        EntradaUrl.Text = Mar.Url;
                        EntradaProveedor.Elemento = Mar.Proveedor;
                        EntradaObs.Text = Mar.Obs;

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Articulos.Marca Mar = this.Elemento as Lbl.Articulos.Marca;

                        Mar.Nombre = EntradaNombre.Text;
                        Mar.Url = EntradaUrl.Text;
                        Mar.Proveedor = EntradaProveedor.Elemento as Lbl.Personas.Persona;
                        Mar.Obs = EntradaObs.Text;
                        Mar.Estado = 1;

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