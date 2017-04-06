using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Reportes
{
        public class IngresosEgresos : Lui.Forms.ChildForm
        {

                private string Fecha1Sql = "";
                private string Fecha2Sql = "";
                internal Lui.Forms.Button ChartButton;
                internal Lui.Forms.TextBox txtCompraMateriales;
                internal Lui.Forms.Label label25;
                internal Lui.Forms.TextBox txtCostoCapital;
                internal Lui.Forms.Label label26;
                internal Lui.Forms.Label label27;
                internal Lui.Forms.Button BotonCostoCapital;
                internal Lui.Forms.Button BotonCostoMateriales;
                internal Lui.Forms.Button BotonIngresosOtros;
                internal Lui.Forms.TextBox EntradaIngresosOtros;
                internal Lui.Forms.Label label24;
                internal Label label4;
                internal Label label8;
                internal Label label12;
                internal Label label14;
                internal Lui.Forms.TextBox EntradaGestionCobro;
                internal Lui.Forms.Button BotonGestionCobro;
                internal Lui.Forms.Button PorTipo;

                #region Código generado por el Diseñador de Windows Forms

                public IngresosEgresos()
                        : base()
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.Cajas.Caja), Lbl.Sys.Permisos.Operaciones.Administrar) == false) {
                                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                                this.Close();
                                return;
                        }

                        InitializeComponent();
                }

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


                // Requerido por el Diseñador de Windows Forms
                private System.ComponentModel.IContainer components = null;

                // NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
                // Puede modificarse utilizando el Diseñador de Windows Forms. 
                // No lo modifique con el editor de código.
                internal Lui.Forms.Label Label1;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.Label Label3;
                internal Lui.Forms.Label Label5;
                internal Lui.Forms.Label Label6;
                internal Lui.Forms.Label Label7;
                internal Lui.Forms.TextBox EntradaFacturacion;
                internal Lui.Forms.TextBox txtCosto;
                internal Lui.Forms.TextBox txtGastosFijos;
                internal Lui.Forms.TextBox txtGastosVariables;
                internal Lui.Forms.TextBox txtOtrosEgresos;
                internal Lui.Forms.ListView Listado;
                internal System.Windows.Forms.ColumnHeader id;
                internal System.Windows.Forms.ColumnHeader fecha;
                internal System.Windows.Forms.ColumnHeader concepto;
                internal System.Windows.Forms.ColumnHeader comprob;
                internal Lui.Forms.Button BotonGastosFijos;
                internal Lui.Forms.Button BotonGastosVariables;
                internal Lui.Forms.Button BotonOtrosEgresos;
                internal System.Windows.Forms.ColumnHeader importe;
                internal System.Windows.Forms.ColumnHeader cuenta;
                internal System.Windows.Forms.ColumnHeader obs;
                internal Lui.Forms.TextBox txtCobros;
                internal Lui.Forms.Label Label10;
                internal Lui.Forms.Button BotonCobros;
                internal Lui.Forms.TextBox txtDiferenciaNeta;
                internal Lui.Forms.Label Label9;
                internal Lui.Forms.TextBox txtDiferenciaBruta;
                internal Lui.Forms.Label Label11;
                internal Lui.Forms.Label Label13;
                internal Lui.Forms.Label Label15;
                internal Lui.Forms.Label Label16;
                internal Lui.Forms.Label Label17;
                internal Lui.Forms.Label Label18;
                internal Lui.Forms.Label Label20;
                internal Lui.Forms.TextBox txtFecha1;
                internal Lui.Forms.TextBox txtFecha2;
                internal Lui.Forms.Label Label22;
                internal Lui.Forms.Label lblDiferenciaBrutaPct;
                internal Lui.Forms.Label lblDiferenciaNetaPct;

                private void InitializeComponent()
                {
                        this.Label1 = new Lui.Forms.Label();
                        this.Label2 = new Lui.Forms.Label();
                        this.Label3 = new Lui.Forms.Label();
                        this.Label5 = new Lui.Forms.Label();
                        this.Label6 = new Lui.Forms.Label();
                        this.Label7 = new Lui.Forms.Label();
                        this.EntradaFacturacion = new Lui.Forms.TextBox();
                        this.txtCosto = new Lui.Forms.TextBox();
                        this.txtGastosFijos = new Lui.Forms.TextBox();
                        this.txtGastosVariables = new Lui.Forms.TextBox();
                        this.txtOtrosEgresos = new Lui.Forms.TextBox();
                        this.BotonGastosFijos = new Lui.Forms.Button();
                        this.BotonGastosVariables = new Lui.Forms.Button();
                        this.BotonOtrosEgresos = new Lui.Forms.Button();
                        this.Listado = new Lui.Forms.ListView();
                        this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.fecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.concepto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.importe = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.cuenta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.comprob = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.obs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.txtCobros = new Lui.Forms.TextBox();
                        this.Label10 = new Lui.Forms.Label();
                        this.BotonCobros = new Lui.Forms.Button();
                        this.txtDiferenciaNeta = new Lui.Forms.TextBox();
                        this.Label9 = new Lui.Forms.Label();
                        this.txtDiferenciaBruta = new Lui.Forms.TextBox();
                        this.Label11 = new Lui.Forms.Label();
                        this.Label13 = new Lui.Forms.Label();
                        this.Label15 = new Lui.Forms.Label();
                        this.Label16 = new Lui.Forms.Label();
                        this.Label17 = new Lui.Forms.Label();
                        this.Label18 = new Lui.Forms.Label();
                        this.Label20 = new Lui.Forms.Label();
                        this.txtFecha1 = new Lui.Forms.TextBox();
                        this.txtFecha2 = new Lui.Forms.TextBox();
                        this.Label22 = new Lui.Forms.Label();
                        this.lblDiferenciaBrutaPct = new Lui.Forms.Label();
                        this.lblDiferenciaNetaPct = new Lui.Forms.Label();
                        this.ChartButton = new Lui.Forms.Button();
                        this.PorTipo = new Lui.Forms.Button();
                        this.txtCompraMateriales = new Lui.Forms.TextBox();
                        this.label25 = new Lui.Forms.Label();
                        this.BotonCostoCapital = new Lui.Forms.Button();
                        this.txtCostoCapital = new Lui.Forms.TextBox();
                        this.label26 = new Lui.Forms.Label();
                        this.label27 = new Lui.Forms.Label();
                        this.BotonCostoMateriales = new Lui.Forms.Button();
                        this.BotonIngresosOtros = new Lui.Forms.Button();
                        this.EntradaIngresosOtros = new Lui.Forms.TextBox();
                        this.label24 = new Lui.Forms.Label();
                        this.label4 = new Lui.Forms.Label();
                        this.label8 = new Lui.Forms.Label();
                        this.label12 = new Lui.Forms.Label();
                        this.label14 = new Lui.Forms.Label();
                        this.EntradaGestionCobro = new Lui.Forms.TextBox();
                        this.BotonGestionCobro = new Lui.Forms.Button();
                        this.SuspendLayout();
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(12, 12);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(44, 24);
                        this.Label1.TabIndex = 0;
                        this.Label1.Text = "Entre";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(16, 68);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(172, 24);
                        this.Label2.TabIndex = 28;
                        this.Label2.Text = "Facturación Total";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(16, 428);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(172, 24);
                        this.Label3.TabIndex = 10;
                        this.Label3.Text = "Compra de Materiales";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(16, 220);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(172, 24);
                        this.Label5.TabIndex = 16;
                        this.Label5.Text = "Gastos Fijos";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label6
                        // 
                        this.Label6.Location = new System.Drawing.Point(16, 248);
                        this.Label6.Name = "Label6";
                        this.Label6.Size = new System.Drawing.Size(172, 24);
                        this.Label6.TabIndex = 19;
                        this.Label6.Text = "Gastos Variables";
                        this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label7
                        // 
                        this.Label7.Location = new System.Drawing.Point(16, 276);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(172, 24);
                        this.Label7.TabIndex = 22;
                        this.Label7.Text = "Otros Egresos";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // txtFacturacion
                        // 
                        this.EntradaFacturacion.AutoSize = false;
                        this.EntradaFacturacion.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaFacturacion.Location = new System.Drawing.Point(188, 68);
                        this.EntradaFacturacion.Name = "txtFacturacion";
                        this.EntradaFacturacion.TemporaryReadOnly = true;
                        this.EntradaFacturacion.Size = new System.Drawing.Size(104, 24);
                        this.EntradaFacturacion.TabIndex = 29;
                        this.EntradaFacturacion.TabStop = false;
                        this.EntradaFacturacion.GotFocus += new System.EventHandler(this.EntradaFacturacion_GotFocus);
                        // 
                        // txtCosto
                        // 
                        this.txtCosto.AutoSize = false;
                        this.txtCosto.DataType = Lui.Forms.DataTypes.Currency;
                        this.txtCosto.Location = new System.Drawing.Point(188, 96);
                        this.txtCosto.Name = "txtCosto";
                        this.txtCosto.TemporaryReadOnly = true;
                        this.txtCosto.Size = new System.Drawing.Size(104, 24);
                        this.txtCosto.TabIndex = 31;
                        this.txtCosto.TabStop = false;
                        // 
                        // txtGastosFijos
                        // 
                        this.txtGastosFijos.AutoSize = false;
                        this.txtGastosFijos.DataType = Lui.Forms.DataTypes.Currency;
                        this.txtGastosFijos.Location = new System.Drawing.Point(188, 220);
                        this.txtGastosFijos.Name = "txtGastosFijos";
                        this.txtGastosFijos.TemporaryReadOnly = true;
                        this.txtGastosFijos.Size = new System.Drawing.Size(104, 24);
                        this.txtGastosFijos.TabIndex = 17;
                        this.txtGastosFijos.TabStop = false;
                        // 
                        // txtGastosVariables
                        // 
                        this.txtGastosVariables.AutoSize = false;
                        this.txtGastosVariables.DataType = Lui.Forms.DataTypes.Currency;
                        this.txtGastosVariables.Location = new System.Drawing.Point(188, 248);
                        this.txtGastosVariables.Name = "txtGastosVariables";
                        this.txtGastosVariables.TemporaryReadOnly = true;
                        this.txtGastosVariables.Size = new System.Drawing.Size(104, 24);
                        this.txtGastosVariables.TabIndex = 20;
                        this.txtGastosVariables.TabStop = false;
                        // 
                        // txtOtrosEgresos
                        // 
                        this.txtOtrosEgresos.AutoSize = false;
                        this.txtOtrosEgresos.DataType = Lui.Forms.DataTypes.Currency;
                        this.txtOtrosEgresos.Location = new System.Drawing.Point(188, 276);
                        this.txtOtrosEgresos.Name = "txtOtrosEgresos";
                        this.txtOtrosEgresos.TemporaryReadOnly = true;
                        this.txtOtrosEgresos.Size = new System.Drawing.Size(104, 24);
                        this.txtOtrosEgresos.TabIndex = 23;
                        this.txtOtrosEgresos.TabStop = false;
                        // 
                        // BotonGastosFijos
                        // 
                        this.BotonGastosFijos.AutoSize = false;
                        this.BotonGastosFijos.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonGastosFijos.Image = null;
                        this.BotonGastosFijos.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonGastosFijos.Location = new System.Drawing.Point(296, 220);
                        this.BotonGastosFijos.Name = "BotonGastosFijos";
                        this.BotonGastosFijos.Size = new System.Drawing.Size(28, 24);
                        this.BotonGastosFijos.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonGastosFijos.Subtext = "";
                        this.BotonGastosFijos.TabIndex = 18;
                        this.BotonGastosFijos.Text = "...";
                        this.BotonGastosFijos.Click += new System.EventHandler(this.BotonGastosFijos_Click);
                        // 
                        // BotonGastosVariables
                        // 
                        this.BotonGastosVariables.AutoSize = false;
                        this.BotonGastosVariables.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonGastosVariables.Image = null;
                        this.BotonGastosVariables.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonGastosVariables.Location = new System.Drawing.Point(296, 248);
                        this.BotonGastosVariables.Name = "BotonGastosVariables";
                        this.BotonGastosVariables.Size = new System.Drawing.Size(28, 24);
                        this.BotonGastosVariables.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonGastosVariables.Subtext = "";
                        this.BotonGastosVariables.TabIndex = 21;
                        this.BotonGastosVariables.Text = "...";
                        this.BotonGastosVariables.Click += new System.EventHandler(this.BotonGastosVariables_Click);
                        // 
                        // BotonOtrosEgresos
                        // 
                        this.BotonOtrosEgresos.AutoSize = false;
                        this.BotonOtrosEgresos.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonOtrosEgresos.Image = null;
                        this.BotonOtrosEgresos.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonOtrosEgresos.Location = new System.Drawing.Point(296, 276);
                        this.BotonOtrosEgresos.Name = "BotonOtrosEgresos";
                        this.BotonOtrosEgresos.Size = new System.Drawing.Size(28, 24);
                        this.BotonOtrosEgresos.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonOtrosEgresos.Subtext = "";
                        this.BotonOtrosEgresos.TabIndex = 24;
                        this.BotonOtrosEgresos.Text = "...";
                        this.BotonOtrosEgresos.Click += new System.EventHandler(this.BotonOtrosEgresos_Click);
                        // 
                        // lvItems
                        // 
                        this.Listado.AllowColumnReorder = true;
                        this.Listado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.Listado.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.Listado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.fecha,
            this.concepto,
            this.importe,
            this.cuenta,
            this.comprob,
            this.obs});
                        this.Listado.FullRowSelect = true;
                        this.Listado.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.Listado.HideSelection = false;
                        this.Listado.Location = new System.Drawing.Point(352, 8);
                        this.Listado.MultiSelect = false;
                        this.Listado.Name = "lvItems";
                        this.Listado.Size = new System.Drawing.Size(332, 522);
                        this.Listado.TabIndex = 37;
                        this.Listado.UseCompatibleStateImageBehavior = false;
                        this.Listado.View = System.Windows.Forms.View.Details;
                        this.Listado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvItems_KeyDown);
                        // 
                        // id
                        // 
                        this.id.Text = "Cód";
                        this.id.Width = 0;
                        // 
                        // fecha
                        // 
                        this.fecha.Text = "Fecha";
                        this.fecha.Width = 86;
                        // 
                        // concepto
                        // 
                        this.concepto.Text = "Concepto";
                        this.concepto.Width = 240;
                        // 
                        // importe
                        // 
                        this.importe.Text = "Importe";
                        this.importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.importe.Width = 86;
                        // 
                        // cuenta
                        // 
                        this.cuenta.Text = "Caja";
                        this.cuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.cuenta.Width = 46;
                        // 
                        // comprob
                        // 
                        this.comprob.Text = "Comprob.";
                        this.comprob.Width = 96;
                        // 
                        // obs
                        // 
                        this.obs.Text = "Obs.";
                        this.obs.Width = 240;
                        // 
                        // txtCobros
                        // 
                        this.txtCobros.AutoSize = false;
                        this.txtCobros.DataType = Lui.Forms.DataTypes.Currency;
                        this.txtCobros.Location = new System.Drawing.Point(188, 372);
                        this.txtCobros.Name = "txtCobros";
                        this.txtCobros.TemporaryReadOnly = true;
                        this.txtCobros.Size = new System.Drawing.Size(104, 24);
                        this.txtCobros.TabIndex = 5;
                        this.txtCobros.TabStop = false;
                        // 
                        // Label10
                        // 
                        this.Label10.Location = new System.Drawing.Point(16, 372);
                        this.Label10.Name = "Label10";
                        this.Label10.Size = new System.Drawing.Size(172, 24);
                        this.Label10.TabIndex = 4;
                        this.Label10.Text = "Ingresos por Cobros";
                        this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // BotonCobros
                        // 
                        this.BotonCobros.AutoSize = false;
                        this.BotonCobros.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonCobros.Image = null;
                        this.BotonCobros.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonCobros.Location = new System.Drawing.Point(296, 372);
                        this.BotonCobros.Name = "BotonCobros";
                        this.BotonCobros.Size = new System.Drawing.Size(28, 24);
                        this.BotonCobros.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonCobros.Subtext = "";
                        this.BotonCobros.TabIndex = 6;
                        this.BotonCobros.Text = "...";
                        this.BotonCobros.Click += new System.EventHandler(this.BotonCobros_Click);
                        // 
                        // txtDiferenciaNeta
                        // 
                        this.txtDiferenciaNeta.AutoSize = false;
                        this.txtDiferenciaNeta.DataType = Lui.Forms.DataTypes.Currency;
                        this.txtDiferenciaNeta.Location = new System.Drawing.Point(188, 320);
                        this.txtDiferenciaNeta.Name = "txtDiferenciaNeta";
                        this.txtDiferenciaNeta.TemporaryReadOnly = true;
                        this.txtDiferenciaNeta.Size = new System.Drawing.Size(104, 24);
                        this.txtDiferenciaNeta.TabIndex = 26;
                        this.txtDiferenciaNeta.TabStop = false;
                        // 
                        // Label9
                        // 
                        this.Label9.Location = new System.Drawing.Point(16, 320);
                        this.Label9.Name = "Label9";
                        this.Label9.Size = new System.Drawing.Size(172, 24);
                        this.Label9.TabIndex = 25;
                        this.Label9.Text = "Margen Final";
                        this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // txtDiferenciaBruta
                        // 
                        this.txtDiferenciaBruta.AutoSize = false;
                        this.txtDiferenciaBruta.DataType = Lui.Forms.DataTypes.Currency;
                        this.txtDiferenciaBruta.Location = new System.Drawing.Point(188, 160);
                        this.txtDiferenciaBruta.Name = "txtDiferenciaBruta";
                        this.txtDiferenciaBruta.TemporaryReadOnly = true;
                        this.txtDiferenciaBruta.Size = new System.Drawing.Size(104, 24);
                        this.txtDiferenciaBruta.TabIndex = 33;
                        this.txtDiferenciaBruta.TabStop = false;
                        // 
                        // Label11
                        // 
                        this.Label11.Location = new System.Drawing.Point(16, 160);
                        this.Label11.Name = "Label11";
                        this.Label11.Size = new System.Drawing.Size(172, 24);
                        this.Label11.TabIndex = 32;
                        this.Label11.Text = "Margen Bruto";
                        this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label13
                        // 
                        this.Label13.Location = new System.Drawing.Point(8, 308);
                        this.Label13.Name = "Label13";
                        this.Label13.Size = new System.Drawing.Size(280, 2);
                        this.Label13.TabIndex = 27;
                        // 
                        // Label15
                        // 
                        this.Label15.Location = new System.Drawing.Point(4, 160);
                        this.Label15.Name = "Label15";
                        this.Label15.Size = new System.Drawing.Size(12, 24);
                        this.Label15.TabIndex = 37;
                        this.Label15.Text = "=";
                        this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // Label16
                        // 
                        this.Label16.Location = new System.Drawing.Point(4, 220);
                        this.Label16.Name = "Label16";
                        this.Label16.Size = new System.Drawing.Size(12, 24);
                        this.Label16.TabIndex = 11;
                        this.Label16.Text = "-";
                        this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // Label17
                        // 
                        this.Label17.Location = new System.Drawing.Point(4, 248);
                        this.Label17.Name = "Label17";
                        this.Label17.Size = new System.Drawing.Size(12, 24);
                        this.Label17.TabIndex = 15;
                        this.Label17.Text = "-";
                        this.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // Label18
                        // 
                        this.Label18.Location = new System.Drawing.Point(4, 276);
                        this.Label18.Name = "Label18";
                        this.Label18.Size = new System.Drawing.Size(12, 24);
                        this.Label18.TabIndex = 23;
                        this.Label18.Text = "-";
                        this.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // Label20
                        // 
                        this.Label20.Location = new System.Drawing.Point(4, 320);
                        this.Label20.Name = "Label20";
                        this.Label20.Size = new System.Drawing.Size(12, 24);
                        this.Label20.TabIndex = 28;
                        this.Label20.Text = "=";
                        this.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // txtFecha1
                        // 
                        this.txtFecha1.AutoSize = false;
                        this.txtFecha1.DataType = Lui.Forms.DataTypes.Date;
                        this.txtFecha1.Location = new System.Drawing.Point(56, 12);
                        this.txtFecha1.Name = "txtFecha1";
                        this.txtFecha1.Size = new System.Drawing.Size(92, 24);
                        this.txtFecha1.TabIndex = 1;
                        this.txtFecha1.LostFocus += new System.EventHandler(this.txtFecha12_LostFocus);
                        // 
                        // txtFecha2
                        // 
                        this.txtFecha2.AutoSize = false;
                        this.txtFecha2.DataType = Lui.Forms.DataTypes.Date;
                        this.txtFecha2.Location = new System.Drawing.Point(192, 12);
                        this.txtFecha2.Name = "txtFecha2";
                        this.txtFecha2.Size = new System.Drawing.Size(92, 24);
                        this.txtFecha2.TabIndex = 3;
                        this.txtFecha2.LostFocus += new System.EventHandler(this.txtFecha12_LostFocus);
                        // 
                        // Label22
                        // 
                        this.Label22.Location = new System.Drawing.Point(148, 12);
                        this.Label22.Name = "Label22";
                        this.Label22.Size = new System.Drawing.Size(44, 24);
                        this.Label22.TabIndex = 2;
                        this.Label22.Text = "y";
                        this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // lblDiferenciaBrutaPct
                        // 
                        this.lblDiferenciaBrutaPct.Location = new System.Drawing.Point(296, 160);
                        this.lblDiferenciaBrutaPct.Name = "lblDiferenciaBrutaPct";
                        this.lblDiferenciaBrutaPct.Size = new System.Drawing.Size(48, 24);
                        this.lblDiferenciaBrutaPct.TabIndex = 34;
                        this.lblDiferenciaBrutaPct.Text = "0%";
                        this.lblDiferenciaBrutaPct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // lblDiferenciaNetaPct
                        // 
                        this.lblDiferenciaNetaPct.Location = new System.Drawing.Point(296, 320);
                        this.lblDiferenciaNetaPct.Name = "lblDiferenciaNetaPct";
                        this.lblDiferenciaNetaPct.Size = new System.Drawing.Size(48, 24);
                        this.lblDiferenciaNetaPct.TabIndex = 27;
                        this.lblDiferenciaNetaPct.Text = "0%";
                        this.lblDiferenciaNetaPct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        
                        // 
                        // ChartButton
                        // 
                        this.ChartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.ChartButton.AutoSize = false;
                        this.ChartButton.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.ChartButton.Image = null;
                        this.ChartButton.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.ChartButton.Location = new System.Drawing.Point(112, 498);
                        this.ChartButton.Name = "ChartButton";
                        this.ChartButton.Size = new System.Drawing.Size(96, 28);
                        this.ChartButton.SubLabelPos = Lui.Forms.SubLabelPositions.Right;
                        this.ChartButton.Subtext = "";
                        this.ChartButton.TabIndex = 39;
                        this.ChartButton.Text = "Graficar";
                        this.ChartButton.Click += new System.EventHandler(this.ChartButton_Click);
                        // 
                        // PorTipo
                        // 
                        this.PorTipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.PorTipo.AutoSize = false;
                        this.PorTipo.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.PorTipo.Image = null;
                        this.PorTipo.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.PorTipo.Location = new System.Drawing.Point(216, 498);
                        this.PorTipo.Name = "PorTipo";
                        this.PorTipo.Size = new System.Drawing.Size(96, 28);
                        this.PorTipo.SubLabelPos = Lui.Forms.SubLabelPositions.Right;
                        this.PorTipo.Subtext = "F8";
                        this.PorTipo.TabIndex = 40;
                        this.PorTipo.Text = "Por Tipo";
                        this.PorTipo.Click += new System.EventHandler(this.PorTipo_Click);
                        // 
                        // txtCompraMateriales
                        // 
                        this.txtCompraMateriales.AutoSize = false;
                        this.txtCompraMateriales.DataType = Lui.Forms.DataTypes.Currency;
                        this.txtCompraMateriales.Location = new System.Drawing.Point(188, 428);
                        this.txtCompraMateriales.Name = "txtCompraMateriales";
                        this.txtCompraMateriales.TemporaryReadOnly = true;
                        this.txtCompraMateriales.Size = new System.Drawing.Size(104, 24);
                        this.txtCompraMateriales.TabIndex = 11;
                        this.txtCompraMateriales.TabStop = false;
                        // 
                        // label25
                        // 
                        this.label25.Location = new System.Drawing.Point(16, 96);
                        this.label25.Name = "label25";
                        this.label25.Size = new System.Drawing.Size(172, 24);
                        this.label25.TabIndex = 30;
                        this.label25.Text = "Costo Materiales";
                        this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // BotonCostoCapital
                        // 
                        this.BotonCostoCapital.AutoSize = false;
                        this.BotonCostoCapital.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonCostoCapital.Image = null;
                        this.BotonCostoCapital.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonCostoCapital.Location = new System.Drawing.Point(296, 192);
                        this.BotonCostoCapital.Name = "BotonCostoCapital";
                        this.BotonCostoCapital.Size = new System.Drawing.Size(28, 24);
                        this.BotonCostoCapital.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonCostoCapital.Subtext = "";
                        this.BotonCostoCapital.TabIndex = 15;
                        this.BotonCostoCapital.Text = "...";
                        this.BotonCostoCapital.Click += new System.EventHandler(this.BotonCostoCapital_Click);
                        // 
                        // txtCostoCapital
                        // 
                        this.txtCostoCapital.AutoSize = false;
                        this.txtCostoCapital.DataType = Lui.Forms.DataTypes.Currency;
                        this.txtCostoCapital.Location = new System.Drawing.Point(188, 192);
                        this.txtCostoCapital.Name = "txtCostoCapital";
                        this.txtCostoCapital.TemporaryReadOnly = true;
                        this.txtCostoCapital.Size = new System.Drawing.Size(104, 24);
                        this.txtCostoCapital.TabIndex = 14;
                        this.txtCostoCapital.TabStop = false;
                        // 
                        // label26
                        // 
                        this.label26.Location = new System.Drawing.Point(4, 192);
                        this.label26.Name = "label26";
                        this.label26.Size = new System.Drawing.Size(12, 24);
                        this.label26.TabIndex = 53;
                        this.label26.Text = "-";
                        this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // label27
                        // 
                        this.label27.Location = new System.Drawing.Point(16, 192);
                        this.label27.Name = "label27";
                        this.label27.Size = new System.Drawing.Size(172, 24);
                        this.label27.TabIndex = 13;
                        this.label27.Text = "Costo Capital";
                        this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // BotonCostoMateriales
                        // 
                        this.BotonCostoMateriales.AutoSize = false;
                        this.BotonCostoMateriales.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonCostoMateriales.Image = null;
                        this.BotonCostoMateriales.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonCostoMateriales.Location = new System.Drawing.Point(296, 428);
                        this.BotonCostoMateriales.Name = "BotonCostoMateriales";
                        this.BotonCostoMateriales.Size = new System.Drawing.Size(28, 24);
                        this.BotonCostoMateriales.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonCostoMateriales.Subtext = "";
                        this.BotonCostoMateriales.TabIndex = 12;
                        this.BotonCostoMateriales.Text = "...";
                        this.BotonCostoMateriales.Click += new System.EventHandler(this.BotonCostoMateriales_Click);
                        // 
                        // BotonIngresosOtros
                        // 
                        this.BotonIngresosOtros.AutoSize = false;
                        this.BotonIngresosOtros.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonIngresosOtros.Image = null;
                        this.BotonIngresosOtros.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonIngresosOtros.Location = new System.Drawing.Point(296, 400);
                        this.BotonIngresosOtros.Name = "BotonIngresosOtros";
                        this.BotonIngresosOtros.Size = new System.Drawing.Size(28, 24);
                        this.BotonIngresosOtros.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonIngresosOtros.Subtext = "";
                        this.BotonIngresosOtros.TabIndex = 9;
                        this.BotonIngresosOtros.Text = "...";
                        this.BotonIngresosOtros.Click += new System.EventHandler(this.BotonIngresosOtros_Click);
                        // 
                        // EntradaIngresosOtros
                        // 
                        this.EntradaIngresosOtros.AutoSize = false;
                        this.EntradaIngresosOtros.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaIngresosOtros.Location = new System.Drawing.Point(188, 400);
                        this.EntradaIngresosOtros.Name = "EntradaIngresosOtros";
                        this.EntradaIngresosOtros.TemporaryReadOnly = true;
                        this.EntradaIngresosOtros.Size = new System.Drawing.Size(104, 24);
                        this.EntradaIngresosOtros.TabIndex = 8;
                        this.EntradaIngresosOtros.TabStop = false;
                        // 
                        // label24
                        // 
                        this.label24.Location = new System.Drawing.Point(16, 400);
                        this.label24.Name = "label24";
                        this.label24.Size = new System.Drawing.Size(172, 24);
                        this.label24.TabIndex = 7;
                        this.label24.Text = "Otros Ingresos";
                        this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label4
                        // 
                        this.label4.BackColor = System.Drawing.Color.Silver;
                        this.label4.Location = new System.Drawing.Point(12, 152);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(280, 1);
                        this.label4.TabIndex = 69;
                        // 
                        // label8
                        // 
                        this.label8.Location = new System.Drawing.Point(4, 96);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(12, 24);
                        this.label8.TabIndex = 70;
                        this.label8.Text = "-";
                        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // label12
                        // 
                        this.label12.Location = new System.Drawing.Point(4, 124);
                        this.label12.Name = "label12";
                        this.label12.Size = new System.Drawing.Size(12, 24);
                        this.label12.TabIndex = 73;
                        this.label12.Text = "-";
                        this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // label14
                        // 
                        this.label14.Location = new System.Drawing.Point(16, 124);
                        this.label14.Name = "label14";
                        this.label14.Size = new System.Drawing.Size(172, 24);
                        this.label14.TabIndex = 71;
                        this.label14.Text = "Gestión de Cobro";
                        this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaGestionCobro
                        // 
                        this.EntradaGestionCobro.AutoSize = false;
                        this.EntradaGestionCobro.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaGestionCobro.Location = new System.Drawing.Point(188, 124);
                        this.EntradaGestionCobro.Name = "EntradaGestionCobro";
                        this.EntradaGestionCobro.TemporaryReadOnly = true;
                        this.EntradaGestionCobro.Size = new System.Drawing.Size(104, 24);
                        this.EntradaGestionCobro.TabIndex = 72;
                        this.EntradaGestionCobro.TabStop = false;
                        // 
                        // BotonGestionCobro
                        // 
                        this.BotonGestionCobro.AutoSize = false;
                        this.BotonGestionCobro.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonGestionCobro.Image = null;
                        this.BotonGestionCobro.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonGestionCobro.Location = new System.Drawing.Point(296, 124);
                        this.BotonGestionCobro.Name = "BotonGestionCobro";
                        this.BotonGestionCobro.Size = new System.Drawing.Size(28, 24);
                        this.BotonGestionCobro.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonGestionCobro.Subtext = "";
                        this.BotonGestionCobro.TabIndex = 74;
                        this.BotonGestionCobro.Text = "...";
                        this.BotonGestionCobro.Click += new System.EventHandler(this.BotonGestionCobro_Click);
                        // 
                        // IngresosEgresos
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.ClientSize = new System.Drawing.Size(692, 535);
                        this.Controls.Add(this.BotonGestionCobro);
                        this.Controls.Add(this.label12);
                        this.Controls.Add(this.label14);
                        this.Controls.Add(this.EntradaGestionCobro);
                        this.Controls.Add(this.label8);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.BotonIngresosOtros);
                        this.Controls.Add(this.EntradaIngresosOtros);
                        this.Controls.Add(this.label24);
                        this.Controls.Add(this.BotonCostoMateriales);
                        this.Controls.Add(this.txtCompraMateriales);
                        this.Controls.Add(this.BotonCobros);
                        this.Controls.Add(this.txtCobros);
                        this.Controls.Add(this.Label10);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.Listado);
                        this.Controls.Add(this.BotonCostoCapital);
                        this.Controls.Add(this.txtCostoCapital);
                        this.Controls.Add(this.label26);
                        this.Controls.Add(this.label27);
                        this.Controls.Add(this.label25);
                        this.Controls.Add(this.PorTipo);
                        this.Controls.Add(this.ChartButton);
                        this.Controls.Add(this.txtFecha2);
                        this.Controls.Add(this.txtFecha1);
                        this.Controls.Add(this.txtDiferenciaBruta);
                        this.Controls.Add(this.txtDiferenciaNeta);
                        this.Controls.Add(this.BotonOtrosEgresos);
                        this.Controls.Add(this.BotonGastosVariables);
                        this.Controls.Add(this.BotonGastosFijos);
                        this.Controls.Add(this.txtOtrosEgresos);
                        this.Controls.Add(this.txtGastosVariables);
                        this.Controls.Add(this.txtGastosFijos);
                        this.Controls.Add(this.txtCosto);
                        this.Controls.Add(this.EntradaFacturacion);
                        this.Controls.Add(this.lblDiferenciaNetaPct);
                        this.Controls.Add(this.lblDiferenciaBrutaPct);
                        this.Controls.Add(this.Label22);
                        this.Controls.Add(this.Label20);
                        this.Controls.Add(this.Label18);
                        this.Controls.Add(this.Label17);
                        this.Controls.Add(this.Label16);
                        this.Controls.Add(this.Label15);
                        this.Controls.Add(this.Label13);
                        this.Controls.Add(this.Label11);
                        this.Controls.Add(this.Label9);
                        this.Controls.Add(this.Label7);
                        this.Controls.Add(this.Label6);
                        this.Controls.Add(this.Label5);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.Label1);
                        this.KeyPreview = true;
                        this.Name = "IngresosEgresos";
                        this.Text = "Reporte Ingresos y Egresos";
                        this.Load += new System.EventHandler(this.FormRepRentabilidad_Load);
                        this.ResumeLayout(false);

                }


                #endregion

                public void MostrarReporte()
                {
                        decimal Facturas = this.Connection.FieldDecimal("SELECT SUM(total) FROM comprob WHERE tipo_fac IN ('FA', 'FB', 'FC', 'FE', 'FM', 'NDA', 'NDB', 'NDC', 'NDE', 'NDM') AND compra=0 AND impresa>0 AND anulada=0 AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                        decimal NotasCredito = this.Connection.FieldDecimal("SELECT SUM(total) FROM comprob WHERE tipo_fac IN ('NCA', 'NCB', 'NCC', 'NCE', 'NCM') AND compra=0 AND impresa>0 AND anulada=0 AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");

                        decimal Costo = this.Connection.FieldDecimal("SELECT SUM(costo*cantidad) FROM comprob, comprob_detalle WHERE comprob.id_comprob=comprob_detalle.id_comprob AND comprob.tipo_fac IN ('FA', 'FB', 'FC', 'FE', 'FM', 'NDA', 'NDB', 'NDC', 'NDE', 'NDM') AND comprob.compra=0 AND comprob.impresa>0 AND comprob.numero>0 AND comprob.anulada=0 AND comprob_detalle.precio>0 AND comprob.fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                        decimal CostoNotasCredito = this.Connection.FieldDecimal("SELECT SUM(costo*cantidad) FROM comprob, comprob_detalle WHERE comprob.id_comprob=comprob_detalle.id_comprob AND comprob.tipo_fac IN ('NCA', 'NCB', 'NCC', 'NCE', 'NCM') AND comprob.compra=0 AND comprob.impresa>0 AND comprob.numero>0 AND comprob.anulada=0 AND comprob.fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");

                        decimal GestionCobro = -this.Connection.FieldDecimal("SELECT SUM(importe) FROM cajas_movim WHERE id_concepto=24010 AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");

                        decimal Facturacion = Facturas - NotasCredito;

                        EntradaFacturacion.Text = Lfx.Types.Formatting.FormatCurrency(Facturacion, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        EntradaFacturacion.Tag = "Facturas: " + Lfx.Types.Formatting.FormatCurrency(Facturas, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales) + " - Notas de Crédito: " + Lfx.Types.Formatting.FormatCurrency(NotasCredito, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        txtCosto.Text = Lfx.Types.Formatting.FormatCurrency(Costo - CostoNotasCredito, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        txtCosto.Tag = "Facturas: " + Lfx.Types.Formatting.FormatCurrency(Costo, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales) + " - Notas de Crédito: " + Lfx.Types.Formatting.FormatCurrency(CostoNotasCredito, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        EntradaGestionCobro.Text = Lfx.Types.Formatting.FormatCurrency(GestionCobro, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        txtDiferenciaBruta.Text = Lfx.Types.Formatting.FormatCurrency(Facturacion - Costo + CostoNotasCredito - GestionCobro, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);

                        txtCostoCapital.Text = Lfx.Types.Formatting.FormatCurrency(-(this.Connection.FieldDecimal("SELECT SUM(importe) FROM cajas_movim WHERE id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo=220) AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'")), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        txtGastosFijos.Text = Lfx.Types.Formatting.FormatCurrency(-(this.Connection.FieldDecimal("SELECT SUM(importe) FROM cajas_movim WHERE id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo=230) AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'")), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        txtGastosVariables.Text = Lfx.Types.Formatting.FormatCurrency(-(this.Connection.FieldDecimal("SELECT SUM(importe) FROM cajas_movim WHERE id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo=240) AND id_concepto NOT IN (24010) AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'")), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        txtOtrosEgresos.Text = Lfx.Types.Formatting.FormatCurrency(-(this.Connection.FieldDecimal("SELECT SUM(importe) FROM cajas_movim WHERE importe<0 AND id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo NOT IN (110, 210, 220, 230, 240, 300)) AND id_concepto<>26030 AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'")), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);

                        if (Facturacion == 0)
                                lblDiferenciaBrutaPct.Text = "N/A";
                        else
                                lblDiferenciaBrutaPct.Text = Lfx.Types.Formatting.FormatCurrency(Lfx.Types.Parsing.ParseCurrency(txtDiferenciaBruta.Text) / Lfx.Types.Parsing.ParseCurrency(EntradaFacturacion.Text) * 100, 1) + "%";

                        txtDiferenciaNeta.Text = Lfx.Types.Formatting.FormatCurrency(
                                        Lfx.Types.Parsing.ParseCurrency(txtDiferenciaBruta.Text)
                                        /* + Lfx.Types.Parsing.ParseCurrency(EntradaIngresosOtros.Text)
                                        - Lfx.Types.Parsing.ParseCurrency(txtCostoMateriales.Text) */
                                        - Lfx.Types.Parsing.ParseCurrency(txtCostoCapital.Text)
                                        - Lfx.Types.Parsing.ParseCurrency(txtGastosFijos.Text)
                                        - Lfx.Types.Parsing.ParseCurrency(txtGastosVariables.Text)
                                        - Lfx.Types.Parsing.ParseCurrency(txtOtrosEgresos.Text),
                                        Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);

                        if (Facturacion == 0)
                                lblDiferenciaNetaPct.Text = "N/A";
                        else
                                lblDiferenciaNetaPct.Text = Lfx.Types.Formatting.FormatCurrency(Lfx.Types.Parsing.ParseCurrency(txtDiferenciaNeta.Text) / Lfx.Types.Parsing.ParseCurrency(EntradaFacturacion.Text) * 100, 1) + "%";


                        //Ingresos y egresos
                        txtCobros.Text = Lfx.Types.Formatting.FormatCurrency(Math.Abs(this.Connection.FieldDecimal("SELECT SUM(importe) FROM cajas_movim WHERE (id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo=110) OR id_concepto=26030 ) AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'")), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        EntradaIngresosOtros.Text = Lfx.Types.Formatting.FormatCurrency(Math.Abs(this.Connection.FieldDecimal("SELECT SUM(importe) FROM cajas_movim WHERE importe>0 AND id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo NOT IN (110, 210, 220, 230, 240, 300)) AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'")), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        txtCompraMateriales.Text = Lfx.Types.Formatting.FormatCurrency(-this.Connection.FieldDecimal("SELECT SUM(importe) FROM cajas_movim WHERE id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo=210) AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'"), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);

                }


                private void FormRepRentabilidad_Load(System.Object sender, System.EventArgs e)
                {
                        txtFecha1.Text = System.DateTime.Now.AddDays(-7).ToString("01/MM/yyyy");
                        txtFecha1.SelectionStart = 0;
                        txtFecha1.SelectionLength = txtFecha1.Text.Length;

                        txtFecha12_LostFocus(null, null);
                }


                public void MostrarDetalles(string Sql)
                {
                        Listado.BeginUpdate();
                        Listado.Items.Clear();

                        System.Data.DataTable Detalles = this.Connection.Select(Sql);
                        foreach (System.Data.DataRow Detalle in Detalles.Rows) {
                                ListViewItem itm = Listado.Items.Add(System.Convert.ToString(Detalle["id_movim"]));
                                itm.SubItems.Add(Lfx.Types.Formatting.FormatDate(Detalle["fecha"]));
                                itm.SubItems.Add(System.Convert.ToString(Detalle["concepto"]));
                                itm.SubItems.Add(Lfx.Types.Formatting.FormatCurrency(System.Convert.ToDecimal(Detalle["importe"]), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales));
                                itm.SubItems.Add(System.Convert.ToString(Detalle["id_caja"]));
                                itm.SubItems.Add(System.Convert.ToString(Detalle["comprob"]));
                                itm.SubItems.Add(System.Convert.ToString(Detalle["obs"]));
                        }

                        Listado.EndUpdate();
                }


                private void BotonOtrosEgresos_Click(object sender, System.EventArgs e)
                {
                        MostrarDetalles("SELECT * FROM cajas_movim WHERE importe<0 AND id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo NOT IN (110, 210, 220, 230, 240, 300)) AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                }


                private void BotonGastosVariables_Click(object sender, System.EventArgs e)
                {
                        MostrarDetalles("SELECT * FROM cajas_movim WHERE id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo=240) AND id_concepto NOT IN (24010) AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                }


                private void BotonCostoCapital_Click(object sender, System.EventArgs e)
                {
                        MostrarDetalles("SELECT * FROM cajas_movim WHERE id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo=220) AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                }

                private void BotonCostoMateriales_Click(object sender, System.EventArgs e)
                {
                        MostrarDetalles("SELECT * FROM cajas_movim WHERE id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo=210) AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                }


                private void BotonGastosFijos_Click(object sender, System.EventArgs e)
                {
                        MostrarDetalles("SELECT * FROM cajas_movim WHERE id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo=230) AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                }


                private void BotonCobros_Click(object sender, System.EventArgs e)
                {
                        MostrarDetalles("SELECT * FROM cajas_movim WHERE id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo=110) AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                }

                private void BotonIngresosOtros_Click(object sender, System.EventArgs e)
                {
                        MostrarDetalles("SELECT * FROM cajas_movim WHERE importe>0 AND id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo NOT IN (110, 210, 220, 230, 240, 300)) AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                }


                private void txtFecha12_LostFocus(object sender, System.EventArgs e)
                {
                        string sFecha1 = txtFecha1.Text;
                        string sFecha2 = txtFecha2.Text;
                        if (sFecha2.Length == 0 && sFecha1.Length > 0) {
                                sFecha2 = sFecha1;
                                sFecha2 = DateTime.DaysInMonth(Lfx.Types.Parsing.ParseInt(sFecha2.Substring(6, 4)), Lfx.Types.Parsing.ParseInt(sFecha2.Substring(3, 2))).ToString().PadLeft(2, '0') + sFecha2.Substring(2, sFecha2.Length - 2);
                                txtFecha2.Text = sFecha2;
                                txtFecha2.SelectionStart = 0;
                                txtFecha2.SelectionLength = txtFecha2.Text.Length;
                        }
                        if (sFecha2.Length > 0 && sFecha1.Length > 0) {
                                Fecha1Sql = Lfx.Types.Formatting.FormatDateSql(sFecha1).ToString() + " 00:00:00";
                                Fecha2Sql = Lfx.Types.Formatting.FormatDateSql(sFecha2).ToString() + " 23:59:59";
                                MostrarReporte();
                        }
                }


                private void lvItems_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
                {
                        switch (e.KeyCode) {
                                case Keys.Up:
                                        if (Listado.Items.Count == 0) {
                                                e.Handled = true;
                                                System.Windows.Forms.SendKeys.Send("+{tab}");
                                        } else if (Listado.SelectedItems.Count > 0 && Listado.SelectedItems[0].Index == 0) {
                                                e.Handled = true;
                                                System.Windows.Forms.SendKeys.Send("+{tab}");
                                        }
                                        break;
                                case Keys.Down:
                                        if (Listado.Items.Count == 0) {
                                                e.Handled = true;
                                                System.Windows.Forms.SendKeys.Send("{tab}");
                                        } else if (Listado.SelectedItems.Count > 0 && Listado.SelectedItems[0].Index == Listado.Items.Count - 1) {
                                                e.Handled = true;
                                                System.Windows.Forms.SendKeys.Send("{tab}");
                                        }
                                        break;
                        }

                }


                private void EntradaFacturacion_GotFocus(object sender, System.EventArgs e)
                {
                        // TODO: EntradaFacturacion.ShowBalloon(System.Convert.ToString(EntradaFacturacion.Tag));
                }


                private void ChartButton_Click(object sender, System.EventArgs e)
                {
                        Lfc.Reportes.Facturacion ChartFact = new Lfc.Reportes.Facturacion();
                        ChartFact.MdiParent = this.MdiParent;
                        ChartFact.Show();
                }

                private void PorTipo_Click(object sender, System.EventArgs e)
                {
                        Listado.BeginUpdate();
                        Listado.Items.Clear();

                        decimal Resultado = 0;
                        Resultado += MostrarTipo(100);
                        Resultado += MostrarTipo(110);
                        Resultado += MostrarTipo(230);
                        Resultado += MostrarTipo(240);
                        Resultado += MostrarTipo(200);
                        Resultado += MostrarTipo(260);
                        Resultado += MostrarTipo(250);
                        Resultado += MostrarTipo(210);
                        Resultado += MostrarTipo(220);
                        Resultado += MostrarTipo(231);
                        Resultado += MostrarTipo(300);

                        ListViewItem itm = null;
                        itm = Listado.Items.Add(System.Convert.ToString("total"));
                        itm.SubItems.Add("-");
                        itm.SubItems.Add("Total");
                        itm.SubItems.Add(Lfx.Types.Formatting.FormatCurrency(Resultado, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales));
                        itm.SubItems.Add("-");
                        itm.SubItems.Add("-");
                        itm.SubItems.Add("-");

                        Listado.EndUpdate();
                }

                private decimal MostrarTipo(int idTipo)
                {
                        decimal Monto = this.Connection.FieldDecimal("SELECT SUM(importe) FROM cajas_movim WHERE id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo=" + idTipo.ToString() + ") AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                        string NombreConcepto = "?";
                        switch (idTipo) {
                                case 0:
                                        NombreConcepto = "-";
                                        break;
                                case 110:
                                        NombreConcepto = "Cobros";
                                        break;
                                case 100:
                                        NombreConcepto = "Otros ingresos";
                                        break;
                                case 230:
                                        NombreConcepto = "Gastos fijos";
                                        break;
                                case 240:
                                        NombreConcepto = "Gastos variables";
                                        break;
                                case 200:
                                        NombreConcepto = "Otros gastos";
                                        break;
                                case 260:
                                        NombreConcepto = "Pérdida";
                                        break;
                                case 250:
                                        NombreConcepto = "Reinversión";
                                        break;
                                case 210:
                                        NombreConcepto = "Costo materiales";
                                        break;
                                case 220:
                                        NombreConcepto = "Costo capital";
                                        break;
                                case 231:
                                        NombreConcepto = "Sueldos y salarios";
                                        break;
                                case 300:
                                        NombreConcepto = "Movimientos y ajustes";
                                        break;
                                default:
                                        NombreConcepto = "???";
                                        break;
                        }

                        ListViewItem itm = null;
                        itm = Listado.Items.Add(System.Convert.ToString(idTipo.ToString()));
                        itm.SubItems.Add("-");
                        itm.SubItems.Add(NombreConcepto);
                        itm.SubItems.Add(Lfx.Types.Formatting.FormatCurrency(Monto, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales));
                        itm.SubItems.Add("-");
                        itm.SubItems.Add("-");
                        itm.SubItems.Add("-");

                        return Monto;
                }

                private void BotonGestionCobro_Click(object sender, EventArgs e)
                {
                        MostrarDetalles("SELECT * FROM cajas_movim WHERE id_concepto=24010 AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                }
        }
}
