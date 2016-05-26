using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lui.Forms
{
	public partial class Note : Control
	{
		public Note()
		{
			InitializeComponent();
		}

		public string Title
		{
			get
			{
				return LabelTitle.Text;
			}
			set
			{
				LabelTitle.Text = value;
			}
		}

		public override string Text
		{
			get
			{
				return LabelText.Text;
			}
			set
			{
				LabelText.Text = value;
			}
		}
	}
}
