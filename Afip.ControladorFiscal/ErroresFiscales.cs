using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afip.ControladorFiscal
{
        /// <summary>
        /// Códigos de error del controlador fiscal.
        /// </summary>
        public enum ErroresFiscales
        {
                Ok = 0,
                Error = 1,
                ErrorImpresora = 2,
                ErrorFiscal = 3,
                TimeOut = 10,
                NAK = 11,
                ErrorBCC = 12,
                ErrorComunicacion,
        }
}
