namespace Lui.Forms
{
        public partial class Control
        {
                private System.ComponentModel.IContainer components = null;

                protected override void Dispose(bool disposing)
                {
                        if (disposing && (components != null)) {
                                components.Dispose();
                        }
                        DisposePens();
                        base.Dispose(disposing);
                }

                #region Código generado por el Diseñador de componentes

                private void InitializeComponent()
                {
                        this.SuspendLayout();
                        // 
                        // Control
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
                        this.Name = "Control";
                        this.Size = new System.Drawing.Size(460, 84);
                        this.TabStopChanged += new System.EventHandler(this.Control_TabStopChanged);
                        this.Enter += new System.EventHandler(this.Control_Enter);
                        this.Leave += new System.EventHandler(this.Control_Leave);
                        this.Resize += new System.EventHandler(this.Control_Resize);
                        this.ResumeLayout(false);

                }
                #endregion

        }
}
