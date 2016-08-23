using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Cajas
{
        public partial class Movimientos : Lfc.FormularioCuenta
        {
                private string Parametros = null;
                private Lbl.Personas.Persona Usuario = null;
                private Lbl.Cajas.Caja m_Caja = null;
                private Lbl.Cajas.Concepto Concepto { get; set; }
                private int TipoConcepto { get; set; }
                private int Direccion { get; set; }
                private decimal Transporte = 0;

                public Movimientos()
                {
                        InitializeComponent();

                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Cajas.Movimiento),
                                TableName = "cajas_movim",
                                KeyColumn = new Lazaro.Pres.Field("cajas_movim.id_movim", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                Joins = new qGen.JoinCollection() { 
                                        new qGen.Join("personas", "cajas_movim.id_persona=personas.id_persona"),
                                        new qGen.Join("cajas", "cajas_movim.id_caja=cajas.id_caja"),
                                        new qGen.Join("conceptos", "cajas_movim.id_concepto=conceptos.id_concepto")
                                },
                                Columns = new Lazaro.Pres.FieldCollection() {
                                        new Lazaro.Pres.Field("cajas.nombre", "Caja", Lfx.Data.InputFieldTypes.Text, 120),
                                        new Lazaro.Pres.Field("cajas_movim.id_concepto", "Concepto", Lfx.Data.InputFieldTypes.Relation, 0),
                                        new Lazaro.Pres.Field("cajas_movim.concepto", "Concepto", Lfx.Data.InputFieldTypes.Text, 320),
                                        new Lazaro.Pres.Field("cajas_movim.fecha", "Fecha", Lfx.Data.InputFieldTypes.Date, 100),
                                        new Lazaro.Pres.Field("cajas_movim.importe", "Importe", Lfx.Data.InputFieldTypes.Currency, 96),
                                        new Lazaro.Pres.Field("cajas_movim.saldo", "Saldo", Lfx.Data.InputFieldTypes.Currency, 96),
                                        new Lazaro.Pres.Field("personas.nombre_visible", "Persona", Lfx.Data.InputFieldTypes.Text, 200),
                                        new Lazaro.Pres.Field("cajas_movim.id_comprob", "Factura", Lfx.Data.InputFieldTypes.Relation, 0),
                                        new Lazaro.Pres.Field("cajas_movim.id_recibo", "Recibo", Lfx.Data.InputFieldTypes.Relation, 0),
                                        new Lazaro.Pres.Field("cajas_movim.obs", "Obs.", Lfx.Data.InputFieldTypes.Text, 240),
                                        new Lazaro.Pres.Field("cajas_movim.comprob", "Comprobante", Lfx.Data.InputFieldTypes.Text, 160)
                                },

                                Filters = new Lazaro.Pres.Filters.FilterCollection() {
                                        new Lazaro.Pres.Filters.RelationFilter("Caja", new Lfx.Data.Relation("cajas_movim.id_caja", "cajas", "cajas.id_caja")),
                                        new Lazaro.Pres.Filters.RelationFilter("Persona", new Lfx.Data.Relation("cajas_movim.id_cliente", "personas", "personas.id_persona", "nombre_visible")),
                                        new Lazaro.Pres.Filters.RelationFilter("Usuario", new Lfx.Data.Relation("cajas_movim.id_persona", "personas", "personas.id_persona", "nombre_visible")),
                                        new Lazaro.Pres.Filters.RelationFilter("Concepto", new Lfx.Data.Relation("cajas_movim.id_concepto", "conceptos", "conceptos.id_concepto")),
                                        new Lazaro.Pres.Filters.SetFilter("Tipo", "conceptos.grupo", new string[] { 
                                                "Todos|0",
                                                "Gastos fijos|1",
                                                "Gastos variables|2",
                                                "Pérdida|3",
                                                "Reinversión|10",
                                                "Publicidad|11",
                                                "Movimientos y Ajustes|50",
                                                "Costo Materiales|60",
                                                "Costo Capital|70",
                                                "Sueldos y Salarios|80",
                                                "Cobros|100"
                                        }, "0"),
                                        new Lazaro.Pres.Filters.SetFilter("Visa", "conceptos.es", new string[] { "Entrada y Salida|0", "Entrada|1", "Salida|2" }, "0"),
                                        new Lazaro.Pres.Filters.DateRangeFilter("Fecha", "cajas_movim.fecha", this.Fechas)
                                },

                                OrderBy = "cajas_movim.id_movim DESC"
                        };

                        this.Definicion.Columns["nombre"].Visible = false;
                        this.Definicion.Columns["nombre"].Printable = false;
                        this.Definicion.Columns["cajas_movim.comprob"].Printable = false;

                        this.Definicion.Columns["cajas_movim.concepto"].TotalFunction = Lazaro.Pres.Spreadsheet.QuickFunctions.TotalName;
                        this.Definicion.Columns["cajas_movim.importe"].TotalFunction = Lazaro.Pres.Spreadsheet.QuickFunctions.Sum;

                        this.Fechas = new Lfx.Types.DateRange("dia-0");

                        this.HabilitarFiltrar = true;
                }


                public Movimientos(string comando)
                        : this()
                {
                        this.Parametros = comando;
                }


                protected override void OnLoad(EventArgs e)
                {
                        base.OnLoad(e);

                        if (this.Connection != null) {
                                if (Parametros == "efectivo") {
                                        this.Caja = Lbl.Sys.Config.Empresa.SucursalActual.CajaDiaria;
                                } else {
                                        int NumeroCaja = Lfx.Types.Parsing.ParseInt(Parametros);
                                        if (NumeroCaja > 0)
                                                this.Caja = new Lbl.Cajas.Caja(this.Connection, NumeroCaja);
                                        else
                                                this.Caja = new Lbl.Cajas.Caja(this.Connection, 999);
                                }

                                if (this.Caja != null) {
                                        // Busco un rango de fechas en el cual haya movimientos
                                        string[] FechasAProbar = new string[] { "dia-0", "semana-0", "mes-0", "mes-1", "mes-2", "mes-3", "mes-4" };
                                        foreach (string FechaAProbar in FechasAProbar) {
                                                Lfx.Types.DateRange Rango = new Lfx.Types.DateRange(FechaAProbar);
                                                qGen.Select SelMovs = new qGen.Select("cajas_movim");
                                                SelMovs.Fields = "COUNT(id_movim)";
                                                SelMovs.WhereClause = new qGen.Where("id_caja", this.Caja.Id);
                                                SelMovs.WhereClause.AddWithValue("fecha", Rango.From, Rango.To);
                                                int Movs = this.Connection.FieldInt(SelMovs);

                                                if (Movs > 0) {
                                                        this.Fechas = new Lfx.Types.DateRange(Rango.From, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59));
                                                        break;
                                                }
                                        }
                                }
                        }
                }


                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
                {
                        decimal Importe = row.Fields["cajas_movim.importe"].ValueDecimal;
                        if (Importe < 0) {
                                this.Contadores[2].AddValue(-Importe);           // Egresos
                                item.SubItems["cajas_movim.importe"].ForeColor = Color.Red;
                                item.UseItemStyleForSubItems = false;
                        } else if (Importe > 0) {
                                this.Contadores[1].AddValue(Importe);           // Ingresos
                        }

                        base.OnItemAdded(item, row);
                }


                public Lbl.Cajas.Caja Caja
                {
                        get
                        {
                                return m_Caja;
                        }
                        set
                        {
                                m_Caja = value;
                                this.Definicion.Filters["cajas_movim.id_caja"].Value = value;
                                if (m_Caja != null) {
                                        m_Caja.Connection = this.Connection;
                                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(m_Caja, Lbl.Sys.Permisos.Operaciones.Ver) == false) {
                                                throw new Lfx.Types.Exceptions.AccessDeniedException("No tiene permiso para ver la caja solicitada");
                                        }
                                }
                        }
                }

                protected override void OnBeginRefreshList()
                {
                        this.CustomFilters.Clear();

                        System.DateTime FechaFrom = Fechas.HasRange ? Fechas.From : new System.DateTime(1900, 1, 1);
                        if (this.Caja == null) {
                                this.Text = "Caja";
                                // Es para todas las cajas
                                Transporte = 0;

                                if (this.Cliente == null && Concepto == null && TipoConcepto == 0) {
                                        // Calculo el transporte combinado de todas las cajas
                                        DataTable Cajas = this.Connection.Select("SELECT id_caja FROM cajas");
                                        foreach (System.Data.DataRow Caja in Cajas.Rows) {
                                                Transporte += Math.Round(this.Connection.FieldDecimal("SELECT saldo FROM " + this.Definicion.TableName + " WHERE  id_caja=" + Caja["id_caja"].ToString() + " AND fecha<'" + Lfx.Types.Formatting.FormatDateSql(FechaFrom).ToString() + " 00:00:00' ORDER BY id_movim DESC"), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                                        }
                                }
                        } else {
                                this.Text = Caja.ToString();
                                // Calculo el transporte de una cuenta
                                Transporte = Math.Round(this.Connection.FieldDecimal("SELECT saldo FROM " + this.Definicion.TableName + " WHERE  id_caja=" + this.Caja.Id.ToString() + " AND fecha<'" + Lfx.Types.Formatting.FormatDateSql(FechaFrom) + " 00:00:00' ORDER BY id_movim DESC LIMIT 1"), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        }

                        if (Direccion == 1)
                                this.CustomFilters.AddWithValue("cajas_movim.importe", qGen.ComparisonOperators.GreaterThan, 0);
                        else if (Direccion == 2)
                                this.CustomFilters.AddWithValue("cajas_movim.importe", qGen.ComparisonOperators.LessThan, 0);

                        if (this.Caja != null) {
                                this.CustomFilters.AddWithValue("cajas_movim.id_caja", this.Caja.Id);
                                this.GroupingColumnName = null;
                                this.Definicion.Columns["cajas_movim.saldo"].Visible = true;
                        } else {
                                this.GroupingColumnName = "nombre";
                                this.Definicion.Columns["cajas_movim.saldo"].Visible = false;
                        }

                        if (this.Cliente != null)
                                this.CustomFilters.AddWithValue("cajas_movim.id_cliente", this.Cliente.Id);

                        if (this.Usuario != null)
                                this.CustomFilters.AddWithValue("cajas_movim.id_persona", this.Usuario.Id);

                        if (Concepto != null)
                                this.CustomFilters.AddWithValue("cajas_movim.id_concepto", Concepto.Id);

                        if (TipoConcepto > 0)
                                this.CustomFilters.AddWithValue("conceptos.grupo", TipoConcepto);

                        if (Fechas.HasRange)
                                this.CustomFilters.AddWithValue("cajas_movim.fecha", Fechas.From, Fechas.To);

                        base.OnBeginRefreshList();
                }


                protected override void OnEndRefreshList()
                {
                        this.Contadores[0].AddValue(Transporte);
                        this.Contadores[3].AddValue(Transporte + this.Contadores[1].Total - this.Contadores[2].Total);

                        base.OnEndRefreshList();
                }


                public override void OnFiltersChanged(Lazaro.Pres.Filters.FilterCollection filters)
                {
                        this.Caja = this.Definicion.Filters["cajas_movim.id_caja"].Value as Lbl.Cajas.Caja;
                        this.Cliente = this.Definicion.Filters["cajas_movim.id_cliente"].Value as Lbl.Personas.Persona;
                        this.Usuario = this.Definicion.Filters["cajas_movim.id_persona"].Value as Lbl.Personas.Persona;
                        this.Concepto = this.Definicion.Filters["cajas_movim.id_concepto"].Value as Lbl.Cajas.Concepto;
                        TipoConcepto = Lfx.Types.Parsing.ParseInt(this.Definicion.Filters["conceptos.grupo"].Value.ToString());
                        Direccion = Lfx.Types.Parsing.ParseInt(this.Definicion.Filters["conceptos.es"].Value.ToString());
                        this.Fechas = this.Definicion.Filters["cajas_movim.fecha"].Value as Lfx.Types.DateRange;

                        BotonArqueo.Visible = !(this.Caja == null || this.Cliente != null || Concepto != null || Direccion != 0 || this.Fechas.To < System.DateTime.Now);

                        base.OnFiltersChanged(filters);
                }


                private void BotonIngreso_Click(object sender, System.EventArgs e)
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(this.Caja, Lbl.Sys.Permisos.Operaciones.Mover)) {
                                Cajas.IngresoEgreso FormularioIngreso = new Cajas.IngresoEgreso();
                                FormularioIngreso.Caja = this.Caja;
                                if (this.Caja != null)
                                        FormularioIngreso.SaldoActual = this.Caja.ObtenerSaldo(false);
                                FormularioIngreso.Ingreso = true;
                                if (FormularioIngreso.ShowDialog() == DialogResult.OK)
                                        this.RefreshList();
                        }
                }


                private void BotonEgreso_Click(object sender, System.EventArgs e)
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(this.Caja, Lbl.Sys.Permisos.Operaciones.Mover)) {
                                Cajas.IngresoEgreso FormularioEgreso = new Cajas.IngresoEgreso();
                                FormularioEgreso.Caja = this.Caja;
                                if (this.Caja != null)
                                        FormularioEgreso.SaldoActual = this.Caja.ObtenerSaldo(false);
                                FormularioEgreso.Ingreso = false;
                                if (FormularioEgreso.ShowDialog() == DialogResult.OK)
                                        this.RefreshList();
                        }
                }


                private void BotonMovimiento_Click(object sender, System.EventArgs e)
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(this.Caja, Lbl.Sys.Permisos.Operaciones.Mover)) {
                                Cajas.Movimiento FormularioMovimiento = new Cajas.Movimiento();
                                FormularioMovimiento.EntradaOrigen.Elemento = this.Caja;
                                FormularioMovimiento.EntradaConcepto.ValueInt = 30000;
                                if (FormularioMovimiento.ShowDialog() == DialogResult.OK)
                                        this.RefreshList();
                        }
                }


                private void BotonArqueo_Click(object sender, System.EventArgs e)
                {
                        if (this.Fechas.To < System.DateTime.Now) {
                                Lfx.Workspace.Master.RunTime.Toast("La vista actual muestra el estado de la caja en una fecha pasada. No puede asentar un arqueo con una fecha pasada. Para asentar un arqueo cambie el filtro de fechas para ver el estado actual de la caja.", "Arqueo de caja");
                                return;
                        } else if (this.Caja == null) {
                                Lfx.Workspace.Master.RunTime.Toast("La vista actual muestra los movimientos de varias cajas combinados. No se puede asentar un arqueo en este estado.", "Arqueo de caja");
                                return;
                        } else if (this.Cliente != null || this.Concepto != null || this.Direccion != 0) {
                                Lfx.Workspace.Master.RunTime.Toast("La vista actual no muestra todos los movimientos de la caja ya que existe un filtro activo (filtro por Cliente, Concepto, etc.). Quite todos los filtros para poder asentar un arqueo.", "Arqueo de caja");
                                return;
                        }

                        Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("¿Confirma que el saldo de la caja de " + Lbl.Sys.Config.Moneda.Simbolo + " " + Lfx.Types.Formatting.FormatCurrency(this.Contadores[3].Total) + " corresponde con lo que se encuentra físicamente en la caja? Si confirma que el saldo de la cuenta es el indicado se asentará una marca de 'Arqueo', para su propio control.", "El saldo de la caja es de " + Lbl.Sys.Config.Moneda.Simbolo + "  " + Lfx.Types.Formatting.FormatCurrency(this.Contadores[3].Total));
                        Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                        if (Pregunta.ShowDialog() == DialogResult.OK) {
                                using (IDbTransaction Trans = this.Caja.Connection.BeginTransaction()) {
                                        this.Caja.Arqueo();
                                        Trans.Commit();
                                }
                                this.RefreshList();
                        } else {
                                Lui.Forms.MessageBox.Show("No se asentó un arqueo. Verifique el saldo de la cuenta y si es necesario realice un ajuste.", "Arqueo de caja");
                        }
                }
                

                protected override Lfx.Types.OperationResult OnEdit(int itemId)
                {
                        Lfx.Data.Row Movim = this.Connection.Tables["cajas_movim"].FastRows[itemId];
                        if (Movim != null) {
                                if (Movim.Fields["id_recibo"].Value != null) {
                                        int IdRecibo = Movim.Fields["id_recibo"].ValueInt;
                                        Type TipoRecibo = typeof(Lbl.Comprobantes.Recibo);
                                        Lfx.Data.Connection NuevaDb = Lfx.Workspace.Master.GetNewConnection("Editar " + TipoRecibo.ToString() + " " + IdRecibo);
                                        Lbl.IElementoDeDatos Elem = Lbl.Instanciador.Instanciar(TipoRecibo, NuevaDb, IdRecibo);
                                        Lfc.FormularioEdicion FormNuevo = Lfc.Instanciador.InstanciarFormularioEdicion(Elem);
                                        FormNuevo.DisposeConnection = true;
                                        FormNuevo.MdiParent = this.MdiParent;
                                        FormNuevo.Show();

                                        return new Lfx.Types.SuccessOperationResult();
                                } else if (Movim.Fields["id_comprob"].Value != null) {
                                        int IdComprob = Movim.Fields["id_comprob"].ValueInt;
                                        Type TipoRecibo = typeof(Lbl.Comprobantes.ComprobanteConArticulos);
                                        Lfx.Data.Connection NuevaDb = Lfx.Workspace.Master.GetNewConnection("Editar " + TipoRecibo.ToString() + " " + IdComprob);
                                        Lbl.IElementoDeDatos Elem = Lbl.Instanciador.Instanciar(TipoRecibo, NuevaDb, IdComprob);
                                        Lfc.FormularioEdicion FormNuevo = Lfc.Instanciador.InstanciarFormularioEdicion(Elem);
                                        FormNuevo.DisposeConnection = true;
                                        FormNuevo.MdiParent = this.MdiParent;
                                        FormNuevo.Show();

                                        return new Lfx.Types.SuccessOperationResult();
                                } else {
                                        return new Lfx.Types.CancelOperationResult();
                                }
                        } else {
                                return new Lfx.Types.CancelOperationResult();
                        }
                }


                protected override void OnKeyDown(KeyEventArgs e)
                {
                        if (e.Shift && e.Control) {
                                switch (e.KeyCode) {
                                        case Keys.F7:
                                                if (this.Caja != null) {
                                                        // Recalculo la cuenta del cliente
                                                        Lui.Forms.MessageBox.Show("Se va a recalcular el transporte de la Caja", "Aviso");
                                                        using (IDbTransaction Trans = this.Caja.Connection.BeginTransaction()) {
                                                                this.Caja.Recalcular();
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
        }
}