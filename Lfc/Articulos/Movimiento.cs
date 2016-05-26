using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Articulos
{
        public partial class Movimiento : Lui.Forms.ChildDialogForm
        {
                public Movimiento()
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.Articulos.Articulo), Lbl.Sys.Permisos.Operaciones.Mover) == false) {
                                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                                this.Close();
                                return;
                        }

                        InitializeComponent();
                }


                public override Lfx.Types.OperationResult Ok()
                {
                        Lbl.Articulos.Articulo Art = EntradaArticulo.Elemento as Lbl.Articulos.Articulo;
                        Lfx.Types.OperationResult Res = new Lfx.Types.SuccessOperationResult();

                        if (Art == null) {
                                Res.Message += "Por favor seleccione un artículo." + Environment.NewLine;
                                Res.Success = false;
                        }

                        if (EntradaDesdeSituacion.ValueInt != EntradaDesdeSituacion.ValueInt) {
                                Res.Message += @"Por favor indique ""Desde"" y ""Hacia""." + Environment.NewLine;
                                Res.Success = false;
                        }

                        if (EntradaCantidad.ValueDecimal <= 0) {
                                Res.Message += "Por favor escriba la cantidad." + Environment.NewLine;
                                Res.Success = false;
                        }

                        if (Res.Success) {
                                if (Art != null && Art.ObtenerSeguimiento() != Lbl.Articulos.Seguimientos.Ninguno) {
                                        if (EntradaArticulo.DatosSeguimiento == null || EntradaArticulo.DatosSeguimiento.Count == 0) {
                                                return new Lfx.Types.FailureOperationResult("Debe ingresar los datos de seguimiento (Ctrl-S) del artículo '" + Art.Nombre + "' para poder realizar movimientos de stock.");
                                        } else {
                                                if (EntradaArticulo.DatosSeguimiento.CantidadTotal < EntradaArticulo.Cantidad)
                                                        return new Lfx.Types.FailureOperationResult("Debe ingresar los datos de seguimiento (Ctrl-S) de todos los artículos '" + Art.Nombre + "' para poder realizar movimientos de stock.");
                                        }
                                }
                        }


                        if (Res.Success) {
                                IDbTransaction Trans = this.Connection.BeginTransaction(IsolationLevel.Serializable);
                                decimal Cantidad = EntradaCantidad.ValueDecimal;
                                Lbl.Articulos.Situacion Origen, Destino;
                                Origen = EntradaDesdeSituacion.Elemento as Lbl.Articulos.Situacion;
                                Destino = EntradaHaciaSituacion.Elemento as Lbl.Articulos.Situacion;
                                Art.MoverExistencias(null, Cantidad, EntradaObs.Text, Origen, Destino, EntradaArticulo.DatosSeguimiento);
                                Trans.Commit();
                        }

                        return Res;
                }

                private void EntradaArticulo_TextChanged(System.Object sender, System.EventArgs e)
                {
                        MostrarStock();
                }


                private int IgnorarEntradaMovimiento_TextChanged = 0;
                private void EntradaMovimiento_TextChanged(object sender, System.EventArgs e)
                {
                        if (IgnorarEntradaMovimiento_TextChanged > 0)
                                return;

                        switch (EntradaMovimiento.TextKey) {
                                case "e":
                                        IgnorarEntradaMovimiento_TextChanged++;
                                        EntradaDesdeSituacion.ValueInt = 998;
                                        EntradaHaciaSituacion.ValueInt = 1;
                                        IgnorarEntradaMovimiento_TextChanged--;
                                        break;

                                case "s":
                                        IgnorarEntradaMovimiento_TextChanged++;
                                        EntradaDesdeSituacion.ValueInt = 1;
                                        EntradaHaciaSituacion.ValueInt = 999;
                                        IgnorarEntradaMovimiento_TextChanged--;
                                        break;

                                case "o":
                                        /* IgnorarEntradaMovimiento_TextChanged++;
                                        EntradaDesdeSituacion.TextInt = 0;
                                        EntradaHaciaSituacion.TextInt = 0;
                                        IgnorarEntradaMovimiento_TextChanged--; */
                                        break;
                        }

                        MostrarStock();
                }


                private void EntradaDesdeHaciaSituacion_TextChanged(object sender, System.EventArgs e)
                {
                        MostrarStock();
                        
                        Lbl.Articulos.Situacion Desde = EntradaDesdeSituacion.Elemento as Lbl.Articulos.Situacion;
                        Lbl.Articulos.Situacion Hacia = EntradaHaciaSituacion.Elemento as Lbl.Articulos.Situacion;
                        EtiquetaDesdeSituacion.Text = EntradaDesdeSituacion.TextDetail;
                        EtiquetaHaciaSituacion.Text = EntradaHaciaSituacion.TextDetail;

                        if ((Desde == null || Desde.CuentaExistencias == false) && (Hacia != null && Hacia.CuentaExistencias == true)) {
                                if (EntradaMovimiento.TextKey != "e")
                                        EntradaMovimiento.TextKey = "e";
                        } else if ((Hacia == null || Hacia.CuentaExistencias == false) && (Desde != null && Desde.CuentaExistencias == true)) {
                                if (EntradaMovimiento.TextKey != "s")
                                        EntradaMovimiento.TextKey = "s";
                        } else {
                                if (EntradaMovimiento.TextKey != "o")
                                        EntradaMovimiento.TextKey = "o";
                        }

                        EntradaDesdeAntes.Visible = Desde != null && Desde.CuentaExistencias;
                        EtiquetaDesdeFlecha.Visible = EntradaDesdeAntes.Visible;
                        EntradaDesdeDespues.Visible = EntradaDesdeAntes.Visible;

                        EntradaHaciaAntes.Visible = Hacia != null && Hacia.CuentaExistencias;
                        EtiquetaHaciaFlecha.Visible = EntradaHaciaAntes.Visible;
                        EntradaHaciaDespues.Visible = EntradaHaciaAntes.Visible;

                        EntradaArticulo.DatosSeguimiento = null;
                }

                private void MostrarStock()
                {
                        Lbl.Articulos.Articulo Articulo = EntradaArticulo.Elemento as Lbl.Articulos.Articulo;

                        if (Articulo != null && (EntradaDesdeSituacion.ValueInt != EntradaHaciaSituacion.ValueInt)) {
                                decimal Cantidad = EntradaCantidad.ValueDecimal;
                                decimal DesdeCantidad = this.Connection.FieldDecimal("SELECT cantidad FROM articulos_stock WHERE id_articulo=" + Articulo.Id.ToString() + " AND id_situacion=" + EntradaDesdeSituacion.ValueInt.ToString());
                                decimal HaciaCantidad = this.Connection.FieldDecimal("SELECT cantidad FROM articulos_stock WHERE id_articulo=" + Articulo.Id.ToString() + " AND id_situacion=" + EntradaHaciaSituacion.ValueInt.ToString());

                                if (EntradaDesdeSituacion.ValueInt < 998 || EntradaDesdeSituacion.ValueInt > 999) {
                                        EntradaDesdeAntes.Text = Lfx.Types.Formatting.FormatNumber(DesdeCantidad, Lbl.Sys.Config.Articulos.Decimales);
                                        EntradaDesdeDespues.Text = Lfx.Types.Formatting.FormatNumber(DesdeCantidad - Cantidad, Lbl.Sys.Config.Articulos.Decimales);
                                } else {
                                        EntradaDesdeAntes.Text = "N/A";
                                        EntradaDesdeDespues.Text = "N/A";
                                }

                                if (EntradaHaciaSituacion.ValueInt < 998 || EntradaHaciaSituacion.ValueInt > 999) {
                                        EntradaHaciaAntes.Text = Lfx.Types.Formatting.FormatNumber(HaciaCantidad, Lbl.Sys.Config.Articulos.Decimales);
                                        EntradaHaciaDespues.Text = Lfx.Types.Formatting.FormatNumber(HaciaCantidad + Cantidad, Lbl.Sys.Config.Articulos.Decimales);
                                } else {
                                        EntradaHaciaAntes.Text = "N/A";
                                        EntradaHaciaDespues.Text = "N/A";
                                }
                        } else {
                                EntradaDesdeAntes.Text = "";
                                EntradaDesdeDespues.Text = "";
                                EntradaHaciaAntes.Text = "";
                                EntradaHaciaDespues.Text = "";
                        }
                }


                protected override void OnLoad(EventArgs e)
                {
                        base.OnLoad(e);
                        if (this.Connection != null) {
                                EntradaMovimiento.TextKey = "s";
                                EntradaDesdeSituacion.Visible = Lfx.Workspace.Master.CurrentConfig.Productos.StockMultideposito;
                                EntradaHaciaSituacion.Visible = Lfx.Workspace.Master.CurrentConfig.Productos.StockMultideposito;
                                Label7.Visible = Lfx.Workspace.Master.CurrentConfig.Productos.StockMultideposito;
                                Label8.Visible = Lfx.Workspace.Master.CurrentConfig.Productos.StockMultideposito;
                        }
                }


                private void EntradaArticulo_ObtenerDatosSeguimiento(object sender, EventArgs e)
                {
                        Lbl.Articulos.Articulo Articulo = EntradaArticulo.Elemento as Lbl.Articulos.Articulo;
                        decimal Cant = EntradaArticulo.Cantidad;

                        if (Cant != 0) {
                                Lfc.Articulos.EditarSeguimiento Editar = new Lfc.Articulos.EditarSeguimiento();
                                Editar.Articulo = Articulo;
                                Editar.Cantidad = Math.Abs(System.Convert.ToInt32(Cant));
                                Editar.SituacionOrigen = this.EntradaDesdeSituacion.Elemento as Lbl.Articulos.Situacion;
                                Editar.DatosSeguimiento = EntradaArticulo.DatosSeguimiento;
                                if (Editar.ShowDialog() == DialogResult.OK) {
                                        EntradaArticulo.DatosSeguimiento = Editar.DatosSeguimiento;
                                }
                        }
                }

                private void EntradaArticulo_PrecioCantidadChanged(object sender, EventArgs e)
                {
                        EntradaCantidad.ValueDecimal = EntradaArticulo.Cantidad;
                }

        }
}