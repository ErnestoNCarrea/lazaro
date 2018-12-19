using System.Windows.Forms;

namespace Lfc.Comprobantes.Facturas
{
        public class IvaVentas : Lfc.FormularioListado
        {
                protected internal Lfx.Types.DateRange m_Fecha = new Lfx.Types.DateRange("mes-1");
                protected internal int m_Sucursal, m_Anuladas = 1, m_PV = 0;
                protected internal string m_Letra = "*";

                public IvaVentas()
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.Comprobantes.Factura), Lbl.Sys.Permisos.Operaciones.Listar) == false) {
                                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                                this.Close();
                                return;
                        }

                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Comprobantes.ComprobanteFacturable),

                                TableName = "comprob",
                                KeyColumn = new Lazaro.Pres.Field("comprob.id_comprob", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                Joins = new qGen.JoinCollection() {
                                                new qGen.Join("personas", "comprob.id_cliente=personas.id_persona"),
                                                new qGen.Join("situaciones", "personas.id_situacion=situaciones.id_situacion"),
                                                new qGen.Join("documentos_tipos", "documentos_tipos.letra=comprob.tipo_fac")
                                },
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("comprob.fecha", "Fecha", Lfx.Data.InputFieldTypes.Date, 96),
				        new Lazaro.Pres.Field("comprob.tipo_fac", "Tipo", Lfx.Data.InputFieldTypes.Text, 40),
				        new Lazaro.Pres.Field("comprob.nombre", "Número", Lfx.Data.InputFieldTypes.Text, 140),
				        new Lazaro.Pres.Field("personas.nombre_visible", "Cliente", Lfx.Data.InputFieldTypes.Text, 300),
				        new Lazaro.Pres.Field("personas.cuit", Lbl.Sys.Config.Pais.ClavePersonasJuridicas.Nombre, Lfx.Data.InputFieldTypes.Text, 140),
                        new Lazaro.Pres.Field("personas.num_doc", "Documento", Lfx.Data.InputFieldTypes.Text, 120),
                        new Lazaro.Pres.Field("situaciones.nombrecorto AS situacion", "Cond. IVA", Lfx.Data.InputFieldTypes.Text, 100),
				        new Lazaro.Pres.Field("(comprob.totalreal-comprob.iva)*(1-comprob.anulada)*(documentos_tipos.direc_ctacte) AS gravado", "Neto", Lfx.Data.InputFieldTypes.Currency, 96),
                                        new Lazaro.Pres.Field("comprob.iva*(1-anulada)*(documentos_tipos.direc_ctacte) AS iva", "IVA", Lfx.Data.InputFieldTypes.Currency, 96),
				        new Lazaro.Pres.Field("comprob.totalreal*(1-anulada)*(documentos_tipos.direc_ctacte) AS total", "Total", Lfx.Data.InputFieldTypes.Currency, 96),
				        new Lazaro.Pres.Field("comprob.anulada", "Anulada", Lfx.Data.InputFieldTypes.Bool, 0),                                
			        },

                                OrderBy = "comprob.pv, comprob.numero"
                        };

                        this.Definicion.Columns["gravado"].TotalFunction = Lazaro.Pres.Spreadsheet.QuickFunctions.Sum;
                        this.Definicion.Columns["iva"].TotalFunction = Lazaro.Pres.Spreadsheet.QuickFunctions.Sum;
                        this.Definicion.Columns["total"].TotalFunction = Lazaro.Pres.Spreadsheet.QuickFunctions.Sum;

                        this.Contadores.Add(new Lfc.Contador("Total", Lui.Forms.DataTypes.Currency));

                        this.HabilitarFiltrar = true;
                        this.HabilitarBusqueda = false;
                        this.HabilitarCrear = false;
                }


                public override Lfx.Types.OperationResult OnFilter()
                {
                        Lfx.Types.OperationResult ResultadoFiltrar = base.OnFilter();

                        if (ResultadoFiltrar.Success == true) {
                                using (Lfc.Comprobantes.Filtros FormFiltros = new Lfc.Comprobantes.Filtros()) {
                                        FormFiltros.Connection = this.Connection;
                                        FormFiltros.EntradaTipo.TemporaryReadOnly = true;
                                        FormFiltros.EntradaTipo.TextKey = this.Definicion.ElementoTipo.ToString();
                                        FormFiltros.EntradaPv.Text = m_PV.ToString();
                                        FormFiltros.EntradaLetra.TextKey = m_Letra;
                                        FormFiltros.EntradaSucursal.ValueInt = m_Sucursal;
                                        FormFiltros.EntradaFormaPago.TemporaryReadOnly = true;
                                        FormFiltros.EntradaFormaPago.ValueInt = 0;
                                        FormFiltros.EntradaCliente.TemporaryReadOnly = true;
                                        FormFiltros.EntradaCliente.ValueInt = 0;
                                        FormFiltros.EntradaVendedor.TemporaryReadOnly = true;
                                        FormFiltros.EntradaVendedor.ValueInt = 0;
                                        FormFiltros.EntradaFechas.Rango = m_Fecha;
                                        FormFiltros.EntradaEstado.TemporaryReadOnly = true;
                                        FormFiltros.EntradaEstado.TextKey = "3";
                                        FormFiltros.EntradaAnuladas.TextKey = m_Anuladas.ToString();
                                        FormFiltros.EntradaMontoDesde.TemporaryReadOnly = true;
                                        FormFiltros.EntradaMontoHasta.TemporaryReadOnly = true;
                                        FormFiltros.Owner = this;
                                        FormFiltros.ShowDialog();

                                        if (FormFiltros.DialogResult == DialogResult.OK) {
                                                m_Sucursal = FormFiltros.EntradaSucursal.ValueInt;
                                                m_Fecha = FormFiltros.EntradaFechas.Rango;
                                                m_Anuladas = Lfx.Types.Parsing.ParseInt(FormFiltros.EntradaAnuladas.TextKey);
                                                m_PV = Lfx.Types.Parsing.ParseInt(FormFiltros.EntradaPv.Text);
                                                this.Definicion.ElementoTipo = Lbl.Instanciador.InferirTipo(FormFiltros.EntradaTipo.TextKey);
                                                m_Letra = FormFiltros.EntradaLetra.TextKey;

                                                this.RefreshList();
                                                ResultadoFiltrar.Success = true;
                                        } else {
                                                ResultadoFiltrar.Success = false;
                                        }
                                }
                        }

                        return ResultadoFiltrar;
                }


                public override void OnExport(string filename, FormatoExportar formato)
                {
                        System.Data.DataTable Tabla = this.Connection.Select(this.SelectCommand());

                        Lfx.Types.OperationProgress Progreso = new Lfx.Types.OperationProgress("Generando archivos", "Leyendo información de los comprobantes");
                        Progreso.Max = Tabla.Rows.Count * 3;
                        Progreso.Begin();

                        var ArchivoCitiVentas = new Lbl.Archivos.Salida.CitiVentas(Progreso);
                        foreach (System.Data.DataRow Registro in Tabla.Rows) {
                                Lbl.Comprobantes.ComprobanteFacturable ComprobanteFacturable = new Lbl.Comprobantes.ComprobanteFacturable(this.Connection, System.Convert.ToInt32(Registro["id_comprob"]));
                                if (!ComprobanteFacturable.Anulado) {
                                        ArchivoCitiVentas.Comprobantes.Add(ComprobanteFacturable);

                                }
                                Progreso.Advance(1);
                        }

                        var ArchivoCitiAlicuotas = new Lbl.Archivos.Salida.CitiVentasAlicuotas(ArchivoCitiVentas);

                        var NombreArchivoBase = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filename), System.IO.Path.GetFileNameWithoutExtension(filename));

                        Progreso.Description = "Generando el archivo de ventas";
                        ArchivoCitiVentas.Escribir(NombreArchivoBase + " Ventas.txt");

                        Progreso.Description = "Generando el archivo de alícuotas";
                        ArchivoCitiAlicuotas.Escribir(NombreArchivoBase + " Ventas Alícuotas.txt");

                        Progreso.End();

                        base.OnExport(filename, formato);
                }


                public override void RefreshList()
                {
                        string Titulo;
                        if (m_Fecha.HasRange)
                                Titulo = "Libro IVA Ventas " + m_Fecha.From.ToString(Lfx.Types.Formatting.DateTime.MonthAndYearPattern);
                        else
                                Titulo = "Libro IVA Ventas";

                        Titulo += " - " + Lbl.Sys.Config.Empresa.RazonSocial;

                        if(Lbl.Sys.Config.Empresa.ClaveTributaria != null)
                                Titulo += " " + Lbl.Sys.Config.Empresa.ClaveTributaria.ToString();
                        this.Text = Titulo;

                        base.RefreshList();
                }


                protected override void OnBeginRefreshList()
                {
                        this.CustomFilters.Clear();
                        this.CustomFilters.AddWithValue("comprob.compra", 0);

                        switch (this.Definicion.ElementoTipo.ToString()) {
                                case "Lbl.Comprobantes.NotaDeCredito":
                                        if (m_Letra == "*")
                                                this.CustomFilters.AddWithValue("comprob.tipo_fac", qGen.ComparisonOperators.In, new qGen.SqlExpression("SELECT letra FROM documentos_tipos WHERE tipo='Lbl.Comprobantes.NotaDeCredito'"));
                                        else
                                                this.CustomFilters.AddWithValue("comprob.tipo_fac", "NC" + m_Letra);
                                        break;

                                case "Lbl.Comprobantes.NotaDeDebito":
                                        if (m_Letra == "*")
                                                this.CustomFilters.AddWithValue("comprob.tipo_fac", qGen.ComparisonOperators.In, new qGen.SqlExpression("SELECT letra FROM documentos_tipos WHERE tipo='Lbl.Comprobantes.NotaDeDebito'"));
                                        else
                                                this.CustomFilters.AddWithValue("comprob.tipo_fac", "ND" + m_Letra);
                                        break;

                                case "Lbl.Comprobantes.Factura":
                                        this.Definicion.Columns["pendiente"].Visible = true;
                                        if (m_Letra == "*")
                                                this.CustomFilters.AddWithValue("comprob.tipo_fac", qGen.ComparisonOperators.In, new qGen.SqlExpression("SELECT letra FROM documentos_tipos WHERE tipo='Lbl.Comprobantes.Factura'"));
                                        else
                                                this.CustomFilters.AddWithValue("comprob.tipo_fac", "F" + m_Letra);
                                        break;

                                case "Lbl.Comprobantes.ComprobanteFacturable":
                                        if (m_Letra == "*")
                                                this.CustomFilters.AddWithValue("comprob.tipo_fac", qGen.ComparisonOperators.In, new qGen.SqlExpression("SELECT letra FROM documentos_tipos WHERE tipobase='Lbl.Comprobantes.ComprobanteFacturable'"));
                                        else
                                                this.CustomFilters.AddWithValue("comprob.tipo_fac", qGen.ComparisonOperators.In, new string[] { "F" + m_Letra, "NC" + m_Letra, "ND" + m_Letra });
                                        break;

                                case "Lbl.Comprobantes.Presupuesto":
                                        this.CustomFilters.AddWithValue("comprob.tipo_fac", "PS");
                                        break;

                                case "Lbl.Comprobantes.Remito":
                                        this.CustomFilters.AddWithValue("comprob.tipo_fac", "R");
                                        break;

                                case "Lbl.Comprobantes.Ticket":
                                        this.CustomFilters.AddWithValue("comprob.tipo_fac", "T");
                                        break;

                                default:
                                        throw new System.NotImplementedException("No se reconoce el tipo de comprobante " + this.Definicion.ElementoTipo.ToString());
                        }

                        if (m_Sucursal > 0)
                                this.CustomFilters.AddWithValue("comprob.id_sucursal", m_Sucursal);

                        if (m_PV > 0)
                                this.CustomFilters.AddWithValue("comprob.pv", m_PV);

                        if (m_Fecha.HasRange)
                                this.CustomFilters.AddWithValue("(comprob.fecha BETWEEN '" + Lfx.Types.Formatting.FormatDateSql(m_Fecha.From) + " 00:00:00' AND '" + Lfx.Types.Formatting.FormatDateSql(m_Fecha.To) + " 23:59:59')");

                        this.CustomFilters.AddWithValue("comprob.impresa", 1);

                        this.SetupListviewColumns();

                        base.OnBeginRefreshList();
                }

                protected override Lfx.Types.OperationResult OnEdit(int itemId)
                {
                        string Tipo = this.Connection.FieldString("SELECT tipo_fac FROM comprob WHERE id_comprob=" + itemId.ToString());
                        Lfx.Workspace.Master.RunTime.Execute("EDITAR " + Tipo + " " + itemId.ToString());
                        return new Lfx.Types.SuccessOperationResult();
                }

                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
                {
                        if (row.Fields["comprob.anulada"].ValueInt != 0) {
                                // Si está anulada, le cambio el nombre
                                item.SubItems["personas.nombre_visible"].Text = "Anulada";
                        }

                        base.OnItemAdded(item, row);
                }


                protected override void OnEndRefreshList()
                {
                        qGen.Select SelTotalFac = this.SelectCommand("SUM", "comprob.total");
                        SelTotalFac.WhereClause.AddWithValue("comprob.anulada", 0);
                        SelTotalFac.WhereClause.AddWithValue("comprob.tipo_fac", qGen.ComparisonOperators.NotIn, new string[] { "NCA", "NCB", "NCC", "NCE", "NCM" });
                        decimal TotalFac = this.Connection.FieldDecimal(SelTotalFac);

                        qGen.Select SelTotalCred = this.SelectCommand("SUM", "comprob.total");
                        SelTotalCred.WhereClause.AddWithValue("comprob.anulada", 0);
                        SelTotalCred.WhereClause.AddWithValue("comprob.tipo_fac", qGen.ComparisonOperators.In, new string[] { "NCA", "NCB", "NCC", "NCE", "NCM" });
                        decimal TotalCred = this.Connection.FieldDecimal(SelTotalCred);

                        this.Contadores[0].SetValue(TotalFac - TotalCred);

                        base.OnEndRefreshList();
                }


                protected override Lazaro.Pres.Spreadsheet.Row FormatRow(int itemId, Lfx.Data.Row row, Lazaro.Pres.Spreadsheet.Sheet sheet, Lazaro.Pres.FieldCollection useFields)
                {
                        Lazaro.Pres.Spreadsheet.Row Res = base.FormatRow(itemId, row, sheet, useFields);

                        switch (row.Fields["tipo_fac"].ValueString) {
                                case "NCA":
                                case "NCB":
                                case "NCC":
                                case "NCE":
                                case "NCM":
                                        row.Fields["gravado"].Value = -row.Fields["gravado"].ValueDecimal;
                                        row.Fields["total"].Value = -row.Fields["total"].ValueDecimal;
                                        break;
                        }

                        if (row.Fields["anulada"].ValueInt != 0)
                                Res.Cells[4].Content = "ANULADA";

                        return Res;
                }
        }
}