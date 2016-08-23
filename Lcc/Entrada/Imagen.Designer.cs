using System;
using System.Collections.Generic;
using System.Text;

namespace Lcc.Entrada
{
        public partial class Imagen
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
                        if (this.Arch != null)
                                this.Arch.Dispose();

                        if (disposing && (components != null)) {
                                components.Dispose();
                        }
                        base.Dispose(disposing);
                }

                private void InitializeComponent()
                {
                        this.components = new System.ComponentModel.Container();
                        this.EntradaImagen = new System.Windows.Forms.PictureBox();
                        this.MenuImagen = new System.Windows.Forms.ContextMenuStrip(this.components);
                        this.guardarEnarchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.copiarAlPortapapelesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        this.BotonQuitarImagen = new Lui.Forms.Button();
                        this.BotonSeleccionarImagen = new Lui.Forms.Button();
                        this.BotonCapturarImagen = new Lui.Forms.Button();
                        this.GroupLabel = new Lui.Forms.Label();
                        ((System.ComponentModel.ISupportInitialize)(this.EntradaImagen)).BeginInit();
                        this.MenuImagen.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // EntradaImagen
                        // 
                        this.EntradaImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaImagen.BackColor = System.Drawing.Color.White;
                        this.EntradaImagen.ContextMenuStrip = this.MenuImagen;
                        this.EntradaImagen.Location = new System.Drawing.Point(0, 32);
                        this.EntradaImagen.Name = "EntradaImagen";
                        this.EntradaImagen.Size = new System.Drawing.Size(140, 125);
                        this.EntradaImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        this.EntradaImagen.TabIndex = 100;
                        this.EntradaImagen.TabStop = false;
                        // 
                        // MenuImagen
                        // 
                        this.MenuImagen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarEnarchivoToolStripMenuItem,
            this.copiarAlPortapapelesToolStripMenuItem});
                        this.MenuImagen.Name = "MenuImagen";
                        this.MenuImagen.Size = new System.Drawing.Size(193, 48);
                        // 
                        // guardarEnarchivoToolStripMenuItem
                        // 
                        this.guardarEnarchivoToolStripMenuItem.Name = "guardarEnarchivoToolStripMenuItem";
                        this.guardarEnarchivoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
                        this.guardarEnarchivoToolStripMenuItem.Text = "Guardar en &archivo...";
                        this.guardarEnarchivoToolStripMenuItem.Click += new System.EventHandler(this.GuardarEnarchivoToolStripMenuItem_Click);
                        // 
                        // copiarAlPortapapelesToolStripMenuItem
                        // 
                        this.copiarAlPortapapelesToolStripMenuItem.Name = "copiarAlPortapapelesToolStripMenuItem";
                        this.copiarAlPortapapelesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
                        this.copiarAlPortapapelesToolStripMenuItem.Text = "&Copiar al portapapeles";
                        this.copiarAlPortapapelesToolStripMenuItem.Click += new System.EventHandler(this.CopiarAlPortapapelesToolStripMenuItem_Click);
                        // 
                        // BotonQuitarImagen
                        // 
                        this.BotonQuitarImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonQuitarImagen.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonQuitarImagen.Image = null;
                        this.BotonQuitarImagen.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonQuitarImagen.Location = new System.Drawing.Point(144, 128);
                        this.BotonQuitarImagen.Name = "BotonQuitarImagen";
                        this.BotonQuitarImagen.Size = new System.Drawing.Size(96, 32);
                        this.BotonQuitarImagen.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonQuitarImagen.Subtext = "";
                        this.BotonQuitarImagen.TabIndex = 2;
                        this.BotonQuitarImagen.Text = "Sin imagen";
                        this.BotonQuitarImagen.Click += new System.EventHandler(this.BotonQuitarImagen_Click);
                        // 
                        // BotonSeleccionarImagen
                        // 
                        this.BotonSeleccionarImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonSeleccionarImagen.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonSeleccionarImagen.Image = null;
                        this.BotonSeleccionarImagen.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonSeleccionarImagen.Location = new System.Drawing.Point(144, 80);
                        this.BotonSeleccionarImagen.Name = "BotonSeleccionarImagen";
                        this.BotonSeleccionarImagen.Size = new System.Drawing.Size(96, 42);
                        this.BotonSeleccionarImagen.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonSeleccionarImagen.Subtext = "";
                        this.BotonSeleccionarImagen.TabIndex = 1;
                        this.BotonSeleccionarImagen.Text = "Seleccionar un archivo";
                        this.BotonSeleccionarImagen.Click += new System.EventHandler(this.BotonSeleccionarImagen_Click);
                        // 
                        // BotonCapturarImagen
                        // 
                        this.BotonCapturarImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonCapturarImagen.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonCapturarImagen.Image = null;
                        this.BotonCapturarImagen.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonCapturarImagen.Location = new System.Drawing.Point(144, 32);
                        this.BotonCapturarImagen.Name = "BotonCapturarImagen";
                        this.BotonCapturarImagen.Size = new System.Drawing.Size(96, 42);
                        this.BotonCapturarImagen.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonCapturarImagen.Subtext = "";
                        this.BotonCapturarImagen.TabIndex = 0;
                        this.BotonCapturarImagen.Text = "Usar un escáner";
                        this.BotonCapturarImagen.Click += new System.EventHandler(this.BotonCapturarImagen_Click);
                        // 
                        // GroupLabel
                        // 
                        this.GroupLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.GroupLabel.Location = new System.Drawing.Point(0, 0);
                        this.GroupLabel.Name = "GroupLabel";
                        this.GroupLabel.Size = new System.Drawing.Size(240, 24);
                        this.GroupLabel.TabIndex = 2;
                        this.GroupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.GroupLabel.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader2;
                        this.GroupLabel.UseMnemonic = false;
                        // 
                        // Imagen
                        // 
                        this.Controls.Add(this.GroupLabel);
                        this.Controls.Add(this.EntradaImagen);
                        this.Controls.Add(this.BotonCapturarImagen);
                        this.Controls.Add(this.BotonQuitarImagen);
                        this.Controls.Add(this.BotonSeleccionarImagen);
                        this.MinimumSize = new System.Drawing.Size(240, 160);
                        this.Name = "Imagen";
                        this.Size = new System.Drawing.Size(240, 160);
                        ((System.ComponentModel.ISupportInitialize)(this.EntradaImagen)).EndInit();
                        this.MenuImagen.ResumeLayout(false);
                        this.ResumeLayout(false);

                }

                internal Lui.Forms.Button BotonCapturarImagen;
                private System.Windows.Forms.ContextMenuStrip MenuImagen;
                private System.Windows.Forms.ToolStripMenuItem guardarEnarchivoToolStripMenuItem;
                private System.Windows.Forms.ToolStripMenuItem copiarAlPortapapelesToolStripMenuItem;
                private Lui.Forms.Label GroupLabel;
        }
}
