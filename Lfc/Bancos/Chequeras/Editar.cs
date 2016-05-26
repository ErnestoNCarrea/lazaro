using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Bancos.Chequeras
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Bancos.Chequera);

                        InitializeComponent();
                }


                public override Lfx.Types.OperationResult ValidarControl()
                {
                        int Desde = EntradaDesde.ValueInt;
                        int Hasta = EntradaHasta.ValueInt;

                        if ((Desde >= Hasta) || (Hasta <= 0) || (Hasta - Desde > 10000))
                                return new Lfx.Types.FailureOperationResult("Debe escribir la numeración de la chequera (desde y hasta)");

                        if(EntradaBanco.Elemento == null)
                                return new Lfx.Types.FailureOperationResult("Debe escribir el banco al que pertenece la chequera.");

                        return base.ValidarControl();
                }


                public override void ActualizarControl()
                {
                        Lbl.Bancos.Chequera Res = this.Elemento as Lbl.Bancos.Chequera;

                        EntradaBanco.Elemento = Res.Banco;
                        EntradaDesde.Text = Res.Desde.ToString();
                        EntradaHasta.Text = Res.Hasta.ToString();
                        EntradaCaja.Elemento = Res.Caja;
                        EntradaTitular.Text = Res.Titular;
                        EntradaEstado.TextKey = Res.Estado.ToString();
                        EntradaSucursal.Elemento = Res.Sucursal;

                        if (Res.Existe)
                                EntradaCaja.Filter = null;
                        else
                                EntradaCaja.Filter = "estado=1";

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Bancos.Chequera Res = this.Elemento as Lbl.Bancos.Chequera;

                        Res.Banco = EntradaBanco.Elemento as Lbl.Bancos.Banco;
                        Res.Caja = EntradaCaja.Elemento as Lbl.Cajas.Caja;
                        Res.Sucursal = EntradaSucursal.Elemento as Lbl.Entidades.Sucursal;
                        Res.Desde = Lfx.Types.Parsing.ParseInt(EntradaDesde.Text);
                        Res.Hasta = Lfx.Types.Parsing.ParseInt(EntradaHasta.Text);
                        Res.Titular = EntradaTitular.Text;
                        Res.Estado = Lfx.Types.Parsing.ParseInt(EntradaEstado.TextKey);

                        base.ActualizarElemento();
                }
        }
}
