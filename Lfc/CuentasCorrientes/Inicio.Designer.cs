namespace Lfc.CuentasCorrientes
{
        public partial class Inicio
        {
                private void InitializeComponent()
                {
                        this.BotonNotaDeb = new Lui.Forms.Button();
                        this.BotonNotaCred = new Lui.Forms.Button();
                        this.BotonAjuste = new Lui.Forms.Button();
                        this.PanelContadores.SuspendLayout();
                        ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // BotonNotaDeb
                        // 
                        this.BotonNotaDeb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonNotaDeb.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonNotaDeb.Image = null;
                        this.BotonNotaDeb.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonNotaDeb.Location = new System.Drawing.Point(152, 137);
                        this.BotonNotaDeb.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
                        this.BotonNotaDeb.MaximumSize = new System.Drawing.Size(108, 40);
                        this.BotonNotaDeb.MinimumSize = new System.Drawing.Size(96, 32);
                        this.BotonNotaDeb.Name = "BotonNotaDeb";
                        this.BotonNotaDeb.Size = new System.Drawing.Size(108, 40);
                        this.BotonNotaDeb.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.BotonNotaDeb.Subtext = "F4";
                        this.BotonNotaDeb.TabIndex = 61;
                        this.BotonNotaDeb.Text = "Nota Déb";
                        this.BotonNotaDeb.Click += new System.EventHandler(this.BotonNotaDeb_Click);
                        // 
                        // BotonNotaCred
                        // 
                        this.BotonNotaCred.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonNotaCred.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonNotaCred.Image = null;
                        this.BotonNotaCred.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonNotaCred.Location = new System.Drawing.Point(152, 91);
                        this.BotonNotaCred.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
                        this.BotonNotaCred.MaximumSize = new System.Drawing.Size(108, 40);
                        this.BotonNotaCred.MinimumSize = new System.Drawing.Size(96, 32);
                        this.BotonNotaCred.Name = "BotonNotaCred";
                        this.BotonNotaCred.Size = new System.Drawing.Size(108, 40);
                        this.BotonNotaCred.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.BotonNotaCred.Subtext = "F3";
                        this.BotonNotaCred.TabIndex = 60;
                        this.BotonNotaCred.Text = "Nota Créd";
                        this.BotonNotaCred.Click += new System.EventHandler(this.BotonNotaCred_Click);
                        // 
                        // BotonAjuste
                        // 
                        this.BotonAjuste.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonAjuste.Image = null;
                        this.BotonAjuste.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonAjuste.Location = new System.Drawing.Point(44, 252);
                        this.BotonAjuste.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
                        this.BotonAjuste.MaximumSize = new System.Drawing.Size(108, 40);
                        this.BotonAjuste.MinimumSize = new System.Drawing.Size(96, 32);
                        this.BotonAjuste.Name = "BotonAjuste";
                        this.BotonAjuste.Size = new System.Drawing.Size(108, 40);
                        this.BotonAjuste.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.BotonAjuste.Subtext = "F5";
                        this.BotonAjuste.TabIndex = 62;
                        this.BotonAjuste.Text = "Ajuste";
                        this.BotonAjuste.Click += new System.EventHandler(this.BotonAjuste_Click);
                        // 
                        // Inicio
                        // 
                        this.ClientSize = new System.Drawing.Size(864, 441);
                        this.Controls.Add(this.BotonAjuste);
                        this.Name = "Inicio";
                        this.Text = "Cuenta corriente";
                        this.Controls.SetChildIndex(this.BotonAjuste, 0);
                        this.Controls.SetChildIndex(this.PanelContadores, 0);
                        this.Controls.SetChildIndex(this.PicEsperar, 0);
                        this.Controls.SetChildIndex(this.EtiquetaCantidad, 0);
                        this.Controls.SetChildIndex(this.Listado, 0);
                        this.PanelContadores.ResumeLayout(false);
                        ((System.ComponentModel.ISupportInitialize)(this.PicEsperar)).EndInit();
                        this.ResumeLayout(false);

                }
                
                internal Lui.Forms.Button BotonNotaDeb;
                internal Lui.Forms.Button BotonNotaCred;
                internal Lui.Forms.Button BotonAjuste;
        }
}
