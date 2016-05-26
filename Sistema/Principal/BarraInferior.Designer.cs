namespace Lazaro.WinMain.Principal
{
        partial class BarraInferior
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
                        if (m_DataBase != null)
                                m_DataBase.Dispose();
                        if (disposing && (components != null)) {
                                components.Dispose();
                        }
                        base.Dispose(disposing);
                }

                #region Código generado por el Diseñador de componentes

                /// <summary> 
                /// Método necesario para admitir el Diseñador. No se puede modificar
                /// el contenido del método con el editor de código.
                /// </summary>
                private void InitializeComponent()
                {
                        this.components = new System.ComponentModel.Container();
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarraInferior));
                        this.PanelReloj = new Lui.Forms.Panel();
                        this.RelojFecha = new Lui.Forms.Label();
                        this.RelojHora = new Lui.Forms.Label();
                        this.PanelArticulo = new Lui.Forms.Panel();
                        this.ArticuloStock = new Lui.Forms.Label();
                        this.label5 = new Lui.Forms.Label();
                        this.ArticuloPvp = new Lui.Forms.Label();
                        this.ArticuloPrecio = new Lui.Forms.Label();
                        this.ArticuloDescripcion = new Lui.Forms.Label();
                        this.ArticuloCodigos = new Lui.Forms.Label();
                        this.ArticuloNombre = new Lui.Forms.LinkLabel();
                        this.PanelAyuda = new Lui.Forms.Panel();
                        this.pictureBox1 = new System.Windows.Forms.PictureBox();
                        this.AyudaTitulo = new Lui.Forms.Label();
                        this.AyudaTexto = new Lui.Forms.Label();
                        this.ProgressBar = new System.Windows.Forms.ProgressBar();
                        this.TimerReloj = new System.Windows.Forms.Timer(this.components);
                        this.PanelPersona = new Lui.Forms.Panel();
                        this.PersonaNombre = new Lui.Forms.LinkLabel();
                        this.PersonaImagen = new System.Windows.Forms.PictureBox();
                        this.EnlaceComentarios = new Lui.Forms.LinkLabel();
                        this.label3 = new Lui.Forms.Label();
                        this.PersonaGrupo = new Lui.Forms.Label();
                        this.PersonaComentario = new Lui.Forms.Label();
                        this.label1 = new Lui.Forms.Label();
                        this.PersonaEmail = new Lui.Forms.Label();
                        this.label4 = new Lui.Forms.Label();
                        this.PersonaDomicilio = new Lui.Forms.Label();
                        this.PersonaTelefono = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.TimerSlowLink = new System.Windows.Forms.Timer(this.components);
                        this.PanelProgreso = new Lui.Forms.Panel();
                        this.pictureBox2 = new System.Windows.Forms.PictureBox();
                        this.EtiquetaDescripcion = new Lui.Forms.Label();
                        this.EtiquetaOperacion = new Lui.Forms.Label();
                        this.PanelReloj.SuspendLayout();
                        this.PanelArticulo.SuspendLayout();
                        this.PanelAyuda.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                        this.PanelPersona.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.PersonaImagen)).BeginInit();
                        this.PanelProgreso.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // PanelReloj
                        // 
                        this.PanelReloj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.PanelReloj.BackColor = System.Drawing.Color.Beige;
                        this.PanelReloj.Controls.Add(this.RelojFecha);
                        this.PanelReloj.Controls.Add(this.RelojHora);
                        this.PanelReloj.Location = new System.Drawing.Point(924, 2);
                        this.PanelReloj.Name = "PanelReloj";
                        this.PanelReloj.Size = new System.Drawing.Size(74, 48);
                        this.PanelReloj.TabIndex = 0;
                        // 
                        // RelojFecha
                        // 
                        this.RelojFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.RelojFecha.Location = new System.Drawing.Point(2, 30);
                        this.RelojFecha.Name = "RelojFecha";
                        this.RelojFecha.Size = new System.Drawing.Size(70, 16);
                        this.RelojFecha.TabIndex = 1;
                        this.RelojFecha.Text = "00/00/00";
                        this.RelojFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.RelojFecha.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.RelojFecha.UseMnemonic = false;
                        // 
                        // RelojHora
                        // 
                        this.RelojHora.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.RelojHora.Location = new System.Drawing.Point(2, 2);
                        this.RelojHora.Name = "RelojHora";
                        this.RelojHora.Size = new System.Drawing.Size(70, 26);
                        this.RelojHora.TabIndex = 0;
                        this.RelojHora.Text = "00:00";
                        this.RelojHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.RelojHora.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Bigger;
                        this.RelojHora.UseMnemonic = false;
                        // 
                        // PanelArticulo
                        // 
                        this.PanelArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.PanelArticulo.Controls.Add(this.ArticuloStock);
                        this.PanelArticulo.Controls.Add(this.label5);
                        this.PanelArticulo.Controls.Add(this.ArticuloPvp);
                        this.PanelArticulo.Controls.Add(this.ArticuloPrecio);
                        this.PanelArticulo.Controls.Add(this.ArticuloDescripcion);
                        this.PanelArticulo.Controls.Add(this.ArticuloCodigos);
                        this.PanelArticulo.Controls.Add(this.ArticuloNombre);
                        this.PanelArticulo.Location = new System.Drawing.Point(2, 2);
                        this.PanelArticulo.Name = "PanelArticulo";
                        this.PanelArticulo.Size = new System.Drawing.Size(920, 48);
                        this.PanelArticulo.TabIndex = 1;
                        this.PanelArticulo.Visible = false;
                        // 
                        // ArticuloStock
                        // 
                        this.ArticuloStock.AutoEllipsis = true;
                        this.ArticuloStock.Location = new System.Drawing.Point(536, 0);
                        this.ArticuloStock.Name = "ArticuloStock";
                        this.ArticuloStock.Size = new System.Drawing.Size(80, 16);
                        this.ArticuloStock.TabIndex = 6;
                        this.ArticuloStock.Text = "12.345.67";
                        this.ArticuloStock.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.ArticuloStock.UseMnemonic = false;
                        // 
                        // label5
                        // 
                        this.label5.AutoEllipsis = true;
                        this.label5.Location = new System.Drawing.Point(496, 0);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(42, 16);
                        this.label5.TabIndex = 5;
                        this.label5.Text = "Stock";
                        this.label5.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.label5.UseMnemonic = false;
                        // 
                        // ArticuloPvp
                        // 
                        this.ArticuloPvp.AutoEllipsis = true;
                        this.ArticuloPvp.Location = new System.Drawing.Point(416, 0);
                        this.ArticuloPvp.Name = "ArticuloPvp";
                        this.ArticuloPvp.Size = new System.Drawing.Size(80, 16);
                        this.ArticuloPvp.TabIndex = 4;
                        this.ArticuloPvp.Text = "12.345.67";
                        this.ArticuloPvp.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.ArticuloPvp.UseMnemonic = false;
                        // 
                        // ArticuloPrecio
                        // 
                        this.ArticuloPrecio.AutoEllipsis = true;
                        this.ArticuloPrecio.Location = new System.Drawing.Point(388, 0);
                        this.ArticuloPrecio.Name = "ArticuloPrecio";
                        this.ArticuloPrecio.Size = new System.Drawing.Size(30, 16);
                        this.ArticuloPrecio.TabIndex = 3;
                        this.ArticuloPrecio.Text = "PVP";
                        this.ArticuloPrecio.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.ArticuloPrecio.UseMnemonic = false;
                        // 
                        // ArticuloDescripcion
                        // 
                        this.ArticuloDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.ArticuloDescripcion.AutoEllipsis = true;
                        this.ArticuloDescripcion.Location = new System.Drawing.Point(70, 16);
                        this.ArticuloDescripcion.Name = "ArticuloDescripcion";
                        this.ArticuloDescripcion.Size = new System.Drawing.Size(850, 32);
                        this.ArticuloDescripcion.TabIndex = 2;
                        this.ArticuloDescripcion.Text = "Ejemplo de descripción de artículo";
                        this.ArticuloDescripcion.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.ArticuloDescripcion.UseMnemonic = false;
                        // 
                        // ArticuloCodigos
                        // 
                        this.ArticuloCodigos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
                        this.ArticuloCodigos.Location = new System.Drawing.Point(0, 0);
                        this.ArticuloCodigos.Name = "ArticuloCodigos";
                        this.ArticuloCodigos.Size = new System.Drawing.Size(68, 48);
                        this.ArticuloCodigos.TabIndex = 0;
                        this.ArticuloCodigos.Text = "00000000";
                        this.ArticuloCodigos.TextAlign = System.Drawing.ContentAlignment.TopRight;
                        this.ArticuloCodigos.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.ArticuloCodigos.UseMnemonic = false;
                        // 
                        // ArticuloNombre
                        // 
                        this.ArticuloNombre.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
                        this.ArticuloNombre.AutoEllipsis = true;
                        this.ArticuloNombre.AutoSize = true;
                        this.ArticuloNombre.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.ArticuloNombre.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
                        this.ArticuloNombre.Location = new System.Drawing.Point(70, 0);
                        this.ArticuloNombre.Name = "ArticuloNombre";
                        this.ArticuloNombre.Size = new System.Drawing.Size(196, 17);
                        this.ArticuloNombre.TabIndex = 7;
                        this.ArticuloNombre.TabStop = true;
                        this.ArticuloNombre.Text = "Nombre del artículo de ejemplo";
                        this.ArticuloNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.ArticuloNombre.UseMnemonic = false;
                        this.ArticuloNombre.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ArticuloNombre_LinkClicked);
                        // 
                        // PanelAyuda
                        // 
                        this.PanelAyuda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.PanelAyuda.Controls.Add(this.pictureBox1);
                        this.PanelAyuda.Controls.Add(this.AyudaTitulo);
                        this.PanelAyuda.Controls.Add(this.AyudaTexto);
                        this.PanelAyuda.Location = new System.Drawing.Point(2, 2);
                        this.PanelAyuda.Name = "PanelAyuda";
                        this.PanelAyuda.Size = new System.Drawing.Size(920, 48);
                        this.PanelAyuda.TabIndex = 2;
                        // 
                        // pictureBox1
                        // 
                        this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
                        this.pictureBox1.Location = new System.Drawing.Point(0, 0);
                        this.pictureBox1.Name = "pictureBox1";
                        this.pictureBox1.Size = new System.Drawing.Size(48, 48);
                        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        this.pictureBox1.TabIndex = 2;
                        this.pictureBox1.TabStop = false;
                        // 
                        // AyudaTitulo
                        // 
                        this.AyudaTitulo.Location = new System.Drawing.Point(52, 0);
                        this.AyudaTitulo.Name = "AyudaTitulo";
                        this.AyudaTitulo.Size = new System.Drawing.Size(670, 28);
                        this.AyudaTitulo.TabIndex = 0;
                        this.AyudaTitulo.Text = "Ayuda dinámica";
                        this.AyudaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        this.AyudaTitulo.UseMnemonic = false;
                        // 
                        // AyudaTexto
                        // 
                        this.AyudaTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.AyudaTexto.Location = new System.Drawing.Point(52, 28);
                        this.AyudaTexto.Name = "AyudaTexto";
                        this.AyudaTexto.Size = new System.Drawing.Size(870, 20);
                        this.AyudaTexto.TabIndex = 1;
                        this.AyudaTexto.Text = "...";
                        this.AyudaTexto.UseMnemonic = false;
                        // 
                        // ProgressBar
                        // 
                        this.ProgressBar.Location = new System.Drawing.Point(60, 12);
                        this.ProgressBar.Name = "ProgressBar";
                        this.ProgressBar.Size = new System.Drawing.Size(212, 24);
                        this.ProgressBar.TabIndex = 3;
                        // 
                        // TimerReloj
                        // 
                        this.TimerReloj.Enabled = true;
                        this.TimerReloj.Interval = 1000;
                        this.TimerReloj.Tick += new System.EventHandler(this.TimerReloj_Tick);
                        // 
                        // PanelPersona
                        // 
                        this.PanelPersona.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.PanelPersona.Controls.Add(this.PersonaNombre);
                        this.PanelPersona.Controls.Add(this.PersonaImagen);
                        this.PanelPersona.Controls.Add(this.EnlaceComentarios);
                        this.PanelPersona.Controls.Add(this.label3);
                        this.PanelPersona.Controls.Add(this.PersonaGrupo);
                        this.PanelPersona.Controls.Add(this.PersonaComentario);
                        this.PanelPersona.Controls.Add(this.label1);
                        this.PanelPersona.Controls.Add(this.PersonaEmail);
                        this.PanelPersona.Controls.Add(this.label4);
                        this.PanelPersona.Controls.Add(this.PersonaDomicilio);
                        this.PanelPersona.Controls.Add(this.PersonaTelefono);
                        this.PanelPersona.Controls.Add(this.label2);
                        this.PanelPersona.Location = new System.Drawing.Point(2, 2);
                        this.PanelPersona.Name = "PanelPersona";
                        this.PanelPersona.Size = new System.Drawing.Size(918, 48);
                        this.PanelPersona.TabIndex = 2;
                        // 
                        // PersonaNombre
                        // 
                        this.PersonaNombre.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
                        this.PersonaNombre.AutoSize = true;
                        this.PersonaNombre.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.PersonaNombre.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
                        this.PersonaNombre.Location = new System.Drawing.Point(53, 3);
                        this.PersonaNombre.MaximumSize = new System.Drawing.Size(250, 16);
                        this.PersonaNombre.Name = "PersonaNombre";
                        this.PersonaNombre.Size = new System.Drawing.Size(212, 16);
                        this.PersonaNombre.TabIndex = 12;
                        this.PersonaNombre.TabStop = true;
                        this.PersonaNombre.Text = "Nombre de la persona de ejemplo";
                        this.PersonaNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.PersonaNombre.UseMnemonic = false;
                        this.PersonaNombre.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PersonaNombre_LinkClicked);
                        // 
                        // PersonaImagen
                        // 
                        this.PersonaImagen.Location = new System.Drawing.Point(0, 0);
                        this.PersonaImagen.Name = "PersonaImagen";
                        this.PersonaImagen.Size = new System.Drawing.Size(52, 48);
                        this.PersonaImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        this.PersonaImagen.TabIndex = 15;
                        this.PersonaImagen.TabStop = false;
                        // 
                        // EnlaceComentarios
                        // 
                        this.EnlaceComentarios.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
                        this.EnlaceComentarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.EnlaceComentarios.AutoEllipsis = true;
                        this.EnlaceComentarios.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.EnlaceComentarios.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
                        this.EnlaceComentarios.Location = new System.Drawing.Point(812, 32);
                        this.EnlaceComentarios.Name = "EnlaceComentarios";
                        this.EnlaceComentarios.Size = new System.Drawing.Size(106, 16);
                        this.EnlaceComentarios.TabIndex = 14;
                        this.EnlaceComentarios.TabStop = true;
                        this.EnlaceComentarios.Text = "Comentarios...";
                        this.EnlaceComentarios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.EnlaceComentarios.UseMnemonic = false;
                        this.EnlaceComentarios.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.EnlaceEtiquetas_LinkClicked);
                        // 
                        // label3
                        // 
                        this.label3.AutoEllipsis = true;
                        this.label3.Location = new System.Drawing.Point(351, 33);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(62, 16);
                        this.label3.TabIndex = 10;
                        this.label3.Text = "Grupo";
                        this.label3.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.label3.UseMnemonic = false;
                        // 
                        // PersonaGrupo
                        // 
                        this.PersonaGrupo.AutoEllipsis = true;
                        this.PersonaGrupo.Location = new System.Drawing.Point(411, 31);
                        this.PersonaGrupo.Name = "PersonaGrupo";
                        this.PersonaGrupo.Size = new System.Drawing.Size(232, 16);
                        this.PersonaGrupo.TabIndex = 11;
                        this.PersonaGrupo.Text = "-";
                        this.PersonaGrupo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.PersonaGrupo.UseMnemonic = false;
                        // 
                        // PersonaComentario
                        // 
                        this.PersonaComentario.AutoEllipsis = true;
                        this.PersonaComentario.Location = new System.Drawing.Point(54, 16);
                        this.PersonaComentario.Name = "PersonaComentario";
                        this.PersonaComentario.Size = new System.Drawing.Size(291, 32);
                        this.PersonaComentario.TabIndex = 9;
                        this.PersonaComentario.Text = "Registra saldo impago en cta. cte. por $ 10000";
                        this.PersonaComentario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.PersonaComentario.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.SmallWarning;
                        this.PersonaComentario.UseMnemonic = false;
                        this.PersonaComentario.Visible = false;
                        // 
                        // label1
                        // 
                        this.label1.AutoEllipsis = true;
                        this.label1.Location = new System.Drawing.Point(351, 17);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(62, 16);
                        this.label1.TabIndex = 8;
                        this.label1.Text = "Correo-e";
                        this.label1.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.label1.UseMnemonic = false;
                        // 
                        // PersonaEmail
                        // 
                        this.PersonaEmail.AutoEllipsis = true;
                        this.PersonaEmail.Location = new System.Drawing.Point(411, 17);
                        this.PersonaEmail.Name = "PersonaEmail";
                        this.PersonaEmail.Size = new System.Drawing.Size(232, 16);
                        this.PersonaEmail.TabIndex = 9;
                        this.PersonaEmail.Text = "info@dominio.com";
                        this.PersonaEmail.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.PersonaEmail.UseMnemonic = false;
                        // 
                        // label4
                        // 
                        this.label4.AutoEllipsis = true;
                        this.label4.Location = new System.Drawing.Point(351, 1);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(62, 16);
                        this.label4.TabIndex = 3;
                        this.label4.Text = "Domicilio";
                        this.label4.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.label4.UseMnemonic = false;
                        // 
                        // PersonaDomicilio
                        // 
                        this.PersonaDomicilio.AutoEllipsis = true;
                        this.PersonaDomicilio.Location = new System.Drawing.Point(411, 1);
                        this.PersonaDomicilio.Name = "PersonaDomicilio";
                        this.PersonaDomicilio.Size = new System.Drawing.Size(232, 16);
                        this.PersonaDomicilio.TabIndex = 4;
                        this.PersonaDomicilio.Text = "12.345.67";
                        this.PersonaDomicilio.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.PersonaDomicilio.UseMnemonic = false;
                        // 
                        // PersonaTelefono
                        // 
                        this.PersonaTelefono.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.PersonaTelefono.AutoEllipsis = true;
                        this.PersonaTelefono.Location = new System.Drawing.Point(700, 0);
                        this.PersonaTelefono.Name = "PersonaTelefono";
                        this.PersonaTelefono.Size = new System.Drawing.Size(218, 16);
                        this.PersonaTelefono.TabIndex = 6;
                        this.PersonaTelefono.Text = "01234 555-12364";
                        this.PersonaTelefono.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.PersonaTelefono.UseMnemonic = false;
                        // 
                        // label2
                        // 
                        this.label2.AutoEllipsis = true;
                        this.label2.Location = new System.Drawing.Point(642, 0);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(64, 16);
                        this.label2.TabIndex = 5;
                        this.label2.Text = "Tel.";
                        this.label2.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.label2.UseMnemonic = false;
                        // 
                        // TimerSlowLink
                        // 
                        this.TimerSlowLink.Interval = 1000;
                        this.TimerSlowLink.Tick += new System.EventHandler(this.TimerSlowLink_Tick);
                        // 
                        // PanelProgreso
                        // 
                        this.PanelProgreso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.PanelProgreso.Controls.Add(this.pictureBox2);
                        this.PanelProgreso.Controls.Add(this.EtiquetaDescripcion);
                        this.PanelProgreso.Controls.Add(this.ProgressBar);
                        this.PanelProgreso.Controls.Add(this.EtiquetaOperacion);
                        this.PanelProgreso.Location = new System.Drawing.Point(2, 2);
                        this.PanelProgreso.Name = "PanelProgreso";
                        this.PanelProgreso.Size = new System.Drawing.Size(920, 48);
                        this.PanelProgreso.TabIndex = 3;
                        this.PanelProgreso.Visible = false;
                        // 
                        // pictureBox2
                        // 
                        this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
                        this.pictureBox2.Location = new System.Drawing.Point(0, 0);
                        this.pictureBox2.Name = "pictureBox2";
                        this.pictureBox2.Size = new System.Drawing.Size(48, 48);
                        this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        this.pictureBox2.TabIndex = 6;
                        this.pictureBox2.TabStop = false;
                        // 
                        // EtiquetaDescripcion
                        // 
                        this.EtiquetaDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaDescripcion.Location = new System.Drawing.Point(284, 28);
                        this.EtiquetaDescripcion.Name = "EtiquetaDescripcion";
                        this.EtiquetaDescripcion.Size = new System.Drawing.Size(637, 20);
                        this.EtiquetaDescripcion.TabIndex = 5;
                        this.EtiquetaDescripcion.Text = "...";
                        this.EtiquetaDescripcion.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.EtiquetaDescripcion.UseMnemonic = false;
                        // 
                        // EtiquetaOperacion
                        // 
                        this.EtiquetaOperacion.Location = new System.Drawing.Point(284, 0);
                        this.EtiquetaOperacion.Name = "EtiquetaOperacion";
                        this.EtiquetaOperacion.Size = new System.Drawing.Size(636, 28);
                        this.EtiquetaOperacion.TabIndex = 4;
                        this.EtiquetaOperacion.Text = "Progreso...";
                        this.EtiquetaOperacion.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        this.EtiquetaOperacion.UseMnemonic = false;
                        // 
                        // BarraInferior
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                        this.Controls.Add(this.PanelProgreso);
                        this.Controls.Add(this.PanelReloj);
                        this.Controls.Add(this.PanelArticulo);
                        this.Controls.Add(this.PanelPersona);
                        this.Controls.Add(this.PanelAyuda);
                        this.Name = "BarraInferior";
                        this.Size = new System.Drawing.Size(1000, 52);
                        this.PanelReloj.ResumeLayout(false);
                        this.PanelArticulo.ResumeLayout(false);
                        this.PanelArticulo.PerformLayout();
                        this.PanelAyuda.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                        this.PanelPersona.ResumeLayout(false);
                        this.PanelPersona.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.PersonaImagen)).EndInit();
                        this.PanelProgreso.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private Lui.Forms.Panel PanelReloj;
                private Lui.Forms.Label RelojFecha;
                private Lui.Forms.Label RelojHora;
                private Lui.Forms.Panel PanelArticulo;
                private Lui.Forms.Label ArticuloCodigos;
                private Lui.Forms.LinkLabel ArticuloNombre;
                private Lui.Forms.Label ArticuloStock;
                private Lui.Forms.Label label5;
                private Lui.Forms.Label ArticuloPvp;
                private Lui.Forms.Label ArticuloPrecio;
                private Lui.Forms.Label ArticuloDescripcion;
                private System.Windows.Forms.Timer TimerReloj;
                private Lui.Forms.Panel PanelAyuda;
                private Lui.Forms.Label AyudaTexto;
                private Lui.Forms.Label AyudaTitulo;
                private Lui.Forms.Label PersonaTelefono;
                private Lui.Forms.Label label2;
                private Lui.Forms.Label PersonaDomicilio;
                private Lui.Forms.Label label4;
                private Lui.Forms.Panel PanelPersona;
                private Lui.Forms.Label label1;
                private Lui.Forms.Label PersonaEmail;
                private Lui.Forms.Label PersonaComentario;
                private Lui.Forms.Label label3;
                private Lui.Forms.Label PersonaGrupo;
                private System.Windows.Forms.PictureBox pictureBox1;
                private Lui.Forms.LinkLabel PersonaNombre;
                private System.Windows.Forms.Timer TimerSlowLink;
                private Lui.Forms.LinkLabel EnlaceComentarios;
                private System.Windows.Forms.PictureBox PersonaImagen;
                internal System.Windows.Forms.ProgressBar ProgressBar;
                private Lui.Forms.Panel PanelProgreso;
                private System.Windows.Forms.PictureBox pictureBox2;
                private Lui.Forms.Label EtiquetaOperacion;
                private Lui.Forms.Label EtiquetaDescripcion;
        }
}
