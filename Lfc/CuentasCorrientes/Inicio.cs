using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.CuentasCorrientes
{
        public partial class Inicio : Lfc.FormularioCuenta
        {
                private Lbl.Personas.Grupo Grupo = null;
                private Lbl.Entidades.Localidad Localidad = null;
                private int Tipo = 0;
                private decimal Transporte = 0;

                public Inicio()
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.CuentasCorrientes.CuentaCorriente), Lbl.Sys.Permisos.Operaciones.Listar) == false) {
                                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                                this.Close();
                                return;
                        }

                        InitializeComponent();

                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.CuentasCorrientes.Movimiento),
                                TableName = "ctacte",
                                KeyColumn = new Lazaro.Pres.Field("ctacte.id_movim", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                Columns = new Lazaro.Pres.FieldCollection() {
                                        new Lazaro.Pres.Field("personas.nombre_visible", "Persona", 320, new Lazaro.Orm.Data.Relation("id_cliente", "personas", "id_persona")),
                                        new Lazaro.Pres.Field("ctacte.id_concepto", "Concepto", Lfx.Data.InputFieldTypes.Relation, 0),
                                        new Lazaro.Pres.Field("ctacte.concepto", "Concepto", Lfx.Data.InputFieldTypes.Text, 320),
                                        new Lazaro.Pres.Field("ctacte.fecha", "Fecha.", Lfx.Data.InputFieldTypes.Date, 100),
                                        new Lazaro.Pres.Field("ctacte.importe", "Importe", Lfx.Data.InputFieldTypes.Currency, 96),
                                        new Lazaro.Pres.Field("ctacte.saldo", "Saldo", Lfx.Data.InputFieldTypes.Currency, 96),
                                        new Lazaro.Pres.Field("ctacte.obs", "Obs.", Lfx.Data.InputFieldTypes.Text, 320),
                                        new Lazaro.Pres.Field("ctacte.comprob", "Comprobante", Lfx.Data.InputFieldTypes.Text, 160),
                                        new Lazaro.Pres.Field("ctacte.id_recibo", "Recibo", Lfx.Data.InputFieldTypes.Relation, 0)
                                },
                                Filters = new Lazaro.Pres.Filters.FilterCollection() {
                                        new Lazaro.Pres.Filters.RelationFilter("Cliente", new Lazaro.Orm.Data.Relation("ctacte.id_cliente", "personas", "id_persona", "nombre_visible")),
                                        new Lazaro.Pres.Filters.SetFilter("Tipo", "personas.tipo", new string[] { "Todos|0", "Clientes|1", "Proveedores|2" }, "0"),
                                        new Lazaro.Pres.Filters.RelationFilter("Grupo", new Lazaro.Orm.Data.Relation("personas.id_grupo", "personas_grupos", "id_grupo")),
                                        new Lazaro.Pres.Filters.RelationFilter("Localidad", new Lazaro.Orm.Data.Relation("personas.id_ciudad", "ciudades", "id_ciudad")),
                                        new Lazaro.Pres.Filters.DateRangeFilter("Fecha", "ctacte.fecha", new Lfx.Types.DateRange("*"))
                                },
                                OrderBy = "personas.nombre_visible"
                        };

                        this.Fechas = new Lfx.Types.DateRange("*");

                        this.HabilitarFiltrar = true;

                        this.BotonAjuste.Visible = Lbl.Sys.Config.Actual.UsuarioConectado.TieneAccesoGlobal();
                }


                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
                {
                        decimal Importe = row.Fields["ctacte.importe"].ValueDecimal;
                        decimal Saldo = row.Fields["ctacte.saldo"].ValueDecimal;

                        if (this.Cliente == null) {
                                if (Saldo < 0) {
                                        this.Contadores[2].AddValue(-Saldo);          // Pasivos
                                        if (item.SubItems.ContainsKey("ctacte.saldo"))
                                                item.SubItems["ctacte.saldo"].ForeColor = Color.Red;
                                        item.UseItemStyleForSubItems = false;
                                } else if (Importe > 0) {
                                        this.Contadores[1].AddValue(Saldo);           // Crédito
                                }
                        } else {
                                if (Importe < 0) {
                                        this.Contadores[2].AddValue(-Importe);        // Egresos
                                        item.SubItems["ctacte.importe"].ForeColor = Color.Red;
                                        item.UseItemStyleForSubItems = false;
                                } else if (Importe > 0) {
                                        this.Contadores[1].AddValue(Importe);         // Ingresos
                                }
                        }

                        base.OnItemAdded(item, row);
                }


                protected override void OnBeginRefreshList()
                {
                        this.CustomFilters.Clear();

                        // TODO: si estoy usando rago de fechas, obtener el transporte
                        Transporte = 0;

                        if (this.Cliente == null) {
                                // Es para todas los clientes
                                this.Definicion.GroupBy = new Lazaro.Pres.Field("ctacte.id_cliente", "Cliente");
                                this.Definicion.OrderBy = "personas.nombre_visible";
                                this.Text = "Listado de cuentas corrientes";

                                this.Definicion.Columns["nombre_visible"].Visible = true;
                                this.Definicion.Columns["fecha"].Visible = false;
                                this.Definicion.Columns["concepto"].Visible = false;
                                this.Definicion.Columns["importe"].Visible = false;
                                this.Definicion.Columns["saldo"].Visible = true;
                                this.Definicion.Columns["obs"].Visible = false;
                                this.Definicion.Columns["comprob"].Visible = false;

                                this.Definicion.Columns["saldo"].Name = "SUM(ctacte.importe) AS saldo";
                                this.Definicion.Having = new qGen.Where("saldo", qGen.ComparisonOperators.NotEqual, 0);

                                this.SetupListviewColumns();

                                this.Contadores[1].Etiqueta = "Créditos";
                                this.Contadores[2].Etiqueta = "Pasivos";

                                if (Tipo != 0)
                                        this.CustomFilters.AddWithValue("(personas.tipo&"+ this.Tipo.ToString() + ")=" + this.Tipo.ToString());

                                if (Grupo != null)
                                        this.CustomFilters.AddWithValue("personas.id_grupo", Grupo.Id);
                                
                                if (Localidad != null)
                                        this.CustomFilters.AddWithValue("personas.id_ciudad", Localidad.Id);
                        } else {
                                // Es un cliente en particular
                                this.CustomFilters.AddWithValue("ctacte.id_cliente", this.Cliente.Id);
                                this.Definicion.GroupBy = null;
                                this.Definicion.OrderBy = "ctacte.id_movim DESC";
                                this.Text = "Cuenta corriente de " + this.Cliente.ToString();

                                this.Definicion.Columns["nombre_visible"].Visible = false;
                                this.Definicion.Columns["fecha"].Visible = true;
                                this.Definicion.Columns["concepto"].Visible = true;
                                this.Definicion.Columns["importe"].Visible = true;
                                this.Definicion.Columns["saldo"].Visible = true;
                                this.Definicion.Columns["obs"].Visible = true;
                                this.Definicion.Columns["comprob"].Visible = true;

                                this.Definicion.Columns["saldo"].Name = "ctacte.saldo";
                                this.Definicion.Having = null;

                                this.SetupListviewColumns();

                                this.Contadores[1].Etiqueta = "Créditos";
                                this.Contadores[2].Etiqueta = "Débitos";
                        }

                        if (Fechas.HasRange)
                                this.CustomFilters.AddWithValue("ctacte.fecha", Fechas.From, Fechas.To);

                        base.OnBeginRefreshList();
                }


                protected override void OnEndRefreshList()
                {
                        this.Contadores[0].AddValue(Transporte);
                        this.Contadores[3].AddValue(Transporte + this.Contadores[1].Total - this.Contadores[2].Total);

                        base.OnEndRefreshList();
                }


                protected override Lfx.Types.OperationResult OnEdit(int itemId)
                {
                        Lfx.Data.Row Movim = Lfx.Workspace.Master.Tables["ctacte"].FastRows[itemId];
                        if (this.Cliente == null) {
                                this.Cliente = new Lbl.Personas.Persona(this.Connection, System.Convert.ToInt32(Movim["id_cliente"]));
                                ((Lazaro.Pres.Filters.RelationFilter)(this.Definicion.Filters["ctacte.id_cliente"])).Value = this.Cliente;
                                RefreshList();
                        } else {
                                if (Movim != null) {
                                        if (Movim["id_recibo"] != null) {
                                                int IdRecibo = System.Convert.ToInt32(Movim["id_recibo"]);
                                                Lfx.Workspace.Master.RunTime.Execute("EDITAR Lbl.Comprobantes.Recibo " + IdRecibo.ToString());
                                        }
                                        if (Movim["id_comprob"] != null) {
                                                int IdFactura = System.Convert.ToInt32(Movim["id_comprob"]);
                                                Lfx.Workspace.Master.RunTime.Execute("EDITAR Lbl.Comprobantes.ComprobanteConArticulos " + IdFactura.ToString());
                                        }
                                }
                        }

                        return new Lfx.Types.SuccessOperationResult();
                }


                public override void OnFiltersChanged(Lazaro.Pres.Filters.FilterCollection filters)
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.CuentasCorrientes.CuentaCorriente), Lbl.Sys.Permisos.Operaciones.Ver)) {
                                this.Cliente = filters["ctacte.id_cliente"].Value as Lbl.Personas.Persona;        
                        }
                        Tipo = System.Convert.ToInt32(((Lazaro.Pres.Filters.SetFilter)(filters["personas.tipo"])).Value);
                        Grupo = ((Lazaro.Pres.Filters.RelationFilter)(filters["personas.id_grupo"])).Elemento as Lbl.Personas.Grupo;
                        Localidad = ((Lazaro.Pres.Filters.RelationFilter)(filters["personas.id_ciudad"])).Elemento as Lbl.Entidades.Localidad;
                        Fechas = ((Lazaro.Pres.Filters.DateRangeFilter)(filters["ctacte.fecha"])).DateRange;

                        base.OnFiltersChanged(filters);
                }


                private void BotonNotaCred_Click(object sender, System.EventArgs e)
                {
                        if (this.Cliente != null) {
                                Lbl.Comprobantes.NotaDeCredito Nota = new Lbl.Comprobantes.NotaDeCredito(this.Connection);
                                Nota.Crear();
                                Nota.Cliente = this.Cliente;
                                Lfc.FormularioEdicion FormularioNota = Lfc.Instanciador.InstanciarFormularioEdicion(Nota);
                                FormularioNota.Connection = this.Connection;
                                FormularioNota.MdiParent = this.MdiParent;
                                FormularioNota.Show();
                        } else {
                                Lui.Forms.MessageBox.Show("Debe seleccionar una persona. Utilice la opción Filtros (tecla <F2>).", "Error");
                        }
                }


                private void BotonNotaDeb_Click(object sender, System.EventArgs e)
                {
                        if (this.Cliente != null) {
                                Lbl.Comprobantes.NotaDeDebito Nota = new Lbl.Comprobantes.NotaDeDebito(this.Connection);
                                Nota.Crear();
                                Nota.Cliente = this.Cliente;
                                Lfc.FormularioEdicion FormularioNota = Lfc.Instanciador.InstanciarFormularioEdicion(Nota);
                                FormularioNota.Connection = this.Connection;
                                FormularioNota.MdiParent = this.MdiParent;
                                FormularioNota.Show();
                        } else {
                                Lui.Forms.MessageBox.Show("Debe seleccionar una persona. Utilice la opción Filtros (tecla <F2>).", "Error");
                        }
                }


                protected override void OnKeyDown(KeyEventArgs e)
                {
                        if (e.Shift && e.Control) {
                                switch (e.KeyCode) {
                                        case Keys.F7:
                                                if (this.Cliente != null) {
                                                        // Recalculo la cuenta del cliente
                                                        Lui.Forms.MessageBox.Show("Se va a recalcular la cuenta corriente", "Aviso");
                                                        using (IDbTransaction Trans = this.Cliente.Connection.BeginTransaction()) {
                                                                this.Cliente.CuentaCorriente.Recalcular();
                                                                Trans.Commit();
                                                        }
                                                        this.RefreshList();
                                                }
                                                e.Handled = true;

                                                break;
                                }
                        }

                        if (e.Handled == false)
                                base.OnKeyDown(e);
                }


                private void BotonAjuste_Click(object sender, System.EventArgs e)
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.CuentasCorrientes.CuentaCorriente), Lbl.Sys.Permisos.Operaciones.Mover)) {
                                Ajuste FormAjuste = new Ajuste();
                                FormAjuste.Owner = this;
                                FormAjuste.SaldoActual = this.Contadores[3].Total;
                                if (FormAjuste.ShowDialog() == DialogResult.OK) {
                                        decimal Importe = FormAjuste.EntradaImporte.ValueDecimal;
                                        if (Importe == 0) {
                                                Lui.Forms.MessageBox.Show("El Importe debe ser mayor o menor que cero.", "Error");
                                        } else {
                                                int ClienteId = 0;
                                                if (this.Cliente != null)
                                                        ClienteId = this.Cliente.Id;
                                                else if (Listado.SelectedItems.Count == 1)
                                                        ClienteId = Lfx.Types.Parsing.ParseInt(Listado.SelectedItems[0].Text);
                                                else
                                                        Lui.Forms.MessageBox.Show("Debe seleccionar un cliente", "Ajuste");

                                                if (ClienteId > 0) {
                                                        Lbl.CuentasCorrientes.CuentaCorriente CtaCte = new Lbl.CuentasCorrientes.CuentaCorriente(new Lbl.Personas.Persona(this.Connection, ClienteId));
                                                        using (IDbTransaction Trans = CtaCte.Connection.BeginTransaction()) {
                                                                CtaCte.Movimiento(false,
                                                                        FormAjuste.EntradaConcepto.Elemento as Lbl.Cajas.Concepto,
                                                                        FormAjuste.EntradaConcepto.TextDetail,
                                                                        Importe,
                                                                        FormAjuste.EntradaObs.Text,
                                                                        null,
                                                                        null,
                                                                        null);
                                                                Trans.Commit();
                                                        }
                                                        this.RefreshList();
                                                }
                                        }
                                }
                        }
                }
        }
}