namespace Lazaro.WinMain.Principal
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
                        if (disposing) {
                                if (components != null)
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
                        this.TimerProgramador = new System.Windows.Forms.Timer();
                        this.MainMenu = new System.Windows.Forms.MainMenu();
                        this.BarraTareas = new System.Windows.Forms.ToolStrip();
                        this.BarraInferior = new Lazaro.WinMain.Principal.BarraInferior();
                        this.SuspendLayout();
                        // 
                        // TimerProgramador
                        // 
                        this.TimerProgramador.Enabled = true;
                        this.TimerProgramador.Interval = 5000;
                        this.TimerProgramador.Tick += new System.EventHandler(this.TimerProgramador_Tick);
                        // 
                        // BarraTareas
                        // 
                        this.BarraTareas.AllowItemReorder = true;
                        this.BarraTareas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.BarraTareas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
                        this.BarraTareas.Location = new System.Drawing.Point(0, 0);
                        this.BarraTareas.Name = "BarraTareas";
                        this.BarraTareas.Padding = new System.Windows.Forms.Padding(4);
                        this.BarraTareas.Size = new System.Drawing.Size(1024, 25);
                        this.BarraTareas.TabIndex = 17;
                        this.BarraTareas.Text = "Tareas";
                        this.BarraTareas.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.BarraTareas_ItemClicked);
                        // 
                        // BarraInferior
                        // 
                        this.BarraInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(234)))), ((int)(((byte)(229)))));
                        this.BarraInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.BarraInferior.Location = new System.Drawing.Point(0, 633);
                        this.BarraInferior.Name = "BarraInferior";
                        this.BarraInferior.Size = new System.Drawing.Size(1024, 57);
                        this.BarraInferior.TabIndex = 15;
                        // 
                        // Inicio
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(1024, 690);
                        this.Controls.Add(this.BarraTareas);
                        this.Controls.Add(this.BarraInferior);
                        this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
                        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                        this.IsMdiContainer = true;
                        this.KeyPreview = true;
                        this.Menu = this.MainMenu;
                        this.Name = "Inicio";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        this.Text = "Lázaro";
                        this.Load += new System.EventHandler(this.FormPrincipal_Load);
                        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPrincipal_KeyDown);
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                internal System.Windows.Forms.Timer TimerProgramador;
                internal System.Windows.Forms.MainMenu MainMenu;
                private BarraInferior BarraInferior;
                public System.Windows.Forms.ToolStrip BarraTareas;
        }
}
