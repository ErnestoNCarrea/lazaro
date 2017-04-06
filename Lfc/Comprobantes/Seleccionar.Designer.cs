using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lfc.Comprobantes
{
        public partial class Seleccionar
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


                // Requerido por el Diseñador de Windows Forms
                private System.ComponentModel.IContainer components = null;

                private void InitializeComponent()
                {
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Seleccionar));
                        this.EtiquetaAviso = new Lui.Forms.Label();
                        this.EntradaNumero = new Lui.Forms.TextBox();
                        this.Label2 = new Lui.Forms.Label();
                        this.EntradaTipo = new Lui.Forms.ComboBox();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaPv = new Lui.Forms.TextBox();
                        this.Label7 = new Lui.Forms.Label();
                        this.Label4 = new Lui.Forms.Label();
                        this.Label8 = new Lui.Forms.Label();
                        this.EntradaVendedor = new Lcc.Entrada.CodigoDetalle();
                        this.Listado = new Lui.Forms.ListView();
                        this.ColId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColFecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColTipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColNumero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColImporte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColCancelada = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.EntradaCliente = new Lcc.Entrada.CodigoDetalle();
                        this.pictureBox1 = new System.Windows.Forms.PictureBox();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // EtiquetaAviso
                        // 
                        this.EtiquetaAviso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaAviso.Location = new System.Drawing.Point(8, 384);
                        this.EtiquetaAviso.Name = "EtiquetaAviso";
                        this.EtiquetaAviso.Size = new System.Drawing.Size(684, 24);
                        this.EtiquetaAviso.TabIndex = 11;
                        this.EtiquetaAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // EntradaNumero
                        // 
                        this.EntradaNumero.Location = new System.Drawing.Point(480, 88);
                        this.EntradaNumero.Name = "EntradaNumero";
                        this.EntradaNumero.Size = new System.Drawing.Size(96, 24);
                        this.EntradaNumero.TabIndex = 9;
                        this.EntradaNumero.TextChanged += new System.EventHandler(this.EntradaVendedorClienteTipoPVNumero_TextChanged);
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(336, 88);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(72, 24);
                        this.Label2.TabIndex = 6;
                        this.Label2.Text = "Número";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaTipo
                        // 
                        this.EntradaTipo.AlwaysExpanded = false;
                        this.EntradaTipo.AutoSize = true;
                        this.EntradaTipo.Location = new System.Drawing.Point(192, 88);
                        this.EntradaTipo.Name = "EntradaTipo";
                        this.EntradaTipo.SetData = new string[] {
        "Factura A|A",
        "Factura B|B",
        "Factura C|C",
        "Factura E|E",
        "Factura M|M",
        "Todas|*"};
                        this.EntradaTipo.Size = new System.Drawing.Size(124, 24);
                        this.EntradaTipo.TabIndex = 5;
                        this.EntradaTipo.TextKey = "*";
                        this.EntradaTipo.TextChanged += new System.EventHandler(this.EntradaVendedorClienteTipoPVNumero_TextChanged);
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(104, 88);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(88, 24);
                        this.Label1.TabIndex = 4;
                        this.Label1.Text = "Tipo";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaPv
                        // 
                        this.EntradaPv.Location = new System.Drawing.Point(408, 88);
                        this.EntradaPv.Name = "EntradaPv";
                        this.EntradaPv.Size = new System.Drawing.Size(48, 24);
                        this.EntradaPv.TabIndex = 7;
                        this.EntradaPv.TextChanged += new System.EventHandler(this.EntradaVendedorClienteTipoPVNumero_TextChanged);
                        // 
                        // Label7
                        // 
                        this.Label7.Location = new System.Drawing.Point(456, 88);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(24, 24);
                        this.Label7.TabIndex = 8;
                        this.Label7.Text = "-";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // Label4
                        // 
                        this.Label4.Location = new System.Drawing.Point(104, 24);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(88, 24);
                        this.Label4.TabIndex = 0;
                        this.Label4.Text = "Cliente";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label8
                        // 
                        this.Label8.Location = new System.Drawing.Point(104, 56);
                        this.Label8.Name = "Label8";
                        this.Label8.Size = new System.Drawing.Size(88, 24);
                        this.Label8.TabIndex = 2;
                        this.Label8.Text = "Vendedor";
                        this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaVendedor
                        // 
                        this.EntradaVendedor.AutoTab = true;
                        this.EntradaVendedor.CanCreate = true;
                        this.EntradaVendedor.Filter = "(tipo&4)=4";
                        this.EntradaVendedor.Location = new System.Drawing.Point(192, 56);
                        this.EntradaVendedor.MaxLength = 200;
                        this.EntradaVendedor.Name = "EntradaVendedor";
                        this.EntradaVendedor.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaVendedor.Required = false;
                        this.EntradaVendedor.Size = new System.Drawing.Size(432, 24);
                        this.EntradaVendedor.TabIndex = 3;
                        this.EntradaVendedor.Text = "0";
                        this.EntradaVendedor.TextChanged += new System.EventHandler(this.EntradaVendedorClienteTipoPVNumero_TextChanged);
                        // 
                        // Listado
                        // 
                        this.Listado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Listado.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.Listado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColId,
            this.ColFecha,
            this.ColTipo,
            this.ColNumero,
            this.ColCliente,
            this.ColImporte,
            this.ColCancelada});
                        this.Listado.FullRowSelect = true;
                        this.Listado.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.Listado.HideSelection = false;
                        this.Listado.LabelWrap = false;
                        this.Listado.Location = new System.Drawing.Point(24, 120);
                        this.Listado.MultiSelect = false;
                        this.Listado.Name = "Listado";
                        this.Listado.Size = new System.Drawing.Size(648, 264);
                        this.Listado.TabIndex = 10;
                        this.Listado.UseCompatibleStateImageBehavior = false;
                        this.Listado.View = System.Windows.Forms.View.Details;
                        this.Listado.SelectedIndexChanged += new System.EventHandler(this.Listado_SelectedIndexChanged);
                        this.Listado.DoubleClick += new System.EventHandler(this.Listado_DoubleClick);
                        this.Listado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Listado_KeyDown);
                        // 
                        // ColId
                        // 
                        this.ColId.Text = "Cód.";
                        this.ColId.Width = 0;
                        // 
                        // ColFecha
                        // 
                        this.ColFecha.Text = "Fecha";
                        this.ColFecha.Width = 86;
                        // 
                        // ColTipo
                        // 
                        this.ColTipo.Text = "Tipo";
                        this.ColTipo.Width = 42;
                        // 
                        // ColNumero
                        // 
                        this.ColNumero.Text = "Número";
                        this.ColNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.ColNumero.Width = 116;
                        // 
                        // ColCliente
                        // 
                        this.ColCliente.Text = "Cliente";
                        this.ColCliente.Width = 196;
                        // 
                        // ColImporte
                        // 
                        this.ColImporte.Text = "Importe";
                        this.ColImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.ColImporte.Width = 86;
                        // 
                        // ColCancelada
                        // 
                        this.ColCancelada.Text = "Cancelada";
                        this.ColCancelada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.ColCancelada.Width = 86;
                        // 
                        // EntradaCliente
                        // 
                        this.EntradaCliente.AutoTab = true;
                        this.EntradaCliente.CanCreate = true;
                        this.EntradaCliente.Location = new System.Drawing.Point(192, 24);
                        this.EntradaCliente.MaxLength = 200;
                        this.EntradaCliente.Name = "EntradaCliente";
                        this.EntradaCliente.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaCliente.Required = false;
                        this.EntradaCliente.Size = new System.Drawing.Size(432, 24);
                        this.EntradaCliente.TabIndex = 1;
                        this.EntradaCliente.Text = "0";
                        this.EntradaCliente.TextChanged += new System.EventHandler(this.EntradaVendedorClienteTipoPVNumero_TextChanged);
                        // 
                        // pictureBox1
                        // 
                        this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
                        this.pictureBox1.Location = new System.Drawing.Point(24, 24);
                        this.pictureBox1.Name = "pictureBox1";
                        this.pictureBox1.Size = new System.Drawing.Size(64, 64);
                        this.pictureBox1.TabIndex = 51;
                        this.pictureBox1.TabStop = false;
                        // 
                        // Seleccionar
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.ClientSize = new System.Drawing.Size(698, 475);
                        this.Controls.Add(this.pictureBox1);
                        this.Controls.Add(this.EntradaTipo);
                        this.Controls.Add(this.EntradaCliente);
                        this.Controls.Add(this.EntradaVendedor);
                        this.Controls.Add(this.EntradaPv);
                        this.Controls.Add(this.EntradaNumero);
                        this.Controls.Add(this.Label7);
                        this.Controls.Add(this.EtiquetaAviso);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.Label4);
                        this.Controls.Add(this.Label8);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.Listado);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "Seleccionar";
                        this.Text = "Seleccionar comprobante";
                        this.Controls.SetChildIndex(this.Listado, 0);
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.Label8, 0);
                        this.Controls.SetChildIndex(this.Label4, 0);
                        this.Controls.SetChildIndex(this.Label2, 0);
                        this.Controls.SetChildIndex(this.EtiquetaAviso, 0);
                        this.Controls.SetChildIndex(this.Label7, 0);
                        this.Controls.SetChildIndex(this.EntradaNumero, 0);
                        this.Controls.SetChildIndex(this.EntradaPv, 0);
                        this.Controls.SetChildIndex(this.EntradaVendedor, 0);
                        this.Controls.SetChildIndex(this.EntradaCliente, 0);
                        this.Controls.SetChildIndex(this.EntradaTipo, 0);
                        this.Controls.SetChildIndex(this.pictureBox1, 0);
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                internal Lui.Forms.Label EtiquetaAviso;
                internal Lui.Forms.TextBox EntradaNumero;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.ComboBox EntradaTipo;
                internal Lui.Forms.Label Label1;
                internal Lui.Forms.Label Label7;
                internal Lui.Forms.Label Label4;
                internal Lui.Forms.Label Label8;
                internal Lcc.Entrada.CodigoDetalle EntradaVendedor;
                internal Lui.Forms.ListView Listado;
                internal System.Windows.Forms.ColumnHeader ColFecha;
                internal System.Windows.Forms.ColumnHeader ColTipo;
                internal System.Windows.Forms.ColumnHeader ColNumero;
                internal System.Windows.Forms.ColumnHeader ColCliente;
                internal System.Windows.Forms.ColumnHeader ColImporte;
                internal Lui.Forms.TextBox EntradaPv;
                internal Lcc.Entrada.CodigoDetalle EntradaCliente;
                internal System.Windows.Forms.ColumnHeader ColCancelada;
                internal System.Windows.Forms.ColumnHeader ColId;
                private PictureBox pictureBox1;
        }
}
