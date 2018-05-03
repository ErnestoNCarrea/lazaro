using NUnit.Framework;

namespace Lbl.Test
{
        [SetUpFixture]
        public class Setup
        {
                public static Lfx.Data.Connection Connection;

                public Setup() { }

                [OneTimeSetUp]
                public void OneTimeSetUp()
                {
                        Lfx.Workspace.Master = new Lfx.Workspace("test", false, false);
                        Lfx.Workspace.Master.DebugMode = true;
                        
                        // Habilito el gestor de configuración
                        Lbl.Sys.Config.Actual = new Lbl.Sys.Configuracion.Global();
                        Lbl.Sys.Config.Cargar();
                        
                        // Habilito la recuperación de conexiones
                        Lfx.Workspace.Master.MasterConnection.EnableRecover = false;

                        //Lbl.Componentes.Cargador.CargarComponentes();

                        System.Console.WriteLine("Iniciando una conexión");
                        Connection = Lfx.Workspace.Master.GetNewConnection("Pruebas unitarias " + this.GetType().FullName) as Lfx.Data.Connection;
                }

                [OneTimeTearDown]
                public void OneTimeTearDown()
                {
                        if (Connection != null && Connection.IsOpen())
                        {
                                Connection.Close();
                        }
                }
        }
}
