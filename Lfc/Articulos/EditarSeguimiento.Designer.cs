namespace Lfc.Articulos
{
        partial class EditarSeguimiento
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
                        this.VariacionesCantidades = new Lcc.Entrada.Articulos.MatrizVariacionCantidad();
                        this.ListaDatosSeguimiento = new Lui.Forms.ListView();
                        this.Variacion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.VariacionCantidad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.VariacionStock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.EtiquetaArticulo = new Lui.Forms.Label();
                        this.label1 = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // VariacionesCantidades
                        // 
                        this.VariacionesCantidades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.VariacionesCantidades.AutoScrollMargin = new System.Drawing.Size(4, 4);
                        this.VariacionesCantidades.EsNumeroDeSerie = false;
                        this.VariacionesCantidades.Location = new System.Drawing.Point(24, 104);
                        this.VariacionesCantidades.Name = "VariacionesCantidades";
                        this.VariacionesCantidades.Size = new System.Drawing.Size(584, 168);
                        this.VariacionesCantidades.TabIndex = 0;
                        // 
                        // ListaDatosSeguimiento
                        // 
                        this.ListaDatosSeguimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.ListaDatosSeguimiento.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.ListaDatosSeguimiento.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Variacion,
            this.VariacionCantidad,
            this.VariacionStock});
                        this.ListaDatosSeguimiento.FieldName = null;
                        this.ListaDatosSeguimiento.FullRowSelect = true;
                        this.ListaDatosSeguimiento.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.ListaDatosSeguimiento.HideSelection = false;
                        this.ListaDatosSeguimiento.Location = new System.Drawing.Point(24, 104);
                        this.ListaDatosSeguimiento.MultiSelect = false;
                        this.ListaDatosSeguimiento.Name = "ListaDatosSeguimiento";
                        this.ListaDatosSeguimiento.ReadOnly = false;
                        this.ListaDatosSeguimiento.Size = new System.Drawing.Size(584, 172);
                        this.ListaDatosSeguimiento.TabIndex = 1;
                        this.ListaDatosSeguimiento.UseCompatibleStateImageBehavior = false;
                        this.ListaDatosSeguimiento.View = System.Windows.Forms.View.Details;
                        this.ListaDatosSeguimiento.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListaDatosSeguimiento_ItemChecked);
                        this.ListaDatosSeguimiento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListaSeries_KeyDown);
                        this.ListaDatosSeguimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ListaDatosSeguimiento_KeyPress);
                        // 
                        // Variacion
                        // 
                        this.Variacion.Text = "Variación";
                        this.Variacion.Width = 446;
                        // 
                        // VariacionCantidad
                        // 
                        this.VariacionCantidad.Text = "Cant.";
                        this.VariacionCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        // 
                        // VariacionStock
                        // 
                        this.VariacionStock.Text = "Máx.";
                        this.VariacionStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                        this.VariacionStock.Width = 45;
                        // 
                        // EtiquetaArticulo
                        // 
                        this.EtiquetaArticulo.AutoEllipsis = true;
                        this.EtiquetaArticulo.Location = new System.Drawing.Point(24, 24);
                        this.EtiquetaArticulo.Name = "EtiquetaArticulo";
                        this.EtiquetaArticulo.Size = new System.Drawing.Size(584, 32);
                        this.EtiquetaArticulo.TabIndex = 51;
                        this.EtiquetaArticulo.Text = "Seleccione artículos";
                        this.EtiquetaArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.EtiquetaArticulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        this.EtiquetaArticulo.UseMnemonic = false;
                        // 
                        // label1
                        // 
                        this.label1.AutoEllipsis = true;
                        this.label1.Location = new System.Drawing.Point(24, 56);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(584, 48);
                        this.label1.TabIndex = 52;
                        this.label1.Text = "El artículo seleccionado utiliza seguimiento (por ejemplo números de serie o tall" +
    "es y colores). Proporcione los datos de seguimiento del artículo seleccionado.";
                        this.label1.UseMnemonic = false;
                        // 
                        // label2
                        // 
                        this.label2.AutoEllipsis = true;
                        this.label2.Location = new System.Drawing.Point(24, 276);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(584, 20);
                        this.label2.TabIndex = 53;
                        this.label2.Text = "Utilice los números o las teclas + y - para cambiar la cantidad de la variación s" +
    "eleccionada.";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label2.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        this.label2.UseMnemonic = false;
                        // 
                        // EditarSeguimiento
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(634, 372);
                        this.Controls.Add(this.EtiquetaArticulo);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.ListaDatosSeguimiento);
                        this.Controls.Add(this.VariacionesCantidades);
                        this.Controls.Add(this.label1);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "EditarSeguimiento";
                        this.Text = "Datos de Seguimiento";
                        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditarSeries_KeyDown);
                        this.Controls.SetChildIndex(this.label1, 0);
                        this.Controls.SetChildIndex(this.VariacionesCantidades, 0);
                        this.Controls.SetChildIndex(this.ListaDatosSeguimiento, 0);
                        this.Controls.SetChildIndex(this.label2, 0);
                        this.Controls.SetChildIndex(this.EtiquetaArticulo, 0);
                        this.ResumeLayout(false);

                }

                #endregion

                private Lcc.Entrada.Articulos.MatrizVariacionCantidad VariacionesCantidades;
                private Lui.Forms.ListView ListaDatosSeguimiento;
                private System.Windows.Forms.ColumnHeader Variacion;
                private System.Windows.Forms.ColumnHeader VariacionCantidad;
                private Lui.Forms.Label EtiquetaArticulo;
                private Lui.Forms.Label label1;
                private Lui.Forms.Label label2;
                private System.Windows.Forms.ColumnHeader VariacionStock;

        }
}
