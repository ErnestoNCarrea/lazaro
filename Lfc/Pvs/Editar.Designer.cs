using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Pvs
{
        public partial class Editar
        {
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

                #region Designer generated code

                private void InitializeComponent()
                {
                        this.EntradaTipo = new Lui.Forms.ComboBox();
                        this.Label16 = new Lui.Forms.Label();
                        this.label1 = new Lui.Forms.Label();
                        this.EntradaEstacion = new Lui.Forms.TextBox();
                        this.EntradaCarga = new Lui.Forms.ComboBox();
                        this.label2 = new Lui.Forms.Label();
                        this.BotonEstacionSeleccionar = new Lui.Forms.Button();
                        this.EntradaSucursal = new Lcc.Entrada.CodigoDetalle();
                        this.label4 = new Lui.Forms.Label();
                        this.label5 = new Lui.Forms.Label();
                        this.label6 = new Lui.Forms.Label();
                        this.label7 = new Lui.Forms.Label();
                        this.EntradaModelo = new Lui.Forms.ComboBox();
                        this.EntradaPuerto = new Lui.Forms.ComboBox();
                        this.EntradaBps = new Lui.Forms.ComboBox();
                        this.EntradaTipoFac = new Lui.Forms.ComboBox();
                        this.label8 = new Lui.Forms.Label();
                        this.label9 = new Lui.Forms.Label();
                        this.label3 = new Lui.Forms.Label();
                        this.EntradaNumero = new Lui.Forms.TextBox();
                        this.label11 = new Lui.Forms.Label();
                        this.EntradaImpresora = new Lcc.Entrada.CodigoDetalle();
                        this.label10 = new Lui.Forms.Label();
                        this.EntradaPrefijo = new Lui.Forms.TextBox();
                        this.label12 = new Lui.Forms.Label();
                        this.EntradaDeTalonario = new Lui.Forms.YesNo();
                        this.PanelControladorFiscal = new Lui.Forms.Panel();
                        this.PanelTalonario = new Lui.Forms.Panel();
                        this.PanelElectronicaAfip = new Lui.Forms.Panel();
                        this.EntradaVariante = new Lui.Forms.ComboBox();
                        this.label13 = new Lui.Forms.Label();
                        this.PanelControladorFiscal.SuspendLayout();
                        this.PanelTalonario.SuspendLayout();
                        this.PanelElectronicaAfip.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // EntradaTipo
                        // 
                        this.EntradaTipo.AlwaysExpanded = true;
                        this.EntradaTipo.AutoSize = true;
                        this.EntradaTipo.Location = new System.Drawing.Point(144, 201);
                        this.EntradaTipo.Name = "EntradaTipo";
                        this.EntradaTipo.SetData = new string[] {
        "Inactivo|0",
        "Talonario / Papel|1",
        "Controlador fiscal AFIP|2",
        "Electrónico AFIP|10"};
                        this.EntradaTipo.Size = new System.Drawing.Size(208, 74);
                        this.EntradaTipo.TabIndex = 11;
                        this.EntradaTipo.TextKey = "1";
                        this.EntradaTipo.TextChanged += new System.EventHandler(this.EntradaTipo_TextChanged);
                        // 
                        // Label16
                        // 
                        this.Label16.Location = new System.Drawing.Point(0, 201);
                        this.Label16.Name = "Label16";
                        this.Label16.Size = new System.Drawing.Size(140, 24);
                        this.Label16.TabIndex = 10;
                        this.Label16.Text = "Tipo";
                        this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(0, 167);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(144, 24);
                        this.label1.TabIndex = 7;
                        this.label1.Text = "Equipo";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaEstacion
                        // 
                        this.EntradaEstacion.ForceCase = Lui.Forms.TextCasing.UpperCase;
                        this.EntradaEstacion.Location = new System.Drawing.Point(144, 167);
                        this.EntradaEstacion.Name = "EntradaEstacion";
                        this.EntradaEstacion.Size = new System.Drawing.Size(332, 24);
                        this.EntradaEstacion.TabIndex = 8;
                        // 
                        // EntradaCarga
                        // 
                        this.EntradaCarga.AlwaysExpanded = true;
                        this.EntradaCarga.AutoSize = true;
                        this.EntradaCarga.Location = new System.Drawing.Point(147, 32);
                        this.EntradaCarga.Name = "EntradaCarga";
                        this.EntradaCarga.SetData = new string[] {
        "Automática|0",
        "Manual|1"};
                        this.EntradaCarga.Size = new System.Drawing.Size(204, 40);
                        this.EntradaCarga.TabIndex = 1;
                        this.EntradaCarga.TextKey = "0";
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(3, 32);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(144, 24);
                        this.label2.TabIndex = 17;
                        this.label2.Text = "Carga de papel";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // BotonEstacionSeleccionar
                        // 
                        this.BotonEstacionSeleccionar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonEstacionSeleccionar.Image = null;
                        this.BotonEstacionSeleccionar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonEstacionSeleccionar.Location = new System.Drawing.Point(480, 167);
                        this.BotonEstacionSeleccionar.Name = "BotonEstacionSeleccionar";
                        this.BotonEstacionSeleccionar.Size = new System.Drawing.Size(28, 24);
                        this.BotonEstacionSeleccionar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonEstacionSeleccionar.Subtext = "";
                        this.BotonEstacionSeleccionar.TabIndex = 9;
                        this.BotonEstacionSeleccionar.Text = "...";
                        this.BotonEstacionSeleccionar.Click += new System.EventHandler(this.BotonEstacionSeleccionar_Click);
                        // 
                        // EntradaSucursal
                        // 
                        this.EntradaSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaSucursal.AutoTab = true;
                        this.EntradaSucursal.CanCreate = true;
                        this.EntradaSucursal.Location = new System.Drawing.Point(144, 32);
                        this.EntradaSucursal.MaximumSize = new System.Drawing.Size(480, 24);
                        this.EntradaSucursal.MaxLength = 200;
                        this.EntradaSucursal.Name = "EntradaSucursal";
                        this.EntradaSucursal.NombreTipo = "Lbl.Entidades.Sucursal";
                        this.EntradaSucursal.PlaceholderText = "Sucursal";
                        this.EntradaSucursal.Required = true;
                        this.EntradaSucursal.Size = new System.Drawing.Size(401, 24);
                        this.EntradaSucursal.TabIndex = 4;
                        this.EntradaSucursal.Text = "0";
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(0, 32);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(144, 24);
                        this.label4.TabIndex = 3;
                        this.label4.Text = "Sucursal";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label5
                        // 
                        this.label5.Location = new System.Drawing.Point(3, 0);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(144, 24);
                        this.label5.TabIndex = 19;
                        this.label5.Text = "Modelo";
                        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label6
                        // 
                        this.label6.Location = new System.Drawing.Point(3, 32);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(144, 24);
                        this.label6.TabIndex = 21;
                        this.label6.Text = "Puerto";
                        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label7
                        // 
                        this.label7.Location = new System.Drawing.Point(3, 64);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(144, 24);
                        this.label7.TabIndex = 23;
                        this.label7.Text = "Velocidad";
                        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaModelo
                        // 
                        this.EntradaModelo.AlwaysExpanded = false;
                        this.EntradaModelo.AutoSize = true;
                        this.EntradaModelo.Location = new System.Drawing.Point(147, 0);
                        this.EntradaModelo.Name = "EntradaModelo";
                        this.EntradaModelo.SetData = new string[] {
        "Hasar|100",
        "Hasar Tiqueadora|110",
        "Epson|300",
        "Epson Tiqueadora|310",
        "Emulación|1"};
                        this.EntradaModelo.Size = new System.Drawing.Size(170, 24);
                        this.EntradaModelo.TabIndex = 0;
                        this.EntradaModelo.TextKey = "300";
                        // 
                        // EntradaPuerto
                        // 
                        this.EntradaPuerto.AlwaysExpanded = false;
                        this.EntradaPuerto.AutoSize = true;
                        this.EntradaPuerto.Location = new System.Drawing.Point(147, 32);
                        this.EntradaPuerto.Name = "EntradaPuerto";
                        this.EntradaPuerto.SetData = new string[] {
        "COM1|1",
        "COM2|2",
        "COM3|3",
        "COM4|4",
        "COM5|5",
        "COM6|6",
        "COM7|7",
        "COM8|8"};
                        this.EntradaPuerto.Size = new System.Drawing.Size(132, 24);
                        this.EntradaPuerto.TabIndex = 1;
                        this.EntradaPuerto.TextKey = "1";
                        // 
                        // EntradaBps
                        // 
                        this.EntradaBps.AlwaysExpanded = false;
                        this.EntradaBps.AutoSize = true;
                        this.EntradaBps.Location = new System.Drawing.Point(147, 64);
                        this.EntradaBps.Name = "EntradaBps";
                        this.EntradaBps.SetData = new string[] {
        "9600 bps|9600",
        "19200 bps|19200"};
                        this.EntradaBps.Size = new System.Drawing.Size(132, 24);
                        this.EntradaBps.TabIndex = 2;
                        this.EntradaBps.TextKey = "9600";
                        // 
                        // EntradaTipoFac
                        // 
                        this.EntradaTipoFac.AlwaysExpanded = true;
                        this.EntradaTipoFac.AutoSize = true;
                        this.EntradaTipoFac.Location = new System.Drawing.Point(144, 66);
                        this.EntradaTipoFac.Name = "EntradaTipoFac";
                        this.EntradaTipoFac.SetData = new string[] {
        "Facturas|F",
        "Facturas y notas de débito|F,ND",
        "Facturas, notas de crédito y débito|F,NC,ND",
        "Remitos|R",
        "Recibos de cobro|RC"};
                        this.EntradaTipoFac.Size = new System.Drawing.Size(332, 91);
                        this.EntradaTipoFac.TabIndex = 6;
                        this.EntradaTipoFac.TextKey = "F,NC,ND";
                        // 
                        // label8
                        // 
                        this.label8.Location = new System.Drawing.Point(0, 66);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(144, 24);
                        this.label8.TabIndex = 5;
                        this.label8.Text = "Documentos";
                        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label9
                        // 
                        this.label9.Location = new System.Drawing.Point(0, 0);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(144, 24);
                        this.label9.TabIndex = 0;
                        this.label9.Text = "Punto de venta";
                        this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label3
                        // 
                        this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label3.Location = new System.Drawing.Point(3, 480);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(542, 43);
                        this.label3.TabIndex = 45;
                        this.label3.Text = "Si desea cambiar el punto de venta predeterminado para las facturas u otros docum" +
    "entos, utilice la opción Preferencias del menú Sistema.";
                        // 
                        // EntradaNumero
                        // 
                        this.EntradaNumero.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaNumero.Location = new System.Drawing.Point(144, 0);
                        this.EntradaNumero.MaxLength = 4;
                        this.EntradaNumero.Name = "EntradaNumero";
                        this.EntradaNumero.Size = new System.Drawing.Size(88, 24);
                        this.EntradaNumero.TabIndex = 2;
                        this.EntradaNumero.Text = "0";
                        // 
                        // label11
                        // 
                        this.label11.Location = new System.Drawing.Point(3, 0);
                        this.label11.Name = "label11";
                        this.label11.Size = new System.Drawing.Size(144, 24);
                        this.label11.TabIndex = 15;
                        this.label11.Text = "Usa talonarios";
                        this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaImpresora
                        // 
                        this.EntradaImpresora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaImpresora.AutoTab = true;
                        this.EntradaImpresora.CanCreate = true;
                        this.EntradaImpresora.Location = new System.Drawing.Point(147, 81);
                        this.EntradaImpresora.MaximumSize = new System.Drawing.Size(480, 24);
                        this.EntradaImpresora.MaxLength = 200;
                        this.EntradaImpresora.Name = "EntradaImpresora";
                        this.EntradaImpresora.NombreTipo = "Lbl.Impresion.Impresora";
                        this.EntradaImpresora.PlaceholderText = "Impresora";
                        this.EntradaImpresora.Required = true;
                        this.EntradaImpresora.Size = new System.Drawing.Size(373, 24);
                        this.EntradaImpresora.TabIndex = 2;
                        this.EntradaImpresora.Text = "0";
                        // 
                        // label10
                        // 
                        this.label10.Location = new System.Drawing.Point(3, 81);
                        this.label10.Name = "label10";
                        this.label10.Size = new System.Drawing.Size(144, 24);
                        this.label10.TabIndex = 6;
                        this.label10.Text = "Impresora predet.";
                        this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaPrefijo
                        // 
                        this.EntradaPrefijo.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaPrefijo.Location = new System.Drawing.Point(144, 0);
                        this.EntradaPrefijo.MaxLength = 4;
                        this.EntradaPrefijo.Name = "EntradaPrefijo";
                        this.EntradaPrefijo.Size = new System.Drawing.Size(68, 24);
                        this.EntradaPrefijo.TabIndex = 1;
                        this.EntradaPrefijo.Text = "0";
                        this.EntradaPrefijo.Visible = false;
                        // 
                        // label12
                        // 
                        this.label12.Location = new System.Drawing.Point(216, 0);
                        this.label12.Name = "label12";
                        this.label12.Size = new System.Drawing.Size(16, 24);
                        this.label12.TabIndex = 2;
                        this.label12.Text = "-";
                        this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label12.Visible = false;
                        // 
                        // EntradaDeTalonario
                        // 
                        this.EntradaDeTalonario.Location = new System.Drawing.Point(147, 0);
                        this.EntradaDeTalonario.Name = "EntradaDeTalonario";
                        this.EntradaDeTalonario.Size = new System.Drawing.Size(55, 24);
                        this.EntradaDeTalonario.TabIndex = 0;
                        this.EntradaDeTalonario.Text = "yesNo1";
                        this.EntradaDeTalonario.Value = true;
                        // 
                        // PanelControladorFiscal
                        // 
                        this.PanelControladorFiscal.Controls.Add(this.EntradaModelo);
                        this.PanelControladorFiscal.Controls.Add(this.EntradaPuerto);
                        this.PanelControladorFiscal.Controls.Add(this.EntradaBps);
                        this.PanelControladorFiscal.Controls.Add(this.label7);
                        this.PanelControladorFiscal.Controls.Add(this.label6);
                        this.PanelControladorFiscal.Controls.Add(this.label5);
                        this.PanelControladorFiscal.Location = new System.Drawing.Point(25, 289);
                        this.PanelControladorFiscal.Name = "PanelControladorFiscal";
                        this.PanelControladorFiscal.Size = new System.Drawing.Size(520, 120);
                        this.PanelControladorFiscal.TabIndex = 13;
                        // 
                        // PanelTalonario
                        // 
                        this.PanelTalonario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.PanelTalonario.Controls.Add(this.EntradaDeTalonario);
                        this.PanelTalonario.Controls.Add(this.label2);
                        this.PanelTalonario.Controls.Add(this.EntradaCarga);
                        this.PanelTalonario.Controls.Add(this.EntradaImpresora);
                        this.PanelTalonario.Controls.Add(this.label11);
                        this.PanelTalonario.Controls.Add(this.label10);
                        this.PanelTalonario.Location = new System.Drawing.Point(25, 289);
                        this.PanelTalonario.Name = "PanelTalonario";
                        this.PanelTalonario.Size = new System.Drawing.Size(520, 120);
                        this.PanelTalonario.TabIndex = 14;
                        // 
                        // PanelElectronicaAfip
                        // 
                        this.PanelElectronicaAfip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.PanelElectronicaAfip.Controls.Add(this.EntradaVariante);
                        this.PanelElectronicaAfip.Controls.Add(this.label13);
                        this.PanelElectronicaAfip.Location = new System.Drawing.Point(25, 289);
                        this.PanelElectronicaAfip.Name = "PanelElectronicaAfip";
                        this.PanelElectronicaAfip.Size = new System.Drawing.Size(520, 120);
                        this.PanelElectronicaAfip.TabIndex = 12;
                        // 
                        // EntradaVariante
                        // 
                        this.EntradaVariante.AlwaysExpanded = true;
                        this.EntradaVariante.AutoSize = true;
                        this.EntradaVariante.Location = new System.Drawing.Point(145, 0);
                        this.EntradaVariante.Name = "EntradaVariante";
                        this.EntradaVariante.SetData = new string[] {
        "Predeterminada|0",
        "Azul y verde|1",
        "Rojo y negro|2"};
                        this.EntradaVariante.Size = new System.Drawing.Size(306, 57);
                        this.EntradaVariante.TabIndex = 0;
                        this.EntradaVariante.TextKey = "0";
                        // 
                        // label13
                        // 
                        this.label13.Location = new System.Drawing.Point(1, 0);
                        this.label13.Name = "label13";
                        this.label13.Size = new System.Drawing.Size(140, 24);
                        this.label13.TabIndex = 12;
                        this.label13.Text = "Variante";
                        this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Editar
                        // 
                        this.Controls.Add(this.EntradaPrefijo);
                        this.Controls.Add(this.EntradaTipoFac);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.EntradaSucursal);
                        this.Controls.Add(this.EntradaNumero);
                        this.Controls.Add(this.EntradaTipo);
                        this.Controls.Add(this.Label16);
                        this.Controls.Add(this.BotonEstacionSeleccionar);
                        this.Controls.Add(this.EntradaEstacion);
                        this.Controls.Add(this.label9);
                        this.Controls.Add(this.label8);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.label12);
                        this.Controls.Add(this.PanelControladorFiscal);
                        this.Controls.Add(this.PanelTalonario);
                        this.Controls.Add(this.PanelElectronicaAfip);
                        this.MinimumSize = new System.Drawing.Size(548, 516);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(548, 528);
                        this.PanelControladorFiscal.ResumeLayout(false);
                        this.PanelControladorFiscal.PerformLayout();
                        this.PanelTalonario.ResumeLayout(false);
                        this.PanelTalonario.PerformLayout();
                        this.PanelElectronicaAfip.ResumeLayout(false);
                        this.PanelElectronicaAfip.PerformLayout();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }
                #endregion

                private Lui.Forms.Label label3;
                internal Lui.Forms.TextBox EntradaNumero;
                internal Lui.Forms.Label label11;
                internal Lcc.Entrada.CodigoDetalle EntradaImpresora;
                internal Lui.Forms.Label label10;
                internal Lui.Forms.Label Label16;
                internal Lui.Forms.Label label1;
                internal Lui.Forms.Label label2;
                internal Lui.Forms.ComboBox EntradaTipo;
                internal Lui.Forms.TextBox EntradaEstacion;
                internal Lui.Forms.ComboBox EntradaCarga;
                internal Lui.Forms.Button BotonEstacionSeleccionar;
                internal Lcc.Entrada.CodigoDetalle EntradaSucursal;
                internal Lui.Forms.Label label4;
                internal Lui.Forms.Label label5;
                internal Lui.Forms.Label label6;
                internal Lui.Forms.Label label7;
                internal Lui.Forms.ComboBox EntradaModelo;
                internal Lui.Forms.ComboBox EntradaPuerto;
                internal Lui.Forms.ComboBox EntradaBps;
                internal Lui.Forms.ComboBox EntradaTipoFac;
                internal Lui.Forms.Label label8;
                internal Lui.Forms.Label label9;
                internal Lui.Forms.TextBox EntradaPrefijo;
                internal Lui.Forms.Label label12;
                private Lui.Forms.YesNo EntradaDeTalonario;
                private Lui.Forms.Panel PanelControladorFiscal;
                private Lui.Forms.Panel PanelTalonario;
                private Lui.Forms.Panel PanelElectronicaAfip;
                internal Lui.Forms.ComboBox EntradaVariante;
                internal Lui.Forms.Label label13;
        }
}
