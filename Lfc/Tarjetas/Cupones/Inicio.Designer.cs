namespace Lfc.Tarjetas.Cupones
{
        public partial class Inicio
        {
                #region Código generado por el Diseñador de Windows Forms

                private void InitializeComponent()
                {
                        this.BotonAnular = new Lui.Forms.Button();
                        this.BotonAcreditar = new Lui.Forms.Button();
                        this.BotonPresentar = new Lui.Forms.Button();
                        this.SuspendLayout();
                        // 
                        // Listado
                        // 
                        this.Listado.Size = new System.Drawing.Size(1080, 472);
                        // 
                        // BotonAnular
                        // 
                        this.BotonAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonAnular.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonAnular.Image = null;
                        this.BotonAnular.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonAnular.Location = new System.Drawing.Point(12, 348);
                        this.BotonAnular.Name = "BotonAnular";
                        this.BotonAnular.Size = new System.Drawing.Size(96, 29);
                        this.BotonAnular.SubLabelPos = Lui.Forms.SubLabelPositions.Right;
                        this.BotonAnular.Subtext = "F6";
                        this.BotonAnular.TabIndex = 7;
                        this.BotonAnular.Text = "Anular";
                        this.BotonAnular.Click += new System.EventHandler(this.BotonAnular_Click);
                        // 
                        // BotonAcreditar
                        // 
                        this.BotonAcreditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonAcreditar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonAcreditar.Image = null;
                        this.BotonAcreditar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonAcreditar.Location = new System.Drawing.Point(12, 312);
                        this.BotonAcreditar.Name = "BotonAcreditar";
                        this.BotonAcreditar.Size = new System.Drawing.Size(96, 29);
                        this.BotonAcreditar.SubLabelPos = Lui.Forms.SubLabelPositions.Right;
                        this.BotonAcreditar.Subtext = "F4";
                        this.BotonAcreditar.TabIndex = 6;
                        this.BotonAcreditar.Text = "Acreditar";
                        this.BotonAcreditar.Click += new System.EventHandler(this.BotonAcreditar_Click);
                        // 
                        // BotonPresentar
                        // 
                        this.BotonPresentar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonPresentar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonPresentar.Image = null;
                        this.BotonPresentar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonPresentar.Location = new System.Drawing.Point(12, 276);
                        this.BotonPresentar.Name = "BotonPresentar";
                        this.BotonPresentar.Size = new System.Drawing.Size(96, 29);
                        this.BotonPresentar.SubLabelPos = Lui.Forms.SubLabelPositions.Right;
                        this.BotonPresentar.Subtext = "F3";
                        this.BotonPresentar.TabIndex = 5;
                        this.BotonPresentar.Text = "Presentar";
                        this.BotonPresentar.Click += new System.EventHandler(this.BotonPresentar_Click);
                        // 
                        // Inicio
                        // 
                        this.PanelAcciones.Controls.Add(this.BotonPresentar);
                        this.PanelAcciones.Controls.Add(this.BotonAnular);
                        this.PanelAcciones.Controls.Add(this.BotonAcreditar);
                        this.Name = "Inicio";
                        this.Text = "Cobros con Cupón";
                        this.Controls.SetChildIndex(this.EtiquetaCantidad, 0);
                        this.ResumeLayout(false);

                }

                #endregion

                internal Lui.Forms.Button BotonAcreditar;
                internal Lui.Forms.Button BotonPresentar;
                internal Lui.Forms.Button BotonAnular;
        }
}
