using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lui.Printing
{
        public partial class ManualFeedDialog : Lui.Forms.DialogForm
        {
                public ManualFeedDialog()
                {
                        InitializeComponent();
                }

                public string DocumentName
                {
                        get
                        {
                                return txtDocumento.Text;
                        }
                        set
                        {
                                txtDocumento.Text = value;
                        }
                }

                public string PrinterName
                {
                        get
                        {
                                return txtImpresora.Text;
                        }
                        set
                        {
                                txtImpresora.Text = value;
                        }
                }
        }
}