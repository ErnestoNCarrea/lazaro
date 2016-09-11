using System;
using System.Windows.Forms;

namespace ServidorFiscal.Forms
{
        public partial class Estado : Lui.Forms.Form
        {
                public ServidorFiscal ServidorAsociado { get; set; }

                public Estado()
                {
                        this.DisplayStyle = Lazaro.Pres.DisplayStyles.Template.Current.White;
                        InitializeComponent();
                }


                private void FormEstado_Load(object sender, System.EventArgs e)
                {
                        this.MostrarEstado(null);
                }


                public void MostrarEstado(string texto)
                {
                        if (this.InvokeRequired) {
                                MethodInvoker Mi = delegate { this.MostrarEstado(texto); };
				Mi.Invoke();
                                return;
                        }

                        if (string.IsNullOrEmpty(texto))
                                EtiquetaEstado.Text = "Preparado, esperando órdenes.";
                        else
                                EtiquetaEstado.Text = texto;

                        if (string.IsNullOrEmpty(this.EtiquetaVersion.Text))
                                this.EtiquetaVersion.Text = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductVersion;

                        if (this.ServidorAsociado == null) {
                                this.IconoBandeja.Text = "No se cargó el servidor.";
                                this.EtiquetaPV.Text = "";
                                this.EtiquetaModeloImpresora.Text = "";
                        } else {
                                if (this.ServidorAsociado.PuntoDeVenta == null || this.ServidorAsociado.PuntoDeVenta.Numero == 0) {
                                        this.IconoBandeja.Text = "No hay definido un punto de venta para esta estación.";
                                        this.EtiquetaPV.Text = "";
                                        this.EtiquetaModeloImpresora.Text = "";
                                } else {
                                        this.IconoBandeja.Text = "Utilizando el punto de venta " + this.ServidorAsociado.PuntoDeVenta.Numero.ToString();
                                        this.EtiquetaPV.Text = this.ServidorAsociado.PuntoDeVenta.ToString();
                                        this.EtiquetaModeloImpresora.Text = this.ServidorAsociado.PuntoDeVenta.FiscalModeloImpresora.ToString() + " en puerto COM" + this.ServidorAsociado.PuntoDeVenta.FiscalPuerto.ToString() + " a " + this.ServidorAsociado.PuntoDeVenta.FiscalBps.ToString() + " bps";
                                }
                        }

                        this.Refresh();
                }


                private void IconoBandeja_DoubleClick(object sender, System.EventArgs e)
                {
                        this.WindowState = FormWindowState.Normal;
                        this.Show();
                }


                private void MenuOcultar_Click(object sender, System.EventArgs e)
                {
                        if (this.Visible == false) {
                                MenuOcultar.Text = "&Ocultar";
                                this.Show();
                        } else {
                                MenuOcultar.Text = "&Mostrar";
                                this.Hide();
                        }
                }


                private void MenuReiniciar_Click(System.Object sender, System.EventArgs e)
                {
                        ServidorAsociado.Impresora.EstadoServidor = Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Reiniciando;
                }


                private void MenuCerrar_Click(System.Object sender, System.EventArgs e)
                {
                        ServidorAsociado.Impresora.EstadoServidor = Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Apagando;
                }


                public void QuitarIcono()
                {
                        try {
                                this.IconoBandeja.Visible = false;
                                this.IconoBandeja.Dispose();
                        } catch {
                                //Nada
                        }
                }


                protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
                {
                        if (this.Visible) {
                                this.Hide();
                                e.Cancel = true;
                        } else {
                                this.QuitarIcono();
                        }
                        base.OnClosing(e);
                }


                private void BotonCerrar_Click(object sender, EventArgs e)
                {
                        ServidorAsociado.Impresora.EstadoServidor = Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Apagando;
                }


                private void BotonReiniciar_Click(object sender, EventArgs e)
                {
                        ServidorAsociado.Impresora.EstadoServidor = Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Reiniciando;
                }

                private void BotonOcultar_Click(object sender, EventArgs e)
                {
                        this.Hide();
                }

                private void Estado_FormClosing(object sender, FormClosingEventArgs e)
                {
                        if (this.Visible) {
                                this.Hide();
                                e.Cancel = true;
                        } else {
                                this.QuitarIcono();
                        }
                }
        }
}