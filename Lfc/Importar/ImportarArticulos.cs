using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Importar
{
        public partial class ImportarArticulos : Lui.Forms.DialogForm
        {
                public ImportarArticulos()
                {
                        InitializeComponent();
                }

                private void BotonExaminar_Click(object sender, EventArgs e)
                {
                        OpenFileDialog FileDialog = new OpenFileDialog();
                        FileDialog.CheckFileExists = true;
                        FileDialog.CheckPathExists = true;
                        FileDialog.InitialDirectory = Lfx.Environment.Folders.UserFolder;
                        FileDialog.Multiselect = false;
                        FileDialog.Title = "Importar artículos";
                        FileDialog.ValidateNames = true;

                        FileDialog.Filter = "Archivos importables|*.xls;*.xlsx;*.csv|Archivos de Microsoft Excel|*.xls;*.xlsx|Archivos de texto separado por comas|*.csv|Todos los archivos|*.*";
                        if (FileDialog.ShowDialog() == DialogResult.OK && FileDialog.FileName != null && FileDialog.FileName.Length > 0) {
                        }
                }
        }
}
