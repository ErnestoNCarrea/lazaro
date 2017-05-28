namespace Lfc.Inicio
{
        partial class ControlPersonas
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

                #region Código generado por el Diseñador de componentes

                /// <summary> 
                /// Método necesario para admitir el Diseñador. No se puede modificar 
                /// el contenido del método con el editor de código.
                /// </summary>
                private void InitializeComponent()
                {
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPersonas));
                        this.PanelBotones = new System.Windows.Forms.FlowLayoutPanel();
                        this.BotonListado = new Lfc.Inicio.Boton();
                        this.BotonCrearCliente = new Lfc.Inicio.Boton();
                        this.BotonCrearProveedor = new Lfc.Inicio.Boton();
                        this.PanelBotones.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // PanelBotones
                        // 
                        this.PanelBotones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.PanelBotones.BackColor = System.Drawing.Color.MediumSeaGreen;
                        this.PanelBotones.Controls.Add(this.BotonListado);
                        this.PanelBotones.Controls.Add(this.BotonCrearCliente);
                        this.PanelBotones.Controls.Add(this.BotonCrearProveedor);
                        this.PanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
                        this.PanelBotones.Location = new System.Drawing.Point(0, 120);
                        this.PanelBotones.Margin = new System.Windows.Forms.Padding(4);
                        this.PanelBotones.Name = "PanelBotones";
                        this.PanelBotones.Size = new System.Drawing.Size(640, 60);
                        this.PanelBotones.TabIndex = 2;
                        // 
                        // BotonListado
                        // 
                        this.BotonListado.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.BotonListado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.BotonListado.Image = ((System.Drawing.Image)(resources.GetObject("BotonListado.Image")));
                        this.BotonListado.Location = new System.Drawing.Point(481, 5);
                        this.BotonListado.Margin = new System.Windows.Forms.Padding(5);
                        this.BotonListado.Name = "BotonListado";
                        this.BotonListado.Size = new System.Drawing.Size(154, 51);
                        this.BotonListado.TabIndex = 0;
                        this.BotonListado.Text = "Listado";
                        this.BotonListado.Click += new System.EventHandler(this.BotonListado_Click);
                        // 
                        // BotonCrearCliente
                        // 
                        this.BotonCrearCliente.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.BotonCrearCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.BotonCrearCliente.Image = ((System.Drawing.Image)(resources.GetObject("BotonCrearCliente.Image")));
                        this.BotonCrearCliente.Location = new System.Drawing.Point(262, 5);
                        this.BotonCrearCliente.Margin = new System.Windows.Forms.Padding(5);
                        this.BotonCrearCliente.Name = "BotonCrearCliente";
                        this.BotonCrearCliente.Size = new System.Drawing.Size(209, 51);
                        this.BotonCrearCliente.TabIndex = 1;
                        this.BotonCrearCliente.Text = "Nuevo cliente";
                        this.BotonCrearCliente.Click += new System.EventHandler(this.BotonCrearCliente_Click);
                        // 
                        // BotonCrearProveedor
                        // 
                        this.BotonCrearProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.BotonCrearProveedor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.BotonCrearProveedor.Image = ((System.Drawing.Image)(resources.GetObject("BotonCrearProveedor.Image")));
                        this.BotonCrearProveedor.Location = new System.Drawing.Point(14, 5);
                        this.BotonCrearProveedor.Margin = new System.Windows.Forms.Padding(5);
                        this.BotonCrearProveedor.Name = "BotonCrearProveedor";
                        this.BotonCrearProveedor.Size = new System.Drawing.Size(238, 51);
                        this.BotonCrearProveedor.TabIndex = 2;
                        this.BotonCrearProveedor.Text = "Nuevo proveedor";
                        this.BotonCrearProveedor.Click += new System.EventHandler(this.BotonCrearProveedor_Click);
                        // 
                        // ControlPersonas
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                        this.BackColor = System.Drawing.Color.SeaGreen;
                        this.Controls.Add(this.PanelBotones);
                        this.Descripcion = "Administre los clientes, proveedores y usuarios del sistema. Puede dar de alta nu" +
    "evos clientes o proveedores si lo necesita.";
                        this.ForeColor = System.Drawing.Color.White;
                        this.Image = ((System.Drawing.Image)(resources.GetObject("$this.Image")));
                        this.Margin = new System.Windows.Forms.Padding(5);
                        this.Name = "ControlPersonas";
                        this.Size = new System.Drawing.Size(640, 300);
                        this.Controls.SetChildIndex(this.PanelBotones, 0);
                        this.PanelBotones.ResumeLayout(false);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.FlowLayoutPanel PanelBotones;
                private Boton BotonListado;
                private Boton BotonCrearCliente;
                private Boton BotonCrearProveedor;
        }
}
