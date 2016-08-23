using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lazaro.Base
{
        public class Prueba
        {
                public static int Main(string[] args)
                {
                        var Archivo = @"C:\Projects\ap.pdf";

                        var Gen = new Util.Comprobantes.GeneradorPdf(null);
                        Gen.GenerarFactura().Save(Archivo);

                        ProcessStartInfo psi = new ProcessStartInfo(Archivo);
                        psi.UseShellExecute = true;
                        Process.Start(psi);
                        return 0;
                }
        }
}
