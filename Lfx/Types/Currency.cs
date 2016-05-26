using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Types
{
	public static class Currency
	{
                public static decimal Truncate(decimal number, int decimals)
		{
			long Expo = System.Convert.ToInt64(Math.Pow(10, decimals));
			return Math.Truncate(number * Expo) / Expo;
		}
	}
}
