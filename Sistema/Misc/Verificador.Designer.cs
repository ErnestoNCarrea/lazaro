namespace Lazaro.WinMain.Misc
{
        partial class Verificador
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Verificador));
                        this.ProgressBar = new System.Windows.Forms.ProgressBar();
                        this.label7 = new Lui.Forms.Label();
                        this.PictureBox1 = new System.Windows.Forms.PictureBox();
                        this.Label27 = new Lui.Forms.Label();
                        this.LowerPanel = new Lui.Forms.ButtonPanel();
                        this.CancelCommandButton = new Lui.Forms.Button();
                        this.OkButton = new Lui.Forms.Button();
                        this.EtiquetaEstado = new Lui.Forms.Label();
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
                        this.LowerPanel.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // ProgressBar
                        // 
                        this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.ProgressBar.Location = new System.Drawing.Point(88, 248);
                        this.ProgressBar.Name = "ProgressBar";
                        this.ProgressBar.Size = new System.Drawing.Size(432, 20);
                        this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
                        this.ProgressBar.TabIndex = 4;
                        // 
                        // label7
                        // 
                        this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label7.Location = new System.Drawing.Point(88, 56);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(432, 52);
                        this.label7.TabIndex = 105;
                        this.label7.Text = "Este proceso realiza una verificación en búsqueda de inconsistencias en los datos" +
    ", saldos de las cuentas, existencias de stock, etc.";
                        // 
                        // PictureBox1
                        // 
                        this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
                        this.PictureBox1.Location = new System.Drawing.Point(24, 24);
                        this.PictureBox1.Name = "PictureBox1";
                        this.PictureBox1.Size = new System.Drawing.Size(47, 64);
                        this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                        this.PictureBox1.TabIndex = 104;
                        this.PictureBox1.TabStop = false;
                        // 
                        // Label27
                        // 
                        this.Label27.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label27.Location = new System.Drawing.Point(88, 24);
                        this.Label27.Name = "Label27";
                        this.Label27.Size = new System.Drawing.Size(432, 32);
                        this.Label27.TabIndex = 103;
                        this.Label27.Text = "Verificando de integridad de los datos";
                        this.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label27.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // LowerPanel
                        // 
                        this.LowerPanel.Controls.Add(this.CancelCommandButton);
                        this.LowerPanel.Controls.Add(this.OkButton);
                        this.LowerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.LowerPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
                        this.LowerPanel.Location = new System.Drawing.Point(0, 299);
                        this.LowerPanel.Name = "LowerPanel";
                        this.LowerPanel.Padding = new System.Windows.Forms.Padding(12);
                        this.LowerPanel.Size = new System.Drawing.Size(546, 58);
                        this.LowerPanel.TabIndex = 106;
                        // 
                        // CancelCommandButton
                        // 
                        this.CancelCommandButton.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.CancelCommandButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.CancelCommandButton.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.CancelCommandButton.Image = null;
                        this.CancelCommandButton.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.CancelCommandButton.Location = new System.Drawing.Point(418, 12);
                        this.CancelCommandButton.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.CancelCommandButton.MaximumSize = new System.Drawing.Size(108, 40);
                        this.CancelCommandButton.MinimumSize = new System.Drawing.Size(96, 32);
                        this.CancelCommandButton.Name = "CancelCommandButton";
                        this.CancelCommandButton.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.CancelCommandButton.Size = new System.Drawing.Size(104, 34);
                        this.CancelCommandButton.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.CancelCommandButton.Subtext = "";
                        this.CancelCommandButton.TabIndex = 51;
                        this.CancelCommandButton.Text = "Cancelar";
                        // 
                        // OkButton
                        // 
                        this.OkButton.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.OkButton.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.OkButton.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.OkButton.Image = null;
                        this.OkButton.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.OkButton.Location = new System.Drawing.Point(308, 12);
                        this.OkButton.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.OkButton.MaximumSize = new System.Drawing.Size(108, 40);
                        this.OkButton.MinimumSize = new System.Drawing.Size(96, 32);
                        this.OkButton.Name = "OkButton";
                        this.OkButton.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.OkButton.Size = new System.Drawing.Size(104, 34);
                        this.OkButton.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.OkButton.Subtext = "F8";
                        this.OkButton.TabIndex = 50;
                        this.OkButton.Text = "Iniciar";
                        this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
                        // 
                        // EtiquetaEstado
                        // 
                        this.EtiquetaEstado.Location = new System.Drawing.Point(88, 224);
                        this.EtiquetaEstado.Name = "EtiquetaEstado";
                        this.EtiquetaEstado.Size = new System.Drawing.Size(432, 20);
                        this.EtiquetaEstado.TabIndex = 107;
                        this.EtiquetaEstado.Text = "Haga clic en \"Iniciar\" para comenzar el proceso.";
                        this.EtiquetaEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Verificador
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.CancelButton = this.CancelCommandButton;
                        this.ClientSize = new System.Drawing.Size(546, 357);
                        this.Controls.Add(this.EtiquetaEstado);
                        this.Controls.Add(this.LowerPanel);
                        this.Controls.Add(this.label7);
                        this.Controls.Add(this.PictureBox1);
                        this.Controls.Add(this.Label27);
                        this.Controls.Add(this.ProgressBar);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        this.Name = "Verificador";
                        this.Text = "Verificar Integridad de los Datos";
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
                        this.LowerPanel.ResumeLayout(false);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                public System.Windows.Forms.ProgressBar ProgressBar;
                internal Lui.Forms.Label label7;
                internal System.Windows.Forms.PictureBox PictureBox1;
                internal Lui.Forms.Label Label27;
                internal Lui.Forms.ButtonPanel LowerPanel;
                internal Lui.Forms.Button OkButton;
                internal Lui.Forms.Button CancelCommandButton;
                private Lui.Forms.Label EtiquetaEstado;

        }
}
