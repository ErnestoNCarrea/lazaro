using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Recibos
{
        public partial class Anular : Lui.Forms.ChildDialogForm
        {
                public Anular()
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.Comprobantes.Recibo), Lbl.Sys.Permisos.Operaciones.Eliminar) == false) {
                                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                                this.Close();
                        }

                        InitializeComponent();
                }


                public Anular(string comando)
                        : this()
                {
                        int IdRecibo = Lfx.Types.Parsing.ParseInt(comando);
                        if (IdRecibo > 0)
                                this.Cargar(IdRecibo);
                }


                public void Cargar(int idRecibo)
                {
                        Lbl.Comprobantes.Recibo Rec = null;

                        if (idRecibo != 0)
                                Rec = new Lbl.Comprobantes.Recibo(this.Connection, idRecibo);

                        if (Rec != null && Rec.Existe) {
                                EntradaFecha.Text = Lfx.Types.Formatting.FormatDate(Rec.Fecha);

                                EntradaImporte.Text = Lfx.Types.Formatting.FormatCurrency(Rec.Total, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                                EntradaCliente.Text = Rec.Cliente.ToString();

                                EntradaPV.Text = Rec.PV.ToString();
                                EntradaNumero.Text = Rec.Numero.ToString();
                                EntradaTipo.TextKey = Rec.Tipo.Nomenclatura;

                                if (Rec.Anulado) {
                                        EtiquetaAviso.Text = "El comprobante ya fue anulado y no puede anularse nuevamente.";
                                        OkButton.Visible = false;
                                } else {
                                        EtiquetaAviso.Text = "Recuerde que necesitar archivar todas las copias del comprobante anulado.";
                                        OkButton.Visible = true;
                                }
                        } else {
                                EtiquetaAviso.Text = "";
                                EntradaFecha.Text = "";
                                EntradaImporte.Text = "";
                                EntradaCliente.Text = "";
                                OkButton.Visible = false;
                        }
                }

                private void EntradaNumeroTipoPV(object sender, EventArgs e)
                {
                        int Numero = EntradaNumero.ValueInt; ;
                        int PV = EntradaPV.ValueInt;

                        int IdRecibo = 0;
                        if (Numero > 0)
                                IdRecibo = this.Connection.FieldInt("SELECT id_recibo FROM recibos WHERE tipo_fac='" + EntradaTipo.TextKey + "' AND pv=" + PV.ToString() + " AND numero=" + Numero.ToString() + " ORDER BY id_recibo DESC");

                        this.Cargar(IdRecibo);
                }

                public override Lfx.Types.OperationResult Ok()
                {
                        if (Lui.LogOn.LogOnData.ValidateAccess(typeof(Lbl.Comprobantes.Recibo), Lbl.Sys.Permisos.Operaciones.Eliminar) == false)
                                return new Lfx.Types.NoAccessOperationResult();

                        Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("Una vez anulado, el comprobante deberá ser archivado en todas sus copias y no podrá ser rehabilitado ni reutilizado.", "¿Está seguro de que desea anular el comprobante?");
                        Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;

                        if (Pregunta.ShowDialog() == DialogResult.OK) {
                                int Numero = Lfx.Types.Parsing.ParseInt(EntradaNumero.Text);
                                int PV = Lfx.Types.Parsing.ParseInt(EntradaPV.Text);
                                Lbl.Comprobantes.Recibo Rec = null;

                                int IdRecibo = 0;
                                if (Numero > 0)
                                        IdRecibo = this.Connection.FieldInt("SELECT id_recibo FROM recibos WHERE tipo_fac='" + EntradaTipo.TextKey + "' AND pv=" + PV.ToString() + " AND numero=" + Numero.ToString());
                                if (IdRecibo != 0)
                                        Rec = new Lbl.Comprobantes.Recibo(this.Connection, IdRecibo);

                                if (Rec != null && Rec.Existe) {
                                        IDbTransaction Trans = Rec.Connection.BeginTransaction(IsolationLevel.Serializable);
                                        Rec.Anular();
                                        Trans.Commit();
                                }

                                EntradaNumero.Text = "";
                                EntradaNumero.Focus();

                                return new Lfx.Types.SuccessOperationResult();
                        } else {
                                return new Lfx.Types.CancelOperationResult();
                        }
                }
        }
}
