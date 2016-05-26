using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Impresoras
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
	{
		public Editar()
		{
                        ElementoTipo = typeof(Lbl.Impresion.Impresora);

                        InitializeComponent();
		}

                public override void ActualizarControl()
                {
                        Lbl.Impresion.Impresora Impresora = this.Elemento as Lbl.Impresion.Impresora;

                        EntradaNombre.Text = Impresora.Nombre;
                        EntradaTipo.TextKey = ((int)(Impresora.Clase)).ToString();
                        EntradaEstacion.Text = Impresora.Estacion;
                        EntradaUbicacion.Text = Impresora.Ubicacion;
                        
                        switch(Impresora.Clase)
                        {
                                case Lbl.Impresion.ClasesImpresora.Papel:
                                        EntradaDispositivo.Text = Impresora.Dispositivo;
                                        EntradaCarga.TextKey = ((int)(Impresora.CargaPapel)).ToString();
                                        EntradaTalonario.TextKey = Impresora.UsaTalonario ? "1": "0";
                                        break;
                                case Lbl.Impresion.ClasesImpresora.FiscalAfip:
                                        EntradaFiscalPuerto.TextKey = Impresora.Dispositivo;
                                        EntradaFiscalModelo.TextKey = ((int)(Impresora.FiscalModelo)).ToString();
                                        EntradaFiscalBps.Text = Impresora.FiscalBps.ToString();
                                        break;
                                case Lbl.Impresion.ClasesImpresora.ElectronicaAfip:
                                        
                                        break;
                        }

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Impresion.Impresora Impresora = this.Elemento as Lbl.Impresion.Impresora;

                        Impresora.Nombre = EntradaNombre.Text;
                        Impresora.Clase = (Lbl.Impresion.ClasesImpresora)Lfx.Types.Parsing.ParseInt(EntradaTipo.TextKey);
                        Impresora.Estacion = EntradaEstacion.Text;
                        Impresora.Ubicacion = EntradaUbicacion.Text;

                        switch (Impresora.Clase) {
                                case Lbl.Impresion.ClasesImpresora.Papel:
                                        Impresora.Dispositivo = EntradaDispositivo.Text;
                                        Impresora.CargaPapel = (Lbl.Impresion.CargasPapel)Lfx.Types.Parsing.ParseInt(EntradaCarga.TextKey);
                                        Impresora.UsaTalonario = EntradaTalonario.TextKey == "1";
                                        break;
                                case Lbl.Impresion.ClasesImpresora.FiscalAfip:
                                        Impresora.Dispositivo = EntradaFiscalPuerto.TextKey;
                                        Impresora.FiscalModelo = (Lbl.Impresion.ModelosFiscales)Lfx.Types.Parsing.ParseInt(EntradaFiscalModelo.TextKey);
                                        Impresora.FiscalBps = Lfx.Types.Parsing.ParseInt(EntradaFiscalBps.Text);
                                        break;
                                case Lbl.Impresion.ClasesImpresora.ElectronicaAfip:

                                        break;
                        }

                        base.ActualizarElemento();
                }

                private void EntradaTipo_TextChanged(object sender, EventArgs e)
                {
                        EntradaTalonario.Enabled = EntradaTipo.TextKey == "1";
                        EntradaCarga.Enabled = EntradaTipo.TextKey == "1";
                        EntradaDispositivo.Enabled = EntradaTipo.TextKey == "1";

                        EntradaFiscalBps.Enabled = EntradaTipo.TextKey == "2";
                        EntradaFiscalModelo.Enabled = EntradaTipo.TextKey == "2";
                        EntradaFiscalPuerto.Enabled = EntradaTipo.TextKey == "2";
                }

                private void BotonSeleccionarEstacion_Click(object sender, EventArgs e)
                {
                        Lui.Forms.WorkstationSelectorForm SelEst = new Lui.Forms.WorkstationSelectorForm();
                        SelEst.Estacion = EntradaEstacion.Text;
                        if (SelEst.ShowDialog() == DialogResult.OK)
                                EntradaEstacion.Text = SelEst.Estacion;
                }

                private void BotonSeleccionarDispositivo_Click(object sender, EventArgs e)
                {
                        using (Lui.Printing.PrinterSelectionDialog FormularioSeleccionarImpresora = new Lui.Printing.PrinterSelectionDialog()) {
                                FormularioSeleccionarImpresora.MuestraImpresorasLazaro = false;
                                if (FormularioSeleccionarImpresora.ShowDialog() == DialogResult.OK) {
                                        Lbl.Impresion.Impresora Impr = FormularioSeleccionarImpresora.SelectedPrinter;
                                        if (Impr != null)
                                                EntradaDispositivo.Text = Impr.Dispositivo;
                                } else {
                                        return;
                                }
                        }
                }

                private void EntradaEstacion_TextChanged(object sender, EventArgs e)
                {
                        BotonSeleccionarDispositivo.Visible = EntradaEstacion.Text.ToUpperInvariant() == Lfx.Environment.SystemInformation.MachineName;
                }
	}
}

