using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Servicios.Importar
{
        public class Reemplazo
        {
                public object Buscar, ReemplazarCon;
                public bool MatchSubString = false;
                public string NombreCampo = null;
                public Lfx.Data.DbTypes Tipo = Lfx.Data.DbTypes.VarChar;

                public Reemplazo(object buscar, object reemplazarCon)
                {
                        this.Buscar = buscar;
                        this.ReemplazarCon = reemplazarCon;

                        if(buscar is int)
                                this.Tipo = Lfx.Data.DbTypes.Integer;
                        else if (buscar is double || buscar is decimal)
                                this.Tipo = Lfx.Data.DbTypes.Numeric;
                        else if (buscar is DateTime)
                                this.Tipo = Lfx.Data.DbTypes.DateTime;
                }

                public Reemplazo(object buscar, object reemplazarCon, string nombreCampo)
                        : this(buscar, reemplazarCon)
                {
                        this.NombreCampo = nombreCampo;
                }

                public object Reemplazar(object value)
                {
                        if (this.MatchSubString == false) {
                                // Reemplazo de valores completos
                                if (Lfx.Types.Object.CompareByValue(value, this.Buscar) == 0)
                                        return this.ReemplazarCon;
                                else
                                        return value;
                        } else {
                                // Reemplazo de subcadenas
                                return ((string)value).Replace(((string)(this.Buscar)), ((string)(this.ReemplazarCon)));
                        }
                }
        }

        public class ReemplazoSubCadenas : Reemplazo
        {
                public ReemplazoSubCadenas(string buscar, string reemplazarCon)
                        : base(buscar, reemplazarCon)
                {
                        this.MatchSubString = true;
                }
        }
}
