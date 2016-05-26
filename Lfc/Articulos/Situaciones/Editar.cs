using System;

namespace Lfc.Articulos.Situaciones
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Articulos.Situacion);

                        InitializeComponent();
                }

                public override void ActualizarControl()
                {
                        Lbl.Articulos.Situacion Item = this.Elemento as Lbl.Articulos.Situacion;

                        EntradaNombre.Text = Item.Nombre;
                        EntradaCuentaStock.TextKey = Item.CuentaExistencias ? "1" : "0";
                        EntradaCuentaStock.TextKey = Item.CuentaExistencias ? "1" : "0";
                        EntradaDeposito.ValueInt = Item.Deposito;

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Articulos.Situacion Item = this.Elemento as Lbl.Articulos.Situacion;

                        Item.Nombre = EntradaNombre.Text;
                        Item.CuentaExistencias = EntradaCuentaStock.TextKey == "1";
                        Item.CuentaExistencias = EntradaCuentaStock.TextKey == "1";
                        Item.Deposito = EntradaDeposito.ValueInt;

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