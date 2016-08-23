using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Recibos
{
	public partial class Rapido : Lui.Forms.ChildDialogForm
	{
		public Rapido()
		{
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.Comprobantes.ReciboDeCobro), Lbl.Sys.Permisos.Operaciones.Crear) == false) {
                                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                                this.Close();
                                return;
                        }

			InitializeComponent();
		}

		public override Lfx.Types.OperationResult Ok()
		{
                        if (Lfx.Types.Parsing.ParseCurrency(EntradaImporte.Text) <= 0)
                                return new Lfx.Types.FailureOperationResult("Por favor escriba el importe.");

			if(EntradaCaja.ValueInt <= 0)
				return new Lfx.Types.FailureOperationResult("Por favor seleccione la caja de destino.");

                        IDbTransaction Trans = this.Connection.BeginTransaction(IsolationLevel.Serializable);

			Lbl.Personas.Persona Cliente = new Lbl.Personas.Persona(Connection, EntradaCliente.ValueInt);
			Lbl.Comprobantes.ReciboDeCobro Rec = new Lbl.Comprobantes.ReciboDeCobro(this.Connection);
			Rec.Crear();
                        Rec.Cliente = Cliente;
			Rec.Cobros.Add(new Lbl.Comprobantes.Cobro(Connection, Lbl.Pagos.TiposFormasDePago.Caja, Lfx.Types.Parsing.ParseCurrency(EntradaImporte.Text)));
			Rec.Cobros[0].CajaDestino = new Lbl.Cajas.Caja(Connection, EntradaCaja.ValueInt);
                        Rec.Vendedor = Lbl.Sys.Config.Actual.UsuarioConectado.Persona;
			Lfx.Types.OperationResult Res = Rec.Guardar();

                        if (Res.Success) {
                                Trans.Commit();

                                if (Rec.Tipo.ImprimirAlGuardar) {
                                        using (IDbTransaction TransImpr = Rec.Connection.BeginTransaction()) {
                                                Lazaro.Base.Util.Impresion.Comprobantes.ImpresorRecibo Impresor = new Lazaro.Base.Util.Impresion.Comprobantes.ImpresorRecibo(Rec, TransImpr);
                                                Lfx.Types.OperationResult ResImprimir = Impresor.Imprimir();
                                                if (ResImprimir.Success) {
                                                        TransImpr.Commit();
                                                } else {
                                                        TransImpr.Rollback();
                                                        if (ResImprimir.Message != null)
                                                                Lui.Forms.MessageBox.Show(ResImprimir.Message, "Error");
                                                        else
                                                                Lui.Forms.MessageBox.Show("Se creó el recibo, pero no se imprimió correctamente.", "Error");
                                                }
                                        }
                                }

                                string NombreCliente = EntradaCliente.TextDetail;
                                Lfx.Workspace.Master.RunTime.Toast("Se creo un recibo para el cliente " + NombreCliente, "Recibo rápido");

                                EntradaCliente.ValueInt = 0;
                                EntradaCliente.Focus();
                                return new Lfx.Types.CancelOperationResult();
                        } else {
                                Trans.Rollback();
                                return Res;
                        }
        	}

		private void EntradaCliente_TextChanged(object sender, EventArgs e)
		{
                        if (EntradaCliente.ValueInt > 0) {
                                Lbl.Personas.Persona Pers = EntradaCliente.Elemento as Lbl.Personas.Persona;
                                decimal Saldo = Pers.CuentaCorriente.ObtenerSaldo(false);
                                if (Saldo > 0)
                                        EntradaImporte.ValueDecimal = Pers.CuentaCorriente.ObtenerSaldo(false);
                                else
                                        EntradaImporte.ValueDecimal = 0;
                        } else {
                                EntradaImporte.ValueDecimal = 0;
                        }
		}
	}
}
