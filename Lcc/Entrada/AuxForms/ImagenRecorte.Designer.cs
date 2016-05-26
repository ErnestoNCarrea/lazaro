namespace Lcc.Entrada.AuxForms
{
        partial class ImagenRecorte
        {
                /// <summary>
                /// Variable del diseñador requerida.
                /// </summary>
                private System.ComponentModel.IContainer components = null;

                #region Código generado por el Diseñador de Windows Forms

                /// <summary>
                /// Método necesario para admitir el Diseñador. No se puede modificar
                /// el contenido del método con el editor de código.
                /// </summary>
                private void InitializeComponent()
                {
                        this.components = new System.ComponentModel.Container();
                        this.EntradaImagen = new System.Windows.Forms.PictureBox();
                        this.MenuEntradImagen = new System.Windows.Forms.ContextMenuStrip(this.components);
                        this.copiarAlPortapapelesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.guardarEnUnArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.label1 = new Lui.Forms.Label();
                        this.EntradaRatio = new Lui.Forms.ComboBox();
                        this.label2 = new Lui.Forms.Label();
                        this.BotonRotarDer = new Lui.Forms.Button();
                        this.BotonRotarIzq = new Lui.Forms.Button();
                        ((System.ComponentModel.ISupportInitialize)(this.EntradaImagen)).BeginInit();
                        this.MenuEntradImagen.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // EntradaImagen
                        // 
                        this.EntradaImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaImagen.ContextMenuStrip = this.MenuEntradImagen;
                        this.EntradaImagen.Location = new System.Drawing.Point(168, 64);
                        this.EntradaImagen.Name = "EntradaImagen";
                        this.EntradaImagen.Size = new System.Drawing.Size(438, 294);
                        this.EntradaImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        this.EntradaImagen.TabIndex = 0;
                        this.EntradaImagen.TabStop = false;
                        this.EntradaImagen.Paint += new System.Windows.Forms.PaintEventHandler(this.EntradaImagen_Paint);
                        this.EntradaImagen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EntradaImagen_MouseDown);
                        this.EntradaImagen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EntradaImagen_MouseMove);
                        this.EntradaImagen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EntradaImagen_MouseUp);
                        // 
                        // MenuEntradImagen
                        // 
                        this.MenuEntradImagen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copiarAlPortapapelesToolStripMenuItem,
            this.guardarEnUnArchivoToolStripMenuItem});
                        this.MenuEntradImagen.Name = "MenuEntradImagen";
                        this.MenuEntradImagen.Size = new System.Drawing.Size(193, 48);
                        // 
                        // copiarAlPortapapelesToolStripMenuItem
                        // 
                        this.copiarAlPortapapelesToolStripMenuItem.Name = "copiarAlPortapapelesToolStripMenuItem";
                        this.copiarAlPortapapelesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
                        this.copiarAlPortapapelesToolStripMenuItem.Text = "&Copiar al portapapeles";
                        this.copiarAlPortapapelesToolStripMenuItem.Click += new System.EventHandler(this.CopiarAlPortapapelesToolStripMenuItem_Click);
                        // 
                        // guardarEnUnArchivoToolStripMenuItem
                        // 
                        this.guardarEnUnArchivoToolStripMenuItem.Name = "guardarEnUnArchivoToolStripMenuItem";
                        this.guardarEnUnArchivoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
                        this.guardarEnUnArchivoToolStripMenuItem.Text = "&Guardar en un archivo";
                        this.guardarEnUnArchivoToolStripMenuItem.Click += new System.EventHandler(this.GuardarEnUnArchivoToolStripMenuItem_Click);
                        // 
                        // label1
                        // 
                        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label1.Location = new System.Drawing.Point(16, 16);
                        this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(590, 48);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "Arrastre el ratón desde la esquina superior izquierda para seleccionar el área de" +
    " la imagen a utilizar.";
                        // 
                        // EntradaRatio
                        // 
                        this.EntradaRatio.AlwaysExpanded = true;
                        this.EntradaRatio.Location = new System.Drawing.Point(16, 88);
                        this.EntradaRatio.Name = "EntradaRatio";
                        this.EntradaRatio.SetData = new string[] {
        "Sin recorte|-1",
        "Cuadrado (1:1)|1",
        "Rectangular 4:3|1.333333",
        "Rectangular 16:9|1.777777",
        "Rectangular 16:10|1.6",
        "Libre|0"};
                        this.EntradaRatio.Size = new System.Drawing.Size(136, 112);
                        this.EntradaRatio.TabIndex = 2;
                        this.EntradaRatio.TextKey = "0";
                        this.EntradaRatio.TextChanged += new System.EventHandler(this.EntradaRatio_TextChanged);
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(16, 64);
                        this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(136, 24);
                        this.label2.TabIndex = 1;
                        this.label2.Text = "Recorte";
                        // 
                        // BotonRotarDer
                        // 
                        this.BotonRotarDer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonRotarDer.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonRotarDer.ForeColor = System.Drawing.Color.Black;
                        this.BotonRotarDer.Image = null;
                        this.BotonRotarDer.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonRotarDer.Location = new System.Drawing.Point(16, 288);
                        this.BotonRotarDer.Name = "BotonRotarDer";
                        this.BotonRotarDer.Size = new System.Drawing.Size(136, 32);
                        this.BotonRotarDer.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonRotarDer.Subtext = "Tecla";
                        this.BotonRotarDer.TabIndex = 3;
                        this.BotonRotarDer.Text = "Rotar a la derecha";
                        this.BotonRotarDer.Click += new System.EventHandler(this.BotonRotarDer_Click);
                        // 
                        // BotonRotarIzq
                        // 
                        this.BotonRotarIzq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonRotarIzq.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonRotarIzq.ForeColor = System.Drawing.Color.Black;
                        this.BotonRotarIzq.Image = null;
                        this.BotonRotarIzq.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonRotarIzq.Location = new System.Drawing.Point(16, 328);
                        this.BotonRotarIzq.Name = "BotonRotarIzq";
                        this.BotonRotarIzq.Size = new System.Drawing.Size(136, 32);
                        this.BotonRotarIzq.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonRotarIzq.Subtext = "Tecla";
                        this.BotonRotarIzq.TabIndex = 4;
                        this.BotonRotarIzq.Text = "Rotar a la izquierda";
                        this.BotonRotarIzq.Click += new System.EventHandler(this.BotonRotarIzq_Click);
                        // 
                        // ImagenRecorte
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.AutoSize = true;
                        this.ClientSize = new System.Drawing.Size(624, 442);
                        this.Controls.Add(this.BotonRotarIzq);
                        this.Controls.Add(this.BotonRotarDer);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.EntradaRatio);
                        this.Controls.Add(this.EntradaImagen);
                        this.Controls.Add(this.label1);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                        this.MinimumSize = new System.Drawing.Size(480, 400);
                        this.Name = "ImagenRecorte";
                        this.ShowIcon = false;
                        this.ShowInTaskbar = false;
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        this.Text = "Recortar imagen";
                        this.Controls.SetChildIndex(this.label1, 0);
                        this.Controls.SetChildIndex(this.EntradaImagen, 0);
                        this.Controls.SetChildIndex(this.EntradaRatio, 0);
                        this.Controls.SetChildIndex(this.label2, 0);
                        this.Controls.SetChildIndex(this.BotonRotarDer, 0);
                        this.Controls.SetChildIndex(this.BotonRotarIzq, 0);
                        ((System.ComponentModel.ISupportInitialize)(this.EntradaImagen)).EndInit();
                        this.MenuEntradImagen.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.PictureBox EntradaImagen;
                private Lui.Forms.Label label1;
                private Lui.Forms.ComboBox EntradaRatio;
                private System.Windows.Forms.ContextMenuStrip MenuEntradImagen;
                private System.Windows.Forms.ToolStripMenuItem copiarAlPortapapelesToolStripMenuItem;
                private System.Windows.Forms.ToolStripMenuItem guardarEnUnArchivoToolStripMenuItem;
                private Lui.Forms.Label label2;
                private Lui.Forms.Button BotonRotarDer;
                private Lui.Forms.Button BotonRotarIzq;
        }
}
