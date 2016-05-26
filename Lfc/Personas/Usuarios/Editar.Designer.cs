using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc.Personas.Usuarios
{
        public partial class Editar
        {
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
                        this.EntradaAcceso = new Lui.Forms.ComboBox();
                        this.Label6 = new Lui.Forms.Label();
                        this.EntradaContrasena = new Lui.Forms.TextBox();
                        this.label1 = new Lui.Forms.Label();
                        this.Listado = new Lui.Forms.ListView();
                        this.ColCod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColNivel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColItems = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.BotonAgregar = new Lui.Forms.Button();
                        this.BotonQuitar = new Lui.Forms.Button();
                        this.EntradaNombreUsuario = new Lui.Forms.TextBox();
                        this.label2 = new Lui.Forms.Label();
                        this.SuspendLayout();
                        // 
                        // EntradaAcceso
                        // 
                        this.EntradaAcceso.AlwaysExpanded = true;
                        this.EntradaAcceso.AutoSize = true;
                        this.EntradaAcceso.Location = new System.Drawing.Point(128, 0);
                        this.EntradaAcceso.Name = "EntradaAcceso";
                        this.EntradaAcceso.SetData = new string[] {
        "Sí|1",
        "No|0"};
                        this.EntradaAcceso.Size = new System.Drawing.Size(72, 40);
                        this.EntradaAcceso.TabIndex = 1;
                        this.EntradaAcceso.TextKey = "1";
                        // 
                        // Label6
                        // 
                        this.Label6.Location = new System.Drawing.Point(0, 0);
                        this.Label6.Name = "Label6";
                        this.Label6.Size = new System.Drawing.Size(128, 24);
                        this.Label6.TabIndex = 0;
                        this.Label6.Text = "Permitir Acceso";
                        this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // EntradaContrasena
                        // 
                        this.EntradaContrasena.Location = new System.Drawing.Point(500, 0);
                        this.EntradaContrasena.Name = "EntradaContrasena";
                        this.EntradaContrasena.PasswordChar = '*';
                        this.EntradaContrasena.Size = new System.Drawing.Size(132, 24);
                        this.EntradaContrasena.TabIndex = 5;
                        // 
                        // label1
                        // 
                        this.label1.Location = new System.Drawing.Point(412, 0);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(88, 24);
                        this.label1.TabIndex = 4;
                        this.label1.Text = "Contraseña";
                        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Listado
                        // 
                        this.Listado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Listado.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.Listado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColCod,
            this.ColNivel,
            this.ColItems});
                        this.Listado.FieldName = null;
                        this.Listado.FullRowSelect = true;
                        this.Listado.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.Listado.LabelWrap = false;
                        this.Listado.Location = new System.Drawing.Point(0, 44);
                        this.Listado.MultiSelect = false;
                        this.Listado.Name = "Listado";
                        this.Listado.ReadOnly = false;
                        this.Listado.Size = new System.Drawing.Size(636, 316);
                        this.Listado.Sorting = System.Windows.Forms.SortOrder.Ascending;
                        this.Listado.TabIndex = 6;
                        this.Listado.UseCompatibleStateImageBehavior = false;
                        this.Listado.View = System.Windows.Forms.View.Details;
                        this.Listado.DoubleClick += new System.EventHandler(this.Listado_DoubleClick);
                        // 
                        // ColCod
                        // 
                        this.ColCod.Text = "Elemento";
                        this.ColCod.Width = 313;
                        // 
                        // ColNivel
                        // 
                        this.ColNivel.Text = "Operaciones";
                        this.ColNivel.Width = 352;
                        // 
                        // ColItems
                        // 
                        this.ColItems.Text = "Elementos";
                        this.ColItems.Width = 320;
                        // 
                        // BotonAgregar
                        // 
                        this.BotonAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonAgregar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonAgregar.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.BotonAgregar.Image = null;
                        this.BotonAgregar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonAgregar.Location = new System.Drawing.Point(532, 368);
                        this.BotonAgregar.Name = "BotonAgregar";
                        this.BotonAgregar.Size = new System.Drawing.Size(104, 28);
                        this.BotonAgregar.SubLabelPos = Lui.Forms.SubLabelPositions.Right;
                        this.BotonAgregar.Subtext = "F6";
                        this.BotonAgregar.TabIndex = 6;
                        this.BotonAgregar.Text = "Agregar";
                        this.BotonAgregar.Click += new System.EventHandler(this.BotonAgregar_Click);
                        // 
                        // BotonQuitar
                        // 
                        this.BotonQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                        this.BotonQuitar.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonQuitar.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.BotonQuitar.Image = null;
                        this.BotonQuitar.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonQuitar.Location = new System.Drawing.Point(420, 368);
                        this.BotonQuitar.Name = "BotonQuitar";
                        this.BotonQuitar.Size = new System.Drawing.Size(104, 28);
                        this.BotonQuitar.SubLabelPos = Lui.Forms.SubLabelPositions.None;
                        this.BotonQuitar.Subtext = "";
                        this.BotonQuitar.TabIndex = 5;
                        this.BotonQuitar.Text = "Quitar";
                        this.BotonQuitar.Click += new System.EventHandler(this.BotonQuitar_Click);
                        // 
                        // EntradaNombreUsuario
                        // 
                        this.EntradaNombreUsuario.Location = new System.Drawing.Point(272, 0);
                        this.EntradaNombreUsuario.Name = "EntradaNombreUsuario";
                        this.EntradaNombreUsuario.Size = new System.Drawing.Size(120, 24);
                        this.EntradaNombreUsuario.TabIndex = 3;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(208, 0);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(64, 24);
                        this.label2.TabIndex = 2;
                        this.label2.Text = "Usuario";
                        this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        // 
                        // Editar
                        // 
                        this.Controls.Add(this.EntradaNombreUsuario);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.BotonQuitar);
                        this.Controls.Add(this.BotonAgregar);
                        this.Controls.Add(this.Listado);
                        this.Controls.Add(this.EntradaContrasena);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.EntradaAcceso);
                        this.Controls.Add(this.Label6);
                        this.MinimumSize = new System.Drawing.Size(640, 400);
                        this.Name = "Editar";
                        this.Size = new System.Drawing.Size(640, 400);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }
                #endregion

                private System.Windows.Forms.ColumnHeader ColNivel;
                private System.Windows.Forms.ColumnHeader ColItems;
                private Lui.Forms.Button BotonAgregar;
                private Lui.Forms.Button BotonQuitar;
                private Lui.Forms.ComboBox EntradaAcceso;
                private Lui.Forms.Label Label6;
                private Lui.Forms.Label label1;
                private Lui.Forms.TextBox EntradaContrasena;
                private Lui.Forms.ListView Listado;
                private System.Windows.Forms.ColumnHeader ColCod;
                private System.ComponentModel.IContainer components = null;
                private Lui.Forms.TextBox EntradaNombreUsuario;
                private Lui.Forms.Label label2;
        }
}
