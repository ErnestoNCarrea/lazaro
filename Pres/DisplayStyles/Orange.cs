using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lazaro.Pres.DisplayStyles
{
        public class Orange : DarkColors
        {
                public override Color BackgroundColor
                {
                        get
                        {
                                return System.Drawing.Color.OrangeRed;
                        }
                }

                public override Color LightColor
                {
                        get
                        {
                                return System.Drawing.Color.DarkOrange;
                        }
                }

                public override Color DarkColor
                {
                        get
                        {
                                return System.Drawing.Color.FromArgb(183, 48, 0);
                        }
                }
        }
}
