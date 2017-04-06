using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Comprobantes
{
        public class Convertir : Lui.Forms.DialogForm
        {
                private string m_OrigenTipo = "";

                #region Código generado por el Diseñador de Windows Forms

                public Convertir()
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
                internal Lui.Forms.Label Label6;
                internal Lui.Forms.Label Label7;
                internal Lui.Forms.Label lblInfo;
                internal System.Windows.Forms.PictureBox PictureBox1;
                internal System.Windows.Forms.PictureBox PictureBox2;
                internal Lui.Forms.ComboBox EntradaDestinoTipo;
                internal Lui.Forms.Label lblOrigenTipo;
                internal Lui.Forms.Label lblDestinoTipo;
                internal Lui.Forms.Label lblDuplicado;
                internal Lui.Forms.Label label1;
                private Lui.Forms.Label EtiquetaTitulo;
                internal PictureBox pictureBox3;
                internal Lui.Forms.TextBox EntradaOrigen;

                private void InitializeComponent()
                {
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Convertir));
                        this.EntradaOrigen = new Lui.Forms.TextBox();
                        this.Label6 = new Lui.Forms.Label();
                        this.Label7 = new Lui.Forms.Label();
                        this.EntradaDestinoTipo = new Lui.Forms.ComboBox();
                        this.lblInfo = new Lui.Forms.Label();
                        this.lblOrigenTipo = new Lui.Forms.Label();
                        this.lblDestinoTipo = new Lui.Forms.Label();
                        this.lblDuplicado = new Lui.Forms.Label();
                        this.PictureBox2 = new System.Windows.Forms.PictureBox();
                        this.PictureBox1 = new System.Windows.Forms.PictureBox();
                        this.label1 = new Lui.Forms.Label();
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.pictureBox3 = new System.Windows.Forms.PictureBox();
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // EntradaOrigen
                        // 
                        this.EntradaOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaOrigen.Location = new System.Drawing.Point(328, 96);
                        this.EntradaOrigen.Name = "EntradaOrigen";
                        this.EntradaOrigen.Size = new System.Drawing.Size(280, 24);
                        this.EntradaOrigen.TabIndex = 1;
                        this.EntradaOrigen.TabStop = false;
                        // 
                        // Label6
                        // 
                        this.Label6.Location = new System.Drawing.Point(24, 96);
                        this.Label6.Name = "Label6";
                        this.Label6.Size = new System.Drawing.Size(304, 24);
                        this.Label6.TabIndex = 0;
                        this.Label6.Text = "A partir del comprobante de origen";
                        this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label7
                        // 
                        this.Label7.Location = new System.Drawing.Point(24, 128);
                        this.Label7.Name = "Label7";
                        this.Label7.Size = new System.Drawing.Size(304, 24);
                        this.Label7.TabIndex = 2;
                        this.Label7.Text = "Se generará un nuevo comprobante tipo";
                        this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaDestinoTipo
                        // 
                        this.EntradaDestinoTipo.AlwaysExpanded = true;
                        this.EntradaDestinoTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaDestinoTipo.AutoSize = true;
                        this.EntradaDestinoTipo.Location = new System.Drawing.Point(328, 128);
                        this.EntradaDestinoTipo.Name = "EntradaDestinoTipo";
                        this.EntradaDestinoTipo.SetData = new string[] {
        "Factura|F",
        "Presupuesto|PS",
        "Remito|R",
        "Nota de Crédito|NC",
        "Nota de Débito|ND"};
                        this.EntradaDestinoTipo.Size = new System.Drawing.Size(280, 90);
                        this.EntradaDestinoTipo.TabIndex = 3;
                        this.EntradaDestinoTipo.TextKey = "F";
                        this.EntradaDestinoTipo.TextChanged += new System.EventHandler(this.EntradaDestinoTipo_TextChanged);
                        // 
                        // lblInfo
                        // 
                        this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.lblInfo.Location = new System.Drawing.Point(304, 310);
                        this.lblInfo.Name = "lblInfo";
                        this.lblInfo.Size = new System.Drawing.Size(304, 22);
                        this.lblInfo.TabIndex = 6;
                        this.lblInfo.Text = "El comprobante original queda sin cambios.";
                        // 
                        // lblOrigenTipo
                        // 
                        this.lblOrigenTipo.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.lblOrigenTipo.Location = new System.Drawing.Point(40, 216);
                        this.lblOrigenTipo.Name = "lblOrigenTipo";
                        this.lblOrigenTipo.Size = new System.Drawing.Size(120, 48);
                        this.lblOrigenTipo.TabIndex = 4;
                        this.lblOrigenTipo.Text = "Nota de Débito A";
                        this.lblOrigenTipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.lblOrigenTipo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
                        // 
                        // lblDestinoTipo
                        // 
                        this.lblDestinoTipo.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.lblDestinoTipo.Location = new System.Drawing.Point(184, 216);
                        this.lblDestinoTipo.Name = "lblDestinoTipo";
                        this.lblDestinoTipo.Size = new System.Drawing.Size(120, 48);
                        this.lblDestinoTipo.TabIndex = 5;
                        this.lblDestinoTipo.Text = "Presupuesto";
                        this.lblDestinoTipo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.lblDestinoTipo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Big;
                        // 
                        // lblDuplicado
                        // 
                        this.lblDuplicado.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.lblDuplicado.Location = new System.Drawing.Point(304, 280);
                        this.lblDuplicado.Name = "lblDuplicado";
                        this.lblDuplicado.Size = new System.Drawing.Size(304, 22);
                        this.lblDuplicado.TabIndex = 58;
                        this.lblDuplicado.Text = "Se creará un duplicado del comprobante original.";
                        this.lblDuplicado.Visible = false;
                        // 
                        // PictureBox2
                        // 
                        this.PictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
                        this.PictureBox2.Location = new System.Drawing.Point(152, 286);
                        this.PictureBox2.Name = "PictureBox2";
                        this.PictureBox2.Size = new System.Drawing.Size(40, 34);
                        this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        this.PictureBox2.TabIndex = 57;
                        this.PictureBox2.TabStop = false;
                        // 
                        // PictureBox1
                        // 
                        this.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
                        this.PictureBox1.Location = new System.Drawing.Point(64, 264);
                        this.PictureBox1.Name = "PictureBox1";
                        this.PictureBox1.Size = new System.Drawing.Size(72, 72);
                        this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        this.PictureBox1.TabIndex = 56;
                        this.PictureBox1.TabStop = false;
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(24, 64);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(584, 24);
                        this.label1.TabIndex = 107;
                        this.label1.Text = "Puede crear un nuevo comprobante a partir de los datos del comprobante actual.";
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 24);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(240, 30);
                        this.EtiquetaTitulo.TabIndex = 106;
                        this.EtiquetaTitulo.Text = "Convertir comprobante";
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // pictureBox3
                        // 
                        this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
                        this.pictureBox3.Location = new System.Drawing.Point(208, 264);
                        this.pictureBox3.Name = "pictureBox3";
                        this.pictureBox3.Size = new System.Drawing.Size(72, 72);
                        this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        this.pictureBox3.TabIndex = 108;
                        this.pictureBox3.TabStop = false;
                        // 
                        // Convertir
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.ClientSize = new System.Drawing.Size(634, 424);
                        this.Controls.Add(this.pictureBox3);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Controls.Add(this.lblDuplicado);
                        this.Controls.Add(this.lblDestinoTipo);
                        this.Controls.Add(this.lblOrigenTipo);
                        this.Controls.Add(this.PictureBox2);
                        this.Controls.Add(this.PictureBox1);
                        this.Controls.Add(this.lblInfo);
                        this.Controls.Add(this.Label7);
                        this.Controls.Add(this.EntradaDestinoTipo);
                        this.Controls.Add(this.Label6);
                        this.Controls.Add(this.EntradaOrigen);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "Convertir";
                        this.Text = "Convertir comprobante";
                        this.Controls.SetChildIndex(this.EntradaOrigen, 0);
                        this.Controls.SetChildIndex(this.Label6, 0);
                        this.Controls.SetChildIndex(this.EntradaDestinoTipo, 0);
                        this.Controls.SetChildIndex(this.Label7, 0);
                        this.Controls.SetChildIndex(this.lblInfo, 0);
                        this.Controls.SetChildIndex(this.PictureBox1, 0);
                        this.Controls.SetChildIndex(this.PictureBox2, 0);
                        this.Controls.SetChildIndex(this.lblOrigenTipo, 0);
                        this.Controls.SetChildIndex(this.lblDestinoTipo, 0);
                        this.Controls.SetChildIndex(this.lblDuplicado, 0);
                        this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
                        this.Controls.SetChildIndex(this.label1, 0);
                        this.Controls.SetChildIndex(this.pictureBox3, 0);
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                public string DestinoTipo
                {
                        get
                        {
                                return EntradaDestinoTipo.TextKey;
                        }
                        set
                        {
                                EntradaDestinoTipo.TextKey = value;
                        }
                }

                public string OrigenTipo
                {
                        get
                        {
                                return m_OrigenTipo;
                        }
                        set
                        {
                                m_OrigenTipo = value;
                                lblOrigenTipo.Text = Lbl.Comprobantes.Comprobante.NombreTipo(m_OrigenTipo);
                        }
                }

                public string OrigenNombre
                {
                        get
                        {
                                return EntradaOrigen.Text;
                        }
                        set
                        {
                                EntradaOrigen.Text = value;
                        }
                }

                private void EntradaDestinoTipo_TextChanged(object sender, System.EventArgs e)
                {
                        lblDestinoTipo.Text = Lbl.Comprobantes.Comprobante.NombreTipo(EntradaDestinoTipo.TextKey);
                }

                public override Lfx.Types.OperationResult Ok()
                {
                        if (EntradaDestinoTipo.TextKey.Length == 0)
                                return new Lfx.Types.FailureOperationResult("Seleccione el tipo de comprobante de destino.");
                        else
                                return new Lfx.Types.SuccessOperationResult();
                }
        }
}
