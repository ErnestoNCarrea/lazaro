using System.Windows.Forms;

namespace Lfc
{
        public partial class FormularioFiltros : Lui.Forms.DialogForm
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

                private void InitializeComponent()
                {
                        this.ControlFiltros = new Lcc.Entrada.Filtros();
                        this.label1 = new Lui.Forms.Label();
                        this.label2 = new Lui.Forms.Label();
                        this.PanelFiltros = new Lui.Forms.Panel();
                        this.PanelFiltros.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // ControlFiltros
                        // 
                        this.ControlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.ControlFiltros.AutoScroll = true;
                        this.ControlFiltros.AutoSize = true;
                        this.ControlFiltros.Font = new System.Drawing.Font("Segoe UI", 9.75F);
                        this.ControlFiltros.Location = new System.Drawing.Point(8, 40);
                        this.ControlFiltros.Name = "ControlFiltros";
                        this.ControlFiltros.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
                        this.ControlFiltros.ShowApplyButton = false;
                        this.ControlFiltros.Size = new System.Drawing.Size(608, 200);
                        this.ControlFiltros.TabIndex = 1;
                        this.ControlFiltros.StyleChanged += new System.EventHandler(this.ControlFiltros_StyleChanged);
                        // 
                        // label1
                        // 
                        this.label1.AutoSize = true;
                        this.label1.Location = new System.Drawing.Point(24, 16);
                        this.label1.Name = "label1";
                        this.label1.Size = new System.Drawing.Size(316, 30);
                        this.label1.TabIndex = 0;
                        this.label1.Text = "Filtrar la información del listado";
                        this.label1.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.MainHeader;
                        // 
                        // label2
                        // 
                        this.label2.Location = new System.Drawing.Point(24, 0);
                        this.label2.Name = "label2";
                        this.label2.Size = new System.Drawing.Size(576, 40);
                        this.label2.TabIndex = 0;
                        this.label2.Text = "Puede filtrar la información del listado para ver sólo los elementos que cumplan " +
    "con los requisitos siguientes. Si imprime o exporta el listado también se aplica" +
    "rán estos filtros.";
                        // 
                        // PanelFiltros
                        // 
                        this.PanelFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.PanelFiltros.AutoScroll = true;
                        this.PanelFiltros.AutoScrollMargin = new System.Drawing.Size(0, 24);
                        this.PanelFiltros.Controls.Add(this.label2);
                        this.PanelFiltros.Controls.Add(this.ControlFiltros);
                        this.PanelFiltros.Location = new System.Drawing.Point(0, 48);
                        this.PanelFiltros.Margin = new System.Windows.Forms.Padding(0);
                        this.PanelFiltros.Name = "PanelFiltros";
                        this.PanelFiltros.Size = new System.Drawing.Size(624, 360);
                        this.PanelFiltros.TabIndex = 1;
                        // 
                        // FormularioFiltros
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
                        this.AutoSize = true;
                        this.ClientSize = new System.Drawing.Size(624, 473);
                        this.Controls.Add(this.PanelFiltros);
                        this.Controls.Add(this.label1);
                        this.ForeColor = System.Drawing.Color.Black;
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                        this.MaximumSize = new System.Drawing.Size(1000, 600);
                        this.MinimumSize = new System.Drawing.Size(480, 320);
                        this.Name = "FormularioFiltros";
                        this.Text = "Filtros";
                        this.Controls.SetChildIndex(this.label1, 0);
                        this.Controls.SetChildIndex(this.PanelFiltros, 0);
                        this.PanelFiltros.ResumeLayout(false);
                        this.PanelFiltros.PerformLayout();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }

                #endregion

                private Lcc.Entrada.Filtros ControlFiltros;
                private Lui.Forms.Label label1;
                private Lui.Forms.Label label2;
                private Lui.Forms.Panel PanelFiltros;

        }
}
