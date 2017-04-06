using System;
using System.Collections.Generic;
using System.Text;

namespace Lui.Printing
{
        public partial class PrintPreviewForm
        {
                public System.Windows.Forms.PrintPreviewControl PrintPreview;
                internal Lui.Forms.Button CancelCommandButton;
                internal Lui.Forms.Button SaveButton;
                internal Lui.Forms.ButtonPanel LowerPanel;
                internal Lui.Forms.Button BotonZoom;

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
                        this.PrintPreview = new System.Windows.Forms.PrintPreviewControl();
                        this.CancelCommandButton = new Lui.Forms.Button();
                        this.SaveButton = new Lui.Forms.Button();
                        this.LowerPanel = new Lui.Forms.ButtonPanel();
                        this.BotonZoom = new Lui.Forms.Button();
                        this.LowerPanel.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // PrintPreview
                        // 
                        this.PrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
                        this.PrintPreview.AutoZoom = false;
                        this.PrintPreview.Location = new System.Drawing.Point(0, 0);
                        this.PrintPreview.Name = "PrintPreview";
                        this.PrintPreview.Size = new System.Drawing.Size(616, 334);
                        this.PrintPreview.TabIndex = 500;
                        this.PrintPreview.UseAntiAlias = true;
                        this.PrintPreview.Zoom = 1D;
                        this.PrintPreview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrintPreview_KeyDown);
                        // 
                        // CancelCommandButton
                        // 
                        this.CancelCommandButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.CancelCommandButton.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.CancelCommandButton.Image = null;
                        this.CancelCommandButton.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.CancelCommandButton.Location = new System.Drawing.Point(394, 12);
                        this.CancelCommandButton.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.CancelCommandButton.MaximumSize = new System.Drawing.Size(108, 40);
                        this.CancelCommandButton.MinimumSize = new System.Drawing.Size(96, 32);
                        this.CancelCommandButton.Name = "CancelCommandButton";
                        this.CancelCommandButton.Padding = new System.Windows.Forms.Padding(2);
                        this.CancelCommandButton.Size = new System.Drawing.Size(96, 40);
                        this.CancelCommandButton.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.CancelCommandButton.Subtext = "Esc";
                        this.CancelCommandButton.TabIndex = 111;
                        this.CancelCommandButton.Text = "Cancelar";
                        this.CancelCommandButton.Click += new System.EventHandler(this.BotonCancelar_Click);
                        // 
                        // SaveButton
                        // 
                        this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                        this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.SaveButton.Image = null;
                        this.SaveButton.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.SaveButton.Location = new System.Drawing.Point(496, 12);
                        this.SaveButton.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.SaveButton.MaximumSize = new System.Drawing.Size(108, 40);
                        this.SaveButton.MinimumSize = new System.Drawing.Size(96, 32);
                        this.SaveButton.Name = "SaveButton";
                        this.SaveButton.Padding = new System.Windows.Forms.Padding(2);
                        this.SaveButton.Size = new System.Drawing.Size(96, 40);
                        this.SaveButton.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.SaveButton.Subtext = "F8";
                        this.SaveButton.TabIndex = 110;
                        this.SaveButton.Text = "Imprimir";
                        // 
                        // LowerPanel
                        // 
                        this.LowerPanel.Controls.Add(this.SaveButton);
                        this.LowerPanel.Controls.Add(this.CancelCommandButton);
                        this.LowerPanel.Controls.Add(this.BotonZoom);
                        this.LowerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.LowerPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
                        this.LowerPanel.Location = new System.Drawing.Point(0, 340);
                        this.LowerPanel.Name = "LowerPanel";
                        this.LowerPanel.Padding = new System.Windows.Forms.Padding(12);
                        this.LowerPanel.Size = new System.Drawing.Size(616, 65);
                        this.LowerPanel.TabIndex = 106;
                        // 
                        // BotonZoom
                        // 
                        this.BotonZoom.DialogResult = System.Windows.Forms.DialogResult.None;
                        this.BotonZoom.Image = null;
                        this.BotonZoom.ImagePos = Lui.Forms.ImagePositions.Top;
                        this.BotonZoom.Location = new System.Drawing.Point(292, 12);
                        this.BotonZoom.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
                        this.BotonZoom.MaximumSize = new System.Drawing.Size(108, 40);
                        this.BotonZoom.MinimumSize = new System.Drawing.Size(96, 32);
                        this.BotonZoom.Name = "BotonZoom";
                        this.BotonZoom.Padding = new System.Windows.Forms.Padding(2);
                        this.BotonZoom.Size = new System.Drawing.Size(96, 40);
                        this.BotonZoom.SubLabelPos = Lui.Forms.SubLabelPositions.Bottom;
                        this.BotonZoom.Subtext = "F2";
                        this.BotonZoom.TabIndex = 101;
                        this.BotonZoom.Text = "Zoom";
                        this.BotonZoom.Click += new System.EventHandler(this.BotonZoom_Click);
                        // 
                        // PrintPreviewForm
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                        this.ClientSize = new System.Drawing.Size(616, 405);
                        this.Controls.Add(this.LowerPanel);
                        this.Controls.Add(this.PrintPreview);
                        this.Name = "PrintPreviewForm";
                        this.Text = "Vista Previa";
                        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormVistaPrevia_KeyDown);
                        this.LowerPanel.ResumeLayout(false);
                        this.ResumeLayout(false);

                }
        }
}
