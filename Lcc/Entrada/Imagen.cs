using System;
using System.Collections.Generic;
using System.Text;

namespace Lcc.Entrada
{
        public partial class Imagen : Lcc.Edicion.ControlEdicion
        {
                internal System.Windows.Forms.PictureBox EntradaImagen;
                internal Lui.Forms.Button BotonQuitarImagen;
                internal Lui.Forms.Button BotonSeleccionarImagen;
                private System.IO.FileStream Arch;

                public Imagen()
                {
                        InitializeComponent();
                        this.BorderStyle = BorderStyles.EditableNoHightlight;
                }

                public override string Text
                {
                        get
                        {
                                return GroupLabel.Text;
                        }
                        set
                        {
                                GroupLabel.Text = value;
                                base.Text = value;
                        }
                }


                public override void ActualizarControl()
                {
                        if (this.Elemento != null && this.Elemento is Lbl.IElementoConImagen)
                                EntradaImagen.Image = ((Lbl.IElementoConImagen)(this.Elemento)).Imagen;
                        else
                                EntradaImagen.Image = null;

                        this.Changed = false;
                }

                public override void ActualizarElemento()
                {
                        if (this.Elemento != null && this.Elemento is Lbl.IElementoConImagen)
                                ((Lbl.IElementoConImagen)(this.Elemento)).Imagen = EntradaImagen.Image;
                }

                private void BotonQuitarImagen_Click(object sender, EventArgs e)
                {
                        if (this.Elemento != null) {
                                if (EntradaImagen.Image != null) {
                                        EntradaImagen.Image = null;
                                        this.Changed = true;
                                        ActualizarElemento();
                                }
                        }
                }

                private void BotonSeleccionarImagen_Click(object sender, EventArgs e)
                {
                        if (this.Elemento != null) {
                                using (System.Windows.Forms.OpenFileDialog Abrir = new System.Windows.Forms.OpenFileDialog()) {
                                        Abrir.Filter = "Archivos JPEG|*.jpg";
                                        Abrir.Multiselect = false;
                                        Abrir.ValidateNames = true;

                                        if (Abrir.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                                                EntradaImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

                                                using (Lcc.Entrada.AuxForms.ImagenRecorte Recorte = new AuxForms.ImagenRecorte()) {
                                                        if (Arch != null)
                                                                Arch.Close();

                                                        Arch = new System.IO.FileStream(Abrir.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                                                        Recorte.Imagen = System.Drawing.Image.FromStream(Arch);
                                                        if (Recorte.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                                                                EntradaImagen.Image = Recorte.Imagen;
                                                                this.Changed = true;
                                                                this.ActualizarElemento();
                                                        }
                                                }
                                        }
                                }
                        }
                }

                private void BotonCapturarImagen_Click(object sender, EventArgs e)
                {
                        try {
                                var WiaDialog = new WIA.CommonDialog();
                                WIA.ImageFile WiaImage = null;
                                
                                WiaImage = WiaDialog.ShowAcquireImage(
                                        WIA.WiaDeviceType.UnspecifiedDeviceType,
                                        WIA.WiaImageIntent.ColorIntent,
                                        WIA.WiaImageBias.MaximizeQuality,
                                        System.Drawing.Imaging.ImageFormat.Jpeg.Guid.ToString("B"), true, false, false);

                                if (WiaImage != null) {
                                        var vector = WiaImage.FileData;
                                        using (var Recorte = new Entrada.AuxForms.ImagenRecorte()) {
                                                Recorte.Imagen = System.Drawing.Image.FromStream(new System.IO.MemoryStream((byte[])vector.get_BinaryData()));
                                                if (Recorte.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                                                        EntradaImagen.Image = Recorte.Imagen;
                                                        this.Changed = true;
                                                        this.ActualizarElemento();
                                                }
                                        }
                                }
                        } catch (Exception ex) {
                                Lui.Forms.MessageBox.Show("No se puede conectar con el dispositivo de captura. " + ex.Message, "Error");
                        }
                }

                private void GuardarEnarchivoToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        System.Windows.Forms.SaveFileDialog DialogoGuardar = new System.Windows.Forms.SaveFileDialog();
                        DialogoGuardar.DefaultExt = ".jpg";
                        DialogoGuardar.AddExtension = true;
                        DialogoGuardar.AutoUpgradeEnabled = true;
                        DialogoGuardar.CheckPathExists = true;
                        DialogoGuardar.CreatePrompt = false;
                        DialogoGuardar.Filter = "Imagen JPEG|*.jpg";
                        DialogoGuardar.OverwritePrompt = true;
                        DialogoGuardar.Title = "Guardar en archivo";
                        DialogoGuardar.ValidateNames = true;
                        DialogoGuardar.FileName = this.Elemento.ToString().Replace("/", " ").Replace(":", " ").Replace("?", "").Replace("\\", "");
                        if (DialogoGuardar.ShowDialog() == System.Windows.Forms.DialogResult.OK && DialogoGuardar.FileName != null && DialogoGuardar.FileName.Length > 0) {
                                EntradaImagen.Image.Save(DialogoGuardar.FileName);
                        }
                }

                private void CopiarAlPortapapelesToolStripMenuItem_Click(object sender, EventArgs e)
                {
                        try {
                                System.Windows.Forms.Clipboard.SetData(System.Windows.Forms.DataFormats.Bitmap, EntradaImagen.Image);
                        } catch {
                                // Nada
                        }
                }
        }
}
