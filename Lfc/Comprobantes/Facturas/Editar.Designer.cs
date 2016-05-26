namespace Lfc.Comprobantes.Facturas
{
        public partial class Editar
        {
                #region Código generado por el Diseñador de Windows Forms

                private void InitializeComponent()
                {
                        this.Label2 = new Lui.Forms.Label();
                        this.EntradaFormaPago = new Lcc.Entrada.CodigoDetalle();
                        this.Label10 = new Lui.Forms.Label();
                        this.EntradaTipo = new Lui.Forms.ComboBox();
                        this.Label11 = new Lui.Forms.Label();
                        this.EntradaRemito = new Lui.Forms.TextBox();
                        this.PanelFormaPago = new Lui.Forms.Panel();
                        this.PanelComprobanteOriginal = new Lui.Forms.Panel();
                        this.EtiquetaComprobanteOriginal = new Lui.Forms.Label();
                        this.EntradaComprobanteOriginal = new Lcc.Entrada.CodigoDetalle();
                        this.PanelFormaPago.SuspendLayout();
                        this.PanelComprobanteOriginal.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // Label2
                        // 
                        this.Label2.Location = new System.Drawing.Point(0, 0);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(108, 24);
                        this.Label2.TabIndex = 0;
                        this.Label2.Text = "Forma de pago";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFormaPago
                        // 
                        this.EntradaFormaPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaFormaPago.AutoTab = true;
                        this.EntradaFormaPago.CanCreate = true;
                        this.EntradaFormaPago.Filter = "cobros=1 AND estado=1";
                        this.EntradaFormaPago.Location = new System.Drawing.Point(112, 0);
                        this.EntradaFormaPago.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaFormaPago.MaxLength = 200;
                        this.EntradaFormaPago.Name = "EntradaFormaPago";
                        this.EntradaFormaPago.NombreTipo = "Lbl.Pagos.FormaDePago";
                        this.EntradaFormaPago.Required = true;
                        this.EntradaFormaPago.Size = new System.Drawing.Size(120, 24);
                        this.EntradaFormaPago.TabIndex = 1;
                        this.EntradaFormaPago.Text = "0";
                        this.EntradaFormaPago.Leave += new System.EventHandler(this.EntradaFormaPago_Leave);
                        // 
                        // Label10
                        // 
                        this.Label10.Location = new System.Drawing.Point(0, 32);
                        this.Label10.Name = "Label10";
                        this.Label10.Size = new System.Drawing.Size(72, 24);
                        this.Label10.TabIndex = 10;
                        this.Label10.Text = "Tipo";
                        this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaTipo
                        // 
                        this.EntradaTipo.AlwaysExpanded = false;
                        this.EntradaTipo.AutoSize = true;
                        this.EntradaTipo.Location = new System.Drawing.Point(72, 32);
                        this.EntradaTipo.Name = "EntradaTipo";
                        this.EntradaTipo.SetData = new string[] {
        "Factura A|FA"};
                        this.EntradaTipo.Size = new System.Drawing.Size(116, 25);
                        this.EntradaTipo.TabIndex = 11;
                        this.EntradaTipo.TextKey = "FA";
                        this.EntradaTipo.TextChanged += new System.EventHandler(this.EntradaTipo_TextChanged);
                        // 
                        // Label11
                        // 
                        this.Label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label11.Location = new System.Drawing.Point(436, 32);
                        this.Label11.Name = "Label11";
                        this.Label11.Size = new System.Drawing.Size(56, 24);
                        this.Label11.TabIndex = 14;
                        this.Label11.Text = "Remito";
                        this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaRemito
                        // 
                        this.EntradaRemito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaRemito.Location = new System.Drawing.Point(492, 32);
                        this.EntradaRemito.Name = "EntradaRemito";
                        this.EntradaRemito.PlaceholderText = "Ninguno";
                        this.EntradaRemito.Size = new System.Drawing.Size(144, 24);
                        this.EntradaRemito.TabIndex = 15;
                        this.EntradaRemito.TextChanged += new System.EventHandler(this.EntradaRemito_TextChanged);
                        // 
                        // PanelFormaPago
                        // 
                        this.PanelFormaPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.PanelFormaPago.Controls.Add(this.Label2);
                        this.PanelFormaPago.Controls.Add(this.EntradaFormaPago);
                        this.PanelFormaPago.Location = new System.Drawing.Point(200, 32);
                        this.PanelFormaPago.Name = "PanelFormaPago";
                        this.PanelFormaPago.Size = new System.Drawing.Size(232, 24);
                        this.PanelFormaPago.TabIndex = 12;
                        // 
                        // PanelComprobanteOriginal
                        // 
                        this.PanelComprobanteOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.PanelComprobanteOriginal.Controls.Add(this.EtiquetaComprobanteOriginal);
                        this.PanelComprobanteOriginal.Controls.Add(this.EntradaComprobanteOriginal);
                        this.PanelComprobanteOriginal.Location = new System.Drawing.Point(200, 32);
                        this.PanelComprobanteOriginal.Name = "PanelComprobanteOriginal";
                        this.PanelComprobanteOriginal.Size = new System.Drawing.Size(232, 24);
                        this.PanelComprobanteOriginal.TabIndex = 12;
                        this.PanelComprobanteOriginal.Visible = false;
                        // 
                        // EtiquetaComprobanteOriginal
                        // 
                        this.EtiquetaComprobanteOriginal.Location = new System.Drawing.Point(0, 0);
                        this.EtiquetaComprobanteOriginal.Name = "EtiquetaComprobanteOriginal";
                        this.EtiquetaComprobanteOriginal.Size = new System.Drawing.Size(108, 24);
                        this.EtiquetaComprobanteOriginal.TabIndex = 0;
                        this.EtiquetaComprobanteOriginal.Text = "Factura";
                        this.EtiquetaComprobanteOriginal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaComprobanteOriginal
                        // 
                        this.EntradaComprobanteOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaComprobanteOriginal.AutoTab = true;
                        this.EntradaComprobanteOriginal.CanCreate = true;
                        this.EntradaComprobanteOriginal.ExtraDetailFields = "tipo_fac,total,fecha";
                        this.EntradaComprobanteOriginal.Filter = "tipo_fac IN (\'FA\', \'FB\', \'FC\', \'FE\', \'FM\') AND numero>0";
                        this.EntradaComprobanteOriginal.Location = new System.Drawing.Point(112, 0);
                        this.EntradaComprobanteOriginal.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaComprobanteOriginal.MaxLength = 200;
                        this.EntradaComprobanteOriginal.Name = "EntradaComprobanteOriginal";
                        this.EntradaComprobanteOriginal.NombreTipo = "Lbl.Comprobantes.Factura";
                        this.EntradaComprobanteOriginal.Required = true;
                        this.EntradaComprobanteOriginal.Size = new System.Drawing.Size(120, 24);
                        this.EntradaComprobanteOriginal.TabIndex = 1;
                        this.EntradaComprobanteOriginal.Text = "0";
                        // 
                        // Editar
                        // 
                        this.Controls.Add(this.PanelComprobanteOriginal);
                        this.Controls.Add(this.EntradaTipo);
                        this.Controls.Add(this.EntradaRemito);
                        this.Controls.Add(this.Label11);
                        this.Controls.Add(this.Label10);
                        this.Controls.Add(this.PanelFormaPago);
                        this.MinimumSize = new System.Drawing.Size(600, 320);
                        this.Name = "Editar";
                        this.Controls.SetChildIndex(this.PanelFormaPago, 0);
                        this.Controls.SetChildIndex(this.Label10, 0);
                        this.Controls.SetChildIndex(this.Label11, 0);
                        this.Controls.SetChildIndex(this.EntradaRemito, 0);
                        this.Controls.SetChildIndex(this.EntradaTipo, 0);
                        this.Controls.SetChildIndex(this.PanelComprobanteOriginal, 0);
                        this.PanelFormaPago.ResumeLayout(false);
                        this.PanelComprobanteOriginal.ResumeLayout(false);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                internal Lui.Forms.Label Label2;
                internal Lui.Forms.Label Label10;
                public Lui.Forms.ComboBox EntradaTipo;
                internal Lui.Forms.Label Label11;
                public Lcc.Entrada.CodigoDetalle EntradaFormaPago;
                public Lui.Forms.TextBox EntradaRemito;
                internal Lui.Forms.Panel PanelFormaPago;
                internal Lui.Forms.Panel PanelComprobanteOriginal;
                internal Lui.Forms.Label EtiquetaComprobanteOriginal;
                public Lcc.Entrada.CodigoDetalle EntradaComprobanteOriginal;
        }
}
