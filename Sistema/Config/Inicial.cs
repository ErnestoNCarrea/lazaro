using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace Lazaro.WinMain.Config
{
        public partial class Inicial : Lui.Forms.Form
        {
                public enum Pasos
                {
                        Inicio,
                        Deteccion,
                        SeleccionarAlmacen,
                        InstalarServidor,
                        NombreServidor,
                        PruebaServidor,
                        DatosEmpresa,
                        Final
                }

                private Pasos Paso = Pasos.Inicio;
                private string ServidorDetectado = null;
                private System.Threading.Thread ThreadBuscar = null, ThreadDescargar = null;

                public Inicial()
                {
                        InitializeComponent();
                }


                protected override void OnFormClosing(FormClosingEventArgs e)
                {
                        if (this.ThreadBuscar != null) {
                                this.ThreadBuscar.Abort();
                                this.ThreadBuscar = null;
                        }

                        if (this.ThreadDescargar != null) {
                                this.ThreadDescargar.Abort();
                                this.ThreadDescargar = null;
                        }
                        base.OnFormClosing(e);
                }


                private void BotonSalir_Click(object sender, EventArgs e)
                {
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.Close();
                }


                private void DetectarConfig()
                {
                        if (this.ThreadBuscar != null) {
                                this.ThreadBuscar.Abort();
                                this.ThreadBuscar = null;
                        }

                        switch (Lfx.Environment.SystemInformation.Platform) {
                                case Lfx.Environment.SystemInformation.Platforms.Windows:
                                        Lfx.Types.OperationProgress Progreso = new Lfx.Types.OperationProgress("Buscando un servidor", "Por favor aguarde mientras Lázaro busca un servidor en la red para utilizar como almacén de datos.");
                                        ProgresoBuscar.Visible = true;
                                        Progreso.Modal = false;
                                        Progreso.Advertise = false;
                                        Progreso.Begin();

                                        System.Threading.ThreadStart Buscar = delegate { this.BuscarServidor(Progreso); };
                                        this.ThreadBuscar = new System.Threading.Thread(Buscar);
                                        this.ThreadBuscar.IsBackground = true;
                                        this.ThreadBuscar.Start();

                                        EtiquetaBuscarEspere.Visible = true;
                                        while (Progreso != null && Progreso.IsRunning) {
                                                System.Threading.Thread.Sleep(100);
                                                EtiquetaBuscando.Text = Progreso.Status;
                                                System.Windows.Forms.Application.DoEvents();
                                                if (this.ThreadBuscar == null)
                                                        return;
                                        }
                                        EtiquetaBuscarEspere.Visible = false;
                                        ProgresoBuscar.Visible = false;

                                        if (ServidorDetectado == null) {
                                                CheckInstalarAhora.Checked = true;
                                                EtiquetaBuscando.Text = "Lázaro no pudo encontrar un servidor SQL en la red. Si desea, puede instalar un servidor SQL en este equipo. Haga clic en 'Siguiente' para continuar.";
                                        } else {
                                                EtiquetaBuscando.Text = "Lázaro detectó un servidor SQL en la red. Haga clic en el botón 'Siguiente' para revisar la configuración detectada.";
                                                CheckOtroEquipo.Checked = true;
                                                EntradaServidor.Text = ServidorDetectado;
                                        }
                                        break;
                                default:
                                        // No es Windows
                                        CheckInstalarAhora.Enabled = false;
                                        break;
                        }
                }


                /// <summary>
                /// Busco un servidor en la red loca.
                /// </summary>
                /// <returns></returns>
                private void BuscarServidor(Lfx.Types.OperationProgress progreso)
                {
                        foreach (NetworkInterface Intrfc in NetworkInterface.GetAllNetworkInterfaces()) {
                                progreso.ChangeStatus("Buscando en " + Intrfc.Name);
                                if (Intrfc.OperationalStatus == OperationalStatus.Up) {
                                        foreach (UnicastIPAddressInformation MiDireccion in Intrfc.GetIPProperties().UnicastAddresses) {
                                                byte FirstByte = MiDireccion.Address.GetAddressBytes()[0];
                                                if (FirstByte == 192 || FirstByte == 10) {
                                                        byte SecondByte = MiDireccion.Address.GetAddressBytes()[1];
                                                        byte ThirdByte = MiDireccion.Address.GetAddressBytes()[2];
                                                        for (byte i = 1; i < 255; i++) {
                                                                try {
                                                                        IPAddress DireccionServidor = new IPAddress(new byte[] { FirstByte, SecondByte, ThirdByte, i });
                                                                        if (DireccionServidor.Equals(MiDireccion.Address) == false) {
                                                                                Ping Pp = new Ping();
                                                                                PingReply Pr = Pp.Send(DireccionServidor, 100);
                                                                                if (Pr.Status == IPStatus.Success) {
                                                                                        try {
                                                                                                System.Net.Sockets.TcpClient Cliente = new System.Net.Sockets.TcpClient();
                                                                                                Cliente.Connect(DireccionServidor, 3306);
                                                                                                Cliente.Close();
                                                                                                this.ServidorDetectado = DireccionServidor.ToString();

                                                                                                System.Net.IPHostEntry DireccionServidorDetectado = System.Net.Dns.GetHostEntry(ServidorDetectado);
                                                                                                this.ServidorDetectado = DireccionServidorDetectado.HostName;

                                                                                                progreso.End();
                                                                                        } catch {
                                                                                                // Nada
                                                                                        }
                                                                                }
                                                                        }
                                                                } catch {
                                                                        // Ignoro esa IP
                                                                }
                                                        }
                                                }
                                        }
                                }
                        }

                        this.ServidorDetectado = null;
                        progreso.End();
                }


                private void MostrarPaneles()
                {
                        if (Paso == Pasos.Final)
                                BotonSiguiente.Text = "Finalizar";
                        else
                                BotonSiguiente.Text = "Siguiente";

                        BotonSiguiente.Enabled = true;
                        BotonAnterior.Enabled = Paso != Pasos.Inicio;

                        PanelInicio.Visible = Paso == Inicial.Pasos.Inicio;
                        PanelDeteccion.Visible = Paso == Inicial.Pasos.Deteccion;
                        PanelSeleccionarAlmacen.Visible = Paso == Inicial.Pasos.SeleccionarAlmacen;
                        PanelNombreServidor.Visible = Paso == Inicial.Pasos.NombreServidor;
                        PanelPruebaServidor.Visible = Paso == Inicial.Pasos.PruebaServidor;
                        PanelDatosEmpresa.Visible = Paso == Inicial.Pasos.DatosEmpresa;
                        PanelInstalacion.Visible = Paso == Inicial.Pasos.InstalarServidor;
                        PanelFinal.Visible = Paso == Inicial.Pasos.Final;
                }

                private void PanelPruebaServidor_VisibleChanged(object sender, EventArgs e)
                {
                        if (PanelPruebaServidor.Visible) {
                                // Probar la conexión al servidor
                                if (CheckEsteEquipo.Checked) {
                                        Lfx.Workspace.Master.ConnectionParameters.ServerName = "localhost";
                                        Lfx.Workspace.Master.ConnectionParameters.UserName = "root";
                                        Lfx.Workspace.Master.ConnectionParameters.Password = "";
                                } else {
                                        Lfx.Workspace.Master.ConnectionParameters.ServerName = EntradaServidor.Text;
                                        Lfx.Workspace.Master.ConnectionParameters.UserName = "lazaro";
                                        Lfx.Workspace.Master.ConnectionParameters.Password = "";
                                }

                                Lfx.Data.DatabaseCache.DefaultCache.AccessMode = Lfx.Data.AccessModes.MySql;
                                Lfx.Data.DatabaseCache.DefaultCache.SlowLink = false;
                                Lfx.Workspace.Master.ConnectionParameters.DatabaseName = "";

                                Lfx.Types.OperationResult Res = this.ProbarServidor();
                                EtiquetaPruebaResultado.Text = Res.Message;
                                BotonSiguiente.Enabled = Res.Success;
                        }
                }


                private Lfx.Types.OperationResult ProbarServidor()
                {
                        try {
                                EtiquetaPruebaResultado.Text = "Probando la conexión...";
                                EtiquetaPruebaError.Text = "";
                                System.Windows.Forms.Application.DoEvents();

                                Lfx.Workspace.Master.MasterConnection.Open();

                                bool TengoDb = false;
                                try {
                                        Lfx.Workspace.Master.MasterConnection.ExecuteNonQuery("USE lazaro");
                                        TengoDb = true;
                                } catch {
                                        try {
                                                Lfx.Workspace.Master.MasterConnection.ExecuteNonQuery("CREATE DATABASE lazaro DEFAULT CHARACTER SET utf8");
                                                Lfx.Workspace.Master.MasterConnection.ExecuteNonQuery("USE lazaro");
                                                TengoDb = true;
                                        } catch {
                                                TengoDb = false;
                                        }
                                }

                                if (string.IsNullOrEmpty(Lfx.Workspace.Master.ConnectionParameters.DatabaseName))
                                        Lfx.Workspace.Master.ConnectionParameters.DatabaseName = "lazaro";
                                Lfx.Workspace.Master.MasterConnection.Close();
                                Lfx.Workspace.Master.MasterConnection.Open();
                                if (TengoDb) {
                                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "DataSource", Lfx.Workspace.Master.ConnectionParameters.ServerName);
                                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "ConnectionType", "mysql");
                                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "DatabaseName", Lfx.Workspace.Master.ConnectionParameters.DatabaseName);
                                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "User", Lfx.Workspace.Master.ConnectionParameters.UserName);
                                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "Password", Lfx.Workspace.Master.ConnectionParameters.Password);
                                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Data", "SlowLink", Lfx.Data.DatabaseCache.DefaultCache.SlowLink ? "1" : "0");
                                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Company", "Branch", 1);

                                        try {
                                                Lfx.Workspace.Master.MasterConnection.ExecuteNonQuery("GRANT ALL ON lazaro.* TO 'lazaro'@'localhost' IDENTIFIED BY ''");
                                                Lfx.Workspace.Master.MasterConnection.ExecuteNonQuery("GRANT ALL ON lazaro.* TO 'lazaro'@'%' IDENTIFIED BY ''");
                                        } catch {
                                                // No pude crear el acceso para otros usuarios... supongo que no importa
                                        }
                                } else {
                                }

                                if (CheckEsteEquipo.Checked)
                                        EtiquetaPruebaError.Text = "Si va a instalar Lázaro en otros equipos de la red, puede utilizar este equipo como servidor. El nombre de este equipo es " + System.Environment.MachineName;
                                else
                                        EtiquetaPruebaError.Text = "";
                                return new Lfx.Types.SuccessOperationResult("Se realizó una prueba de la configuración del almacén de datos. Todo parece estar en orden. Haga clic en 'Siguiente' para continuar.");
                        } catch (Exception ex) {
                                EtiquetaPruebaError.Text = "El mensaje de error es: " + ex.Message;
                                return new Lfx.Types.FailureOperationResult("No se pudo conectar al almacén de datos proporcionado. Haga clic en el botón 'Anterior' para ir a la pantalla anterior y volver a intentarlo.");
                        }
                }


                private void BotonSiguiente_Click(object sender, EventArgs e)
                {
                        switch (Paso) {
                                case Inicial.Pasos.Inicio:
                                        if (RadioInicioInstalacionLocal.Checked)
                                                Paso = Inicial.Pasos.InstalarServidor;
                                        else if (RadioInicioConexionRemota.Checked)
                                                Paso = Inicial.Pasos.Deteccion;
                                        break;
                                case Inicial.Pasos.Deteccion:
                                        Paso = Inicial.Pasos.SeleccionarAlmacen;
                                        break;
                                case Inicial.Pasos.SeleccionarAlmacen:
                                        if (CheckEsteEquipo.Checked) {
                                                Paso = Inicial.Pasos.PruebaServidor;
                                        } else if (CheckOtroEquipo.Checked) {
                                                Paso = Inicial.Pasos.NombreServidor;
                                        } else if (CheckInstalarAhora.Checked) {
                                                Paso = Inicial.Pasos.InstalarServidor;
                                        } else if (CheckConfigAvanzada.Checked) {
                                                using (Config.ConfigurarBd ConfigBD = new Config.ConfigurarBd()) {
                                                        this.Hide();
                                                        if (ConfigBD.ShowDialog() == DialogResult.Cancel) {
                                                                this.Show();
                                                        } else {
                                                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                                                this.Close();
                                                        }
                                                }
                                        }
                                        break;
                                case Inicial.Pasos.NombreServidor:
                                        if (EntradaServidor.Text.Length == 0) {
                                                Lui.Forms.MessageBox.Show("Por favor escriba el nombre del equipo.", "Error");
                                        } else {
                                                Paso = Inicial.Pasos.PruebaServidor;
                                        }
                                        break;
                                case Inicial.Pasos.PruebaServidor:
                                        if (Lfx.Workspace.Master.MasterConnection.IsOpen() && Lfx.Workspace.Master.IsPrepared()) {
                                                int PaisActual = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Pais", 0);
                                                if (PaisActual == 0)
                                                        Paso = Pasos.DatosEmpresa;
                                                else
                                                        Paso = Pasos.Final;
                                        } else {
                                                Paso = Inicial.Pasos.Final;
                                        }
                                        break;
                                case Pasos.DatosEmpresa:
                                        if (EntradaPais.Elemento == null || EntradaEmpresaNombre.Text.Length < 3 || EntradaEmpresaEmail.Text.Length < 3 || EntradaEmpresaEmail.Text.IndexOf('@') < 0) {
                                                Lui.Forms.MessageBox.Show("Por favor proporcione los datos de la empresa antes de continuar.", "Error");
                                        } else {
                                                Paso = Pasos.Final;
                                        }
                                        break;
                                case Inicial.Pasos.Final:
                                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                        this.Close();
                                        return;
                                case Inicial.Pasos.InstalarServidor:
                                        if (BotonInstalar.Enabled)
                                                BotonInstalar.PerformClick();
                                        else
                                                this.Paso = 0;
                                        break;
                        }
                        this.MostrarPaneles();
                }

                private void BotonAnterior_Click(object sender, EventArgs e)
                {
                        BotonSiguiente.Visible = true;
                        switch (Paso) {
                                case Inicial.Pasos.NombreServidor:
                                        Paso = Inicial.Pasos.SeleccionarAlmacen;
                                        break;
                                case Inicial.Pasos.PruebaServidor:
                                        if (RadioInicioInstalacionLocal.Checked)
                                                Paso = Inicial.Pasos.Inicio;
                                        else if (CheckEsteEquipo.Checked)
                                                Paso = Inicial.Pasos.SeleccionarAlmacen;
                                        else if (CheckOtroEquipo.Checked)
                                                Paso = Inicial.Pasos.NombreServidor;
                                        break;
                                case Inicial.Pasos.Deteccion:
                                case Inicial.Pasos.InstalarServidor:
                                case Inicial.Pasos.Final:
                                case Inicial.Pasos.DatosEmpresa:
                                default:
                                        Paso = Inicial.Pasos.Inicio;
                                        break;
                        }
                        this.MostrarPaneles();
                }

                private void BotonConfiguracionAvanzada_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        using (Config.ConfigurarBd ConfigBD = new Config.ConfigurarBd()) {
                                this.Hide();
                                if (ConfigBD.ShowDialog() == DialogResult.Cancel) {
                                        this.Show();
                                } else {
                                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                        this.Close();
                                }
                        }
                }

                private void PanelInstalarAhora_VisibleChanged(object sender, EventArgs e)
                {
                        if (PanelInstalacion.Visible) {
                                BotonInstalar.Enabled = true;
                                BotonInstalar.Visible = true;
                                EtiquetaDescargando.Text = "Haga clic en el botón 'Instalar' para descargar e instalar un servidor SQL en este equipo.";
                                ProgresoDescargando.Visible = false;
                                if (System.IO.File.Exists(Lfx.Environment.Folders.ApplicationFolder + @"..\WebInstall\InstalarMariaDB.exe"))
                                        BotonInstalar.PerformClick();
                        } else {
                                if (this.ThreadDescargar != null) {
                                        this.ThreadDescargar.Abort();
                                        this.ThreadDescargar = null;
                                }
                        }
                }

                private void PanelDeteccion_VisibleChanged(object sender, EventArgs e)
                {
                        if (PanelDeteccion.Visible) {
                                EtiquetaBuscando.Text = "Detectando configuración...";
                                this.DetectarConfig();
                        } else {
                                if (this.ThreadBuscar != null) {
                                        this.ThreadBuscar.Abort();
                                        this.ThreadBuscar = null;
                                }
                        }
                }

                private bool Inited = false;
                private void Inicial_Activated(object sender, EventArgs e)
                {
                        if (Inited == false) {
                                Inited = true;
                                this.MostrarPaneles();
                        }
                }

                private void BotonInstalar_Click(object sender, EventArgs e)
                {
                        BotonInstalar.Enabled = false;
                        BotonSiguiente.Enabled = false;
                        EtiquetaDescargando.Text = "Descargando, por favor aguarde...";
                        EtiquetaDescargando.Visible = true;
                        ProgresoDescargando.Visible = true;

                        if (this.ThreadDescargar != null) {
                                this.ThreadDescargar.Abort();
                                this.ThreadDescargar = null;
                        }

                        Lfx.Types.OperationProgress Progreso = new Lfx.Types.OperationProgress("Instalar servidor SQL", "Se está descargando, instalando y configurando un servidor SQL en este equipo");
                        Progreso.Advertise = false;
                        Progreso.Modal = false;
                        Progreso.Begin();

                        System.Threading.ThreadStart Buscar = delegate { this.DescargarEInstalar(Progreso); };
                        this.ThreadDescargar = new System.Threading.Thread(Buscar);
                        this.ThreadDescargar.IsBackground = true;
                        this.ThreadDescargar.Start();

                        while (Progreso != null && Progreso.IsRunning) {
                                System.Threading.Thread.Sleep(100);
                                EtiquetaDescargando.Text = Progreso.Status;
                                System.Windows.Forms.Application.DoEvents();
                                if (this.ThreadDescargar == null)
                                        // Cancelar
                                        return;
                        }

                        EtiquetaDescargando.Text = "Continuando...";
                        Paso = Inicial.Pasos.DatosEmpresa;
                        this.MostrarPaneles();
                }

                private void DescargarEInstalar(Lfx.Types.OperationProgress progreso)
                {
                        string InstaladorMariaDb = "InstalarMariaDB.exe";
                        string CarpetaDescarga;

                        if (System.IO.File.Exists(Lfx.Environment.Folders.ApplicationFolder + @"..\WebInstall\" + InstaladorMariaDb)) {
                                CarpetaDescarga = Lfx.Environment.Folders.ApplicationFolder + @"..\WebInstall\";
                        } else {
                                progreso.ChangeStatus("Descargando, por favor aguarde...");
                                CarpetaDescarga = Lfx.Environment.Folders.TemporaryFolder;
                                Lfx.Environment.Folders.EnsurePathExists(CarpetaDescarga);
                                using (WebClient Cliente = new WebClient()) {
                                        try {
                                                Cliente.DownloadFile("http://www.lazarogestion.com/aslnlwc/" + InstaladorMariaDb, CarpetaDescarga + InstaladorMariaDb);
                                        } catch (Exception ex) {
                                                progreso.ChangeStatus("Error al descargar: " + ex.Message);
                                        }
                                }
                        }

                        if (System.IO.File.Exists(CarpetaDescarga + InstaladorMariaDb)) {
                                progreso.ChangeStatus("Instalando...");
                                try {
                                        Lfx.Environment.Shell.Execute(CarpetaDescarga + InstaladorMariaDb, "/verysilent /sp- /norestart", System.Diagnostics.ProcessWindowStyle.Normal, true);
                                } catch (Exception ex) {
                                        progreso.ChangeStatus("Error al instalar: " + ex.Message);
                                }
                        }

                        Lfx.Workspace.Master.ConnectionParameters.ServerName = "localhost";
                        Lfx.Workspace.Master.ConnectionParameters.UserName = "root";
                        Lfx.Workspace.Master.ConnectionParameters.Password = "";
                        Lfx.Data.DatabaseCache.DefaultCache.AccessMode = Lfx.Data.AccessModes.MySql;
                        Lfx.Data.DatabaseCache.DefaultCache.SlowLink = false;
                        Lfx.Workspace.Master.ConnectionParameters.DatabaseName = "";

                        Lfx.Types.OperationResult Res = this.ProbarServidor();
                        if (Res.Success) {
                                if (Lfx.Workspace.Master.IsPrepared() == false)
                                        Lfx.Workspace.Master.Prepare(progreso);
                                progreso.End();
                        } else {
                                Lfx.Workspace.Master.RunTime.Toast("No se puede descargar o instalar el servidor SQL. Puede volver atrás para intentarlo nuevamente o salir para instalarlo de forma manual.", "Error");
                        }
                }

                private void BotonDetectar_Click(object sender, EventArgs e)
                {
                        Paso = Pasos.Deteccion;
                        this.MostrarPaneles();
                }

                private void BotonConfiguracionAvanzada2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        Paso = Pasos.SeleccionarAlmacen;
                        MostrarPaneles();
                }

                private void EntradaPais_TextChanged(object sender, EventArgs e)
                {
                        Lbl.Entidades.Pais Pais = EntradaPais.Elemento as Lbl.Entidades.Pais;
                        if (Pais != null) {
                                if (Pais.ClavePersonasJuridicas != null)
                                        EtiquetaClaveTributaria.Text = Pais.ClavePersonasJuridicas.ToString();
                                else
                                        EtiquetaClaveTributaria.Text = "Clave tributaria";
                        } else {
                                EtiquetaClaveTributaria.Text = "Clave tributaria";
                        }
                }

                private void PanelDatosEmpresa_VisibleChanged(object sender, EventArgs e)
                {
                        if (PanelDatosEmpresa.Visible) {
                                // Al aparecer
                                Lfx.Workspace.Master.CurrentConfig.ClearCache();
                                EntradaEmpresaNombre.Text = Lbl.Sys.Config.Empresa.Nombre;
                                int IdPais = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Pais", 0);
                                EntradaPais.ValueInt = IdPais;
                                if (Lbl.Sys.Config.Empresa.ClaveTributaria != null)
                                        EntradaEmpresaClaveTributaria.Text = Lbl.Sys.Config.Empresa.ClaveTributaria.Valor;
                                EntradaEmpresaEmail.Text = Lbl.Sys.Config.Empresa.Email;
                                EntradaEmpresaNombre.Focus();
                        } else {
                                // Al desaparecer
                                Lbl.Entidades.Pais Pais = EntradaPais.Elemento as Lbl.Entidades.Pais;
                                if (Pais != null)
                                        Lbl.Sys.Config.CambiarPais(Pais);
                                Lbl.Sys.Config.Empresa.Nombre = EntradaEmpresaNombre.Text;
                                if (EntradaEmpresaClaveTributaria.Text.Length > 0)
                                        Lbl.Sys.Config.Empresa.ClaveTributaria = new Lbl.Personas.Claves.Cuit(EntradaEmpresaClaveTributaria.Text);
                                else
                                        Lbl.Sys.Config.Empresa.ClaveTributaria = null;
                                Lbl.Sys.Config.Empresa.Email = EntradaEmpresaEmail.Text;
                        }
                }
        }
}