namespace Lfc.Articulos
{
        public partial class Editar
        {
                private void InitializeComponent()
                {
                        this.Frame2 = new Lui.Forms.Frame();
                        this.EntradaPvpIva = new Lui.Forms.TextBox();
                        this.label23 = new Lui.Forms.Label();
                        this.EntradaCosto = new Lui.Forms.TextBox();
                        this.EntradaMargen = new Lui.Forms.ComboBox();
                        this.EntradaPvp = new Lui.Forms.TextBox();
                        this.BotonInfoCosto = new Lui.Forms.Button();
                        this.Label6 = new Lui.Forms.Label();
                        this.EntradaCaja = new Lcc.Entrada.CodigoDetalle();
                        this.Label8 = new Lui.Forms.Label();
                        this.EtiquetaAlicuota = new Lui.Forms.Label();
                        this.Label10 = new Lui.Forms.Label();
                        this.label17 = new Lui.Forms.Label();
                        this.EntradaUnidad = new Lui.Forms.ComboBox();
                        this.EntradaTipoDeArticulo = new Lui.Forms.ComboBox();
                        this.BotonReceta = new Lui.Forms.Button();
                        this.BotonUnidad = new Lui.Forms.Button();
                        this.label19 = new Lui.Forms.Label();
                        this.Label7 = new Lui.Forms.Label();
                        this.EntradaStockMinimo = new Lui.Forms.TextBox();
                        this.Label11 = new Lui.Forms.Label();
                        this.Label9 = new Lui.Forms.Label();
                        this.EntradaStockActual = new Lui.Forms.TextBox();
                        this.EtiquetaCodigo1 = new Lui.Forms.Label();
                        this.Label5 = new Lui.Forms.Label();
                        this.EntradaCodigo1 = new Lui.Forms.TextBox();
                        this.EntradaCodigo4 = new Lui.Forms.TextBox();
                        this.EntradaCodigo3 = new Lui.Forms.TextBox();
                        this.EntradaCodigo2 = new Lui.Forms.TextBox();
                        this.EtiquetaCodigo4 = new Lui.Forms.Label();
                        this.EtiquetaCodigo3 = new Lui.Forms.Label();
                        this.EtiquetaCodigo2 = new Lui.Forms.Label();
                        this.EntradaDestacado = new Lui.Forms.ComboBox();
                        this.EntradaWeb = new Lui.Forms.ComboBox();
                        this.EntradaModelo = new Lui.Forms.TextBox();
                        this.EntradaGarantia = new Lui.Forms.TextBox();
                        this.EntradaCategoria = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaMarca = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaDescripcion2 = new Lui.Forms.TextBox();
                        this.EntradaUrl = new Lui.Forms.TextBox();
                        this.EntradaDescripcion = new Lui.Forms.TextBox();
                        this.EntradaNombre = new Lui.Forms.TextBox();
                        this.EntradaSerie = new Lui.Forms.TextBox();
                        this.label20 = new Lui.Forms.Label();
                        this.Label2 = new Lui.Forms.Label();
                        this.Label13 = new Lui.Forms.Label();
                        this.Label15 = new Lui.Forms.Label();
                        this.Label3 = new Lui.Forms.Label();
                        this.Label4 = new Lui.Forms.Label();
                        this.Label1 = new Lui.Forms.Label();
                        this.Label18 = new Lui.Forms.Label();
                        this.Label16 = new Lui.Forms.Label();
                        this.Label12 = new Lui.Forms.Label();
                        this.Frame3 = new Lui.Forms.Frame();
                        this.PanelProducto = new Lui.Forms.Panel();
                        this.EntradaSeguimiento = new Lui.Forms.ComboBox();
                        this.label21 = new Lui.Forms.Label();
                        this.PanelServicio = new Lui.Forms.Panel();
                        this.label22 = new Lui.Forms.Label();
                        this.EntradaPeriodicidad = new Lui.Forms.ComboBox();
                        this.label14 = new Lui.Forms.Label();
                        this.EntradaProveedor = new Lcc.Entrada.CodigoDetalle();
                        this.Frame2.SuspendLayout();
                        this.Frame3.SuspendLayout();
                        this.PanelProducto.SuspendLayout();
                        this.PanelServicio.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // Frame2
                        // 
                        this.Frame2.Controls.Add(this.EntradaPvpIva);
                        this.Frame2.Controls.Add(this.label23);
                        this.Frame2.Controls.Add(this.EntradaCosto);
                        this.Frame2.Controls.Add(this.EntradaMargen);
                        this.Frame2.Controls.Add(this.EntradaPvp);
                        this.Frame2.Controls.Add(this.BotonInfoCosto);
                        this.Frame2.Controls.Add(this.Label6);
                        this.Frame2.Controls.Add(this.EntradaCaja);
                        this.Frame2.Controls.Add(this.Label8);
                        this.Frame2.Controls.Add(this.EtiquetaAlicuota);
                        this.Frame2.Controls.Add(this.Label10);
                        this.Frame2.Controls.Add(this.label17);
                        this.Frame2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
                        this.Frame2.Location = new System.Drawing.Point(0, 352);
                        this.Frame2.Margin = new System.Windows.Forms.Padding(0);
                        this.Frame2.Name = "Frame2";
                        this.Frame2.Size = new System.Drawing.Size(360, 316);
                        this.Frame2.TabIndex = 0;
                        this.Frame2.Text = "Precio y costo";
                        // 
                        // EntradaPvpIva
                        // 
                        this.EntradaPvpIva.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaPvpIva.Location = new System.Drawing.Point(182, 211);
                        this.EntradaPvpIva.MaxLength = 14;
                        this.EntradaPvpIva.Name = "EntradaPvpIva";
                        this.EntradaPvpIva.PlaceholderText = "Precio de venta al público con IVA incluido";
                        this.EntradaPvpIva.Prefijo = "$";
                        this.EntradaPvpIva.Size = new System.Drawing.Size(104, 24);
                        this.EntradaPvpIva.TabIndex = 8;
                        this.EntradaPvpIva.Text = "0.00";
                        this.EntradaPvpIva.TextChanged += new System.EventHandler(this.EntradaPvpIva_TextChanged);
                        // 
                        // label23
                        // 
                        this.label23.Location = new System.Drawing.Point(8, 211);
                        this.label23.Name = "label23";
                        this.label23.Size = new System.Drawing.Size(168, 24);
                        this.label23.TabIndex = 7;
                        this.label23.Text = "Precio de venta con IVA";
                        this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaCosto
                        // 
                        this.EntradaCosto.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaCosto.Location = new System.Drawing.Point(136, 40);
                        this.EntradaCosto.MaxLength = 14;
                        this.EntradaCosto.Name = "EntradaCosto";
                        this.EntradaCosto.PlaceholderText = "Precio de costo o de compra.";
                        this.EntradaCosto.Prefijo = "$";
                        this.EntradaCosto.Size = new System.Drawing.Size(104, 24);
                        this.EntradaCosto.TabIndex = 1;
                        this.EntradaCosto.Text = "0.00";
                        this.EntradaCosto.GotFocus += new System.EventHandler(this.EntradaCosto_GotFocus);
                        this.EntradaCosto.TextChanged += new System.EventHandler(this.EntradaCostoMargen_TextChanged);
                        // 
                        // EntradaMargen
                        // 
                        this.EntradaMargen.AlwaysExpanded = true;
                        this.EntradaMargen.Location = new System.Drawing.Point(136, 72);
                        this.EntradaMargen.Name = "EntradaMargen";
                        this.EntradaMargen.SetData = new string[] {
        "Otro|-1"};
                        this.EntradaMargen.Size = new System.Drawing.Size(224, 96);
                        this.EntradaMargen.TabIndex = 4;
                        this.EntradaMargen.TextKey = "-1";
                        this.EntradaMargen.TextChanged += new System.EventHandler(this.EntradaCostoMargen_TextChanged);
                        // 
                        // EntradaPvp
                        // 
                        this.EntradaPvp.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaPvp.Location = new System.Drawing.Point(182, 180);
                        this.EntradaPvp.MaxLength = 14;
                        this.EntradaPvp.Name = "EntradaPvp";
                        this.EntradaPvp.PlaceholderText = "Precio de venta al público. Puede dejar el PVP en blanco y utilizar un márgen pre" +
    "definido a continuación";
                        this.EntradaPvp.Prefijo = "$";
                        this.EntradaPvp.Size = new System.Drawing.Size(104, 24);
                        this.EntradaPvp.TabIndex = 6;
                        this.EntradaPvp.Text = "0.00";
                        this.EntradaPvp.TextChanged += new System.EventHandler(this.EntradaPvp_TextChanged);
                        // 
                        // BotonInfoCosto
                        // 
                        this.BotonInfoCosto.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonInfoCosto.Image = null;
                        this.BotonInfoCosto.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonInfoCosto.Location = new System.Drawing.Point(248, 40);
                        this.BotonInfoCosto.Name = "BotonInfoCosto";
                        this.BotonInfoCosto.Size = new System.Drawing.Size(28, 24);
                        this.BotonInfoCosto.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonInfoCosto.Subtext = "";
                        this.BotonInfoCosto.TabIndex = 2;
                        this.BotonInfoCosto.Text = "...";
                        this.BotonInfoCosto.Click += new System.EventHandler(this.BotonMasInfo_Click);
                        // 
                        // Label6
                        // 
                        this.Label6.Location = new System.Drawing.Point(8, 40);
                        this.Label6.Name = "Label6";
                        this.Label6.Size = new System.Drawing.Size(120, 24);
                        this.Label6.TabIndex = 0;
                        this.Label6.Text = "Precio de costo";
                        this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaCaja
                        // 
                        this.EntradaCaja.AutoTab = true;
                        this.EntradaCaja.CanCreate = true;
                        this.EntradaCaja.Filter = "estado=1 AND id_caja>999";
                        this.EntradaCaja.Location = new System.Drawing.Point(133, 274);
                        this.EntradaCaja.MaxLength = 200;
                        this.EntradaCaja.Name = "EntradaCaja";
                        this.EntradaCaja.NombreTipo = "Lbl.Cajas.Caja";
                        this.EntradaCaja.PlaceholderText = "Ninguna";
                        this.EntradaCaja.Required = false;
                        this.EntradaCaja.Size = new System.Drawing.Size(224, 24);
                        this.EntradaCaja.TabIndex = 11;
                        this.EntradaCaja.Text = "0";
                        // 
                        // Label8
                        // 
                        this.Label8.Location = new System.Drawing.Point(8, 72);
                        this.Label8.Name = "Label8";
                        this.Label8.Size = new System.Drawing.Size(120, 24);
                        this.Label8.TabIndex = 3;
                        this.Label8.Text = "Margen";
                        this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EtiquetaAlicuota
                        // 
                        this.EtiquetaAlicuota.Location = new System.Drawing.Point(152, 242);
                        this.EtiquetaAlicuota.Name = "EtiquetaAlicuota";
                        this.EtiquetaAlicuota.Size = new System.Drawing.Size(205, 24);
                        this.EtiquetaAlicuota.TabIndex = 9;
                        this.EtiquetaAlicuota.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.EtiquetaAlicuota.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Info;
                        // 
                        // Label10
                        // 
                        this.Label10.Location = new System.Drawing.Point(8, 180);
                        this.Label10.Name = "Label10";
                        this.Label10.Size = new System.Drawing.Size(168, 24);
                        this.Label10.TabIndex = 5;
                        this.Label10.Text = "Precio de venta sin IVA";
                        this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // label17
                        // 
                        this.label17.Location = new System.Drawing.Point(5, 274);
                        this.label17.Name = "label17";
                        this.label17.Size = new System.Drawing.Size(120, 24);
                        this.label17.TabIndex = 10;
                        this.label17.Text = "Caja asociada";
                        this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaUnidad
                        // 
                        this.EntradaUnidad.AlwaysExpanded = true;
                        this.EntradaUnidad.AutoSize = true;
                        this.EntradaUnidad.Location = new System.Drawing.Point(160, 0);
                        this.EntradaUnidad.Name = "EntradaUnidad";
                        this.EntradaUnidad.SetData = new string[] {
        "N/A|",
        "Unidades|u",
        "Bolsas|bolsa",
        "Baldes|balde",
        "Rollos|rollo",
        "Cajas|caja",
        "Fajos|fajo",
        "Metros|m",
        "Metros²|m²",
        "Metros³|m³",
        "Centímetros|cm",
        "Centímetros³|cm³",
        "Litros|l",
        "Kg|kg"};
                        this.EntradaUnidad.Size = new System.Drawing.Size(160, 91);
                        this.EntradaUnidad.TabIndex = 1;
                        this.EntradaUnidad.TextKey = "u";
                        this.EntradaUnidad.Enter += new System.EventHandler(this.EntradaPvp_Enter);
                        // 
                        // EntradaTipoDeArticulo
                        // 
                        this.EntradaTipoDeArticulo.AlwaysExpanded = true;
                        this.EntradaTipoDeArticulo.AutoSize = true;
                        this.EntradaTipoDeArticulo.Location = new System.Drawing.Point(168, 40);
                        this.EntradaTipoDeArticulo.Name = "EntradaTipoDeArticulo";
                        this.EntradaTipoDeArticulo.SetData = new string[] {
        "Servicio|0",
        "Producto simple|1",
        "Producto compuesto|2"};
                        this.EntradaTipoDeArticulo.Size = new System.Drawing.Size(160, 57);
                        this.EntradaTipoDeArticulo.TabIndex = 1;
                        this.EntradaTipoDeArticulo.TextKey = "1";
                        this.EntradaTipoDeArticulo.TextChanged += new System.EventHandler(this.EntradaTipoDeArticulo_TextChanged);
                        // 
                        // BotonReceta
                        // 
                        this.BotonReceta.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonReceta.Image = null;
                        this.BotonReceta.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonReceta.Location = new System.Drawing.Point(336, 40);
                        this.BotonReceta.Name = "BotonReceta";
                        this.BotonReceta.Size = new System.Drawing.Size(28, 24);
                        this.BotonReceta.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonReceta.Subtext = "";
                        this.BotonReceta.TabIndex = 2;
                        this.BotonReceta.Text = "...";
                        this.BotonReceta.Visible = false;
                        this.BotonReceta.Click += new System.EventHandler(this.BotonReceta_Click);
                        // 
                        // BotonUnidad
                        // 
                        this.BotonUnidad.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonUnidad.Image = null;
                        this.BotonUnidad.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonUnidad.Location = new System.Drawing.Point(328, 0);
                        this.BotonUnidad.Name = "BotonUnidad";
                        this.BotonUnidad.Size = new System.Drawing.Size(28, 24);
                        this.BotonUnidad.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonUnidad.Subtext = "";
                        this.BotonUnidad.TabIndex = 2;
                        this.BotonUnidad.Text = "...";
                        this.BotonUnidad.Click += new System.EventHandler(this.BotonUnidad_Click);
                        // 
                        // label19
                        // 
                        this.label19.Location = new System.Drawing.Point(0, 0);
                        this.label19.Name = "label19";
                        this.label19.Size = new System.Drawing.Size(152, 24);
                        this.label19.TabIndex = 0;
                        this.label19.Text = "Unidad";
                        this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // Label7
                        // 
                        this.Label7.Location = new System.Drawing.Point(8, 40);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(152, 24);
                        this.Label7.TabIndex = 0;
                        this.Label7.Text = "Tipo de artículo";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaStockMinimo
                        // 
                        this.EntradaStockMinimo.DataType = Lui.Forms.DataTypes.Stock;
                        this.EntradaStockMinimo.Location = new System.Drawing.Point(160, 176);
                        this.EntradaStockMinimo.MaxLength = 14;
                        this.EntradaStockMinimo.Name = "EntradaStockMinimo";
                        this.EntradaStockMinimo.PlaceholderText = "Nivel mínimo de existencias";
                        this.EntradaStockMinimo.Size = new System.Drawing.Size(96, 24);
                        this.EntradaStockMinimo.TabIndex = 6;
                        this.EntradaStockMinimo.Text = "0";
                        // 
                        // Label11
                        // 
                        this.Label11.Location = new System.Drawing.Point(0, 176);
                        this.Label11.Name = "Label11";
                        this.Label11.Size = new System.Drawing.Size(152, 24);
                        this.Label11.TabIndex = 5;
                        this.Label11.Text = "Punto de reposición";
                        this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // Label9
                        // 
                        this.Label9.Location = new System.Drawing.Point(0, 208);
                        this.Label9.Name = "Label9";
                        this.Label9.Size = new System.Drawing.Size(152, 24);
                        this.Label9.TabIndex = 7;
                        this.Label9.Text = "Existencias";
                        this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaStockActual
                        // 
                        this.EntradaStockActual.DataType = Lui.Forms.DataTypes.Stock;
                        this.EntradaStockActual.Location = new System.Drawing.Point(160, 208);
                        this.EntradaStockActual.Name = "EntradaStockActual";
                        this.EntradaStockActual.ReadOnly = true;
                        this.EntradaStockActual.Size = new System.Drawing.Size(96, 24);
                        this.EntradaStockActual.TabIndex = 8;
                        this.EntradaStockActual.Text = "0";
                        this.EntradaStockActual.TextChanged += new System.EventHandler(this.EntradaStockActual_TextChanged);
                        // 
                        // EtiquetaCodigo1
                        // 
                        this.EtiquetaCodigo1.Location = new System.Drawing.Point(0, 0);
                        this.EtiquetaCodigo1.Name = "EtiquetaCodigo1";
                        this.EtiquetaCodigo1.Size = new System.Drawing.Size(104, 24);
                        this.EtiquetaCodigo1.TabIndex = 0;
                        this.EtiquetaCodigo1.Text = "Código 1";
                        this.EtiquetaCodigo1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(0, 96);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(104, 24);
                        this.Label5.TabIndex = 16;
                        this.Label5.Text = "Nombre";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCodigo1
                        // 
                        this.EntradaCodigo1.Location = new System.Drawing.Point(104, 0);
                        this.EntradaCodigo1.MaxLength = 50;
                        this.EntradaCodigo1.Name = "EntradaCodigo1";
                        this.EntradaCodigo1.Size = new System.Drawing.Size(132, 24);
                        this.EntradaCodigo1.TabIndex = 1;
                        // 
                        // EntradaCodigo4
                        // 
                        this.EntradaCodigo4.Location = new System.Drawing.Point(796, 0);
                        this.EntradaCodigo4.MaxLength = 50;
                        this.EntradaCodigo4.Name = "EntradaCodigo4";
                        this.EntradaCodigo4.Size = new System.Drawing.Size(140, 24);
                        this.EntradaCodigo4.TabIndex = 7;
                        // 
                        // EntradaCodigo3
                        // 
                        this.EntradaCodigo3.ForceCase = Lui.Forms.TextCasing.UpperCase;
                        this.EntradaCodigo3.Location = new System.Drawing.Point(564, 0);
                        this.EntradaCodigo3.MaxLength = 50;
                        this.EntradaCodigo3.Name = "EntradaCodigo3";
                        this.EntradaCodigo3.Size = new System.Drawing.Size(132, 24);
                        this.EntradaCodigo3.TabIndex = 5;
                        // 
                        // EntradaCodigo2
                        // 
                        this.EntradaCodigo2.Location = new System.Drawing.Point(336, 0);
                        this.EntradaCodigo2.MaxLength = 50;
                        this.EntradaCodigo2.Name = "EntradaCodigo2";
                        this.EntradaCodigo2.Size = new System.Drawing.Size(132, 24);
                        this.EntradaCodigo2.TabIndex = 3;
                        // 
                        // EtiquetaCodigo4
                        // 
                        this.EtiquetaCodigo4.Location = new System.Drawing.Point(712, 0);
                        this.EtiquetaCodigo4.Name = "EtiquetaCodigo4";
                        this.EtiquetaCodigo4.Size = new System.Drawing.Size(84, 24);
                        this.EtiquetaCodigo4.TabIndex = 6;
                        this.EtiquetaCodigo4.Text = "Código 4";
                        this.EtiquetaCodigo4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EtiquetaCodigo3
                        // 
                        this.EtiquetaCodigo3.Location = new System.Drawing.Point(480, 0);
                        this.EtiquetaCodigo3.Name = "EtiquetaCodigo3";
                        this.EtiquetaCodigo3.Size = new System.Drawing.Size(84, 24);
                        this.EtiquetaCodigo3.TabIndex = 4;
                        this.EtiquetaCodigo3.Text = "Código 3";
                        this.EtiquetaCodigo3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EtiquetaCodigo2
                        // 
                        this.EtiquetaCodigo2.Location = new System.Drawing.Point(252, 0);
                        this.EtiquetaCodigo2.Name = "EtiquetaCodigo2";
                        this.EtiquetaCodigo2.Size = new System.Drawing.Size(84, 24);
                        this.EtiquetaCodigo2.TabIndex = 2;
                        this.EtiquetaCodigo2.Text = "Código 2";
                        this.EtiquetaCodigo2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaDestacado
                        // 
                        this.EntradaDestacado.AlwaysExpanded = true;
                        this.EntradaDestacado.AutoSize = true;
                        this.EntradaDestacado.Location = new System.Drawing.Point(104, 272);
                        this.EntradaDestacado.Name = "EntradaDestacado";
                        this.EntradaDestacado.SetData = new string[] {
        "Sí|1",
        "No|0"};
                        this.EntradaDestacado.Size = new System.Drawing.Size(64, 40);
                        this.EntradaDestacado.TabIndex = 25;
                        this.EntradaDestacado.TextKey = "0";
                        // 
                        // EntradaWeb
                        // 
                        this.EntradaWeb.AlwaysExpanded = true;
                        this.EntradaWeb.AutoSize = true;
                        this.EntradaWeb.Location = new System.Drawing.Point(280, 272);
                        this.EntradaWeb.Name = "EntradaWeb";
                        this.EntradaWeb.SetData = new string[] {
        "Siempre|1",
        "Sólo si hay existencias|2",
        "Nunca|0"};
                        this.EntradaWeb.Size = new System.Drawing.Size(176, 57);
                        this.EntradaWeb.TabIndex = 27;
                        this.EntradaWeb.TextKey = "2";
                        // 
                        // EntradaModelo
                        // 
                        this.EntradaModelo.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaModelo.Location = new System.Drawing.Point(104, 64);
                        this.EntradaModelo.MaxLength = 200;
                        this.EntradaModelo.Name = "EntradaModelo";
                        this.EntradaModelo.Size = new System.Drawing.Size(352, 24);
                        this.EntradaModelo.TabIndex = 13;
                        this.EntradaModelo.TextChanged += new System.EventHandler(this.EntradaCategoriaMarcaModeloSerie_TextChanged);
                        // 
                        // EntradaGarantia
                        // 
                        this.EntradaGarantia.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaGarantia.Location = new System.Drawing.Point(604, 272);
                        this.EntradaGarantia.MaxLength = 3;
                        this.EntradaGarantia.Name = "EntradaGarantia";
                        this.EntradaGarantia.PlaceholderText = "Período de garantía en meses.";
                        this.EntradaGarantia.Size = new System.Drawing.Size(104, 24);
                        this.EntradaGarantia.Sufijo = "meses";
                        this.EntradaGarantia.TabIndex = 29;
                        this.EntradaGarantia.Text = "0";
                        // 
                        // EntradaCategoria
                        // 
                        this.EntradaCategoria.AutoTab = true;
                        this.EntradaCategoria.CanCreate = true;
                        this.EntradaCategoria.Location = new System.Drawing.Point(104, 32);
                        this.EntradaCategoria.MaxLength = 0;
                        this.EntradaCategoria.Name = "EntradaCategoria";
                        this.EntradaCategoria.NombreTipo = "Lbl.Articulos.Categoria";
                        this.EntradaCategoria.PlaceholderText = "Rubro o categoría";
                        this.EntradaCategoria.Required = true;
                        this.EntradaCategoria.Size = new System.Drawing.Size(352, 24);
                        this.EntradaCategoria.TabIndex = 9;
                        this.EntradaCategoria.Text = "0";
                        this.EntradaCategoria.TextChanged += new System.EventHandler(this.EntradaCategoriaMarcaModeloSerie_TextChanged);
                        // 
                        // EntradaMarca
                        // 
                        this.EntradaMarca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaMarca.AutoTab = true;
                        this.EntradaMarca.CanCreate = true;
                        this.EntradaMarca.Location = new System.Drawing.Point(552, 32);
                        this.EntradaMarca.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaMarca.MaxLength = 0;
                        this.EntradaMarca.Name = "EntradaMarca";
                        this.EntradaMarca.NombreTipo = "Lbl.Articulos.Marca";
                        this.EntradaMarca.PlaceholderText = "Sin especificar";
                        this.EntradaMarca.Required = false;
                        this.EntradaMarca.Size = new System.Drawing.Size(248, 24);
                        this.EntradaMarca.TabIndex = 11;
                        this.EntradaMarca.Text = "0";
                        this.EntradaMarca.TextChanged += new System.EventHandler(this.EntradaCategoriaMarcaModeloSerie_TextChanged);
                        // 
                        // EntradaDescripcion2
                        // 
                        this.EntradaDescripcion2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaDescripcion2.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaDescripcion2.Location = new System.Drawing.Point(512, 160);
                        this.EntradaDescripcion2.MultiLine = true;
                        this.EntradaDescripcion2.Name = "EntradaDescripcion2";
                        this.EntradaDescripcion2.PlaceholderText = "Descripción larga";
                        this.EntradaDescripcion2.Size = new System.Drawing.Size(288, 104);
                        this.EntradaDescripcion2.TabIndex = 23;
                        // 
                        // EntradaUrl
                        // 
                        this.EntradaUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaUrl.Location = new System.Drawing.Point(104, 128);
                        this.EntradaUrl.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaUrl.Name = "EntradaUrl";
                        this.EntradaUrl.PlaceholderText = "Dirección de la página web del producto.";
                        this.EntradaUrl.Size = new System.Drawing.Size(480, 24);
                        this.EntradaUrl.TabIndex = 19;
                        // 
                        // EntradaDescripcion
                        // 
                        this.EntradaDescripcion.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaDescripcion.Location = new System.Drawing.Point(104, 160);
                        this.EntradaDescripcion.MultiLine = true;
                        this.EntradaDescripcion.Name = "EntradaDescripcion";
                        this.EntradaDescripcion.PlaceholderText = "Descripción corta";
                        this.EntradaDescripcion.Size = new System.Drawing.Size(292, 104);
                        this.EntradaDescripcion.TabIndex = 21;
                        // 
                        // EntradaNombre
                        // 
                        this.EntradaNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaNombre.Location = new System.Drawing.Point(104, 96);
                        this.EntradaNombre.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaNombre.MaxLength = 200;
                        this.EntradaNombre.Name = "EntradaNombre";
                        this.EntradaNombre.PlaceholderText = "Nombre completo del artículo";
                        this.EntradaNombre.Size = new System.Drawing.Size(480, 24);
                        this.EntradaNombre.TabIndex = 17;
                        this.EntradaNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EntradaNombre_KeyPress);
                        // 
                        // EntradaSerie
                        // 
                        this.EntradaSerie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaSerie.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaSerie.Location = new System.Drawing.Point(552, 64);
                        this.EntradaSerie.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaSerie.MaxLength = 200;
                        this.EntradaSerie.Name = "EntradaSerie";
                        this.EntradaSerie.Size = new System.Drawing.Size(248, 24);
                        this.EntradaSerie.TabIndex = 15;
                        this.EntradaSerie.TextChanged += new System.EventHandler(this.EntradaCategoriaMarcaModeloSerie_TextChanged);
                        // 
                        // label20
                        // 
                        this.label20.Location = new System.Drawing.Point(512, 272);
                        this.label20.Name = "label20";
                        this.label20.Size = new System.Drawing.Size(92, 24);
                        this.label20.TabIndex = 28;
                        this.label20.Text = "Garantía";
                        this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(0, 32);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(104, 24);
                        this.Label2.TabIndex = 8;
                        this.Label2.Text = "Categoría";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label13
                        // 
                        this.Label13.Location = new System.Drawing.Point(0, 160);
                        this.Label13.Name = "Label13";
                        this.Label13.Size = new System.Drawing.Size(104, 24);
                        this.Label13.TabIndex = 20;
                        this.Label13.Text = "Descripción";
                        this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label15
                        // 
                        this.Label15.Location = new System.Drawing.Point(0, 272);
                        this.Label15.Name = "Label15";
                        this.Label15.Size = new System.Drawing.Size(104, 24);
                        this.Label15.TabIndex = 24;
                        this.Label15.Text = "Destacado";
                        this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(0, 64);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(104, 24);
                        this.Label3.TabIndex = 12;
                        this.Label3.Text = "Modelo";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label4
                        // 
                        this.Label4.Location = new System.Drawing.Point(472, 64);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(80, 24);
                        this.Label4.TabIndex = 14;
                        this.Label4.Text = "Serie";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(472, 32);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(80, 24);
                        this.Label1.TabIndex = 10;
                        this.Label1.Text = "Marca";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label18
                        // 
                        this.Label18.Location = new System.Drawing.Point(408, 160);
                        this.Label18.Name = "Label18";
                        this.Label18.Size = new System.Drawing.Size(100, 56);
                        this.Label18.TabIndex = 22;
                        this.Label18.Text = "Descripción extendida";
                        // 
                        // Label16
                        // 
                        this.Label16.Location = new System.Drawing.Point(184, 272);
                        this.Label16.Name = "Label16";
                        this.Label16.Size = new System.Drawing.Size(96, 24);
                        this.Label16.TabIndex = 26;
                        this.Label16.Text = "Publicar";
                        this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label12
                        // 
                        this.Label12.Location = new System.Drawing.Point(0, 128);
                        this.Label12.Name = "Label12";
                        this.Label12.Size = new System.Drawing.Size(104, 24);
                        this.Label12.TabIndex = 18;
                        this.Label12.Text = "URL";
                        this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Frame3
                        // 
                        this.Frame3.Controls.Add(this.Label7);
                        this.Frame3.Controls.Add(this.BotonReceta);
                        this.Frame3.Controls.Add(this.EntradaTipoDeArticulo);
                        this.Frame3.Controls.Add(this.PanelProducto);
                        this.Frame3.Controls.Add(this.PanelServicio);
                        this.Frame3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
                        this.Frame3.Location = new System.Drawing.Point(402, 352);
                        this.Frame3.Margin = new System.Windows.Forms.Padding(0);
                        this.Frame3.Name = "Frame3";
                        this.Frame3.Size = new System.Drawing.Size(388, 336);
                        this.Frame3.TabIndex = 33;
                        this.Frame3.Text = "Existencias";
                        // 
                        // PanelProducto
                        // 
                        this.PanelProducto.Controls.Add(this.label19);
                        this.PanelProducto.Controls.Add(this.EntradaStockMinimo);
                        this.PanelProducto.Controls.Add(this.EntradaStockActual);
                        this.PanelProducto.Controls.Add(this.EntradaSeguimiento);
                        this.PanelProducto.Controls.Add(this.EntradaUnidad);
                        this.PanelProducto.Controls.Add(this.Label9);
                        this.PanelProducto.Controls.Add(this.BotonUnidad);
                        this.PanelProducto.Controls.Add(this.Label11);
                        this.PanelProducto.Controls.Add(this.label21);
                        this.PanelProducto.Location = new System.Drawing.Point(8, 104);
                        this.PanelProducto.Name = "PanelProducto";
                        this.PanelProducto.Size = new System.Drawing.Size(384, 240);
                        this.PanelProducto.TabIndex = 3;
                        // 
                        // EntradaSeguimiento
                        // 
                        this.EntradaSeguimiento.AlwaysExpanded = true;
                        this.EntradaSeguimiento.AutoSize = true;
                        this.EntradaSeguimiento.Location = new System.Drawing.Point(160, 96);
                        this.EntradaSeguimiento.Name = "EntradaSeguimiento";
                        this.EntradaSeguimiento.SetData = new string[] {
        "Predeterminado|0",
        "Ninguno|1",
        "Por números de serie|3",
        "Por variaciones|5"};
                        this.EntradaSeguimiento.Size = new System.Drawing.Size(160, 74);
                        this.EntradaSeguimiento.TabIndex = 4;
                        this.EntradaSeguimiento.TextKey = "0";
                        this.EntradaSeguimiento.TextChanged += new System.EventHandler(this.EntradaSeguimiento_TextChanged);
                        // 
                        // label21
                        // 
                        this.label21.Location = new System.Drawing.Point(0, 96);
                        this.label21.Name = "label21";
                        this.label21.Size = new System.Drawing.Size(152, 24);
                        this.label21.TabIndex = 3;
                        this.label21.Text = "Seguimiento";
                        this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // PanelServicio
                        // 
                        this.PanelServicio.Controls.Add(this.label22);
                        this.PanelServicio.Controls.Add(this.EntradaPeriodicidad);
                        this.PanelServicio.Location = new System.Drawing.Point(8, 104);
                        this.PanelServicio.Name = "PanelServicio";
                        this.PanelServicio.Size = new System.Drawing.Size(384, 232);
                        this.PanelServicio.TabIndex = 4;
                        this.PanelServicio.Visible = false;
                        // 
                        // label22
                        // 
                        this.label22.Location = new System.Drawing.Point(0, 0);
                        this.label22.Name = "label22";
                        this.label22.Size = new System.Drawing.Size(152, 24);
                        this.label22.TabIndex = 0;
                        this.label22.Text = "Periodicidad";
                        this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EntradaPeriodicidad
                        // 
                        this.EntradaPeriodicidad.AlwaysExpanded = true;
                        this.EntradaPeriodicidad.AutoSize = true;
                        this.EntradaPeriodicidad.Location = new System.Drawing.Point(160, 0);
                        this.EntradaPeriodicidad.Name = "EntradaPeriodicidad";
                        this.EntradaPeriodicidad.SetData = new string[] {
        "Ninguna|0,",
        "Por ocasión|9",
        "Por minuto|1",
        "Por hora|2",
        "Diaria|3",
        "Semanal|4",
        "Quincenal|5",
        "Mensual|6",
        "Bimestral|7",
        "Semestral|8",
        "Anual|9"};
                        this.EntradaPeriodicidad.Size = new System.Drawing.Size(160, 91);
                        this.EntradaPeriodicidad.TabIndex = 1;
                        this.EntradaPeriodicidad.TextKey = "0,";
                        // 
                        // label14
                        // 
                        this.label14.Location = new System.Drawing.Point(512, 304);
                        this.label14.Name = "label14";
                        this.label14.Size = new System.Drawing.Size(92, 24);
                        this.label14.TabIndex = 30;
                        this.label14.Text = "Proveedor";
                        this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaProveedor
                        // 
                        this.EntradaProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaProveedor.AutoTab = true;
                        this.EntradaProveedor.CanCreate = true;
                        this.EntradaProveedor.Filter = "(tipo&2)=2";
                        this.EntradaProveedor.Location = new System.Drawing.Point(604, 304);
                        this.EntradaProveedor.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaProveedor.MaxLength = 200;
                        this.EntradaProveedor.Name = "EntradaProveedor";
                        this.EntradaProveedor.NombreTipo = "Lbl.Personas.Proveedor";
                        this.EntradaProveedor.PlaceholderText = "Sin especificar";
                        this.EntradaProveedor.Required = false;
                        this.EntradaProveedor.Size = new System.Drawing.Size(196, 24);
                        this.EntradaProveedor.TabIndex = 31;
                        this.EntradaProveedor.Text = "0";
                        // 
                        // Editar
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                        this.Controls.Add(this.label14);
                        this.Controls.Add(this.EntradaProveedor);
                        this.Controls.Add(this.Frame2);
                        this.Controls.Add(this.EntradaCodigo1);
                        this.Controls.Add(this.Frame3);
                        this.Controls.Add(this.EntradaCodigo4);
                        this.Controls.Add(this.EntradaCodigo3);
                        this.Controls.Add(this.EntradaCodigo2);
                        this.Controls.Add(this.Label18);
                        this.Controls.Add(this.EtiquetaCodigo4);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.EtiquetaCodigo3);
                        this.Controls.Add(this.Label4);
                        this.Controls.Add(this.EtiquetaCodigo2);
                        this.Controls.Add(this.EntradaDestacado);
                        this.Controls.Add(this.EntradaWeb);
                        this.Controls.Add(this.EntradaModelo);
                        this.Controls.Add(this.EntradaGarantia);
                        this.Controls.Add(this.label20);
                        this.Controls.Add(this.EntradaSerie);
                        this.Controls.Add(this.EntradaCategoria);
                        this.Controls.Add(this.EntradaNombre);
                        this.Controls.Add(this.EntradaMarca);
                        this.Controls.Add(this.EntradaDescripcion);
                        this.Controls.Add(this.EntradaDescripcion2);
                        this.Controls.Add(this.EntradaUrl);
                        this.Controls.Add(this.EtiquetaCodigo1);
                        this.Controls.Add(this.Label5);
                        this.Controls.Add(this.Label12);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.Label13);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.Label15);
                        this.Controls.Add(this.Label16);
                        this.MinimumSize = new System.Drawing.Size(800, 688);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(800, 694);
                        this.Frame2.ResumeLayout(false);
                        this.Frame2.PerformLayout();
                        this.Frame3.ResumeLayout(false);
                        this.Frame3.PerformLayout();
                        this.PanelProducto.ResumeLayout(false);
                        this.PanelProducto.PerformLayout();
                        this.PanelServicio.ResumeLayout(false);
                        this.PanelServicio.PerformLayout();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                internal Lui.Forms.ComboBox EntradaUnidad;
                internal Lui.Forms.Label label19;
                internal Lui.Forms.Button BotonUnidad;
                internal Lui.Forms.Label Label15;
                internal Lui.Forms.TextBox EntradaCodigo4;
                internal Lui.Forms.Label EtiquetaCodigo4;
                internal Lui.Forms.TextBox EntradaCodigo3;
                internal Lui.Forms.Label EtiquetaCodigo3;
                internal Lui.Forms.TextBox EntradaCodigo2;
                internal Lui.Forms.Label EtiquetaCodigo2;
                internal Lui.Forms.TextBox EntradaCodigo1;
                internal Lui.Forms.Label EtiquetaCodigo1;
                internal Lui.Forms.TextBox EntradaDescripcion;
                internal Lui.Forms.Label Label13;
                internal Lui.Forms.TextBox EntradaUrl;
                internal Lui.Forms.Label Label12;
                internal Lui.Forms.TextBox EntradaStockMinimo;
                internal Lui.Forms.Label Label11;
                internal Lui.Forms.TextBox EntradaPvp;
                internal Lui.Forms.Label Label10;
                internal Lui.Forms.TextBox EntradaStockActual;
                internal Lui.Forms.Label Label9;
                internal Lui.Forms.ComboBox EntradaMargen;
                internal Lui.Forms.Label Label8;
                internal Lui.Forms.ComboBox EntradaTipoDeArticulo;
                internal Lui.Forms.Label Label7;
                internal Lui.Forms.TextBox EntradaCosto;
                internal Lui.Forms.Label Label6;
                internal Lui.Forms.Frame Frame2;
                internal Lui.Forms.TextBox EntradaNombre;
                internal Lui.Forms.Label Label5;
                internal Lui.Forms.TextBox EntradaSerie;
                internal Lui.Forms.TextBox EntradaModelo;
                internal Lui.Forms.Label Label4;
                internal Lui.Forms.Label Label3;
                internal Lcc.Entrada.CodigoDetalle EntradaCategoria;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.Label Label1;
                internal Lcc.Entrada.CodigoDetalle EntradaMarca;
                internal Lui.Forms.ComboBox EntradaDestacado;
                internal Lui.Forms.Button BotonInfoCosto;
                internal Lui.Forms.Label Label16;
                internal Lui.Forms.ComboBox EntradaWeb;
                internal Lui.Forms.TextBox EntradaDescripcion2;
                internal Lui.Forms.Label Label18;
                internal Lcc.Entrada.CodigoDetalle EntradaCaja;
                internal Lui.Forms.Label label17;
                internal Lui.Forms.TextBox EntradaGarantia;
                internal Lui.Forms.Label label20;
                internal Lui.Forms.Button BotonReceta;
                internal Lui.Forms.Label EtiquetaAlicuota;
                internal Lui.Forms.Frame Frame3;
                internal Lui.Forms.ComboBox EntradaSeguimiento;
                internal Lui.Forms.Label label21;
                internal Lui.Forms.Label label14;
                internal Lcc.Entrada.CodigoDetalle EntradaProveedor;
                internal Lui.Forms.Panel PanelServicio;
                internal Lui.Forms.Label label22;
                internal Lui.Forms.ComboBox EntradaPeriodicidad;
                internal Lui.Forms.Panel PanelProducto;
                internal Lui.Forms.TextBox EntradaPvpIva;
                internal Lui.Forms.Label label23;
        }
}
