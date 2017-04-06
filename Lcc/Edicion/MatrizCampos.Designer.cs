namespace Lcc.Edicion
{
        partial class MatrizCampos : ControlEdicion
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
                        this.GroupLabel = new Lui.Forms.Label();
                        this.FieldContainer = new Lui.Forms.Panel();
                        this.SuspendLayout();
                        // 
                        // GroupLabel
                        // 
                        this.GroupLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.GroupLabel.Location = new System.Drawing.Point(0, 0);
                        this.GroupLabel.Name = "GroupLabel";
                        this.GroupLabel.Size = new System.Drawing.Size(460, 24);
                        this.GroupLabel.TabIndex = 1;
                        this.GroupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.GroupLabel.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader2;
                        this.GroupLabel.UseMnemonic = false;
                        // 
                        // FieldContainer
                        // 
                        this.FieldContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.FieldContainer.Location = new System.Drawing.Point(0, 32);
                        this.FieldContainer.Margin = new System.Windows.Forms.Padding(0);
                        this.FieldContainer.Name = "FieldContainer";
                        this.FieldContainer.Size = new System.Drawing.Size(460, 0);
                        this.FieldContainer.TabIndex = 2;
                        // 
                        // MatrizCampos
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                        this.Controls.Add(this.FieldContainer);
                        this.Controls.Add(this.GroupLabel);
                        this.Name = "MatrizCampos";
                        this.Size = new System.Drawing.Size(460, 212);
                        this.ResumeLayout(false);

                }

                #endregion

                private Lui.Forms.Label GroupLabel;
                protected Lui.Forms.Panel FieldContainer;
        }
}
