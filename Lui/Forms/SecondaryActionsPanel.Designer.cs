namespace Lui.Forms
{
        partial class SecondaryActionsPanel
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
                        this.PanelPrimario = new System.Windows.Forms.FlowLayoutPanel();
                        this.SuspendLayout();
                        // 
                        // PanelPrimario
                        // 
                        this.PanelPrimario.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.PanelPrimario.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
                        this.PanelPrimario.Location = new System.Drawing.Point(0, 0);
                        this.PanelPrimario.Name = "PanelPrimario";
                        this.PanelPrimario.Size = new System.Drawing.Size(602, 130);
                        this.PanelPrimario.TabIndex = 0;
                        this.PanelPrimario.WrapContents = false;
                        // 
                        // ActionsPanel
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.PanelPrimario);
                        this.Name = "ActionsPanel";
                        this.Size = new System.Drawing.Size(602, 130);
                        this.ResumeLayout(false);

                }

                #endregion

                private System.Windows.Forms.FlowLayoutPanel PanelPrimario;
        }
}
