namespace Lazaro.WinMain.Config
{
        public partial class ConfigurarBd
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

                private void InitializeComponent()
                {
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurarBd));
                        this.EtiquetaEncab = new Lui.Forms.Label();
                        this.EntradaServidor = new Lui.Forms.TextBox();
                        this.EtiquetaServidor = new Lui.Forms.Label();
                        this.EntradaSucursal = new Lui.Forms.TextBox();
                        this.label5 = new Lui.Forms.Label();
                        this.EntradaBD = new Lui.Forms.TextBox();
                        this.Label2 = new Lui.Forms.Label();
                        this.EntradaConexion = new Lui.Forms.ComboBox();
                        this.Label1 = new Lui.Forms.Label();
                        this.EntradaContrasena = new Lui.Forms.TextBox();
                        this.EntradaUsuario = new Lui.Forms.TextBox();
                        this.Label28 = new Lui.Forms.Label();
                        this.Label29 = new Lui.Forms.Label();
                        this.LowerPanel = new Lui.Forms.ButtonPanel();
                        this.CancelCommandButton = new Lui.Forms.Button();
                        this.OkButton = new Lui.Forms.Button();
                        this.PictureBox1 = new System.Windows.Forms.PictureBox();
                        this.label7 = new Lui.Forms.Label();
                        this.LowerPanel.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // EtiquetaEncab
                        // 
                        this.EtiquetaEncab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaEncab.Location = new System.Drawing.Point(24, 24);
                        this.EtiquetaEncab.Name = "EtiquetaEncab";
                        this.EtiquetaEncab.Size = new System.Drawing.Size(544, 40);
                        this.EtiquetaEncab.TabIndex = 0;
                        this.EtiquetaEncab.Text = "Configuración del almacén de datos";
                        this.EtiquetaEncab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.EtiquetaEncab.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // EntradaServidor
                        // 
                        this.EntradaServidor.ForceCase = Lui.Forms.TextCasing.LowerCase;
                        this.EntradaServidor.Location = new System.Drawing.Point(280, 120);
                        this.EntradaServidor.Name = "EntradaServidor";
                        this.EntradaServidor.Size = new System.Drawing.Size(272, 24);
                        this.EntradaServidor.TabIndex = 3;
                        this.EntradaServidor.Leave += new System.EventHandler(this.EntradaServidor_Leave);
                        // 
                        // EtiquetaServidor
                        // 
                        this.EtiquetaServidor.Location = new System.Drawing.Point(64, 120);
                        this.EtiquetaServidor.Name = "EtiquetaServidor";
                        this.EtiquetaServidor.Size = new System.Drawing.Size(216, 24);
                        this.EtiquetaServidor.TabIndex = 2;
                        this.EtiquetaServidor.Text = "Nombre o dirección del servidor";
                        this.EtiquetaServidor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaSucursal
                        // 
                        this.EntradaSucursal.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaSucursal.Location = new System.Drawing.Point(280, 295);
                        this.EntradaSucursal.Name = "EntradaSucursal";
                        this.EntradaSucursal.Size = new System.Drawing.Size(60, 24);
                        this.EntradaSucursal.TabIndex = 16;
                        this.EntradaSucursal.Text = "1";
                        // 
                        // label5
                        // 
                        this.label5.Location = new System.Drawing.Point(64, 295);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(216, 24);
                        this.label5.TabIndex = 15;
                        this.label5.Text = "Sucursal predeterminada";
                        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaBD
                        // 
                        this.EntradaBD.Location = new System.Drawing.Point(280, 199);
                        this.EntradaBD.Name = "EntradaBD";
                        this.EntradaBD.Size = new System.Drawing.Size(172, 24);
                        this.EntradaBD.TabIndex = 7;
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(64, 199);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(216, 24);
                        this.Label2.TabIndex = 6;
                        this.Label2.Text = "Nombre de la base de datos";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaConexion
                        // 
                        this.EntradaConexion.AlwaysExpanded = true;
                        this.EntradaConexion.AutoSize = true;
                        this.EntradaConexion.Location = new System.Drawing.Point(280, 152);
                        this.EntradaConexion.Name = "EntradaConexion";
                        this.EntradaConexion.SetData = new string[] {
        "MySQL|mysql",
        "MariaDB/MySQL|mariadb"};
                        this.EntradaConexion.Size = new System.Drawing.Size(196, 40);
                        this.EntradaConexion.TabIndex = 5;
                        this.EntradaConexion.TextKey = "mysql";
                        this.EntradaConexion.TextChanged += new System.EventHandler(this.EntradaConexion_TextChanged);
                        // 
                        // Label1
                        // 
                        this.Label1.Location = new System.Drawing.Point(64, 152);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(216, 24);
                        this.Label1.TabIndex = 4;
                        this.Label1.Text = "Tipo de servidor";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaContrasena
                        // 
                        this.EntradaContrasena.Location = new System.Drawing.Point(280, 263);
                        this.EntradaContrasena.Name = "EntradaContrasena";
                        this.EntradaContrasena.PasswordChar = '*';
                        this.EntradaContrasena.Size = new System.Drawing.Size(124, 24);
                        this.EntradaContrasena.TabIndex = 11;
                        // 
                        // EntradaUsuario
                        // 
                        this.EntradaUsuario.Location = new System.Drawing.Point(280, 231);
                        this.EntradaUsuario.Name = "EntradaUsuario";
                        this.EntradaUsuario.Size = new System.Drawing.Size(124, 24);
                        this.EntradaUsuario.TabIndex = 9;
                        // 
                        // Label28
                        // 
                        this.Label28.Location = new System.Drawing.Point(64, 263);
                        this.Label28.Name = "Label28";
                        this.Label28.Size = new System.Drawing.Size(216, 24);
                        this.Label28.TabIndex = 10;
                        this.Label28.Text = "Contraseña";
                        this.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label29
                        // 
                        this.Label29.Location = new System.Drawing.Point(64, 231);
                        this.Label29.Name = "Label29";
                        this.Label29.Size = new System.Drawing.Size(216, 24);
                        this.Label29.TabIndex = 8;
                        this.Label29.Text = "Nombre de usuario";
                        this.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // LowerPanel
                        // 
                        this.LowerPanel.Controls.Add(this.CancelCommandButton);
                        this.LowerPanel.Controls.Add(this.OkButton);
                        this.LowerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.LowerPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
                        this.LowerPanel.Location = new System.Drawing.Point(0, 386);
                        this.LowerPanel.Name = "LowerPanel";
                        this.LowerPanel.Padding = new System.Windows.Forms.Padding(12);
                        this.LowerPanel.Size = new System.Drawing.Size(594, 60);
                        this.LowerPanel.TabIndex = 50;
                        // 
                        // CancelCommandButton
                        // 
                        this.CancelCommandButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.CancelCommandButton.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.CancelCommandButton.Image = null;
                        this.CancelCommandButton.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.CancelCommandButton.Location = new System.Drawing.Point(466, 12);
                        this.CancelCommandButton.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.CancelCommandButton.MaximumSize = new System.Drawing.Size(160, 64);
                        this.CancelCommandButton.MinimumSize = new System.Drawing.Size(96, 32);
                        this.CancelCommandButton.Name = "CancelCommandButton";
                        this.CancelCommandButton.Size = new System.Drawing.Size(104, 36);
                        this.CancelCommandButton.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.CancelCommandButton.Subtext = "";
                        this.CancelCommandButton.TabIndex = 51;
                        this.CancelCommandButton.Text = "Cancelar";
                        this.CancelCommandButton.Click += new System.EventHandler(this.BotonCancelar_Click);
                        // 
                        // OkButton
                        // 
                        this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.OkButton.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.OkButton.Image = null;
                        this.OkButton.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.OkButton.Location = new System.Drawing.Point(356, 12);
                        this.OkButton.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.OkButton.MaximumSize = new System.Drawing.Size(160, 64);
                        this.OkButton.MinimumSize = new System.Drawing.Size(96, 32);
                        this.OkButton.Name = "OkButton";
                        this.OkButton.Size = new System.Drawing.Size(104, 36);
                        this.OkButton.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.OkButton.Subtext = "F8";
                        this.OkButton.TabIndex = 50;
                        this.OkButton.Text = "Aceptar";
                        this.OkButton.Click += new System.EventHandler(this.BotonAceptar_Click);
                        // 
                        // PictureBox1
                        // 
                        this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
                        this.PictureBox1.Location = new System.Drawing.Point(24, 64);
                        this.PictureBox1.Name = "PictureBox1";
                        this.PictureBox1.Size = new System.Drawing.Size(32, 32);
                        this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                        this.PictureBox1.TabIndex = 101;
                        this.PictureBox1.TabStop = false;
                        // 
                        // label7
                        // 
                        this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label7.Location = new System.Drawing.Point(64, 64);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(504, 48);
                        this.label7.TabIndex = 1;
                        this.label7.Text = "Es necesario un servidor SQL donde guardar los datos. El servidor SQL puede estar" +
    " en este equipo o en otro equipo si dispone de una conexión de red.";
                        // 
                        // ConfigurarBd
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(594, 446);
                        this.Controls.Add(this.EntradaBD);
                        this.Controls.Add(this.EntradaServidor);
                        this.Controls.Add(this.EntradaConexion);
                        this.Controls.Add(this.EntradaContrasena);
                        this.Controls.Add(this.EntradaUsuario);
                        this.Controls.Add(this.EntradaSucursal);
                        this.Controls.Add(this.label7);
                        this.Controls.Add(this.PictureBox1);
                        this.Controls.Add(this.LowerPanel);
                        this.Controls.Add(this.EtiquetaEncab);
                        this.Controls.Add(this.label5);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.EtiquetaServidor);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.Label29);
                        this.Controls.Add(this.Label28);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.Name = "ConfigurarBd";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "Configurar Acceso a Datos";
                        this.Load += new System.EventHandler(this.ConfigBD_Load);
                        this.LowerPanel.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private Lui.Forms.Label EtiquetaEncab;
                private Lui.Forms.TextBox EntradaServidor;
                private Lui.Forms.Label EtiquetaServidor;
                private Lui.Forms.TextBox EntradaBD;
                private Lui.Forms.Label Label2;
                private Lui.Forms.ComboBox EntradaConexion;
                private Lui.Forms.Label Label1;
                private Lui.Forms.TextBox EntradaContrasena;
                private Lui.Forms.TextBox EntradaUsuario;
                private Lui.Forms.Label Label28;
                private Lui.Forms.Label Label29;
                private Lui.Forms.ButtonPanel LowerPanel;
                private Lui.Forms.Button CancelCommandButton;
                private Lui.Forms.Button OkButton;
                private Lui.Forms.TextBox EntradaSucursal;
                private Lui.Forms.Label label5;
                private System.Windows.Forms.PictureBox PictureBox1;
                private Lui.Forms.Label label7;
        }
}
