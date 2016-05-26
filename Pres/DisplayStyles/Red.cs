using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lazaro.Pres.DisplayStyles
{
        public class Red : DarkColors
        {
                public override Color BackgroundColor
                {
                        get
                        {
                                return System.Drawing.Color.Firebrick;
                        }
                }


                public override Color DarkColor
                {
                        get
                        {
                                return System.Drawing.Color.DarkRed;
                        }
                }


                public override Color LightColor
                {
                        get
                        {
                                return System.Drawing.Color.IndianRed;
                        }
                }
        }
}