using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Alicuotas
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
	{
		public Editar()
		{
                        ElementoTipo = typeof(Lbl.Impuestos.Alicuota);

                        InitializeComponent();
		}

                public override void ActualizarControl()
                {
                        Lbl.Impuestos.Alicuota Alic = this.Elemento as Lbl.Impuestos.Alicuota;

                        EntradaNombre.Text = Alic.Nombre;
                        EntradaPorcentaje.Text = Alic.Porcentaje.ToString();
                        EntradaImporteMinimo.Text = Alic.ImporteMinimo.ToString();

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Impuestos.Alicuota Alic = this.Elemento as Lbl.Impuestos.Alicuota;

                        Alic.Nombre = EntradaNombre.Text;
                        Alic.Porcentaje = EntradaPorcentaje.Text.ParseDecimal();
                        Alic.ImporteMinimo = EntradaImporteMinimo.Text.ParseCurrency();

                        base.ActualizarElemento();
                }

                public override Lfx.Types.OperationResult ValidarControl()
                {
                        if (EntradaNombre.Text.Length == 0)
                                return new Lfx.Types.FailureOperationResult("Debe escribir el nombre del elemento");
                        if (EntradaPorcentaje.ValueDecimal < -100 || EntradaPorcentaje.ValueDecimal > 100)
                                return new Lfx.Types.FailureOperationResult("Debe escribir un porcentaje de retención válido");
                        if (EntradaImporteMinimo.ValueDecimal < 0)
                                return new Lfx.Types.FailureOperationResult("El importe mínimo debe ser mayor o igual a cero");

                        return base.ValidarControl();
                }
	}
}

