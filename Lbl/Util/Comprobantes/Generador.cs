using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazaro.Base.Util.Comprobantes
{
        /// <summary>
        /// Un generador de comprobantes oficiales, que a partir de un borrador (por ejemplo
        /// una factura guardada pero sin imprimir), genera un comprobante oficial.
        /// 
        /// Normalmente va a generar un comprobante de una de tres formas:
        ///     1. Asignarle un número e imprimirlo en papel.
        ///     2. Utilizar un controlador fiscal homologado.
        ///     3. En forma electrónica, a través de internet (servicios web de AFIP).
        /// </summary>
        public abstract class Generador : IGenerador
        {
                public Lbl.Comprobantes.Comprobante Comprobante { get; set; }

                public Generador(Lbl.Comprobantes.Comprobante comprobante)
                {
                        this.Comprobante = comprobante;
                }
        }
}
