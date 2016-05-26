using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Comprobantes
{
        public class FormComprobanteMasDatos : Lui.Forms.DialogForm
        {

                #region Código generado por el Diseñador de Windows Forms

                public FormComprobanteMasDatos()
                        :
                        base()
                {

                        // Necesario para admitir el Diseñador de Windows Forms
                        InitializeComponent();

                        // agregar código de constructor después de llamar a InitializeComponent

                }

                // Limpiar los recursos que se estén utilizando.
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }

                        base.Dispose(disposing);
                }

                // Requerido por el Diseñador de Windows Forms
                private System.ComponentModel.IContainer components = null;

                // NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
                // Puede modificarse utilizando el Diseñador de Windows Forms. 
                // No lo modifique con el editor de código.
                internal Lui.Forms.Label EtiquetaHaciaSituacion;
                internal Lcc.Entrada.CodigoDetalle EntradaHaciaSituacion;
                internal Lui.Forms.Label EtiquetaDesdeSituacion;
                internal Lui.Forms.Label label1;
                internal Lui.Forms.ComboBox EntradaBloqueada;
                private Lui.Forms.Label EtiquetaTitulo;
                internal Lui.Forms.Label label2;
                internal Lui.Forms.Label label3;
                internal Lcc.Entrada.CodigoDetalle EntradaDesdeSituacion;

                private void InitializeComponent()
                {
                        this.EtiquetaHaciaSituacion = new Lui.Forms.Label();
                        this.EntradaHaciaSituacion = new Lcc.Entrada.CodigoDetalle();
                        this.EtiquetaDesdeSituacion = new Lui.Forms.Label();
                        this.EntradaDesdeSituacion = new Lcc.Entrada.CodigoDetalle();
                        this.label1 = new Lui.Forms.Label();
                        this.EntradaBloqueada = new Lui.Forms.ComboBox();
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.label3 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // lblHaciaSituacion
                        // 
                        this.EtiquetaHaciaSituacion.Location = new System.Drawing.Point(24, 144);
                        this.EtiquetaHaciaSituacion.Name = "lblHaciaSituacion";
                        this.EtiquetaHaciaSituacion.Size = new System.Drawing.Size(168, 24);
                        this.EtiquetaHaciaSituacion.TabIndex = 2;
                        this.EtiquetaHaciaSituacion.Text = "Destino";
                        this.EtiquetaHaciaSituacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaHaciaSituacion
                        // 
                        this.EntradaHaciaSituacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaHaciaSituacion.AutoTab = true;
                        this.EntradaHaciaSituacion.CanCreate = false;
                        this.EntradaHaciaSituacion.Filter = "";
                        this.EntradaHaciaSituacion.Location = new System.Drawing.Point(192, 144);
                        this.EntradaHaciaSituacion.MaxLength = 200;
                        this.EntradaHaciaSituacion.Name = "EntradaHaciaSituacion";
                        this.EntradaHaciaSituacion.Required = true;
                        this.EntradaHaciaSituacion.Size = new System.Drawing.Size(416, 24);
                        this.EntradaHaciaSituacion.TabIndex = 3;
                        this.EntradaHaciaSituacion.NombreTipo = "Lbl.Articulos.Situacion";
                        this.EntradaHaciaSituacion.Text = "0";
                        // 
                        // lblDesdeSituacion
                        // 
                        this.EtiquetaDesdeSituacion.Location = new System.Drawing.Point(24, 72);
                        this.EtiquetaDesdeSituacion.Name = "lblDesdeSituacion";
                        this.EtiquetaDesdeSituacion.Size = new System.Drawing.Size(168, 24);
                        this.EtiquetaDesdeSituacion.TabIndex = 0;
                        this.EtiquetaDesdeSituacion.Text = "Origen";
                        this.EtiquetaDesdeSituacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaDesdeSituacion
                        // 
                        this.EntradaDesdeSituacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaDesdeSituacion.AutoTab = true;
                        this.EntradaDesdeSituacion.CanCreate = false;
                        this.EntradaDesdeSituacion.Filter = "facturable=1";
                        this.EntradaDesdeSituacion.Location = new System.Drawing.Point(192, 72);
                        this.EntradaDesdeSituacion.MaxLength = 200;
                        this.EntradaDesdeSituacion.Name = "EntradaDesdeSituacion";
                        this.EntradaDesdeSituacion.Required = true;
                        this.EntradaDesdeSituacion.Size = new System.Drawing.Size(416, 24);
                        this.EntradaDesdeSituacion.TabIndex = 1;
                        this.EntradaDesdeSituacion.NombreTipo = "Lbl.Articulos.Situacion";
                        this.EntradaDesdeSituacion.Text = "0";
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(24, 224);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(168, 24);
                        this.label1.TabIndex = 4;
                        this.label1.Text = "Accesibilidad";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaBloqueada
                        // 
                        this.EntradaBloqueada.AlwaysExpanded = true;
                        this.EntradaBloqueada.AutoSize = true;
                        this.EntradaBloqueada.Location = new System.Drawing.Point(192, 224);
                        this.EntradaBloqueada.Name = "EntradaBloqueada";
                        this.EntradaBloqueada.SetData = new string[] {
        "Editable|0",
        "Bloqueado|1"};
                        this.EntradaBloqueada.Size = new System.Drawing.Size(128, 39);
                        this.EntradaBloqueada.TabIndex = 5;
                        this.EntradaBloqueada.TextKey = "0";
                        this.EntradaBloqueada.TextChanged += new System.EventHandler(this.EntradaBloqueada_TextChanged);
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 24);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(285, 30);
                        this.EtiquetaTitulo.TabIndex = 107;
                        this.EtiquetaTitulo.Text = "Más datos del comprobante";
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(192, 104);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(416, 32);
                        this.label2.TabIndex = 108;
                        this.label2.Text = "¿De dónde se deben restar las existencias cuando se hagan movimientos relacionado" +
    "s a este comprobante?";
                        this.label2.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(192, 176);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(416, 24);
                        this.label3.TabIndex = 109;
                        this.label3.Text = "¿Hacia dónde van esas existencias?";
                        this.label3.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                        // 
                        // FormComprobanteMasDatos
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(634, 374);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Controls.Add(this.EtiquetaHaciaSituacion);
                        this.Controls.Add(this.EntradaBloqueada);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.EntradaHaciaSituacion);
                        this.Controls.Add(this.EtiquetaDesdeSituacion);
                        this.Controls.Add(this.EntradaDesdeSituacion);
                        this.Controls.Add(this.label2);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "FormComprobanteMasDatos";
                        this.Text = "Más datos del comprobante";
                        this.Controls.SetChildIndex(this.label2, 0);
                        this.Controls.SetChildIndex(this.EntradaDesdeSituacion, 0);
                        this.Controls.SetChildIndex(this.EtiquetaDesdeSituacion, 0);
                        this.Controls.SetChildIndex(this.EntradaHaciaSituacion, 0);
                        this.Controls.SetChildIndex(this.label1, 0);
                        this.Controls.SetChildIndex(this.EntradaBloqueada, 0);
                        this.Controls.SetChildIndex(this.EtiquetaHaciaSituacion, 0);
                        this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
                        this.Controls.SetChildIndex(this.label3, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private void EntradaBloqueada_TextChanged(object sender, System.EventArgs e)
                {
                        EntradaDesdeSituacion.TemporaryReadOnly = (EntradaBloqueada.TextKey == "1");
                        EntradaHaciaSituacion.TemporaryReadOnly = (EntradaBloqueada.TextKey == "1");
                }
        }
}
