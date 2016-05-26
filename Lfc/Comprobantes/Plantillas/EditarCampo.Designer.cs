using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Plantillas
{
        public partial class EditarCampo
        {
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
                        this.Label15 = new Lui.Forms.Label();
                        this.EntradaTexto = new Lui.Forms.TextBox();
                        this.label1 = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.EntradaX = new Lui.Forms.TextBox();
                        this.EntradaY = new Lui.Forms.TextBox();
                        this.label3 = new Lui.Forms.Label();
                        this.EntradaFuenteNombre = new Lui.Forms.ComboBox();
                        this.label4 = new Lui.Forms.Label();
                        this.EntradaAlto = new Lui.Forms.TextBox();
                        this.EntradaAncho = new Lui.Forms.TextBox();
                        this.label5 = new Lui.Forms.Label();
                        this.label6 = new Lui.Forms.Label();
                        this.EntradaFuenteTamano = new Lui.Forms.TextBox();
                        this.EntradaAlienacionHorizontal = new Lui.Forms.ComboBox();
                        this.label7 = new Lui.Forms.Label();
                        this.EntradaAlienacionVertical = new Lui.Forms.ComboBox();
                        this.EntradaAnchoBorde = new Lui.Forms.TextBox();
                        this.label8 = new Lui.Forms.Label();
                        this.ColorFondo = new Lui.Forms.Button();
                        this.ColorTexto = new Lui.Forms.Button();
                        this.ColorBorde = new Lui.Forms.Button();
                        this.EntradaAjusteTexto = new Lui.Forms.ComboBox();
                        this.label9 = new Lui.Forms.Label();
                        this.EntradaFormato = new Lui.Forms.ComboBox();
                        this.EtiquetaMuestra = new System.Windows.Forms.Label();
                        this.PanelMuestra = new System.Windows.Forms.Panel();
                        this.PanelMuestraBorde = new System.Windows.Forms.Panel();
                        this.label10 = new Lui.Forms.Label();
                        this.BotonColorFondoPredet = new Lui.Forms.Button();
                        this.EntradaPreimpreso = new Lui.Forms.ComboBox();
                        this.PanelMuestra.SuspendLayout();
                        this.PanelMuestraBorde.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // Label15
                        // 
                        this.Label15.Location = new System.Drawing.Point(24, 56);
                        this.Label15.Name = "Label15";
                        this.Label15.Size = new System.Drawing.Size(88, 24);
                        this.Label15.TabIndex = 3;
                        this.Label15.Text = "Formato";
                        this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaTexto
                        // 
                        this.EntradaTexto.Location = new System.Drawing.Point(112, 24);
                        this.EntradaTexto.Name = "EntradaTexto";
                        this.EntradaTexto.Size = new System.Drawing.Size(400, 24);
                        this.EntradaTexto.TabIndex = 1;
                        this.EntradaTexto.TextChanged += new System.EventHandler(this.EntradaTexto_TextChanged);
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(24, 24);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(88, 24);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "Texto";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(24, 88);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(88, 24);
                        this.label2.TabIndex = 5;
                        this.label2.Text = "Posición";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaX
                        // 
                        this.EntradaX.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaX.Location = new System.Drawing.Point(112, 88);
                        this.EntradaX.Name = "EntradaX";
                        this.EntradaX.Size = new System.Drawing.Size(56, 24);
                        this.EntradaX.Sufijo = "x";
                        this.EntradaX.TabIndex = 6;
                        this.EntradaX.Text = "0";
                        // 
                        // EntradaY
                        // 
                        this.EntradaY.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaY.Location = new System.Drawing.Point(180, 88);
                        this.EntradaY.Name = "EntradaY";
                        this.EntradaY.Size = new System.Drawing.Size(56, 24);
                        this.EntradaY.Sufijo = "y";
                        this.EntradaY.TabIndex = 8;
                        this.EntradaY.Text = "0";
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(168, 88);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(20, 24);
                        this.label3.TabIndex = 7;
                        this.label3.Text = ",";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFuenteNombre
                        // 
                        this.EntradaFuenteNombre.AlwaysExpanded = false;
                        this.EntradaFuenteNombre.Location = new System.Drawing.Point(112, 120);
                        this.EntradaFuenteNombre.Name = "EntradaFuenteNombre";
                        this.EntradaFuenteNombre.SetData = new string[] {
        "Predeterminada|*",
        "Vera Serif|Bitstream Vera Serif",
        "Vera Sans Serif|Bitstream Vera Sans",
        "Vera Monoespaciada|Bitstream Vera Sans Mono",
        "Segoe UI|Segoe UI",
        "Courier|Courier New"};
                        this.EntradaFuenteNombre.Size = new System.Drawing.Size(256, 24);
                        this.EntradaFuenteNombre.TabIndex = 14;
                        this.EntradaFuenteNombre.TextKey = "*";
                        this.EntradaFuenteNombre.TextChanged += new System.EventHandler(this.EntradaFuenteFuenteTamano_TextChanged);
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(24, 120);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(88, 24);
                        this.label4.TabIndex = 13;
                        this.label4.Text = "Fuente";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaAlto
                        // 
                        this.EntradaAlto.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaAlto.Location = new System.Drawing.Point(400, 88);
                        this.EntradaAlto.Name = "EntradaAlto";
                        this.EntradaAlto.Size = new System.Drawing.Size(56, 24);
                        this.EntradaAlto.Sufijo = "v";
                        this.EntradaAlto.TabIndex = 12;
                        this.EntradaAlto.Text = "0";
                        // 
                        // EntradaAncho
                        // 
                        this.EntradaAncho.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaAncho.Location = new System.Drawing.Point(328, 88);
                        this.EntradaAncho.Name = "EntradaAncho";
                        this.EntradaAncho.Size = new System.Drawing.Size(56, 24);
                        this.EntradaAncho.Sufijo = "h";
                        this.EntradaAncho.TabIndex = 10;
                        this.EntradaAncho.Text = "0";
                        // 
                        // label5
                        // 
                        this.label5.Location = new System.Drawing.Point(384, 88);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(16, 24);
                        this.label5.TabIndex = 11;
                        this.label5.Text = "x";
                        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // label6
                        // 
                        this.label6.Location = new System.Drawing.Point(264, 88);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(64, 24);
                        this.label6.TabIndex = 9;
                        this.label6.Text = "Tamaño";
                        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFuenteTamano
                        // 
                        this.EntradaFuenteTamano.DataType = Lui.Forms.DataTypes.Float;
                        this.EntradaFuenteTamano.DecimalPlaces = 2;
                        this.EntradaFuenteTamano.Location = new System.Drawing.Point(376, 120);
                        this.EntradaFuenteTamano.Name = "EntradaFuenteTamano";
                        this.EntradaFuenteTamano.Size = new System.Drawing.Size(92, 24);
                        this.EntradaFuenteTamano.Sufijo = "ptos.";
                        this.EntradaFuenteTamano.TabIndex = 15;
                        this.EntradaFuenteTamano.Text = "10.00";
                        this.EntradaFuenteTamano.TextChanged += new System.EventHandler(this.EntradaFuenteFuenteTamano_TextChanged);
                        // 
                        // EntradaAlienacionHorizontal
                        // 
                        this.EntradaAlienacionHorizontal.AlwaysExpanded = true;
                        this.EntradaAlienacionHorizontal.AutoSize = true;
                        this.EntradaAlienacionHorizontal.Location = new System.Drawing.Point(112, 152);
                        this.EntradaAlienacionHorizontal.Name = "EntradaAlienacionHorizontal";
                        this.EntradaAlienacionHorizontal.SetData = new string[] {
        "Izquierda|Near",
        "Centro|Center",
        "Derecha|Far"};
                        this.EntradaAlienacionHorizontal.Size = new System.Drawing.Size(140, 56);
                        this.EntradaAlienacionHorizontal.TabIndex = 17;
                        this.EntradaAlienacionHorizontal.TextKey = "Near";
                        this.EntradaAlienacionHorizontal.TextChanged += new System.EventHandler(this.EntradaAlienacionHorizontal_TextChanged);
                        // 
                        // label7
                        // 
                        this.label7.Location = new System.Drawing.Point(24, 152);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(88, 24);
                        this.label7.TabIndex = 16;
                        this.label7.Text = "Alineación";
                        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaAlienacionVertical
                        // 
                        this.EntradaAlienacionVertical.AlwaysExpanded = true;
                        this.EntradaAlienacionVertical.AutoSize = true;
                        this.EntradaAlienacionVertical.Location = new System.Drawing.Point(260, 152);
                        this.EntradaAlienacionVertical.Name = "EntradaAlienacionVertical";
                        this.EntradaAlienacionVertical.SetData = new string[] {
        "Arriba|Near",
        "Centro|Center",
        "Abajo|Far"};
                        this.EntradaAlienacionVertical.Size = new System.Drawing.Size(140, 56);
                        this.EntradaAlienacionVertical.TabIndex = 18;
                        this.EntradaAlienacionVertical.TextKey = "Near";
                        this.EntradaAlienacionVertical.TextChanged += new System.EventHandler(this.EntradaAlienacionVertical_TextChanged);
                        // 
                        // EntradaAnchoBorde
                        // 
                        this.EntradaAnchoBorde.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaAnchoBorde.Location = new System.Drawing.Point(112, 264);
                        this.EntradaAnchoBorde.Name = "EntradaAnchoBorde";
                        this.EntradaAnchoBorde.Size = new System.Drawing.Size(88, 24);
                        this.EntradaAnchoBorde.Sufijo = "ptos.";
                        this.EntradaAnchoBorde.TabIndex = 22;
                        this.EntradaAnchoBorde.Text = "0";
                        this.EntradaAnchoBorde.TextChanged += new System.EventHandler(this.EntradaAnchoBorde_TextChanged);
                        // 
                        // label8
                        // 
                        this.label8.Location = new System.Drawing.Point(24, 264);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(88, 24);
                        this.label8.TabIndex = 21;
                        this.label8.Text = "Borde";
                        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // ColorFondo
                        // 
                        this.ColorFondo.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.ColorFondo.ForeColor = System.Drawing.Color.Black;
                        this.ColorFondo.Image = null;
                        this.ColorFondo.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.ColorFondo.Location = new System.Drawing.Point(112, 304);
                        this.ColorFondo.Name = "ColorFondo";
                        this.ColorFondo.Size = new System.Drawing.Size(84, 28);
                        this.ColorFondo.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.ColorFondo.Subtext = "Tecla";
                        this.ColorFondo.TabIndex = 24;
                        this.ColorFondo.Text = "Fondo";
                        this.ColorFondo.Click += new System.EventHandler(this.BotonColorFondo_Click);
                        // 
                        // ColorTexto
                        // 
                        this.ColorTexto.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.ColorTexto.ForeColor = System.Drawing.Color.Black;
                        this.ColorTexto.Image = null;
                        this.ColorTexto.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.ColorTexto.Location = new System.Drawing.Point(216, 304);
                        this.ColorTexto.Name = "ColorTexto";
                        this.ColorTexto.Size = new System.Drawing.Size(80, 28);
                        this.ColorTexto.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.ColorTexto.Subtext = "Tecla";
                        this.ColorTexto.TabIndex = 25;
                        this.ColorTexto.Text = "Texto";
                        this.ColorTexto.Click += new System.EventHandler(this.BotonColorTexto_Click);
                        // 
                        // ColorBorde
                        // 
                        this.ColorBorde.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.ColorBorde.ForeColor = System.Drawing.Color.Black;
                        this.ColorBorde.Image = null;
                        this.ColorBorde.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.ColorBorde.Location = new System.Drawing.Point(312, 304);
                        this.ColorBorde.Name = "ColorBorde";
                        this.ColorBorde.Size = new System.Drawing.Size(84, 28);
                        this.ColorBorde.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.ColorBorde.Subtext = "Tecla";
                        this.ColorBorde.TabIndex = 26;
                        this.ColorBorde.Text = "Borde";
                        this.ColorBorde.Click += new System.EventHandler(this.BotonColorBorde_Click);
                        // 
                        // EntradaAjusteTexto
                        // 
                        this.EntradaAjusteTexto.AlwaysExpanded = true;
                        this.EntradaAjusteTexto.AutoSize = true;
                        this.EntradaAjusteTexto.Location = new System.Drawing.Point(112, 216);
                        this.EntradaAjusteTexto.Name = "EntradaAjusteTexto";
                        this.EntradaAjusteTexto.SetData = new string[] {
        "Sólo un renglon|0",
        "Fluir texto hacia abajo|1"};
                        this.EntradaAjusteTexto.Size = new System.Drawing.Size(288, 39);
                        this.EntradaAjusteTexto.TabIndex = 20;
                        this.EntradaAjusteTexto.TextKey = "0";
                        this.EntradaAjusteTexto.TextChanged += new System.EventHandler(this.EntradaAjusteTexto_TextChanged);
                        // 
                        // label9
                        // 
                        this.label9.Location = new System.Drawing.Point(24, 216);
                        this.label9.Name = "label9";
                        this.label9.Size = new System.Drawing.Size(88, 24);
                        this.label9.TabIndex = 19;
                        this.label9.Text = "Ajuste";
                        this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFormato
                        // 
                        this.EntradaFormato.AlwaysExpanded = false;
                        this.EntradaFormato.Enabled = false;
                        this.EntradaFormato.Location = new System.Drawing.Point(112, 56);
                        this.EntradaFormato.Name = "EntradaFormato";
                        this.EntradaFormato.SetData = new string[] {
                                "Predeterminado|*",
                                "Fecha corta (01/01/2001)|dd/MM/yyyy",
                                "Fecha larga (lunes, 1 de enero de 2001)|dddd, d \"de\" MMMM \"de\" yyyy",
                                "Fecha y hora (01/01/2001 12:00)|dd/MM/yyyy HH:mm",
                                "Numérico con 2 decimales|#.00",
                                "Numérico con 4 decimales|#.0000",
                                "Entero de 7 dígitos|0000000",
                                "Entero de 8 dígitos|00000000"};
                        this.EntradaFormato.Size = new System.Drawing.Size(400, 24);
                        this.EntradaFormato.TabIndex = 4;
                        this.EntradaFormato.TextKey = "*";
                        // 
                        // EtiquetaMuestra
                        // 
                        this.EtiquetaMuestra.BackColor = System.Drawing.Color.White;
                        this.EtiquetaMuestra.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.EtiquetaMuestra.Location = new System.Drawing.Point(0, 0);
                        this.EtiquetaMuestra.Name = "EtiquetaMuestra";
                        this.EtiquetaMuestra.Size = new System.Drawing.Size(176, 72);
                        this.EtiquetaMuestra.TabIndex = 51;
                        this.EtiquetaMuestra.Text = "Texto de muestra";
                        this.EtiquetaMuestra.UseMnemonic = false;
                        // 
                        // PanelMuestra
                        // 
                        this.PanelMuestra.BackColor = System.Drawing.Color.White;
                        this.PanelMuestra.Controls.Add(this.PanelMuestraBorde);
                        this.PanelMuestra.Location = new System.Drawing.Point(432, 176);
                        this.PanelMuestra.Name = "PanelMuestra";
                        this.PanelMuestra.Size = new System.Drawing.Size(224, 136);
                        this.PanelMuestra.TabIndex = 52;
                        // 
                        // PanelMuestraBorde
                        // 
                        this.PanelMuestraBorde.BackColor = System.Drawing.Color.DimGray;
                        this.PanelMuestraBorde.Controls.Add(this.EtiquetaMuestra);
                        this.PanelMuestraBorde.Location = new System.Drawing.Point(24, 32);
                        this.PanelMuestraBorde.Name = "PanelMuestraBorde";
                        this.PanelMuestraBorde.Size = new System.Drawing.Size(176, 72);
                        this.PanelMuestraBorde.TabIndex = 52;
                        // 
                        // label10
                        // 
                        this.label10.Location = new System.Drawing.Point(24, 304);
                        this.label10.Name = "label10";
                        this.label10.Size = new System.Drawing.Size(88, 24);
                        this.label10.TabIndex = 23;
                        this.label10.Text = "Color";
                        this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // BotonColorFondoPredet
                        // 
                        this.BotonColorFondoPredet.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonColorFondoPredet.ForeColor = System.Drawing.Color.Black;
                        this.BotonColorFondoPredet.Image = null;
                        this.BotonColorFondoPredet.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonColorFondoPredet.Location = new System.Drawing.Point(112, 336);
                        this.BotonColorFondoPredet.Name = "BotonColorFondoPredet";
                        this.BotonColorFondoPredet.Size = new System.Drawing.Size(84, 28);
                        this.BotonColorFondoPredet.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonColorFondoPredet.Subtext = "Tecla";
                        this.BotonColorFondoPredet.TabIndex = 27;
                        this.BotonColorFondoPredet.Text = "Transp.";
                        this.BotonColorFondoPredet.Click += new System.EventHandler(this.BotonColorFondoPredet_Click);
                        // 
                        // EntradaPreimpreso
                        // 
                        this.EntradaPreimpreso.AlwaysExpanded = true;
                        this.EntradaPreimpreso.AutoSize = true;
                        this.EntradaPreimpreso.Location = new System.Drawing.Point(520, 24);
                        this.EntradaPreimpreso.Name = "EntradaPreimpreso";
                        this.EntradaPreimpreso.SetData = new string[] {
        "Normal|0",
        "Preimpreso|1"};
                        this.EntradaPreimpreso.Size = new System.Drawing.Size(140, 39);
                        this.EntradaPreimpreso.TabIndex = 2;
                        this.EntradaPreimpreso.TextKey = "";
                        this.EntradaPreimpreso.TextChanged += new System.EventHandler(this.EntradaPreimpreso_TextChanged);
                        // 
                        // EditarCampo
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(688, 487);
                        this.Controls.Add(this.EntradaPreimpreso);
                        this.Controls.Add(this.BotonColorFondoPredet);
                        this.Controls.Add(this.PanelMuestra);
                        this.Controls.Add(this.EntradaAjusteTexto);
                        this.Controls.Add(this.ColorBorde);
                        this.Controls.Add(this.ColorTexto);
                        this.Controls.Add(this.ColorFondo);
                        this.Controls.Add(this.EntradaAnchoBorde);
                        this.Controls.Add(this.EntradaAlienacionVertical);
                        this.Controls.Add(this.EntradaAlienacionHorizontal);
                        this.Controls.Add(this.EntradaFuenteTamano);
                        this.Controls.Add(this.EntradaAlto);
                        this.Controls.Add(this.EntradaAncho);
                        this.Controls.Add(this.label5);
                        this.Controls.Add(this.label6);
                        this.Controls.Add(this.EntradaFuenteNombre);
                        this.Controls.Add(this.EntradaY);
                        this.Controls.Add(this.EntradaX);
                        this.Controls.Add(this.EntradaTexto);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.EntradaFormato);
                        this.Controls.Add(this.label10);
                        this.Controls.Add(this.label9);
                        this.Controls.Add(this.label8);
                        this.Controls.Add(this.label7);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.Label15);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "EditarCampo";
                        this.Text = "Editar campo";
                        this.Controls.SetChildIndex(this.Label15, 0);
                        this.Controls.SetChildIndex(this.label1, 0);
                        this.Controls.SetChildIndex(this.label2, 0);
                        this.Controls.SetChildIndex(this.label4, 0);
                        this.Controls.SetChildIndex(this.label7, 0);
                        this.Controls.SetChildIndex(this.label8, 0);
                        this.Controls.SetChildIndex(this.label9, 0);
                        this.Controls.SetChildIndex(this.label10, 0);
                        this.Controls.SetChildIndex(this.EntradaFormato, 0);
                        this.Controls.SetChildIndex(this.label3, 0);
                        this.Controls.SetChildIndex(this.EntradaTexto, 0);
                        this.Controls.SetChildIndex(this.EntradaX, 0);
                        this.Controls.SetChildIndex(this.EntradaY, 0);
                        this.Controls.SetChildIndex(this.EntradaFuenteNombre, 0);
                        this.Controls.SetChildIndex(this.label6, 0);
                        this.Controls.SetChildIndex(this.label5, 0);
                        this.Controls.SetChildIndex(this.EntradaAncho, 0);
                        this.Controls.SetChildIndex(this.EntradaAlto, 0);
                        this.Controls.SetChildIndex(this.EntradaFuenteTamano, 0);
                        this.Controls.SetChildIndex(this.EntradaAlienacionHorizontal, 0);
                        this.Controls.SetChildIndex(this.EntradaAlienacionVertical, 0);
                        this.Controls.SetChildIndex(this.EntradaAnchoBorde, 0);
                        this.Controls.SetChildIndex(this.ColorFondo, 0);
                        this.Controls.SetChildIndex(this.ColorTexto, 0);
                        this.Controls.SetChildIndex(this.ColorBorde, 0);
                        this.Controls.SetChildIndex(this.EntradaAjusteTexto, 0);
                        this.Controls.SetChildIndex(this.PanelMuestra, 0);
                        this.Controls.SetChildIndex(this.BotonColorFondoPredet, 0);
                        this.Controls.SetChildIndex(this.EntradaPreimpreso, 0);
                        this.PanelMuestra.ResumeLayout(false);
                        this.PanelMuestraBorde.ResumeLayout(false);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }
                #endregion

                protected Lui.Forms.Label Label15;
                protected Lui.Forms.Label label1;
                protected Lui.Forms.Label label2;
                protected Lui.Forms.Label label3;
                protected Lui.Forms.Label label4;
                protected Lui.Forms.Label label5;
                protected Lui.Forms.Label label6;
                protected Lui.Forms.TextBox EntradaTexto;
                protected Lui.Forms.TextBox EntradaX;
                protected Lui.Forms.TextBox EntradaY;
                protected Lui.Forms.ComboBox EntradaFuenteNombre;
                protected Lui.Forms.TextBox EntradaAlto;
                protected Lui.Forms.TextBox EntradaAncho;
                protected Lui.Forms.TextBox EntradaFuenteTamano;
                protected Lui.Forms.Label label7;
                protected Lui.Forms.ComboBox EntradaAlienacionHorizontal;
                protected Lui.Forms.ComboBox EntradaAlienacionVertical;
                protected Lui.Forms.TextBox EntradaAnchoBorde;
                protected Lui.Forms.Label label8;
                protected Lui.Forms.Button ColorFondo;
                protected Lui.Forms.Button ColorTexto;
                protected Lui.Forms.Button ColorBorde;
                protected Lui.Forms.ComboBox EntradaAjusteTexto;
                protected Lui.Forms.Label label9;
                protected Lui.Forms.ComboBox EntradaFormato;
                protected System.ComponentModel.IContainer components = null;
                protected Label EtiquetaMuestra;
                protected Panel PanelMuestra;
                protected Panel PanelMuestraBorde;
                protected Lui.Forms.Label label10;
                protected Lui.Forms.Button BotonColorFondoPredet;
                protected Lui.Forms.ComboBox EntradaPreimpreso;
        }
}
