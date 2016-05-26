using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lui.Forms
{
        public partial class MessageBox : Lui.Forms.Form
        {
                public MessageBox()
                {
                        this.DisplayStyle = Lazaro.Pres.DisplayStyles.Template.Current.White;
                        InitializeComponent();
                }


                public static void Show(string message, string caption)
                {
                        using (Lui.Forms.MessageBox FormMessageBox = new Lui.Forms.MessageBox()) {
                                FormMessageBox.Text = caption;
                                FormMessageBox.EtiquetaTitulo.Text = caption;
                                FormMessageBox.MessageText.Text = message;
                                FormMessageBox.ShowDialog();
                                FormMessageBox.Close();
                        }
                }


                private void OkButton_Click(object sender, EventArgs e)
                {
                        this.Close();
                }

                private void MessageBoxForm_KeyDown(object sender, KeyEventArgs e)
                {
                        if (e.Alt == false && e.Control == true && e.KeyCode == Keys.C) {
                                System.Windows.Forms.Clipboard.SetData(System.Windows.Forms.DataFormats.StringFormat, MessageText.Text);
                                e.Handled = true;
                        } else if (e.Alt == false && e.Control == false && e.KeyCode == Keys.Escape) {
                                e.Handled = true;
                                this.Close();
                        }
                }


                protected override void OnResize(System.EventArgs e)
                {
                        base.OnResize(e);
                        if (this.Created) {
                                this.MessageText.MaximumSize = new Size(EtiquetaTitulo.Right - MessageText.Left, 0);
                                this.MessageText.AutoSize = true;
                                this.Height = this.MessageText.Bottom + this.LowerPanel.Height + 32 + (this.Height - this.ClientRectangle.Height);
                        }
                }


                protected override void OnLoad(System.EventArgs e)
                {
                        base.OnLoad(e);
                        this.Size = new Size(480, 320);
                        this.CenterToParent();
                }
        }
}