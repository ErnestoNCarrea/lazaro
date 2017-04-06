using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace Lui.Forms
{
        public partial class Button
        {
                protected override void Dispose(bool disposing)
                {
                        if (disposing) {
                                if (components != null)
                                        components.Dispose();
                        }
                        base.Dispose(disposing);
                }

                private System.ComponentModel.IContainer components = null;

                #region Código generado por el Diseñador de Windows Forms

                private void InitializeComponent()
                {
                        this.MainText = new System.Windows.Forms.Label();
                        this.SubText = new System.Windows.Forms.Label();
                        this.IconPicture = new System.Windows.Forms.PictureBox();
                        ((System.ComponentModel.ISupportInitialize)(this.IconPicture)).BeginInit();
                        this.SuspendLayout();
                        // 
                        // MainText
                        // 
                        this.MainText.Location = new System.Drawing.Point(2, 2);
                        this.MainText.Name = "MainText";
                        this.MainText.Size = new System.Drawing.Size(316, 64);
                        this.MainText.TabIndex = 1;
                        this.MainText.Text = "Command asdasd";
                        this.MainText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.MainText.Click += new System.EventHandler(this.MainText_Click);
                        this.MainText.DoubleClick += new System.EventHandler(this.MainText_DoubleClick);
                        this.MainText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainText_MouseDown);
                        // 
                        // SubText
                        // 
                        this.SubText.Location = new System.Drawing.Point(2, 78);
                        this.SubText.Name = "SubText";
                        this.SubText.Size = new System.Drawing.Size(312, 8);
                        this.SubText.TabIndex = 2;
                        this.SubText.Text = "Tecla";
                        this.SubText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                        this.SubText.Visible = false;
                        this.SubText.Click += new System.EventHandler(this.SubText_Click);
                        this.SubText.DoubleClick += new System.EventHandler(this.SubText_DoubleClick);
                        // 
                        // IconPicture
                        // 
                        this.IconPicture.BackColor = System.Drawing.Color.Transparent;
                        this.IconPicture.Location = new System.Drawing.Point(4, 4);
                        this.IconPicture.Name = "IconPicture";
                        this.IconPicture.Size = new System.Drawing.Size(44, 44);
                        this.IconPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                        this.IconPicture.TabIndex = 3;
                        this.IconPicture.TabStop = false;
                        this.IconPicture.Visible = false;
                        // 
                        // Button
                        // 
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                        this.Controls.Add(this.IconPicture);
                        this.Controls.Add(this.SubText);
                        this.Controls.Add(this.MainText);
                        this.Name = "Button";
                        this.Size = new System.Drawing.Size(320, 80);
                        this.SizeChanged += new System.EventHandler(this.Button_SizeChanged);
                        ((System.ComponentModel.ISupportInitialize)(this.IconPicture)).EndInit();
                        this.ResumeLayout(false);
                        this.PerformLayout();

                }


                #endregion

                private System.Windows.Forms.Label MainText;
                private System.Windows.Forms.Label SubText;
                private System.Windows.Forms.PictureBox IconPicture;
        }
}
