namespace Lfc.Cajas.Vencimientos
{
        partial class Editar
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
                        this.EntradaFrecuencia = new Lui.Forms.ComboBox();
                        this.Label11 = new Lui.Forms.Label();
                        this.EntradaNombre = new Lui.Forms.TextBox();
                        this.lblLabel1 = new Lui.Forms.Label();
                        this.frame1 = new Lui.Forms.Frame();
                        this.label4 = new Lui.Forms.Label();
                        this.label1 = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.EntradaFechaInicio = new Lui.Forms.TextBox();
                        this.label3 = new Lui.Forms.Label();
                        this.EntradaFechaFin = new Lui.Forms.TextBox();
                        this.EntradaRepetir = new Lui.Forms.TextBox();
                        this.label5 = new Lui.Forms.Label();
                        this.EntradaConcepto = new Lcc.Entrada.CodigoDetalle();
                        this.frame2 = new Lui.Forms.Frame();
                        this.label6 = new Lui.Forms.Label();
                        this.EntradaImporte = new Lui.Forms.TextBox();
                        this.label7 = new Lui.Forms.Label();
                        this.EntradaEstado = new Lui.Forms.ComboBox();
                        this.EntradaObs = new Lui.Forms.TextBox();
                        this.label8 = new Lui.Forms.Label();
                        this.frame1.SuspendLayout();
                        this.frame2.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // EntradaFrecuencia
                        // 
                        this.EntradaFrecuencia.AlwaysExpanded = true;
                        this.EntradaFrecuencia.Location = new System.Drawing.Point(120, 72);
                        this.EntradaFrecuencia.Name = "EntradaFrecuencia";
                        this.EntradaFrecuencia.SetData = new string[] {
        "Única|Unica",
        "Diaria|Diaria",
        "Semanal|Semanal",
        "Mensual|Mensual",
        "Bimestral|Bimestral",
        "Trimestral|Trimestral",
        "Cuatrimestral|Cuatrimestral",
        "Semestral|Semestral",
        "Anual|Anual"};
                        this.EntradaFrecuencia.Size = new System.Drawing.Size(176, 76);
                        this.EntradaFrecuencia.TabIndex = 3;
                        this.EntradaFrecuencia.TextKey = "";
                        // 
                        // Label11
                        // 
                        this.Label11.Location = new System.Drawing.Point(8, 72);
                        this.Label11.Name = "Label11";
                        this.Label11.Size = new System.Drawing.Size(112, 24);
                        this.Label11.TabIndex = 2;
                        this.Label11.Text = "Frecuencia";
                        this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaNombre
                        // 
                        this.EntradaNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaNombre.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaNombre.Location = new System.Drawing.Point(120, 0);
                        this.EntradaNombre.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaNombre.Name = "EntradaNombre";
                        this.EntradaNombre.Size = new System.Drawing.Size(436, 24);
                        this.EntradaNombre.TabIndex = 1;
                        // 
                        // lblLabel1
                        // 
                        this.lblLabel1.Location = new System.Drawing.Point(0, 0);
                        this.lblLabel1.Name = "lblLabel1";
                        this.lblLabel1.Size = new System.Drawing.Size(120, 24);
                        this.lblLabel1.TabIndex = 0;
                        this.lblLabel1.Text = "Nombre";
                        this.lblLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // frame1
                        // 
                        this.frame1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.frame1.Controls.Add(this.label1);
                        this.frame1.Controls.Add(this.label2);
                        this.frame1.Controls.Add(this.EntradaFechaInicio);
                        this.frame1.Controls.Add(this.label4);
                        this.frame1.Controls.Add(this.EntradaFrecuencia);
                        this.frame1.Controls.Add(this.label3);
                        this.frame1.Controls.Add(this.Label11);
                        this.frame1.Controls.Add(this.EntradaFechaFin);
                        this.frame1.Controls.Add(this.EntradaRepetir);
                        this.frame1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
                        this.frame1.Location = new System.Drawing.Point(0, 280);
                        this.frame1.Name = "frame1";
                        this.frame1.Size = new System.Drawing.Size(560, 160);
                        this.frame1.TabIndex = 7;
                        this.frame1.Text = "Periodicidad";
                        // 
                        // label4
                        // 
                        this.label4.Location = new System.Drawing.Point(488, 72);
                        this.label4.Name = "label4";
                        this.label4.Size = new System.Drawing.Size(68, 24);
                        this.label4.TabIndex = 8;
                        this.label4.Text = "veces";
                        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(8, 40);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(112, 24);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "Inicio";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(320, 40);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(96, 24);
                        this.label2.TabIndex = 4;
                        this.label2.Text = "Fin";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFechaInicio
                        // 
                        this.EntradaFechaInicio.DataType = Lui.Forms.DataTypes.Date;
                        this.EntradaFechaInicio.Location = new System.Drawing.Point(120, 40);
                        this.EntradaFechaInicio.Name = "EntradaFechaInicio";
                        this.EntradaFechaInicio.Size = new System.Drawing.Size(100, 24);
                        this.EntradaFechaInicio.TabIndex = 1;
                        // 
                        // label3
                        // 
                        this.label3.Location = new System.Drawing.Point(320, 72);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(96, 24);
                        this.label3.TabIndex = 6;
                        this.label3.Text = "O repetir";
                        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaFechaFin
                        // 
                        this.EntradaFechaFin.DataType = Lui.Forms.DataTypes.Date;
                        this.EntradaFechaFin.Location = new System.Drawing.Point(416, 40);
                        this.EntradaFechaFin.Name = "EntradaFechaFin";
                        this.EntradaFechaFin.Size = new System.Drawing.Size(104, 24);
                        this.EntradaFechaFin.TabIndex = 5;
                        // 
                        // EntradaRepetir
                        // 
                        this.EntradaRepetir.DataType = Lui.Forms.DataTypes.Integer;
                        this.EntradaRepetir.Location = new System.Drawing.Point(416, 72);
                        this.EntradaRepetir.MaxLength = 3;
                        this.EntradaRepetir.Name = "EntradaRepetir";
                        this.EntradaRepetir.Size = new System.Drawing.Size(68, 24);
                        this.EntradaRepetir.TabIndex = 7;
                        this.EntradaRepetir.Text = "0";
                        // 
                        // label5
                        // 
                        this.label5.Location = new System.Drawing.Point(8, 40);
                        this.label5.Name = "label5";
                        this.label5.Size = new System.Drawing.Size(112, 24);
                        this.label5.TabIndex = 0;
                        this.label5.Text = "Concepto";
                        this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaConcepto
                        // 
                        this.EntradaConcepto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaConcepto.AutoTab = true;
                        this.EntradaConcepto.CanCreate = true;
                        this.EntradaConcepto.Filter = "";
                        this.EntradaConcepto.Location = new System.Drawing.Point(120, 40);
                        this.EntradaConcepto.MaximumSize = new System.Drawing.Size(480, 32);
                        this.EntradaConcepto.MaxLength = 200;
                        this.EntradaConcepto.Name = "EntradaConcepto";
                        this.EntradaConcepto.Required = true;
                        this.EntradaConcepto.Size = new System.Drawing.Size(432, 24);
                        this.EntradaConcepto.TabIndex = 1;
                        this.EntradaConcepto.NombreTipo = "Lbl.Cajas.Concepto";
                        this.EntradaConcepto.Text = "0";
                        // 
                        // frame2
                        // 
                        this.frame2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.frame2.Controls.Add(this.label5);
                        this.frame2.Controls.Add(this.EntradaConcepto);
                        this.frame2.Controls.Add(this.label6);
                        this.frame2.Controls.Add(this.EntradaImporte);
                        this.frame2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
                        this.frame2.Location = new System.Drawing.Point(0, 160);
                        this.frame2.Name = "frame2";
                        this.frame2.Size = new System.Drawing.Size(560, 96);
                        this.frame2.TabIndex = 6;
                        this.frame2.Text = "Pago";
                        // 
                        // label6
                        // 
                        this.label6.Location = new System.Drawing.Point(8, 72);
                        this.label6.Name = "label6";
                        this.label6.Size = new System.Drawing.Size(112, 24);
                        this.label6.TabIndex = 2;
                        this.label6.Text = "Importe";
                        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaImporte
                        // 
                        this.EntradaImporte.DataType = Lui.Forms.DataTypes.Currency;
                        this.EntradaImporte.Location = new System.Drawing.Point(120, 72);
                        this.EntradaImporte.Name = "EntradaImporte";
                        this.EntradaImporte.Size = new System.Drawing.Size(76, 24);
                        this.EntradaImporte.TabIndex = 3;
                        // 
                        // label7
                        // 
                        this.label7.Location = new System.Drawing.Point(0, 32);
                        this.label7.Name = "label7";
                        this.label7.Size = new System.Drawing.Size(120, 24);
                        this.label7.TabIndex = 2;
                        this.label7.Text = "Estado";
                        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaEstado
                        // 
                        this.EntradaEstado.AlwaysExpanded = true;
                        this.EntradaEstado.AutoSize = true;
                        this.EntradaEstado.Location = new System.Drawing.Point(120, 32);
                        this.EntradaEstado.Name = "EntradaEstado";
                        this.EntradaEstado.SetData = new string[] {
        "Inactivo|0",
        "Activo|1",
        "Terminado|100"};
                        this.EntradaEstado.Size = new System.Drawing.Size(144, 57);
                        this.EntradaEstado.TabIndex = 3;
                        this.EntradaEstado.TextKey = "1";
                        // 
                        // EntradaObs
                        // 
                        this.EntradaObs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.EntradaObs.ForceCase = Lui.Forms.TextCasing.Automatic;
                        this.EntradaObs.Location = new System.Drawing.Point(120, 96);
                        this.EntradaObs.MaximumSize = new System.Drawing.Size(480, 56);
                        this.EntradaObs.MultiLine = true;
                        this.EntradaObs.Name = "EntradaObs";
                        this.EntradaObs.Size = new System.Drawing.Size(436, 56);
                        this.EntradaObs.TabIndex = 5;
                        // 
                        // label8
                        // 
                        this.label8.Location = new System.Drawing.Point(0, 96);
                        this.label8.Name = "label8";
                        this.label8.Size = new System.Drawing.Size(120, 24);
                        this.label8.TabIndex = 4;
                        this.label8.Text = "Observaciones";
                        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Editar
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.Controls.Add(this.EntradaObs);
                        this.Controls.Add(this.EntradaEstado);
                        this.Controls.Add(this.frame2);
                        this.Controls.Add(this.frame1);
                        this.Controls.Add(this.EntradaNombre);
                        this.Controls.Add(this.lblLabel1);
                        this.Controls.Add(this.label8);
                        this.Controls.Add(this.label7);
                        this.MinimumSize = new System.Drawing.Size(560, 444);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(560, 444);
                        this.frame1.ResumeLayout(false);
                        this.frame1.PerformLayout();
                        this.frame2.ResumeLayout(false);
                        this.frame2.PerformLayout();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                internal Lui.Forms.ComboBox EntradaFrecuencia;
                internal Lui.Forms.Label Label11;
                internal Lui.Forms.TextBox EntradaNombre;
                internal Lui.Forms.Label lblLabel1;
                private Lui.Forms.Frame frame1;
                internal Lui.Forms.Label label1;
                internal Lui.Forms.TextBox EntradaFechaInicio;
                internal Lui.Forms.Label label3;
                internal Lui.Forms.TextBox EntradaRepetir;
                internal Lui.Forms.Label label2;
                internal Lui.Forms.TextBox EntradaFechaFin;
                private Lui.Forms.Label label5;
                internal Lcc.Entrada.CodigoDetalle EntradaConcepto;
                private Lui.Forms.Frame frame2;
                internal Lui.Forms.Label label6;
                internal Lui.Forms.TextBox EntradaImporte;
                internal Lui.Forms.Label label7;
                internal Lui.Forms.ComboBox EntradaEstado;
                internal Lui.Forms.TextBox EntradaObs;
                internal Lui.Forms.Label label8;
                internal Lui.Forms.Label label4;
        }
}
