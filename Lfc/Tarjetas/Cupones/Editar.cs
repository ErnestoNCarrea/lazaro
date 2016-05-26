using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Tarjetas.Cupones
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Pagos.Cupon);

                        InitializeComponent();

                }


                public override void ActualizarControl()
                {
                        Lbl.Pagos.Cupon Elem = this.Elemento as Lbl.Pagos.Cupon;

                        EntradaNumero.Text = Elem.Numero.ToString();
                        EntradaFormaPago.Elemento = Elem.FormaDePago;
                        EntradaPlan.Elemento = Elem.Plan;

                        EntradaFechaPresentacion.Text = Lfx.Types.Formatting.FormatDate(Elem.FechaPresentacion);
                        EntradaFechaAcreditacion.Text = Lfx.Types.Formatting.FormatDate(Elem.FechaAcreditacion);

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Pagos.Cupon Elem = this.Elemento as Lbl.Pagos.Cupon;

                        Elem.Numero = EntradaNumero.Text;
                        Elem.FormaDePago = EntradaFormaPago.Elemento as Lbl.Pagos.FormaDePago;
                        Elem.Plan = EntradaPlan.Elemento as Lbl.Pagos.Plan;

                        Elem.FechaPresentacion = Lfx.Types.Parsing.ParseDate(EntradaFechaPresentacion.Text);
                        Elem.FechaAcreditacion = Lfx.Types.Parsing.ParseDate(EntradaFechaAcreditacion.Text);

                        base.ActualizarElemento();
                }
        }
}