using System;
using System.Collections.Generic;
using System.Text;

namespace Lui.Forms
{
        public partial class WorkstationSelectorForm
        {
                private System.ComponentModel.IContainer components = null;

                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null) {
                                        components.Dispose();
                                }
                        }
                        base.Dispose(disposing);
                }

                #region Designer generated code

                private void InitializeComponent()
                {
                        this.Listado = new Lui.Forms.ListView();
                        this.NombreEstacion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.Nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.SuspendLayout();
                        // 
                        // Listado
                        // 
                        this.Listado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Listado.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.Listado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NombreEstacion,
            this.Nombre});
                        this.Listado.FullRowSelect = true;
                        this.Listado.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
                        this.Listado.HideSelection = false;
                        this.Listado.LabelWrap = false;
                        this.Listado.Location = new System.Drawing.Point(24, 24);
                        this.Listado.MultiSelect = false;
                        this.Listado.Name = "Listado";
                        this.Listado.Size = new System.Drawing.Size(584, 272);
                        this.Listado.TabIndex = 0;
                        this.Listado.UseCompatibleStateImageBehavior = false;
                        this.Listado.View = System.Windows.Forms.View.Details;
                        // 
                        // NombreEstacion
                        // 
                        this.NombreEstacion.Text = "Equipo";
                        this.NombreEstacion.Width = 0;
                        // 
                        // Nombre
                        // 
                        this.Nombre.Text = "Equipo";
                        this.Nombre.Width = 320;
                        // 
                        // WorkstationSelectorForm
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.ClientSize = new System.Drawing.Size(634, 371);
                        this.Controls.Add(this.Listado);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.Name = "WorkstationSelectorForm";
                        this.Text = "Seleccionar equipo";
                        this.Controls.SetChildIndex(this.Listado, 0);
                        this.ResumeLayout(false);

                }
                #endregion
        }
}