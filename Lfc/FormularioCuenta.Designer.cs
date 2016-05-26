namespace Lfc
{
	partial class FormularioCuenta
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

		private void InitializeComponent()
		{
                        this.EtiquetaTitulo = new Lui.Forms.Label();
                        this.PanelContadores.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // EtiquetaTitulo
                        // 
                        this.EtiquetaTitulo.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        this.EtiquetaTitulo.Location = new System.Drawing.Point(8, 8);
                        this.EtiquetaTitulo.Name = "EtiquetaTitulo";
                        this.EtiquetaTitulo.Size = new System.Drawing.Size(208, 64);
                        this.EtiquetaTitulo.TabIndex = 68;
                        this.EtiquetaTitulo.Text = "Cuentas corrientes";
                        this.EtiquetaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.EtiquetaTitulo.UseMnemonic = false;
                        // 
                        // FormularioCuenta
                        // 
                        this.Controls.Add(this.EtiquetaTitulo);
                        this.Name = "FormularioCuenta";
                        this.Text = "Caja";
                        this.Controls.SetChildIndex(this.PanelContadores, 0);
                        this.Controls.SetChildIndex(this.PicEsperar, 0);
                        this.Controls.SetChildIndex(this.EtiquetaCantidad, 0);
                        this.Controls.SetChildIndex(this.Listado, 0);
                        this.Controls.SetChildIndex(this.EtiquetaTitulo, 0);
                        this.PanelContadores.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).EndInit();
                        this.ResumeLayout(false);

		}


		#endregion

                internal Lui.Forms.Label EtiquetaTitulo;

        }
}
