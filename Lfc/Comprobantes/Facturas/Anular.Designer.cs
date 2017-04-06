using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Facturas
{
        public partial class Anular
        {
                #region Código generado por el Diseñador de Windows Forms

                // Limpiar los recursos que se estén utilizando.
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
                        this.components = new System.ComponentModel.Container();
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anular));
                        this.EntradaTipo = new Lui.Forms.ComboBox();
                        this.EntradaDesde = new Lui.Forms.TextBox();
                        this.EtiquetaAviso = new Lui.Forms.Label();
                        this.EntradaPV = new Lui.Forms.TextBox();
                        this.Label7 = new Lui.Forms.Label();
                        this.EntradaAnularPagos = new Lui.Forms.ComboBox();
                        this.label3 = new Lui.Forms.Label();
                        this.EntradaHasta = new Lui.Forms.TextBox();
                        this.label2 = new Lui.Forms.Label();
                        this.ListadoFacturas = new Lui.Forms.ListView();
                        this.ColTipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColNumero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColFecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColImporte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.label4 = new Lui.Forms.Label();
                        this.label5 = new Lui.Forms.Label();
                        this.label6 = new Lui.Forms.Label();
                        this.ComprobanteVistaPrevia = new Lfc.Comprobantes.Facturas.Editar();
                        this.TimerRefrescar = new System.Windows.Forms.Timer(this.components);
                        this.EntradaCompra = new Lui.Forms.ComboBox();
                        this.SuspendLayout();
                        // 
                        // EntradaTipo
                        // 
                        this.EntradaTipo.AlwaysExpanded = true;
                        this.EntradaTipo.Location = new System.Drawing.Point(152, 112);
                        this.EntradaTipo.Name = "EntradaTipo";
                        this.EntradaTipo.SetData = new string[] {
        "A|A",
        "B|B",
        "C|C",
        "E|E",
        "M|M",
        "Ticket|T"};
                        this.EntradaTipo.Size = new System.Drawing.Size(144, 88);
                        this.EntradaTipo.TabIndex = 1;
                        this.EntradaTipo.TextKey = "B";
                        this.EntradaTipo.TextChanged += new System.EventHandler(this.EntradaDesdeTipoPV_TextChanged);
                        // 
                        // EntradaDesde
                        // 
                        this.EntradaDesde.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaDesde.Location = new System.Drawing.Point(152, 248);
                        this.EntradaDesde.Name = "EntradaDesde";
                        this.EntradaDesde.Size = new System.Drawing.Size(100, 24);
                        this.EntradaDesde.TabIndex = 5;
                        this.EntradaDesde.Text = "0";
                        this.EntradaDesde.TextChanged += new System.EventHandler(this.EntradaDesdeTipoPV_TextChanged);
                        // 
                        // EtiquetaAviso
                        // 
                        this.EtiquetaAviso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
                        this.EtiquetaAviso.Location = new System.Drawing.Point(24, 360);
                        this.EtiquetaAviso.Name = "EtiquetaAviso";
                        this.EtiquetaAviso.Size = new System.Drawing.Size(272, 71);
                        this.EtiquetaAviso.TabIndex = 10;
                        this.EtiquetaAviso.UseMnemonic = false;
                        // 
                        // EntradaPV
                        // 
                        this.EntradaPV.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaPV.Location = new System.Drawing.Point(152, 216);
                        this.EntradaPV.Name = "EntradaPV";
                        this.EntradaPV.Size = new System.Drawing.Size(52, 24);
                        this.EntradaPV.TabIndex = 3;
                        this.EntradaPV.Text = "1";
                        this.EntradaPV.TextChanged += new System.EventHandler(this.EntradaDesdeTipoPV_TextChanged);
                        // 
                        // Label7
                        // 
                        this.Label7.Location = new System.Drawing.Point(24, 248);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(128, 24);
                        this.Label7.TabIndex = 4;
                        this.Label7.Text = "Desde";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaAnularPagos
                        // 
                        this.EntradaAnularPagos.AlwaysExpanded = true;
                        this.EntradaAnularPagos.AutoSize = true;
                        this.EntradaAnularPagos.Location = new System.Drawing.Point(152, 312);
                        this.EntradaAnularPagos.Name = "EntradaAnularPagos";
                        this.EntradaAnularPagos.SetData = new string[] {
        "Si, revertir los cobros|1",
        "No, dejar los cobros|0"};
                        this.EntradaAnularPagos.Size = new System.Drawing.Size(144, 40);
                        this.EntradaAnularPagos.TabIndex = 9;
                        this.EntradaAnularPagos.TextKey = "0";
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(24, 312);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(128, 24);
                        this.label3.TabIndex = 8;
                        this.label3.Text = "Revertir cobros";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaHasta
                        // 
                        this.EntradaHasta.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaHasta.Location = new System.Drawing.Point(152, 280);
                        this.EntradaHasta.Name = "EntradaHasta";
                        this.EntradaHasta.Size = new System.Drawing.Size(100, 24);
                        this.EntradaHasta.TabIndex = 7;
                        this.EntradaHasta.Text = "0";
                        this.EntradaHasta.TextChanged += new System.EventHandler(this.EntradaDesdeTipoPV_TextChanged);
                        this.EntradaHasta.Enter += new System.EventHandler(this.EntradaHasta_Enter);
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(24, 280);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(128, 24);
                        this.label2.TabIndex = 6;
                        this.label2.Text = "Hasta";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // ListadoFacturas
                        // 
                        this.ListadoFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.ListadoFacturas.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.ListadoFacturas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColTipo,
            this.ColNumero,
            this.ColFecha,
            this.ColCliente,
            this.ColImporte});
                        this.ListadoFacturas.FieldName = null;
                        this.ListadoFacturas.FullRowSelect = true;
                        this.ListadoFacturas.LabelWrap = false;
                        this.ListadoFacturas.Location = new System.Drawing.Point(320, 112);
                        this.ListadoFacturas.MultiSelect = false;
                        this.ListadoFacturas.Name = "ListadoFacturas";
                        this.ListadoFacturas.ReadOnly = false;
                        this.ListadoFacturas.Size = new System.Drawing.Size(616, 320);
                        this.ListadoFacturas.TabIndex = 11;
                        this.ListadoFacturas.UseCompatibleStateImageBehavior = false;
                        this.ListadoFacturas.View = System.Windows.Forms.View.Details;
                        // 
                        // ColTipo
                        // 
                        this.ColTipo.Text = "Tipo";
                        this.ColTipo.Width = 120;
                        // 
                        // ColNumero
                        // 
                        this.ColNumero.Text = "Número";
                        this.ColNumero.Width = 120;
                        // 
                        // ColFecha
                        // 
                        this.ColFecha.Text = "Fecha";
                        this.ColFecha.Width = 96;
                        // 
                        // ColCliente
                        // 
                        this.ColCliente.Text = "Cliente";
                        this.ColCliente.Width = 320;
                        // 
                        // ColImporte
                        // 
                        this.ColImporte.Text = "Importe";
                        this.ColImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.ColImporte.Width = 96;
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(24, 216);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(128, 24);
                        this.label4.TabIndex = 2;
                        this.label4.Text = "Punto de venta";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label5
                        // 
                        this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label5.Location = new System.Drawing.Point(24, 64);
                        this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(912, 40);
                        this.label5.TabIndex = 102;
                        this.label5.Text = resources.GetString("label5.Text");
                        // 
                        // label6
                        // 
                        this.label6.AutoSize = true;
                        this.label6.Location = new System.Drawing.Point(24, 24);
                        this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(328, 30);
                        this.label6.TabIndex = 101;
                        this.label6.Text = "Anular uno o más comprobantes";
                        this.label6.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        this.label6.UseMnemonic = false;
                        // 
                        // ComprobanteVistaPrevia
                        // 
                        this.ComprobanteVistaPrevia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.ComprobanteVistaPrevia.AutoSize = true;
                        this.ComprobanteVistaPrevia.Location = new System.Drawing.Point(320, 112);
                        this.ComprobanteVistaPrevia.MinimumSize = new System.Drawing.Size(600, 320);
                        this.ComprobanteVistaPrevia.Name = "ComprobanteVistaPrevia";
                        this.ComprobanteVistaPrevia.Size = new System.Drawing.Size(616, 320);
                        this.ComprobanteVistaPrevia.TabIndex = 12;
                        this.ComprobanteVistaPrevia.TabStop = false;
                        this.ComprobanteVistaPrevia.Visible = false;
                        // 
                        // TimerRefrescar
                        // 
                        this.TimerRefrescar.Interval = 750;
                        this.TimerRefrescar.Tick += new System.EventHandler(this.TimerRefrescar_Tick);
                        // 
                        // EntradaCompra
                        // 
                        this.EntradaCompra.AlwaysExpanded = true;
                        this.EntradaCompra.AutoSize = true;
                        this.EntradaCompra.Location = new System.Drawing.Point(27, 112);
                        this.EntradaCompra.Name = "EntradaCompra";
                        this.EntradaCompra.SetData = new string[] {
        "Venta|0",
        "Compra|1"};
                        this.EntradaCompra.Size = new System.Drawing.Size(119, 40);
                        this.EntradaCompra.TabIndex = 0;
                        this.EntradaCompra.TextKey = "0";
                        this.EntradaCompra.TextChanged += new System.EventHandler(this.EntradaCompra_TextChanged);
                        // 
                        // Anular
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.ClientSize = new System.Drawing.Size(962, 521);
                        this.Controls.Add(this.EntradaCompra);
                        this.Controls.Add(this.label5);
                        this.Controls.Add(this.label6);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.EntradaHasta);
                        this.Controls.Add(this.EntradaTipo);
                        this.Controls.Add(this.EntradaAnularPagos);
                        this.Controls.Add(this.Label7);
                        this.Controls.Add(this.EntradaPV);
                        this.Controls.Add(this.EntradaDesde);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.EtiquetaAviso);
                        this.Controls.Add(this.ComprobanteVistaPrevia);
                        this.Controls.Add(this.ListadoFacturas);
                        this.Name = "Anular";
                        this.Text = "Anular comprobantes";
                        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                        this.Controls.SetChildIndex(this.ListadoFacturas, 0);
                        this.Controls.SetChildIndex(this.ComprobanteVistaPrevia, 0);
                        this.Controls.SetChildIndex(this.EtiquetaAviso, 0);
                        this.Controls.SetChildIndex(this.label3, 0);
                        this.Controls.SetChildIndex(this.EntradaDesde, 0);
                        this.Controls.SetChildIndex(this.EntradaPV, 0);
                        this.Controls.SetChildIndex(this.Label7, 0);
                        this.Controls.SetChildIndex(this.EntradaAnularPagos, 0);
                        this.Controls.SetChildIndex(this.EntradaTipo, 0);
                        this.Controls.SetChildIndex(this.EntradaHasta, 0);
                        this.Controls.SetChildIndex(this.label2, 0);
                        this.Controls.SetChildIndex(this.label4, 0);
                        this.Controls.SetChildIndex(this.label6, 0);
                        this.Controls.SetChildIndex(this.label5, 0);
                        this.Controls.SetChildIndex(this.EntradaCompra, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.ComponentModel.IContainer components = null;
                public Lui.Forms.ComboBox EntradaTipo;
                internal Lui.Forms.TextBox EntradaDesde;
                internal Lui.Forms.Label EtiquetaAviso;
                internal Lui.Forms.TextBox EntradaPV;
                internal Lui.Forms.Label Label7;
                public Lui.Forms.ComboBox EntradaAnularPagos;
                private Lfc.Comprobantes.Facturas.Editar ComprobanteVistaPrevia;
                internal Lui.Forms.TextBox EntradaHasta;
                private Lui.Forms.ListView ListadoFacturas;
                private ColumnHeader ColTipo;
                private ColumnHeader ColNumero;
                private ColumnHeader ColFecha;
                private ColumnHeader ColCliente;
                private ColumnHeader ColImporte;
                private Lui.Forms.Label label3;
                internal Lui.Forms.Label label2;
                internal Lui.Forms.Label label4;
                private Lui.Forms.Label label5;
                private Lui.Forms.Label label6;
                private Timer TimerRefrescar;
                public Lui.Forms.ComboBox EntradaCompra;
        }
}
