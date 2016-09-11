using System;
using System.Collections.Generic;

namespace ServidorFiscal.Forms
{
        public partial class Estado
        {
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                                this.QuitarIcono();
                        }
                        base.Dispose(disposing);
                }

                private System.ComponentModel.IContainer components = null;

                #region Código generado por el Diseñador de Windows Forms

                private void InitializeComponent()
                {
                        this.components = new System.ComponentModel.Container();
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Estado));
                        this.IconoBandeja = new System.Windows.Forms.NotifyIcon(this.components);
                        this.MenuContextual = new System.Windows.Forms.ContextMenu();
                        this.MenuOcultar = new System.Windows.Forms.MenuItem();
                        this.MenuItem1 = new System.Windows.Forms.MenuItem();
                        this.MenuCerrar = new System.Windows.Forms.MenuItem();
                        this.MenuReiniciar = new System.Windows.Forms.MenuItem();
                        this.label1 = new Lui.Forms.Label();
                        this.EtiquetaEstado = new Lui.Forms.Label();
                        this.EtiquetaModeloImpresora = new Lui.Forms.Label();
                        this.label4 = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.EtiquetaEstadoFiscal = new Lui.Forms.Label();
                        this.label5 = new Lui.Forms.Label();
                        this.EtiquetaPV = new Lui.Forms.Label();
                        this.label7 = new Lui.Forms.Label();
                        this.EtiquetaVersion = new Lui.Forms.Label();
                        this.label8 = new Lui.Forms.Label();
                        this.label3 = new Lui.Forms.Label();
                        this.pictureBox1 = new System.Windows.Forms.PictureBox();
                        this.BotonCerrar = new Lui.Forms.Button();
                        this.BotonReiniciar = new Lui.Forms.Button();
                        this.BotonOcultar = new Lui.Forms.Button();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // IconoBandeja
                        // 
                        this.IconoBandeja.ContextMenu = this.MenuContextual;
                        this.IconoBandeja.Icon = ((System.Drawing.Icon)(resources.GetObject("IconoBandeja.Icon")));
                        this.IconoBandeja.Text = "Servidor Fiscal Lázaro";
                        this.IconoBandeja.Visible = true;
                        this.IconoBandeja.DoubleClick += new System.EventHandler(this.IconoBandeja_DoubleClick);
                        // 
                        // MenuContextual
                        // 
                        this.MenuContextual.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuOcultar,
            this.MenuItem1,
            this.MenuCerrar,
            this.MenuReiniciar});
                        // 
                        // MenuOcultar
                        // 
                        this.MenuOcultar.Index = 0;
                        this.MenuOcultar.Text = "&Mostrar";
                        this.MenuOcultar.Visible = false;
                        this.MenuOcultar.Click += new System.EventHandler(this.MenuOcultar_Click);
                        // 
                        // MenuItem1
                        // 
                        this.MenuItem1.Index = 1;
                        this.MenuItem1.Text = "-";
                        this.MenuItem1.Visible = false;
                        // 
                        // MenuCerrar
                        // 
                        this.MenuCerrar.Index = 2;
                        this.MenuCerrar.Text = "&Apagar";
                        this.MenuCerrar.Click += new System.EventHandler(this.MenuCerrar_Click);
                        // 
                        // MenuReiniciar
                        // 
                        this.MenuReiniciar.Index = 3;
                        this.MenuReiniciar.Text = "&Reiniciar";
                        this.MenuReiniciar.Click += new System.EventHandler(this.MenuReiniciar_Click);
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(104, 144);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(104, 24);
                        this.label1.TabIndex = 3;
                        this.label1.Text = "Estado";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EtiquetaEstado
                        // 
                        this.EtiquetaEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaEstado.Location = new System.Drawing.Point(216, 144);
                        this.EtiquetaEstado.Name = "EtiquetaEstado";
                        this.EtiquetaEstado.Size = new System.Drawing.Size(288, 24);
                        this.EtiquetaEstado.TabIndex = 4;
                        this.EtiquetaEstado.Text = "Esperando órdenes.";
                        this.EtiquetaEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EtiquetaModeloImpresora
                        // 
                        this.EtiquetaModeloImpresora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaModeloImpresora.Location = new System.Drawing.Point(216, 176);
                        this.EtiquetaModeloImpresora.Name = "EtiquetaModeloImpresora";
                        this.EtiquetaModeloImpresora.Size = new System.Drawing.Size(288, 24);
                        this.EtiquetaModeloImpresora.TabIndex = 6;
                        this.EtiquetaModeloImpresora.Text = "Genérico";
                        this.EtiquetaModeloImpresora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(104, 176);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(104, 24);
                        this.label4.TabIndex = 5;
                        this.label4.Text = "Impresora";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // label2
                        // 
                        this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label2.Location = new System.Drawing.Point(104, 56);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(400, 48);
                        this.label2.TabIndex = 9;
                        this.label2.Text = "Este componente se encarga de comunicarse con la impresora fiscal para hacer la i" +
    "mpresión de comprobantes y cierre Z.";
                        // 
                        // EtiquetaEstadoFiscal
                        // 
                        this.EtiquetaEstadoFiscal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaEstadoFiscal.Location = new System.Drawing.Point(216, 208);
                        this.EtiquetaEstadoFiscal.Name = "EtiquetaEstadoFiscal";
                        this.EtiquetaEstadoFiscal.Size = new System.Drawing.Size(288, 24);
                        this.EtiquetaEstadoFiscal.TabIndex = 11;
                        this.EtiquetaEstadoFiscal.Text = "0000 / 0000";
                        this.EtiquetaEstadoFiscal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label5
                        // 
                        this.label5.Location = new System.Drawing.Point(104, 208);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(104, 24);
                        this.label5.TabIndex = 10;
                        this.label5.Text = "Estado fiscal";
                        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EtiquetaPV
                        // 
                        this.EtiquetaPV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaPV.Location = new System.Drawing.Point(216, 112);
                        this.EtiquetaPV.Name = "EtiquetaPV";
                        this.EtiquetaPV.Size = new System.Drawing.Size(288, 24);
                        this.EtiquetaPV.TabIndex = 13;
                        this.EtiquetaPV.Text = "No está definido";
                        this.EtiquetaPV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label7
                        // 
                        this.label7.Location = new System.Drawing.Point(104, 112);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(104, 24);
                        this.label7.TabIndex = 12;
                        this.label7.Text = "Punto de venta";
                        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // EtiquetaVersion
                        // 
                        this.EtiquetaVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaVersion.Location = new System.Drawing.Point(216, 240);
                        this.EtiquetaVersion.Name = "EtiquetaVersion";
                        this.EtiquetaVersion.Size = new System.Drawing.Size(288, 24);
                        this.EtiquetaVersion.TabIndex = 15;
                        this.EtiquetaVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label8
                        // 
                        this.label8.Location = new System.Drawing.Point(104, 240);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(104, 24);
                        this.label8.TabIndex = 14;
                        this.label8.Text = "Versión";
                        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // label3
                        // 
                        this.label3.AutoSize = true;
                        this.label3.Location = new System.Drawing.Point(104, 24);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(248, 30);
                        this.label3.TabIndex = 16;
                        this.label3.Text = "Servidor fiscal de Lázaro";
                        this.label3.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // pictureBox1
                        // 
                        this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
                        this.pictureBox1.Location = new System.Drawing.Point(24, 24);
                        this.pictureBox1.Name = "pictureBox1";
                        this.pictureBox1.Size = new System.Drawing.Size(64, 64);
                        this.pictureBox1.TabIndex = 17;
                        this.pictureBox1.TabStop = false;
                        // 
                        // BotonCerrar
                        // 
                        this.BotonCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonCerrar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonCerrar.Image = null;
                        this.BotonCerrar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonCerrar.Location = new System.Drawing.Point(136, 280);
                        this.BotonCerrar.Name = "BotonCerrar";
                        this.BotonCerrar.Size = new System.Drawing.Size(96, 32);
                        this.BotonCerrar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonCerrar.Subtext = "Tecla";
                        this.BotonCerrar.TabIndex = 2;
                        this.BotonCerrar.Text = "Apagar";
                        this.BotonCerrar.Click += new System.EventHandler(this.BotonCerrar_Click);
                        // 
                        // BotonReiniciar
                        // 
                        this.BotonReiniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonReiniciar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonReiniciar.Image = null;
                        this.BotonReiniciar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonReiniciar.Location = new System.Drawing.Point(24, 280);
                        this.BotonReiniciar.Name = "BotonReiniciar";
                        this.BotonReiniciar.Size = new System.Drawing.Size(96, 32);
                        this.BotonReiniciar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonReiniciar.Subtext = "Tecla";
                        this.BotonReiniciar.TabIndex = 1;
                        this.BotonReiniciar.Text = "Reiniciar";
                        this.BotonReiniciar.Click += new System.EventHandler(this.BotonReiniciar_Click);
                        // 
                        // BotonOcultar
                        // 
                        this.BotonOcultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonOcultar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonOcultar.Image = null;
                        this.BotonOcultar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonOcultar.Location = new System.Drawing.Point(408, 280);
                        this.BotonOcultar.Name = "BotonOcultar";
                        this.BotonOcultar.Size = new System.Drawing.Size(96, 32);
                        this.BotonOcultar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonOcultar.Subtext = "Tecla";
                        this.BotonOcultar.TabIndex = 0;
                        this.BotonOcultar.Text = "Ocultar";
                        this.BotonOcultar.Click += new System.EventHandler(this.BotonOcultar_Click);
                        // 
                        // Estado
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(527, 332);
                        this.Controls.Add(this.BotonOcultar);
                        this.Controls.Add(this.BotonReiniciar);
                        this.Controls.Add(this.BotonCerrar);
                        this.Controls.Add(this.pictureBox1);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.EtiquetaVersion);
                        this.Controls.Add(this.EtiquetaPV);
                        this.Controls.Add(this.EtiquetaEstadoFiscal);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.EtiquetaModeloImpresora);
                        this.Controls.Add(this.EtiquetaEstado);
                        this.Controls.Add(this.label8);
                        this.Controls.Add(this.label7);
                        this.Controls.Add(this.label5);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.label1);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.Name = "Estado";
                        this.ShowIcon = false;
                        this.ShowInTaskbar = false;
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "Servidor fiscal";
                        this.TopMost = true;
                        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Estado_FormClosing);
                        this.Load += new System.EventHandler(this.FormEstado_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private Lui.Forms.Label label3;
                private System.Windows.Forms.PictureBox pictureBox1;
                private Lui.Forms.Button BotonCerrar;
                private Lui.Forms.Button BotonReiniciar;
                private System.Windows.Forms.NotifyIcon IconoBandeja;
                private System.Windows.Forms.ContextMenu MenuContextual;
                private System.Windows.Forms.MenuItem MenuCerrar;
                private System.Windows.Forms.MenuItem MenuOcultar;
                private System.Windows.Forms.MenuItem MenuItem1;
                private Lui.Forms.Label label1;
                private Lui.Forms.Label EtiquetaEstado;
                private Lui.Forms.Label EtiquetaModeloImpresora;
                private Lui.Forms.Label label4;
                private Lui.Forms.Label label2;
                private Lui.Forms.Label label5;
                private Lui.Forms.Label EtiquetaEstadoFiscal;
                private Lui.Forms.Label EtiquetaPV;
                private Lui.Forms.Label label7;
                private Lui.Forms.Label EtiquetaVersion;
                private Lui.Forms.Label label8;
                private System.Windows.Forms.MenuItem MenuReiniciar;
                private Lui.Forms.Button BotonOcultar;
        }
}