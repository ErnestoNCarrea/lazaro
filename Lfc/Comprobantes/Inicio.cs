using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Comprobantes
{
        public partial class Inicio : Lfc.FormularioListado
        {
                protected internal Lfx.Types.DateRange m_Fechas = new Lfx.Types.DateRange("mes-0");
                protected internal string m_Estado = "0";
                protected internal int m_Sucursal, m_FormaPago, m_Cliente, m_Vendedor, m_Anuladas = 1, m_PV = 0;
                protected internal decimal m_MontoDesde = 0, m_MontoHasta = 0;


                public string Letra { get; set; }

                public Inicio()
                {
                        this.Letra = "*";

                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Comprobantes.ComprobanteConArticulos),

                                TableName = "comprob",
                                KeyColumn = new Lazaro.Pres.Field("comprob.id_comprob", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                Joins = new qGen.JoinCollection() { new qGen.Join("personas", "comprob.id_cliente=personas.id_persona") },
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("comprob.tipo_fac", "Tipo", Lfx.Data.InputFieldTypes.Text, 40),
				        new Lazaro.Pres.Field("comprob.nombre", "Número", Lfx.Data.InputFieldTypes.Text, 120),
				        new Lazaro.Pres.Field("comprob.fecha", "Fecha", Lfx.Data.InputFieldTypes.Date, 96),
				        new Lazaro.Pres.Field("personas.nombre_visible", "Cliente", Lfx.Data.InputFieldTypes.Text, 320),
				        new Lazaro.Pres.Field("comprob.total", "Total", Lfx.Data.InputFieldTypes.Currency, 96),
				        new Lazaro.Pres.Field("comprob.impresa", "Impresa", Lfx.Data.InputFieldTypes.Bool, 0),
				        new Lazaro.Pres.Field("comprob.anulada", "Anulada", Lfx.Data.InputFieldTypes.Bool, 0),
				        new Lazaro.Pres.Field("comprob.total-comprob.cancelado AS pendiente", "Pendiente", Lfx.Data.InputFieldTypes.Currency, 96),
				        new Lazaro.Pres.Field("comprob.id_vendedor", "Vendedor", Lfx.Data.InputFieldTypes.Relation, 160),
				        new Lazaro.Pres.Field("comprob.obs", "Obs", Lfx.Data.InputFieldTypes.Memo, 160),
                                
			        },

                                ExtraSearchColumns = new Lazaro.Pres.FieldCollection() {
                                        new Lazaro.Pres.Field("series", "Series")
                                },

                                OrderBy = "comprob.id_comprob DESC"
                        };

                        this.Definicion.Columns["total"].TotalFunction = Lazaro.Pres.Spreadsheet.QuickFunctions.Sum;
                        this.Definicion.Columns["pendiente"].TotalFunction = Lazaro.Pres.Spreadsheet.QuickFunctions.Sum;

                        this.Contadores.Add(new Lfc.Contador("Total", Lui.Forms.DataTypes.Currency));
                        this.Contadores.Add(new Lfc.Contador("Pendiente", Lui.Forms.DataTypes.Currency));

                        this.HabilitarFiltrar = true;
                }


                public Inicio(string comando)
                        : this()
                {
                        this.Letra = comando;
                }


                protected override void OnLoad(EventArgs e)
                {
                        base.OnLoad(e);
                        if (Lfx.Workspace.Master != null)
                                m_Sucursal = Lfx.Workspace.Master.CurrentConfig.Empresa.SucursalActual;
                }


                public override Lfx.Types.OperationResult OnFilter()
                {
                        Lfx.Types.OperationResult ResultadoFiltrar = base.OnFilter();

                        if (ResultadoFiltrar.Success == true) {
                                using (Comprobantes.Filtros FormFiltros = new Comprobantes.Filtros()) {
                                        FormFiltros.Connection = this.Connection;
                                        FormFiltros.EntradaTipo.TextKey = this.Definicion.ElementoTipo.ToString();
                                        FormFiltros.EntradaPv.Text = m_PV.ToString();
                                        FormFiltros.EntradaLetra.TextKey = Letra;
                                        FormFiltros.EntradaSucursal.ValueInt = m_Sucursal;
                                        FormFiltros.EntradaFormaPago.ValueInt = m_FormaPago;
                                        FormFiltros.EntradaCliente.ValueInt = m_Cliente;
                                        FormFiltros.EntradaVendedor.ValueInt = m_Vendedor;
                                        FormFiltros.EntradaFechas.Rango = m_Fechas;
                                        FormFiltros.EntradaEstado.TextKey = m_Estado;
                                        FormFiltros.EntradaAnuladas.ValueInt = m_Anuladas;
                                        FormFiltros.EntradaMontoDesde.ValueDecimal = m_MontoDesde;
                                        FormFiltros.EntradaMontoHasta.ValueDecimal = m_MontoHasta;
                                        FormFiltros.Owner = this;
                                        FormFiltros.ShowDialog();

                                        if (FormFiltros.DialogResult == DialogResult.OK) {
                                                m_Sucursal = FormFiltros.EntradaSucursal.ValueInt;
                                                m_FormaPago = FormFiltros.EntradaFormaPago.ValueInt;
                                                m_Cliente = FormFiltros.EntradaCliente.ValueInt;
                                                m_Vendedor = FormFiltros.EntradaVendedor.ValueInt;
                                                m_Fechas = FormFiltros.EntradaFechas.Rango;
                                                m_Estado = FormFiltros.EntradaEstado.TextKey;
                                                m_Anuladas = FormFiltros.EntradaAnuladas.ValueInt;
                                                m_PV = FormFiltros.EntradaPv.ValueInt;
                                                m_MontoDesde = FormFiltros.EntradaMontoDesde.ValueDecimal;
                                                m_MontoHasta = FormFiltros.EntradaMontoHasta.ValueDecimal;
                                                this.Definicion.ElementoTipo = Lbl.Instanciador.InferirTipo(FormFiltros.EntradaTipo.TextKey);
                                                Letra = FormFiltros.EntradaLetra.TextKey;

                                                this.RefreshList();
                                                ResultadoFiltrar.Success = true;
                                        } else {
                                                ResultadoFiltrar.Success = false;
                                        }
                                }
                        }

                        return ResultadoFiltrar;
                }

                public override Lfx.Types.OperationResult OnCreate()
                {
                        Lfx.Workspace.Master.RunTime.Execute("CREAR " + this.Definicion.ElementoTipo.ToString() + " " + this.Letra);
                        return new Lfx.Types.SuccessOperationResult();
                }

                public override string SearchText
                {
                        get
                        {
                                return base.SearchText;
                        }
                        set
                        {
                                if (value == null) {
                                        base.SearchText = null;
                                } else if (System.Text.RegularExpressions.Regex.IsMatch(value, @"^[0-3]\d(-|/)[0-1]\d(-|/)(\d{2}|\d{4})$")) {
                                        this.SearchText = Lfx.Types.Formatting.FormatDateTimeSql(value).ToString();
                                } else if (System.Text.RegularExpressions.Regex.IsMatch(value, @"^[0-3]\d(-|/)[0-1]\d$")) {
                                        this.SearchText = Lfx.Types.Formatting.FormatDateTimeSql(value + System.DateTime.Now.ToString("yyyy")).ToString();
                                } else {
                                        base.SearchText = value;
                                }
                        }
                }

                protected override void OnBeginRefreshList()
                {
                        this.CustomFilters.Clear();
                        this.CustomFilters.AddWithValue("compra", 0);

                        switch (this.Definicion.ElementoTipo.ToString()) {
                                case "Lbl.Comprobantes.NotaDeCredito":
                                        this.Definicion.Columns["pendiente"].Visible = true;
                                        if (Letra == "*")
                                                this.CustomFilters.AddWithValue("comprob.tipo_fac", qGen.ComparisonOperators.In, new string[] { "NCA", "NCB", "NCC", "NCE", "NCM" });
                                        else
                                                this.CustomFilters.AddWithValue("comprob.tipo_fac", "NC" + Letra);
                                        break;

                                case "Lbl.Comprobantes.NotaDeDebito":
                                        this.Definicion.Columns["pendiente"].Visible = true;
                                        if (Letra == "*")
                                                this.CustomFilters.AddWithValue("comprob.tipo_fac", qGen.ComparisonOperators.In, new string[] { "NDA", "NDB", "NDC", "NDE", "NDM" });
                                        else
                                                this.CustomFilters.AddWithValue("comprob.tipo_fac", "ND" + Letra);
                                        break;

                                case "Lbl.Comprobantes.Factura":
                                        this.Definicion.Columns["pendiente"].Visible = true;
                                        if (Letra == "*")
                                                this.CustomFilters.AddWithValue("comprob.tipo_fac", qGen.ComparisonOperators.In, new string[] { "FA", "FB", "FC", "FE", "FM" });
                                        else
                                                this.CustomFilters.AddWithValue("comprob.tipo_fac", "F" + Letra);
                                        break;

                                case "Lbl.Comprobantes.Presupuesto":
                                        this.Definicion.Columns["pendiente"].Visible = false;
                                        this.CustomFilters.AddWithValue("comprob.tipo_fac", "PS");
                                        break;

                                case "Lbl.Comprobantes.Remito":
                                        this.Definicion.Columns["pendiente"].Visible = false;
                                        this.CustomFilters.AddWithValue("comprob.tipo_fac", "R");
                                        break;

                                case "Lbl.Comprobantes.Ticket":
                                        this.Definicion.Columns["pendiente"].Visible = true;
                                        this.CustomFilters.AddWithValue("comprob.tipo_fac", "T");
                                        break;

                                case "Lbl.Comprobantes.ComprobanteFacturable":
                                default:
                                        this.Definicion.Columns["pendiente"].Visible = true;
                                        if (Letra == "*")
                                                this.CustomFilters.AddWithValue("comprob.tipo_fac", qGen.ComparisonOperators.In, new string[] { "FA", "FB", "FC", "FE", "FM", "NCA", "NCB", "NCC", "NCE", "NCM", "NDA", "NDB", "NDC", "NDE", "NDM" });
                                        else
                                                this.CustomFilters.AddWithValue("comprob.tipo_fac", qGen.ComparisonOperators.In, new string[] { "F" + Letra, "NC" + Letra, "ND" + Letra });
                                        break;
                        }

                        if (m_Vendedor > 0)
                                this.CustomFilters.AddWithValue("comprob.id_vendedor", m_Vendedor);

                        if (SearchText == string.Empty) {
                                if (m_Sucursal > 0)
                                        this.CustomFilters.AddWithValue("comprob.id_sucursal", m_Sucursal);

                                if (m_FormaPago > 0)
                                        this.CustomFilters.AddWithValue("comprob.id_formapago", m_FormaPago);

                                if (m_Cliente > 0)
                                        this.CustomFilters.AddWithValue("comprob.id_cliente", m_Cliente);

                                if (m_PV > 0)
                                        this.CustomFilters.AddWithValue("comprob.pv", m_PV);

                                if (m_Fechas.HasRange)
                                        this.CustomFilters.AddWithValue("(comprob.fecha BETWEEN '" + Lfx.Types.Formatting.FormatDateSql(m_Fechas.From) + " 00:00:00' AND '" + Lfx.Types.Formatting.FormatDateSql(m_Fechas.To) + " 23:59:59')");
                        }

                        switch (m_Estado) {
                                case "0":
                                        // Nada
                                        break;
                                case "1":
                                        this.CustomFilters.AddWithValue("comprob.impresa=1 AND (comprob.cancelado>=comprob.total) AND comprob.total>0");
                                        break;
                                case "2":
                                        this.CustomFilters.AddWithValue("comprob.impresa=1 AND (comprob.cancelado<comprob.total) AND comprob.total>0");
                                        break;
                                case "3":
                                        this.CustomFilters.AddWithValue("comprob.impresa", 1);
                                        break;
                        }

                        if (m_Anuladas == 0)
                                this.CustomFilters.AddWithValue("comprob.anulada", 0);

                        if (m_MontoDesde != 0 && m_MontoHasta != 0)
                                this.CustomFilters.AddWithValue("comprob.total BETWEEN " + Lfx.Types.Formatting.FormatCurrencySql(m_MontoDesde) + " AND " + Lfx.Types.Formatting.FormatCurrencySql(m_MontoHasta));
                        else if (m_MontoDesde != 0)
                                this.CustomFilters.AddWithValue("comprob.total>=" + Lfx.Types.Formatting.FormatCurrencySql(m_MontoDesde));
                        else if (m_MontoHasta != 0)
                                this.CustomFilters.AddWithValue("comprob.total<=" + Lfx.Types.Formatting.FormatCurrencySql(m_MontoHasta));

                        this.SetupListviewColumns();

                        base.OnBeginRefreshList();
                }

                protected override Lfx.Types.OperationResult OnEdit(int itemId)
                {
                        string sTipo = this.Connection.FieldString("SELECT tipo_fac FROM comprob WHERE id_comprob=" + itemId.ToString());
                        Lfx.Workspace.Master.RunTime.Execute("EDITAR " + sTipo + " " + itemId.ToString());
                        return new Lfx.Types.SuccessOperationResult();
                }

                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
                {
                        if (row.Fields["anulada"].ValueInt == 0 && row.Fields["impresa"].ValueInt != 0) {
                                string TipoComprob = row.Fields["tipo_fac"].ValueString;
                                if (TipoComprob.Length >= 2 && TipoComprob.Substring(0, 2) == "NC")
                                        this.Contadores[0].AddValue(-row.Fields["total"].ValueDecimal);
                                else
                                        this.Contadores[0].AddValue(row.Fields["total"].ValueDecimal);
                        }

                        if (row.Fields["anulada"].ValueInt != 0) {
                                // Si está anulada, la tacho
                                item.Font = new Font(item.Font, FontStyle.Strikeout);
                                item.ForeColor = System.Drawing.Color.Black;
                        } else if (row.Fields["impresa"].ValueInt == 0) {
                                // No impresa, en gris
                                item.ForeColor = System.Drawing.Color.Gray;
                        } else if (this.Definicion.ElementoTipo != typeof(Lbl.Comprobantes.Presupuesto) && row.Fields["pendiente"].ValueDecimal > 0) {
                                // Impaga, en rojo
                                this.Contadores[1].AddValue(row.Fields["pendiente"].ValueDecimal);
                                item.ForeColor = System.Drawing.Color.Red;
                        } else {
                                item.ForeColor = System.Drawing.Color.Black;
                        }

                        int IdVendedor = row.Fields["id_vendedor"].ValueInt;
                        if (IdVendedor > 0) {
                                Lfx.Data.Row Vend = Lfx.Workspace.Master.Tables["personas"].FastRows[IdVendedor];
                                if (Vend != null)
                                        item.SubItems["comprob.id_vendedor"].Text = Vend.Fields["nombre_visible"].Value.ToString();
                        }
                }
        }
}