using System;

namespace Lbl.Test
{
        public class Program
        {
                public static int Main(string[] args)
                {
                        new TestSetup().OneTimeSetUp();

                        var Tst = new Entity.Comprobantes.FacturaTest();
                        Tst.CrearTransaccion();
                        Tst.ProbarFacturaAConIvaEnCtaCte();
                        Tst.DesecharTransaccion();

                        new TestSetup().OneTimeTearDown();

                        System.Console.ReadLine();

                        return 0;
                }
        }
}