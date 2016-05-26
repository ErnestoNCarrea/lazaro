using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Reportes
{
        public class Facturacion : Lui.Forms.ChildForm
        {
                private Lui.Forms.Chart Chart;
                internal Lui.Forms.Button PorMes;
                internal Lui.Forms.Button PorRentabilidad;
                private System.Windows.Forms.PictureBox pictureBox1;
                private Lui.Forms.Label label1;
                private Lui.Forms.Label label2;
                private System.Windows.Forms.PictureBox pictureBox2;
                private Lui.Forms.Label label3;
                private System.Windows.Forms.PictureBox pictureBox3;
                private Lui.Forms.Label label4;
                private System.Windows.Forms.PictureBox pictureBox4;
                private Lui.Forms.Chart ChartRent;
                private Lui.Forms.ListView ListadoAnual;
                private System.Windows.Forms.ColumnHeader lvAnualMes;
                private System.Windows.Forms.ColumnHeader lvAnualMonto;
                private Lui.Forms.Label label7;
                private System.Windows.Forms.PictureBox pictureBox7;
                private Lui.Forms.Label label8;
                private System.Windows.Forms.PictureBox pictureBox8;
                private Lui.Forms.Label label9;
                private System.Windows.Forms.PictureBox pictureBox9;
                internal Lui.Forms.Button BotonPorDiaDelMes;
                private Lui.Forms.Chart ChartMes;
                private Label label5;
                private PictureBox pictureBox5;
                private Label label6;
                private PictureBox pictureBox6;
                private Label label10;
                private PictureBox pictureBox10;
                private System.ComponentModel.IContainer components = null;

                public Facturacion()
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.Cajas.Caja), Lbl.Sys.Permisos.Operaciones.Administrar) == false) {
                                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                                this.Close();
                                return;
                        }

                        InitializeComponent();
                }

                /// <summary>
                /// Limpiar los recursos que se estén utilizando.
                /// </summary>
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }
                        base.Dispose(disposing);
                }

                #region Código generado por el diseñador
                /// <summary>
                /// Método necesario para admitir el Diseñador. No se puede modificar
                /// el contenido del método con el editor de código.
                /// </summary>
                private void InitializeComponent()
                {
                        this.Chart = new Lui.Forms.Chart();
                        this.PorMes = new Lui.Forms.Button();
                        this.PorRentabilidad = new Lui.Forms.Button();
                        this.ChartRent = new Lui.Forms.Chart();
                        this.pictureBox1 = new System.Windows.Forms.PictureBox();
                        this.label1 = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.pictureBox2 = new System.Windows.Forms.PictureBox();
                        this.label3 = new Lui.Forms.Label();
                        this.pictureBox3 = new System.Windows.Forms.PictureBox();
                        this.label4 = new Lui.Forms.Label();
                        this.pictureBox4 = new System.Windows.Forms.PictureBox();
                        this.ListadoAnual = new Lui.Forms.ListView();
                        this.lvAnualMes = new System.Windows.Forms.ColumnHeader();
                        this.lvAnualMonto = new System.Windows.Forms.ColumnHeader();
                        this.label7 = new Lui.Forms.Label();
                        this.pictureBox7 = new System.Windows.Forms.PictureBox();
                        this.label8 = new Lui.Forms.Label();
                        this.pictureBox8 = new System.Windows.Forms.PictureBox();
                        this.ChartMes = new Lui.Forms.Chart();
                        this.BotonPorDiaDelMes = new Lui.Forms.Button();
                        this.label9 = new Lui.Forms.Label();
                        this.pictureBox9 = new System.Windows.Forms.PictureBox();
                        this.label5 = new Lui.Forms.Label();
                        this.pictureBox5 = new System.Windows.Forms.PictureBox();
                        this.label6 = new Lui.Forms.Label();
                        this.pictureBox6 = new System.Windows.Forms.PictureBox();
                        this.label10 = new Lui.Forms.Label();
                        this.pictureBox10 = new System.Windows.Forms.PictureBox();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // Chart
                        // 
                        this.Chart.BackColor = System.Drawing.Color.White;
                        this.Chart.Location = new System.Drawing.Point(156, 8);
                        this.Chart.Name = "Chart";
                        this.Chart.Size = new System.Drawing.Size(420, 164);
                        this.Chart.TabIndex = 0;
                        this.Chart.Title = "Comparativa por Año";
                        this.Chart.VerticalGrid = true;
                        // 
                        // PorMes
                        // 
                        this.PorMes.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.PorMes.Image = null;
                        this.PorMes.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.PorMes.Location = new System.Drawing.Point(48, 136);
                        this.PorMes.Name = "PorMes";
                        this.PorMes.Size = new System.Drawing.Size(100, 40);
                        this.PorMes.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.PorMes.Subtext = "";
                        this.PorMes.TabIndex = 1;
                        this.PorMes.Text = "Mostrar";
                        this.PorMes.Click += new System.EventHandler(this.PorMes_Click);
                        // 
                        // PorRentabilidad
                        // 
                        this.PorRentabilidad.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.PorRentabilidad.Image = null;
                        this.PorRentabilidad.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.PorRentabilidad.Location = new System.Drawing.Point(48, 308);
                        this.PorRentabilidad.Name = "PorRentabilidad";
                        this.PorRentabilidad.Size = new System.Drawing.Size(100, 40);
                        this.PorRentabilidad.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.PorRentabilidad.Subtext = "";
                        this.PorRentabilidad.TabIndex = 2;
                        this.PorRentabilidad.Text = "Mostrar";
                        this.PorRentabilidad.Click += new System.EventHandler(this.PorRentabilidad_Click);
                        // 
                        // ChartRent
                        // 
                        this.ChartRent.BackColor = System.Drawing.Color.White;
                        this.ChartRent.Location = new System.Drawing.Point(156, 180);
                        this.ChartRent.Name = "ChartRent";
                        this.ChartRent.Size = new System.Drawing.Size(420, 164);
                        this.ChartRent.TabIndex = 3;
                        this.ChartRent.Title = "Rentabilidad";
                        this.ChartRent.VerticalGrid = true;
                        // 
                        // pictureBox1
                        // 
                        this.pictureBox1.BackColor = System.Drawing.Color.Green;
                        this.pictureBox1.Location = new System.Drawing.Point(12, 20);
                        this.pictureBox1.Name = "pictureBox1";
                        this.pictureBox1.Size = new System.Drawing.Size(20, 8);
                        this.pictureBox1.TabIndex = 4;
                        this.pictureBox1.TabStop = false;
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(40, 76);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(108, 16);
                        this.label1.TabIndex = 5;
                        this.label1.Text = "Año ante pasado";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(40, 56);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(108, 16);
                        this.label2.TabIndex = 7;
                        this.label2.Text = "Año pasado";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // pictureBox2
                        // 
                        this.pictureBox2.BackColor = System.Drawing.Color.DarkGreen;
                        this.pictureBox2.Location = new System.Drawing.Point(32, 40);
                        this.pictureBox2.Name = "pictureBox2";
                        this.pictureBox2.Size = new System.Drawing.Size(20, 8);
                        this.pictureBox2.TabIndex = 6;
                        this.pictureBox2.TabStop = false;
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(40, 16);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(108, 16);
                        this.label3.TabIndex = 9;
                        this.label3.Text = "Este año";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // pictureBox3
                        // 
                        this.pictureBox3.BackColor = System.Drawing.Color.Gainsboro;
                        this.pictureBox3.Location = new System.Drawing.Point(12, 80);
                        this.pictureBox3.Name = "pictureBox3";
                        this.pictureBox3.Size = new System.Drawing.Size(20, 8);
                        this.pictureBox3.TabIndex = 8;
                        this.pictureBox3.TabStop = false;
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(60, 36);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(88, 16);
                        this.label4.TabIndex = 11;
                        this.label4.Text = "Costo";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // pictureBox4
                        // 
                        this.pictureBox4.BackColor = System.Drawing.Color.Silver;
                        this.pictureBox4.Location = new System.Drawing.Point(12, 60);
                        this.pictureBox4.Name = "pictureBox4";
                        this.pictureBox4.Size = new System.Drawing.Size(20, 8);
                        this.pictureBox4.TabIndex = 10;
                        this.pictureBox4.TabStop = false;
                        // 
                        // lvAnual
                        // 
                        this.ListadoAnual.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.ListadoAnual.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvAnualMes,
            this.lvAnualMonto});
                        this.ListadoAnual.FullRowSelect = true;
                        this.ListadoAnual.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.ListadoAnual.LabelWrap = false;
                        this.ListadoAnual.Location = new System.Drawing.Point(584, 8);
                        this.ListadoAnual.MultiSelect = false;
                        this.ListadoAnual.Name = "lvAnual";
                        this.ListadoAnual.Scrollable = false;
                        this.ListadoAnual.Size = new System.Drawing.Size(176, 336);
                        this.ListadoAnual.TabIndex = 16;
                        this.ListadoAnual.UseCompatibleStateImageBehavior = false;
                        this.ListadoAnual.View = System.Windows.Forms.View.Details;
                        // 
                        // lvAnualMes
                        // 
                        this.lvAnualMes.Text = "";
                        this.lvAnualMes.Width = 96;
                        // 
                        // lvAnualMonto
                        // 
                        this.lvAnualMonto.Text = "Monto";
                        this.lvAnualMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.lvAnualMonto.Width = 64;
                        // 
                        // label7
                        // 
                        this.label7.Location = new System.Drawing.Point(40, 380);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(108, 16);
                        this.label7.TabIndex = 22;
                        this.label7.Text = "Mes pasado";
                        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // pictureBox7
                        // 
                        this.pictureBox7.BackColor = System.Drawing.Color.DarkGray;
                        this.pictureBox7.Location = new System.Drawing.Point(12, 384);
                        this.pictureBox7.Name = "pictureBox7";
                        this.pictureBox7.Size = new System.Drawing.Size(20, 8);
                        this.pictureBox7.TabIndex = 21;
                        this.pictureBox7.TabStop = false;
                        // 
                        // label8
                        // 
                        this.label8.Location = new System.Drawing.Point(40, 360);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(108, 16);
                        this.label8.TabIndex = 20;
                        this.label8.Text = "Este mes";
                        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // pictureBox8
                        // 
                        this.pictureBox8.BackColor = System.Drawing.Color.Green;
                        this.pictureBox8.Location = new System.Drawing.Point(12, 364);
                        this.pictureBox8.Name = "pictureBox8";
                        this.pictureBox8.Size = new System.Drawing.Size(20, 8);
                        this.pictureBox8.TabIndex = 19;
                        this.pictureBox8.TabStop = false;
                        // 
                        // ChartMes
                        // 
                        this.ChartMes.BackColor = System.Drawing.Color.White;
                        this.ChartMes.Location = new System.Drawing.Point(156, 352);
                        this.ChartMes.Name = "ChartMes";
                        this.ChartMes.Size = new System.Drawing.Size(604, 124);
                        this.ChartMes.TabIndex = 18;
                        this.ChartMes.Title = "Comparativa por Día del Mes";
                        this.ChartMes.VerticalGrid = true;
                        // 
                        // BotonPorDiaDelMes
                        // 
                        this.BotonPorDiaDelMes.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonPorDiaDelMes.Image = null;
                        this.BotonPorDiaDelMes.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonPorDiaDelMes.Location = new System.Drawing.Point(48, 480);
                        this.BotonPorDiaDelMes.Name = "BotonPorDiaDelMes";
                        this.BotonPorDiaDelMes.Size = new System.Drawing.Size(100, 40);
                        this.BotonPorDiaDelMes.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.BotonPorDiaDelMes.Subtext = "";
                        this.BotonPorDiaDelMes.TabIndex = 17;
                        this.BotonPorDiaDelMes.Text = "Mostrar";
                        this.BotonPorDiaDelMes.Click += new System.EventHandler(this.BotonPorDiaDelMes_Click);
                        // 
                        // label9
                        // 
                        this.label9.Location = new System.Drawing.Point(40, 400);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(108, 16);
                        this.label9.TabIndex = 24;
                        this.label9.Text = "Mes ante pasado";
                        this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // pictureBox9
                        // 
                        this.pictureBox9.BackColor = System.Drawing.Color.DarkGray;
                        this.pictureBox9.Location = new System.Drawing.Point(12, 404);
                        this.pictureBox9.Name = "pictureBox9";
                        this.pictureBox9.Size = new System.Drawing.Size(20, 8);
                        this.pictureBox9.TabIndex = 23;
                        this.pictureBox9.TabStop = false;
                        // 
                        // label5
                        // 
                        this.label5.Location = new System.Drawing.Point(36, 228);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(108, 16);
                        this.label5.TabIndex = 30;
                        this.label5.Text = "Gastos";
                        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // pictureBox5
                        // 
                        this.pictureBox5.BackColor = System.Drawing.Color.Red;
                        this.pictureBox5.Location = new System.Drawing.Point(8, 232);
                        this.pictureBox5.Name = "pictureBox5";
                        this.pictureBox5.Size = new System.Drawing.Size(20, 8);
                        this.pictureBox5.TabIndex = 29;
                        this.pictureBox5.TabStop = false;
                        // 
                        // label6
                        // 
                        this.label6.Location = new System.Drawing.Point(36, 208);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(108, 16);
                        this.label6.TabIndex = 28;
                        this.label6.Text = "Facturación";
                        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // pictureBox6
                        // 
                        this.pictureBox6.BackColor = System.Drawing.Color.Goldenrod;
                        this.pictureBox6.Location = new System.Drawing.Point(8, 212);
                        this.pictureBox6.Name = "pictureBox6";
                        this.pictureBox6.Size = new System.Drawing.Size(20, 8);
                        this.pictureBox6.TabIndex = 27;
                        this.pictureBox6.TabStop = false;
                        // 
                        // label10
                        // 
                        this.label10.Location = new System.Drawing.Point(36, 188);
                        this.label10.Name = "label10";
                        this.label10.Size = new System.Drawing.Size(108, 16);
                        this.label10.TabIndex = 26;
                        this.label10.Text = "Rentabilidad";
                        this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // pictureBox10
                        // 
                        this.pictureBox10.BackColor = System.Drawing.Color.Green;
                        this.pictureBox10.Location = new System.Drawing.Point(8, 192);
                        this.pictureBox10.Name = "pictureBox10";
                        this.pictureBox10.Size = new System.Drawing.Size(20, 8);
                        this.pictureBox10.TabIndex = 25;
                        this.pictureBox10.TabStop = false;
                        // 
                        // Facturacion
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(768, 480);
                        this.Controls.Add(this.label5);
                        this.Controls.Add(this.pictureBox5);
                        this.Controls.Add(this.label6);
                        this.Controls.Add(this.pictureBox6);
                        this.Controls.Add(this.label10);
                        this.Controls.Add(this.pictureBox10);
                        this.Controls.Add(this.label9);
                        this.Controls.Add(this.pictureBox9);
                        this.Controls.Add(this.label7);
                        this.Controls.Add(this.pictureBox7);
                        this.Controls.Add(this.label8);
                        this.Controls.Add(this.pictureBox8);
                        this.Controls.Add(this.ChartMes);
                        this.Controls.Add(this.BotonPorDiaDelMes);
                        this.Controls.Add(this.ListadoAnual);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.pictureBox4);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.pictureBox3);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.pictureBox2);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.pictureBox1);
                        this.Controls.Add(this.ChartRent);
                        this.Controls.Add(this.PorRentabilidad);
                        this.Controls.Add(this.PorMes);
                        this.Controls.Add(this.Chart);
                        this.Name = "Facturacion";
                        this.Text = "Facturación";
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
                        this.ResumeLayout(false);

                }
                #endregion

                public void RentabilidadAnual(int anio, Lui.Forms.Chart Chrt)
                {
                        if (Chrt.Series == null)
                                Chrt.Series = new System.Collections.Generic.List<Lbl.Charts.Serie>();

                        Lbl.Charts.Element[] ElFacturacion = new Lbl.Charts.Element[12];
                        Lbl.Charts.Element[] ElCosto = new Lbl.Charts.Element[12];
                        Lbl.Charts.Element[] ElGastos = new Lbl.Charts.Element[12];
                        Lbl.Charts.Element[] ElRentabilidad = new Lbl.Charts.Element[12];

                        for (int mes = 1; mes <= 12; mes++) {

                                if (anio > DateTime.Now.Year || (anio == DateTime.Now.Year && mes > DateTime.Now.Month)) {
                                        //Nada ?
                                } else {
                                        ElFacturacion[mes - 1] = new Lbl.Charts.Element();
                                        ElCosto[mes - 1] = new Lbl.Charts.Element();
                                        ElGastos[mes - 1] = new Lbl.Charts.Element();
                                        ElRentabilidad[mes - 1] = new Lbl.Charts.Element();

                                        string Fecha1Sql = anio.ToString("0000") + "-" + mes.ToString("00") + "-01";
                                        string Fecha2Sql = anio.ToString("0000") + "-" + mes.ToString("00") + "-31";

                                        decimal Facturas = this.Connection.FieldDecimal("SELECT SUM(total) FROM comprob WHERE tipo_fac IN ('FA', 'FB', 'FC', 'FE', 'FM', 'NDA', 'NDB', 'NDC', 'NDE', 'NDM') AND impresa>0 AND compra=0 AND anulada=0 AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                                        decimal NotasCredito = this.Connection.FieldDecimal("SELECT SUM(total) FROM comprob WHERE tipo_fac IN ('NCA', 'NCB', 'NCC', 'NCE', 'NCM') AND impresa>0 AND compra=0 AND anulada=0 AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                                        decimal Costo = this.Connection.FieldDecimal("SELECT SUM(costo*cantidad) FROM comprob, comprob_detalle WHERE comprob.id_comprob=comprob_detalle.id_comprob AND comprob.tipo_fac IN ('FA', 'FB', 'FC', 'FE', 'FM', 'NDA', 'NDB', 'NDC', 'NDE', 'NDM') AND comprob.compra=0 AND comprob.numero>0 AND comprob.anulada=0 AND comprob_detalle.precio>0 AND comprob.fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                                        decimal CostoNotasCredito = this.Connection.FieldDecimal("SELECT SUM(costo*cantidad) FROM comprob, comprob_detalle WHERE comprob.id_comprob=comprob_detalle.id_comprob AND comprob.tipo_fac IN ('NCA', 'NCB', 'NCC', 'NCE', 'NCM') AND comprob.impresa>0 AND comprob.compra=0 AND comprob.anulada=0 AND comprob.fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                                        //decimal CostoCapital = this.Connection.FieldDecimal("SELECT SUM(importe) FROM cajas_movim WHERE id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo=220) AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                                        decimal GastosFijos = this.Connection.FieldDecimal("SELECT SUM(importe) FROM cajas_movim WHERE id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo=230) AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                                        decimal GastosVariables = this.Connection.FieldDecimal("SELECT SUM(importe) FROM cajas_movim WHERE id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo=240) AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                                        decimal OtrosEgresos = this.Connection.FieldDecimal("SELECT SUM(importe) FROM cajas_movim WHERE importe<0 AND id_concepto IN (SELECT id_concepto FROM conceptos WHERE grupo NOT IN (110, 210, 220, 230, 240, 300)) AND id_concepto<>26030 AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");

                                        ElFacturacion[mes - 1].Value = Facturas - NotasCredito;
                                        ElCosto[mes - 1].Value = Costo - CostoNotasCredito;
                                        ElGastos[mes - 1].Value = Math.Abs(GastosFijos + GastosVariables + OtrosEgresos);
                                        ElRentabilidad[mes - 1].Value = ElFacturacion[mes - 1].Value - ElCosto[mes - 1].Value - ElGastos[mes - 1].Value;
                                }

                        }
                        Lbl.Charts.Serie Serie1 = new Lbl.Charts.Serie("Facturación");
                        Lbl.Charts.Serie Serie2 = new Lbl.Charts.Serie("Gastos");
                        Lbl.Charts.Serie Serie3 = new Lbl.Charts.Serie("Rentabilidad");

                        Serie1.Elements = ElFacturacion;
                        Serie2.Elements = ElGastos;
                        Serie3.Elements = ElRentabilidad;

                        if (anio == DateTime.Now.Year) {
                                Serie1.Color = System.Drawing.Color.Goldenrod;
                                Serie2.Color = System.Drawing.Color.Red;
                                Serie3.Color = System.Drawing.Color.Green;
                        } else {
                                Serie1.Color = System.Drawing.Color.LightGoldenrodYellow;
                                Serie2.Color = System.Drawing.Color.Pink;
                                Serie3.Color = System.Drawing.Color.LightGreen;
                        }

                        Chrt.Series.Add(Serie1);
                        Chrt.Series.Add(Serie2);
                        Chrt.Series.Add(Serie3);
                }

                private Lbl.Charts.Element[] FacturacionAnual(int anio, bool costo, int sucursal)
                {
                        Lbl.Charts.Element[] Elements = new Lbl.Charts.Element[12];

                        for (int mes = 1; mes <= 12; mes++) {
                                if (mes == System.DateTime.Now.Month && anio == System.DateTime.Now.Year) {
                                        Elements[mes - 1] = null;
                                } else {
                                        string Fecha1Sql = anio.ToString("0000") + "-" + mes.ToString("00") + "-01";
                                        string Fecha2Sql = anio.ToString("0000") + "-" + mes.ToString("00") + "-31";

                                        decimal ValoresSuma = 0, ValoresResta = 0;

                                        string WhereSuc = "";
                                        if (sucursal > 0)
                                                WhereSuc = " id_sucursal=" + sucursal.ToString() + " AND ";

                                        if (costo == false) {
                                                //Tomo la facturación
                                                ValoresSuma = this.Connection.FieldDecimal("SELECT SUM(total) FROM comprob WHERE " + WhereSuc + " tipo_fac IN ('FA', 'FB', 'FC', 'FE', 'FM', 'NDA', 'NDB', 'NDC', 'NDE', 'NDM') AND impresa>0 AND compra=0 AND anulada=0 AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                                                ValoresResta = this.Connection.FieldDecimal("SELECT SUM(total) FROM comprob WHERE " + WhereSuc + " tipo_fac IN ('NCA', 'NCB', 'NCC', 'NCE', 'NCM') AND impresa>0 AND compra=0 AND anulada=0 AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                                        } else {
                                                //Tomo el costo de la facturación
                                                ValoresSuma = this.Connection.FieldDecimal("SELECT SUM(costo*cantidad) FROM comprob, comprob_detalle WHERE " + WhereSuc + " comprob.id_comprob=comprob_detalle.id_comprob AND comprob.tipo_fac IN ('FA', 'FB', 'FC', 'FE', 'FM', 'NDA', 'NDB', 'NDC', 'NDE', 'NDM') AND comprob.impresa>0 AND comprob.compra=0 AND comprob.anulada=0 AND comprob_detalle.precio>0 AND comprob.fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                                                ValoresResta = this.Connection.FieldDecimal("SELECT SUM(costo*cantidad) FROM comprob, comprob_detalle WHERE " + WhereSuc + " comprob.id_comprob=comprob_detalle.id_comprob AND comprob.tipo_fac IN ('NCA', 'NCB', 'NCC', 'NCE', 'NCM') AND comprob.impresa>0 AND comprob.compra=0 AND comprob.anulada=0 AND comprob.fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                                        }

                                        if (ValoresSuma != 0) {
                                                Elements[mes - 1] = new Lbl.Charts.Element();
                                                Elements[mes - 1].Value = ValoresSuma - ValoresResta;
                                        } else {
                                                Elements[mes - 1] = null;
                                        }
                                }
                        }
                        return Elements;
                }


                private Lbl.Charts.Element[] FacturacionMensual(int anio, int mes, int sucursal)
                {
                        Lbl.Charts.Element[] Elements = new Lbl.Charts.Element[31];

                        for (int dia = 1; dia <= 31; dia++) {
                                if (mes == System.DateTime.Now.Month && anio == System.DateTime.Now.Year && dia == System.DateTime.Now.Day) {
                                        Elements[dia - 1] = null;
                                } else {
                                        int anio1 = anio, anio2 = anio;
                                        if (anio == 0) {
                                                anio1 = 1900;
                                                anio2 = 2099;
                                        }
                                        int mes1 = mes, mes2 = mes;
                                        if (mes == 0) {
                                                mes1 = 1900;
                                                mes2 = 2099;
                                        }

                                        string Fecha1Sql = anio1.ToString("0000") + "-" + mes1.ToString("00") + "-" + dia.ToString("00") + " 00:00:00";
                                        string Fecha2Sql = anio2.ToString("0000") + "-" + mes2.ToString("00") + "-" + dia.ToString("00") + " 23:59:59";

                                        decimal ValoresSuma = 0, ValoresResta = 0;

                                        string WhereSuc = "";
                                        if (sucursal > 0)
                                                WhereSuc = " id_sucursal=" + sucursal.ToString() + " AND ";

                                        //Tomo la facturación
                                        ValoresSuma = this.Connection.FieldDecimal("SELECT SUM(total) FROM comprob WHERE " + WhereSuc + " tipo_fac IN ('FA', 'FB', 'FC', 'FE', 'FM', 'NDA', 'NDB', 'NDC', 'NDE', 'NDM') AND impresa>0 AND compra=0 AND anulada=0 AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");
                                        ValoresResta = this.Connection.FieldDecimal("SELECT SUM(total) FROM comprob WHERE " + WhereSuc + " tipo_fac IN ('NCA', 'NCB', 'NCC', 'NCE', 'NCM') AND impresa>0 AND compra=0 AND anulada=0 AND fecha BETWEEN '" + Fecha1Sql + "' AND '" + Fecha2Sql + "'");

                                        if (ValoresSuma != 0) {
                                                Elements[dia - 1] = new Lbl.Charts.Element();
                                                Elements[dia - 1].Value = ValoresSuma - ValoresResta;
                                        } else {
                                                Elements[dia - 1] = null;
                                        }
                                }
                        }
                        return Elements;
                }



                private void PorMes_Click(object sender, System.EventArgs e)
                {
                        Chart.Title = "Facturación Por Mes";
                        Chart.GraphicType = Lui.Forms.Chart.GraphicTypes.Lines;

                        Chart.Series = new System.Collections.Generic.List<Lbl.Charts.Serie>();
                        Chart.Series.Add(new Lbl.Charts.Serie(""));
                        Chart.Series.Add(new Lbl.Charts.Serie(""));
                        Chart.Series.Add(new Lbl.Charts.Serie(""));
                        Chart.Series.Add(new Lbl.Charts.Serie(""));

                        Chart.Series[0] = new Lbl.Charts.Serie("");
                        Chart.Series[0].Color = System.Drawing.Color.Gainsboro;
                        Chart.Series[0].Elements = FacturacionAnual(System.DateTime.Now.Year - 2, false, 0);
                        Chart.Redraw();

                        Chart.Series[1] = new Lbl.Charts.Serie("");
                        Chart.Series[1].Color = System.Drawing.Color.Silver;
                        Chart.Series[1].Elements = FacturacionAnual(System.DateTime.Now.Year - 1, false, 0);
                        Chart.Redraw();

                        Chart.Series[2] = new Lbl.Charts.Serie("");
                        Chart.Series[2].Color = System.Drawing.Color.DarkGreen;
                        Chart.Series[2].Elements = FacturacionAnual(System.DateTime.Now.Year, true, 0);
                        Chart.Redraw();

                        Chart.Series[3] = new Lbl.Charts.Serie("");
                        Chart.Series[3].Color = System.Drawing.Color.Green;
                        Chart.Series[3].Elements = FacturacionAnual(System.DateTime.Now.Year, false, 0);

                        ListadoAnual.Items.Clear();
                        lvAnualMonto.Text = System.DateTime.Now.Year.ToString();
                        for (int mes = 1; mes <= 12; mes++) {
                                ListViewItem Item = ListadoAnual.Items.Add(new System.DateTime(System.DateTime.Now.Year, mes, 1).ToString("MMMM"));
                                if (Chart.Series[3].Elements[mes - 1] != null) {
                                        Item.SubItems.Add(Lfx.Types.Formatting.FormatCurrencyForPrint(Chart.Series[3].Elements[mes - 1].Value, 0));
                                }
                        }

                        Chart.Redraw();
                }

                private void PorRentabilidad_Click(object sender, System.EventArgs e)
                {
                        ChartRent.Title = "Rentabilidad Por Mes";
                        ChartRent.GraphicType = Lui.Forms.Chart.GraphicTypes.Lines;

                        RentabilidadAnual(System.DateTime.Now.Year - 1, ChartRent);
                        RentabilidadAnual(System.DateTime.Now.Year, ChartRent);

                        ChartRent.Redraw();
                }

                private void BotonPorDiaDelMes_Click(object sender, System.EventArgs e)
                {
                        ChartMes.Title = "Facturación Por Día del Mes";
                        ChartMes.GraphicType = Lui.Forms.Chart.GraphicTypes.Lines;

                        ChartMes.Series = new System.Collections.Generic.List<Lbl.Charts.Serie>();
                        ChartMes.Series.Add(new Lbl.Charts.Serie(""));
                        ChartMes.Series.Add(new Lbl.Charts.Serie(""));
                        ChartMes.Series.Add(new Lbl.Charts.Serie(""));

                        ChartMes.Series[0] = new Lbl.Charts.Serie("");
                        ChartMes.Series[0].Color = System.Drawing.Color.Gainsboro;
                        ChartMes.Series[0].Elements = FacturacionMensual(System.DateTime.Now.AddMonths(-2).Year, System.DateTime.Now.AddMonths(-2).Month, 1);
                        ChartMes.Redraw();

                        ChartMes.Series[1] = new Lbl.Charts.Serie("");
                        ChartMes.Series[1].Color = System.Drawing.Color.Silver;
                        ChartMes.Series[1].Elements = FacturacionMensual(System.DateTime.Now.AddMonths(-1).Year, System.DateTime.Now.AddMonths(-1).Month, 1);

                        ChartMes.Series[2] = new Lbl.Charts.Serie("");
                        ChartMes.Series[2].Color = System.Drawing.Color.Green;
                        ChartMes.Series[2].Elements = FacturacionMensual(0, 0, 1);

                        ChartMes.Redraw();
                }
        }
}
