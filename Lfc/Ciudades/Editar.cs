using System;

namespace Lfc.Ciudades
{
	public partial class Editar : Lcc.Edicion.ControlEdicion
	{
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Entidades.Localidad);

                        InitializeComponent();
                }

                public override Lfx.Types.OperationResult ValidarControl()
                {
                        if (EntradaNivel.TextKey != "0" && EntradaParent.ValueInt == 0)
                                return new Lfx.Types.FailureOperationResult("Debe ingresar la Provincia o el Departamento");

                        return base.ValidarControl();
                }

                public override void ActualizarControl()
                {
                        Lbl.Entidades.Localidad Localidad = this.Elemento as Lbl.Entidades.Localidad;

                        EntradaNombre.Text = Localidad.Nombre;
                        EntradaCp.Text = Localidad.CodigoPostal;
                        EntradaIva.TextKey = ((int)(Localidad.Iva)).ToString();
                        EntradaParent.Elemento = Localidad.Provincia;

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Entidades.Localidad Res = this.Elemento as Lbl.Entidades.Localidad;

                        Res.Nombre = EntradaNombre.Text;
                        Res.CodigoPostal = EntradaCp.Text;
                        Res.Provincia = EntradaParent.Elemento as Lbl.Entidades.Localidad;
                        Res.Iva = (Lbl.Impuestos.SituacionIva)(Lfx.Types.Parsing.ParseInt(EntradaIva.TextKey));

                        base.ActualizarElemento();
                }

                private void EntradaNivel_TextChanged(object sender, EventArgs e)
                {
                        switch(EntradaNivel.TextKey) {
                                case "0":
                                        EntradaParent.Enabled = false;
                                        break;
                                case "2":
                                        EntradaParent.Enabled = true;
                                        break;
                        }
                }
	}
}