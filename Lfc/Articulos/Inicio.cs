using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Articulos
{
        public partial class Inicio : Lfc.FormularioListado
        {
                protected internal decimal m_PvpDesde = 0, m_PvpHasta = 0;
                protected internal Lbl.Personas.Persona m_Proveedor = null;
                protected internal Lbl.Articulos.Marca m_Marca = null;
                protected internal Lbl.Articulos.Categoria m_Categoria = null;
                protected internal Lbl.Articulos.Rubro m_Rubro = null;
                protected internal Lbl.Articulos.Situacion m_Situacion = null;
                private string m_Stock = "*";

                public Inicio()
                {
                        this.InitializeComponent();

                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Articulos.Articulo),

                                TableName = "articulos",
                                KeyColumn = new Lazaro.Pres.Field("articulos.id_articulo", "Cód.", Lfx.Data.InputFieldTypes.Serial, 80),
                                DetailColumnName = "nombre",
                                Joins = this.FixedJoins(),
                                OrderBy = "articulos.nombre",
                                Columns = new Lazaro.Pres.FieldCollection()
                                {
				        new Lazaro.Pres.Field("articulos.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
                                        new Lazaro.Pres.Field("articulos.costo", "Costo", Lfx.Data.InputFieldTypes.Currency, 96),
				        new Lazaro.Pres.Field("articulos.pvp", "PVP", Lfx.Data.InputFieldTypes.Currency, 96),
				        new Lazaro.Pres.Field("articulos.stock_actual", "Stock Act", Lfx.Data.InputFieldTypes.Numeric, 96),
				        new Lazaro.Pres.Field("articulos.stock_minimo", "Stock Mín", Lfx.Data.InputFieldTypes.Numeric, 96),
				        new Lazaro.Pres.Field("articulos.pedido", "Pedidos", Lfx.Data.InputFieldTypes.Numeric, 96),
				        new Lazaro.Pres.Field("articulos.apedir", "A Pedir", Lfx.Data.InputFieldTypes.Numeric, 96),
				        new Lazaro.Pres.Field("articulos.destacado", "Destacado", Lfx.Data.InputFieldTypes.Bool, 0),
				        new Lazaro.Pres.Field("articulos.codigo1", "Código 1", Lfx.Data.InputFieldTypes.Text, 120),
				        new Lazaro.Pres.Field("articulos.codigo2", "Código 2", Lfx.Data.InputFieldTypes.Text, 120),
				        new Lazaro.Pres.Field("articulos.codigo3", "Código 3", Lfx.Data.InputFieldTypes.Text, 120),
                                        new Lazaro.Pres.Field("articulos_categorias.nombre AS categorias_nombre", "Categoría", Lfx.Data.InputFieldTypes.Text, 120)
			        },

                                ExtraSearchColumns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("articulos.codigo4", "Código 4", Lfx.Data.InputFieldTypes.Text, 0),
				        new Lazaro.Pres.Field("articulos.descripcion", "Descripción", Lfx.Data.InputFieldTypes.Memo, 0),
				        new Lazaro.Pres.Field("articulos.descripcion2", "Descripción Extendida", Lfx.Data.InputFieldTypes.Memo, 0),
				        new Lazaro.Pres.Field("articulos.obs", "Observaciones", Lfx.Data.InputFieldTypes.Memo, 0)
			        },

                                Filters = new Lazaro.Pres.Filters.FilterCollection()
                                {
                                        new Lazaro.Pres.Filters.RelationFilter("Rubro", new Lazaro.Orm.Data.Relation("id_rubro", "articulos_rubros", "id_rubro")),
                                        new Lazaro.Pres.Filters.RelationFilter("Categoría", new Lazaro.Orm.Data.Relation("id_categoria", "articulos_categorias", "id_categoria")),
                                        new Lazaro.Pres.Filters.RelationFilter("Marca", new Lazaro.Orm.Data.Relation("id_marca", "marcas", "id_marca")),
                                        new Lazaro.Pres.Filters.RelationFilter("Proveedor", new Lazaro.Orm.Data.Relation("id_proveedor", "personas", "id_persona", "nombre_visible")),
                                        new Lazaro.Pres.Filters.RelationFilter("Situación", new Lazaro.Orm.Data.Relation("id_situacion", "articulos_situaciones", "id_situacion")),
                                        new Lazaro.Pres.Filters.SetFilter("Existencias", "stock_actual", new string[] { "Cualquiera|*", "En existencia|cs", "Sin existencia|ss", "Con faltante|faltante", "Con faltante (incluyendo pedidos)|faltanteip", "Con pedidos|pedido", "A pedir|apedir" }, "*")
                                }
                        };

                        this.Contadores.Add(new Contador("Costo", Lui.Forms.DataTypes.Currency, "$", null));
                        this.Contadores.Add(new Contador("PVP", Lui.Forms.DataTypes.Currency, "$", null));

                        this.Definicion.Columns["pedido"].TotalFunction = Lazaro.Pres.Spreadsheet.QuickFunctions.Sum;
                        this.Definicion.Columns["apedir"].TotalFunction = Lazaro.Pres.Spreadsheet.QuickFunctions.Sum;
                        this.Definicion.Columns["articulos.stock_actual"].TotalFunction = Lazaro.Pres.Spreadsheet.QuickFunctions.Sum;

                        this.HabilitarFiltrar = true;
                }


                public Inicio(string comando)
                        : this()
                {
                        switch(comando){
                                case "APEDIR":
                                        this.Stock = "apedir";
                                        break;
                                case "PEDIDOS":
                                        this.Stock = "pedido";
                                        break;
                        }
                }


                public string Stock
                {
                        get
                        {
                                return m_Stock;
                        }
                        set
                        {
                                this.Definicion.Filters["stock_actual"].Value = value;
                                m_Stock = value;
                        }
                }


                private qGen.JoinCollection FixedJoins()
                {
                        return new qGen.JoinCollection() { 
                                new qGen.Join("articulos_categorias", "articulos_categorias.id_categoria=articulos.id_categoria")
                        };
                }

                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
                {
                        if (row.Fields["destacado"].ValueInt != 0)
                                item.Font = new Font(item.Font, FontStyle.Bold);

                        if (item.SubItems.ContainsKey("stock_actual")) {
                                if (row.Fields["stock_actual"].ValueDecimal < row.Fields["stock_minimo"].ValueDecimal) {
                                        //Faltante
                                        item.UseItemStyleForSubItems = false;
                                        item.SubItems["stock_actual"].BackColor = System.Drawing.Color.Pink;
                                        item.SubItems["stock_actual"].BackColor = System.Drawing.Color.Pink;
                                }
                        }

                        if (item.SubItems.ContainsKey("apedir")) {
                                if (row.Fields["apedir"].ValueDecimal > 0)
                                        item.SubItems["apedir"].Text = "-";
                                else
                                        item.SubItems["apedir"].BackColor = System.Drawing.Color.LightPink;
                        }
                }

                protected override void OnBeginRefreshList()
                {
                        this.CustomFilters.Clear();

                        if (m_Proveedor != null)
                                this.CustomFilters.Add(new qGen.ComparisonCondition("articulos.id_proveedor", m_Proveedor.Id));

                        if (m_Marca != null)
                                this.CustomFilters.Add(new qGen.ComparisonCondition("articulos.id_marca", m_Marca.Id));

                        if (m_Categoria != null)
                                this.CustomFilters.Add(new qGen.ComparisonCondition("articulos.id_categoria", m_Categoria.Id));

                        if (m_Rubro != null)
                                this.CustomFilters.Add(new qGen.ComparisonCondition("articulos.id_categoria", qGen.ComparisonOperators.In, new qGen.SqlExpression("SELECT id_categoria FROM articulos_categorias WHERE id_rubro=" + m_Rubro.Id.ToString())));

                        if (m_PvpDesde != 0)
                                this.CustomFilters.Add(new qGen.ComparisonCondition("articulos.pvp", qGen.ComparisonOperators.GreaterOrEqual, m_PvpDesde));
                        if (m_PvpHasta != 0)
                                this.CustomFilters.Add(new qGen.ComparisonCondition("articulos.pvp", qGen.ComparisonOperators.LessOrEqual, m_PvpHasta));

                        if (m_Situacion != null && this.Definicion.Columns[3].Name != "articulos_stock.cantidad") {
                                this.CustomFilters.Add(new qGen.ComparisonCondition("articulos_stock.id_situacion", m_Situacion.Id));
                                this.CustomFilters.Add(new qGen.ComparisonCondition("articulos_stock.cantidad", qGen.ComparisonOperators.NotEqual, 0));
                                this.Definicion.Joins = this.FixedJoins();
                                this.Definicion.Joins.Add(new qGen.Join("articulos_stock", "articulos.id_articulo=articulos_stock.id_articulo"));
                                this.Definicion.Columns[3].Name = "articulos_stock.cantidad";
                                this.SetupListviewColumns();
                        } else if (this.Definicion.Columns[3].Name != "articulos.stock_actual") {
                                this.Definicion.Joins = this.FixedJoins();
                                this.Definicion.Columns[3].Name = "articulos.stock_actual";
                                this.SetupListviewColumns();
                        }

                        switch (m_Stock) {
                                case "cs":
                                        this.CustomFilters.Add(new qGen.ComparisonCondition("articulos.stock_actual", qGen.ComparisonOperators.GreaterThan, 0));
                                        break;

                                case "ss":
                                        this.CustomFilters.Add(new qGen.ComparisonCondition("articulos.stock_actual", qGen.ComparisonOperators.LessOrEqual, 0));
                                        break;

                                case "faltante":
                                        this.CustomFilters.AddWithValue("articulos.stock_actual", qGen.ComparisonOperators.LessThan, new qGen.SqlExpression("articulos.stock_minimo"));
                                        break;

                                case "faltanteip":
                                        this.CustomFilters.Add(new qGen.ComparisonCondition("articulos.stock_actual+articulos.pedido", qGen.ComparisonOperators.LessThan, new qGen.SqlExpression("articulos.stock_minimo")));
                                        break;

                                case "apedir":
                                        this.CustomFilters.Add(new qGen.ComparisonCondition("articulos.apedir", qGen.ComparisonOperators.GreaterThan, 0));
                                        break;

                                case "pedido":
                                        this.CustomFilters.Add(new qGen.ComparisonCondition("pedido", qGen.ComparisonOperators.GreaterThan, 0));
                                        break;
                        }

                        base.OnBeginRefreshList();
                }

                protected override void OnEndRefreshList()
                {
                        string SelectValorizacion = "SELECT SUM(costo*stock_actual) FROM articulos";
                        if (this.Definicion.Joins != null && this.Definicion.Joins.Count > 0) {
                                foreach (var Jo in this.Definicion.Joins) {
                                        SelectValorizacion += this.Connection.Factory.Formatter.SqlText(Jo);
                                }
                        }
                        if (this.CustomFilters.Count > 0)
                                SelectValorizacion += " WHERE " + Lfx.Workspace.Master.Formatter.SqlText(this.CustomFilters);
                        this.Contadores[0].Total = this.Connection.FieldDecimal(SelectValorizacion);

                        SelectValorizacion = "SELECT SUM(pvp*stock_actual) FROM articulos";
                        if (this.Definicion.Joins != null && this.Definicion.Joins.Count > 0) {
                                foreach (qGen.Join Jo in this.Definicion.Joins) {
                                        SelectValorizacion += this.Connection.Factory.Formatter.SqlText(Jo);
                                }
                        }
                        if (this.CustomFilters.Count > 0)
                                SelectValorizacion += " WHERE " + this.Connection.Factory.Formatter.SqlText(this.CustomFilters);
                        this.Contadores[1].Total = this.Connection.FieldDecimal(SelectValorizacion);

                        base.OnEndRefreshList();
                }

                private void BotonCambioMasivoPrecios_Click(object sender, System.EventArgs e)
                {
                        var FormPrecios = new CambioMasivoPrecios();

                        foreach(ListViewItem Itm in this.Listado.Items) {
                                ListViewItem NuevoItm = FormPrecios.ListadoArticulos.Items.Add(Itm.SubItems["articulos.nombre"].Text);
                                NuevoItm.Tag = Itm.Text;
                                NuevoItm.SubItems.Add(Itm.SubItems["articulos.costo"].Text);
                                NuevoItm.SubItems.Add(Itm.SubItems["articulos.costo"].Text);
                                NuevoItm.SubItems.Add(Itm.SubItems["articulos.pvp"].Text);
                                NuevoItm.SubItems.Add(Itm.SubItems["articulos.pvp"].Text);
                        }

                        FormPrecios.ShowDialog();
                        this.RefreshList();
                }

                public override void OnFiltersChanged(Lazaro.Pres.Filters.FilterCollection filters)
                {
                        m_Rubro = filters["id_rubro"].Value as Lbl.Articulos.Rubro;
                        m_Categoria = filters["id_categoria"].Value as Lbl.Articulos.Categoria;
                        m_Marca = filters["id_marca"].Value as Lbl.Articulos.Marca;
                        m_Proveedor = filters["id_proveedor"].Value as Lbl.Personas.Persona;
                        m_Situacion = filters["id_situacion"].Value as Lbl.Articulos.Situacion;
                        m_Stock = filters["stock_actual"].Value as string;

                        base.OnFiltersChanged(filters);
                }
        }
}