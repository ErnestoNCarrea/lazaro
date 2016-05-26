namespace Lbl.Bancos.Claves
{
        /// <summary>
        /// Clave Bancaria Uniforme (Argentina)
        /// http://www.clientebancario.gov.ar/default.asp
        /// </summary>
        public class Cbu : IdentificadorUnico
        {
                public override string Nombre
                {
                        get
                        {
                                return "CBU";
                        }
                }


                public static bool EsValido(string cbu)
                {
                        string MiCopia = cbu.Replace("-", "").Replace(" ", "").Replace(".", "").Replace("/", "");
                        if (MiCopia.Length != 22)
                                return false;

                        int[] Ponderador = { 3, 9, 7, 1 };
                        //int[] Ponderador = { 7, 1, 3, 9 };
                        int Verificador;

                        Verificador = 0;
                        string Bloque1 = MiCopia.Substring(0, 8);
                        for (int i = 0; i < 7; i++) {
                                Verificador += Lfx.Types.Parsing.ParseInt(Bloque1.Substring(i, 1)) * Ponderador[i % 4] ;
                        }
                        Verificador = (Verificador % 10) % 10;
                        if (Lfx.Types.Parsing.ParseInt(Bloque1.Substring(7, 1)) != Verificador)
                                return false;

                        Verificador = 0;
                        string Bloque2 = MiCopia.Substring(8, 14);
                        for (int i = 0; i < 13; i++) {
                                Verificador += Lfx.Types.Parsing.ParseInt(Bloque2.Substring(i, 1)) * Ponderador[i % 4];
                        }
                        Verificador = (10 - (Verificador % 10)) % 10;
                        if (Lfx.Types.Parsing.ParseInt(Bloque2.Substring(13, 1)) != Verificador)
                                return false;

                        return true;
                }

                public override bool EsValido()
                {
                        return Lbl.Bancos.Claves.Cbu.EsValido(this.Valor);
                }
        }
}
