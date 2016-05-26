using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Cajas.Conceptos
{
	public partial class Editar : Lcc.Edicion.ControlEdicion
	{
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Cajas.Concepto);

                        InitializeComponent();
                }

                public override void ActualizarControl()
                {
                        Lbl.Cajas.Concepto Conc = this.Elemento as Lbl.Cajas.Concepto;

                        EntradaCodigo.ValueInt = Conc.Id;
                        EntradaNombre.Text = Conc.Nombre;
                        EntradaDireccion.TextKey = Conc.Direccion.ToString();
                        EntradaGrupo.TextKey = Conc.Grupo.ToString();

                        base.ActualizarControl();
                }

		public override Lfx.Types.OperationResult ValidarControl()
		{
			if(EntradaNombre.Text.Length < 2)
				return new Lfx.Types.FailureOperationResult("Escriba un nombre para el concepto");

                        return base.ValidarControl();
		}

                public override void ActualizarElemento()
                {
                        Lbl.Cajas.Concepto Conc = this.Elemento as Lbl.Cajas.Concepto;

                        Conc.Nombre = EntradaNombre.Text;
                        Conc.Direccion = Lfx.Types.Parsing.ParseInt(EntradaDireccion.TextKey);
                        Conc.Grupo = Lfx.Types.Parsing.ParseInt(EntradaGrupo.TextKey);

                        base.ActualizarElemento();
                }
	}
}