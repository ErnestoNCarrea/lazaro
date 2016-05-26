using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lazaro.Pres.DisplayStyles
{
        public class Personas : Green
        {
                public override Bitmap Icon
                {
                        get
                        {
                                return (Bitmap)(global::Lazaro.Pres.Properties.Resources.ResourceManager.GetObject("persona"));
                        }
                }
        }
}
