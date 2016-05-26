namespace Lui.Forms
{
        public partial class Frame
        {
                /// <summary> 
                /// Variable del diseñador requerida.
                /// </summary>
                private System.ComponentModel.IContainer components = null;

                /// <summary> 
                /// Limpiar los recursos que se están utilizando.
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
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(0, 0);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(0, 25);
                        this.EtiquetaTitulo.TabIndex = 2;
                        this.EtiquetaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.EtiquetaTitulo.Visible = false;
                        // 
                        // Frame
                        // 
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Name = "Frame";
                        this.Size = new System.Drawing.Size(640, 400);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                protected Lui.Forms.Label EtiquetaTitulo;


        }
}
