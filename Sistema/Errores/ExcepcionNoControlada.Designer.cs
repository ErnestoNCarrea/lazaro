namespace Lazaro.WinMain.Errores
{
        partial class ExcepcionNoControlada
        {
                private System.ComponentModel.IContainer components = null;

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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcepcionNoControlada));
                        this.PicDiablito = new System.Windows.Forms.PictureBox();
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.EtiquetaDescripcion = new Lui.Forms.Label();
                        this.BotonCerrar = new Lui.Forms.Button();
                        this.label1 = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.linkLabel1 = new Lui.Forms.LinkLabel();
                        ((System.ComponentModel.ISupportInitialize)(this.PicDiablito)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // PicDiablito
                        // 
                        this.PicDiablito.Image = ((System.Drawing.Image)(resources.GetObject("PicDiablito.Image")));
                        this.PicDiablito.Location = new System.Drawing.Point(24, 24);
                        this.PicDiablito.Name = "PicDiablito";
                        this.PicDiablito.Size = new System.Drawing.Size(36, 40);
                        this.PicDiablito.TabIndex = 0;
                        this.PicDiablito.TabStop = false;
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(80, 24);
                        this.EtiquetaTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(432, 32);
                        this.EtiquetaTitulo.TabIndex = 1;
                        this.EtiquetaTitulo.Text = "Reporte de error";
                        this.EtiquetaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        // 
                        // EtiquetaDescripcion
                        // 
                        this.EtiquetaDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaDescripcion.Location = new System.Drawing.Point(80, 184);
                        this.EtiquetaDescripcion.Name = "EtiquetaDescripcion";
                        this.EtiquetaDescripcion.Size = new System.Drawing.Size(424, 44);
                        this.EtiquetaDescripcion.TabIndex = 5;
                        this.EtiquetaDescripcion.Text = "Por favor aguarde mientras se genera un reporte.";
                        // 
                        // BotonCerrar
                        // 
                        this.BotonCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonCerrar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonCerrar.Enabled = false;
                        this.BotonCerrar.Image = null;
                        this.BotonCerrar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonCerrar.Location = new System.Drawing.Point(392, 232);
                        this.BotonCerrar.Name = "BotonCerrar";
                        this.BotonCerrar.Size = new System.Drawing.Size(112, 40);
                        this.BotonCerrar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonCerrar.Subtext = "Tecla";
                        this.BotonCerrar.TabIndex = 0;
                        this.BotonCerrar.Text = "Continuar";
                        this.BotonCerrar.Click += new System.EventHandler(this.BotonCerrar_Click);
                        // 
                        // label1
                        // 
                        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label1.Location = new System.Drawing.Point(80, 64);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(432, 24);
                        this.label1.TabIndex = 2;
                        this.label1.Text = "Lázaro encontró un problema y está generando un reporte.";
                        // 
                        // label2
                        // 
                        this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label2.Location = new System.Drawing.Point(80, 96);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(432, 48);
                        this.label2.TabIndex = 3;
                        this.label2.Text = "Por favor cierre el sistema y vuelva a intentar la operación nuevamente. Si el pr" +
    "oblema persiste, puede ingresar al foro de soporte:";
                        // 
                        // linkLabel1
                        // 
                        this.linkLabel1.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
                        this.linkLabel1.AutoSize = true;
                        this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
                        this.linkLabel1.Location = new System.Drawing.Point(80, 152);
                        this.linkLabel1.Name = "linkLabel1";
                        this.linkLabel1.Size = new System.Drawing.Size(196, 17);
                        this.linkLabel1.TabIndex = 4;
                        this.linkLabel1.TabStop = true;
                        this.linkLabel1.Text = "www.lazarogestion.com/soporte";
                        this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
                        // 
                        // ExcepcionNoControlada
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(537, 297);
                        this.ControlBox = false;
                        this.Controls.Add(this.linkLabel1);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.BotonCerrar);
                        this.Controls.Add(this.EtiquetaDescripcion);
                        this.Controls.Add(this.PicDiablito);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.Name = "ExcepcionNoControlada";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "Error";
                        this.TopMost = true;
                        ((System.ComponentModel.ISupportInitialize)(this.PicDiablito)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.PictureBox PicDiablito;
                private Lui.Forms.Label EtiquetaTitulo;
                public Lui.Forms.Label EtiquetaDescripcion;
                public Lui.Forms.Button BotonCerrar;
                public Lui.Forms.Label label1;
                public Lui.Forms.Label label2;
                private Lui.Forms.LinkLabel linkLabel1;
        }
}
