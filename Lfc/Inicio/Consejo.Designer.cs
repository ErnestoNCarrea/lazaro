namespace Lfc.Inicio
{
        partial class Consejo
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consejo));
                        this.SuspendLayout();
                        // 
                        // Consejo
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                        this.BackColor = System.Drawing.Color.DarkOrchid;
                        this.Image = ((System.Drawing.Image)(resources.GetObject("$this.Image")));
                        this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
                        this.Name = "Consejo";
                        this.Text = "Consejo del día";
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion
        }
}
