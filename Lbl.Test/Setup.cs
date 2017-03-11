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
                        
                        // Habilito el gestor de configuración
                        Lbl.Sys.Config.Actual = new Lbl.Sys.Configuracion.Global();
                        Lbl.Sys.Config.Cargar();
                        
                        // Habilito la recuperación de conexiones
                        Lfx.Workspace.Master.MasterConnection.EnableRecover = false;

                        //Lbl.Componentes.Cargador.CargarComponentes();

                        Connection = Lfx.Workspace.Master.GetNewConnection("Pruebas unitarias") as Lfx.Data.Connection;
                        Trans = Connection.BeginTransaction();
                        
                }

                [OneTimeTearDown]
                public void OneTimeTearDown()
                {
                        if (Trans != null)
                        {
                                Trans.Rollback();
                        }

                        if (Connection != null && Connection.IsOpen())
                        {
                                Connection.Close();
                        }
                }
        }
}
