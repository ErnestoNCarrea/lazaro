using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lazaro.WinMain.Config
{
        public partial class ConfigurarBd : Lui.Forms.Form
        {
                public ConfigurarBd()
                {
                        InitializeComponent();
                }

                private void ConfigBD_Load(object sender, System.EventArgs e)
                {
                        string Servidor = Lfx.Workspace.Master.CurrentConfig.ReadLocalSettingString("Data", "DataSource", null);
                        string Conexion = Lfx.Workspace.Master.CurrentConfig.ReadLocalSettingString("Data", "ConnectionType", null);
                        string BD = Lfx.Workspace.Master.CurrentConfig.ReadLocalSettingString("Data", "DatabaseName", null);
                        string Usuario = Lfx.Workspace.Master.CurrentConfig.ReadLocalSettingString("Data", "User", null);
                        string Contrasena = Lfx.Workspace.Master.CurrentConfig.ReadLocalSettingString("Data", "Password", null);
                        string Branch = Lfx.Workspace.Master.CurrentConfig.ReadLocalSettingString("Company", "Branch", null);

                        if (Servidor == null)
                                EntradaServidor.Text = "localhost";
                        else
                                EntradaServidor.Text = Servidor;

                        if (Conexion == null)
                                EntradaConexion.TextKey = "mysql";
                        else
                                EntradaConexion.TextKey = Conexion;

                        if (BD == null)
                                EntradaBD.Text = "lazaro";
                        else
                                EntradaBD.Text = BD;

                        if (Usuario == null) {
                                if (EntradaServidor.Text == "localhost")
                                        EntradaUsuario.Text = "root";
                                else
                                        EntradaUsuario.Text = "lazaro";
                        } else {
                                EntradaUsuario.Text = Usuario;
                        }

                        if (Contrasena == null)
                                EntradaContrasena.Text = "";
                        else
                                EntradaContrasena.Text = Contrasena;

                        if (Branch == null)
                                EntradaSucursal.Text = "1";
                        else
                                EntradaSucursal.Text = Branch;
                }


                private void EntradaConexion_TextChanged(System.Object sender, System.EventArgs e)
                {
                        switch (EntradaConexion.TextKey) {
                                case "odbc":
                                        EtiquetaServidor.Text = "DSN";
                                        break;
                                default:
                                        EtiquetaServidor.Text = "Servidor";
                                        break;
                        }
                }


                private void BotonAceptar_Click(System.Object sender, System.EventArgs e)
                {
                        if (EntradaServidor.Text.Length == 0) {
                                Lui.Forms.MessageBox.Show("Por favor escriba el nombre del Servidor.", "Error");
                                return;
                        }
                        if (EntradaConexion.TextKey != "odbc" && EntradaUsuario.Text.Length == 0) {
                                Lui.Forms.MessageBox.Show("Por favor escriba el nombre del Usuario.", "Error");
                                return;
                        }

                        this.Hide();

                        Lfx.Workspace.Master.ConnectionParameters.ServerName = EntradaServidor.Text;
                        switch (EntradaConexion.TextKey) {
                                case "odbc":
                                        Lfx.Data.DatabaseCache.DefaultCache.AccessMode = Lfx.Data.AccessModes.Odbc;
                                        break;
                                case "myodbc":
                                case "mysql":
                                        Lfx.Data.DatabaseCache.DefaultCache.AccessMode = Lfx.Data.AccessModes.MySql;
                                        break;
                                case "npgsql":
                                        Lfx.Data.DatabaseCache.DefaultCache.AccessMode = Lfx.Data.AccessModes.Npgsql;
                                        break;
                                case "mssql":
                                        Lfx.Data.DatabaseCache.DefaultCache.AccessMode = Lfx.Data.AccessModes.MSSql;
                                        break;
                                case "sqlite":
                                        Lfx.Data.DatabaseCache.DefaultCache.AccessMode = Lfx.Data.AccessModes.SQLite;
                                        break;
                        }

                        Lfx.Workspace.Master.ConnectionParameters.DatabaseName = EntradaBD.Text;
                        Lfx.Workspace.Master.ConnectionParameters.UserName = EntradaUsuario.Text;
                        Lfx.Workspace.Master.ConnectionParameters.Password = EntradaContrasena.Text;

                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "DataSource", Lfx.Workspace.Master.ConnectionParameters.ServerName);
                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "ConnectionType", EntradaConexion.TextKey);
                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "DatabaseName", EntradaBD.Text);
                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "User", EntradaUsuario.Text);
                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "Password", EntradaContrasena.Text);
                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "SlowLink", Lfx.Data.DatabaseCache.DefaultCache.SlowLink ? "1" : "0");
                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Company", "Branch", EntradaSucursal.Text);

                        Aplicacion.AbrirConexion();
                        this.DialogResult = DialogResult.Retry;
                }


                private void BotonCancelar_Click(System.Object sender, System.EventArgs e)
                {
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                }

                private void EntradaServidor_Leave(object sender, EventArgs e)
                {
                        if (EntradaServidor.Text == "localhost" || EntradaServidor.Text == "127.0.0.1") {
                                if (EntradaUsuario.Text == "lazaro" && EntradaContrasena.Text == "") {
                                        EntradaUsuario.Text = "root";
                                }
                        } else {
                                if (EntradaUsuario.Text == "root" && EntradaContrasena.Text == "") {
                                        EntradaUsuario.Text = "lazaro";
                                }
                        }
                }
        }
}