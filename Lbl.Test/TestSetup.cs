using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Lbl.Test
{
        [SetUpFixture]
        public class TestSetup
        {
                public static Lfx.Data.Connection Connection;
                public static System.Data.IDbTransaction Trans;

                public TestSetup()
                {
                }

                [OneTimeSetUp]
                public virtual void OneTimeSetUp()
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

                        Lbl.Sys.Config.Actual.UsuarioConectado = new Sys.Configuracion.UsuarioConectado(new Personas.Usuario(Connection, 1));
                }

                [OneTimeTearDown]
                public virtual void OneTimeTearDown()
                {
                        if (Connection != null && Connection.IsOpen()) {
                                Connection.Close();
                        }
                }
        }
}
