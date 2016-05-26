using System;
using System.Collections.Generic;
using System.Text;

namespace Lui.Printing
{
        public partial class PrinterSelectionDialog
        {
                #region Código generado por el Diseñador de Windows Forms

                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }
                        base.Dispose(disposing);
                }


                private System.ComponentModel.IContainer components = null;

                private Lui.Forms.ListView Listado;
                private System.Windows.Forms.ColumnHeader Nombre;

                private void InitializeComponent()
                {
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrinterSelectionDialog));
                        this.Listado = new Lui.Forms.ListView();
                        this.Nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.NombreVisible = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.Label1 = new Lui.Forms.Label();
                        this.PictureBox1 = new System.Windows.Forms.PictureBox();
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // Listado
                        // 
                        this.Listado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Listado.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.Listado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nombre,
            this.NombreVisible});
                        this.Listado.FullRowSelect = true;
                        this.Listado.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
                        this.Listado.HideSelection = false;
                        this.Listado.Location = new System.Drawing.Point(160, 56);
                        this.Listado.MultiSelect = false;
                        this.Listado.Name = "Listado";
                        this.Listado.Size = new System.Drawing.Size(448, 224);
                        this.Listado.TabIndex = 0;
                        this.Listado.UseCompatibleStateImageBehavior = false;
                        this.Listado.View = System.Windows.Forms.View.Details;
                        this.Listado.DoubleClick += new System.EventHandler(this.Listado_DoubleClick);
                        this.Listado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Listado_KeyDown);
                        // 
                        // Nombre
                        // 
                        this.Nombre.Text = "Nombre";
                        this.Nombre.Width = 0;
                        // 
                        // NombreVisible
                        // 
                        this.NombreVisible.Text = "Nombre";
                        this.NombreVisible.Width = 300;
                        // 
                        // Label1
                        // 
                        this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label1.Location = new System.Drawing.Point(160, 24);
                        this.Label1.Name = "Label1";
                        this.Label1.Size = new System.Drawing.Size(448, 32);
                        this.Label1.TabIndex = 51;
                        this.Label1.Text = "Seleccione una impresora";
                        this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label1.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        // 
                        // PictureBox1
                        // 
                        this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
                        this.PictureBox1.Location = new System.Drawing.Point(24, 24);
                        this.PictureBox1.Name = "PictureBox1";
                        this.PictureBox1.Size = new System.Drawing.Size(116, 112);
                        this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        this.PictureBox1.TabIndex = 52;
                        this.PictureBox1.TabStop = false;
                        // 
                        // PrinterSelectionDialog
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(634, 371);
                        this.Controls.Add(this.PictureBox1);
                        this.Controls.Add(this.Label1);
                        this.Controls.Add(this.Listado);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "PrinterSelectionDialog";
                        this.Text = "Seleccionar impresora";
                        this.Activated += new System.EventHandler(this.FormSeleccionarImpresora_Activated);
                        this.Controls.SetChildIndex(this.Listado, 0);
                        this.Controls.SetChildIndex(this.Label1, 0);
                        this.Controls.SetChildIndex(this.PictureBox1, 0);
                        ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
                        this.ResumeLayout(false);

                }

                #endregion

                internal Forms.Label Label1;
                internal System.Windows.Forms.PictureBox PictureBox1;
        }
}
