namespace Lcc.Entrada
{
        partial class RangoFechas
        {
                private System.ComponentModel.IContainer components = null;

                protected override void Dispose(bool disposing)
                {
                        if (disposing && (components != null)) {
                                components.Dispose();
                        }
                        base.Dispose(disposing);
                }

                #region Código generado por el Diseñador de componentes

                private void InitializeComponent()
                {
                        this.EntradaTipoDeRango = new Lui.Forms.ComboBox();
                        this.EntradaDesde = new Lui.Forms.TextBox();
                        this.EntradaHasta = new Lui.Forms.TextBox();
                        this.EntradaRango = new Lui.Forms.ComboBox();
                        this.EtiquetaDesde = new Lui.Forms.Label();
                        this.EtiquetaHasta = new Lui.Forms.Label();
                        this.PanelCombos = new Lui.Forms.Panel();
                        this.PanelFechas = new Lui.Forms.Panel();
                        this.PanelCombos.SuspendLayout();
                        this.PanelFechas.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // EntradaTipoDeRango
                        // 
                        this.EntradaTipoDeRango.AlwaysExpanded = false;
                        this.EntradaTipoDeRango.AutoSize = true;
                        this.EntradaTipoDeRango.Location = new System.Drawing.Point(0, 0);
                        this.EntradaTipoDeRango.Name = "EntradaTipoDeRango";
                        this.EntradaTipoDeRango.SetData = new string[] {
        "Por día|dia",
        "Por semana|semana",
        "Por mes|mes",
        "Por rango|rango",
        "Todas|todas"};
                        this.EntradaTipoDeRango.Size = new System.Drawing.Size(124, 25);
                        this.EntradaTipoDeRango.TabIndex = 0;
                        this.EntradaTipoDeRango.TextKey = "semana";
                        this.EntradaTipoDeRango.TextChanged += new System.EventHandler(this.EntradaTipoDeRango_TextChanged);
                        this.EntradaTipoDeRango.SizeChanged += new System.EventHandler(this.Combos_SizeChanged);
                        // 
                        // EntradaDesde
                        // 
                        this.EntradaDesde.DataType = Lui.Forms.DataTypes.Date;
                        this.EntradaDesde.Location = new System.Drawing.Point(120, 8);
                        this.EntradaDesde.Name = "EntradaDesde";
                        this.EntradaDesde.Size = new System.Drawing.Size(108, 24);
                        this.EntradaDesde.TabIndex = 1;
                        this.EntradaDesde.TextChanged += new System.EventHandler(this.EntradaDesde_TextChanged);
                        // 
                        // EntradaHasta
                        // 
                        this.EntradaHasta.DataType = Lui.Forms.DataTypes.Date;
                        this.EntradaHasta.Location = new System.Drawing.Point(292, 8);
                        this.EntradaHasta.Name = "EntradaHasta";
                        this.EntradaHasta.Size = new System.Drawing.Size(108, 24);
                        this.EntradaHasta.TabIndex = 3;
                        this.EntradaHasta.TextChanged += new System.EventHandler(this.EntradaHasta_TextChanged);
                        // 
                        // EntradaRango
                        // 
                        this.EntradaRango.AlwaysExpanded = false;
                        this.EntradaRango.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaRango.AutoSize = true;
                        this.EntradaRango.Location = new System.Drawing.Point(128, 0);
                        this.EntradaRango.Name = "EntradaRango";
                        this.EntradaRango.SetData = new string[] {
        "a|1"};
                        this.EntradaRango.Size = new System.Drawing.Size(311, 25);
                        this.EntradaRango.TabIndex = 1;
                        this.EntradaRango.TextKey = "1";
                        this.EntradaRango.TextChanged += new System.EventHandler(this.EntradaRango_TextChanged);
                        this.EntradaRango.SizeChanged += new System.EventHandler(this.Combos_SizeChanged);
                        // 
                        // EtiquetaDesde
                        // 
                        this.EtiquetaDesde.Location = new System.Drawing.Point(64, 8);
                        this.EtiquetaDesde.Name = "EtiquetaDesde";
                        this.EtiquetaDesde.Size = new System.Drawing.Size(56, 24);
                        this.EtiquetaDesde.TabIndex = 0;
                        this.EtiquetaDesde.Text = "Desde";
                        this.EtiquetaDesde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EtiquetaHasta
                        // 
                        this.EtiquetaHasta.Location = new System.Drawing.Point(236, 8);
                        this.EtiquetaHasta.Name = "EtiquetaHasta";
                        this.EtiquetaHasta.Size = new System.Drawing.Size(56, 24);
                        this.EtiquetaHasta.TabIndex = 2;
                        this.EtiquetaHasta.Text = "Hasta";
                        this.EtiquetaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // PanelCombos
                        // 
                        this.PanelCombos.Controls.Add(this.EntradaTipoDeRango);
                        this.PanelCombos.Controls.Add(this.EntradaRango);
                        this.PanelCombos.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelCombos.Location = new System.Drawing.Point(2, 2);
                        this.PanelCombos.Name = "PanelCombos";
                        this.PanelCombos.Size = new System.Drawing.Size(441, 26);
                        this.PanelCombos.TabIndex = 0;
                        this.PanelCombos.SizeChanged += new System.EventHandler(this.Paneles_SizeChanged);
                        // 
                        // PanelFechas
                        // 
                        this.PanelFechas.Controls.Add(this.EtiquetaDesde);
                        this.PanelFechas.Controls.Add(this.EntradaDesde);
                        this.PanelFechas.Controls.Add(this.EtiquetaHasta);
                        this.PanelFechas.Controls.Add(this.EntradaHasta);
                        this.PanelFechas.Dock = System.Windows.Forms.DockStyle.Top;
                        this.PanelFechas.Location = new System.Drawing.Point(2, 28);
                        this.PanelFechas.Name = "PanelFechas";
                        this.PanelFechas.Size = new System.Drawing.Size(441, 32);
                        this.PanelFechas.TabIndex = 1;
                        this.PanelFechas.SizeChanged += new System.EventHandler(this.Paneles_SizeChanged);
                        this.PanelFechas.VisibleChanged += new System.EventHandler(this.Paneles_SizeChanged);
                        // 
                        // RangoFechas
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.PanelFechas);
                        this.Controls.Add(this.PanelCombos);
                        this.Name = "RangoFechas";
                        this.Size = new System.Drawing.Size(445, 62);
                        this.Controls.SetChildIndex(this.PanelCombos, 0);
                        this.Controls.SetChildIndex(this.PanelFechas, 0);
                        this.PanelCombos.ResumeLayout(false);
                        this.PanelCombos.PerformLayout();
                        this.PanelFechas.ResumeLayout(false);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private Lui.Forms.ComboBox EntradaTipoDeRango;
                private Lui.Forms.TextBox EntradaDesde;
                private Lui.Forms.TextBox EntradaHasta;
                private Lui.Forms.ComboBox EntradaRango;
                private Lui.Forms.Label EtiquetaDesde;
                private Lui.Forms.Label EtiquetaHasta;
                private Lui.Forms.Panel PanelCombos;
                private Lui.Forms.Panel PanelFechas;
        }
}
