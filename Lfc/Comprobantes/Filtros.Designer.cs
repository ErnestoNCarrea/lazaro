using System;
using System.Windows.Forms;

namespace Lfc.Comprobantes
{
        public partial class Filtros
        {
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }

                        base.Dispose(disposing);
                }

                private System.ComponentModel.IContainer components = null;

                #region Código generado por el Diseñador de Windows Forms

                private void InitializeComponent()
                {
                        this.EntradaCliente = new Lcc.Entrada.CodigoDetalle();
                        this.Label2 = new Lui.Forms.Label();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaEstado = new Lui.Forms.ComboBox();
                        this.Label3 = new Lui.Forms.Label();
                        this.EntradaTipo = new Lui.Forms.ComboBox();
                        this.Label4 = new Lui.Forms.Label();
                        this.EntradaVendedor = new Lcc.Entrada.CodigoDetalle();
                        this.Label5 = new Lui.Forms.Label();
                        this.EntradaAnuladas = new Lui.Forms.ComboBox();
                        this.Label6 = new Lui.Forms.Label();
                        this.EntradaSucursal = new Lcc.Entrada.CodigoDetalle();
                        this.label7 = new Lui.Forms.Label();
                        this.EntradaFormaPago = new Lcc.Entrada.CodigoDetalle();
                        this.label8 = new Lui.Forms.Label();
                        this.EntradaLetra = new Lui.Forms.ComboBox();
                        this.Label9 = new Lui.Forms.Label();
                        this.EntradaPv = new Lui.Forms.TextBox();
                        this.EntradaFechas = new Lcc.Entrada.RangoFechas();
                        this.tableLayoutPanel1 = new Lui.Forms.TableLayoutPanel();
                        this.label10 = new Lui.Forms.Label();
                        this.tableLayoutPanel3 = new Lui.Forms.TableLayoutPanel();
                        this.EntradaMontoHasta = new Lui.Forms.TextBox();
                        this.EntradaMontoDesde = new Lui.Forms.TextBox();
                        this.label12 = new Lui.Forms.Label();
                        this.label11 = new Lui.Forms.Label();
                        this.tableLayoutPanel2 = new Lui.Forms.TableLayoutPanel();
                        this.tableLayoutPanel1.SuspendLayout();
                        this.tableLayoutPanel3.SuspendLayout();
                        this.tableLayoutPanel2.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // OkButton
                        // 
                        this.OkButton.Location = new System.Drawing.Point(394, 8);
                        // 
                        // CancelCommandButton
                        // 
                        this.CancelCommandButton.Location = new System.Drawing.Point(514, 8);
                        // 
                        // EntradaCliente
                        // 
                        this.EntradaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaCliente.CanCreate = false;
                        this.EntradaCliente.Filter = "";
                        this.EntradaCliente.Location = new System.Drawing.Point(137, 152);
                        this.EntradaCliente.MaxLength = 200;
                        this.EntradaCliente.Name = "EntradaCliente";
                        this.EntradaCliente.Required = false;
                        this.EntradaCliente.Size = new System.Drawing.Size(446, 24);
                        this.EntradaCliente.TabIndex = 11;
                        this.EntradaCliente.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaCliente.Text = "0";
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(3, 149);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(128, 24);
                        this.Label2.TabIndex = 10;
                        this.Label2.Text = "Cliente";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(3, 271);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(128, 24);
                        this.Label1.TabIndex = 18;
                        this.Label1.Text = "Fecha";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaEstado
                        // 
                        this.EntradaEstado.AlwaysExpanded = false;
                        this.EntradaEstado.AutoSize = true;
                        this.EntradaEstado.Name = "EntradaEstado";
                        this.EntradaEstado.SetData = new string[] {
        "Todas|0",
        "Sólo las Impresas|3",
        "Sólo las Pagas|1",
        "Sólo las Impresas e Impagas|2"};
                        this.EntradaEstado.Size = new System.Drawing.Size(248, 25);
                        this.EntradaEstado.TabIndex = 15;
                        this.EntradaEstado.TextKey = "0";
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(3, 209);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(128, 24);
                        this.Label3.TabIndex = 14;
                        this.Label3.Text = "Estado";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaTipo
                        // 
                        this.EntradaTipo.AlwaysExpanded = false;
                        this.EntradaTipo.AutoSize = true;
                        this.EntradaTipo.Location = new System.Drawing.Point(3, 3);
                        this.EntradaTipo.Name = "EntradaTipo";
                        this.EntradaTipo.SetData = new string[] {
        "Comprob. Facturables|Lbl.Comprobantes.ComprobanteFacturable",
        "Facturas|Lbl.Comprobantes.Factura",
        "Tickets|Lbl.Comprobantes.Ticket",
        "Notas de Crédito|Lbl.Comprobantes.NotaDeCredito",
        "Notas de Débito|Lbl.Comprobantes.NotaDeDebito",
        "Presupuestos|Lbl.Comprobantes.Presupuesto",
        "Remitos|Lbl.Comprobantes.Remito"};
                        this.EntradaTipo.Size = new System.Drawing.Size(180, 25);
                        this.EntradaTipo.TabIndex = 0;
                        this.EntradaTipo.TextKey = "Lbl.Comprobantes.Factura";
                        this.EntradaTipo.TextChanged += new System.EventHandler(this.EntradaTipo_TextChanged);
                        // 
                        // Label4
                        // 
                        this.Label4.Location = new System.Drawing.Point(3, 88);
                        this.Label4.Name = "Label4";
                        this.Label4.Size = new System.Drawing.Size(128, 24);
                        this.Label4.TabIndex = 6;
                        this.Label4.Text = "Tipo";
                        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaVendedor
                        // 
                        this.EntradaVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaVendedor.CanCreate = false;
                        this.EntradaVendedor.Filter = "(tipo&4)=4";
                        this.EntradaVendedor.Location = new System.Drawing.Point(137, 182);
                        this.EntradaVendedor.MaxLength = 200;
                        this.EntradaVendedor.Name = "EntradaVendedor";
                        this.EntradaVendedor.Required = false;
                        this.EntradaVendedor.Size = new System.Drawing.Size(446, 24);
                        this.EntradaVendedor.TabIndex = 13;
                        this.EntradaVendedor.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaVendedor.Text = "0";
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(3, 179);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(128, 24);
                        this.Label5.TabIndex = 12;
                        this.Label5.Text = "Vendedor";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaAnuladas
                        // 
                        this.EntradaAnuladas.AlwaysExpanded = false;
                        this.EntradaAnuladas.AutoSize = true;
                        this.EntradaAnuladas.Location = new System.Drawing.Point(137, 243);
                        this.EntradaAnuladas.Name = "EntradaAnuladas";
                        this.EntradaAnuladas.SetData = new string[] {
        "Ocultar|0",
        "Mostrar|1"};
                        this.EntradaAnuladas.Size = new System.Drawing.Size(248, 25);
                        this.EntradaAnuladas.TabIndex = 17;
                        this.EntradaAnuladas.TextKey = "0";
                        // 
                        // Label6
                        // 
                        this.Label6.Location = new System.Drawing.Point(3, 240);
                        this.Label6.Name = "Label6";
                        this.Label6.Size = new System.Drawing.Size(128, 24);
                        this.Label6.TabIndex = 16;
                        this.Label6.Text = "Anuladas";
                        this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaSucursal
                        // 
                        this.EntradaSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaSucursal.CanCreate = false;
                        this.EntradaSucursal.Filter = "";
                        this.EntradaSucursal.Location = new System.Drawing.Point(137, 3);
                        this.EntradaSucursal.MaxLength = 200;
                        this.EntradaSucursal.Name = "EntradaSucursal";
                        this.EntradaSucursal.Required = false;
                        this.EntradaSucursal.Size = new System.Drawing.Size(446, 24);
                        this.EntradaSucursal.TabIndex = 1;
                        this.EntradaSucursal.NombreTipo = "Lbl.Entidades.Sucursal";
                        this.EntradaSucursal.Text = "0";
                        // 
                        // label7
                        // 
                        this.label7.Location = new System.Drawing.Point(3, 0);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(128, 24);
                        this.label7.TabIndex = 0;
                        this.label7.Text = "Sucursal";
                        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFormaPago
                        // 
                        this.EntradaFormaPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaFormaPago.CanCreate = false;
                        this.EntradaFormaPago.Filter = "";
                        this.EntradaFormaPago.Location = new System.Drawing.Point(137, 33);
                        this.EntradaFormaPago.MaxLength = 200;
                        this.EntradaFormaPago.Name = "EntradaFormaPago";
                        this.EntradaFormaPago.Required = false;
                        this.EntradaFormaPago.Size = new System.Drawing.Size(446, 24);
                        this.EntradaFormaPago.TabIndex = 3;
                        this.EntradaFormaPago.NombreTipo = "Lbl.Pagos.FormaDePago";
                        this.EntradaFormaPago.Text = "0";
                        // 
                        // label8
                        // 
                        this.label8.Location = new System.Drawing.Point(3, 60);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(128, 24);
                        this.label8.TabIndex = 4;
                        this.label8.Text = "Monto";
                        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaLetra
                        // 
                        this.EntradaLetra.AlwaysExpanded = false;
                        this.EntradaLetra.AutoSize = true;
                        this.EntradaLetra.Location = new System.Drawing.Point(189, 3);
                        this.EntradaLetra.Name = "EntradaLetra";
                        this.EntradaLetra.SetData = new string[] {
        "Todas|*",
        "A|A",
        "B|B",
        "C|C",
        "E|E",
        "M|M"};
                        this.EntradaLetra.Size = new System.Drawing.Size(84, 25);
                        this.EntradaLetra.TabIndex = 1;
                        this.EntradaLetra.TextKey = "*";
                        // 
                        // Label9
                        // 
                        this.Label9.Location = new System.Drawing.Point(3, 119);
                        this.Label9.Name = "Label9";
                        this.Label9.Size = new System.Drawing.Size(128, 24);
                        this.Label9.TabIndex = 8;
                        this.Label9.Text = "PV";
                        this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaPv
                        // 
                        this.EntradaPv.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaPv.Location = new System.Drawing.Point(137, 122);
                        this.EntradaPv.Name = "EntradaPv";
                        this.EntradaPv.Size = new System.Drawing.Size(44, 24);
                        this.EntradaPv.TabIndex = 9;
                        this.EntradaPv.Text = "0";
                        // 
                        // EntradaFechas
                        // 
                        this.EntradaFechas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaFechas.AutoSize = true;
                        this.EntradaFechas.Location = new System.Drawing.Point(137, 274);
                        this.EntradaFechas.MuestraFuturos = false;
                        this.EntradaFechas.Name = "EntradaFechas";
                        this.EntradaFechas.Size = new System.Drawing.Size(446, 33);
                        this.EntradaFechas.TabIndex = 19;
                        // 
                        // tableLayoutPanel1
                        // 
                        this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.tableLayoutPanel1.ColumnCount = 2;
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                        this.tableLayoutPanel1.Controls.Add(this.label10, 0, 1);
                        this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 2);
                        this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
                        this.tableLayoutPanel1.Controls.Add(this.EntradaFechas, 1, 9);
                        this.tableLayoutPanel1.Controls.Add(this.label8, 0, 2);
                        this.tableLayoutPanel1.Controls.Add(this.EntradaPv, 1, 4);
                        this.tableLayoutPanel1.Controls.Add(this.EntradaAnuladas, 1, 8);
                        this.tableLayoutPanel1.Controls.Add(this.Label4, 0, 3);
                        this.tableLayoutPanel1.Controls.Add(this.EntradaEstado, 1, 7);
                        this.tableLayoutPanel1.Controls.Add(this.EntradaVendedor, 1, 6);
                        this.tableLayoutPanel1.Controls.Add(this.Label9, 0, 4);
                        this.tableLayoutPanel1.Controls.Add(this.EntradaCliente, 1, 5);
                        this.tableLayoutPanel1.Controls.Add(this.Label2, 0, 5);
                        this.tableLayoutPanel1.Controls.Add(this.EntradaSucursal, 1, 0);
                        this.tableLayoutPanel1.Controls.Add(this.Label5, 0, 6);
                        this.tableLayoutPanel1.Controls.Add(this.Label3, 0, 7);
                        this.tableLayoutPanel1.Controls.Add(this.Label6, 0, 8);
                        this.tableLayoutPanel1.Controls.Add(this.Label1, 0, 9);
                        this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 3);
                        this.tableLayoutPanel1.Controls.Add(this.EntradaFormaPago, 1, 1);
                        this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 24);
                        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
                        this.tableLayoutPanel1.RowCount = 10;
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel1.Size = new System.Drawing.Size(586, 366);
                        this.tableLayoutPanel1.TabIndex = 0;
                        // 
                        // label10
                        // 
                        this.label10.Location = new System.Drawing.Point(3, 30);
                        this.label10.Name = "label10";
                        this.label10.Size = new System.Drawing.Size(128, 24);
                        this.label10.TabIndex = 2;
                        this.label10.Text = "Pago";
                        this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // tableLayoutPanel3
                        // 
                        this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.tableLayoutPanel3.ColumnCount = 4;
                        this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                        this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                        this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                        this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                        this.tableLayoutPanel3.Controls.Add(this.EntradaMontoHasta, 3, 0);
                        this.tableLayoutPanel3.Controls.Add(this.EntradaMontoDesde, 1, 0);
                        this.tableLayoutPanel3.Controls.Add(this.label12, 2, 0);
                        this.tableLayoutPanel3.Controls.Add(this.label11, 0, 0);
                        this.tableLayoutPanel3.Location = new System.Drawing.Point(134, 60);
                        this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
                        this.tableLayoutPanel3.Name = "tableLayoutPanel3";
                        this.tableLayoutPanel3.RowCount = 1;
                        this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel3.Size = new System.Drawing.Size(452, 28);
                        this.tableLayoutPanel3.TabIndex = 5;
                        // 
                        // EntradaMontoHasta
                        // 
                        this.EntradaMontoHasta.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaMontoHasta.Location = new System.Drawing.Point(214, 3);
                        this.EntradaMontoHasta.Name = "EntradaMontoHasta";
                        this.EntradaMontoHasta.Prefijo = "$";
                        this.EntradaMontoHasta.Size = new System.Drawing.Size(109, 24);
                        this.EntradaMontoHasta.TabIndex = 3;
                        // 
                        // EntradaMontoDesde
                        // 
                        this.EntradaMontoDesde.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaMontoDesde.Location = new System.Drawing.Point(62, 3);
                        this.EntradaMontoDesde.Name = "EntradaMontoDesde";
                        this.EntradaMontoDesde.Prefijo = "$";
                        this.EntradaMontoDesde.Size = new System.Drawing.Size(114, 24);
                        this.EntradaMontoDesde.TabIndex = 1;
                        // 
                        // label12
                        // 
                        this.label12.Location = new System.Drawing.Point(182, 0);
                        this.label12.Name = "label12";
                        this.label12.Size = new System.Drawing.Size(26, 24);
                        this.label12.TabIndex = 2;
                        this.label12.Text = "y";
                        this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label11
                        // 
                        this.label11.Location = new System.Drawing.Point(3, 0);
                        this.label11.Name = "label11";
                        this.label11.Size = new System.Drawing.Size(53, 24);
                        this.label11.TabIndex = 0;
                        this.label11.Text = "entre";
                        this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // tableLayoutPanel2
                        // 
                        this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.tableLayoutPanel2.AutoSize = true;
                        this.tableLayoutPanel2.ColumnCount = 2;
                        this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                        this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                        this.tableLayoutPanel2.Controls.Add(this.EntradaTipo, 0, 0);
                        this.tableLayoutPanel2.Controls.Add(this.EntradaLetra, 1, 0);
                        this.tableLayoutPanel2.Location = new System.Drawing.Point(134, 88);
                        this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
                        this.tableLayoutPanel2.Name = "tableLayoutPanel2";
                        this.tableLayoutPanel2.RowCount = 1;
                        this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.tableLayoutPanel2.Size = new System.Drawing.Size(452, 31);
                        this.tableLayoutPanel2.TabIndex = 7;
                        // 
                        // Filtros
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(634, 454);
                        this.Controls.Add(this.tableLayoutPanel1);
                        this.Name = "Filtros";
                        this.Text = "Filtros";
                        this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
                        this.tableLayoutPanel1.ResumeLayout(false);
                        this.tableLayoutPanel1.PerformLayout();
                        this.tableLayoutPanel3.ResumeLayout(false);
                        this.tableLayoutPanel2.ResumeLayout(false);
                        this.tableLayoutPanel2.PerformLayout();
                        this.ResumeLayout(false);

                }

                #endregion

                internal Lcc.Entrada.CodigoDetalle EntradaCliente;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.Label Label1;
                internal Lui.Forms.Label Label3;
                internal Lui.Forms.Label Label4;
                internal Lui.Forms.ComboBox EntradaEstado;
                internal Lui.Forms.ComboBox EntradaTipo;
                internal Lcc.Entrada.CodigoDetalle EntradaVendedor;
                internal Lui.Forms.Label Label5;
                internal Lui.Forms.ComboBox EntradaAnuladas;
                internal Lui.Forms.Label label7;
                internal Lcc.Entrada.CodigoDetalle EntradaSucursal;
                internal Lui.Forms.Label label8;
                internal Lcc.Entrada.CodigoDetalle EntradaFormaPago;
                internal Lui.Forms.ComboBox EntradaLetra;
                internal Label Label9;
                internal Lui.Forms.TextBox EntradaPv;
                internal Lcc.Entrada.RangoFechas EntradaFechas;
                private TableLayoutPanel tableLayoutPanel1;
                private TableLayoutPanel tableLayoutPanel2;
                internal Label label10;
                private TableLayoutPanel tableLayoutPanel3;
                internal Lui.Forms.TextBox EntradaMontoHasta;
                internal Lui.Forms.TextBox EntradaMontoDesde;
                internal Label label12;
                internal Label label11;
                internal Lui.Forms.Label Label6;
        }
}
