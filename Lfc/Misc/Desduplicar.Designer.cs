namespace Lfc.Misc
{
        partial class Desduplicar
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

                #region Código generado por el Diseñador de Windows Forms

                /// <summary>
                /// Método necesario para admitir el Diseñador. No se puede modificar
                /// el contenido del método con el editor de código.
                /// </summary>
                private void InitializeComponent()
                {
                        this.EtiquetaElemento1 = new Lui.Forms.Label();
                        this.EntradaElementoDuplicado = new Lcc.Entrada.CodigoDetalle();
                        this.EtiquetaElemento2 = new Lui.Forms.Label();
                        this.EntradaElementoOriginal = new Lcc.Entrada.CodigoDetalle();
                        this.txtTipo = new Lui.Forms.ComboBox();
                        this.label3 = new Lui.Forms.Label();
                        this.PanelPersona = new Lui.Forms.Panel();
                        this.EntradaCtaCteFinal = new Lui.Forms.TextBox();
                        this.label4 = new Lui.Forms.Label();
                        this.EntradaCtaCte2 = new Lui.Forms.TextBox();
                        this.label2 = new Lui.Forms.Label();
                        this.EntradaCtaCte1 = new Lui.Forms.TextBox();
                        this.label1 = new Lui.Forms.Label();
                        this.label5 = new Lui.Forms.Label();
                        this.PanelPersona.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // EtiquetaElemento1
                        // 
                        this.EtiquetaElemento1.Location = new System.Drawing.Point(28, 56);
                        this.EtiquetaElemento1.Name = "EtiquetaElemento1";
                        this.EtiquetaElemento1.Size = new System.Drawing.Size(124, 24);
                        this.EtiquetaElemento1.TabIndex = 2;
                        this.EtiquetaElemento1.Text = "Registro 1";
                        this.EtiquetaElemento1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaElementoDuplicado
                        // 
                        this.EntradaElementoDuplicado.AutoTab = true;
                        this.EntradaElementoDuplicado.CanCreate = true;
                        this.EntradaElementoDuplicado.Location = new System.Drawing.Point(152, 88);
                        this.EntradaElementoDuplicado.MaxLength = 200;
                        this.EntradaElementoDuplicado.Name = "EntradaElementoDuplicado";
                        this.EntradaElementoDuplicado.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaElementoDuplicado.Required = true;
                        this.EntradaElementoDuplicado.Size = new System.Drawing.Size(456, 24);
                        this.EntradaElementoDuplicado.TabIndex = 5;
                        this.EntradaElementoDuplicado.Text = "0";
                        this.EntradaElementoDuplicado.TextChanged += new System.EventHandler(this.EntradaElementoDuplicado_TextChanged);
                        // 
                        // EtiquetaElemento2
                        // 
                        this.EtiquetaElemento2.Location = new System.Drawing.Point(28, 88);
                        this.EtiquetaElemento2.Name = "EtiquetaElemento2";
                        this.EtiquetaElemento2.Size = new System.Drawing.Size(124, 24);
                        this.EtiquetaElemento2.TabIndex = 4;
                        this.EtiquetaElemento2.Text = "Registro 2";
                        this.EtiquetaElemento2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaElementoOriginal
                        // 
                        this.EntradaElementoOriginal.AutoTab = true;
                        this.EntradaElementoOriginal.CanCreate = true;
                        this.EntradaElementoOriginal.Location = new System.Drawing.Point(152, 56);
                        this.EntradaElementoOriginal.MaxLength = 200;
                        this.EntradaElementoOriginal.Name = "EntradaElementoOriginal";
                        this.EntradaElementoOriginal.NombreTipo = "Lbl.Personas.Persona";
                        this.EntradaElementoOriginal.Required = true;
                        this.EntradaElementoOriginal.Size = new System.Drawing.Size(456, 24);
                        this.EntradaElementoOriginal.TabIndex = 3;
                        this.EntradaElementoOriginal.Text = "0";
                        this.EntradaElementoOriginal.TextChanged += new System.EventHandler(this.EntradaElementoOriginal_TextChanged);
                        // 
                        // txtTipo
                        // 
                        this.txtTipo.AlwaysExpanded = true;
                        this.txtTipo.AutoSize = true;
                        this.txtTipo.Location = new System.Drawing.Point(152, 24);
                        this.txtTipo.Name = "txtTipo";
                        this.txtTipo.SetData = new string[] {
        "Persona|personas"};
                        this.txtTipo.Size = new System.Drawing.Size(140, 22);
                        this.txtTipo.TabIndex = 1;
                        this.txtTipo.TextKey = "personas";
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(28, 24);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(124, 24);
                        this.label3.TabIndex = 0;
                        this.label3.Text = "Tipo de registro";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // PanelPersona
                        // 
                        this.PanelPersona.Controls.Add(this.EntradaCtaCteFinal);
                        this.PanelPersona.Controls.Add(this.label4);
                        this.PanelPersona.Controls.Add(this.EntradaCtaCte2);
                        this.PanelPersona.Controls.Add(this.label2);
                        this.PanelPersona.Controls.Add(this.EntradaCtaCte1);
                        this.PanelPersona.Controls.Add(this.label1);
                        this.PanelPersona.Location = new System.Drawing.Point(28, 120);
                        this.PanelPersona.Name = "PanelPersona";
                        this.PanelPersona.Size = new System.Drawing.Size(576, 104);
                        this.PanelPersona.TabIndex = 6;
                        // 
                        // EntradaCtaCteFinal
                        // 
                        this.EntradaCtaCteFinal.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaCtaCteFinal.Location = new System.Drawing.Point(276, 72);
                        this.EntradaCtaCteFinal.Name = "EntradaCtaCteFinal";
                        this.EntradaCtaCteFinal.Prefijo = "$";
                        this.EntradaCtaCteFinal.Size = new System.Drawing.Size(120, 24);
                        this.EntradaCtaCteFinal.TabIndex = 5;
                        this.EntradaCtaCteFinal.TabStop = false;
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(124, 72);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(156, 24);
                        this.label4.TabIndex = 4;
                        this.label4.Text = "Saldo resultante";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCtaCte2
                        // 
                        this.EntradaCtaCte2.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaCtaCte2.Location = new System.Drawing.Point(276, 36);
                        this.EntradaCtaCte2.Name = "EntradaCtaCte2";
                        this.EntradaCtaCte2.Prefijo = "$";
                        this.EntradaCtaCte2.Size = new System.Drawing.Size(120, 24);
                        this.EntradaCtaCte2.TabIndex = 3;
                        this.EntradaCtaCte2.TabStop = false;
                        this.EntradaCtaCte2.TextChanged += new System.EventHandler(this.EntradaCtaCte1CtaCte2_TextChanged);
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(124, 36);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(152, 24);
                        this.label2.TabIndex = 2;
                        this.label2.Text = "Saldo registro 2";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCtaCte1
                        // 
                        this.EntradaCtaCte1.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaCtaCte1.Location = new System.Drawing.Point(276, 8);
                        this.EntradaCtaCte1.Name = "EntradaCtaCte1";
                        this.EntradaCtaCte1.Prefijo = "$";
                        this.EntradaCtaCte1.Size = new System.Drawing.Size(120, 24);
                        this.EntradaCtaCte1.TabIndex = 1;
                        this.EntradaCtaCte1.TabStop = false;
                        this.EntradaCtaCte1.TextChanged += new System.EventHandler(this.EntradaCtaCte1CtaCte2_TextChanged);
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(124, 8);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(152, 24);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "Saldo registro 1";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label5
                        // 
                        this.label5.Location = new System.Drawing.Point(28, 248);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(580, 48);
                        this.label5.TabIndex = 51;
                        this.label5.Text = "Todos los datos relacionados al registro 2, como su cuenta corriente, comprobante" +
    "s y movimientos de caja o stock, pasarán al registro 1. El registro 2 será enton" +
    "ces eliminado.";
                        // 
                        // Desduplicar
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(634, 372);
                        this.Controls.Add(this.label5);
                        this.Controls.Add(this.PanelPersona);
                        this.Controls.Add(this.txtTipo);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.EntradaElementoOriginal);
                        this.Controls.Add(this.EntradaElementoDuplicado);
                        this.Controls.Add(this.EtiquetaElemento2);
                        this.Controls.Add(this.EtiquetaElemento1);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "Desduplicar";
                        this.Text = "Desduplicar";
                        this.Controls.SetChildIndex(this.EtiquetaElemento1, 0);
                        this.Controls.SetChildIndex(this.EtiquetaElemento2, 0);
                        this.Controls.SetChildIndex(this.EntradaElementoDuplicado, 0);
                        this.Controls.SetChildIndex(this.EntradaElementoOriginal, 0);
                        this.Controls.SetChildIndex(this.label3, 0);
                        this.Controls.SetChildIndex(this.txtTipo, 0);
                        this.Controls.SetChildIndex(this.PanelPersona, 0);
                        this.Controls.SetChildIndex(this.label5, 0);
                        this.PanelPersona.ResumeLayout(false);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                internal Lui.Forms.Label EtiquetaElemento1;
                internal Lcc.Entrada.CodigoDetalle EntradaElementoDuplicado;
                internal Lui.Forms.Label EtiquetaElemento2;
                internal Lcc.Entrada.CodigoDetalle EntradaElementoOriginal;
                internal Lui.Forms.ComboBox txtTipo;
                internal Lui.Forms.Label label3;
                private Lui.Forms.Panel PanelPersona;
                internal Lui.Forms.Label label1;
                private Lui.Forms.TextBox EntradaCtaCte2;
                internal Lui.Forms.Label label2;
                private Lui.Forms.TextBox EntradaCtaCte1;
                private Lui.Forms.TextBox EntradaCtaCteFinal;
                internal Lui.Forms.Label label4;
                private Lui.Forms.Label label5;
        }
}
