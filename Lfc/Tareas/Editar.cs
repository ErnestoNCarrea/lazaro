using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Tareas
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                internal decimal Descuento = 0;
                
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Tareas.Tarea);

                        InitializeComponent();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Tareas.Tarea Tarea = this.Elemento as Lbl.Tareas.Tarea;

                        Tarea.Cliente = EntradaCliente.Elemento as Lbl.Personas.Persona;
                        Tarea.Encargado = EntradaEncargado.Elemento as Lbl.Personas.Persona;
                        Tarea.Tipo = EntradaTarea.Elemento as Lbl.Tareas.Tipo;
                        Tarea.Prioridad = EntradaPrioridad.ValueInt;
                        Tarea.Nombre = EntradaAsunto.Text;
                        if (Tarea.Presupuesto != null && EntradaDescripcion.Text.Trim() == Tarea.Presupuesto.Obs)
                                Tarea.Descripcion = null;
                        else
                                Tarea.Descripcion = EntradaDescripcion.Text.Trim();
                        Tarea.Estado = EntradaEstado.ValueInt;
                        Tarea.FechaEstimada = Lfx.Types.Parsing.ParseDate(EntradaEntregaEstimada.Text);
                        Tarea.FechaLimite = Lfx.Types.Parsing.ParseDate(EntradaEntregaLimite.Text);
                        Tarea.Importe = EntradaImportePresupuesto.ValueDecimal;
                        Tarea.Obs = EntradaObs.Text;

                        base.ActualizarElemento();
                }

                public override void ActualizarControl()
                {
                        Lbl.Tareas.Tarea Tarea = this.Elemento as Lbl.Tareas.Tarea;

                        EntradaAsunto.Text = Tarea.Nombre;
                        EntradaCliente.Elemento = Tarea.Cliente;
                        EntradaEncargado.Elemento = Tarea.Encargado;
                        EntradaTarea.Elemento = Tarea.Tipo;
                        EntradaPrioridad.ValueInt = ((int)(Tarea.Prioridad));
                        EntradaDescripcion.Text = Tarea.Descripcion;
                        EntradaEstado.ValueInt = Tarea.Estado;
                        EntradaFechaIngreso.Text = Lfx.Types.Formatting.FormatDateAndTime(Tarea.Fecha);
                        EntradaEntregaEstimada.Text = Lfx.Types.Formatting.FormatDate(Tarea.FechaEstimada);
                        EntradaEntregaLimite.Text = Lfx.Types.Formatting.FormatDate(Tarea.FechaLimite);
                        EntradaImportePresupuesto.ValueDecimal = Tarea.Importe;
                        EntradaObs.Text = Tarea.Obs;

                        if (Tarea.Presupuesto == null)
                                EntradaComprobante.Text = "";
                        else
                                EntradaComprobante.Text = Tarea.Presupuesto.ToString();

                        if (Tarea.Existe) {
                                this.MostrarPresupuesto();
                                this.CargarHistorial();
                        }

                        base.ActualizarControl();

                        if (Tarea.Existe)
                                this.Text = Tarea.ToString() + " de " + Tarea.Cliente.ToString();
                        else
                                this.Text = "Creando nueva tarea";
                }


                public override Lfx.Types.OperationResult ValidarControl()
                {
                        if (EntradaAsunto.Text.Length == 0) 
                                return new Lfx.Types.FailureOperationResult("Debe escribir el nombre de la tarea.");

                        if (EntradaEncargado.Elemento == null)
                                return new Lfx.Types.FailureOperationResult("Debe seleccionar el encargado.");

                        if (EntradaCliente.Elemento == null)
                                return new Lfx.Types.FailureOperationResult("Debe seleccionar el cliente.");

                        if (EntradaTarea.Elemento == null)
                                return new Lfx.Types.FailureOperationResult("Debe seleccionar el tipo de tarea.");

                        return base.ValidarControl(); ;
                }


                private void CargarHistorial()
                {
                        ListaHistorialCliente.BeginUpdate();
                        ListaHistorialCliente.Items.Clear();
                        ListaHistorialTarea.BeginUpdate();
                        ListaHistorialTarea.Items.Clear();

                        string TextoSql = "SELECT tickets_eventos.id_ticket, tickets_eventos.fecha, tickets_eventos.descripcion, personas.nombre FROM tickets_eventos, personas WHERE tickets_eventos.id_tecnico=personas.id_persona AND tickets_eventos.id_ticket IN (SELECT id_ticket FROM tickets WHERE id_persona=" + EntradaCliente.ValueInt.ToString() + ") ORDER BY tickets_eventos.id_evento DESC";
                        System.Data.DataTable Eventos = this.Connection.Select(TextoSql);
                        if (Eventos.Rows.Count > 0) {
                                foreach (System.Data.DataRow Evento in Eventos.Rows) {
                                        ListViewItem Itm;
                                        if (System.Convert.ToInt32(Evento["id_ticket"]) == this.Elemento.Id) {
                                                Itm = ListaHistorialTarea.Items.Add(System.Convert.ToString(Evento["id_ticket"]));
                                        } else {
                                                Itm = ListaHistorialCliente.Items.Add(System.Convert.ToString(Evento["id_ticket"]));
                                                Itm.SubItems.Add(new ListViewItem.ListViewSubItem(Itm, Evento["nombre"].ToString()));
                                        }
                                        Itm.SubItems.Add(new ListViewItem.ListViewSubItem(Itm, Lfx.Types.Formatting.FormatDate(Evento["fecha"])));
                                        Itm.SubItems.Add(new ListViewItem.ListViewSubItem(Itm, System.Convert.ToString(Evento["descripcion"]).Replace(System.Convert.ToString(Lfx.Types.ControlChars.Cr), " ").Replace(System.Convert.ToString(Lfx.Types.ControlChars.Lf), "")));
                                        if (System.Convert.ToInt32(Evento["id_ticket"]) != this.Elemento.Id)
                                                Itm.ForeColor = System.Drawing.Color.Gray;
                                }
                        }

                        ListaHistorialCliente.EndUpdate();
                        ListaHistorialTarea.EndUpdate();

                        // Ancho automático para las columnas
                        foreach (System.Windows.Forms.ColumnHeader lvHeader in ListaHistorialCliente.Columns) {
                                lvHeader.Width = -2;
                        }
                        foreach (System.Windows.Forms.ColumnHeader lvHeader in ListaHistorialTarea.Columns) {
                                lvHeader.Width = -2;
                        }
                }


                private Lfx.Types.OperationResult CargarNovedad()
                {
                        if (this.Elemento.Existe == false) {
                                return new Lfx.Types.FailureOperationResult("No se puede cargar novedades en una Tarea que aun no ha sido creada.");
                        } else {
                                Tareas.Novedad FormularioNovedad = new Tareas.Novedad();
                                FormularioNovedad.EntradaTicket.Elemento = this.Elemento;
                                FormularioNovedad.EntradaTicket.Enabled = false;
                                if (FormularioNovedad.ShowDialog() == DialogResult.OK)
                                        this.CargarHistorial();
                                return new Lfx.Types.SuccessOperationResult();
                        }
                }


                private Lfx.Types.OperationResult AsociarPresupuesto()
                {
                        Lbl.Tareas.Tarea Tarea = this.Elemento as Lbl.Tareas.Tarea;

                        if (Tarea.Presupuesto == null) {
                                using (Comprobantes.Seleccionar SelPresup = new Comprobantes.Seleccionar()) {
                                        SelPresup.AceptarAnuladas = false;
                                        SelPresup.AceptarNoImpresas = true;
                                        SelPresup.AceptarCanceladas = true;
                                        SelPresup.Cliente = EntradaCliente.Elemento as Lbl.Personas.Persona;
                                        SelPresup.TipoComprob = Comprobantes.Seleccionar.TiposComprob.Presupuestos;
                                        if (SelPresup.ShowDialog() == DialogResult.OK && SelPresup.Comprobante != null) {
                                                Tarea.Presupuesto = SelPresup.Comprobante as Lbl.Comprobantes.Presupuesto;
                                                if (EntradaCliente.Elemento == null)
                                                        EntradaCliente.Elemento = Tarea.Presupuesto.Cliente;
                                                if (EntradaDescripcion.Text == string.Empty)
                                                        EntradaDescripcion.Text = Tarea.Presupuesto.Obs;
                                                else if (EntradaObs.Text == string.Empty)
                                                        EntradaObs.Text = Tarea.Presupuesto.Obs;
                                                EntradaComprobante.Text = Tarea.Presupuesto.ToString();
                                                return new Lfx.Types.SuccessOperationResult();
                                        } else {
                                                return new Lfx.Types.CancelOperationResult();
                                        }
                                }
                        } else {
                                Lfc.FormularioEdicion EditarPresupuesto = Lfc.Instanciador.InstanciarFormularioEdicion(Tarea.Presupuesto);
                                EditarPresupuesto.MdiParent = this.ParentForm.MdiParent;
                                EditarPresupuesto.Show();
                                return new Lfx.Types.SuccessOperationResult();
                        }
                }


                private Lfx.Types.OperationResult Facturar()
                {
                        Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("¿Desea guardar los cambios realizados y generar una factura a partir de esta tarea?", "Facturar");
                        if (Pregunta.ShowDialog() != DialogResult.OK)
                                return new Lfx.Types.CancelOperationResult();

                        if (EntradaEstado.ValueInt < 50)
                                EntradaEstado.ValueInt = 50;

                        Lfx.Types.OperationResult Res = this.Save();
                        if (Res.Success == false)
                                return Res;

                        var Tarea = this.Elemento as Lbl.Tareas.Tarea;
                        Lbl.Comprobantes.ComprobanteFacturable Factura;

                        var ConnFacturaNueva = Lfx.Workspace.Master.GetNewConnection("Convertir tarea en factura") as Lfx.Data.Connection;

                        if (Tarea.Factura != null && Tarea.Factura.Anulado == false) {
                                // Ya fue facturada... lo muestro
                                Factura = Tarea.Factura;
                        } else {
                                // No tiene comprobante, lo creo
                                Factura = new Lbl.Comprobantes.Factura(ConnFacturaNueva);

                                Factura.Crear();
                                Factura.Cliente = EntradaCliente.Elemento as Lbl.Personas.Persona;
                                Factura.Cliente.Connection = ConnFacturaNueva;
                                Factura.Tipo = Factura.Cliente.ObtenerTipoComprobante();
                                Factura.Tipo.Connection = ConnFacturaNueva;
                                Factura.Vendedor = EntradaEncargado.Elemento as Lbl.Personas.Persona;
                                Factura.Vendedor.Connection = ConnFacturaNueva;
                                Factura.Obs = EntradaTarea.TextDetail + " s/" + this.Elemento.ToString();
                                if (Tarea.Articulos.Count > 0) {
                                        Factura.Articulos.AddRange(Tarea.Articulos);
                                } else if (Tarea.Presupuesto != null && Tarea.Presupuesto.Articulos.Count > 0) {
                                        Factura.Articulos.AddRange(Tarea.Presupuesto.Articulos);
                                        Factura.Descuento = Tarea.Presupuesto.Descuento;
                                }

                                if (EntradaImportePresupuesto.ValueDecimal > 0) {
                                        Lbl.Comprobantes.DetalleArticulo Art = new Lbl.Comprobantes.DetalleArticulo(Factura);

                                        Art.Nombre = Tarea.Nombre;
                                        Art.ImporteUnitario = EntradaImportePresupuesto.ValueDecimal;
                                        Art.Cantidad = 1;

                                        Factura.Articulos.Add(Art);
                                }
                        }

                        Lfc.FormularioEdicion FormularioFactura = Lfc.Instanciador.InstanciarFormularioEdicion(Factura);
                        FormularioFactura.MdiParent = this.ParentForm.MdiParent;        
                        FormularioFactura.ControlDestino = EntradaComprobanteId;

                        FormularioFactura.Show();
                        return new Lfx.Types.SuccessOperationResult();
                }


                private void EntradaComprobanteId_TextChanged(object sender, System.EventArgs e)
                {
                        int ComprobanteId = Lfx.Types.Parsing.ParseInt(EntradaComprobanteId.Text);
                        if (ComprobanteId > 0) {
                                EntradaComprobante.Text = Lbl.Comprobantes.Comprobante.TipoYNumeroCompleto(this.Connection, ComprobanteId);
                                // Guardo el comprobante en la tarea (sólo si no tenía uno asociado)
                                using (System.Data.IDbTransaction Trans = this.Connection.BeginTransaction()) {
                                        qGen.Update Actual = new qGen.Update("tickets");
                                        Actual.ColumnValues.Add(new Lazaro.Orm.Data.ColumnValue("id_comprob", ComprobanteId));
                                        Actual.WhereClause = new qGen.Where();
                                        Actual.WhereClause.AddWithValue("id_comprob", 0);
                                        Actual.WhereClause.AddWithValue("id_ticket", this.Elemento.Id);
                                        this.Connection.ExecuteNonQuery(Actual);
                                        Trans.Commit();
                                }
                        } else {
                                EntradaComprobante.Text = "";
                        }
                }


                private void ListaHistorial_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
                {
                        switch (e.KeyCode) {
                                case Keys.Enter:
                                        if (ListaHistorialCliente.SelectedItems.Count > 0) {
                                                e.Handled = true;
                                                Lui.Forms.MessageBox.Show(ListaHistorialCliente.SelectedItems[0].SubItems[3].Text, ListaHistorialCliente.SelectedItems[0].SubItems[1].Text);
                                        }
                                        break;
                        }

                }


                private Lfx.Types.OperationResult EditarArticulos()
                {
                        Lbl.Tareas.Tarea Tarea = this.Elemento as Lbl.Tareas.Tarea;
                        Tareas.Articulos FormularioArticulos = new Tareas.Articulos();
                        FormularioArticulos.MdiParent = this.ParentForm.MdiParent;
                        FormularioArticulos.Tarea = Tarea;
                        FormularioArticulos.Show();

                        return new Lfx.Types.SuccessOperationResult();
                }


                public void MostrarPresupuesto()
                {
                        //decimal ValorArticulos = this.Connection.FieldDecimal("SELECT SUM(cantidad*precio) FROM tickets_articulos WHERE id_ticket=" + this.Elemento.Id.ToString());
                        //EntradaPresupuesto2.ValueDecimal = ValorArticulos * (1 - Descuento / 100);
                        var Tarea = this.Elemento as Lbl.Tareas.Tarea;
                        EntradaPresupuesto2.ValueDecimal = Tarea.Articulos.Total_Importe * (1m - Tarea.DescuentoArticulos / 100m);
                }


                private void ListaHistorial_SelectedIndexChanged(object sender, System.EventArgs e)
                {
                        if (ListaHistorialCliente.SelectedItems.Count > 0)
                                ListaHistorialCliente.SelectedItems[0].EnsureVisible();
                }


                public override Lazaro.Pres.Forms.FormActionCollection GetFormActions()
                {
                        Lazaro.Pres.Forms.FormActionCollection Res = base.GetFormActions();
                        Res.Add(new Lazaro.Pres.Forms.FormAction("Facturar", "F4", "facturar", 10, Lazaro.Pres.Forms.FormActionVisibility.Secondary));
                        Res.Add(new Lazaro.Pres.Forms.FormAction("Artículos", "F5", "articulos", 20, Lazaro.Pres.Forms.FormActionVisibility.Secondary));
                        Res.Add(new Lazaro.Pres.Forms.FormAction("Novedad", "F6", "novedad", 30, Lazaro.Pres.Forms.FormActionVisibility.Secondary));
                        Res.Add(new Lazaro.Pres.Forms.FormAction("Presupuesto", "F7", "presupuesto", 40, Lazaro.Pres.Forms.FormActionVisibility.Secondary));
                        return Res;
                }


                public override Lfx.Types.OperationResult PerformFormAction(string name)
                {
                        switch (name) {
                                case "facturar":
                                        return Facturar();
                                case "articulos":
                                        return EditarArticulos();
                                case "novedad":
                                        return CargarNovedad();
                                case "presupuesto":
                                        return AsociarPresupuesto();
                                default:
                                        return base.PerformFormAction(name);
                        }
                }

                private void Editar_Enter(object sender, EventArgs e)
                {
                        this.MostrarPresupuesto();
                }
        }
}