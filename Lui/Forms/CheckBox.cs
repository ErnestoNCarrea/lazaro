using System;
using System.Collections.Generic;

namespace Lui.Forms
{
        public class CheckBox : System.Windows.Forms.CheckBox
        {
                protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
                {
                        if (e.Alt == false && e.Control == false) {
                                switch (e.KeyCode) {
                                        case System.Windows.Forms.Keys.Up:
                                                e.Handled = true;
                                                System.Windows.Forms.SendKeys.Send("+{tab}");
                                                break;

                                        case System.Windows.Forms.Keys.Down:
                                        case System.Windows.Forms.Keys.Return:
                                                e.Handled = true;
                                                System.Windows.Forms.SendKeys.Send("{tab}");
                                                break;
                                }
                        }
                        base.OnKeyDown(e);
                }
        }
}
