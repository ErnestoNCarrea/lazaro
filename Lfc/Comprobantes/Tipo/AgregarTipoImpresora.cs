using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Tipo
{
        public partial class AgregarTipoImpresora : Lui.Forms.DialogForm
        {
                public Lbl.Comprobantes.Tipo Tipo;

                public AgregarTipoImpresora()
                {
                        InitializeComponent();
                        OkButton.Enabled = false;
                }

                public Lbl.Impresion.TipoImpresora TipoImpresora
                {
                        get
                        {
                                Lbl.Impresion.TipoImpresora Res = new Lbl.Impresion.TipoImpresora(this.Tipo.Connection);
                                Res.Tipo = Tipo;
                                Res.Impresora = EntradaImpresora.Elemento as Lbl.Impresion.Impresora;
                                Res.Sucursal = EntradaSucursal.Elemento as Lbl.Entidades.Sucursal;
                                if (EntradaEstacion.Text.Length > 0)
                                        Res.Estacion = EntradaEstacion.Text;
                                else
                                        Res.Estacion = null;

                                int Pv = EntradaPuntoDeVenta.ValueInt;
                                if (Pv > 0) {
                                        
                                        int IdPv = 0;
                                        if (Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.ContainsKey(Pv))
                                                IdPv = Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero[Pv].Id;
                                        if (IdPv == 0)
                                                Res.PuntoDeVenta = null;
                                        else
                                                Res.PuntoDeVenta = new Lbl.Comprobantes.PuntoDeVenta(this.Connection, IdPv);
                                } else {
                                        Res.PuntoDeVenta = null;
                                }

                                return Res;
                        }
                }

                private void BotonEstacionSeleccionar_Click(object sender, EventArgs e)
                {
                        Lui.Forms.WorkstationSelectorForm SelEst = new Lui.Forms.WorkstationSelectorForm();
                        SelEst.Estacion = EntradaEstacion.Text;
                        if (SelEst.ShowDialog() == DialogResult.OK)
                                EntradaEstacion.Text = SelEst.Estacion;
                }

                private void EntradaImpresora_TextChanged(object sender, EventArgs e)
                {
                        OkButton.Enabled = EntradaImpresora.Elemento != null;
                }
        }
}
