namespace Lbl.Personas.Claves
{
        /// <summary>
        /// Clave Única de Identificación Tributaria (Argentina)
        /// </summary>
        public class Cuit : IdentificadorUnico
        {
                public Cuit(string valor)
                {
                        string Res = valor;

                        Res = Res.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "").Replace("_", "");

                        if (Res.Length == 11)
                                this.Valor = Res.Substring(0, 2) + "-" + Res.Substring(2, 8) + "-" + Res.Substring(10, 1);
                        else
                                this.Valor = Res;
                }


                public override string Nombre
                {
                        get
                        {
                                return "CUIT";
                        }
                }


                public static bool EsValido(string valor)
                {
                        // Utiliza el digito verificador para determinar la validez de una CUIT
                        // Devuelve Verdadero si la CUIT es válida
                        // Espera la CUIT en formato XX-XXXXXXXX-X
                        if (System.Text.RegularExpressions.Regex.IsMatch(valor, @"^\d{2}-\d{8}-\d{1}$")
                                || System.Text.RegularExpressions.Regex.IsMatch(valor, @"^\d{11}$")) {
                                        string ValorPlano = valor.Replace("-", "");
                                int Suma = 0;
                                Suma += int.Parse(ValorPlano.Substring(0, 1)) * 5;
                                Suma += int.Parse(ValorPlano.Substring(1, 1)) * 4;
                                Suma += int.Parse(ValorPlano.Substring(2, 1)) * 3;
                                Suma += int.Parse(ValorPlano.Substring(3, 1)) * 2;
                                Suma += int.Parse(ValorPlano.Substring(4, 1)) * 7;
                                Suma += int.Parse(ValorPlano.Substring(5, 1)) * 6;
                                Suma += int.Parse(ValorPlano.Substring(6, 1)) * 5;
                                Suma += int.Parse(ValorPlano.Substring(7, 1)) * 4;
                                Suma += int.Parse(ValorPlano.Substring(8, 1)) * 3;
                                Suma += int.Parse(ValorPlano.Substring(9, 1)) * 2;
                                // El digito verificador es 11 menos el mdulo de la suma y 11
                                int Verificador = 11 - (Suma % 11);

                                switch (Verificador) {
                                        case 11:
                                                Verificador = 0;
                                                break;
                                        case 10:
                                                Verificador = 9;
                                                break;
                                }
                                return int.Parse(ValorPlano.Substring(10, 1)) == Verificador;
                        } else {
                                return false;
                        }
                }

                public override bool EsValido()
                {
                        return Lbl.Personas.Claves.Cuit.EsValido(this.Valor);
                }
        }
}
