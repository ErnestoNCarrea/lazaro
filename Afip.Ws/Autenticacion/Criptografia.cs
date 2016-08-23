using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Afip.Ws.Autenticacion
{
        public class Criptografia
        {
                public static SignedCms CrearCmsFirmado(string mensaje, X509Certificate2 argCertFirmante)
                {
                        byte[] MensajeBytes = Encoding.UTF8.GetBytes(mensaje);

                        // Pongo el mensaje en un objeto ContentInfo (requerido para construir el obj SignedCms)
                        SignedCms CmsFirmado = new SignedCms(new ContentInfo(MensajeBytes));

                        // Creo objeto CmsSigner que tiene las caracteristicas del firmante 
                        CmsSigner CmsFirmante = new CmsSigner(argCertFirmante);
                        CmsFirmante.IncludeOption = X509IncludeOption.EndCertOnly;

                        // Firmo el mensaje PKCS #7 
                        CmsFirmado.ComputeSignature(CmsFirmante);

                        return CmsFirmado;
                }
        }
}
