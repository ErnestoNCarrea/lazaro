using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Types
{
        // FIXME: deprecated
	public static class Ini
	{
		public static string GetSection(string sIni, string sSectionName)
		{
			if(sIni == null)
				return null;

			int r = sIni.IndexOf("[" + sSectionName + "]") + 1;

			if(r > 0) {
				string Resultado = null;
				Resultado = sIni.Substring(r + sSectionName.Length + 1, sIni.Length - (r + sSectionName.Length + 1));
				r = Resultado.IndexOf("[") + 1;

				if(r > 0)
					Resultado = Resultado.Substring(0, r - 1);

				return Resultado;
			}

			return null;
		}

		public static string ReadString(string sIni, string sSectionName, string sClave)
		{
			return ReadString(sIni, sSectionName, sClave, "");
		}

		public static string ReadString(string sIni, string sSectionName, string sClave, string sDefault)
		{
			if(sIni == null)
				return null;

			string sSeccion = null;

			if(sSectionName.Length > 0)
				sSeccion = System.Environment.NewLine + GetSection(sIni, sSectionName) + System.Environment.NewLine;
			else
				sSeccion = sIni;

			int r = sSeccion.ToLower().IndexOf(System.Environment.NewLine + sClave.ToLower() + "=") + 1;

			if(r > 0) {
				string Resultado = sSeccion.Substring(r + System.Environment.NewLine.Length + sClave.Length,
					sSeccion.Length
					- (r + System.Environment.NewLine.Length + sClave.Length + 1));
				r = Resultado.IndexOf(System.Environment.NewLine) + 1;

				if(r > 0)
					Resultado = Resultado.Substring(0, r - 1);

				return Resultado;
			} else {
				return sDefault;
			}
		}

		public static int ReadInt(string sIni, string sSectionName, string sClave)
		{
			return ReadInt(sIni, sSectionName, sClave, 0);
		}

		public static int ReadInt(string sIni, string sSectionName, string sClave, int iDefault)
		{
			return Lfx.Types.Parsing.ParseInt(ReadString(sIni, sSectionName, sClave, iDefault.ToString()));
		}

		public static System.Drawing.Rectangle ReadRectangle(string sIni, string sSectionName, string sClave, System.Drawing.Rectangle rDefault)
		{
			System.Drawing.Rectangle readRectangleReturn = new System.Drawing.Rectangle();
			string Cadena = null;
                        IList<string> ColXY = null;
                        IList<string> ColHW = null;

			Cadena = ReadString(sIni, sSectionName, sClave, "");

			if(Cadena != null && Cadena.Length > 0) {
				ColXY = Lfx.Types.Strings.SplitDelimitedString(Cadena, ",");

				if(System.Convert.ToString(ColXY[0]).IndexOf("-") != -1) {
					ColHW = Lfx.Types.Strings.SplitDelimitedString(System.Convert.ToString(ColXY[0]), "-");
					readRectangleReturn.X = System.Convert.ToInt32(ColHW[0]);
					readRectangleReturn.Width = System.Convert.ToInt32(ColHW[1]) - readRectangleReturn.X;
				} else {
					readRectangleReturn.X = System.Convert.ToInt32(ColXY[0]);
					readRectangleReturn.Width = 0;
				}

				if(System.Convert.ToString(ColXY[1]).IndexOf("-") != -1) {
					ColHW = Lfx.Types.Strings.SplitDelimitedString(System.Convert.ToString(ColXY[1]), "-");
					readRectangleReturn.Y = System.Convert.ToInt32(ColHW[0]);
					readRectangleReturn.Height = System.Convert.ToInt32(ColHW[1]) - readRectangleReturn.Y;
				} else {
					readRectangleReturn.Y = System.Convert.ToInt32(ColXY[1]);
					readRectangleReturn.Height = 0;
				}
			} else {
				readRectangleReturn = rDefault;
			}

			return readRectangleReturn;
		}

		public static Dictionary<string, string> SectionToCollection(string seccion)
		{
			string Seccion = seccion;
                        Dictionary<string, string> Res = new Dictionary<string, string>();

			while(Seccion.Length > 0) {
				string Linea = Lfx.Types.Strings.GetNextToken(ref Seccion, System.Environment.NewLine);

				if(Linea.Length > 0) {
					string Clave = Lfx.Types.Strings.GetNextToken(ref Linea, "=");
					Res.Add(Clave, Linea);
				}
			}

			return Res;
		}

		public static string CollectionToSection(System.Collections.Hashtable c)
		{
			string sResult = null;

			foreach(System.Collections.DictionaryEntry itm in c) {
				sResult += System.Convert.ToString(itm.Key) + "=" + System.Convert.ToString(itm.Value).Replace(System.Environment.NewLine, @"\n") + System.Environment.NewLine;
			}

			return sResult;
		}
	}
}
