using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lazaro.Pres.DisplayStyles
{
        public class Brown : DarkColors
        {
                public override Color BackgroundColor
                {
                        get
                        {
                                return System.Drawing.Color.SaddleBrown;
                        }
                }


                public override Color DarkColor
                {
                        get
                        {
                                return System.Drawing.Color.Brown;
                        }
                }


                public override Color LightColor
                {
                        get
                        {
                                return System.Drawing.Color.Sienna;
                        }
                }
        }
}