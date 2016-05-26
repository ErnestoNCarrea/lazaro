namespace Lcc.Entrada
{
        partial class Filtros
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

                #region Código generado por el Diseñador de componentes

                /// <summary> 
                /// Método necesario para admitir el Diseñador. No se puede modificar 
                /// el contenido del método con el editor de código.
                /// </summary>
                private void InitializeComponent()
                {
                        this.TablaFiltros = new Lui.Forms.TableLayoutPanel();
                        this.PanelInferior = new System.Windows.Forms.FlowLayoutPanel();
                        this.BotonAplicar = new Lui.Forms.Button();
                        this.PanelInferior.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // TablaFiltros
                        // 
                        this.TablaFiltros.AutoScroll = true;
                        this.TablaFiltros.AutoScrollMargin = new System.Drawing.Size(0, 24);
                        this.TablaFiltros.AutoSize = true;
                        this.TablaFiltros.ColumnCount = 2;
                        this.TablaFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                        this.TablaFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
                        this.TablaFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.TablaFiltros.Location = new System.Drawing.Point(3, 4);
                        this.TablaFiltros.MaximumSize = new System.Drawing.Size(800, 600);
                        this.TablaFiltros.Name = "TablaFiltros";
                        this.TablaFiltros.Padding = new System.Windows.Forms.Padding(12);
                        this.TablaFiltros.RowCount = 1;
                        this.TablaFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.TablaFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle());
                        this.TablaFiltros.Size = new System.Drawing.Size(336, 223);
                        this.TablaFiltros.TabIndex = 0;
                        // 
                        // PanelInferior
                        // 
                        this.PanelInferior.AutoSize = true;
                        this.PanelInferior.Controls.Add(this.BotonAplicar);
                        this.PanelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.PanelInferior.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
                        this.PanelInferior.Location = new System.Drawing.Point(3, 227);
                        this.PanelInferior.Name = "PanelInferior";
                        this.PanelInferior.Size = new System.Drawing.Size(336, 28);
                        this.PanelInferior.TabIndex = 1;
                        // 
                        // BotonAplicar
                        // 
                        this.BotonAplicar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonAplicar.Image = null;
                        this.BotonAplicar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonAplicar.Location = new System.Drawing.Point(261, 3);
                        this.BotonAplicar.Name = "BotonAplicar";
                        this.BotonAplicar.ReadOnly = false;
                        this.BotonAplicar.Size = new System.Drawing.Size(72, 22);
                        this.BotonAplicar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonAplicar.Subtext = "Tecla";
                        this.BotonAplicar.TabIndex = 0;
                        this.BotonAplicar.Text = "Aplicar";
                        this.BotonAplicar.Click += new System.EventHandler(this.BotonAplicar_Click);
                        // 
                        // Filtros
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.AutoScroll = true;
                        this.AutoSize = true;
                        this.Controls.Add(this.TablaFiltros);
                        this.Controls.Add(this.PanelInferior);
                        this.Name = "Filtros";
                        this.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
                        this.Size = new System.Drawing.Size(342, 259);
                        this.PanelInferior.ResumeLayout(false);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                protected Lui.Forms.TableLayoutPanel TablaFiltros;
                private System.Windows.Forms.FlowLayoutPanel PanelInferior;
                private Lui.Forms.Button BotonAplicar;
        }
}
