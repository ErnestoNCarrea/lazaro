using System;

namespace Lui.Forms
{
	public enum TextCasing
	{
		None = 0,
		UpperCase = 1,
		LowerCase = 2,
                /// <summary>
                /// Poner la primera letras de cada palabra en mayúsculas, salvo artículos y otras excepciones.
                /// </summary>
		Caption = 3,
                /// <summary>
                /// Poner mayúsculas y minúsculas apropiadamente sólo si se escribió todo en mayúsculas o todo en minúsuclas.
                /// Si el usuario usó mayúsculas y minúsculas mezcladas, las respetamos.
                /// </summary>
                Automatic
	}

	public enum DataTypes
	{
		FreeText = 0,
		Integer,
		Float,
		Currency,
                Stock,
		Date,
		DateTime
	}

	public enum ImagePositions
	{
		Top = 0,
		Middle = 1
	}
	public enum SubLabelPositions
	{
		None = 0,
		Bottom = 1,
		Right = 2,
		LongBottom = 3
	}
	
	/// <summary>
	/// Miembros estáticos necesarios para el funcionamiento de los controles.
	/// </summary>
	internal static class PopUps
	{
		internal static DataSetHelp FormDataSetHelp;
	}
}
