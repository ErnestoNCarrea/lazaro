using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lui.Forms
{
	public partial class DialogForm : Lui.Forms.Form
	{
                public DialogForm()
                {
                        this.DisplayStyle = Lazaro.Pres.DisplayStyles.Template.Current.White;
                        InitializeComponent();
                }

		public virtual Lfx.Types.OperationResult Ok()
		{
			return new Lfx.Types.SuccessOperationResult();
		}

                public virtual DialogResult Cancel()
                {
                        return DialogResult.Cancel;
                }

                private void CancelCommandButton_Click(object sender, System.EventArgs e)
		{
                        this.DialogResult = Cancel();
			this.Close();
		}

                private void OkButton_Click(object sender, System.EventArgs e)
		{
			Lfx.Types.OperationResult res = Ok();

			if (res.Success == true) {
				this.DialogResult = DialogResult.OK;
				this.Close();
			} else if (res.Message != null) {
                                Lui.Forms.MessageBox.Show(res.Message, "Aviso");
                        }
		}


		private void DialogForm_SizeChanged(object sender, System.EventArgs e)
		{
			CancelCommandButton.Left = LowerPanel.Width - CancelCommandButton.Width - 4;
			OkButton.Left = CancelCommandButton.Left - OkButton.Width - 4;
		}
	}
}