namespace Lfc.Comprobantes.Compra
{
        partial class Editar
        {
                /// <summary> 
                /// Variable del diseñador requerida.
                /// </summary>
                private System.ComponentModel.IContainer components = null;

                /// <summary> 
                /// Limpiar los recursos que se estén utilizando.
                /// </summary>
                /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
                protected override void Dispose(bool disposing)
                {
                        if (disposing && (components != null)) {
                                components.Dispose();
                        }
                        base.Dispose(disposing);
                }

                #region Código generado por el Diseñador de componentes

                /// <summary> 
                /// Método necesario para admitir el Diseñador. No se puede modificar 
                /// el contenido del método con el editor de código.
                /// </summary>
                private void InitializeComponent()
                {
                        this.EntradaTipo = new Lui.Forms.ComboBox();
                        this.EntradaFormaPago = new Lui.Forms.ComboBox();
                        this.EntradaFecha = new Lui.Forms.TextBox();
                        this.EntradaPV = new Lui.Forms.TextBox();
                        this.EntradaHaciaSituacion = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaNumero = new Lui.Forms.TextBox();
                        this.EntradaProductos = new Lcc.Entrada.Articulos.MatrizDetalleComprobante();
                        this.EntradaProveedor = new Lcc.Entrada.CodigoDetalle();
                        this.label7 = new Lui.Forms.Label();
                        this.EtiquetaHaciaSituacion = new Lui.Forms.Label();
                        this.Label2 = new Lui.Forms.Label();
                        this.Label3 = new Lui.Forms.Label();
                        this.EntradaEstado = new Lui.Forms.ComboBox();
                        this.BotonObs = new Lui.Forms.Button();
                        this.BotonConvertir = new Lui.Forms.Button();
                        this.EntradaOtrosGastos = new Lui.Forms.TextBox();
                        this.EntradaCancelado = new Lui.Forms.TextBox();
                        this.EntradaGastosEnvio = new Lui.Forms.TextBox();
                        this.EntradaTotal = new Lui.Forms.TextBox();
                        this.EntradaObs = new System.Windows.Forms.TextBox();
                        this.label9 = new Lui.Forms.Label();
                        this.label6 = new Lui.Forms.Label();
                        this.EtiquetaEstado = new Lui.Forms.Label();
                        this.label1 = new Lui.Forms.Label();
                        this.Label4 = new Lui.Forms.Label();
                        this.Contenedor = new Lui.Forms.Panel();
                        this.Contenedor.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // EntradaTipo
                        // 
                        this.EntradaTipo.AlwaysExpanded = false;
                        this.EntradaTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaTipo.AutoSize = true;
                        this.EntradaTipo.Location = new System.Drawing.Point(312, 0);
                        this.EntradaTipo.Name = "EntradaTipo";
                        this.EntradaTipo.SetData = new string[] {
        "Factura A|FA"};
                        this.EntradaTipo.Size = new System.Drawing.Size(132, 25);
                        this.EntradaTipo.TabIndex = 17;
                        this.EntradaTipo.TextKey = "FA";
                        this.EntradaTipo.TextChanged += new System.EventHandler(this.EntradaTipoPvNumero_TextChanged);
                        // 
                        // EntradaFormaPago
                        // 
                        this.EntradaFormaPago.AlwaysExpanded = false;
                        this.EntradaFormaPago.AutoSize = true;
                        this.EntradaFormaPago.Location = new System.Drawing.Point(188, 28);
                        this.EntradaFormaPago.Name = "EntradaFormaPago";
                        this.EntradaFormaPago.SetData = new string[] {
        "No controla pago|0",
        "Efectivo|1",
        "Cuenta corriente|3"};
                        this.EntradaFormaPago.Size = new System.Drawing.Size(176, 25);
                        this.EntradaFormaPago.TabIndex = 23;
                        this.EntradaFormaPago.TextKey = "0";
                        // 
                        // EntradaFecha
                        // 
                        this.EntradaFecha.DataType = Lui.Forms.DataTypes.Date;
                        this.EntradaFecha.Location = new System.Drawing.Point(80, 28);
                        this.EntradaFecha.Name = "EntradaFecha";
                        this.EntradaFecha.Size = new System.Drawing.Size(100, 24);
                        this.EntradaFecha.TabIndex = 21;
                        // 
                        // EntradaPV
                        // 
                        this.EntradaPV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaPV.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaPV.Location = new System.Drawing.Point(480, 0);
                        this.EntradaPV.Name = "EntradaPV";
                        this.EntradaPV.Size = new System.Drawing.Size(56, 24);
                        this.EntradaPV.TabIndex = 18;
                        this.EntradaPV.Text = "0";
                        this.EntradaPV.TextChanged += new System.EventHandler(this.EntradaTipoPvNumero_TextChanged);
                        // 
                        // EntradaHaciaSituacion
                        // 
                        this.EntradaHaciaSituacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaHaciaSituacion.AutoTab = true;
                        this.EntradaHaciaSituacion.CanCreate = false;
                        this.EntradaHaciaSituacion.Filter = "deposito>0";
                        this.EntradaHaciaSituacion.Location = new System.Drawing.Point(444, 28);
                        this.EntradaHaciaSituacion.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaHaciaSituacion.MaxLength = 200;
                        this.EntradaHaciaSituacion.Name = "EntradaHaciaSituacion";
                        this.EntradaHaciaSituacion.NombreTipo = "Lbl.Articulos.Situacion";
                        this.EntradaHaciaSituacion.Required = true;
                        this.EntradaHaciaSituacion.Size = new System.Drawing.Size(197, 24);
                        this.EntradaHaciaSituacion.TabIndex = 25;
                        this.EntradaHaciaSituacion.Text = "0";
                        // 
                        // EntradaNumero
                        // 
                        this.EntradaNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaNumero.Location = new System.Drawing.Point(540, 0);
                        this.EntradaNumero.Name = "EntradaNumero";
                        this.EntradaNumero.Size = new System.Drawing.Size(100, 24);
                        this.EntradaNumero.TabIndex = 19;
                        this.EntradaNumero.TextChanged += new System.EventHandler(this.EntradaTipoPvNumero_TextChanged);
                        this.EntradaNumero.Leave += new System.EventHandler(this.EntradaNumero_Leave);
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
                        this.EntradaProductos.FreeTextCode = "*";
                        this.EntradaProductos.Location = new System.Drawing.Point(0, 64);
                        this.EntradaProductos.Name = "EntradaProductos";
                        this.EntradaProductos.Precio = Lcc.Entrada.Articulos.Precios.Costo;
                        this.EntradaProductos.ShowStock = false;
                        this.EntradaProductos.Size = new System.Drawing.Size(642, 240);
                        this.EntradaProductos.TabIndex = 26;
                        this.EntradaProductos.TotalChanged += new System.EventHandler(this.RecalcularTotal);
                        this.EntradaProductos.ObtenerDatosSeguimiento += new System.EventHandler(this.EntradaProductos_ObtenerDatosSeguimiento);
                        this.EntradaProductos.TextChanged += new System.EventHandler(this.RecalcularTotal);
                        // 
                        // EntradaProveedor
                        // 
                        this.EntradaProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaProveedor.AutoTab = true;
                        this.EntradaProveedor.CanCreate = true;
                        this.EntradaProveedor.Filter = "estado=1";
                        this.EntradaProveedor.Location = new System.Drawing.Point(80, 0);
                        this.EntradaProveedor.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaProveedor.MaxLength = 200;
                        this.EntradaProveedor.Name = "EntradaProveedor";
                        this.EntradaProveedor.NombreTipo = "Lbl.Personas.Proveedor";
                        this.EntradaProveedor.Required = true;
                        this.EntradaProveedor.Size = new System.Drawing.Size(192, 24);
                        this.EntradaProveedor.TabIndex = 15;
                        this.EntradaProveedor.Text = "0";
                        // 
                        // label7
                        // 
                        this.label7.Location = new System.Drawing.Point(0, 28);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(80, 24);
                        this.label7.TabIndex = 20;
                        this.label7.Text = "Fecha";
                        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EtiquetaHaciaSituacion
                        // 
                        this.EtiquetaHaciaSituacion.Location = new System.Drawing.Point(372, 28);
                        this.EtiquetaHaciaSituacion.Name = "EtiquetaHaciaSituacion";
                        this.EtiquetaHaciaSituacion.Size = new System.Drawing.Size(68, 24);
                        this.EtiquetaHaciaSituacion.TabIndex = 24;
                        this.EtiquetaHaciaSituacion.Text = "Destino";
                        this.EtiquetaHaciaSituacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label2
                        // 
                        this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label2.Location = new System.Drawing.Point(448, 0);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(28, 24);
                        this.Label2.TabIndex = 16;
                        this.Label2.Text = "Nº";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(0, 0);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(80, 24);
                        this.Label3.TabIndex = 14;
                        this.Label3.Text = "Proveedor";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaEstado
                        // 
                        this.EntradaEstado.AlwaysExpanded = true;
                        this.EntradaEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaEstado.AutoSize = true;
                        this.EntradaEstado.Location = new System.Drawing.Point(288, 312);
                        this.EntradaEstado.Name = "EntradaEstado";
                        this.EntradaEstado.SetData = new string[] {
        "N/A|0"};
                        this.EntradaEstado.Size = new System.Drawing.Size(164, 23);
                        this.EntradaEstado.TabIndex = 55;
                        this.EntradaEstado.TextKey = "0";
                        // 
                        // BotonObs
                        // 
                        this.BotonObs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonObs.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonObs.Image = null;
                        this.BotonObs.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonObs.Location = new System.Drawing.Point(116, 368);
                        this.BotonObs.Name = "BotonObs";
                        this.BotonObs.Size = new System.Drawing.Size(108, 32);
                        this.BotonObs.SubLabelPos = Lui.Forms.SubLabelPositions.Right;
                        this.BotonObs.Subtext = "F7";
                        this.BotonObs.TabIndex = 62;
                        this.BotonObs.Text = "Observac.";
                        this.BotonObs.Click += new System.EventHandler(this.BotonObs_Click);
                        // 
                        // BotonConvertir
                        // 
                        this.BotonConvertir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonConvertir.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonConvertir.Image = null;
                        this.BotonConvertir.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonConvertir.Location = new System.Drawing.Point(0, 368);
                        this.BotonConvertir.Name = "BotonConvertir";
                        this.BotonConvertir.Size = new System.Drawing.Size(108, 32);
                        this.BotonConvertir.SubLabelPos = Lui.Forms.SubLabelPositions.Right;
                        this.BotonConvertir.Subtext = "F4";
                        this.BotonConvertir.TabIndex = 60;
                        this.BotonConvertir.Text = "Convertir";
                        this.BotonConvertir.Click += new System.EventHandler(this.BotonConvertir_Click);
                        // 
                        // EntradaOtrosGastos
                        // 
                        this.EntradaOtrosGastos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaOtrosGastos.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaOtrosGastos.Location = new System.Drawing.Point(116, 340);
                        this.EntradaOtrosGastos.Name = "EntradaOtrosGastos";
                        this.EntradaOtrosGastos.Prefijo = "$";
                        this.EntradaOtrosGastos.Size = new System.Drawing.Size(104, 24);
                        this.EntradaOtrosGastos.TabIndex = 53;
                        this.EntradaOtrosGastos.Text = "0.00";
                        this.EntradaOtrosGastos.TextChanged += new System.EventHandler(this.RecalcularTotal);
                        // 
                        // EntradaCancelado
                        // 
                        this.EntradaCancelado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCancelado.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaCancelado.Location = new System.Drawing.Point(516, 372);
                        this.EntradaCancelado.Name = "EntradaCancelado";
                        this.EntradaCancelado.Prefijo = "$";
                        this.EntradaCancelado.Size = new System.Drawing.Size(124, 28);
                        this.EntradaCancelado.TabIndex = 59;
                        this.EntradaCancelado.TabStop = false;
                        this.EntradaCancelado.Text = "0.00";
                        this.EntradaCancelado.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Bigger;
                        // 
                        // EntradaGastosEnvio
                        // 
                        this.EntradaGastosEnvio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaGastosEnvio.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaGastosEnvio.Location = new System.Drawing.Point(116, 312);
                        this.EntradaGastosEnvio.Name = "EntradaGastosEnvio";
                        this.EntradaGastosEnvio.Prefijo = "$";
                        this.EntradaGastosEnvio.Size = new System.Drawing.Size(104, 24);
                        this.EntradaGastosEnvio.TabIndex = 51;
                        this.EntradaGastosEnvio.Text = "0.00";
                        this.EntradaGastosEnvio.TextChanged += new System.EventHandler(this.RecalcularTotal);
                        // 
                        // EntradaTotal
                        // 
                        this.EntradaTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaTotal.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaTotal.Location = new System.Drawing.Point(516, 340);
                        this.EntradaTotal.Name = "EntradaTotal";
                        this.EntradaTotal.Prefijo = "$";
                        this.EntradaTotal.Size = new System.Drawing.Size(124, 28);
                        this.EntradaTotal.TabIndex = 57;
                        this.EntradaTotal.TabStop = false;
                        this.EntradaTotal.Text = "0.00";
                        this.EntradaTotal.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Bigger;
                        // 
                        // EntradaObs
                        // 
                        this.EntradaObs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaObs.Location = new System.Drawing.Point(224, 340);
                        this.EntradaObs.Name = "EntradaObs";
                        this.EntradaObs.Size = new System.Drawing.Size(32, 25);
                        this.EntradaObs.TabIndex = 61;
                        this.EntradaObs.Visible = false;
                        // 
                        // label9
                        // 
                        this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.label9.Location = new System.Drawing.Point(0, 340);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(116, 24);
                        this.label9.TabIndex = 52;
                        this.label9.Text = "Otros Gastos";
                        this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label6
                        // 
                        this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.label6.Location = new System.Drawing.Point(412, 372);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(104, 28);
                        this.label6.TabIndex = 58;
                        this.label6.Text = "Cancelado";
                        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        this.label6.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
                        // 
                        // EtiquetaEstado
                        // 
                        this.EtiquetaEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.EtiquetaEstado.Location = new System.Drawing.Point(226, 312);
                        this.EtiquetaEstado.Name = "EtiquetaEstado";
                        this.EtiquetaEstado.Size = new System.Drawing.Size(60, 24);
                        this.EtiquetaEstado.TabIndex = 54;
                        this.EtiquetaEstado.Text = "Estado";
                        this.EtiquetaEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label1
                        // 
                        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.label1.Location = new System.Drawing.Point(0, 312);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(116, 24);
                        this.label1.TabIndex = 50;
                        this.label1.Text = "Gastos de Envío";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label4
                        // 
                        this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label4.Location = new System.Drawing.Point(412, 340);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(104, 28);
                        this.Label4.TabIndex = 56;
                        this.Label4.Text = "Total";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        this.Label4.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
                        // 
                        // Contenedor
                        // 
                        this.Contenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Contenedor.Controls.Add(this.EntradaEstado);
                        this.Contenedor.Controls.Add(this.EntradaFormaPago);
                        this.Contenedor.Controls.Add(this.EntradaTipo);
                        this.Contenedor.Controls.Add(this.EntradaObs);
                        this.Contenedor.Controls.Add(this.BotonObs);
                        this.Contenedor.Controls.Add(this.Label3);
                        this.Contenedor.Controls.Add(this.BotonConvertir);
                        this.Contenedor.Controls.Add(this.Label2);
                        this.Contenedor.Controls.Add(this.EntradaOtrosGastos);
                        this.Contenedor.Controls.Add(this.EtiquetaHaciaSituacion);
                        this.Contenedor.Controls.Add(this.EntradaCancelado);
                        this.Contenedor.Controls.Add(this.label7);
                        this.Contenedor.Controls.Add(this.EntradaGastosEnvio);
                        this.Contenedor.Controls.Add(this.EntradaProveedor);
                        this.Contenedor.Controls.Add(this.EntradaTotal);
                        this.Contenedor.Controls.Add(this.EntradaProductos);
                        this.Contenedor.Controls.Add(this.EntradaNumero);
                        this.Contenedor.Controls.Add(this.label9);
                        this.Contenedor.Controls.Add(this.EntradaHaciaSituacion);
                        this.Contenedor.Controls.Add(this.label6);
                        this.Contenedor.Controls.Add(this.EntradaPV);
                        this.Contenedor.Controls.Add(this.EtiquetaEstado);
                        this.Contenedor.Controls.Add(this.EntradaFecha);
                        this.Contenedor.Controls.Add(this.label1);
                        this.Contenedor.Controls.Add(this.Label4);
                        this.Contenedor.Location = new System.Drawing.Point(0, 0);
                        this.Contenedor.Name = "Contenedor";
                        this.Contenedor.Size = new System.Drawing.Size(640, 400);
                        this.Contenedor.TabIndex = 0;
                        // 
                        // Editar
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.Contenedor);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(640, 400);
                        this.Contenedor.ResumeLayout(false);
                        this.Contenedor.PerformLayout();
                        this.ResumeLayout(false);

                }

