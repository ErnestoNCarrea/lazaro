using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Lfx.Types;

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

                        EntradaModelo.ValueInt = ((int)(Pv.FiscalModeloImpresora));
                        EntradaPuerto.ValueInt = Pv.FiscalPuerto;
                        EntradaBps.ValueInt = Pv.FiscalBps;

                        EntradaVariante.ValueInt = Pv.Variante;

                        this.EntradaTipo_TextChanged(this, null);

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

                        Pv.FiscalModeloImpresora = (Lbl.Impresion.ModelosFiscales)(EntradaModelo.ValueInt);
                        Pv.FiscalPuerto = EntradaPuerto.ValueInt;
                        Pv.FiscalBps = EntradaBps.ValueInt;

                        Pv.Variante = EntradaVariante.ValueInt;

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
                        PanelTalonario.Visible = EntradaTipo.ValueInt == 1;
                        PanelControladorFiscal.Visible = EntradaTipo.ValueInt == 2;
                        PanelElectronicaAfip.Visible = EntradaTipo.ValueInt == 10;

                        if (EntradaEstacion.Text.Length == 0) {
                                // Si es un controlador fiscal y no tiene una estación asociada, as
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

                        this.InicarServidorFiscal();

                        base.AfterSave(transaction);
                }


                /// <summary>
                /// Iniciar un servidor fiscal, si esta es una estación fiscal y si no hay uno iniciado
                /// </summary>
                public void InicarServidorFiscal()
                {
                        // Buscar si algún punto de venta fiscal corresponde a este equipo
                        foreach (var Pv in Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.Values) {
                                if (Pv.Tipo == Lbl.Comprobantes.TipoPv.ControladorFiscal && Pv.Estacion == Lfx.Environment.SystemInformation.MachineName) {
                                        // Buscar un servidor fiscal ejecutándose
                                        Process[] ServidoresFiscales = Process.GetProcessesByName("ServidorFiscal.exe");
                                        if (ServidoresFiscales.Length > 0) {
                                                // Si hay uno, lo reinicio
                                                Lfx.Workspace.Master.DefaultScheduler.AddTask("REBOOT", "fiscal" + Pv.ToString(), "*");
                                        } else { 
                                                // Si no hay ninguno, lo inicio
                                                Lfx.Workspace.Master.RunTime.Execute("RUN ServidorFiscal.ServidorFiscal");
                                        }
                                        break;
                                }
                        }
                }

                public override OperationResult BeforeSave()
                {
                        var TipoPv = (Lbl.Comprobantes.TipoPv)EntradaTipo.ValueInt;

                        if (TipoPv == Lbl.Comprobantes.TipoPv.ElectronicoAfip) {
                                var RutaCertif = System.IO.Path.Combine(Lbl.Sys.Config.CarpetaEmpresa, "AFIP");
                                Lfx.Environment.Folders.EnsurePathExists(RutaCertif);

                                // Si no existe el archivo P12, le solicito al usuario que seleccione uno
                                var ArchivoCertif = System.IO.Path.Combine(RutaCertif, "Certificado.p12");
                                if (System.IO.File.Exists(ArchivoCertif) == false) {
                                        var DialogoSeleccionarP12 = new OpenFileDialog();
                                        DialogoSeleccionarP12.Title = "Seleccionar certificado";
                                        DialogoSeleccionarP12.AutoUpgradeEnabled = true;
                                        DialogoSeleccionarP12.DefaultExt = ".p12";
                                        DialogoSeleccionarP12.CheckFileExists = true;
                                        DialogoSeleccionarP12.CheckPathExists = true;
                                        //DialogoSeleccionarP12.InitialDirectory = System.IO.Path.Combine(Lfx.Environment.Folders.UserFolder, "Plantillas");
                                        DialogoSeleccionarP12.Multiselect = false;
                                        DialogoSeleccionarP12.ValidateNames = true;

                                        if (DialogoSeleccionarP12.ShowDialog() == DialogResult.OK && DialogoSeleccionarP12.FileName != null && DialogoSeleccionarP12.FileName.Length > 0) {
                                                System.IO.File.Copy(DialogoSeleccionarP12.FileName, ArchivoCertif);
                                        }
                                }
                        }

                        return base.BeforeSave();
                }
        }
}