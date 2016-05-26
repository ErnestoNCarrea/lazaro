using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Lbl.Test
{
        [SetUpFixture]
        public class Setup
        {
                public static Lfx.Data.Connection Connection;
                public static System.Data.IDbTransaction Trans;

                public Setup() { }

                [OneTimeSetUp]
                public void OneTimeSetUp()
                {
                        Lfx.Workspace.Master = new Lfx.Workspace("test", false, false);
                        Lfx.Workspace.Master.DebugMode = true;
                        Lfx.Workspace.Master.TraceMode = true;
                        
                        // Habilito el gestor de configuración
                        Lbl.Sys.Config.Actual = new Lbl.Sys.Configuracion.Global();
                        Lbl.Sys.Config.Cargar();
                        
                        // Habilito la recuperación de conexiones
                        Lfx.Workspace.Master.MasterConnection.EnableRecover = true;

                        //Lbl.Componentes.Cargador.CargarComponentes();

                        Connection = Lfx.Workspace.Master.GetNewConnection("Pruebas unitarias");
                        Trans = Connection.BeginTransaction();
                        
                }

                [OneTimeTearDown]
                public void OneTimeTearDown()
                {
                        Trans.Rollback();
                        Connection.Close();
                }
        }
}
