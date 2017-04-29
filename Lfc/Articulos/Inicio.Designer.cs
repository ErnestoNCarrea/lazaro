using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lfc.Articulos
{
        public partial class Inicio : Lfc.FormularioListado
        {
                protected Lui.Forms.Button BotonCambioMasivoPrecios;

                private void InitializeComponent()
                {
                        this.BotonCambioMasivoPrecios = new Lui.Forms.Button();
                        this.PanelContadores.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // EtiquetaListadoVacio
                        // 
                        this.EtiquetaListadoVacio.Size = new System.Drawing.Size(583, 100);
                        // 
                        // BotonCrear
                        // 
                        this.BotonCrear.Location = new System.Drawing.Point(54, 409);
                        // 
                        // Listado
                        // 
                        this.Listado.Size = new System.Drawing.Size(908, 661);
                        // 
                        // BotonCambioMasivoPrecios
                        // 
                        this.BotonCambioMasivoPrecios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonCambioMasivoPrecios.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonCambioMasivoPrecios.Image = null;
                        this.BotonCambioMasivoPrecios.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonCambioMasivoPrecios.Location = new System.Drawing.Point(55, 171);
                        this.BotonCambioMasivoPrecios.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
                        this.BotonCambioMasivoPrecios.MaximumSize = new System.Drawing.Size(160, 64);
                        this.BotonCambioMasivoPrecios.MinimumSize = new System.Drawing.Size(96, 32);
                        this.BotonCambioMasivoPrecios.Name = "BotonCambioMasivoPrecios";
                        this.BotonCambioMasivoPrecios.Size = new System.Drawing.Size(160, 50);
                        this.BotonCambioMasivoPrecios.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.BotonCambioMasivoPrecios.Subtext = "F7";
                        this.BotonCambioMasivoPrecios.TabIndex = 49;
                        this.BotonCambioMasivoPrecios.Text = "Precios";
                        this.BotonCambioMasivoPrecios.Click += new System.EventHandler(this.BotonCambioMasivoPrecios_Click);
                        // 
                        // Inicio
                        // 
                        this.PanelAcciones.Controls.Add(this.BotonCambioMasivoPrecios);
                        this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
                        this.ClientSize = new System.Drawing.Size(972, 551);
                        this.Name = "Inicio";
                        this.PanelContadores.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).EndInit();
                        this.ResumeLayout(false);

                }
        }
}
