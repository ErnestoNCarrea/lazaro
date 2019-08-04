namespace Lfc.Monedas
{
        partial class Editar
        {
                private System.ComponentModel.IContainer components = null;

                protected override void Dispose(bool disposing)
                {
                        if (disposing && (components != null))
                        {
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
                        this.EntradaNombre = new Lui.Forms.TextBox();
                        this.Label3 = new Lui.Forms.Label();
                        this.EntradaCotizacion = new Lui.Forms.TextBox();
                        this.label1 = new Lui.Forms.Label();
                        this.EntradaCodigoIso = new Lui.Forms.TextBox();
                        this.label2 = new Lui.Forms.Label();
                        this.EntradaSigno = new Lui.Forms.TextBox();
                        this.label4 = new Lui.Forms.Label();
                        this.LabelFechaValor = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaNombre
                        // 
                        this.EntradaNombre.Location = new System.Drawing.Point(151, 13);
                        this.EntradaNombre.Name = "EntradaNombre";
                        this.EntradaNombre.Size = new System.Drawing.Size(172, 24);
                        this.EntradaNombre.TabIndex = 7;
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(8, 13);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(140, 24);
                        this.Label3.TabIndex = 6;
                        this.Label3.Text = "Nombre";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCotizacion
                        // 
                        this.EntradaCotizacion.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaCotizacion.Location = new System.Drawing.Point(151, 48);
                        this.EntradaCotizacion.Name = "EntradaCotizacion";
                        this.EntradaCotizacion.Prefijo = "$";
                        this.EntradaCotizacion.Size = new System.Drawing.Size(172, 24);
                        this.EntradaCotizacion.TabIndex = 9;
                        this.EntradaCotizacion.Text = "0.00";
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(8, 48);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(140, 24);
                        this.label1.TabIndex = 8;
                        this.label1.Text = "Cotización";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaCodigoIso
                        // 
                        this.EntradaCodigoIso.Location = new System.Drawing.Point(151, 80);
                        this.EntradaCodigoIso.Name = "EntradaCodigoIso";
                        this.EntradaCodigoIso.Size = new System.Drawing.Size(172, 24);
                        this.EntradaCodigoIso.TabIndex = 11;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(8, 80);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(140, 24);
                        this.label2.TabIndex = 10;
                        this.label2.Text = "Codigo ISO";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaSigno
                        // 
                        this.EntradaSigno.Location = new System.Drawing.Point(151, 112);
                        this.EntradaSigno.Name = "EntradaSigno";
                        this.EntradaSigno.Size = new System.Drawing.Size(172, 24);
                        this.EntradaSigno.TabIndex = 13;
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(8, 112);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(140, 24);
                        this.label4.TabIndex = 12;
                        this.label4.Text = "Simbolo";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // LabelFechaValor
                        // 
                        this.LabelFechaValor.Location = new System.Drawing.Point(8, 160);
                        this.LabelFechaValor.Name = "LabelFechaValor";
                        this.LabelFechaValor.Size = new System.Drawing.Size(560, 24);
                        this.LabelFechaValor.TabIndex = 14;
                        this.LabelFechaValor.Text = "Text Text Text Text Text ";
                        this.LabelFechaValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Editar
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.Controls.Add(this.LabelFechaValor);
                        this.Controls.Add(this.EntradaSigno);
                        this.Controls.Add(this.label4);
                        this.Controls.Add(this.EntradaCodigoIso);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.EntradaCotizacion);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.EntradaNombre);
                        this.Controls.Add(this.Label3);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(647, 314);
                        this.ResumeLayout(false);

                }

                #endregion

                internal Lui.Forms.TextBox EntradaNombre;
                internal Lui.Forms.Label Label3;
                internal Lui.Forms.TextBox EntradaCotizacion;
                internal Lui.Forms.Label label1;
                internal Lui.Forms.TextBox EntradaCodigoIso;
                internal Lui.Forms.Label label2;
                internal Lui.Forms.TextBox EntradaSigno;
                internal Lui.Forms.Label label4;
                internal Lui.Forms.Label LabelFechaValor;
        }
}
