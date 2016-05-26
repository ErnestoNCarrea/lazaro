using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Recibos
{
        public partial class Editar
        {
                #region Código generado por el Diseñador de Windows Forms

                // Limpiar los recursos que se están utilizando.
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }
                        base.Dispose(disposing);
                }

                private void InitializeComponent()
                {
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editar));
                        this.Label3 = new Lui.Forms.Label();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaVendedor = new Lcc.Entrada.CodigoDetalle();
                        this.Label2 = new Lui.Forms.Label();
                        this.EntradaNumero = new Lui.Forms.TextBox();
                        this.ListaFacturas = new Lui.Forms.ListView();
                        this.FacturasId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.FacturasNumero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.FacturasFecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.FacturasImporte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.FacturasPendiente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.EtiquetaFacturasImporte = new Lui.Forms.Label();
                        this.BotonAgregarFactura = new Lui.Forms.Button();
                        this.BotonQuitarFactura = new Lui.Forms.Button();
                        this.PanelValores = new Lui.Forms.Panel();
                        this.LabelAgregarValores = new System.Windows.Forms.Label();
                        this.ListaValores = new Lui.Forms.ListView();
                        this.ValoresTipoPagoId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ValoresTipoPago = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ValoresImporte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ValoresObs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.BotonAgregarValor = new Lui.Forms.Button();
                        this.BotonQuitarValor = new Lui.Forms.Button();
                        this.Label4 = new Lui.Forms.Label();
                        this.EtiquetaValoresImporte = new Lui.Forms.Label();
                        this.Label5 = new Lui.Forms.Label();
                        this.EntradaCliente = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaConceptoTexto = new Lui.Forms.TextBox();
                        this.label6 = new Lui.Forms.Label();
                        this.TablaCentral = new Lui.Forms.TableLayoutPanel();
                        this.PanelComprob = new Lui.Forms.Panel();
                        this.LabelAgregarFacturas = new System.Windows.Forms.Label();
                        this.EntradaPV = new Lui.Forms.TextBox();
                        this.label7 = new Lui.Forms.Label();
                        this.EntradaConcepto = new Lcc.Entrada.CodigoDetalle();
                        this.PanelValores.SuspendLayout();
                        this.TablaCentral.SuspendLayout();
                        this.PanelComprob.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // Label3
                        // 
                        this.Label3.Dock = System.Windows.Forms.DockStyle.Top;
                        this.Label3.Location = new System.Drawing.Point(0, 0);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(372, 32);
                        this.Label3.TabIndex = 0;
                        this.Label3.Text = "Este recibo cancela los siguientes comprobantes:";
                        this.Label3.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(224, 0);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(80, 24);
                        this.Label1.TabIndex = 3;
                        this.Label1.Text = "Vendedor";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaVendedor
                        // 
                        this.EntradaVendedor.AutoTab = true;
                        this.EntradaVendedor.CanCreate = true;
                        this.EntradaVendedor.Filter = "(tipo&4)=4 AND estado=1";
                        this.EntradaVendedor.Location = new System.Drawing.Point(304, 0);
                        this.EntradaVendedor.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaVendedor.MaxLength = 200;
                        this.EntradaVendedor.Name = "EntradaVendedor";
                        this.EntradaVendedor.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaVendedor.Required = true;
                        this.EntradaVendedor.Size = new System.Drawing.Size(200, 24);
                        this.EntradaVendedor.TabIndex = 4;
                        this.EntradaVendedor.Text = "0";
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(0, 0);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(76, 24);
                        this.Label2.TabIndex = 0;
                        this.Label2.Text = "Número";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaNumero
                        // 
                        this.EntradaNumero.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaNumero.Location = new System.Drawing.Point(112, 0);
                        this.EntradaNumero.Name = "EntradaNumero";
                        this.EntradaNumero.Size = new System.Drawing.Size(100, 24);
                        this.EntradaNumero.TabIndex = 2;
                        this.EntradaNumero.Text = "0";
                        // 
                        // ListaFacturas
                        // 
                        this.ListaFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.ListaFacturas.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.ListaFacturas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FacturasId,
            this.FacturasNumero,
            this.FacturasFecha,
            this.FacturasImporte,
            this.FacturasPendiente});
                        this.ListaFacturas.FullRowSelect = true;
                        this.ListaFacturas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.ListaFacturas.HideSelection = false;
                        this.ListaFacturas.Location = new System.Drawing.Point(0, 28);
                        this.ListaFacturas.MultiSelect = false;
                        this.ListaFacturas.Name = "ListaFacturas";
                        this.ListaFacturas.Size = new System.Drawing.Size(376, 324);
                        this.ListaFacturas.Sorting = System.Windows.Forms.SortOrder.Ascending;
                        this.ListaFacturas.TabIndex = 1;
                        this.ListaFacturas.UseCompatibleStateImageBehavior = false;
                        this.ListaFacturas.View = System.Windows.Forms.View.Details;
                        this.ListaFacturas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListaFacturas_KeyDown);
                        // 
                        // FacturasId
                        // 
                        this.FacturasId.Text = "Id";
                        this.FacturasId.Width = 0;
                        // 
                        // FacturasNumero
                        // 
                        this.FacturasNumero.Text = "Nro.";
                        this.FacturasNumero.Width = 240;
                        // 
                        // FacturasFecha
                        // 
                        this.FacturasFecha.Text = "Fecha";
                        this.FacturasFecha.Width = 90;
                        // 
                        // FacturasImporte
                        // 
                        this.FacturasImporte.Text = "Importe";
                        this.FacturasImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.FacturasImporte.Width = 72;
                        // 
                        // FacturasPendiente
                        // 
                        this.FacturasPendiente.Text = "Pendiente";
                        this.FacturasPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.FacturasPendiente.Width = 72;
                        // 
                        // EtiquetaFacturasImporte
                        // 
                        this.EtiquetaFacturasImporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaFacturasImporte.Location = new System.Drawing.Point(260, 360);
                        this.EtiquetaFacturasImporte.Name = "EtiquetaFacturasImporte";
                        this.EtiquetaFacturasImporte.Size = new System.Drawing.Size(112, 43);
                        this.EtiquetaFacturasImporte.TabIndex = 5;
                        this.EtiquetaFacturasImporte.Text = "$ 0.00";
                        this.EtiquetaFacturasImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        this.EtiquetaFacturasImporte.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Bigger;
                        // 
                        // BotonAgregarFactura
                        // 
                        this.BotonAgregarFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonAgregarFactura.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonAgregarFactura.Image = null;
                        this.BotonAgregarFactura.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonAgregarFactura.Location = new System.Drawing.Point(0, 360);
                        this.BotonAgregarFactura.Name = "BotonAgregarFactura";
                        this.BotonAgregarFactura.Size = new System.Drawing.Size(104, 43);
                        this.BotonAgregarFactura.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.BotonAgregarFactura.Subtext = "F2";
                        this.BotonAgregarFactura.TabIndex = 0;
                        this.BotonAgregarFactura.Text = "Agregar";
                        this.BotonAgregarFactura.Click += new System.EventHandler(this.BotonFacturasAgregar_Click);
                        // 
                        // BotonQuitarFactura
                        // 
                        this.BotonQuitarFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonQuitarFactura.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonQuitarFactura.Image = null;
                        this.BotonQuitarFactura.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonQuitarFactura.Location = new System.Drawing.Point(112, 360);
                        this.BotonQuitarFactura.Name = "BotonQuitarFactura";
                        this.BotonQuitarFactura.Size = new System.Drawing.Size(104, 43);
                        this.BotonQuitarFactura.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.BotonQuitarFactura.Subtext = "F3";
                        this.BotonQuitarFactura.TabIndex = 1;
                        this.BotonQuitarFactura.Text = "Quitar";
                        this.BotonQuitarFactura.Visible = false;
                        this.BotonQuitarFactura.Click += new System.EventHandler(this.BotonFacturasQuitar_Click);
                        // 
                        // PanelValores
                        // 
                        this.PanelValores.Controls.Add(this.LabelAgregarValores);
                        this.PanelValores.Controls.Add(this.ListaValores);
                        this.PanelValores.Controls.Add(this.BotonAgregarValor);
                        this.PanelValores.Controls.Add(this.BotonQuitarValor);
                        this.PanelValores.Controls.Add(this.Label4);
                        this.PanelValores.Controls.Add(this.EtiquetaValoresImporte);
                        this.PanelValores.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.PanelValores.Location = new System.Drawing.Point(381, 3);
                        this.PanelValores.Name = "PanelValores";
                        this.PanelValores.Size = new System.Drawing.Size(372, 403);
                        this.PanelValores.TabIndex = 1;
                        this.PanelValores.Text = "Valores";
                        // 
                        // LabelAgregarValores
                        // 
                        this.LabelAgregarValores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.LabelAgregarValores.BackColor = System.Drawing.SystemColors.Info;
                        this.LabelAgregarValores.ForeColor = System.Drawing.SystemColors.InfoText;
                        this.LabelAgregarValores.Location = new System.Drawing.Point(4, 56);
                        this.LabelAgregarValores.Margin = new System.Windows.Forms.Padding(0);
                        this.LabelAgregarValores.Name = "LabelAgregarValores";
                        this.LabelAgregarValores.Padding = new System.Windows.Forms.Padding(12);
                        this.LabelAgregarValores.Size = new System.Drawing.Size(364, 280);
                        this.LabelAgregarValores.TabIndex = 2;
                        this.LabelAgregarValores.Text = "Seleccione uno o más valores (pagos) que componen este recibo.";
                        this.LabelAgregarValores.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.LabelAgregarValores.Click += new System.EventHandler(this.LabelAgregarValores_Click);
                        // 
                        // ListaValores
                        // 
                        this.ListaValores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.ListaValores.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.ListaValores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ValoresTipoPagoId,
            this.ValoresTipoPago,
            this.ValoresImporte,
            this.ValoresObs});
                        this.ListaValores.FullRowSelect = true;
                        this.ListaValores.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.ListaValores.HideSelection = false;
                        this.ListaValores.Location = new System.Drawing.Point(0, 28);
                        this.ListaValores.MultiSelect = false;
                        this.ListaValores.Name = "ListaValores";
                        this.ListaValores.Size = new System.Drawing.Size(372, 324);
                        this.ListaValores.TabIndex = 1;
                        this.ListaValores.UseCompatibleStateImageBehavior = false;
                        this.ListaValores.View = System.Windows.Forms.View.Details;
                        this.ListaValores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListaValores_KeyDown);
                        // 
                        // ValoresTipoPagoId
                        // 
                        this.ValoresTipoPagoId.Text = "TipoPago";
                        this.ValoresTipoPagoId.Width = 0;
                        // 
                        // ValoresTipoPago
                        // 
                        this.ValoresTipoPago.Text = "Tipo";
                        this.ValoresTipoPago.Width = 160;
                        // 
                        // ValoresImporte
                        // 
                        this.ValoresImporte.Text = "Importe";
                        this.ValoresImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.ValoresImporte.Width = 96;
                        // 
                        // ValoresObs
                        // 
                        this.ValoresObs.Text = "Obs";
                        this.ValoresObs.Width = 500;
                        // 
                        // BotonAgregarValor
                        // 
                        this.BotonAgregarValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonAgregarValor.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonAgregarValor.Image = null;
                        this.BotonAgregarValor.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonAgregarValor.Location = new System.Drawing.Point(0, 360);
                        this.BotonAgregarValor.Name = "BotonAgregarValor";
                        this.BotonAgregarValor.Size = new System.Drawing.Size(104, 43);
                        this.BotonAgregarValor.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.BotonAgregarValor.Subtext = "F4";
                        this.BotonAgregarValor.TabIndex = 0;
                        this.BotonAgregarValor.Text = "Agregar";
                        this.BotonAgregarValor.Click += new System.EventHandler(this.BotonValoresAgregar_Click);
                        // 
                        // BotonQuitarValor
                        // 
                        this.BotonQuitarValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonQuitarValor.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonQuitarValor.Image = null;
                        this.BotonQuitarValor.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonQuitarValor.Location = new System.Drawing.Point(112, 360);
                        this.BotonQuitarValor.Name = "BotonQuitarValor";
                        this.BotonQuitarValor.Size = new System.Drawing.Size(104, 43);
                        this.BotonQuitarValor.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.BotonQuitarValor.Subtext = "F5";
                        this.BotonQuitarValor.TabIndex = 1;
                        this.BotonQuitarValor.Text = "Quitar";
                        this.BotonQuitarValor.Click += new System.EventHandler(this.BotonValoresQuitar_Click);
                        // 
                        // Label4
                        // 
                        this.Label4.Dock = System.Windows.Forms.DockStyle.Top;
                        this.Label4.Location = new System.Drawing.Point(0, 0);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(372, 32);
                        this.Label4.TabIndex = 0;
                        this.Label4.Text = "Y está compuesto por los siguientes valores:";
                        this.Label4.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        // 
                        // EtiquetaValoresImporte
                        // 
                        this.EtiquetaValoresImporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaValoresImporte.Location = new System.Drawing.Point(260, 360);
                        this.EtiquetaValoresImporte.Name = "EtiquetaValoresImporte";
                        this.EtiquetaValoresImporte.Size = new System.Drawing.Size(112, 43);
                        this.EtiquetaValoresImporte.TabIndex = 5;
                        this.EtiquetaValoresImporte.Text = "$ 0.00";
                        this.EtiquetaValoresImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        this.EtiquetaValoresImporte.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Bigger;
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(512, 0);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(52, 24);
                        this.Label5.TabIndex = 5;
                        this.Label5.Text = "Cliente";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCliente
                        // 
                        this.EntradaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCliente.AutoTab = true;
                        this.EntradaCliente.CanCreate = true;
                        this.EntradaCliente.Filter = "";
                        this.EntradaCliente.Location = new System.Drawing.Point(564, 0);
                        this.EntradaCliente.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaCliente.MaxLength = 200;
                        this.EntradaCliente.Name = "EntradaCliente";
                        this.EntradaCliente.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaCliente.Required = true;
                        this.EntradaCliente.Size = new System.Drawing.Size(192, 24);
                        this.EntradaCliente.TabIndex = 6;
                        this.EntradaCliente.Text = "0";
                        // 
                        // EntradaConceptoTexto
                        // 
                        this.EntradaConceptoTexto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaConceptoTexto.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaConceptoTexto.Location = new System.Drawing.Point(84, 28);
                        this.EntradaConceptoTexto.Name = "EntradaConceptoTexto";
                        this.EntradaConceptoTexto.Size = new System.Drawing.Size(344, 24);
                        this.EntradaConceptoTexto.TabIndex = 8;
                        // 
                        // label6
                        // 
                        this.label6.Location = new System.Drawing.Point(0, 28);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(84, 24);
                        this.label6.TabIndex = 7;
                        this.label6.Text = "Descripción";
                        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // TablaCentral
                        // 
                        this.TablaCentral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.TablaCentral.ColumnCount = 2;
                        this.TablaCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                        this.TablaCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                        this.TablaCentral.Controls.Add(this.PanelValores, 1, 0);
                        this.TablaCentral.Controls.Add(this.PanelComprob, 0, 0);
                        this.TablaCentral.Location = new System.Drawing.Point(0, 64);
                        this.TablaCentral.Name = "TablaCentral";
                        this.TablaCentral.RowCount = 1;
                        this.TablaCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                        this.TablaCentral.Size = new System.Drawing.Size(756, 409);
                        this.TablaCentral.TabIndex = 11;
                        // 
                        // PanelComprob
                        // 
                        this.PanelComprob.Controls.Add(this.LabelAgregarFacturas);
                        this.PanelComprob.Controls.Add(this.ListaFacturas);
                        this.PanelComprob.Controls.Add(this.EtiquetaFacturasImporte);
                        this.PanelComprob.Controls.Add(this.BotonQuitarFactura);
                        this.PanelComprob.Controls.Add(this.BotonAgregarFactura);
                        this.PanelComprob.Controls.Add(this.Label3);
                        this.PanelComprob.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.PanelComprob.Location = new System.Drawing.Point(3, 3);
                        this.PanelComprob.Name = "PanelComprob";
                        this.PanelComprob.Size = new System.Drawing.Size(372, 403);
                        this.PanelComprob.TabIndex = 0;
                        // 
                        // LabelAgregarFacturas
                        // 
                        this.LabelAgregarFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.LabelAgregarFacturas.BackColor = System.Drawing.SystemColors.Info;
                        this.LabelAgregarFacturas.ForeColor = System.Drawing.SystemColors.InfoText;
                        this.LabelAgregarFacturas.Location = new System.Drawing.Point(4, 56);
                        this.LabelAgregarFacturas.Margin = new System.Windows.Forms.Padding(0);
                        this.LabelAgregarFacturas.Name = "LabelAgregarFacturas";
                        this.LabelAgregarFacturas.Padding = new System.Windows.Forms.Padding(12);
                        this.LabelAgregarFacturas.Size = new System.Drawing.Size(364, 280);
                        this.LabelAgregarFacturas.TabIndex = 2;
                        this.LabelAgregarFacturas.Text = resources.GetString("LabelAgregarFacturas.Text");
                        this.LabelAgregarFacturas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.LabelAgregarFacturas.Click += new System.EventHandler(this.LabelAgregarFacturas_Click);
                        // 
                        // EntradaPV
                        // 
                        this.EntradaPV.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaPV.Location = new System.Drawing.Point(76, 0);
                        this.EntradaPV.Name = "EntradaPV";
                        this.EntradaPV.Size = new System.Drawing.Size(32, 24);
                        this.EntradaPV.TabIndex = 1;
                        this.EntradaPV.Text = "0";
                        // 
                        // label7
                        // 
                        this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.label7.Location = new System.Drawing.Point(440, 28);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(76, 24);
                        this.label7.TabIndex = 9;
                        this.label7.Text = "Concepto";
                        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaConcepto
                        // 
                        this.EntradaConcepto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaConcepto.AutoTab = true;
                        this.EntradaConcepto.CanCreate = true;
                        this.EntradaConcepto.Location = new System.Drawing.Point(516, 28);
                        this.EntradaConcepto.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaConcepto.MaxLength = 200;
                        this.EntradaConcepto.Name = "EntradaConcepto";
                        this.EntradaConcepto.NombreTipo = "Lbl.Cajas.Concepto";
                        this.EntradaConcepto.PlaceholderText = "Sin especificar";
                        this.EntradaConcepto.Required = true;
                        this.EntradaConcepto.Size = new System.Drawing.Size(240, 24);
                        this.EntradaConcepto.TabIndex = 10;
                        this.EntradaConcepto.Text = "0";
                        // 
                        // Editar
                        // 
                        this.Controls.Add(this.label7);
                        this.Controls.Add(this.EntradaConcepto);
                        this.Controls.Add(this.EntradaConceptoTexto);
                        this.Controls.Add(this.EntradaPV);
                        this.Controls.Add(this.EntradaNumero);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.Label5);
                        this.Controls.Add(this.TablaCentral);
                        this.Controls.Add(this.label6);
                        this.Controls.Add(this.EntradaCliente);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.EntradaVendedor);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(756, 474);
                        this.PanelValores.ResumeLayout(false);
                        this.TablaCentral.ResumeLayout(false);
                        this.PanelComprob.ResumeLayout(false);
                        this.ResumeLayout(false);

                }


                #endregion

                private System.ComponentModel.IContainer components = null;
                private Lui.Forms.Label Label3;
                private Lui.Forms.Label Label1;
                private Lcc.Entrada.CodigoDetalle EntradaVendedor;
                private Lui.Forms.Label Label2;
                private Lui.Forms.TextBox EntradaNumero;
                private Lui.Forms.ListView ListaFacturas;
                private Lui.Forms.Button BotonAgregarFactura;
                private Lui.Forms.Panel PanelValores;
                private Lui.Forms.ListView ListaValores;
                private Lui.Forms.Label EtiquetaFacturasImporte;
                private Lui.Forms.Button BotonQuitarFactura;
                private Lui.Forms.Label EtiquetaValoresImporte;
                private Lui.Forms.Button BotonAgregarValor;
                private Lui.Forms.Button BotonQuitarValor;
                private System.Windows.Forms.ColumnHeader FacturasId;
                private System.Windows.Forms.ColumnHeader FacturasNumero;
                private System.Windows.Forms.ColumnHeader FacturasFecha;
                private System.Windows.Forms.ColumnHeader FacturasPendiente;
                private System.Windows.Forms.ColumnHeader ValoresTipoPagoId;
                private System.Windows.Forms.ColumnHeader ValoresTipoPago;
                private System.Windows.Forms.ColumnHeader ValoresImporte;
                private System.Windows.Forms.ColumnHeader ValoresObs;
                private System.Windows.Forms.ColumnHeader FacturasImporte;
                private Lui.Forms.Label Label4;
                private Lui.Forms.Label Label5;
                private Lcc.Entrada.CodigoDetalle EntradaCliente;
                private Lui.Forms.TextBox EntradaConceptoTexto;
                private Lui.Forms.TextBox EntradaPV;
                private Lcc.Entrada.CodigoDetalle EntradaConcepto;
                private Lui.Forms.Label label6;
                private Lui.Forms.Label label7;
                private Label LabelAgregarValores;
                private Label LabelAgregarFacturas;
                private Lui.Forms.Panel PanelComprob;
                private Lui.Forms.TableLayoutPanel TablaCentral;

        }
}
