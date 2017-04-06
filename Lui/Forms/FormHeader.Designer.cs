namespace Lui.Forms
{
        partial class FormHeader
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
                        this.ImageIcon = new System.Windows.Forms.PictureBox();
                        this.LabelColor = new System.Windows.Forms.Label();
                        this.LabelColor2 = new System.Windows.Forms.Label();
                        this.label1 = new System.Windows.Forms.Label();
                        this.LabelCaption = new Lui.Forms.Label();
                        ((System.ComponentModel.ISupportInitialize)(this.ImageIcon)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // ImageIcon
                        // 
                        this.ImageIcon.Image = global::Lui.Properties.Resources.form;
                        this.ImageIcon.Location = new System.Drawing.Point(32, 16);
                        this.ImageIcon.Name = "ImageIcon";
                        this.ImageIcon.Size = new System.Drawing.Size(32, 32);
                        this.ImageIcon.TabIndex = 1;
                        this.ImageIcon.TabStop = false;
                        // 
                        // LabelColor
                        // 
                        this.LabelColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.LabelColor.BackColor = System.Drawing.Color.Sienna;
                        this.LabelColor.Location = new System.Drawing.Point(320, 8);
                        this.LabelColor.Name = "LabelColor";
                        this.LabelColor.Size = new System.Drawing.Size(128, 16);
                        this.LabelColor.TabIndex = 2;
                        this.LabelColor.UseMnemonic = false;
                        // 
                        // LabelColor2
                        // 
                        this.LabelColor2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.LabelColor2.BackColor = System.Drawing.Color.SaddleBrown;
                        this.LabelColor2.Location = new System.Drawing.Point(320, 0);
                        this.LabelColor2.Name = "LabelColor2";
                        this.LabelColor2.Size = new System.Drawing.Size(128, 8);
                        this.LabelColor2.TabIndex = 3;
                        this.LabelColor2.UseMnemonic = false;
                        // 
                        // label1
                        // 
                        this.label1.BackColor = System.Drawing.Color.Tan;
                        this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.label1.Location = new System.Drawing.Point(0, 63);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(600, 1);
                        this.label1.TabIndex = 4;
                        this.label1.UseMnemonic = false;
                        this.label1.Visible = false;
                        // 
                        // LabelCaption
                        // 
                        this.LabelCaption.AutoSize = true;
                        this.LabelCaption.Location = new System.Drawing.Point(72, 16);
                        this.LabelCaption.Name = "LabelCaption";
                        this.LabelCaption.Size = new System.Drawing.Size(210, 30);
                        this.LabelCaption.TabIndex = 0;
                        this.LabelCaption.Text = "Título del formulario";
                        this.LabelCaption.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        this.LabelCaption.UseMnemonic = false;
                        // 
                        // FormHeader
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.Controls.Add(this.LabelColor2);
                        this.Controls.Add(this.LabelColor);
                        this.Controls.Add(this.ImageIcon);
                        this.Controls.Add(this.LabelCaption);
                        this.Controls.Add(this.label1);
                        this.Name = "FormHeader";
                        this.Size = new System.Drawing.Size(600, 64);
                        ((System.ComponentModel.ISupportInitialize)(this.ImageIcon)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private Label LabelCaption;
                private System.Windows.Forms.PictureBox ImageIcon;
                private System.Windows.Forms.Label LabelColor;
                private System.Windows.Forms.Label LabelColor2;
                private System.Windows.Forms.Label label1;
        }
}
