using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Monedas
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Entidades.Moneda);

                        InitializeComponent();
                }

                public override void ActualizarControl()
                {
                        Lbl.Entidades.Moneda Res = this.Elemento as Lbl.Entidades.Moneda;

                        EntradaCotizacion.ValueDecimal = Res.Cotizacion;                       

                        base.ActualizarControl();
                }

                public override Lfx.Types.OperationResult ValidarControl()
                {
                      

                        if (EntradaCotizacion.ValueDecimal<0)
                              return new Lfx.Types.FailureOperationResult("La catización debe ser mayor a 0");                       

                        return base.ValidarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Entidades.Moneda Res = this.Elemento as Lbl.Entidades.Moneda;


                        Res.Cotizacion = EntradaCotizacion.ValueDecimal;                       

                        base.ActualizarElemento();
                }
        }
}
