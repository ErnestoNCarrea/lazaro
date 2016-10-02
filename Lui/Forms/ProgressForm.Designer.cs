namespace Lui.Forms
{
	partial class ProgressForm
	{
		#region Código generado por el Diseñador de Windows Forms

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private System.ComponentModel.IContainer components = null;

                private Lui.Forms.Label EtiquetaNombreOperacion;
                private System.Windows.Forms.ProgressBar ProgressBar;
                private System.Windows.Forms.PictureBox PictureBox1;
                private Lui.Forms.Label EtiquetaDescripcion;
		private Lui.Forms.Label EtiquetaEstado;

		private void InitializeComponent()
		{
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressForm));
                        this.EtiquetaNombreOperacion = new Lui.Forms.Label();
                        this.EtiquetaDescripcion = new Lui.Forms.Label();
                        this.ProgressBar = new System.Windows.Forms.ProgressBar();
                        this.PictureBox1 = new System.Windows.Forms.PictureBox();
                        this.EtiquetaEstado = new Lui.Forms.Label();
                        this.BotonCancelar = new Lui.Forms.LinkLabel();
                        this.EtiquetaOtrasOperaciones = new Lui.Forms.Label();
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // EtiquetaNombreOperacion
                        // 
                        this.EtiquetaNombreOperacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaNombreOperacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        this.EtiquetaNombreOperacion.Location = new System.Drawing.Point(104, 24);
                        this.EtiquetaNombreOperacion.Name = "EtiquetaNombreOperacion";
                        this.EtiquetaNombreOperacion.Size = new System.Drawing.Size(392, 44);
                        this.EtiquetaNombreOperacion.TabIndex = 0;
                        this.EtiquetaNombreOperacion.Text = "Procesando...";
                        this.EtiquetaNombreOperacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.EtiquetaNombreOperacion.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        // 
                        // EtiquetaDescripcion
                        // 
                        this.EtiquetaDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaDescripcion.Location = new System.Drawing.Point(104, 108);
                        this.EtiquetaDescripcion.Name = "EtiquetaDescripcion";
                        this.EtiquetaDescripcion.Size = new System.Drawing.Size(392, 78);
                        this.EtiquetaDescripcion.TabIndex = 2;
                        this.EtiquetaDescripcion.Text = "Por favor aguarde mientras se completan las operaciones.";
                        // 
                        // ProgressBar
                        // 
                        this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.ProgressBar.Location = new System.Drawing.Point(104, 240);
                        this.ProgressBar.Name = "ProgressBar";
                        this.ProgressBar.Size = new System.Drawing.Size(392, 20);
                        this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
                        this.ProgressBar.TabIndex = 3;
                        // 
                        // PictureBox1
                        // 
                        this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
                        this.PictureBox1.Location = new System.Drawing.Point(24, 24);
                        this.PictureBox1.Name = "PictureBox1";
                        this.PictureBox1.Size = new System.Drawing.Size(64, 64);
                        this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        this.PictureBox1.TabIndex = 5;
                        this.PictureBox1.TabStop = false;
                        // 
                        // EtiquetaEstado
                        // 
                        this.EtiquetaEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaEstado.Location = new System.Drawing.Point(104, 196);
                        this.EtiquetaEstado.Name = "EtiquetaEstado";
                        this.EtiquetaEstado.Size = new System.Drawing.Size(392, 44);
                        this.EtiquetaEstado.TabIndex = 0;
                        // 
                        // BotonCancelar
                        // 
                        this.BotonCancelar.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
                        this.BotonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.BotonCancelar.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
                        this.BotonCancelar.Location = new System.Drawing.Point(407, 168);
                        this.BotonCancelar.Name = "BotonCancelar";
                        this.BotonCancelar.Size = new System.Drawing.Size(89, 20);
                        this.BotonCancelar.TabIndex = 0;
                        this.BotonCancelar.TabStop = true;
                        this.BotonCancelar.Text = "Cancelar";
                        this.BotonCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                        this.BotonCancelar.Visible = false;
                        this.BotonCancelar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BotonCancelar_LinkClicked);
                        // 
                        // EtiquetaOtrasOperaciones
                        // 
                        this.EtiquetaOtrasOperaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EtiquetaOtrasOperaciones.Location = new System.Drawing.Point(104, 72);
                        this.EtiquetaOtrasOperaciones.Name = "EtiquetaOtrasOperaciones";
                        this.EtiquetaOtrasOperaciones.Size = new System.Drawing.Size(392, 32);
                        this.EtiquetaOtrasOperaciones.TabIndex = 6;
                        // 
                        // ProgressForm
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(521, 292);
                        this.ControlBox = false;
                        this.Controls.Add(this.EtiquetaOtrasOperaciones);
                        this.Controls.Add(this.BotonCancelar);
                        this.Controls.Add(this.ProgressBar);
                        this.Controls.Add(this.EtiquetaEstado);
                        this.Controls.Add(this.PictureBox1);
                        this.Controls.Add(this.EtiquetaDescripcion);
                        this.Controls.Add(this.EtiquetaNombreOperacion);
                        this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.Name = "ProgressForm";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "Progreso";
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
                        this.ResumeLayout(false);

		}


		#endregion

                private LinkLabel BotonCancelar;
                private Label EtiquetaOtrasOperaciones;
	}
}
