using System;
using System.Collections.Generic;
using System.Text;

namespace Lazaro.WinMain.Misc
{
        public partial class Ingreso
        {
                #region Código generado por el Diseñador de Windows Forms

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

                private void InitializeComponent()
                {
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ingreso));
                        this.EntradaContrasena = new Lui.Forms.TextBox();
                        this.Label1 = new Lui.Forms.Label();
                        this.Label2 = new Lui.Forms.Label();
                        this.Titulo = new Lui.Forms.Label();
                        this.CancelCommandButton = new Lui.Forms.Button();
                        this.OkButton = new Lui.Forms.Button();
                        this.EntradaUsuario = new Lcc.Entrada.CodigoDetalle();
                        this.LowerPanel = new Lui.Forms.ButtonPanel();
                        this.panel1 = new Lui.Forms.Panel();
                        this.PictureBox1 = new System.Windows.Forms.PictureBox();
                        this.label3 = new Lui.Forms.Label();
                        this.BotonWebAyuda = new Lui.Forms.LinkLabel();
                        this.LowerPanel.SuspendLayout();
                        this.panel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // EntradaContrasena
                        // 
                        this.EntradaContrasena.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaContrasena.Location = new System.Drawing.Point(232, 192);
                        this.EntradaContrasena.Name = "EntradaContrasena";
                        this.EntradaContrasena.PasswordChar = '*';
                        this.EntradaContrasena.Size = new System.Drawing.Size(169, 24);
                        this.EntradaContrasena.TabIndex = 5;
                        this.EntradaContrasena.TextChanged += new System.EventHandler(this.CambioDatos);
                        // 
                        // Label1
                        // 
                        this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.Label1.Location = new System.Drawing.Point(136, 160);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(96, 24);
                        this.Label1.TabIndex = 2;
                        this.Label1.Text = "Usuario";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label2
                        // 
                        this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.Label2.Location = new System.Drawing.Point(136, 192);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(96, 24);
                        this.Label2.TabIndex = 4;
                        this.Label2.Text = "Contraseña";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Titulo
                        // 
                        this.Titulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Titulo.Location = new System.Drawing.Point(136, 32);
                        this.Titulo.Name = "Titulo";
                        this.Titulo.Size = new System.Drawing.Size(380, 32);
                        this.Titulo.TabIndex = 0;
                        this.Titulo.Text = "Bienvenido a Lázaro";
                        this.Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Titulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        // 
                        // CancelCommandButton
                        // 
                        this.CancelCommandButton.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.CancelCommandButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.CancelCommandButton.Image = null;
                        this.CancelCommandButton.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.CancelCommandButton.Location = new System.Drawing.Point(419, 12);
                        this.CancelCommandButton.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.CancelCommandButton.MaximumSize = new System.Drawing.Size(108, 40);
                        this.CancelCommandButton.MinimumSize = new System.Drawing.Size(96, 32);
                        this.CancelCommandButton.Name = "CancelCommandButton";
                        this.CancelCommandButton.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.CancelCommandButton.Size = new System.Drawing.Size(104, 40);
                        this.CancelCommandButton.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.CancelCommandButton.Subtext = "";
                        this.CancelCommandButton.TabIndex = 1;
                        this.CancelCommandButton.Text = "Cancelar";
                        this.CancelCommandButton.Click += new System.EventHandler(this.BotonCancelar_Click);
                        // 
                        // OkButton
                        // 
                        this.OkButton.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.OkButton.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.OkButton.Enabled = false;
                        this.OkButton.Image = null;
                        this.OkButton.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.OkButton.Location = new System.Drawing.Point(309, 12);
                        this.OkButton.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.OkButton.MaximumSize = new System.Drawing.Size(108, 40);
                        this.OkButton.MinimumSize = new System.Drawing.Size(96, 32);
                        this.OkButton.Name = "OkButton";
                        this.OkButton.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.OkButton.Size = new System.Drawing.Size(104, 40);
                        this.OkButton.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.OkButton.Subtext = "";
                        this.OkButton.TabIndex = 0;
                        this.OkButton.Text = "Ingresar";
                        this.OkButton.Click += new System.EventHandler(this.BotonAceptar_Click);
                        // 
                        // EntradaUsuario
                        // 
                        this.EntradaUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaUsuario.AutoTab = true;
                        this.EntradaUsuario.CanCreate = false;
                        this.EntradaUsuario.Filter = "(tipo&4)=4 AND contrasena<>\'\' AND estado=1";
                        this.EntradaUsuario.Location = new System.Drawing.Point(232, 160);
                        this.EntradaUsuario.Margin = new System.Windows.Forms.Padding(0);
                        this.EntradaUsuario.MaxLength = 200;
                        this.EntradaUsuario.Name = "EntradaUsuario";
                        this.EntradaUsuario.NombreTipo = "Lbl.Personas.Usuario";
                        this.EntradaUsuario.Required = true;
                        this.EntradaUsuario.Size = new System.Drawing.Size(281, 24);
                        this.EntradaUsuario.TabIndex = 3;
                        this.EntradaUsuario.Text = "0";
                        this.EntradaUsuario.TextChanged += new System.EventHandler(this.CambioDatos);
                        // 
                        // LowerPanel
                        // 
                        this.LowerPanel.Controls.Add(this.CancelCommandButton);
                        this.LowerPanel.Controls.Add(this.OkButton);
                        this.LowerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.LowerPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
                        this.LowerPanel.Location = new System.Drawing.Point(0, 248);
                        this.LowerPanel.Name = "LowerPanel";
                        this.LowerPanel.Padding = new System.Windows.Forms.Padding(12);
                        this.LowerPanel.Size = new System.Drawing.Size(547, 64);
                        this.LowerPanel.TabIndex = 6;
                        // 
                        // panel1
                        // 
                        this.panel1.BackColor = System.Drawing.Color.White;
                        this.panel1.Controls.Add(this.PictureBox1);
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.panel1.Location = new System.Drawing.Point(0, 0);
                        this.panel1.Name = "panel1";
                        this.panel1.Size = new System.Drawing.Size(100, 248);
                        this.panel1.TabIndex = 8;
                        // 
                        // PictureBox1
                        // 
                        this.PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.PictureBox1.Image = global::Lazaro.Properties.Resources.lazaro_120_v;
                        this.PictureBox1.Location = new System.Drawing.Point(20, 108);
                        this.PictureBox1.Name = "PictureBox1";
                        this.PictureBox1.Size = new System.Drawing.Size(35, 120);
                        this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                        this.PictureBox1.TabIndex = 51;
                        this.PictureBox1.TabStop = false;
                        // 
                        // label3
                        // 
                        this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label3.Location = new System.Drawing.Point(136, 72);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(380, 76);
                        this.label3.TabIndex = 1;
                        this.label3.Text = resources.GetString("label3.Text");
                        // 
                        // BotonWebAyuda
                        // 
                        this.BotonWebAyuda.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
                        this.BotonWebAyuda.AutoSize = true;
                        this.BotonWebAyuda.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.BotonWebAyuda.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
                        this.BotonWebAyuda.Location = new System.Drawing.Point(416, 194);
                        this.BotonWebAyuda.Name = "BotonWebAyuda";
                        this.BotonWebAyuda.Size = new System.Drawing.Size(44, 17);
                        this.BotonWebAyuda.TabIndex = 7;
                        this.BotonWebAyuda.TabStop = true;
                        this.BotonWebAyuda.Text = "Ayuda";
                        this.BotonWebAyuda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.BotonWebAyuda.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BotonWebAyuda_LinkClicked);
                        // 
                        // Ingreso
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.CancelButton = this.CancelCommandButton;
                        this.ClientSize = new System.Drawing.Size(547, 312);
                        this.ControlBox = false;
                        this.Controls.Add(this.BotonWebAyuda);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.panel1);
                        this.Controls.Add(this.EntradaUsuario);
                        this.Controls.Add(this.EntradaContrasena);
                        this.Controls.Add(this.Titulo);
                        this.Controls.Add(this.LowerPanel);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.Label1);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.Name = "Ingreso";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "Ingreso al Sistema";
                        this.Load += new System.EventHandler(this.FormIngreso_Load);
                        this.LowerPanel.ResumeLayout(false);
                        this.panel1.ResumeLayout(false);
                        this.panel1.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private Lui.Forms.Label Label1;
                private Lui.Forms.Label Label2;
                private Lui.Forms.Button OkButton;
                private Lui.Forms.TextBox EntradaContrasena;
                private Lcc.Entrada.CodigoDetalle EntradaUsuario;
                private Lui.Forms.Button CancelCommandButton;
                private Lui.Forms.Label Titulo;
                private Lui.Forms.ButtonPanel LowerPanel;
                private Lui.Forms.Panel panel1;
                private System.Windows.Forms.PictureBox PictureBox1;
                private Lui.Forms.Label label3;
                private Lui.Forms.LinkLabel BotonWebAyuda;
        }
}