                #endregion

                internal Lui.Forms.ComboBox EntradaTipo;
                internal Lui.Forms.ComboBox EntradaFormaPago;
                internal Lui.Forms.TextBox EntradaFecha;
                internal Lui.Forms.TextBox EntradaPV;
                internal Lcc.Entrada.CodigoDetalle EntradaHaciaSituacion;
                internal Lui.Forms.TextBox EntradaNumero;
                internal Lcc.Entrada.Articulos.MatrizDetalleComprobante EntradaProductos;
                internal Lcc.Entrada.CodigoDetalle EntradaProveedor;
                internal Lui.Forms.Label label7;
                internal Lui.Forms.Label EtiquetaHaciaSituacion;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.Label Label3;
                internal Lui.Forms.ComboBox EntradaEstado;
                internal Lui.Forms.Button BotonObs;
                internal Lui.Forms.Button BotonConvertir;
                internal Lui.Forms.TextBox EntradaOtrosGastos;
                internal Lui.Forms.TextBox EntradaCancelado;
                internal Lui.Forms.TextBox EntradaGastosEnvio;
                internal Lui.Forms.TextBox EntradaTotal;
                internal System.Windows.Forms.TextBox EntradaObs;
                internal Lui.Forms.Label label9;
                internal Lui.Forms.Label label6;
                internal Lui.Forms.Label EtiquetaEstado;
                internal Lui.Forms.Label label1;
                internal Lui.Forms.Label Label4;
                private Lui.Forms.Panel Contenedor;
        }
}
