using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Cajas.Vencimientos
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Vencimientos.Vencimiento);

                        InitializeComponent();
                }

                public override void ActualizarControl()
                {
                        Lbl.Vencimientos.Vencimiento Res = this.Elemento as Lbl.Vencimientos.Vencimiento;

                        EntradaConcepto.Elemento = Res.Concepto;
                        EntradaFechaFin.Text = Lfx.Types.Formatting.FormatDate(Res.FechaFin);
                        EntradaFechaInicio.Text = Lfx.Types.Formatting.FormatDate(Res.FechaInicio);
                        EntradaFrecuencia.TextKey = Res.Frecuencia.ToString();
                        EntradaImporte.Text = Lfx.Types.Formatting.FormatCurrency(Res.Importe, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        EntradaNombre.Text = Res.Nombre;
                        EntradaObs.Text = Res.Obs;
                        EntradaRepetir.Text = Res.Repetir.ToString();
                        EntradaEstado.TextKey = Res.Estado.ToString();

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Vencimientos.Vencimiento Res = this.Elemento as Lbl.Vencimientos.Vencimiento;

                        Res.Concepto = EntradaConcepto.Elemento as Lbl.Cajas.Concepto;
                        Res.Estado = Lfx.Types.Parsing.ParseInt(EntradaEstado.TextKey);
                        Res.FechaFin = Lfx.Types.Parsing.ParseDate(EntradaFechaFin.Text);
                        Res.FechaInicio = Lfx.Types.Parsing.ParseDate(EntradaFechaInicio.Text);
                        switch (EntradaFrecuencia.TextKey) {
                                case "Unica":
                                        Res.Frecuencia = Lbl.Vencimientos.Frecuencias.Unica;
                                        break;
                                case "Diaria":
                                        Res.Frecuencia = Lbl.Vencimientos.Frecuencias.Diaria;
                                        break;
                                case "Semanal":
                                        Res.Frecuencia = Lbl.Vencimientos.Frecuencias.Semanal;
                                        break;
                                case "Mensual":
                                        Res.Frecuencia = Lbl.Vencimientos.Frecuencias.Mensual;
                                        break;
                                case "Bimestral":
                                        Res.Frecuencia = Lbl.Vencimientos.Frecuencias.Bimestral;
                                        break;
                                case "Trimestral":
                                        Res.Frecuencia = Lbl.Vencimientos.Frecuencias.Trimestral;
                                        break;
                                case "Cuatrimestral":
                                        Res.Frecuencia = Lbl.Vencimientos.Frecuencias.Cuatrimestral;
                                        break;
                                case "Semestral":
                                        Res.Frecuencia = Lbl.Vencimientos.Frecuencias.Semestral;
                                        break;
                                case "Anual":
                                        Res.Frecuencia = Lbl.Vencimientos.Frecuencias.Anual;
                                        break;
                        }

                        Res.Importe = Lfx.Types.Parsing.ParseCurrency(EntradaImporte.Text);
                        Res.Nombre = EntradaNombre.Text;
                        Res.Obs = EntradaObs.Text;
                        Res.Repetir = Lfx.Types.Parsing.ParseInt(EntradaRepetir.Text);

                        base.ActualizarElemento();
                }
        }
}