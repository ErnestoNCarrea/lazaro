using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Lazaro.WinMain.Misc
{
        public partial class Fiscal : Lui.Forms.DialogForm
        {
                private Lbl.ColeccionGenerica<Lbl.Comprobantes.PuntoDeVenta> PuntosDeVenta = null;
                private int Pv = 0;
                private int Pventa = 0;

                public Fiscal()
                {
                        InitializeComponent();
                }


                protected override void OnLoad(EventArgs e)
                {
                        base.OnLoad(e);
                        if (this.Connection != null) {
                                //Lleno la tabla de PVs
                                System.Data.DataTable TablaPvs = this.Connection.Select("SELECT * FROM pvs WHERE tipo=2 AND id_sucursal=" + Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual.ToString());
                                this.PuntosDeVenta = new Lbl.ColeccionGenerica<Lbl.Comprobantes.PuntoDeVenta>(this.Connection, TablaPvs);
                                string[] PvsDataSet = new string[TablaPvs.Rows.Count];
                                int i = 0;
                                foreach (Lbl.Comprobantes.PuntoDeVenta Punto in this.PuntosDeVenta) {
                                        PvsDataSet[i++] = "Punto de venta Nº " + Punto.ToString() + "|" + Punto.Id.ToString();
                                }
                                EntradaPv.SetData = PvsDataSet;

                                if (EntradaPv.SetData.Length > 0) {
                                        //Busco el PV para esta estación, en esta sucursal
                                        this.Pv = Connection.FieldInt("SELECT id_pv FROM pvs WHERE tipo=2 AND id_sucursal=" + Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual.ToString() + " AND estacion='" + Lfx.Environment.SystemInformation.MachineName + "'");
                                        this.Pventa = Connection.FieldInt("SELECT numero FROM pvs WHERE tipo=2 AND id_sucursal=" + Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual.ToString() + " AND estacion='" + Lfx.Environment.SystemInformation.MachineName + "'");
                                        if (this.Pv == 0)
                                                //Busco el PV para alguna estación, en esta sucursal
                                                this.Pv = Connection.FieldInt("SELECT id_pv FROM pvs WHERE tipo=2 AND id_sucursal=" + Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual.ToString());
                                                this.Pventa = Connection.FieldInt("SELECT numero FROM pvs WHERE tipo=2 AND id_sucursal=" + Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual.ToString() + " AND estacion='" + Lfx.Environment.SystemInformation.MachineName + "'");

                                        if (this.Pv != 0)
                                                EntradaPv.ValueInt = this.Pv;
                                }

                                MostrarDatos();
                        }
                }


                private void MostrarDatos()
                {
                        if (this.Pv != 0) {
                                string LsaString = Connection.FieldString("SELECT lsa FROM pvs WHERE id_pv=" + this.Pv.ToString());

                                if (LsaString != null && LsaString.Length > 0) {
                                        System.DateTime LSA = DateTime.ParseExact(LsaString,
                                                @"yyyy\-MM\-dd HH\:mm\:ss",
                                                System.Globalization.DateTimeFormatInfo.InvariantInfo,
                                                System.Globalization.DateTimeStyles.AllowWhiteSpaces);

                                        if (LSA < System.DateTime.Now.AddMinutes(-10))
                                                EtiquetaEstadoServidor.Text = "Inactivo";
                                        else
                                                EtiquetaEstadoServidor.Text = "Activo";
                                } else {
                                        EtiquetaEstadoServidor.Text = "Inactivo";
                                }

                                string UltimoZ = Connection.FieldString("SELECT ultimoz FROM pvs WHERE id_pv=" + this.Pv.ToString());
                                if (UltimoZ != null && UltimoZ.Length > 0) {
                                        System.DateTime FechaUltimoCierreZ = DateTime.ParseExact(UltimoZ,
                                                @"yyyy\-MM\-dd HH\:mm\:ss",
                                                System.Globalization.DateTimeFormatInfo.InvariantInfo,
                                                System.Globalization.DateTimeStyles.AllowWhiteSpaces);

                                        EtiquetaUltimoCierreZ.Text = Lfx.Types.Formatting.FormatSmartDateAndTime(FechaUltimoCierreZ);
                                } else {
                                        EtiquetaUltimoCierreZ.Text = "desconocido";
                                }
                        }
                        HabilitarBotones();
                }

                private void Timer1_Tick(object sender, System.EventArgs e)
                {
                        MostrarDatos();
                }

                private void EntradaPV_TextChanged(object sender, System.EventArgs e)
                {
                        this.Pv = Lfx.Types.Parsing.ParseInt(EntradaPv.TextKey);
                        MostrarDatos();
                }

                private void HabilitarBotones()
                {
                        if (EtiquetaEstadoServidor.Text == "Activo") {
                                BotonCierreZ.Enabled = true;
                                BotonReiniciar.Enabled = true;
                                BotonIniciarDetener.Text = "Detener";
                        } else if (EtiquetaEstadoServidor.Text == "Inactivo") {
                                BotonCierreZ.Enabled = false;
                                BotonReiniciar.Enabled = false;
                                BotonIniciarDetener.Text = "Iniciar";
                        }
                        BotonIniciarDetener.Enabled = true;
                }

                private void BotonCierreZ_Click(object sender, System.EventArgs e)
                {
                        Lfx.Workspace.Master.DefaultScheduler.AddTask("CIERRE Z", "fiscal" + this.Pventa.ToString(), "*");
                        Lui.Forms.MessageBox.Show("Se envió un comando de Cierre Z al punto de venta seleccionado.", "Cierre Z");
                        BotonCierreZ.Enabled = false;
                }

                private void BotonReiniciar_Click(object sender, System.EventArgs e)
                {
                        Lui.Forms.MessageBox.Show("Se envió un comando de Reiniciar al punto de venta seleccionado.", "Reiniciar");
                        Lfx.Workspace.Master.DefaultScheduler.AddTask("REBOOT", "fiscal" + this.Pventa.ToString(), "*");
                }

                private void BotonIniciarDetener_Click(object sender, System.EventArgs e)
                {
                        if (BotonIniciarDetener.Text == "Iniciar") {
                                string EstacionFiscal = Connection.FieldString("SELECT estacion FROM pvs WHERE id_pv=" + this.Pv.ToString());
                                if (string.Compare(EstacionFiscal, System.Environment.MachineName, true) == 0) {
                                        // Servidor local
                                        Lfx.Workspace.Master.RunTime.Execute("FISCAL INICIAR");
                                } else {
                                        // Servidor remoto
                                        Lui.Forms.MessageBox.Show("Se envió una orden de iniciar el servidor fiscal a través de la red. Para que esto funcione es necesario que Lázaro esté abierto en el equipo remoto.", "Iniciar remoto");
                                }
                        } else {
                                Lfx.Workspace.Master.DefaultScheduler.AddTask("END", "fiscal" + this.Pv.ToString(), "*");
                                Lui.Forms.MessageBox.Show("Se envió una orden de detener el servidor fiscal. Puede demorar hasta 1 minuto y mientras tanto seguir apareciendo como activo.", "Detener");
                        }
                }

                private void Fiscal_Load(object sender, System.EventArgs e)
                {
                        OkButton.Visible = false;
                        CancelCommandButton.Text = "Cerrar";
                }
        }
}