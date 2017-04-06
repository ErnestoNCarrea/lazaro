namespace Lfc.Articulos
{
	partial class Rendimiento
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
                        this.label19 = new Lui.Forms.Label();
                        this.label1 = new Lui.Forms.Label();
                        this.EntradaRendimiento = new Lui.Forms.TextBox();
                        this.label2 = new Lui.Forms.Label();
                        this.EntradaUnidad = new Lui.Forms.ComboBox();
                        this.EntradaUnidadRend = new Lui.Forms.ComboBox();
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.label3 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // label19
                        // 
                        this.label19.Location = new System.Drawing.Point(24, 136);
                        this.label19.Name = "label19";
                        this.label19.Size = new System.Drawing.Size(176, 24);
                        this.label19.TabIndex = 0;
                        this.label19.Text = "El artículo se compra en";
                        this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(24, 240);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(176, 24);
                        this.label1.TabIndex = 2;
                        this.label1.Text = "Y cada uno/a rinde";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaRendimiento
                        // 
                        this.EntradaRendimiento.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaRendimiento.Location = new System.Drawing.Point(200, 240);
                        this.EntradaRendimiento.Name = "EntradaRendimiento";
                        this.EntradaRendimiento.PlaceholderText = "Precio de costo o de compra.";
                        this.EntradaRendimiento.Size = new System.Drawing.Size(96, 24);
                        this.EntradaRendimiento.TabIndex = 3;
                        this.EntradaRendimiento.Text = "0.00";
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(449, 241);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(40, 24);
                        this.label2.TabIndex = 5;
                        this.label2.Text = "c/u.";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaUnidad
                        // 
                        this.EntradaUnidad.AlwaysExpanded = true;
                        this.EntradaUnidad.AutoSize = true;
                        this.EntradaUnidad.Location = new System.Drawing.Point(200, 136);
                        this.EntradaUnidad.Name = "EntradaUnidad";
                        this.EntradaUnidad.SetData = new string[] {
        "N/A|",
        "Unidades|u",
        "Bolsas|bolsa",
        "Baldes|balde",
        "Rollos|rollo",
        "Cajas|caja",
        "Fajos|fajo",
        "Metros|m",
        "Metros²|m²",
        "Metros³|m³",
        "Centímetros|cm",
        "Centímetros³|cm³",
        "Litros|l",
        "Kg|kg"};
                        this.EntradaUnidad.Size = new System.Drawing.Size(137, 91);
                        this.EntradaUnidad.TabIndex = 1;
                        this.EntradaUnidad.TextKey = "u";
                        // 
                        // EntradaUnidadRend
                        // 
                        this.EntradaUnidadRend.AlwaysExpanded = true;
                        this.EntradaUnidadRend.AutoSize = true;
                        this.EntradaUnidadRend.Location = new System.Drawing.Point(304, 240);
                        this.EntradaUnidadRend.Name = "EntradaUnidadRend";
                        this.EntradaUnidadRend.SetData = new string[] {
        "N/A|",
        "Unidades|u",
        "Bolsas|bolsa",
        "Baldes|balde",
        "Rollos|rollo",
        "Cajas|caja",
        "Fajos|fajo",
        "Metros|m",
        "Metros²|m²",
        "Metros³|m³",
        "Centímetros|cm",
        "Centímetros³|cm³",
        "Litros|l",
        "Kg|kg"};
                        this.EntradaUnidadRend.Size = new System.Drawing.Size(137, 91);
                        this.EntradaUnidadRend.TabIndex = 4;
                        this.EntradaUnidadRend.TextKey = "";
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.AutoSize = true;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(24, 24);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(135, 30);
                        this.EtiquetaTitulo.TabIndex = 102;
                        this.EtiquetaTitulo.Text = "Rendimiento";
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(24, 64);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(464, 56);
                        this.label3.TabIndex = 103;
                        this.label3.Text = "Si el artículo se compra y se vende en diferentes unidades, por ejemplo los artíc" +
    "ulos que se venden fraccionados, puede proporcionar esa información aquí:";
                        // 
                        // Rendimiento
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(513, 417);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Controls.Add(this.EntradaUnidad);
                        this.Controls.Add(this.EntradaUnidadRend);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.EntradaRendimiento);
                        this.Controls.Add(this.label19);
                        this.Controls.Add(this.label1);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "Rendimiento";
                        this.Text = "Rendimiento";
                        this.Controls.SetChildIndex(this.label1, 0);
                        this.Controls.SetChildIndex(this.label19, 0);
                        this.Controls.SetChildIndex(this.EntradaRendimiento, 0);
                        this.Controls.SetChildIndex(this.label2, 0);
                        this.Controls.SetChildIndex(this.EntradaUnidadRend, 0);
                        this.Controls.SetChildIndex(this.EntradaUnidad, 0);
                        this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
                        this.Controls.SetChildIndex(this.label3, 0);
                        this.ResumeLayout(false);
                        this.PerformLayout();

		}

		#endregion

		internal Lui.Forms.Label label19;
		internal Lui.Forms.Label label1;
		internal Lui.Forms.TextBox EntradaRendimiento;
		internal Lui.Forms.Label label2;
                internal Lui.Forms.ComboBox EntradaUnidad;
                internal Lui.Forms.ComboBox EntradaUnidadRend;
                private Lui.Forms.Label EtiquetaTitulo;
                internal Lui.Forms.Label label3;
	}
}
