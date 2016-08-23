using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afip.Ws.FacturaElectronica
{
        public class ColeccionImportesAlicuotas : List<ImporteAlicuota>
        {
                /// <summary>
                /// Devuelve el total neto gravado (base imponible) de la colección.
                /// </summary>
                public decimal ImporteNetoGravado()
                {
                        decimal Res = 0;

                        foreach (ImporteAlicuota Alic in this) {
                                Res += Alic.BaseImponible;
                        }

                        return Res;
                }

                /// <summary>
                /// Devuelve el total de IVA de la colección.
                /// </summary>
                public decimal ImporteIva()
                {
                        decimal Res = 0;

                        foreach(ImporteAlicuota Alic in this) {
                                Res += Alic.Importe;
                        }

                        return Res;
                }
        }
}
