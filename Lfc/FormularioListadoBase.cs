using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc
{
        public partial class FormularioListadoBase : Lui.Forms.ChildForm
        {
                // La definición del listado
                public Lazaro.Pres.Listings.Listing Definicion { get; set; }
                public List<Contador> Contadores = new List<Contador>();

                public bool HabilitarBorrar { get; set; }

                // Miembros privados
                protected string m_SearchText = string.Empty;

                protected Dictionary<string, int> FormFieldToSubItem = new Dictionary<string, int>();
                protected Dictionary<string, int> SubItemToFormField = new Dictionary<string, int>();
                protected int m_Limit = 2000;
                protected qGen.Where m_CustomFilters = new qGen.Where();
                protected qGen.Where m_FixedFilters = new qGen.Where();

                // Grouping
                protected string m_GroupingColumnName = null;
                protected string LastGroupingValue = null;
                protected ListViewGroup LastGroup = null;

                // Labels
                protected List<int> m_Labels = null;
                protected string m_LabelField = null;

                private Dictionary<int, ListViewItem> ItemListado = new Dictionary<int, ListViewItem>();
                private Lui.Forms.ListViewColumnSorter Sorter = new Lui.Forms.ListViewColumnSorter();

                private Lbl.Atributos.Nomenclatura m_AtributoNomenclatura = null;
                private Lbl.Atributos.Datos m_AtributoDatos = null;

                public FormularioListadoBase()
                {
                        //this.DisplayStyle = Lazaro.Pres.DisplayStyles.Template.Current.White;
                        InitializeComponent();

                        this.StockImage = "listado";

                        RefreshTimer.Start();
                }


                public Type ElementoTipo
                {
                        get
                        {
                                return this.Definicion.ElementoTipo;
                        }
                }


                public Lbl.Atributos.Nomenclatura AtributoNomenclatura
                {
                        get
                        {
                                if (m_AtributoNomenclatura == null && this.ElementoTipo != null)
                                        m_AtributoNomenclatura = this.ElementoTipo.GetAttribute<Lbl.Atributos.Nomenclatura>();
                                return m_AtributoNomenclatura;
                        }
                }


                public Lbl.Atributos.Datos AtributoDatos
                {
                        get
                        {
                                if (m_AtributoDatos == null && this.ElementoTipo != null)
                                        m_AtributoDatos = this.ElementoTipo.GetAttribute<Lbl.Atributos.Datos>();
                                return m_AtributoDatos;
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public bool HabilitarFiltrar
                {
                        get
                        {
                                return BotonFiltrar.Visible;
                        }
                        set
                        {
                                BotonFiltrar.Visible = value;
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public bool HabilitarImprimir
                {
                        get
                        {
                                return BotonImprimir.Visible;
                        }
                        set
                        {
                                BotonImprimir.Visible = value;
                        }
                }



                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public List<int> Labels
                {
                        get
                        {
                                return m_Labels;
                        }
                        set
                        {
                                m_Labels = value;
                        }
                }


                public string LabelField
                {
                        get
                        {
                                return m_LabelField;
                        }
                        set
                        {
                                m_LabelField = value;
                        }
                }



                /// <summary>
                /// Filtros variables, que se cambian mientras el usuario está viendo el listado (por ejemplo con la tecla F2)
                /// </summary>
                public qGen.Where CustomFilters
                {
                        get
                        {
                                return m_CustomFilters;
                        }
                        set
                        {
                                m_CustomFilters = value;
                        }
                }

                
                /// <summary>
                /// Filtros fijos, que el usuario no puede cambiar.
                /// </summary>
                public qGen.Where FixedFilters
                {
                        get
                        {
                                return m_FixedFilters;
                        }
                        set
                        {
                                m_FixedFilters = value;
                        }
                }


                public int Limit
                {
                        get
                        {
                                return m_Limit;
                        }
                        set
                        {
                                m_Limit = value;
                        }
                }

                public string GroupingColumnName
                {
                        get
                        {
                                return m_GroupingColumnName;
                        }
                        set
                        {
                                if (value == null || value.Length == 0)
                                        m_GroupingColumnName = null;
                                else
                                        m_GroupingColumnName = value;
                        }
                }

                public virtual string SearchText
                {
                        get
                        {
                                return m_SearchText;
                        }
                        set
                        {
                                m_SearchText = value;
                        }
                }


                public virtual void Search(string text)
                {
                        if (this.SearchText != text) {
                                this.SearchText = text;
                                this.RefreshList();
                        }
                }


                public virtual Lfx.Types.OperationResult OnPrint(bool selectPrinter)
                {
                        if (Listado.Items.Count == 0)
                                return new Lfx.Types.FailureOperationResult("El listado está vacío");

                        Lazaro.Pres.Spreadsheet.Workbook Workbook = this.ToWorkbook();
                        Lazaro.Base.Util.Impresion.ImpresorListado Impresor = new Lazaro.Base.Util.Impresion.ImpresorListado(Workbook.Sheets[0], null);

                        if (selectPrinter) {
                                using (Lui.Printing.PrinterSelectionDialog SeleccionarImpresroa = new Lui.Printing.PrinterSelectionDialog()) {
                                        if (SeleccionarImpresroa.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                                                Impresor.Impresora = SeleccionarImpresroa.SelectedPrinter;
                                        } else {
                                                return new Lfx.Types.CancelOperationResult();
                                        }
                                }
                                using (PageSetupDialog PreferenciasDeImpresion = new PageSetupDialog()) {
                                        //PreferenciasDeImpresion.PrinterSettings = Impresor.PrinterSettings;
                                        PreferenciasDeImpresion.Document = Impresor;
                                        PreferenciasDeImpresion.AllowPrinter = true;
                                        PreferenciasDeImpresion.AllowPaper = true;
                                        if (PreferenciasDeImpresion.ShowDialog(this) == DialogResult.OK) {
                                                return Impresor.Imprimir();
                                        } else {
                                                return new Lfx.Types.CancelOperationResult();
                                        }
                                }
                        } else {
                                // Sin diálogo de selección de impresora
                                return Impresor.Imprimir();
                        }
                }


                public virtual Lfx.Types.OperationResult OnFilter()
                {
                        if (this.Definicion != null && this.Definicion.Filters != null) {
                                FormularioFiltros FormFiltros = new FormularioFiltros();
                                FormFiltros.Connection = this.Connection;
                                FormFiltros.FromFilters(this.Definicion.Filters);
                                if (FormFiltros.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                                        this.OnFiltersChanged(this.Definicion.Filters);
                                        this.RefreshList();
                                        return new Lfx.Types.SuccessOperationResult();
                                } else {
                                        return new Lfx.Types.CancelOperationResult();
                                }
                        } else {
                                return new Lfx.Types.SuccessOperationResult();
                        }
                }


                public virtual void OnFiltersChanged(Lazaro.Pres.Filters.FilterCollection filters)
                {

                }


                private string ExplicarFiltros(Lazaro.Pres.Filters.FilterCollection filters)
                {
                        System.Text.StringBuilder Res = new System.Text.StringBuilder();
                        foreach (Lazaro.Pres.Filters.IFilter filter in filters) {
                                if (filter is Lazaro.Pres.Filters.RelationFilter) {
                                        if (filter.Value != null)
                                                Res.Append(", " + filter.Label + " es " + filter.Value.ToString());
                                } else if (filter is Lazaro.Pres.Filters.NumericRangeFilter) {
                                        if (Lfx.Types.Parsing.ParseDecimal(filter.Value as string) != 0)
                                                Res.Append(", " + filter.Label + " es " + filter.Value.ToString());
                                } else if (filter is Lazaro.Pres.Filters.DateRangeFilter) {
                                        Lfx.Types.DateRange Rng = filter.Value as Lfx.Types.DateRange;
                                        if (Rng != null && Rng.HasRange)
                                                Res.Append(", " + filter.Label + " es " + Rng.ToString());
                                } else if (filter is Lazaro.Pres.Filters.SetFilter) {
                                        if (Lfx.Types.Parsing.ParseDecimal(filter.Value as string) > 0)
                                                Res.Append(", " + filter.Label + " es " + filter.Value.ToString());
                                }
                        }

                        return Res.ToString();
                }


                private void FormularioListadoBase_KeyDown(object sender, KeyEventArgs e)
                {
                        if (e.Control == true & e.Alt == false & e.Shift == false) {
                                switch (e.KeyCode) {
                                        case Keys.Space:
                                                e.Handled = true;
                                                this.RefreshList();
                                                break;
                                        case Keys.U:
                                                e.Handled = true;
                                                foreach (Lazaro.Pres.Field Fld in this.Definicion.Columns) {
                                                        if (FormFieldToSubItem.ContainsKey(Lfx.Data.Field.GetNameOnly(Fld.Name)))
                                                                Listado.Columns[FormFieldToSubItem[Lfx.Data.Field.GetNameOnly(Fld.Name)]].Width = Fld.Width;
                                                }
                                                break;
                                }
                        }
                }


                protected void SaveColumns()
                {
                        try {
                                foreach (ColumnHeader Ch in Listado.Columns) {
                                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting(this.GetType().ToString(), "Columns." + Ch.Name + ".Width", Ch.Width);
                                }
                        } catch {
                        }
                }


                protected bool ColumnsLoaded = false;
                protected void LoadColumns()
                {
                        if (ColumnsLoaded == false) {
                                try {
                                        foreach (ColumnHeader Ch in Listado.Columns) {
                                                Ch.Width = Lfx.Workspace.Master.CurrentConfig.ReadLocalSettingInt(this.GetType().ToString(), "Columns." + Ch.Name + ".Width", Ch.Width);
                                        }
                                        ColumnsLoaded = true;
                                } catch {
                                        // Nada
                                }
                        }
                }


                private void BotonFiltrar_Click(object sender, EventArgs e)
                {
                        this.OnFilter();
                }


                private void BotonImprimir_Click(object sender, EventArgs e)
                {
                        if ((System.Windows.Forms.Control.ModifierKeys & Keys.Shift) != Keys.Shift)
                                this.ShowExportDialog();
                        else
                                this.OnPrint(false);
                }


                private void BotonCancelar_Click(object sender, EventArgs e)
                {
                        this.Close();
                }


                protected virtual void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
                {
                }


                protected virtual void OnBeginRefreshList()
                {
                        this.LastGroupingValue = null;
                        this.LastGroup = null;

                        foreach (Contador Cont in Contadores) {
                                Cont.Reset();
                        }
                }


                /// <summary>
                /// Devuelve una lista de Ids de los ítem seleccionados en el listado.
                /// </summary>
                public Lbl.ListaIds CodigosSeleccionados
                {
                        get
                        {
                                if (Listado.CheckBoxes && Listado.CheckedItems.Count > 0) {
                                        Lbl.ListaIds Res = new Lbl.ListaIds();
                                        foreach (ListViewItem itm in Listado.CheckedItems) {
                                                Res.Add(Lfx.Types.Parsing.ParseInt(itm.Text));
                                        }
                                        return Res;
                                } else if (Listado.SelectedItems.Count > 0) {
                                        Lbl.ListaIds Res = new Lbl.ListaIds();
                                        foreach (ListViewItem itm in Listado.SelectedItems) {
                                                Res.Add(Lfx.Types.Parsing.ParseInt(itm.Text));
                                        }
                                        return Res;
                                } else {
                                        return null;
                                }
                        }
                }


                /// <summary>
                /// Devuelve una lista de Ids de todos los ítem del listado.
                /// </summary>
                public Lbl.ListaIds CodigosItem
                {
                        get
                        {
                                Lbl.ListaIds Res = new Lbl.ListaIds();
                                foreach (ListViewItem itm in Listado.Items) {
                                        Res.Add(Lfx.Types.Parsing.ParseInt(itm.Text));
                                }
                                return Res;
                        }
                }

                /// <summary>
                /// Devuelve el Id del elemento seleccionado del listado.
                /// </summary>
                public int CodigoSeleccionado
                {
                        get
                        {
                                if (Listado.SelectedItems.Count > 0)
                                        return Lfx.Types.Parsing.ParseInt(Listado.SelectedItems[0].Text);
                                else
                                        return 0;
                        }
                }


                protected virtual void OnEndRefreshList()
                {
                        if (Contadores.Count == 0) {
                                PanelContadores.Visible = false;
                        } else {
                                PanelContadores.Visible = true;

                                // TODO: hacer esto con más de 4 contadores, tal vez
                                if (this.Contadores.Count >= 1) {
                                        Contador Cont1 = this.Contadores[0];
                                        EtiquetaContador1.Text = Cont1.Etiqueta;
                                        EtiquetaContador1.Visible = true;
                                        EntradaContador1.DataType = Cont1.DataType;
                                        EntradaContador1.Prefijo = Cont1.Prefijo;
                                        EntradaContador1.Sufijo = Cont1.Sufijo;
                                        EntradaContador1.ValueDecimal = Cont1.Total;
                                        EntradaContador1.Visible = true;
                                } else {
                                        EtiquetaContador1.Visible = false;
                                        EntradaContador1.Visible = false;
                                }

                                if (this.Contadores.Count >= 2) {
                                        Contador Cont2 = this.Contadores[1];
                                        EtiquetaContador2.Text = Cont2.Etiqueta;
                                        EtiquetaContador2.Visible = true;
                                        EntradaContador2.DataType = Cont2.DataType;
                                        EntradaContador2.Prefijo = Cont2.Prefijo;
                                        EntradaContador2.Sufijo = Cont2.Sufijo;
                                        EntradaContador2.ValueDecimal = Cont2.Total;
                                        EntradaContador2.Visible = true;
                                } else {
                                        EtiquetaContador2.Visible = false;
                                        EntradaContador2.Visible = false;
                                }

                                if (this.Contadores.Count >= 3) {
                                        Contador Cont3 = this.Contadores[2];
                                        EtiquetaContador3.Text = Cont3.Etiqueta;
                                        EtiquetaContador3.Visible = true;
                                        EntradaContador3.DataType = Cont3.DataType;
                                        EntradaContador3.Prefijo = Cont3.Prefijo;
                                        EntradaContador3.Sufijo = Cont3.Sufijo;
                                        EntradaContador3.ValueDecimal = Cont3.Total;
                                        EntradaContador3.Visible = true;
                                } else {
                                        EtiquetaContador3.Visible = false;
                                        EntradaContador3.Visible = false;
                                }

                                if (this.Contadores.Count >= 4) {
                                        Contador Cont4 = this.Contadores[3];
                                        EtiquetaContador4.Text = Cont4.Etiqueta;
                                        EtiquetaContador4.Visible = true;
                                        EntradaContador4.DataType = Cont4.DataType;
                                        EntradaContador4.Prefijo = Cont4.Prefijo;
                                        EntradaContador4.Sufijo = Cont4.Sufijo;
                                        EntradaContador4.ValueDecimal = Cont4.Total;
                                        EntradaContador4.Visible = true;
                                } else {
                                        EtiquetaContador4.Visible = false;
                                        EntradaContador4.Visible = false;
                                }
                        }
                }


                private void Listado_KeyDown(object sender, KeyEventArgs e)
                {
                        if (e.Shift == false && e.Alt == false && e.Control == false) {
                                switch (e.KeyCode) {
                                        case Keys.Return:
                                                if (Listado.SelectedItems.Count > 0) {
                                                        e.Handled = true;
                                                        Lfx.Types.OperationResult Res = this.OnItemClick(Listado.SelectedItems[0]);
                                                        if (Res.Success == false && Res.Message != null)
                                                                Lui.Forms.MessageBox.Show(Res.Message, "Error");
                                                }
                                                break;
                                        case Keys.Delete:
                                                if (this.HabilitarBorrar || this.EstadosEstandar) {
                                                        e.Handled = true;
                                                        Lbl.ListaIds Codigos = this.CodigosSeleccionados;

                                                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(this.Definicion.ElementoTipo, Lbl.Sys.Permisos.Operaciones.Eliminar)) {
                                                                if (Codigos != null && Codigos.Count > 0) {
                                                                        string EstaSeguro = "¿Está seguro de que desea desactivar ";
                                                                        if (Codigos.Count == 1)
                                                                                EstaSeguro += "el elemento seleccionado?";
                                                                        else
                                                                                EstaSeguro += "los " + Codigos.Count.ToString() + " elementos seleccionado?";
                                                                        Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog(EstaSeguro, "Desactivar");
                                                                        Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                                                                        if (Pregunta.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                                                                                Lfx.Types.OperationResult Res = this.SolicitudEliminacion(Codigos);
                                                                                if (Res.Success == false && string.IsNullOrEmpty(Res.Message) == false)
                                                                                        Lfx.Workspace.Master.RunTime.Toast(Res.Message, "Error");
                                                                        }
                                                                }
                                                        } else {
                                                                Lfx.Workspace.Master.RunTime.Toast("No tiene permiso para desactivar registros.", "Aviso");
                                                        }
                                                } else {
                                                        Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("Los elementos de este listado no se pueden eliminar ni desactivar. ¿Le gustaría ver una página web con más información sobre el tema?", "Eliminación");
                                                        Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                                                        if (Pregunta.ShowDialog() == DialogResult.OK)
                                                                Help.ShowHelp(this, "http://www.lazarogestion.com/?q=node/49");
                                                }
                                                break;
                                }
                        }
                }

                public virtual Lfx.Types.OperationResult SolicitudEliminacion(Lbl.ListaIds codigos)
                {
                        return this.DesactivarRegistros(codigos);
                }

                public virtual Lfx.Types.OperationResult DesactivarRegistros(Lbl.ListaIds codigos)
                {
                        System.Data.IDbTransaction Trans = this.Connection.BeginTransaction();

                        qGen.Select SelElementos = new qGen.Select(this.AtributoDatos.TablaDatos);
                        SelElementos.WhereClause = new qGen.Where(this.AtributoDatos.CampoId, qGen.ComparisonOperators.In, codigos.ToArray());

                        System.Data.DataTable TablaElementos = this.Connection.Select(SelElementos);
                        foreach (System.Data.DataRow RegElem in TablaElementos.Rows) {
                                Lbl.IElementoDeDatos Elem = Lbl.Instanciador.Instanciar(this.ElementoTipo, this.Connection, (Lfx.Data.Row)RegElem);
                                if (Elem is Lbl.IEstadosEstandar)
                                        ((Lbl.IEstadosEstandar)(Elem)).Activar(false);
                        }
                        Trans.Commit();

                        return new Lfx.Types.SuccessOperationResult();
                }

                protected virtual Lfx.Types.OperationResult OnEdit(int itemId)
                {
                        if (itemId > 0 && this.Definicion.ElementoTipo != null && Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(this.Definicion.ElementoTipo, Lbl.Sys.Permisos.Operaciones.Ver)) {
                                Lfc.FormularioEdicion FormNuevo = null;
                                try {
                                        Lfx.Data.Connection NuevaDb = Lfx.Workspace.Master.GetNewConnection("Editar " + this.Definicion.ElementoTipo.ToString() + " " + itemId);
                                        Lbl.IElementoDeDatos Elem = Lbl.Instanciador.Instanciar(this.Definicion.ElementoTipo, NuevaDb, itemId);
                                        FormNuevo = Lfc.Instanciador.InstanciarFormularioEdicion(Elem);
                                } catch (Exception ex) {
                                        return new Lfx.Types.FailureOperationResult(ex.Message);
                                }

                                if (FormNuevo != null) {
                                        FormNuevo.DisposeConnection = true;
                                        FormNuevo.MdiParent = this.MdiParent;
                                        //FormNuevo.FromRow(Elem);
                                        FormNuevo.Show();

                                        return new Lfx.Types.SuccessOperationResult();
                                } else {
                                        return new Lfx.Types.FailureOperationResult("No se puede editar el elemento");
                                }
                        } else {
                                return new Lfx.Types.NoAccessOperationResult();
                        }
                }


                protected virtual Lfx.Types.OperationResult OnItemClick(ListViewItem itm)
                {
                        int SelectedId = Lfx.Types.Parsing.ParseInt(Listado.SelectedItems[0].Text);
                        if (SelectedId > 0) {
                                this.CancelFill = true;
                                return this.OnEdit(SelectedId);
                        } else {
                                return new Lfx.Types.CancelOperationResult();
                        }
                }


                private void Listado_DoubleClick(object sender, System.EventArgs e)
                {
                        if (Listado.FocusedItem != null) {
                                Listado.FocusedItem.Checked = !Listado.FocusedItem.Checked;
                                this.OnItemClick(Listado.FocusedItem);
                        }
                }


                private void Listado_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
                {
                        if (this.Definicion.Sortable == false)
                                return;

                        if (e.Column != this.Sorter.SortColumn)
                                // Hago esto para que ante un cambio de columna el orden sea siempre ascendente
                                this.Sorter.SortOrder = SortOrder.Descending;

                        string NuevoOrden = null;
                        if (e.Column == 0) {
                                NuevoOrden = this.Definicion.KeyColumn.Name;
                        } else if ((e.Column - 1) < this.Definicion.Columns.Count) {
                                NuevoOrden = Listado.Columns[e.Column].Name;
                        }

                        this.SetupSorter(NuevoOrden, this.Sorter.SortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending);
                        Listado.ListViewItemSorter = this.Sorter;
                        Listado.Sort();
                }


                protected void SetupSorter(string nuevoOrden)
                {
                        string Orden = nuevoOrden;

                        if (string.IsNullOrEmpty(Orden))
                                return;

                        if (Orden.IndexOf(',') >= 0) {
                                string Resto = Orden;
                                Orden = Lfx.Types.Strings.GetNextToken(ref Resto, ",");
                        }

                        if (Orden.EndsWith(" DESC"))
                                this.SetupSorter(Orden.Substring(0, Orden.Length - 5).Trim(), SortOrder.Descending);
                        else
                                this.SetupSorter(Orden, SortOrder.Ascending);
                }


                protected void SetupSorter(string nuevoOrden, SortOrder sortOrder)
                {
                        if (this.Definicion == null)
                                return;

                        if (this.Definicion.Sortable == false) {
                                this.Sorter.SortOrder = SortOrder.None;
                                return;
                        }

                        if (nuevoOrden == null) {
                                this.Sorter.SortOrder = SortOrder.None;
                                return;
                        }

                        if (Lfx.Data.Field.HaveSameName(nuevoOrden, this.Definicion.KeyColumn.Name)) {
                                this.Sorter.DataType = this.Definicion.KeyColumn.DataType;
                                this.Sorter.SortColumn = 0;
                        } else if (Listado.Columns.ContainsKey(nuevoOrden)) {
                                this.Sorter.DataType = this.Definicion.Columns[nuevoOrden].DataType;
                                this.Sorter.SortColumn = Listado.Columns.IndexOfKey(nuevoOrden);
                        } else {
                                this.Sorter.SortColumn = 0;
                                this.Sorter.SortOrder = SortOrder.None;
                                this.Sorter.DataType = Lfx.Data.InputFieldTypes.Text;
                        }

                        // quito la cláusula AS
                        if (nuevoOrden.IndexOf(" AS ") > 0)
                                nuevoOrden = nuevoOrden.Substring(0, nuevoOrden.IndexOf(" AS ")).Trim();

                        if (sortOrder == SortOrder.Descending) {
                                this.Definicion.OrderBy = nuevoOrden + " DESC";
                                this.Sorter.SortOrder = SortOrder.Descending;
                        } else {
                                this.Definicion.OrderBy = nuevoOrden;
                                this.Sorter.SortOrder = SortOrder.Ascending;
                        }
                }


                protected void SetupListviewColumns()
                {
                        if (this.Connection != null && this.Definicion != null && this.Definicion.Columns != null) {
                                SubItemToFormField.Clear();
                                FormFieldToSubItem.Clear();

                                Listado.BeginUpdate();
                                Listado.SuspendLayout();

                                //Listado.Items.Clear();
                                Listado.Groups.Clear();

                                int ColNum = 0;
                                Listado.Columns.Clear();

                                Listado.Columns.Add(new ColumnHeader());
                                Listado.Columns[ColNum].Name = this.Definicion.KeyColumn.Name;
                                Listado.Columns[ColNum].Width = this.Definicion.KeyColumn.Width;
                                Listado.Columns[ColNum].Text = this.Definicion.KeyColumn.Label;

                                if (FormFieldToSubItem.ContainsKey(Listado.Columns[ColNum].Name) == false)
                                        FormFieldToSubItem.Add(Listado.Columns[ColNum].Name, ColNum);
                                if (FormFieldToSubItem.ContainsKey(this.Definicion.KeyColumn.Name) == false)
                                        FormFieldToSubItem.Add(this.Definicion.KeyColumn.Name, ColNum);

                                ColNum++;

                                for (int i = 0; i < this.Definicion.Columns.Count; i++) {
                                        if (this.Definicion.Columns[i].Visible) {
                                                if (Listado.Columns.Count <= ColNum)
                                                        Listado.Columns.Add(new ColumnHeader());

                                                Listado.Columns[ColNum].Name = this.Definicion.Columns[i].Name;
                                                Listado.Columns[ColNum].Width = this.Definicion.Columns[i].Width;
                                                Listado.Columns[ColNum].Text = this.Definicion.Columns[i].Label;

                                                if (FormFieldToSubItem.ContainsKey(Listado.Columns[ColNum].Name) == false)
                                                        FormFieldToSubItem.Add(Listado.Columns[ColNum].Name, ColNum);
                                                if (FormFieldToSubItem.ContainsKey(this.Definicion.Columns[i].Name) == false)
                                                        FormFieldToSubItem.Add(this.Definicion.Columns[i].Name, ColNum);

                                                switch (this.Definicion.Columns[i].DataType) {
                                                        case Lfx.Data.InputFieldTypes.Integer:
                                                        case Lfx.Data.InputFieldTypes.Serial:
                                                        case Lfx.Data.InputFieldTypes.Numeric:
                                                        case Lfx.Data.InputFieldTypes.Currency:
                                                                Listado.Columns[ColNum].TextAlign = HorizontalAlignment.Right;
                                                                break;
                                                        default:
                                                                Listado.Columns[ColNum].TextAlign = HorizontalAlignment.Left;
                                                                break;
                                                }

                                                ColNum++;
                                        }
                                }

                                if (this.Definicion.KeyColumn != null) {
                                        Listado.Columns[0].Width = this.Definicion.KeyColumn.Width;
                                        Listado.Columns[0].Text = this.Definicion.KeyColumn.Label;
                                }


                                this.SetupSorter(this.Definicion.OrderBy);

                                Listado.ResumeLayout();
                                Listado.EndUpdate();
                        }
                }


                public virtual void RefreshList()
                {
                        if (this.Connection == null)
                                return;

                        LastGroup = null;

                        if (Listado.Columns.Count <= 1)
                                this.SetupListviewColumns();
                        this.LoadColumns();
                        this.OnBeginRefreshList();

                        this.Fill(this.SelectCommand());

                        this.OnEndRefreshList();
                }

                protected qGen.Select SelectCommand()
                {
                        return this.SelectCommand(null, null, null);
                }


                protected qGen.Select SelectCommand(bool forCount, qGen.Where additionalFilters)
                {
                        return this.SelectCommand("COUNT", null, additionalFilters);
                }

                protected qGen.Select SelectCommand(string agrFunction, string onField)
                {
                        return SelectCommand(agrFunction, onField, null);
                }

                protected qGen.Select SelectCommand(string agrFunction, string onField, qGen.Where additionalFilters)
                {
                        if (this.Connection != null && this.Definicion != null && this.Definicion.TableName != null) {
                                qGen.Select ComandoSelect = new qGen.Select(this.Connection.SqlMode);

                                // Genero la lista de tablas, con JOIN y todo
                                string ListaTablas = null;
                                ListaTablas = this.Definicion.TableName;

                                if (this.Definicion.Joins != null && this.Definicion.Joins.Count > 0)
                                        ComandoSelect.Joins = this.Definicion.Joins;

                                foreach (Lazaro.Pres.Field Fld in this.Definicion.Columns) {
                                        if (Fld.DataType == Lfx.Data.InputFieldTypes.Relation && Fld.Relation != null) {
                                                qGen.Join RelJoin = new qGen.Join(Fld.Relation);
                                                if (ComandoSelect.Joins.Contains(RelJoin) == false)
                                                        ComandoSelect.Joins.Add(RelJoin);
                                        }
                                }

                                string ListaCampos;
                                if (agrFunction != null) {
                                        if (onField == null)
                                                onField = this.Definicion.KeyColumn.Name;
                                        string Alias = agrFunction + "_" + onField.Replace(".", "_");
                                        ListaCampos = agrFunction + "(" + onField + ") AS " + Alias;
                                } else {
                                        // Genero la lista de campos
                                        ListaCampos = this.Definicion.KeyColumn.Name;
                                        foreach (Lazaro.Pres.Field CurField in this.Definicion.Columns)
                                                ListaCampos += "," + CurField.Name;
                                }

                                // Genero las condiciones del WHERE
                                qGen.Where WhereBuscarTexto = new qGen.Where();
                                WhereBuscarTexto.Operator = qGen.AndOr.Or;

                                if (this.SearchText != string.Empty) {
                                        bool EsNumero = this.SearchText.IsNumericInt() || this.SearchText.IsNumericFloat();
                                        if (this.SearchText.IsNumericInt())
                                                WhereBuscarTexto.AddWithValue(this.Definicion.KeyColumn.Name, Lfx.Types.Parsing.ParseInt(this.SearchText).ToString());

                                        if (this.Definicion.Columns != null) {
                                                foreach (Lazaro.Pres.Field CurField in this.Definicion.Columns) {
                                                        if (CurField.Name.IndexOf(" AS ") == -1 && CurField.Name.IndexOf("(") == -1) {
                                                                switch (CurField.DataType) {
                                                                        case Lfx.Data.InputFieldTypes.Binary:
                                                                        case Lfx.Data.InputFieldTypes.Image:
                                                                        case Lfx.Data.InputFieldTypes.Bool:
                                                                        case Lfx.Data.InputFieldTypes.Set:
                                                                                // En estos tipos de campos no se busca
                                                                                break;
                                                                        case Lfx.Data.InputFieldTypes.Date:
                                                                        case Lfx.Data.InputFieldTypes.DateTime:
                                                                                // En estos campos, busco atento a que se trata de una fecha
                                                                                NullableDateTime Fecha = SearchText.ParseDateTime();    // TODO: cachear el valor para que no lo parsee en cada iteración
                                                                                if (Fecha != null) {
                                                                                        DateTime SearchDate = Fecha.Value;
                                                                                        DateTime FromDate = new DateTime(SearchDate.Year, SearchDate.Month, SearchDate.Day, 0, 0, 0);
                                                                                        DateTime ToDate = new DateTime(SearchDate.Year, SearchDate.Month, SearchDate.Day, 23, 59, 59);
                                                                                        WhereBuscarTexto.AddWithValue(CurField.Name, FromDate, ToDate);
                                                                                }
                                                                                break;
                                                                        case Lfx.Data.InputFieldTypes.Currency:
                                                                        case Lfx.Data.InputFieldTypes.Integer:
                                                                        case Lfx.Data.InputFieldTypes.Numeric:
                                                                        case Lfx.Data.InputFieldTypes.NumericSet:
                                                                        case Lfx.Data.InputFieldTypes.Serial:
                                                                                // En estos tipos de campos busco sólo números
                                                                                if (EsNumero)
                                                                                        WhereBuscarTexto.AddWithValue(CurField.Name, qGen.ComparisonOperators.InsensitiveLike, "%" + this.SearchText + "%");
                                                                                break;
                                                                        case Lfx.Data.InputFieldTypes.Relation:
                                                                        default:
                                                                                WhereBuscarTexto.AddWithValue(CurField.Name, qGen.ComparisonOperators.InsensitiveLike, "%" + this.SearchText + "%");
                                                                                break;
                                                                }

                                                        }
                                                }
                                        }
                                        if (this.Definicion.ExtraSearchColumns != null) {
                                                foreach (Lazaro.Pres.Field CurField in this.Definicion.ExtraSearchColumns) {
                                                        switch (CurField.DataType) {
                                                                case Lfx.Data.InputFieldTypes.Binary:
                                                                case Lfx.Data.InputFieldTypes.Image:
                                                                        // En estos tipos de campos no se busca
                                                                        break;
                                                                case Lfx.Data.InputFieldTypes.Currency:
                                                                case Lfx.Data.InputFieldTypes.Integer:
                                                                case Lfx.Data.InputFieldTypes.Numeric:
                                                                case Lfx.Data.InputFieldTypes.NumericSet:
                                                                case Lfx.Data.InputFieldTypes.Serial:
                                                                        // En estos tipos de campos busco sólo números
                                                                        if (EsNumero)
                                                                                WhereBuscarTexto.AddWithValue(CurField.Name, qGen.ComparisonOperators.InsensitiveLike, "%" + this.SearchText + "%");
                                                                        break;
                                                                case Lfx.Data.InputFieldTypes.Relation:
                                                                default:
                                                                        WhereBuscarTexto.AddWithValue(CurField.Name, qGen.ComparisonOperators.InsensitiveLike, "%" + this.SearchText + "%");
                                                                        break;
                                                        }
                                                }
                                        }
                                }

                                qGen.Where WhereCompleto = new qGen.Where();
                                WhereCompleto.Operator = qGen.AndOr.And;

                                if (m_Labels != null) {
                                        if (m_LabelField == null || m_LabelField.Length == 0)
                                                m_LabelField = this.Definicion.KeyColumn.Name;
                                        if (m_Labels.Count == 1) {
                                                // Ids negativos sólo cuando hay una sola etiqueta
                                                if (m_Labels[0] > 0)
                                                        WhereCompleto.AddWithValue(m_LabelField, qGen.ComparisonOperators.In, new qGen.SqlExpression("(SELECT item_id FROM sys_labels_values WHERE id_label=" + m_Labels[0].ToString() + ")"));
                                                else
                                                        WhereCompleto.AddWithValue(m_LabelField, qGen.ComparisonOperators.NotIn, new qGen.SqlExpression("(SELECT item_id FROM sys_labels_values WHERE id_label=" + (-m_Labels[0]).ToString() + ")"));
                                        } else if (m_Labels.Count > 1) {
                                                string[] LabelsString = Array.ConvertAll<int, string>(m_Labels.ToArray(), new Converter<int, string>(Convert.ToString));
                                                WhereCompleto.AddWithValue(m_LabelField, qGen.ComparisonOperators.In, new qGen.SqlExpression("(SELECT item_id FROM sys_labels_values WHERE id_label IN (" + string.Join(",", LabelsString) + "))"));
                                        }
                                }

                                if (WhereBuscarTexto.Count > 0)
                                        WhereCompleto.AddWithValue(WhereBuscarTexto);

                                if (m_CustomFilters != null && m_CustomFilters.Count > 0)
                                        WhereCompleto.AddWithValue(m_CustomFilters);

                                if (m_FixedFilters != null && m_FixedFilters.Count > 0)
                                        WhereCompleto.AddWithValue(m_FixedFilters);

                                if (additionalFilters != null && additionalFilters.Count > 0)
                                        WhereCompleto.AddWithValue(additionalFilters);

                                ComandoSelect.Tables = ListaTablas;
                                ComandoSelect.Fields = ListaCampos;
                                ComandoSelect.WhereClause = WhereCompleto;

                                if (this.Definicion.GroupBy != null && agrFunction == null)
                                        ComandoSelect.Group = this.Definicion.GroupBy.Name;

                                if (this.Definicion.Having != null)
                                        ComandoSelect.HavingClause = this.Definicion.Having;

                                if (agrFunction == null)
                                        ComandoSelect.Order = this.Definicion.OrderBy;

                                return ComandoSelect;
                        } else {
                                return null;
                        }
                }


                private bool CancelFill = false;
                protected void Fill(qGen.Select command)
                {
                        if (this.Listado.Columns.Count == 0)
                                this.SetupListviewColumns();

                        CancelFill = false;

                        if (this.Connection == null || command == null)
                                return;

                        if (command.Window == null) {
                                if (Lfx.Workspace.Master.SlowLink)
                                        command.Window = new qGen.Window(1000 > m_Limit ? 1000 : m_Limit);
                                else if (m_Limit > 0)
                                        command.Window = new qGen.Window(m_Limit);
                                else
                                        command.Window = null;
                        }

                        System.Data.DataTable Tabla = this.Connection.Select(command);

                        ListViewItem CurItem = null;

                        if (Listado.SelectedItems.Count > 0)
                                CurItem = (ListViewItem)Listado.SelectedItems[0].Clone();
                        else
                                CurItem = null;

                        bool Actualizando;
                        if (ItemListado.Count > 0) {
                                Actualizando = true;
                                EtiquetaCantidad.Text = "Actualizando...";
                        } else {
                                Actualizando = false;
                                //Listado.Items.Clear();
                                EtiquetaCantidad.Text = "Cargando...";
                        }
                        PicEsperar.Visible = true;
                        EtiquetaCantidad.Refresh();
                        PicEsperar.Refresh();

                        Listado.ListViewItemSorter = null;
                        Listado.SuspendLayout();
                        Listado.BeginUpdate();

                        foreach (ListViewItem Itm in ItemListado.Values) {
                                Itm.Tag = null;
                        }

                        if (Tabla != null && Tabla.Rows.Count > 0) {
                                int FillCount = 0;
                                foreach (System.Data.DataRow DtRow in Tabla.Rows) {
                                        Lfx.Data.Row Registro = (Lfx.Data.Row)DtRow;

                                        string NombreCampoId = Lfx.Data.Field.GetNameOnly(this.Definicion.KeyColumn.Name);
                                        int ItemId = Registro.Fields[NombreCampoId].ValueInt;

                                        if (CancelFill) {
                                                if (Listado.Created) {
                                                        Listado.EndUpdate();
                                                        Listado.ResumeLayout();
                                                }
                                                return;
                                        }

                                        ListViewItem Itm;
                                        string ItemKey = ItemId.ToString();
                                        if (ItemListado.ContainsKey(ItemId)) {
                                                Itm = this.FormatListViewItem(ItemListado[ItemId], ItemId, Registro);
                                                if (Listado.Items.Contains(Itm) == false)
                                                        Listado.Items.Add(Itm);
                                        } else {
                                                Itm = this.FormatListViewItem(new ListViewItem(ItemKey), ItemId, Registro);
                                                ItemListado.Add(ItemId, Itm);
                                                Listado.Items.Add(Itm);
                                        }

                                        Itm.Tag = Registro;

                                        // Agrego el item a un grupo, si hay agrupación activa
                                        if (m_GroupingColumnName != null) {
                                                string FormattedGroupingValue = this.FormatValue(Registro[m_GroupingColumnName], this.Definicion.Columns[m_GroupingColumnName]);
                                                if (LastGroupingValue != FormattedGroupingValue) {
                                                        LastGroupingValue = FormattedGroupingValue;
                                                        if (Listado.Groups[LastGroupingValue] != null)
                                                                LastGroup = Listado.Groups[LastGroupingValue];
                                                        else
                                                                LastGroup = Listado.Groups.Add(LastGroupingValue, LastGroupingValue);
                                                }
                                        }
                                        Itm.Group = LastGroup;

                                        OnItemAdded(Itm, Registro);

                                        if (CurItem != null && Itm.Text == CurItem.Text)
                                                CurItem = Itm;

                                        if ((++FillCount % 100) == 0) {
                                                // Cuando ya tengo algunos como para mostrar, actualizo el listview
                                                // así parece que el listado ya cargó, cuando en realidad sigue cargando
                                                double Pct = Math.Round(FillCount * 100D / Tabla.Rows.Count);
                                                if (Actualizando) {
                                                        EtiquetaCantidad.Text = "Actualizando, " + Pct.ToString() + "%";
                                                        System.Windows.Forms.Application.DoEvents();
                                                } else {
                                                        EtiquetaCantidad.Text = "Cargando, " + Pct.ToString() + "%";
                                                        Listado.EndUpdate();
                                                        Listado.ResumeLayout(true);
                                                        System.Windows.Forms.Application.DoEvents();
                                                        Listado.BeginUpdate();
                                                        Listado.SuspendLayout();
                                                }
                                        }
                                }
                        }

                        foreach (ListViewItem Itm in Listado.Items) {
                                if (Itm.Tag == null) {
                                        Listado.Items.Remove(Itm);
                                }
                        }

                        if (Listado.Items.Count > 0 && Listado.SelectedItems.Count == 0) {
                                Listado.Items[0].Focused = true;
                                Listado.Items[0].Selected = true;
                        }

                        if (Listado.Items.Count == 0) {
                                EtiquetaCantidad.Text = "";
                                EtiquetaCantidad.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Default;
                        } else if (Listado.Items.Count == m_Limit) {
                                int Cantidad;
                                try {
                                        qGen.Select SelCount = this.SelectCommand(true, null);
                                        Cantidad = this.Connection.FieldInt(SelCount);
                                } catch {
                                        Cantidad = 0;
                                }

                                if (Cantidad > 0)
                                        EtiquetaCantidad.Text = "Mostrando sólo los primeros " + m_Limit.ToString() + " de un total de " + Cantidad.ToString();
                                else
                                        EtiquetaCantidad.Text = "Mostrando sólo los primeros " + m_Limit.ToString();
                                EtiquetaCantidad.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        } else {
                                EtiquetaCantidad.Text = Listado.Items.Count.ToString() + " elementos";
                                EtiquetaCantidad.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Default;
                        }


                        // Muestro los totales de grupo
                        if (m_GroupingColumnName != null) {
                                foreach (ListViewGroup Grp in Listado.Groups) {
                                        Grp.Header = Grp.Name + " (" + Grp.Items.Count.ToString() + ")";
                                        ListViewItem Itm = Listado.Items.Add("Subtotales");
                                        Itm.Font = new Font(Itm.Font, FontStyle.Bold);
                                        Itm.BackColor = Color.Lavender;
                                        foreach (ColumnHeader Col in Listado.Columns) {
                                                if (Col.Name != this.Definicion.KeyColumn.Name) {
                                                        Itm.Group = Grp;
                                                        object ColFunc = this.Definicion.Columns[Col.Name].TotalFunction;
                                                        if (ColFunc == null) {
                                                                Itm.SubItems.Add("");
                                                        } else if (ColFunc is Lazaro.Pres.Spreadsheet.QuickFunctions) {
                                                                Lazaro.Pres.Spreadsheet.QuickFunctions QuickFunc = (Lazaro.Pres.Spreadsheet.QuickFunctions)(this.Definicion.Columns[Col.Name].TotalFunction);
                                                                switch (QuickFunc) {
                                                                        case Lazaro.Pres.Spreadsheet.QuickFunctions.Count:
                                                                                Itm.SubItems.Add(Grp.Items.Count.ToString());
                                                                                break;
                                                                        case Lazaro.Pres.Spreadsheet.QuickFunctions.Sum:
                                                                                decimal Res = 0;
                                                                                foreach (ListViewItem SubItm in Grp.Items) {
                                                                                        Lfx.Data.Row Rw = SubItm.Tag as Lfx.Data.Row;
                                                                                        if (Rw != null)
                                                                                                Res += Rw.Fields[Col.Name].ValueDecimal;
                                                                                }
                                                                                Itm.SubItems.Add(Lfx.Types.Formatting.FormatCurrency(Res));
                                                                                break;
                                                                        default:
                                                                                Itm.SubItems.Add("");
                                                                                break;
                                                                }
                                                        } else {
                                                                Itm.SubItems.Add(ColFunc.ToString());
                                                        }
                                                }
                                        }
                                }
                        }


                        if (this.Sorter != null && this.Sorter.SortOrder != SortOrder.None) {
                                Listado.ListViewItemSorter = this.Sorter;
                                Listado.Sort();
                        }

                        Listado.EndUpdate();
                        Listado.ResumeLayout();

                        PicEsperar.Visible = false;

                        if (CurItem != null) {
                                CurItem.Selected = true;
                                CurItem.Focused = true;
                                CurItem.EnsureVisible();
                        }

                        CancelFill = true;
                }


                protected virtual Lazaro.Pres.Spreadsheet.Row FormatRow(int itemId, Lfx.Data.Row row, Lazaro.Pres.Spreadsheet.Sheet sheet, Lazaro.Pres.FieldCollection useFields)
                {
                        Lazaro.Pres.Spreadsheet.Row Reng = new Lazaro.Pres.Spreadsheet.Row(sheet);

                        if (this.Definicion.KeyColumn != null && this.Definicion.KeyColumn.Printable) {
                                Lazaro.Pres.Spreadsheet.Cell KeyCell = Reng.Cells.Add();
                                KeyCell.Content = itemId;
                        }

                        for (int FieldNum = 0; FieldNum < useFields.Count; FieldNum++) {
                                if (useFields[FieldNum].Printable) {

                                        string FieldName = Lfx.Data.Field.GetNameOnly(useFields[FieldNum].Name);

                                        if (FieldNum >= 0) {
                                                Lazaro.Pres.Spreadsheet.Cell NewCell = Reng.Cells.Add();

                                                switch (useFields[FieldNum].DataType) {
                                                        case Lfx.Data.InputFieldTypes.Integer:
                                                        case Lfx.Data.InputFieldTypes.Serial:
                                                                if (row[FieldName] == null || row[FieldName] is DBNull)
                                                                        NewCell.Content = null;
                                                                else if (useFields[FieldNum].Format != null)
                                                                        NewCell.Content = System.Convert.ToInt32(row[FieldName]).ToString(useFields[FieldNum].Format);
                                                                else
                                                                        NewCell.Content = row[FieldName].ToString();
                                                                break;

                                                        case Lfx.Data.InputFieldTypes.Relation:
                                                        case Lfx.Data.InputFieldTypes.Text:
                                                        case Lfx.Data.InputFieldTypes.Memo:
                                                                if (row[FieldName] == null)
                                                                        NewCell.Content = null;
                                                                else if (row[FieldName] is System.Byte[])
                                                                        NewCell.Content = System.Text.Encoding.Default.GetString(((System.Byte[])(row[FieldName])));
                                                                else
                                                                        NewCell.Content = row.Fields[FieldName].Value.ToString();
                                                                break;

                                                        case Lfx.Data.InputFieldTypes.Currency:
                                                                double ValorCur = (row[FieldName] == null || row[FieldName] is DBNull) ? 0 : System.Convert.ToDouble(row[FieldName]);
                                                                NewCell.Content = ValorCur;
                                                                break;

                                                        case Lfx.Data.InputFieldTypes.Numeric:
                                                                if (row[FieldName] == null || row[FieldName] is DBNull)
                                                                        NewCell.Content = null;
                                                                else
                                                                        NewCell.Content = System.Convert.ToDouble(row[FieldName]);
                                                                break;

                                                        case Lfx.Data.InputFieldTypes.Date:
                                                                if (row.Fields[FieldName].Value != null)
                                                                        NewCell.Content = row.Fields[FieldName].ValueDateTime;
                                                                break;

                                                        case Lfx.Data.InputFieldTypes.DateTime:
                                                                NewCell.Content = row[FieldName];
                                                                break;

                                                        case Lfx.Data.InputFieldTypes.Bool:
                                                                if (System.Convert.ToBoolean(row[FieldName]))
                                                                        NewCell.Content = "Sí";
                                                                else
                                                                        NewCell.Content = "No";
                                                                break;

                                                        case Lfx.Data.InputFieldTypes.Set:
                                                                int SetValue = System.Convert.ToInt32(row[FieldName]);
                                                                if (useFields[FieldNum] != null && useFields[FieldNum].SetValues != null & useFields[FieldNum].SetValues.ContainsKey(SetValue))
                                                                        NewCell.Content = useFields[FieldNum].SetValues[SetValue];
                                                                else
                                                                        NewCell.Content = "???";
                                                                break;

                                                        default:
                                                                NewCell.Content = row[FieldName];
                                                                break;
                                                }
                                        }
                                }
                        }

                        return Reng;
                }


                private ListViewItem FormatListViewItem(ListViewItem itm, int itemId, Lfx.Data.Row row)
                {
                        for (int ColNum = 1; ColNum < Listado.Columns.Count; ColNum++) {
                                string FieldName = Listado.Columns[ColNum].Name;

                                string FieldValueAsText;
                                int FieldNum = -1;
                                if (SubItemToFormField.ContainsKey(FieldName) == false) {
                                        for (int fi = 0; fi < this.Definicion.Columns.Count; fi++) {
                                                if (this.Definicion.Columns[fi].Name == FieldName) {
                                                        FieldNum = fi;
                                                        SubItemToFormField.Add(FieldName, FieldNum);
                                                        break;
                                                }
                                        }
                                } else {
                                        FieldNum = SubItemToFormField[FieldName];
                                }
                                int RowField = FieldNum + 1;

                                FieldValueAsText = this.FormatValue(row[RowField], this.Definicion.Columns[FieldNum]);

                                if (FieldNum == -1) {
                                        itm.Text = FieldValueAsText;
                                } else {
                                        ListViewItem.ListViewSubItem SubItm;
                                        if (itm.SubItems.Count - 1 < ColNum) {
                                                SubItm = itm.SubItems.Add(FieldValueAsText);
                                                SubItm.Name = FieldName;
                                        } else {
                                                SubItm = itm.SubItems[ColNum];
                                                SubItm.Text = FieldValueAsText;
                                        }
                                }
                        }

                        if (this.EstadosEstandar && this.ColumnaEstado != null) {
                                if (row.Fields[this.ColumnaEstado].ValueInt == 0)
                                        itm.ForeColor = Color.Gray;
                        }

                        return itm;
                }


                private string m_ColumnaEstado = string.Empty;
                protected string ColumnaEstado
                {
                        get
                        {
                                if (m_ColumnaEstado == string.Empty) {
                                        if (this.Definicion == null || this.Definicion.ElementoTipo == null)
                                                return null;
                                        else if (this.Definicion.Columns.ContainsKey("estado"))
                                                m_ColumnaEstado = this.Definicion.Columns["estado"].Name;
                                        else
                                                m_ColumnaEstado = null;
                                }
                                return m_ColumnaEstado;
                        }
                }


                private int m_EstadosEstandar = -1;
                protected bool EstadosEstandar
                {
                        get
                        {
                                if (m_EstadosEstandar == -1) {
                                        if (this.Definicion == null || this.Definicion.ElementoTipo == null)
                                                return false;
                                        else if (this.Definicion.ElementoTipo.GetInterface("Lbl.IEstadosEstandar") != null)
                                                m_EstadosEstandar = 1;
                                        else
                                                m_EstadosEstandar = 0;
                                }

                                return m_EstadosEstandar > 0;
                        }
                }


                private string FormatValue(object cellValue, Lazaro.Pres.Field formField)
                {
                        string FieldValueAsText;

                        if (cellValue == null)
                                return "";

                        if (formField == null)
                                return cellValue.ToString();

                        switch (formField.DataType) {
                                case Lfx.Data.InputFieldTypes.Integer:
                                case Lfx.Data.InputFieldTypes.Serial:
                                        if (cellValue == null || cellValue is DBNull)
                                                FieldValueAsText = "";
                                        else if (formField.Format != null)
                                                FieldValueAsText = Lfx.Types.Parsing.ParseInt(cellValue.ToString()).ToString(formField.Format);
                                        else
                                                FieldValueAsText = Lfx.Types.Parsing.ParseInt(cellValue.ToString()).ToString();
                                        break;

                                case Lfx.Data.InputFieldTypes.Text:
                                case Lfx.Data.InputFieldTypes.Memo:
                                case Lfx.Data.InputFieldTypes.Relation:
                                        if (cellValue == null)
                                                FieldValueAsText = "";
                                        else if (cellValue is System.Byte[])
                                                FieldValueAsText = System.Text.Encoding.Default.GetString(((System.Byte[])(cellValue)));
                                        else
                                                FieldValueAsText = cellValue.ToString();
                                        break;

                                case Lfx.Data.InputFieldTypes.Currency:
                                        decimal ValorCur = (cellValue == null || cellValue is DBNull) ? 0 : System.Convert.ToDecimal(cellValue);
                                        if (ValorCur == 0)
                                                FieldValueAsText = "-";
                                        else
                                                FieldValueAsText = Lfx.Types.Formatting.FormatCurrency(ValorCur, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                                        break;

                                case Lfx.Data.InputFieldTypes.Numeric:
                                        if (cellValue == null || cellValue is DBNull)
                                                FieldValueAsText = "";
                                        else
                                                FieldValueAsText = Lfx.Types.Formatting.FormatNumber(System.Convert.ToDecimal(cellValue), 2);
                                        break;

                                case Lfx.Data.InputFieldTypes.Date:
                                        if (cellValue != null) {
                                                if (formField.Format != null)
                                                        FieldValueAsText = System.Convert.ToDateTime(cellValue).ToString(formField.Format).ToTitleCase();
                                                else
                                                        FieldValueAsText = System.Convert.ToDateTime(cellValue).ToString(Lfx.Types.Formatting.DateTime.ShortDatePattern);
                                        } else {
                                                FieldValueAsText = "";
                                        }
                                        break;

                                case Lfx.Data.InputFieldTypes.DateTime:
                                        if (cellValue != null) {
                                                if (formField.Format != null)
                                                        FieldValueAsText = System.Convert.ToDateTime(cellValue).ToString(formField.Format).ToTitleCase();
                                                else
                                                        FieldValueAsText = System.Convert.ToDateTime(cellValue).ToString(Lfx.Types.Formatting.DateTime.FullDateTimePattern);
                                        } else {
                                                FieldValueAsText = "";
                                        }
                                        break;

                                case Lfx.Data.InputFieldTypes.YearMonth:
                                        if (cellValue != null) {
                                                if (formField.Format != null)
                                                        FieldValueAsText = System.Convert.ToDateTime(cellValue).ToString(formField.Format).ToTitleCase();
                                                else
                                                        FieldValueAsText = System.Convert.ToDateTime(cellValue).ToString(Lfx.Types.Formatting.DateTime.ShortMonthAndYearPattern);
                                        } else {
                                                FieldValueAsText = "";
                                        }
                                        break;

                                case Lfx.Data.InputFieldTypes.Bool:
                                        if (System.Convert.ToBoolean(cellValue))
                                                FieldValueAsText = "Sí";
                                        else
                                                FieldValueAsText = "No";
                                        break;

                                case Lfx.Data.InputFieldTypes.Set:
                                        int SetValue = System.Convert.ToInt32(cellValue);
                                        if (formField != null && formField.SetValues != null & formField.SetValues.ContainsKey(SetValue))
                                                FieldValueAsText = formField.SetValues[SetValue];
                                        else
                                                FieldValueAsText = "???";
                                        break;

                                default:
                                        switch (cellValue.GetType().ToString()) {
                                                case "System.Single":
                                                case "System.Double":
                                                        if (System.Convert.ToDouble(cellValue) == 0)
                                                                FieldValueAsText = "-";
                                                        else
                                                                FieldValueAsText = Lfx.Types.Formatting.FormatNumber(System.Convert.ToDecimal(cellValue), 2);
                                                        break;

                                                case "System.Decimal":
                                                        if (System.Convert.ToDecimal(cellValue) == 0)
                                                                FieldValueAsText = "-";
                                                        else
                                                                FieldValueAsText = Lfx.Types.Formatting.FormatNumber(System.Convert.ToDecimal(cellValue), 4);
                                                        break;

                                                case "System.Integer":
                                                case "System.Int16":
                                                case "System.Int32":
                                                case "System.Int64":
                                                        if (System.Convert.ToInt32(cellValue) == 0)
                                                                FieldValueAsText = "-";
                                                        else
                                                                FieldValueAsText = Lfx.Types.Formatting.FormatNumber(System.Convert.ToDecimal(cellValue), 0);
                                                        break;

                                                case "System.DateTime":
                                                        FieldValueAsText = Lfx.Types.Formatting.FormatDate(cellValue);
                                                        break;

                                                case "System.String":
                                                        FieldValueAsText = System.Convert.ToString(cellValue);
                                                        break;

                                                case "System.Byte[]":
                                                        FieldValueAsText = System.Text.Encoding.Default.GetString((byte[])cellValue);
                                                        break;

                                                case "System.DBNull":
                                                        FieldValueAsText = "";
                                                        break;

                                                default:
                                                        FieldValueAsText = cellValue.ToString();
                                                        break;
                                        }
                                        break;
                        }
                        return FieldValueAsText;
                }

                protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
                {
                        this.SaveColumns();

                        base.OnClosing(e);
                }

                protected override void OnActivated(EventArgs e)
                {
                        if (this.Text == "Listado" && this.Definicion.ElementoTipo != null) {
                                Lbl.Atributos.Nomenclatura Attr = this.Definicion.ElementoTipo.GetAttribute<Lbl.Atributos.Nomenclatura>();
                                if (Attr != null)
                                        this.Text = "Listado de " + Attr.NombrePlural;
                        }

                        if (this.Visible && (Lfx.Workspace.Master.SlowLink == false || this.Listado.Items.Count < 500))
                                RefreshTimer.Start();

                        base.OnActivated(e);
                }


                protected virtual void ShowExportDialog()
                {
                        if (Listado.Items.Count == 0) {
                                Lfx.Workspace.Master.RunTime.Toast("No se puede imprimir o exportar el listado porque no contiene datos.", "Listado");
                                return;
                        }

                        using (Lfc.FormularioListadoExportar FormExportar = new Lfc.FormularioListadoExportar()) {
                                if (FormExportar.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                                        FormatoExportar Formato = FormExportar.SaveFormat;
                                        if (Formato == FormatoExportar.Imprimir) {
                                                this.OnPrint(false);
                                        } else if (Formato == FormatoExportar.ImprimirAvanzado) {
                                                this.OnPrint(true);
                                        } else {
                                                SaveFileDialog DialogoGuardar = new SaveFileDialog();
                                                DialogoGuardar.OverwritePrompt = true;
                                                DialogoGuardar.ValidateNames = true;
                                                DialogoGuardar.CheckPathExists = true;
                                                switch (Formato) {
                                                        case FormatoExportar.Html:
                                                                DialogoGuardar.DefaultExt = ".html";
                                                                DialogoGuardar.Filter = "Formato HTML|*.htm;*.html";
                                                                break;
                                                        case FormatoExportar.Excel:
                                                                DialogoGuardar.DefaultExt = ".xlsx";
                                                                DialogoGuardar.Filter = "Microsoft Excel 2007-2013|*.xlsx";
                                                                break;
                                                        case FormatoExportar.ExcelXml:
                                                                DialogoGuardar.DefaultExt = ".xls";
                                                                DialogoGuardar.Filter = "Formato de Microsoft Excel|*.xls";
                                                                break;
                                                }

                                                DialogoGuardar.FileName = this.Text.Replace(":", "");
                                                if (DialogoGuardar.ShowDialog() == DialogResult.OK) {
                                                        Lazaro.Pres.Spreadsheet.Workbook Workbook = this.ToWorkbook();
                                                        string FileName = DialogoGuardar.FileName;
                                                        this.OnExport(FileName, Formato);
                                                        try {
                                                                switch (Formato) {
                                                                        case FormatoExportar.Html:
                                                                                Workbook.SaveTo(FileName, Lazaro.Pres.Spreadsheet.SaveFormats.Html);
                                                                                break;
                                                                        case FormatoExportar.Excel:
                                                                                Workbook.SaveTo(FileName, Lazaro.Pres.Spreadsheet.SaveFormats.Excel);
                                                                                break;
                                                                        //case FormatoExportar.ExcelXml:
                                                                        //        Workbook.SaveTo(FileName, Lazaro.Pres.Spreadsheet.SaveFormats.ExcelXml);
                                                                        //        break;
                                                                }
                                                        } catch (Exception ex) {
                                                                Lfx.Workspace.Master.RunTime.Toast("No se puede guardar el archivo. " + ex.Message, "Error");
                                                        }
                                                }
                                        }
                                }
                        }
                }
                public virtual void OnExport(string filename, FormatoExportar formato)
                {
                        
                }

                public virtual Lazaro.Pres.Spreadsheet.Workbook ToWorkbook()
                {
                        return ToWorkbook(this.Definicion.Columns);
                }

                public virtual Lazaro.Pres.Spreadsheet.Workbook ToWorkbook(Lazaro.Pres.FieldCollection useFields)
                {
                        Lazaro.Pres.Spreadsheet.Workbook Res = new Lazaro.Pres.Spreadsheet.Workbook();
                        Lazaro.Pres.Spreadsheet.Sheet Sheet = new Lazaro.Pres.Spreadsheet.Sheet(this.Text);
                        Res.Sheets.Add(Sheet);

                        // Exporto los encabezados de columna
                        if (this.Definicion.KeyColumn.Printable) {
                                Sheet.ColumnHeaders.Add(new Lazaro.Pres.Spreadsheet.ColumnHeader(this.Definicion.KeyColumn.Label, this.Definicion.KeyColumn.Width));
                                Sheet.ColumnHeaders[0].DataType = this.Definicion.KeyColumn.DataType;
                                Sheet.ColumnHeaders[0].Format = this.Definicion.KeyColumn.Format;
                                Sheet.ColumnHeaders[0].Printable = this.Definicion.KeyColumn.Printable;
                        }

                        int OrderColumn = -1;
                        if (useFields != null) {
                                for (int i = 0; i <= useFields.Count - 1; i++) {
                                        if (useFields[i].Printable) {
                                                Lazaro.Pres.Spreadsheet.ColumnHeader ColHead = new Lazaro.Pres.Spreadsheet.ColumnHeader(useFields[i].Label, useFields[i].Width);
                                                ColHead.Name = Lfx.Data.Field.GetNameOnly(useFields[i].Name);
                                                ColHead.TextAlignment = useFields[i].Alignment;
                                                ColHead.DataType = useFields[i].DataType;
                                                ColHead.Format = useFields[i].Format;
                                                ColHead.TotalFunction = useFields[i].TotalFunction;
                                                ColHead.Printable = useFields[i].Printable;
                                                Sheet.ColumnHeaders.Add(ColHead);

                                                if (ColHead.Name == this.Definicion.OrderBy)
                                                        OrderColumn = Sheet.ColumnHeaders.Count - 1;

                                                if (ColHead.Name == this.GroupingColumnName)
                                                        Sheet.ColumnHeaders.GroupingColumn = Sheet.ColumnHeaders.Count - 1;
                                        }
                                }
                        }

                        // Exporto los renglones
                        System.Data.DataTable Tabla = this.Connection.Select(this.SelectCommand());
                        foreach (System.Data.DataRow DtRow in Tabla.Rows) {
                                Lfx.Data.Row Registro = (Lfx.Data.Row)DtRow;

                                string NombreCampoId = Lfx.Data.Field.GetNameOnly(this.Definicion.KeyColumn.Name);
                                int ItemId = Registro.Fields[NombreCampoId].ValueInt;

                                Lazaro.Pres.Spreadsheet.Row Reng = this.FormatRow(ItemId, Registro, Sheet, useFields);

                                Sheet.Rows.Add(Reng);
                        }

                        if (OrderColumn >= 0) {
                                if (m_GroupingColumnName != null) {
                                        Sheet.SortByGroupAndColumn(OrderColumn, true);
                                } else {
                                        if (OrderColumn >= 0)
                                                Sheet.Sort(OrderColumn, true);
                                }
                        }

                        return Res;
                }

                private void RefreshTimer_Tick(object sender, EventArgs e)
                {
                        RefreshTimer.Stop();
                        System.Windows.Forms.Application.DoEvents();
                        this.RefreshList();
                }

                private void FormularioListadoBase_FormClosing(object sender, FormClosingEventArgs e)
                {
                        RefreshTimer.Stop();
                        CancelFill = true;
                }
        }
}