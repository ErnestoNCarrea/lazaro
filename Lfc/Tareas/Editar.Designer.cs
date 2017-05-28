using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Tareas
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

                // Requerido por el Diseñador de Windows Forms
                private System.ComponentModel.IContainer components = null;

                private void InitializeComponent()
                {
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaCliente = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaTarea = new Lcc.Entrada.CodigoDetalle();
                        this.Label3 = new Lui.Forms.Label();
                        this.EntradaEncargado = new Lcc.Entrada.CodigoDetalle();
                        this.Label4 = new Lui.Forms.Label();
                        this.Label5 = new Lui.Forms.Label();
                        this.EntradaAsunto = new Lui.Forms.TextBox();
                        this.Label6 = new Lui.Forms.Label();
                        this.Label7 = new Lui.Forms.Label();
                        this.EntradaDescripcion = new Lui.Forms.TextBox();
                        this.Label8 = new Lui.Forms.Label();
                        this.Label9 = new Lui.Forms.Label();
                        this.Label10 = new Lui.Forms.Label();
                        this.EntradaEntregaEstimada = new Lui.Forms.TextBox();
                        this.EntradaEntregaLimite = new Lui.Forms.TextBox();
                        this.EntradaImportePresupuesto = new Lui.Forms.TextBox();
                        this.EntradaObs = new Lui.Forms.TextBox();
                        this.Label11 = new Lui.Forms.Label();
                        this.FrameHistorialCliente = new Lui.Forms.Frame();
                        this.ListaHistorialCliente = new Lui.Forms.ListView();
                        this.HistorialClienteColTarea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.HistorialClienteColEncargado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.HistorialClienteColFecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.HistorialClienteColDetalle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.EntradaEstado = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaFechaIngreso = new Lui.Forms.TextBox();
                        this.Label12 = new Lui.Forms.Label();
                        this.EntradaComprobante = new Lui.Forms.TextBox();
                        this.Label13 = new Lui.Forms.Label();
                        this.EntradaComprobanteId = new System.Windows.Forms.TextBox();
                        this.EntradaPresupuesto2 = new Lui.Forms.TextBox();
                        this.EntradaPrioridad = new Lui.Forms.ComboBox();
                        this.Label14 = new Lui.Forms.Label();
                        this.Label15 = new Lui.Forms.Label();
                        this.FrameHistorialTarea = new Lui.Forms.Frame();
                        this.ListaHistorialTarea = new Lui.Forms.ListView();
                        this.HistorialTareaColEncargado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.HistorialTareaColFecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.HistorialTareaColDetalle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ContAbajo = new System.Windows.Forms.SplitContainer();
                        this.FrameHistorialCliente.SuspendLayout();
                        this.FrameHistorialTarea.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.ContAbajo)).BeginInit();
                        this.ContAbajo.Panel1.SuspendLayout();
                        this.ContAbajo.Panel2.SuspendLayout();
                        this.ContAbajo.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(0, 0);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(135, 24);
                        this.Label1.TabIndex = 0;
                        this.Label1.Text = "Cliente";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCliente
                        // 
                        this.EntradaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCliente.AutoTab = true;
                        this.EntradaCliente.CanCreate = true;
                        this.EntradaCliente.Location = new System.Drawing.Point(141, 0);
                        this.EntradaCliente.MaxLength = 200;
                        this.EntradaCliente.Name = "EntradaCliente";
                        this.EntradaCliente.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaCliente.Required = true;
                        this.EntradaCliente.Size = new System.Drawing.Size(294, 24);
                        this.EntradaCliente.TabIndex = 1;
                        this.EntradaCliente.Text = "0";
                        // 
                        // EntradaTarea
                        // 
                        this.EntradaTarea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaTarea.AutoTab = true;
                        this.EntradaTarea.CanCreate = true;
                        this.EntradaTarea.Location = new System.Drawing.Point(141, 32);
                        this.EntradaTarea.MaxLength = 200;
                        this.EntradaTarea.Name = "EntradaTarea";
                        this.EntradaTarea.NombreTipo = "Lbl.Tareas.Tipo";
                        this.EntradaTarea.Required = true;
                        this.EntradaTarea.Size = new System.Drawing.Size(294, 24);
                        this.EntradaTarea.TabIndex = 3;
                        this.EntradaTarea.Text = "0";
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(0, 32);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(135, 24);
                        this.Label3.TabIndex = 2;
                        this.Label3.Text = "Tarea";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaEncargado
                        // 
                        this.EntradaEncargado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaEncargado.AutoTab = true;
                        this.EntradaEncargado.CanCreate = false;
                        this.EntradaEncargado.Filter = "(tipo&4)=4";
                        this.EntradaEncargado.Location = new System.Drawing.Point(141, 64);
                        this.EntradaEncargado.MaxLength = 200;
                        this.EntradaEncargado.Name = "EntradaEncargado";
                        this.EntradaEncargado.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaEncargado.Required = true;
                        this.EntradaEncargado.Size = new System.Drawing.Size(294, 24);
                        this.EntradaEncargado.TabIndex = 5;
                        this.EntradaEncargado.Text = "0";
                        // 
                        // Label4
                        // 
                        this.Label4.Location = new System.Drawing.Point(0, 64);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(135, 24);
                        this.Label4.TabIndex = 4;
                        this.Label4.Text = "Encargado";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(0, 96);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(135, 24);
                        this.Label5.TabIndex = 6;
                        this.Label5.Text = "Asunto";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaAsunto
                        // 
                        this.EntradaAsunto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaAsunto.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaAsunto.Location = new System.Drawing.Point(141, 96);
                        this.EntradaAsunto.Name = "EntradaAsunto";
                        this.EntradaAsunto.Size = new System.Drawing.Size(294, 24);
                        this.EntradaAsunto.TabIndex = 7;
                        // 
                        // Label6
                        // 
                        this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label6.Location = new System.Drawing.Point(459, 0);
                        this.Label6.Name = "Label6";
                        this.Label6.Size = new System.Drawing.Size(81, 24);
                        this.Label6.TabIndex = 13;
                        this.Label6.Text = "Estado";
                        this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label7
                        // 
                        this.Label7.Location = new System.Drawing.Point(0, 128);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(135, 24);
                        this.Label7.TabIndex = 8;
                        this.Label7.Text = "Descripción";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaDescripcion
                        // 
                        this.EntradaDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaDescripcion.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaDescripcion.Location = new System.Drawing.Point(141, 128);
                        this.EntradaDescripcion.MultiLine = true;
                        this.EntradaDescripcion.Name = "EntradaDescripcion";
                        this.EntradaDescripcion.Size = new System.Drawing.Size(294, 88);
                        this.EntradaDescripcion.TabIndex = 9;
                        // 
                        // Label8
                        // 
                        this.Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label8.Location = new System.Drawing.Point(459, 64);
                        this.Label8.Name = "Label8";
                        this.Label8.Size = new System.Drawing.Size(156, 24);
                        this.Label8.TabIndex = 17;
                        this.Label8.Text = "Fecha final. estimada";
                        this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label9
                        // 
                        this.Label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label9.Location = new System.Drawing.Point(459, 96);
                        this.Label9.Name = "Label9";
                        this.Label9.Size = new System.Drawing.Size(156, 24);
                        this.Label9.TabIndex = 19;
                        this.Label9.Text = "Fecha final. límite";
                        this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label10
                        // 
                        this.Label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label10.Location = new System.Drawing.Point(459, 208);
                        this.Label10.Name = "Label10";
                        this.Label10.Size = new System.Drawing.Size(128, 24);
                        this.Label10.TabIndex = 23;
                        this.Label10.Text = "Presupuesto";
                        this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaEntregaEstimada
                        // 
                        this.EntradaEntregaEstimada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaEntregaEstimada.DataType = Lui.Forms.DataTypes.Date;
                        this.EntradaEntregaEstimada.Location = new System.Drawing.Point(611, 64);
                        this.EntradaEntregaEstimada.Name = "EntradaEntregaEstimada";
                        this.EntradaEntregaEstimada.Size = new System.Drawing.Size(112, 24);
                        this.EntradaEntregaEstimada.TabIndex = 18;
                        // 
                        // EntradaEntregaLimite
                        // 
                        this.EntradaEntregaLimite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaEntregaLimite.DataType = Lui.Forms.DataTypes.Date;
                        this.EntradaEntregaLimite.Location = new System.Drawing.Point(611, 96);
                        this.EntradaEntregaLimite.Name = "EntradaEntregaLimite";
                        this.EntradaEntregaLimite.Size = new System.Drawing.Size(112, 24);
                        this.EntradaEntregaLimite.TabIndex = 20;
                        // 
                        // EntradaImportePresupuesto
                        // 
                        this.EntradaImportePresupuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaImportePresupuesto.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaImportePresupuesto.Location = new System.Drawing.Point(585, 208);
                        this.EntradaImportePresupuesto.Name = "EntradaImportePresupuesto";
                        this.EntradaImportePresupuesto.Prefijo = "$";
                        this.EntradaImportePresupuesto.Size = new System.Drawing.Size(80, 24);
                        this.EntradaImportePresupuesto.TabIndex = 24;
                        this.EntradaImportePresupuesto.Text = "0.00";
                        // 
                        // EntradaObs
                        // 
                        this.EntradaObs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaObs.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaObs.Location = new System.Drawing.Point(141, 224);
                        this.EntradaObs.MultiLine = true;
                        this.EntradaObs.Name = "EntradaObs";
                        this.EntradaObs.Size = new System.Drawing.Size(294, 24);
                        this.EntradaObs.TabIndex = 11;
                        // 
                        // Label11
                        // 
                        this.Label11.Location = new System.Drawing.Point(0, 224);
                        this.Label11.Name = "Label11";
                        this.Label11.Size = new System.Drawing.Size(135, 24);
                        this.Label11.TabIndex = 10;
                        this.Label11.Text = "Observaciones";
                        this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // FrameHistorialCliente
                        // 
                        this.FrameHistorialCliente.Controls.Add(this.ListaHistorialCliente);
                        this.FrameHistorialCliente.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.FrameHistorialCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F);
                        this.FrameHistorialCliente.Location = new System.Drawing.Point(0, 0);
                        this.FrameHistorialCliente.Name = "FrameHistorialCliente";
                        this.FrameHistorialCliente.Size = new System.Drawing.Size(356, 203);
                        this.FrameHistorialCliente.TabIndex = 29;
                        this.FrameHistorialCliente.Text = "Historial del cliente en otras tareas";
                        // 
                        // ListaHistorialCliente
                        // 
                        this.ListaHistorialCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.ListaHistorialCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.ListaHistorialCliente.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HistorialClienteColTarea,
            this.HistorialClienteColEncargado,
            this.HistorialClienteColFecha,
            this.HistorialClienteColDetalle});
                        this.ListaHistorialCliente.FieldName = null;
                        this.ListaHistorialCliente.FullRowSelect = true;
                        this.ListaHistorialCliente.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.ListaHistorialCliente.Location = new System.Drawing.Point(3, 40);
                        this.ListaHistorialCliente.MultiSelect = false;
                        this.ListaHistorialCliente.Name = "ListaHistorialCliente";
                        this.ListaHistorialCliente.ReadOnly = false;
                        this.ListaHistorialCliente.Size = new System.Drawing.Size(350, 160);
                        this.ListaHistorialCliente.TabIndex = 30;
                        this.ListaHistorialCliente.UseCompatibleStateImageBehavior = false;
                        this.ListaHistorialCliente.View = System.Windows.Forms.View.Details;
                        this.ListaHistorialCliente.SelectedIndexChanged += new System.EventHandler(this.ListaHistorial_SelectedIndexChanged);
                        this.ListaHistorialCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListaHistorial_KeyDown);
                        // 
                        // HistorialClienteColTarea
                        // 
                        this.HistorialClienteColTarea.Text = "Tarea";
                        // 
                        // HistorialClienteColEncargado
                        // 
                        this.HistorialClienteColEncargado.Text = "Encargado";
                        this.HistorialClienteColEncargado.Width = 180;
                        // 
                        // HistorialClienteColFecha
                        // 
                        this.HistorialClienteColFecha.Text = "Fecha";
                        this.HistorialClienteColFecha.Width = 80;
                        // 
                        // HistorialClienteColDetalle
                        // 
                        this.HistorialClienteColDetalle.Text = "Detalle";
                        this.HistorialClienteColDetalle.Width = 650;
                        // 
                        // EntradaEstado
                        // 
                        this.EntradaEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaEstado.AutoTab = true;
                        this.EntradaEstado.CanCreate = true;
                        this.EntradaEstado.Location = new System.Drawing.Point(537, 0);
                        this.EntradaEstado.MaxLength = 200;
                        this.EntradaEstado.Name = "EntradaEstado";
                        this.EntradaEstado.NombreTipo = "Lbl.Tareas.EstadoTarea";
                        this.EntradaEstado.Required = true;
                        this.EntradaEstado.Size = new System.Drawing.Size(234, 24);
                        this.EntradaEstado.TabIndex = 14;
                        this.EntradaEstado.Text = "0";
                        // 
                        // EntradaFechaIngreso
                        // 
                        this.EntradaFechaIngreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaFechaIngreso.Location = new System.Drawing.Point(611, 32);
                        this.EntradaFechaIngreso.Name = "EntradaFechaIngreso";
                        this.EntradaFechaIngreso.Size = new System.Drawing.Size(160, 24);
                        this.EntradaFechaIngreso.TabIndex = 16;
                        this.EntradaFechaIngreso.TabStop = false;
                        // 
                        // Label12
                        // 
                        this.Label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label12.Location = new System.Drawing.Point(459, 32);
                        this.Label12.Name = "Label12";
                        this.Label12.Size = new System.Drawing.Size(156, 24);
                        this.Label12.TabIndex = 15;
                        this.Label12.Text = "Fecha de ingreso";
                        this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaComprobante
                        // 
                        this.EntradaComprobante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaComprobante.Location = new System.Drawing.Point(585, 240);
                        this.EntradaComprobante.Name = "EntradaComprobante";
                        this.EntradaComprobante.ReadOnly = true;
                        this.EntradaComprobante.Size = new System.Drawing.Size(184, 24);
                        this.EntradaComprobante.TabIndex = 28;
                        this.EntradaComprobante.TabStop = false;
                        // 
                        // Label13
                        // 
                        this.Label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label13.Location = new System.Drawing.Point(459, 240);
                        this.Label13.Name = "Label13";
                        this.Label13.Size = new System.Drawing.Size(128, 24);
                        this.Label13.TabIndex = 27;
                        this.Label13.Text = "Comprobante";
                        this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaComprobanteId
                        // 
                        this.EntradaComprobanteId.Location = new System.Drawing.Point(0, 164);
                        this.EntradaComprobanteId.Name = "EntradaComprobanteId";
                        this.EntradaComprobanteId.Size = new System.Drawing.Size(28, 25);
                        this.EntradaComprobanteId.TabIndex = 34;
                        this.EntradaComprobanteId.Visible = false;
                        this.EntradaComprobanteId.TextChanged += new System.EventHandler(this.EntradaComprobanteId_TextChanged);
                        // 
                        // EntradaPresupuesto2
                        // 
                        this.EntradaPresupuesto2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaPresupuesto2.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaPresupuesto2.Location = new System.Drawing.Point(681, 208);
                        this.EntradaPresupuesto2.Name = "EntradaPresupuesto2";
                        this.EntradaPresupuesto2.Prefijo = "$";
                        this.EntradaPresupuesto2.Size = new System.Drawing.Size(88, 24);
                        this.EntradaPresupuesto2.TabIndex = 26;
                        this.EntradaPresupuesto2.TabStop = false;
                        this.EntradaPresupuesto2.Text = "0.00";
                        // 
                        // EntradaPrioridad
                        // 
                        this.EntradaPrioridad.AlwaysExpanded = true;
                        this.EntradaPrioridad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaPrioridad.AutoSize = true;
                        this.EntradaPrioridad.Location = new System.Drawing.Point(585, 128);
                        this.EntradaPrioridad.Name = "EntradaPrioridad";
                        this.EntradaPrioridad.SetData = new string[] {
        "Muy Alta|10",
        "Alta|5",
        "Normal|0",
        "Baja|-5"};
                        this.EntradaPrioridad.Size = new System.Drawing.Size(164, 74);
                        this.EntradaPrioridad.TabIndex = 22;
                        this.EntradaPrioridad.TextKey = "0";
                        // 
                        // Label14
                        // 
                        this.Label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label14.Location = new System.Drawing.Point(459, 128);
                        this.Label14.Name = "Label14";
                        this.Label14.Size = new System.Drawing.Size(128, 24);
                        this.Label14.TabIndex = 21;
                        this.Label14.Text = "Prioridad";
                        this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label15
                        // 
                        this.Label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label15.Location = new System.Drawing.Point(665, 208);
                        this.Label15.Name = "Label15";
                        this.Label15.Size = new System.Drawing.Size(16, 24);
                        this.Label15.TabIndex = 25;
                        this.Label15.Text = "+";
                        this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // FrameHistorialTarea
                        // 
                        this.FrameHistorialTarea.Controls.Add(this.ListaHistorialTarea);
                        this.FrameHistorialTarea.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.FrameHistorialTarea.Font = new System.Drawing.Font("Segoe UI", 9.75F);
                        this.FrameHistorialTarea.Location = new System.Drawing.Point(0, 0);
                        this.FrameHistorialTarea.Name = "FrameHistorialTarea";
                        this.FrameHistorialTarea.Size = new System.Drawing.Size(406, 203);
                        this.FrameHistorialTarea.TabIndex = 35;
                        this.FrameHistorialTarea.Text = "Historial de la tarea";
                        // 
                        // ListaHistorialTarea
                        // 
                        this.ListaHistorialTarea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.ListaHistorialTarea.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.ListaHistorialTarea.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HistorialTareaColEncargado,
            this.HistorialTareaColFecha,
            this.HistorialTareaColDetalle});
                        this.ListaHistorialTarea.FieldName = null;
                        this.ListaHistorialTarea.FullRowSelect = true;
                        this.ListaHistorialTarea.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.ListaHistorialTarea.Location = new System.Drawing.Point(3, 40);
                        this.ListaHistorialTarea.MultiSelect = false;
                        this.ListaHistorialTarea.Name = "ListaHistorialTarea";
                        this.ListaHistorialTarea.ReadOnly = false;
                        this.ListaHistorialTarea.Size = new System.Drawing.Size(400, 160);
                        this.ListaHistorialTarea.TabIndex = 30;
                        this.ListaHistorialTarea.UseCompatibleStateImageBehavior = false;
                        this.ListaHistorialTarea.View = System.Windows.Forms.View.Details;
                        // 
                        // HistorialTareaColEncargado
                        // 
                        this.HistorialTareaColEncargado.Text = "Encargado";
                        this.HistorialTareaColEncargado.Width = 180;
                        // 
                        // HistorialTareaColFecha
                        // 
                        this.HistorialTareaColFecha.Text = "Fecha";
                        this.HistorialTareaColFecha.Width = 80;
                        // 
                        // HistorialTareaColDetalle
                        // 
                        this.HistorialTareaColDetalle.Text = "Detalle";
                        this.HistorialTareaColDetalle.Width = 650;
                        // 
                        // ContAbajo
                        // 
                        this.ContAbajo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.ContAbajo.Location = new System.Drawing.Point(0, 283);
                        this.ContAbajo.Name = "ContAbajo";
                        // 
                        // ContAbajo.Panel1
                        // 
                        this.ContAbajo.Panel1.Controls.Add(this.FrameHistorialTarea);
                        this.ContAbajo.Panel1MinSize = 320;
                        // 
                        // ContAbajo.Panel2
                        // 
                        this.ContAbajo.Panel2.Controls.Add(this.FrameHistorialCliente);
                        this.ContAbajo.Panel2MinSize = 320;
                        this.ContAbajo.Size = new System.Drawing.Size(768, 203);
                        this.ContAbajo.SplitterDistance = 406;
                        this.ContAbajo.SplitterWidth = 6;
                        this.ContAbajo.TabIndex = 36;
                        this.ContAbajo.TabStop = false;
                        // 
                        // Editar
                        // 
                        this.AutoSize = true;
                        this.Controls.Add(this.ContAbajo);
                        this.Controls.Add(this.EntradaPrioridad);
                        this.Controls.Add(this.EntradaPresupuesto2);
                        this.Controls.Add(this.EntradaComprobanteId);
                        this.Controls.Add(this.EntradaComprobante);
                        this.Controls.Add(this.EntradaFechaIngreso);
                        this.Controls.Add(this.EntradaEstado);
                        this.Controls.Add(this.EntradaObs);
                        this.Controls.Add(this.EntradaImportePresupuesto);
                        this.Controls.Add(this.EntradaEntregaLimite);
                        this.Controls.Add(this.EntradaEntregaEstimada);
                        this.Controls.Add(this.EntradaDescripcion);
                        this.Controls.Add(this.EntradaAsunto);
                        this.Controls.Add(this.EntradaEncargado);
                        this.Controls.Add(this.EntradaTarea);
                        this.Controls.Add(this.EntradaCliente);
                        this.Controls.Add(this.Label15);
                        this.Controls.Add(this.Label11);
                        this.Controls.Add(this.Label7);
                        this.Controls.Add(this.Label5);
                        this.Controls.Add(this.Label4);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.Label14);
                        this.Controls.Add(this.Label6);
                        this.Controls.Add(this.Label12);
                        this.Controls.Add(this.Label9);
                        this.Controls.Add(this.Label8);
                        this.Controls.Add(this.Label13);
                        this.Controls.Add(this.Label10);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(771, 489);
                        this.Enter += new System.EventHandler(this.Editar_Enter);
                        this.FrameHistorialCliente.ResumeLayout(false);
                        this.FrameHistorialCliente.PerformLayout();
                        this.FrameHistorialTarea.ResumeLayout(false);
                        this.FrameHistorialTarea.PerformLayout();
                        this.ContAbajo.Panel1.ResumeLayout(false);
                        this.ContAbajo.Panel2.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.ContAbajo)).EndInit();
                        this.ContAbajo.ResumeLayout(false);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                internal Lui.Forms.Label Label1;
                internal Lcc.Entrada.CodigoDetalle EntradaCliente;
                internal Lcc.Entrada.CodigoDetalle EntradaTarea;
                internal Lui.Forms.Label Label3;
                internal Lcc.Entrada.CodigoDetalle EntradaEncargado;
                internal Lui.Forms.Label Label4;
                internal Lui.Forms.Label Label5;
                internal Lui.Forms.TextBox EntradaAsunto;
                internal Lui.Forms.Label Label6;
                internal Lui.Forms.Label Label7;
                internal Lui.Forms.TextBox EntradaDescripcion;
                internal Lui.Forms.Label Label8;
                internal Lui.Forms.Label Label9;
                internal Lui.Forms.Label Label10;
                internal Lui.Forms.TextBox EntradaEntregaEstimada;
                internal Lui.Forms.TextBox EntradaEntregaLimite;
                internal Lui.Forms.TextBox EntradaImportePresupuesto;
                internal Lui.Forms.TextBox EntradaObs;
                internal Lui.Forms.Label Label11;
                internal Lui.Forms.Frame FrameHistorialCliente;
                internal Lui.Forms.ListView ListaHistorialCliente;
                internal System.Windows.Forms.ColumnHeader HistorialClienteColEncargado;
                internal System.Windows.Forms.ColumnHeader HistorialClienteColDetalle;
                internal Lcc.Entrada.CodigoDetalle EntradaEstado;
                internal Lui.Forms.Label Label12;
                internal Lui.Forms.Label Label13;
                internal Lui.Forms.TextBox EntradaFechaIngreso;
                internal Lui.Forms.TextBox EntradaComprobante;
                internal System.Windows.Forms.TextBox EntradaComprobanteId;
                internal System.Windows.Forms.ColumnHeader HistorialClienteColFecha;
                internal Lui.Forms.TextBox EntradaPresupuesto2;
                internal Lui.Forms.Label Label14;
                internal Lui.Forms.Label Label15;
                internal Lui.Forms.ComboBox EntradaPrioridad;
                private System.Windows.Forms.ColumnHeader HistorialClienteColTarea;
                internal Lui.Forms.Frame FrameHistorialTarea;
                internal Lui.Forms.ListView ListaHistorialTarea;
                internal ColumnHeader HistorialTareaColEncargado;
                internal ColumnHeader HistorialTareaColFecha;
                internal ColumnHeader HistorialTareaColDetalle;
                private SplitContainer ContAbajo;
        }
}
