using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Lfc.Bancos.Cheques
{
        public partial class Pagar : Lui.Forms.DialogForm
        {
                IList<string> Cheques = null;
                private string ChequesIds = null;

                public Pagar()
                {
                        InitializeComponent();
                }


                private int Ignorar_Importes_TextChanged = 0;
                private void Importes_TextChanged(object sender, System.EventArgs e)
                {
                        if (Ignorar_Importes_TextChanged > 0)
                                return;

                        Ignorar_Importes_TextChanged++;
                        if (sender == EntradaTotal)
                                EntradaImpuestos.ValueDecimal = EntradaSubTotal.ValueDecimal - EntradaTotal.ValueDecimal;
                        else
                                EntradaTotal.ValueDecimal = EntradaSubTotal.ValueDecimal + EntradaImpuestos.ValueDecimal;
                        Ignorar_Importes_TextChanged--;
                }

                public System.Windows.Forms.DialogResult Mostrar(IList<string> chequesAPagar)
                {
                        this.Cheques = chequesAPagar;

                        foreach (string ChequeId in Cheques) {
                                if (ChequesIds == null)
                                        ChequesIds = ChequeId;
                                else
                                        ChequesIds += "," + ChequeId;
                        }

                        if (ChequesIds != null) {
                                decimal Total = this.Connection.FieldDecimal("SELECT SUM(importe) FROM bancos_cheques WHERE id_cheque IN (" + ChequesIds + ")");

                                EntradaCantidad.ValueInt = Cheques.Count;
                                EntradaSubTotal.ValueDecimal = Total;
                                return this.ShowDialog();
                        } else {
                                return DialogResult.Cancel;
                        }
                }

                public override Lfx.Types.OperationResult Ok()
                {
                        Lfx.Types.OperationResult Res = new Lfx.Types.SuccessOperationResult();
                        if (EntradaCajaOrigen.ValueInt <= 0) {
                                Res.Success = false;
                                Res.Message += "Por favor seleccione la cuenta de origen." + Environment.NewLine;
                        }
                        if (EntradaTotal.ValueDecimal <= 0) {
                                Res.Success = false;
                                Res.Message += "El importe total debe ser mayor o igual a cero." + Environment.NewLine;
                        }
                        if (Res.Success == true) {
                                decimal Impuestos = EntradaImpuestos.ValueDecimal;

                                IDbTransaction Trans = null;
                                if (this.Connection.InTransaction == false) {
                                        Trans = this.Connection.BeginTransaction(IsolationLevel.Serializable);
                                }

                                string ChequesNum = null;
                                System.Data.DataTable TablaCheques = Connection.Select("SELECT * FROM bancos_cheques WHERE id_cheque IN (" + ChequesIds + ")");
                                Lbl.Cajas.Caja CajaOrigen = new Lbl.Cajas.Caja(Connection, EntradaCajaOrigen.ValueInt);
                                foreach (System.Data.DataRow RowCheque in TablaCheques.Rows) {
                                        Lbl.Bancos.Cheque Cheque = new Lbl.Bancos.Cheque(this.Connection, (Lfx.Data.Row)RowCheque);
                                        Cheque.Pagar(CajaOrigen);
                                }

                                if (Impuestos != 0)
                                        CajaOrigen.Movimiento(true, new Lbl.Cajas.Concepto(this.Connection, 23030),
                                                "Impuestos de cheque(s)",
                                                null,
                                                -Impuestos,
                                                "Cheques Nº " + ChequesNum, null, null, null);

                                if (Trans != null) {
                                        Trans.Commit();
                                }
                        }
                        return Res;
                }
        }
}
