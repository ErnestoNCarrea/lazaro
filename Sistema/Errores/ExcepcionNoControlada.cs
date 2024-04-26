using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lazaro.WinMain.Errores
{
        public partial class ExcepcionNoControlada : Lui.Forms.Form
        {
                public ExcepcionNoControlada()
                {
                        this.DisplayStyle = Lazaro.Pres.DisplayStyles.Template.Current.White;
                        InitializeComponent();
                }

                private void BotonCerrar_Click(object sender, EventArgs e)
                {
                        this.Close();
                }

                private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        Help.ShowHelp(this, "http://www.lazarogestion.com/soporte");
                }

                private Exception exception;
                public Exception Excepcion
                {
                        get
                        {
                                return this.exception;
                        }
                        set {
                                this.exception = value;
                                this.EtiquetaDescripcion.Text = this.exception.ToString();
                                this.Height = Screen.FromControl(this).Bounds.Height - 128;
                        }
                }
        }
}
