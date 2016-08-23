using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afip.Ws.FacturaElectronica
{
        /// <summary>
        /// Un cliente que se puede asociar a un comprobante.
        /// </summary>
        public class Cliente
        {
                /// <summary>
                /// El tipo de documento que identifica al cliente.
                /// </summary>
                public Tablas.DocumentoTipos DocumentoTipo { get; set; }

                /// <summary>
                /// El número de documento del cliente.
                /// </summary>
                public long DocumentoNumero { get; set; }
        }
}
