namespace Lfc
{
	partial class FormularioListadoExportar
	{
		#region Código generado por el Diseñador de Windows Forms
                /// <summary> 
                /// Limpiar los recursos que se estén utilizando.
                /// </summary>
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }
                        base.Dispose(disposing);
                }

		private void InitializeComponent()
		{
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioListadoExportar));
                        this.label1 = new Lui.Forms.Label();
                        this.BotonCancelar = new Lui.Forms.Button();
                        this.pictureBox1 = new System.Windows.Forms.PictureBox();
                        this.BotonImprimirAvanzado = new Lui.Forms.Button();
                        this.BotonImprimir = new Lui.Forms.Button();
                        this.BotonExcel = new Lui.Forms.Button();
                        this.BotonHtml = new Lui.Forms.Button();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // label1
                        // 
                        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.label1.Location = new System.Drawing.Point(24, 24);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(455, 32);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "Imprimir o exportar documento";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label1.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // BotonCancelar
                        // 
                        this.BotonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.BotonCancelar.Image = null;
                        this.BotonCancelar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonCancelar.Location = new System.Drawing.Point(24, 376);
                        this.BotonCancelar.Name = "BotonCancelar";
                        this.BotonCancelar.Size = new System.Drawing.Size(104, 40);
                        this.BotonCancelar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonCancelar.Subtext = "";
                        this.BotonCancelar.TabIndex = 5;
                        this.BotonCancelar.Text = "Cancelar";
                        this.BotonCancelar.Click += new System.EventHandler(this.BotonCancelar_Click);
                        // 
                        // pictureBox1
                        // 
                        this.pictureBox1.Image = global::Lfc.Properties.Resources.printer_4;
                        this.pictureBox1.Location = new System.Drawing.Point(40, 72);
                        this.pictureBox1.Name = "pictureBox1";
                        this.pictureBox1.Size = new System.Drawing.Size(136, 136);
                        this.pictureBox1.TabIndex = 6;
                        this.pictureBox1.TabStop = false;
                        // 
                        // BotonImprimirAvanzado
                        // 
                        this.BotonImprimirAvanzado.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonImprimirAvanzado.Image = ((System.Drawing.Image)(resources.GetObject("BotonImprimirAvanzado.Image")));
                        this.BotonImprimirAvanzado.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonImprimirAvanzado.Location = new System.Drawing.Point(208, 160);
                        this.BotonImprimirAvanzado.Name = "BotonImprimirAvanzado";
                        this.BotonImprimirAvanzado.Size = new System.Drawing.Size(312, 80);
                        this.BotonImprimirAvanzado.SubLabelPos = Lui.Forms.SubLabelPositions.LongBottom;
                        this.BotonImprimirAvanzado.Subtext = "Permite seleccionar la impresora, orientación, márgenes y otras opciones.";
                        this.BotonImprimirAvanzado.TabIndex = 2;
                        this.BotonImprimirAvanzado.Text = "Impresión avanzada";
                        this.BotonImprimirAvanzado.Click += new System.EventHandler(this.BotonImprimirAvanzado_Click);
                        // 
                        // BotonImprimir
                        // 
                        this.BotonImprimir.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonImprimir.Image = ((System.Drawing.Image)(resources.GetObject("BotonImprimir.Image")));
                        this.BotonImprimir.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonImprimir.Location = new System.Drawing.Point(208, 72);
                        this.BotonImprimir.Name = "BotonImprimir";
                        this.BotonImprimir.Size = new System.Drawing.Size(312, 80);
                        this.BotonImprimir.SubLabelPos = Lui.Forms.SubLabelPositions.LongBottom;
                        this.BotonImprimir.Subtext = "Imprime el documento en la impresora predeterminada.";
                        this.BotonImprimir.TabIndex = 1;
                        this.BotonImprimir.Text = "Imprimir";
                        this.BotonImprimir.Click += new System.EventHandler(this.BotonImprimir_Click);
                        // 
                        // BotonExcel
                        // 
                        this.BotonExcel.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonExcel.Image = ((System.Drawing.Image)(resources.GetObject("BotonExcel.Image")));
                        this.BotonExcel.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonExcel.Location = new System.Drawing.Point(208, 336);
                        this.BotonExcel.Name = "BotonExcel";
                        this.BotonExcel.Size = new System.Drawing.Size(312, 80);
                        this.BotonExcel.SubLabelPos = Lui.Forms.SubLabelPositions.LongBottom;
                        this.BotonExcel.Subtext = "Exporta los datos a una hoja de Microsoft Excel, también compatible con LibreOffi" +
    "ce.";
                        this.BotonExcel.TabIndex = 4;
                        this.BotonExcel.Text = "Exportar a Excel";
                        this.BotonExcel.Click += new System.EventHandler(this.BotonExcel_Click);
                        // 
                        // BotonHtml
                        // 
                        this.BotonHtml.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonHtml.Image = ((System.Drawing.Image)(resources.GetObject("BotonHtml.Image")));
                        this.BotonHtml.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonHtml.Location = new System.Drawing.Point(208, 248);
                        this.BotonHtml.Name = "BotonHtml";
                        this.BotonHtml.Size = new System.Drawing.Size(312, 80);
                        this.BotonHtml.SubLabelPos = Lui.Forms.SubLabelPositions.LongBottom;
                        this.BotonHtml.Subtext = "Exporta los datos a una archivo HTML para abrir con un navegador o publicar en la" +
    " Web.";
                        this.BotonHtml.TabIndex = 3;
                        this.BotonHtml.Text = "Exportar en HTML";
                        this.BotonHtml.Click += new System.EventHandler(this.BotonHtml_Click);
                        // 
                        // FormularioListadoExportar
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.CancelButton = this.BotonCancelar;
                        this.ClientSize = new System.Drawing.Size(544, 441);
                        this.Controls.Add(this.pictureBox1);
                        this.Controls.Add(this.BotonImprimirAvanzado);
                        this.Controls.Add(this.BotonCancelar);
                        this.Controls.Add(this.BotonImprimir);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.BotonExcel);
                        this.Controls.Add(this.BotonHtml);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.Name = "FormularioListadoExportar";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        this.Text = "Imprimir o exportar";
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                        this.ResumeLayout(false);

		}

        	#endregion

                internal Lui.Forms.Label label1;
                private System.ComponentModel.Container components = null;
                internal Lui.Forms.Button BotonHtml;
                internal Lui.Forms.Button BotonExcel;
                internal Lui.Forms.Button BotonImprimir;
                internal Lui.Forms.Button BotonCancelar;
                internal Lui.Forms.Button BotonImprimirAvanzado;
                private System.Windows.Forms.PictureBox pictureBox1;

	}
}
