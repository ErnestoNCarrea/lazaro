using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lfx.Types
{
	public static class Strings
	{
		public static IList<string> SplitDelimitedString(string text)
		{
			return SplitDelimitedString(text, ",", "\"");
		}

                public static IList<string> SplitDelimitedString(string text, string delimiter)
		{
                        return SplitDelimitedString(text, delimiter, "\"");
		}

                public static IList<string> SplitDelimitedString(string text, string delimiter, string qualifier)
		{
                        if (text == null || text == string.Empty)
                                return new List<string>();

                        string Statement = String.Format("{0}(?=(?:[^{1}]*{1}[^{1}]*{1})*(?![^{1}]*{1}))", Regex.Escape(delimiter), Regex.Escape(qualifier));
                        Regex Expression = new Regex(Statement, RegexOptions.Compiled | RegexOptions.Multiline);
                        return Expression.Split(text);
		}

		public static string GetNextToken(ref string stringValue)
		{
			return GetNextToken(ref stringValue, ",");
		}

		public static string GetNextToken(ref string stringValue, string stringSeparator)
		{
			if(stringValue == null)
				return null;
			string getNextTokenReturn = null;
			int r = 0;
			r = stringValue.IndexOf(stringSeparator) + 1;

			if(r > 0) {
				getNextTokenReturn = stringValue.Substring(0, r - 1);
				int LongResto = stringValue.Length - r - (stringSeparator.Length - 1);
				stringValue = stringValue.Substring(stringValue.Length - LongResto, LongResto);
			} else {
				getNextTokenReturn = stringValue;
				stringValue = "";
			}

			return getNextTokenReturn;
		}


		public static bool ValueInCsv(string csv, string strVal, string separador)
		{
			bool valueInCSVReturn = false;
			// Devuelve Verdadero si el valor sValue se encuentra dentro de la lista sCSV
			valueInCSVReturn = (separador + csv + separador).Replace(" ", "").IndexOf(separador + strVal + separador) != -1;
			return valueInCSVReturn;
		}

		public static string SHA256(string text)
		{
			System.Security.Cryptography.SHA256 Proveedor = new System.Security.Cryptography.SHA256Managed();
			byte[] HashBinario = Proveedor.ComputeHash(System.Text.Encoding.Default.GetBytes(text));
                        System.Text.StringBuilder HashTexto = new System.Text.StringBuilder();
                        foreach (byte b in HashBinario) {
                                HashTexto.Append(b.ToString("x2").ToLower());
                        }
			return HashTexto.ToString();
		}


		public static void WriteTextFile(string fileName, string content)
		{
			System.IO.BinaryWriter wr = new System.IO.BinaryWriter(new System.IO.FileStream(fileName, System.IO.FileMode.OpenOrCreate));
			wr.Write(System.Text.Encoding.Default.GetBytes(content));
			wr.Close();
		}


		public static string ReadTextFile(string sFileName)
		{
			string readTextFileReturn = null;
			System.IO.FileStream Archivo = new System.IO.FileStream(sFileName, System.IO.FileMode.OpenOrCreate);
			System.IO.StreamReader Lector = new System.IO.StreamReader(Archivo, System.Text.Encoding.Default);
			readTextFileReturn = Lector.ReadToEnd();
			Lector.Close();
			Archivo.Close();
			return readTextFileReturn;
		}

                public static bool Like(string text, string patterns)
                {
                        if (patterns == null)
                                return false;

                        string[] Patterns = patterns.Split(new string[] { ";", System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string Pattern in Patterns) {
                                string RegExSafePattern = System.Text.RegularExpressions.Regex.Escape(Pattern);
                                string FinalRegExPattern = RegExSafePattern.Replace(@"\*", ".+").Replace(@"\?", ".");
                                System.Text.RegularExpressions.Regex RegExPattern = new System.Text.RegularExpressions.Regex("^" + FinalRegExPattern + "$");
                                if (RegExPattern.IsMatch(text))
                                        return true;
                        }
                        return false;
                }


                public static string EscapeHtml(string text)
                {
                        return System.Security.SecurityElement.Escape(text);
                        //es lo mismo que return text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
                }

                public static string EscapeXml(string text)
                {
                        return System.Security.SecurityElement.Escape(text);
                        //es lo mismo que return text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
                }
	}
}
