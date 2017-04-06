using System.Windows.Forms;

namespace Lazaro.WinMain.Config
{
        public partial class ErrorConexion
        {
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

                #region Código generado por el Diseñador de Windows Forms

                private void InitializeComponent()
                {
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorConexion));
                        this.EtiquetaEncab = new Lui.Forms.Label();
                        this.BotonConfigurar = new Lui.Forms.Button();
                        this.BotonReintentar = new Lui.Forms.Button();
                        this.BotonSalir = new Lui.Forms.Button();
                        this.LowerPanel = new Lui.Forms.ButtonPanel();
                        this.EtiquetaErrorOriginal = new Lui.Forms.Label();
                        this.panel1 = new Lui.Forms.Panel();
                        this.pictureBox2 = new System.Windows.Forms.PictureBox();
                        this.EtiquetaAyuda = new Lui.Forms.Label();
                        this.pictureBox3 = new System.Windows.Forms.PictureBox();
                        this.LowerPanel.SuspendLayout();
                        this.panel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // EtiquetaEncab
                        // 
                        this.EtiquetaEncab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaEncab.Location = new System.Drawing.Point(128, 28);
                        this.EtiquetaEncab.Name = "EtiquetaEncab";
                        this.EtiquetaEncab.Size = new System.Drawing.Size(484, 24);
                        this.EtiquetaEncab.TabIndex = 0;
                        this.EtiquetaEncab.Text = "No se puede establecer conexión con el servidor";
                        this.EtiquetaEncab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.EtiquetaEncab.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        // 
                        // BotonConfigurar
                        // 
                        this.BotonConfigurar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonConfigurar.Image = null;
                        this.BotonConfigurar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonConfigurar.Location = new System.Drawing.Point(400, 12);
                        this.BotonConfigurar.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.BotonConfigurar.MaximumSize = new System.Drawing.Size(108, 40);
                        this.BotonConfigurar.MinimumSize = new System.Drawing.Size(96, 32);
                        this.BotonConfigurar.Name = "BotonConfigurar";
                        this.BotonConfigurar.Size = new System.Drawing.Size(108, 40);
                        this.BotonConfigurar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonConfigurar.Subtext = "F8";
                        this.BotonConfigurar.TabIndex = 1;
                        this.BotonConfigurar.Text = "Configuración";
                        this.BotonConfigurar.Click += new System.EventHandler(this.BotonConfigurar_Click);
                        // 
                        // BotonReintentar
                        // 
                        this.BotonReintentar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonReintentar.Image = null;
                        this.BotonReintentar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonReintentar.Location = new System.Drawing.Point(286, 12);
                        this.BotonReintentar.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.BotonReintentar.MaximumSize = new System.Drawing.Size(108, 40);
                        this.BotonReintentar.MinimumSize = new System.Drawing.Size(96, 32);
                        this.BotonReintentar.Name = "BotonReintentar";
                        this.BotonReintentar.Size = new System.Drawing.Size(108, 40);
                        this.BotonReintentar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonReintentar.Subtext = "F8";
                        this.BotonReintentar.TabIndex = 0;
                        this.BotonReintentar.Text = "Volver a intentar";
                        this.BotonReintentar.Click += new System.EventHandler(this.BotonReintentar_Click);
                        // 
                        // BotonSalir
                        // 
                        this.BotonSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonSalir.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonSalir.Image = null;
                        this.BotonSalir.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonSalir.Location = new System.Drawing.Point(514, 12);
                        this.BotonSalir.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.BotonSalir.MaximumSize = new System.Drawing.Size(108, 40);
                        this.BotonSalir.MinimumSize = new System.Drawing.Size(96, 32);
                        this.BotonSalir.Name = "BotonSalir";
                        this.BotonSalir.Size = new System.Drawing.Size(96, 40);
                        this.BotonSalir.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonSalir.Subtext = "F8";
                        this.BotonSalir.TabIndex = 2;
                        this.BotonSalir.Text = "Salir";
                        this.BotonSalir.Click += new System.EventHandler(this.BotonSalir_Click);
                        // 
                        // LowerPanel
                        // 
                        this.LowerPanel.Controls.Add(this.BotonSalir);
                        this.LowerPanel.Controls.Add(this.BotonConfigurar);
                        this.LowerPanel.Controls.Add(this.BotonReintentar);
                        this.LowerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.LowerPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
                        this.LowerPanel.Location = new System.Drawing.Point(0, 308);
                        this.LowerPanel.Name = "LowerPanel";
                        this.LowerPanel.Padding = new System.Windows.Forms.Padding(12);
                        this.LowerPanel.Size = new System.Drawing.Size(634, 64);
                        this.LowerPanel.TabIndex = 0;
                        // 
                        // EtiquetaErrorOriginal
                        // 
                        this.EtiquetaErrorOriginal.Location = new System.Drawing.Point(124, 200);
                        this.EtiquetaErrorOriginal.Name = "EtiquetaErrorOriginal";
                        this.EtiquetaErrorOriginal.Size = new System.Drawing.Size(488, 100);
                        this.EtiquetaErrorOriginal.TabIndex = 21;
                        this.EtiquetaErrorOriginal.Text = "No hay más información sobre el error.";
                        // 
                        // panel1
                        // 
                        this.panel1.BackColor = System.Drawing.Color.White;
                        this.panel1.Controls.Add(this.pictureBox2);
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.panel1.Location = new System.Drawing.Point(0, 0);
                        this.panel1.Name = "panel1";
                        this.panel1.Size = new System.Drawing.Size(100, 308);
                        this.panel1.TabIndex = 54;
                        // 
                        // pictureBox2
                        // 
                        this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.pictureBox2.Image = global::Lazaro.Properties.Resources.lazaro_120_v;
                        this.pictureBox2.Location = new System.Drawing.Point(20, 168);
                        this.pictureBox2.Name = "pictureBox2";
                        this.pictureBox2.Size = new System.Drawing.Size(35, 120);
                        this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                        this.pictureBox2.TabIndex = 51;
                        this.pictureBox2.TabStop = false;
                        // 
                        // EtiquetaAyuda
                        // 
                        this.EtiquetaAyuda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaAyuda.Location = new System.Drawing.Point(172, 64);
                        this.EtiquetaAyuda.Name = "EtiquetaAyuda";
                        this.EtiquetaAyuda.Size = new System.Drawing.Size(440, 120);
                        this.EtiquetaAyuda.TabIndex = 55;
                        this.EtiquetaAyuda.Text = "Su computadora no está configurada correctamente.";
                        // 
                        // pictureBox3
                        // 
                        this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
                        this.pictureBox3.Location = new System.Drawing.Point(128, 64);
                        this.pictureBox3.Name = "pictureBox3";
                        this.pictureBox3.Size = new System.Drawing.Size(36, 36);
                        this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        this.pictureBox3.TabIndex = 57;
                        this.pictureBox3.TabStop = false;
                        // 
                        // ErrorConexion
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(634, 372);
                        this.Controls.Add(this.pictureBox3);
                        this.Controls.Add(this.EtiquetaAyuda);
                        this.Controls.Add(this.panel1);
                        this.Controls.Add(this.EtiquetaErrorOriginal);
                        this.Controls.Add(this.LowerPanel);
                        this.Controls.Add(this.EtiquetaEncab);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.Name = "ErrorConexion";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "Lázaro";
                        this.LowerPanel.ResumeLayout(false);
                        this.panel1.ResumeLayout(false);
                        this.panel1.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private Lui.Forms.Button BotonConfigurar;
                private Lui.Forms.Button BotonReintentar;
                private Lui.Forms.Button BotonSalir;
                private Lui.Forms.Label EtiquetaEncab;
                private Lui.Forms.Label EtiquetaErrorOriginal;
                private PictureBox pictureBox2;
                private Lui.Forms.ButtonPanel LowerPanel;
                private PictureBox pictureBox3;
                private Lui.Forms.Label EtiquetaAyuda;
                private Lui.Forms.Panel panel1;
        }
}
