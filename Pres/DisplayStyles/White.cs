using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lazaro.Pres.DisplayStyles
{
        public class White : LightColors
        {
                public override Color BackgroundColor
                {
                        get
                        {
                                return Color.White;
                        }
                }


                public override Color LightColor
                {
                        get
                        {
                                return Color.WhiteSmoke;
                        }
                }


                public override Color DarkColor
                {
                        get
                        {
                                return Color.FromArgb(219, 211, 189);
                        }
                }


                public override Color DataAreaColor
                {
                        get
                        {
                                return Color.White;
                        }
                }


                public override Color TextColor
                {
                        get
                        {
                                return Color.Black;
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
                                //return Color.LightSteelBlue;
                                return Color.FromArgb(206, 210, 192);
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