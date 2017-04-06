namespace Lui.Forms
{
        partial class YesNo
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
                        this.EtiquetaSi = new System.Windows.Forms.Label();
                        this.EtiquetaNo = new System.Windows.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EtiquetaSi
                        // 
                        this.EtiquetaSi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
                        this.EtiquetaSi.AutoEllipsis = true;
                        this.EtiquetaSi.BackColor = System.Drawing.SystemColors.Highlight;
                        this.EtiquetaSi.ForeColor = System.Drawing.SystemColors.HighlightText;
                        this.EtiquetaSi.Location = new System.Drawing.Point(2, 2);
                        this.EtiquetaSi.Name = "EtiquetaSi";
                        this.EtiquetaSi.Size = new System.Drawing.Size(32, 23);
                        this.EtiquetaSi.TabIndex = 0;
                        this.EtiquetaSi.Text = "Sí";
                        this.EtiquetaSi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.EtiquetaSi.Click += new System.EventHandler(this.EtiquetaSi_Click);
                        // 
                        // EtiquetaNo
                        // 
                        this.EtiquetaNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
                        this.EtiquetaNo.AutoEllipsis = true;
                        this.EtiquetaNo.Location = new System.Drawing.Point(37, 2);
                        this.EtiquetaNo.Name = "EtiquetaNo";
                        this.EtiquetaNo.Size = new System.Drawing.Size(32, 23);
                        this.EtiquetaNo.TabIndex = 1;
                        this.EtiquetaNo.Text = "No";
                        this.EtiquetaNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.EtiquetaNo.Click += new System.EventHandler(this.EtiquetaNo_Click);
                        // 
                        // YesNo
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.Controls.Add(this.EtiquetaNo);
                        this.Controls.Add(this.EtiquetaSi);
                        this.Name = "YesNo";
                        this.Size = new System.Drawing.Size(74, 27);
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Label EtiquetaSi;
                private System.Windows.Forms.Label EtiquetaNo;
        }
}
