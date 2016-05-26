using System;
using System.Collections.Generic;
using System.Text;

namespace Lazaro.Pres.Spreadsheet
{
        public class Formula
        {
                public string Text;

                public Formula(string text)
                {
                        this.Text = text;
                }

                public override string ToString()
                {
                        return Text;
                }
        }
}
