using System;
using System.Windows.Forms;

namespace Lui.Forms
{
        public partial class WorkspaceSelectorForm : Lui.Forms.DialogForm
        {
                private string m_WorkspaceName = null;

                public WorkspaceSelectorForm()
                {
                        InitializeComponent();
                        CancelCommandButton.Text = "Cancelar";
                        Espacios.Font = Lazaro.Pres.DisplayStyles.Template.Current.DefaultFont;
                }


                protected override void OnActivated(EventArgs e)
                {
                        base.OnActivated(e);

                        Espacios.Items.Clear();
                        System.IO.DirectoryInfo Dir = new System.IO.DirectoryInfo(Lfx.Environment.Folders.ApplicationDataFolder);
                        foreach (System.IO.FileInfo NombreEspacio in Dir.GetFiles("*.lwf")) {
                                string Nombre = NombreEspacio.Name.Replace(".lwf", "");
                                if (Nombre == "default")
                                        Nombre = "Predeterminado";
                                if (Nombre == Nombre.ToLower() || Nombre == Nombre.ToUpper())
                                        Nombre = Nombre.ToTitleCase();

                                Espacios.Items.Add(Nombre);
                                if (Nombre == "Predeterminado")
                                        Espacios.SelectedIndex = Espacios.Items.Count - 1;
                        }
                        if (Espacios.Items.Count > 0 && Espacios.SelectedIndex < 0)
                                Espacios.SelectedIndex = 0;
                }


                private void Espacios_SelectedValueChanged(object sender, System.EventArgs e)
                {
                        if (Espacios.SelectedItem != null) {
                                m_WorkspaceName = Espacios.SelectedItem.ToString();
                                this.OkButton.Enabled = true;
                        } else {
                                this.OkButton.Enabled = false;
                        }
                }


                public string WorkspaceName
                {
                        get
                        {
                                if (m_WorkspaceName == "Predeterminado")
                                        return "default";
                                else
                                        return m_WorkspaceName;
                        }
                }


                private void Espacios_KeyDown(object sender, KeyEventArgs e)
                {
                        if (e.Control == false && e.Alt == false) {
                                switch (e.KeyCode) {
                                        case Keys.Return:
                                                e.Handled = true;
                                                if (OkButton.Enabled && OkButton.Visible)
                                                        OkButton.PerformClick();
                                                break;
                                }
                        }
                }
        }
}