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
                        this.PanelActualizarAlmacen = new Lui.Forms.Panel();
                        this.label5 = new Lui.Forms.Label();
                        this.BotonNoActualizarAlmacen = new Lui.Forms.LinkLabel();
                        this.label4 = new Lui.Forms.Label();
                        this.BotonActualizarAlmacen = new Lui.Forms.LinkLabel();
                        this.label3 = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.PanelConsejo = new Lfc.Inicio.Consejo();
                        this.PanelComprobantes = new Lfc.Inicio.ControlComprobantes();
                        this.PanelPersonas = new Lfc.Inicio.ControlPersonas();
                        this.PanelArticulos = new Lfc.Inicio.ControlArticulos();
                        this.PanelWeb.SuspendLayout();
                        this.PanelActualizarAlmacen.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // BotonWebInicio
                        // 
                        this.BotonWebInicio.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
                        this.BotonWebInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonWebInicio.AutoSize = true;
                        this.BotonWebInicio.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.BotonWebInicio.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
                        this.BotonWebInicio.Location = new System.Drawing.Point(990, 770);
                        this.BotonWebInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.BotonWebInicio.Name = "BotonWebInicio";
                        this.BotonWebInicio.Size = new System.Drawing.Size(189, 23);
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
                        this.BotonForoWeb.Location = new System.Drawing.Point(300, 90);
                        this.BotonForoWeb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.BotonForoWeb.Name = "BotonForoWeb";
                        this.BotonForoWeb.Size = new System.Drawing.Size(131, 23);
                        this.BotonForoWeb.TabIndex = 5;
                        this.BotonForoWeb.TabStop = true;
                        this.BotonForoWeb.Text = "Foro de soporte";
                        this.BotonForoWeb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.BotonForoWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BotonForoWeb_LinkClicked);
                        // 
                        // label1
                        // 
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(20, 15);
                        this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(212, 37);
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
                        this.BotonWebPrimerosPasos.Location = new System.Drawing.Point(60, 60);
                        this.BotonWebPrimerosPasos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.BotonWebPrimerosPasos.Name = "BotonWebPrimerosPasos";
                        this.BotonWebPrimerosPasos.Size = new System.Drawing.Size(125, 23);
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
                        this.BotonAyudaWeb.Location = new System.Drawing.Point(60, 90);
                        this.BotonAyudaWeb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.BotonAyudaWeb.Name = "BotonAyudaWeb";
                        this.BotonAyudaWeb.Size = new System.Drawing.Size(136, 23);
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
                        this.BotonWebComoFactura.Location = new System.Drawing.Point(300, 60);
                        this.BotonWebComoFactura.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.BotonWebComoFactura.Name = "BotonWebComoFactura";
                        this.BotonWebComoFactura.Size = new System.Drawing.Size(167, 23);
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
                        this.PanelWeb.Location = new System.Drawing.Point(60, 560);
                        this.PanelWeb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                        this.PanelWeb.Name = "PanelWeb";
                        this.PanelWeb.Size = new System.Drawing.Size(600, 130);
                        this.PanelWeb.TabIndex = 9;
                        // 
                        // PanelActualizarAlmacen
                        // 
                        this.PanelActualizarAlmacen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
                        this.PanelActualizarAlmacen.BackColor = System.Drawing.Color.Snow;
                        this.PanelActualizarAlmacen.Controls.Add(this.label5);
                        this.PanelActualizarAlmacen.Controls.Add(this.BotonNoActualizarAlmacen);
                        this.PanelActualizarAlmacen.Controls.Add(this.label4);
                        this.PanelActualizarAlmacen.Controls.Add(this.BotonActualizarAlmacen);
                        this.PanelActualizarAlmacen.Controls.Add(this.label3);
                        this.PanelActualizarAlmacen.Controls.Add(this.label2);
                        this.PanelActualizarAlmacen.Location = new System.Drawing.Point(60, 60);
                        this.PanelActualizarAlmacen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
                        this.PanelActualizarAlmacen.Name = "PanelActualizarAlmacen";
                        this.PanelActualizarAlmacen.Size = new System.Drawing.Size(1140, 691);
                        this.PanelActualizarAlmacen.TabIndex = 11;
                        this.PanelActualizarAlmacen.Visible = false;
                        // 
                        // label5
                        // 
                        this.label5.Location = new System.Drawing.Point(22, 230);
                        this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(1089, 34);
                        this.label5.TabIndex = 7;
                        this.label5.Text = "Si no desea actualizar el almacén de datos ahora, haga clic en el enlace:";
                        // 
                        // BotonNoActualizarAlmacen
                        // 
                        this.BotonNoActualizarAlmacen.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
                        this.BotonNoActualizarAlmacen.AutoSize = true;
                        this.BotonNoActualizarAlmacen.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.BotonNoActualizarAlmacen.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
                        this.BotonNoActualizarAlmacen.Location = new System.Drawing.Point(22, 264);
                        this.BotonNoActualizarAlmacen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.BotonNoActualizarAlmacen.Name = "BotonNoActualizarAlmacen";
                        this.BotonNoActualizarAlmacen.Size = new System.Drawing.Size(299, 23);
                        this.BotonNoActualizarAlmacen.TabIndex = 6;
                        this.BotonNoActualizarAlmacen.TabStop = true;
                        this.BotonNoActualizarAlmacen.Text = "No, gracias. Tal vez en otro momento.";
                        this.BotonNoActualizarAlmacen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.BotonNoActualizarAlmacen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BotonNoActualizarAlmacen_LinkClicked);
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(22, 145);
                        this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(1089, 34);
                        this.label4.TabIndex = 5;
                        this.label4.Text = "Para descargar la versión nueva del almacén de datos, visite la siguiente página:" +
    "";
                        // 
                        // BotonActualizarAlmacen
                        // 
                        this.BotonActualizarAlmacen.ActiveLinkColor = System.Drawing.Color.RoyalBlue;
                        this.BotonActualizarAlmacen.AutoSize = true;
                        this.BotonActualizarAlmacen.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.BotonActualizarAlmacen.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
                        this.BotonActualizarAlmacen.Location = new System.Drawing.Point(22, 179);
                        this.BotonActualizarAlmacen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.BotonActualizarAlmacen.Name = "BotonActualizarAlmacen";
                        this.BotonActualizarAlmacen.Size = new System.Drawing.Size(347, 23);
                        this.BotonActualizarAlmacen.TabIndex = 4;
                        this.BotonActualizarAlmacen.TabStop = true;
                        this.BotonActualizarAlmacen.Text = "http://lazarogestion.com/descargar/servidor";
                        this.BotonActualizarAlmacen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.BotonActualizarAlmacen.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BotonActualizarAlmacen_LinkClicked);
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(22, 81);
                        this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(1089, 55);
                        this.label3.TabIndex = 2;
                        this.label3.Text = resources.GetString("label3.Text");
                        // 
                        // label2
                        // 
                        this.label2.AutoSize = true;
                        this.label2.Location = new System.Drawing.Point(20, 26);
                        this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(349, 37);
                        this.label2.TabIndex = 1;
                        this.label2.Text = "Actualizar almacén de datos";
                        this.label2.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
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
                        this.PanelConsejo.Location = new System.Drawing.Point(680, 60);
                        this.PanelConsejo.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
                        this.PanelConsejo.Name = "PanelConsejo";
                        this.PanelConsejo.Size = new System.Drawing.Size(520, 200);
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
                        this.PanelComprobantes.Location = new System.Drawing.Point(680, 280);
                        this.PanelComprobantes.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
                        this.PanelComprobantes.MinimumSize = new System.Drawing.Size(520, 375);
                        this.PanelComprobantes.Name = "PanelComprobantes";
                        this.PanelComprobantes.Size = new System.Drawing.Size(520, 471);
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
                        this.PanelPersonas.Location = new System.Drawing.Point(60, 340);
                        this.PanelPersonas.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
                        this.PanelPersonas.Name = "PanelPersonas";
                        this.PanelPersonas.Size = new System.Drawing.Size(600, 200);
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
                        this.PanelArticulos.Location = new System.Drawing.Point(60, 60);
                        this.PanelArticulos.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
                        this.PanelArticulos.Name = "PanelArticulos";
                        this.PanelArticulos.Size = new System.Drawing.Size(600, 260);
                        this.PanelArticulos.TabIndex = 0;
                        this.PanelArticulos.Text = "Artículos";
                        // 
                        // Inicio
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.BackColor = System.Drawing.Color.White;
                        this.ClientSize = new System.Drawing.Size(1230, 802);
                        this.Controls.Add(this.PanelConsejo);
                        this.Controls.Add(this.PanelWeb);
                        this.Controls.Add(this.PanelComprobantes);
                        this.Controls.Add(this.PanelPersonas);
                        this.Controls.Add(this.PanelArticulos);
                        this.Controls.Add(this.BotonWebInicio);
                        this.Controls.Add(this.PanelActualizarAlmacen);
                        this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
                        this.Name = "Inicio";
                        this.Padding = new System.Windows.Forms.Padding(40, 40, 40, 40);
                        this.Text = "Inicio";
                        this.PanelWeb.ResumeLayout(false);
                        this.PanelWeb.PerformLayout();
                        this.PanelActualizarAlmacen.ResumeLayout(false);
                        this.PanelActualizarAlmacen.PerformLayout();
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
                private Lui.Forms.Panel PanelActualizarAlmacen;
                private Lui.Forms.Label label5;
                private Lui.Forms.LinkLabel BotonNoActualizarAlmacen;
                private Lui.Forms.Label label4;
                private Lui.Forms.LinkLabel BotonActualizarAlmacen;
                private Lui.Forms.Label label3;
                private Lui.Forms.Label label2;

        }
}
