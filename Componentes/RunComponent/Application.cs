using System;
using System.Diagnostics;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RunComponent
{
	/// <summary>
	/// Permite ejecutar un componente Lfx desde la línea de comandos.
	/// </summary>
	public class Application
	{
		//[STAThread]
                public static void Main(string[] args)
                {

                        //Console.WriteLine("RunComponent");
                        //Console.WriteLine("    Ejecuta un componente Lfx fuera del entorno de Lázaro.");
                        //Console.WriteLine("    Copyright 2004-2016 Ernesto N. Carrea");
                        //Console.WriteLine("");
                        System.Windows.Forms.Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ThreadExceptionHandler);
                        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandler);
                        System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

                        string ComponentName = null, FunctionName = null;
                        if (args.Length == 2) {
                                ComponentName = args[0];
                                FunctionName = args[1];
                        } else if (args.Length == 1) {
                                ComponentName = args[0];
                                FunctionName = args[0];
                        } else if (args.Length == 0) {
                                ComponentName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location);
                                FunctionName = ComponentName;
                        }

                        Lfx.Workspace.Master = new Lfx.Workspace("default");
                        Lbl.Sys.Config.Actual = new Lbl.Sys.Configuracion.Global();
                        Lbl.Sys.Config.Cargar();

                        if (ComponentName != null && FunctionName != null) {
                                //Console.WriteLine("Ejecutando " + ComponentName + "." + FunctionName);
                                Lbl.Componentes.Componente Comp = new Lbl.Componentes.Componente(Lfx.Workspace.Master.GetNewConnection(ComponentName) as Lfx.Data.Connection);
                                Comp.Crear();
                                Comp.Nombre = ComponentName;
                                Comp.EspacioNombres = ComponentName;
                                Lfx.Components.Manager.RegisterComponent(Comp);

                                Lfx.Components.Function Funcion = null;
                                try {
                                        Funcion = Comp.Funciones[FunctionName].Instancia;
                                } catch (Exception ex) {
                                        System.Windows.Forms.MessageBox.Show(ex.ToString(), "Error");
                                }
                                if (Funcion != null) {
                                        Funcion.Workspace = Lfx.Workspace.Master;
                                        Funcion.ExecutableName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                                        Funcion.Arguments = Environment.GetCommandLineArgs();
                                        Funcion.Run(true);
                                } else {
                                        System.Windows.Forms.MessageBox.Show("No se puede ejecutar " + ComponentName + "." + FunctionName, "Error");
                                }
                        } else {
                                Console.WriteLine("Uso:");
                                Console.WriteLine("    RunComponent [NombreComponente] [NombreFuncion]");
                                Console.WriteLine("        Si no se especifica NombreFuncion, se asume igual que NombreComponente.");
                                Console.WriteLine("        Si no se especifica NombreComponente, se asume el nombre de este ejecutable.");
                        }
                }

                public static void ThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
                {
                        ExceptionHandler(e.Exception);
                }

                private static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs args)
                {
                        ExceptionHandler(args.ExceptionObject as Exception);
                }

                public static void ExceptionHandler(Exception ex)
                {
                        System.Text.StringBuilder Texto = new System.Text.StringBuilder();
                        Texto.AppendLine("Lugar   : " + ex.Source);
                        try {
                                System.Diagnostics.StackTrace Traza = new System.Diagnostics.StackTrace(ex, true);
                                Texto.AppendLine("Línea   : " + Traza.GetFrame(0).GetFileLineNumber());
                                Texto.AppendLine("Columna : " + Traza.GetFrame(0).GetFileColumnNumber());
                        }
                        catch {
                                //Nada
                        }
                        Texto.AppendLine("Equipo  : " + Lfx.Environment.SystemInformation.MachineName);
                        Texto.AppendLine("Plataf. : " + Lfx.Environment.SystemInformation.Platform);
                        Texto.AppendLine("RunTime : " + Lfx.Environment.SystemInformation.RunTime);
                        Texto.AppendLine("Excepción no controlada: " + ex.ToString());
                        Texto.AppendLine("");

                        Texto.AppendLine("Lazaro versión " + System.Diagnostics.FileVersionInfo.GetVersionInfo(Lfx.Environment.Folders.ApplicationFolder + "Lazaro.exe").ProductVersion + " del " + new System.IO.FileInfo(Lfx.Environment.Folders.ApplicationFolder + "Lazaro.exe").LastWriteTime.ToString());
                        System.IO.DirectoryInfo Dir = new System.IO.DirectoryInfo(Lfx.Environment.Folders.ApplicationFolder);
                        foreach (System.IO.FileInfo DirItem in Dir.GetFiles("*.dll")) {
                                Texto.AppendLine(DirItem.Name + " versión " + System.Diagnostics.FileVersionInfo.GetVersionInfo(DirItem.FullName).ProductVersion + " del " + new System.IO.FileInfo(DirItem.FullName).LastWriteTime.ToString());
                        }

                        Dir = new System.IO.DirectoryInfo(Lfx.Environment.Folders.ComponentsFolder);
                        foreach (System.IO.FileInfo DirItem in Dir.GetFiles("*.dll")) {
                                Texto.AppendLine(DirItem.Name + " versión " + System.Diagnostics.FileVersionInfo.GetVersionInfo(DirItem.FullName).ProductVersion + " del " + new System.IO.FileInfo(DirItem.FullName).LastWriteTime.ToString());
                        }

                        Texto.AppendLine("Traza:");
                        Texto.AppendLine(ex.StackTrace);

                        MailMessage Mensaje = new MailMessage();
                        Mensaje.To.Add(new MailAddress("error@lazarogestion.com"));
                        Mensaje.From = new MailAddress(Lbl.Sys.Config.Actual.UsuarioConectado.Id.ToString() + "@" + Lfx.Environment.SystemInformation.MachineName, Lbl.Sys.Config.Actual.UsuarioConectado.Nombre + " en " + Lbl.Sys.Config.Empresa.Nombre);
                        try {
                                //No sé por qué, pero una vez dió un error al poner el asunto
                                Mensaje.Subject = ex.Message;
                        }
                        catch {
                                Mensaje.Subject = "Excepción no controlada";
                                Texto.Insert(0, ex.Message + System.Environment.NewLine);
                        }

                        Mensaje.Body = Texto.ToString();

                        SmtpClient Cliente = new SmtpClient("mail.lazarogestion.com");
                        try {
                                Cliente.Send(Mensaje);
                        }
                        catch {
                                // Nada
                        }
                }
	}
}
