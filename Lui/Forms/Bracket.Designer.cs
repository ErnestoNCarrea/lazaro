namespace Lui.Forms
{
        partial class Bracket
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
                        this.label1 = new System.Windows.Forms.Label();
                        this.label2 = new System.Windows.Forms.Label();
                        this.label3 = new System.Windows.Forms.Label();
                        this.label4 = new System.Windows.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // label1
                        // 
                        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.label1.Location = new System.Drawing.Point(8, 0);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(48, 1);
                        this.label1.TabIndex = 0;
                        // 
                        // label2
                        // 
                        this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
                        this.label2.Location = new System.Drawing.Point(0, 156);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(8, 1);
                        this.label2.TabIndex = 1;
                        // 
                        // label3
                        // 
                        this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right)));
                        this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
                        this.label3.Location = new System.Drawing.Point(8, 319);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(48, 1);
                        this.label3.TabIndex = 2;
                        // 
                        // label4
                        // 
                        this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)));
                        this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
                        this.label4.Location = new System.Drawing.Point(8, 0);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(1, 320);
                        this.label4.TabIndex = 3;
                        // 
                        // Bracket
                        // 
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.label1);
                        this.Name = "Bracket";
                        this.Size = new System.Drawing.Size(58, 321);
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.Label label1;
                private System.Windows.Forms.Label label2;
                private System.Windows.Forms.Label label3;
                private System.Windows.Forms.Label label4;
        }
}
