using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Lfc.Inicio
{
        [System.ComponentModel.DefaultEvent("Click")]
        public partial class Boton : UserControl
        {
                new public event System.EventHandler Click;

                public Boton()
                {
                        InitializeComponent();
                }

                [EditorBrowsable(EditorBrowsableState.Always),
                        Browsable(true),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
                public override string Text
                {
                        get
                        {
                                return EtiquetaTexto.Text;
                        }
                        set
                        {
                                EtiquetaTexto.Text = value;
                        }
                }

                public Image Image
                {
                        get
                        {
                                return ImagenIcono.Image;
                        }
                        set
                        {
                                ImagenIcono.Image = value;
                        }
                }

                private void EtiquetaTexto_Click(object sender, EventArgs e)
                {
                        if (this.Enabled && this.Click != null)
                                this.Click(this, e);
                }

                private void ImagenIcono_Click(object sender, EventArgs e)
                {
                        if (this.Enabled && this.Click != null)
                                this.Click(this, e);
                }
        }
}
