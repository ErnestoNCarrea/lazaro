using System;
using System.Collections.Generic;
using System.Text;

namespace Lcc.Entrada
{
        public partial class Telefono
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

                private Lui.Forms.TextBox EntradaNombre;
                private Lui.Forms.TextBox EntradaCaracteristica;
                private Lui.Forms.TextBox EntradaNumero;
                private Lui.Forms.Label label1;
                private Lui.Forms.Label label2;

                private void InitializeComponent()
                {
                        this.EntradaNombre = new Lui.Forms.TextBox();
                        this.EntradaCaracteristica = new Lui.Forms.TextBox();
                        this.EntradaNumero = new Lui.Forms.TextBox();
                        this.label1 = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaNombre
                        // 
                        this.EntradaNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaNombre.Location = new System.Drawing.Point(352, 0);
                        this.EntradaNombre.Name = "EntradaNombre";
                        this.EntradaNombre.PlaceholderText = "Tipo";
                        this.EntradaNombre.Size = new System.Drawing.Size(108, 24);
                        this.EntradaNombre.TabIndex = 4;
                        this.EntradaNombre.TextChanged += new System.EventHandler(this.Entradas_TextChanged);
                        // 
                        // EntradaCaracteristica
                        // 
                        this.EntradaCaracteristica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
                        this.EntradaCaracteristica.Location = new System.Drawing.Point(12, 0);
                        this.EntradaCaracteristica.Name = "EntradaCaracteristica";
                        this.EntradaCaracteristica.PlaceholderText = "Característica";
                        this.EntradaCaracteristica.Size = new System.Drawing.Size(60, 24);
                        this.EntradaCaracteristica.TabIndex = 1;
                        this.EntradaCaracteristica.TextChanged += new System.EventHandler(this.Entradas_TextChanged);
                        // 
                        // EntradaNumero
                        // 
                        this.EntradaNumero.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaNumero.Location = new System.Drawing.Point(84, 0);
                        this.EntradaNumero.Name = "EntradaNumero";
                        this.EntradaNumero.PlaceholderText = "Número Telefónico";
                        this.EntradaNumero.Size = new System.Drawing.Size(267, 24);
                        this.EntradaNumero.TabIndex = 3;
                        this.EntradaNumero.TextChanged += new System.EventHandler(this.Entradas_TextChanged);
                        // 
                        // label1
                        // 
                        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
                        this.label1.Location = new System.Drawing.Point(0, 0);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(12, 24);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "(";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        // 
                        // label2
                        // 
                        this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
                        this.label2.Location = new System.Drawing.Point(72, 0);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(12, 24);
                        this.label2.TabIndex = 2;
                        this.label2.Text = ")";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Telefono
                        // 
                        this.Controls.Add(this.EntradaNumero);
                        this.Controls.Add(this.EntradaCaracteristica);
                        this.Controls.Add(this.EntradaNombre);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.label1);
                        this.Name = "Telefono";
                        this.Size = new System.Drawing.Size(460, 24);
                        this.ResumeLayout(false);

                }
        }
}
