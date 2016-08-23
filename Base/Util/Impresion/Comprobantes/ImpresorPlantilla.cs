using System;
using System.Collections.Generic;
using System.Data;

namespace Lazaro.Base.Util.Impresion.Comprobantes
{
        public class ImpresorPlantilla : ImpresorElemento
        {
                public ImpresorPlantilla(Lbl.ElementoDeDatos elemento, IDbTransaction transaction)
			: base(elemento, transaction)
		{
		}

                protected override Lbl.Impresion.Plantilla ObtenerPlantilla()
                {
                        return this.Elemento as Lbl.Impresion.Plantilla;
                }

                public override string ObtenerValorCampo(string nombreCampo, string formato)
                {
                        return nombreCampo;
                }
        }
}
