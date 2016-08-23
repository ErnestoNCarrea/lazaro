using System;
using System.Collections.Generic;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Afip.Ws.Autenticacion
{
        /// <summary>
        /// Cliente del servicio web de Autenticación y Autorización (WSAA).
        /// </summary>
        public class ServicioAutenticacion : ServicioAfip
        {
                // Entero de 32 bits sin signo que identifica el requerimiento 
                // No se usa UInt32 porque no es compatible con CLS
                public static long UniqueId = 1;

                // Identificacion del WSN para el cual se solicita el TA 
                public string Servicio = "wsfe";

                // Identificacion del WSN para el cual se solicita el TA 
                public string UrlWsaa = "http://wsaahomo.afip.gov.ar/ws/services/LoginCms?WSDL";

                // Ruta del certificado X509 (con clave privada) usado para firmar, en formato PKCS 12 (.p12)
                public string RutaCertificado = @"Certificado.p12";

                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public TicketAcceso Autenticar()
                {
                        // Paso 1: Generar el Login Ticket Request 
                        var Tra = this.ObtenerTra();

                        // Paso 2: Firmar el Login Ticket Request 
                        X509Certificate2 CertificadoFirmante = new X509Certificate2(this.RutaCertificado);

                        // Crear un CMS firmado
                        SignedCms CmsFirmado = Criptografia.CrearCmsFirmado(Tra.OuterXml, CertificadoFirmante);

                        // Lo convierto a base 64
                        string CmsFirmadoBase64 = Convert.ToBase64String(CmsFirmado.Encode());

                        // Paso 3: Invocar al WSAA para obtener el Login Ticket Response 
                        var ServicioWsaa = new AfipAutenticacion.LoginCMSClient();
                        // TODO: ServicioWsaa.Url = this.UrlWsaa;

                        string LoginTicketResponse = ServicioWsaa.loginCms(CmsFirmadoBase64);

                        // Paso 4: Analizar el Login Ticket Response recibido del WSAA
                        var XmlLoginTicketResponse = new XmlDocument();
                        XmlLoginTicketResponse.LoadXml(LoginTicketResponse);

                        UniqueId = long.Parse(XmlLoginTicketResponse.SelectSingleNode("//uniqueId").InnerText);

                        var Res = new TicketAcceso();

                        Res.GenerationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//generationTime").InnerText);
                        Res.ExpirationTime = DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//expirationTime").InnerText);
                        Res.Sign = XmlLoginTicketResponse.SelectSingleNode("//sign").InnerText;
                        Res.Token = XmlLoginTicketResponse.SelectSingleNode("//token").InnerText;

                        return Res;
                }

                /// <summary>
                /// Genera un TRA (Ticket de Requerimiento de Acceso).
                /// </summary>
                /// <returns>Un documento XML conteniendo el TRA.</returns>
                protected XmlDocument ObtenerTra()
                {
                        string XmlStrLoginTicketRequestTemplate = "<loginTicketRequest><header><uniqueId></uniqueId><generationTime></generationTime><expirationTime></expirationTime></header><service></service></loginTicketRequest>";

                        XmlNode XmlNodoUniqueId;
                        XmlNode XmlNodoGenerationTime;
                        XmlNode XmlNodoExpirationTime;
                        XmlNode XmlNodoService;

                        XmlDocument XmlLoginTicketRequest = new XmlDocument();
                        XmlLoginTicketRequest.LoadXml(XmlStrLoginTicketRequestTemplate);

                        XmlNodoUniqueId = XmlLoginTicketRequest.SelectSingleNode("//uniqueId");
                        XmlNodoGenerationTime = XmlLoginTicketRequest.SelectSingleNode("//generationTime");
                        XmlNodoExpirationTime = XmlLoginTicketRequest.SelectSingleNode("//expirationTime");
                        XmlNodoService = XmlLoginTicketRequest.SelectSingleNode("//service");

                        XmlNodoGenerationTime.InnerText = DateTime.Now.AddMinutes(-10).ToString("s");
                        XmlNodoExpirationTime.InnerText = DateTime.Now.AddMinutes(+10).ToString("s");
                        XmlNodoUniqueId.InnerText = Convert.ToString(UniqueId++);
                        XmlNodoService.InnerText = this.Servicio;

                        return XmlLoginTicketRequest;
                }
        }
}
