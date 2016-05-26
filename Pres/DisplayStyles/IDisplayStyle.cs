using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lazaro.Pres.DisplayStyles
{
        public interface IDisplayStyle
        {
                Color BackgroundColor { get; }
                Color LightColor { get; }
                Color DarkColor { get; }
                Color TextColor { get; }
                Color GrayTextColor { get; }
                Color BorderColor { get; }
                Color ActiveBorderColor { get; }
                Color DataAreaColor { get; }
                Color DataAreaTextColor { get; }
                Color DataAreaGrayTextColor { get; }
                Color SelectionColor { get; }

                Bitmap Icon { get; }
        }
}
