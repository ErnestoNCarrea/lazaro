namespace Lfc.Reportes
{
        partial class Reporte
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
                        this.ListViewReporte = new Lui.Forms.ListView();
                        this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
                        this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
                        this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
                        this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
                        this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
                        this.BotonActualizar = new Lui.Forms.Button();
                        this.EntradaExpandirGrupos = new Lui.Forms.ComboBox();
                        this.SuspendLayout();
                        // 
                        // ListViewReporte
                        // 
                        this.ListViewReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.ListViewReporte.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
                        this.ListViewReporte.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.ListViewReporte.Location = new System.Drawing.Point(12, 44);
                        this.ListViewReporte.Name = "ListViewReporte";
                        this.ListViewReporte.Size = new System.Drawing.Size(744, 424);
                        this.ListViewReporte.TabIndex = 2;
                        this.ListViewReporte.UseCompatibleStateImageBehavior = false;
                        this.ListViewReporte.View = System.Windows.Forms.View.Details;
                        // 
                        // BotonActualizar
                        // 
                        this.BotonActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonActualizar.AutoSize = false;
                        this.BotonActualizar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonActualizar.Image = null;
                        this.BotonActualizar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonActualizar.Location = new System.Drawing.Point(668, 12);
                        this.BotonActualizar.Name = "BotonActualizar";
                        this.BotonActualizar.Size = new System.Drawing.Size(84, 24);
                        this.BotonActualizar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonActualizar.Subtext = "Tecla";
                        this.BotonActualizar.TabIndex = 1;
                        this.BotonActualizar.Text = "Actualizar";
                        this.BotonActualizar.Click += new System.EventHandler(this.BotonActualizar_Click);
                        // 
                        // EntradaExpandirGrupos
                        // 
                        this.EntradaExpandirGrupos.AutoSize = false;
                        this.EntradaExpandirGrupos.Name = "EntradaExpandirGrupos";
                        this.EntradaExpandirGrupos.SetData = new string[] {
        "Mostrar detalles|1",
        "Sólo subtotales|0"};
                        this.EntradaExpandirGrupos.Size = new System.Drawing.Size(148, 24);
                        this.EntradaExpandirGrupos.TabIndex = 0;
                        this.EntradaExpandirGrupos.TextKey = "0";
                        // 
                        // Reporte
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(768, 480);
                        this.Controls.Add(this.EntradaExpandirGrupos);
                        this.Controls.Add(this.BotonActualizar);
                        this.Controls.Add(this.ListViewReporte);
                        this.Name = "Reporte";
                        this.Text = "Reporte";
                        this.ResumeLayout(false);

                }

                #endregion

                private Lui.Forms.ListView ListViewReporte;
                private Lui.Forms.Button BotonActualizar;
                private System.Windows.Forms.ColumnHeader columnHeader1;
                private System.Windows.Forms.ColumnHeader columnHeader2;
                private System.Windows.Forms.ColumnHeader columnHeader3;
                private System.Windows.Forms.ColumnHeader columnHeader4;
                private System.Windows.Forms.ColumnHeader columnHeader5;
                internal Lui.Forms.ComboBox EntradaExpandirGrupos;
        }
}
