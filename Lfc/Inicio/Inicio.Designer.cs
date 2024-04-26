namespace Lfc.Inicio
{
        partial class Inicio
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
                        this.BotonWebInicio = new Lui.Forms.LinkLabel();
                        this.BotonForoWeb = new Lui.Forms.LinkLabel();
                        this.label1 = new Lui.Forms.Label();
                        this.BotonWebPrimerosPasos = new Lui.Forms.LinkLabel();
                        this.BotonAyudaWeb = new Lui.Forms.LinkLabel();
                        this.BotonWebComoFactura = new Lui.Forms.LinkLabel();
                        this.PanelWeb = new Lui.Forms.Panel();
                        this.PanelConsejo = new Lfc.Inicio.Consejo();
                        this.PanelComprobantes = new Lfc.Inicio.ControlComprobantes();
                        this.PanelPersonas = new Lfc.Inicio.ControlPersonas();
                        this.PanelArticulos = new Lfc.Inicio.ControlArticulos();
                        this.PanelWeb.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // BotonWebInicio
                        // 
                        this.BotonWebInicio.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
                        this.BotonWebInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonWebInicio.AutoSize = true;
                        this.BotonWebInicio.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.BotonWebInicio.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
                        this.BotonWebInicio.Location = new System.Drawing.Point(792, 616);
                        this.BotonWebInicio.Name = "BotonWebInicio";
                        this.BotonWebInicio.Size = new System.Drawing.Size(145, 17);
                        this.BotonWebInicio.TabIndex = 3;
                        this.BotonWebInicio.TabStop = true;
                        this.BotonWebInicio.Text = "www.lazarogestion.com";
                        this.BotonWebInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.BotonWebInicio.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BotonWebInicio_LinkClicked);
                        // 
                        // BotonForoWeb
                        // 
                        this.BotonForoWeb.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
                        this.BotonForoWeb.AutoSize = true;
                        this.BotonForoWeb.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.BotonForoWeb.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
                        this.BotonForoWeb.Location = new System.Drawing.Point(240, 72);
                        this.BotonForoWeb.Name = "BotonForoWeb";
                        this.BotonForoWeb.Size = new System.Drawing.Size(104, 17);
                        this.BotonForoWeb.TabIndex = 5;
                        this.BotonForoWeb.TabStop = true;
                        this.BotonForoWeb.Text = "Foro de soporte";
                        this.BotonForoWeb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.BotonForoWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BotonForoWeb_LinkClicked);
                        // 
                        // label1
                        // 
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(16, 12);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(173, 30);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "Ayuda en la web";
                        this.label1.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // BotonWebPrimerosPasos
                        // 
                        this.BotonWebPrimerosPasos.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
                        this.BotonWebPrimerosPasos.AutoSize = true;
                        this.BotonWebPrimerosPasos.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.BotonWebPrimerosPasos.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
                        this.BotonWebPrimerosPasos.Location = new System.Drawing.Point(48, 48);
                        this.BotonWebPrimerosPasos.Name = "BotonWebPrimerosPasos";
                        this.BotonWebPrimerosPasos.Size = new System.Drawing.Size(99, 17);
                        this.BotonWebPrimerosPasos.TabIndex = 6;
                        this.BotonWebPrimerosPasos.TabStop = true;
                        this.BotonWebPrimerosPasos.Text = "Primeros pasos";
                        this.BotonWebPrimerosPasos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.BotonWebPrimerosPasos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BotonWebPrimerosPasos_LinkClicked);
                        // 
                        // BotonAyudaWeb
                        // 
                        this.BotonAyudaWeb.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
                        this.BotonAyudaWeb.AutoSize = true;
                        this.BotonAyudaWeb.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.BotonAyudaWeb.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
                        this.BotonAyudaWeb.Location = new System.Drawing.Point(48, 72);
                        this.BotonAyudaWeb.Name = "BotonAyudaWeb";
                        this.BotonAyudaWeb.Size = new System.Drawing.Size(104, 17);
                        this.BotonAyudaWeb.TabIndex = 7;
                        this.BotonAyudaWeb.TabStop = true;
                        this.BotonAyudaWeb.Text = "Ayuda en la web";
                        this.BotonAyudaWeb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.BotonAyudaWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BotonWebAyudaWeb_LinkClicked);
                        // 
                        // BotonWebComoFactura
                        // 
                        this.BotonWebComoFactura.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
                        this.BotonWebComoFactura.AutoSize = true;
                        this.BotonWebComoFactura.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.BotonWebComoFactura.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
                        this.BotonWebComoFactura.Location = new System.Drawing.Point(240, 48);
                        this.BotonWebComoFactura.Name = "BotonWebComoFactura";
                        this.BotonWebComoFactura.Size = new System.Drawing.Size(126, 17);
                        this.BotonWebComoFactura.TabIndex = 8;
                        this.BotonWebComoFactura.TabStop = true;
                        this.BotonWebComoFactura.Text = "Imprimir una factura";
                        this.BotonWebComoFactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.BotonWebComoFactura.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BotonWebComoFactura_LinkClicked);
                        // 
                        // PanelWeb
                        // 
                        this.PanelWeb.Anchor = System.Windows.Forms.AnchorStyles.Top;
                        this.PanelWeb.BackColor = System.Drawing.Color.White;
                        this.PanelWeb.Controls.Add(this.label1);
                        this.PanelWeb.Controls.Add(this.BotonWebComoFactura);
                        this.PanelWeb.Controls.Add(this.BotonForoWeb);
                        this.PanelWeb.Controls.Add(this.BotonAyudaWeb);
                        this.PanelWeb.Controls.Add(this.BotonWebPrimerosPasos);
                        this.PanelWeb.Location = new System.Drawing.Point(48, 448);
                        this.PanelWeb.Name = "PanelWeb";
                        this.PanelWeb.Size = new System.Drawing.Size(480, 104);
                        this.PanelWeb.TabIndex = 9;
                        // 
                        // PanelConsejo
                        // 
                        this.PanelConsejo.Anchor = System.Windows.Forms.AnchorStyles.Top;
                        this.PanelConsejo.BackColor = System.Drawing.Color.DarkOrchid;
                        this.PanelConsejo.Descripcion = "...puede hacer cuentas al escribir números en Lázaro? Al ingresar datos en cualqu" +
    "ier campo numérico puede hacer cálculos como 2+2 o 7*5 y Lázaro calculará automá" +
    "ticamente el resultado.";
                        this.PanelConsejo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.PanelConsejo.Image = ((System.Drawing.Image)(resources.GetObject("PanelConsejo.Image")));
                        this.PanelConsejo.Location = new System.Drawing.Point(544, 48);
                        this.PanelConsejo.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
                        this.PanelConsejo.Name = "PanelConsejo";
                        this.PanelConsejo.Size = new System.Drawing.Size(416, 160);
                        this.PanelConsejo.TabIndex = 10;
                        this.PanelConsejo.Text = "Consejo del día";
                        this.PanelConsejo.DoubleClick += new System.EventHandler(this.PanelConsejo_DoubleClick);
                        // 
                        // PanelComprobantes
                        // 
                        this.PanelComprobantes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
                        this.PanelComprobantes.BackColor = System.Drawing.Color.OrangeRed;
                        this.PanelComprobantes.Descripcion = "Administre diferentes tipos de comprobantes, como ser facturas y tickets, recibos" +
    ", remitos y presupuestos.";
                        this.PanelComprobantes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.PanelComprobantes.ForeColor = System.Drawing.Color.White;
                        this.PanelComprobantes.Image = ((System.Drawing.Image)(resources.GetObject("PanelComprobantes.Image")));
                        this.PanelComprobantes.Location = new System.Drawing.Point(544, 224);
                        this.PanelComprobantes.Margin = new System.Windows.Forms.Padding(5);
                        this.PanelComprobantes.MinimumSize = new System.Drawing.Size(416, 300);
                        this.PanelComprobantes.Name = "PanelComprobantes";
                        this.PanelComprobantes.Size = new System.Drawing.Size(416, 377);
                        this.PanelComprobantes.TabIndex = 2;
                        this.PanelComprobantes.Text = "Comprobantes";
                        // 
                        // PanelPersonas
                        // 
                        this.PanelPersonas.Anchor = System.Windows.Forms.AnchorStyles.Top;
                        this.PanelPersonas.BackColor = System.Drawing.Color.SeaGreen;
                        this.PanelPersonas.Descripcion = "Administre los clientes, proveedores y usuarios del sistema. Puede dar de alta nu" +
    "evos clientes o proveedores si lo necesita.";
                        this.PanelPersonas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.PanelPersonas.ForeColor = System.Drawing.Color.White;
                        this.PanelPersonas.Image = ((System.Drawing.Image)(resources.GetObject("PanelPersonas.Image")));
                        this.PanelPersonas.Location = new System.Drawing.Point(48, 272);
                        this.PanelPersonas.Margin = new System.Windows.Forms.Padding(5);
                        this.PanelPersonas.Name = "PanelPersonas";
                        this.PanelPersonas.Size = new System.Drawing.Size(480, 160);
                        this.PanelPersonas.TabIndex = 1;
                        this.PanelPersonas.Text = "Personas";
                        // 
                        // PanelArticulos
                        // 
                        this.PanelArticulos.Anchor = System.Windows.Forms.AnchorStyles.Top;
                        this.PanelArticulos.BackColor = System.Drawing.Color.SteelBlue;
                        this.PanelArticulos.Descripcion = "Administre los productos o servicios que vende en su empresa.";
                        this.PanelArticulos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.PanelArticulos.ForeColor = System.Drawing.Color.White;
                        this.PanelArticulos.Image = ((System.Drawing.Image)(resources.GetObject("PanelArticulos.Image")));
                        this.PanelArticulos.Location = new System.Drawing.Point(48, 48);
                        this.PanelArticulos.Margin = new System.Windows.Forms.Padding(5);
                        this.PanelArticulos.Name = "PanelArticulos";
                        this.PanelArticulos.Size = new System.Drawing.Size(480, 208);
                        this.PanelArticulos.TabIndex = 0;
                        this.PanelArticulos.Text = "Artículos";
                        // 
                        // Inicio
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.BackColor = System.Drawing.Color.White;
                        this.ClientSize = new System.Drawing.Size(984, 586);
                        this.Controls.Add(this.PanelConsejo);
                        this.Controls.Add(this.PanelWeb);
                        this.Controls.Add(this.PanelComprobantes);
                        this.Controls.Add(this.PanelPersonas);
                        this.Controls.Add(this.PanelArticulos);
                        this.Controls.Add(this.BotonWebInicio);
                        this.Margin = new System.Windows.Forms.Padding(5);
                        this.Name = "Inicio";
                        this.Padding = new System.Windows.Forms.Padding(32);
                        this.Text = "Inicio";
                        this.PanelWeb.ResumeLayout(false);
                        this.PanelWeb.PerformLayout();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private ControlArticulos PanelArticulos;
                private ControlPersonas PanelPersonas;
                private ControlComprobantes PanelComprobantes;
                private Lui.Forms.LinkLabel BotonWebInicio;
                private Lui.Forms.LinkLabel BotonForoWeb;
                private Lui.Forms.Label label1;
                private Lui.Forms.LinkLabel BotonWebPrimerosPasos;
                private Lui.Forms.LinkLabel BotonAyudaWeb;
                private Lui.Forms.LinkLabel BotonWebComoFactura;
                private Lui.Forms.Panel PanelWeb;
                private Consejo PanelConsejo;

        }
}
