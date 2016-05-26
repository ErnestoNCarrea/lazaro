using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Comprobantes.Impresoras
{
        public partial class Editar
        {
                internal Lui.Forms.TextBox EntradaNombre;
                internal Lui.Forms.Label Label5;
                private System.ComponentModel.IContainer components = null;

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

                private void InitializeComponent()
                {
                        this.EntradaNombre = new Lui.Forms.TextBox();
                        this.Label5 = new Lui.Forms.Label();
                        this.EntradaUbicacion = new Lui.Forms.TextBox();
                        this.label10 = new Lui.Forms.Label();
                        this.EntradaTalonario = new Lui.Forms.ComboBox();
                        this.label9 = new Lui.Forms.Label();
                        this.EntradaFiscalBps = new Lui.Forms.ComboBox();
                        this.label2 = new Lui.Forms.Label();
                        this.EntradaFiscalPuerto = new Lui.Forms.ComboBox();
                        this.EntradaFiscalModelo = new Lui.Forms.ComboBox();
                        this.label7 = new Lui.Forms.Label();
                        this.label6 = new Lui.Forms.Label();
                        this.label1 = new Lui.Forms.Label();
                        this.EntradaTipo = new Lui.Forms.ComboBox();
                        this.Label16 = new Lui.Forms.Label();
                        this.EntradaCarga = new Lui.Forms.ComboBox();
                        this.label3 = new Lui.Forms.Label();
                        this.EntradaEstacion = new Lui.Forms.TextBox();
                        this.BotonSeleccionarEstacion = new Lui.Forms.Button();
                        this.EntradaDispositivo = new Lui.Forms.TextBox();
                        this.label4 = new Lui.Forms.Label();
                        this.BotonSeleccionarDispositivo = new Lui.Forms.Button();
                        this.SuspendLayout();
                        // 
                        // EntradaNombre
                        // 
                        this.EntradaNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaNombre.Location = new System.Drawing.Point(120, 0);
                        this.EntradaNombre.Name = "EntradaNombre";
                        this.EntradaNombre.Size = new System.Drawing.Size(519, 24);
                        this.EntradaNombre.TabIndex = 1;
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(0, 0);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(120, 24);
                        this.Label5.TabIndex = 0;
                        this.Label5.Text = "Nombre";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaUbicacion
                        // 
                        this.EntradaUbicacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaUbicacion.Location = new System.Drawing.Point(120, 160);
                        this.EntradaUbicacion.Name = "EntradaUbicacion";
                        this.EntradaUbicacion.Size = new System.Drawing.Size(519, 24);
                        this.EntradaUbicacion.TabIndex = 10;
                        // 
                        // label10
                        // 
                        this.label10.Location = new System.Drawing.Point(0, 160);
                        this.label10.Name = "label10";
                        this.label10.Size = new System.Drawing.Size(120, 24);
                        this.label10.TabIndex = 9;
                        this.label10.Text = "Ubicación";
                        this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaTalonario
                        // 
                        this.EntradaTalonario.AlwaysExpanded = true;
                        this.EntradaTalonario.AutoSize = true;
                        this.EntradaTalonario.Location = new System.Drawing.Point(244, 196);
                        this.EntradaTalonario.Name = "EntradaTalonario";
                        this.EntradaTalonario.SetData = new string[] {
        "Sí|1",
        "No|0"};
                        this.EntradaTalonario.Size = new System.Drawing.Size(116, 40);
                        this.EntradaTalonario.TabIndex = 12;
                        this.EntradaTalonario.TextKey = "0";
                        // 
                        // label9
                        // 
                        this.label9.Location = new System.Drawing.Point(120, 196);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(124, 24);
                        this.label9.TabIndex = 11;
                        this.label9.Text = "Usa Talonarios";
                        this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFiscalBps
                        // 
                        this.EntradaFiscalBps.AlwaysExpanded = true;
                        this.EntradaFiscalBps.AutoSize = true;
                        this.EntradaFiscalBps.Enabled = false;
                        this.EntradaFiscalBps.Location = new System.Drawing.Point(244, 412);
                        this.EntradaFiscalBps.Name = "EntradaFiscalBps";
                        this.EntradaFiscalBps.SetData = new string[] {
        "9600 bps|9600",
        "19200 bps|19200"};
                        this.EntradaFiscalBps.Size = new System.Drawing.Size(136, 40);
                        this.EntradaFiscalBps.TabIndex = 20;
                        this.EntradaFiscalBps.TextKey = "9600";
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(120, 240);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(124, 24);
                        this.label2.TabIndex = 13;
                        this.label2.Text = "Carga de Papel";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFiscalPuerto
                        // 
                        this.EntradaFiscalPuerto.AlwaysExpanded = true;
                        this.EntradaFiscalPuerto.AutoSize = true;
                        this.EntradaFiscalPuerto.Enabled = false;
                        this.EntradaFiscalPuerto.Location = new System.Drawing.Point(244, 364);
                        this.EntradaFiscalPuerto.Name = "EntradaFiscalPuerto";
                        this.EntradaFiscalPuerto.SetData = new string[] {
        "COM1|1",
        "COM2|2"};
                        this.EntradaFiscalPuerto.Size = new System.Drawing.Size(136, 40);
                        this.EntradaFiscalPuerto.TabIndex = 18;
                        this.EntradaFiscalPuerto.TextKey = "1";
                        // 
                        // EntradaFiscalModelo
                        // 
                        this.EntradaFiscalModelo.AlwaysExpanded = true;
                        this.EntradaFiscalModelo.AutoSize = true;
                        this.EntradaFiscalModelo.Enabled = false;
                        this.EntradaFiscalModelo.Location = new System.Drawing.Point(244, 284);
                        this.EntradaFiscalModelo.Name = "EntradaFiscalModelo";
                        this.EntradaFiscalModelo.SetData = new string[] {
        "Hasar|100",
        "Hasar Tiqueadora|110",
        "Epson|300",
        "Emulación|1"};
                        this.EntradaFiscalModelo.Size = new System.Drawing.Size(136, 74);
                        this.EntradaFiscalModelo.TabIndex = 16;
                        this.EntradaFiscalModelo.TextKey = "300";
                        // 
                        // label7
                        // 
                        this.label7.Location = new System.Drawing.Point(120, 412);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(124, 24);
                        this.label7.TabIndex = 19;
                        this.label7.Text = "Velocidad";
                        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label6
                        // 
                        this.label6.Location = new System.Drawing.Point(120, 364);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(124, 24);
                        this.label6.TabIndex = 17;
                        this.label6.Text = "Puerto";
                        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(120, 288);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(124, 24);
                        this.label1.TabIndex = 15;
                        this.label1.Text = "Modelo";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaTipo
                        // 
                        this.EntradaTipo.AlwaysExpanded = true;
                        this.EntradaTipo.AutoSize = true;
                        this.EntradaTipo.Location = new System.Drawing.Point(120, 32);
                        this.EntradaTipo.Name = "EntradaTipo";
                        this.EntradaTipo.SetData = new string[] {
                                "Nula|0",
                                "Impresora de común|1",
                                "Controlador fiscal AFIP|2"
                        };
                        this.EntradaTipo.Size = new System.Drawing.Size(208, 57);
                        this.EntradaTipo.TabIndex = 2;
                        this.EntradaTipo.TextKey = "1";
                        this.EntradaTipo.TextChanged += new System.EventHandler(this.EntradaTipo_TextChanged);
                        // 
                        // Label16
                        // 
                        this.Label16.Location = new System.Drawing.Point(0, 32);
                        this.Label16.Name = "Label16";
                        this.Label16.Size = new System.Drawing.Size(120, 24);
                        this.Label16.TabIndex = 1;
                        this.Label16.Text = "Tipo";
                        this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCarga
                        // 
                        this.EntradaCarga.AlwaysExpanded = true;
                        this.EntradaCarga.AutoSize = true;
                        this.EntradaCarga.Location = new System.Drawing.Point(244, 240);
                        this.EntradaCarga.Name = "EntradaCarga";
                        this.EntradaCarga.SetData = new string[] {
        "Automática|0",
        "Manual|1"};
                        this.EntradaCarga.Size = new System.Drawing.Size(208, 40);
                        this.EntradaCarga.TabIndex = 14;
                        this.EntradaCarga.TextKey = "0";
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(0, 96);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(120, 24);
                        this.label3.TabIndex = 3;
                        this.label3.Text = "Equipo";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaEstacion
                        // 
                        this.EntradaEstacion.ForceCase = Lui.Forms.TextCasing.UpperCase;
                        this.EntradaEstacion.Location = new System.Drawing.Point(120, 96);
                        this.EntradaEstacion.Name = "EntradaEstacion";
                        this.EntradaEstacion.Size = new System.Drawing.Size(336, 24);
                        this.EntradaEstacion.TabIndex = 4;
                        this.EntradaEstacion.TextChanged += new System.EventHandler(this.EntradaEstacion_TextChanged);
                        // 
                        // BotonSeleccionarEstacion
                        // 
                        this.BotonSeleccionarEstacion.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonSeleccionarEstacion.Image = null;
                        this.BotonSeleccionarEstacion.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonSeleccionarEstacion.Location = new System.Drawing.Point(464, 96);
                        this.BotonSeleccionarEstacion.Name = "BotonSeleccionarEstacion";
                        this.BotonSeleccionarEstacion.Size = new System.Drawing.Size(28, 24);
                        this.BotonSeleccionarEstacion.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonSeleccionarEstacion.Subtext = "";
                        this.BotonSeleccionarEstacion.TabIndex = 5;
                        this.BotonSeleccionarEstacion.Text = "...";
                        this.BotonSeleccionarEstacion.Click += new System.EventHandler(this.BotonSeleccionarEstacion_Click);
                        // 
                        // EntradaDispositivo
                        // 
                        this.EntradaDispositivo.Location = new System.Drawing.Point(120, 128);
                        this.EntradaDispositivo.Name = "EntradaDispositivo";
                        this.EntradaDispositivo.Size = new System.Drawing.Size(336, 24);
                        this.EntradaDispositivo.TabIndex = 7;
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(0, 128);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(120, 24);
                        this.label4.TabIndex = 6;
                        this.label4.Text = "Dispositivo";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // BotonSeleccionarDispositivo
                        // 
                        this.BotonSeleccionarDispositivo.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonSeleccionarDispositivo.Image = null;
                        this.BotonSeleccionarDispositivo.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonSeleccionarDispositivo.Location = new System.Drawing.Point(464, 128);
                        this.BotonSeleccionarDispositivo.Name = "BotonSeleccionarDispositivo";
                        this.BotonSeleccionarDispositivo.Size = new System.Drawing.Size(28, 24);
                        this.BotonSeleccionarDispositivo.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonSeleccionarDispositivo.Subtext = "";
                        this.BotonSeleccionarDispositivo.TabIndex = 8;
                        this.BotonSeleccionarDispositivo.Text = "...";
                        this.BotonSeleccionarDispositivo.Click += new System.EventHandler(this.BotonSeleccionarDispositivo_Click);
                        // 
                        // Editar
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                        this.AutoSize = true;
                        this.Controls.Add(this.BotonSeleccionarDispositivo);
                        this.Controls.Add(this.EntradaDispositivo);
                        this.Controls.Add(this.BotonSeleccionarEstacion);
                        this.Controls.Add(this.EntradaTalonario);
                        this.Controls.Add(this.label9);
                        this.Controls.Add(this.EntradaFiscalBps);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.EntradaFiscalPuerto);
                        this.Controls.Add(this.EntradaFiscalModelo);
                        this.Controls.Add(this.label7);
                        this.Controls.Add(this.label6);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.EntradaTipo);
                        this.Controls.Add(this.Label16);
                        this.Controls.Add(this.EntradaCarga);
                        this.Controls.Add(this.EntradaEstacion);
                        this.Controls.Add(this.EntradaUbicacion);
                        this.Controls.Add(this.EntradaNombre);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.label10);
                        this.Controls.Add(this.Label5);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(640, 482);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }
                #endregion

                internal Lui.Forms.TextBox EntradaUbicacion;
                internal Lui.Forms.Label label10;
                internal Lui.Forms.ComboBox EntradaTalonario;
                internal Lui.Forms.Label label9;
                internal Lui.Forms.ComboBox EntradaFiscalBps;
                internal Lui.Forms.Label label2;
                internal Lui.Forms.ComboBox EntradaFiscalPuerto;
                internal Lui.Forms.ComboBox EntradaFiscalModelo;
                internal Lui.Forms.Label label7;
                internal Lui.Forms.Label label6;
                internal Lui.Forms.Label label1;
                internal Lui.Forms.ComboBox EntradaTipo;
                internal Lui.Forms.Label Label16;
                internal Lui.Forms.ComboBox EntradaCarga;
                internal Lui.Forms.Label label3;
                internal Lui.Forms.TextBox EntradaEstacion;
                internal Lui.Forms.Button BotonSeleccionarEstacion;
                internal Lui.Forms.TextBox EntradaDispositivo;
                internal Lui.Forms.Label label4;
                internal Lui.Forms.Button BotonSeleccionarDispositivo;
        }
}
