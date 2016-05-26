namespace Lui.Forms
{
	partial class CalendarPopUp
	{
		private Lui.Forms.Calendar Calendar1;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
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

		#region Código generado por el diseñador
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
                        this.Calendar1 = new Lui.Forms.Calendar();
                        this.BotonAnioAnterior = new Lui.Forms.Button();
                        this.BotonAnioSiguiente = new Lui.Forms.Button();
                        this.BotonMes1 = new Lui.Forms.Button();
                        this.BotonMes2 = new Lui.Forms.Button();
                        this.BotonMes4 = new Lui.Forms.Button();
                        this.BotonMes3 = new Lui.Forms.Button();
                        this.BotonMes8 = new Lui.Forms.Button();
                        this.BotonMes7 = new Lui.Forms.Button();
                        this.BotonMes6 = new Lui.Forms.Button();
                        this.BotonMes5 = new Lui.Forms.Button();
                        this.BotonMes12 = new Lui.Forms.Button();
                        this.BotonMes11 = new Lui.Forms.Button();
                        this.BotonMes10 = new Lui.Forms.Button();
                        this.BotonMes9 = new Lui.Forms.Button();
                        this.BotonHoy = new Lui.Forms.Button();
                        this.SuspendLayout();
                        // 
                        // Calendar1
                        // 
                        this.Calendar1.DateFormat = "dd/MM/yyyy";
                        this.Calendar1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
                        this.Calendar1.Location = new System.Drawing.Point(280, 28);
                        this.Calendar1.MultiSelect = false;
                        this.Calendar1.Name = "Calendar1";
                        this.Calendar1.Padding = new System.Windows.Forms.Padding(2);
                        this.Calendar1.ShowFocusRect = true;
                        this.Calendar1.Size = new System.Drawing.Size(232, 200);
                        this.Calendar1.TabIndex = 0;
                        this.Calendar1.CurrentDateChanged += new System.EventHandler(this.Calendar1_CurrentDateChanged);
                        this.Calendar1.DoubleClick += new System.EventHandler(this.Calendar1_DoubleClick);
                        this.Calendar1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Calendar1_KeyPress);
                        // 
                        // BotonAnioAnterior
                        // 
                        this.BotonAnioAnterior.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonAnioAnterior.ForeColor = System.Drawing.Color.Black;
                        this.BotonAnioAnterior.Image = null;
                        this.BotonAnioAnterior.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonAnioAnterior.Location = new System.Drawing.Point(28, 152);
                        this.BotonAnioAnterior.Name = "BotonAnioAnterior";
                        this.BotonAnioAnterior.Size = new System.Drawing.Size(68, 24);
                        this.BotonAnioAnterior.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonAnioAnterior.Subtext = "";
                        this.BotonAnioAnterior.TabIndex = 13;
                        this.BotonAnioAnterior.Text = "< 2013";
                        this.BotonAnioAnterior.Click += new System.EventHandler(this.BotonAnioAnterior_Click);
                        // 
                        // BotonAnioSiguiente
                        // 
                        this.BotonAnioSiguiente.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonAnioSiguiente.ForeColor = System.Drawing.Color.Black;
                        this.BotonAnioSiguiente.Image = null;
                        this.BotonAnioSiguiente.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonAnioSiguiente.Location = new System.Drawing.Point(172, 152);
                        this.BotonAnioSiguiente.Name = "BotonAnioSiguiente";
                        this.BotonAnioSiguiente.Size = new System.Drawing.Size(68, 24);
                        this.BotonAnioSiguiente.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonAnioSiguiente.Subtext = "";
                        this.BotonAnioSiguiente.TabIndex = 14;
                        this.BotonAnioSiguiente.Text = "2015 >";
                        this.BotonAnioSiguiente.Click += new System.EventHandler(this.BotonAnioSiguiente_Click);
                        // 
                        // BotonMes1
                        // 
                        this.BotonMes1.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonMes1.ForeColor = System.Drawing.Color.Black;
                        this.BotonMes1.Image = null;
                        this.BotonMes1.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonMes1.Location = new System.Drawing.Point(28, 28);
                        this.BotonMes1.Name = "BotonMes1";
                        this.BotonMes1.Size = new System.Drawing.Size(68, 24);
                        this.BotonMes1.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonMes1.Subtext = "";
                        this.BotonMes1.TabIndex = 1;
                        this.BotonMes1.Text = "Ene";
                        this.BotonMes1.Click += new System.EventHandler(this.BotonMes1_Click);
                        // 
                        // BotonMes2
                        // 
                        this.BotonMes2.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonMes2.ForeColor = System.Drawing.Color.Black;
                        this.BotonMes2.Image = null;
                        this.BotonMes2.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonMes2.Location = new System.Drawing.Point(100, 28);
                        this.BotonMes2.Name = "BotonMes2";
                        this.BotonMes2.Size = new System.Drawing.Size(68, 24);
                        this.BotonMes2.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonMes2.Subtext = "";
                        this.BotonMes2.TabIndex = 2;
                        this.BotonMes2.Text = "Feb";
                        this.BotonMes2.Click += new System.EventHandler(this.BotonMes2_Click);
                        // 
                        // BotonMes4
                        // 
                        this.BotonMes4.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonMes4.ForeColor = System.Drawing.Color.Black;
                        this.BotonMes4.Image = null;
                        this.BotonMes4.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonMes4.Location = new System.Drawing.Point(28, 56);
                        this.BotonMes4.Name = "BotonMes4";
                        this.BotonMes4.Size = new System.Drawing.Size(68, 24);
                        this.BotonMes4.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonMes4.Subtext = "";
                        this.BotonMes4.TabIndex = 4;
                        this.BotonMes4.Text = "Abr";
                        this.BotonMes4.Click += new System.EventHandler(this.BotonMes4_Click);
                        // 
                        // BotonMes3
                        // 
                        this.BotonMes3.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonMes3.ForeColor = System.Drawing.Color.Black;
                        this.BotonMes3.Image = null;
                        this.BotonMes3.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonMes3.Location = new System.Drawing.Point(172, 28);
                        this.BotonMes3.Name = "BotonMes3";
                        this.BotonMes3.Size = new System.Drawing.Size(68, 24);
                        this.BotonMes3.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonMes3.Subtext = "";
                        this.BotonMes3.TabIndex = 3;
                        this.BotonMes3.Text = "Mar";
                        this.BotonMes3.Click += new System.EventHandler(this.BotonMes3_Click);
                        // 
                        // BotonMes8
                        // 
                        this.BotonMes8.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonMes8.ForeColor = System.Drawing.Color.Black;
                        this.BotonMes8.Image = null;
                        this.BotonMes8.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonMes8.Location = new System.Drawing.Point(100, 84);
                        this.BotonMes8.Name = "BotonMes8";
                        this.BotonMes8.Size = new System.Drawing.Size(68, 24);
                        this.BotonMes8.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonMes8.Subtext = "";
                        this.BotonMes8.TabIndex = 8;
                        this.BotonMes8.Text = "Ago";
                        this.BotonMes8.Click += new System.EventHandler(this.BotonMes8_Click);
                        // 
                        // BotonMes7
                        // 
                        this.BotonMes7.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonMes7.ForeColor = System.Drawing.Color.Black;
                        this.BotonMes7.Image = null;
                        this.BotonMes7.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonMes7.Location = new System.Drawing.Point(28, 84);
                        this.BotonMes7.Name = "BotonMes7";
                        this.BotonMes7.Size = new System.Drawing.Size(68, 24);
                        this.BotonMes7.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonMes7.Subtext = "";
                        this.BotonMes7.TabIndex = 7;
                        this.BotonMes7.Text = "Jul";
                        this.BotonMes7.Click += new System.EventHandler(this.BotonMes7_Click);
                        // 
                        // BotonMes6
                        // 
                        this.BotonMes6.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonMes6.ForeColor = System.Drawing.Color.Black;
                        this.BotonMes6.Image = null;
                        this.BotonMes6.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonMes6.Location = new System.Drawing.Point(172, 56);
                        this.BotonMes6.Name = "BotonMes6";
                        this.BotonMes6.Size = new System.Drawing.Size(68, 24);
                        this.BotonMes6.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonMes6.Subtext = "";
                        this.BotonMes6.TabIndex = 6;
                        this.BotonMes6.Text = "Jun";
                        this.BotonMes6.Click += new System.EventHandler(this.BotonMes6_Click);
                        // 
                        // BotonMes5
                        // 
                        this.BotonMes5.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonMes5.ForeColor = System.Drawing.Color.Black;
                        this.BotonMes5.Image = null;
                        this.BotonMes5.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonMes5.Location = new System.Drawing.Point(100, 56);
                        this.BotonMes5.Name = "BotonMes5";
                        this.BotonMes5.Size = new System.Drawing.Size(68, 24);
                        this.BotonMes5.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonMes5.Subtext = "";
                        this.BotonMes5.TabIndex = 5;
                        this.BotonMes5.Text = "May";
                        this.BotonMes5.Click += new System.EventHandler(this.BotonMes5_Click);
                        // 
                        // BotonMes12
                        // 
                        this.BotonMes12.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonMes12.ForeColor = System.Drawing.Color.Black;
                        this.BotonMes12.Image = null;
                        this.BotonMes12.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonMes12.Location = new System.Drawing.Point(172, 112);
                        this.BotonMes12.Name = "BotonMes12";
                        this.BotonMes12.Size = new System.Drawing.Size(68, 24);
                        this.BotonMes12.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonMes12.Subtext = "";
                        this.BotonMes12.TabIndex = 12;
                        this.BotonMes12.Text = "Dic";
                        this.BotonMes12.Click += new System.EventHandler(this.BotonMes12_Click);
                        // 
                        // BotonMes11
                        // 
                        this.BotonMes11.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonMes11.ForeColor = System.Drawing.Color.Black;
                        this.BotonMes11.Image = null;
                        this.BotonMes11.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonMes11.Location = new System.Drawing.Point(100, 112);
                        this.BotonMes11.Name = "BotonMes11";
                        this.BotonMes11.Size = new System.Drawing.Size(68, 24);
                        this.BotonMes11.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonMes11.Subtext = "";
                        this.BotonMes11.TabIndex = 11;
                        this.BotonMes11.Text = "Nov";
                        this.BotonMes11.Click += new System.EventHandler(this.BotonMes11_Click);
                        // 
                        // BotonMes10
                        // 
                        this.BotonMes10.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonMes10.ForeColor = System.Drawing.Color.Black;
                        this.BotonMes10.Image = null;
                        this.BotonMes10.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonMes10.Location = new System.Drawing.Point(28, 112);
                        this.BotonMes10.Name = "BotonMes10";
                        this.BotonMes10.Size = new System.Drawing.Size(68, 24);
                        this.BotonMes10.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonMes10.Subtext = "";
                        this.BotonMes10.TabIndex = 10;
                        this.BotonMes10.Text = "Oct";
                        this.BotonMes10.Click += new System.EventHandler(this.BotonMes10_Click);
                        // 
                        // BotonMes9
                        // 
                        this.BotonMes9.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonMes9.ForeColor = System.Drawing.Color.Black;
                        this.BotonMes9.Image = null;
                        this.BotonMes9.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonMes9.Location = new System.Drawing.Point(172, 84);
                        this.BotonMes9.Name = "BotonMes9";
                        this.BotonMes9.Size = new System.Drawing.Size(68, 24);
                        this.BotonMes9.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonMes9.Subtext = "";
                        this.BotonMes9.TabIndex = 9;
                        this.BotonMes9.Text = "Sep";
                        this.BotonMes9.Click += new System.EventHandler(this.BotonMes9_Click);
                        // 
                        // BotonHoy
                        // 
                        this.BotonHoy.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonHoy.ForeColor = System.Drawing.Color.Black;
                        this.BotonHoy.Image = null;
                        this.BotonHoy.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonHoy.Location = new System.Drawing.Point(100, 192);
                        this.BotonHoy.Name = "BotonHoy";
                        this.BotonHoy.Size = new System.Drawing.Size(68, 24);
                        this.BotonHoy.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonHoy.Subtext = "";
                        this.BotonHoy.TabIndex = 15;
                        this.BotonHoy.Text = "Hoy";
                        this.BotonHoy.Click += new System.EventHandler(this.BotonHoy_Click);
                        // 
                        // CalendarPopUp
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(543, 308);
                        this.Controls.Add(this.BotonHoy);
                        this.Controls.Add(this.BotonMes12);
                        this.Controls.Add(this.BotonMes11);
                        this.Controls.Add(this.BotonMes10);
                        this.Controls.Add(this.BotonMes9);
                        this.Controls.Add(this.BotonMes8);
                        this.Controls.Add(this.BotonMes7);
                        this.Controls.Add(this.BotonMes6);
                        this.Controls.Add(this.BotonMes5);
                        this.Controls.Add(this.BotonMes4);
                        this.Controls.Add(this.BotonMes3);
                        this.Controls.Add(this.BotonMes2);
                        this.Controls.Add(this.BotonMes1);
                        this.Controls.Add(this.BotonAnioSiguiente);
                        this.Controls.Add(this.BotonAnioAnterior);
                        this.Controls.Add(this.Calendar1);
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                        this.Name = "CalendarPopUp";
                        this.ShowInTaskbar = false;
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        this.Text = "Calendario";
                        this.TopMost = true;
                        this.Controls.SetChildIndex(this.Calendar1, 0);
                        this.Controls.SetChildIndex(this.BotonAnioAnterior, 0);
                        this.Controls.SetChildIndex(this.BotonAnioSiguiente, 0);
                        this.Controls.SetChildIndex(this.BotonMes1, 0);
                        this.Controls.SetChildIndex(this.BotonMes2, 0);
                        this.Controls.SetChildIndex(this.BotonMes3, 0);
                        this.Controls.SetChildIndex(this.BotonMes4, 0);
                        this.Controls.SetChildIndex(this.BotonMes5, 0);
                        this.Controls.SetChildIndex(this.BotonMes6, 0);
                        this.Controls.SetChildIndex(this.BotonMes7, 0);
                        this.Controls.SetChildIndex(this.BotonMes8, 0);
                        this.Controls.SetChildIndex(this.BotonMes9, 0);
                        this.Controls.SetChildIndex(this.BotonMes10, 0);
                        this.Controls.SetChildIndex(this.BotonMes11, 0);
                        this.Controls.SetChildIndex(this.BotonMes12, 0);
                        this.Controls.SetChildIndex(this.BotonHoy, 0);
                        this.ResumeLayout(false);

		}
		#endregion

                private Button BotonAnioAnterior;
                private Button BotonAnioSiguiente;
                private Button BotonMes1;
                private Button BotonMes2;
                private Button BotonMes4;
                private Button BotonMes3;
                private Button BotonMes8;
                private Button BotonMes7;
                private Button BotonMes6;
                private Button BotonMes5;
                private Button BotonMes12;
                private Button BotonMes11;
                private Button BotonMes10;
                private Button BotonMes9;
                private Button BotonHoy;
	}
}
