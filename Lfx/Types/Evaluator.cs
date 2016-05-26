using System;
using System.Globalization;

namespace Lfx.Types
{
	public static class Evaluator
	{
                public static decimal EvaluateDecimal(string evalString)
                {
                        try {
                                return decimal.Parse(Evaluate(evalString), System.Globalization.CultureInfo.InvariantCulture);
                        } catch {
                                return 0;
                        }
                }


		public static string Evaluate(string evalString)
		{
			string Expresion = evalString.Replace(" ", "").Replace(new string((char)13, 1), "").Replace(new string((char)10, 1), "").Replace(new string((char)9, 1), "").Replace(",", "");

			if (Expresion.Replace("(", "").Length != Expresion.Replace(")", "").Length)
				return "Falta abrir o cerrar paréntesis";

			do
			{
				int AbreParentesis = Expresion.IndexOf("(");

				if (AbreParentesis >= 0)
				{
					// Tiene paréntesis. La descompongo
					int ParentesisAbiertos = 1;

					for (int i = AbreParentesis + 1; i <= Expresion.Length - 1; i++)
					{
						switch (Expresion[i])
						{
							case '(':
								ParentesisAbiertos++;
								break;

							case ')':
								ParentesisAbiertos--;
								break;
						}

						if (ParentesisAbiertos == 0)
						{
							string SubExpresion = Expresion.Substring(AbreParentesis + 1, i - AbreParentesis - 1);
							Expresion = Expresion.Substring(0, AbreParentesis) + Evaluate(SubExpresion) + Expresion.Substring(i + 1, Expresion.Length - i - 1);
							break;
						}
					}
				}
				else
				{
					// No tiene parntesis. La evaluo
					int PosOperador = Expresion.IndexOf('+');

					if (PosOperador < 0)
					{
						PosOperador = Expresion.IndexOf('-');

						while (PosOperador >= 0)
						{
							// Detecto el - unario
							if (PosOperador == 0)
							{
								// Es unario, porque es el primer caracter de la expresin
								PosOperador = Expresion.IndexOf('-', PosOperador + 1);
							}
							else if (char.IsNumber(Expresion[PosOperador - 1]) == false)
							{
								// Es unario, porque el caracter antes no es un dgito 
								PosOperador = Expresion.IndexOf('-', PosOperador + 1);
							}
							else
							{
								// No es unario. Dejo de lupear
								break;
							}
						}
					}

					if (PosOperador < 0)
						PosOperador = Expresion.IndexOf('*');

					if (PosOperador < 0)
						PosOperador = Expresion.IndexOf('/');

					if (PosOperador < 0)
					{
						// Es un número
						return decimal.Parse(Expresion, NumberStyles.Float, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
					}
					else
					{
						// Es una expresin simple
						string Parte1 = Expresion.Substring(0, PosOperador);
						string Parte2 = Expresion.Substring(PosOperador + 1, Expresion.Length - PosOperador - 1);

						switch (Expresion[PosOperador])
						{
							case '+':
                                                                return (decimal.Parse(Evaluate(Parte1), NumberStyles.Float, CultureInfo.InvariantCulture) + decimal.Parse(Evaluate(Parte2), NumberStyles.Float, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);
							case '-':
                                                                return (decimal.Parse(Evaluate(Parte1), NumberStyles.Float, CultureInfo.InvariantCulture) - decimal.Parse(Evaluate(Parte2), NumberStyles.Float, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);
							case '*':
                                                                return (decimal.Parse(Evaluate(Parte1), NumberStyles.Float, CultureInfo.InvariantCulture) * decimal.Parse(Evaluate(Parte2), NumberStyles.Float, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);
							case '/':
                                                                return (decimal.Parse(Evaluate(Parte1), NumberStyles.Float, CultureInfo.InvariantCulture) / decimal.Parse(Evaluate(Parte2), NumberStyles.Float, CultureInfo.InvariantCulture)).ToString(CultureInfo.InvariantCulture);
						}
					}
				}
			} while (true);
		}
	}
}