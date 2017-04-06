namespace Lfc.Log
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
                        this.components = new System.ComponentModel.Container();
                        this.ListaHistoral = new Lui.Forms.ListView();
                        this.ColFecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColPersona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColAccion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.ColDatos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.formHeader1 = new Lui.Forms.FormHeader();
                        this.TimerRefrescar = new System.Windows.Forms.Timer(this.components);
                        this.SuspendLayout();
                        // 
                        // ListaHistoral
                        // 
                        this.ListaHistoral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.ListaHistoral.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.ListaHistoral.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColFecha,
            this.ColPersona,
            this.ColAccion,
            this.ColDatos});
                        this.ListaHistoral.FullRowSelect = true;
                        this.ListaHistoral.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
                        this.ListaHistoral.Location = new System.Drawing.Point(24, 88);
                        this.ListaHistoral.MultiSelect = false;
                        this.ListaHistoral.Name = "ListaHistoral";
                        this.ListaHistoral.Size = new System.Drawing.Size(696, 272);
                        this.ListaHistoral.TabIndex = 0;
                        this.ListaHistoral.UseCompatibleStateImageBehavior = false;
                        this.ListaHistoral.View = System.Windows.Forms.View.Details;
                        this.ListaHistoral.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListaHistoral_KeyDown);
                        this.ListaHistoral.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListaHistoral_MouseDoubleClick);
                        // 
                        // ColFecha
                        // 
                        this.ColFecha.Text = "Fecha";
                        this.ColFecha.Width = 205;
                        // 
                        // ColPersona
                        // 
                        this.ColPersona.Text = "Usuario";
                        this.ColPersona.Width = 160;
                        // 
                        // ColAccion
                        // 
                        this.ColAccion.Text = "Accion";
                        this.ColAccion.Width = 151;
                        // 
                        // ColDatos
                        // 
                        this.ColDatos.Text = "Datos";
                        this.ColDatos.Width = 600;
                        // 
                        // formHeader1
                        // 
                        this.formHeader1.Dock = System.Windows.Forms.DockStyle.Top;
                        this.formHeader1.Location = new System.Drawing.Point(0, 0);
                        this.formHeader1.Name = "formHeader1";
                        this.formHeader1.Size = new System.Drawing.Size(738, 64);
                        this.formHeader1.TabIndex = 101;
                        this.formHeader1.Text = "Historial";
                        // 
                        // TimerRefrescar
                        // 
                        this.TimerRefrescar.Enabled = true;
                        this.TimerRefrescar.Interval = 500;
                        this.TimerRefrescar.Tick += new System.EventHandler(this.TimerRefrescar_Tick);
                        // 
                        // Editar
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(738, 443);
                        this.Controls.Add(this.formHeader1);
                        this.Controls.Add(this.ListaHistoral);
                        this.Name = "Editar";
                        this.Text = "Historial";
                        this.Controls.SetChildIndex(this.ListaHistoral, 0);
                        this.Controls.SetChildIndex(this.formHeader1, 0);
                        this.ResumeLayout(false);

                }

                #endregion

                private Lui.Forms.ListView ListaHistoral;
                private System.Windows.Forms.ColumnHeader ColFecha;
                private System.Windows.Forms.ColumnHeader ColPersona;
                private System.Windows.Forms.ColumnHeader ColAccion;
                private System.Windows.Forms.ColumnHeader ColDatos;
                private Lui.Forms.FormHeader formHeader1;
                private System.Windows.Forms.Timer TimerRefrescar;
        }
}