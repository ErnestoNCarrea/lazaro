using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lui.Forms
{
        public partial class Bracket : UserControl, IControl
        {
                public Bracket()
                {
                        InitializeComponent();
                }

                public int MarkerPosition
                {
                        get
                        {
                                return label2.Top;
                        }
                        set
                        {
                                label2.Top = value;
                        }
                }
        }
}
