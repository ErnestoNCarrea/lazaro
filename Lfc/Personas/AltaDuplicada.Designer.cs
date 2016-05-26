using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lfc.Personas
{
        public partial class AltaDuplicada
        {
                private Lui.Forms.Label label1;
                private Lui.Forms.Label label2;
                public Lui.Forms.ListView ListaComparacion;
                private System.Windows.Forms.ColumnHeader NombreColumna;
                private System.Windows.Forms.ColumnHeader ColumnaActual;
                private System.Windows.Forms.ColumnHeader ColumnaNueva;
                private Lui.Forms.Label label3;
                private Lui.Forms.Button BotonContinuar;
                private Lui.Forms.Button BotonCorregir;
                private Lui.Forms.Button BotonCancelar;
                private Timer TimerHabilitarBotones;
                private System.ComponentModel.IContainer components = null;

                /// <summary>
                /// Limpiar los recursos que se estén utilizando.
                /// </summary>
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
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
                        this.components = new System.ComponentModel.Container();
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltaDuplicada));
                        this.label1 = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.ListaComparacion = new Lui.Forms.ListView();
                        this.NombreColumna = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColumnaActual = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColumnaNueva = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.label3 = new Lui.Forms.Label();
                        this.BotonCancelar = new Lui.Forms.Button();
                        this.BotonContinuar = new Lui.Forms.Button();
                        this.BotonCorregir = new Lui.Forms.Button();
                        this.TimerHabilitarBotones = new System.Windows.Forms.Timer(this.components);
                        this.SuspendLayout();
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(24, 24);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(544, 36);
                        this.label1.TabIndex = 3;
                        this.label1.Text = "Posible duplicación de datos";
                        this.label1.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(24, 60);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(544, 40);
                        this.label2.TabIndex = 4;
                        this.label2.Text = "Es posible que el cliente que intenta agregar ya haya sigo agregado con anteriori" +
    "dad. Puede revisar las similitudes para decidir si se trata de la misma persona:" +
    "";
                        // 
                        // ListaComparacion
                        // 
                        this.ListaComparacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.ListaComparacion.BackColor = System.Drawing.SystemColors.Window;
                        this.ListaComparacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.ListaComparacion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NombreColumna,
            this.ColumnaActual,
            this.ColumnaNueva});
                        this.ListaComparacion.FieldName = null;
                        this.ListaComparacion.FullRowSelect = true;
                        this.ListaComparacion.GridLines = true;
                        this.ListaComparacion.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.ListaComparacion.LabelWrap = false;
                        this.ListaComparacion.Location = new System.Drawing.Point(24, 100);
                        this.ListaComparacion.Name = "ListaComparacion";
                        this.ListaComparacion.ReadOnly = false;
                        this.ListaComparacion.Size = new System.Drawing.Size(544, 112);
                        this.ListaComparacion.TabIndex = 5;
                        this.ListaComparacion.TabStop = false;
                        this.ListaComparacion.UseCompatibleStateImageBehavior = false;
                        this.ListaComparacion.View = System.Windows.Forms.View.Details;
                        // 
                        // NombreColumna
                        // 
                        this.NombreColumna.Text = "";
                        this.NombreColumna.Width = 100;
                        // 
                        // ColumnaActual
                        // 
                        this.ColumnaActual.Text = "Cliente anterior";
                        this.ColumnaActual.Width = 220;
                        // 
                        // ColumnaNueva
                        // 
                        this.ColumnaNueva.Text = "Cliente nuevo";
                        this.ColumnaNueva.Width = 220;
                        // 
                        // label3
                        // 
                        this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.label3.Location = new System.Drawing.Point(24, 220);
                        this.label3.Name = "label3";
                        this.label3.Size = new System.Drawing.Size(544, 32);
                        this.label3.TabIndex = 6;
                        this.label3.Text = "¿Qué desea hacer con los datos cargados?";
                        this.label3.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        // 
                        // BotonCancelar
                        // 
                        this.BotonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.BotonCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.BotonCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BotonCancelar.Image")));
                        this.BotonCancelar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonCancelar.Location = new System.Drawing.Point(24, 260);
                        this.BotonCancelar.Name = "BotonCancelar";
                        this.BotonCancelar.Size = new System.Drawing.Size(544, 68);
                        this.BotonCancelar.SubLabelPos = Lui.Forms.SubLabelPositions.LongBottom;
                        this.BotonCancelar.Subtext = "No agrega ni actualiza ningún dato. Sólo vuelve al formulario de alta para revisa" +
    "r los datos ingresados.";
                        this.BotonCancelar.TabIndex = 0;
                        this.BotonCancelar.Text = "Volver al formulario de alta";
                        this.BotonCancelar.Click += new System.EventHandler(this.CmdCancelar_Click);
                        // 
                        // BotonContinuar
                        // 
                        this.BotonContinuar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonContinuar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonContinuar.Enabled = false;
                        this.BotonContinuar.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.BotonContinuar.Image = ((System.Drawing.Image)(resources.GetObject("BotonContinuar.Image")));
                        this.BotonContinuar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonContinuar.Location = new System.Drawing.Point(24, 336);
                        this.BotonContinuar.Name = "BotonContinuar";
                        this.BotonContinuar.Size = new System.Drawing.Size(544, 68);
                        this.BotonContinuar.SubLabelPos = Lui.Forms.SubLabelPositions.LongBottom;
                        this.BotonContinuar.Subtext = "Seleccione esta opción si se trata de clientes diferentes o si intenta deliberada" +
    "mente cargar un dato duplicado.";
                        this.BotonContinuar.TabIndex = 1;
                        this.BotonContinuar.Text = "Crear un cliente nuevo";
                        this.BotonContinuar.Click += new System.EventHandler(this.CmdCrearNuevo_Click);
                        // 
                        // BotonCorregir
                        // 
                        this.BotonCorregir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                        this.BotonCorregir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.BotonCorregir.Enabled = false;
                        this.BotonCorregir.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.BotonCorregir.Image = ((System.Drawing.Image)(resources.GetObject("BotonCorregir.Image")));
                        this.BotonCorregir.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonCorregir.Location = new System.Drawing.Point(24, 412);
                        this.BotonCorregir.Name = "BotonCorregir";
                        this.BotonCorregir.Size = new System.Drawing.Size(544, 68);
                        this.BotonCorregir.SubLabelPos = Lui.Forms.SubLabelPositions.LongBottom;
                        this.BotonCorregir.Subtext = "Seleccione esta opción si verificó que se trata del mismo cliente y no desea crea" +
    "r datos duplicados.";
                        this.BotonCorregir.TabIndex = 2;
                        this.BotonCorregir.Text = "Actualizar los datos del cliente actual";
                        this.BotonCorregir.Click += new System.EventHandler(this.CmdActualizar_Click);
                        // 
                        // TimerHabilitarBotones
                        // 
                        this.TimerHabilitarBotones.Enabled = true;
                        this.TimerHabilitarBotones.Interval = 2000;
                        this.TimerHabilitarBotones.Tick += new System.EventHandler(this.TimerHabilitarBotones_Tick);
                        // 
                        // AltaDuplicada
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.CancelButton = this.BotonCancelar;
                        this.ClientSize = new System.Drawing.Size(592, 493);
                        this.Controls.Add(this.BotonCancelar);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.BotonContinuar);
                        this.Controls.Add(this.BotonCorregir);
                        this.Controls.Add(this.ListaComparacion);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.label2);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                        this.Name = "AltaDuplicada";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        this.Text = "Posible duplicación de datos";
                        this.ResumeLayout(false);

                }
                #endregion
        }
}
