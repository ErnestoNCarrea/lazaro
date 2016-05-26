using System;
using System.Collections.Generic;
using System.Text;

namespace Lui.Printing
{
	public class Services
	{
		public static Lfx.Types.OperationResult ShowManualFeedDialog(string printerName, string documentName)
		{
                        Lui.Printing.ManualFeedDialog OFormFacturaCargaManual = new Lui.Printing.ManualFeedDialog();
			OFormFacturaCargaManual.DocumentName = documentName;

			// Muestro el nombre de la impresora
                        if (printerName != null && printerName.Length > 0) {
                                OFormFacturaCargaManual.PrinterName = printerName;
                        } else {
                                System.Drawing.Printing.PrinterSettings CurrentSettings = new System.Drawing.Printing.PrinterSettings();
                                OFormFacturaCargaManual.PrinterName = CurrentSettings.PrinterName;
                        }

			if (OFormFacturaCargaManual.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
				return new Lfx.Types.FailureOperationResult("Operación cancelada");
			else
				return new Lfx.Types.SuccessOperationResult();
		}
	}
}