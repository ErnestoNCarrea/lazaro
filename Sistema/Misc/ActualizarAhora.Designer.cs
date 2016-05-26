using System;
using System.Windows.Forms;

namespace Lazaro.WinMain.Misc
{
        partial class ActualizarAhora
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
                        this.components = new System.ComponentModel.Container();
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizarAhora));
                        this.BarraProgreso = new Lui.Forms.ProgressBar();
                        this.panel1 = new Lui.Forms.Panel();
                        this.pictureBox2 = new System.Windows.Forms.PictureBox();
                        this.labelH11 = new Lui.Forms.Label();
                        this.label1 = new Lui.Forms.Label();
                        this.EtiquetaEstado = new Lui.Forms.Label();
                        this.EtiquetaProgreso = new Lui.Forms.Label();
                        this.BotonInstalar = new Lui.Forms.Button();
                        this.EtiquetaAyuda = new Lui.Forms.Label();
                        this.TimerProgreso = new System.Windows.Forms.Timer(this.components);
                        this.panel1.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // BarraProgreso
                        // 
                        this.BarraProgreso.Location = new System.Drawing.Point(128, 132);
                        this.BarraProgreso.Name = "BarraProgreso";
                        this.BarraProgreso.Size = new System.Drawing.Size(464, 24);
                        this.BarraProgreso.TabIndex = 0;
                        // 
                        // panel1
                        // 
                        this.panel1.BackColor = System.Drawing.Color.White;
                        this.panel1.Controls.Add(this.pictureBox2);
                        this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
                        this.panel1.Location = new System.Drawing.Point(0, 0);
                        this.panel1.Name = "panel1";
                        this.panel1.Size = new System.Drawing.Size(100, 306);
                        this.panel1.TabIndex = 55;
                        // 
                        // pictureBox2
                        // 
                        this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
                        this.pictureBox2.Location = new System.Drawing.Point(20, 166);
                        this.pictureBox2.Name = "pictureBox2";
                        this.pictureBox2.Size = new System.Drawing.Size(37, 120);
                        this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                        this.pictureBox2.TabIndex = 51;
                        this.pictureBox2.TabStop = false;
                        // 
                        // labelH11
                        // 
                        this.labelH11.Location = new System.Drawing.Point(128, 24);
                        this.labelH11.Name = "labelH11";
                        this.labelH11.Size = new System.Drawing.Size(464, 24);
                        this.labelH11.TabIndex = 56;
                        this.labelH11.Text = "Actualizando Lázaro";
                        this.labelH11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.labelH11.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(128, 56);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(464, 40);
                        this.label1.TabIndex = 57;
                        this.label1.Text = "La versión de Lázaro que está utilizando es antigua. Por favor aguarde mientras s" +
    "e busca una versión más nueva.";
                        // 
                        // EtiquetaEstado
                        // 
                        this.EtiquetaEstado.Location = new System.Drawing.Point(128, 112);
                        this.EtiquetaEstado.Name = "EtiquetaEstado";
                        this.EtiquetaEstado.Size = new System.Drawing.Size(380, 20);
                        this.EtiquetaEstado.TabIndex = 58;
                        this.EtiquetaEstado.Text = "Iniciando...";
                        this.EtiquetaEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EtiquetaProgreso
                        // 
                        this.EtiquetaProgreso.Location = new System.Drawing.Point(512, 112);
                        this.EtiquetaProgreso.Name = "EtiquetaProgreso";
                        this.EtiquetaProgreso.Size = new System.Drawing.Size(80, 20);
                        this.EtiquetaProgreso.TabIndex = 59;
                        this.EtiquetaProgreso.Text = "0%";
                        this.EtiquetaProgreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // BotonInstalar
                        // 
                        this.BotonInstalar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonInstalar.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.BotonInstalar.Image = null;
                        this.BotonInstalar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonInstalar.Location = new System.Drawing.Point(480, 248);
                        this.BotonInstalar.Name = "BotonInstalar";
                        this.BotonInstalar.Size = new System.Drawing.Size(112, 36);
                        this.BotonInstalar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonInstalar.Subtext = "Tecla";
                        this.BotonInstalar.TabIndex = 61;
                        this.BotonInstalar.Text = "Cancelar";
                        this.BotonInstalar.Click += new System.EventHandler(this.BotonInstalar_Click);
                        // 
                        // EtiquetaAyuda
                        // 
                        this.EtiquetaAyuda.Location = new System.Drawing.Point(128, 168);
                        this.EtiquetaAyuda.Name = "EtiquetaAyuda";
                        this.EtiquetaAyuda.Size = new System.Drawing.Size(464, 68);
                        this.EtiquetaAyuda.TabIndex = 63;
                        this.EtiquetaAyuda.Text = "Si no desea instalar la actualización ahora, haga clic en el botón \'Cancelar\'. La" +
    " descarga continuará en segundo plano y se instalará en otro momento.";
                        // 
                        // TimerProgreso
                        // 
                        this.TimerProgreso.Enabled = true;
                        this.TimerProgreso.Interval = 1000;
                        this.TimerProgreso.Tick += new System.EventHandler(this.TimerProgreso_Tick);
                        // 
                        // ActualizarAhora
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(609, 306);
                        this.Controls.Add(this.EtiquetaAyuda);
                        this.Controls.Add(this.BotonInstalar);
                        this.Controls.Add(this.EtiquetaProgreso);
                        this.Controls.Add(this.EtiquetaEstado);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.labelH11);
                        this.Controls.Add(this.panel1);
                        this.Controls.Add(this.BarraProgreso);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        this.Name = "ActualizarAhora";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "Actualizador";
                        this.panel1.ResumeLayout(false);
                        this.panel1.PerformLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                private Lui.Forms.ProgressBar BarraProgreso;
                internal PictureBox pictureBox2;
                private Lui.Forms.Label labelH11;
                private Lui.Forms.Label label1;
                private Lui.Forms.Label EtiquetaEstado;
                private Lui.Forms.Label EtiquetaProgreso;
                private Lui.Forms.Button BotonInstalar;
                private Lui.Forms.Label EtiquetaAyuda;
                private Timer TimerProgreso;
                private Lui.Forms.Panel panel1;
        }
}
