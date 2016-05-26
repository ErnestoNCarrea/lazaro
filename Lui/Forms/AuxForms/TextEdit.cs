using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lui.Forms.AuxForms
{
	public partial class TextEdit : Lui.Forms.DialogForm
	{
                public TextEdit()
                {
                        InitializeComponent();
                        EntradaTexto.MenuItemEditor.Visible = false;
                }


		public string EditText
		{
			get
			{
				return EntradaTexto.Text;
			}
			set
			{
				EntradaTexto.Text = value;
			}
		}


                public bool ReadOnly
                {
                        get
                        {
                                return EntradaTexto.TemporaryReadOnly;
                        }
                        set
                        {
                                EntradaTexto.TemporaryReadOnly = value;
                                this.OkButton.Visible = !value;
                        }
                }
	}
}