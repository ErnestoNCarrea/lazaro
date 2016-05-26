using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Comprobantes.Tipo
{
        public partial class Editar
        {
                internal Lui.Forms.TextBox EntradaNombre;
                internal Lui.Forms.Label Label5;
                internal Lui.Forms.Label label1;
                internal Lui.Forms.Label label2;
                internal Lui.Forms.TextBox EntradaLetra;
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
                        this.EntradaLetra = new Lui.Forms.TextBox();
                        this.label1 = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.EntradaMueveStock = new Lui.Forms.ComboBox();
                        this.label7 = new Lui.Forms.Label();
                        this.EntradaSituacionOrigen = new Lcc.Entrada.CodigoDetalle();
                        this.label3 = new Lui.Forms.Label();
                        this.EntradaSituacionDestino = new Lcc.Entrada.CodigoDetalle();
                        this.EntradaNumerarAl = new Lui.Forms.ComboBox();
                        this.label4 = new Lui.Forms.Label();
                        this.EntradaImprimirRepetir = new Lui.Forms.ComboBox();
                        this.label6 = new Lui.Forms.Label();
                        this.EntradaImprimirModificar = new Lui.Forms.ComboBox();
                        this.label8 = new Lui.Forms.Label();
                        this.EntradaImprimirGuardar = new Lui.Forms.ComboBox();
                        this.label9 = new Lui.Forms.Label();
                        this.GroupLabel = new Lui.Forms.Label();
                        this.Listado = new Lui.Forms.ListView();
                        this.ColCod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColSucursal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColEstacion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColPv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColImpresora = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.BotonQuitar = new Lui.Forms.Button();
                        this.BotonAgregar = new Lui.Forms.Button();
                        this.EntradaCargaPapel = new Lui.Forms.ComboBox();
                        this.label10 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaNombre
                        // 
                        this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaNombre.Location = new System.Drawing.Point(120, 0);
                        this.EntradaNombre.Name = "EntradaNombre";
                        this.EntradaNombre.Size = new System.Drawing.Size(320, 24);
                        this.EntradaNombre.TabIndex = 1;
                        // 
                        // Label5
                        // 
                        this.Label5.Location = new System.Drawing.Point(0, 0);
                        this.Label5.Name = "Label5";
                        this.Label5.Size = new System.Drawing.Size(116, 24);
                        this.Label5.TabIndex = 0;
                        this.Label5.Text = "Nombre";
                        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaLetra
                        // 
                        this.EntradaLetra.Location = new System.Drawing.Point(120, 32);
                        this.EntradaLetra.Name = "EntradaLetra";
                        this.EntradaLetra.Size = new System.Drawing.Size(320, 24);
                        this.EntradaLetra.TabIndex = 3;
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(0, 32);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(116, 24);
                        this.label1.TabIndex = 2;
                        this.label1.Text = "Tipo";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(0, 64);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(116, 24);
                        this.label2.TabIndex = 4;
                        this.label2.Text = "Mueve Stock";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaMueveStock
                        // 
                        this.EntradaMueveStock.AlwaysExpanded = true;
                        this.EntradaMueveStock.AutoSize = true;
                        this.EntradaMueveStock.Location = new System.Drawing.Point(120, 64);
                        this.EntradaMueveStock.Name = "EntradaMueveStock";
                        this.EntradaMueveStock.SetData = new string[] {
        "Saliente|-1",
        "Entrante|1",
        "No|0"};
                        this.EntradaMueveStock.Size = new System.Drawing.Size(128, 57);
                        this.EntradaMueveStock.TabIndex = 5;
                        this.EntradaMueveStock.TextKey = "1";
                        this.EntradaMueveStock.TextChanged += new System.EventHandler(this.EntradaMueveStock_TextChanged);
                        // 
                        // label7
                        // 
                        this.label7.Location = new System.Drawing.Point(68, 128);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(76, 24);
                        this.label7.TabIndex = 6;
                        this.label7.Text = "Desde";
                        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaSituacionOrigen
                        // 
                        this.EntradaSituacionOrigen.AutoTab = true;
                        this.EntradaSituacionOrigen.CanCreate = true;
                        this.EntradaSituacionOrigen.Location = new System.Drawing.Point(144, 128);
                        this.EntradaSituacionOrigen.MaxLength = 200;
                        this.EntradaSituacionOrigen.Name = "EntradaSituacionOrigen";
                        this.EntradaSituacionOrigen.NombreTipo = "Lbl.Articulos.Situacion";
                        this.EntradaSituacionOrigen.PlaceholderText = "Sin especificar";
                        this.EntradaSituacionOrigen.Required = true;
                        this.EntradaSituacionOrigen.Size = new System.Drawing.Size(240, 24);
                        this.EntradaSituacionOrigen.TabIndex = 7;
                        this.EntradaSituacionOrigen.Text = "0";
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(68, 156);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(76, 24);
                        this.label3.TabIndex = 8;
                        this.label3.Text = "Hacia";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaSituacionDestino
                        // 
                        this.EntradaSituacionDestino.AutoTab = true;
                        this.EntradaSituacionDestino.CanCreate = true;
                        this.EntradaSituacionDestino.Location = new System.Drawing.Point(144, 156);
                        this.EntradaSituacionDestino.MaxLength = 200;
                        this.EntradaSituacionDestino.Name = "EntradaSituacionDestino";
                        this.EntradaSituacionDestino.NombreTipo = "Lbl.Articulos.Situacion";
                        this.EntradaSituacionDestino.PlaceholderText = "Sin especificar";
                        this.EntradaSituacionDestino.Required = true;
                        this.EntradaSituacionDestino.Size = new System.Drawing.Size(240, 24);
                        this.EntradaSituacionDestino.TabIndex = 9;
                        this.EntradaSituacionDestino.Text = "0";
                        // 
                        // EntradaNumerarAl
                        // 
                        this.EntradaNumerarAl.AlwaysExpanded = true;
                        this.EntradaNumerarAl.AutoSize = true;
                        this.EntradaNumerarAl.Location = new System.Drawing.Point(124, 192);
                        this.EntradaNumerarAl.Name = "EntradaNumerarAl";
                        this.EntradaNumerarAl.SetData = new string[] {
        "Manualmente|0",
        "Cuando se crea el comprobante|1",
        "Cuando se imprime el comprobante|2"};
                        this.EntradaNumerarAl.Size = new System.Drawing.Size(248, 57);
                        this.EntradaNumerarAl.TabIndex = 11;
                        this.EntradaNumerarAl.TextKey = "1";
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(4, 192);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(116, 24);
                        this.label4.TabIndex = 10;
                        this.label4.Text = "Numerar";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaImprimirRepetir
                        // 
                        this.EntradaImprimirRepetir.AlwaysExpanded = true;
                        this.EntradaImprimirRepetir.AutoSize = true;
                        this.EntradaImprimirRepetir.Location = new System.Drawing.Point(216, 272);
                        this.EntradaImprimirRepetir.Name = "EntradaImprimirRepetir";
                        this.EntradaImprimirRepetir.SetData = new string[] {
        "Sí|1",
        "No|0"};
                        this.EntradaImprimirRepetir.Size = new System.Drawing.Size(52, 40);
                        this.EntradaImprimirRepetir.TabIndex = 13;
                        this.EntradaImprimirRepetir.TextKey = "1";
                        // 
                        // label6
                        // 
                        this.label6.Location = new System.Drawing.Point(0, 272);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(208, 40);
                        this.label6.TabIndex = 12;
                        this.label6.Text = "¿Permite imprimir varias veces el mismo comprobante?";
                        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaImprimirModificar
                        // 
                        this.EntradaImprimirModificar.AlwaysExpanded = true;
                        this.EntradaImprimirModificar.AutoSize = true;
                        this.EntradaImprimirModificar.Location = new System.Drawing.Point(216, 320);
                        this.EntradaImprimirModificar.Name = "EntradaImprimirModificar";
                        this.EntradaImprimirModificar.SetData = new string[] {
        "Sí|1",
        "No|0"};
                        this.EntradaImprimirModificar.Size = new System.Drawing.Size(52, 40);
                        this.EntradaImprimirModificar.TabIndex = 15;
                        this.EntradaImprimirModificar.TextKey = "1";
                        // 
                        // label8
                        // 
                        this.label8.Location = new System.Drawing.Point(0, 320);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(208, 40);
                        this.label8.TabIndex = 14;
                        this.label8.Text = "¿Permite modificar comprobantes impresos?";
                        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaImprimirGuardar
                        // 
                        this.EntradaImprimirGuardar.AlwaysExpanded = true;
                        this.EntradaImprimirGuardar.AutoSize = true;
                        this.EntradaImprimirGuardar.Location = new System.Drawing.Point(216, 368);
                        this.EntradaImprimirGuardar.Name = "EntradaImprimirGuardar";
                        this.EntradaImprimirGuardar.SetData = new string[] {
        "Sí|1",
        "No|0"};
                        this.EntradaImprimirGuardar.Size = new System.Drawing.Size(52, 40);
                        this.EntradaImprimirGuardar.TabIndex = 17;
                        this.EntradaImprimirGuardar.TextKey = "1";
                        // 
                        // label9
                        // 
                        this.label9.Location = new System.Drawing.Point(0, 368);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(208, 40);
                        this.label9.TabIndex = 16;
                        this.label9.Text = "Imprimir automáticamente al guardar el comprobante";
                        this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // GroupLabel
                        // 
                        this.GroupLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.GroupLabel.Location = new System.Drawing.Point(468, 0);
                        this.GroupLabel.Name = "GroupLabel";
                        this.GroupLabel.Size = new System.Drawing.Size(378, 32);
                        this.GroupLabel.TabIndex = 30;
                        this.GroupLabel.Text = "Dónde se imprime:";
                        this.GroupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.GroupLabel.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        this.GroupLabel.UseMnemonic = false;
                        // 
                        // Listado
                        // 
                        this.Listado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Listado.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.Listado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColCod,
            this.ColSucursal,
            this.ColEstacion,
            this.ColPv,
            this.ColImpresora});
                        this.Listado.FieldName = null;
                        this.Listado.FullRowSelect = true;
                        this.Listado.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.Listado.LabelWrap = false;
                        this.Listado.Location = new System.Drawing.Point(468, 32);
                        this.Listado.MultiSelect = false;
                        this.Listado.Name = "Listado";
                        this.Listado.ReadOnly = false;
                        this.Listado.Size = new System.Drawing.Size(378, 328);
                        this.Listado.TabIndex = 31;
                        this.Listado.UseCompatibleStateImageBehavior = false;
                        this.Listado.View = System.Windows.Forms.View.Details;
                        // 
                        // ColCod
                        // 
                        this.ColCod.Text = "Cod";
                        this.ColCod.Width = 0;
                        // 
                        // ColSucursal
                        // 
                        this.ColSucursal.Text = "Sucursal";
                        this.ColSucursal.Width = 160;
                        // 
                        // ColEstacion
                        // 
                        this.ColEstacion.Text = "Estacion";
                        this.ColEstacion.Width = 160;
                        // 
                        // ColPv
                        // 
                        this.ColPv.Text = "PV";
                        this.ColPv.Width = 96;
                        // 
                        // ColImpresora
                        // 
                        this.ColImpresora.Text = "Se imprime en";
                        this.ColImpresora.Width = 160;
                        // 
                        // BotonQuitar
                        // 
                        this.BotonQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonQuitar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonQuitar.Image = null;
                        this.BotonQuitar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonQuitar.Location = new System.Drawing.Point(619, 374);
                        this.BotonQuitar.Name = "BotonQuitar";
                        this.BotonQuitar.Size = new System.Drawing.Size(108, 34);
                        this.BotonQuitar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonQuitar.Subtext = "";
                        this.BotonQuitar.TabIndex = 32;
                        this.BotonQuitar.Text = "Quitar";
                        this.BotonQuitar.Click += new System.EventHandler(this.BotonQuitar_Click);
                        // 
                        // BotonAgregar
                        // 
                        this.BotonAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonAgregar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonAgregar.Image = null;
                        this.BotonAgregar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonAgregar.Location = new System.Drawing.Point(739, 374);
                        this.BotonAgregar.Name = "BotonAgregar";
                        this.BotonAgregar.Size = new System.Drawing.Size(108, 34);
                        this.BotonAgregar.SubLabelPos = Lui.Forms.SubLabelPositions.Right;
                        this.BotonAgregar.Subtext = "F6";
                        this.BotonAgregar.TabIndex = 33;
                        this.BotonAgregar.Text = "Agregar";
                        this.BotonAgregar.Click += new System.EventHandler(this.BotonAgregar_Click);
                        // 
                        // EntradaCargaPapel
                        // 
                        this.EntradaCargaPapel.AlwaysExpanded = true;
                        this.EntradaCargaPapel.AutoSize = true;
                        this.EntradaCargaPapel.Location = new System.Drawing.Point(216, 416);
                        this.EntradaCargaPapel.Name = "EntradaCargaPapel";
                        this.EntradaCargaPapel.SetData = new string[] {
        "Automática|0",
        "Manual|1"};
                        this.EntradaCargaPapel.Size = new System.Drawing.Size(104, 40);
                        this.EntradaCargaPapel.TabIndex = 19;
                        this.EntradaCargaPapel.TextKey = "0";
                        // 
                        // label10
                        // 
                        this.label10.Location = new System.Drawing.Point(0, 416);
                        this.label10.Name = "label10";
                        this.label10.Size = new System.Drawing.Size(208, 24);
                        this.label10.TabIndex = 18;
                        this.label10.Text = "Carga de papel";
                        this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Editar
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                        this.Controls.Add(this.EntradaCargaPapel);
                        this.Controls.Add(this.label10);
                        this.Controls.Add(this.BotonQuitar);
                        this.Controls.Add(this.BotonAgregar);
                        this.Controls.Add(this.Listado);
                        this.Controls.Add(this.EntradaImprimirGuardar);
                        this.Controls.Add(this.EntradaImprimirModificar);
                        this.Controls.Add(this.EntradaImprimirRepetir);
                        this.Controls.Add(this.EntradaNumerarAl);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.EntradaSituacionDestino);
                        this.Controls.Add(this.label7);
                        this.Controls.Add(this.EntradaSituacionOrigen);
                        this.Controls.Add(this.EntradaMueveStock);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.EntradaLetra);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.EntradaNombre);
                        this.Controls.Add(this.Label5);
                        this.Controls.Add(this.label9);
                        this.Controls.Add(this.label8);
                        this.Controls.Add(this.label6);
                        this.Controls.Add(this.GroupLabel);
                        this.MinimumSize = new System.Drawing.Size(848, 462);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(848, 462);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }
                #endregion

                private Lui.Forms.ComboBox EntradaMueveStock;
                internal Lui.Forms.Label label7;
                internal Lcc.Entrada.CodigoDetalle EntradaSituacionOrigen;
                internal Lui.Forms.Label label3;
                internal Lcc.Entrada.CodigoDetalle EntradaSituacionDestino;
                private Lui.Forms.ComboBox EntradaNumerarAl;
                internal Lui.Forms.Label label4;
                private Lui.Forms.ComboBox EntradaImprimirRepetir;
                internal Lui.Forms.Label label6;
                private Lui.Forms.ComboBox EntradaImprimirModificar;
                internal Lui.Forms.Label label8;
                private Lui.Forms.ComboBox EntradaImprimirGuardar;
                internal Lui.Forms.Label label9;
                private Lui.Forms.Label GroupLabel;
                private Lui.Forms.ListView Listado;
                private System.Windows.Forms.ColumnHeader ColCod;
                private System.Windows.Forms.ColumnHeader ColSucursal;
                private System.Windows.Forms.ColumnHeader ColEstacion;
                private System.Windows.Forms.ColumnHeader ColPv;
                internal Lui.Forms.Button BotonQuitar;
                internal Lui.Forms.Button BotonAgregar;
                private System.Windows.Forms.ColumnHeader ColImpresora;
                private Lui.Forms.ComboBox EntradaCargaPapel;
                internal Lui.Forms.Label label10;
        }
}
