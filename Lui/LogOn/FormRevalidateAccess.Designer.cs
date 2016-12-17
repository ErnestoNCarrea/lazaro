namespace Lui.LogOn
{
	partial class FormRevalidateAccess
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
			if(disposing && (components != null)) {
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRevalidateAccess));
                        this.Titulo = new Lui.Forms.Label();
                        this.EntradaContrasena = new Lui.Forms.TextBox();
                        this.PictureBox2 = new System.Windows.Forms.PictureBox();
                        this.Label2 = new Lui.Forms.Label();
                        this.EntradaUsuario = new Lui.Forms.TextBox();
                        this.label3 = new Lui.Forms.Label();
                        this.LabelExplain = new Lui.Forms.Label();
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // Titulo
                        // 
                        this.Titulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Titulo.Location = new System.Drawing.Point(36, 36);
                        this.Titulo.Name = "Titulo";
                        this.Titulo.Size = new System.Drawing.Size(400, 32);
                        this.Titulo.TabIndex = 0;
                        this.Titulo.Text = "Para continuar, por favor escriba su contraseña";
                        this.Titulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.Titulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        // 
                        // EntradaContrasena
                        // 
                        this.EntradaContrasena.Location = new System.Drawing.Point(164, 156);
                        this.EntradaContrasena.Name = "EntradaContrasena";
                        this.EntradaContrasena.PasswordChar = '*';
                        this.EntradaContrasena.Size = new System.Drawing.Size(180, 24);
                        this.EntradaContrasena.TabIndex = 4;
                        // 
                        // PictureBox2
                        // 
                        this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
                        this.PictureBox2.Location = new System.Drawing.Point(36, 124);
                        this.PictureBox2.Name = "PictureBox2";
                        this.PictureBox2.Size = new System.Drawing.Size(32, 32);
                        this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                        this.PictureBox2.TabIndex = 54;
                        this.PictureBox2.TabStop = false;
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(76, 156);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(88, 24);
                        this.Label2.TabIndex = 3;
                        this.Label2.Text = "Contraseña";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaUsuario
                        // 
                        this.EntradaUsuario.Enabled = false;
                        this.EntradaUsuario.Location = new System.Drawing.Point(164, 124);
                        this.EntradaUsuario.Name = "EntradaUsuario";
                        this.EntradaUsuario.Size = new System.Drawing.Size(272, 24);
                        this.EntradaUsuario.TabIndex = 2;
                        this.EntradaUsuario.Text = "0";
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(76, 124);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(88, 24);
                        this.label3.TabIndex = 1;
                        this.label3.Text = "Usuario";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // LabelExplain
                        // 
                        this.LabelExplain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.LabelExplain.Location = new System.Drawing.Point(36, 68);
                        this.LabelExplain.Name = "LabelExplain";
                        this.LabelExplain.Size = new System.Drawing.Size(400, 40);
                        this.LabelExplain.TabIndex = 55;
                        this.LabelExplain.Text = "La operación que intenta realizar requiere por motivos de seguridad que vuelva a " +
    "escribir su contraseña.";
                        this.LabelExplain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        // 
                        // FormRevalidateAccess
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(474, 292);
                        this.Controls.Add(this.LabelExplain);
                        this.Controls.Add(this.EntradaUsuario);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.EntradaContrasena);
                        this.Controls.Add(this.PictureBox2);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.Titulo);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.Name = "FormRevalidateAccess";
                        this.Text = "Revalidar autorización";
                        this.Controls.SetChildIndex(this.Titulo, 0);
                        this.Controls.SetChildIndex(this.Label2, 0);
                        this.Controls.SetChildIndex(this.PictureBox2, 0);
                        this.Controls.SetChildIndex(this.EntradaContrasena, 0);
                        this.Controls.SetChildIndex(this.label3, 0);
                        this.Controls.SetChildIndex(this.EntradaUsuario, 0);
                        this.Controls.SetChildIndex(this.LabelExplain, 0);
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
                        this.ResumeLayout(false);

		}

		#endregion

		private Lui.Forms.Label Titulo;
		internal Lui.Forms.TextBox EntradaContrasena;
		internal System.Windows.Forms.PictureBox PictureBox2;
		internal Lui.Forms.Label Label2;
		internal Lui.Forms.TextBox EntradaUsuario;
		internal Lui.Forms.Label label3;
		protected internal Lui.Forms.Label LabelExplain;
	}
}
