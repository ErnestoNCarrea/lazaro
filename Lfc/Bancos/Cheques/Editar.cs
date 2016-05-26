using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Bancos.Cheques
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Bancos.Cheque);

                        InitializeComponent();
                }

                public override void ActualizarControl()
                {
                        Lbl.Bancos.Cheque Res = this.Elemento as Lbl.Bancos.Cheque;

                        EntradaEmisor.Text = Res.Emisor;
                        EntradaBanco.Elemento = Res.Banco;
                        EntradaNumero.Text = Res.Numero.ToString();
                        EntradaFechaCobro.Text = Lfx.Types.Formatting.FormatDate(Res.FechaCobro);
                        EntradaFechaEmision.Text = Lfx.Types.Formatting.FormatDate(Res.FechaEmision);

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Bancos.Cheque Res = this.Elemento as Lbl.Bancos.Cheque;

                        Res.Emisor = EntradaEmisor.Text;
                        Res.Banco = EntradaBanco.Elemento as Lbl.Bancos.Banco;
                        Res.Numero = Lfx.Types.Parsing.ParseInt(EntradaNumero.Text);
                        Res.FechaCobro = Lfx.Types.Parsing.ParseDate(EntradaFechaCobro.Text);
                        Res.FechaEmision = Lfx.Types.Parsing.ParseDate(EntradaFechaEmision.Text);

                        base.ActualizarElemento();
                }
        }
}
