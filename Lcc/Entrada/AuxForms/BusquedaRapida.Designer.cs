namespace Lcc.Entrada.AuxForms
{
        partial class BusquedaRapida
	{

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

		private System.ComponentModel.IContainer components = null;

		// NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
		// Puede modificarse utilizando el Diseñador de Windows Forms. 
		// No lo modifique con el editor de código.
		internal Lui.Forms.ListView Listado;
		internal System.Windows.Forms.ColumnHeader id;
		internal System.Windows.Forms.ColumnHeader nombre;
		internal Lui.Forms.TextBox EntradaBuscar;
		internal System.Windows.Forms.ColumnHeader extra1;
		internal Lui.Forms.Button BotonNuevo;
		internal System.Windows.Forms.Timer TimerRefrescar;
		internal System.Windows.Forms.ColumnHeader extra2;
		internal System.Windows.Forms.ColumnHeader extra3;
		internal System.Windows.Forms.ColumnHeader extra4;

		private void InitializeComponent()
		{
                        this.components = new System.ComponentModel.Container();
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusquedaRapida));
                        this.Listado = new Lui.Forms.ListView();
                        this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.extra1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.extra2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.extra3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.extra4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.EntradaBuscar = new Lui.Forms.TextBox();
                        this.BotonNuevo = new Lui.Forms.Button();
                        this.TimerRefrescar = new System.Windows.Forms.Timer(this.components);
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.EtiquetaResultados = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.EtiquetaSeleccionar = new Lui.Forms.Label();
                        this.pictureBox1 = new System.Windows.Forms.PictureBox();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // Listado
                        // 
                        this.Listado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Listado.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.Listado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.nombre,
            this.extra1,
            this.extra2,
            this.extra3,
            this.extra4});
                        this.Listado.FieldName = null;
                        this.Listado.FullRowSelect = true;
                        this.Listado.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.Listado.HideSelection = false;
                        this.Listado.LabelWrap = false;
                        this.Listado.Location = new System.Drawing.Point(24, 128);
                        this.Listado.MultiSelect = false;
                        this.Listado.Name = "Listado";
                        this.Listado.ReadOnly = false;
                        this.Listado.Size = new System.Drawing.Size(664, 269);
                        this.Listado.TabIndex = 3;
                        this.Listado.UseCompatibleStateImageBehavior = false;
                        this.Listado.View = System.Windows.Forms.View.Details;
                        this.Listado.SelectedIndexChanged += new System.EventHandler(this.Listado_SelectedIndexChanged);
                        this.Listado.DoubleClick += new System.EventHandler(this.Listado_DoubleClick);
                        this.Listado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Listado_KeyDown);
                        // 
                        // id
                        // 
                        this.id.Text = "Cód";
                        // 
                        // nombre
                        // 
                        this.nombre.Text = "Detalle";
                        this.nombre.Width = 300;
                        // 
                        // extra1
                        // 
                        this.extra1.Text = "";
                        this.extra1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.extra1.Width = 100;
                        // 
                        // extra2
                        // 
                        this.extra2.Text = "";
                        this.extra2.Width = 100;
                        // 
                        // extra3
                        // 
                        this.extra3.Text = "";
                        this.extra3.Width = 80;
                        // 
                        // extra4
                        // 
                        this.extra4.Text = "";
                        this.extra4.Width = 80;
                        // 
                        // EntradaBuscar
                        // 
                        this.EntradaBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaBuscar.AutoNav = false;
                        this.EntradaBuscar.Cursor = System.Windows.Forms.Cursors.Default;
                        this.EntradaBuscar.Location = new System.Drawing.Point(104, 64);
                        this.EntradaBuscar.Name = "EntradaBuscar";
                        this.EntradaBuscar.PlaceholderText = "¿Qué está buscando?";
                        this.EntradaBuscar.Size = new System.Drawing.Size(392, 24);
                        this.EntradaBuscar.TabIndex = 1;
                        this.EntradaBuscar.Text = "¿Qué está buscando?";
                        this.EntradaBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EntradaBuscar_KeyPress);
                        this.EntradaBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntradaBuscar_KeyDown);
                        this.EntradaBuscar.TextChanged += new System.EventHandler(this.EntradaBuscar_TextChanged);
                        // 
                        // BotonNuevo
                        // 
                        this.BotonNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonNuevo.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonNuevo.Image = null;
                        this.BotonNuevo.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonNuevo.Location = new System.Drawing.Point(592, 48);
                        this.BotonNuevo.Name = "BotonNuevo";
                        this.BotonNuevo.Size = new System.Drawing.Size(96, 40);
                        this.BotonNuevo.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.BotonNuevo.Subtext = "F6";
                        this.BotonNuevo.TabIndex = 4;
                        this.BotonNuevo.Text = "Crear";
                        this.BotonNuevo.Click += new System.EventHandler(this.BotonNuevo_Click);
                        // 
                        // TimerRefrescar
                        // 
                        this.TimerRefrescar.Interval = 1000;
                        this.TimerRefrescar.Tick += new System.EventHandler(this.TimerRefrescar_Tick);
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(96, 24);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(175, 30);
                        this.EtiquetaTitulo.TabIndex = 0;
                        this.EtiquetaTitulo.Text = "Búsqueda rápida";
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        this.EtiquetaTitulo.UseMnemonic = false;
                        // 
                        // EtiquetaResultados
                        // 
                        this.EtiquetaResultados.Location = new System.Drawing.Point(24, 104);
                        this.EtiquetaResultados.Name = "EtiquetaResultados";
                        this.EtiquetaResultados.Size = new System.Drawing.Size(664, 24);
                        this.EtiquetaResultados.TabIndex = 2;
                        this.EtiquetaResultados.Text = "Seleccione de la lista o utilice el cuadro de búsqueda.";
                        // 
                        // label2
                        // 
                        this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label2.Location = new System.Drawing.Point(24, 445);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(664, 32);
                        this.label2.TabIndex = 6;
                        this.label2.Text = resources.GetString("label2.Text");
                        this.label2.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        // 
                        // EtiquetaSeleccionar
                        // 
                        this.EtiquetaSeleccionar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaSeleccionar.Location = new System.Drawing.Point(122, 378);
                        this.EtiquetaSeleccionar.Name = "EtiquetaSeleccionar";
                        this.EtiquetaSeleccionar.Size = new System.Drawing.Size(475, 30);
                        this.EtiquetaSeleccionar.TabIndex = 8;
                        this.EtiquetaSeleccionar.Tag = "Pulse la tecla Entrar para seleccionar {0}.";
                        this.EtiquetaSeleccionar.Text = "Pulse la tecla Entrar para seleccionar {0}.";
                        this.EtiquetaSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.EtiquetaSeleccionar.UseMnemonic = false;
                        this.EtiquetaSeleccionar.Visible = false;
                        // 
                        // pictureBox1
                        // 
                        this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
                        this.pictureBox1.Location = new System.Drawing.Point(24, 24);
                        this.pictureBox1.Name = "pictureBox1";
                        this.pictureBox1.Size = new System.Drawing.Size(64, 64);
                        this.pictureBox1.TabIndex = 9;
                        this.pictureBox1.TabStop = false;
                        // 
                        // BusquedaRapida
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.ClientSize = new System.Drawing.Size(714, 496);
                        this.Controls.Add(this.pictureBox1);
                        this.Controls.Add(this.EtiquetaSeleccionar);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Controls.Add(this.BotonNuevo);
                        this.Controls.Add(this.EntradaBuscar);
                        this.Controls.Add(this.Listado);
                        this.Controls.Add(this.EtiquetaResultados);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.Name = "BusquedaRapida";
                        this.ShowInTaskbar = false;
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        this.Text = "Búsqueda rápida";
                        this.TopMost = true;
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

		}

                private Lui.Forms.Label EtiquetaTitulo;
                private Lui.Forms.Label EtiquetaResultados;
                private Lui.Forms.Label label2;
                private Lui.Forms.Label EtiquetaSeleccionar;
                private System.Windows.Forms.PictureBox pictureBox1;
	}
}
