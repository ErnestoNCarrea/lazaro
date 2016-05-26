using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Tipo
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
	{
		public Editar()
		{
                        ElementoTipo = typeof(Lbl.Comprobantes.Tipo);

                        InitializeComponent();
		}

                public override void ActualizarControl()
                {
                        Lbl.Comprobantes.Tipo Tipo = this.Elemento as Lbl.Comprobantes.Tipo;

                        EntradaNombre.Text = Tipo.Nombre;
                        EntradaNombre.ReadOnly = true;
                        EntradaLetra.Text = Tipo.Nomenclatura;
                        EntradaLetra.ReadOnly = true;

                        EntradaMueveStock.ValueInt = System.Convert.ToInt32(Tipo.MueveExistencias);
                        EntradaSituacionOrigen.Elemento = Tipo.SituacionOrigen;
                        EntradaSituacionDestino.Elemento = Tipo.SituacionDestino;
                        EntradaNumerarAl.TextKey = Tipo.NumerarAlGuardar ? "1" : (Tipo.NumerarAlImprimir ? "2" : "0");
                        EntradaImprimirRepetir.ValueInt = Tipo.PermiteImprimirVariasVeces ? 1 : 0;
                        EntradaImprimirModificar.ValueInt = Tipo.PermiteModificarImpresos ? 1 : 0;
                        EntradaImprimirGuardar.ValueInt = Tipo.ImprimirAlGuardar ? 1 : 0;
                        EntradaCargaPapel.ValueInt = (int)(Tipo.CargaPapel);

                        this.MostrarImpresoras(Tipo.Impresoras);

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Comprobantes.Tipo Tipo = this.Elemento as Lbl.Comprobantes.Tipo;

                        Tipo.Nombre = EntradaNombre.Text;
                        Tipo.Nomenclatura = EntradaLetra.Text;
                        Tipo.MueveExistencias = EntradaMueveStock.ValueInt;
                        Tipo.SituacionOrigen = EntradaSituacionOrigen.Elemento as Lbl.Articulos.Situacion;
                        Tipo.SituacionDestino = EntradaSituacionDestino.Elemento as Lbl.Articulos.Situacion;
                        Tipo.NumerarAlGuardar = EntradaNumerarAl.TextKey == "1";
                        Tipo.NumerarAlImprimir = EntradaNumerarAl.TextKey == "2";
                        Tipo.PermiteImprimirVariasVeces = EntradaImprimirRepetir.TextKey == "1";
                        Tipo.PermiteModificarImpresos = EntradaImprimirModificar.TextKey == "1";
                        Tipo.ImprimirAlGuardar = EntradaImprimirGuardar.TextKey == "1";
                        Tipo.CargaPapel = (Lbl.Impresion.CargasPapel)(EntradaCargaPapel.ValueInt);

                        base.ActualizarElemento();
                }

                private void EntradaMueveStock_TextChanged(object sender, EventArgs e)
                {
                        EntradaSituacionOrigen.Enabled = EntradaMueveStock.TextKey == "1";
                        EntradaSituacionDestino.Enabled = EntradaMueveStock.TextKey == "1";
                }

                private void MostrarImpresoras(Lbl.ColeccionGenerica<Lbl.Impresion.TipoImpresora> impresoras)
                {
                        Listado.SuspendLayout();
                        Listado.Items.Clear();

                        if (impresoras != null) {
                                foreach (Lbl.Impresion.TipoImpresora Impr in impresoras) {
                                        this.MostrarImpresora(Impr);
                                }
                        }

                        Listado.ResumeLayout();
                }

                private void MostrarImpresora(Lbl.Impresion.TipoImpresora impresora)
                {
                        string Key = impresora.GetHashCode().ToString();
                        ListViewItem Itm = Listado.Items.Add(Key, Key, 0);
                        Itm.Tag = impresora;

                        if (impresora.Sucursal == null)
                                Itm.SubItems.Add("Todas");
                        else
                                Itm.SubItems.Add(impresora.Sucursal.Nombre);

                        if (impresora.Estacion == null)
                                Itm.SubItems.Add("Todas");
                        else
                                Itm.SubItems.Add(impresora.Estacion);

                        if (impresora.PuntoDeVenta == null)
                                Itm.SubItems.Add("Todos");
                        else
                                Itm.SubItems.Add(impresora.PuntoDeVenta.ToString());

                        Itm.SubItems.Add(impresora.Impresora.ToString());
                }

                private void BotonQuitar_Click(object sender, System.EventArgs e)
                {
                        if (Listado.SelectedItems.Count > 0) {
                                Lbl.Impresion.TipoImpresora Impr = Listado.SelectedItems[0].Tag as Lbl.Impresion.TipoImpresora;
                                if (Impr != null)
                                        QuitarImpresora(Impr);
                        }
                }

                private void QuitarImpresora(Lbl.Impresion.TipoImpresora impresora)
                {
                        Lbl.Comprobantes.Tipo Tipo = this.Elemento as Lbl.Comprobantes.Tipo;

                        Tipo.Impresoras.Remove(impresora);
                        Listado.Items.RemoveByKey(impresora.GetHashCode().ToString());
                }

                private void BotonAgregar_Click(object sender, EventArgs e)
                {
                        Lbl.Comprobantes.Tipo Tipo = this.Elemento as Lbl.Comprobantes.Tipo;
                        AgregarTipoImpresora FormularioAgregar = new AgregarTipoImpresora();
                        FormularioAgregar.Tipo = Tipo;

                        if (FormularioAgregar.ShowDialog() == DialogResult.OK) {
                                Lbl.Impresion.TipoImpresora TipoImpr = FormularioAgregar.TipoImpresora;
                                if (TipoImpr != null && TipoImpr.Impresora != null) {
                                        Tipo.Impresoras.Add(TipoImpr);
                                        this.MostrarImpresora(TipoImpr);
                                }
                        }
                }


                public override Lazaro.Pres.DisplayStyles.IDisplayStyle HeaderDisplayStyle
                {
                        get
                        {
                                return Lazaro.Pres.DisplayStyles.Template.Current.Comprobantes;
                        }
                }
	}
}

