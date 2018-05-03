using NUnit.Framework;

namespace Lbl.Test
{
        [TestFixture]
        public class PruebaConDatos
        {
                public PruebaConDatos() { }

                [SetUp]
                public void CrearTransaccion()
                {
                        TestSetup.Trans = TestSetup.Connection.BeginTransaction();
                }

                [TearDown]
                public void DesecharTransaccion()
                {
                        TestSetup.Trans.Rollback();
                }
        }
}
