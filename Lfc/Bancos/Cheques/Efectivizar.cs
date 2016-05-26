using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Bancos.Cheques
{
        public partial class Efectivizar : Lui.Forms.DialogForm
        {
                public Lbl.Bancos.Cheque m_Cheque;

                public Efectivizar()
                {
                        InitializeComponent();
                }

                public Lbl.Bancos.Cheque Cheque
                {
                        get
                        {
                                return m_Cheque;
                        }
                        set
                        {
                                m_Cheque = value;
                                this.Connection = m_Cheque.Connection;
                                this.EntradaTotal.ValueDecimal = m_Cheque.Importe;
                                this.EntradaGestionDeCobro.Text = "0";
                                this.EntradaImpuestos.Text = "0";
                                this.OkButton.Enabled = m_Cheque.Estado <= 5;
                        }
                }

                private int Ignorar_EntradaImportes_TextChanged = 0;
                private void EntradaImportes_TextChanged(object sender, System.EventArgs e)
                {
                        if (Ignorar_EntradaImportes_TextChanged > 0)
                                return;

                        Ignorar_EntradaImportes_TextChanged++;
                        if (sender == EntradaTotal)
                                EntradaImpuestos.ValueDecimal = EntradaSubTotal.ValueDecimal - EntradaTotal.ValueDecimal - EntradaGestionDeCobro.ValueDecimal;
                        else
                                EntradaTotal.ValueDecimal = (EntradaSubTotal.ValueDecimal - EntradaGestionDeCobro.ValueDecimal - EntradaImpuestos.ValueDecimal);
                        Ignorar_EntradaImportes_TextChanged--;
                }


                public override Lfx.Types.OperationResult Ok()
                {
                        Lfx.Types.OperationResult Res = new Lfx.Types.SuccessOperationResult();
                        if (EntradaCajaDestino.ValueInt <= 0) {
                                Res.Success = false;
                                Res.Message += "Por favor seleccione la cuenta de destino." + Environment.NewLine;
                        }
                        if (EntradaTotal.ValueDecimal <= 0) {
                                Res.Success = false;
                                Res.Message += "El importe total debe ser mayor o igual a cero." + Environment.NewLine;
                        }
                        if (Res.Success == true) {
                                decimal GestionDeCobro = Lfx.Types.Parsing.ParseCurrency(EntradaGestionDeCobro.Text);
                                decimal Impuestos = Lfx.Types.Parsing.ParseCurrency(EntradaImpuestos.Text);

                                IDbTransaction Trans = this.Connection.BeginTransaction(IsolationLevel.Serializable);

                                Lbl.Cajas.Caja CajaDestino = EntradaCajaDestino.Elemento as Lbl.Cajas.Caja;
                                this.Cheque.Efectivizar(CajaDestino, GestionDeCobro, Impuestos);

                                Trans.Commit();
                        }
                        return Res;
                }
        }
}