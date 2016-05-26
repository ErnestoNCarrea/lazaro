namespace Lfc
{
        partial class FormularioEdicion
        {
                private System.ComponentModel.IContainer components = null;

                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }
                        base.Dispose(disposing);
                }

                #region Código generado por el Diseñador de Windows Forms

                private void InitializeComponent()
                {
                        this.PanelAccionesPrimariasYSecundarias = new Lui.Forms.ActionsPanel();
                        this.PanelEdicion = new Lui.Forms.Panel();
                        this.EntradaImagen = new Lcc.Entrada.Imagen();
                        this.EntradaTags = new Lcc.Edicion.MatrizTags();
                        this.EntradaComentarios = new Lcc.Edicion.Comentarios();
                        this.Encabezado = new Lui.Forms.FormHeader();
                        this.PanelAccionesTerciarias = new Lui.Forms.SecondaryActionsPanel();
                        this.PanelExtendido = new Lui.Forms.Panel();
                        this.label1 = new System.Windows.Forms.Label();
                        this.LabelSep1 = new System.Windows.Forms.Label();
                        this.PanelExtendido.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // PanelAccionesPrimariasYSecundarias
                        // 
                        this.PanelAccionesPrimariasYSecundarias.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.PanelAccionesPrimariasYSecundarias.FormActions = null;
                        this.PanelAccionesPrimariasYSecundarias.Location = new System.Drawing.Point(0, 409);
                        this.PanelAccionesPrimariasYSecundarias.Name = "PanelAccionesPrimariasYSecundarias";
                        this.PanelAccionesPrimariasYSecundarias.Padding = new System.Windows.Forms.Padding(12);
                        this.PanelAccionesPrimariasYSecundarias.Size = new System.Drawing.Size(792, 64);
                        this.PanelAccionesPrimariasYSecundarias.TabIndex = 2;
                        this.PanelAccionesPrimariasYSecundarias.ButtonClick += new System.EventHandler(this.LowerPanel_ButtonClick);
                        // 
                        // PanelEdicion
                        // 
                        this.PanelEdicion.AutoScroll = true;
                        this.PanelEdicion.AutoScrollMargin = new System.Drawing.Size(0, 48);
                        this.PanelEdicion.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.PanelEdicion.Location = new System.Drawing.Point(0, 64);
                        this.PanelEdicion.Name = "PanelEdicion";
                        this.PanelEdicion.Padding = new System.Windows.Forms.Padding(24, 24, 16, 16);
                        this.PanelEdicion.Size = new System.Drawing.Size(432, 345);
                        this.PanelEdicion.TabIndex = 0;
                        // 
                        // EntradaImagen
                        // 
                        this.EntradaImagen.Dock = System.Windows.Forms.DockStyle.Top;
                        this.EntradaImagen.Font = new System.Drawing.Font("Bitstream Vera Sans", 9.75F);
                        this.EntradaImagen.Location = new System.Drawing.Point(12, 12);
                        this.EntradaImagen.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
                        this.EntradaImagen.MinimumSize = new System.Drawing.Size(240, 160);
                        this.EntradaImagen.Name = "EntradaImagen";
                        this.EntradaImagen.Size = new System.Drawing.Size(319, 172);
                        this.EntradaImagen.TabIndex = 0;
                        this.EntradaImagen.Text = "Imagen";
                        // 
                        // EntradaTags
                        // 
                        this.EntradaTags.AutoScrollMargin = new System.Drawing.Size(0, 12);
                        this.EntradaTags.AutoSize = true;
                        this.EntradaTags.Dock = System.Windows.Forms.DockStyle.Top;
                        this.EntradaTags.Font = new System.Drawing.Font("Bitstream Vera Sans", 9.75F);
                        this.EntradaTags.Location = new System.Drawing.Point(12, 372);
                        this.EntradaTags.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
                        this.EntradaTags.MinimumSize = new System.Drawing.Size(240, 160);
                        this.EntradaTags.Name = "EntradaTags";
                        this.EntradaTags.Size = new System.Drawing.Size(319, 160);
                        this.EntradaTags.TabIndex = 2;
                        this.EntradaTags.Text = "Otros atributos";
                        // 
                        // EntradaComentarios
                        // 
                        this.EntradaComentarios.Dock = System.Windows.Forms.DockStyle.Top;
                        this.EntradaComentarios.Font = new System.Drawing.Font("Bitstream Vera Sans", 9.75F);
                        this.EntradaComentarios.Location = new System.Drawing.Point(12, 196);
                        this.EntradaComentarios.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
                        this.EntradaComentarios.MinimumSize = new System.Drawing.Size(240, 152);
                        this.EntradaComentarios.Name = "EntradaComentarios";
                        this.EntradaComentarios.Size = new System.Drawing.Size(319, 164);
                        this.EntradaComentarios.TabIndex = 1;
                        this.EntradaComentarios.Text = "Comentarios";
                        // 
                        // Encabezado
                        // 
                        this.Encabezado.Dock = System.Windows.Forms.DockStyle.Top;
                        this.Encabezado.Location = new System.Drawing.Point(0, 0);
                        this.Encabezado.Name = "Encabezado";
                        this.Encabezado.Size = new System.Drawing.Size(792, 64);
                        this.Encabezado.TabIndex = 4;
                        this.Encabezado.Text = "Encab";
                        // 
                        // PanelAccionesTerciarias
                        // 
                        this.PanelAccionesTerciarias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.PanelAccionesTerciarias.FormActions = null;
                        this.PanelAccionesTerciarias.Location = new System.Drawing.Point(432, 38);
                        this.PanelAccionesTerciarias.Name = "PanelAccionesTerciarias";
                        this.PanelAccionesTerciarias.Size = new System.Drawing.Size(352, 24);
                        this.PanelAccionesTerciarias.TabIndex = 3;
                        this.PanelAccionesTerciarias.ButtonClick += new System.EventHandler(this.PanelAccionesTerciarias_ButtonClick);
                        // 
                        // PanelExtendido
                        // 
                        this.PanelExtendido.AutoScroll = true;
                        this.PanelExtendido.AutoScrollMargin = new System.Drawing.Size(0, 48);
                        this.PanelExtendido.Controls.Add(this.EntradaTags);
                        this.PanelExtendido.Controls.Add(this.label1);
                        this.PanelExtendido.Controls.Add(this.EntradaComentarios);
                        this.PanelExtendido.Controls.Add(this.LabelSep1);
                        this.PanelExtendido.Controls.Add(this.EntradaImagen);
                        this.PanelExtendido.Dock = System.Windows.Forms.DockStyle.Right;
                        this.PanelExtendido.Location = new System.Drawing.Point(432, 64);
                        this.PanelExtendido.Name = "PanelExtendido";
                        this.PanelExtendido.Padding = new System.Windows.Forms.Padding(12);
                        this.PanelExtendido.Size = new System.Drawing.Size(360, 345);
                        this.PanelExtendido.TabIndex = 1;
                        this.PanelExtendido.Visible = false;
                        // 
                        // label1
                        // 
                        this.label1.Dock = System.Windows.Forms.DockStyle.Top;
                        this.label1.Location = new System.Drawing.Point(12, 360);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(319, 12);
                        this.label1.TabIndex = 4;
                        // 
                        // LabelSep1
                        // 
                        this.LabelSep1.Dock = System.Windows.Forms.DockStyle.Top;
                        this.LabelSep1.Location = new System.Drawing.Point(12, 184);
                        this.LabelSep1.Name = "LabelSep1";
                        this.LabelSep1.Size = new System.Drawing.Size(319, 12);
                        this.LabelSep1.TabIndex = 3;
                        // 
                        // FormularioEdicion
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(792, 473);
                        this.Controls.Add(this.PanelEdicion);
                        this.Controls.Add(this.PanelExtendido);
                        this.Controls.Add(this.PanelAccionesTerciarias);
                        this.Controls.Add(this.PanelAccionesPrimariasYSecundarias);
                        this.Controls.Add(this.Encabezado);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.Name = "FormularioEdicion";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        this.Text = "Editar";
                        this.PanelExtendido.ResumeLayout(false);
                        this.PanelExtendido.PerformLayout();
                        this.ResumeLayout(false);

                }

                #endregion

                private Lui.Forms.ActionsPanel PanelAccionesPrimariasYSecundarias;
                private Lui.Forms.Panel PanelEdicion;
                private Lcc.Entrada.Imagen EntradaImagen;
                private Lcc.Edicion.MatrizTags EntradaTags;
                private Lcc.Edicion.Comentarios EntradaComentarios;
                private Lui.Forms.FormHeader Encabezado;
                private Lui.Forms.SecondaryActionsPanel PanelAccionesTerciarias;
                private Lui.Forms.Panel PanelExtendido;
                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Label LabelSep1;
        }
}
