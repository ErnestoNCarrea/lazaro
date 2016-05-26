namespace Lfc
{
        partial class FormularioListadoBase
        {
                /// <summary>
                /// Variable del diseñador requerida.
                /// </summary>
                private System.ComponentModel.IContainer components = null;

                /// <summary>
                /// Limpiar los recursos que se estén utilizando.
                /// </summary>
                /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
                protected override void Dispose(bool disposing)
                {
                        if (disposing && (components != null)) {
                                components.Dispose();
                        }
                        base.Dispose(disposing);
                }

                #region Código generado por el Diseñador de Windows Forms

                /// <summary>
                /// Método necesario para admitir el Diseñador. No se puede modificar
                /// el contenido del método con el editor de código.
                /// </summary>
                private void InitializeComponent()
                {
                        this.components = new System.ComponentModel.Container();
                        this.Listado = new Lui.Forms.ListView();
                        this.EtiquetaContador2 = new Lui.Forms.Label();
                        this.EntradaContador2 = new Lui.Forms.TextBox();
                        this.EtiquetaContador1 = new Lui.Forms.Label();
                        this.EntradaContador1 = new Lui.Forms.TextBox();
                        this.EtiquetaCantidad = new Lui.Forms.Label();
                        this.BotonImprimir = new Lui.Forms.Button();
                        this.BotonFiltrar = new Lui.Forms.Button();
                        this.BotonCancelar = new Lui.Forms.Button();
                        this.PanelContadores = new Lui.Forms.Panel();
                        this.EntradaContador4 = new Lui.Forms.TextBox();
                        this.EtiquetaContador4 = new Lui.Forms.Label();
                        this.EntradaContador3 = new Lui.Forms.TextBox();
                        this.EtiquetaContador3 = new Lui.Forms.Label();
                        this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
                        this.PicEsperar = new System.Windows.Forms.PictureBox();
                        this.PanelAcciones = new Lui.Forms.ButtonPanel();
                        this.PanelContadores.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).BeginInit();
                        this.PanelAcciones.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // Listado
                        // 
                        this.Listado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Listado.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.Listado.FullRowSelect = true;
                        this.Listado.HideSelection = false;
                        this.Listado.Location = new System.Drawing.Point(224, 0);
                        this.Listado.MultiSelect = false;
                        this.Listado.Name = "Listado";
                        this.Listado.Size = new System.Drawing.Size(640, 441);
                        this.Listado.TabIndex = 3;
                        this.Listado.UseCompatibleStateImageBehavior = false;
                        this.Listado.View = System.Windows.Forms.View.Details;
                        this.Listado.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.Listado_ColumnClick);
                        this.Listado.DoubleClick += new System.EventHandler(this.Listado_DoubleClick);
                        this.Listado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Listado_KeyDown);
                        // 
                        // EtiquetaContador2
                        // 
                        this.EtiquetaContador2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaContador2.Location = new System.Drawing.Point(0, 28);
                        this.EtiquetaContador2.Name = "EtiquetaContador2";
                        this.EtiquetaContador2.Size = new System.Drawing.Size(100, 24);
                        this.EtiquetaContador2.TabIndex = 63;
                        this.EtiquetaContador2.Text = "Contador2";
                        this.EtiquetaContador2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.EtiquetaContador2.UseMnemonic = false;
                        this.EtiquetaContador2.Visible = false;
                        // 
                        // EntradaContador2
                        // 
                        this.EntradaContador2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaContador2.Location = new System.Drawing.Point(100, 28);
                        this.EntradaContador2.Name = "EntradaContador2";
                        this.EntradaContador2.ReadOnly = true;
                        this.EntradaContador2.Size = new System.Drawing.Size(108, 24);
                        this.EntradaContador2.TabIndex = 62;
                        this.EntradaContador2.TabStop = false;
                        this.EntradaContador2.Visible = false;
                        // 
                        // EtiquetaContador1
                        // 
                        this.EtiquetaContador1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaContador1.Location = new System.Drawing.Point(0, 0);
                        this.EtiquetaContador1.Name = "EtiquetaContador1";
                        this.EtiquetaContador1.Size = new System.Drawing.Size(100, 24);
                        this.EtiquetaContador1.TabIndex = 61;
                        this.EtiquetaContador1.Text = "Contador 1";
                        this.EtiquetaContador1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.EtiquetaContador1.UseMnemonic = false;
                        this.EtiquetaContador1.Visible = false;
                        // 
                        // EntradaContador1
                        // 
                        this.EntradaContador1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaContador1.Location = new System.Drawing.Point(100, 0);
                        this.EntradaContador1.Name = "EntradaContador1";
                        this.EntradaContador1.ReadOnly = true;
                        this.EntradaContador1.Size = new System.Drawing.Size(108, 24);
                        this.EntradaContador1.TabIndex = 60;
                        this.EntradaContador1.TabStop = false;
                        this.EntradaContador1.Visible = false;
                        // 
                        // EtiquetaCantidad
                        // 
                        this.EtiquetaCantidad.AutoEllipsis = true;
                        this.EtiquetaCantidad.Location = new System.Drawing.Point(32, 192);
                        this.EtiquetaCantidad.Name = "EtiquetaCantidad";
                        this.EtiquetaCantidad.Size = new System.Drawing.Size(184, 40);
                        this.EtiquetaCantidad.TabIndex = 59;
                        this.EtiquetaCantidad.Text = "Cargando...";
                        this.EtiquetaCantidad.UseMnemonic = false;
                        // 
                        // BotonImprimir
                        // 
                        this.BotonImprimir.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.BotonImprimir.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonImprimir.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.BotonImprimir.Image = null;
                        this.BotonImprimir.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonImprimir.Location = new System.Drawing.Point(44, 91);
                        this.BotonImprimir.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
                        this.BotonImprimir.Name = "BotonImprimir";
                        this.BotonImprimir.Size = new System.Drawing.Size(136, 40);
                        this.BotonImprimir.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.BotonImprimir.Subtext = "F8";
                        this.BotonImprimir.TabIndex = 65;
                        this.BotonImprimir.Text = "Listado";
                        this.BotonImprimir.Click += new System.EventHandler(this.BotonImprimir_Click);
                        // 
                        // BotonFiltrar
                        // 
                        this.BotonFiltrar.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.BotonFiltrar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonFiltrar.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.BotonFiltrar.Image = null;
                        this.BotonFiltrar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonFiltrar.Location = new System.Drawing.Point(44, 45);
                        this.BotonFiltrar.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
                        this.BotonFiltrar.Name = "BotonFiltrar";
                        this.BotonFiltrar.Size = new System.Drawing.Size(136, 40);
                        this.BotonFiltrar.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.BotonFiltrar.Subtext = "F2";
                        this.BotonFiltrar.TabIndex = 64;
                        this.BotonFiltrar.Text = "Filtrar";
                        this.BotonFiltrar.Visible = false;
                        this.BotonFiltrar.Click += new System.EventHandler(this.BotonFiltrar_Click);
                        // 
                        // BotonCancelar
                        // 
                        this.BotonCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.BotonCancelar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.BotonCancelar.Image = null;
                        this.BotonCancelar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonCancelar.Location = new System.Drawing.Point(44, 137);
                        this.BotonCancelar.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
                        this.BotonCancelar.Name = "BotonCancelar";
                        this.BotonCancelar.Size = new System.Drawing.Size(136, 40);
                        this.BotonCancelar.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.BotonCancelar.Subtext = "Esc";
                        this.BotonCancelar.TabIndex = 66;
                        this.BotonCancelar.Text = "Volver";
                        this.BotonCancelar.Click += new System.EventHandler(this.BotonCancelar_Click);
                        // 
                        // PanelContadores
                        // 
                        this.PanelContadores.Controls.Add(this.EntradaContador4);
                        this.PanelContadores.Controls.Add(this.EtiquetaContador4);
                        this.PanelContadores.Controls.Add(this.EntradaContador3);
                        this.PanelContadores.Controls.Add(this.EtiquetaContador3);
                        this.PanelContadores.Controls.Add(this.EntradaContador1);
                        this.PanelContadores.Controls.Add(this.EntradaContador2);
                        this.PanelContadores.Controls.Add(this.EtiquetaContador1);
                        this.PanelContadores.Controls.Add(this.EtiquetaContador2);
                        this.PanelContadores.Location = new System.Drawing.Point(8, 72);
                        this.PanelContadores.Name = "PanelContadores";
                        this.PanelContadores.Size = new System.Drawing.Size(208, 108);
                        this.PanelContadores.TabIndex = 67;
                        // 
                        // EntradaContador4
                        // 
                        this.EntradaContador4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaContador4.Location = new System.Drawing.Point(100, 84);
                        this.EntradaContador4.Name = "EntradaContador4";
                        this.EntradaContador4.ReadOnly = true;
                        this.EntradaContador4.Size = new System.Drawing.Size(108, 24);
                        this.EntradaContador4.TabIndex = 66;
                        this.EntradaContador4.TabStop = false;
                        this.EntradaContador4.Visible = false;
                        // 
                        // EtiquetaContador4
                        // 
                        this.EtiquetaContador4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaContador4.Location = new System.Drawing.Point(0, 84);
                        this.EtiquetaContador4.Name = "EtiquetaContador4";
                        this.EtiquetaContador4.Size = new System.Drawing.Size(100, 24);
                        this.EtiquetaContador4.TabIndex = 67;
                        this.EtiquetaContador4.Text = "Contador2";
                        this.EtiquetaContador4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.EtiquetaContador4.UseMnemonic = false;
                        this.EtiquetaContador4.Visible = false;
                        // 
                        // EntradaContador3
                        // 
                        this.EntradaContador3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaContador3.Location = new System.Drawing.Point(100, 56);
                        this.EntradaContador3.Name = "EntradaContador3";
                        this.EntradaContador3.ReadOnly = true;
                        this.EntradaContador3.Size = new System.Drawing.Size(108, 24);
                        this.EntradaContador3.TabIndex = 64;
                        this.EntradaContador3.TabStop = false;
                        this.EntradaContador3.Visible = false;
                        // 
                        // EtiquetaContador3
                        // 
                        this.EtiquetaContador3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaContador3.Location = new System.Drawing.Point(0, 56);
                        this.EtiquetaContador3.Name = "EtiquetaContador3";
                        this.EtiquetaContador3.Size = new System.Drawing.Size(100, 24);
                        this.EtiquetaContador3.TabIndex = 65;
                        this.EtiquetaContador3.Text = "Contador2";
                        this.EtiquetaContador3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.EtiquetaContador3.UseMnemonic = false;
                        this.EtiquetaContador3.Visible = false;
                        // 
                        // RefreshTimer
                        // 
                        this.RefreshTimer.Interval = 50;
                        this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
                        // 
                        // PicEsperar
                        // 
                        this.PicEsperar.Image = global::Lfc.Properties.Resources.ajax_loader;
                        this.PicEsperar.Location = new System.Drawing.Point(8, 196);
                        this.PicEsperar.Name = "PicEsperar";
                        this.PicEsperar.Size = new System.Drawing.Size(16, 16);
                        this.PicEsperar.TabIndex = 68;
                        this.PicEsperar.TabStop = false;
                        // 
                        // PanelAcciones
                        // 
                        this.PanelAcciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
                        this.PanelAcciones.Controls.Add(this.BotonCancelar);
                        this.PanelAcciones.Controls.Add(this.BotonImprimir);
                        this.PanelAcciones.Controls.Add(this.BotonFiltrar);
                        this.PanelAcciones.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
                        this.PanelAcciones.Location = new System.Drawing.Point(0, 240);
                        this.PanelAcciones.Name = "PanelAcciones";
                        this.PanelAcciones.Padding = new System.Windows.Forms.Padding(44, 12, 44, 12);
                        this.PanelAcciones.Size = new System.Drawing.Size(224, 201);
                        this.PanelAcciones.TabIndex = 4;
                        // 
                        // FormularioListadoBase
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                        this.ClientSize = new System.Drawing.Size(864, 441);
                        this.Controls.Add(this.PanelAcciones);
                        this.Controls.Add(this.PicEsperar);
                        this.Controls.Add(this.PanelContadores);
                        this.Controls.Add(this.Listado);
                        this.Controls.Add(this.EtiquetaCantidad);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.MinimumSize = new System.Drawing.Size(640, 400);
                        this.Name = "FormularioListadoBase";
                        this.Text = "FormularioListadoBase";
                        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormularioListadoBase_FormClosing);
                        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormularioListadoBase_KeyDown);
                        this.PanelContadores.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).EndInit();
                        this.PanelAcciones.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                public Lui.Forms.ListView Listado;
                protected Lui.Forms.Label EtiquetaContador2;
                protected Lui.Forms.TextBox EntradaContador2;
                protected Lui.Forms.Label EtiquetaContador1;
                protected Lui.Forms.TextBox EntradaContador1;
                protected Lui.Forms.Label EtiquetaCantidad;
                protected Lui.Forms.Button BotonImprimir;
                protected Lui.Forms.Button BotonFiltrar;
                protected Lui.Forms.Button BotonCancelar;
                protected Lui.Forms.Panel PanelContadores;
                protected Lui.Forms.TextBox EntradaContador4;
                protected Lui.Forms.Label EtiquetaContador4;
                protected Lui.Forms.TextBox EntradaContador3;
                protected Lui.Forms.Label EtiquetaContador3;
                protected System.Windows.Forms.Timer RefreshTimer;
                protected System.Windows.Forms.PictureBox PicEsperar;
                protected Lui.Forms.ButtonPanel PanelAcciones;
        }
}
