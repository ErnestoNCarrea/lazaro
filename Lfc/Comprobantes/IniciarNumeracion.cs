using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Comprobantes
{
        public partial class IniciarNumeracion : Lui.Forms.ChildDialogForm
        {
                public IniciarNumeracion()
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.Comprobantes.Factura), Lbl.Sys.Permisos.Operaciones.Administrar) == false) {
                                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                                this.Close();
                                return;
                        }

                        InitializeComponent();

                        EntradaTipoPvDesde_TextChanged(null, null);
                }

                private void EntradaTipoPvDesde_TextChanged(object sender, EventArgs e)
                {
                        if(EntradaPv.ValueInt < 0 || EntradaPv.ValueInt > 999) {
                                LabelAyuda.Text = "Seleccione el Tipo de Comprobante y un Punto de Venta apropiado.";
                                OkButton.Enabled = false;
                                return;
                        }

                        if (EntradaDesde.ValueInt <= 0) {
                                LabelAyuda.Text = "Ingrese el número en el cual iniciar la numeración del Tipo de Comprobante seleccionado.";
                                OkButton.Enabled = false;
                                return;
                        }

                        string IncluyeTipos = "";

                        switch (EntradaTipo.TextKey) {
                                case "A":
                                        IncluyeTipos = "'FA', 'NCA', 'NDA'";
                                        break;

                                case "B":
                                        IncluyeTipos = "'FB', 'NCB', 'NDB'";
                                        break;

                                case "C":
                                        IncluyeTipos = "'FC', 'NCC', 'NDC'";
                                        break;

                                case "E":
                                        IncluyeTipos = "'FE', 'NCE', 'NDE'";
                                        break;

                                case "M":
                                        IncluyeTipos = "'FM', 'NCM', 'NDM'";
                                        break;
                                default:
                                        IncluyeTipos = "'" + EntradaTipo.TextKey + "'";
                                        break;
                        }

                        int ProxNum = this.Connection.FieldInt("SELECT MAX(numero) FROM comprob WHERE compra=0 AND impresa=1 AND tipo_fac IN (" + IncluyeTipos + ") AND pv=" + EntradaPv.ValueInt.ToString());
                        if (ProxNum == 0) {
                                if (EntradaDesde.ValueInt < 2) {
                                        LabelAyuda.Text = "Seleccione el Próximo Número a utilizar en el talonario " + EntradaTipo.TextKey + " " + EntradaPv.ValueInt.ToString("0000") + ". El Próximo Número debe ser 2 o más (para comenzar el talonario en el número 1 no es necesario iniciar el Talonario).";
                                        OkButton.Enabled = false;
                                } else {
                                        LabelAyuda.Text = "El talonario " + EntradaTipo.TextKey + " " + EntradaPv.ValueInt.ToString("0000") + " comenzará (o continuará) la impresión en el número " + EntradaDesde.ValueInt.ToString("00000000") + ".";
                                        OkButton.Enabled = true;
                                }
                        } else {
                                if (EntradaDesde.ValueInt <= ProxNum + 1) {
                                        LabelAyuda.Text = "No se puede iniciar la numeración en el talonario " + EntradaTipo.TextKey + " " + EntradaPv.ValueInt.ToString("0000") + " en el número indicado porque el talonario ya está en uso y el próximo comprobante que se imprima tendrá el número " + (ProxNum + 1).ToString("00000000") + ". La numeración de un talonario no puede retroceder.";
                                        OkButton.Enabled = false;
                                } else {
                                        LabelAyuda.Text = "El talonario " + EntradaTipo.TextKey + " " + EntradaPv.ValueInt.ToString("0000") + " continuará la impresión en el número " + EntradaDesde.ValueInt.ToString("00000000") + ".";
                                        OkButton.Enabled = true;
                                }
                        }
                }

                public override Lfx.Types.OperationResult Ok()
                {
                        if (EntradaPv.ValueInt < 0 || EntradaPv.ValueInt > 999) {
                                LabelAyuda.Text = "Seleccione el Tipo de Comprobante y un Punto de Venta apropiado.";
                                OkButton.Enabled = false;
                        }

                        using (IDbTransaction Trans = this.Connection.BeginTransaction()) {
                                qGen.Insert InsertarComprob = new qGen.Insert("comprob");

                                switch (EntradaTipo.TextKey) {
                                        case "A":
                                        case "B":
                                        case "C":
                                        case "E":
                                        case "M":
                                                InsertarComprob.ColumnValues.AddWithValue("tipo_fac", "F" + EntradaTipo.TextKey);
                                                break;
                                        default:
                                                InsertarComprob.ColumnValues.AddWithValue("tipo_fac", EntradaTipo.TextKey);
                                                break;
                                }
                                InsertarComprob.ColumnValues.AddWithValue("id_formapago", 3);
                                InsertarComprob.ColumnValues.AddWithValue("id_sucursal", Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual);
                                InsertarComprob.ColumnValues.AddWithValue("pv", EntradaPv.ValueInt);
                                InsertarComprob.ColumnValues.AddWithValue("numero", EntradaDesde.ValueInt - 1);
                                InsertarComprob.ColumnValues.AddWithValue("fecha", new DateTime(1900, 1, 1, 0, 0, 0));
                                InsertarComprob.ColumnValues.AddWithValue("id_vendedor", Lbl.Sys.Config.Actual.UsuarioConectado.Id);
                                InsertarComprob.ColumnValues.AddWithValue("id_cliente", Lbl.Sys.Config.Actual.UsuarioConectado.Id);
                                InsertarComprob.ColumnValues.AddWithValue("obs", "Marcador de inicio de numeración.");
                                InsertarComprob.ColumnValues.AddWithValue("impresa", 1);
                                InsertarComprob.ColumnValues.AddWithValue("anulada", 1);
                                this.Connection.Execute(InsertarComprob);
                                Trans.Commit();
                        }

                        return base.Ok();
                }
        }
}
