using System;
using System.Windows.Forms;

// Código desarrollado por José Miguel Torres
// jtorres_diaz@terra.es
// Mayo 2004
// El código original fue tomado de la web. El Copyright va al autor original.

namespace Lui.Forms
{
        /// <summary>
        /// Clase equivalente InputBox de Visual Basic.
        /// </summary>
        /// <remarks>Devuelve DialogResult.OK en Aceptar o Intro.
        /// Devuelve DialogResult.Cancel en Cancelar o Escape.</remarks>

        public partial class InputBox : Lui.Forms.Form
        {
                private InputBox()
                {
                        InitializeComponent();
                }

                /// <summary>
                /// Ejecuta InputBox.
                /// </summary>
                /// <param name="prompt">Cadena de pregunta del InputBox.</param>
                /// <returns>Devuelve cadena introducida por el usuario si DialgoResult es OK.</returns>
                public static string ShowInputBox(string prompt)
                {
                        InputBox box = new InputBox();
                        box.Text = Application.ProductName;
                        box.EtiquetaInfo.Text = prompt;
                        box.Texto.Text = "";
                        box.StartPosition = FormStartPosition.CenterScreen;
                        box.ShowDialog();

                        if (box.DialogResult.CompareTo(DialogResult.OK) == 0)
                                return box.Texto.Text;
                        else
                                return "";
                }

                /// <summary>
                /// Ejecuta InputBox.
                /// </summary>
                /// <param name="prompt">Cadena de pregunta del InputBox.</param>
                /// <param name="title">Titulo del InputBox.</param>
                /// <param name="defaultValue">Valor por defecto en la casilla de entra de texto.</param>
                /// <returns>Devuelve cadena introducida por el usuario si DialgoResult es OK.</returns>
                public static string ShowInputBox(string prompt, string title, string defaultValue)
                {
                        InputBox box = new InputBox();
                        box.Text = title;
                        box.EtiquetaInfo.Text = prompt;
                        box.Texto.Text = defaultValue;
                        box.StartPosition = FormStartPosition.CenterScreen;
                        box.ShowDialog();

                        if (box.DialogResult.CompareTo(DialogResult.OK) == 0)
                                return box.Texto.Text;
                        else
                                return "";
                }

                /// <summary>
                /// Ejecuta InputBox.
                /// </summary>
                /// <param name="prompt">Cadena de pregunta del InputBox.</param>
                /// <param name="title">Titulo del InputBox.</param>
                /// <param name="defaultValue">Valor por defecto en la casilla de entra de texto.</param>
                /// <param name="XPos">Posiciona el InputBox en la coordenada X horizontal.</param>
                /// <param name="YPos">Posiciona el InputBox en la coordenada Y vertical.</param>
                /// <returns>Devuelve cadena introducida por el usuario si DialgoResult es OK.</returns>
                public static string ShowInputBox(string prompt, string title, string defaultValue, int XPos, int YPos)
                {
                        InputBox box = new InputBox();
                        box.Text = title;
                        box.EtiquetaInfo.Text = prompt;
                        box.Texto.Text = defaultValue;
                        box.Location = new System.Drawing.Point(XPos, YPos);
                        box.ShowDialog();

                        if (box.DialogResult.CompareTo(DialogResult.OK) == 0)
                                return box.Texto.Text;
                        else
                                return "";
                }

                private void OkButton_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                }

                private void CancelBtn_Click(object sender, EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void Texto_KeyDown(object sender, KeyEventArgs e)
                {
                        if (e.KeyCode == Keys.Enter) {
                                e.Handled = true;
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                        } else if (e.KeyCode == Keys.Escape) {
                                e.Handled = true;
                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                        }
                }
       }
}
