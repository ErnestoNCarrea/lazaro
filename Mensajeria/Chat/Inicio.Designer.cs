namespace Lazaro.Mensajeria.Chat
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
                        this.components = new System.ComponentModel.Container();
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
                        this.Pestanias = new System.Windows.Forms.ToolStrip();
                        this.BotonNuevo = new System.Windows.Forms.ToolStripDropDownButton();
                        this.Listado = new Lui.Forms.ListView();
                        this.ColNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                        this.TimerContactos = new System.Windows.Forms.Timer(this.components);
                        this.Pestanias.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // Pestanias
                        // 
                        this.Pestanias.AllowItemReorder = true;
                        this.Pestanias.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.Pestanias.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
                        this.Pestanias.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BotonNuevo});
                        this.Pestanias.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
                        this.Pestanias.Location = new System.Drawing.Point(0, 0);
                        this.Pestanias.Name = "Pestanias";
                        this.Pestanias.Padding = new System.Windows.Forms.Padding(4);
                        this.Pestanias.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
                        this.Pestanias.Size = new System.Drawing.Size(624, 32);
                        this.Pestanias.TabIndex = 0;
                        this.Pestanias.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Pestanias_ItemClicked);
                        // 
                        // BotonNuevo
                        // 
                        this.BotonNuevo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
                        this.BotonNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
                        this.BotonNuevo.Image = ((System.Drawing.Image)(resources.GetObject("BotonNuevo.Image")));
                        this.BotonNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
                        this.BotonNuevo.Name = "BotonNuevo";
                        this.BotonNuevo.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
                        this.BotonNuevo.Size = new System.Drawing.Size(79, 21);
                        this.BotonNuevo.Text = "Contactos";
                        this.BotonNuevo.ToolTipText = "Nuevo mensaje instantáneo";
                        // 
                        // Listado
                        // 
                        this.Listado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.Listado.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.Listado.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColNombre});
                        this.Listado.FieldName = null;
                        this.Listado.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
                        this.Listado.HideSelection = false;
                        this.Listado.Location = new System.Drawing.Point(16, 48);
                        this.Listado.MultiSelect = false;
                        this.Listado.Name = "Listado";
                        this.Listado.ReadOnly = false;
                        this.Listado.ShowItemToolTips = true;
                        this.Listado.Size = new System.Drawing.Size(592, 296);
                        this.Listado.TabIndex = 0;
                        this.Listado.UseCompatibleStateImageBehavior = false;
                        this.Listado.View = System.Windows.Forms.View.List;
                        this.Listado.DoubleClick += new System.EventHandler(this.Listado_DoubleClick);
                        // 
                        // ColNombre
                        // 
                        this.ColNombre.Text = "Nombre";
                        this.ColNombre.Width = 240;
                        // 
                        // TimerContactos
                        // 
                        this.TimerContactos.Interval = 1000;
                        this.TimerContactos.Tick += new System.EventHandler(this.TimerContactos_Tick);
                        // 
                        // Inicio
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(624, 361);
                        this.Controls.Add(this.Pestanias);
                        this.Controls.Add(this.Listado);
                        this.ForeColor = System.Drawing.SystemColors.ControlText;
                        this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
                        this.Name = "Inicio";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        this.Text = "Mensaje instantáneo";
                        this.Pestanias.ResumeLayout(false);
                        this.Pestanias.PerformLayout();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private System.Windows.Forms.ToolStrip Pestanias;
                private System.Windows.Forms.ToolStripDropDownButton BotonNuevo;
                private Lui.Forms.ListView Listado;
                private System.Windows.Forms.ColumnHeader ColNombre;
                private System.Windows.Forms.Timer TimerContactos;

        }
}