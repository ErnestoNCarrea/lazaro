using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Recibos
{
        public partial class EditarPago : Lui.Forms.DialogForm
        {
                public EditarPago()
                {
                        InitializeComponent();
                }

                public override Lfx.Types.OperationResult Ok()
                {
                        return Pago.ValidateData();
                }
        }
}