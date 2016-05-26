using System;

namespace Lfx.Types
{
	/// <summary>
	/// Clases referentes al manejo de tipos.
	/// </summary>
	public static class ControlChars
	{
		public const char Lf = '\n';
		public const char Cr = '\r';
		public const string CrLf = "\r\n";
		public const char Tab = (char)9;
		public const char Space = ' ';
		public const char Escape = (char)27;
	}


        public static class ControlCodes
        {
                public static int Luhn(string cardNumber)
                {
                        string FixedCardNumber = "";
                        for (int i = 0; i < cardNumber.Length; i++) {
                                if (char.IsDigit(cardNumber, i))
                                        FixedCardNumber += cardNumber[i];
                        }

                        FixedCardNumber = FixedCardNumber.PadLeft(16, '0');

                        int multiplier, digit, sum, total = 0;
                        for (int i = 1; i <= 15; i++) {
                                multiplier = 1 + (i % 2);
                                digit = int.Parse(FixedCardNumber.Substring(i - 1, 1));
                                sum = digit * multiplier;
                                if (sum > 9)
                                        sum -= 9;
                                total += sum;
                        }
                        int Res = 10 - (total % 10);
                        if (Res == 10)
                                return 0;
                        else
                                return Res;
                }

                public static int Modulus10(string digitos)
                {
                        int Sumatoria = 0;
                        int Multiplicador = 2;

                        for (int i = digitos.Length - 1; i >= 0; i--) {
                                int Digitos = Lfx.Types.Parsing.ParseInt(digitos.Substring(i, 1)) * Multiplicador;
                                string DigitosCadena = Digitos.ToString();
                                int SumaDigitos = 0;
                                for (int j = 0; j < DigitosCadena.Length; j++) {
                                        SumaDigitos += Lfx.Types.Parsing.ParseInt(DigitosCadena.Substring(j, 1));
                                }
                                Sumatoria += SumaDigitos;
                                Multiplicador = Multiplicador == 1 ? 2 : 1;
                        }

                        int Modulo = Sumatoria % 10;
                        if (Modulo == 0)
                                return 0;
                        else
                                return 10 - Modulo;
                }
        }
}