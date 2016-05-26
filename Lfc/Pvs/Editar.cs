using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Pvs
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Comprobantes.PuntoDeVenta);

                        InitializeComponent();

                }

                protected override void OnLoad(EventArgs e)
                {
                        base.OnLoad(e);
                        if (this.Connection != null) {
                                System.Collections.Generic.List<string> ListaTipos = new System.Collections.Generic.List<string>();
                                ListaTipos.Add("Cualquiera|*");
                                ListaTipos.Add("Facutras|F");
                                ListaTipos.Add("Notas de débito|ND");
                                ListaTipos.Add("Notas de crédito|NC");
                                ListaTipos.Add("Facutras, notas de débito|F,ND");
                                ListaTipos.Add("Facutras, notas de crédito y débito|F,NC,ND");

                                System.Data.DataTable DocumentosTipos = this.Connection.Select("SELECT letra,nombre FROM documentos_tipos ORDER BY letra");
                                foreach (System.Data.DataRow DocumentoTipo in DocumentosTipos.Rows) {
                                        ListaTipos.Add(DocumentoTipo["nombre"].ToString() + "|" + DocumentoTipo["letra"].ToString());
                                }
                                EntradaTipoFac.SetData = ListaTipos.ToArray();
                        }
                }


                public override void ActualizarControl()
                {
                        Lbl.Comprobantes.PuntoDeVenta Pv = this.Elemento as Lbl.Comprobantes.PuntoDeVenta;

                        EntradaPrefijo.ValueInt = Pv.Prefijo;
                        EntradaNumero.ValueInt = Pv.Numero;
                        if (string.IsNullOrEmpty(Pv.TipoFac))
                                EntradaTipoFac.TextKey = "*";
                        else
                                EntradaTipoFac.TextKey = Pv.TipoFac;
                        EntradaSucursal.Elemento = Pv.Sucursal;
                        EntradaImpresora.Elemento = Pv.Impresora;

                        EntradaTipo.ValueInt = (int)(Pv.Tipo);

                        EntradaDeTalonario.Value = Pv.UsaTalonario;
                        EntradaEstacion.Text = Pv.Estacion;
                        EntradaCarga.ValueInt = Pv.CargaManual ? 1 : 0;

                        EntradaModelo.ValueInt = ((int)(Pv.ModeloImpresoraFiscal));
                        EntradaPuerto.ValueInt = Pv.Puerto;
                        EntradaBps.ValueInt = Pv.Bps;

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Comprobantes.PuntoDeVenta Pv = this.Elemento as Lbl.Comprobantes.PuntoDeVenta;

                        Pv.Prefijo = EntradaPrefijo.ValueInt;
                        Pv.Numero = EntradaNumero.ValueInt;
                        if (EntradaTipoFac.TextKey == "*")
                                Pv.TipoFac = "";
                        else
                                Pv.TipoFac = EntradaTipoFac.TextKey;
                        Pv.Sucursal = EntradaSucursal.Elemento as Lbl.Entidades.Sucursal;
                        Pv.Impresora = EntradaImpresora.Elemento as Lbl.Impresion.Impresora;

                        Pv.Tipo = (Lbl.Comprobantes.TipoPv)(EntradaTipo.ValueInt);

                        Pv.UsaTalonario = EntradaDeTalonario.Value;
                        Pv.Estacion = EntradaEstacion.Text;
                        Pv.CargaManual = EntradaCarga.ValueInt == 1;

                        Pv.ModeloImpresoraFiscal = (Lbl.Impresion.ModelosFiscales)(EntradaModelo.ValueInt);
                        Pv.Puerto = EntradaPuerto.ValueInt;
                        Pv.Bps = EntradaBps.ValueInt;

                        base.ActualizarElemento();
                }


                private void BotonEstacionSeleccionar_Click(object sender, System.EventArgs e)
                {
                        Lui.Forms.WorkstationSelectorForm SelEst = new Lui.Forms.WorkstationSelectorForm();
                        SelEst.Estacion = EntradaEstacion.Text;
                        if (SelEst.ShowDialog() == DialogResult.OK)
                                EntradaEstacion.Text = SelEst.Estacion;
                }


                private void EntradaTipo_TextChanged(object sender, System.EventArgs e)
                {
                        EntradaModelo.Enabled = EntradaTipo.TextKey == "2";
                        EntradaPuerto.Enabled = EntradaTipo.TextKey == "2";
                        EntradaBps.Enabled = EntradaTipo.TextKey == "2";
                        EntradaCarga.Enabled = EntradaTipo.TextKey == "1";

                        if (EntradaEstacion.Text.Length == 0) {
                                EntradaEstacion.Text = Lfx.Environment.SystemInformation.MachineName;
                        }
                }


                public override Lfx.Types.OperationResult ValidarControl()
                {
                        if (EntradaSucursal.Elemento == null)
                                return new Lfx.Types.FailureOperationResult("Por favor seleccione una sucursal.");

                        if (EntradaNumero.ValueInt <= 0)
                                return new Lfx.Types.FailureOperationResult("Por favor escriba el número para este punto de venta.");

                        if (EntradaTipo.ValueInt == 2) {
                                if (EntradaEstacion.Text.Length == 0)
                                        return new Lfx.Types.FailureOperationResult("Por favor seleccione el equipo a la cual está conectada la impresora fiscal.");
                        }

                        return base.ValidarControl();
                }

                public override void AfterSave(System.Data.IDbTransaction transaction)
                {
                        Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.Clear();

                        base.AfterSave(transaction);
                }
        }
}