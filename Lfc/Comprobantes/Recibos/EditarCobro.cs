using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Recibos
{
	public partial class EditarCobro : Lui.Forms.DialogForm
	{
                public EditarCobro()
                {
                        InitializeComponent();
                }

		public override Lfx.Types.OperationResult Ok()
		{
                        return Cobro.ValidateData();
		}
	}
}