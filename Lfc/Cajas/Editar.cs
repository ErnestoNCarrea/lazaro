using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Cajas
{
	public partial class Editar : Lcc.Edicion.ControlEdicion
	{
		private bool CustomName;

                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Cajas.Caja);

                        InitializeComponent();

                        EtiquetaClaveBancaria.Text = Lbl.Sys.Config.Pais.ClaveBancaria.Nombre;
                }

                public override Lfx.Types.OperationResult ValidarControl()
                {
                        Lfx.Types.OperationResult validarReturn = new Lfx.Types.SuccessOperationResult();

                        if (EntradaMoneda.ValueInt == 0) {
                                validarReturn.Success = false;
                                validarReturn.Message += "Seleccione la Currency." + Environment.NewLine;
                        }

                        if (EntradaNombre.Text.Length < 2) {
                                validarReturn.Success = false;
                                validarReturn.Message += "Seleccione el Nombre de la cuenta." + Environment.NewLine;
                        }

                        switch(Lbl.Sys.Config.Pais.ClaveBancaria.Nombre)
                        {
                                case "CBU":
                                        if (EntradaClaveBancaria.Text.Length > 0 && Lbl.Bancos.Claves.Cbu.EsValido(EntradaClaveBancaria.Text) == false) {
                                                validarReturn.Success = false;
                                                validarReturn.Message += "La CBU es incorrecta." + Environment.NewLine;
                                        }
                                        break;
                        }

                        return validarReturn;
                }


                public override void ActualizarControl()
                {
                        Lbl.Cajas.Caja Caja = this.Elemento as Lbl.Cajas.Caja;

                        EntradaTitular.Text = Caja.Titular;
                        EntradaTipo.TextKey = ((int)(Caja.Tipo)).ToString();
                        EntradaNumero.Text = Caja.Numero;
                        EntradaBanco.Elemento = Caja.Banco;
                        EntradaMoneda.Elemento = Caja.Moneda;
                        EntradaNombre.Text = Caja.Nombre;
                        EntradaClaveBancaria.Text = Caja.ClaveBancaria;
                        EntradaEstado.TextKey = Caja.Estado.ToString();

                        base.ActualizarControl();
                }


                public override void ActualizarElemento()
                {
                        Lbl.Cajas.Caja Caja = this.Elemento as Lbl.Cajas.Caja;

                        Caja.Nombre = EntradaNombre.Text;
                        Caja.Numero = EntradaNumero.Text;
                        Caja.Titular = EntradaTitular.Text;
                        Caja.Banco = EntradaBanco.Elemento as Lbl.Bancos.Banco;
                        Caja.Moneda = EntradaMoneda.Elemento as Lbl.Entidades.Moneda;
                        Caja.Tipo = (Lbl.Cajas.TiposDeCaja)(Lfx.Types.Parsing.ParseInt(EntradaTipo.TextKey));
                        Caja.ClaveBancaria = EntradaClaveBancaria.Text;
                        Caja.Estado = Lfx.Types.Parsing.ParseInt(EntradaEstado.TextKey);

                        base.ActualizarElemento();
                }


		private void EntradaNombre_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			CustomName = true;
		}


		private void NumeroBanco_TextChanged(object sender, System.EventArgs e)
		{
			if (CustomName == false)
			{
				EntradaNombre.Text = EntradaNumero.Text;
				if (EntradaBanco.TextDetail.Length > 0)
				{
					if (EntradaNumero.Text.Length > 0)
						EntradaNombre.Text += " de ";

					EntradaNombre.Text += EntradaBanco.TextDetail;
				}
			}
		}


		private void EntradaTipo_TextChanged(object sender, System.EventArgs e)
		{
			EntradaBanco.Enabled = Lfx.Types.Parsing.ParseInt(EntradaTipo.TextKey) > 0;
			EntradaNumero.Enabled = Lfx.Types.Parsing.ParseInt(EntradaTipo.TextKey) > 0;
		}
	}
}