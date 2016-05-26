namespace Lfc.Comprobantes.Tipo
{
        partial class AgregarTipoImpresora
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
                        if (disposing && (components != null)) {
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
                        this.EntradaImpresora = new Lcc.Entrada.CodigoDetalle();
                        this.Label16 = new Lui.Forms.Label();
                        this.EntradaSucursal = new Lcc.Entrada.CodigoDetalle();
                        this.label1 = new Lui.Forms.Label();
                        this.Label3 = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.BotonSeleccionarEstacion = new Lui.Forms.Button();
                        this.EntradaEstacion = new Lui.Forms.TextBox();
                        this.EntradaPuntoDeVenta = new Lui.Forms.TextBox();
                        this.label4 = new Lui.Forms.Label();
                        this.label5 = new Lui.Forms.Label();
                        this.label6 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaImpresora
                        // 
                        this.EntradaImpresora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaImpresora.AutoTab = true;
                        this.EntradaImpresora.CanCreate = true;
                        this.EntradaImpresora.Filter = "";
                        this.EntradaImpresora.Location = new System.Drawing.Point(152, 64);
                        this.EntradaImpresora.MaxLength = 200;
                        this.EntradaImpresora.Name = "EntradaImpresora";
                        this.EntradaImpresora.PlaceholderText = "Ninguno";
                        this.EntradaImpresora.Required = false;
                        this.EntradaImpresora.Size = new System.Drawing.Size(456, 24);
                        this.EntradaImpresora.TabIndex = 1;
                        this.EntradaImpresora.NombreTipo = "Lbl.Impresion.Impresora";
                        this.EntradaImpresora.Text = "0";
                        this.EntradaImpresora.TextChanged += new System.EventHandler(this.EntradaImpresora_TextChanged);
                        // 
                        // Label16
                        // 
                        this.Label16.Location = new System.Drawing.Point(24, 64);
                        this.Label16.Name = "Label16";
                        this.Label16.Size = new System.Drawing.Size(128, 24);
                        this.Label16.TabIndex = 0;
                        this.Label16.Text = "Impresora";
                        this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaSucursal
                        // 
                        this.EntradaSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaSucursal.AutoTab = true;
                        this.EntradaSucursal.CanCreate = true;
                        this.EntradaSucursal.Filter = "";
                        this.EntradaSucursal.Location = new System.Drawing.Point(152, 136);
                        this.EntradaSucursal.MaxLength = 200;
                        this.EntradaSucursal.Name = "EntradaSucursal";
                        this.EntradaSucursal.PlaceholderText = "Todas";
                        this.EntradaSucursal.Required = false;
                        this.EntradaSucursal.Size = new System.Drawing.Size(456, 24);
                        this.EntradaSucursal.TabIndex = 3;
                        this.EntradaSucursal.NombreTipo = "Lbl.Entidades.Sucursal";
                        this.EntradaSucursal.Text = "0";
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(24, 136);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(128, 24);
                        this.label1.TabIndex = 2;
                        this.label1.Text = "Sucursal";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Label3
                        // 
                        this.Label3.Location = new System.Drawing.Point(24, 168);
                        this.Label3.Name = "Label3";
                        this.Label3.Size = new System.Drawing.Size(128, 24);
                        this.Label3.TabIndex = 4;
                        this.Label3.Text = "Punto de venta";
                        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(24, 200);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(128, 24);
                        this.label2.TabIndex = 6;
                        this.label2.Text = "Equipo";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // BotonSeleccionarEstacion
                        // 
                        this.BotonSeleccionarEstacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonSeleccionarEstacion.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonSeleccionarEstacion.ForeColor = System.Drawing.Color.Black;
                        this.BotonSeleccionarEstacion.Image = null;
                        this.BotonSeleccionarEstacion.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonSeleccionarEstacion.Location = new System.Drawing.Point(352, 200);
                        this.BotonSeleccionarEstacion.Name = "BotonSeleccionarEstacion";
                        this.BotonSeleccionarEstacion.Size = new System.Drawing.Size(28, 24);
                        this.BotonSeleccionarEstacion.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonSeleccionarEstacion.Subtext = "";
                        this.BotonSeleccionarEstacion.TabIndex = 8;
                        this.BotonSeleccionarEstacion.Text = "...";
                        this.BotonSeleccionarEstacion.Click += new System.EventHandler(this.BotonEstacionSeleccionar_Click);
                        // 
                        // EntradaEstacion
                        // 
                        this.EntradaEstacion.ForceCase = Lui.Forms.TextCasing.UpperCase;
                        this.EntradaEstacion.Location = new System.Drawing.Point(152, 200);
                        this.EntradaEstacion.Name = "EntradaEstacion";
                        this.EntradaEstacion.Size = new System.Drawing.Size(196, 24);
                        this.EntradaEstacion.TabIndex = 7;
                        // 
                        // EntradaPuntoDeVenta
                        // 
                        this.EntradaPuntoDeVenta.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaPuntoDeVenta.Location = new System.Drawing.Point(152, 168);
                        this.EntradaPuntoDeVenta.Name = "EntradaPuntoDeVenta";
                        this.EntradaPuntoDeVenta.Size = new System.Drawing.Size(72, 24);
                        this.EntradaPuntoDeVenta.TabIndex = 5;
                        this.EntradaPuntoDeVenta.Text = "0";
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(24, 24);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(584, 32);
                        this.label4.TabIndex = 51;
                        this.label4.Text = "Este tipo de comprobante se imprimie en";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label4.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // label5
                        // 
                        this.label5.Location = new System.Drawing.Point(24, 104);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(584, 28);
                        this.label5.TabIndex = 52;
                        this.label5.Text = "Dadas las siguientes condiciones";
                        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.label5.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        // 
                        // label6
                        // 
                        this.label6.Location = new System.Drawing.Point(228, 168);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(316, 24);
                        this.label6.TabIndex = 53;
                        this.label6.Text = "(0 para todos los puntos de venta)";
                        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // AgregarTipoImpresora
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(634, 372);
                        this.Controls.Add(this.label6);
                        this.Controls.Add(this.label5);
                        this.Controls.Add(this.EntradaPuntoDeVenta);
                        this.Controls.Add(this.EntradaSucursal);
                        this.Controls.Add(this.Label3);
                        this.Controls.Add(this.BotonSeleccionarEstacion);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.EntradaEstacion);
                        this.Controls.Add(this.Label16);
                        this.Controls.Add(this.EntradaImpresora);
                        this.Controls.Add(this.label4);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "AgregarTipoImpresora";
                        this.Text = "Asociar tipo de comprobante con impresora";
                        this.Controls.SetChildIndex(this.label4, 0);
                        this.Controls.SetChildIndex(this.EntradaImpresora, 0);
                        this.Controls.SetChildIndex(this.Label16, 0);
                        this.Controls.SetChildIndex(this.EntradaEstacion, 0);
                        this.Controls.SetChildIndex(this.label1, 0);
                        this.Controls.SetChildIndex(this.label2, 0);
                        this.Controls.SetChildIndex(this.BotonSeleccionarEstacion, 0);
                        this.Controls.SetChildIndex(this.Label3, 0);
                        this.Controls.SetChildIndex(this.EntradaSucursal, 0);
                        this.Controls.SetChildIndex(this.EntradaPuntoDeVenta, 0);
                        this.Controls.SetChildIndex(this.label5, 0);
                        this.Controls.SetChildIndex(this.label6, 0);
                        this.ResumeLayout(false);

                }

                #endregion

                internal Lcc.Entrada.CodigoDetalle EntradaImpresora;
                internal Lui.Forms.Label Label16;
                internal Lcc.Entrada.CodigoDetalle EntradaSucursal;
                internal Lui.Forms.Label label1;
                internal Lui.Forms.Label Label3;
                internal Lui.Forms.Label label2;
                internal Lui.Forms.Button BotonSeleccionarEstacion;
                internal Lui.Forms.TextBox EntradaEstacion;
                internal Lui.Forms.TextBox EntradaPuntoDeVenta;
                internal Lui.Forms.Label label4;
                internal Lui.Forms.Label label5;
                internal Lui.Forms.Label label6;
        }
}
