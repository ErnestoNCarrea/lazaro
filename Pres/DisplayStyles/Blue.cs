using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lazaro.Pres.DisplayStyles
{
        public class Blue : DarkColors
        {
                public override Color BackgroundColor
                {
                        get
                        {
                                return System.Drawing.Color.SteelBlue;
                        }
                }

                public override Color LightColor
                {
                        get
                        {
                                return System.Drawing.Color.CornflowerBlue;
                        }
                }

                public override Color DarkColor
                {
                        get
                        {
                                return System.Drawing.Color.MidnightBlue;
                        }
                }


                public override Color DataAreaColor
                {
                        get
                        {
                                return System.Drawing.Color.LightSteelBlue;
                        }
                }
        }
}
