using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lazaro.Pres.DisplayStyles
{
        public class Green : DarkColors
        {
                public override Color BackgroundColor
                {
                        get
                        {
                                return System.Drawing.Color.SeaGreen;
                        }
                }


                public override Color DarkColor
                {
                        get
                        {
                                return System.Drawing.Color.Green;
                        }
                }

                public override Color LightColor
                {
                        get
                        {
                                return System.Drawing.Color.MediumSeaGreen;
                        }
                }
        }
}
