namespace Lazaro.Mensajeria.Chat
{
        partial class ChatControl
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
                        this.EntradaEnviar = new Lui.Forms.TextBox();
                        this.EntradaConversacion = new System.Windows.Forms.TextBox();
                        this.EtiquetaNombre = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaEnviar
                        // 
                        this.EntradaEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaEnviar.Location = new System.Drawing.Point(8, 320);
                        this.EntradaEnviar.Name = "EntradaEnviar";
                        this.EntradaEnviar.Size = new System.Drawing.Size(608, 24);
                        this.EntradaEnviar.TabIndex = 2;
                        this.EntradaEnviar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EntradaEnviar_KeyDown);
                        // 
                        // EntradaConversacion
                        // 
                        this.EntradaConversacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaConversacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.EntradaConversacion.Location = new System.Drawing.Point(8, 40);
                        this.EntradaConversacion.Multiline = true;
                        this.EntradaConversacion.Name = "EntradaConversacion";
                        this.EntradaConversacion.ReadOnly = true;
                        this.EntradaConversacion.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
                        this.EntradaConversacion.Size = new System.Drawing.Size(615, 272);
                        this.EntradaConversacion.TabIndex = 3;
                        this.EntradaConversacion.TabStop = false;
                        // 
                        // EtiquetaNombre
                        // 
                        this.EtiquetaNombre.AutoSize = true;
                        this.EtiquetaNombre.Location = new System.Drawing.Point(0, 0);
                        this.EtiquetaNombre.Name = "EtiquetaNombre";
                        this.EtiquetaNombre.Size = new System.Drawing.Size(118, 29);
                        this.EtiquetaNombre.TabIndex = 4;
                        this.EtiquetaNombre.Text = "Conversación";
                        this.EtiquetaNombre.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        // 
                        // ChatControl
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.Controls.Add(this.EtiquetaNombre);
                        this.Controls.Add(this.EntradaEnviar);
                        this.Controls.Add(this.EntradaConversacion);
                        this.Name = "ChatControl";
                        this.Size = new System.Drawing.Size(623, 353);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private Lui.Forms.TextBox EntradaEnviar;
                private System.Windows.Forms.TextBox EntradaConversacion;
                private Lui.Forms.Label EtiquetaNombre;
        }
}
