using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Lazaro.WinMain.Principal
{
        public partial class Inicio : Form
        {
                private System.Threading.Thread AdminNotif = null;
                public Lfx.Types.ShowProgressDelegate ShowProgress = null;
                private Lfc.Inicio.Inicio FormInicio = null;

                private static System.Collections.Generic.Dictionary<string, MenuItemInfo> MenuItemInfoTable = null;

                public Inicio()
                {
                        InitializeComponent();

                        ShowProgress = new Lfx.Types.ShowProgressDelegate(ShowProgressRoutine);

                        Lbl.Notificaciones.Administrador.Principal = new Lbl.Notificaciones.Administrador();
                        //Lbl.Notificaciones.Administrador.Principal.Iniciar();
                        // Inicio el administrador de notificaciones en un nuevo thread
                        System.Threading.ThreadStart ParamInicio = delegate { Lbl.Notificaciones.Administrador.Principal.Iniciar(); };
                        this.AdminNotif = new System.Threading.Thread(ParamInicio);
                        this.AdminNotif.SetApartmentState(System.Threading.ApartmentState.STA);
                        this.AdminNotif.Start();
                }


                public void ShowProgressRoutine(Lfx.Types.OperationProgress progreso)
                {
                        this.BarraInferior.ShowProgressRoutine(progreso);
                }


                private void FormPrincipal_Load(object sender, EventArgs e)
                {
                        this.CargarMenuPrincipal();

                        //De forma predeterminada, se usa modo maximizado
                        string ModoPredeterminado = "maximizado";
                        if (Lfx.Environment.SystemInformation.RunTime != Lfx.Environment.SystemInformation.RunTimes.DotNet) {
                                //Pero se usa el modo flotante fuera del entorno .NET ya que Mono no tiene buen soporte MDI
                                //y en Linux el modo MDI no es bienvenido
                                ModoPredeterminado = "flotante";
                        }

                        BarraInferior.Visible = Lfx.Workspace.Master.CurrentConfig.ReadLocalSettingInt("Sistema", "Apariencia.BarraInformacion", 1) != 0;
                        switch (Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Apariencia.ModoPantalla", ModoPredeterminado)) {
                                case "normal":
                                        this.Text = "Lázaro - " + Lbl.Sys.Config.Actual.UsuarioConectado.Persona.Nombres + " en " + Lfx.Workspace.Master.ToString();
                                        break;
                                case "maximizado":
                                        this.WindowState = FormWindowState.Maximized;
                                        this.Text = "Lázaro - " + Lbl.Sys.Config.Actual.UsuarioConectado.Persona.Nombres + " en " + Lfx.Workspace.Master.ToString();
                                        break;
                                case "completo":
                                        this.Text = "";
                                        this.ControlBox = false;
                                        this.WindowState = FormWindowState.Maximized;
                                        break;
                                case "flotante":
                                        Aplicacion.Flotante = true;
                                        this.BarraTareas.Visible = false;
                                        this.Height = 108;
                                        this.MinimumSize = new Size(128, 112);
                                        if (Lfx.Environment.SystemInformation.Platform == Lfx.Environment.SystemInformation.Platforms.Windows)
                                                //Sólo Windows permite la combinación de MaximumSize y Maximized
                                                this.WindowState = FormWindowState.Maximized;
                                        else
                                                this.Top = 20;
                                        break;
                        }

                        if (Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Apariencia.NoMostrarInicio", 0) == 0) {
                                FormInicio = new Lfc.Inicio.Inicio();
                                FormInicio.MdiParent = this;
                                FormInicio.Show();
                                MostrarAyuda("Bienvenido a Lázaro", "Pulse la tecla <F12> para mostrar la pantalla de inicio.");
                        } else {
                                MostrarAyuda("Bienvenido a Lázaro", "Pulse la tecla <F12> para activar el menú principal.");
                        }
                }


                private static bool YaPregunteReiniciar = false;
                private static bool YaSubiEstadisticas = false;
                private void TimerProgramador_Tick(object sender, EventArgs e)
                {
                        TimerProgramador.Stop();

                        if (this.Visible) {
                                //Ejecuto tareas del programador
                                Lfx.Services.Task ProximaTarea = null;
                                // En conexiones lentas, 1 vez por minuto
                                // En conexiones rápidas, cada 5 segundos
                                if (Lfx.Workspace.Master.SlowLink) {
                                        if (Lfx.Workspace.Master.DefaultScheduler.LastGetTask == System.DateTime.MinValue || (DateTime.Now - Lfx.Workspace.Master.DefaultScheduler.LastGetTask).Minutes >= 1)
                                                ProximaTarea = Lfx.Workspace.Master.DefaultScheduler.GetNextTask("lazaro");
                                } else {
                                        if (Lfx.Workspace.Master.DefaultScheduler.LastGetTask == System.DateTime.MinValue || (DateTime.Now - Lfx.Workspace.Master.DefaultScheduler.LastGetTask).Seconds >= 5)
                                                ProximaTarea = Lfx.Workspace.Master.DefaultScheduler.GetNextTask("lazaro");
                                }

                                if (ProximaTarea != null) {
                                        // Lanzo la tarea en un nuevo thread
                                        System.Threading.ThreadStart ParamInicio = delegate { Ejecutor.Exec(ProximaTarea.Command, ProximaTarea.ComputerName); };
                                        new System.Threading.Thread(ParamInicio).Start();
                                }

                                if (YaSubiEstadisticas == false && Lfx.Workspace.Master.DebugMode == false) {
                                        YaSubiEstadisticas = true;
                                        System.Threading.ThreadStart ParamInicio = delegate { Aplicacion.EnviarEstadisticas(); };
                                        System.Threading.Thread Thr = new System.Threading.Thread(ParamInicio);
                                        Thr.IsBackground = true;
                                        Thr.Start();
                                }

                                if (YaPregunteReiniciar == false && Lfx.Updates.Updater.Master != null && Lfx.Updates.Updater.Master.UpdatesPending() && ActiveForm == this) {
                                        YaPregunteReiniciar = true;
                                        Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("Existe una nueva versión de Lázaro. Debe reiniciar la aplicación para instalar la actualización.", "¿Desea reiniciar ahora?");
                                        Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                                        DialogResult Respuesta = Pregunta.ShowDialog();
                                        if (Respuesta == DialogResult.OK)
                                                Ejecutor.Exec("REBOOT");
                                }
                        }

                        TimerProgramador.Start();
                }


                private void FormPrincipal_KeyDown(object sender, KeyEventArgs e)
                {
                        switch (e.KeyCode) {
                                case Keys.F10:
                                case Keys.F12:
                                        if (e.Shift == false && e.Alt == false && e.Shift == false) {
                                                e.Handled = true;
                                                if (FormInicio == null) {
                                                        MostrarAyuda("Menú principal", "Utilice las teclas de cursor (flechas) para navegar el menú. Pulse <Intro> (o <Enter>) para ejecutar una opción.");
                                                        System.Windows.Forms.SendKeys.Send("%S");
                                                } else {
                                                        MostrarAyuda("Pantalla de inicio", "Si no encuentra lo que busca en la pantalla de inicio utilice el menú en la parte superior.");
                                                        FormInicio.Focus();
                                                }
                                        }
                                        break;
                                case Keys.I:
                                        if (e.Control == true && e.Alt == true && Lbl.Sys.Config.Actual.UsuarioConectado.TieneAccesoGlobal()) {
                                                e.Handled = true;
                                                System.Windows.Forms.OpenFileDialog DialogoArchivo = new System.Windows.Forms.OpenFileDialog();
                                                DialogoArchivo.DefaultExt = "sql";
                                                DialogoArchivo.Filter = "Archivo SQL|*.sql";
                                                DialogoArchivo.Multiselect = false;
                                                DialogoArchivo.Title = "Inyectar SQL";
                                                if (DialogoArchivo.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                                                        using (System.IO.Stream Archivo = System.IO.File.OpenRead(DialogoArchivo.FileName))
                                                        using (System.IO.StreamReader Lector = new System.IO.StreamReader(Archivo, System.Text.Encoding.Default))
                                                        using (Lfx.Data.Connection ConexionActualizar = Lfx.Workspace.Master.GetNewConnection("Inyectar SQL"))
                                                        using (IDbTransaction Trans = ConexionActualizar.BeginTransaction()) {
                                                                string SqlActualizacion = ConexionActualizar.CustomizeSql(Lector.ReadToEnd());
                                                                do {
                                                                        string Comando = Lfx.Data.Connection.GetNextCommand(ref SqlActualizacion);
                                                                        try {
                                                                                ConexionActualizar.ExecuteSql(Comando);
                                                                        } catch (Exception ex) {
                                                                                Lfx.Workspace.Master.RunTime.Toast(Comando + System.Environment.NewLine + System.Environment.NewLine + ex.Message, "Error al inyectar datos");
                                                                        }
                                                                }
                                                                while (SqlActualizacion.Length > 0);
                                                                Trans.Commit();
                                                        }
                                                }
                                        }
                                        break;
                                case Keys.B:
                                        if (e.Control && e.Alt == false && e.Shift == false) {
                                                e.Handled = true;
                                                BarraInferior.Visible = !BarraInferior.Visible;
                                                Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("Sistema", "Apariencia.BarraInformacion", BarraInferior.Visible ? 1 : 0);
                                        }
                                        break;
                                case Keys.J:
                                        if (e.Control == true && e.Alt == false && e.Shift == false) {
                                                e.Handled = true;
                                                string Cmd = Lui.Forms.InputBox.ShowInputBox("Comando");
                                                if (Cmd != null && Cmd.Length > 0)
                                                        Ejecutor.Exec(Cmd);
                                        }
                                        break;
                                case Keys.F:
                                        if (e.Control == true && e.Alt == false && e.Shift == false) {
                                                e.Handled = true;
                                                Ejecutor.Exec("CREAR Lbl.Comprobantes.Factura");
                                        }
                                        break;
                                case Keys.T:
                                        if (e.Control == true && e.Alt == false && e.Shift == false) {
                                                e.Handled = true;
                                                Ejecutor.Exec("CREAR Lbl.Comprobantes.Ticket");
                                        }
                                        break;
                                case Keys.P:
                                        if (e.Control == true && e.Alt == false && e.Shift == false) {
                                                e.Handled = true;
                                                Ejecutor.Exec("CREAR Lbl.Comprobantes.Presupuesto");
                                        }
                                        break;
                                case Keys.R:
                                        if (e.Control == true && e.Alt == false && e.Shift == false) {
                                                e.Handled = true;
                                                Ejecutor.Exec("CREAR Lbl.Comprobantes.ReciboDeCobro");
                                        }
                                        break;
                                case Keys.L:
                                        if (e.Control == true && e.Alt == false && e.Shift == false) {
                                                e.Handled = true;
                                                Ejecutor.Exec("CALC");
                                        }
                                        break;
                        }
                }


                protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
                {
                        if (AdminNotif != null) {
                                AdminNotif.Abort();
                                AdminNotif = null;
                        }
                        TimerProgramador.Stop();

                        if (Lfx.Workspace.Master != null)
                                Lfx.Workspace.Master.Dispose();

                        base.OnClosing(e);
                }


                // **************************************************************************************************
                // **************************************************************************************************
                // **************************************************************************************************
                // Ayuda Dinámica
                // **************************************************************************************************
                // **************************************************************************************************
                // **************************************************************************************************

                public void MostrarItem(string tabla, int item)
                {
                        if (BarraInferior.Visible)
                                BarraInferior.MostrarItem(tabla, item);
                }


                public void MostrarAyuda(string titulo, string texto)
                {
                        if (BarraInferior.Visible)
                                BarraInferior.MostrarAyuda(titulo, texto);
                }


                // **************************************************************************************************
                // **************************************************************************************************
                // **************************************************************************************************
                // Sistema de Menú
                // **************************************************************************************************
                // **************************************************************************************************
                // **************************************************************************************************

                private void CargarMenuComponentes()
                {
                        foreach (Lfx.Components.IComponent CompInfo in Lfx.Components.Manager.ComponentesCargados.Values) {
                                // Registro el componente
                                Lfx.Types.OperationResult Res = Lfx.Components.Manager.RegisterComponent(CompInfo);

                                if (Res.Success == false && Res.Message != null)
                                        Lui.Forms.MessageBox.Show(Res.Message, "Error");

                                if (CompInfo != null && CompInfo.MenuEntries != null) {
                                        foreach (Lfx.Components.MenuEntry MenuItem in CompInfo.MenuEntries) {
                                                //Busco el Parent
                                                MenuItem ColgarDe = null;
                                                MenuItemInfo ItmInfo;
                                                foreach (MenuItemInfo ItemInfo in MenuItemInfoTable.Values) {
                                                        if (ItemInfo.ParentText + "." + ItemInfo.Text == ("Menu." + MenuItem.Parent).QuitarAcentos()) {
                                                                ColgarDe = ItemInfo.Item;
                                                                break;
                                                        }
                                                }
                                                if (ColgarDe == null) {
                                                        //Si no hay de donde colgarlo, lo creo
                                                        ColgarDe = new MenuItem(MenuItem.Parent, new System.EventHandler(Menu_Click));
                                                        ItmInfo = new MenuItemInfo();
                                                        ItmInfo.Item = ColgarDe;
                                                        ItmInfo.Funcion = "";
                                                        ItmInfo.ParentText = "Menu".QuitarAcentos();
                                                        ItmInfo.Text = MenuItem.Parent.QuitarAcentos();

                                                        AgregarAlMenu(this.MainMenu, ColgarDe, ItmInfo);
                                                }

                                                MenuItem Itm = new MenuItem(MenuItem.Name, new System.EventHandler(Menu_Click));
                                                ItmInfo = new MenuItemInfo();
                                                ItmInfo.Item = Itm;
                                                ItmInfo.Funcion = MenuItem.Function;
                                                ItmInfo.ParentText = "Menu." + MenuItem.Parent.QuitarAcentos();
                                                ItmInfo.Text = MenuItem.Name.QuitarAcentos();
                                                AgregarAlMenu(ColgarDe, Itm, ItmInfo);
                                        }
                                }
                        }
                }

                /// <summary>
                /// Crea el menú Sistema y algunas opciones fijas (Acerca de..., Salir, etc.),
                /// y carga el resto del menú desde un archivo XML.
                /// </summary>
                private void CargarMenuPrincipal()
                {
                        // Vacío el menú
                        MenuItemInfoTable = new Dictionary<string, MenuItemInfo>();
                        Aplicacion.FormularioPrincipal.MainMenu.MenuItems.Clear();

                        System.Xml.XmlDocument MenuXml = new XmlDocument();
                        MenuXml.Load(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Lazaro.Principal.menu.xml"));

                        CargarMenuXml(MenuXml.GetElementsByTagName("Menu").Item(0), Aplicacion.FormularioPrincipal.MainMenu, "Menu");

                        CargarMenuComponentes();
                }

                /// <summary>
                /// Carga un menú desde un documento Xml.
                /// </summary>
                private void CargarMenuXml(XmlNode node, Menu colgarDe, string parentText)
                {
                        Lfx.Data.Connection Conn = null;

                        if (node.ChildNodes.Count > 0) {
                                foreach (XmlNode opcion in node.ChildNodes) {
                                        MenuItem Itm = new MenuItem(opcion.Attributes["Nombre"].Value, new System.EventHandler(Menu_Click));

                                        MenuItemInfo ItmInfo = new MenuItemInfo();
                                        ItmInfo.Item = Itm;
                                        if (opcion.Attributes["Funcion"] != null) {
                                                ItmInfo.Funcion = opcion.Attributes["Funcion"].Value;
                                                if (opcion.Attributes["Funcion"].Value == "MDILIST")
                                                        Itm.MdiList = true;
                                        }
                                        ItmInfo.ParentText = parentText.QuitarAcentos();
                                        ItmInfo.Text = opcion.Attributes["Nombre"].Value.QuitarAcentos();

                                        AgregarAlMenu(colgarDe, Itm, ItmInfo);

                                        if (ItmInfo.Funcion == "MENU Lbl.Cajas.Caja")
                                                Itm.Select += new EventHandler(Menu_Select);

                                        string NuevoParentText = null;

                                        if (parentText.Length > 0)
                                                NuevoParentText = parentText + "." + opcion.Attributes["Nombre"].Value;
                                        else
                                                NuevoParentText = opcion.Attributes["Funcion"].Value;

                                        CargarMenuXml(opcion, Itm, NuevoParentText);
                                }
                        }

                        if (Conn != null)
                                Conn.Dispose();
                }

                /// <summary>
                /// Agrega un ítem a un menú y lo hace OwnerDraw.
                /// </summary>
                /// <param name="ColgarDe">Objeto Menu del cual colgar este menú.</param>
                /// <param name="Itm">Objeto Menu que se quiere agregar</param>
                /// <param name="ItmInfo">Estructura con información extendida sobre Itm</param>
                private void AgregarAlMenu(Menu ColgarDe, MenuItem Itm, MenuItemInfo ItmInfo)
                {
                        // Para los tem OwnerDraw, ver las funciones Menu_Select, Menu_MeasureItem y Menu_DrawItem más abajo
                        if (Lfx.Environment.SystemInformation.Platform == Lfx.Environment.SystemInformation.Platforms.Windows) {
                                Itm.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.Menu_MeasureItem);
                                Itm.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Menu_DrawItem);
                                Itm.OwnerDraw = true;
                        }
                        Itm.Tag = Itm.GetHashCode();
                        ColgarDe.MenuItems.Add(Itm);
                        MenuItemInfoTable.Add(Itm.Tag.ToString(), ItmInfo);
                }


                private void Menu_MeasureItem(System.Object sender, System.Windows.Forms.MeasureItemEventArgs e)
                {
                        MenuItem MiItem = ((MenuItem)(sender));

                        if (MiItem.Text == "-") {
                                e.ItemHeight = 4;
                                e.ItemWidth = 24;
                        } else {
                                SizeF ItemSize = e.Graphics.MeasureString(MiItem.Text.Replace("&", ""), Lazaro.Pres.DisplayStyles.Template.Current.MenuFont);

                                if (MiItem.Parent == this.MainMenu) {
                                        e.ItemHeight = System.Convert.ToInt32(ItemSize.Height + 2);
                                        e.ItemWidth = System.Convert.ToInt32(ItemSize.Width);
                                } else {
                                        e.ItemHeight = System.Convert.ToInt32(ItemSize.Height + 8);
                                        e.ItemWidth = System.Convert.ToInt32(ItemSize.Width + 16);

                                        if (e.ItemWidth < 64)
                                                e.ItemWidth = 64;
                                }
                        }
                }

                private void Menu_DrawItem(System.Object sender, System.Windows.Forms.DrawItemEventArgs e)
                {
                        MenuItem MiItem = ((MenuItem)(sender));
                        float MargenX = 12;
                        float MargenY = 4;

                        if (MiItem.Parent == Aplicacion.FormularioPrincipal.MainMenu) {
                                MargenX = 6;
                                MargenY = 2;
                        }

                        StringFormat FormatoTexto = new StringFormat();
                        FormatoTexto.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
                        SolidBrush Fondo = new SolidBrush(System.Drawing.SystemColors.Menu);
                        e.Graphics.FillRectangle(Fondo, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                        // e.Graphics.FillRectangle(New SolidBrush(PaletaCambiarBrillo(SystemColors.Menu, -40)), e.Bounds.X + 1, e.Bounds.Y, 20, e.Bounds.Height - 1)

                        if (MiItem.Text == "-") {
                                e.Graphics.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.SystemColors.ControlDark), e.Bounds.X + 3, e.Bounds.Y + 1, e.Bounds.Width - 6, e.Bounds.Height - 3);
                        } else if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
                                SolidBrush Resalte = new SolidBrush(System.Drawing.SystemColors.Highlight);
                                Pen Recuadro = new Pen(System.Drawing.SystemColors.Highlight);
                                SolidBrush Texto = new SolidBrush(System.Drawing.SystemColors.HighlightText);
                                // e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None
                                e.Graphics.FillRectangle(Resalte, e.Bounds.X + 1, e.Bounds.Y, e.Bounds.Width - 2, e.Bounds.Height - 1);
                                // e.Graphics.FillRectangle(New SolidBrush(PaletaCambiarBrillo(SystemColors.Highlight, 40)), e.Bounds.X + 1, e.Bounds.Y, 20, e.Bounds.Height - 1)
                                e.Graphics.DrawRectangle(Recuadro, e.Bounds.X + 1, e.Bounds.Y, e.Bounds.Width - 2, e.Bounds.Height - 1);
                                e.Graphics.DrawString(MiItem.Text, Lazaro.Pres.DisplayStyles.Template.Current.MenuFont, Texto, e.Bounds.X + MargenX, e.Bounds.Y + MargenY, FormatoTexto);
                                Recuadro.Dispose();
                                Resalte.Dispose();
                                Texto.Dispose();
                        } else if ((e.State & DrawItemState.Disabled) == DrawItemState.Disabled) {
                                SolidBrush Texto = new SolidBrush(System.Drawing.SystemColors.GrayText);
                                // e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None
                                e.Graphics.DrawString(MiItem.Text, Lazaro.Pres.DisplayStyles.Template.Current.MenuFont, Texto, e.Bounds.X + MargenX, e.Bounds.Y + MargenY, FormatoTexto);
                                Texto.Dispose();
                        } else {
                                SolidBrush Texto = new SolidBrush(System.Drawing.SystemColors.MenuText);
                                // e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.None
                                e.Graphics.DrawString(MiItem.Text, Lazaro.Pres.DisplayStyles.Template.Current.MenuFont, Texto, e.Bounds.X + MargenX, e.Bounds.Y + MargenY, FormatoTexto);
                                Texto.Dispose();
                        }
                        Fondo.Dispose();
                }

                /// <summary>
                /// Maneja los eventos Click de los menús
                /// </summary>
                /// <param name="sender"></param>
                /// <param name="e"></param>
                private void Menu_Click(object sender, System.EventArgs e)
                {
                        MenuItem ItemClicked = (MenuItem)sender;
                        MenuItemInfo ItmInfo = MenuItemInfoTable[ItemClicked.Tag.ToString()];

                        int Hits = Lfx.Workspace.Master.CurrentConfig.ReadLocalSettingInt("MenuStats", ItmInfo.FullPath, 0);
                        Lfx.Workspace.Master.CurrentConfig.WriteLocalSetting("MenuStats", ItmInfo.FullPath, Hits + 1);
                        if (ItmInfo.Funcion == "MENU Lbl.Cajas.Caja") {
                                // Nada
                        } else {
                                Ejecutor.Exec(ItmInfo.Funcion);
                        }
                }


                private void Menu_Select(object sender, System.EventArgs e)
                {
                        MenuItem ItemClicked = (MenuItem)sender;
                        MenuItemInfo ItmInfo = MenuItemInfoTable[ItemClicked.Tag.ToString()];

                        if (ItmInfo.Funcion == "MENU Lbl.Cajas.Caja" && ItemClicked.IsParent == false) {
                                DataTable Cajas = Lfx.Workspace.Master.MasterConnection.Select("SELECT id_caja, nombre FROM cajas WHERE estado>0 ORDER BY nombre");

                                foreach (System.Data.DataRow Caja in Cajas.Rows) {
                                        MenuItem ItmH = new MenuItem(Caja["nombre"].ToString(), new System.EventHandler(Menu_Click));
                                        MenuItemInfo ItmInfoH = new MenuItemInfo();
                                        ItmInfoH.Item = ItmH;
                                        ItmInfoH.Funcion = "INSTANCIAR Lfc.Cajas.Movimientos " + Caja["id_caja"].ToString();
                                        ItmInfoH.ParentText = ItmInfo.Text;
                                        ItmInfoH.Text = System.Convert.ToString(Caja["nombre"]).QuitarAcentos();
                                        AgregarAlMenu(ItemClicked, ItmH, ItmInfoH);
                                }
                        }
                }


                /// <summary>
                /// Procesa el resultado de una operación.
                /// Si es un OperationResult, muestra el mensaje.
                /// Si es un formulario, muestra el formulario.
                /// </summary>
                public void ProcesarObjeto(object obj)
                {
                        if (obj is Lfx.Types.OperationResult) {
                                Lfx.Types.OperationResult ResOp = obj as Lfx.Types.OperationResult;
                                if (ResOp.Success == false && ResOp.Message != null)
                                        Lfx.Workspace.Master.RunTime.Toast(ResOp.Message, "Error");
                        } else if (obj is System.Windows.Forms.Form) {
                                System.Windows.Forms.Form ResForm = obj as System.Windows.Forms.Form;

                                if(obj is Lui.Forms.ChildForm) {
                                        ResForm.MdiParent = Aplicacion.FormularioPrincipal;
                                } else if (Aplicacion.Flotante) {
                                        ResForm.WindowState = Aplicacion.FormularioPrincipal.WindowState;
                                        ResForm.Owner = Aplicacion.FormularioPrincipal;
                                }

                                if (ResForm.DialogResult == System.Windows.Forms.DialogResult.Abort) {
                                        Lfx.Workspace.Master.RunTime.Toast("No se puede tener acceso al formulario.", "Error");
                                        ResForm.Dispose();
                                } else {
                                        try {
                                                ResForm.Show();
                                                ResForm.BringToFront();
                                        } catch (ApplicationException ex) {
                                                Lfx.Workspace.Master.RunTime.Toast(ex.Message, "Error");
                                                ResForm.Dispose();
                                        }
                                }
                        } else if (obj != null) {
                                Lfx.Workspace.Master.RunTime.Toast("La operación devolvió un objeto tipo " + obj.GetType().ToString(), "Aviso");
                        }
                }

                public Lfx.Workspace Workspace
                {
                        get
                        {
                                return Lfx.Workspace.Master;
                        }
                }

                private void BarraTareas_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
                {
                        int FormId = ((int)e.ClickedItem.Tag);
                        bool Encontre = false;
                        foreach (Form Frm in this.MdiChildren) {
                                Lui.Forms.ChildForm Frm2 = Frm as Lui.Forms.ChildForm;
                                if (Frm2 != null && Frm2.Uid == FormId) {
                                        Encontre = true;
                                        Frm.Visible = true;
                                        Frm.Show();
                                        Frm.Activate();
                                        break;
                                }
                        }
                        if (Encontre == false)
                                BarraTareas.Items.Remove(e.ClickedItem);
                }
        }
}