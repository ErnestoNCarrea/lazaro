namespace Lfc.Comprobantes
{
        public partial class Editar
        {
                #region Código generado por el Diseñador de Windows Forms

                private void InitializeComponent()
                {
                        this.EntradaProductos = new Lcc.Entrada.Articulos.MatrizDetalleComprobante();
                        this.Label3 = new Lui.Forms.Label();
                        this.EntradaCliente = new Lcc.Entrada.CodigoDetalle();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaVendedor = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaTotal = new Lui.Forms.TextBox();
                        this.Label4 = new Lui.Forms.Label();
                        this.Label5 = new Lui.Forms.Label();
                        this.EntradaSubTotal = new Lui.Forms.TextBox();
                        this.EntradaDescuento = new Lui.Forms.TextBox();
                        this.Label6 = new Lui.Forms.Label();
                        this.EntradaInteres = new Lui.Forms.TextBox();
                        this.Label7 = new Lui.Forms.Label();
                        this.EntradaCuotas = new Lui.Forms.TextBox();
                        this.Label8 = new Lui.Forms.Label();
                        this.EntradaValorCuota = new Lui.Forms.TextBox();
                        this.Label9 = new Lui.Forms.Label();
                        this.EntradaComprobanteId = new System.Windows.Forms.TextBox();
                        this.label2 = new Lui.Forms.Label();
                        this.EntradaPV = new Lui.Forms.TextBox();
                        this.PnlCuotas = new Lui.Forms.Panel();
                        this.EntradaIva = new Lui.Forms.TextBox();
                        this.EtiquetaIva = new Lui.Forms.Label();
                        this.EntradaSubTotalIva = new Lui.Forms.TextBox();
                        this.PnlCuotas.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // EntradaProductos
                        // 
                        this.EntradaProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaProductos.AutoScroll = true;
                        this.EntradaProductos.AutoScrollMargin = new System.Drawing.Size(4, 4);
                        this.EntradaProductos.BloquearAtriculo = false;
                        this.EntradaProductos.BloquearCantidad = false;
                        this.EntradaProductos.BloquearDescuento = false;
                        this.EntradaProductos.BloquearPrecio = false;
                        this.EntradaProductos.DiscriminarIva = false;
                        this.EntradaProductos.FreeTextCode = "*";
                        this.EntradaProductos.Location = new System.Drawing.Point(0, 32);
                        this.EntradaProductos.MostrarExistencias = true;
                        this.EntradaProductos.Name = "EntradaProductos";
                        this.EntradaProductos.Precio = Lcc.Entrada.Articulos.Precios.Pvp;
                        this.EntradaProductos.Size = new System.Drawing.Size(960, 264);
                        this.EntradaProductos.TabIndex = 20;
                        this.EntradaProductos.TotalChanged += new System.EventHandler(this.EntradaProductos_TotalChanged);
                        this.EntradaProductos.ObtenerDatosSeguimiento += new System.EventHandler(this.EntradaProductos_ObtenerDatosSeguimiento);
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(248, 0);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(56, 24);
                        this.Label3.TabIndex = 3;
                        this.Label3.Text = "Cliente";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCliente
                        // 
                        this.EntradaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCliente.AutoTab = true;
                        this.EntradaCliente.CanCreate = true;
                        this.EntradaCliente.Filter = "estado=1";
                        this.EntradaCliente.Location = new System.Drawing.Point(304, 0);
                        this.EntradaCliente.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaCliente.MaxLength = 200;
                        this.EntradaCliente.Name = "EntradaCliente";
                        this.EntradaCliente.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaCliente.Required = true;
                        this.EntradaCliente.Size = new System.Drawing.Size(480, 24);
                        this.EntradaCliente.TabIndex = 4;
                        this.EntradaCliente.Text = "0";
                        this.EntradaCliente.TextChanged += new System.EventHandler(this.EntradaCliente_TextChanged);
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(0, 0);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(72, 24);
                        this.Label1.TabIndex = 1;
                        this.Label1.Text = "Vendedor";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaVendedor
                        // 
                        this.EntradaVendedor.AutoTab = true;
                        this.EntradaVendedor.CanCreate = true;
                        this.EntradaVendedor.Filter = "(tipo&4)=4 AND estado=1";
                        this.EntradaVendedor.Location = new System.Drawing.Point(72, 0);
                        this.EntradaVendedor.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaVendedor.MaxLength = 200;
                        this.EntradaVendedor.Name = "EntradaVendedor";
                        this.EntradaVendedor.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaVendedor.Required = true;
                        this.EntradaVendedor.Size = new System.Drawing.Size(168, 24);
                        this.EntradaVendedor.TabIndex = 2;
                        this.EntradaVendedor.Text = "0";
                        // 
                        // EntradaTotal
                        // 
                        this.EntradaTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaTotal.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaTotal.Location = new System.Drawing.Point(816, 328);
                        this.EntradaTotal.Name = "EntradaTotal";
                        this.EntradaTotal.Prefijo = "$";
                        this.EntradaTotal.Size = new System.Drawing.Size(144, 32);
                        this.EntradaTotal.TabIndex = 41;
                        this.EntradaTotal.Text = "0.00";
                        this.EntradaTotal.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Bigger;
                        this.EntradaTotal.TextChanged += new System.EventHandler(this.EntradaTotal_TextChanged);
                        // 
                        // Label4
                        // 
                        this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label4.Location = new System.Drawing.Point(736, 328);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(80, 32);
                        this.Label4.TabIndex = 40;
                        this.Label4.Text = "Total";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        this.Label4.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
                        // 
                        // Label5
                        // 
                        this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.Label5.Location = new System.Drawing.Point(0, 304);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(64, 24);
                        this.Label5.TabIndex = 21;
                        this.Label5.Text = "Subtotal";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaSubTotal
                        // 
                        this.EntradaSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaSubTotal.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaSubTotal.Location = new System.Drawing.Point(64, 304);
                        this.EntradaSubTotal.Name = "EntradaSubTotal";
                        this.EntradaSubTotal.Prefijo = "$";
                        this.EntradaSubTotal.ReadOnly = true;
                        this.EntradaSubTotal.Size = new System.Drawing.Size(92, 24);
                        this.EntradaSubTotal.TabIndex = 22;
                        this.EntradaSubTotal.TabStop = false;
                        this.EntradaSubTotal.Text = "0.00";
                        this.EntradaSubTotal.TextChanged += new System.EventHandler(this.RecalcularTotal);
                        // 
                        // EntradaDescuento
                        // 
                        this.EntradaDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaDescuento.DataType = Lui.Forms.DataTypes.Float;
                        this.EntradaDescuento.Location = new System.Drawing.Point(380, 304);
                        this.EntradaDescuento.Name = "EntradaDescuento";
                        this.EntradaDescuento.Size = new System.Drawing.Size(76, 24);
                        this.EntradaDescuento.Sufijo = "%";
                        this.EntradaDescuento.TabIndex = 24;
                        this.EntradaDescuento.Text = "0.0000";
                        this.EntradaDescuento.TextChanged += new System.EventHandler(this.RecalcularTotal);
                        // 
                        // Label6
                        // 
                        this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.Label6.Location = new System.Drawing.Point(320, 304);
                        this.Label6.Name = "Label6";
                        this.Label6.Size = new System.Drawing.Size(60, 24);
                        this.Label6.TabIndex = 23;
                        this.Label6.Text = "Descto.";
                        this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaInteres
                        // 
                        this.EntradaInteres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaInteres.DataType = Lui.Forms.DataTypes.Float;
                        this.EntradaInteres.Location = new System.Drawing.Point(380, 332);
                        this.EntradaInteres.Name = "EntradaInteres";
                        this.EntradaInteres.Size = new System.Drawing.Size(76, 24);
                        this.EntradaInteres.Sufijo = "%";
                        this.EntradaInteres.TabIndex = 26;
                        this.EntradaInteres.Text = "0.0000";
                        this.EntradaInteres.TextChanged += new System.EventHandler(this.RecalcularTotal);
                        // 
                        // Label7
                        // 
                        this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.Label7.Location = new System.Drawing.Point(320, 332);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(60, 24);
                        this.Label7.TabIndex = 25;
                        this.Label7.Text = "Recargo";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCuotas
                        // 
                        this.EntradaCuotas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaCuotas.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaCuotas.Location = new System.Drawing.Point(52, 0);
                        this.EntradaCuotas.MaxLength = 2;
                        this.EntradaCuotas.Name = "EntradaCuotas";
                        this.EntradaCuotas.Size = new System.Drawing.Size(32, 24);
                        this.EntradaCuotas.TabIndex = 28;
                        this.EntradaCuotas.Text = "0";
                        this.EntradaCuotas.TextChanged += new System.EventHandler(this.RecalcularTotal);
                        // 
                        // Label8
                        // 
                        this.Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.Label8.Location = new System.Drawing.Point(0, 0);
                        this.Label8.Name = "Label8";
                        this.Label8.Size = new System.Drawing.Size(52, 24);
                        this.Label8.TabIndex = 27;
                        this.Label8.Text = "Cuotas";
                        this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaValorCuota
                        // 
                        this.EntradaValorCuota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaValorCuota.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaValorCuota.Location = new System.Drawing.Point(108, 0);
                        this.EntradaValorCuota.Name = "EntradaValorCuota";
                        this.EntradaValorCuota.Prefijo = "$";
                        this.EntradaValorCuota.Size = new System.Drawing.Size(80, 24);
                        this.EntradaValorCuota.TabIndex = 30;
                        this.EntradaValorCuota.TabStop = false;
                        this.EntradaValorCuota.Text = "0.00";
                        // 
                        // Label9
                        // 
                        this.Label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.Label9.Location = new System.Drawing.Point(84, 0);
                        this.Label9.Name = "Label9";
                        this.Label9.Size = new System.Drawing.Size(24, 24);
                        this.Label9.TabIndex = 29;
                        this.Label9.Text = "de";
                        this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // EntradaComprobanteId
                        // 
                        this.EntradaComprobanteId.Location = new System.Drawing.Point(492, 336);
                        this.EntradaComprobanteId.Name = "EntradaComprobanteId";
                        this.EntradaComprobanteId.Size = new System.Drawing.Size(28, 25);
                        this.EntradaComprobanteId.TabIndex = 52;
                        this.EntradaComprobanteId.Visible = false;
                        // 
                        // label2
                        // 
                        this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.label2.Location = new System.Drawing.Point(904, 0);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(24, 24);
                        this.label2.TabIndex = 5;
                        this.label2.Text = "PV";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaPV
                        // 
                        this.EntradaPV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaPV.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaPV.Location = new System.Drawing.Point(928, 0);
                        this.EntradaPV.MaxLength = 2;
                        this.EntradaPV.Name = "EntradaPV";
                        this.EntradaPV.Size = new System.Drawing.Size(32, 24);
                        this.EntradaPV.TabIndex = 6;
                        this.EntradaPV.Text = "0";
                        // 
                        // PnlCuotas
                        // 
                        this.PnlCuotas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.PnlCuotas.Controls.Add(this.Label8);
                        this.PnlCuotas.Controls.Add(this.EntradaCuotas);
                        this.PnlCuotas.Controls.Add(this.Label9);
                        this.PnlCuotas.Controls.Add(this.EntradaValorCuota);
                        this.PnlCuotas.Location = new System.Drawing.Point(464, 304);
                        this.PnlCuotas.Name = "PnlCuotas";
                        this.PnlCuotas.Size = new System.Drawing.Size(188, 24);
                        this.PnlCuotas.TabIndex = 27;
                        // 
                        // EntradaIva
                        // 
                        this.EntradaIva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaIva.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaIva.Location = new System.Drawing.Point(64, 332);
                        this.EntradaIva.Name = "EntradaIva";
                        this.EntradaIva.Prefijo = "$";
                        this.EntradaIva.ReadOnly = true;
                        this.EntradaIva.Size = new System.Drawing.Size(92, 24);
                        this.EntradaIva.TabIndex = 54;
                        this.EntradaIva.TabStop = false;
                        this.EntradaIva.Text = "0.00";
                        this.EntradaIva.TextChanged += new System.EventHandler(this.RecalcularTotal);
                        // 
                        // EtiquetaIva
                        // 
                        this.EtiquetaIva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EtiquetaIva.Location = new System.Drawing.Point(0, 332);
                        this.EtiquetaIva.Name = "EtiquetaIva";
                        this.EtiquetaIva.Size = new System.Drawing.Size(64, 24);
                        this.EtiquetaIva.TabIndex = 53;
                        this.EtiquetaIva.Text = "IVA";
                        this.EtiquetaIva.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaSubTotalIva
                        // 
                        this.EntradaSubTotalIva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaSubTotalIva.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaSubTotalIva.Location = new System.Drawing.Point(162, 319);
                        this.EntradaSubTotalIva.Name = "EntradaSubTotalIva";
                        this.EntradaSubTotalIva.Prefijo = "$";
                        this.EntradaSubTotalIva.ReadOnly = true;
                        this.EntradaSubTotalIva.Size = new System.Drawing.Size(92, 24);
                        this.EntradaSubTotalIva.TabIndex = 55;
                        this.EntradaSubTotalIva.TabStop = false;
                        this.EntradaSubTotalIva.Text = "0.00";
                        // 
                        // Editar
                        // 
                        this.Controls.Add(this.EntradaSubTotalIva);
                        this.Controls.Add(this.EntradaIva);
                        this.Controls.Add(this.EtiquetaIva);
                        this.Controls.Add(this.PnlCuotas);
                        this.Controls.Add(this.EntradaPV);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.EntradaCliente);
                        this.Controls.Add(this.EntradaComprobanteId);
                        this.Controls.Add(this.EntradaInteres);
                        this.Controls.Add(this.Label7);
                        this.Controls.Add(this.EntradaDescuento);
                        this.Controls.Add(this.Label6);
                        this.Controls.Add(this.EntradaSubTotal);
                        this.Controls.Add(this.Label5);
                        this.Controls.Add(this.Label4);
                        this.Controls.Add(this.EntradaTotal);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.EntradaVendedor);
                        this.Controls.Add(this.EntradaProductos);
                        this.MinimumSize = new System.Drawing.Size(600, 360);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(960, 360);
                        this.PnlCuotas.ResumeLayout(false);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                internal Lcc.Entrada.Articulos.MatrizDetalleComprobante EntradaProductos;
                internal Lui.Forms.Label Label3;
                internal Lcc.Entrada.CodigoDetalle EntradaCliente;
                internal Lui.Forms.Label Label1;
                internal Lcc.Entrada.CodigoDetalle EntradaVendedor;
                internal Lui.Forms.TextBox EntradaTotal;
                internal Lui.Forms.Label Label4;
                internal Lui.Forms.Label Label5;
                internal Lui.Forms.TextBox EntradaSubTotal;
                internal Lui.Forms.TextBox EntradaDescuento;
                internal Lui.Forms.Label Label6;
                internal Lui.Forms.TextBox EntradaInteres;
                internal Lui.Forms.Label Label7;
                internal Lui.Forms.TextBox EntradaCuotas;
                internal Lui.Forms.Label Label8;
                internal Lui.Forms.TextBox EntradaValorCuota;
                internal Lui.Forms.Label Label9;
                internal System.Windows.Forms.TextBox EntradaComprobanteId;
                internal Lui.Forms.Label label2;
                internal Lui.Forms.TextBox EntradaPV;
                internal Lui.Forms.Panel PnlCuotas;
                internal Lui.Forms.TextBox EntradaIva;
                internal Lui.Forms.Label EtiquetaIva;
                internal Lui.Forms.TextBox EntradaSubTotalIva;
        }
}
