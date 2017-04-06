using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Lazaro.WinMain.Misc
{
        public partial class Fiscal
        {
                #region Código generado por el Diseñador de Windows Forms

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

                private void InitializeComponent()
                {
                        this.components = new System.ComponentModel.Container();
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fiscal));
                        this.BotonCierreZ = new Lui.Forms.Button();
                        this.Timer1 = new System.Windows.Forms.Timer(this.components);
                        this.EtiquetaCierreZ = new Lui.Forms.Label();
                        this.label1 = new Lui.Forms.Label();
                        this.EntradaPv = new Lui.Forms.ComboBox();
                        this.BotonReiniciar = new Lui.Forms.Button();
                        this.label2 = new Lui.Forms.Label();
                        this.EtiquetaEstadoServidor = new Lui.Forms.Label();
                        this.EtiquetaUltimoCierreZ = new Lui.Forms.Label();
                        this.BotonIniciarDetener = new Lui.Forms.Button();
                        this.Titulo = new Lui.Forms.Label();
                        this.label3 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // BotonCierreZ
                        // 
                        this.BotonCierreZ.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonCierreZ.Image = null;
                        this.BotonCierreZ.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonCierreZ.Location = new System.Drawing.Point(512, 112);
                        this.BotonCierreZ.Name = "BotonCierreZ";
                        this.BotonCierreZ.Size = new System.Drawing.Size(100, 40);
                        this.BotonCierreZ.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonCierreZ.Subtext = "Ctrl-Z";
                        this.BotonCierreZ.TabIndex = 8;
                        this.BotonCierreZ.Text = "Cierre Z";
                        this.BotonCierreZ.Click += new System.EventHandler(this.BotonCierreZ_Click);
                        // 
                        // Timer1
                        // 
                        this.Timer1.Enabled = true;
                        this.Timer1.Interval = 2000;
                        this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
                        // 
                        // EtiquetaCierreZ
                        // 
                        this.EtiquetaCierreZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaCierreZ.Location = new System.Drawing.Point(24, 224);
                        this.EtiquetaCierreZ.Name = "EtiquetaCierreZ";
                        this.EtiquetaCierreZ.Size = new System.Drawing.Size(144, 24);
                        this.EtiquetaCierreZ.TabIndex = 3;
                        this.EtiquetaCierreZ.Text = "Último cierre Z";
                        this.EtiquetaCierreZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(24, 112);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(144, 24);
                        this.label1.TabIndex = 51;
                        this.label1.Text = "Punto de venta";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaPv
                        // 
                        this.EntradaPv.AlwaysExpanded = true;
                        this.EntradaPv.AutoSize = true;
                        this.EntradaPv.Location = new System.Drawing.Point(168, 112);
                        this.EntradaPv.Name = "EntradaPv";
                        this.EntradaPv.SetData = null;
                        this.EntradaPv.Size = new System.Drawing.Size(248, 23);
                        this.EntradaPv.TabIndex = 52;
                        this.EntradaPv.TextKey = "";
                        this.EntradaPv.TextChanged += new System.EventHandler(this.EntradaPV_TextChanged);
                        // 
                        // BotonReiniciar
                        // 
                        this.BotonReiniciar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonReiniciar.Enabled = false;
                        this.BotonReiniciar.Image = null;
                        this.BotonReiniciar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonReiniciar.Location = new System.Drawing.Point(512, 208);
                        this.BotonReiniciar.Name = "BotonReiniciar";
                        this.BotonReiniciar.Size = new System.Drawing.Size(100, 40);
                        this.BotonReiniciar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonReiniciar.Subtext = "Ctrl-Z";
                        this.BotonReiniciar.TabIndex = 53;
                        this.BotonReiniciar.Text = "Reiniciar";
                        this.BotonReiniciar.Click += new System.EventHandler(this.BotonReiniciar_Click);
                        // 
                        // label2
                        // 
                        this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label2.Location = new System.Drawing.Point(24, 256);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(144, 24);
                        this.label2.TabIndex = 54;
                        this.label2.Text = "Estado del servidor";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EtiquetaEstadoServidor
                        // 
                        this.EtiquetaEstadoServidor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaEstadoServidor.Location = new System.Drawing.Point(168, 256);
                        this.EtiquetaEstadoServidor.Name = "EtiquetaEstadoServidor";
                        this.EtiquetaEstadoServidor.Size = new System.Drawing.Size(328, 24);
                        this.EtiquetaEstadoServidor.TabIndex = 56;
                        this.EtiquetaEstadoServidor.Text = "Desconocido";
                        this.EtiquetaEstadoServidor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EtiquetaUltimoCierreZ
                        // 
                        this.EtiquetaUltimoCierreZ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaUltimoCierreZ.Location = new System.Drawing.Point(168, 224);
                        this.EtiquetaUltimoCierreZ.Name = "EtiquetaUltimoCierreZ";
                        this.EtiquetaUltimoCierreZ.Size = new System.Drawing.Size(328, 24);
                        this.EtiquetaUltimoCierreZ.TabIndex = 55;
                        this.EtiquetaUltimoCierreZ.Text = "Desconocido";
                        this.EtiquetaUltimoCierreZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // BotonIniciarDetener
                        // 
                        this.BotonIniciarDetener.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonIniciarDetener.Image = null;
                        this.BotonIniciarDetener.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonIniciarDetener.Location = new System.Drawing.Point(512, 160);
                        this.BotonIniciarDetener.Name = "BotonIniciarDetener";
                        this.BotonIniciarDetener.Size = new System.Drawing.Size(100, 40);
                        this.BotonIniciarDetener.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonIniciarDetener.Subtext = "Ctrl-Z";
                        this.BotonIniciarDetener.TabIndex = 57;
                        this.BotonIniciarDetener.Text = "Iniciar";
                        this.BotonIniciarDetener.Click += new System.EventHandler(this.BotonIniciarDetener_Click);
                        // 
                        // Titulo
                        // 
                        this.Titulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Titulo.Location = new System.Drawing.Point(24, 24);
                        this.Titulo.Name = "Titulo";
                        this.Titulo.Size = new System.Drawing.Size(584, 32);
                        this.Titulo.TabIndex = 58;
                        this.Titulo.Text = "Panel de control de impresora fiscal";
                        this.Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Titulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        // 
                        // label3
                        // 
                        this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label3.Location = new System.Drawing.Point(24, 56);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(584, 48);
                        this.label3.TabIndex = 59;
                        this.label3.Text = "Si aun no configuró su impresora fiscal, hágalo ahora desde el menú Comprobantes " +
    "-> Tablas -> Puntos de venta.";
                        // 
                        // Fiscal
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(634, 371);
                        this.Controls.Add(this.EntradaPv);
                        this.Controls.Add(this.BotonIniciarDetener);
                        this.Controls.Add(this.EtiquetaEstadoServidor);
                        this.Controls.Add(this.EtiquetaUltimoCierreZ);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.BotonReiniciar);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.EtiquetaCierreZ);
                        this.Controls.Add(this.BotonCierreZ);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.Titulo);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.Name = "Fiscal";
                        this.Text = "Panel de impresora fiscal";
                        this.Load += new System.EventHandler(this.Fiscal_Load);
                        this.Controls.SetChildIndex(this.Titulo, 0);
                        this.Controls.SetChildIndex(this.label3, 0);
                        this.Controls.SetChildIndex(this.BotonCierreZ, 0);
                        this.Controls.SetChildIndex(this.EtiquetaCierreZ, 0);
                        this.Controls.SetChildIndex(this.label1, 0);
                        this.Controls.SetChildIndex(this.BotonReiniciar, 0);
                        this.Controls.SetChildIndex(this.label2, 0);
                        this.Controls.SetChildIndex(this.EtiquetaUltimoCierreZ, 0);
                        this.Controls.SetChildIndex(this.EtiquetaEstadoServidor, 0);
                        this.Controls.SetChildIndex(this.BotonIniciarDetener, 0);
                        this.Controls.SetChildIndex(this.EntradaPv, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }
                #endregion

                internal Lui.Forms.Button BotonCierreZ;
                internal System.Windows.Forms.Timer Timer1;
                private Lui.Forms.Label label1;
                internal Lui.Forms.ComboBox EntradaPv;
                internal Lui.Forms.Label label2;
                internal Lui.Forms.Button BotonReiniciar;
                internal Lui.Forms.Button BotonIniciarDetener;
                internal Lui.Forms.Label EtiquetaEstadoServidor;
                internal Lui.Forms.Label EtiquetaUltimoCierreZ;
                internal Lui.Forms.Label EtiquetaCierreZ;
                private Lui.Forms.Label Titulo;
                private Lui.Forms.Label label3;

        }
}
