using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lazaro.WinMain.Backup
{
        public partial class Manager
        {
                #region Código generado por el Diseñador de Windows Forms

                // Limpiar los recursos que se estén utilizando.
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

                private void InitializeComponent()
                {
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager));
                        this.BotonBackup = new Lui.Forms.Button();
                        this.Listado = new Lui.Forms.ListView();
                        this.Carpeta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.Numero = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.FechaYHora = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.Usuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.Label2 = new Lui.Forms.Label();
                        this.BotonEliminar = new Lui.Forms.Button();
                        this.BotonRestaurar = new Lui.Forms.Button();
                        this.BotonCopiar = new Lui.Forms.Button();
                        this.formHeader1 = new Lui.Forms.FormHeader();
                        this.SuspendLayout();
                        // 
                        // BotonBackup
                        // 
                        this.BotonBackup.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonBackup.Image = ((System.Drawing.Image)(resources.GetObject("BotonBackup.Image")));
                        this.BotonBackup.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonBackup.Location = new System.Drawing.Point(24, 88);
                        this.BotonBackup.Name = "BotonBackup";
                        this.BotonBackup.Size = new System.Drawing.Size(432, 72);
                        this.BotonBackup.SubLabelPos = Lui.Forms.SubLabelPositions.LongBottom;
                        this.BotonBackup.Subtext = "Haga clic aquí para crear una copia de seguridad en este equipo.";
                        this.BotonBackup.TabIndex = 0;
                        this.BotonBackup.Text = "Crear una copia de seguridad ahora";
                        this.BotonBackup.Click += new System.EventHandler(this.BotonBackup_Click);
                        // 
                        // Listado
                        // 
                        this.Listado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Listado.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.Listado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Carpeta,
            this.Numero,
            this.FechaYHora,
            this.Usuario});
                        this.Listado.FieldName = null;
                        this.Listado.FullRowSelect = true;
                        this.Listado.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.Listado.HideSelection = false;
                        this.Listado.Location = new System.Drawing.Point(28, 208);
                        this.Listado.Name = "Listado";
                        this.Listado.ReadOnly = false;
                        this.Listado.Size = new System.Drawing.Size(620, 160);
                        this.Listado.TabIndex = 3;
                        this.Listado.UseCompatibleStateImageBehavior = false;
                        this.Listado.View = System.Windows.Forms.View.Details;
                        // 
                        // Carpeta
                        // 
                        this.Carpeta.Text = "Carpeta";
                        this.Carpeta.Width = 0;
                        // 
                        // Numero
                        // 
                        this.Numero.Text = "#";
                        this.Numero.Width = 30;
                        // 
                        // FechaYHora
                        // 
                        this.FechaYHora.Text = "Fecha y Hora";
                        this.FechaYHora.Width = 204;
                        // 
                        // Usuario
                        // 
                        this.Usuario.Text = "Usuario";
                        this.Usuario.Width = 171;
                        // 
                        // Label2
                        // 
                        this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Label2.Location = new System.Drawing.Point(28, 168);
                        this.Label2.Name = "Label2";
                        this.Label2.Size = new System.Drawing.Size(620, 40);
                        this.Label2.TabIndex = 2;
                        this.Label2.Text = "Copias de seguridad presentes en este equipo";
                        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        this.Label2.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.GroupHeader;
                        // 
                        // BotonEliminar
                        // 
                        this.BotonEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonEliminar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonEliminar.Image = null;
                        this.BotonEliminar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonEliminar.Location = new System.Drawing.Point(664, 232);
                        this.BotonEliminar.Name = "BotonEliminar";
                        this.BotonEliminar.Size = new System.Drawing.Size(108, 40);
                        this.BotonEliminar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonEliminar.Subtext = "F3";
                        this.BotonEliminar.TabIndex = 4;
                        this.BotonEliminar.Text = "Eliminar";
                        this.BotonEliminar.Click += new System.EventHandler(this.BotonEliminar_Click);
                        // 
                        // BotonRestaurar
                        // 
                        this.BotonRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonRestaurar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonRestaurar.Image = null;
                        this.BotonRestaurar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonRestaurar.Location = new System.Drawing.Point(664, 280);
                        this.BotonRestaurar.Name = "BotonRestaurar";
                        this.BotonRestaurar.Size = new System.Drawing.Size(108, 40);
                        this.BotonRestaurar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonRestaurar.Subtext = "F6";
                        this.BotonRestaurar.TabIndex = 5;
                        this.BotonRestaurar.Text = "Restaurar";
                        this.BotonRestaurar.Click += new System.EventHandler(this.BotonRestaurar_Click);
                        // 
                        // BotonCopiar
                        // 
                        this.BotonCopiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonCopiar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonCopiar.Image = null;
                        this.BotonCopiar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonCopiar.Location = new System.Drawing.Point(664, 328);
                        this.BotonCopiar.Name = "BotonCopiar";
                        this.BotonCopiar.Size = new System.Drawing.Size(108, 40);
                        this.BotonCopiar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonCopiar.Subtext = "F6";
                        this.BotonCopiar.TabIndex = 6;
                        this.BotonCopiar.Text = "Examinar";
                        this.BotonCopiar.Click += new System.EventHandler(this.BotonCopiar_Click);
                        // 
                        // formHeader1
                        // 
                        this.formHeader1.Dock = System.Windows.Forms.DockStyle.Top;
                        this.formHeader1.Location = new System.Drawing.Point(0, 0);
                        this.formHeader1.Name = "formHeader1";
                        this.formHeader1.Size = new System.Drawing.Size(794, 64);
                        this.formHeader1.TabIndex = 101;
                        this.formHeader1.Text = "Copias de seguridad";
                        // 
                        // Manager
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(794, 452);
                        this.Controls.Add(this.formHeader1);
                        this.Controls.Add(this.BotonCopiar);
                        this.Controls.Add(this.Label2);
                        this.Controls.Add(this.BotonRestaurar);
                        this.Controls.Add(this.BotonEliminar);
                        this.Controls.Add(this.Listado);
                        this.Controls.Add(this.BotonBackup);
                        this.Name = "Manager";
                        this.Text = "Administrador de copias de seguridad";
                        this.Controls.SetChildIndex(this.BotonBackup, 0);
                        this.Controls.SetChildIndex(this.Listado, 0);
                        this.Controls.SetChildIndex(this.BotonEliminar, 0);
                        this.Controls.SetChildIndex(this.BotonRestaurar, 0);
                        this.Controls.SetChildIndex(this.Label2, 0);
                        this.Controls.SetChildIndex(this.BotonCopiar, 0);
                        this.Controls.SetChildIndex(this.formHeader1, 0);
                        this.ResumeLayout(false);

                }

                #endregion

                internal Lui.Forms.Button BotonBackup;
                internal Lui.Forms.Label Label2;
                internal Lui.Forms.ListView Listado;
                internal System.Windows.Forms.ColumnHeader FechaYHora;
                internal System.Windows.Forms.ColumnHeader Usuario;
                internal System.Windows.Forms.ColumnHeader Carpeta;
                internal Lui.Forms.Button BotonEliminar;
                internal Lui.Forms.Button BotonRestaurar;
                internal System.Windows.Forms.ColumnHeader Numero;
                internal Lui.Forms.Button BotonCopiar;
                private Lui.Forms.FormHeader formHeader1;
        }
}
