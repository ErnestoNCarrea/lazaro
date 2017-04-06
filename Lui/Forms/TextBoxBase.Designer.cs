using System;
using System.Collections.Generic;
using System.Text;

namespace Lui.Forms
{
        public partial class TextBoxBase
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

                /// <summary>
                /// Método necesario para admitir el Diseñador. No se puede modificar
                /// el contenido del método con el editor de código.
                /// </summary>
                private void InitializeComponent()
                {
                        this.TextBox1 = new System.Windows.Forms.TextBox();
                        this.SuspendLayout();
                        // 
                        // TextBox1
                        // 
                        this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.TextBox1.Location = new System.Drawing.Point(4, 4);
                        this.TextBox1.Name = "TextBox1";
                        this.TextBox1.Size = new System.Drawing.Size(452, 18);
                        this.TextBox1.TabIndex = 0;
                        this.TextBox1.Click += new System.EventHandler(this.TextBox1_Click);
                        // 
                        // TextBoxBase
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                        this.Controls.Add(this.TextBox1);
                        this.Name = "TextBoxBase";
                        this.Size = new System.Drawing.Size(460, 24);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                protected System.Windows.Forms.TextBox TextBox1;
        }
}
