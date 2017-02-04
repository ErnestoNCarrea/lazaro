using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Lazaro.Base.Util.Impresion
{
        public class Impresor : System.Drawing.Printing.PrintDocument
        {
                public Lbl.Impresion.Impresora Impresora = null;
                protected const double mm = 3.937007874015748031496062992126;
                protected Lfx.Data.IConnection m_DataBase = null;
                public IDbTransaction Transaction = null;

                public int PaginaNumero { get; set; }

                public Impresor(IDbTransaction transaction)
                {
                        this.Transaction = transaction;
                }

                public Lfx.Data.IConnection Connection
                {
                        get
                        {
                                if (m_DataBase == null)
                                        m_DataBase = Lfx.Workspace.Master.MasterConnection;
                                return m_DataBase;
                        }
                }

                public Lfx.Workspace Workspace
                {
                        get
                        {
                                return Lfx.Workspace.Master;
                        }
                }


                protected override void OnBeginPrint(System.Drawing.Printing.PrintEventArgs e)
                {
                        if (this.Impresora != null) {
                                if (Impresora.EsVistaPrevia)
                                        this.PrintController = new System.Drawing.Printing.PreviewPrintController();

                                if (this.Impresora.EsLocalPredeterminada == false) {
                                        if (this.Impresora.EsLocal)
                                                this.PrinterSettings.PrinterName = this.Impresora.Dispositivo;
                                        else
                                                this.PrinterSettings.PrinterName = this.Impresora.DispositivoUnc;
                                }
                        }

                        base.OnBeginPrint(e);
                }


                public virtual Lfx.Types.OperationResult Imprimir()
                {
                        if (Lfx.Workspace.Master.DebugMode) {
                                this.Print();
                        } else {
                                try {
                                        this.Print();
                                } catch (System.ComponentModel.Win32Exception ex) {
                                        return new Lfx.Types.FailureOperationResult(ex.Message);
                                } catch (System.Drawing.Printing.InvalidPrinterException ex) {
                                        return new Lfx.Types.FailureOperationResult(ex.Message);
                                }
                        }
                        return new Lfx.Types.SuccessOperationResult();
                }
        }
}
