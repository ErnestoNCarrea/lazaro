using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lazaro.Pres.DisplayStyles
{
        public class OldStyle : LightColors
        {
                public override Color BackgroundColor
                {
                        get
                        {
                                return Color.FromArgb(236, 234, 229);
                        }
                }

                public override Color LightColor
                {
                        get
                        {
                                return Color.White; //.FromArgb(242, 241, 237);
                        }
                }

                public override Color DarkColor
                {
                        get
                        {
                                return Color.FromArgb(219, 211, 189);
                        }
                }

                public override Color TextColor
                {
                        get
                        {
                                return System.Drawing.SystemColors.ControlText;
                        }
                }


                public override Color SelectionColor
                {
                        get
                        {
                                return System.Drawing.Color.DarkOrange;
                        }
                }

                public override Color BorderColor
                {
                        get
                        {
                                return Color.Transparent;
                        }
                }

                public override Color ActiveBorderColor
                {
                        get
                        {
                                return Color.DarkOrange;
                        }
                }
        }
}